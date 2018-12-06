// --------------------------------------------------------------------------------------------------------------------
//<copyright file{get;set;}//"SubmitCandidateResumeModel.cs" company{get;set;}//"DCR Workforce Inc">
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

    public class SubmitCandidateResumeModel
    {
        public string strClientName { get; set; }// SubmitCandidate_Data["P5"].ToString().Trim();
        public string str_Button_SaveConfirmOK { get; set; }// SubmitCandidate_Data["P28"].ToString().Trim();
        public string str_Button_Search { get; set; }// SubmitCandidate_Data["P29"].ToString().Trim();
        public string str_Button_addcandidatetoresumebank { get; set; }// SubmitCandidate_Data["P30"].ToString().Trim();
        public string str_Link_SubmitReq { get; set; }// SubmitCandidate_Data["P31"].ToString().Trim();
        public string str_Select_employmentTypeID { get; set; }// SubmitCandidate_Data["P36"].ToString().Trim();
        public string strSelectSkills_Years { get; set; }// SubmitCandidate_Data["P37"].ToString().Trim();
        public string strRadiobtnSkills_Level { get; set; }// SubmitCandidate_Data["P38"].ToString().Trim();
        public string strRadiobtnFormer_Employee { get; set; }// SubmitCandidate_Data["P40"].ToString().Trim();
        public string strRadiobtnFormer_Contractor { get; set; }// SubmitCandidate_Data["P45"].ToString().Trim();
        public string str_Txt_CandidatePayRate { get; set; }// SubmitCandidate_Data["P51"].ToString().Trim();
        public string str_Txt_CandidateOTPayRate { get; set; }// SubmitCandidate_Data["P52"].ToString().Trim();
        public string str_Txt_BillRate { get; set; }// SubmitCandidate_Data["P53"].ToString().Trim();
        public string str_Txt_OTBillRate { get; set; }// SubmitCandidate_Data["P54"].ToString().Trim();
        public string str_Txt_STID { get; set; }// SubmitCandidate_Data["P55"].ToString().Trim();
        public string str_Button_SubmitToRequirement { get; set; }// SubmitCandidate_Data["P56"].ToString().Trim();
        public string str_Txt_candidateSSN { get; set; }// SubmitCandidate_Data["P57"].ToString().Trim();
        public string str_Date_DOB { get; set; }// SubmitCandidate_Data["P58"].ToString().Trim();
        public string str_Radio_IsSSNValid { get; set; }// SubmitCandidate_Data["P59"].ToString().Trim();
        public string str_Txt_address1 { get; set; }// SubmitCandidate_Data["P60"].ToString().Trim();
        public string str_Txt_city { get; set; }// SubmitCandidate_Data["P61"].ToString().Trim();
        public string str_Select_state { get; set; }// SubmitCandidate_Data["P62"].ToString().Trim();
        public string str_Select_country { get; set; }// SubmitCandidate_Data["P63"].ToString().Trim();
        public string str_Txt_zipcode { get; set; }// SubmitCandidate_Data["P64"].ToString().Trim();
        public string str_Radio_SpouseRelatives { get; set; }// SubmitCandidate_Data["P65"].ToString().Trim();
        public string str_Txt_relativeName { get; set; }// SubmitCandidate_Data["P66"].ToString().Trim();
        public string str_Select_isFormallyEmployeed { get; set; }// SubmitCandidate_Data["P67"].ToString().Trim();
        public string str_Select_iseligibilityID { get; set; }// SubmitCandidate_Data["P75"].ToString().Trim();
        public string str_Select_padsID { get; set; }// SubmitCandidate_Data["P68"].ToString().Trim();
        public string str_Radio_Referral { get; set; }// SubmitCandidate_Data["P69"].ToString().Trim();
        public string str_Date_processingDate { get; set; }// SubmitCandidate_Data["P70"].ToString().Trim();
        public string str_Txt_Email { get; set; }// SubmitCandidate_Data["P72"].ToString().Trim();
        public string str_Select_Gender { get; set; }// SubmitCandidate_Data["P73"].ToString().Trim();
        public string str_Txt_mobilePhone { get; set; }// SubmitCandidate_Data["P74"].ToString().Trim();
        public string str_Radio_Retiree { get; set; }// SubmitCandidate_Data["P33"].ToString().Trim();

        public string strDateAssignmentStart { get; set; }// SubmitCandidate_Data["72"].ToString().Trim();
        public string strDateAssignmentEnd { get; set; }// SubmitCandidate_Data["73"].ToString().Trim();
        public string str_RadioButton_RetireeRadio { get; set; }// SubmitCandidate_Data["33"].ToString().Trim();

        public string str_Select_ACACompliantHealthCoverage { get; set; }// SubmitCandidate_Data["P46"].ToString().Trim() -- Bimbo;
        public string str_Select_ACACostPer { get; set; }// SubmitCandidate_Data["P47"].ToString().Trim() --- Bimbo;
        public string str_Txt_ACACost { get; set; }// SubmitCandidate_Data["P48"].ToString().Trim();

        //cp chem                      
        public string str_select_Employmenttype_employmentTypeID { get; set; }// SubmitCandidate_Data["P34"].ToString().Trim();
        public string str_select_YearsExperience_skillYearsExpID { get; set; }// SubmitCandidate_Data["P35"].ToString().Trim();
        public string str_radiobutton_Level_skillLevelID { get; set; }// SubmitCandidate_Data["P36"].ToString().Trim();
        public string str_txt_Comments_supplierComments { get; set; }// SubmitCandidate_Data["P37"].ToString().Trim();
        public string str_radiobutton_FormerEmployee_ExperienceRadio1 { get; set; }// SubmitCandidate_Data["P38"].ToString().Trim();
        public string str_Date_FromerEmployeeFromDate_fromDate1 { get; set; }// SubmitCandidate_Data["P39"].ToString().Trim();
        public string str_Date_FromerEmployeeToDate_toDate1 { get; set; }// SubmitCandidate_Data["P40"].ToString().Trim();
        public string str_txt_FromerEmployeeJobTitle_jobTitle { get; set; }// SubmitCandidate_Data["P41"].ToString().Trim();
        public string str_txt_FromerEmployeeSupervisor_supervisorName { get; set; }// SubmitCandidate_Data["P60"].ToString().Trim();
        public string str_txt_CandidatePayRate_supplierRegPayRate { get; set; }// SubmitCandidate_Data["P49"].ToString().Trim();
        public string str_txt_CandidateOTPayRate_supplierOTPayRate { get; set; }// SubmitCandidate_Data["P50"].ToString().Trim();
        public string str_txt_BillRate_supplierRegBillRate { get; set; }// SubmitCandidate_Data["P51"].ToString().Trim();
        public string str_txt_BillRate_supplierOTBillRate { get; set; }// SubmitCandidate_Data["P52"].ToString().Trim();
        public string str_txt_OTBillRate_supplierOTBillRate { get; set; }// SubmitCandidate_Data["P52"].ToString().Trim();
        //APS
        public string str_txt_CandidateEmail_Email { get; set; }// SubmitCandidate_Data["P61"].ToString().Trim();
        public string str_select_Gender_Gender { get; set; }// SubmitCandidate_Data["P62"].ToString().Trim();
        public string str_txt_CellPhone_mobilePhone { get; set; }// SubmitCandidate_Data["P63"].ToString().Trim();
        public string str_txt_SocialSecurityNumber_candidateSSN { get; set; }// SubmitCandidate_Data["P64"].ToString().Trim();
        public string str_Date_DateofBirth_dob { get; set; }// SubmitCandidate_Data["P66"].ToString().Trim();
        public string str_select_CountryofCitizenship_country { get; set; }// SubmitCandidate_Data["P67"].ToString().Trim();
        public string str_txt_Street_address1 { get; set; }// SubmitCandidate_Data["P68"].ToString().Trim();
        public string str_txt_City_city { get; set; }// SubmitCandidate_Data["P69"].ToString().Trim();
        public string str_select_State_state { get; set; }// SubmitCandidate_Data["P70"].ToString().Trim();
        public string str_txt_Zip_zipcode { get; set; }// SubmitCandidate_Data["P71"].ToString().Trim();
        public string str_btn_SpouseRelativesatAPS_Yes_No { get; set; }// SubmitCandidate_Data["P72"].ToString().Trim();
        public string str_select_PADSBasisforAction_padsID { get; set; }// SubmitCandidate_Data["P71"].ToString().Trim();
        public string str_txt_SpouseRelativesName_relativeName { get; set; }// SubmitCandidate_Data["P74"].ToString().Trim();
        public string str_Date_OnSiteArrivalDate_processingDate { get; set; }// SubmitCandidate_Data["P75"].ToString().Trim();
        public string str_btn_Referral_Yes_No { get; set; }// SubmitCandidate_Data["P76"].ToString().Trim();
        public string str_select_FormerEmployee_isFormallyEmployeed { get; set; }// SubmitCandidate_Data["P77"].ToString().Trim();
        public string str_select_NativeAmericanFossilOnly_nativeAmericanID { get; set; }// SubmitCandidate_Data["P75"].ToString().Trim();
        public string str_select_Eligibilitytoworkatworklocation_eligibilityID { get; set; }// SubmitCandidate_Data["P79"].ToString().Trim();
        public string str_txt_Justification_lbljustificationDescription { get; set; }// SubmitCandidate_Data["P80"].ToString().Trim();
        public string str_btn_PriorYPHoldingsorATTemployee_ExperienceRadio { get; set; }// SubmitCandidate_Data["P38"].ToString().Trim();
        public string str_Date_PriorYPHoldingsorATTemployeeFromDate_fromDate1 { get; set; }// SubmitCandidate_Data["P39"].ToString().Trim();
        public string str_Date_PriorYPHoldingsorATTemployeeToDate_toDate1 { get; set; }// SubmitCandidate_Data["P40"].ToString().Trim();
        public string str_txt_PriorYPHoldingsorATTemployeeTitle_jobTitle { get; set; }// SubmitCandidate_Data["P41"].ToString().Trim();
        public string str_txt_PriorYPHoldingsorATTemployeeSupervisor_supervisorName { get; set; }// SubmitCandidate_Data["P60"].ToString().Trim();
        public string str_btn_PriorYPHoldingsorATTcontractor_contractor { get; set; }// SubmitCandidate_Data["P43"].ToString().Trim();
        public string str_Date_PriorYPHoldingsorATTcontractorFromDate_fromDateContractor1 { get; set; }// SubmitCandidate_Data["P44"].ToString().Trim();
        public string str_Date_PriorYPHoldingsorATTcontractorToDate_toDateContractor1 { get; set; }// SubmitCandidate_Data["P45"].ToString().Trim();
        public string str_txt_PriorYPHoldingsorATTcontractorTitle_jobTitle { get; set; }// SubmitCandidate_Data["P46"].ToString().Trim();
        public string str_txt_PriorYPHoldingsorATTcontractorSupervisor_supervisorName { get; set; }// SubmitCandidate_Data["P47"].ToString().Trim();
        public string str_btn_YPHoldingsorATTRetiree_RetireeRadio { get; set; }// SubmitCandidate_Data["P31"].ToString().Trim();
        public string str_Date_YPHoldingsorATTRetireeRetiredDate_RetiredDate { get; set; }// SubmitCandidate_Data["P32"].ToString().Trim();
        public string str_txt_YPHoldingsorATTRetireeTitle_RetiredJobTitle { get; set; }// SubmitCandidate_Data["P33"].ToString().Trim();
        public string str_txt_Last4DigitsofSSN_STID1 { get; set; }// SubmitCandidate_Data["P81"].ToString().Trim();
        public string str_select_SSNMonth_STID2 { get; set; }// SubmitCandidate_Data["P82"].ToString().Trim();
        public string str_select_SSNDate_STID3 { get; set; }// SubmitCandidate_Data["P83"].ToString().Trim();
        public string str_select_SSNYear_STID4 { get; set; }// SubmitCandidate_Data["P84"].ToString().Trim();
        public string str_select_SupplierOperationsCompany_OperativeCompany { get; set; }// SubmitCandidate_Data["P85"].ToString().Trim();
        public string str_radiobutton_retiree_RetireeRadio1 { get; set; }// SubmitCandidate_Data["P31"].ToString().Trim();
        public string str_radiobutton_FormerContractor_contractor1 { get; set; }// SubmitCandidate_Data["P42"].ToString().Trim();
        public string str_Date_FormerContractor_fromDateContractor1 { get; set; }// SubmitCandidate_Data["P44"].ToString().Trim();
        public string str_Date_FormerContractor_toDateContractor1 { get; set; }// SubmitCandidate_Data["P45"].ToString().Trim();
        public string str_txt_FromerContractorJobTitle_jobTitle { get; set; }// SubmitCandidate_Data["P46"].ToString().Trim();
        public string str_txt_FromerContractorSupervisor_supervisorName { get; set; }// SubmitCandidate_Data["P47"].ToString().Trim();
        public string str_Date_RetiredDate_RetiredDate { get; set; }// SubmitCandidate_Data["P32"].ToString().Trim();
        public string str_txt_RetiredJobTitle_RetiredJobTitle { get; set; }// SubmitCandidate_Data["P33"].ToString().Trim();
        public string str_Radiobtn_Former_Contractor_contractor1 { get; set; }
        public string str_ID_Date_FormerContractor_fromDateContractor1 { get; set; }
        public string str_radiobutton_EPRIRetiree_RetireeRadio1 { get; set; }
        public string str_radiobutton_EPRIRetiree_RetireeRadio0 { get; set; }
        public string str_txt_RetiredDate_RetiredDate { get; set; }
        public string str_txt_JobTitle_RetiredJobTitle { get; set; }
        public string str_select_HastheNonEmployeebeenofferedACACompliantHealthCoverage_ACACompliantHealthCoverage { get; set; }// SubmitCandidate_Data["P96"].ToString().Trim();
        public string str_select_ACACostPer_ACACostPer { get; set; }// SubmitCandidate_Data["P97"].ToString().Trim();
        public string str_txt_ACACost_ACACost { get; set; }// SubmitCandidate_Data["P98"].ToString().Trim();
        public string str_select_SupplierOperatingCompany_OperativeCompany { get; set; }// SubmitCandidate_Data["P99"].ToString().Trim();
        public string str_radiobtn_HOSdocuments { get; set; }//= SubmitCandidate_Data["P86"].ToString().Trim();
        public string str_radiobtn_CDLwithnecessaryendorsements { get; set; }//= SubmitCandidate_Data["P87"].ToString().Trim();
        public string str_radiobtn_CurrentlyvalidMedicalExaminer { get; set; }//= SubmitCandidate_Data["P88"].ToString().Trim();
        public string str_radiobtn_MotorVehicleRecord { get; set; }//= SubmitCandidate_Data["P89"].ToString().Trim();
        public string str_radiobtn_CertificateofMotorVehicleViolations { get; set; }//= SubmitCandidate_Data["P90"].ToString().Trim();
        public string str_radiobtn_Preemploymentdrugtestcompletion { get; set; }//= SubmitCandidate_Data["P91"].ToString().Trim();
        public string str_radiobtn_ApplicationfromDriverLeasingService { get; set; } //= SubmitCandidate_Data["P92"].ToString().Trim();
        public string str_radiobtn_verificationofpriordrivingexperience { get; set; }//= SubmitCandidate_Data["P93"].ToString().Trim();
        public string str_radiobtn_workhistoryverification { get; set; }//= SubmitCandidate_Data["P94"].ToString().Trim();
        public string str_radiobtn_HazMattrainingcertificate { get; set; }//= SubmitCandidate_Data["P95"].ToString().Trim();
        //public string str_Date_FromerEmployeeFromDate_fromDate1 { get; set; }
        public string str_select_EmploymentType_employmentTypeID { get; set; }
        public string str_Txt_NottoExceedBillRate_supplierRegBillRate { get; set; }// SubmitCandidate_Data["P51"].ToString().Trim();
        public string str_Txt_Comments_lbljustificationDescription { get; set; }// SubmitCandidate_Data["P80"].ToString().Trim();
        //QL
        public string str_txt_Email_Email { get; set; }// SubmitCandidate_Data["P100"].ToString().Trim();
        public string str_Txt_UploadFilePath { get; set; }// SubmitCandidate_Data["P101"].ToString().Trim();
        public string str_Txt_UploadAdditionalDocument { get; set; }// SubmitCandidate_Data["P102"].ToString().Trim();
        public string str_Txt_Justificationtosubmitthecandidateforthisrequirementrequisition_lbljustificationDescription { get; set; }// SubmitCandidate_Data["P80"].ToString().Trim();
        public string str_Radiobutton_PreviousEmployee_ExperienceRadio { get; set; }// SubmitCandidate_Data["P38"].ToString().Trim();
        public string str_Date_PreviousEmployeeFromDate_fromDate1 { get; set; }// SubmitCandidate_Data["P39"].ToString().Trim();
        public string str_Date_PreviousEmployeeToDate_toDate1 { get; set; }// SubmitCandidateData["P40"].ToString().Trim();
        public string str_txt_Previousemployeejobtitle_jobTitle { get; set; }// SubmitCandidate_Data["P41"].ToString().Trim();
        public string str_txt_PreviousemployeeSupervisor_supervisorName { get; set; }// SubmitCandidate_Data["P60"].ToString().Trim();
        public string str_Radiobutton_PreviousCW_contractor { get; set; }// SubmitCandidate_Data["P103"].ToString().Trim();
        public string str_Date_PreviousCW_fromDateContractor1 { get; set; }// SubmitCandidate_Data["P104"].ToString().Trim();
        public string str_Date_PreviousCW_toDateContractor1 { get; set; }// SubmitCandidate_Data["P105"].ToString().Trim();
        public string str_Txt_PreviousCWjobtitle_jobTitle { get; set; }// SubmitCandidate_Data["P106"].ToString().Trim();
        public string str_Txt_PreviousCWSupervisor_supervisorName { get; set; }// SubmitCandidate_Data["P107"].ToString().Trim();
        public string str_RadioButton_Retiree_RetireeRadio { get; set; }// SubmitCandidate_Data["P31"].ToString().Trim();
        public string str_txt_RetireeJobTitle_RetiredJobTitle { get; set; }// SubmitCandidate_Data["P108"].ToString().Trim();
        public string str_Select_InWhichCurrencydoyouwanttosubmittheCandidate_currencyID { get; set; }// SubmitCandidate_Data["P109"].ToString().Trim();
       
        public string str_Txt_Last4digitsofSSN_SSN { get; set; }// SubmitCandidate_Data["P110"].ToString().Trim();
        public string str_radiobutton_isssnvalid { get; set; }// SubmitCandidate_Data["P111"].ToString().Trim();
        public string str_radiobutton_SpouseRelativesatAPS { get; set; }// SubmitCandidate_Data["P72"].ToString().Trim();

        public string str_txt_FromerEmployeeJobTitle { get; set; }// SubmitCandidate_Data["P41"].ToString().Trim();
        public string str_txt_FromerEmployeeSupervisor { get; set; }// SubmitCandidate_Data["P60"].ToString().Trim();
        public string str_select_BirthMonth_STID2 { get; set; }// SubmitCandidate_Data["P82"].ToString().Trim();
        public string str_Txt_Justification_lbljustificationDescription { get; set; }
        public string str_select_BirthDay_STID3 { get; set; }
        public string str_txt_Justificationtosubmitthecandidateforthisrequirementrequisitionmax500characters_lbljustificationDescription { get; set; }
    }

}
