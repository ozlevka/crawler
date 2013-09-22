using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerLibrary.DataConfig
{
    public class ConfigItemBase
    {
        public object Id { get; set; }

        public string Name { get; set; }

        public IList<ConfigItemBase> InnerObjects { get; set; }

        public ParserType Type { get; set; }
    }
}
