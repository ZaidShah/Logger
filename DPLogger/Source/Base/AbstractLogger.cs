using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DP.Logger.Configuration;

namespace DP.Logger.Base
{
    internal class AbstractLogger
    {
        protected internal AbstractLogger()
        {
            if (null != DPLoggerSection.Instance)
            {
                this.Application = DPLoggerSection.Instance.Application;
            }
        }        

        protected internal string Text { get; set; }
        protected internal LogType LogType { get; set; }
        protected internal string Application { get; set; }
        protected internal DateTime LogTime { get; set; }
        
        protected virtual void BeforeLog()
        {
        }

        protected virtual void Log()
        {
        }

        protected virtual void AfterLog()
        {

        }

        protected internal void Log(string text)
        {
            Log(text, this.LogType);
        }

        protected internal void Log(string text, LogType logType)
        {
            this.Text = text;
            this.LogType = logType;
            this.LogTime = DateTime.Now;

            BeforeLog();
            Log();
            AfterLog();
        }
    }
}
