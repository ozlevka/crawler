using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CrawlerLibrary.ConfigurationModel
{
    public class DocumentElement
    {
        public IEnumerable<DocumentElement> Elements { get; set; }
        public string Name { get; private set; }

        public string Selector { get; private set; }

        public string FieldName { get; private set; }

        internal DocumentElement StartParse(XElement xmlElement)
        {
            Name = xmlElement.Attribute("name").Value;
            Selector = xmlElement.Attribute("selector").Value;
            XAttribute attr = xmlElement.Attribute("field");
            if (attr != null)
	        {
                FieldName = attr.Value;
	        }                

            if (xmlElement.HasElements)
            {
                IEnumerable<XElement> innerXmlElements = xmlElement.Elements("element");

                if (innerXmlElements != null)
	            {
		            List<DocumentElement> innerElements = new List<DocumentElement>();
                    Elements = innerElements; 
                    
                    foreach (var item in innerXmlElements)
	                {
                        DocumentElement el = new DocumentElement();
                        el.StartParse(item);
                        innerElements.Add(el);
	                }
	            }                
            }
            return this;
        }
    }
}
