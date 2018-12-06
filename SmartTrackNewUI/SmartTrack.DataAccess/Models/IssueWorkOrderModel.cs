// --------------------------------------------------------------------------------------------------------------------
//<copyright file{get;set;}//"IssueWorkOrderModel.cs" company{get;set;}//"DCR Workforce Inc">
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

    public class IssueWorkOrderModel
    {
        public string strClientName { get; set; }// IssueWorkOrder_Data["P5"].ToString().Trim();
        public string strMainMenuLink { get; set; }// IssueWorkOrder_Data["P6"].ToString().Trim();
        public string strSubMenuLink { get; set; }// IssueWorkOrder_Data["P7"].ToString().Trim();
        public string str_Link_ReqNumber { get; set; }// IssueWorkOrder_Data["P8"].ToString().Trim();
        public string str_Link_ActionList_ViewCandidates { get; set; }// IssueWorkOrder_Data["P9"].ToString().Trim();
        public string str_CandidateName { get; set; }// IssueWorkOrder_Data["P10"].ToString().Trim();
        public string str_Txt_Years { get; set; }// IssueWorkOrder_Data["P11"].ToString().Trim();
        public string str_Link_ActionList_IssueWorkOrder { get; set; }// IssueWorkOrder_Data["P11"].ToString().Trim();
        public string str_AddListTxt_txtTimecardApprover { get; set; }// IssueWorkOrder_Data["P12"].ToString().Trim();
        public string str_DeleteListTxt_txtTimecardApprover { get; set; }// IssueWorkOrder_Data["P13"].ToString().Trim();
        public string str_AddListTxt_ChargeNumbers { get; set; }// IssueWorkOrder_Data["P14"].ToString().Trim();
        public string str_DeleteListTxt_ChargeNumbers { get; set; }// IssueWorkOrder_Data["P15"].ToString().Trim();
        public string str_AddListTxt_GLNumbers { get; set; }// IssueWorkOrder_Data["P16"].ToString().Trim();
        public string str_DeleteListTxt_GLNumbers { get; set; }// IssueWorkOrder_Data["P17"].ToString().Trim();
        public string str_Txt_PrefStartdate { get; set; }// IssueWorkOrder_Data["P18"].ToString().Trim();
        public string str_Txt_enddate { get; set; }// IssueWorkOrder_Data["P19"].ToString().Trim();
        public string str_Txt_supplierRegPayRate { get; set; }// IssueWorkOrder_Data["P20"].ToString().Trim();//Candidate Pay Rate
        public string str_Txt_supplierOTPayRate { get; set; }// IssueWorkOrder_Data["P21"].ToString().Trim();//Candidate OT Pay Rate
        public string str_Txt_supplierRegBillRate { get; set; }// IssueWorkOrder_Data["P22"].ToString().Trim(); //Supplier Bill Rate
        public string str_Txt_supplierOTBillRate { get; set; }// IssueWorkOrder_Data["P23"].ToString().Trim(); //Supplier OT Bill Rate
        public string str_Txt_supplierMarkupRate { get; set; }// IssueWorkOrder_Data["P24"].ToString().Trim(); //Supplier Markup%
        public string str_Txt_ProposedFinalRegBillRate { get; set; }// IssueWorkOrder_Data["P25"].ToString().Trim();//Final Bill Rate dcr
        public string str_Txt_finalRegBillRate { get; set; }// IssueWorkOrder_Data["P25"].ToString().Trim();//Final Bill Rate
        public string str_Txt_proposedFinalOTBillRate { get; set; }// IssueWorkOrder_Data["P26"].ToString().Trim();//Final OT Bill Rate dcr
        public string str_Txt_finalOTBillRate { get; set; }// IssueWorkOrder_Data["P26"].ToString().Trim();//Final OT Bill Rate
        public string str_Txt_mspFeeMarkup { get; set; }// IssueWorkOrder_Data["P27"].ToString().Trim();//MSP Fee %
        public string str_Txt_mspRegBillRate { get; set; }// IssueWorkOrder_Data["P28"].ToString().Trim();//MSP Fee, MSP Rate
        public string str_Txt_mspOTBillRate { get; set; }// IssueWorkOrder_Data["P29"].ToString().Trim(); //MSP OT Fee, MSP OT Rate
        public string str_Txt_vmsRegBillRate { get; set; }// IssueWorkOrder_Data["P30"].ToString().Trim();//VMS Rate
        public string str_Txt_vmsOTBillRate { get; set; }// IssueWorkOrder_Data["P31"].ToString().Trim();//VMS OT Rate
        public string str_Txt_purchaseOrderNumber { get; set; }// IssueWorkOrder_Data["P32"].ToString().Trim(); 
        public string str_Txt_WeeklySpendValue { get; set; }// IssueWorkOrder_Data["P35"].ToString().Trim();
        public string str_Txt_weeklyRegHoursNTE { get; set; }// IssueWorkOrder_Data["P36"].ToString().Trim();
        public string str_Txt_weeklyOTHoursNTE { get; set; }// IssueWorkOrder_Data["P37"].ToString().Trim();
        public string str_Txt_yearlyRegHoursNTE { get; set; }// IssueWorkOrder_Data["P38"].ToString().Trim();
        public string str_Txt_totalContractValue { get; set; }// IssueWorkOrder_Data["P39"].ToString().Trim();
        public string str_Btn_IssueWorkOrder_Submit { get; set; }// IssueWorkOrder_Data["P40"].ToString().Trim();
        public string str_Btn_IssueWorkOrder_Submit_Confirm { get; set; }// IssueWorkOrder_Data["P41"].ToString().Trim();
        public string str_Btn_IssueWorkOrder_Submit_Confirm_Ok { get; set; }// IssueWorkOrder_Data["P42"].ToString().Trim();
        public string str_Link_CancelWorkOrder { get; set; }//// IssueWorkOrder_Data["P43"].ToString().Trim();
        public string str_Txt_CancelWorkOrdercomment { get; set; }//// IssueWorkOrder_Data["P44"].ToString().Trim();
        public string str_Button_CancelWorkOrderbutton { get; set; }//// IssueWorkOrder_Data["P45"].ToString().Trim();
        public string str_Button_CancelWorkOrderbutton_yes { get; set; }//// IssueWorkOrder_Data["P46"].ToString().Trim();
        public string str_Btn_ExtendOffer_Submit_Confirm_Ok { get; set; }//// IssueWorkOrder_Data["P47"].ToString().Trim();
        public string str_Link_issueworkorder_Editcandidateinfo { get; set; }//// IssueWorkOrder_Data["P48"].ToString().Trim();
        public string str_Button_issueworkorder_Editcandidateinfo_OK { get; set; }//// IssueWorkOrder_Data["P49"].ToString().Trim();

        //Cp Chem
        public string str_txt_TimecardApprovers_txtTimecardApprover { get; set; }//// IssueWorkOrder_Data["P10"].ToString().Trim();
        public string str_txt_GLNumbers_txtGLNo { get; set; }//// IssueWorkOrder_Data["P12"].ToString().Trim();
        public string str_btn_GLNumberAdd_addGLNobtn { get; set; }//// IssueWorkOrder_Data["P13"].ToString().Trim();
        public string str_btn_GLNumberDelete_deleteGLNobtn { get; set; }//// IssueWorkOrder_Data["P14"].ToString().Trim();
        public string str_Date_AnticipatedStartDate_preferredStartDate { get; set; }//// IssueWorkOrder_Data["P16"].ToString().Trim();
        public string str_Date_StartDate_preferredStartDate { get; set; }//// IssueWorkOrder_Data["P16"].ToString().Trim();
        public string str_Date_NeededStartDate_preferredStartDate { get; set; }//// IssueWorkOrder_Data["P16"].ToString().Trim();
        public string str_Date_Enddate_endDate { get; set; }//// IssueWorkOrder_Data["P17"].ToString().Trim();
        public string str_Date_AssignmentEndDate_endDate { get; set; }//// IssueWorkOrder_Data["P17"].ToString().Trim();
        public string str_Txt_PoNumber_purchaseOrderNumber { get; set; }//// IssueWorkOrder_Data["P29"].ToString().Trim();
        public string str_txt_CandidatePayRate_supplierRegPayRate { get; set; }//// IssueWorkOrder_Data["P18"].ToString().Trim();
        public string str_txt_CandidateOTPayRate_supplierOTPayRate { get; set; }//// IssueWorkOrder_Data["P19"].ToString().Trim();
        public string str_txt_SupplierBillRate_supplierRegBillRate { get; set; }//// IssueWorkOrder_Data["P20"].ToString().Trim();
        public string str_txt_SupplierOTBillRate_supplierOTBillRate { get; set; }//// IssueWorkOrder_Data["P21"].ToString().Trim();
        public string str_txt_IW_SupplierMarkup_supplierMarkupRate { get; set; }//// IssueWorkOrder_Data["P22"].ToString().Trim();
        public string str_txt_FinalBillRate_finalRegBillRate { get; set; }//// IssueWorkOrder_Data["P23"].ToString().Trim();
        public string str_txt_FinalOTBillRate_finalOTBillRate { get; set; }//// IssueWorkOrder_Data["P24"].ToString().Trim();
        public string str_txt_SupplierMarkup_supplierMarkupRate { get; set; }//// IssueWorkOrder_Data["P22"].ToString().Trim();
        public string str_txt_MspFee_mspFeeMarkup { get; set; }//// IssueWorkOrder_Data["P25"].ToString().Trim();
        public string str_txt_MspFee_mspRegBillRate { get; set; }//// IssueWorkOrder_Data["P26"].ToString().Trim();
        public string str_txt_MSPRate_mspRegBillRate { get; set; }//// IssueWorkOrder_Data["P26"].ToString().Trim();
        public string str_txt_MspOtFee_mspOTBillRate { get; set; }//// IssueWorkOrder_Data["P27"].ToString().Trim();
        public string str_txt_MSPOTRate_mspOTBillRate { get; set; }//// IssueWorkOrder_Data["P27"].ToString().Trim();
        public string str_txt_HoursperweekNTE_weeklyRegHoursNTE { get; set; }//// IssueWorkOrder_Data["P34"].ToString().Trim();
        public string str_txt_OThoursperweekNTE_weeklyOTHoursNTE { get; set; }//// IssueWorkOrder_Data["P35"].ToString().Trim();
        public string str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE { get; set; }//// IssueWorkOrder_Data["P36"].ToString().Trim();
        public string str_txt_EstimatedContractValue_totalContractValue { get; set; }//// IssueWorkOrder_Data["P37"].ToString().Trim();
        public string str_txt_TotalContractValue_totalContractValue { get; set; }//// IssueWorkOrder_Data["P37"].ToString().Trim();
        public string str_Typeahead_ChargeCostCenterNumber_chargeCostCenterId { get; set; }//// IssueWorkOrder_Data["P30"].ToString().Trim();
        public string str_Typeahead_BusinessUnit_chargeCostCenterId { get; set; }//// IssueWorkOrder_Data["P30"].ToString().Trim();
        public string str_Typeahead_ChargeProjectWBSElement_chargeProjectId { get; set; }//// IssueWorkOrder_Data["P31"].ToString().Trim();
        public string str_Typeahead_ProjectCodeCFR_chargeProjectId { get; set; }//// IssueWorkOrder_Data["P31"].ToString().Trim();
        public string str_select_GLNumber_chargeGLId { get; set; }//// IssueWorkOrder_Data["P32"].ToString().Trim();
        public string str_select_ObjectAccount_chargeGLId { get; set; }//// IssueWorkOrder_Data["P32"].ToString().Trim();
        public string str_select_CompanyCode_chargedeptNumber { get; set; }//// IssueWorkOrder_Data["P32"].ToString().Trim();
        public string str_Typeahead_ChargeNumbers_txtChargeNo { get; set; }//// IssueWorkOrder_Data["P41"].ToString().Trim();
        public string str_select_ChargeNumbersCompanyCode_deptNumber { get; set; }//// IssueWorkOrder_Data["P33"].ToString().Trim();
        public string str_select_CostCenter_CostCenterId { get; set; }//// IssueWorkOrder_Data["P33"].ToString().Trim();
        public string str_select_WBS_ProjectId { get; set; }//// IssueWorkOrder_Data["P31"].ToString().Trim();
        public string str_Date_DesiredStartDate_preferredStartDate { get; set; }//// IssueWorkOrder_Data["P16"].ToString().Trim();
        public string str_select_ChargeNumberType_ChargeNumberTypes { get; set; }//// IssueWorkOrder_Data["P31"].ToString().Trim();
        public string str_Typeahead_ChargeNumber_txtCharge { get; set; }//// IssueWorkOrder_Data["P41"].ToString().Trim();
        public string str_select_AccountCodingsAccountUnit_deptNumber { get; set; }//// IssueWorkOrder_Data["P44"].ToString().Trim();
        public string str_select_AccountCodingsCompany_siteLocationID { get; set; }//// IssueWorkOrder_Data["P45"].ToString().Trim();
        public string str_select_AccountCodingsProject_ProjectId { get; set; }//// IssueWorkOrder_Data["P46"].ToString().Trim();
        public string str_select_AccountCodingsActivity_ProfitCenterId { get; set; }//// IssueWorkOrder_Data["P47"].ToString().Trim();
        public string str_Typeahead_ChargeNumberProjectName_ChargeprogramId { get; set; }//// IssueWorkOrder_Data["P41"].ToString().Trim();
        public string str_Typeahead_ChargeNumberProjectNumber_ChargeCostCenterId { get; set; }//// IssueWorkOrder_Data["P42"].ToString().Trim();
        public string str_Typeahead_ChargeNumberPOID_ChargeProjectId { get; set; }//// IssueWorkOrder_Data["P43"].ToString().Trim();
        public string str_txt_EstimatedLaborandExpCost_totalContractValue { get; set; }//// IssueWorkOrder_Data["P37"].ToString().Trim();
        public string str_Click_TimecardApproversDelete_deleteTimecardApproverbtn { get; set; }//// IssueWorkOrder_Data["P11"].ToString().Trim();
        public string str_txt_SocialSecurityNumber_candidateSSN { get; set; }//// IssueWorkOrder_Data["P48"].ToString().Trim();
        public string str_Date_DateofBirth_DOB { get; set; }//// IssueWorkOrder_Data["P49"].ToString().Trim();
        public string str_select_Gender_Gender { get; set; }//// IssueWorkOrder_Data["P50"].ToString().Trim();
        public string str_txt_Last4digitsofssn_STID1 { get; set; }//// IssueWorkOrder_Data["P51"].ToString().Trim();
        public string str_select_Month_STID2 { get; set; }//// IssueWorkOrder_Data["P52"].ToString().Trim();
        public string str_select_Date_STID3 { get; set; }//// IssueWorkOrder_Data["P53"].ToString().Trim();
        public string str_Date_PrefferedStartDate_preferredStartDate { get; set; }//// IssueWorkOrder_Data["P16"].ToString().Trim();
        //public string str_Date_NeededStartDate_preferredStartDate { get; set; }
        public string str_txt_ChargeNumberPA_txtChargePA { get; set; }//// IssueWorkOrder_Data["P54"].ToString().Trim();
        public string str_select_ChargeNumberPAA_chargeCostCenterId { get; set; }//// IssueWorkOrder_Data["P55"].ToString().Trim();
        public string str_Typeahead_ChargeNumberLegalEntity_ChargeorganizationID { get; set; }//// IssueWorkOrder_Data["P56"].ToString().Trim();
        public string str_Typeahead_ChargeNumberBusinessArea_ChargeProjectId { get; set; }//// IssueWorkOrder_Data["P57"].ToString().Trim();
        public string str_Typeahead_ChargeNumbernaturalAccount_ChargeGLId { get; set; }//// IssueWorkOrder_Data["P58"].ToString().Trim();
        public string str_Typeahead_ChargeNumberLocalAnalysis_ChargesiteLocationID { get; set; }//// IssueWorkOrder_Data["P59"].ToString().Trim();
        public string str_Typeahead_ChargeNumberCostCenter_ChargeCostCenterId { get; set; }//// IssueWorkOrder_Data["P60"].ToString().Trim();
        public string str_Typeahead_ChargeNumberInterCompany_ChargedeptNumber { get; set; }//// IssueWorkOrder_Data["P61"].ToString().Trim();
        public string str_Date_EndDate_endDate { get; set; }
        public string str_Typeahead_PONumber_purchaseOrderNumber { get; set; }//// IssueWorkOrder_Data["P29"].ToString().Trim();
        public string str_Select_BusinessUnit_ChargeProjectId { get; set; }//// IssueWorkOrder_Data["P57"].ToString().Trim();
        public string str_Select_Reqtype_ChargeorganizationID { get; set; }//// IssueWorkOrder_Data["P56"].ToString().Trim();
        public string str_typeahead_CostCenter_ChargeCostCenterId { get; set; }//// IssueWorkOrder_Data["P60"].ToString().Trim();
        public string str_Typeahead_Department_ChargeorganizationID { get; set; }//// IssueWorkOrder_Data["P56"].ToString().Trim();
        public string str_Select_AccountCode_ChargeCostCenterId { get; set; }//// IssueWorkOrder_Data["P60"].ToString().Trim();
        public string str_Txt_WorkDayID_customerTrackingNumber { get; set; }//// IssueWorkOrder_Data["P62"].ToString().Trim();
        public string str_Typeahead_ChargeCompanyNumber_deptNumber { get; set; }//// IssueWorkOrder_Data["P33"].ToString().Trim();
        public string str_Typeahead_APCostCenter_CostCenterId { get; set; }//// IssueWorkOrder_Data["P30"].ToString().Trim();
        public string str_Select_ChargeGLAccount_ChargeGLId { get; set; }//// IssueWorkOrder_Data["P58"].ToString().Trim();
        public string str_Txt_CalculatedMarkup_calculatedMarkup { get; set; }//// IssueWorkOrder_Data["P63"].ToString().Trim();
        // public string str_txt_MSPFeeMarkup_mspFeeMarkup { get; set; }       // public string str_txt_MSPFeeMarkup_mspFeeMarkup { get; set; }

        //QL
        public string str_Select_CORE_ChargeProjectId { get; set; }//// IssueWorkOrder_Data["P57"].ToString().Trim();
        public string str_Select_Businessunit_ChargeorganizationID { get; set; }//// IssueWorkOrder_Data["P56"].ToString().Trim();
        public string str_typeahead_BusinessArea_ChargeCostCenterId { get; set; }//// IssueWorkOrder_Data["P60"].ToString().Trim();
        public string str_Typeahead_AccountCode_ChargeCostCenterId { get; set; }//// IssueWorkOrder_Data["P60"].ToString().Trim();
        public string str_Select_ExpenseAccount_ChargeGLId { get; set; }//// IssueWorkOrder_Data["P58"].ToString().Trim();
        public string str_Select_HyperionCodeGLUnit_ChargeGLId { get; set; }//// IssueWorkOrder_Data["P58"].ToString().Trim();
        public string str_Typeahead_APDepartment_ChargedeptName { get; set; }//// IssueWorkOrder_Data["P64"].ToString().Trim();

      //  public string str_Select_Businessunit_ChargeorganizationID { get; set; }//// IssueWorkOrder_Data["P56"].ToString().Trim();
        public string str_Select_HypersionCodeGLUnit_ChargeGLId { get; set; }//// IssueWorkOrder_Data["P58"].ToString().Trim();
        public string str_Select_APDepartment_ChargedeptName { get; set; }//// IssueWorkOrder_Data["P64"].ToString().Trim();
        //Added by manjusha
        public string str_Txt_Billrate_Supplierbillrate { get; set; }
        public string str_Txt_numberofhours_offertoHire { get; set; }
        public string str_Txt_numberofResources_offertoHire { get; set; }
        public string str_Txt_Estimatedcontract_offertoHire { get; set; }
        public string str_Txt_numberofDays_offertoHire { get; set; }
        public string str_Typeahead_Company_ChargedeptNumber { get; set; }        
        public string str_Typeahead_PoNumber_purchaseOrderNumber { get; set; }        
        public string str_txt_ActiveDirectoryID_customerTrackingNumber { get; set; }

        public string str_Typeahead_WBSElement_ChargeProjectId { get; set; }//// IssueWorkOrder_Data["P31"].ToString().Trim();
        public string str_Typeahead_GL_ChargeGLId { get; set; }//// IssueWorkOrder_Data["P32"].ToString().Trim();


    }

}
