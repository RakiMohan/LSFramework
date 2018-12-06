// --------------------------------------------------------------------------------------------------------------------
//<copyright file="CreateRequirementRepository.cs" company="DCR Workforce Inc">
//   Copyright (c) DCR Workforce Inc. All rights reserved.
//   This code and information should not be copied and used outside of DCR Workforce Inc.
// </copyright>
// <summary>
//   Builds the Container for the Autofac IOC.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmartTrack.DataAccess.Repository
{
    using SmartTrack.DataAccess.Models;
    using System.Data;

    public class SubmitCandidateResumeRepository
    {

        public SubmitCandidateResumeModel GetSubmitCandidateResumeData(DataRow SubmitCandidate_Data)
        {
            SubmitCandidateResumeModel submitCandidateResumeModel = new SubmitCandidateResumeModel();
            submitCandidateResumeModel.strClientName = SubmitCandidate_Data["P3"].ToString().Trim();
            submitCandidateResumeModel.str_Button_SaveConfirmOK = SubmitCandidate_Data["P26"].ToString().Trim();
            submitCandidateResumeModel.str_Button_Search = SubmitCandidate_Data["P27"].ToString().Trim();
            submitCandidateResumeModel.str_Button_addcandidatetoresumebank = SubmitCandidate_Data["P28"].ToString().Trim();
            submitCandidateResumeModel.str_Link_SubmitReq = SubmitCandidate_Data["P29"].ToString().Trim();
            submitCandidateResumeModel.str_Select_employmentTypeID = SubmitCandidate_Data["P34"].ToString().Trim();
            submitCandidateResumeModel.strSelectSkills_Years = SubmitCandidate_Data["P35"].ToString().Trim();
            submitCandidateResumeModel.strRadiobtnSkills_Level = SubmitCandidate_Data["P36"].ToString().Trim();
            submitCandidateResumeModel.strRadiobtnFormer_Employee = SubmitCandidate_Data["P38"].ToString().Trim();
            submitCandidateResumeModel.strRadiobtnFormer_Contractor = SubmitCandidate_Data["P42"].ToString().Trim();
            submitCandidateResumeModel.str_Txt_CandidatePayRate = SubmitCandidate_Data["P49"].ToString().Trim();
            submitCandidateResumeModel.str_Txt_CandidateOTPayRate = SubmitCandidate_Data["P50"].ToString().Trim();
            submitCandidateResumeModel.str_Txt_BillRate = SubmitCandidate_Data["P51"].ToString().Trim();
            submitCandidateResumeModel.str_Txt_OTBillRate = SubmitCandidate_Data["P52"].ToString().Trim();
            submitCandidateResumeModel.str_Txt_STID = SubmitCandidate_Data["P53"].ToString().Trim();
            submitCandidateResumeModel.str_Button_SubmitToRequirement = SubmitCandidate_Data["P54"].ToString().Trim();
            submitCandidateResumeModel.str_Txt_candidateSSN = SubmitCandidate_Data["P55"].ToString().Trim();
            submitCandidateResumeModel.str_Date_DOB = SubmitCandidate_Data["P56"].ToString().Trim();
            submitCandidateResumeModel.str_Radio_IsSSNValid = SubmitCandidate_Data["P57"].ToString().Trim();
            submitCandidateResumeModel.str_Txt_address1 = SubmitCandidate_Data["P58"].ToString().Trim();
            submitCandidateResumeModel.str_Txt_city = SubmitCandidate_Data["P59"].ToString().Trim();
            submitCandidateResumeModel.str_Select_state = SubmitCandidate_Data["P60"].ToString().Trim();
            submitCandidateResumeModel.str_Select_country = SubmitCandidate_Data["P61"].ToString().Trim();
            submitCandidateResumeModel.str_Txt_zipcode = SubmitCandidate_Data["P62"].ToString().Trim();
            submitCandidateResumeModel.str_Radio_SpouseRelatives = SubmitCandidate_Data["P63"].ToString().Trim();
            submitCandidateResumeModel.str_Txt_relativeName = SubmitCandidate_Data["P64"].ToString().Trim();
            submitCandidateResumeModel.str_Select_isFormallyEmployeed = SubmitCandidate_Data["P65"].ToString().Trim();
            submitCandidateResumeModel.str_Select_padsID = SubmitCandidate_Data["P66"].ToString().Trim();
            submitCandidateResumeModel.str_Radio_Referral = SubmitCandidate_Data["P67"].ToString().Trim();
            submitCandidateResumeModel.str_Date_processingDate = SubmitCandidate_Data["P68"].ToString().Trim();
            submitCandidateResumeModel.str_Txt_Email = SubmitCandidate_Data["P70"].ToString().Trim();
            submitCandidateResumeModel.str_Select_Gender = SubmitCandidate_Data["P71"].ToString().Trim();
            submitCandidateResumeModel.str_Txt_mobilePhone = SubmitCandidate_Data["P72"].ToString().Trim();
            submitCandidateResumeModel.str_Select_iseligibilityID = SubmitCandidate_Data["P73"].ToString().Trim();
            submitCandidateResumeModel.str_Radio_Retiree = SubmitCandidate_Data["P31"].ToString().Trim();

            submitCandidateResumeModel.strDateAssignmentStart = SubmitCandidate_Data["P70"].ToString().Trim();
            submitCandidateResumeModel.strDateAssignmentEnd = SubmitCandidate_Data["P71"].ToString().Trim();
            submitCandidateResumeModel.str_RadioButton_RetireeRadio = SubmitCandidate_Data["P31"].ToString().Trim();

            submitCandidateResumeModel.str_Select_ACACompliantHealthCoverage = SubmitCandidate_Data["P44"].ToString().Trim();
            submitCandidateResumeModel.str_Select_ACACostPer = SubmitCandidate_Data["P45"].ToString().Trim();
            submitCandidateResumeModel.str_Txt_ACACost = SubmitCandidate_Data["P46"].ToString().Trim();

            //cp chem

            submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID = SubmitCandidate_Data["P34"].ToString().Trim();
            submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID = SubmitCandidate_Data["P35"].ToString().Trim();
            submitCandidateResumeModel.str_radiobutton_Level_skillLevelID = SubmitCandidate_Data["P36"].ToString().Trim();
            submitCandidateResumeModel.str_txt_Comments_supplierComments = SubmitCandidate_Data["P37"].ToString().Trim();
            submitCandidateResumeModel.str_radiobutton_FormerEmployee_ExperienceRadio1 = SubmitCandidate_Data["P38"].ToString().Trim();
            submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 = SubmitCandidate_Data["P39"].ToString().Trim();
            submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 = SubmitCandidate_Data["P40"].ToString().Trim();
            submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle = SubmitCandidate_Data["P41"].ToString().Trim();
            submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName = SubmitCandidate_Data["P60"].ToString().Trim();
            submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate = SubmitCandidate_Data["P49"].ToString().Trim();
            submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate = SubmitCandidate_Data["P50"].ToString().Trim();
            submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate = SubmitCandidate_Data["P51"].ToString().Trim();
            submitCandidateResumeModel.str_txt_BillRate_supplierOTBillRate = SubmitCandidate_Data["P52"].ToString().Trim();
            submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate = SubmitCandidate_Data["P52"].ToString().Trim();
            //APS
            submitCandidateResumeModel.str_txt_CandidateEmail_Email = SubmitCandidate_Data["P61"].ToString().Trim();
            submitCandidateResumeModel.str_select_Gender_Gender = SubmitCandidate_Data["P62"].ToString().Trim();
            submitCandidateResumeModel.str_txt_CellPhone_mobilePhone = SubmitCandidate_Data["P63"].ToString().Trim();
            submitCandidateResumeModel.str_txt_SocialSecurityNumber_candidateSSN = SubmitCandidate_Data["P64"].ToString().Trim();
            submitCandidateResumeModel.str_Date_DateofBirth_dob = SubmitCandidate_Data["P66"].ToString().Trim();
            submitCandidateResumeModel.str_select_CountryofCitizenship_country = SubmitCandidate_Data["P67"].ToString().Trim();
            submitCandidateResumeModel.str_txt_Street_address1 = SubmitCandidate_Data["P68"].ToString().Trim();
            submitCandidateResumeModel.str_txt_City_city = SubmitCandidate_Data["P69"].ToString().Trim();
            submitCandidateResumeModel.str_select_State_state = SubmitCandidate_Data["P70"].ToString().Trim();
            submitCandidateResumeModel.str_txt_Zip_zipcode = SubmitCandidate_Data["P71"].ToString().Trim();
            submitCandidateResumeModel.str_btn_SpouseRelativesatAPS_Yes_No = SubmitCandidate_Data["P72"].ToString().Trim();
            submitCandidateResumeModel.str_select_PADSBasisforAction_padsID = SubmitCandidate_Data["P71"].ToString().Trim();
            submitCandidateResumeModel.str_txt_SpouseRelativesName_relativeName = SubmitCandidate_Data["P74"].ToString().Trim();
            submitCandidateResumeModel.str_btn_Referral_Yes_No = SubmitCandidate_Data["P76"].ToString().Trim();
            submitCandidateResumeModel.str_Date_OnSiteArrivalDate_processingDate = SubmitCandidate_Data["P77"].ToString().Trim();
            submitCandidateResumeModel.str_select_FormerEmployee_isFormallyEmployeed = SubmitCandidate_Data["P74"].ToString().Trim();
            submitCandidateResumeModel.str_select_NativeAmericanFossilOnly_nativeAmericanID = SubmitCandidate_Data["P75"].ToString().Trim();
            submitCandidateResumeModel.str_select_Eligibilitytoworkatworklocation_eligibilityID = SubmitCandidate_Data["P79"].ToString().Trim();
            submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription = SubmitCandidate_Data["P80"].ToString().Trim();
            submitCandidateResumeModel.str_btn_PriorYPHoldingsorATTemployee_ExperienceRadio = SubmitCandidate_Data["P38"].ToString().Trim();
            submitCandidateResumeModel.str_Date_PriorYPHoldingsorATTemployeeFromDate_fromDate1 = SubmitCandidate_Data["P39"].ToString().Trim();
            submitCandidateResumeModel.str_Date_PriorYPHoldingsorATTemployeeToDate_toDate1 = SubmitCandidate_Data["P40"].ToString().Trim();
            submitCandidateResumeModel.str_txt_PriorYPHoldingsorATTemployeeTitle_jobTitle = SubmitCandidate_Data["P41"].ToString().Trim();
            submitCandidateResumeModel.str_txt_PriorYPHoldingsorATTemployeeSupervisor_supervisorName = SubmitCandidate_Data["P60"].ToString().Trim();
            submitCandidateResumeModel.str_btn_PriorYPHoldingsorATTcontractor_contractor = SubmitCandidate_Data["P43"].ToString().Trim();
            submitCandidateResumeModel.str_Date_PriorYPHoldingsorATTcontractorFromDate_fromDateContractor1 = SubmitCandidate_Data["P44"].ToString().Trim();
            submitCandidateResumeModel.str_Date_PriorYPHoldingsorATTcontractorToDate_toDateContractor1 = SubmitCandidate_Data["P45"].ToString().Trim();
            submitCandidateResumeModel.str_txt_PriorYPHoldingsorATTcontractorTitle_jobTitle = SubmitCandidate_Data["P46"].ToString().Trim();
            submitCandidateResumeModel.str_txt_PriorYPHoldingsorATTcontractorSupervisor_supervisorName = SubmitCandidate_Data["P47"].ToString().Trim();
            submitCandidateResumeModel.str_btn_YPHoldingsorATTRetiree_RetireeRadio = SubmitCandidate_Data["P31"].ToString().Trim();
            submitCandidateResumeModel.str_Date_YPHoldingsorATTRetireeRetiredDate_RetiredDate = SubmitCandidate_Data["P32"].ToString().Trim();
            submitCandidateResumeModel.str_txt_YPHoldingsorATTRetireeTitle_RetiredJobTitle = SubmitCandidate_Data["P33"].ToString().Trim();
            submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 = SubmitCandidate_Data["P81"].ToString().Trim();
            submitCandidateResumeModel.str_select_SSNMonth_STID2 = SubmitCandidate_Data["P82"].ToString().Trim();
            submitCandidateResumeModel.str_select_SSNDate_STID3 = SubmitCandidate_Data["P83"].ToString().Trim();
            submitCandidateResumeModel.str_select_SSNYear_STID4 = SubmitCandidate_Data["P84"].ToString().Trim();
            submitCandidateResumeModel.str_select_SupplierOperationsCompany_OperativeCompany = SubmitCandidate_Data["P85"].ToString().Trim();
            submitCandidateResumeModel.str_radiobutton_FormerContractor_contractor1 = SubmitCandidate_Data["P42"].ToString().Trim();
            submitCandidateResumeModel.str_radiobutton_retiree_RetireeRadio1 = SubmitCandidate_Data["P31"].ToString().Trim();
            submitCandidateResumeModel.str_txt_RetiredJobTitle_RetiredJobTitle = SubmitCandidate_Data["P33"].ToString().Trim();
            submitCandidateResumeModel.str_Date_RetiredDate_RetiredDate = SubmitCandidate_Data["P32"].ToString().Trim();
            submitCandidateResumeModel.str_txt_FromerContractorSupervisor_supervisorName = SubmitCandidate_Data["P47"].ToString().Trim();
            submitCandidateResumeModel.str_txt_FromerContractorJobTitle_jobTitle = SubmitCandidate_Data["P46"].ToString().Trim();
            submitCandidateResumeModel.str_Date_FormerContractor_toDateContractor1 = SubmitCandidate_Data["P45"].ToString().Trim();
            submitCandidateResumeModel.str_Date_FormerContractor_fromDateContractor1 = SubmitCandidate_Data["P44"].ToString().Trim();

            submitCandidateResumeModel.str_Radiobtn_Former_Contractor_contractor1 = SubmitCandidate_Data["P42"].ToString().Trim();

            submitCandidateResumeModel.str_select_State_state = SubmitCandidate_Data["P70"].ToString().Trim();
            submitCandidateResumeModel.str_ID_Date_FormerContractor_fromDateContractor1 = SubmitCandidate_Data["P44"].ToString().Trim();
            submitCandidateResumeModel.str_radiobutton_EPRIRetiree_RetireeRadio1 = SubmitCandidate_Data["P31"].ToString().Trim();
            submitCandidateResumeModel.str_radiobutton_EPRIRetiree_RetireeRadio0 = SubmitCandidate_Data["P31"].ToString().Trim();
            submitCandidateResumeModel.str_txt_RetiredDate_RetiredDate = SubmitCandidate_Data["P32"].ToString().Trim();
            submitCandidateResumeModel.str_txt_JobTitle_RetiredJobTitle = SubmitCandidate_Data["P33"].ToString().Trim();
            submitCandidateResumeModel.str_select_HastheNonEmployeebeenofferedACACompliantHealthCoverage_ACACompliantHealthCoverage = SubmitCandidate_Data["P96"].ToString().Trim();
            submitCandidateResumeModel.str_select_ACACostPer_ACACostPer = SubmitCandidate_Data["P97"].ToString().Trim();
            submitCandidateResumeModel.str_txt_ACACost_ACACost = SubmitCandidate_Data["P98"].ToString().Trim();
            submitCandidateResumeModel.str_select_SupplierOperatingCompany_OperativeCompany = SubmitCandidate_Data["P99"].ToString().Trim();
            submitCandidateResumeModel.str_radiobtn_HOSdocuments = SubmitCandidate_Data["P86"].ToString().Trim();
            submitCandidateResumeModel.str_radiobtn_CDLwithnecessaryendorsements = SubmitCandidate_Data["P87"].ToString().Trim();
            submitCandidateResumeModel.str_radiobtn_CurrentlyvalidMedicalExaminer = SubmitCandidate_Data["P88"].ToString().Trim();
            submitCandidateResumeModel.str_radiobtn_MotorVehicleRecord = SubmitCandidate_Data["P89"].ToString().Trim();
            submitCandidateResumeModel.str_radiobtn_CertificateofMotorVehicleViolations = SubmitCandidate_Data["P90"].ToString().Trim();
            submitCandidateResumeModel.str_radiobtn_Preemploymentdrugtestcompletion = SubmitCandidate_Data["P91"].ToString().Trim();
            submitCandidateResumeModel.str_radiobtn_ApplicationfromDriverLeasingService = SubmitCandidate_Data["P92"].ToString().Trim();
            submitCandidateResumeModel.str_radiobtn_verificationofpriordrivingexperience = SubmitCandidate_Data["P93"].ToString().Trim();
            submitCandidateResumeModel.str_radiobtn_workhistoryverification = SubmitCandidate_Data["P94"].ToString().Trim();
            submitCandidateResumeModel.str_radiobtn_HazMattrainingcertificate = SubmitCandidate_Data["P95"].ToString().Trim();
            submitCandidateResumeModel.str_select_EmploymentType_employmentTypeID = SubmitCandidate_Data["P34"].ToString().Trim();
            submitCandidateResumeModel.str_Txt_Comments_lbljustificationDescription = SubmitCandidate_Data["P80"].ToString().Trim();
            submitCandidateResumeModel.str_Txt_NottoExceedBillRate_supplierRegBillRate = SubmitCandidate_Data["P51"].ToString().Trim();
            submitCandidateResumeModel.str_txt_Email_Email = SubmitCandidate_Data["P100"].ToString().Trim();
            submitCandidateResumeModel.str_Txt_UploadFilePath = SubmitCandidate_Data["P101"].ToString().Trim();
            submitCandidateResumeModel.str_Txt_UploadAdditionalDocument = SubmitCandidate_Data["P102"].ToString().Trim();
            submitCandidateResumeModel.str_Txt_Justificationtosubmitthecandidateforthisrequirementrequisition_lbljustificationDescription = SubmitCandidate_Data["P80"].ToString().Trim();
            submitCandidateResumeModel.str_Date_PreviousEmployeeFromDate_fromDate1 = SubmitCandidate_Data["P39"].ToString().Trim();
            submitCandidateResumeModel.str_Date_PreviousEmployeeToDate_toDate1 = SubmitCandidate_Data["P40"].ToString().Trim();
            submitCandidateResumeModel.str_txt_Previousemployeejobtitle_jobTitle = SubmitCandidate_Data["P41"].ToString().Trim();
            submitCandidateResumeModel.str_txt_PreviousemployeeSupervisor_supervisorName = SubmitCandidate_Data["P60"].ToString().Trim();
            submitCandidateResumeModel.str_Radiobutton_PreviousCW_contractor = SubmitCandidate_Data["P103"].ToString().Trim();
            submitCandidateResumeModel.str_Date_PreviousCW_fromDateContractor1 = SubmitCandidate_Data["P104"].ToString().Trim();
            submitCandidateResumeModel.str_Date_PreviousCW_toDateContractor1 = SubmitCandidate_Data["P105"].ToString().Trim();
            submitCandidateResumeModel.str_Txt_PreviousCWjobtitle_jobTitle = SubmitCandidate_Data["P106"].ToString().Trim();
            submitCandidateResumeModel.str_Txt_PreviousCWSupervisor_supervisorName = SubmitCandidate_Data["P107"].ToString().Trim();
            submitCandidateResumeModel.str_RadioButton_Retiree_RetireeRadio = SubmitCandidate_Data["P31"].ToString().Trim();
            submitCandidateResumeModel.str_txt_RetireeJobTitle_RetiredJobTitle = SubmitCandidate_Data["P108"].ToString().Trim();
            submitCandidateResumeModel.str_Select_InWhichCurrencydoyouwanttosubmittheCandidate_currencyID = SubmitCandidate_Data["P109"].ToString().Trim();
            submitCandidateResumeModel.str_Txt_Last4digitsofSSN_SSN = SubmitCandidate_Data["P110"].ToString().Trim();
            submitCandidateResumeModel.str_radiobutton_isssnvalid = SubmitCandidate_Data["P111"].ToString().Trim();
            submitCandidateResumeModel.str_radiobutton_SpouseRelativesatAPS = SubmitCandidate_Data["P72"].ToString().Trim();

            submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle = SubmitCandidate_Data["P41"].ToString().Trim();
            submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor = SubmitCandidate_Data["P60"].ToString().Trim();
            submitCandidateResumeModel.str_select_BirthMonth_STID2 = SubmitCandidate_Data["P82"].ToString().Trim();
            submitCandidateResumeModel.str_Txt_Justification_lbljustificationDescription = SubmitCandidate_Data["P80"].ToString().Trim();
            submitCandidateResumeModel.str_select_BirthDay_STID3 = SubmitCandidate_Data["P83"].ToString().Trim();
            submitCandidateResumeModel.str_txt_Justificationtosubmitthecandidateforthisrequirementrequisitionmax500characters_lbljustificationDescription = SubmitCandidate_Data["P80"].ToString().Trim();
            return submitCandidateResumeModel;
        }


    }
}