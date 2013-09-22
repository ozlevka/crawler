using CrawlerLibrary.DataConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerLibrary.DAL
{
    public interface IDataBase
    {
        void SetConnectionString(string connectionString);

        bool SaveConfiguration(ConfigItemBase configItem);

        ConfigItemBase GetConfiguration(string name);

        ConfigItemBase GetConfiguration(object id);

        bool CreateDataBase();
    }
}
