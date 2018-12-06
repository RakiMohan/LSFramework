// --------------------------------------------------------------------------------------------------------------------
//<copyright file{get;set;}//"AcceptWorkOrderModel.cs" company{get;set;}//"DCR Workforce Inc">
//   Copyright (c) DCR Workforce Inc. All rights reserved.
//   This code and information should not be copied and used outside of DCR Workforce Inc.
// </copyright>
// <summary>
//   Builds the Container for the Autofac IOC.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmartTrack.DataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AcceptWorkOrderModel
    {
        public string strClientName { get; set; }// AcceptWorkOrder_Data["P5"].ToString().Trim();
        public string strMainMenuLink { get; set; }// AcceptWorkOrder_Data["P6"].ToString().Trim();
        public string strSubMenuLink { get; set; }// AcceptWorkOrder_Data["P7"].ToString().Trim();
        public string str_Link_ReqNumber { get; set; }// AcceptWorkOrder_Data["P8"].ToString().Trim();
        public string str_Link_CandidatesWithOffers { get; set; }// AcceptWorkOrder_Data["P9"].ToString().Trim();
        public string str_CandidateName { get; set; }// AcceptWorkOrder_Data["P10"].ToString().Trim();
        public string str_Link_AcceptWorkOrder_Data { get; set; }// AcceptWorkOrder_Data["P11"].ToString().Trim();
        public string str_Txt_homephone { get; set; }// AcceptWorkOrder_Data["P12"].ToString().Trim();
        public string str_Txt_email { get; set; }// AcceptWorkOrder_Data["P13"].ToString().Trim();
        public string str_Txt_address1 { get; set; }// AcceptWorkOrder_Data["P14"].ToString().Trim();
        public string str_Txt_address2 { get; set; }// AcceptWorkOrder_Data["P15"].ToString().Trim();
        public string str_Txt_city { get; set; }// AcceptWorkOrder_Data["P16"].ToString().Trim();
        public string str_Txt_zip { get; set; }// AcceptWorkOrder_Data["P17"].ToString().Trim();
        public string str_Select_state { get; set; }// AcceptWorkOrder_Data["P18"].ToString().Trim();
        public string str_Txt_emergencyContact1Name { get; set; }// AcceptWorkOrder_Data["P19"].ToString().Trim();
        public string str_Txt_emergencyContact1Phone { get; set; }// AcceptWorkOrder_Data["P20"].ToString().Trim();
        public string str_Txt_emergencyContact2Name { get; set; }// AcceptWorkOrder_Data["P21"].ToString().Trim();
        public string str_Txt_emergencyContact2Phone { get; set; }// AcceptWorkOrder_Data["P22"].ToString().Trim();
        public string str_Select_SCountry { get; set; }// AcceptWorkOrder_Data["P23"].ToString().Trim();
        public string str_Select_Sstate { get; set; }// AcceptWorkOrder_Data["P24"].ToString().Trim();
        public string str_Select_SCounty { get; set; }// AcceptWorkOrder_Data["P25"].ToString().Trim();
        public string str_Btn_Accept_Submit { get; set; }// AcceptWorkOrder_Data["P40"].ToString().Trim();
        public string str_Btn_AcceptWorkOrder_Data_Submit_Confirm { get; set; }// AcceptWorkOrder_Data["P41"].ToString().Trim();
        public string str_Btn_AcceptWorkOrder_Data_Submit_Confirm_Ok { get; set; }// AcceptWorkOrder_Data["P42"].ToString().Trim();
        public string str_Link_RejectWorkOrder { get; set; }// AcceptWorkOrder_Data["P43"].ToString().Trim();
        public string str_Txt_RejectWorkOrderComment { get; set; }// AcceptWorkOrder_Data["P44"].ToString().Trim();
        public string str_Button_Reject { get; set; }// AcceptWorkOrder_Data["P45"].ToString().Trim();
        public string str_Radiobtn_DoesthisresourcehaveaSocialSecurityNumber_isSSNAvailable { get; set; }// AcceptWorkOrder_Data["P24"].ToString().Trim();
        public string str_txt_SocailSecurityNumber_candidateSSN { get; set; }// AcceptWorkOrder_Data["P25"].ToString().Trim();
        public string str_txt_ConfirmSocailSecurityNumber_candidateSSNConfirm { get; set; }// AcceptWorkOrder_Data["P26"].ToString().Trim();
        public string str_Date_DateofBirth_DOB { get; set; }// AcceptWorkOrder_Data["P44"].ToString().Trim();
        public string str_Select_Race_nativeAmericanID { get; set; }// AcceptWorkOrder_Data["P45"].ToString().Trim();
        public string str_Select_Gender_Gender { get; set; }// AcceptWorkOrder_Data["P46"].ToString().Trim();
        public string str_Txt_PhoneNumber_homephone { get; set; }
        public string str_Txt_Email_email { get; set; }
        public string str_Txt_AddressLine1_address1 { get; set; }
        public string str_Txt__AddressLine2_address2 { get; set; }
        public string str_Txt_City_city { get; set; }
        public string str_Txt_Zip_zip { get; set; }
        public string str_Select_State_state { get; set; }
        public string str_Txt_EmergencyContactName_emergencyContact1Name { get; set; }
        public string str_Txt_EmergencyContactPhone_emergencyContact1Phone { get; set; }
        public string str_Txt_2ndEmergencyContactName_emergencyContact2Name { get; set; }
        public string str_Txt_2ndEmergencyContactPhone_emergencyContact2Phone { get; set; }
        public string str_Select_Country_SCountry { get; set; }
        public string str_Select_State_SState { get; set; }
        public string str_Select__County_SCounty { get; set; }

    }
}
