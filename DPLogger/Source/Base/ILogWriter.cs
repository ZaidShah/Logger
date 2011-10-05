using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP.Logger.Base
{
    public interface ILogWriter
    {        
        void Write(string text);
        void Write(string text, LogType logType);
    }
}
