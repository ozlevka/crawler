using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrawlerLibrary.Configuration;

namespace CrawlerTest
{
    [TestClass]
    public class ConfigurationTests
    {
        [TestMethod]
        public void LoadTest()
        {
            GMailSection section = GMailSection.Instance;

            Assert.IsNotNull(section.Accounts);
            Assert.IsTrue(section.Accounts.Count > 0);

            Assert.IsNotNull(section.Accounts.OfType<GMailAccount>().First(gma => gma.Name == "some.crawl"));
        }
    }
}
