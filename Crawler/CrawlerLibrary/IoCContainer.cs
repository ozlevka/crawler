using CrawlerLibrary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerLibrary
{
    public class IoCContainer : IDependencyResolver
    {
        

        public T Resolve<T>() where T : class
        {
            return default(T);
        }
    }
}
