using CrawlerLibrary.ConfigurationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerLibrary.CrawlerConfiguration
{
    public interface ICrawlerConfiguration
    {
        Site LoadModel();
    }
}
