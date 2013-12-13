using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrawlerLibrary;
using CrawlerLibrary.CrawlerConfiguration;
using System.IO;
using CrawlerLibrary.ConfigurationModel;

namespace CrawlerTest
{
    [TestClass]
    public class XmlConfigurationTests
    {
        [TestMethod]
        public void TestLoadDataFromXmlFile()
        {
            IoCContainer container = new IoCContainer();
            ICrawlerConfiguration config = container.Resolve<ICrawlerConfiguration>();
            Site site;
            using(Stream str = File.Open("c:\\dev\\crawler\\CrawlerTest\\CrawlerTest\\Data\\TestXmlConfig.xml",FileMode.Open))
            {
                site = config.LoadModel(str);
            }                
        }
    }
}
