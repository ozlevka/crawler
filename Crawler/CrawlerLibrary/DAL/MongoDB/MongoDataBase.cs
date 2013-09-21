using MongoDB.Driver;
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

        public void SetConnectionString(string connectionString)
        {
            MongoClient client = new MongoClient(connectionString);
            MongoServer server = client.GetServer();
            MongoUrl url = MongoUrl.Create(connectionString);

            mDataBase = server.GetDatabase(url.DatabaseName);
        }
    }
}
