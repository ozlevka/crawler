using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrawlerLibrary;
using CrawlerLibrary.CrawlerConfiguration;

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

            
        }
    }
}
