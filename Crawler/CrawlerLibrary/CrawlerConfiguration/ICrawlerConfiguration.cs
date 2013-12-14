using CrawlerLibrary.ConfigurationModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerLibrary.CrawlerConfiguration
{
    public interface ICrawlerConfiguration
    {
        IEnumerable<Site> LoadModel();

        IEnumerable<Site> LoadModel(string model);

        IEnumerable<Site> LoadModel(Stream modelStream);
    }
}
