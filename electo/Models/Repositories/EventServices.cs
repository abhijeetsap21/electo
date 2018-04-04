using electo.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using static electo.Models.SP_Models.StoredProcedureModels;

namespace electo.Models.Repositories
{
    public class EventServices : IEventServices
    {
        private readonly UnitOfWork uow;
        public EventServices()
        {
            uow = new UnitOfWork();
        }

        //IEnumerable<sp_Event_GetByCampaignId_Result> GetByCampaignId(long Id);
        public IEnumerable<sp_Event_GetByCampaignId_Result> GetByCampaignId(long Id)
        {
            var CampaignId = new SqlParameter("@CampaignId", Id);

            var objEventList = uow.sp_Event_GetByCampaignId_Result_.SQLQuery<sp_Event_GetByCampaignId_Result>("sp_Event_GetByCampaignId @CampaignId", CampaignId).ToList();

            if (objEventList != null)
            {
                return objEventList;
            }
            return null;
        }

        //IEnumerable<sp_Event_GetByEventTypeId_Result> GetByEventTypeId(long Id);
        public IEnumerable<sp_Event_GetByEventTypeId_Result> GetByEventTypeId(long Id)
        {
            var EventTypeId = new SqlParameter("@EventTypeId", Id);

            var objEventList = uow.sp_Event_GetByEventTypeId_Result_.SQLQuery<sp_Event_GetByEventTypeId_Result>("sp_Event_GetByEventTypeId @EventTypeId", EventTypeId).ToList();

            if (objEventList != null)
            {
                return objEventList;
            }
            return null;
        }

        public IEnumerable<sp_Event_GetByCampaignIdANDEventTypeID_Result> GetByCampaignIdANDEventTypeID(long Id,int EventTypeId)
        {
            var CampaignId = new SqlParameter("@CampaignId", Id);
            var eventTypeID_ = new SqlParameter("@eventTypeID", EventTypeId);
            var objEventList = uow.sp_Event_GetByCampaignId_Result_.SQLQuery<sp_Event_GetByCampaignIdANDEventTypeID_Result>("sp_Event_GetByCampaignIdANDEventTypeID @CampaignId, @eventTypeID", CampaignId, eventTypeID_).ToList();
            try
            {
                if (objEventList != null)
                {
                    return objEventList;
                }
            }
            catch { }
            return null;
        }
        public int createEvent(sp_createEvent osp_createEvent)
        {
            int result;

            var eventTypeID_ = new SqlParameter("@eventTypeID", osp_createEvent.eventTypeID);
            var campaignID_ = new SqlParameter("@campaignID", osp_createEvent.campaignID);
            var dataIsCreated_ = new SqlParameter("@dataIsCreated", BaseUtil.GetCurrentDateTime());
            var createdBy_ = new SqlParameter("@createdBy", osp_createEvent.createdBy);
            var eventTitle_ = new SqlParameter("@eventTitle", osp_createEvent.eventTitle);
            var eventDescription_ = new SqlParameter("@eventDescription", osp_createEvent.eventDescription);
            var mediaURL_ = new SqlParameter("@mediaURL", SqlString.Null);
            if (osp_createEvent.mediaURL != null)
            {
                mediaURL_ = new SqlParameter("@mediaURL", osp_createEvent.mediaURL);
            }

            try
            {
                // string  q = "sp_createEvent @eventTypeID='" + osp_createEvent.eventTypeID + "',@campaignID='" + osp_createEvent.campaignID + "',@dataIsCreated='" + BaseUtil.GetCurrentDateTime() + "',@createdBy='" + osp_createEvent .createdBy + "',@eventTitle='" + osp_createEvent.eventTitle + "',@eventDescription='" + osp_createEvent.eventDescription + "',@mediaURL='" + osp_createEvent.mediaURL+"'" ;
                result = uow.sp_createEvent_.SQLQuery<int>("sp_createEvent @eventTypeID,@campaignID,@dataIsCreated,@createdBy,@eventTitle,@eventDescription,@mediaURL", eventTypeID_, campaignID_, dataIsCreated_, createdBy_, eventTitle_, eventDescription_, mediaURL_).FirstOrDefault();
            }

            catch (Exception e)
            {
                result = 0;
            }
            return result;
        }
    }
}