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

    public class AddCandidateandSubmitCandidateRequirementRepository
    {
        public AddResumeSubmitCandidate GetAddResumeandSubmitCandidate(DataRow Submitcandiate_Data)
        {
            AddResumeSubmitCandidate addResumesubmitCandidatemodel = new AddResumeSubmitCandidate();

            addResumesubmitCandidatemodel.strClientName = Submitcandiate_Data["P3"].ToString().Trim();
            addResumesubmitCandidatemodel.strMainMenuLink = Submitcandiate_Data["P4"].ToString().Trim();
            addResumesubmitCandidatemodel.strSubMenuLink = Submitcandiate_Data["P5"].ToString().Trim();
            addResumesubmitCandidatemodel.Requirementnumber = Submitcandiate_Data["P6"].ToString().Trim();
            addResumesubmitCandidatemodel.ActionList = Submitcandiate_Data["P7"].ToString().Trim();
            addResumesubmitCandidatemodel.str_txt_LastName_LastName = Submitcandiate_Data["P8"].ToString().Trim();
            addResumesubmitCandidatemodel.str_txt_FirstName_FirstName = Submitcandiate_Data["P9"].ToString().Trim();
            addResumesubmitCandidatemodel.str_txt_MiddleName_MiddleName = Submitcandiate_Data["P10"].ToString().Trim();
            addResumesubmitCandidatemodel.str_txt_NickName_NickName = Submitcandiate_Data["P11"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Select_SuffixName_SuffixName = Submitcandiate_Data["P12"].ToString().Trim();
            addResumesubmitCandidatemodel.str_TypeHead_ZipCode_ZipCode = Submitcandiate_Data["P13"].ToString().Trim();
            addResumesubmitCandidatemodel.str_TypeHead_Country_Country = Submitcandiate_Data["P14"].ToString().Trim();
            addResumesubmitCandidatemodel.str_TypeHead_State_State = Submitcandiate_Data["P15"].ToString().Trim();
            addResumesubmitCandidatemodel.str_TypeHead_city_city = Submitcandiate_Data["P16"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Radio_Available = Submitcandiate_Data["P17"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Date_Available_AvailableDate = Submitcandiate_Data["P18"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Select_Recruiter_RecruiterName = Submitcandiate_Data["P19"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Radio_PastPresentMilitaryEmployment = Submitcandiate_Data["P20"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Txt_PastPresentMilitaryEmployment_EmploymentDetails = Submitcandiate_Data["P21"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Txt_ATSID_ATSID = Submitcandiate_Data["P22"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Resume_ResumeUpload_btnresumeupload = Submitcandiate_Data["P23"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Button_AddCandidateResumePopup_OK = Submitcandiate_Data["P24"].ToString().Trim();

            //2nd page

            addResumesubmitCandidatemodel.str_txt_CandidateEmail_Email = Submitcandiate_Data["P35"].ToString().Trim();
            addResumesubmitCandidatemodel.str_txt_CandidateSummary_lbljustificationDescription = Submitcandiate_Data["P36"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Select_EmploymentType_employmentTypeID = Submitcandiate_Data["P37"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Select_SupplierLegalEntity_OperativeCompany = Submitcandiate_Data["P38"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Radio_FormerEmployee = Submitcandiate_Data["P39"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Date_FromDate_fromDate1 = Submitcandiate_Data["P40"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Date_ToDatetoDate1 = Submitcandiate_Data["P41"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Txt_PID_jobTitle = Submitcandiate_Data["P42"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Txt_FormerEmployeeUsername_FormerEmployee = Submitcandiate_Data["P43"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Radio_FormerTVC = Submitcandiate_Data["P44"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Date_FormerTVCFromDate_fromDate1 = Submitcandiate_Data["P45"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Date_FormerTVCToDatetoDate1 = Submitcandiate_Data["P46"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Txt_FormerTVCPID_jobTitle = Submitcandiate_Data["P47"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Txt_FormerTVCUsername_ContractorDetails = Submitcandiate_Data["P48"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Radio_FormerIntern = Submitcandiate_Data["P49"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Date_RetireeDate_RetiredDate = Submitcandiate_Data["P50"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Txt_FormerInternUsername_InternDetails = Submitcandiate_Data["P51"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Radio_ExemptNonExempt = Submitcandiate_Data["P52"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Txt_CandidatePayRate_supplierRegPayRate = Submitcandiate_Data["P53"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Txt_CandidateOTPayRate_supplierOTPayRate = Submitcandiate_Data["P54"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Txt_BillRate_supplierRegBillRate = Submitcandiate_Data["P55"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Txt_OTBillRate_supplierOTBillRate = Submitcandiate_Data["P56"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Txt_Last4DigitsofNationalID_STID1 = Submitcandiate_Data["P57"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Select_BirthMonth_STID2 = Submitcandiate_Data["P58"].ToString().Trim();
            addResumesubmitCandidatemodel.str_Select_BirthDay_STID3 = Submitcandiate_Data["P59"].ToString().Trim();
            addResumesubmitCandidatemodel.str_PopUp_SubmitRequistion_Yes = Submitcandiate_Data["P60"].ToString().Trim();
            addResumesubmitCandidatemodel.str_PopUp_SubmitRequistion_Ok = Submitcandiate_Data["P61"].ToString().Trim();


            return addResumesubmitCandidatemodel;
        }


    }
}