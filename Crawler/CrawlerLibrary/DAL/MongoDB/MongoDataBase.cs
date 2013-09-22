using CrawlerLibrary.DataConfig;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerLibrary.DAL.MongoDB
{
    public class DataBaseForMongo : IDataBase
    {
        private MongoDatabase mDataBase;
        private static readonly string s_configCollection = "configs";

        public void SetConnectionString(string connectionString)
        {
            MongoClient client = new MongoClient(connectionString);
            MongoServer server = client.GetServer();
            MongoUrl url = MongoUrl.Create(connectionString);

            mDataBase = server.GetDatabase(url.DatabaseName);
        }

        
        public bool SaveConfiguration(ConfigItemBase configItem)
        {
            MongoCollection collection = mDataBase.GetCollection<ConfigItemBase>(s_configCollection);
            WriteConcernResult result = collection.Save<ConfigItemBase>(configItem);

            return result.Ok;
        }

        public ConfigItemBase GetConfiguration(string name)
        {
            MongoCollection<ConfigItemBase> collection = mDataBase.GetCollection<ConfigItemBase>(s_configCollection);
            return collection.AsQueryable<ConfigItemBase>().Single<ConfigItemBase>(ci => ci.Name == name);
        }

        public ConfigItemBase GetConfiguration(object id)
        {
            MongoCollection<ConfigItemBase> collection = mDataBase.GetCollection<ConfigItemBase>(s_configCollection);
            return collection.FindOneByIdAs<ConfigItemBase>(id as BsonValue);
        }


        public bool CreateDataBase()
        {
            throw new NotImplementedException();
        }
    }
}
