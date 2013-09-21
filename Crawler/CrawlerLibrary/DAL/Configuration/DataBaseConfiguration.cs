using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerLibrary.DAL.Configuration
{
    public class DataBaseConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("database")]
        public DataBaseConfigElement DataBaseElement
        {
            get { return (DataBaseConfigElement)this["database"]; }
            set { this["database"] = value; }
        }

    }

    public class DataBaseConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("type", DefaultValue = "CrawlerLibrary.DAL.MongoDB.MongoDataBase, CrawlerLibrary")]
        public string Type
        {
            get { return (string)this["type"]; }
            set { this["type"] = value; }
        }

        [ConfigurationProperty("connectionString", DefaultValue = "mongodb://localhost/crawler")]
        public string ConnectionString
        {
            get { return (string)this["connectionString"]; }
            set { this["connectionString"] = value; }
        }

    }
}
