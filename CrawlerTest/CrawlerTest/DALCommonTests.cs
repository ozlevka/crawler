using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using CrawlerLibrary.DataConfig;
using System.Collections.Generic;
using CrawlerLibrary.DAL;
using CrawlerLibrary.DAL.MongoDB;

namespace CrawlerTest
{
    [TestClass]
    public class DALCommonTests
    {
        [TestMethod]
        public void TestConnectionCRUD()
        {
            MongoClient client = new MongoClient();
            MongoServer server = client.GetServer();

            MongoDatabase db = server.GetDatabase("testcrud");

            string actualName = Guid.NewGuid().ToString();

            db.CreateCollection("testcollection");

            MongoCollection<TestObject> collection = db.GetCollection<TestObject>("testcollection");

            TestObject obj = new TestObject
            {
                Name = actualName
            };

            collection.Insert(obj);
            TestObject tst = collection.AsQueryable<TestObject>().Single<TestObject>(e => e.Name == actualName);

            Assert.IsNotNull(tst);
            

            server.DropDatabase("testcrud");
        }

        [TestMethod]
        public void ParseObjectBaseCrudTest()
        {
            MongoClient client = new MongoClient();
            MongoServer server = client.GetServer();

            MongoDatabase db = server.GetDatabase("crawler");

            MongoCollection<ParseObjectBase> collection = db.GetCollection<ParseObjectBase>("configs");

            ParseObjectBase main = new ParseObjectBase
            {
                Name = "Main",
                InnerObjects = new List<ParseObjectBase>()
            };

            for (int i = 0; i < 10; i++)
            {
                ParseObjectBase inner = new ParseObjectBase
                {
                    Name = "Inner" + i
                };

                main.InnerObjects.Add(inner);
            }

            collection.Insert(main);

            ParseObjectBase pobj = collection.AsQueryable<ParseObjectBase>().Single<ParseObjectBase>(e => e.Name == "Main");

            Assert.IsNotNull(pobj);
            Assert.AreEqual(pobj.InnerObjects.Count, 10);

            for (int i = 0; i < pobj.InnerObjects.Count; i++)
            {
                ParseObjectBase inner = pobj.InnerObjects[i];
                Assert.AreEqual(inner.Name, "Inner" + i);
            }

            collection.RemoveAll();
        }

        [TestMethod]
        public void DBFactoryLoadTest()
        {
            DBFactory factory = new DBFactory();
            IDataBase db = factory.GetDataBase();

            DataBaseForMongo namedDB = db as DataBaseForMongo;

            Assert.IsNotNull(namedDB);
        }
    }

    public class TestObject
    {
        [BsonId]
        public ObjectId Id { get; set; }
        
        public string Name { get; set; }
    }
}
