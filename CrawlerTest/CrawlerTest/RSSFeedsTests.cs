using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Diagnostics;

namespace CrawlerTest
{
    [TestClass]
    public class RSSFeedsTests
    {
        [TestMethod]
        public void TestSyndicationFeed()
        {
            SyndicationFeed feed; 
            using(XmlReader reader = XmlReader.Create("http://feeds.feedburner.com/lccLatestDeals"))
            {
                feed = SyndicationFeed.Load(reader);
            }

            foreach (var item in feed.Items)
            {
                Debug.Print(string.Format("title:{0} Summary: {1}", item.Title.Text, item.Summary.Text));
            }
        }
    }
}
