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

    public class AddResumeSubmitCandidate
    {
        public string str_BrowserName { get; set; }//SubmitCandidate_Data["P1"].ToString().Trim();
        public string strClientName { get; set; } //SubmitCandidate_Data["P3"].ToString().Trim();
        public string strMainMenuLink { get; set; } //SubmitCandidate_Data["P4"].ToString().Trim();
        public string strSubMenuLink { get; set; } //SubmitCandidate_Data["P5"].ToString().Trim();
        public string Requirementnumber { get; set; } //SubmitCandidate_Data["P6"].ToString().Trim();
        public string ActionList { get; set; } //SubmitCandidate_Data["P7"].ToString().Trim();
        public string str_txt_LastName_LastName { get; set; }// SubmitCandidate_Data["P8"].ToString().Trim();
        public string str_txt_FirstName_FirstName { get; set; }// SubmitCandidate_Data["P9"].ToString().Trim();
        public string str_txt_MiddleName_MiddleName { get; set; }// SubmitCandidate_Data["P10"].ToString().Trim();
        public string str_txt_NickName_NickName { get; set; }// SubmitCandidate_Data["P11"].ToString().Trim();
        public string str_Select_SuffixName_SuffixName { get; set; }// SubmitCandidate_Data["P12"].ToString().Trim();
        public string str_TypeHead_ZipCode_ZipCode { get; set; }// SubmitCandidate_Data["P13"].ToString().Trim();
        public string str_TypeHead_Country_Country { get; set; }// SubmitCandidate_Data["P14"].ToString().Trim();
        public string str_TypeHead_State_State { get; set; }// SubmitCandidate_Data["P15"].ToString().Trim();
        public string str_TypeHead_city_city { get; set; }// SubmitCandidate_Data["P16"].ToString().Trim();
        public string str_Radio_Available { get; set; }// SubmitCandidate_Data["P17"].ToString().Trim();
        public string str_Date_Available_AvailableDate { get; set; }// SubmitCandidate_Data["P18"].ToString().Trim();
        public string str_Select_Recruiter_RecruiterName { get; set; }// SubmitCandidate_Data["P19"].ToString().Trim();
        public string str_Radio_PastPresentMilitaryEmployment { get; set; }// SubmitCandidate_Data["P20"].ToString().Trim();
        public string str_Txt_PastPresentMilitaryEmployment_EmploymentDetails { get; set; }// SubmitCandidate_Data["P21"].ToString().Trim();
        public string str_Txt_ATSID_ATSID { get; set; }// SubmitCandidate_Data["P22"].ToString().Trim();
        public string str_Resume_ResumeUpload_btnresumeupload { get; set; }// SubmitCandidate_Data["P23"].ToString().Trim();
        public string str_Button_AddCandidateResumePopup_OK { get; set; }// SubmitCandidate_Data["P24"].ToString().Trim();


        //2nd page
        public string str_txt_CandidateEmail_Email { get; set; }// SubmitCandidate_Data["P35"].ToString().Trim();
        public string str_txt_CandidateSummary_lbljustificationDescription { get; set; }// SubmitCandidate_Data["P36"].ToString().Trim();
        public string str_Select_EmploymentType_employmentTypeID { get; set; }// SubmitCandidate_Data["P37"].ToString().Trim();
        public string str_Select_SupplierLegalEntity_OperativeCompany { get; set; }// SubmitCandidate_Data["P38"].ToString().Trim();
        public string str_Radio_FormerEmployee { get; set; }// SubmitCandidate_Data["P39"].ToString().Trim();  
        public string str_Date_FromDate_fromDate1 { get; set; }// SubmitCandidate_Data["P40"].ToString().Trim();
        public string str_Date_ToDatetoDate1 { get; set; }// SubmitCandidate_Data["P41"].ToString().Trim();
        public string str_Txt_PID_jobTitle { get; set; }// SubmitCandidate_Data["P42"].ToString().Trim();
        public string str_Txt_FormerEmployeeUsername_FormerEmployee { get; set; }// SubmitCandidate_Data["P43"].ToString().Trim();
        public string str_Radio_FormerTVC { get; set; }// SubmitCandidate_Data["P44"].ToString().Trim();
        public string str_Date_FormerTVCFromDate_fromDate1 { get; set; }// SubmitCandidate_Data["P45"].ToString().Trim();
        public string str_Date_FormerTVCToDatetoDate1 { get; set; }// SubmitCandidate_Data["P46"].ToString().Trim();
        public string str_Txt_FormerTVCPID_jobTitle { get; set; }// SubmitCandidate_Data["P47"].ToString().Trim();
        public string str_Txt_FormerTVCUsername_ContractorDetails { get; set; }// SubmitCandidate_Data["P48"].ToString().Trim();
        public string str_Radio_FormerIntern { get; set; }// SubmitCandidate_Data["P49"].ToString().Trim();
        public string str_Date_RetireeDate_RetiredDate { get; set; }// SubmitCandidate_Data["P50"].ToString().Trim();
        public string str_Txt_FormerInternUsername_InternDetails { get; set; }// SubmitCandidate_Data["P51"].ToString().Trim();
        public string str_Radio_ExemptNonExempt { get; set; }// SubmitCandidate_Data["P52"].ToString().Trim();
        public string str_Txt_CandidatePayRate_supplierRegPayRate { get; set; }// SubmitCandidate_Data["P53"].ToString().Trim();
        public string str_Txt_CandidateOTPayRate_supplierOTPayRate { get; set; }// SubmitCandidate_Data["P54"].ToString().Trim();
        public string str_Txt_BillRate_supplierRegBillRate { get; set; }// SubmitCandidate_Data["P55"].ToString().Trim();
        public string str_Txt_OTBillRate_supplierOTBillRate { get; set; }// SubmitCandidate_Data["P56"].ToString().Trim();
        public string str_Txt_Last4DigitsofNationalID_STID1 { get; set; }// SubmitCandidate_Data["P57"].ToString().Trim();
        public string str_Select_BirthMonth_STID2 { get; set; }// SubmitCandidate_Data["P58"].ToString().Trim();
        public string str_Select_BirthDay_STID3 { get; set; }// SubmitCandidate_Data["P59"].ToString().Trim();
        public string str_PopUp_SubmitRequistion_Yes { get; set; }// SubmitCandidate_Data["P60"].ToString().Trim();
        public string str_PopUp_SubmitRequistion_Ok { get; set; }// SubmitCandidate_Data["P61"].ToString().Trim();

    }
}
