using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerLibrary.Mail
{
    public interface IMailFactory
    {
        IMailFetcher GetMailFetcher(string accountName);
    }
}
