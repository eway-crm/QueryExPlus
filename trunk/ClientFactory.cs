using System;

namespace QueryExPlus
{
    static class DbClientFactory
    {
        //TODO: This should not be in the factory since that is against Objcet Oriented design. I am not sure where to put it yet.
        public static bool ValidateSettings(ConnectionSettings conSettings)
        {
            switch (conSettings.Type)
            {
                case ConnectionSettings.ConnectionType.SqlConnection:
                    return conSettings.SqlServer != null && conSettings.SqlServer.Length > 0;
                case ConnectionSettings.ConnectionType.Odbc:
                    return conSettings.OdbcConnectionString != null && conSettings.OdbcConnectionString.Length > 0;
                case ConnectionSettings.ConnectionType.Oracle:
                    return conSettings.OracleDataSource != null && conSettings.OracleDataSource.Length > 0;
                default:
                    throw new ArgumentOutOfRangeException("conSettings.Type");
            }
        }

        public static DbClient GetDBClient(ConnectionSettings conSettings)
        {
            switch (conSettings.Type)
            {
                case ConnectionSettings.ConnectionType.SqlConnection:
                    return new SqlDBClient(conSettings);
                case ConnectionSettings.ConnectionType.Odbc:
                    return new OdbcClient(conSettings);
                case ConnectionSettings.ConnectionType.Oracle:
                    return new OracleDbClient(conSettings);
                default:
                    throw new ArgumentOutOfRangeException("conSettings.Type");
            }
        }
        
        public static IBrowser GetBrowser(DbClient client)
        {
            if ((client as SqlDBClient) != null)
            {
                return new SqlBrowser(client);
            }
            if ((client as OdbcClient) != null)
            {
                return new ODBCBrowser(client);
            }
            if ((client as OracleDbClient)!= null)
            {
                return new OracleBrowser(client);
            }
            throw new ApplicationException("Unknown connection type");
        }
    }
}
