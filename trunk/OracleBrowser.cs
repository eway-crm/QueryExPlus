using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace QueryExPlus
{
    /// <summary>
    /// A simple implementation of IBrowser for Oracle.  No support for SPs, packages, etc
    /// </summary>
    internal class OracleBrowser : IBrowser
    {
        class OracleNode : TreeNode
        {
            internal string type = "";
            internal string dragText = "";
            public OracleNode(string text) : base(text) { }
        }

        const int timeout = 5;
        DbClient dbClient;

        public OracleBrowser(DbClient dbClient)
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
				new TreeNode ("User Views"),
			};

            DataSet ds = dbClient.ExecuteOnWorker("select TABLE_NAME from USER_TABLES", timeout);
            if (ds == null || ds.Tables.Count == 0) return null;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                OracleNode node = new OracleNode(row[0].ToString());
                node.type = "T";
                node.dragText = node.Text;
                top[0].Nodes.Add(node);
                // Add a dummy sub-node to user tables and views so they'll have a clickable expand sign
                // allowing us to have GetSubObjectHierarchy called so the user can view the columns
                node.Nodes.Add(new TreeNode());
            }

            ds = dbClient.ExecuteOnWorker("select VIEW_NAME from USER_VIEWS", timeout);
            if (ds == null || ds.Tables.Count == 0) return top;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                OracleNode node = new OracleNode(row[0].ToString());
                node.type = "V";
                node.dragText = node.Text;
                top[1].Nodes.Add(node);
                // Add a dummy sub-node to user tables and views so they'll have a clickable expand sign
                // allowing us to have GetSubObjectHierarchy called so the user can view the columns
                node.Nodes.Add(new TreeNode());
            }

            return top;
        }

        public TreeNode[] GetSubObjectHierarchy(TreeNode node)
        {
            // Show the column breakdown for the selected table

            if (node is OracleNode)
            {
                OracleNode on = (OracleNode)node;
                if (on.type == "T" || on.type == "V")
                {
                    DataSet ds = dbClient.ExecuteOnWorker("select COLUMN_NAME name, DATA_TYPE type, DATA_LENGTH clength, DATA_PRECISION nprecision, DATA_SCALE nscale, NULLABLE nullable from USER_TAB_COLUMNS where TABLE_NAME = '"
                        + on.Text + "'", timeout);
                    if (ds == null || ds.Tables.Count == 0) return null;

                    TreeNode[] tn = new OracleNode[ds.Tables[0].Rows.Count];
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

                        OracleNode column = new OracleNode(row["name"].ToString() + " ("
                            + row["type"].ToString() + length + ", " + nullable + ")");

                        column.dragText = row["name"].ToString();

                        tn[count++] = column;
                    }
                    return tn;
                }
            }
            return null;
        }

        public string GetDragText(TreeNode node)
        {
            if (node is OracleNode)
                return ((OracleNode)node).dragText;
            else
                return null;
        }

        public StringCollection GetActionList(TreeNode node)
        {
            if (!(node is OracleNode)) return null;

            OracleNode on = (OracleNode)node;
            StringCollection output = new StringCollection();

            if (on.type == "T" || on.type == "V")
            {
                output.Add("select * from " + on.dragText);
            }

            return output.Count == 0 ? null : output;
        }

        public string GetActionText(TreeNode node, string action)
        {
            if (!(node is OracleNode)) return null;
            OracleNode on = (OracleNode)node;
            if (action.StartsWith("select * from "))
                return action;
            else
                return null;
        }

        public string[] GetDatabases()
        {
            return new String[] { dbClient.Database };
        }

        public IBrowser Clone(DbClient newDbClient)
        {
            OracleBrowser ob = new OracleBrowser(newDbClient);
            return ob;
        }
    }
}
