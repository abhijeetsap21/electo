using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static electo.Models.SP_Models.StoredProcedureModels;

namespace electo.Models.IRepositories
{
    interface IEnquiryServices
    {
        IEnumerable<sp_GetNewEnquiries_Result> GetNewEnquiries_Result(string enquirytype, string date, string mobile, bool isTaskCompleted);
        IEnumerable<enquiryType> getEnquiryTypes();
        enquiry get(long eID);
        enquiry _save(enquiry _enq);
        enquiry create(enquiry _enq);
    }
}
