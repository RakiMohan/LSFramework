// --------------------------------------------------------------------------------------------------------------------
//<copyright file{get;set;}//"SubmitCandidateMethodModel.cs" company{get;set;}//"DCR Workforce Inc">
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

    public class SubmitCandidateMethodModel
    {
        public string str_BrowserName { get; set; }//SubmitCandidate_Data["P1"].ToString().Trim();
        public string strClientName { get; set; }// SubmitCandidate_Data["P5"].ToString().Trim();
        public string strMainMenuLink { get; set; }// SubmitCandidate_Data["P6"].ToString().Trim();
        public string strSubMenuLink { get; set; }// SubmitCandidate_Data["P7"].ToString().Trim();
        public string str_Link_ReqNumber { get; set; }// SubmitCandidate_Data["P8"].ToString().Trim();
        public string str_Link_SearchCandidate { get; set; }// SubmitCandidate_Data["P9"].ToString().Trim();
        public string str_Txt_Last4DigitsSSN { get; set; }// SubmitCandidate_Data["P10"].ToString().Trim();
        public string str_Txt_LastName { get; set; }// SubmitCandidate_Data["P11"].ToString().Trim();
        public string str_Txt_FirstName { get; set; }// SubmitCandidate_Data["P12"].ToString().Trim();
        public string str_Txt_MiddleName { get; set; }// SubmitCandidate_Data["P13"].ToString().Trim();
        public string str_Select_Suffix { get; set; }// SubmitCandidate_Data["P14"].ToString().Trim();
        public string str_Txt_LocationCity { get; set; }// SubmitCandidate_Data["P15"].ToString().Trim();
        public string str_Select_State { get; set; }// SubmitCandidate_Data["P16"].ToString().Trim();
        public string str_RadioButton_Available { get; set; }// SubmitCandidate_Data["P17"].ToString().Trim();
        public string str_Txt_AvailableDate { get; set; }// SubmitCandidate_Data["P18"].ToString().Trim();
        public string str_Txt_ATSID { get; set; }// SubmitCandidate_Data["P19"].ToString().Trim();
        public string str_Txt_Keywords { get; set; }// SubmitCandidate_Data["P20"].ToString().Trim();
        public string str_Select_MyResumes { get; set; }// SubmitCandidate_Data["P21"].ToString().Trim();
        public string str_Select_Recruiter { get; set; }// SubmitCandidate_Data["P22"].ToString().Trim();
        public string str_RadioButton_MilitaryEmployment { get; set; }// SubmitCandidate_Data["P23"].ToString().Trim();
        public string str_Select_SecurityClearance { get; set; }// SubmitCandidate_Data["P24"].ToString().Trim();
        public string str_RadioButton_SecurityClearance { get; set; }// SubmitCandidate_Data["P25"].ToString().Trim();
        public string str_Txt_UploadFilePath { get; set; }// SubmitCandidate_Data["P26"].ToString().Trim();
        public string str_Button_Save { get; set; }// SubmitCandidate_Data["P27"].ToString().Trim();
        public string str_Button_SaveConfirmOK { get; set; }// SubmitCandidate_Data["P28"].ToString().Trim();
        public string str_Button_Search { get; set; }// SubmitCandidate_Data["P29"].ToString().Trim();
        public string str_Button_addcandidatetoresumebank { get; set; }// SubmitCandidate_Data["P30"].ToString().Trim();
        public string str_Link_SubmitReq { get; set; }// SubmitCandidate_Data["P31"].ToString().Trim();
        public string strSelectSkills_Years { get; set; }// SubmitCandidate_Data["P36"].ToString().Trim();
        public string strRadiobtnSkills_Level { get; set; }// SubmitCandidate_Data["P37"].ToString().Trim();
        public string str_Txt_CandidatePayRate { get; set; }// SubmitCandidate_Data["P50"].ToString().Trim();
        public string str_Txt_CandidateOTPayRate { get; set; }// SubmitCandidate_Data["P51"].ToString().Trim();
        public string str_Txt_BillRate { get; set; }// SubmitCandidate_Data["P52"].ToString().Trim();
        public string str_Txt_OTBillRate { get; set; }// SubmitCandidate_Data["P53"].ToString().Trim();
        public string str_Button_SubmitToRequirement { get; set; }// SubmitCandidate_Data["P55"].ToString().Trim();
        public string str_RadioButton_RetireeRadio { get; set; }// SubmitCandidate_Data["P33"].ToString().Trim();



        // Mass Uplaod Candidates
        public string str_Link_UploadFile { get; set; }//SubmitCandidate_Data["72"].Trim();
        public string str_Txt_MassUploadFilePath { get; set; }// SubmitCandidate_Data["P73"].ToString().Trim();
        public string str_Txt_Comment { get; set; }// SubmitCandidate_Data["P74"].ToString().Trim();
        public string str_Btn_Upload { get; set; }// SubmitCandidate_Data["P75"].ToString().Trim();
        public string str_Btn_Yes_Action_MassUpload { get; set; }// SubmitCandidate_Data["P76"].ToString().Trim();
        public string str_Btn_OK_MassUpload { get; set; }// SubmitCandidate_Data["P77"].ToString().Trim();
        public string str_Btn_Close_MassUpload { get; set; }// SubmitCandidate_Data["P78"].ToString().Trim();
        public string str_Txt_LastName_LastName { get; set; }
        public string str_Txt_FirstName_FirstName { get; set; }
        public string str_Txt_LocationCity_LocationCity { get; set; }// SubmitCandidate_Data["P15"].ToString().Trim();
        public string str_Select_State_StateID { get; set; }// SubmitCandidate_Data["P16"].ToString().Trim();
        public string str_RadioButton_Available_AvailableStatus1 { get; set; }// SubmitCandidate_Data["P17"].ToString().Trim();
        public string str_Txt_ATSID_ATSIDField { get; set; }// SubmitCandidate_Data["P17"].ToString().Trim();
        public string str_Select_CandidatesUnder_MyResumesID { get; set; }// SubmitCandidate_Data["P19"].ToString().Trim();
        //     public string str_Txt_LastName_LastName { get; set; }// SubmitCandidate_Data["P9"].ToString().Trim();
        //     public string str_Txt_FirstName_FirstName { get; set; }// SubmitCandidate_Data["P10"].ToString().Trim();
        public string str_select_State_State { get; set; }// SubmitCandidate_Data["P15"].ToString().Trim();
        public string str_Txt_SearchCand { get; set; }// SubmitCandidate_Data["P9"].ToString().Trim();
        public string str_DraftRequirementNUmber_CLSRNumber { get; set; }// SubmitCandidate_Data["P6"].ToString().Trim();

    }
}
