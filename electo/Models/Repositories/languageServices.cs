using electo.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace electo.Models.Repositories
{
    public class languageServices: IlanguageServices
    {
            private readonly UnitOfWork uow;
            public languageServices()
            {
                uow = new UnitOfWork();
            }

            public IEnumerable<language> getAll_LangaugeList()
            {                
                var _LangaugeList = uow.language_.GetAll().ToList();
                return _LangaugeList;
            }
        public int create(language Olanguage)
        {
            int result = 0;
            
            try
            {
                uow.language_.Add(Olanguage);
                result = 1;
            }
            catch { }
            return result;
        }

    }
}