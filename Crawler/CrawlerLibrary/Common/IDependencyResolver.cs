using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerLibrary.Common
{
    public interface IDependencyResolver
    {
        public T Resolve<T>() where T : class;
    }
}
