using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;

using DP.Logger.Configuration;
using DP.Logger.Base;


namespace DP.Logger
{
    class LogWriterBuilder
    {
        LogWriter objLogWriter;

        public LogWriterBuilder()
        {
            this.objLogWriter = new LogWriter();
        }

        public LogWriter Build()
        {   
            if (null==DPLoggerSection.Instance)
            {
                return null;                
            }                        

            if (DPLoggerSection.Instance.DatabaseLogger.Enabled)
            {
                DatabaseLogger objDatabaseLogger = DatabaseLogger.CreateDatabaseLogger();
                if (objDatabaseLogger == null) return null;                
                this.objLogWriter.AddLogger(objDatabaseLogger);                                                    
            }

            if (DPLoggerSection.Instance.FileLogger.Enabled)
            {
                try
                {
                    FileStreamLogger objFileStreamLogger = new FileStreamLogger(new FileStream(Path.Combine(DPLoggerSection.Instance.FileLogger.Path, DPLoggerSection.Instance.FileLogger.FileName), FileMode.OpenOrCreate, FileAccess.Write), DPLoggerSection.Instance.FileLogger.MaxSize);           
                    this.objLogWriter.AddLogger(objFileStreamLogger);
                }
                catch { return null; }
            }

            return this.objLogWriter;
        }
    }
}
