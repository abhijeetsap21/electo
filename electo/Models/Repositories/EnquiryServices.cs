using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using electo.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static electo.Models.SP_Models.StoredProcedureModels;
using System.Data.SqlTypes;

namespace electo.Models.Repositories
{
    public class EnquiryServices : IEnquiryServices
    {
        private readonly UnitOfWork uow;
        public EnquiryServices()
        {
            uow = new UnitOfWork();
        }

        public IEnumerable<enquiryType> getEnquiryTypes()
        {
            var _objelectionType = uow.enquiryType.GetAll().ToList();
            return _objelectionType;
        }

        public IEnumerable<sp_GetNewEnquiries_Result> GetNewEnquiries_Result(string enquirytype, string date, string mobile, bool isTaskCompleted)
        {
            var enquirytype_ = new SqlParameter("@enquirytype", SqlString.Null);
            if (enquirytype != "")
            {
                enquirytype_ = new SqlParameter("@enquirytype", enquirytype);
            }
            
            var date_ = new SqlParameter("@date", SqlString.Null);
            DateTime date__;
            if (date == "")
            {
                date__ = DateTime.Now;
                date_ = new SqlParameter("@date", date__);
            }
            else
            {
                date__ = Convert.ToDateTime(date);
                date_ = new SqlParameter("@date", date__);
            }
              
                  
            var mobile_ = new SqlParameter("@mobile", mobile);
            var isTaskCompleted_ = new SqlParameter("@isTaskCompleted", isTaskCompleted);
            var EnquiryResult = uow.sp_GetNewEnquiries_Result.SQLQuery<sp_GetNewEnquiries_Result>("sp_GetNewEnquiries @enquirytype,@date,@mobile,@isTaskCompleted", enquirytype_, date_, mobile_, isTaskCompleted_).ToList();
            return EnquiryResult;
        }

        public enquiry get(long eID)
        {
            var enquiryDetails = uow.GetEnquiryDetails.GetByID(eID);
            return enquiryDetails;
        }

        public enquiry _save(enquiry _enq)
        {
            try
            {
                _enq.dataIsUpdated = BaseUtil.GetCurrentDateTime();
                _enq.modifiedBy = Convert.ToInt64(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
                uow.saveDetails.Update(_enq);
            }
            catch (Exception e)
            {

            }
            return _enq;
        }
        public enquiry create(enquiry _enq)
        {
            try
            {
                _enq.dataIsCreated = BaseUtil.GetCurrentDateTime();             
                _enq.dataIsUpdated = BaseUtil.GetCurrentDateTime();
                _enq.modifiedBy = Convert.ToInt64(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
                uow.saveDetails.Add(_enq);
            }
            catch   {}
            return _enq;
        }
    }
}