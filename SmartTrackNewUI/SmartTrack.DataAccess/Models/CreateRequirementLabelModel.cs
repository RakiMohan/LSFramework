// --------------------------------------------------------------------------------------------------------------------
//<copyright file{ get; set; }"CreateRequirementModel.cs" company{ get; set; }"DCR Workforce Inc">
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

    public class CreateRequirementModelLabel
    {
        //Added by manjusha
        public string strRequirementNumber { get; set; } //REQ_Data["P6"].ToString().Trim();
        public string str_T2_Select_JobCategory_typeofServiceID { get; set; } //REQ_Data["P38"].ToString().Trim();
        public string str_T1_Typeahead_HiringLeader_hiringManager { get; set; } //REQ_Data["P18"].ToString().Trim();
        public string str_T1_Select_Company_organizationID { get; set; } //REQ_Data["P9"].ToString().Trim();
        public string str_T1_Typeahead_BusinessArea_CostCenterId { get; set; } //REQ_Data["P30"].ToString().Trim();
        public string str_T1_Typeahead_Team_deptNumber { get; set; } //REQ_Data["P90"].ToString().Trim();
        public string str_T1_Select_ExpenseAmount_GLId { get; set; } //REQ_Data["P14"].ToString().Trim();
        public string str_T1_Select_ReasonforRequest_reasonToHireID { get; set; }// REQ_Data["P15"].ToString().Trim();
        public string str_T2_Select_Hours_shiftID { get; set; } //REQ_Data["P71"].ToString().Trim();

        //Ryder
        public string str_T1_btn_DoesthedesiredskillsetexistatRydertoday { get; set; } //REQ_Data["P160"].ToString().Trim();
        public string str_T1_Text_Whoisthedesiredresource_singleLine9 { get; set; } //REQ_Data["P161"].ToString().Trim();
        public string str_T1_Text_Whatisthereasonfortheinabilitytoattainthedesiredresource_singleLine10 { get; set; } //REQ_Data["P162"].ToString().Trim();
        public string str_T1_btn_Isthisspendinyourplan { get; set; } //REQ_Data["P163"].ToString().Trim();
        public string str_T1_Text_Ifthespendisintheplanwhatlocationcodeappliestoit_singleLine12 { get; set; } //REQ_Data["P164"].ToString().Trim();
        public string str_T1_btn_Haveyousearchedfortheresourceininternalresourceapplication { get; set; } //REQ_Data["P165"].ToString().Trim();

        //Quicken Loans 
        public string str_T1_btn_IsDeveloper { get; set; } //REQ_Data["P166"].ToString().Trim();
        public string str_T1_btn_NeedPCorMac { get; set; } //REQ_Data["P167"].ToString().Trim();
        public string str_T1_btn_NeedsLaptoporDesktop { get; set; } //REQ_Data["P168"].ToString().Trim();
        public string str_T2_btn_TravelandAncillaryExpenses_expenses { get; set; } //REQ_Data["P169"].ToString().Trim();
        public string str_T2_txt_EstimatedExpenseAmountperResourceforContractPeriod_expenseFixedAmount { get; set; } //REQ_Data["P170"].ToString().Trim();
        public string str_T2_txt_SalaryRangeMin_MinConversionSalary { get; set; } //REQ_Data["P171"].ToString().Trim();
        public string str_T2_txt_SalaryRangeMax_MaxConversionSalary { get; set; } //REQ_Data["P172"].ToString().Trim();

        //Ended by manjusha
        public string strBrowserName { get; set; } //REQ_Data["P1"].ToString().Trim();
        public string strClientName { get; set; } //REQ_Data["P3"].ToString().Trim();
        public string strMainMenuLink { get; set; } //REQ_Data["P4"].ToString().Trim();
        public string strSubMenuLink { get; set; } //REQ_Data["P5"].ToString().Trim();
        public string strSelectRequisitionType { get; set; } //REQ_Data["P6"].ToString().Trim();
        public string strNewRequisition { get; set; } //REQ_Data["P7"].ToString().Trim();
        public string str_T1_Requestor_CreateUserID { get; set; } //REQ_Data["P8"].ToString().Trim();

        public string str_TypeHead_CreatedUserID { get; set; } //REQ_Data["P8"].ToString().Trim();
        public string strTypeHeadCostCenter { get; set; } //REQ_Data["P13"].ToString().Trim();
        public string str_Select_MaterialGroup { get; set; } //REQ_Data["P17"].ToString().Trim();
        public string strDateAssignmentEnd_Month { get; set; } //REQ_Data["P22"].ToString().Trim();
        public string strEngagingManager_LastName { get; set; } //REQ_Data["P22"].ToString().Trim();
        public string strAltEngagingManager_LastNameFirstName { get; set; } //REQ_Data["P22"].ToString().Trim();
        public string str_type_siteLocationID { get; set; }

        //public string strNewRequisition { get; set; } //REQ_Data["P9"].ToString().Trim();
        public string strSelectCostCenter { get; set; } //REQ_Data["P10"].ToString().Trim();
        public string str_Select_ServiceMethod { get; set; } //REQ_Data["P10"].ToString().Trim();
        public string str_Select_MatrixNumber { get; set; } //REQ_Data["P10"].ToString().Trim();
        public string strSelectBusinessArea { get; set; } //REQ_Data["P11"].ToString().Trim();
        public string strSelectGeneralLedgerAccount { get; set; } //REQ_Data["P12"].ToString().Trim();
        public string str_TypeHead_deptNumber { get; set; } //REQ_Data["P12"].ToString().Trim();
        public string str_Select_deptNumber { get; set; } //REQ_Data["P13"].ToString().Trim();
        public string strtxtLegalEntity { get; set; } //REQ_Data["P13"].ToString().Trim();
        public string str_TypeHead_programId { get; set; } //REQ_Data["P13"].ToString().Trim();
        public string strEngagingManager { get; set; } //REQ_Data["P14"].ToString().Trim();
        public string str_TypeHead_ProjectName { get; set; } //REQ_Data["P15"].ToString().Trim();
        public string strAltEngagingManager { get; set; } //REQ_Data["P16"].ToString().Trim();
        public string str_RadioBtn_ChargingMethod { get; set; } //REQ_Data["P17"].ToString().Trim();
        public string str_RadioBtn_AccountAssignment { get; set; } //REQ_Data["P17"].ToString().Trim();
        public string str_Txt_AccountAssignment { get; set; } //REQ_Data["P18"].ToString().Trim();
        public string stSelectrUnionName { get; set; } //REQ_Data["P18"].ToString().Trim();
        public string str_Txt_FundingSource { get; set; } //REQ_Data["P18"].ToString().Trim();
        public string str_Select_ACADLevel { get; set; } //REQ_Data["P18"].ToString().Trim();
        public string str_Txt_EAA_Approver { get; set; } //REQ_Data["P18"].ToString().Trim();
        public string str_Select_HeadcountApproved { get; set; } //REQ_Data["P19"].ToString().Trim();
        public string str_Txt_ServiceDept { get; set; } //REQ_Data["P19"].ToString().Trim();
        public string str_Txt_ProfitCenter { get; set; } //REQ_Data["P19"].ToString().Trim();
        public string str_Txt_CostCenterId { get; set; } //REQ_Data["P19"].ToString().Trim();
        public string str_TypeHead_CostCenterId { get; set; }// REQ_Data["P19"].ToString().Trim();
        public string str_Txt_ProductDept { get; set; } //REQ_Data["P20"].ToString().Trim();
        public string str_Select_Program { get; set; } //REQ_Data["P20"].ToString().Trim();
        public string str_Select_EngagementType { get; set; } //REQ_Data["P20"].ToString().Trim();
        public string strSelectPriority { get; set; } //REQ_Data["P21"].ToString().Trim();
        public string strSelectWorkweek { get; set; } //REQ_Data["P22"].ToString().Trim();
        public string strTxtNumberofResources { get; set; } //REQ_Data["P23"].ToString().Trim();
        public string strSelectReasonforHire { get; set; } //REQ_Data["P24"].ToString().Trim();
        public string str_Select_SecurityClearance { get; set; } //REQ_Data["P24"].ToString().Trim();
        public string str_RadioBtn_CanStartWithoutClearance { get; set; } //REQ_Data["P25"].ToString().Trim();
        public string str_RadioBtn_SpecificIndividualRequired { get; set; } //REQ_Data["P25"].ToString().Trim();
        public string str_RadioBtn_BadgeAccess { get; set; } //REQ_Data["P25"].ToString().Trim();
        public string str_RadioBtn_Radio1 { get; set; } //REQ_Data["P25"].ToString().Trim();
        public string str_RadioBtn_Radio2 { get; set; } //REQ_Data["P26"].ToString().Trim();
        public string str_Txt_EPPICProject { get; set; } //REQ_Data["P26"].ToString().Trim();

        public string str_RadioBtn_Radio3 { get; set; } //REQ_Data["P27"].ToString().Trim();
        public string str_Workweek { get; set; } //REQ_Data["P27"].ToString().Trim();
        public string str_RadioBtn_Radio4 { get; set; } //REQ_Data["P28"].ToString().Trim();
        public string str_Btn_SpecificIndividualRequired { get; set; } //REQ_Data["P26"].ToString().Trim();
        public string str_RadioBtn_InterimClearanceSufficient { get; set; } //REQ_Data["P26"].ToString().Trim();
        public string str_Txt_PrimeContractNumber { get; set; } //REQ_Data["P27"].ToString().Trim();
        public string str_select_spendLevelId { get; set; } //REQ_Data["P27"].ToString().Trim();

        public string str_Button_SecurityClearanceDetailsMSGActionButton { get; set; } //REQ_Data["P28"].ToString().Trim();
        public string str_select_EPPICRegion { get; set; } //REQ_Data["P28"].ToString().Trim();
        public string strtrainingStartDate { get; set; } //REQ_Data["P27"].ToString().Trim();
        public string str_Button_MsgwindowActionButton { get; set; } //REQ_Data["P29"].ToString().Trim();
        public string str_Select_EPPICResourcePool { get; set; } //REQ_Data["P29"].ToString().Trim();

        public string strTxtJustificationtoHire { get; set; } //REQ_Data["P30"].ToString().Trim();
        public string strDateAssignmentStart { get; set; } //REQ_Data["P31"].ToString().Trim();
        public string strDateAssignmentEnd { get; set; } //REQ_Data["P32"].ToString().Trim();
        public string strSelectWorkLocation { get; set; } //REQ_Data["P33"].ToString().Trim();
        public string strTxtWorkLocation { get; set; } //REQ_Data["P33"].ToString().Trim();
        public string strSelectOrganization { get; set; } //REQ_Data["P34"].ToString().Trim();
        public string str_Txt_PlantNumber { get; set; } //REQ_Data["P34"].ToString().Trim();
        public string str_RadioBtn_computerAccess { get; set; } //REQ_Data["P34"].ToString().Trim();
        public string strSelectWorkLocationAddress { get; set; } //REQ_Data["P35"].ToString().Trim();
        public string str_Txt_MailStation { get; set; } //REQ_Data["P36"].ToString().Trim();
        public string str_Radio_NetworkAccessNeeded { get; set; } //REQ_Data["P36"].ToString().Trim();
        public string str_Txt_NetworkAccessRole { get; set; } //REQ_Data["P37"].ToString().Trim();
        public string str_Radio_CaesarsEmailNeeded { get; set; } //REQ_Data["P38"].ToString().Trim();

        //Suntrust

        public string str_GlAccount { get; set; } //REQ_Data["P29"].ToString().Trim();

        //Tufts
        public string strjustification { get; set; } //REQ_Data["P28"].ToString().Trim();

        public string btnOutLine_Action_Button { get; set; } //REQ_Data["P39"].ToString().Trim();
        public string strSelectTypeofService { get; set; } //REQ_Data["P40"].ToString().Trim();
        public string strSelectJobTitle { get; set; } //REQ_Data["P41"].ToString().Trim();
        public string strTextAreaJobDescription { get; set; } //REQ_Data["P42"].ToString().Trim();
        public string strtxtSkills_Mandatory { get; set; } //REQ_Data["P43"].ToString().Trim();
        public string strtxtSkills_Desired { get; set; } //REQ_Data["P44"].ToString().Trim();
        public string strtxtSkills_Name { get; set; } //REQ_Data["P45"].ToString().Trim();
        public string strtxtSkills_Description { get; set; } //REQ_Data["P46"].ToString().Trim();
        public string strRadiobtnSkills_Level { get; set; } //REQ_Data["P47"].ToString().Trim();
        public string strSelectSkills_Years { get; set; } //REQ_Data["P48"].ToString().Trim();
        public string strtxtSpecialNeeds_Category { get; set; } //REQ_Data["P50"].ToString().Trim();
        public string strtxtSpecialNeeds_Description { get; set; } //REQ_Data["P51"].ToString().Trim();
        public string strRadiobtnRecurring { get; set; } //REQ_Data["P52"].ToString().Trim();
        public string strRadiobtnFrequency { get; set; } //REQ_Data["P53"].ToString().Trim();
        public string strSelect_Recurring_Frequency_MSG_Box { get; set; } //REQ_Data["P54"].ToString().Trim();
        public string strButton_Recurring_Frequency_MSG_Box_Action_Button { get; set; } //REQ_Data["P55"].ToString().Trim();
        public string strRadiobtnInterviewRequired { get; set; } //REQ_Data["P56"].ToString().Trim();
        public string strRadiobtnTravelRequired { get; set; } //REQ_Data["P57"].ToString().Trim();
        public string strtxtTravelLocation { get; set; } //REQ_Data["P58"].ToString().Trim();
        public string strtxtTravelDescription { get; set; } //REQ_Data["P59"].ToString().Trim();
        public string strTxt_expenseFixedAmount { get; set; }
        public string strtxtapprovedTotalHours { get; set; }
        public string strselectcurrencyID { get; set; }
        public string strselectrateTypeID { get; set; }
        public string strTxt_ContractValueCalculation_rdtypeoption { get; set; }


        public string strtxtEstWeeklyHours { get; set; } //REQ_Data["P60"].ToString().Trim();
        public string strtxtPayRateMin { get; set; } //REQ_Data["P61"].ToString().Trim();
        public string strtxtPayRateMax { get; set; } //REQ_Data["P62"].ToString().Trim();
        public string strtxtBillRateMin { get; set; } //REQ_Data["P63"].ToString().Trim();
        public string strtxtBillRateMax { get; set; } //REQ_Data["P64"].ToString().Trim();
        public string strtxtEstimatedContractValue { get; set; } //REQ_Data["P65"].ToString().Trim();
        public string strRadiobtnRateNegotiable { get; set; } //REQ_Data["P66"].ToString().Trim();
        public string strRadiobtnSubmit_resumes_with_higher_rates { get; set; } //REQ_Data["P67"].ToString().Trim();
        public string strRadiobtnOTAllowed { get; set; } //REQ_Data["P68"].ToString().Trim();
        public string strRadiobtn_OT_Limitation { get; set; } //REQ_Data["P69"].ToString().Trim();
        public string strTxt_otHoursLimit { get; set; } //REQ_Data["P70"].ToString().Trim();
        public string strRadiobtn_otPreTrue { get; set; } //REQ_Data["P71"].ToString().Trim();
        public string strRadiobtnExempt_NonExempt { get; set; } //REQ_Data["P72"].ToString().Trim();

        public string strTxt_shiftDiffPercent { get; set; } //REQ_Data["P72"].ToString().Trim();
        public string strRadiobtn_CandidateMeeting { get; set; }

        public string strTxt_hasOTHours { get; set; } //REQ_Data["P73"].ToString().Trim();
        public string strselectShift { get; set; } //REQ_Data["P73"].ToString().Trim();
        public string strbtnJobDesc_Action_Button { get; set; } //REQ_Data["P74"].ToString().Trim();
        public string strChkbox_guidelineAccepted { get; set; } //REQ_Data["P75"].ToString().Trim();
        public string strRadiobtn_Workflow { get; set; } //REQ_Data["P76"].ToString().Trim();
        public string strbtnWorkflow_Action_Button { get; set; } //REQ_Data["P77"].ToString().Trim();
        public string strbtnAppQuestion_Action_Button { get; set; } //REQ_Data["P78"].ToString().Trim();
        public string strbtnReviewSubmit_Action_Button { get; set; } //REQ_Data["P79"].ToString().Trim();
        public string str_Txt_UploadFilePath { get; set; } //REQ_Data["P28"].ToString().Trim();//For Martiz client

        //Cp Chem
        public string str_T1_Typeahead_Requestor_CreatedUserID { get; set; } //REQ_Data["P8"].ToString().Trim();
        public string str_T1_select_OrganizationName_organizationID { get; set; } //REQ_Data["P9"].ToString().Trim();
        public string str_T1_select_Organization_organizationID { get; set; } //REQ_Data["P9"].ToString().Trim();
        public string str_T1_select_AccountCode_organizationID { get; set; } //REQ_Data["P9"].ToString().Trim();
        public string str_T1_select_BusinessUnit_organizationID { get; set; } //REQ_Data["P9"].ToString().Trim();
        public string str_T1_select_BusinessArea_organizationID { get; set; } //REQ_Data["P9"].ToString().Trim();
        public string str_T1_select_LabourCategory_serviceMethodID { get; set; } //REQ_Data["P10"].ToString().Trim();
        public string str_T1_select_ServiceMethod_serviceMethodID { get; set; } //REQ_Data["P10"].ToString().Trim();
        public string str_T1_select_EngagementType_serviceMethodID { get; set; } //REQ_Data["P10"].ToString().Trim();
        public string str_T1_Typeahead_HRCostCenter_programId { get; set; } //REQ_Data["P13"].ToString().Trim();
        public string str_T1_select_Program_programId { get; set; } //REQ_Data["P13"].ToString().Trim();
        public string str_T1_select_ACADlevel_programId { get; set; } //REQ_Data["P13"].ToString().Trim();
        public string str_T1_select_GLAccount_GLId { get; set; } //REQ_Data["P14"].ToString().Trim();
        public string str_T1_select_GeneralLedgerAccount_GLId { get; set; } //REQ_Data["P14"].ToString().Trim();
        public string str_T1_select_ContractorCatergory_GLId { get; set; } //REQ_Data["P14"].ToString().Trim();
        public string str_T1_select_ObjectAccount_GLId { get; set; } //REQ_Data["P14"].ToString().Trim();
        public string str_T1_Typeahead_APCostCenter_CostCenterId { get; set; } //REQ_Data["P30"].ToString().Trim();
        public string str_T1_Typeahead_CostCenter_CostCenterId { get; set; } //REQ_Data["P30"].ToString().Trim();
        public string str_T1_select_CostCenter_CostCenterId { get; set; } //REQ_Data["P30"].ToString().Trim();
        public string str_T1_select_ContractorCost_CostCenterId { get; set; } //REQ_Data["P30"].ToString().Trim();
        public string str_T1_Typeahead_BusinessUnit_CostCenterId { get; set; } //REQ_Data["P30"].ToString().Trim();
        public string str_T1_select_ReasontoHire_reasonToHireID { get; set; } //REQ_Data["P15"].ToString().Trim();
        public string str_T1_select_ReasonForEngagement_reasonToHireID { get; set; } //REQ_Data["P15"].ToString().Trim();
        public string str_T1_Txt_NumberofResources_noofresources { get; set; } //REQ_Data["P16"].ToString().Trim();
        public string str_T1_Txt_NumberofPositions_noofresources { get; set; } //REQ_Data["P16"].ToString().Trim();
        public string str_T1_Typeahead_HiringManager_hiringManager { get; set; } //REQ_Data["P18"].ToString().Trim();
        public string str_T1_Typeahead_EngagingManager_hiringManager { get; set; } //REQ_Data["P18"].ToString().Trim();
        public string str_T1_Typeahead_Leader_hiringManager { get; set; } //REQ_Data["P18"].ToString().Trim();
        public string str_T1_Typeahead_AlternateHiringManager_altHiringManager { get; set; } //REQ_Data["P19"].ToString().Trim();
        public string str_T1_select_AlternateHiringManager_altHiringManager { get; set; } //REQ_Data["P19"].ToString().Trim();
        public string str_T1_Typeahead_FFDSupervisor_altHiringManager { get; set; } //REQ_Data["P19"].ToString().Trim();
        public string str_T1_Typeahead_Supervisor_altHiringManager { get; set; } //REQ_Data["P19"].ToString().Trim();
        public string str_T1_Typeahead_FinancialPartner_altHiringManager { get; set; } //REQ_Data["P19"].ToString().Trim();
        public string str_T1_select_AcessLocation_siteLocationID { get; set; } //REQ_Data["P31"].ToString().Trim();
        public string str_T1_select_SiteLocation_siteLocationID { get; set; } //REQ_Data["P31"].ToString().Trim();
        public string str_T1_Date_AnticipatedStartDate_neededStartDate { get; set; } //REQ_Data["P20"].ToString().Trim();
        public string str_T1_Date_AssignmentStartDate_neededStartDate { get; set; } //REQ_Data["P20"].ToString().Trim();
        public string str_T1_Date_DesiredStartDate_neededStartDate { get; set; } //REQ_Data["P20"].ToString().Trim();
        public string str_T1_Date_NeededDate_neededStartDate { get; set; } //REQ_Data["P20"].ToString().Trim();
        public string str_T1_Date_StartDate_neededStartDate { get; set; } //REQ_Data["P20"].ToString().Trim();
        public string str_T1_Date_PlannedEndDate_enddate { get; set; } //REQ_Data["P21"].ToString().Trim();
        public string str_T1_Date_AssignmentEndDate_enddate { get; set; } //REQ_Data["P21"].ToString().Trim();
        public string str_T1_Date_EndDate_enddate { get; set; } //REQ_Data["P21"].ToString().Trim();
        public string str_T1_btn_BadgeAcess_laborClassCode { get; set; } //REQ_Data["P32"].ToString().Trim();
        public string str_T1_txt_JustificationtoHire_JustificationtoHire { get; set; } //REQ_Data["P28"].ToString().Trim();
        public string str_T1_txt_PatientNameandOtherDetails_JustificationtoHire { get; set; } //REQ_Data["P28"].ToString().Trim();
        public string str_T1_txt_RequestJustification_JustificationtoHire { get; set; } //REQ_Data["P28"].ToString().Trim();
        public string str_T1_btn_SystemAcess_directIndirect { get; set; } //REQ_Data["P33"].ToString().Trim();
        public string str_T1_Typeahead_Worklocation_workLocationID { get; set; } //REQ_Data["P23"].ToString().Trim();
        public string str_T1_Select_Worklocation_workLocationID { get; set; } //REQ_Data["P23"].ToString().Trim();
        public string str_T1_select_PersonnelArea_workLocationID { get; set; } //REQ_Data["P23"].ToString().Trim();
        public string str_T1_Typeahead_WorkLocationAddress_workLocationAddress { get; set; } //REQ_Data["P24"].ToString().Trim();
        public string str_T1_Typeahead_PersonnelAreaAddress_workLocationAddress { get; set; } //REQ_Data["P24"].ToString().Trim();
        //public string str_T1_Typeahead_AccountingUnit_deptNumber { get; set; } //REQ_Data["P90"].ToString().Trim();
        public string str_T1_select_WorkWeek_workScheduleID { get; set; } //REQ_Data["P27"].ToString().Trim();
        public string str_T1_Typeahead_AccountUnitName_deptName { get; set; } //REQ_Data["P34"].ToString().Trim();
        public string str_T1_select_Priority_priority { get; set; } //REQ_Data["P35"].ToString().Trim();
        public string str_select_UnionName_laborClassCode { get; set; } //REQ_Data["P108"].ToString().Trim();
        public string str_select_HeadcountApproved_laborClassCode { get; set; } //REQ_Data["P108"].ToString().Trim();
        public string str_T1_btn_Union_directIndirect { get; set; } //REQ_Data["P36"].ToString().Trim();
        public string str_T1_btn_ChargingMethod_directIndirect { get; set; } //REQ_Data["P36"].ToString().Trim();
        public string str_T1_select_UnionName_laborClassCode { get; set; } //REQ_Data["P108"].ToString().Trim();
        public string str_T1_select_HeadcountApproved_laborClassCode { get; set; } //REQ_Data["P108"].ToString().Trim();
        public string str_T1_select_SCAPosition_laborClassCode { get; set; } //REQ_Data["P108"].ToString().Trim();
        public string str_T1_select_BusinessUnit_ProjectId { get; set; } //REQ_Data["P109"].ToString().Trim();
        public string str_T1_Typeahead_ProjectWBSElement_ProjectId { get; set; } //REQ_Data["P109"].ToString().Trim();
        public string str_T1_text_ProjectCodeCFR_ProjectId { get; set; } //REQ_Data["P109"].ToString().Trim();
        public string str_T1_Typeahead_PONumber_poNumber { get; set; } //REQ_Data["P110"].ToString().Trim();
        public string str_T1_Typeahead_MailStation_matrixNumber { get; set; } //REQ_Data["P111"].ToString().Trim();
        public string str_T1_txt_FundingSource_matrixNumber { get; set; } //REQ_Data["P111"].ToString().Trim();
        public string str_T1_btn_ACAD_directIndirect { get; set; } //REQ_Data["P112"].ToString().Trim();
        public string str_T1_btn_ComputerAccess_computerAccess { get; set; } //REQ_Data["P113"].ToString().Trim();
        public string str_T1_select_CIPAcess_ciplocation { get; set; } //REQ_Data["P114"].ToString().Trim();
        public string str_T1_txt_LegalEntity_association { get; set; } //REQ_Data["P115"].ToString().Trim();
        public string str_T1_txt_servicedept_ServDept { get; set; } //REQ_Data["P116"].ToString().Trim();
        public string str_T1_txt_ProductDept_ProDept { get; set; } //REQ_Data["P117"].ToString().Trim();
        public string str_T1_select_SecurityClearance_securityClearanceLevelID { get; set; } //REQ_Data["P118"].ToString().Trim();
        public string str_T1_btn_CanStartwithoutClearance_txtWithout { get; set; } //REQ_Data["P119"].ToString().Trim();
        public string str_T1_btn_InterimClearanceSufficient_txtSufficient { get; set; } //REQ_Data["P120"].ToString().Trim();
        public string str_T1_txt_PrimeContractNumber_txtContractNumber { get; set; } //REQ_Data["P121"].ToString().Trim();
        public string str_T1_btn_SecurityClearanceDetailsMSGActionButton_Submit { get; set; } //REQ_Data["P122"].ToString().Trim();
        public string str_T1_btn_SecurityClearanceDetailsMsgwindowActionButton { get; set; } //REQ_Data["P123"].ToString().Trim();
        public string str_T1_select_UnitNumber_deptNumber { get; set; } //REQ_Data["P90"].ToString().Trim();
        public string str_T1_Typeahead_AccountingUnit_deptNumber { get; set; } //REQ_Data["P90"].ToString().Trim();
        public string str_T1_Typeahead_Department_deptNumber { get; set; } //REQ_Data["P90"].ToString().Trim();
        public string str_T1_select_CompanyCode_deptNumber { get; set; } //REQ_Data["P90"].ToString().Trim();
        public string str_T1_select_unionPosition_laborClassCode { get; set; } //REQ_Data["P108"].ToString().Trim();
        //  public string str_T1_Typeahead_EngagingManager_hiringManager { get; set; } //REQ_Data["P18"].ToString().Trim();
        public string str_T1_select_GamingProcess_programId { get; set; } //REQ_Data["P13"].ToString().Trim();
        public string str_T1_select_ReasonforthisRequest_reasonToHireID { get; set; } //REQ_Data["P15"].ToString().Trim();
        public string str_T1_txt_Justification_JustificationtoHire { get; set; } //REQ_Data["P28"].ToString().Trim();
        public string str_T1_btn_NetworkAcessNeeded_radio6 { get; set; } //REQ_Data["P124"].ToString().Trim();
        public string str_T1_txt_NetwotkAcessRole_singleLine7 { get; set; } //REQ_Data["P125"].ToString().Trim();
        public string str_T1_btn_CeasarsEmailNeeded_radio5 { get; set; } //REQ_Data["P126"].ToString().Trim();
        public string str_T1_Radio_AccountAssignment_CostCenter_AccountAssignment1 { get; set; } //REQ_Data["P127"].ToString().Trim();
        public string str_T1_select_AccountAssignmentWBS_ProjectId { get; set; } //REQ_Data["P128"].ToString().Trim();
        public string str_T1_select_FunctionalArea_ProfitCenterId { get; set; } //REQ_Data["P129"].ToString().Trim();
        //    public string str_T1_Typeahead_EngagingManager_hiringManager { get; set; } //REQ_Data["P18"].ToString().Trim();
        public string str_T1_select_Department_organizationID { get; set; } //REQ_Data["P9"].ToString().Trim();
        public string str_T1_typehead_PurchaseOrderNumber_CostCenterId { get; set; } //REQ_Data["P30"].ToString().Trim();
        //job Description
        public string str_T2_select_JobCategories_typeofServiceID { get; set; } //REQ_Data["P38"].ToString().Trim();
        public string str_T2_Select_TypeofService_typeofServiceID { get; set; } //REQ_Data["P38"].ToString().Trim();
        public string str_T2_select_PositionType_typeofServiceID { get; set; } //REQ_Data["P38"].ToString().Trim();
        public string str_T2_select_FunctionType_typeofServiceID { get; set; } //REQ_Data["P38"].ToString().Trim();
        public string str_T2_select_JobClassification_typeofServiceID { get; set; } //REQ_Data["P38"].ToString().Trim();
        public string str_T2_Typeahead_JobTitle_txtJobTitle { get; set; } //REQ_Data["P39"].ToString().Trim();
        public string str_T2_txt_JobDescription_jobDescription { get; set; } //REQ_Data["P40"].ToString().Trim();
        public string str_T2_txt_SkillMandatory_skillDescMandatory { get; set; } //REQ_Data["P41"].ToString().Trim();
        public string str_T2_txt_SkillDesired_skillDescDesired { get; set; } //REQ_Data["P42"].ToString().Trim();
        public string str_T2_txt_IdealCandidate_skillDescDesired { get; set; } //REQ_Data["P42"].ToString().Trim();
        public string str_T2_txt_SkillMatrix_skillName { get; set; } //REQ_Data["P43"].ToString().Trim();
        public string str_T2_txt_SkillDescription_skillDescription { get; set; } //REQ_Data["P44"].ToString().Trim();
        public string str_T2_Radiobtn_Level_skillLevelID { get; set; } //REQ_Data["P45"].ToString().Trim();
        public string str_T2_select_years_skillYearsExpID { get; set; } //REQ_Data["P46"].ToString().Trim();
        public string str_T2_select_Catgerory_specialNeedCategoryID { get; set; } //REQ_Data["P48"].ToString().Trim();
        public string str_T2_txt_Description_specialNeedDescription { get; set; } //REQ_Data["P49"].ToString().Trim();
        public string str_T2_Radiobutton_mandatoryPrestartFalse { get; set; } //REQ_Data["P50"].ToString().Trim();
        public string str_T2_Radiobutton_recurringScheduleTrue { get; set; } //REQ_Data["P51"].ToString().Trim();
        public string str_T2_Radiobutton_Recurring_recurringScheduleFalse { get; set; } //REQ_Data["P51"].ToString().Trim();
        public string str_T2_select_Recurringfrequency_ddlFrequency { get; set; } //REQ_Data["P52"].ToString().Trim();
        public string str_T2_Radiobutton_InterviewRequired_interviewRequired { get; set; } //REQ_Data["P54"].ToString().Trim();
        public string str_T2_radiobutton_TravelRequired_travel { get; set; } //REQ_Data["P55"].ToString().Trim();
        public string str_T2_txt_TravelLocation_travelLocation { get; set; } //REQ_Data["P56"].ToString().Trim();
        public string str_T2_Radiobutton_Exempt_exemptTrue { get; set; } //REQ_Data["P70"].ToString().Trim();
        public string str_T2_Radiobutton_OtAllowed_OtAllowed { get; set; } //REQ_Data["P66"].ToString().Trim();
        public string str_T2_Radiobutton_OtLimitation_OtLimit { get; set; } //REQ_Data["P67"].ToString().Trim();
        public string str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit { get; set; } //REQ_Data["P68"].ToString().Trim();
        public string str_T2_Radiobutton_OtPerTrue_OtpreTrue { get; set; } //REQ_Data["P69"].ToString().Trim();
        public string str_T2_Radiobutton_TravelRequired_travel { get; set; } //REQ_Data["P55"].ToString().Trim();
        //public string str_T2_txt_TravelLocation_travelLocation { get; set; } //REQ_Data["P56"].ToString().Trim();
        public string str_T2_txt_EstimatedExpenseAmountperResource_expenseFixedAmount { get; set; } //REQ_Data["P56"].ToString().Trim();
        public string str_T2_txt_TravelDescription_travelDescription { get; set; } //REQ_Data["P57"].ToString().Trim();
        public string str_T2_select_Shift_shiftID { get; set; } //REQ_Data["P71"].ToString().Trim();
        public string str_T2_Amount_shiftDiffPercent { get; set; } //REQ_Data["P72"].ToString().Trim();
        public string str_T2_btn_TravelandAncillaryExpensesyes_expenses { get; set; } //REQ_Data["P55"].ToString().Trim();

        public string str_T2_Radiobutton_strTxt_ContractValueCalculation_rdtypeoption1 { get; set; }
        public string str_T2_Radiobutton_strTxt_ContractValueCalculation_rdtypeoption2 { get; set; }
        public string str_T2_Radiobutton_strTxt_ContractValueCalculation_rdtypeoption3 { get; set; }
        public string str_T2_Radiobutton_strTxt_ContractValueCalculation_rdtypeoption4 { get; set; }
        public string str_T2_txt_AnticipatedaverageOTperweek_hasOTHours { get; set; } //REQ_Data["P74"].ToString().Trim();
        public string str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours { get; set; } //REQ_Data["P75"].ToString().Trim();
        public string str_T2_txt_EstimatedTotalofHours_approvedTotalHours { get; set; } //REQ_Data["P75"].ToString().Trim();
        public string str_T2_select_Currency_currencyID { get; set; } //REQ_Data["P76"].ToString().Trim();
        public string str_T2_select_ratetype_rateTypeID { get; set; } //REQ_Data["P77"].ToString().Trim();
        public string str_T2_txt_PayRateLow_payRateLow { get; set; } //REQ_Data["P59"].ToString().Trim();
        public string str_T2_txt_PayRateHigh_payRateHigh { get; set; } //REQ_Data["P60"].ToString().Trim();
        public string str_T2_txt_Billratelow_billRateLow { get; set; } //REQ_Data["P61"].ToString().Trim();
        public string str_T2_txt_BillrateHigh_billRateHigh { get; set; } //REQ_Data["P62"].ToString().Trim();
        public string str_t2_txt_EstimatedContractValue_estContractValue { get; set; } //REQ_Data["P63"].ToString().Trim();
        public string str_T2_txt_totalContractValue_estContractValue { get; set; } //REQ_Data["P63"].ToString().Trim();
        public string str_T2_btn_RateNegotiable_rateNego { get; set; } //REQ_Data["P64"].ToString().Trim();
        public string str_T3_guidelines_guidelineAccepted { get; set; } //REQ_Data["P82"].ToString().Trim();

        public string str_T2_Typeahead_JobCategory_txtJobTitle { get; set; } //REQ_Data["P39"].ToString().Trim();
        public string str_T2_txt_AssignmentDescription_jobDescription { get; set; } //REQ_Data["P40"].ToString().Trim();



        //    public string str_Select_MaterialGroup { get; set; } 

        //For Requistion template scenario
        public string strbtnSaveasMytemplate_Action_Button { get; set; } //REQ_Data["P79"].ToString().Trim();
        public string strtxttemplateName { get; set; } //REQ_Data["P81"].ToString().Trim();
        public string strbtntemplatesubmit { get; set; } //REQ_Data["P82"].ToString().Trim();
        public string strbtncancelpopupyes { get; set; } //REQ_Data["P83"].ToString().Trim();

        public string str_RadioBtn_template1 { get; set; }// REQ_Data["P81"].ToString().Trim();
        public string str_Txt_txtReqNo { get; set; }// REQ_Data["P82"].ToString().Trim();
        public string str_TypeHead_txtdeptNumber { get; set; }// REQ_Data["P83"].ToString().Trim();
        public string str_txtstartDateFrom { get; set; }// REQ_Data["P84"].ToString().Trim();
        public string str_txtstartDateTo { get; set; }// REQ_Data["P85"].ToString().Trim();
        public string str_txtHiringManager { get; set; }// REQ_Data["P86"].ToString().Trim();
        public string str_Txt_txtSAElastName { get; set; }// REQ_Data["P87"].ToString().Trim();
        public string str_txtJobTitle { get; set; }// REQ_Data["P88"].ToString().Trim();
        public string str_Select_txtServiceType { get; set; }// REQ_Data["P89"].ToString().Trim();
        public string str_Select_txtOrganization { get; set; }// REQ_Data["P89"].ToString().Trim();
        public string str_Select_txtLocationType { get; set; }// REQ_Data["P90"].ToString().Trim();
        public string str_Select_searchButton { get; set; }// REQ_Data["P91"].ToString().Trim();
        public string str_btn_SelectRequisition { get; set; }// REQ_Data["P92"].ToString().Trim();
        public string str_Select_KCPLReasonforEngagement { get; set; } // REQ_Data["P19"].ToString().Trim();
        public string str_Select_KCPLComplianceAccessNeeded { get; set; } // REQ_Data["P17"].ToString().Trim();
        public string strRadiobtn_KcplMileage_Reimbursement { get; set; } // REQ_Data["P73"].ToString().Trim();
        public string strRadiobtn_TravelandAncillaryExpenses { get; set; } // REQ_Data["P58"].ToString().Trim();
        public string strRadiobtn_RegularUseofaCompanyVehicle { get; set; } // REQ_Data["P49"].ToString().Trim();
        public string strRadiobtn_KcplTotalEstimatedDollarValue { get; set; } // REQ_Data["P65"].ToString().Trim();
        public string strtxtEstimatedExpenseAmount { get; set; }  // REQ_Data["P81"].ToString().Trim();

        //Add Section 
        public string str_Application_Section_Name { get; set; }  // REQ_Data["P93"].ToString().Trim();
        public string str_btn_Addsection_Section_Name2 { get; set; }  // REQ_Data["P94"].ToString().Trim();     
        public string str_AddSection_SaveContinue_Btn { get; set; } //REQ_Data["P95"].ToString().Trim();
        public string str_btn_Addsection_Saveandclose { get; set; }  // REQ_Data["P96"].ToString().Trim();
        public string str_btn_Addsection { get; set; }  // REQ_Data["P97"].ToString().Trim();     // Click on Add Selection

        //Add Question
        public string str_btn_Addquestion { get; set; }  // REQ_Data["P98"].ToString().Trim();   // Click on Add Question Button
        public string str_select_questiontype { get; set; }  // REQ_Data["P99"].ToString().Trim();  // Sheet Name
        public string str_Txt_QuestionType { get; set; }  // REQ_Data["P"].ToString().Trim();  // Sheet Name


        public string str_btn_Addsection_Saveandcontinue { get; set; }  // REQ_Data["P9"].ToString().Trim();
        public string strTestCaseId { get; set; }
        public string str_Questionselection { get; set; } //// REQ_Data["P9"].ToString().Trim();

        // For Save as Draft Scenario Models

        public string str_btn_SaveasDraft { get; set; }  // REQ_Data["P18"].ToString().Trim();


        public string str_T2_select_year_skillYearsExpID { get; set; }

        public string str_T1_Typeahead_Requestor_hiringManager { get; set; } //REQ_Data["P18"].ToString().Trim();
        public string str_T1_Typeahead_RCCode_deptNumber { get; set; } //REQ_Data["P90"].ToString().Trim();
        public string str_T1_Typeahead_AlternateRequestor_altHiringManager { get; set; } //REQ_Data["P19"].ToString().Trim();
        public string str_T1_select_AccountCode_programId { get; set; } //REQ_Data["P13"].ToString().Trim();
        public string str_T1_select_YPCompany_siteLocationID { get; set; } //REQ_Data["P31"].ToString().Trim();

        public string str_T2_Typeahead_Title_txtJobTitle { get; set; } //REQ_Data["P39"].ToString().Trim();
        public string str_T2_Typeahead_AssignmentDetail_jobDescription { get; set; } //REQ_Data["P40"].ToString().Trim();
        public string str_T1_btn_HRReviewed_computerAccess { get; set; } //REQ_Data["P113"].ToString().Trim();
        public string str_T1_Typeahead_Branch_organizationID { get; set; } //REQ_Data["P9"].ToString().Trim();
        public string str_T1_Typeahead_programManager_altHiringManager { get; set; } //REQ_Data["P19"].ToString().Trim();
        public string str_T1_Select_Company_siteLocationID { get; set; } //REQ_Data["P31"].ToString().Trim();
        public string str_T1_Select_AccountUnit_deptNumber { get; set; } //REQ_Data["P90"].ToString().Trim();
        public string str_T1_text_MatrixNumber_matrixNumber { get; set; } //REQ_Data["P111"].ToString().Trim();
        public string str_T1_typehead_MatrixManager_hiringManager { get; set; } //REQ_Data["P18"].ToString().Trim();
        public string str_T1_typeahead_FunctionalManager_altHiringManager { get; set; } //REQ_Data["P19"].ToString().Trim();
        public string str_T1_select_Department_deptNumber { get; set; } //REQ_Data["P90"].ToString().Trim();
        public string str_T1_select_CoEReqType_serviceMethodID { get; set; } //REQ_Data["P10"].ToString().Trim();
        public string str_T1_Typeahead_POID_ProjectId { get; set; } //REQ_Data["P109"].ToString().Trim();
        public string str_T1_select_TypeofAssignment_workScheduleID { get; set; } //REQ_Data["P27"].ToString().Trim();
        public string str_T1_txt_AdditionalWorkLocationDetails_JustificationtoHire { get; set; } //REQ_Data["P28"].ToString().Trim();
        public string str_T2_txt_IsthisareplacementrequistionRequistion_association { get; set; } //REQ_Data["P131"].ToString().Trim();
        public string str_T2_btn_IsOnCallRequired_shiftTrue { get; set; } //REQ_Data["P132"].ToString().Trim();
        public string str_T2_txt_IsOnCallRequiredAmount_shiftDiffAmount { get; set; } //REQ_Data["P133"].ToString().Trim();
        public string str_T2_select_LaborCategory_typeofServiceID { get; set; } //REQ_Data["P38"].ToString().Trim();
        public string str_T2_btn_Isthisareplacementrequistion_directIndirectTrue { get; set; } //REQ_Data["P130"].ToString().Trim();
        public string str_T2_txt_BillRateRange_billRateHigh { get; set; } //REQ_Data["P62"].ToString().Trim();
        public string str_T2_txt_BillRateRange_billRateLow { get; set; } //REQ_Data["P61"].ToString().Trim();
        public string str_Typeahead_PlantNumber_siteLocationID { get; set; } //REQ_Data["P31"].ToString().Trim();
        public string str_select_PurchaseOrganization_programId { get; set; } //REQ_Data["P13"].ToString().Trim();
        public string str_select_MaterialGroup_laborClassCode { get; set; } //REQ_Data["P108"].ToString().Trim();
        public string str_txt_Requisitioner_CreatedUserID { get; set; } //REQ_Data["P145"].ToString().Trim();
        public string str_Typeahead_DelegateofAuthority_altHiringManager { get; set; } //REQ_Data["P19"].ToString().Trim();
        public string str_T1_select_PurchasingGroup_serviceMethodID { get; set; } //REQ_Data["P10"].ToString().Trim();
        public string str_T1_Radio_ProjectOrWBSElement_AccountAssignment3 { get; set; } //REQ_Data["P144"].ToString().Trim();
        public string str_T1_Radio_CostCenterOrProfitCenter_AccountAssignment1 { get; set; } //REQ_Data["P144"].ToString().Trim();
        public string str_T1_Typehead_ProfitCenter_ProfitCenterId { get; set; } //REQ_Data["P129"].ToString().Trim();
        public string str_T1_typehead_EngagingManagerPM_hiringManager { get; set; }
        public string str_datepicker_NeededDate_neededStartDate { get; set; }
        public string str_datepicker_EndDate_enddate { get; set; }
        public string str_T1_select_JustificationforOpening_reasonToHireID { get; set; }
        public string str_T1_Select_QualityAssurance_programId { get; set; }
        public string str_T1_Select_PlaceOfWork_siteLocationID { get; set; }
        public string str_T1_txt_OfficeCubicleNumber_matrixNumber { get; set; }
        public string str_T1_TypeHead_CompanyCode_deptNumber { get; set; }
        public string str_T1_select_WorkLocation_workLocationID { get; set; }
        public string str_T1_txt_IncumbentNameTermDate_JustificationtoHire { get; set; }
        public string str_T1_TypeHead_WorkLocationAddress_workLocationAddress { get; set; }
        public string str_T2_TypeHead_JobTitle_txtJobTitle { get; set; }

        #region rakesh
        public string str_T1_typehead_LocationCode_CostCenterId { get; set; }
        public string str_T1_Txt_LocationName_CostCenterName { get; set; }
        public string str_T1_Select_ShiftStart_ProfitCenterId { get; set; }
        public string str_T1_Select_ShiftEnd_spendLevelId { get; set; }
        public string str_T1_txt_Comments_JustificationtoHire { get; set; }
        public string str_T2_Txt_WeeklySpend_WeeklySpendValue { get; set; }
        public string str_T1_select_ReasonToEngage_reasonToHireID { get; set; }
        public string str_T1_select_DirectFill_laborClassCode { get; set; }
        #endregion


        public string str_T1_select_Divison_organizationID { get; set; } //REQ_Data["P9"].ToString().Trim();
        public string str_T1_select_COEBAT_ProfitCenterId { get; set; } //REQ_Data["P129"].ToString().Trim();
        public string str_T1_select_DeptProgramTaskOrder_programId { get; set; } //REQ_Data["P13"].ToString().Trim();
        public string str_T1_txt_PA_association { get; set; } //REQ_Data["P115"].ToString().Trim();
        public string str_T1_select_PAA_CostCenterId { get; set; } //REQ_Data["P30"].ToString().Trim();
        public string str_T1_txt_ManagerPeopleSoftNumber_ServDept { get; set; } //REQ_Data["P116"].ToString().Trim();
        public string str_T1_btn_USCitizenshipRequired_laborClassCode { get; set; } //REQ_Data["P146"].ToString().Trim();
        public string str_T1_Typeahead_EAAApprover_altHiringManager { get; set; } //REQ_Data["P19"].ToString().Trim();
        public string str_T1_txt_Justificationforhire_JustificationtoHire { get; set; } //REQ_Data["P28"].ToString().Trim();
        public string str_T1_Typeahead_LegalEntity_organizationID { get; set; } //REQ_Data["P9"].ToString().Trim();
        public string str_T1_Typeahead_BusinessArea_ProjectId { get; set; } //REQ_Data["P109"].ToString().Trim();
        public string str_T1_Typeahead_NaturalAccount_GLId { get; set; } //REQ_Data["P14"].ToString().Trim();
        public string str_T1_Typeahead_LocalAnalysis_siteLocationID { get; set; } //REQ_Data["P31"].ToString().Trim();
        public string str_T1_Typeahead_Fiscal_matrixNumber { get; set; } //REQ_Data["P111"].ToString().Trim();
        public string str_T1_Typeahead_Intercompany_deptNumber { get; set; } //REQ_Data["P90"].ToString().Trim();
        public string str_T1_select_BusinessUnit_serviceMethodID { get; set; } //REQ_Data["P10"].ToString().Trim();
        public string str_T1_select_EmergencyPosition_laborClassCode { get; set; } //REQ_Data["P108"].ToString().Trim();
        public string str_T1_txt_AdditionalrequirementDetails_JustificationtoHire { get; set; } //REQ_Data["P28"].ToString().Trim();
        public string str_T2_btn_Isthisareplacementrequisition_directIndirect { get; set; } //REQ_Data["P149"].ToString().Trim();
        public string str_T2_txt_Requisition_association { get; set; } //REQ_Data["P150"].ToString().Trim();
        public string str_T2_btn_Arethereunionizedworkersatthislocation_UnauthorizedWorker { get; set; } //REQ_Data["P151"].ToString().Trim();
        public string str_T2_txt_CBAContract_CollectiveBargainingAgreementCode { get; set; } //REQ_Data["P152"].ToString().Trim();
        public string str_T2_btn_Isthepositionexpectedtobelongerthan13weeks_interviewRequired { get; set; } //REQ_Data["P153"].ToString().Trim();
        public string str_T2_txt_Amount_shiftDiffAmount { get; set; } //REQ_Data["P155"].ToString().Trim();
        public string str_T2_btn_Isthereashiftdifferential_shift { get; set; } //REQ_Data["P154"].ToString().Trim();
        public string str_T2_txt_Workinghours_shiftDiffPercent { get; set; } //REQ_Data["P156"].ToString().Trim();
        public string str_T2_btn_IsTravelRequired_expenses { get; set; } //REQ_Data["P157"].ToString().Trim();
        public string str_T1_select_FundingSource_serviceMethodID { get; set; } //REQ_Data["P10"].ToString().Trim();
        public string str_T2_select_JobTitle_jobTitleID { get; set; }
        public string str_T2_selectGLAccount_GLIdJD { get; set; }
        public string str_T1_select_GLBusinessUnit_GLId { get; set; }
        public string str_T1_Select_ComplianceAccessNeeded_matrixNumber { get; set; }
        public string str_T1_btn_ComputerSystemsAccess_ComputerSystemsAccess { get; set; }
        public string str_T2_Radio_RegularUseofaCompanyVehicle { get; set; }
        public string str_T2_Radio_ExemptNonExempt { get; set; }
        public string str_T2_Radio_MileageReimbursement { get; set; }
        public string str_T1_Typeahead_BuyerName_CostCenterId { get; set; } //REQ_Data["P30"].ToString().Trim();
        public string str_T1_Typeahead_GoodsReceiptApprover_altHiringManager { get; set; } //REQ_Data["P19"].ToString().Trim();
        public string str_T1_select_ShiftStart_ProfitCenterId { get; set; } //REQ_Data["P129"].ToString().Trim();
        public string str_T1_select_ShiftEnd_spendLevelId { get; set; } //REQ_Data["P158"].ToString().Trim();
        public string str_T1_Typeahead_OrganizationName_organizationID { get; set; } //REQ_Data["P9"].ToString().Trim();
        public string str_T1_Typeahead_CourseName_serviceMethodID { get; set; } //REQ_Data["P10"].ToString().Trim();
        public string str_T1_Typeahead_SpendCategory_deptNumber { get; set; } //REQ_Data["P90"].ToString().Trim();
        public string str_T1_Typeahead_Fund_siteLocationID { get; set; } //REQ_Data["P31"].ToString().Trim();
        public string str_T1_Typeahead_Purpose_ProfitCenterId { get; set; } //REQ_Data["P129"].ToString().Trim();
        public string str_T1_Typeahead_ProgramName_programId { get; set; } //REQ_Data["P13"].ToString().Trim();
        public string str_T1_Txt_POdetailsRemoteCWWorklocationaddress_JustificationtoHire { get; set; } //REQ_Data["P28"].ToString().Trim();
        public string str_txt_TemplateName_templateName { get; set; } //REQ_Data["P194"].ToString().Trim();
        public string str_btn_TemplateSubmit_Submit { get; set; } //REQ_Data["P195"].ToString().Trim();
        public string str_btn_TemplateCancel_Cancel { get; set; } //REQ_Data["P196"].ToString().Trim();
        public string str_btn_TemplateCancel_btnReviewCancel { get; set; } //REQ_Data["P197"].ToString().Trim();
        public string str_T1_Typeahead_Division_programId { get; set; } //REQ_Data["P13"].ToString().Trim();
        public string str_T1_Radiobtn_CWCanWorkRemotely_directIndirect { get; set; } //REQ_Data["P159"].ToString().Trim();
        public string str_Search_searchButton { get; set; } //REQ_Data["P198"].ToString().Trim();
        public string str_T1_Typeahead_Divison_GLId { get; set; } //REQ_Data["P14"].ToString().Trim();
        public string str_T1_Select_ReqType_organizationID { get; set; } //REQ_Data["P9"].ToString().Trim();
        public string str_T1_Select_SubDivision_programId { get; set; } //REQ_Data["P13"].ToString().Trim();
        public string str_T1_Select_Department_deptNumber { get; set; } //REQ_Data["P90"].ToString().Trim();
        public string str_T1_Txt_Comments_JustificationtoHire { get; set; } //REQ_Data["P28"].ToString().Trim();
        public string str_T1_Typeahead_Department_organizationID { get; set; } //REQ_Data["P9"].ToString().Trim();
        public string str_T1_Select_AccountCode_CostCenterId { get; set; } //REQ_Data["P30"].ToString().Trim();
        public string str_T1_Select_SupervisorOrg_ProfitCenterId { get; set; } //REQ_Data["P129"].ToString().Trim();
        public string str_T1_Typeahead_FinanceEntity_organizationID { get; set; } //REQ_Data["P9"].ToString().Trim();
        public string str_T1_Typeahead_BusinessStructure_deptNumber { get; set; } //REQ_Data["P90"].ToString().Trim();
        public string str_T1_Date_TargetStartDate_neededStartDate { get; set; } //REQ_Data["P20"].ToString().Trim();
        public string str_T1_Date_TargetEnddate_enddate { get; set; } //REQ_Data["P21"].ToString().Trim();
        public string str_T1_Typeahead_PrimaryLocation_workLocationID { get; set; } //REQ_Data["P23"].ToString().Trim();
        public string str_T1_Typeahead_PrimaryLocationAddress_workLocationAddress { get; set; } //REQ_Data["P24"].ToString().Trim();
        public string str_T1_Typeahead_ProductLine_siteLocationID { get; set; } //REQ_Data["P31"].ToString().Trim();
        public string str_T1_Select_DirectFill_laborClassCode { get; set; } //REQ_Data["P108"].ToString().Trim();
        public string str_T1_Select_WorkerSubType_serviceMethodID { get; set; } //REQ_Data["P10"].ToString().Trim();
        public string str_T1_Txt_Justification_JustificationtoHire { get; set; } //REQ_Data["P28"].ToString().Trim();
        public string str_T1_Select_TimeType_workScheduleID { get; set; } //REQ_Data["P27"].ToString().Trim();
        public string str_T2_Typeahead_JobPostingTitle_txtJobTitle { get; set; } //REQ_Data["P39"].ToString().Trim();
        public string str_T2_btn_CandidateMeeting_inter { get; set; } //REQ_Data["P54"].ToString().Trim();
        public string str_T2_Select_Workshift_shiftID { get; set; } //REQ_Data["P71"].ToString().Trim();
        public string str_T1_Typeahead_Requestor_createdUserID { get; set; } // REQ_Data["P8"].ToString().Trim();

        public string str_T1_select_CommodityCode_laborClassCode { get; set; }// REQ_Data["P17"].ToString().Trim();
        public string str_T1_select_ReasonForHire_reasonToHireID { get; set; }// REQ_Data["P24"].ToString().Trim();
        public string str_T1_TypeHead_EPPICProject_ProjectId { get; set; }//REQ_Data["P26"].ToString().Trim();

        public string str_T1_Select_EPPICRole_spendLevelId { get; set; }//REQ_Data["P27"].ToString().Trim();
        public string str_T1_select_EPPICRegion_ProfitCenterId { get; set; }//REQ_Data["P28"].ToString().Trim();
        public string str_T1_select_EPPICResourcePool_matrixNumber { get; set; }//REQ_Data["P29"].ToString().Trim();
        public string str_T1_select_CompanyNumber_deptNumber { get; set; }//REQ_Data["P11"].ToString().Trim();
        public string str_T1_Select_CompanyNumber_deptNumber { get; set; } //REQ_Data["P90"].ToString().Trim();
        public string str_T1_Select_HRCostCenter_programId { get; set; } //REQ_Data["P13"].ToString().Trim();
        public string str_T1_Select_CommodityCode_laborClassCode { get; set; } //REQ_Data["P108"].ToString().Trim();
        public string str_T1_Typeahead_EPPICProject_ProjectId { get; set; } //REQ_Data["P109"].ToString().Trim();
        public string str_T1_Select_EPPICRegion_ProfitCenterId { get; set; } //REQ_Data["P129"].ToString().Trim();
        public string str_T1_Select_EPPICResourcePool_matrixNumber { get; set; } //REQ_Data["P111"].ToString().Trim();
        public string str_T1_Select_WorkerClassification_laborClassCode { get; set; } //REQ_Data["P108"].ToString().Trim();
        public string str_T1_Typeahead_Requestor_altHiringManager { get; set; } //REQ_Data["P19"].ToString().Trim();
        public string str_T1_Typeahead_RequestOwner_hiringManager { get; set; } //REQ_Data["P18"].ToString().Trim();
        public string str_T1_Typeahead_Company_deptNumber { get; set; } //REQ_Data["P90"].ToString().Trim();
        public string str_T1_Select_EngagementType_serviceMethodID { get; set; } //REQ_Data["P10"].ToString().Trim();
        public string str_T2_Select_GLAccount_GLIdJD { get; set; } //REQ_Data["P79"].ToString().Trim();
        public string str_T2_Select_Business_organizationID { get; set; } //REQ_Data["P80"].ToString().Trim();
        public string str_T2_btn_RateInformation_rdtypeoption { get; set; } //REQ_Data["P58"].ToString().Trim();
        public string str_T2_Txt_NottoExceedBillRate_billRateHigh { get; set; } //REQ_Data["P62"].ToString().Trim();

        public string str_Radiobtn_SkillMatrixMandatory_skillRequiredTrue { get; set; }//REQ_Data["P56"].ToString().Trim();
        public string str_T1_Select_CORE_ProjectId { get; set; } //REQ_Data["P109"].ToString().Trim();
        public string str_T1_Typeahead_APDepartment_deptName { get; set; } //REQ_Data["P34"].ToString().Trim();
        public string str_T1_Select_HypersionCodeGLUnit_GLId { get; set; } //REQ_Data["P14"].ToString().Trim();
        public string str_T1_Select_HRDepartment_deptNumber { get; set; } //REQ_Data["P90"].ToString().Trim();
        public string str_T1_Select_LocationCode_siteLocationID { get; set; } //REQ_Data["P31"].ToString().Trim();
        public string str_T1_Typeahead_AccountCode_CostCenterId { get; set; } //REQ_Data["P30"].ToString().Trim();
        public string str_T1_Select_BusinessUnit_organizationID { get; set; } //REQ_Data["P9"].ToString().Trim();
        public string str_T2_Radiobutton_SkillMandatory_skillRequired { get; set; } //REQ_Data["P47"].ToString().Trim();
        public string str_T2_Radiobutton_mandatoryPrestart { get; set; } //REQ_Data["P50"].ToString().Trim();
        public string str_T2_btn_RecurringFrequencySubmit { get; set; } //REQ_Data["P53"].ToString().Trim();
        public string str_T2_Txt_EstimatedLaborExpCost_estContractValue { get; set; } //REQ_Data["P63"].ToString().Trim();
        public string str_T2_Radiobutton_RateNegotiable_rateNego { get; set; } //REQ_Data["P173"].ToString().Trim();
        public string str_T2_Radiobutton_SubmitResumeswithHigherRates_rateCon { get; set; } //REQ_Data["P174"].ToString().Trim();
        public string str_T1_Typeahead_BusinessUnit_organizationID { get; set; }
        public string str_T1_Typeahead_ObjectAccount_GLId { get; set; }
        public string str_T1_Select_Group_serviceMethodID { get; set; }
        public string str_T1_select_WorkWeek_ProjectId { get; set; }
        public string str_T1_select_ReasontoEngage_reasonToHireID { get; set; }
        public string str_T1_select_DoestheCWhaveITorFacilitiesneeds_siteLocationID { get; set; }
        public string str_T1_btn_WillCWAccessPII_laborClassCode { get; set; }
        public string str_T2_txt_skillName_skillName { get; set; }
        public string str_T2_txt_Desired_skillDescDesired { get; set; }
        public string str_T2_select_Years_skillYearsExpID { get; set; }
        public string str_T2_txt_EstHoursWeek_EstWeeklyHours { get; set; }
        public string str_T2_select_RateType_rateTypeID { get; set; }
        public string str_T2_select_TypeofService_typeofServiceID { get; set; }
        public string str_T2_txt_Description_skillDescription { get; set; }
        public string str_T2_txt_Mandatory_skillDescMandatory { get; set; }
        public string str_T1_Typeahead_WBSElement_ProjectId { get; set; } //REQ_Data["P109"].ToString().Trim();
        public string str_T1_Typeahead_MatrixNumber_matrixNumber { get; set; } //REQ_Data["P111"].ToString().Trim();

        //Identified Requirement Models
        public string str_T4_Txt_LastName_lastname { get; set; } //REQ_Data["P200"].ToString().Trim();
        public string str_T4_Txt_FirstName_firstname { get; set; } //REQ_Data["P201"].ToString().Trim();
        public string str_T4_Txt_MiddleName_middlename { get; set; } //REQ_Data["P202"].ToString().Trim();
        public string str_T4_Select_Suffix_nameSuffix { get; set; } //REQ_Data["P203"].ToString().Trim();
        public string str_T4_btn_UploadResume_uploadResume { get; set; } //REQ_Data["P204"].ToString().Trim();
        public string str_T4_Radiobutton_FormerEmployee_exEmployee { get; set; } //REQ_Data["P205"].ToString().Trim();
        public string str_T4_Txt_FormerEmployeeDetails_exEmployeeDetails { get; set; } //REQ_Data["P206"].ToString().Trim();
        public string str_T4_Radiobutton_Retiree_retiredEmployee { get; set; } //REQ_Data["P207"].ToString().Trim();
        public string str_T4_Txt_RetireeDetails_retiredEmployeeDetails { get; set; } //REQ_Data["P208"].ToString().Trim();
        public string str_T4_Radiobutton_FormerIntern_exIntern { get; set; } //REQ_Data["P209"].ToString().Trim();
        public string str_T4_Txt_FormerInternDetails_exInternDetails { get; set; } //REQ_Data["P210"].ToString().Trim();
        public string str_T4_Radiobutton_FormerContractor_exContractor { get; set; } //REQ_Data["P211"].ToString().Trim();
        public string str_T4_Txt_FormerContractorDetails_exContractorDetails { get; set; } //REQ_Data["P212"].ToString().Trim();
        public string str_T4_Txt_Justification_soleJustificationDescription { get; set; } //REQ_Data["P213"].ToString().Trim();
        public string str_T4_btn_UploadJustification_uploadJustification { get; set; } //REQ_Data["P214"].ToString().Trim();
        public string str_T4_Select_Supplier_supplierName { get; set; } //REQ_Data["P215"].ToString().Trim();


   //     public string str_T2_txt_Description_skillDescription { get; set; }
    //    public string str_T2_Value_EstimatedcontrctValue { get; set; }//164
        // public string str_T1_Date_AnticipatedStartDate_neededStartDate { get; set; }

        //public string str_T2_Typeahead_JobTitle_txtJobTitle { get; set; }

        //public string str_T1_btn_ComputerAcess_computerAccess { get; set; }

        //public string str_T1_select_EngagementType_serviceMethodID { get; set; }

        //public string str_T1_select_HeadcountApproved_laborClassCode { get; set; }

        //public string str_T1_select_UnionName_laborClassCode { get; set; }

        //public string str_T1_select_UnionName_laborClassCode { get; set; }

        // public string str_T2_Radiobutton_OtPerTrue_OtpreTrue { get; set; }
    }
}
