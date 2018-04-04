using electo.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace electo.Models.Repositories
{

    public class biographyServices: IbiographyServices
    {
        private readonly UnitOfWork uow;
        public biographyServices()
        {
            uow = new UnitOfWork();
        }

        public int createbiography(Biography_s Biography_s_)
        {
            int result=0;
            try
            {
                Biography_s_.createdBy = Convert.ToInt64(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
                Biography_s_.modifiedBy = Convert.ToInt64(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
                Biography_s_.dataIsCreated = BaseUtil.GetCurrentDateTime();
                Biography_s_.dataIsUpdated = BaseUtil.GetCurrentDateTime();
                uow.Biography_s_.Add(Biography_s_);
                result = 1;
            }

            catch (Exception e)
            {
                result = 0;
            }
            return result;
        }
            public Biography_s Find(int id) {
            var Biography_s_ = uow.Biography_s_.GetByID(id);
            if (Biography_s_ != null)
            {
                return Biography_s_;
            }
            else {
                return null;
            }
        }

        public int updatebiography(Biography_s Biography_s_)
        {
            int result = 0;
            try
            {
              
                Biography_s_.modifiedBy = Convert.ToInt64(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));              
                Biography_s_.dataIsUpdated = BaseUtil.GetCurrentDateTime();
                uow.Biography_s_.Update(Biography_s_);
                result = 1;
            }

            catch (Exception e)
            {
                result = 0;
            }
            return result;
        }


        public IEnumerable<sp_getAllBiographiesStartwithLetter_Result> getListStartWith(string  Variable_)
        {
            var Variable_letter = new SqlParameter("@NAME", SqlString.Null);
            if (Variable_!=null)
            {
                Variable_letter = new SqlParameter("@NAME", Variable_);
            }
            
            try
            {
                return uow.Biography_s_.SQLQuery<sp_getAllBiographiesStartwithLetter_Result>("sp_getAllBiographiesStartwithLetter @NAME", Variable_letter).ToList();
            }
            catch (Exception e){ }
                return null;
            }
       }
    
}