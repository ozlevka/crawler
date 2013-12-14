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
        public IEnumerable<Site> LoadModel()
        {
            if (_xmlDoc == null)
            {
                throw new ArgumentNullException("Load xml");
            }

            IEnumerable<XElement> xmlSites = _xmlDoc.Root.Elements("site");
            if (xmlSites != null)
            {
                List<Site> sites = new List<Site>();
                foreach (var xmlSite in xmlSites)
                {
                    Site s = new Site();
                    s.StartParse(xmlSite);
                    sites.Add(s);
                }

                return sites;
            }

            return null;
        }


        public IEnumerable<Site> LoadModel(string model)
        {
            Parse(model);
            return LoadModel();
        }

        public IEnumerable<Site> LoadModel(Stream modelStream)
        {
            Load(modelStream);
            return LoadModel();
        }
    }
}
