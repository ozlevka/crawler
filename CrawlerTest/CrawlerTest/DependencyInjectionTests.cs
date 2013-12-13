using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrawlerLibrary.CrawlerConfiguration;
using CrawlerLibrary;

namespace CrawlerTest
{
    [TestClass]
    public class DependencyInjectionTests
    {
        [TestMethod]
        public void TestResolveConfiguration()
        {
            IoCContainer _resolver = new IoCContainer();

            ICrawlerConfiguration config = _resolver.Resolve<ICrawlerConfiguration>();

            Assert.IsNotNull(config);
            Assert.AreEqual(config.GetType(), typeof(XmlConfiguration)); 
        }
    }
}
