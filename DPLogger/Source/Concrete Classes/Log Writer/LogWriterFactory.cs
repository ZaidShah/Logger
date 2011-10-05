using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DP.Logger.Base;

namespace DP.Logger
{
    public class LogWriterFactory
    {
        public static ILogWriter CreateLogWriter()
        {
            try
            {                
                return new LogWriterBuilder().Build();                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
