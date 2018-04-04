
function FIllDistrictDll(stateId) {
    debugger
    $.ajax({
        url: '/zone/getDistrictListByStateID',
        type: 'POST',
        datatype: 'application/json',
        contentType: 'application/json',
        data: JSON.stringify({
            stateId: +stateId
        }),
        success: function (result) {
            $("#districtID").html("");
            $("#districtID").append($('<option></option>').val('').html(' District '));
            $.each($.parseJSON(result), function (i, VSC) {
                $("#districtID").append($('<option></option>').val(VSC.districtID).html(VSC.districtName))
            })

        },
        error: function () {

            bootbox.alert({
                title: "Alert !",
                message: '<p>Whooaaa! Something went wrong..</p>',
                timeOut: 2000

            });
        },
    });
}

function FillMuncipartyDll(stateId) {
    debugger;
   

    $.ajax({
        url: '/zone/getMuncipalCorporationListByStateID',
        type: 'POST',
        datatype: 'application/json',
        contentType: 'application/json',
        data: JSON.stringify({
            stateId: +stateId
        }),
        success: function (result) {
            $("#ddl_muncipal").html("");
            $("#ddl_muncipal").append($('<option></option>').val('').html('Muncipal Corporation'));
            $.each($.parseJSON(result), function (i, VSC) {
                $("#ddl_muncipal").append($('<option></option>').val(VSC.municipalCorporationID).html(VSC.municipalCorporationName1))
            })

        },
        error: function () {

            bootbox.alert({
                title: "Alert !",
                message: '<p>Whooaaa! Something went wrong..</p>',
                timeOut: 2000

            });
        },
    });   
}

function FillZoneDll(stateId,MPCorporationID) {
    debugger;


    $.ajax({
        url: '/zone/getZoneListBymuncipalCorpID',
        type: 'POST',
        datatype: 'application/json',
        contentType: 'application/json',
        data: JSON.stringify({
            stateId: +stateId,
            MPCorporation: +MPCorporationID
        }),
        success: function (result) {
            $("#zoneID").html("");
            $("#zoneID").append($('<option></option>').val('').html(' Zone '));
            $.each($.parseJSON(result), function (i, VSC) {
                $("#zoneID").append($('<option></option>').val(VSC.zoneID).html(VSC.zoneName))
            })

        },
        error: function () {

            bootbox.alert({
                title: "Alert !",
                message: '<p>Whooaaa! Something went wrong..</p>',
                timeOut: 2000

            });
        },
    });
}

function FillLoKSabha(stateId)
    {
    $.ajax
   ({
       url: '/VidhanSabha/GetLOCKSABHAConstituencyLsit',
       type: 'POST',
       datatype: 'application/json',
       contentType: 'application/json',
       data: JSON.stringify({
           stateId: +stateId
       }),
       success: function (result) {
           $("#ddl_LKSC_Constituency").html("");
           $("#ddl_LKSC_Constituency").append($('<option></option>').val('').html(' Lock Sabha'));
           $.each($.parseJSON(result), function (i, VSC) {
               $("#ddl_LKSC_Constituency").append($('<option></option>').val(VSC.lokSabhaConstituencyID).html(VSC.lokSabhaConstituencyName))
           })

       },
       error: function () {

           bootbox.alert({
               title: "Alert !",
               message: '<p>Whooaaa! Something went wrong..</p>',
               timeOut: 2000

           });
       },
   });

}

function FillVidhanSabha(stateId) {
    $.ajax
   ({
       url: '/VidhanSabha/getvidhanSabhaConstituencyByStateID',
       type: 'POST',
       datatype: 'application/json',
       contentType: 'application/json',
       data: JSON.stringify({
           stateId: +stateId
       }),
       success: function (result) {
           $("#ddl_VKSC_Constituency").html("");
           $("#ddl_VKSC_Constituency").append($('<option></option>').val('').html(' Vidhan Sabha'));
           $.each($.parseJSON(result), function (i, VSC) {
               $("#ddl_VKSC_Constituency").append($('<option></option>').val(VSC.vidhanSabhaConstituencyID).html(VSC.vidhanSabhaConstituencyName))
           })

       },
       error: function () {

           bootbox.alert({
               title: "Alert !",
               message: '<p>Whooaaa! Something went wrong..</p>',
               timeOut: 2000

           });
       },
   });

}

