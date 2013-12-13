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
            Name = xmlDocument.Attribute("name").Value;
            Url = xmlDocument.Attribute("url").Value;

            var elements = xmlDocument.Elements("element");
            if (elements != null)
            {
                List<DocumentElement> xmlElements = new List<DocumentElement>();
                Elements = xmlElements;
                foreach (var item in elements)
                {
                    DocumentElement dElement = new DocumentElement();
                    xmlElements.Add(dElement.StartParse(item));
                }
            }

            return this;
        }
    }
}
