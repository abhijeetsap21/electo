using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electo.Models.IRepositories
{
    interface INewsServices
    {
        void createNews(news news);
        IEnumerable<sp_GetLatestNews_Result> getNews();
    }
}