function getvidhanSabhaConstituencyByStateIDANDLKSCID(stateId, loksabhaID) {
    $.ajax
   ({
       url: '/VidhanSabha/getvidhanSabhaConstituencyByStateIDANDLKSCID',
       type: 'POST',
       datatype: 'application/json',
       contentType: 'application/json',
       data: JSON.stringify({
           stateId: +stateId,
           LSCID: +loksabhaID
       }),
       success: function (result) {
           $("#ddl_VKSC_Constituency").html("");
           $("#ddl_VKSC_Constituency").append($('<option></option>').val('').html(' Vidhan Sabha'));
           $.each($.parseJSON(result), function (i, VSC) {
               $("#ddl_VKSC_Constituency").append($('<option></option>').val(VSC.vidhanSabhaConstituencyID).html(VSC.vidhanSabhaConstituencyName))
           })

       },
       error: function () {

           bootbox.alert({
               title: "Alert !",
               message: '<p>Whooaaa! Something went wrong..</p>',
               timeOut: 2000

           });
       },
   });

}
function FillWardByVidhanSabhaConsistuencyID(vidhanSabhaConstituencyID) {
    debugger
    $.ajax
   ({       
       url: '/Ward/getWardByStateIDAndMUncipalCorporationID',
       type: 'POST',
       datatype: 'application/json',
       contentType: 'application/json',
       data: JSON.stringify({
           stateId: 0,
           districtId: 0,
           MPCorporation: 0,
           vidhanSabhaConstituencyID: +vidhanSabhaConstituencyID
       }),
       success: function (result) {
           $("#ddl_Ward").html("");
           $("#ddl_Ward").append($('<option></option>').val('').html(' Ward'));
           $.each($.parseJSON(result), function (i, VSC) {
               $("#ddl_Ward").append($('<option></option>').val(VSC.wardID).html(VSC.wardName))
           })

       },
       error: function () {

           bootbox.alert({
               title: "Alert !",
               message: '<p>Whooaaa! Something went wrong..</p>',
               timeOut: 2000

           });
       },
   });

}

function FillWard(stateId, MPCorporation, districtId) {
    debugger
    var vidhanSabhaConstituencyID = 0;
    $.ajax
   ({
       url: '/Ward/getWardByStateIDAndMUncipalCorporationID',
       type: 'POST',
       datatype: 'application/json',
       contentType: 'application/json',
       data: JSON.stringify({
           stateId: +stateId,
           districtId: +districtId,
           MPCorporation: +MPCorporation,
           vidhanSabhaConstituencyID:+vidhanSabhaConstituencyID
       }),
       success: function (result) {
           $("#ddl_Ward").html("");
           $("#ddl_Ward").append($('<option></option>').val('').html(' Ward'));
           $.each($.parseJSON(result), function (i, VSC) {
               $("#ddl_Ward").append($('<option></option>').val(VSC.wardID).html(VSC.wardName))
           })

       },
       error: function () {

           bootbox.alert({
               title: "Alert !",
               message: '<p>Whooaaa! Something went wrong..</p>',
               timeOut: 2000

           });
       },
   });

}

function FillPollingBooth(wardID) {
    debugger
    $.ajax
   ({
       url: '/PollingBooth/getPollingBoothList',
       type: 'POST',
       datatype: 'application/json',
       contentType: 'application/json',
       data: JSON.stringify({
           wardID: +wardID
       }),
       success: function (result) {
           $("#ddl_PollingBooth").html("");
           $("#ddl_PollingBooth").append($('<option></option>').val('').html(' Ward'));
           $.each($.parseJSON(result), function (i, VSC) {
               $("#ddl_PollingBooth").append($('<option></option>').val(VSC.pollingBoothID).html(VSC.pollingBoothName))
           })

       },
       error: function () {

           bootbox.alert({
               title: "Alert !",
               message: '<p>Whooaaa! Something went wrong..</p>',
               timeOut: 2000

           });
       },
   });

}   

function FillAreaDDL(wardid) {
    debugger
    $.ajax
   ({       
       url: '/Area/getAll_areaList',
       type: 'POST',
       datatype: 'application/json',
       contentType: 'application/json',
       data: JSON.stringify({
           wardID: +wardid         
       }),
       success: function (result) {
           $("#areaID").html("");
           $("#areaID").append($('<option></option>').val('').html(' Area Name'));
           $.each($.parseJSON(result), function (i, VSC) {
               $("#areaID").append($('<option></option>').val(VSC.areaID).html(VSC.areaName))
           })

       },
       error: function () {

           bootbox.alert({
               title: "Alert !",
               message: '<p>Whooaaa! Something went wrong..</p>',
               timeOut: 2000

           });
       },
   });

}