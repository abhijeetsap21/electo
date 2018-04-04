using electo.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace electo.Models.Repositories
{
    public class PollingBoothService: IPollingBooth
    {
        private readonly UnitOfWork uow;
        public PollingBoothService()
        {
            uow = new UnitOfWork();
        }

        public IEnumerable<sp_pollingBoothList_Result> get_PollingBoothList(int stateId, int LSCID, int VSCID, int wardID)
        {
            var LSCID_ = new SqlParameter("lokSabhaId", SqlString.Null);
            var stateId_ = new SqlParameter("@stateId", SqlString.Null);
            var VSC_ID_ = new SqlParameter("@vidhansabhaID", SqlString.Null);
            var ward_id_ = new SqlParameter("@wardID", SqlString.Null);
            if (LSCID != 0)
            {
                LSCID_ = new SqlParameter("@lokSabhaId", LSCID);
            }
            if (stateId != 0)
            {
                stateId_ = new SqlParameter("@stateId", stateId);
            }
            if (VSCID != 0)
            {
                VSC_ID_ = new SqlParameter("@vidhansabhaID", VSCID);
            }
            if (wardID != 0)
            {
                ward_id_ = new SqlParameter("@wardID", wardID);
            }

            var _pollingBoothListList = uow.sp_getVidhanSabhaLsit_Result_.SQLQuery<sp_pollingBoothList_Result>("sp_pollingBoothList @stateId,@lokSabhaId, @vidhansabhaID,@wardID", stateId_, LSCID_, VSC_ID_, ward_id_).ToList();
            return _pollingBoothListList;
        }
        

        public int createPollingBooth(pollingBooth pollingBooth_)
        {
            int result;
            try
            {
                uow.createPollingBooth_.Add(pollingBooth_);
                result = 1;
            }
            catch (Exception e)
            {
                result = 0;
            }
            return result;
        }

        public IEnumerable<sp_getPoolingBoothByCampignID_Result> get_PollingBoothListByCampaignID(Int64 CampaignID)
        {
            var CampaignID_ = new SqlParameter("@CampignID", CampaignID);
            var _pollingBoothListList = uow.sp_pollingBoothList_Result_.SQLQuery<sp_getPoolingBoothByCampignID_Result>("sp_getPoolingBoothByCampignID @CampignID", CampaignID_).ToList();
            return _pollingBoothListList;
        }

        public int AssignPollingBoothToAssignPollingBoothIncharge(AssignPollingBoothToPollingBoothIncharge oAssignPollingBoothToPollingBoothIncharge)
        {
            int result;

            pollingBooth_andInchargRelationship opollingBooth_andInchargRelationship = new pollingBooth_andInchargRelationship();
            opollingBooth_andInchargRelationship.campaignID = oAssignPollingBoothToPollingBoothIncharge.campaignid;
            opollingBooth_andInchargRelationship.createdBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            opollingBooth_andInchargRelationship.dataIsCreated = BaseUtil.GetCurrentDateTime();
            opollingBooth_andInchargRelationship.dataIsUpdated = BaseUtil.GetCurrentDateTime();
            opollingBooth_andInchargRelationship.modifiedBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            opollingBooth_andInchargRelationship.pollingBoothID = oAssignPollingBoothToPollingBoothIncharge.PollingBoothID;
            opollingBooth_andInchargRelationship.volunteerID = oAssignPollingBoothToPollingBoothIncharge.voluntearID;
            opollingBooth_andInchargRelationship.isActive = true;
            try
            {
                uow.pollingBooth_andInchargRelationship_.Add(opollingBooth_andInchargRelationship);
                result = 1;
            }

            catch (Exception e)
            {
                result = 0;
            }
            return result;
        }

    
    }
}