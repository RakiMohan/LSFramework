// --------------------------------------------------------------------------------------------------------------------
//<copyright file="SubmitCandidateAddResume" company="DCR Workforce Inc">
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

    public class SubmitCandidateAddResume
    {
        public string str_BrowserName { get; set; }//SubmitCandidate_Data["P1"].ToString().Trim();
        public string strClientName { get; set; }        
        public string str_Link_ReqNumber {get;set;}// SubmitCandidate_Data["P8"].ToString().Trim();
        public string str_Txt_Last4DigitsSSN {get;set;}// SubmitCandidate_Data["P10"].ToString().Trim();
        public string str_Txt_LastName {get;set;}// SubmitCandidate_Data["P11"].ToString().Trim();
        public string str_Txt_FirstName {get;set;}// SubmitCandidate_Data["P12"].ToString().Trim();
        public string str_Txt_MiddleName {get;set;}// SubmitCandidate_Data["P13"].ToString().Trim();
        public string str_Select_Suffix {get;set;}// SubmitCandidate_Data["P14"].ToString().Trim();
        public string str_Txt_LocationCity {get;set;}// SubmitCandidate_Data["P15"].ToString().Trim();
        public string str_Select_State {get;set;}// SubmitCandidate_Data["P16"].ToString().Trim();
        public string str_RadioButton_Available {get;set;}// SubmitCandidate_Data["P17"].ToString().Trim();
        public string str_Txt_AvailableDate {get;set;}// SubmitCandidate_Data["P18"].ToString().Trim();
        public string str_Txt_ATSID {get;set;}// SubmitCandidate_Data["P19"].ToString().Trim();
        public string str_Txt_Keywords {get;set;}// SubmitCandidate_Data["P20"].ToString().Trim();
        public string str_Select_MyResumes {get;set;}// SubmitCandidate_Data["P21"].ToString().Trim();
        public string str_Select_Recruiter {get;set;}// SubmitCandidate_Data["P22"].ToString().Trim();
        public string str_RadioButton_MilitaryEmployment {get;set;}// SubmitCandidate_Data["P23"].ToString().Trim();
        public string str_Select_SecurityClearance {get;set;}// SubmitCandidate_Data["P24"].ToString().Trim();
        public string str_RadioButton_SecurityClearance {get;set;}// SubmitCandidate_Data["P25"].ToString().Trim();
        public string str_Txt_UploadFilePath {get;set;}// SubmitCandidate_Data["P26"].ToString().Trim();
        public string str_Button_Save {get;set;}// SubmitCandidate_Data["P27"].ToString().Trim();
        public string str_Button_SaveConfirmOK {get;set;}// SubmitCandidate_Data["P28"].ToString().Trim();
        public string str_select_Languages { get; set; } // SubmitCandidate_Data["P57"].ToString().Trim();
        public string str_Radio_Employement { get; set; } // SubmitCandidate_Data["P58"].ToString().Trim();
        public string str_Txt_Employement { get; set; } // SubmitCandidate_Data["P59"].ToString().Trim();
        public string str_select_locationorcityLocationCity { get; set; }
        public string str_Select_Suffix_SuffixName { get; set; }
        public string str_select_Country_country { get; set; }
        public string str_Txt_LastName_LastName { get; set; }
        public string str_Txt_FirstName_FirstName { get; set; }
        public string str_select_State_State { get; set; }

    }
}
