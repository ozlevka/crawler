using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerLibrary.DataConfig
{
    public class ParseObjectBase
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string HtmlPath { get; set; }

        public IList<ParseObjectBase> InnerObjects { get; set; }
    }
}
