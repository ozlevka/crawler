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


        public void StartParse(XDocument xmlDocument)
        {

        }
    }
}
