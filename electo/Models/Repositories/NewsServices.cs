using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using electo.Models.IRepositories;
using static electo.Models.SP_Models.StoredProcedureModels;
using System.Data.SqlClient;
using System.Data.SqlTypes;
namespace electo.Models.Repositories
{
    public class NewsServices :INewsServices
    {
        private readonly UnitOfWork uow;

        public NewsServices()
        {
            uow = new UnitOfWork();
        }
        public void createNews(news news)
        {
            uow.createNews_.Add(news);
        }

        public IEnumerable<sp_GetLatestNews_Result> getNews()
        {
            var result = uow.getNews_.SQLQuery<sp_GetLatestNews_Result>("sp_GetLatestNews");
            return result;
        }
    }
}