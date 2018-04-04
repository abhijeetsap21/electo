using electo.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using electo.Models;
using System.Data.SqlTypes;

namespace electo.Models.Repositories
{
    public class PoliticalPartyService: IPoliticalPartyService
    {

        private readonly UnitOfWork uow;
        
        public PoliticalPartyService()
        {           
            uow = new UnitOfWork();            
        }

        public IEnumerable<sp_politicalPartyList_Result> getAll_PoliticalPartyListByStateID( int stateId, string PoliticalPartyName)
        {            
            var stateId_ = new SqlParameter("@stateID", stateId);
            var partyName_ = new SqlParameter("@partyName", PoliticalPartyName);
            var _sp_politicalPartyList_Result = uow.sp_politicalPartyList_Result_.SQLQuery<sp_politicalPartyList_Result>("sp_politicalPartyList @stateID,  @partyName", stateId_, partyName_).ToList();
            return _sp_politicalPartyList_Result;
        }
        public int createParty(CreatePartyViewModel oCreatePartyViewModel)
        {

            var politicalPartyName_= new SqlParameter("@politicalPartyName ", oCreatePartyViewModel._politicalParty.politicalPartyName);
            var politicalPartyLogo_= new SqlParameter("@politicalPartyLogo", oCreatePartyViewModel._politicalParty.politicalPartyLogo);
            var politicalPartyWebsiteUrl_= new SqlParameter("@politicalPartyWebsiteUrl", oCreatePartyViewModel._politicalParty.politicalPartyWebsiteUrl);
            var politicalPartyEmail_ = new SqlParameter("@politicalPartyEmail", oCreatePartyViewModel._politicalParty.politicalPartyEmail);
            var dataIsCreated_ = new SqlParameter("@dataIsCreated", oCreatePartyViewModel._politicalParty.dataIsCreated);           
            var createdBy_= new SqlParameter("@createdBy", oCreatePartyViewModel._politicalParty.createdBy);          
               
            var districtID_ = new SqlParameter("@districtID", oCreatePartyViewModel._politicalPartyAddress.districtID);
            var stateId_ = new SqlParameter("@stateID", oCreatePartyViewModel._politicalPartyAddress.stateID);

            var plotNo_ = new SqlParameter("@plotNo", SqlString.Null);
            if (oCreatePartyViewModel._politicalPartyAddress.plotNo != null)
            {
                 plotNo_ = new SqlParameter("@plotNo", oCreatePartyViewModel._politicalPartyAddress.plotNo);
            }


          

            var streetNo_ = new SqlParameter("@streetNo", SqlString.Null);
            if (oCreatePartyViewModel._politicalPartyAddress.streetNo != null)
            {
             streetNo_ = new SqlParameter("@streetNo", oCreatePartyViewModel._politicalPartyAddress.streetNo);
            }
            var address1_ = new SqlParameter("@address1", SqlString.Null);
            if (oCreatePartyViewModel._politicalPartyAddress.address1!= null)
            {             
                 address1_ = new SqlParameter("@address1", oCreatePartyViewModel._politicalPartyAddress.address1);
            }
            
            var address2_ = new SqlParameter("@address2", SqlString.Null);
            if (oCreatePartyViewModel._politicalPartyAddress.address2 != null)
            {
                address2_ = new SqlParameter("@address2", oCreatePartyViewModel._politicalPartyAddress.address2);
            }
            var pincode_ = new SqlParameter("@pincode", oCreatePartyViewModel._politicalPartyAddress.pincode);
            var telephone_ = new SqlParameter("@telephone", oCreatePartyViewModel._politicalPartyAddress.telephone);

            int result = 0;
            try
            { 

                result = uow.sp_createParty_Result_.SQLQuery<int>("sp_createParty @politicalPartyName, @politicalPartyLogo, @politicalPartyWebsiteUrl, @politicalPartyEmail, @dataIsCreated, @createdBy,  @districtID, @stateID, @plotNo, @streetNo, @address1, @address2, @pincode, @telephone",
                                                                                        politicalPartyName_, politicalPartyLogo_, politicalPartyWebsiteUrl_, politicalPartyEmail_, dataIsCreated_,  createdBy_, districtID_, stateId_, plotNo_, streetNo_, address1_, address2_, pincode_, telephone_).FirstOrDefault();
  
            }
            catch (Exception e)
            {               
            }
            return result;

        }



        public IEnumerable<sp_partyAddressList_Result> PoliticalPartyAddressList(int politicalPartyId)
        {

            var politicalPartyId_ = new SqlParameter("@politicalPartyID", politicalPartyId);

            var sp_partyAddressList_Result_ = uow.sp_partyAddressList_Result_.SQLQuery<sp_partyAddressList_Result>("sp_partyAddressList @politicalPartyID", politicalPartyId_).ToList();
            return sp_partyAddressList_Result_;
        }

        public bool saveNewAddress(politicalPartyAddress opoliticalPartyAddress)
        {
            bool result = false;

            try
            {
                uow.politicalPartyAddress_.Add(opoliticalPartyAddress);
                result = true;
            }
            catch (Exception e){ }
            return result;
        }
    }
}