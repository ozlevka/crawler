using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CrawlerLibrary.ConfigurationModel
{
    public class Site
    {
        public IEnumerable<SiteDocument> Documents { get; private set; }
        public IList<Exception> Errors { get; set; }

        public void StartParse(XElement xmlElement)
        {
            IEnumerable<XElement> docs = xmlElement.Descendants("document");
            if (docs != null && docs.Count() > 0)
            {
                List<SiteDocument> siteDocuments = new List<SiteDocument>();
                Documents = siteDocuments;
                foreach (var document in docs)
                {
                    SiteDocument d = new SiteDocument();
                    try
                    {
                        siteDocuments.Add(d.StartParse(document));
                    }
                    catch (Exception ex)
                    {
                        if (Errors == null)
                        {
                            Errors = new List<Exception>();
                        }

                        Errors.Add(ex);
                    }
                } 
            }
        }
    }
}
