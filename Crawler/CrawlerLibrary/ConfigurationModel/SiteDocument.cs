using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CrawlerLibrary.ConfigurationModel
{
    public class SiteDocument
    {
               
        public IEnumerable<DocumentElement> Elements { get; set; }

        public string Name { get; private set; }

        public string Url { get; private set; }
        
        internal SiteDocument StartParse(XElement xmlDocument)
        {
            if (xmlDocument == null) throw new ArgumentNullException("xmlDocument can not be null");
            XAttribute nameAttr = xmlDocument.Attribute("name");
            XAttribute urlAttr = xmlDocument.Attribute("url");


            return this;
        }
    }
}
