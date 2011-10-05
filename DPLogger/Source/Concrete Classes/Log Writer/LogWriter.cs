using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DP.Logger.Base;

namespace DP.Logger
{
    sealed public class LogWriter:ILogWriter
    {
        internal LogWriter()
        {
        }

        List<AbstractLogger> objLoggerList = new List<AbstractLogger>();
       
        internal void AddLogger(AbstractLogger objAbstractLogger)
        {
            this.objLoggerList.Add(objAbstractLogger);
        }

        internal void RemoveLogger(AbstractLogger objAbstractLogger)
        {
            this.objLoggerList.Remove(objAbstractLogger);
        }

        #region ILogger Members

        public void Write(string text)
        {
            foreach (AbstractLogger logger in objLoggerList)
            {
                logger.Log(text);                
            }
        }

        public void Write(string text, LogType logType)
        {
            foreach (AbstractLogger logger in objLoggerList)
            {
                logger.Log(text, logType);
            }
        }

        #endregion
    }
}
