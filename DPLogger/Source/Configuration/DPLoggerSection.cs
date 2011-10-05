using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DP.Logger.Configuration
{
    sealed class DPLoggerSection:ConfigurationSection
    {
        private DPLoggerSection():base()
        {
        }

        private static DPLoggerSection instance;

        public static DPLoggerSection Instance 
        {
            get
            {
                if (instance==null)
                {
                    try 
                    {
                        System.Configuration.Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        instance = (DPLoggerSection)cfg.GetSection("DPLoggerGroup/DPLoggerSection");                    
                    } 
                    catch(Exception ex) 
                    {
                        instance=null;
                    }
                }

                return instance;
            }            
        }

        [ConfigurationProperty("enabled", DefaultValue="true", IsRequired= false)]
        public bool Enabled 
        {
            get { return (bool)this["enabled"];}
            set { this["enabled"] = value; }
        }

        [ConfigurationProperty("application")]
        public string Application 
        {
            get { return (string)this["application"]; }
            set { this["application"] = value; }
        }

        [ConfigurationProperty("DatabaseLoggerElement")]
        public DatabaseLoggerElement DatabaseLogger
        {
            get { return (DatabaseLoggerElement)this["DatabaseLoggerElement"]; }
            set { this["DatabaseLoggerElement"] = value; }
        }

        [ConfigurationProperty("FileLoggerElement")]
        public FileLoggerElement FileLogger 
        {
            get { return (FileLoggerElement)this["FileLoggerElement"]; }
            set { this["FileLoggerElement"] = value; } 
        }
    }
}
