using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace QueryExPlus
{
    /// <summary>
    /// An implementation of IBrowser for MS SQL Server.
    /// </summary>
    internal class SqlBrowser : IBrowser
    {
        class SqlNode : TreeNode
        {
            internal string type = "";
            internal string name, owner, safeName, dragText;
            public SqlNode(string text) : base(text) { }
        }

        const int timeout = 5;
        DbClient dbClient;

        public SqlBrowser(DbClient dbClient)
        {
            this.dbClient = dbClient;
        }

        public DbClient DbClient
        {
            get { return dbClient; }
        }

        public TreeNode[] GetObjectHierarchy()
        {
            TreeNode[] top = new TreeNode[]
			{
				new TreeNode ("User Tables"),
				new TreeNode ("System Tables"),
				new TreeNode ("Views"),
				new TreeNode ("User Stored Procs"),
				new TreeNode ("MS Stored Procs"),
				new TreeNode ("Functions")
			};

            string Query;
            //Query = "select type, ObjectProperty (id, N'IsMSShipped') shipped, object_name(id) object, user_name(uid) owner from sysobjects where type in (N'U', N'S', N'V', N'P', N'FN') order by object, owner";

            Query = "select table_type as type, table_name as object, table_schema as [schema] from INFORMATION_SCHEMA.TABLES"
                    + " UNION"
                    + " select routine_type, routine_name, routine_schema from INFORMATION_SCHEMA.ROUTINES";

            DataSet ds = dbClient.ExecuteOnWorker(Query, timeout);
            if (ds == null || ds.Tables.Count == 0) return null;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string type = row["type"].ToString().Substring(0, 2).Trim();
                int position;
                switch (type)
                {
                    case "BASE_TABLE":
                        type = "U"; position = 0; break;
                    case "VIEW":
                        type = "V"; position = 2; break;
                    case "PROCEDURE":
                        type = "P"; position = 3; break;
                    case "FUNCTION":
                        type = "FN"; position = 5; break;
                    default:
                        type = "S"; position = 1; break;
                }

//                if (type == "U") position = 0;										// user table       - U
//                else if (type == "S") position = 1;								// system table         - S
//                else if (type == "V") position = 2;								// view                 - V
//                else if (type == "FN") position = 5;								// function         - FN
//                else if ((int)row["shipped"] == 0) position = 3;				// user stored proc     
//                else position = 4;														// MS stored proc

                string prefix = row["schema"].ToString(); // == "dbo" ? "" : row["owner"].ToString() + ".";
                SqlNode node = new SqlNode(row["object"].ToString() + " (" + prefix + ")"); // new SqlNode(prefix + row["object"].ToString());
                node.type = type;
                node.name = row["object"].ToString();
                node.owner = row["schema"].ToString();

                // If the object name contains a space, wrap the "safe name" in square brackets.
                if (node.owner.IndexOf(' ') >= 0 || node.name.IndexOf(' ') >= 0)
                {
                    node.safeName = "[" + node.name + "]";
                    node.dragText = "[" + node.owner + "].[" + node.name + "]";
                }
                else
                {
                    node.safeName = node.name;
                    node.dragText = node.owner + "." + node.name;
                }
                top[position].Nodes.Add(node);

                // Add a dummy sub-node to user tables and views so they'll have a clickable expand sign
                // allowing us to have GetSubObjectHierarchy called so the user can view the columns
                if (type == "U" || type == "V") node.Nodes.Add(new TreeNode());
            }
            return top;
        }

        public TreeNode[] GetSubObjectHierarchy(TreeNode node)
        {
            // Show the column breakdown for the selected table
            if (node is SqlNode)
            {
                SqlNode sn = (SqlNode)node;
                if (sn.type == "U" || sn.type == "V")					// break down columns for user tables and views
                {
                    DataSet ds = dbClient.ExecuteOnWorker("select COLUMN_NAME name, DATA_TYPE type, CHARACTER_MAXIMUM_LENGTH clength, NUMERIC_PRECISION nprecision, NUMERIC_SCALE nscale, IS_NULLABLE nullable  from INFORMATION_SCHEMA.COLUMNS where TABLE_CATALOG = db_name() and TABLE_SCHEMA = '"
                        + sn.owner + "' and TABLE_NAME = '" + sn.name + "' order by ORDINAL_POSITION", timeout);
                    if (ds == null || ds.Tables.Count == 0) return null;

                    TreeNode[] tn = new SqlNode[ds.Tables[0].Rows.Count];
                    int count = 0;

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string length;
                        if (row["clength"].ToString() != "")
                            length = "(" + row["clength"].ToString() + ")";
                        else if (row["nprecision"].ToString() != "")
                            length = "(" + row["nprecision"].ToString() + "," + row["nscale"].ToString() + ")";
                        else length = "";

                        string nullable = row["nullable"].ToString().StartsWith("Y") ? "null" : "not null";

                        SqlNode column = new SqlNode(row["name"].ToString() + " ("
                            + row["type"].ToString() + length + ", " + nullable + ")");
                        column.type = "CO";			// column
                        column.dragText = row["name"].ToString();
                        if (column.dragText.IndexOf(' ') >= 0)
                            column.dragText = "[" + column.dragText + "]";
                        column.safeName = column.dragText;
                        tn[count++] = column;
                    }
                    return tn;
                }
            }
            return null;
        }

        public string GetDragText(TreeNode node)
        {
            if (node is SqlNode)
                return ((SqlNode)node).dragText;
            else
                return "";
        }

        public StringCollection GetActionList(TreeNode node)
        {
            if (!(node is SqlNode)) return null;

            SqlNode sn = (SqlNode)node;
            StringCollection output = new StringCollection();

            if (sn.type == "U" || sn.type == "S" || sn.type == "V")
            {
                output.Add("select * from " + sn.safeName);
                output.Add("sp_help " + sn.safeName);
                if (sn.type != "V")
                {
                    output.Add("sp_helpindex " + sn.safeName);
                    output.Add("sp_helpconstraint " + sn.safeName);
                    output.Add("sp_helptrigger " + sn.safeName);
                }
                output.Add("(insert all fields)");
                output.Add("(insert all fields, table prefixed)");
            }

            if (sn.type == "V" || sn.type == "P" || sn.type == "FN")
                output.Add("View / Modify " + sn.name);

            if (sn.type == "CO" && ((SqlNode)sn.Parent).type == "U")
                output.Add("Alter column...");

            return output.Count == 0 ? null : output;
        }

        public string GetActionText(TreeNode node, string action)
        {
            if (!(node is SqlNode)) return null;

            SqlNode sn = (SqlNode)node;

            if (action.StartsWith("select * from ") || action.StartsWith("sp_"))
                return action;

            if (action.StartsWith("(insert all fields"))
            {
                StringBuilder sb = new StringBuilder();
                // If the table-prefixed option has been selected, add the table name to all the fields
                string prefix = action == "(insert all fields)" ? "" : sn.safeName + ".";
                int chars = 0;
                foreach (TreeNode subNode in GetSubObjectHierarchy(node))
                {
                    if (chars > 50)
                    {
                        chars = 0;
                        sb.Append("\r\n");
                    }
                    string s = (sb.Length == 0 ? "" : ", ") + prefix + ((SqlNode)subNode).dragText;
                    chars += s.Length;
                    sb.Append(s);
                }
                return sb.Length == 0 ? null : sb.ToString();
            }

            if (action.StartsWith("View / Modify "))
            {
                DataSet ds = dbClient.ExecuteOnWorker("sp_helptext " + sn.safeName, timeout);
                if (ds == null || ds.Tables.Count == 0) return null;

                StringBuilder sb = new StringBuilder();
                bool altered = false;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string line = row[0].ToString();
                    if (!altered && line.Trim().ToUpper().StartsWith("CREATE"))
                    {
                        sb.Append("ALTER" + line.Trim().Substring(6, line.Trim().Length - 6) + "\r\n");
                        altered = true;
                    }
                    else
                        sb.Append(line);
                }
                return sb.ToString().Trim();
            }

            if (action == "Alter column...")
                return "alter table " + ((SqlNode)sn.Parent).dragText + " alter column " + sn.safeName + " ";

            return null;
        }

        public string[] GetDatabases()
        {
            // cool, but only supported in SQL Server 2000+
            DataSet ds = dbClient.ExecuteOnWorker("dbo.sp_MShasdbaccess", timeout);
            // works in SQL Server 7...
            if (ds == null || ds.Tables.Count == 0)
                ds = dbClient.ExecuteOnWorker("select name from master.dbo.sysdatabases order by name", timeout);
            if (ds == null || ds.Tables.Count == 0) return null;
            string[] sa = new string[ds.Tables[0].Rows.Count];
            int count = 0;
            foreach (DataRow row in ds.Tables[0].Rows)
                sa[count++] = row[0].ToString().Trim();
            return sa;
        }

        public IBrowser Clone(DbClient newDbClient)
        {
            SqlBrowser sb = new SqlBrowser(newDbClient);
            return sb;
        }
    }
}
