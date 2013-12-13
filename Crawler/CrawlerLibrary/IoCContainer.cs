using CrawlerLibrary.Common;
using CrawlerLibrary.CrawlerConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerLibrary
{
    public class IoCContainer : IDependencyResolver
    {
        private TinyIoC.TinyIoCContainer _container = TinyIoC.TinyIoCContainer.Current;
        public IoCContainer()
        {
            _container.Register<ICrawlerConfiguration, XmlConfiguration>();
        }

        public T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }
    }
}
