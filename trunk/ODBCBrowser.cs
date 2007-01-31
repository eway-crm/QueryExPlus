using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.Odbc;
using System.Text;
using System.Windows.Forms;

namespace QueryExPlus
{
    /// <summary>
    /// An implementation of IBrowser
    /// </summary>
    internal class ODBCBrowser : IBrowser
    {
        class ODBCNode : TreeNode
        {
            internal string type = "";
            internal string name, owner, safeName, dragText;
            public ODBCNode(string text) : base(text) { }
        }

        const int timeout = 5;
        DbClient dbClient;

        public ODBCBrowser(DbClient dbClient)
        {
            this.dbClient = dbClient;
        }

        public DbClient DbClient
        {
            get { return dbClient; }
        }

        private DataSet CreateSchemaDataset()
        {
            DataSet schemaDS = new DataSet();
            DataTable schemaTable = schemaDS.Tables.Add("Schema");
            schemaTable.Columns.Add("type", typeof (string));
            schemaTable.Columns.Add("shipped", typeof (string));
            schemaTable.Columns.Add("object", typeof (string));
            schemaTable.Columns.Add("owner", typeof(string));
            return schemaDS;
        }

        public TreeNode[] GetObjectHierarchy()
        {
            TreeNode[] top = new TreeNode[]
			{
				new TreeNode ("User Tables"),
				new TreeNode ("System Tables"),
				new TreeNode ("Views"),
				new TreeNode ("User Stored Procs"),
				new TreeNode ("System Stored Procs"),
				new TreeNode ("Functions")
			};

            DataSet ds = CreateSchemaDataset();
            string[,] schemas = { { "TABLES", "U", "TABLE_SCHEM", "TABLE_NAME" }, { "VIEWS", "V", "TABLE_SCHEM", "TABLE_NAME" }, { "PROCEDURES", "P", "PROCEDURE_SCHEM", "PROCEDURE_NAME" } };
            for (int i = 0; i < 3; i++ )
            {
                AppendSchemas(ds.Tables[0], schemas[i, 0], schemas[i, 1], schemas[i, 2], schemas[i, 3]);
            }

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string type = row["type"].ToString();

                int position;
                if (type == "U") position = 0;										// user table
                else if (type == "S") position = 1;								// system table
                else if (type == "V") position = 2;								// view
                else if (type == "FN") position = 5;								// function
                else position = 3;												// user stored proc

                string prefix = row["owner"].ToString() == "dbo" ? "" : row["owner"].ToString() + ".";
                ODBCNode node = new ODBCNode(prefix + row["object"].ToString());
                node.type = type;
                node.name = row["object"].ToString();
                node.owner = row["owner"].ToString();

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

        private void AppendSchemas(DataTable dt, string schemaName, string schemaType, string SchemaColumnName, string NameColumnName)
        {
			OdbcConnection con = null;
			DataTable tab = null;

            try
            {
                con = ((OdbcConnection) ((OdbcClient) DbClient).Connection);
                tab = con.GetSchema(schemaName); //schema // ie ODBC SchemaGuid.Columns or .Tables
                //                   ,restrictions // ie new object[] {null, null, null, "TABLE"}
                if (tab != null)
                {
                    DataColumn SchemaColumn = tab.Columns[SchemaColumnName];
                    DataColumn NameColumn = tab.Columns[NameColumnName];
                    
                    DataColumn NewTypeColumn = dt.Columns["type"];
                    DataColumn NewObjectColumn = dt.Columns["object"];
                    DataColumn NewOwnerColumn = dt.Columns["owner"]; 
                    foreach (DataRow dr in tab.Rows)
                    {
                        DataRow NewDataRow = dt.NewRow();
                        NewDataRow[NewTypeColumn] = schemaType;
                        NewDataRow[NewOwnerColumn] = (string) dr[SchemaColumn];
                        NewDataRow[NewObjectColumn] = (string) dr[NameColumn];
                        dt.Rows.Add(NewDataRow);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally {
                if (tab != null)
                    tab.Dispose();
            }
        }

        public TreeNode[] GetSubObjectHierarchy(TreeNode node)
        {
            // Show the column breakdown for the selected table
            if (node is ODBCNode)
            {
                string table = node.Text;

                OdbcConnection con = null;
                DataTable tab = null;

                try
                {
                    con = ((OdbcConnection)((OdbcClient)DbClient).Connection);
                    tab = con.GetSchema("Columns", new string[] { null, ((ODBCNode)node).owner, ((ODBCNode)node).name }); //schema // ie ODBC SchemaGuid.Columns or .Tables
                    //                   ,restrictions // ie new object[] {null, null, null, "TABLE"}
                    if (tab != null)
                    {                        
                        DataColumn NameColumn = tab.Columns["COLUMN_NAME"];
                        DataColumn TypeColumn = tab.Columns["DATA_TYPE"];
                        DataColumn NullableColumn = tab.Columns["NULLABLE"];
                        TreeNode[] tn = new ODBCNode[tab.Rows.Count];
                        int count = 0;

                        foreach (DataRow row in tab.Rows)
                        {
                            //string nullable = row[NullableColumn].ToString().StartsWith("Y") ? "null" : "not null";

                            ODBCNode column = new ODBCNode(row[NameColumn].ToString()); // + " ("
                                //+ row[TypeColumn].ToString() + length + ", " + nullable + ")");
                            column.type = "CO";			// column
                            column.dragText = row[NameColumn].ToString();
                            if (column.dragText.IndexOf(' ') >= 0)
                                column.dragText = "[" + column.dragText + "]";
                            column.safeName = column.dragText; 
                            
                            tn[count++] = column;
                        }
                        return tn;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    if (tab != null)
                        tab.Dispose();
                }
            }
            return null;
        }

        public string GetDragText(TreeNode node)
        {
            if (node is ODBCNode)
                return ((ODBCNode)node).dragText;
            else
                return "";
        }

        public StringCollection GetActionList(TreeNode node)
        {
            if (!(node is ODBCNode)) return null;

            ODBCNode sn = (ODBCNode)node;
            StringCollection output = new StringCollection();

            if (sn.type == "U" || sn.type == "S" || sn.type == "V")
            {
                output.Add("select * from " + sn.safeName);
//                output.Add("sp_help " + sn.safeName);
//                if (sn.type != "V")
//                {
//                    output.Add("sp_helpindex " + sn.safeName);
//                    output.Add("sp_helpconstraint " + sn.safeName);
//                    output.Add("sp_helptrigger " + sn.safeName);
//                }
                output.Add("(insert all fields)");
                output.Add("(insert all fields, table prefixed)");
            }

//            if (sn.type == "V" || sn.type == "P" || sn.type == "FN")
//                output.Add("View / Modify " + sn.name);

//            if (sn.type == "CO" && ((ODBCNode)sn.Parent).type == "U")
//                output.Add("Alter column...");

            return output.Count == 0 ? null : output;
        }

        public string GetActionText(TreeNode node, string action)
        {
            if (!(node is ODBCNode)) return null;

            ODBCNode sn = (ODBCNode)node;

            if (action.StartsWith("select * from "))
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
                    string s = (sb.Length == 0 ? "" : ", ") + prefix + ((ODBCNode)subNode).dragText;
                    chars += s.Length;
                    sb.Append(s);
                }
                return sb.Length == 0 ? null : sb.ToString();
            }

            return null;
        }

        public string[] GetDatabases()
        {
            return new string[] {dbClient.Database};
//            // cool, but only supported in SQL Server 2000+
//            DataSet ds = dbClient.ExecuteOnWorker("dbo.sp_MShasdbaccess", timeout);
//            // works in SQL Server 7...
//            if (ds == null || ds.Tables.Count == 0)
//                ds = dbClient.ExecuteOnWorker("select name from master.dbo.sysdatabases order by name", timeout);
//            if (ds == null || ds.Tables.Count == 0) return null;
//            string[] sa = new string[ds.Tables[0].Rows.Count];
//            int count = 0;
//            foreach (DataRow row in ds.Tables[0].Rows)
//                sa[count++] = row[0].ToString().Trim();
//            return sa;
//            return null;
        }

        public IBrowser Clone(DbClient newDbClient)
        {
            ODBCBrowser sb = new ODBCBrowser(newDbClient);
            return sb;
        }
    }
}
