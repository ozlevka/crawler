using CrawlerLibrary.DAL.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerLibrary.DAL
{    
    public class DBFactory
    {
        private static DataBaseConfigurationSection _config;
        
        static DBFactory()
        {
            _config = (DataBaseConfigurationSection)ConfigurationManager.GetSection("dbConfig");
        }
        
        public IDataBase GetDataBase()
        {
            Type dbType = Type.GetType(_config.DataBaseElement.Type);
            IDataBase db = (IDataBase)Activator.CreateInstance(dbType);
            db.SetConnectionString(_config.DataBaseElement.ConnectionString);

            return db;
        }
    }
}
