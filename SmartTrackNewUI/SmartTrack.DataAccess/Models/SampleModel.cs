// --------------------------------------------------------------------------------------------------------------------
//<copyright file{get;set;}//"ConfirmCWModel.cs" company{get;set;}//"DCR Workforce Inc">
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

    public class SampleModel
    {
        //public string str_select_HeadcountApproved_ddlaborClassCode;
        public string strClientName { get; set; }// ConfirmCW_Data["P5"].ToString().Trim();
        public string strMainMenuLink { get; set; }// ConfirmCW_Data["P6"].ToString().Trim();
        public string strSubMenuLink { get; set; }// ConfirmCW_Data["P7"].ToString().Trim();
        public string str_Link_ReqNumber { get; set; }// ConfirmCW_Data["P8"].ToString().Trim();
        public string str_Link_ActionList_ViewCandidates { get; set; }// ConfirmCW_Data["P9"].ToString().Trim();
        public string str_CandidateName { get; set; }// ConfirmCW_Data["P10"].ToString().Trim();
        public string str_Link_ActionList_ConfirmCW { get; set; }// ConfirmCW_Data["P11"].ToString().Trim();
        public string str_Txt_LastName { get; set; }// ConfirmCW_Data["P12"].ToString().Trim();
        public string str_Txt_FirstName { get; set; }// ConfirmCW_Data["P13"].ToString().Trim();
        public string str_Txt_MiddleName { get; set; }// ConfirmCW_Data["P14"].ToString().Trim();
        public string str_Select_SuffixName { get; set; }// ConfirmCW_Data["P15"].ToString().Trim();
        public string str_Txt_SmartTrackIdentifier { get; set; }// ConfirmCW_Data["P16"].ToString().Trim();
        public string str_Txt_jobTitleName { get; set; }// ConfirmCW_Data["P17"].ToString().Trim();
        public string str_Select_programName { get; set; }// ConfirmCW_Data["P18"].ToString().Trim();
        public string str_Radio_CWUser { get; set; }// ConfirmCW_Data["P18"].ToString().Trim();
        public string str_Txt_candidateEmail { get; set; }

        public string str_TypeHead_deptNumber { get; set; }// ConfirmCW_Data["P20"].ToString().Trim();
        public string str_Txt_isCWuserEmail { get; set; }// ConfirmCW_Data["P19"].ToString().Trim();
        public string str_TypeHead_deptName { get; set; }// ConfirmCW_Data["P40"].ToString().Trim();
        public string str_Txt_matrixNumber { get; set; }// ConfirmCW_Data["P21"].ToString().Trim();
        public string str_Select_serviceType { get; set; }// ConfirmCW_Data["P22"].ToString().Trim();
        public string str_Select_reqType { get; set; }// ConfirmCW_Data["P23"].ToString().Trim();
        public string str_selectOrgId { get; set; }// ConfirmCW_Data["P24"].ToString().Trim();
        public string str_Select_serviceMethodID { get; set; }
        public string str_select_CostCenterId { get; set; }
        public string str_Select_GLId { get; set; }
        public string str_Select_MaterialGroup { get; set; }

        public string str_Txt_SSN { get; set; }
        public string str_Select_Month { get; set; }
        public string str_Select_Date { get; set; }
        public string str_Select_Year { get; set; }
        public string str_Select_rateTypeID { get; set; }
        public string str_Select_savingsTypeID { get; set; }
        public string str_Select_paycodeId { get; set; }
        public string str_Txt_payCodePayRate { get; set; }

        public string str_Txt_payCodeSupplierBillrate { get; set; }
        public string str_Select_SCountry { get; set; }
        public string str_Select_SState { get; set; }
        public string str_Select_SCounty { get; set; }


        public string str_Radio_isCWuser1 { get; set; }

        public string str_selectworkLocationID { get; set; }// ConfirmCW_Data["P25"].ToString().Trim();
        public string str_Txt_JobCode { get; set; }// ConfirmCW_Data["P26"].ToString().Trim();
        public string str_Select_siteLocationID { get; set; }// ConfirmCW_Data["P27"].ToString().Trim();
        public string str_Txt_hiringManagerName { get; set; }// ConfirmCW_Data["P28"].ToString().Trim();
        public string str_Txt_alternateHiringManagerName { get; set; }// ConfirmCW_Data["P29"].ToString().Trim();
        public string str_Txt_cwKeyWords { get; set; }// ConfirmCW_Data["P30"].ToString().Trim();
        public string str_Select_supplierContact { get; set; }// ConfirmCW_Data["P31"].ToString().Trim();
        public string str_Select_invoicePaymentContact { get; set; }// ConfirmCW_Data["P32"].ToString().Trim();
        public string str_AddListTxt_txtTimecardApprover { get; set; }// ConfirmCW_Data["P33"].ToString().Trim();
        public string str_DeleteListTxt_txtTimecardApprover { get; set; }// ConfirmCW_Data["P34"].ToString().Trim();
        public string str_AddListTxt_ChargeNumbers { get; set; }// ConfirmCW_Data["P35"].ToString().Trim();
        public string str_DeleteListTxt_ChargeNumbers { get; set; }// ConfirmCW_Data["P36"].ToString().Trim();
        public string str_AddListTxt_GLNumbers { get; set; }// ConfirmCW_Data["P37"].ToString().Trim();
        public string str_DeleteListTxt_GLNumbers { get; set; }// ConfirmCW_Data["P38"].ToString().Trim();
        public string str_Txt_purchaseOrderNumber { get; set; }// ConfirmCW_Data["P39"].ToString().Trim();
        public string str_RadioBtn_WarehouseWorker_directIndirect { get; set; }// ConfirmCW_Data["P39"].ToString().Trim();
        public string str_Txt_customerTrackingNumber { get; set; }// ConfirmCW_Data["P40"].ToString().Trim(); //VIP Number
        public string str_Txt_RadioBtn_ChargingMethod_exemptFlag { get; set; }// ConfirmCW_Data["P41"].ToString().Trim();
        public string str_Txt_customerTrackingNumber2 { get; set; }// ConfirmCW_Data["P42"].ToString().Trim();//NEAT ID
        public string str_Txt_customerTrackingNumber3 { get; set; }// ConfirmCW_Data["P43"].ToString().Trim();//LMP ID
        public string str_Txt_badgeNumber { get; set; }// ConfirmCW_Data["P44"].ToString().Trim();
        public string str_Txt_LineItem { get; set; }// ConfirmCW_Data["P44"].ToString().Trim();
        public string str_Select_ddlaborClassCode { get; set; }// ConfirmCW_Data["P45"].ToString().Trim();
        public string str_Select_AccountType { get; set; }// ConfirmCW_Data["P46"].ToString().Trim();
        public string str_Select_dayID { get; set; }// ConfirmCW_Data["P47"].ToString().Trim();
        public string str_Select_workweek { get; set; }// ConfirmCW_Data["P48"].ToString().Trim();
        public string str_Select_shiftID { get; set; }// ConfirmCW_Data["P49"].ToString().Trim();
        public string str_Txt_PrefStartdate { get; set; }// ConfirmCW_Data["P50"].ToString().Trim();
        public string str_select_Businesunit { get; set; }// ConfirmCW_Data["P96"].ToString().Trim();
        public string str_select_Employmenttype { get; set; }// ConfirmCW_Data["P97"].ToString().Trim();
        public string str_Radio_TImesheet { get; set; }// ConfirmCW_Data["P98"].ToString().Trim();

        //  DateTime dt {get;set;}// DateTime.ParseExact(str_Txt_PrefStartdate, "MM/dd/yyyy", null);
        //   str_Txt_PrefStartdate {get;set;}// dt.ToString("MM/dd/yyyy");

        public string str_Txt_enddate { get; set; }// ConfirmCW_Data["P51"].ToString().Trim();
        public string str_RadioBtn_TimeSheet_FromSTTimeSheet { get; set; }// ConfirmCW_Data["P52"].ToString().Trim();
        public string str_RadioBtn_Rehire { get; set; }// ConfirmCW_Data["P52"].ToString().Trim();
        public string str_Txt_regPayRate { get; set; }// ConfirmCW_Data["P53"].ToString().Trim();//Proposed Pay Rate
        public string str_Txt_OTPayRate { get; set; }// ConfirmCW_Data["P54"].ToString().Trim();//Proposed OT Pay Rate
        public string str_Txt_regBillRate { get; set; }// ConfirmCW_Data["P55"].ToString().Trim(); //Proposed Bill Rate
        public string str_Txt_OTBillRate { get; set; }// ConfirmCW_Data["P56"].ToString().Trim(); //Proposed OT Bill Rate
        public string str_Txt_supplierRegPayRate { get; set; }// ConfirmCW_Data["P57"].ToString().Trim(); //Candidate Pay Rate
        public string str_Txt_supplierOTPayRate { get; set; }// ConfirmCW_Data["P58"].ToString().Trim(); //Candidate OT Pay Rate
        public string str_Txt_supplierMarkupRate { get; set; }// ConfirmCW_Data["P59"].ToString().Trim(); //Supplier Markup%
        public string str_Txt_supplierRegBillRate { get; set; }// ConfirmCW_Data["P60"].ToString().Trim(); //Supplier Bill Rate
        public string str_Txt_supplierOTBillRate { get; set; }// ConfirmCW_Data["P61"].ToString().Trim(); //Supplier OT Bill Rate
        public string str_Txt_mspRegBillRate { get; set; }// ConfirmCW_Data["P62"].ToString().Trim();//MSP Fee, MSP Rate 
        public string str_Txt_mspOTBillRate { get; set; }// ConfirmCW_Data["P63"].ToString().Trim(); //MSP OT Fee, MSP OT Rate 
        public string str_Txt_FinalBillRate { get; set; }// ConfirmCW_Data["P64"].ToString().Trim();//Final Bill Rate            
        public string str_Txt_finalOTBillRate { get; set; }// ConfirmCW_Data["P65"].ToString().Trim();//Final OT Bill Rate
        public string str_Txt_dtPayRate { get; set; }// ConfirmCW_Data["P66"].ToString().Trim();
        public string str_Txt_finalDTBillRate { get; set; }// ConfirmCW_Data["P67"].ToString().Trim();
        public string str_Txt_mspDTBillRate { get; set; }// ConfirmCW_Data["P68"].ToString().Trim();
        public string str_Txt_SupplierDTBillRate { get; set; }// ConfirmCW_Data["P69"].ToString().Trim();
        public string str_Txt_weeklyRegHoursNTE { get; set; }// ConfirmCW_Data["P70"].ToString().Trim();
        public string str_Txt_weeklyOTHoursNTE { get; set; }// ConfirmCW_Data["P71"].ToString().Trim();
        public string str_Txt_yearlyRegHoursNTE { get; set; }// ConfirmCW_Data["P72"].ToString().Trim();
        public string str_Txt_totalContractValue { get; set; }// ConfirmCW_Data["P73"].ToString().Trim();
        public string str_RadioButton_RetireeRadio { get; set; }// ConfirmCW_Data["P74"].ToString().Trim();
        public string str_Txt_RetiredDate { get; set; }// ConfirmCW_Data["P75"].ToString().Trim();
        public string str_Txt_RetiredJobTitle { get; set; }// ConfirmCW_Data["P76"].ToString().Trim();
        public string str_Select_jobCodeID { get; set; }// ConfirmCW_Data["P76"].ToString().Trim();
        public string str_Select_SecurityClearance { get; set; }// ConfirmCW_Data["P77"].ToString().Trim();
        public string str_Select_ClearanceStatus { get; set; }// ConfirmCW_Data["P78"].ToString().Trim();
        public string str_Txt_payRateSavings { get; set; }// ConfirmCW_Data["P79"].ToString().Trim();
        public string str_Txt_supplierBillRateSavings { get; set; }// ConfirmCW_Data["P80"].ToString().Trim();
        public string str_Txt_oneTimeSavings { get; set; }// ConfirmCW_Data["P81"].ToString().Trim();
        public string str_Txt_savingComment { get; set; }// ConfirmCW_Data["P82"].ToString().Trim();
        public string str_Txt_vmsRegBillRate { get; set; }// ConfirmCW_Data["P83"].ToString().Trim();
        public string str_Txt_vmsOTBillRate { get; set; }// ConfirmCW_Data["P84"].ToString().Trim();
        public string str_Txt_mspFeeMarkup { get; set; }// ConfirmCW_Data["P85"].ToString().Trim();
        public string str_Txt_mspFee { get; set; }// ConfirmCW_Data["P86"].ToString().Trim();
        public string str_Txt_mspOTFee { get; set; }// ConfirmCW_Data["P87"].ToString().Trim();
        public string str_Radio_Btn_Indp_Cons { get; set; }// ConfirmCW_Data["P88"].ToString().Trim();
        public string str_Select_ProjectId { get; set; }// ConfirmCW_Data["P89"].ToString().Trim();//EPPIC Project  KeyBank  
        public string str_Select_ProfitCenterId { get; set; }// ConfirmCW_Data["P90"].ToString().Trim();//EPPIC Region  *  KeyBank   
        public string str_Select_spendLevelId { get; set; }// ConfirmCW_Data["P91"].ToString().Trim();//EPPIC Role  *  KeyBank 
        public string str_Btn_ConfirmCW_Submit { get; set; }// ConfirmCW_Data["P92"].ToString().Trim();
        public string str_Btn_ConfirmCW_Submit_Confirm { get; set; }// ConfirmCW_Data["P93"].ToString().Trim();
        public string str_Btn_ConfirmCW_Submit_Confirm_Ok { get; set; }// ConfirmCW_Data["P94"].ToString().Trim();
        public string str_Radio_Referral { get; set; }// ConfirmCW_Data["P95"].ToString().Trim();
        public string str_Select_EngagementType { get; set; }// ConfirmCW_Data["P16"].ToString().Trim();
        public string str_Radio_FromRehire { get; set; }// ConfirmCW_Data["P44"].ToString().Trim();

        //SSN

        public string str_Txt_STID { get; set; }// ConfirmCW_Data["P91"].ToString().Trim();   - Bimbo
        //Cp Chem 
        public string str_txt_LastName_lastName { get; set; }// ConfirmCW_Data["P10"].ToString().Trim();
        public string str_txt_LegalLastName_lastName { get; set; }// ConfirmCW_Data["P10"].ToString().Trim();
        public string str_txt_FirstName_firstName { get; set; }// ConfirmCW_Data["P11"].ToString().Trim();
        public string str_txt_LegalFirstName_firstName { get; set; }// ConfirmCW_Data["P11"].ToString().Trim();
        public string str_txt_MiddleName_middleName { get; set; }// ConfirmCW_Data["P12"].ToString().Trim();
        public string str_select_Suffix_nameSuffix { get; set; }// ConfirmCW_Data["P12"].ToString().Trim();
        public string str_txt_Suffix_nameSuffix { get; set; }// ConfirmCW_Data["P13"].ToString().Trim();
        public string str_btn_CWUseryes_isCWuser { get; set; }// ConfirmCW_Data["P14"].ToString().Trim();
        public string str_txt_CandidateEmail_candidateEmail { get; set; }// ConfirmCW_Data["P15"].ToString().Trim();
        public string str_txt_WorkingTitle_jobTitleName { get; set; }// ConfirmCW_Data["P18"].ToString().Trim();
        public string str_select_TypeofService_serviceType { get; set; }// ConfirmCW_Data["P20"].ToString().Trim();
        public string str_select_FunctionType_serviceType { get; set; }// ConfirmCW_Data["P20"].ToString().Trim();
        public string str_select_JobClassificationTos_serviceType { get; set; }// ConfirmCW_Data["P20"].ToString().Trim();
        public string str_Select_JobCategory_serviceType { get; set; }// ConfirmCW_Data["P20"].ToString().Trim();
        public string str_select_OrganizationName_organization { get; set; }// ConfirmCW_Data["P23"].ToString().Trim();
        public string str_select_BusinessUnit_organization { get; set; }// ConfirmCW_Data["P23"].ToString().Trim();
        public string str_select_Organization_organization { get; set; }// ConfirmCW_Data["P23"].ToString().Trim();
        public string str_select_BusinessArea_organization { get; set; }// ConfirmCW_Data["P23"].ToString().Trim();
        public string str_select_AccountCode_organization { get; set; }// ConfirmCW_Data["P23"].ToString().Trim();
        public string str_typeahead_POCostCenter_CostCenterId { get; set; }// ConfirmCW_Data["P25"].ToString().Trim();
        public string str_typeahead_APCostCenter_CostCenterId { get; set; }// ConfirmCW_Data["P25"].ToString().Trim();
        public string str_select_CostCenter_CostCenterId { get; set; }// ConfirmCW_Data["P25"].ToString().Trim();
        public string str_Typeahead_CostCenter_CostCenterId { get; set; }// ConfirmCW_Data["P25"].ToString().Trim();
        public string str_Typeahead_BusinessUnit_CostCenterId { get; set; }// ConfirmCW_Data["P25"].ToString().Trim();
        public string str_select_GLAccount_GLId { get; set; }// ConfirmCW_Data["P26"].ToString().Trim();
        public string str_Typeahead_GeneralLedgerAccount_GLId { get; set; }// ConfirmCW_Data["P26"].ToString().Trim();
        public string str_select_GeneralLedgerAccount_GLId { get; set; }// ConfirmCW_Data["P26"].ToString().Trim();
        public string str_select_ObjectAccount_GLId { get; set; }// ConfirmCW_Data["P26"].ToString().Trim();
        public string str_Select_HyperionCodeGlUnit_GLId { get; set; }// ConfirmCW_Data["P26"].ToString().Trim();
        public string str_Typeahead_WorkLocation_workLocationID { get; set; }// ConfirmCW_Data["P28"].ToString().Trim();
        public string str_Select_WorkLocation_workLocationID { get; set; }// ConfirmCW_Data["P28"].ToString().Trim();
        public string str_select_PersonnelArea_workLocationID { get; set; }// ConfirmCW_Data["P28"].ToString().Trim();
        public string str_Typeahead_HiringManager_hiringManagerName { get; set; }// ConfirmCW_Data["P29"].ToString().Trim();
        public string str_Typeahead_EngagingManager_hiringManagerName { get; set; }// ConfirmCW_Data["P29"].ToString().Trim();
        public string str_Typeahead_AltHiringManager_alternateHiringManagerName { get; set; }// ConfirmCW_Data["P30"].ToString().Trim();
        public string str_Typeahead_Supervisor_alternateHiringManagerName { get; set; }// ConfirmCW_Data["P30"].ToString().Trim();
        public string str_Typeahead_FinancialPartner_alternateHiringManagerName { get; set; }// ConfirmCW_Data["P30"].ToString().Trim();
        public string str_select_ReqType_reqType { get; set; }// ConfirmCW_Data["P31"].ToString().Trim();
        public string str_select_EmployementType_employmentTypeID { get; set; }// ConfirmCW_Data["P32"].ToString().Trim();
        public string str_txt_Keywords_cwKeyWords { get; set; }// ConfirmCW_Data["P33"].ToString().Trim();
        public string str_txt_Last4digitsofssn_STID1 { get; set; }// ConfirmCW_Data["P34"].ToString().Trim();
        public string str_select_Month_STID2 { get; set; }// ConfirmCW_Data["P35"].ToString().Trim();
        public string str_select_Date_STID3 { get; set; }// ConfirmCW_Data["P36"].ToString().Trim();
        public string str_Typeahead_Supplier_supplierName { get; set; }// ConfirmCW_Data["P38"].ToString().Trim();
        public string str_select_SupplierContact_supplierContact { get; set; }// ConfirmCW_Data["P39"].ToString().Trim();
        public string str_select_InvoicePaymentContact_invoicePaymentContact { get; set; }// ConfirmCW_Data["P40"].ToString().Trim();
        public string str_btn_TimecardApproveradd_addTimecardApproverbtn { get; set; }// ConfirmCW_Data["P41"].ToString().Trim();
        public string str_btn_TimecardApproverdelete_deleteTimecardApproverbtn { get; set; }// ConfirmCW_Data["P42"].ToString().Trim();
        public string str_select_RateType_rateTypeID { get; set; }// ConfirmCW_Data["P94"].ToString().Trim();
        public string str_txt_PONumber_purchaseOrderNumber { get; set; }// ConfirmCW_Data["P95"].ToString().Trim();
        public string str_btn_Timesheet_FromSTTimeSheet { get; set; }// ConfirmCW_Data["P45"].ToString().Trim();
        public string str_select_TimesheetStartDateoftheWeek_dayID { get; set; }// ConfirmCW_Data["P46"].ToString().Trim();
        public string str_Date_GoLiveDate_cwGoLiveDate { get; set; }// ConfirmCW_Data["P47"].ToString().Trim();
        public string str_select_AccountType_AccountType { get; set; }// ConfirmCW_Data["P48"].ToString().Trim();
        public string str_select_PayGroup_AccountType { get; set; }// ConfirmCW_Data["P48"].ToString().Trim();
        public string str_Date_AnticipatedStartDate_preferredStartDate { get; set; }// ConfirmCW_Data["P49"].ToString().Trim();
        public string str_Date_PlannedEndDate_endDate { get; set; }// ConfirmCW_Data["P50"].ToString().Trim();
        public string str_Date_StartDate_preferredStartDate { get; set; }// ConfirmCW_Data["P50"].ToString().Trim();
        public string str_btn_IndependentConsultant_IndependentConsultant { get; set; }// ConfirmCW_Data["P51"].ToString().Trim();
        public string str_txt_ProposedPayRate_regPayRate { get; set; }// ConfirmCW_Data["P52"].ToString().Trim();
        public string str_txt_ProposedOtPayRate_OTPayRate { get; set; }// ConfirmCW_Data["P53"].ToString().Trim();
        public string str_txt_ProposedBillRate_regBillRate { get; set; }// ConfirmCW_Data["P54"].ToString().Trim();
        public string str_txt_ProposedOtBillRate_OTBillRate { get; set; }// ConfirmCW_Data["P55"].ToString().Trim();
        public string str_txt_CandidatePayRate_supplierRegPayRate { get; set; }// ConfirmCW_Data["P56"].ToString().Trim();
        public string str_txt_CandidateOtPayrate_supplierOTPayRate { get; set; }// ConfirmCW_Data["P57"].ToString().Trim();
        public string str_txt_SupplierMarkup_supplierMarkupRate { get; set; }// ConfirmCW_Data["P58"].ToString().Trim();
        public string str_txt_SupplierBillRate_supplierRegBillRate { get; set; }// ConfirmCW_Data["P60"].ToString().Trim();
        public string str_txt_SupplierOtBillRate_supplierOTBillRate { get; set; }// ConfirmCW_Data["P61"].ToString().Trim();
        public string str_txt_FinalBillRate_FinalBillRate { get; set; }// ConfirmCW_Data["P62"].ToString().Trim();
        public string str_txt_FinalOtBillRate_FinalOTBillRate { get; set; }// ConfirmCW_Data["P63"].ToString().Trim();
        public string str_txt_DTPayRate_dtPayRate { get; set; }// ConfirmCW_Data["P64"].ToString().Trim();
        public string str_txt_FinalDTBillRate_finalDTBillRate { get; set; }// ConfirmCW_Data["P65"].ToString().Trim();
        public string str_txt_MSPDoubleTimeBillRate_mspDTBillRate { get; set; }// ConfirmCW_Data["P66"].ToString().Trim();
        public string str_txt_MSPDTBillRate_mspDTBillRate { get; set; }// ConfirmCW_Data["P66"].ToString().Trim();
        public string str_txt_SupplierDtBillRate_SupplierDTBillRate { get; set; }// ConfirmCW_Data["P67"].ToString().Trim();
        public string str_txt_MSPFeeMarkup_mspFeeMarkup { get; set; }// ConfirmCW_Data["P68"].ToString().Trim();
        public string str_txt_MSPFee_mspRegBillRate { get; set; }// ConfirmCW_Data["P69"].ToString().Trim();
        public string str_txt_MSPRate_mspRegBillRate { get; set; }// ConfirmCW_Data["P69"].ToString().Trim();
        public string str_txt_MSPOtFee_mspOTBillRate { get; set; }// ConfirmCW_Data["P70"].ToString().Trim();
        public string str_txt_MSPOTBillRate_mspOTBillRate { get; set; }// ConfirmCW_Data["P70"].ToString().Trim();
        public string str_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE { get; set; }// ConfirmCW_Data["P71"].ToString().Trim();
        public string str_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE { get; set; }// ConfirmCW_Data["P72"].ToString().Trim();
        public string str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE { get; set; }// ConfirmCW_Data["P73"].ToString().Trim();
        public string str_txt_TotalContractValue_totalContractValue { get; set; }// ConfirmCW_Data["P74"].ToString().Trim();
        public string str_btn_Retiree_isRetiree { get; set; }// ConfirmCW_Data["P75"].ToString().Trim();
        public string str_Date_RetiredDate_RetiredDate { get; set; }// ConfirmCW_Data["P76"].ToString().Trim();
        public string str_txt_JobTitle_RetiredJobTitle { get; set; }// ConfirmCW_Data["P77"].ToString().Trim();
        public string str_txt_PayRateSaving_payRateSavings { get; set; }// ConfirmCW_Data["P78"].ToString().Trim();
        public string str_txt_SupplierBillRateSavings_supplierBillRateSavings { get; set; }// ConfirmCW_Data["P79"].ToString().Trim();
        public string str_select_SavingsCategory_savingsTypeID { get; set; }// ConfirmCW_Data["P80"].ToString().Trim();
        public string str_txt_OneTimeSavings_oneTimeSavings { get; set; }// ConfirmCW_Data["P81"].ToString().Trim();
        public string str_txt_SavingsCommands_savingComment { get; set; }// ConfirmCW_Data["P82"].ToString().Trim();
        public string str_select_Paycode_paycodeId { get; set; }// ConfirmCW_Data["P83"].ToString().Trim();
        public string str_txt_payrate_payCodePayRate { get; set; }// ConfirmCW_Data["P84"].ToString().Trim();
        public string str_txt_SupplierBillRate_payCodeSupplierBillrate { get; set; }// ConfirmCW_Data["P85"].ToString().Trim();
        public string str_txt_FinalBillRate_payCodeFinalBillRate { get; set; }// ConfirmCW_Data["P86"].ToString().Trim();
        public string str_select_Country_SCountry { get; set; }// ConfirmCW_Data["P87"].ToString().Trim();
        public string str_select_State_SState { get; set; }// ConfirmCW_Data["P88"].ToString().Trim();
        public string str_select_County_SCounty { get; set; }// ConfirmCW_Data["P89"].ToString().Trim();
        public string str_btn_Union_directIndirect { get; set; }// ConfirmCW_Data["P91"].ToString().Trim();
        public string str_select_UnionName_ddlaborClassCode { get; set; }// ConfirmCW_Data["P92"].ToString().Trim();
        public string str_select_HeadcountApproved_ddlaborClassCode { get; set; }// ConfirmCW_Data["P92"].ToString().Trim();
        public string str_select_SCAPosition_ddlaborClassCode { get; set; }// ConfirmCW_Data["P92"].ToString().Trim();
        public string str_select_WorkWeek_workweek { get; set; }// ConfirmCW_Data["P93"].ToString().Trim();
        public string str_select_JobCategories_serviceType { get; set; }// ConfirmCW_Data["P96"].ToString().Trim();
        public string str_txt_InternalOrder_matrixNumber { get; set; }// ConfirmCW_Data["P97"].ToString().Trim();
        public string str_txt_CT_customerTrackingNumber { get; set; }// ConfirmCW_Data["P98"].ToString().Trim();
        public string str_txt_EmployeeID_customerTrackingNumber { get; set; }// ConfirmCW_Data["P98"].ToString().Trim();
        public string str_txt_VIPNumber_customerTrackingNumber { get; set; }// ConfirmCW_Data["P98"].ToString().Trim();
        public string str_txt_WorkdayEmployeeID_customerTrackingNumber { get; set; }// ConfirmCW_Data["P98"].ToString().Trim();
        public string str_txt_UltiproID_CustomerTrackingNumber2 { get; set; }// ConfirmCW_Data["P99"].ToString().Trim();
        public string str_txt_NEATID_CustomerTrackingNumber2 { get; set; }// ConfirmCW_Data["P99"].ToString().Trim();
        public string str_btn_ExemptNonExempt_exemptFlag { get; set; }// ConfirmCW_Data["P100"].ToString().Trim();
        public string str_btn_ChargingMethod_exemptFlag { get; set; }// ConfirmCW_Data["P100"].ToString().Trim();
        public string str_select_LaborCategory_serviceMethodID { get; set; }// ConfirmCW_Data["P101"].ToString().Trim();
        public string str_txt_JobCode_JobCode { get; set; }// ConfirmCW_Data["P102"].ToString().Trim();
        public string str_select_HRCostCenter_programName { get; set; }// ConfirmCW_Data["P103"].ToString().Trim();
        public string str_select_AcessLocation_siteLocationID { get; set; }// ConfirmCW_Data["P104"].ToString().Trim();
        public string str_select_SiteLocation_siteLocationID { get; set; }// ConfirmCW_Data["P104"].ToString().Trim();
        public string str_Select_LocationCode_siteLocationID { get; set; }// ConfirmCW_Data["P104"].ToString().Trim();
        public string str_txt_JustificationToHire_JustificationtoHire { get; set; }// ConfirmCW_Data["P105"].ToString().Trim();
        public string str_select_Shift_ShiftId { get; set; }// ConfirmCW_Data["P106"].ToString().Trim();
        public string str_Typeahead_AccountingUnit_deptNumber { get; set; }// ConfirmCW_Data["P107"].ToString().Trim();
        public string str_select_CompanyCode_deptNumber { get; set; }// ConfirmCW_Data["P107"].ToString().Trim();
        public string str_txt_Dept_deptNumber { get; set; }// ConfirmCW_Data["P107"].ToString().Trim();
        public string str_Typeahead_Team_deptNumber { get; set; }// ConfirmCW_Data["P107"].ToString().Trim();
        public string str_Select_HRDepartment_deptNumber { get; set; }// ConfirmCW_Data["P107"].ToString().Trim();
        public string str_Typeahead_AccountingUnitName_deptName { get; set; }// ConfirmCW_Data["P108"].ToString().Trim();
        public string str_txt_DeptName_deptName { get; set; }// ConfirmCW_Data["P108"].ToString().Trim();
        public string str_txt_DeptDescription_deptName { get; set; }// ConfirmCW_Data["P108"].ToString().Trim();
        public string str_txt_APDepartment_deptName { get; set; }// ConfirmCW_Data["P108"].ToString().Trim();
        public string str_txt_LegalEntity_association { get; set; }// ConfirmCW_Data["P109"].ToString().Trim();
        public string str_txt_ServiceDept_ServDept { get; set; }// ConfirmCW_Data["P113"].ToString().Trim();
        public string str_txt_ProductDept_ProDept { get; set; }// ConfirmCW_Data["P114"].ToString().Trim();
        public string str_typeahead_CostCenterNumber_chargeCostCenterNumber { get; set; }// ConfirmCW_Data["P115"].ToString().Trim();
        public string str_Typeahead_BusinessUnit_chargeCostCenterId { get; set; }// ConfirmCW_Data["P115"].ToString().Trim();
        public string str_select_GLNumber_GLAccounts { get; set; }// ConfirmCW_Data["P116"].ToString().Trim();
        public string str_txt_ProductDept_chargeProDept { get; set; }// ConfirmCW_Data["P117"].ToString().Trim();
        public string str_txt_LegalEntity_chargeassociation { get; set; }// ConfirmCW_Data["P118"].ToString().Trim();
        public string str_txt_ServiceDept_chargeServDept { get; set; }// ConfirmCW_Data["P120"].ToString().Trim();
        public string str_select_Program_programName { get; set; }// ConfirmCW_Data["P122"].ToString().Trim();
        public string str_txt_LMPID_CustomerTrackingNumber3 { get; set; }// ConfirmCW_Data["P123"].ToString().Trim();
        public string str_txt_BadgeNumber_badgeNumber { get; set; }// ConfirmCW_Data["P124"].ToString().Trim();  
        public String str_select_SecurityClearance_SecurityClearance { get; set; }// ConfirmCW_Data["P125"].ToString().Trim(); 
        public string str_select_ClearanceStatus_ClearanceStatus { get; set; }// ConfirmCW_Data["P126"].ToString().Trim();
        public string str_Typeahead_ProjectWBSElement_ProjectId { get; set; }// ConfirmCW_Data["P127"].ToString().Trim();
        public string str_text_ProjectCodeCFR_ProjectId { get; set; }// ConfirmCW_Data["P127"].ToString().Trim();
        public string str_text_ReasonForHire_reasonToHire { get; set; }// ConfirmCW_Data["P128"].ToString().Trim();
        public string str_text_ReasonForEngagement_reasonToHire { get; set; }// ConfirmCW_Data["P128"].ToString().Trim();
        public string str_Typeahead_ChargeProjectWBSElement_chargeProjectId { get; set; }// ConfirmCW_Data["P129"].ToString().Trim();
        public string str_Typeahead_ProjectCodeCFR_chargeProjectId { get; set; }// ConfirmCW_Data["P129"].ToString().Trim();
        public string str_select_PayCodeGroup_payCodeGroupId { get; set; }// ConfirmCW_Data["P130"].ToString().Trim();
        public string str_select_PayCode_paycodeId { get; set; }// ConfirmCW_Data["P131"].ToString().Trim();
        public string str_text_PayRate_payCodePayRate { get; set; }// ConfirmCW_Data["P132"].ToString().Trim();
        public string str_text_SupplierBillRate_payCodeSupplierBillrate { get; set; }// ConfirmCW_Data["P133"].ToString().Trim();
        public string str_text_FinalBillRate_payCodeFinalBillRate { get; set; }// ConfirmCW_Data["P134"].ToString().Trim();
        public string str_select_ObjectAccount_chargeGLId { get; set; }// ConfirmCW_Data["P135"].ToString().Trim();
        public string str_select_CompanyCode_chargedeptNumber { get; set; }// ConfirmCW_Data["P136"].ToString().Trim();
        public string str_Typeahead_ChargeNumbers_txtChargeNo { get; set; }// ConfirmCW_Data["P137"].ToString().Trim();
        public string str_txt_GLNumbers_txtGLNo { get; set; }// ConfirmCW_Data["P138"].ToString().Trim();
        public string str_txt_VMSRate_vmsRegBillRate { get; set; }// ConfirmCW_Data["P139"].ToString().Trim();
        public string str_txt_VMSOTRate_vmsOTBillRate { get; set; }// ConfirmCW_Data["P140"].ToString().Trim();
        public string str_txt_MatrixNumber_matrixNumber { get; set; }// ConfirmCW_Data["P97"].ToString().Trim();
        public string str_select_FundingSource_serviceMethodID { get; set; }// ConfirmCW_Data["P101"].ToString().Trim();
        public string str_txt_JustificationforRequest_JustificationtoHire { get; set; }// ConfirmCW_Data["P105"].ToString().Trim();
        public string str_txt_GamingProcess_programName { get; set; }// ConfirmCW_Data["P122"].ToString().Trim();
        public string str_txt_POlineItem_LineItem { get; set; }// ConfirmCW_Data["P141"].ToString().Trim();
        public string str_txt_AribaReq_CustomerTrackingNumber2 { get; set; }// ConfirmCW_Data["P99"].ToString().Trim();
        public string str_select_UnionPosition_ddlaborClassCode { get; set; }// ConfirmCW_Data["P92"].ToString().Trim();
        public string str_btn_AccountAssignmentCostCenter_AccountAssignment1 { get; set; }// ConfirmCW_Data["P142"].ToString().Trim();
        public string str_select_WBSElement_ProjectId { get; set; }// ConfirmCW_Data["P127"].ToString().Trim();
        public string str_Select_CORE_ProjectId { get; set; }// ConfirmCW_Data["P127"].ToString().Trim();
        public string str_select_FunctionalArea_ProfitCenterId { get; set; }// ConfirmCW_Data["P143"].ToString().Trim();
        public string str_select_ChargeNumberType_ChargeNumberTypes { get; set; }// ConfirmCW_Data["P144"].ToString().Trim();
        public string str_txt_Justification_JustificationtoHire { get; set; }// ConfirmCW_Data["P105"].ToString().Trim();
        public string str_Typeahead_PurchaseOrderNumber_CostCenterId { get; set; }// ConfirmCW_Data["P25"].ToString().Trim();
        public string str_Typeahead_Department_organization { get; set; }// ConfirmCW_Data["P23"].ToString().Trim();
        public string str_Typeahead_ChargeNumber_txtCharge { get; set; }// ConfirmCW_Data["P137"].ToString().Trim();
        public string str_txt_YPUID_customerTrackingNumber { get; set; }// ConfirmCW_Data["P98"].ToString().Trim();
        public string str_select_ChargeNumbersCompany_AutoFilledChargeNoLabel1 { get; set; }// ConfirmCW_Data["P145"].ToString().Trim();
        public string str_select_ChargeNumbersAccount_AutoFilledChargeNoLabel2 { get; set; }// ConfirmCW_Data["P146"].ToString().Trim();
        public string str_Typeahead_ChargeNumbersRC_AutoFilledChargeNoLabel3 { get; set; }// ConfirmCW_Data["P147"].ToString().Trim();
        public string str_txt_ChargeNumbersMarket_AutoFilledChargeNoLabel4 { get; set; }// ConfirmCW_Data["P148"].ToString().Trim();
        public string str_txt_ChargeNumbersIssueDate_txtAutoFilledChargeNoLabel5 { get; set; }// ConfirmCW_Data["P149"].ToString().Trim();
        public string str_txt_ChargeNumbersDM_txtAutoFilledChargeNoLabel6 { get; set; }// ConfirmCW_Data["P150"].ToString().Trim();
        public string str_txt_ChargeNumbersFutureUse_txtAutoFilledChargeNoLabel7 { get; set; }// ConfirmCW_Data["P151"].ToString().Trim();

        public string str_txt_RCDescription_deptName { get; set; }// ConfirmCW_Data["P108"].ToString().Trim();
        public string str_txt_RCCode_deptNumber { get; set; }// ConfirmCW_Data["P107"].ToString().Trim();
        public string str_select_AccountCode_programName { get; set; }// ConfirmCW_Data["P122"].ToString().Trim();
        public string str_select_YPCompany_siteLocationID { get; set; }// ConfirmCW_Data["P104"].ToString().Trim();
        public string str_select_LabourCategory_serviceType { get; set; }// ConfirmCW_Data["P20"].ToString().Trim();
        public string str_Typeahead_ProgramManager_alternateHiringManagerName { get; set; }// ConfirmCW_Data["P30"].ToString().Trim();
        public string str_select_CoEReqType_serviceMethodID { get; set; }// ConfirmCW_Data["P101"].ToString().Trim();
        public string str_Typeahead_Branch_organization { get; set; }// ConfirmCW_Data["P23"].ToString().Trim();
        public string str_Typeahead_Department_deptNumber { get; set; }// ConfirmCW_Data["P107"].ToString().Trim();
        public string str_Typeahead_POID_ProjectId { get; set; }// ConfirmCW_Data["P127"].ToString().Trim();
        public string str_txt_WorkOrderNumber_customerTrackingNumber { get; set; }// ConfirmCW_Data["P98"].ToString().Trim();
        public string str_btn_HRReviewed_computerAccess { get; set; }// ConfirmCW_Data["P152"].ToString().Trim();
        public string str_select_TypeofAssignment_workweek { get; set; }// ConfirmCW_Data["P93"].ToString().Trim();
        public string str_select_SupplierOperationCompany_OperativeCompany { get; set; }// ConfirmCW_Data["P156"].ToString().Trim();
        public string str_select_AccountCodingsAccountUnit_deptNumber { get; set; }// ConfirmCW_Data["P157"].ToString().Trim();
        public string str_select_AccountCodingsCompany_siteLocationID { get; set; }// ConfirmCW_Data["P158"].ToString().Trim();
        public string str_select_AccountCodingsProject_ProjectId { get; set; }// ConfirmCW_Data["P159"].ToString().Trim();
        public string str_select_AccountCodingsActivity_ProfitCenterId { get; set; }// ConfirmCW_Data["P159"].ToString().Trim();
        public string str_Typeahead_MatrixManager_hiringManagerName { get; set; }// ConfirmCW_Data["P29"].ToString().Trim();
        public string str_Typeahead_FunctionalManager_alternateHiringManagerName { get; set; }// ConfirmCW_Data["P30"].ToString().Trim();
        public string str_select_Company_siteLocationID { get; set; }// ConfirmCW_Data["P104"].ToString().Trim();
        public string str_select_EngagementType_serviceMethodID { get; set; }// ConfirmCW_Data["P101"].ToString().Trim();

        public string str_Typeahead_ChargeNumberProjectName_ChargeprogramId { get; set; }// ConfirmCW_Data["P153"].ToString().Trim();
        public string str_Typeahead_ChargeNumberProjectNumber_ChargeCostCenterId { get; set; }// ConfirmCW_Data["P154"].ToString().Trim();
        public string str_Typeahead_ChargeNumberPOID_ChargeProjectId { get; set; }// ConfirmCW_Data["P155"].ToString().Trim();
        public string str_select_WorkdayJobTitle_jobCodeID { get; set; }
        public string str_select_CompanyNumber_deptNumber { get; set; }
        public string str_TypeHead_EPPICProject_ProjectId { get; set; } // ConfirmCW_Data["P162"].ToString().Trim();
        public string str_Select_EPPICRole_spendLevelId { get; set; } // ConfirmCW_Data["P163"].ToString().Trim();
        public string str_select_EPPICRegion_ProfitCenterId { get; set; } // ConfirmCW_Data["P164"].ToString().Trim();
        public string str_select_EPPICResourcePool_matrixNumber { get; set; } // ConfirmCW_Data["P165"].ToString().Trim();
        public string str_radiobtn_IsRehire_FromRehire { get; set; }
        public string str_txt_CellPhone_mobilePhone { get; set; }// ConfirmCW_Data["P168"].ToString().Trim();
        public string str_txt_PhoneExtension_phoneExtension { get; set; }// ConfirmCW_Data["P169"].ToString().Trim();
        public string str_Radio_ACAD_directIndirect { get; set; }// ConfirmCW_Data["P170"].ToString().Trim();
        public string str_Date_DateofBirth_DOB { get; set; }// ConfirmCW_Data["P171"].ToString().Trim();
        public string str_txt_Street_address1 { get; set; }// ConfirmCW_Data["P172"].ToString().Trim();
        public string str_txt_SocialSecurityNumber_candidateSocialSecurityNumber { get; set; }// ConfirmCW_Data["P173"].ToString().Trim();
        public string str_txt_City_City { get; set; }// ConfirmCW_Data["P173"].ToString().Trim();
        public string str_btn_IsSSNValid_isSSNValid { get; set; }// ConfirmCW_Data["P174"].ToString().Trim();
        public string str_select_State_stateName { get; set; }// ConfirmCW_Data["P185"].ToString().Trim();
        public string str_select_CountryofCitizenship_countryName { get; set; }// ConfirmCW_Data["P176"].ToString().Trim();
        public string str_txt_ZipCode_zipcode { get; set; }// ConfirmCW_Data["P177"].ToString().Trim();
        public string str_btn_SpouseRelativesatAPS_relative { get; set; }// ConfirmCW_Data["P178"].ToString().Trim();
        public string str_select_FormerEmployee_FormallyEmployedFieldId { get; set; }// ConfirmCW_Data["P179"].ToString().Trim();
        public string str_txt_SpourseRelativeName_relativeName { get; set; }// ConfirmCW_Data["P180"].ToString().Trim();
        public string str_select_PositionType_serviceType { get; set; }// ConfirmCW_Data["P20"].ToString().Trim();
        public string str_select_PadsBasicsforAction_padsName { get; set; }// ConfirmCW_Data["P181"].ToString().Trim();
        public string str_btn_Refferal_Radio4 { get; set; }// ConfirmCW_Data["P182"].ToString().Trim();
        public string str_date_OnSiteArrivalDate_processingDate { get; set; }// ConfirmCW_Data["P183"].ToString().Trim();
        public string str_select_Eligibilitytoworkatworklocation_eligibilityID { get; set; }// ConfirmCW_Data["P184"].ToString().Trim();
        public string str_Typeahead_Leader_hiringManagerName { get; set; }// ConfirmCW_Data["P29"].ToString().Trim();
        public string str_select_UnitNumber_deptNumber { get; set; }// ConfirmCW_Data["P107"].ToString().Trim();
        public string str_Typeahead_FFDSupervisor_alternateHiringManagerName { get; set; }// ConfirmCW_Data["P30"].ToString().Trim();
        public string str_select_ACADLevel_programName { get; set; }// ConfirmCW_Data["P122"].ToString().Trim();
        public string str_select_ContractorCost_CostCenterId { get; set; }// ConfirmCW_Data["P25"].ToString().Trim();
        public string str_select_ContractorCategory_GLId { get; set; }// ConfirmCW_Data["P26"].ToString().Trim();
        public string str_Typeahead_MailStation_matrixNumber { get; set; }// ConfirmCW_Data["P97"].ToString().Trim();
        public string str_btn_ComputerAccess_computerAccess { get; set; }// ConfirmCW_Data["P152"].ToString().Trim();
        public string str_txt_RequestJustification_JustificationtoHire { get; set; }// ConfirmCW_Data["P105"].ToString().Trim();
        public string str_Radio_AccountAssignmentCostcenter_AccountAssignment1 { get; set; }// ConfirmCW_Data["P167"].ToString().Trim();
        public string str_radio_AccountAssignmentWBSElement_AccountAssignment3 { get; set; }// ConfirmCW_Data["P167"].ToString().Trim();
        public string str_select_PlantNumber_siteLocationID { get; set; }// ConfirmCW_Data["P104"].ToString().Trim();
        public string str_select_MaterialGroup_ddlaborClassCode { get; set; }// ConfirmCW_Data["P92"].ToString().Trim();
        public string str_Typeahead_PurchasingGroup_serviceMethodID { get; set; }// ConfirmCW_Data["P101"].ToString().Trim();
        public string str_select_PurchaseOrg_programName { get; set; }// ConfirmCW_Data["P122"].ToString().Trim();
        public string str_Typeahead_DelegateofAuthority_alternateHiringManagerName { get; set; }// ConfirmCW_Data["P30"].ToString().Trim();
        public string str_Typeahead_ProfitCenter_ProfitCenterId { get; set; }// ConfirmCW_Data["P143"].ToString().Trim();
        public string str_btn_CWUseryes_isCWuser1 { get; set; }// ConfirmCW_Data["P175"].ToString().Trim();
        public string str_select_Typeofservice_serviceType { get; set; }// ConfirmCW_Data["P20"].ToString().Trim()
        public string str_T1_txt_Keywords_cwKeyWords { get; set; }// ConfirmCW_Data["P30"].ToString().Trim();
        public string str_Date_NeededStartDate_preferredStartDate { get; set; }// ConfirmCW_Data["P49"].ToString().Trim();
        public string str_Date_Enddate_endDate { get; set; }// ConfirmCW_Data["P50"].ToString().Trim();
        public string str_txt_CandidateOTPayRate_supplierOTPayRate { get; set; }// ConfirmCW_Data["P58"].ToString().Trim(); //Candidate OT Pay Rate
        public string str_txt_SupplierOTBillRate_supplierOTBillRate { get; set; }// ConfirmCW_Data["P61"].ToString().Trim(); //Supplier OT Bill Rate
        public string str_txt_EstimatedContractValue_totalContractValue { get; set; }// ConfirmCW_Data["P73"].ToString().Trim();
        public string str_txt_ChargeNumberPA_txtChargePA { get; set; }// ConfirmCW_Data["P185"].ToString().Trim();
        public string str_select_ChargeNumberPAA_chargeCostCenterId { get; set; }// ConfirmCW_Data["P186"].ToString().Trim();
        public string str_select_Emergencyposition_laborClassCode { get; set; }// ConfirmCW_Data["P187"].ToString().Trim();
        public string str_Typeahead_ChargeNumberLegalEntity_ChargeorganizationID { get; set; }// ConfirmCW_Data["P188"].ToString().Trim();
        public string str_Typeahead_ChargeNumberBusinessArea_ChargeProjectId { get; set; }// ConfirmCW_Data["P189"].ToString().Trim();
        public string str_Select_CORE_ChargeProjectId { get; set; }// ConfirmCW_Data["P189"].ToString().Trim();
        public string str_Typeahead_ChargeNumbernaturalAccount_ChargeGLId { get; set; }// ConfirmCW_Data["P190"].ToString().Trim();
        public string str_Typeahead_ChargeNumberLocalAnalysis_ChargesiteLocationID { get; set; }// ConfirmCW_Data["P191"].ToString().Trim();
        public string str_Typeahead_ChargeNumberCostCenter_ChargeCostCenterId { get; set; }// ConfirmCW_Data["P192"].ToString().Trim();
        public string str_Typeahead_AccountCode_ChargeCostCenterId { get; set; }// ConfirmCW_Data["P192"].ToString().Trim();
        public string str_Typeahead_ChargeNumberInterCompany_ChargedeptNumber { get; set; }// ConfirmCW_Data["P193"].ToString().Trim();
        public string str_select_HastheNonEmployeebeenofferedACACompliantHealthCoverage_ACACompliantHealthCoverage { get; set; }// ConfirmCW_Data["P194"].ToString().Trim();
        public string str_select_ACACostPer_ACACostPer { get; set; }// ConfirmCW_Data["P195"].ToString().Trim();
        public string str_txt_ACACost_ACACost { get; set; }// ConfirmCW_Data["P196"].ToString().Trim();
        public string str_select_SupplierOperatingCompany_OperativeCompany { get; set; }// ConfirmCW_Data["P197"].ToString().Trim();
        public string str_Typeahead_EAAApprover_alternateHiringManagerName { get; set; }// ConfirmCW_Data["P30"].ToString().Trim();
        public string str_select_Division_organization { get; set; }// ConfirmCW_Data["P23"].ToString().Trim();
        public string str_select_DeptProgramTaskOrder_programName { get; set; }// ConfirmCW_Data["P122"].ToString().Trim();
        public string str_select_PAA_CostCenterId { get; set; }// ConfirmCW_Data["P25"].ToString().Trim();
        public string str_txt_PA_association { get; set; }// ConfirmCW_Data["P109"].ToString().Trim();
        public string str_select_COEBAT_ProfitCenterId { get; set; }// ConfirmCW_Data["P143"].ToString().Trim();
        public string str_Typeahead_LegalEntity_organization { get; set; }// ConfirmCW_Data["P23"].ToString().Trim();
        public string str_Select_Company_organization { get; set; }// ConfirmCW_Data["P23"].ToString().Trim();
        public string str_Typeahead_BusinessArea_ProjectId { get; set; }// ConfirmCW_Data["P127"].ToString().Trim();
        public string str_Typeahead_NaturalAccount_GLId { get; set; }// ConfirmCW_Data["P26"].ToString().Trim();
        public string str_Select_ExpenseAccount_GLId { get; set; }// ConfirmCW_Data["P26"].ToString().Trim();
        public string str_select_LocalAnalysis_siteLocationID { get; set; }// ConfirmCW_Data["P104"].ToString().Trim();
        public string str_Typeahead_InterCompany_deptNumber { get; set; }// ConfirmCW_Data["P107"].ToString().Trim();
        public string str_select_BusinessUnit_serviceMethodID { get; set; }// ConfirmCW_Data["P101"].ToString().Trim();
        public string str_select_ServiceMethod_serviceMethodID { get; set; }
        public string str_txt_Comments_JustificationtoHire { get; set; }
        public string str_select_SmartTrackTimesheet_AccountType { get; set; }
        public string str_select_BuyerName_CostCenterId { get; set; }// ConfirmCW_Data["P25"].ToString().Trim();
        public string str_Typeahead_BusinessArea_CostCenterId { get; set; }// ConfirmCW_Data["P25"].ToString().Trim();
        public string str_Typeahead_GoodsReceiptApprover_alternateHiringManagerName { get; set; }// ConfirmCW_Data["P30"].ToString().Trim();
        public string str_txt_CompanyCode_deptNumber { get; set; }
        public string str_txt_CompanyCodedescription_deptName { get; set; }
        public string str_select_QualityAssurance_programName { get; set; }
        public string str_select_PlaceofWork_siteLocationID { get; set; }
        public string str_text_JustificationforOpening_reasonToHire { get; set; }
        public string str_Typeahead_OfficeCubicleNumber_matrixNumber { get; set; }
        public string str_txt_CandidateBillRateSavings_supplierBillRateSavings { get; set; }
        public string str_Txt_ComplianceAccessNeeded_matrixNumber { get; set; }
        public string str_select_GLBusinessUnit_GLId { get; set; }
        public string str_txt_CandidateFirstName_firstName { get; set; }
        public string str_txt_CandidateLastName_lastName { get; set; }
        public string str_txt_CandidateMiddleName_middleName { get; set; }
        public string str_txt_CandidateNameSuffix_nameSuffix { get; set; }
        public string str_Typeahead_SpendCategory_deptNumber { get; set; }// ConfirmCW_Data["P107"].ToString().Trim();
        public string str_Typeahead_CourseName_serviceMethodID { get; set; }// ConfirmCW_Data["P101"].ToString().Trim();
        public string str_Typeahead_OrganizationName_organization { get; set; }// ConfirmCW_Data["P23"].ToString().Trim();
        public string str_Txt_POdetailsRemoteCWWorklocationaddress_JustificationtoHire { get; set; }// ConfirmCW_Data["P105"].ToString().Trim();
        public string str_Select_Purpose_ProfitCenterId { get; set; }// ConfirmCW_Data["P143"].ToString().Trim();
        public string str_Select_Fund_siteLocationID { get; set; }// ConfirmCW_Data["P104"].ToString().Trim();
        public string str_Typeahead_PONumber_purchaseOrderNumber { get; set; }// ConfirmCW_Data["P95"].ToString().Trim();
        public string str_Select_Department_deptNumber { get; set; }// ConfirmCW_Data["P107"].ToString().Trim();
        public string str_Select_SubDivision_programName { get; set; }// ConfirmCW_Data["P122"].ToString().Trim();
        public string str_Select_ServiceMethod_serviceMethodID { get; set; }// ConfirmCW_Data["P101"].ToString().Trim();
        public string str_Typeahead_Division_GLId { get; set; }// ConfirmCW_Data["P26"].ToString().Trim();
        public string str_Select_ReqType_organization { get; set; }// ConfirmCW_Data["P23"].ToString().Trim();
        public string str_Txt_Comments_JustificationtoHire { get; set; }// ConfirmCW_Data["P105"].ToString().Trim();
        public string str_Select_BusinessUnit_ProjectId { get; set; }// ConfirmCW_Data["P127"].ToString().Trim();
        public string str_Select_AccountCode_CostCenterId { get; set; }// ConfirmCW_Data["P25"].ToString().Trim();
        public string str_Txt_WorkDayID_customerTrackingNumber { get; set; }// ConfirmCW_Data["P98"].ToString().Trim();
        public string str_Typeahead_BusinessStructure_deptNumber { get; set; }// ConfirmCW_Data["P107"].ToString().Trim();
        public string str_Select_ProductLine_siteLocationID { get; set; }// ConfirmCW_Data["P104"].ToString().Trim();
        public string str_Select_WorkerSubType_serviceMethodID { get; set; }// ConfirmCW_Data["P101"].ToString().Trim();
        public string str_Typeahead_FinanceEntity_organization { get; set; }// ConfirmCW_Data["P23"].ToString().Trim();
        public string str_Typeahead_PrimaryLocation_workLocationID { get; set; }// ConfirmCW_Data["P28"].ToString().Trim();
        public string str_Typeahead_HiringLeader_workLocationID { get; set; }// ConfirmCW_Data["P28"].ToString().Trim();
        public string str_Select_SupervisoryOrg_ProfitCenterId { get; set; }// ConfirmCW_Data["P143"].ToString().Trim();
        public string str_typeahead_CostCenter_ChargeCostCenterId { get; set; }// ConfirmCW_Data["P192"].ToString().Trim();
        public string str_Typeahead_Department_ChargeorganizationID { get; set; }// ConfirmCW_Data["P188"].ToString().Trim();
        public string str_Select_AccountCode_ChargeCostCenterId { get; set; }// ConfirmCW_Data["P192"].ToString().Trim();
        public string str_typeahead_BusinessArea_ChargeCostCenterId { get; set; }// ConfirmCW_Data["P192"].ToString().Trim();
        public string str_Select_BusinessUnit_ChargeProjectId { get; set; }// ConfirmCW_Data["P189"].ToString().Trim();
        public string str_Select_Reqtype_ChargeorganizationID { get; set; }// ConfirmCW_Data["P188"].ToString().Trim();
        public string str_Select_Businessunit_ChargeorganizationID { get; set; }// ConfirmCW_Data["P188"].ToString().Trim();
                     
        public string str_Select_CommodityCode_laborClassCode { get; set; }// ConfirmCW_Data["P92"].ToString().Trim();
        public string str_Typeahead_ChargeCompanyNumber_deptNumber { get; set; }// ConfirmCW_Data["P136"].ToString().Trim();
        public string str_Select_APCostCenter_chargeGLId { get; set; }// ConfirmCW_Data["P135"].ToString().Trim();
        public string str_Typeahead_GLAccount_chargeCostCenterId { get; set; }// ConfirmCW_Data["P186"].ToString().Trim();
        public string str_Select_Category_serviceType { get; set; }// ConfirmCW_Data["P20"].ToString().Trim();
        public string str_Typeahead_CompanyNumber_deptNumber { get; set; }// ConfirmCW_Data["P107"].ToString().Trim();
        public string str_Select_Business_organization { get; set; }// ConfirmCW_Data["P23"].ToString().Trim();
        public string str_Select_WorkerClassification_laborClassCode { get; set; }// ConfirmCW_Data["P92"].ToString().Trim();
        public string str_Typeahead_RequestOwner_hiringManagerName { get; set; }// ConfirmCW_Data["P29"].ToString().Trim();
        public string str_Typeahead_Requestor_alternateHiringManagerName { get; set; }// ConfirmCW_Data["P30"].ToString().Trim();
        public string str_Select_ChargeGLAccount_ChargeGLId { get; set; }// ConfirmCW_Data["P190"].ToString().Trim();
        public string str_Select_ExpenseAccount_ChargeGLId { get; set; }// ConfirmCW_Data["P190"].ToString().Trim();
        public string str_Select_HyperionCodeGLUnit_ChargeGLId { get; set; }// ConfirmCW_Data["P190"].ToString().Trim();
        public string str_btn_FormerEmployee_exEmployee { get; set; }// ConfirmCW_Data["P198"].ToString().Trim();
        public string str_Txt_FormerEmployeeDetails_exEmployeeDetails { get; set; }// ConfirmCW_Data["P199"].ToString().Trim();
        public string str_btn_FormerContigentWorker_exContractor { get; set; }// ConfirmCW_Data["P200"].ToString().Trim();
        public string str_Txt_FormerContigentWorker_exContractorDetails { get; set; }// ConfirmCW_Data["P201"].ToString().Trim();
        public string str_Select_TimeEntity_timeentry { get; set; }// ConfirmCW_Data["P202"].ToString().Trim();
        public string str_Txt_WorkdayID_CustomerTrackingNumber2 { get; set; }// ConfirmCW_Data["P99"].ToString().Trim();
        public string str_txt_iCIMSID_CustomerTrackingNumber2 { get; set; }// ConfirmCW_Data["P99"].ToString().Trim();
        public string str_Txt_RACFID_customerTrackingNumber { get; set; }// ConfirmCW_Data["P98"].ToString().Trim();
        public string str_txt_CommonID_customerTrackingNumber { get; set; }// ConfirmCW_Data["P98"].ToString().Trim();
        public string str_txt_peopleSoftID_customerTrackingNumber { get; set; }// ConfirmCW_Data["P98"].ToString().Trim();
        public string str_Txt_ILMID_CustomerTrackingNumber3 { get; set; }// ConfirmCW_Data["P123"].ToString().Trim();
        public string str_Typeahead_Division_programName { get; set; }// ConfirmCW_Data["P103"].ToString().Trim();
        public string str_btn_CWcanworkRemotely_directIndirect { get; set; }// ConfirmCW_Data["P91"].ToString().Trim();
        public string str_Txt_Justification_JustificationtoHire { get; set; }// ConfirmCW_Data["P105"].ToString().Trim();
        public string str_Typeahead_ChargeCostCenterNumber_chargeCostCenterId { get; set; }// ConfirmCW_Data["P186"].ToString().Trim();
        public string str_select_GLNumber_chargeGLId { get; set; }// ConfirmCW_Data["P135"].ToString().Trim();
        public string str_Txt_RehireDetails_exEmployeeDetails { get; set; }// ConfirmCW_Data["P199"].ToString().Trim();
        public string str_Select_GRIFeeType_MSPTracking1 { get; set; }// ConfirmCW_Data["P203"].ToString().Trim();
        public string str_Select_GRISpendType_MSPTracking2 { get; set; }// ConfirmCW_Data["P204"].ToString().Trim();
        public string str_Select_GRISpendbyIndustry_MSPTracking3 { get; set; }// ConfirmCW_Data["P205"].ToString().Trim();
        public string str_Select_GRISpendbyCountry_MSPTracking4 { get; set; }// ConfirmCW_Data["P206"].ToString().Trim();
        public string str_Select_GRISpendbyCategory_MSPTracking5 { get; set; }// ConfirmCW_Data["P207"].ToString().Trim();
        public string str_txt_SocialSecurityNumber_candidateSSN { get; set; }// ConfirmCW_Data["P208"].ToString().Trim();
        public string str_Select_Gender_Gender { get; set; }// ConfirmCW_Data["P209"].ToString().Trim();
        public string str_Select_Race_nativeAmericanName { get; set; }// ConfirmCW_Data["P210"].ToString().Trim();
        public string str_Typeahead_APDepartment_ChargedeptName { get; set; }// ConfirmCW_Data["P210"].ToString().Trim();
        public string str_Txt_PeopleSoftID_customerTrackingNumber { get; set; }// ConfirmCW_Data["P98"].ToString().Trim();
        public string str_Txt_Supplier_supplierName { get; set; }// ConfirmCW_Data["P38"].ToString().Trim();
    //    public string str_Txt_PeopleSoftID_customerTrackingNumber { get; set; }// ConfirmCW_Data["P98"].ToString().Trim();
        public string str_Select_APDepartment_deptName { get; set; }// ConfirmCW_Data["P108"].ToString().Trim();
     //   public string str_Select_Businessunit_ChargeorganizationID { get; set; }// ConfirmCW_Data["P188"].ToString().Trim();
        public string str_Select_HyperionCodeGLUnit_GLId { get; set; }// ConfirmCW_Data["P26"].ToString().Trim();
        public string str_Typeahead_MatrixNumber_matrixNumber { get; set; }// ConfirmCW_Data["P97"].ToString().Trim();
        public string str_Typeahead_WBSElement_ProjectId { get; set; }// ConfirmCW_Data["P127"].ToString().Trim();
        public string str_Typeahead_ProgramName_programName { get; set; }// ConfirmCW_Data["P122"].ToString().Trim();
        public string str_Typeahead_GL_ChargeGLId { get; set; }// ConfirmCW_Data["P190"].ToString().Trim();
        public string str_Typeahead_WBSElement_ChargeProjectId { get; set; }// ConfirmCW_Data["P129"].ToString().Trim();
        public string str_Txt_SavingsComment_savingComment { get; set; }// ConfirmCW_Data["P82"].ToString().Trim();
        public string str_uploadPOfile { get; set; }// ConfirmCW_Data["P82"].ToString().Trim();
    }
}