// --------------------------------------------------------------------------------------------------------------------
//<copyright file{get;set;}//"AcceptOfferModel" company{get;set;}//"DCR Workforce Inc">
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

    public class AcceptOfferModel
    {
        public string strClientName { get; set; }// AcceptOffer_Data["P5"].ToString().Trim();
        public string strMainMenuLink { get; set; }// AcceptOffer_Data["P6"].ToString().Trim();
        public string strSubMenuLink { get; set; }// AcceptOffer_Data["P7"].ToString().Trim();
        public string str_Link_ReqNumber { get; set; }// AcceptOffer_Data["P8"].ToString().Trim();
        public string str_Link_CandidatesWithOffers { get; set; }// AcceptOffer_Data["P9"].ToString().Trim();
        public string str_CandidateName { get; set; }// AcceptOffer_Data["P10"].ToString().Trim();
        public string str_Link_AcceptOffer { get; set; }// AcceptOffer_Data["P11"].ToString().Trim();
        public string str_Txt_SmartTrackIdentifier { get; set; }// AcceptOffer_Data["P12"].ToString().Trim();
        public string str_Select_Country { get; set; }// AcceptOffer_Data["P13"].ToString().Trim();
        public string str_Select_state { get; set; }// AcceptOffer_Data["P14"].ToString().Trim();
        public string str_Select_County { get; set; }// AcceptOffer_Data["P15"].ToString().Trim();
        public string str_Txt_candidateSSN { get; set; }// AcceptOffer_Data["P16"].ToString().Trim();
        public string str_Date_DOB { get; set; }// AcceptOffer_Data["P17"].ToString().Trim();
        public string str_Txt_Email { get; set; }// AcceptOffer_Data["P18"].ToString().Trim();
        public string str_Btn_Accept_Submit { get; set; }// AcceptOffer_Data["P28"].ToString().Trim();
        public string str_Btn_AcceptOffer_Submit_Confirm { get; set; }// AcceptOffer_Data["P29"].ToString().Trim();
        public string str_Btn_AcceptOffer_Submit_Confirm_Ok { get; set; }// AcceptOffer_Data["P30"].ToString().Trim();
        public string str_Btn_Rejectoffer_Link { get; set; }//// AcceptOffer_Data["P31"].ToString().Trim();
        public string str_Select_RejectOfferReason { get; set; } // AcceptOffer_Data["P32"].ToString().Trim();
        public string str_Txt_RejectOfferReason_Comment { get; set; } // AcceptOffer_Data["P33"].ToString().Trim();
        public string str_Button_RejectOfferReason { get; set; } // AcceptOffer_Data["P34"].ToString().Trim();
        public string str_Button_RejectOfferYes { get; set; } // AcceptOffer_Data["P35"].ToString().Trim();
        public string str_Button_RejectOfferOK { get; set; } // AcceptOffer_Data["P36"].ToString().Trim();
        //Identified 
        public string str_Txt_LastName_LastName { get; set; } // AcceptOffer_Data["P50"].ToString().Trim();
        public string str_Txt_FirstName_FirstName { get; set; } // AcceptOffer_Data["P51"].ToString().Trim();
        public string str_txt_MiddleName_MiddleName { get; set; } // AcceptOffer_Data["P52"].ToString().Trim();
        public string str_Select_SuffixName_SuffixName { get; set; } // AcceptOffer_Data["P53"].ToString().Trim();
        public string str_Radio_Available_Available { get; set; } // AcceptOffer_Data["P54"].ToString().Trim();
        public string str_Date_Available_AvailableDate { get; set; } // AcceptOffer_Data["P55"].ToString().Trim();
        public string str_Txt_PermanatLocation_LocationCity { get; set; } // AcceptOffer_Data["P56"].ToString().Trim();
        public string str_Select_State_StatesID { get; set; } // AcceptOffer_Data["P57"].ToString().Trim();
        public string str_Select_Recruiter_RecruiterName { get; set; } // AcceptOffer_Data["P58"].ToString().Trim();
        public string str_Txt_Keywords_Keywords { get; set; } // AcceptOffer_Data["P59"].ToString().Trim();
        public string str_Resume_ResumeUpload_btnresumeupload { get; set; } // AcceptOffer_Data["P60"].ToString().Trim();
        public string str_Radiobutton_Retiree_RetireeRadio { get; set; } // AcceptOffer_Data["P61"].ToString().Trim();
        public string str_Date_RetiredDate_RetiredDate { get; set; } // AcceptOffer_Data["P62"].ToString().Trim();
        public string str_txt_RetireeJobTitle_RetiredJobTitle { get; set; } // AcceptOffer_Data["P63"].ToString().Trim();
        public string str_select_YearsExperience_skillYearsExpID { get; set; } // AcceptOffer_Data["P64"].ToString().Trim();
        public string str_radiobutton_Level_skillLevelID { get; set; } // AcceptOffer_Data["P65"].ToString().Trim();
        public string str_txt_Comments_supplierComments { get; set; } // AcceptOffer_Data["P66"].ToString().Trim();
        public string str_Radio_PastPresentMilitaryEmployment_Employment { get; set; } // AcceptOffer_Data["P67"].ToString().Trim();
        public string str_Txt_PastPresentMilitaryEmployment_EmploymentDetails { get; set; } // AcceptOffer_Data["P68"].ToString().Trim();
        public string str_radiobutton_FormerEmployee_ExperienceRadio { get; set; } // AcceptOffer_Data["P69"].ToString().Trim();
        public string str_Date_FromerEmployeeFromDate_fromDate1 { get; set; } // AcceptOffer_Data["P70"].ToString().Trim();
        public string str_Date_FromerEmployeeToDate_toDate1 { get; set; } // AcceptOffer_Data["P71"].ToString().Trim();
        public string str_txt_FromerEmployeeJobTitle_jobTitle { get; set; } // AcceptOffer_Data["P72"].ToString().Trim();
        public string str_txt_FromerEmployeeSupervisor_supervisorName { get; set; } // AcceptOffer_Data["P73"].ToString().Trim();
        public string str_radiobutton_FromerContractor_contractor { get; set; } // AcceptOffer_Data["P74"].ToString().Trim();
        public string str_Date_FormerContractor_fromDateContractor1 { get; set; } // AcceptOffer_Data["P75"].ToString().Trim();
        public string str_Date_FormerContractor_toDateContractor1 { get; set; } // AcceptOffer_Data["P76"].ToString().Trim();
        public string str_txt_FromerContractorJobTitle_jobTitle { get; set; } // AcceptOffer_Data["P77"].ToString().Trim();
        public string str_txt_FromerContractorSupervisor_supervisorName { get; set; } // AcceptOffer_Data["P78"].ToString().Trim();
        public string str_txt_CandidatePayRate_supplierRegPayRate { get; set; } // AcceptOffer_Data["P79"].ToString().Trim();
        public string str_txt_CandidateOTPayRate_supplierOTPayRate { get; set; } // AcceptOffer_Data["P80"].ToString().Trim();
        public string str_txt_BillRate_supplierRegBillRate { get; set; } // AcceptOffer_Data["P81"].ToString().Trim();
        public string str_txt_SupplierOTBillRate_supplierOTBillRate { get; set; } // AcceptOffer_Data["P82"].ToString().Trim();
        public string str_txt_Last4DigitsofSSN_STID1 { get; set; } // AcceptOffer_Data["P83"].ToString().Trim();
        public string str_select_SSNMonth_STID2 { get; set; } // AcceptOffer_Data["P84"].ToString().Trim();
        public string str_select_SSNDate_STID3 { get; set; } // AcceptOffer_Data["P85"].ToString().Trim();
        public string str_select_EmployementType_employmentTypeID { get; set; } // AcceptOffer_Data["P87"].ToString().Trim();

        
    }

}
