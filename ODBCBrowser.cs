using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.Odbc;
using System.Text;
using System.Windows.Forms;

namespace QueryExPlus
{
    /// <summary>
	/// QueryExPlus.dl3bak.ODBCBrowser 
	/// 
	/// An implementation of IBrowser for ODBC
	/// 
	/// (c) 2003 by dl3bak@qsl.net
	/// 
	/// free for public distribution
	/// 
	/// </summary>
	internal class ODBCBrowser : IBrowser
	{
		DbClient dbClient;

		class ODBCNode : TreeNode
		{
			internal int type = -1;
			internal string dragText 
			{
				get {
					// if name contains blanks, suround it with []
					if (Text.IndexOf (' ') >= 0)
						return "[" + Text + "]";
					else 
						return Text;
					
				}
			}
			public ODBCNode (string text, int type) : base (text) 
			{
				this.type = type;
			}
		}

		public ODBCBrowser (DbClient dbClient)
		{
			this.dbClient = dbClient;
		}

		public DbClient DbClient
		{
			get {return dbClient;}
		}

		public IBrowser Clone (DbClient newDbClient)
		{
			ODBCBrowser sb = new ODBCBrowser (newDbClient);
			return sb;
		}

		public TreeNode[] GetObjectHierarchy()
		{
			TreeNode[] top = new TreeNode[]
			{
				new TreeNode ("TABLE"),				// 0
				new TreeNode ("VIEW"),				// 1
				new TreeNode ("SYSTEM TABLE"),		// 2
				new TreeNode ("SYSTEM VIEW")		// 3
			};

		    string[] schemas = {"TABLES", "VIEWS", "TABLES", "VIEWS"};
			int curNoteType = 0;
			for(int i = 0; i<4; i++)
			{
			    CreateNodeHierachy(top, curNoteType++, top[i].Text, schemas[i]);
			}
		    return top;
		}

		/// <summary>
		/// 
		///  return TreeNode[].Add("SELECT [COLUMN_NAME] FROM [Columns] WHERE [Tablename] = {filter}")
		/// 
		/// </summary>
		public TreeNode[] GetSubObjectHierarchy (TreeNode node)
		{
			// Show the column breakdown for the selected table
			
			if (node is ODBCNode)
			{
				string table = node.Text;
			

				string[] fields = GetODBCBrowserValues("COLUMN_NAME"
				                        ,"Columns" // // ODBC.Columns
				                        , new string[] {GetDatabaseFilter(), null, table}
                                        ,null);
				
				if (fields != null)
				{
					TreeNode[] tn = new ODBCNode [fields.Length];
					int count = 0;
					
					foreach (string name in fields)
					{
						ODBCNode column = new ODBCNode (name, -1);
						tn [count++] = column;
					}
					return tn;
				}
			}
			return null;
		}

		public string GetDragText (TreeNode node)
		{
			if (node is ODBCNode)
				return ((ODBCNode) node).dragText;
			else
				return "";
		}

		public StringCollection GetActionList (TreeNode node)
		{
			if (!(node is ODBCNode)) return null;

			ODBCNode on = (ODBCNode) node;
			StringCollection output = new StringCollection();

			if (on.type >= 0)
			{
				output.Add ("select * from " + on.dragText);
				output.Add ("(insert all fields)");
				output.Add ("(insert all fields, table prefixed)");
			}

			return output.Count == 0 ? null : output;
		}

		public string GetActionText (TreeNode node, string action)
		{
			if (!(node is ODBCNode)) return null;
			
			ODBCNode on = (ODBCNode) node;
			if (action.StartsWith ("select * from "))
				return action;
			
			if (action.StartsWith ("(insert all fields"))
			{				
				StringBuilder sb = new StringBuilder();
				// If the table-prefixed option has been selected, add the table name to all the fields
				string prefix = action == "(insert all fields)" ? "" : on.dragText + ".";
				int chars = 0;
				foreach (TreeNode subNode in GetSubObjectHierarchy (node))
				{
					if (chars > 50)
					{
						chars = 0;
						sb.Append ("\r\n");
					}
					string s = (sb.Length == 0 ? "" : ", ") + prefix + ((ODBCNode) subNode).dragText;
					chars += s.Length;
					sb.Append (s);
				}
				return sb.Length == 0 ? null : sb.ToString();
			}
			
			return null;
		}

		public string[] GetDatabases()
		{
			string[] result = GetODBCBrowserValues(
			                        "CATALOG_NAME","Databases" //ODBCSchemaGuid.Catalogs
			                        ,null, null);
			
			if (result == null)
				result = new String[] {dbClient.Database};
			
			return result;
		}

#region implementation helpers

		private string GetDatabaseFilter()
		{
			string result = dbClient.Database;
			if ((result != null) && (result.Length == 0))
				return null;
			return result;
		}
		
		/// <summary>
		/// top[curNoteType].Add("SELECT [TABLE_NAME] FROM [Tables] WHERE [Tabletyp] = {filter}")
		/// </summary>
		private void CreateNodeHierachy(TreeNode[] top, int curNoteType, string filter, string schema)
		{
			string[] result = null;
			
			result = GetODBCBrowserValues(
                                   "TABLE_NAME", schema //ODBCSchemaGuid.Tables
			                        ,new string[] {GetDatabaseFilter(), null, null}
                                    , filter);
			
			if (result != null)
			{
				foreach (string str in result)
				{
				    if (str != null)
				    {
				        ODBCNode node = new ODBCNode (str, curNoteType);
									
				        top [curNoteType].Nodes.Add (node);
				        // Add a dummy sub-node to user tables and views so they'll have a clickable expand sign
				        // allowing us to have GetSubObjectHierarchy called so the user can view the columns
				        node.Nodes.Add (new TreeNode());
				    }
				}
			}
		}

		/// <summary>
		/// ODBC specific internal Query
		/// 
		/// SELECT {resultColumnName} 
		/// FROM {schema} 
		/// WHERE {restrictions}
		/// 
		/// </summary>		
		/// <returns>String-Array with Fields from </returns>
		string[] GetODBCBrowserValues(string resultColumnName
		                               	, string schema
		                               	, string[] restrictions
                                        , string Table_Type)
		{
			OdbcConnection con = null;
			DataTable tab = null;
			string[] sa = null;
			
			try {
				con = ((OdbcConnection) ((OdbcClient) DbClient).Connection) ;
                tab = con.GetSchema(schema, restrictions); //schema // ie ODBC SchemaGuid.Columns or .Tables
			                            //                   ,restrictions // ie new object[] {null, null, null, "TABLE"}
			                              //                 );

                DataColumn col = tab.Columns[resultColumnName];
			    DataColumn TableTypeCol = null;
                DataColumn TableSchemaCol = null;
                if (Table_Type != null)
                {
                    TableTypeCol = tab.Columns["TABLE_TYPE"];
                    TableSchemaCol = tab.Columns["TABLE_SCHEM"];
                }
				sa = new string [tab.Rows.Count];
				int count = 0;
				foreach (DataRow row in tab.Rows)
                    if (Table_Type == null || row[TableTypeCol].ToString() == Table_Type)
					    sa [count++] = row[TableSchemaCol].ToString().Trim() + "." +  row[col].ToString().Trim();
			
			} catch (Exception) {			
			} finally {
				if (tab != null)
					tab.Dispose();			
			}
			return sa;		
		}
#endregion
    }
}
