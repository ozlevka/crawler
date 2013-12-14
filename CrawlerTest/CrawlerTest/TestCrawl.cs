using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsQuery;
using CrawlerLibrary;
using CrawlerLibrary.CrawlerConfiguration;
using CrawlerLibrary.ConfigurationModel;
using System.IO;
using System.Collections.Generic;
using CsQuery.Implementation;
using CsQuery.Engine;

namespace CrawlerTest
{
    [TestClass]
    public class TestCrawl
    {
        [TestMethod]
        public void TestParsing()
        {
            CQ dom = "<div>Hello world! <b>I am feeling bold!</b> What about <b>you?</b></div>";

            var res = dom.Select("div b");

            Assert.AreEqual(res.Length, 2);
            Assert.AreEqual(res[0].TextContent, "I am feeling bold!");
            Assert.AreEqual(res[1].TextContent, "you?");
        }

        [TestMethod]
        public void TestPageWalkingByConfiguration()
        {
            IoCContainer container = new IoCContainer();
            ICrawlerConfiguration config = container.Resolve<ICrawlerConfiguration>();
            Site site;
            using (Stream str = File.Open("c:\\dev\\crawler\\CrawlerTest\\CrawlerTest\\Data\\TestParseSite.xml", FileMode.Open))
            {
                site = config.LoadModel(str).First();
            }

            Assert.IsNull(site.Errors, "Configuration parsing throws errors");

            Dictionary<string, Dictionary<string, List<string>>> result = new Dictionary<string, Dictionary<string, List<string>>>();

            foreach (SiteDocument document in site.Documents)
            {
               
               CQ dom = CQ.CreateFromUrl(document.Url);
               Dictionary<string, List<string>> els = new Dictionary<string, List<string>>();
               result.Add(document.Name, els);
               foreach (var element in document.Elements)
               {
                   CQ domEls = dom[element.Selector];
                   List<string> values = domEls.Select(el => ParseNodeValue(el)).ToList();
                   els.Add(element.Name, values);                   
               }
            }
        }

        private string ParseNodeValue(IDomObject el)
        {
            if (el.NodeName == "A")
            {
                return el.GetAttribute("href");
            }
            return el.InnerText;
        }        
        
        [TestMethod]
        public void TestPageWalkingByXPath()
        {

        }
    }
}
