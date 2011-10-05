using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DP.Logger.Configuration
{
    sealed class DatabaseLoggerElement:ConfigurationElement
    {
        private DatabaseLoggerElement()
            : base()
        {
        }

        //
        [ConfigurationProperty("enabled", DefaultValue = "true", IsRequired = false)]
        public bool Enabled
        {
            get { return (bool)this["enabled"]; }
            set { this["enabled"] = value; }
        }

        [ConfigurationProperty("ConnectionString")]
        public string ConnectionString 
        {
            get { return (string)this["ConnectionString"]; }
            set { this["ConnectionString"] = value; }
        }

    }
}
