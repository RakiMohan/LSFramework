// --------------------------------------------------------------------------------------------------------------------
//<copyright file="SubmitToManExtendOfferMethodModel.cs" company="DCR Workforce Inc">
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

    public class SubmitToManExtendOfferMethodModel
    {
            public string strClientName {get;set;}// ExtendOffer_Data["P5"].ToString().Trim();
            public string strMainMenuLink {get;set;}// ExtendOffer_Data["P6"].ToString().Trim();
            public string strSubMenuLink {get;set;}// ExtendOffer_Data["P7"].ToString().Trim();
            public string str_Link_ReqNumber {get;set;}// ExtendOffer_Data["P8"].ToString().Trim();
            public string str_Link_ActionList_ViewCandidates {get;set;}// ExtendOffer_Data["P44"].ToString().Trim();
            public string str_Link_ActionList_ExperienceValidation {get;set;}// ExtendOffer_Data["P44"].ToString().Trim();
            public string str_CandidateName {get;set;}// ExtendOffer_Data["P10"].ToString().Trim();
            public string str_Txt_Years {get;set;}// ExtendOffer_Data["P46"].ToString().Trim();
            public string str_Link_ActionList_ExtendOffer {get;set;}// ExtendOffer_Data["P46"].ToString().Trim();
            public string str_Txt_Months {get;set;}// ExtendOffer_Data["P47"].ToString().Trim();
            public string str_Txt_proposedRegPayRate {get;set;}// ExtendOffer_Data["P47"].ToString().Trim();   //Proposed Pay Rate
            public string str_Txt_proposedOTPayRate {get;set;}// ExtendOffer_Data["P48"].ToString().Trim();//Proposed OT Pay Rate
            public string str_Txt_payRateMarkup {get;set;}// ExtendOffer_Data["P49"].ToString().Trim();//Pay Rate Markup%:
            public string str_Txt_proposedRegBillRate {get;set;}// ExtendOffer_Data["P50"].ToString().Trim();//Proposed Supplier Bill Rate:
            public string str_Txt_proposedOTBillRate {get;set;}// ExtendOffer_Data["P51"].ToString().Trim(); //Proposed Supplier OT Bill Rate:
            public string str_Txt_finalRegBillRate {get;set;}// ExtendOffer_Data["P52"].ToString().Trim();//Final Bill Rate: 
            public string str_Txt_finalOTBillRate {get;set;}// ExtendOffer_Data["P53"].ToString().Trim();//Final OT Bill Rate:  
            public string str_Txt_weeklyRegHoursNTE {get;set;}// ExtendOffer_Data["P54"].ToString().Trim();
            public string str_Txt_weeklyOTHoursNTE {get;set;}// ExtendOffer_Data["P55"].ToString().Trim();
            public string str_Txt_yearlyRegHoursNTE {get;set;}// ExtendOffer_Data["P56"].ToString().Trim();
            public string str_Txt_totalContractValue {get;set;}// ExtendOffer_Data["P57"].ToString().Trim();
            public string str_Txt_PrefStartdate {get;set;}// ExtendOffer_Data["P58"].ToString().Trim();
            public string str_Txt_enddate {get;set;}// ExtendOffer_Data["P59"].ToString().Trim();
            public string str_AddListTxt_txtTimecardApprover {get;set;}// ExtendOffer_Data["P60"].ToString().Trim();
            public string str_DeleteListTxt_txtTimecardApprover {get;set;}// ExtendOffer_Data["P61"].ToString().Trim();
            public string str_AddListTxt_ChargeNumbers {get;set;}// ExtendOffer_Data["P62"].ToString().Trim();
            public string str_DeleteListTxt_ChargeNumbers {get;set;}// ExtendOffer_Data["P63"].ToString().Trim();
            public string str_AddListTxt_GLNumbers {get;set;}// ExtendOffer_Data["P64"].ToString().Trim();
            public string str_DeleteListTxt_GLNumbers {get;set;}// ExtendOffer_Data["P65"].ToString().Trim();
            //  public string str_Txt_ProposedSupplierOTBillRate {get;set;}// ExtendOffer_Data["P14"].ToString().Trim();
            //  public string str_Txt_proposedRegBillRate {get;set;}// ExtendOffer_Data["P14"].ToString().Trim();
            //  public string str_Txt_proposedOTBillRate {get;set;}// ExtendOffer_Data["P14"].ToString().Trim();
            //   public string str_Txt_Proposebillrate {get;set;}// ExtendOffer_Data["P15"].ToString().Trim();
            //  public string str_Txt_finalRegBillRate {get;set;}// ExtendOffer_Data["P15"].ToString().Trim();
            // public string str_Txt_proposedOTPayRate {get;set;}// ExtendOffer_Data["P15""].ToString().Trim();
            //   public string str_Txt_Proposeotbillrate {get;set;}// ExtendOffer_Data["P16"].ToString().Trim();
            public string str_Btn_ExtendOffer_Submit {get;set;}// ExtendOffer_Data["P66"].ToString().Trim();
            public string str_Btn_ExtendOffer_Submit_Confirm {get;set;}// ExtendOffer_Data["P67"].ToString().Trim();
            public string str_Btn_ExtendOffer_Submit_Confirm_Ok {get;set;}// ExtendOffer_Data["P68"].ToString().Trim();
            public string str_Txt_poNumber {get;set;}// ExtendOffer_Data["P69"].ToString().Trim();     

            public string str_Txt_ProposeDifferentRate { get; set; }// ExtendOffer_Data["P75"].ToString().Trim();
            //Added by manjusha
            public string str_Txt_Billrate_Supplierbillrate { get; set; }
            public string str_Txt_numberofhours_offertoHire { get; set; }
            public string str_Txt_numberofResources_offertoHire { get; set; }
            public string str_Txt_Estimatedcontract_offertoHire { get; set; }
            public string str_Txt_numberofDays_offertoHire { get; set; }
            public string str_Txt_IdentifiedCandidate_PayRateMarkup_markup { get; set; }// ExtendOffer_Data["P47"].ToString().Trim();
    }
}
