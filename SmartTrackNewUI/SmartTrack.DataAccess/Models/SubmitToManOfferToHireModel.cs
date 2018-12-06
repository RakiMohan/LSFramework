// --------------------------------------------------------------------------------------------------------------------
//<copyright file="SubmitToManOfferToHireModel.cs" company="DCR Workforce Inc">
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

    public class SubmitToManOfferToHireModel
    {
        public string strClientName {get;set;}// OfferToHire_Data["P5"].ToString().Trim();
        public string strMainMenuLink {get;set;}// OfferToHire_Data["P6"].ToString().Trim();
        public string strSubMenuLink {get;set;}// OfferToHire_Data["P7"].ToString().Trim();
        public string str_Link_ReqNumber {get;set;}// OfferToHire_Data["P8"].ToString().Trim();
        public string str_Link_ActionList_ViewCandidates {get;set;}// OfferToHire_Data["P9"].ToString().Trim();
        public string str_CandidateName {get;set;}// OfferToHire_Data["P10"].ToString().Trim();
        public string str_Link_ActionList_OfferToHire {get;set;}// OfferToHire_Data["P19"].ToString().Trim();
        public string str_Btn_OfferToHire_Continue {get;set;}// OfferToHire_Data["P20"].ToString().Trim();
        public string str_Txt_ProposeDifferentRate {get;set;}// OfferToHire_Data["P21"].ToString().Trim();
        public string str_Txt_Proposebillrate {get;set;}// OfferToHire_Data["P22"].ToString().Trim();
        public string str_Txt_Proposeotbillrate {get;set;}// OfferToHire_Data["P23"].ToString().Trim();
        public string str_Select_dayID {get;set;}// OfferToHire_Data["P24"].ToString().Trim();
        public string str_Txt_weeklyRegHoursNTE {get;set;}// OfferToHire_Data["P25"].ToString().Trim();
        public string str_Txt_weeklyOTHoursNTE {get;set;}// OfferToHire_Data["P26"].ToString().Trim();
        public string str_Txt_yearlyRegHoursNTE {get;set;}// OfferToHire_Data["P27"].ToString().Trim();
        public string str_Txt_totalContractValue {get;set;}// OfferToHire_Data["P28"].ToString().Trim();
        public string str_RadioButton_Emailwithcontractusage {get;set;}// OfferToHire_Data["P29"].ToString().Trim();
        public string str_Select_ddemailschedule {get;set;}// OfferToHire_Data["P30"].ToString().Trim();
        public string str_Txt_PrefStartdate {get;set;}// OfferToHire_Data["P31"].ToString().Trim();
        public string str_Txt_enddate {get;set;}// OfferToHire_Data["P32"].ToString().Trim();
        public string str_AddListTxt_txtTimecardApprover {get;set;}// OfferToHire_Data["P33"].ToString().Trim();
        public string str_DeleteListTxt_txtTimecardApprover {get;set;}// OfferToHire_Data["P34"].ToString().Trim();
        public string str_AddListTxt_ChargeNumbers {get;set;}// OfferToHire_Data["P35"].ToString().Trim();
        public string str_DeleteListTxt_ChargeNumbers {get;set;}// OfferToHire_Data["P36"].ToString().Trim();
        public string str_AddListTxt_GLNumbers {get;set;}// OfferToHire_Data["P37"].ToString().Trim();
        public string str_DeleteListTxt_GLNumbers {get;set;}// OfferToHire_Data["P38"].ToString().Trim();
        public string str_Btn_OfferToHire_Submit {get;set;}// OfferToHire_Data["P39"].ToString().Trim();
        public string str_Btn_OfferToHire_Submit_Confirm {get;set;}// OfferToHire_Data["P40"].ToString().Trim();
        public string str_Btn_OfferToHire_Submit_Confirm_Ok {get;set;}// OfferToHire_Data["P41"].ToString().Trim();
        public string str_typehead_FinancialNumber_financialNumber { get; set; }
        public string str_txt_FinancialLineItemNumber_financialLineItemNumber { get; set; }
        public string str_txt_Amount_financialAmount { get; set; }

        public string str_Txt_FinancialNumber { get; set; }
        public string str_select_GLBusinessUnit_chargeGLId { get; set; }
        public string str_Typeahead_Account_chargeCostCenterId { get; set; }
        public string str_Typeahead_OperatingUnit_chargeProfitCenterId { get; set; }
        public string str_Typeahead_DepartmentID_chargedeptNumber { get; set; }
        public string str_Typeahead_ProjectID_chargeProjectId { get; set; }
        public string str_Typeahead_WorkID_chargeprogramId { get; set; }
        public string str_select_Resource_chargespendLevelId { get; set; }

        //Added by manjusha
        public string str_Txt_Billrate_Supplierbillrate { get; set; }
        public string str_Txt_numberofhours_offertoHire { get; set; }
        public string str_Txt_numberofResources_offertoHire { get; set; }
        public string str_Txt_Estimatedcontract_offertoHire { get; set; }
        public string str_Txt_numberofDays_offertoHire { get; set; }

        //Identified
        public string str_Txt_payrate_ProposepayrateForMarkup { get; set; }// OfferToHire_Data["P90"].ToString().Trim();
        public string str_Txt_OTpayrate_ProposeotpayrateForMarkup { get; set; }// OfferToHire_Data["P91"].ToString().Trim();
        public string str_Txt_payratemarkup_supplierpayratemarkup { get; set; }// OfferToHire_Data["P92"].ToString().Trim();
        public string str_Txt_BillRate_ProposebillrateForMarkup { get; set; }// OfferToHire_Data["P93"].ToString().Trim();
        public string str_Txt_OTBillRate_ProposeotbillrateForMarkup { get; set; }// OfferToHire_Data["P94"].ToString().Trim();
        public string str_Select_ChargeNumberTypes { get; set; }// OfferToHire_Data["P95"].ToString().Trim();
        public string str_Typeahead_ChargeNumbers_txtChargeNo { get; set; }// OfferToHire_Data["P96"].ToString().Trim();
        public string str_Txt_LastName_lastname { get; set; }// OfferToHire_Data["P97"].ToString().Trim();
        public string str_Txt_FirstName_firstname { get; set; }// OfferToHire_Data["P98"].ToString().Trim();
        public string str_Txt_MiddleName_middlename { get; set; }// OfferToHire_Data["P99"].ToString().Trim();
        public string str_Select_Suffix_nameSuffix { get; set; }// OfferToHire_Data["P100"].ToString().Trim();
        public string str_btn_UploadResume_uploadResume { get; set; }// OfferToHire_Data["P101"].ToString().Trim();
        public string str_Radiobutton_Retiree_retiredEmployee { get; set; }// OfferToHire_Data["P102"].ToString().Trim();
        public string str_Txt_RetireeDetails_retiredEmployeeDetails { get; set; }// OfferToHire_Data["P103"].ToString().Trim();
        public string str_radiobutton_FormerEmployee_exEmployee { get; set; }// OfferToHire_Data["P104"].ToString().Trim();
        public string str_Txt_FormerEmployeeDetails_exEmployeeDetails { get; set; }// OfferToHire_Data["P105"].ToString().Trim();
        public string str_radiobutton_FormerIntern_exIntern { get; set; }// OfferToHire_Data["P106"].ToString().Trim();
        public string str_Txt_FormerInternDetails_exInternDetails { get; set; }// OfferToHire_Data["P107"].ToString().Trim();
        public string str_radiobutton_FormerContractor_exContractor { get; set; }// OfferToHire_Data["P108"].ToString().Trim();
        public string str_Txt_FormerContractorDetails_exContractorDetails { get; set; }// OfferToHire_Data["P109"].ToString().Trim();
        public string str_Txt_Justification_soleJustificationDescription { get; set; }// OfferToHire_Data["P110"].ToString().Trim();
        public string str_btn_UploadJustification_uploadJustification { get; set; }// OfferToHire_Data["P111"].ToString().Trim();
        public string str_Typeahead_Supplier_supplierName { get; set; }// OfferToHire_Data["P112"].ToString().Trim();
        public string str_Txt_ContactLastName_recruiterLastName { get; set; }// OfferToHire_Data["P113"].ToString().Trim();
        public string str_Txt_ContactFirstName_recruiterFirstName { get; set; }// OfferToHire_Data["P114"].ToString().Trim();
        public string str_Txt_Phone_workPhone { get; set; }// OfferToHire_Data["P115"].ToString().Trim();
        public string str_Txt_Email_workEmail { get; set; }// OfferToHire_Data["P116"].ToString().Trim();
        public string str_Radiobuttion_FormerUSGovtMilitaryEmployee_exGovMilEmployee { get; set; }// OfferToHire_Data["P117"].ToString().Trim();        
        public string str_Txt_FormerUSGovtMilitaryEmployeeDetails_exGovMilEmployeeDetails { get; set; }// OfferToHire_Data["P118"].ToString().Trim();
        public string str_Select_RateLevel_ddRateLevel { get; set; }// OfferToHire_Data["P119"].ToString().Trim();
    }
}
