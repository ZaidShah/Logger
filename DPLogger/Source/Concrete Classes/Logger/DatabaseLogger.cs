using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace DP.Logger.Base
{
    class DatabaseLogger : AbstractLogger
    {       
        List<DbParameter> parameterList = new List<DbParameter>();
        const string INSERT_QUERY = @"INSERT INTO [DPLogger].[dbo].[Logger]
                                    ([Text]
                                    ,[Type]
                                    ,[Application])
                                VALUES
                                    (@Text,
                                    @Type, 
                                    @Application)";

        public static DatabaseLogger CreateDatabaseLogger()
        {
            try
            {
                if (!DB.IsConnectionReady)
                {
                    return null;
                }

                if (!DB.ReadyConnection)
	            {
                    return null;	 
	            }
                return new DatabaseLogger();
            }
            catch (Exception)
            {
                return null;
            }
        }

        protected internal DatabaseLogger()
            : base()
        {
        }      

        protected override void BeforeLog()
        {          
            
            DbParameter dbParameter = DB.CreateParameter("@Text", this.Text);
            parameterList.Add(dbParameter);

            dbParameter = DB.CreateParameter("@Type", this.LogType);
            parameterList.Add(dbParameter);

            dbParameter = DB.CreateParameter("@Application", this.Application);
            parameterList.Add(dbParameter);
        }

        protected override void Log()
        {
            DB.ExecuteNonQuery(INSERT_QUERY, parameterList); 
        }

        protected override void AfterLog()
        {
            DB.CloseConnection();
        }
    }
}
