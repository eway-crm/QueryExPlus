using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace QueryExPlus
{
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable()]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public partial class ServerList
    {

        private ArrayList itemsField = new ArrayList();

        /// <remarks/>
        [XmlElement("Server", Form = XmlSchemaForm.Unqualified)]
        public ConnectionSettings[] Items
        {
            get
            {
                return (ConnectionSettings[]) this.itemsField.ToArray(typeof(ConnectionSettings));
            }
            set
            {
                this.itemsField.Clear();
                this.itemsField.AddRange(value);
            }
        }
        
        public int Add(ConnectionSettings conSettings)
        {
            return itemsField.Add(conSettings);
        }
        public int IndexOf(string key)
        {
            for (int i = 0; i < itemsField.Count; i++)
            {
                ConnectionSettings conSetting = (ConnectionSettings) itemsField[i];
                if (conSetting.Key == key)
                    return i;
            }
            return -1;
        }
    }

    /// <remarks/>
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [XmlType(AnonymousType = true)]
    public class ConnectionSettings
    {
        [Serializable]
        public enum ConnectionType
        {
            SqlConnection,
            Odbc,
            Oracle,
            OleDb
        }
        
        #region Private Variables

        ConnectionType _Type;
        string _SqlServer="";
        string _SqlDatabase;
        bool _Trusted;
        string _LoginName;
        string _Password;
        string _OdbcConnectionString;
        string _OracleDataSource = "";
        string _OleDbConnectionString;
        #endregion

        #region Public Properties

        public ConnectionType Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        public string SqlServer
        {
            get { return _SqlServer; }
            set { _SqlServer = value; }
        }

        public string SqlDatabase
        {
            get { return _SqlDatabase; }
            set { _SqlDatabase = value; }
        }

        public bool Trusted
        {
            get { return _Trusted; }
            set { _Trusted = value; }
        }

        public string LoginName
        {
            get { return _LoginName; }
            set { _LoginName = value; }
        }

        [XmlIgnore]
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        [XmlIgnore]
        public string Key
        {
            get
            {
                switch (this.Type)
                {
                    case ConnectionType.SqlConnection:
                        return "SQL_" + SqlServer;
                    case ConnectionType.Oracle:
                        return "ORACLE_"+OracleDataSource;
                    case ConnectionType.Odbc:
                        return "Odbc";
                    case ConnectionType.OleDb:
                        return "OleDb";
                    default:
                        throw new ArgumentOutOfRangeException("ConnectionType", "Invalid Connection Type");
                }                
            }
        }

        [XmlIgnore]
        public string Description
        {
            get 
            {

                switch (this.Type)
                {
                    case ConnectionType.SqlConnection:
                        return SqlServer + " (" + (Trusted ? "Trusted" : LoginName.Trim()) + ")";
                    case ConnectionType.Oracle:
                        return OracleDataSource + " (" + (Trusted? "Trusted" : LoginName.Trim()) + ")";
                    case ConnectionType.Odbc:
                        return "Odbc";
                    case ConnectionType.OleDb:
                        return "OleDb";
                    default:
                        throw new ArgumentOutOfRangeException("ConnectionType", "Invalid Connection Type");
                }                
            }
        }

        public string OdbcConnectionString
        {
            get { return _OdbcConnectionString; }
            set { _OdbcConnectionString = value; }
        }

        public string OleDbConnectionString
        {
            get { return _OleDbConnectionString; }
            set { _OleDbConnectionString = value; }
        }

        public string OracleDataSource
        {
            get { return _OracleDataSource; }
            set { _OracleDataSource = value; }
        }

        #endregion

        #region Public Functions
        ///<summary>
        ///Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        ///</summary>
        ///
        ///<returns>
        ///A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        ///</returns>
        ///<filterpriority>2</filterpriority>
        public override string ToString()
        {
            switch (this.Type)
            {
                case ConnectionType.SqlConnection:                    
                    return _SqlServer;
                case ConnectionType.Oracle: 
                    return _OracleDataSource;
                case ConnectionType.Odbc:
                    return "Odbc";
                case ConnectionType.OleDb:
                    return "OleDb";
                default:
                    throw new ArgumentOutOfRangeException("ConnectionType", "Invalid Connection Type");
            }                  
        }

        public ConnectionSettings Clone()
        {
            ConnectionSettings newConSettings;
            newConSettings = new ConnectionSettings();
            newConSettings.Type= _Type;
            newConSettings.SqlServer = _SqlServer;
            newConSettings.SqlDatabase = _SqlDatabase;
            newConSettings.Trusted = _Trusted;
            newConSettings.LoginName = _LoginName;
            newConSettings.Password = _Password;
            newConSettings.OdbcConnectionString = _OdbcConnectionString;
            newConSettings.OleDbConnectionString = _OleDbConnectionString;
            newConSettings.OracleDataSource = _OracleDataSource;
            return newConSettings;
        }
        #endregion
    }
}
