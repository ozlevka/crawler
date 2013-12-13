using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerLibrary.ConfigurationModel
{
    public class Site
    {
        public IEnumerable<SiteDocument> Documents { get; set; }
    }
}
