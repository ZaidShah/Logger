using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DP.Logger.Configuration
{
    sealed class FileLoggerElement:ConfigurationElement
    {
        private FileLoggerElement()
            : base()
        {
        }

        [ConfigurationProperty("FileName")]
        public string FileName
        {
            get { return (string)this["FileName"]; }
            set { this["FileName"] = value; }
        }

        [ConfigurationProperty("Path")]
        public string Path
        {
            get { return (string)this["Path"]; }
            set { this["Path"] = value; }
        }

        [ConfigurationProperty("MaxSize")]
        public int MaxSize
        {
            get { return (int)this["MaxSize"]; }
            set { this["MaxSize"] = value; }
        }

        [ConfigurationProperty("enabled", DefaultValue = "true", IsRequired = false)]
        public bool Enabled
        {
            get { return (bool)this["enabled"]; }
            set { this["enabled"] = value; }
        }
    }
}
