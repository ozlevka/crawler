using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerLibrary.Configuration
{
    public class GMailSection : ConfigurationSection
    {
        static GMailSection()
        {
            Instance = (GMailSection)ConfigurationManager.GetSection("gmail");
        }

        public static GMailSection Instance { get; private set; }
        
        [ConfigurationProperty("accounts")]
        public GMailAccountsCollection Accounts
        {
            get { return (GMailAccountsCollection)this["accounts"]; }
            set { this["accounts"] = value; }
        }
    }

    public class GMailAccountsCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new GMailAccount();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((GMailAccount)element).Name;
        }
    }


    public class GMailAccount : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("password", IsRequired = true)]
        public string Password
        {
            get { return (string)this["password"]; }
            set { this["password"] = value; }
        }

        [ConfigurationProperty("server")]
        public string Server
        {
            get { return (string)this["server"]; }
            set { this["server"] = value; }
        }

        [ConfigurationProperty("port")]
        public int Port
        {
            get { return (int)this["port"]; }
            set { this["port"] = value; }
        }


    }
}
