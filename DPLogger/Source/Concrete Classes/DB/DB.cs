using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Configuration;
using DP.Logger.Configuration;


namespace DP.Logger
{
    public class DB
    {
        static DB()
        {            
            DB_PROVIDER_FACTORY = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings[DPLoggerSection.Instance.DatabaseLogger.ConnectionString].ProviderName);
            CONNECTION_STRING = ConfigurationManager.ConnectionStrings[DPLoggerSection.Instance.DatabaseLogger.ConnectionString].ConnectionString;
        }

        public static bool IsConnectionReady
        {
            get 
            {
                if (null == Instance)
                {
                    return false;
                }

                return true;
            }
        }

        public static bool ReadyConnection 
        {
            get
            {
                if (!IsConnectionReady)
                {
                    return false;
                }
                                
                try
                {
                    if (ConnectionState.Closed==Instance.State)
                    {
                        Instance.Open();
                    }

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static void CloseConnection ()
        {            
            if (ConnectionState.Open==Instance.State)
            {
                Instance.Close();                    
            }            
        }

        private static readonly DbProviderFactory DB_PROVIDER_FACTORY;
        private static readonly string CONNECTION_STRING;

        private static DbConnection objDbConnection;
        
        private static DbConnection Instance
        {
            get
            {
                try
                {
                    if (null == objDbConnection)
                    {
                        objDbConnection = DB_PROVIDER_FACTORY.CreateConnection();
                        objDbConnection.ConnectionString = CONNECTION_STRING;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }

                return objDbConnection;
            }
        }

        public static int ExecuteNonQuery(string query, List<DbParameter> parameterList)
        {

            DbCommand dbCommand = Instance.CreateCommand();
            dbCommand.CommandText = query;

            foreach (DbParameter dbParameter in parameterList)
            {
                dbCommand.Parameters.Add(dbParameter);
            }

            return dbCommand.ExecuteNonQuery();
        }       

        public static DbParameter CreateParameter(string parameterName, object parameterValue) 
        {   
            DbParameter dbParameter = DB_PROVIDER_FACTORY.CreateParameter();

            dbParameter.ParameterName = parameterName;
            dbParameter.Value = parameterValue;

            return dbParameter;
        }

        public static DbParameter CreateParameter(string parameterName, object parameterValue, int size, DbType dbType)
        {
            DbParameter dbParameter = CreateParameter(parameterName, parameterValue, dbType);
            dbParameter.Size = size;            

            return dbParameter;
        }

        public static DbParameter CreateParameter(string parameterName, object parameterValue, DbType dbType)
        {
            DbParameter dbParameter = CreateParameter(parameterName, parameterValue);            
            dbParameter.DbType = dbType;

            return dbParameter;
        }
    }
}
