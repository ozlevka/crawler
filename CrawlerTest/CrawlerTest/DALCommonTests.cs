using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;



namespace CrawlerTest
{
    [TestClass]
    public class DALCommonTests
    {
    }

    public class TestObject
    {
        [BsonId]
        public ObjectId Id { get; set; }
        
        public string Name { get; set; }
    }
}
