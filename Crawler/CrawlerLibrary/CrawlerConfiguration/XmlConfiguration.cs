using CrawlerLibrary.ConfigurationModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CrawlerLibrary.CrawlerConfiguration
{
    public class XmlConfiguration : ICrawlerConfiguration
    {
        private XDocument _xmlDoc;

        public XDocument XML
        {
            get
            {
                return _xmlDoc;
            }

            set
            {
                _xmlDoc = value;
            }
        }
        
        public void Parse(string xml)
        {
            _xmlDoc = XDocument.Parse(xml);
        }

        public void Load(string uri)
        {
            _xmlDoc = XDocument.Load(uri);
        }

        public void Load(Stream str)
        {
            _xmlDoc = XDocument.Load(str);
        }


        public void Load(XmlReader xmlReader)
        {
            _xmlDoc = XDocument.Load(xmlReader);
        }

        public void Load(TextReader textReader)
        {
            _xmlDoc = XDocument.Load(textReader);
        }
        public Site LoadModel()
        {
            if (_xmlDoc == null)
            {
                throw new ArgumentNullException("Load xml");
            }

            Site site = new Site();
            site.StartParse(_xmlDoc);
            return site;
        }
    }
}
