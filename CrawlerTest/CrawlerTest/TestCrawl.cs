using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsQuery;

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
    }
}
