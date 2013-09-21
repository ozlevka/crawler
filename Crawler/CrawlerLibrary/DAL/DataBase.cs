using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerLibrary.DAL
{
    public interface IDataBase
    {
        void SetConnectionString(string connectionString);
    }
}
