using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DP.Logger.Base
{
    class FileStreamLogger:AbstractLogger
    {
        Stream objStream;
        StreamWriter objStreamWriter;
        public int MaxSize { get; set; }        

        protected internal FileStreamLogger():base()
        {
            
        }

        protected internal FileStreamLogger(FileStream objFileStream, int maxSize)
        {
            this.objStream = objFileStream;
            this.MaxSize = maxSize;
        }

        protected override void BeforeLog()
        {
            objStreamWriter = new StreamWriter(this.objStream, Encoding.UTF8);            
        }

        protected override void Log()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Text);
            sb.Append(" ");
            sb.Append(this.LogType);
            sb.Append(" ");
            sb.Append(this.LogTime);
            sb.Append(" ");
            sb.Append(this.Application);

            if ((this.objStream.Length + Encoding.UTF8.GetBytes(sb.ToString()).Length)>=this.MaxSize)
            {
                this.objStream.Position = 0;           
            }

            this.objStreamWriter.WriteLine(sb.ToString());
            this.objStream.SetLength(this.objStream.Position);
        }

        protected override void AfterLog()
        {
            objStreamWriter.Flush();
            objStreamWriter.Close();
            objStreamWriter.Dispose();
        }
    }
}
