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

    public class CreateRequirementRepository
    {
        public CreateRequirementModel GetCreateRequirementData(DataRow REQ_Data,DataRow LabelData)
        {
            CreateRequirementModel createRequirementModel = new CreateRequirementModel();

           // createRequirementModel.optionList.Add(REQ_Data["P1"].ToString().Trim());

            createRequirementModel.strBrowserName =  LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P1"].ToString().Trim();
            createRequirementModel.strClientName = LabelData["P3"].ToString().Trim()+"_Label_"+REQ_Data["P3"].ToString().Trim();
            createRequirementModel.strMainMenuLink = LabelData["P4"].ToString().Trim()+"_Label_"+REQ_Data["P4"].ToString().Trim();
            createRequirementModel.strSubMenuLink = LabelData["P5"].ToString().Trim()+"_Label_"+REQ_Data["P5"].ToString().Trim();
            createRequirementModel.strSelectRequisitionType = LabelData["P6"].ToString().Trim()+"_Label_"+REQ_Data["P6"].ToString().Trim();
            createRequirementModel.strNewRequisition = LabelData["P7"].ToString().Trim()+"_Label_"+REQ_Data["P7"].ToString().Trim();

            createRequirementModel.str_TypeHead_CreatedUserID = LabelData["P8"].ToString().Trim()+"_Label_"+REQ_Data["P8"].ToString().Trim();


            //    createRequirementModel.str_Select_MatrixNumber = LabelData["P8"].ToString().Trim()+"_Label_"+REQ_Data["P8"].ToString().Trim();
            createRequirementModel.strSelectBusinessArea = LabelData["P9"].ToString().Trim()+"_Label_"+REQ_Data["P9"].ToString().Trim();
            createRequirementModel.str_T1_select_GLBusinessUnit_GLId = LabelData["P9"].ToString().Trim()+"_Label_"+REQ_Data["P9"].ToString().Trim();
            createRequirementModel.str_Select_ServiceMethod = LabelData["P10"].ToString().Trim()+"_Label_"+REQ_Data["P10"].ToString().Trim();
            createRequirementModel.str_Select_deptNumber = LabelData["P11"].ToString().Trim()+"_Label_"+REQ_Data["P11"].ToString().Trim();
            createRequirementModel.str_TypeHead_deptNumber = LabelData["P12"].ToString().Trim()+"_Label_"+REQ_Data["P12"].ToString().Trim();

            createRequirementModel.strTypeHeadCostCenter = LabelData["P13"].ToString().Trim()+"_Label_"+REQ_Data["P13"].ToString().Trim();
            createRequirementModel.strSelectGeneralLedgerAccount = LabelData["P14"].ToString().Trim()+"_Label_"+REQ_Data["P14"].ToString().Trim();
            createRequirementModel.strSelectReasonforHire = LabelData["P15"].ToString().Trim()+"_Label_"+REQ_Data["P15"].ToString().Trim();
            createRequirementModel.strTxtNumberofResources = LabelData["P16"].ToString().Trim()+"_Label_"+REQ_Data["P16"].ToString().Trim();

            createRequirementModel.str_Select_MaterialGroup = LabelData["P17"].ToString().Trim()+"_Label_"+REQ_Data["P17"].ToString().Trim();
            createRequirementModel.strEngagingManager = LabelData["P18"].ToString().Trim()+"_Label_"+REQ_Data["P18"].ToString().Trim();

            createRequirementModel.strAltEngagingManager = LabelData["P19"].ToString().Trim()+"_Label_"+REQ_Data["P19"].ToString().Trim();

            createRequirementModel.strDateAssignmentStart = LabelData["P20"].ToString().Trim()+"_Label_"+REQ_Data["P20"].ToString().Trim();
            createRequirementModel.strDateAssignmentEnd = LabelData["P21"].ToString().Trim()+"_Label_"+REQ_Data["P21"].ToString().Trim();
            createRequirementModel.strDateAssignmentEnd_Month = LabelData["P22"].ToString().Trim()+"_Label_"+REQ_Data["P22"].ToString().Trim();
            createRequirementModel.strTxtWorkLocation = LabelData["P23"].ToString().Trim()+"_Label_"+REQ_Data["P23"].ToString().Trim();
            createRequirementModel.strSelectWorkLocationAddress = LabelData["P24"].ToString().Trim()+"_Label_"+REQ_Data["P24"].ToString().Trim();

            //Tufts client filed

            createRequirementModel.strjustification = LabelData["P28"].ToString().Trim()+"_Label_"+REQ_Data["P28"].ToString().Trim();


            createRequirementModel.str_GlAccount = LabelData["P29"].ToString().Trim()+"_Label_"+REQ_Data["P29"].ToString().Trim();

            createRequirementModel.str_type_siteLocationID = LabelData["P25"].ToString().Trim()+"_Label_"+REQ_Data["P25"].ToString().Trim();
            createRequirementModel.strSelectWorkweek = LabelData["P26"].ToString().Trim()+"_Label_"+REQ_Data["P26"].ToString().Trim();
            createRequirementModel.strSelectCostCenter = LabelData["P13"].ToString().Trim()+"_Label_"+REQ_Data["P13"].ToString().Trim();
            createRequirementModel.strtxtLegalEntity = LabelData["P13"].ToString().Trim()+"_Label_"+REQ_Data["P13"].ToString().Trim();
            createRequirementModel.str_TypeHead_programId = LabelData["P13"].ToString().Trim()+"_Label_"+REQ_Data["P13"].ToString().Trim();
            //  createRequirementModel.strEngagingManager_LastName = LabelData["P14"].ToString().Trim()+"_Label_"+REQ_Data["P14"].ToString().Trim();
            createRequirementModel.str_TypeHead_ProjectName = LabelData["P15"].ToString().Trim()+"_Label_"+REQ_Data["P15"].ToString().Trim();

            createRequirementModel.str_RadioBtn_ChargingMethod = LabelData["P17"].ToString().Trim()+"_Label_"+REQ_Data["P17"].ToString().Trim();
            createRequirementModel.str_RadioBtn_AccountAssignment = LabelData["P17"].ToString().Trim()+"_Label_"+REQ_Data["P17"].ToString().Trim();
            createRequirementModel.str_Select_KCPLComplianceAccessNeeded = LabelData["P17"].ToString().Trim()+"_Label_"+REQ_Data["P17"].ToString().Trim();
            createRequirementModel.str_Txt_AccountAssignment = LabelData["P18"].ToString().Trim()+"_Label_"+REQ_Data["P18"].ToString().Trim();
            createRequirementModel.stSelectrUnionName = LabelData["P18"].ToString().Trim()+"_Label_"+REQ_Data["P18"].ToString().Trim();
            createRequirementModel.str_Txt_FundingSource = LabelData["P18"].ToString().Trim()+"_Label_"+REQ_Data["P18"].ToString().Trim();
            createRequirementModel.str_Select_ACADLevel = LabelData["P18"].ToString().Trim()+"_Label_"+REQ_Data["P18"].ToString().Trim();
            createRequirementModel.str_Txt_EAA_Approver = LabelData["P18"].ToString().Trim()+"_Label_"+REQ_Data["P18"].ToString().Trim();
            createRequirementModel.str_Select_HeadcountApproved = LabelData["P19"].ToString().Trim()+"_Label_"+REQ_Data["P19"].ToString().Trim();
            createRequirementModel.str_Txt_ServiceDept = LabelData["P19"].ToString().Trim()+"_Label_"+REQ_Data["P19"].ToString().Trim();
            createRequirementModel.str_Txt_ProfitCenter = LabelData["P19"].ToString().Trim()+"_Label_"+REQ_Data["P19"].ToString().Trim();
            createRequirementModel.str_Txt_CostCenterId = LabelData["P19"].ToString().Trim()+"_Label_"+REQ_Data["P19"].ToString().Trim();
            createRequirementModel.str_TypeHead_CostCenterId = LabelData["P19"].ToString().Trim()+"_Label_"+REQ_Data["P19"].ToString().Trim();
            createRequirementModel.str_Select_KCPLReasonforEngagement = LabelData["P19"].ToString().Trim()+"_Label_"+REQ_Data["P19"].ToString().Trim();
            createRequirementModel.str_Txt_ProductDept = LabelData["P20"].ToString().Trim()+"_Label_"+REQ_Data["P20"].ToString().Trim();
            createRequirementModel.str_Select_Program = LabelData["P20"].ToString().Trim()+"_Label_"+REQ_Data["P20"].ToString().Trim();
            createRequirementModel.str_Select_EngagementType = LabelData["P20"].ToString().Trim()+"_Label_"+REQ_Data["P20"].ToString().Trim();
            createRequirementModel.strSelectPriority = LabelData["P21"].ToString().Trim()+"_Label_"+REQ_Data["P21"].ToString().Trim();

            createRequirementModel.strSelectWorkLocation = LabelData["P23"].ToString().Trim()+"_Label_"+REQ_Data["P23"].ToString().Trim();
            createRequirementModel.str_Select_SecurityClearance = LabelData["P24"].ToString().Trim()+"_Label_"+REQ_Data["P24"].ToString().Trim();
            createRequirementModel.str_RadioBtn_CanStartWithoutClearance = LabelData["P25"].ToString().Trim()+"_Label_"+REQ_Data["P25"].ToString().Trim();
            createRequirementModel.str_RadioBtn_SpecificIndividualRequired = LabelData["P25"].ToString().Trim()+"_Label_"+REQ_Data["P25"].ToString().Trim();
            createRequirementModel.str_RadioBtn_BadgeAccess = LabelData["P25"].ToString().Trim()+"_Label_"+REQ_Data["P25"].ToString().Trim();
            createRequirementModel.str_RadioBtn_Radio1 = LabelData["P25"].ToString().Trim()+"_Label_"+REQ_Data["P25"].ToString().Trim();
            createRequirementModel.str_RadioBtn_Radio2 = LabelData["P26"].ToString().Trim()+"_Label_"+REQ_Data["P26"].ToString().Trim();
            createRequirementModel.str_Txt_EPPICProject = LabelData["P26"].ToString().Trim()+"_Label_"+REQ_Data["P26"].ToString().Trim();
            createRequirementModel.str_RadioBtn_Radio3 = LabelData["P27"].ToString().Trim()+"_Label_"+REQ_Data["P27"].ToString().Trim();
            createRequirementModel.str_Workweek = LabelData["P27"].ToString().Trim()+"_Label_"+REQ_Data["P27"].ToString().Trim();
            createRequirementModel.str_RadioBtn_Radio4 = LabelData["P28"].ToString().Trim()+"_Label_"+REQ_Data["P28"].ToString().Trim();
            createRequirementModel.str_Btn_SpecificIndividualRequired = LabelData["P26"].ToString().Trim()+"_Label_"+REQ_Data["P26"].ToString().Trim();
            createRequirementModel.str_RadioBtn_InterimClearanceSufficient = LabelData["P26"].ToString().Trim()+"_Label_"+REQ_Data["P26"].ToString().Trim();
            createRequirementModel.str_Txt_PrimeContractNumber = LabelData["P27"].ToString().Trim()+"_Label_"+REQ_Data["P27"].ToString().Trim();
            createRequirementModel.str_select_spendLevelId = LabelData["P27"].ToString().Trim()+"_Label_"+REQ_Data["P27"].ToString().Trim();
            createRequirementModel.str_Button_SecurityClearanceDetailsMSGActionButton = LabelData["P28"].ToString().Trim()+"_Label_"+REQ_Data["P28"].ToString().Trim();
            createRequirementModel.str_select_EPPICRegion = LabelData["P28"].ToString().Trim()+"_Label_"+REQ_Data["P28"].ToString().Trim();
            createRequirementModel.strtrainingStartDate = LabelData["P27"].ToString().Trim()+"_Label_"+REQ_Data["P27"].ToString().Trim();
            createRequirementModel.str_Button_MsgwindowActionButton = LabelData["P29"].ToString().Trim()+"_Label_"+REQ_Data["P29"].ToString().Trim();
            createRequirementModel.str_Select_EPPICResourcePool = LabelData["P29"].ToString().Trim()+"_Label_"+REQ_Data["P29"].ToString().Trim();
            createRequirementModel.strTxtJustificationtoHire = LabelData["P30"].ToString().Trim()+"_Label_"+REQ_Data["P30"].ToString().Trim();
            createRequirementModel.str_Select_EPPICResourcePool = LabelData["P29"].ToString().Trim()+"_Label_"+REQ_Data["P29"].ToString().Trim();


            createRequirementModel.strSelectOrganization = LabelData["P34"].ToString().Trim()+"_Label_"+REQ_Data["P34"].ToString().Trim();
            createRequirementModel.str_Txt_PlantNumber = LabelData["P34"].ToString().Trim()+"_Label_"+REQ_Data["P34"].ToString().Trim();
            createRequirementModel.str_RadioBtn_computerAccess = LabelData["P34"].ToString().Trim()+"_Label_"+REQ_Data["P34"].ToString().Trim();

            createRequirementModel.str_Txt_MailStation = LabelData["P36"].ToString().Trim()+"_Label_"+REQ_Data["P36"].ToString().Trim();
            createRequirementModel.str_Radio_NetworkAccessNeeded = LabelData["P36"].ToString().Trim()+"_Label_"+REQ_Data["P36"].ToString().Trim();
            createRequirementModel.str_Txt_NetworkAccessRole = LabelData["P37"].ToString().Trim()+"_Label_"+REQ_Data["P37"].ToString().Trim();
            createRequirementModel.str_Radio_CaesarsEmailNeeded = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P38"].ToString().Trim();
            createRequirementModel.btnOutLine_Action_Button = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P37"].ToString().Trim();
            createRequirementModel.strSelectTypeofService = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P38"].ToString().Trim();
            createRequirementModel.strSelectJobTitle = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P39"].ToString().Trim();
            createRequirementModel.strTextAreaJobDescription = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P40"].ToString().Trim();
            createRequirementModel.strtxtSkills_Mandatory = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P41"].ToString().Trim();
            createRequirementModel.strtxtSkills_Desired = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P42"].ToString().Trim();
            createRequirementModel.strtxtSkills_Name = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P43"].ToString().Trim();
            createRequirementModel.strtxtSkills_Description = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P44"].ToString().Trim();
            createRequirementModel.strRadiobtnSkills_Level = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P45"].ToString().Trim();
            createRequirementModel.strSelectSkills_Years = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P46"].ToString().Trim();
            createRequirementModel.strRadiobtn_RegularUseofaCompanyVehicle = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P47"].ToString().Trim();
            createRequirementModel.strtxtSpecialNeeds_Category = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P48"].ToString().Trim();
            createRequirementModel.strtxtSpecialNeeds_Description = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P49"].ToString().Trim();
            createRequirementModel.strRadiobtnRecurring = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P50"].ToString().Trim();
            createRequirementModel.strRadiobtnFrequency = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P51"].ToString().Trim();
            createRequirementModel.strSelect_Recurring_Frequency_MSG_Box = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P52"].ToString().Trim();
            createRequirementModel.strButton_Recurring_Frequency_MSG_Box_Action_Button = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P53"].ToString().Trim();
            createRequirementModel.strRadiobtnInterviewRequired = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P54"].ToString().Trim();
            createRequirementModel.strRadiobtn_CandidateMeeting = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P54"].ToString().Trim();

            createRequirementModel.strRadiobtnTravelRequired = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P55"].ToString().Trim();
            createRequirementModel.strRadiobtn_TravelandAncillaryExpenses = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P55"].ToString().Trim();
            createRequirementModel.strtxtTravelLocation = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P56"].ToString().Trim();
            createRequirementModel.strTxt_expenseFixedAmount = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P56"].ToString().Trim();
            createRequirementModel.strtxtTravelDescription = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P57"].ToString().Trim();
            createRequirementModel.strTxt_ContractValueCalculation_rdtypeoption = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P58"].ToString().Trim();

            createRequirementModel.strtxtPayRateMin = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P59"].ToString().Trim();
            createRequirementModel.strtxtPayRateMax = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P60"].ToString().Trim();
            createRequirementModel.strtxtBillRateMin = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P61"].ToString().Trim();
            createRequirementModel.strtxtBillRateMax = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P62"].ToString().Trim();
            createRequirementModel.strtxtEstimatedContractValue = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P63"].ToString().Trim();
            createRequirementModel.strRadiobtn_KcplTotalEstimatedDollarValue = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P63"].ToString().Trim();
            createRequirementModel.strRadiobtnRateNegotiable = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P64"].ToString().Trim();
            createRequirementModel.strRadiobtnSubmit_resumes_with_higher_rates = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P65"].ToString().Trim();
            createRequirementModel.strRadiobtnOTAllowed = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P66"].ToString().Trim();
            createRequirementModel.strRadiobtn_OT_Limitation = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P67"].ToString().Trim();
            createRequirementModel.strRadiobtn_KcplMileage_Reimbursement = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P71"].ToString().Trim();
            createRequirementModel.strTxt_otHoursLimit = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P68"].ToString().Trim();
            createRequirementModel.strRadiobtn_otPreTrue = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P69"].ToString().Trim();
            createRequirementModel.strRadiobtnExempt_NonExempt = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P70"].ToString().Trim();
            createRequirementModel.strselectShift = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P71"].ToString().Trim();
            createRequirementModel.strTxt_shiftDiffPercent = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P72"].ToString().Trim();

            createRequirementModel.strtxtapprovedTotalHours = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P75"].ToString().Trim();
            createRequirementModel.strselectcurrencyID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P76"].ToString().Trim();

            createRequirementModel.strbtnJobDesc_Action_Button = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P81"].ToString().Trim();
            createRequirementModel.strChkbox_guidelineAccepted = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P82"].ToString().Trim();
            createRequirementModel.strTxt_hasOTHours = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P82"].ToString().Trim();
            createRequirementModel.strtxtEstWeeklyHours = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P83"].ToString().Trim();
            createRequirementModel.strTxt_hasOTHours = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P74"].ToString().Trim();
            createRequirementModel.strtxtEstWeeklyHours = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P75"].ToString().Trim();
            createRequirementModel.strselectrateTypeID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P77"].ToString().Trim();
            createRequirementModel.str_Txt_UploadFilePath = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P78"].ToString().Trim();
            createRequirementModel.strRadiobtn_Workflow = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P83"].ToString().Trim();
            createRequirementModel.strbtnWorkflow_Action_Button = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P84"].ToString().Trim();
            createRequirementModel.strbtnAppQuestion_Action_Button = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P85"].ToString().Trim();
            createRequirementModel.strbtnReviewSubmit_Action_Button = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P86"].ToString().Trim();
            createRequirementModel.str_RadioBtn_template1 = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P87"].ToString().Trim();
            // createRequirementModel.str_RadioBtn_template1 = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P81"].ToString().Trim();
            createRequirementModel.strtxtEstimatedExpenseAmount = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P79"].ToString().Trim();
            createRequirementModel.str_Txt_txtReqNo = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P80"].ToString().Trim();
            createRequirementModel.str_TypeHead_txtdeptNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P81"].ToString().Trim();
            createRequirementModel.str_txtstartDateFrom = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P82"].ToString().Trim();
            createRequirementModel.str_txtHiringManager = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P84"].ToString().Trim();
            createRequirementModel.str_Txt_txtSAElastName = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P85"].ToString().Trim();
            createRequirementModel.str_txtJobTitle = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P86"].ToString().Trim();
            createRequirementModel.str_Select_txtServiceType = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P87"].ToString().Trim();
            createRequirementModel.str_Select_txtOrganization = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P88"].ToString().Trim();
            createRequirementModel.str_Select_txtLocationType = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P90"].ToString().Trim();
            createRequirementModel.str_Select_searchButton = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P91"].ToString().Trim();
            createRequirementModel.str_btn_SelectRequisition = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P92"].ToString().Trim();

            //Add Section
            createRequirementModel.str_Application_Section_Name = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P93"].ToString().Trim();
            createRequirementModel.str_btn_Addsection_Section_Name2 = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P94"].ToString().Trim();
            createRequirementModel.str_AddSection_SaveContinue_Btn = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P95"].ToString().Trim();
            createRequirementModel.str_btn_Addsection_Saveandclose = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P96"].ToString().Trim();
            createRequirementModel.str_btn_Addsection = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P97"].ToString().Trim();   // Click on Add Selection

            //Add Question
            //createRequirementModel.str_btn_Addsection_Saveandcontinue = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P93"].ToString().Trim();          
            createRequirementModel.str_btn_Addquestion = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P98"].ToString().Trim();   // Click on Add Question Button
            createRequirementModel.str_select_questiontype = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P99"].ToString().Trim();   // SheetName
            createRequirementModel.strTestCaseId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["TestCaseID"].ToString().Trim();
            createRequirementModel.str_Questionselection = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P9"].ToString().Trim();

            //Create requirement Template scenarion
            createRequirementModel.strbtnSaveasMytemplate_Action_Button = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P79"].ToString().Trim();
            createRequirementModel.strtxttemplateName = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P81"].ToString().Trim();
            createRequirementModel.strbtntemplatesubmit = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P82"].ToString().Trim();
            createRequirementModel.strbtncancelpopupyes = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P83"].ToString().Trim();

            //  Create requirement Save as Draft scenario

            createRequirementModel.str_btn_SaveasDraft = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P18"].ToString().Trim();

            //cp chem
            createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P8"].ToString().Trim();
            createRequirementModel.str_T1_select_OrganizationName_organizationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P9"].ToString().Trim();
            createRequirementModel.str_T1_select_Organization_organizationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P9"].ToString().Trim();
            createRequirementModel.str_T1_select_AccountCode_organizationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P9"].ToString().Trim();
            createRequirementModel.str_T1_select_BusinessUnit_organizationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P9"].ToString().Trim();
            createRequirementModel.str_T1_select_BusinessArea_organizationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P9"].ToString().Trim();
            createRequirementModel.str_T1_Select_Company_organizationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P9"].ToString().Trim();
            createRequirementModel.str_T1_select_LabourCategory_serviceMethodID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P10"].ToString().Trim();
            createRequirementModel.str_T1_select_ServiceMethod_serviceMethodID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P10"].ToString().Trim();
            createRequirementModel.str_T1_select_EngagementType_serviceMethodID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P10"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_HRCostCenter_programId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P13"].ToString().Trim();
            createRequirementModel.str_T1_select_Program_programId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P13"].ToString().Trim();
            createRequirementModel.str_T1_select_ACADlevel_programId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P13"].ToString().Trim();
            createRequirementModel.str_T1_select_GLAccount_GLId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P14"].ToString().Trim();
            createRequirementModel.str_T1_select_ContractorCatergory_GLId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P14"].ToString().Trim();
            createRequirementModel.str_T1_select_GeneralLedgerAccount_GLId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P14"].ToString().Trim();
            createRequirementModel.str_T1_select_ObjectAccount_GLId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P14"].ToString().Trim();
            createRequirementModel.str_T1_Select_ExpenseAmount_GLId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P14"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_APCostCenter_CostCenterId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P30"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P30"].ToString().Trim();
            createRequirementModel.str_T1_select_CostCenter_CostCenterId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P30"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_BusinessUnit_CostCenterId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P30"].ToString().Trim();
            createRequirementModel.str_T1_select_ContractorCost_CostCenterId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P30"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_BusinessArea_CostCenterId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P30"].ToString().Trim();
            createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P15"].ToString().Trim();
            createRequirementModel.str_T1_select_ReasonForEngagement_reasonToHireID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P15"].ToString().Trim();
            createRequirementModel.str_T1_Select_ReasonforRequest_reasonToHireID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P15"].ToString().Trim();
            createRequirementModel.str_T1_Txt_NumberofResources_noofresources = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P16"].ToString().Trim();
            createRequirementModel.str_T1_Txt_NumberofPositions_noofresources = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P16"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P18"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_Leader_hiringManager = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P18"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P18"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_HiringLeader_hiringManager = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P18"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_AlternateHiringManager_altHiringManager = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P19"].ToString().Trim();
            createRequirementModel.str_T1_select_AlternateHiringManager_altHiringManager = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P19"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_FinancialPartner_altHiringManager = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P19"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_FFDSupervisor_altHiringManager = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P19"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P19"].ToString().Trim();
            createRequirementModel.str_T1_Date_AnticipatedStartDate_neededStartDate = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P20"].ToString().Trim();
            createRequirementModel.str_T1_Date_NeededDate_neededStartDate = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P20"].ToString().Trim();
            createRequirementModel.str_T1_Date_AssignmentStartDate_neededStartDate = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P20"].ToString().Trim();
            createRequirementModel.str_T1_Date_DesiredStartDate_neededStartDate = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P20"].ToString().Trim();
            createRequirementModel.str_T1_Date_StartDate_neededStartDate = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P20"].ToString().Trim();
            createRequirementModel.str_T1_Date_PlannedEndDate_enddate = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P21"].ToString().Trim();
            createRequirementModel.str_T1_Date_AssignmentEndDate_enddate = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P21"].ToString().Trim();
            createRequirementModel.str_T1_Date_EndDate_enddate = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P21"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P23"].ToString().Trim();
            createRequirementModel.str_T1_Select_Worklocation_workLocationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P23"].ToString().Trim();
            createRequirementModel.str_T1_select_PersonnelArea_workLocationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P23"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P24"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_PersonnelAreaAddress_workLocationAddress = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P24"].ToString().Trim();
            createRequirementModel.str_T1_select_WorkWeek_workScheduleID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P27"].ToString().Trim();
            createRequirementModel.str_T1_txt_JustificationtoHire_JustificationtoHire = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P28"].ToString().Trim();
            createRequirementModel.str_T1_txt_PatientNameandOtherDetails_JustificationtoHire = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P28"].ToString().Trim();
            createRequirementModel.str_T1_txt_RequestJustification_JustificationtoHire = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P28"].ToString().Trim();
            createRequirementModel.str_T1_btn_SystemAcess_directIndirect = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P33"].ToString().Trim();
            createRequirementModel.str_T1_select_AcessLocation_siteLocationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P31"].ToString().Trim();
            createRequirementModel.str_T1_select_SiteLocation_siteLocationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P31"].ToString().Trim();
            createRequirementModel.str_T1_btn_BadgeAcess_laborClassCode = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P32"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_AccountUnitName_deptName = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P34"].ToString().Trim();
            createRequirementModel.str_T1_select_Priority_priority = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P35"].ToString().Trim();
            createRequirementModel.str_T1_btn_Union_directIndirect = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P36"].ToString().Trim();
            createRequirementModel.str_T1_btn_ChargingMethod_directIndirect = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P36"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_AccountingUnit_deptNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P90"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_Department_deptNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P90"].ToString().Trim();
            createRequirementModel.str_T1_select_CompanyCode_deptNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P90"].ToString().Trim();
            createRequirementModel.str_T1_select_UnitNumber_deptNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P90"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_Team_deptNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P90"].ToString().Trim();
            createRequirementModel.str_T1_select_UnionName_laborClassCode = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P108"].ToString().Trim();
            createRequirementModel.str_T1_select_HeadcountApproved_laborClassCode = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P108"].ToString().Trim();
            createRequirementModel.str_T1_select_SCAPosition_laborClassCode = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P108"].ToString().Trim();
            createRequirementModel.str_T1_select_BusinessUnit_ProjectId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P109"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_ProjectWBSElement_ProjectId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P109"].ToString().Trim();
            createRequirementModel.str_T1_text_ProjectCodeCFR_ProjectId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P109"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_PONumber_poNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P110"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_MailStation_matrixNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P111"].ToString().Trim();
            createRequirementModel.str_T1_txt_FundingSource_matrixNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P111"].ToString().Trim();
            createRequirementModel.str_T1_btn_ACAD_directIndirect = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P112"].ToString().Trim();
            createRequirementModel.str_T1_btn_ComputerAccess_computerAccess = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P113"].ToString().Trim();
            createRequirementModel.str_T1_select_CIPAcess_ciplocation = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P114"].ToString().Trim();
            createRequirementModel.str_T1_txt_LegalEntity_association = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P115"].ToString().Trim();
            createRequirementModel.str_T1_txt_servicedept_ServDept = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P116"].ToString().Trim();
            createRequirementModel.str_T1_txt_ProductDept_ProDept = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P117"].ToString().Trim();
            createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P118"].ToString().Trim();
            createRequirementModel.str_T1_btn_CanStartwithoutClearance_txtWithout = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P119"].ToString().Trim();
            createRequirementModel.str_T1_btn_InterimClearanceSufficient_txtSufficient = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P120"].ToString().Trim();
            createRequirementModel.str_T1_txt_PrimeContractNumber_txtContractNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P121"].ToString().Trim();
            createRequirementModel.str_T1_btn_SecurityClearanceDetailsMSGActionButton_Submit = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P122"].ToString().Trim();
            //   createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P18"].ToString().Trim();
            createRequirementModel.str_T1_select_unionPosition_laborClassCode = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P108"].ToString().Trim();
            createRequirementModel.str_T1_select_GamingProcess_programId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P13"].ToString().Trim();
            createRequirementModel.str_T1_select_ReasonforthisRequest_reasonToHireID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P15"].ToString().Trim();
            createRequirementModel.str_T1_txt_Justification_JustificationtoHire = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P28"].ToString().Trim();
            createRequirementModel.str_T1_btn_NetworkAcessNeeded_radio6 = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P124"].ToString().Trim();
            createRequirementModel.str_T1_txt_NetwotkAcessRole_singleLine7 = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P125"].ToString().Trim();
            createRequirementModel.str_T1_btn_CeasarsEmailNeeded_radio5 = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P126"].ToString().Trim();
            createRequirementModel.str_T1_Radio_AccountAssignment_CostCenter_AccountAssignment1 = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P127"].ToString().Trim();
            createRequirementModel.str_T1_select_AccountAssignmentWBS_ProjectId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P128"].ToString().Trim();
            createRequirementModel.str_T1_select_FunctionalArea_ProfitCenterId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P129"].ToString().Trim();
            createRequirementModel.str_T1_select_Department_organizationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P9"].ToString().Trim();
            createRequirementModel.str_T1_typehead_PurchaseOrderNumber_CostCenterId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P30"].ToString().Trim();
            //job descripition 
            createRequirementModel.str_T2_select_JobCategories_typeofServiceID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P38"].ToString().Trim();
            createRequirementModel.str_T2_Select_TypeofService_typeofServiceID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P38"].ToString().Trim();
            createRequirementModel.str_T2_select_PositionType_typeofServiceID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P38"].ToString().Trim();
            createRequirementModel.str_T2_select_FunctionType_typeofServiceID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P38"].ToString().Trim();
            createRequirementModel.str_T2_select_JobClassification_typeofServiceID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P38"].ToString().Trim();
            createRequirementModel.str_T2_Select_JobCategory_typeofServiceID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P38"].ToString().Trim();
            createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P39"].ToString().Trim();
            createRequirementModel.str_T2_txt_JobDescription_jobDescription = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P40"].ToString().Trim();
            createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P41"].ToString().Trim();
            createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P42"].ToString().Trim();
            createRequirementModel.str_T2_txt_IdealCandidate_skillDescDesired = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P42"].ToString().Trim();
            createRequirementModel.str_T2_txt_SkillMatrix_skillName = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P43"].ToString().Trim();
            createRequirementModel.str_T2_txt_SkillDescription_skillDescription = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P44"].ToString().Trim();
            createRequirementModel.str_T2_Radiobtn_Level_skillLevelID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P45"].ToString().Trim();
            createRequirementModel.str_T2_select_year_skillYearsExpID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P46"].ToString().Trim();
            createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P48"].ToString().Trim();
            createRequirementModel.str_T2_txt_Description_specialNeedDescription = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P49"].ToString().Trim();
            createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P50"].ToString().Trim();
            createRequirementModel.str_T2_Radiobutton_recurringScheduleTrue = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P51"].ToString().Trim();
            createRequirementModel.str_T2_Radiobutton_Recurring_recurringScheduleFalse = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P51"].ToString().Trim();
            createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P52"].ToString().Trim();
            createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P54"].ToString().Trim();
            createRequirementModel.str_T2_radiobutton_TravelRequired_travel = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P55"].ToString().Trim();

            createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P70"].ToString().Trim();
            createRequirementModel.str_T2_select_Shift_shiftID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P71"].ToString().Trim();
            createRequirementModel.str_T2_Amount_shiftDiffPercent = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P72"].ToString().Trim();
            createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P66"].ToString().Trim();
            createRequirementModel.str_T2_Radiobutton_OtLimitation_OtLimit = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P67"].ToString().Trim();
            createRequirementModel.str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P68"].ToString().Trim();
            createRequirementModel.str_T2_Radiobutton_OtPerTrue_OtpreTrue = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P69"].ToString().Trim();
            createRequirementModel.str_T2_btn_TravelandAncillaryExpensesyes_expenses = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P55"].ToString().Trim();
            createRequirementModel.str_T2_txt_EstimatedExpenseAmountperResource_expenseFixedAmount = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P56"].ToString().Trim();
            createRequirementModel.str_T2_Radiobutton_TravelRequired_travel = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P55"].ToString().Trim();
            createRequirementModel.str_T2_txt_TravelLocation_travelLocation = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P56"].ToString().Trim();
            createRequirementModel.str_T2_txt_TravelDescription_travelDescription = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P57"].ToString().Trim();
            createRequirementModel.str_T2_txt_AnticipatedaverageOTperweek_hasOTHours = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P74"].ToString().Trim();
            createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P74"].ToString().Trim();
            createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P75"].ToString().Trim();
            createRequirementModel.str_T2_select_Currency_currencyID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P76"].ToString().Trim();
            createRequirementModel.str_T2_select_ratetype_rateTypeID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P77"].ToString().Trim();
            createRequirementModel.str_T2_txt_PayRateLow_payRateLow = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P59"].ToString().Trim();
            createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P60"].ToString().Trim();
            createRequirementModel.str_T2_txt_Billratelow_billRateLow = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P61"].ToString().Trim();
            createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P62"].ToString().Trim();
            createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P63"].ToString().Trim();
            createRequirementModel.str_T2_txt_totalContractValue_estContractValue = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P63"].ToString().Trim();
            createRequirementModel.str_T2_btn_RateNegotiable_rateNego = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P64"].ToString().Trim();
            createRequirementModel.str_T3_guidelines_guidelineAccepted = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P82"].ToString().Trim();

            createRequirementModel.str_T2_Typeahead_JobCategory_txtJobTitle = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P39"].ToString().Trim();
            createRequirementModel.str_T2_txt_JobDescription_jobDescription = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P40"].ToString().Trim();

            #region rakesh
            createRequirementModel.str_T1_typehead_LocationCode_CostCenterId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P134"].ToString().Trim();
            createRequirementModel.str_T1_Txt_LocationName_CostCenterName = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P135"].ToString().Trim();
            createRequirementModel.str_T1_Select_ShiftStart_ProfitCenterId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P136"].ToString().Trim();
            createRequirementModel.str_T1_Select_ShiftEnd_spendLevelId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P137"].ToString().Trim();
            createRequirementModel.str_T1_txt_Comments_JustificationtoHire = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P28"].ToString().Trim();
            createRequirementModel.str_T2_Txt_WeeklySpend_WeeklySpendValue = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P143"].ToString().Trim();
            createRequirementModel.str_T1_select_ReasonToEngage_reasonToHireID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P15"].ToString().Trim();
            createRequirementModel.str_T1_select_DirectFill_laborClassCode = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P108"].ToString().Trim();
            #endregion
            createRequirementModel.str_T1_Typeahead_Requestor_hiringManager = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P18"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_RCCode_deptNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P90"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_AlternateRequestor_altHiringManager = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P19"].ToString().Trim();
            createRequirementModel.str_T1_select_AccountCode_programId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P13"].ToString().Trim();
            createRequirementModel.str_T1_select_YPCompany_siteLocationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P31"].ToString().Trim();

            createRequirementModel.str_T2_Typeahead_Title_txtJobTitle = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P39"].ToString().Trim();
            createRequirementModel.str_T2_Typeahead_AssignmentDetail_jobDescription = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P40"].ToString().Trim();
            createRequirementModel.str_T1_btn_HRReviewed_computerAccess = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P113"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_Branch_organizationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P9"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_programManager_altHiringManager = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P19"].ToString().Trim();
            createRequirementModel.str_T1_Select_Company_siteLocationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P31"].ToString().Trim();
            createRequirementModel.str_T1_Select_AccountUnit_deptNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P90"].ToString().Trim();
            createRequirementModel.str_T1_text_MatrixNumber_matrixNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P111"].ToString().Trim();
            createRequirementModel.str_T1_typehead_MatrixManager_hiringManager = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P18"].ToString().Trim();
            createRequirementModel.str_T1_typeahead_FunctionalManager_altHiringManager = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P19"].ToString().Trim();
            createRequirementModel.str_T1_select_Department_deptNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P90"].ToString().Trim();
            createRequirementModel.str_T1_select_CoEReqType_serviceMethodID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P10"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_POID_ProjectId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P109"].ToString().Trim();
            createRequirementModel.str_T1_select_TypeofAssignment_workScheduleID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P27"].ToString().Trim();
            createRequirementModel.str_T1_txt_AdditionalWorkLocationDetails_JustificationtoHire = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P28"].ToString().Trim();
            createRequirementModel.str_T2_select_LaborCategory_typeofServiceID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P38"].ToString().Trim();
            createRequirementModel.str_T2_btn_Isthisareplacementrequistion_directIndirectTrue = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P130"].ToString().Trim();
            createRequirementModel.str_T2_txt_IsthisareplacementrequistionRequistion_association = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P131"].ToString().Trim();
            createRequirementModel.str_T2_btn_IsOnCallRequired_shiftTrue = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P132"].ToString().Trim();
            createRequirementModel.str_T2_txt_IsOnCallRequiredAmount_shiftDiffAmount = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P133"].ToString().Trim();
            createRequirementModel.str_T2_txt_BillRateRange_billRateLow = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P61"].ToString().Trim();
            createRequirementModel.str_T2_txt_BillRateRange_billRateHigh = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P62"].ToString().Trim();
            createRequirementModel.str_T2_txt_AssignmentDescription_jobDescription = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P40"].ToString().Trim();
            createRequirementModel.str_Typeahead_DelegateofAuthority_altHiringManager = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P19"].ToString().Trim();
            createRequirementModel.str_T1_Radio_CostCenterOrProfitCenter_AccountAssignment1 = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P144"].ToString().Trim();
            createRequirementModel.str_T1_Radio_ProjectOrWBSElement_AccountAssignment3 = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P144"].ToString().Trim();
            createRequirementModel.str_T1_select_PurchasingGroup_serviceMethodID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P10"].ToString().Trim();
            createRequirementModel.str_txt_Requisitioner_CreatedUserID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P145"].ToString().Trim();
            createRequirementModel.str_select_MaterialGroup_laborClassCode = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P108"].ToString().Trim();
            createRequirementModel.str_select_PurchaseOrganization_programId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P13"].ToString().Trim();
            createRequirementModel.str_Typeahead_PlantNumber_siteLocationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P31"].ToString().Trim();
            createRequirementModel.str_T1_Typehead_ProfitCenter_ProfitCenterId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P129"].ToString().Trim();
            createRequirementModel.str_T1_typehead_EngagingManagerPM_hiringManager = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P18"].ToString().Trim();
            createRequirementModel.str_datepicker_NeededDate_neededStartDate = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P20"].ToString().Trim();
            createRequirementModel.str_datepicker_EndDate_enddate = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P21"].ToString().Trim();
            createRequirementModel.str_T1_Select_QualityAssurance_programId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P13"].ToString().Trim();
            createRequirementModel.str_T1_Select_PlaceOfWork_siteLocationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P25"].ToString().Trim();
            createRequirementModel.str_T1_TypeHead_CompanyCode_deptNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P12"].ToString().Trim();
            createRequirementModel.str_T1_select_WorkLocation_workLocationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P23"].ToString().Trim();
            createRequirementModel.str_T1_txt_IncumbentNameTermDate_JustificationtoHire = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P30"].ToString().Trim();
            createRequirementModel.str_T1_TypeHead_WorkLocationAddress_workLocationAddress = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P24"].ToString().Trim();
            createRequirementModel.str_T1_select_JustificationforOpening_reasonToHireID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P15"].ToString().Trim();
            createRequirementModel.str_T2_TypeHead_JobTitle_txtJobTitle = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P39"].ToString().Trim();
            createRequirementModel.str_T1_select_Divison_organizationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P9"].ToString().Trim();
            createRequirementModel.str_T1_select_COEBAT_ProfitCenterId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P129"].ToString().Trim();
            createRequirementModel.str_T1_select_DeptProgramTaskOrder_programId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P13"].ToString().Trim();
            createRequirementModel.str_T1_txt_PA_association = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P115"].ToString().Trim();
            createRequirementModel.str_T1_select_PAA_CostCenterId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P30"].ToString().Trim();
            createRequirementModel.str_T1_txt_ManagerPeopleSoftNumber_ServDept = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P116"].ToString().Trim();
            createRequirementModel.str_T1_btn_USCitizenshipRequired_laborClassCode = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P146"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_EAAApprover_altHiringManager = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P19"].ToString().Trim();
            createRequirementModel.str_T1_txt_Justificationforhire_JustificationtoHire = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P28"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_LegalEntity_organizationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P9"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_BusinessArea_ProjectId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P109"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_NaturalAccount_GLId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P14"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_LocalAnalysis_siteLocationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P31"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_Fiscal_matrixNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P111"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_Intercompany_deptNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P90"].ToString().Trim();
            createRequirementModel.str_T1_select_BusinessUnit_serviceMethodID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P10"].ToString().Trim();
            createRequirementModel.str_T1_select_EmergencyPosition_laborClassCode = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P108"].ToString().Trim();
            createRequirementModel.str_T1_txt_AdditionalrequirementDetails_JustificationtoHire = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P28"].ToString().Trim();
            createRequirementModel.str_T2_btn_Isthisareplacementrequisition_directIndirect = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P149"].ToString().Trim();
            createRequirementModel.str_T2_txt_Requisition_association = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P150"].ToString().Trim();
            createRequirementModel.str_T2_btn_Arethereunionizedworkersatthislocation_UnauthorizedWorker = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P151"].ToString().Trim();
            createRequirementModel.str_T2_txt_CBAContract_CollectiveBargainingAgreementCode = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P152"].ToString().Trim();
            createRequirementModel.str_T2_btn_Isthepositionexpectedtobelongerthan13weeks_interviewRequired = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P153"].ToString().Trim();
            createRequirementModel.str_T2_txt_Amount_shiftDiffAmount = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P155"].ToString().Trim();
            createRequirementModel.str_T2_btn_Isthereashiftdifferential_shift = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P154"].ToString().Trim();
            createRequirementModel.str_T2_txt_Workinghours_shiftDiffPercent = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P156"].ToString().Trim();
            createRequirementModel.str_T2_btn_IsTravelRequired_expenses = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P157"].ToString().Trim();
            createRequirementModel.str_T1_select_FundingSource_serviceMethodID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P10"].ToString().Trim();
            createRequirementModel.str_T2_select_JobTitle_jobTitleID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P39"].ToString().Trim();
            createRequirementModel.str_T2_selectGLAccount_GLIdJD = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P147"].ToString().Trim();
            createRequirementModel.str_T1_btn_ComputerSystemsAccess_ComputerSystemsAccess = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P113"].ToString().Trim();
            createRequirementModel.str_T1_Select_ComplianceAccessNeeded_matrixNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P113"].ToString().Trim();
            createRequirementModel.str_T2_Radio_RegularUseofaCompanyVehicle = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P11"].ToString().Trim();
            createRequirementModel.str_T2_Radio_ExemptNonExempt = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P11"].ToString().Trim();
            createRequirementModel.str_T2_Radio_MileageReimbursement = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P11"].ToString().Trim();
            createRequirementModel.str_T1_select_ShiftEnd_spendLevelId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P158"].ToString().Trim();
            createRequirementModel.str_T1_select_ShiftStart_ProfitCenterId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P136"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_GoodsReceiptApprover_altHiringManager = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P19"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_BuyerName_CostCenterId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P30"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_OrganizationName_organizationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P9"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_CourseName_serviceMethodID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P10"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_SpendCategory_deptNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P90"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_Fund_siteLocationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P31"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_Purpose_ProfitCenterId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P129"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_ProgramName_programId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P13"].ToString().Trim();
            createRequirementModel.str_T1_Txt_POdetailsRemoteCWWorklocationaddress_JustificationtoHire = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P28"].ToString().Trim();
            createRequirementModel.str_txt_TemplateName_templateName = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P194"].ToString().Trim();
            createRequirementModel.str_btn_TemplateSubmit_Submit = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P195"].ToString().Trim();
            createRequirementModel.str_btn_TemplateCancel_Cancel = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P196"].ToString().Trim();
            createRequirementModel.str_btn_TemplateCancel_btnReviewCancel = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P197"].ToString().Trim();
            createRequirementModel.str_T1_Radiobtn_CWCanWorkRemotely_directIndirect = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P159"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_Division_programId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P13"].ToString().Trim();
            createRequirementModel.str_Search_searchButton = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P198"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_Divison_GLId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P14"].ToString().Trim();
            createRequirementModel.str_T1_Select_ReqType_organizationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P9"].ToString().Trim();
            createRequirementModel.str_T1_Select_SubDivision_programId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P13"].ToString().Trim();
            createRequirementModel.str_T1_Select_Department_deptNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P90"].ToString().Trim();
            createRequirementModel.str_T1_Txt_Comments_JustificationtoHire = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P28"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_Department_organizationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P9"].ToString().Trim();
            createRequirementModel.str_T1_Select_AccountCode_CostCenterId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P30"].ToString().Trim();
            createRequirementModel.str_T1_Select_SupervisorOrg_ProfitCenterId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P129"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_FinanceEntity_organizationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P9"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_BusinessStructure_deptNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P90"].ToString().Trim();
            createRequirementModel.str_T1_Date_TargetStartDate_neededStartDate = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P20"].ToString().Trim();
            createRequirementModel.str_T1_Date_TargetEnddate_enddate = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P21"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_PrimaryLocation_workLocationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P23"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_PrimaryLocationAddress_workLocationAddress = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P24"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_ProductLine_siteLocationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P31"].ToString().Trim();
            createRequirementModel.str_T1_Select_DirectFill_laborClassCode = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P108"].ToString().Trim();
            createRequirementModel.str_T1_Select_WorkerSubType_serviceMethodID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P10"].ToString().Trim();
            createRequirementModel.str_T1_Txt_Justification_JustificationtoHire = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P28"].ToString().Trim();
            createRequirementModel.str_T1_Select_TimeType_workScheduleID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P27"].ToString().Trim();
            createRequirementModel.str_T2_Typeahead_JobPostingTitle_txtJobTitle = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P39"].ToString().Trim();
            createRequirementModel.str_T2_btn_CandidateMeeting_inter = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P54"].ToString().Trim();
            createRequirementModel.str_T2_Select_Workshift_shiftID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P71"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_Requestor_createdUserID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P8"].ToString().Trim();

            createRequirementModel.str_T1_select_CompanyNumber_deptNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P11"].ToString().Trim();
            createRequirementModel.str_T1_select_CommodityCode_laborClassCode = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P142"].ToString().Trim();

            createRequirementModel.str_T1_select_ReasonForHire_reasonToHireID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P15"].ToString().Trim();
            createRequirementModel.str_T1_TypeHead_EPPICProject_ProjectId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P138"].ToString().Trim();
            createRequirementModel.str_T1_Select_EPPICRole_spendLevelId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P139"].ToString().Trim();
            createRequirementModel.str_T1_select_EPPICRegion_ProfitCenterId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P140"].ToString().Trim();
            createRequirementModel.str_T1_select_EPPICResourcePool_matrixNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P141"].ToString().Trim();
            createRequirementModel.str_T1_Select_CompanyNumber_deptNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P90"].ToString().Trim();
            createRequirementModel.str_T1_Select_HRCostCenter_programId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P13"].ToString().Trim();
            createRequirementModel.str_T1_Select_CommodityCode_laborClassCode = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P108"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_EPPICProject_ProjectId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P109"].ToString().Trim();
            createRequirementModel.str_T1_Select_EPPICRegion_ProfitCenterId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P129"].ToString().Trim();
            createRequirementModel.str_T1_Select_EPPICResourcePool_matrixNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P111"].ToString().Trim();
            createRequirementModel.str_T1_Select_WorkerClassification_laborClassCode = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P108"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_Requestor_altHiringManager = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P19"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_RequestOwner_hiringManager = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P18"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_Company_deptNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P90"].ToString().Trim();
            createRequirementModel.str_T1_Select_EngagementType_serviceMethodID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P10"].ToString().Trim();
            createRequirementModel.str_T2_Select_GLAccount_GLIdJD = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P79"].ToString().Trim();
            createRequirementModel.str_T2_Select_Business_organizationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P80"].ToString().Trim();
            createRequirementModel.str_T2_btn_RateInformation_rdtypeoption = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P58"].ToString().Trim();
            createRequirementModel.str_T2_Txt_NottoExceedBillRate_billRateHigh = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P62"].ToString().Trim(); createRequirementModel.str_T2_Txt_NottoExceedBillRate_billRateHigh = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P62"].ToString().Trim();

            createRequirementModel.str_T1_btn_DoesthedesiredskillsetexistatRydertoday = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P160"].ToString().Trim();
            createRequirementModel.str_T1_Text_Whoisthedesiredresource_singleLine9 = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P161"].ToString().Trim();
            createRequirementModel.str_T1_Text_Whatisthereasonfortheinabilitytoattainthedesiredresource_singleLine10 = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P162"].ToString().Trim();
            createRequirementModel.str_T1_btn_Isthisspendinyourplan = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P163"].ToString().Trim();
            createRequirementModel.str_T1_Text_Ifthespendisintheplanwhatlocationcodeappliestoit_singleLine12 = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P164"].ToString().Trim();
            createRequirementModel.str_T1_btn_Haveyousearchedfortheresourceininternalresourceapplication = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P165"].ToString().Trim();

            createRequirementModel.str_T1_btn_IsDeveloper = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P166"].ToString().Trim();
            createRequirementModel.str_T1_btn_NeedPCorMac = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P167"].ToString().Trim();
            createRequirementModel.str_T1_btn_NeedsLaptoporDesktop = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P168"].ToString().Trim();
            createRequirementModel.str_T2_btn_TravelandAncillaryExpenses_expenses = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P169"].ToString().Trim();
            createRequirementModel.str_T2_txt_EstimatedExpenseAmountperResourceforContractPeriod_expenseFixedAmount = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P170"].ToString().Trim();
            createRequirementModel.str_T2_txt_SalaryRangeMin_MinConversionSalary = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P171"].ToString().Trim();
            createRequirementModel.str_T2_txt_SalaryRangeMax_MaxConversionSalary = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P172"].ToString().Trim();

            createRequirementModel.str_Radiobtn_SkillMatrixMandatory_skillRequiredTrue = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P55"].ToString().Trim();
            createRequirementModel.str_T1_Select_HRDepartment_deptNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P90"].ToString().Trim();
            createRequirementModel.str_T1_Select_LocationCode_siteLocationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P31"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_AccountCode_CostCenterId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P30"].ToString().Trim();
            createRequirementModel.str_T1_Select_HypersionCodeGLUnit_GLId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P14"].ToString().Trim();
            createRequirementModel.str_T1_select_BusinessUnit_organizationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P9"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_APDepartment_deptName = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P34"].ToString().Trim();
            createRequirementModel.str_T1_Select_CORE_ProjectId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P109"].ToString().Trim();
            createRequirementModel.str_T2_Radiobutton_SkillMandatory_skillRequired = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P47"].ToString().Trim();
            createRequirementModel.str_T2_Radiobutton_mandatoryPrestart = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P50"].ToString().Trim();
            createRequirementModel.str_T2_btn_RecurringFrequencySubmit = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P53"].ToString().Trim();
            createRequirementModel.str_T2_Txt_EstimatedLaborExpCost_estContractValue = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P63"].ToString().Trim();
            createRequirementModel.str_T2_Radiobutton_RateNegotiable_rateNego = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P173"].ToString().Trim();
            createRequirementModel.str_T2_Radiobutton_SubmitResumeswithHigherRates_rateCon = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P174"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_BusinessUnit_organizationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P30"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_ObjectAccount_GLId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P14"].ToString().Trim();
            createRequirementModel.str_T1_Select_Group_serviceMethodID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P10"].ToString().Trim();
            createRequirementModel.str_T1_select_WorkWeek_ProjectId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P109"].ToString().Trim();
            createRequirementModel.str_T1_select_ReasontoEngage_reasonToHireID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P15"].ToString().Trim();
            createRequirementModel.str_T1_select_DoestheCWhaveITorFacilitiesneeds_siteLocationID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P31"].ToString().Trim();
            createRequirementModel.str_T1_btn_WillCWAccessPII_laborClassCode = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P108"].ToString().Trim();
            createRequirementModel.str_T2_txt_skillName_skillName = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P43"].ToString().Trim();
            createRequirementModel.str_T2_txt_Desired_skillDescDesired = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P44"].ToString().Trim();
            createRequirementModel.str_T2_select_Years_skillYearsExpID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P46"].ToString().Trim();
            createRequirementModel.str_T2_txt_EstHoursWeek_EstWeeklyHours = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P74"].ToString().Trim();
            createRequirementModel.str_T2_select_RateType_rateTypeID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P77"].ToString().Trim();
            createRequirementModel.str_T2_select_TypeofService_typeofServiceID = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P38"].ToString().Trim();
            createRequirementModel.str_T2_txt_Description_skillDescription = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P44"].ToString().Trim();
            createRequirementModel.str_T2_txt_Mandatory_skillDescMandatory = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P41"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_WBSElement_ProjectId = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P109"].ToString().Trim();
            createRequirementModel.str_T1_Typeahead_MatrixNumber_matrixNumber = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P111"].ToString().Trim();
            //Identified requiremetn repository added by manjusha
            createRequirementModel.str_T4_Txt_LastName_lastname = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P200"].ToString().Trim();
            createRequirementModel.str_T4_Txt_FirstName_firstname = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P201"].ToString().Trim();
            createRequirementModel.str_T4_Txt_MiddleName_middlename = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P202"].ToString().Trim();
            createRequirementModel.str_T4_Select_Suffix_nameSuffix = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P203"].ToString().Trim();
            createRequirementModel.str_T4_btn_UploadResume_uploadResume = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P204"].ToString().Trim();
            createRequirementModel.str_T4_Radiobutton_FormerEmployee_exEmployee = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P205"].ToString().Trim();
            createRequirementModel.str_T4_Txt_FormerEmployeeDetails_exEmployeeDetails = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P206"].ToString().Trim();
            createRequirementModel.str_T4_Radiobutton_Retiree_retiredEmployee = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P207"].ToString().Trim();
            createRequirementModel.str_T4_Txt_RetireeDetails_retiredEmployeeDetails = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P208"].ToString().Trim();
            createRequirementModel.str_T4_Radiobutton_FormerIntern_exIntern = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P209"].ToString().Trim();
            createRequirementModel.str_T4_Txt_FormerInternDetails_exInternDetails = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P210"].ToString().Trim();
            createRequirementModel.str_T4_Radiobutton_FormerContractor_exContractor = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P211"].ToString().Trim();
            createRequirementModel.str_T4_Txt_FormerContractorDetails_exContractorDetails = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P212"].ToString().Trim();
            createRequirementModel.str_T4_Txt_Justification_soleJustificationDescription = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P213"].ToString().Trim();
            createRequirementModel.str_T4_btn_UploadJustification_uploadJustification = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P214"].ToString().Trim();
            createRequirementModel.str_T4_Select_Supplier_supplierName = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P215"].ToString().Trim();
            createRequirementModel.str_T1_Txt_DepartmentName_deptName = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P34"].ToString().Trim();
            createRequirementModel.str_T4_Radiobutton_FormerUSGovtMilitaryEmployee_exGovMilEmployee = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P220"].ToString().Trim();
            createRequirementModel.str_T4_Txt_FormerUSGovtMilitaryEmployee_exGovMilEmployeeDetails = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P221"].ToString().Trim();
            createRequirementModel.str_T4_Txt_ContactLastName_recruiterLastName = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P216"].ToString().Trim();
            createRequirementModel.str_T4_Txt_ContactFirstName_recruiterFirstName = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P217"].ToString().Trim();
            createRequirementModel.str_T4_Txt_Phone_workPhone = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P218"].ToString().Trim();
            createRequirementModel.str_T4_Txt_Email_workEmail = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P219"].ToString().Trim();
         //   createRequirementModel.str_T2_Value_EstimatedcontrctValue = LabelData["P1"].ToString().Trim()+"_Label_"+REQ_Data["P164"].ToString().Trim();
            return createRequirementModel;
        }

        public ApproveModel GetApproveData(DataRow Approve_Data)
        {
            ApproveModel approveModel = new ApproveModel();
            approveModel.strClientName = Approve_Data["P3"].ToString().Trim();
            approveModel.strMainMenuLink = Approve_Data["P4"].ToString().Trim();
            approveModel.strSubMenuLink = Approve_Data["P5"].ToString().Trim();
            approveModel.str_Link_ReqNumber = Approve_Data["P6"].ToString().Trim();
            approveModel.str_Link_Approve = Approve_Data["P7"].ToString().Trim();
            approveModel.str_Txt_ApproveComment = Approve_Data["P8"].ToString().Trim();
            approveModel.str_Btn_Approve_Action = Approve_Data["P9"].ToString().Trim();
            approveModel.str_Btn_Approve_Confirm_Action = Approve_Data["P10"].ToString().Trim();
            approveModel.str_Btn_Approve_Confirm_OK_Action = Approve_Data["P11"].ToString().Trim();
            return approveModel;
        }

        public BroadcastModel GetBroadcastData(DataRow Broadcast_Data)
        {
            BroadcastModel broadcastModel = new BroadcastModel();
            broadcastModel.strClientName = Broadcast_Data["P3"].ToString().Trim();
            broadcastModel.strMainMenuLink = Broadcast_Data["P4"].ToString().Trim();
            broadcastModel.strSubMenuLink = Broadcast_Data["P5"].ToString().Trim();
            broadcastModel.str_Link_ReqNumber = Broadcast_Data["P6"].ToString().Trim();
            broadcastModel.str_Link_Broadcast = Broadcast_Data["P7"].ToString().Trim();
            broadcastModel.str_Button_BroadcastToSupplier = Broadcast_Data["P8"].ToString().Trim();
            broadcastModel.str_Txt_PayRates_Min = Broadcast_Data["P9"].ToString().Trim();
            broadcastModel.str_Txt_PayRates_Max = Broadcast_Data["P10"].ToString().Trim();
            broadcastModel.str_Txt_MarkUp = Broadcast_Data["P11"].ToString().Trim();
            broadcastModel.str_CheckBox_RateLevel = Broadcast_Data["P11"].ToString().Trim();
            broadcastModel.str_Txt_BillRate_Min = Broadcast_Data["P12"].ToString().Trim();
            broadcastModel.str_Txt_BillRate_Max = Broadcast_Data["P13"].ToString().Trim();
            broadcastModel.str_Button_SupplierSelection = Broadcast_Data["P14"].ToString().Trim();
            broadcastModel.str_Select_DistributionList = Broadcast_Data["P15"].ToString().Trim();
            broadcastModel.str_Select_Tier = Broadcast_Data["P16"].ToString().Trim();
            broadcastModel.str_Select_GeographicalLocation = Broadcast_Data["P17"].ToString().Trim();
            broadcastModel.str_CheckBox_Suppliers = Broadcast_Data["P18"].ToString().Trim();
            broadcastModel.str_Btn_Broadcast_Action = Broadcast_Data["P19"].ToString().Trim();
            broadcastModel.str_Btn_Broadcast_Action_Confirm = Broadcast_Data["P20"].ToString().Trim();
            broadcastModel.str_Btn_Broadcast_Req_Action_Confirm = Broadcast_Data["P21"].ToString().Trim();
            broadcastModel.str_Link_AddComment = Broadcast_Data["P22"].ToString().Trim();
            broadcastModel.str_Radio_DisplayComment = Broadcast_Data["P23"].ToString().Trim();
            broadcastModel.str_TxtArea_Comment = Broadcast_Data["P24"].ToString().Trim();
            broadcastModel.str_Btn_Submit = Broadcast_Data["P25"].ToString().Trim();
            broadcastModel.str_Btn_Comment_confirm_Yes = Broadcast_Data["P26"].ToString().Trim();
            broadcastModel.str_Btn_Comment_confirm_Ok = Broadcast_Data["P27"].ToString().Trim();
            broadcastModel.str_Chnage_Status = Broadcast_Data["P28"].ToString().Trim();
            broadcastModel.str_Select_ChangeStatus = Broadcast_Data["P29"].ToString().Trim();
            broadcastModel.str_ChangestatusButton_Submit = Broadcast_Data["P30"].ToString().Trim();
            broadcastModel.str_Link_Cancel = Broadcast_Data["P31"].ToString().Trim();
            broadcastModel.str_Select_CancelReason = Broadcast_Data["P32"].ToString().Trim();
            broadcastModel.str_Button_Cancel = Broadcast_Data["P33"].ToString().Trim();
            broadcastModel.str_Button_confirmOk = Broadcast_Data["P34"].ToString().Trim();
            broadcastModel.str_Link_Edit = Broadcast_Data["P35"].ToString().Trim();
            broadcastModel.strbtnReviewSubmit_Edit = Broadcast_Data["P36"].ToString().Trim();
            broadcastModel.str_txt_BillRatesUSD_ddlBillratesHigh = Broadcast_Data["P37"].ToString().Trim();
            return broadcastModel;
        }

        //public ApproveVoucherModel GetApproveVoucherData(DataRow Approve_Vouchers_Data)
        //{
        //    ApproveVoucherModel approveVoucherModel = new ApproveVoucherModel();
        //    approveVoucherModel.strTestCaseId = Approve_Vouchers_Data["TestCaseID"].ToString().Trim();
        //    approveVoucherModel.strUserID = Approve_Vouchers_Data["P3"].ToString().Trim();
        //    approveVoucherModel.strClientName = Approve_Vouchers_Data["P5"].ToString().Trim();
        //    approveVoucherModel.strMainMenuLink = Approve_Vouchers_Data["P6"].ToString().Trim();
        //    approveVoucherModel.strSubMenuLink = Approve_Vouchers_Data["P7"].ToString().Trim();
        //    approveVoucherModel.str_Txt_global_filter = Approve_Vouchers_Data["P8"].ToString().Trim();
        //    approveVoucherModel.str_btn_ActionButton = Approve_Vouchers_Data["P9"].ToString().Trim();
        //    approveVoucherModel.str_link_Actionlink = Approve_Vouchers_Data["P10"].ToString().Trim();
        //    approveVoucherModel.str_Select_cboReson = Approve_Vouchers_Data["P11"].ToString().Trim();
        //    approveVoucherModel.str_Txt_TxtComments = Approve_Vouchers_Data["P12"].ToString().Trim();
        //    return approveVoucherModel;
        //}

        //public SubmitCandidateMethodModel GetSubmitCandidateMethodData(DataRow SubmitCandidate_Data)
        //{
        //    SubmitCandidateMethodModel submitCandidateMethodModel = new SubmitCandidateMethodModel();
        //    submitCandidateMethodModel.strClientName = SubmitCandidate_Data["P3"].ToString().Trim();
        //    submitCandidateMethodModel.strMainMenuLink = SubmitCandidate_Data["P4"].ToString().Trim();
        //    submitCandidateMethodModel.strSubMenuLink = SubmitCandidate_Data["P5"].ToString().Trim();
        //    submitCandidateMethodModel.str_Link_ReqNumber = SubmitCandidate_Data["P6"].ToString().Trim();
        //    submitCandidateMethodModel.str_Link_SearchCandidate = SubmitCandidate_Data["P7"].ToString().Trim();
        //    submitCandidateMethodModel.str_Txt_Last4DigitsSSN = SubmitCandidate_Data["P8"].ToString().Trim();
        //    submitCandidateMethodModel.str_Txt_LastName = SubmitCandidate_Data["P9"].ToString().Trim();
        //    submitCandidateMethodModel.str_Txt_FirstName = SubmitCandidate_Data["P10"].ToString().Trim();
        //    submitCandidateMethodModel.str_Txt_MiddleName = SubmitCandidate_Data["P11"].ToString().Trim();
        //    submitCandidateMethodModel.str_Select_Suffix = SubmitCandidate_Data["P12"].ToString().Trim();
        //    submitCandidateMethodModel.str_Txt_LocationCity = SubmitCandidate_Data["P13"].ToString().Trim();
        //    submitCandidateMethodModel.str_Select_State = SubmitCandidate_Data["P14"].ToString().Trim();
        //    submitCandidateMethodModel.str_RadioButton_Available = SubmitCandidate_Data["P15"].ToString().Trim();
        //    submitCandidateMethodModel.str_Txt_AvailableDate = SubmitCandidate_Data["P16"].ToString().Trim();
        //    submitCandidateMethodModel.str_Txt_ATSID = SubmitCandidate_Data["P17"].ToString().Trim();
        //    submitCandidateMethodModel.str_Txt_Keywords = SubmitCandidate_Data["P18"].ToString().Trim();
        //    submitCandidateMethodModel.str_Select_MyResumes = SubmitCandidate_Data["P19"].ToString().Trim();
        //    submitCandidateMethodModel.str_Select_Recruiter = SubmitCandidate_Data["P20"].ToString().Trim();
        //    submitCandidateMethodModel.str_RadioButton_MilitaryEmployment = SubmitCandidate_Data["P21"].ToString().Trim();
        //    submitCandidateMethodModel.str_Select_SecurityClearance = SubmitCandidate_Data["P22"].ToString().Trim();
        //    submitCandidateMethodModel.str_RadioButton_SecurityClearance = SubmitCandidate_Data["P23"].ToString().Trim();
        //    submitCandidateMethodModel.str_Txt_UploadFilePath = SubmitCandidate_Data["P24"].ToString().Trim();
        //    submitCandidateMethodModel.str_Button_Save = SubmitCandidate_Data["P25"].ToString().Trim();
        //    submitCandidateMethodModel.str_Button_SaveConfirmOK = SubmitCandidate_Data["P26"].ToString().Trim();
        //    submitCandidateMethodModel.str_Button_Search = SubmitCandidate_Data["P27"].ToString().Trim();
        //    submitCandidateMethodModel.str_Button_addcandidatetoresumebank = SubmitCandidate_Data["P28"].ToString().Trim();
        //    submitCandidateMethodModel.str_Link_SubmitReq = SubmitCandidate_Data["P29"].ToString().Trim();

        //    submitCandidateMethodModel.strSelectSkills_Years = SubmitCandidate_Data["P34"].ToString().Trim();
        //    submitCandidateMethodModel.strRadiobtnSkills_Level = SubmitCandidate_Data["P35"].ToString().Trim();
        //    submitCandidateMethodModel.str_Txt_CandidatePayRate = SubmitCandidate_Data["P48"].ToString().Trim();
        //    submitCandidateMethodModel.str_Txt_CandidateOTPayRate = SubmitCandidate_Data["P49"].ToString().Trim();
        //    submitCandidateMethodModel.str_Txt_BillRate = SubmitCandidate_Data["P50"].ToString().Trim();
        //    submitCandidateMethodModel.str_Txt_OTBillRate = SubmitCandidate_Data["P51"].ToString().Trim();
        //    submitCandidateMethodModel.str_Button_SubmitToRequirement = SubmitCandidate_Data["P53"].ToString().Trim();

        //    // Mass upload candidates
        //    submitCandidateMethodModel.str_Link_UploadFile = SubmitCandidate_Data["P70"].ToString().Trim();
        //    submitCandidateMethodModel.str_Txt_MassUploadFilePath = SubmitCandidate_Data["P71"].ToString().Trim();
        //    submitCandidateMethodModel.str_Txt_Comment = SubmitCandidate_Data["P72"].ToString().Trim();
        //    submitCandidateMethodModel.str_Btn_Upload = SubmitCandidate_Data["P73"].ToString().Trim();
        //    submitCandidateMethodModel.str_Btn_Yes_Action_MassUpload = SubmitCandidate_Data["P74"].ToString().Trim();
        //    submitCandidateMethodModel.str_Btn_OK_MassUpload = SubmitCandidate_Data["P75"].ToString().Trim();
        //    submitCandidateMethodModel.str_Btn_Close_MassUpload = SubmitCandidate_Data["P76"].ToString().Trim();
        //    submitCandidateMethodModel.str_Txt_LastName_LastName = SubmitCandidate_Data["P9"].ToString().Trim();
        //    submitCandidateMethodModel.str_Txt_FirstName_FirstName = SubmitCandidate_Data["P10"].ToString().Trim();
        //    submitCandidateMethodModel.str_Txt_LocationCity_LocationCity = SubmitCandidate_Data["P13"].ToString().Trim();
        //    submitCandidateMethodModel.str_Select_State_StateID = SubmitCandidate_Data["P14"].ToString().Trim();
        //    submitCandidateMethodModel.str_RadioButton_Available_AvailableStatus1 = SubmitCandidate_Data["P15"].ToString().Trim();
        //    submitCandidateMethodModel.str_Txt_ATSID_ATSIDField = SubmitCandidate_Data["P17"].ToString().Trim();
        //    submitCandidateMethodModel.str_Select_CandidatesUnder_MyResumesID = SubmitCandidate_Data["P19"].ToString().Trim();
        //    submitCandidateMethodModel.str_Txt_LastName_LastName = SubmitCandidate_Data["P9"].ToString().Trim();
        //    submitCandidateMethodModel.str_Txt_FirstName_FirstName = SubmitCandidate_Data["P10"].ToString().Trim();

        //    return submitCandidateMethodModel;
        //}

        //public SubmitCandidateResumeModel GetSubmitCandidateResumeData(DataRow SubmitCandidate_Data)
        //{
        //    SubmitCandidateResumeModel submitCandidateResumeModel = new SubmitCandidateResumeModel();
        //    submitCandidateResumeModel.strClientName = SubmitCandidate_Data["P3"].ToString().Trim();
        //    submitCandidateResumeModel.str_Button_SaveConfirmOK = SubmitCandidate_Data["P26"].ToString().Trim();
        //    submitCandidateResumeModel.str_Button_Search = SubmitCandidate_Data["P27"].ToString().Trim();
        //    submitCandidateResumeModel.str_Button_addcandidatetoresumebank = SubmitCandidate_Data["P28"].ToString().Trim();
        //    submitCandidateResumeModel.str_Link_SubmitReq = SubmitCandidate_Data["P29"].ToString().Trim();
        //    submitCandidateResumeModel.str_Select_employmentTypeID = SubmitCandidate_Data["P34"].ToString().Trim();
        //    submitCandidateResumeModel.strSelectSkills_Years = SubmitCandidate_Data["P35"].ToString().Trim();
        //    submitCandidateResumeModel.strRadiobtnSkills_Level = SubmitCandidate_Data["P36"].ToString().Trim();
        //    submitCandidateResumeModel.strRadiobtnFormer_Employee = SubmitCandidate_Data["P38"].ToString().Trim();
        //    submitCandidateResumeModel.strRadiobtnFormer_Contractor = SubmitCandidate_Data["P42"].ToString().Trim();
        //    submitCandidateResumeModel.str_Txt_CandidatePayRate = SubmitCandidate_Data["P49"].ToString().Trim();
        //    submitCandidateResumeModel.str_Txt_CandidateOTPayRate = SubmitCandidate_Data["P50"].ToString().Trim();
        //    submitCandidateResumeModel.str_Txt_BillRate = SubmitCandidate_Data["P51"].ToString().Trim();
        //    submitCandidateResumeModel.str_Txt_OTBillRate = SubmitCandidate_Data["P52"].ToString().Trim();
        //    submitCandidateResumeModel.str_Txt_STID = SubmitCandidate_Data["P53"].ToString().Trim();
        //    submitCandidateResumeModel.str_Button_SubmitToRequirement = SubmitCandidate_Data["P54"].ToString().Trim();
        //    submitCandidateResumeModel.str_Txt_candidateSSN = SubmitCandidate_Data["P55"].ToString().Trim();
        //    submitCandidateResumeModel.str_Date_DOB = SubmitCandidate_Data["P56"].ToString().Trim();
        //    submitCandidateResumeModel.str_Radio_IsSSNValid = SubmitCandidate_Data["P57"].ToString().Trim();
        //    submitCandidateResumeModel.str_Txt_address1 = SubmitCandidate_Data["P58"].ToString().Trim();
        //    submitCandidateResumeModel.str_Txt_city = SubmitCandidate_Data["P59"].ToString().Trim();
        //    submitCandidateResumeModel.str_Select_state = SubmitCandidate_Data["P60"].ToString().Trim();
        //    submitCandidateResumeModel.str_Select_country = SubmitCandidate_Data["P61"].ToString().Trim();
        //    submitCandidateResumeModel.str_Txt_zipcode = SubmitCandidate_Data["P62"].ToString().Trim();
        //    submitCandidateResumeModel.str_Radio_SpouseRelatives = SubmitCandidate_Data["P63"].ToString().Trim();
        //    submitCandidateResumeModel.str_Txt_relativeName = SubmitCandidate_Data["P64"].ToString().Trim();
        //    submitCandidateResumeModel.str_Select_isFormallyEmployeed = SubmitCandidate_Data["P65"].ToString().Trim();
        //    submitCandidateResumeModel.str_Select_padsID = SubmitCandidate_Data["P66"].ToString().Trim();
        //    submitCandidateResumeModel.str_Radio_Referral = SubmitCandidate_Data["P67"].ToString().Trim();
        //    submitCandidateResumeModel.str_Date_processingDate = SubmitCandidate_Data["P68"].ToString().Trim();
        //    submitCandidateResumeModel.str_Txt_Email = SubmitCandidate_Data["P70"].ToString().Trim();
        //    submitCandidateResumeModel.str_Select_Gender = SubmitCandidate_Data["P71"].ToString().Trim();
        //    submitCandidateResumeModel.str_Txt_mobilePhone = SubmitCandidate_Data["P72"].ToString().Trim();
        //    submitCandidateResumeModel.str_Select_iseligibilityID = SubmitCandidate_Data["P73"].ToString().Trim();
        //    submitCandidateResumeModel.str_Radio_Retiree = SubmitCandidate_Data["P31"].ToString().Trim();

        //    submitCandidateResumeModel.strDateAssignmentStart = SubmitCandidate_Data["P70"].ToString().Trim();
        //    submitCandidateResumeModel.strDateAssignmentEnd = SubmitCandidate_Data["P71"].ToString().Trim();
        //    submitCandidateResumeModel.str_RadioButton_RetireeRadio = SubmitCandidate_Data["P31"].ToString().Trim();

        //    submitCandidateResumeModel.str_Select_ACACompliantHealthCoverage = SubmitCandidate_Data["P44"].ToString().Trim();
        //    submitCandidateResumeModel.str_Select_ACACostPer = SubmitCandidate_Data["P45"].ToString().Trim();
        //    submitCandidateResumeModel.str_Txt_ACACost = SubmitCandidate_Data["P46"].ToString().Trim();

        //    //cp chem

        //    submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID = SubmitCandidate_Data["P34"].ToString().Trim();
        //    submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID = SubmitCandidate_Data["P35"].ToString().Trim();
        //    submitCandidateResumeModel.str_radiobutton_Level_skillLevelID = SubmitCandidate_Data["P36"].ToString().Trim();
        //    submitCandidateResumeModel.str_radiobutton_FormerEmployee_ExperienceRadio1 = SubmitCandidate_Data["P38"].ToString().Trim();
        //    submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 = SubmitCandidate_Data["P39"].ToString().Trim();
        //    submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 = SubmitCandidate_Data["P40"].ToString().Trim();
        //    submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle = SubmitCandidate_Data["P41"].ToString().Trim();
        //    submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName = SubmitCandidate_Data["P60"].ToString().Trim();


        //    return submitCandidateResumeModel;
        //}

        public SubmitCandidateMethodModel GetSubmitCandidateMethodData(DataRow SubmitCandidate_Data)
        {
            SubmitCandidateMethodModel submitCandidateMethodModel = new SubmitCandidateMethodModel();
            submitCandidateMethodModel.strClientName = SubmitCandidate_Data["P3"].ToString().Trim();
            submitCandidateMethodModel.strMainMenuLink = SubmitCandidate_Data["P4"].ToString().Trim();
            submitCandidateMethodModel.strSubMenuLink = SubmitCandidate_Data["P5"].ToString().Trim();
            submitCandidateMethodModel.str_Link_ReqNumber = SubmitCandidate_Data["P6"].ToString().Trim();
            submitCandidateMethodModel.str_Link_SearchCandidate = SubmitCandidate_Data["P7"].ToString().Trim();
            submitCandidateMethodModel.str_Txt_Last4DigitsSSN = SubmitCandidate_Data["P8"].ToString().Trim();
            submitCandidateMethodModel.str_Txt_LastName = SubmitCandidate_Data["P9"].ToString().Trim();
            submitCandidateMethodModel.str_Txt_FirstName = SubmitCandidate_Data["P10"].ToString().Trim();
            submitCandidateMethodModel.str_Txt_MiddleName = SubmitCandidate_Data["P11"].ToString().Trim();
            submitCandidateMethodModel.str_Select_Suffix = SubmitCandidate_Data["P12"].ToString().Trim();
            submitCandidateMethodModel.str_Txt_LocationCity = SubmitCandidate_Data["P13"].ToString().Trim();
            submitCandidateMethodModel.str_Select_State = SubmitCandidate_Data["P14"].ToString().Trim();
            submitCandidateMethodModel.str_RadioButton_Available = SubmitCandidate_Data["P15"].ToString().Trim();
            submitCandidateMethodModel.str_Txt_AvailableDate = SubmitCandidate_Data["P16"].ToString().Trim();
            submitCandidateMethodModel.str_Txt_ATSID = SubmitCandidate_Data["P17"].ToString().Trim();
            submitCandidateMethodModel.str_Txt_Keywords = SubmitCandidate_Data["P18"].ToString().Trim();
            submitCandidateMethodModel.str_Select_MyResumes = SubmitCandidate_Data["P19"].ToString().Trim();
            submitCandidateMethodModel.str_Select_Recruiter = SubmitCandidate_Data["P20"].ToString().Trim();
            submitCandidateMethodModel.str_RadioButton_MilitaryEmployment = SubmitCandidate_Data["P21"].ToString().Trim();
            submitCandidateMethodModel.str_Select_SecurityClearance = SubmitCandidate_Data["P22"].ToString().Trim();
            submitCandidateMethodModel.str_RadioButton_SecurityClearance = SubmitCandidate_Data["P23"].ToString().Trim();
            submitCandidateMethodModel.str_Txt_UploadFilePath = SubmitCandidate_Data["P24"].ToString().Trim();
            submitCandidateMethodModel.str_Button_Save = SubmitCandidate_Data["P25"].ToString().Trim();
            submitCandidateMethodModel.str_Button_SaveConfirmOK = SubmitCandidate_Data["P26"].ToString().Trim();
            submitCandidateMethodModel.str_Button_Search = SubmitCandidate_Data["P27"].ToString().Trim();
            submitCandidateMethodModel.str_Button_addcandidatetoresumebank = SubmitCandidate_Data["P28"].ToString().Trim();
            submitCandidateMethodModel.str_Link_SubmitReq = SubmitCandidate_Data["P29"].ToString().Trim();

            submitCandidateMethodModel.strSelectSkills_Years = SubmitCandidate_Data["P34"].ToString().Trim();
            submitCandidateMethodModel.strRadiobtnSkills_Level = SubmitCandidate_Data["P35"].ToString().Trim();
            submitCandidateMethodModel.str_Txt_CandidatePayRate = SubmitCandidate_Data["P48"].ToString().Trim();
            submitCandidateMethodModel.str_Txt_CandidateOTPayRate = SubmitCandidate_Data["P49"].ToString().Trim();
            submitCandidateMethodModel.str_Txt_BillRate = SubmitCandidate_Data["P50"].ToString().Trim();
            submitCandidateMethodModel.str_Txt_OTBillRate = SubmitCandidate_Data["P51"].ToString().Trim();
            submitCandidateMethodModel.str_Button_SubmitToRequirement = SubmitCandidate_Data["P53"].ToString().Trim();

            // Mass upload candidates
            submitCandidateMethodModel.str_Link_UploadFile = SubmitCandidate_Data["P70"].ToString().Trim();
            submitCandidateMethodModel.str_Txt_MassUploadFilePath = SubmitCandidate_Data["P71"].ToString().Trim();
            submitCandidateMethodModel.str_Txt_Comment = SubmitCandidate_Data["P72"].ToString().Trim();
            submitCandidateMethodModel.str_Btn_Upload = SubmitCandidate_Data["P73"].ToString().Trim();
            submitCandidateMethodModel.str_Btn_Yes_Action_MassUpload = SubmitCandidate_Data["P74"].ToString().Trim();
            submitCandidateMethodModel.str_Btn_OK_MassUpload = SubmitCandidate_Data["P75"].ToString().Trim();
            submitCandidateMethodModel.str_Btn_Close_MassUpload = SubmitCandidate_Data["P76"].ToString().Trim();
            submitCandidateMethodModel.str_Txt_LastName_LastName = SubmitCandidate_Data["P9"].ToString().Trim();
            submitCandidateMethodModel.str_Txt_FirstName_FirstName = SubmitCandidate_Data["P10"].ToString().Trim();
            submitCandidateMethodModel.str_Txt_LocationCity_LocationCity = SubmitCandidate_Data["P13"].ToString().Trim();
            submitCandidateMethodModel.str_Select_State_StateID = SubmitCandidate_Data["P14"].ToString().Trim();
            submitCandidateMethodModel.str_RadioButton_Available_AvailableStatus1 = SubmitCandidate_Data["P15"].ToString().Trim();
            submitCandidateMethodModel.str_Txt_ATSID_ATSIDField = SubmitCandidate_Data["P17"].ToString().Trim();
            submitCandidateMethodModel.str_Select_CandidatesUnder_MyResumesID = SubmitCandidate_Data["P19"].ToString().Trim();
            submitCandidateMethodModel.str_Txt_LastName_LastName = SubmitCandidate_Data["P9"].ToString().Trim();
            submitCandidateMethodModel.str_Txt_FirstName_FirstName = SubmitCandidate_Data["P10"].ToString().Trim();

            return submitCandidateMethodModel;
        }


        public SubmitCandidateAddResume GetSubmitCandidateAddResumeData(DataRow SubmitCandidate_Data)
        {
            SubmitCandidateAddResume submitCandidateAddResume = new SubmitCandidateAddResume();
            submitCandidateAddResume.str_BrowserName = SubmitCandidate_Data["P1"].ToString().Trim();
            submitCandidateAddResume.strClientName = SubmitCandidate_Data["P3"].ToString().Trim();
            submitCandidateAddResume.str_Link_ReqNumber = SubmitCandidate_Data["P6"].ToString().Trim();
            submitCandidateAddResume.str_Txt_Last4DigitsSSN = SubmitCandidate_Data["P8"].ToString().Trim();
            submitCandidateAddResume.str_Txt_LastName = SubmitCandidate_Data["P9"].ToString().Trim();
            submitCandidateAddResume.str_Txt_FirstName = SubmitCandidate_Data["P10"].ToString().Trim();
            submitCandidateAddResume.str_Txt_MiddleName = SubmitCandidate_Data["P11"].ToString().Trim();
            submitCandidateAddResume.str_Select_Suffix = SubmitCandidate_Data["P12"].ToString().Trim();
            submitCandidateAddResume.str_Txt_LocationCity = SubmitCandidate_Data["P13"].ToString().Trim();
            submitCandidateAddResume.str_Select_State = SubmitCandidate_Data["P14"].ToString().Trim();
            submitCandidateAddResume.str_RadioButton_Available = SubmitCandidate_Data["P15"].ToString().Trim();
            submitCandidateAddResume.str_Txt_AvailableDate = SubmitCandidate_Data["P16"].ToString().Trim();
            submitCandidateAddResume.str_Txt_ATSID = SubmitCandidate_Data["P17"].ToString().Trim();
            submitCandidateAddResume.str_Txt_Keywords = SubmitCandidate_Data["P18"].ToString().Trim();
            submitCandidateAddResume.str_Select_MyResumes = SubmitCandidate_Data["P19"].ToString().Trim();
            submitCandidateAddResume.str_Select_Recruiter = SubmitCandidate_Data["P20"].ToString().Trim();
            submitCandidateAddResume.str_RadioButton_MilitaryEmployment = SubmitCandidate_Data["P21"].ToString().Trim();
            submitCandidateAddResume.str_Select_SecurityClearance = SubmitCandidate_Data["P22"].ToString().Trim();
            submitCandidateAddResume.str_RadioButton_SecurityClearance = SubmitCandidate_Data["P23"].ToString().Trim();
            submitCandidateAddResume.str_Txt_UploadFilePath = SubmitCandidate_Data["P24"].ToString().Trim();
            submitCandidateAddResume.str_Button_Save = SubmitCandidate_Data["P25"].ToString().Trim();
            submitCandidateAddResume.str_Button_SaveConfirmOK = SubmitCandidate_Data["P26"].ToString().Trim();
            submitCandidateAddResume.str_select_Languages = SubmitCandidate_Data["P57"].ToString().Trim();
            submitCandidateAddResume.str_Radio_Employement = SubmitCandidate_Data["P58"].ToString().Trim();
            submitCandidateAddResume.str_Txt_Employement = SubmitCandidate_Data["P59"].ToString().Trim();
            submitCandidateAddResume.str_select_locationorcityLocationCity = SubmitCandidate_Data["P13"].ToString().Trim();
            submitCandidateAddResume.str_Select_Suffix_SuffixName = SubmitCandidate_Data["P32"].ToString().Trim();
            submitCandidateAddResume.str_select_Country_country = SubmitCandidate_Data["P11"].ToString().Trim();
            submitCandidateAddResume.str_Txt_LastName_LastName = SubmitCandidate_Data["P9"].ToString().Trim();
            submitCandidateAddResume.str_Txt_FirstName_FirstName = SubmitCandidate_Data["P10"].ToString().Trim();
            submitCandidateAddResume.str_select_State_State = SubmitCandidate_Data["P12"].ToString().Trim();
            return submitCandidateAddResume;
        }

        public AcceptOfferModel GetAcceptOfferData(DataRow AcceptOffer_Data)
        {
            AcceptOfferModel acceptOfferModel = new AcceptOfferModel();
            acceptOfferModel.strClientName = AcceptOffer_Data["P3"].ToString().Trim();
            acceptOfferModel.strMainMenuLink = AcceptOffer_Data["P4"].ToString().Trim();
            acceptOfferModel.strSubMenuLink = AcceptOffer_Data["P5"].ToString().Trim();
            acceptOfferModel.str_Link_ReqNumber = AcceptOffer_Data["P6"].ToString().Trim();
            acceptOfferModel.str_Link_CandidatesWithOffers = AcceptOffer_Data["P7"].ToString().Trim();
            acceptOfferModel.str_CandidateName = AcceptOffer_Data["P8"].ToString().Trim();
            acceptOfferModel.str_Link_AcceptOffer = AcceptOffer_Data["P9"].ToString().Trim();
            acceptOfferModel.str_Txt_SmartTrackIdentifier = AcceptOffer_Data["P10"].ToString().Trim();
            acceptOfferModel.str_Select_Country = AcceptOffer_Data["P11"].ToString().Trim();
            acceptOfferModel.str_Select_state = AcceptOffer_Data["P12"].ToString().Trim();
            acceptOfferModel.str_Select_County = AcceptOffer_Data["P13"].ToString().Trim();
            acceptOfferModel.str_Txt_candidateSSN = AcceptOffer_Data["P14"].ToString().Trim();
            acceptOfferModel.str_Date_DOB = AcceptOffer_Data["P15"].ToString().Trim();
            acceptOfferModel.str_Txt_Email = AcceptOffer_Data["P16"].ToString().Trim();
            acceptOfferModel.str_Btn_Accept_Submit = AcceptOffer_Data["P26"].ToString().Trim();
            acceptOfferModel.str_Btn_AcceptOffer_Submit_Confirm = AcceptOffer_Data["P27"].ToString().Trim();
            acceptOfferModel.str_Btn_AcceptOffer_Submit_Confirm_Ok = AcceptOffer_Data["P28"].ToString().Trim();
            acceptOfferModel.str_Btn_Rejectoffer_Link = AcceptOffer_Data["P29"].ToString().Trim();
            acceptOfferModel.str_Select_RejectOfferReason = AcceptOffer_Data["P30"].ToString().Trim();
            acceptOfferModel.str_Txt_RejectOfferReason_Comment = AcceptOffer_Data["P31"].ToString().Trim();
            acceptOfferModel.str_Button_RejectOfferReason = AcceptOffer_Data["P32"].ToString().Trim();
            acceptOfferModel.str_Button_RejectOfferYes = AcceptOffer_Data["P33"].ToString().Trim();
            acceptOfferModel.str_Button_RejectOfferOK = AcceptOffer_Data["P34"].ToString().Trim();

            //Identified
            acceptOfferModel.str_Txt_LastName_LastName = AcceptOffer_Data["P50"].ToString().Trim();
            acceptOfferModel.str_Txt_FirstName_FirstName = AcceptOffer_Data["P51"].ToString().Trim();
            acceptOfferModel.str_txt_MiddleName_MiddleName = AcceptOffer_Data["P52"].ToString().Trim();
            acceptOfferModel.str_Select_SuffixName_SuffixName = AcceptOffer_Data["P53"].ToString().Trim();
            acceptOfferModel.str_Radio_Available_Available = AcceptOffer_Data["P54"].ToString().Trim();
            acceptOfferModel.str_Date_Available_AvailableDate = AcceptOffer_Data["P55"].ToString().Trim();
            acceptOfferModel.str_Txt_PermanatLocation_LocationCity = AcceptOffer_Data["P56"].ToString().Trim();
            acceptOfferModel.str_Select_State_StatesID = AcceptOffer_Data["P57"].ToString().Trim();
            acceptOfferModel.str_Select_Recruiter_RecruiterName = AcceptOffer_Data["P58"].ToString().Trim();
            acceptOfferModel.str_Txt_Keywords_Keywords = AcceptOffer_Data["P59"].ToString().Trim();
            acceptOfferModel.str_Resume_ResumeUpload_btnresumeupload = AcceptOffer_Data["P60"].ToString().Trim();
            acceptOfferModel.str_Radiobutton_Retiree_RetireeRadio = AcceptOffer_Data["P61"].ToString().Trim();
            acceptOfferModel.str_Date_RetiredDate_RetiredDate = AcceptOffer_Data["P62"].ToString().Trim();
            acceptOfferModel.str_txt_RetireeJobTitle_RetiredJobTitle = AcceptOffer_Data["P63"].ToString().Trim();
            acceptOfferModel.str_select_YearsExperience_skillYearsExpID = AcceptOffer_Data["P64"].ToString().Trim();
            acceptOfferModel.str_radiobutton_Level_skillLevelID = AcceptOffer_Data["P65"].ToString().Trim();
            acceptOfferModel.str_txt_Comments_supplierComments = AcceptOffer_Data["P66"].ToString().Trim();
            acceptOfferModel.str_Radio_PastPresentMilitaryEmployment_Employment = AcceptOffer_Data["P67"].ToString().Trim();
            acceptOfferModel.str_Txt_PastPresentMilitaryEmployment_EmploymentDetails = AcceptOffer_Data["P68"].ToString().Trim();
            acceptOfferModel.str_radiobutton_FormerEmployee_ExperienceRadio = AcceptOffer_Data["P69"].ToString().Trim();
            acceptOfferModel.str_Date_FromerEmployeeFromDate_fromDate1 = AcceptOffer_Data["P70"].ToString().Trim();
            acceptOfferModel.str_Date_FromerEmployeeToDate_toDate1 = AcceptOffer_Data["P71"].ToString().Trim();
            acceptOfferModel.str_txt_FromerEmployeeJobTitle_jobTitle = AcceptOffer_Data["P72"].ToString().Trim();
            acceptOfferModel.str_txt_FromerEmployeeSupervisor_supervisorName = AcceptOffer_Data["P73"].ToString().Trim();
            acceptOfferModel.str_radiobutton_FromerContractor_contractor = AcceptOffer_Data["P74"].ToString().Trim();
            acceptOfferModel.str_Date_FormerContractor_fromDateContractor1 = AcceptOffer_Data["P75"].ToString().Trim();
            acceptOfferModel.str_Date_FormerContractor_toDateContractor1 = AcceptOffer_Data["P76"].ToString().Trim();
            acceptOfferModel.str_txt_FromerContractorJobTitle_jobTitle = AcceptOffer_Data["P77"].ToString().Trim();
            acceptOfferModel.str_txt_FromerContractorSupervisor_supervisorName = AcceptOffer_Data["P78"].ToString().Trim();
            acceptOfferModel.str_txt_CandidatePayRate_supplierRegPayRate = AcceptOffer_Data["P79"].ToString().Trim();
            acceptOfferModel.str_txt_CandidateOTPayRate_supplierOTPayRate = AcceptOffer_Data["P80"].ToString().Trim();
            acceptOfferModel.str_txt_BillRate_supplierRegBillRate = AcceptOffer_Data["P81"].ToString().Trim();
            acceptOfferModel.str_txt_SupplierOTBillRate_supplierOTBillRate = AcceptOffer_Data["P82"].ToString().Trim();

            acceptOfferModel.str_txt_Last4DigitsofSSN_STID1 = AcceptOffer_Data["P83"].ToString().Trim();
            acceptOfferModel.str_select_SSNMonth_STID2 = AcceptOffer_Data["P84"].ToString().Trim();
            acceptOfferModel.str_select_SSNDate_STID3 = AcceptOffer_Data["P84"].ToString().Trim();

            return acceptOfferModel;
        }

        public IssueWorkOrderModel GetIssueWorkOrderData(DataRow IssueWorkOrder_Data)
        {
            IssueWorkOrderModel issueWorkOrderModel = new IssueWorkOrderModel();
            issueWorkOrderModel.strClientName = IssueWorkOrder_Data["P3"].ToString().Trim();
            issueWorkOrderModel.strMainMenuLink = IssueWorkOrder_Data["P4"].ToString().Trim();
            issueWorkOrderModel.strSubMenuLink = IssueWorkOrder_Data["P5"].ToString().Trim();
            issueWorkOrderModel.str_Link_ReqNumber = IssueWorkOrder_Data["P6"].ToString().Trim();
            issueWorkOrderModel.str_Link_ActionList_ViewCandidates = IssueWorkOrder_Data["P7"].ToString().Trim();
            issueWorkOrderModel.str_CandidateName = IssueWorkOrder_Data["P8"].ToString().Trim();
            issueWorkOrderModel.str_Txt_Years = IssueWorkOrder_Data["P9"].ToString().Trim();
            issueWorkOrderModel.str_Link_ActionList_IssueWorkOrder = IssueWorkOrder_Data["P9"].ToString().Trim();
            issueWorkOrderModel.str_AddListTxt_txtTimecardApprover = IssueWorkOrder_Data["P10"].ToString().Trim();
            issueWorkOrderModel.str_DeleteListTxt_txtTimecardApprover = IssueWorkOrder_Data["P11"].ToString().Trim();
            issueWorkOrderModel.str_AddListTxt_ChargeNumbers = IssueWorkOrder_Data["P12"].ToString().Trim();
            issueWorkOrderModel.str_DeleteListTxt_ChargeNumbers = IssueWorkOrder_Data["P13"].ToString().Trim();
            issueWorkOrderModel.str_AddListTxt_GLNumbers = IssueWorkOrder_Data["P14"].ToString().Trim();
            issueWorkOrderModel.str_DeleteListTxt_GLNumbers = IssueWorkOrder_Data["P15"].ToString().Trim();
            issueWorkOrderModel.str_Txt_PrefStartdate = IssueWorkOrder_Data["P16"].ToString().Trim();
            issueWorkOrderModel.str_Txt_enddate = IssueWorkOrder_Data["P17"].ToString().Trim();
            issueWorkOrderModel.str_Txt_supplierRegPayRate = IssueWorkOrder_Data["P18"].ToString().Trim();//Candidate Pay Rate
            issueWorkOrderModel.str_Txt_supplierOTPayRate = IssueWorkOrder_Data["P19"].ToString().Trim();//Candidate OT Pay Rate
            issueWorkOrderModel.str_Txt_supplierRegBillRate = IssueWorkOrder_Data["P20"].ToString().Trim(); //Supplier Bill Rate
            issueWorkOrderModel.str_Txt_supplierOTBillRate = IssueWorkOrder_Data["P21"].ToString().Trim(); //Supplier OT Bill Rate
            issueWorkOrderModel.str_Txt_supplierMarkupRate = IssueWorkOrder_Data["P22"].ToString().Trim(); //Supplier Markup%
            issueWorkOrderModel.str_Txt_ProposedFinalRegBillRate = IssueWorkOrder_Data["P23"].ToString().Trim();//Final Bill Rate dcr
            issueWorkOrderModel.str_Txt_finalRegBillRate = IssueWorkOrder_Data["P23"].ToString().Trim();//Final Bill Rate
            issueWorkOrderModel.str_Txt_proposedFinalOTBillRate = IssueWorkOrder_Data["P24"].ToString().Trim();//Final OT Bill Rate dcr
            issueWorkOrderModel.str_Txt_finalOTBillRate = IssueWorkOrder_Data["P24"].ToString().Trim();//Final OT Bill Rate
            issueWorkOrderModel.str_Txt_mspFeeMarkup = IssueWorkOrder_Data["P25"].ToString().Trim();//MSP Fee %
            issueWorkOrderModel.str_Txt_mspRegBillRate = IssueWorkOrder_Data["P26"].ToString().Trim();//MSP Fee, MSP Rate
            issueWorkOrderModel.str_Txt_mspOTBillRate = IssueWorkOrder_Data["P27"].ToString().Trim(); //MSP OT Fee, MSP OT Rate
            issueWorkOrderModel.str_Txt_vmsRegBillRate = IssueWorkOrder_Data["P28"].ToString().Trim();//VMS Rate
            issueWorkOrderModel.str_Txt_vmsOTBillRate = IssueWorkOrder_Data["P29"].ToString().Trim();//VMS OT Rate
            issueWorkOrderModel.str_Txt_purchaseOrderNumber = IssueWorkOrder_Data["P30"].ToString().Trim();
            issueWorkOrderModel.str_Txt_WeeklySpendValue = IssueWorkOrder_Data["P33"].ToString().Trim();
            issueWorkOrderModel.str_Txt_weeklyRegHoursNTE = IssueWorkOrder_Data["P34"].ToString().Trim();
            issueWorkOrderModel.str_Txt_weeklyOTHoursNTE = IssueWorkOrder_Data["P35"].ToString().Trim();
            issueWorkOrderModel.str_Txt_yearlyRegHoursNTE = IssueWorkOrder_Data["P36"].ToString().Trim();
            issueWorkOrderModel.str_Txt_totalContractValue = IssueWorkOrder_Data["P37"].ToString().Trim();
            issueWorkOrderModel.str_Btn_IssueWorkOrder_Submit = IssueWorkOrder_Data["P38"].ToString().Trim();
            issueWorkOrderModel.str_Btn_IssueWorkOrder_Submit_Confirm = IssueWorkOrder_Data["P39"].ToString().Trim();
            issueWorkOrderModel.str_Btn_IssueWorkOrder_Submit_Confirm_Ok = IssueWorkOrder_Data["P40"].ToString().Trim();
            issueWorkOrderModel.str_Link_CancelWorkOrder = IssueWorkOrder_Data["P41"].ToString().Trim();
            issueWorkOrderModel.str_Typeahead_ChargeNumbers_txtChargeNo = IssueWorkOrder_Data["P41"].ToString().Trim();
            issueWorkOrderModel.str_Txt_CancelWorkOrdercomment = IssueWorkOrder_Data["P42"].ToString().Trim();
            issueWorkOrderModel.str_Button_CancelWorkOrderbutton = IssueWorkOrder_Data["P43"].ToString().Trim();
            issueWorkOrderModel.str_Button_CancelWorkOrderbutton_yes = IssueWorkOrder_Data["P44"].ToString().Trim();
            issueWorkOrderModel.str_Btn_ExtendOffer_Submit_Confirm_Ok = IssueWorkOrder_Data["P45"].ToString().Trim();
            issueWorkOrderModel.str_Link_issueworkorder_Editcandidateinfo = IssueWorkOrder_Data["P46"].ToString().Trim();
            issueWorkOrderModel.str_Button_issueworkorder_Editcandidateinfo_OK = IssueWorkOrder_Data["P47"].ToString().Trim();

            //Cp Chem 
            issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover = IssueWorkOrder_Data["P10"].ToString().Trim();
            issueWorkOrderModel.str_txt_GLNumbers_txtGLNo = IssueWorkOrder_Data["P12"].ToString().Trim();
            issueWorkOrderModel.str_btn_GLNumberAdd_addGLNobtn = IssueWorkOrder_Data["P13"].ToString().Trim();
            issueWorkOrderModel.str_btn_GLNumberDelete_deleteGLNobtn = IssueWorkOrder_Data["P14"].ToString().Trim();
            issueWorkOrderModel.str_Date_AnticipatedStartDate_preferredStartDate = IssueWorkOrder_Data["P16"].ToString().Trim();
            issueWorkOrderModel.str_Date_StartDate_preferredStartDate = IssueWorkOrder_Data["P16"].ToString().Trim();
            issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate = IssueWorkOrder_Data["P16"].ToString().Trim();
            issueWorkOrderModel.str_Date_AssignmentEndDate_endDate = IssueWorkOrder_Data["P17"].ToString().Trim();
            issueWorkOrderModel.str_Date_Enddate_endDate = IssueWorkOrder_Data["P17"].ToString().Trim();
            issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate = IssueWorkOrder_Data["P18"].ToString().Trim();
            issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate = IssueWorkOrder_Data["P19"].ToString().Trim();
            issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate = IssueWorkOrder_Data["P20"].ToString().Trim();
            issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate = IssueWorkOrder_Data["P21"].ToString().Trim();
            issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate = IssueWorkOrder_Data["P23"].ToString().Trim();
            issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate = IssueWorkOrder_Data["P24"].ToString().Trim();
            issueWorkOrderModel.str_txt_IW_SupplierMarkup_supplierMarkupRate = IssueWorkOrder_Data["P22"].ToString().Trim();
            issueWorkOrderModel.str_txt_MspFee_mspFeeMarkup = IssueWorkOrder_Data["P25"].ToString().Trim();
            issueWorkOrderModel.str_txt_MspFee_mspRegBillRate = IssueWorkOrder_Data["P26"].ToString().Trim();
            issueWorkOrderModel.str_txt_MSPRate_mspRegBillRate = IssueWorkOrder_Data["P26"].ToString().Trim();
            issueWorkOrderModel.str_txt_MspOtFee_mspOTBillRate = IssueWorkOrder_Data["P27"].ToString().Trim();
            issueWorkOrderModel.str_txt_MSPOTRate_mspOTBillRate = IssueWorkOrder_Data["P27"].ToString().Trim();
            issueWorkOrderModel.str_Txt_PoNumber_purchaseOrderNumber = IssueWorkOrder_Data["P29"].ToString().Trim();
            issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE = IssueWorkOrder_Data["P34"].ToString().Trim();
            issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE = IssueWorkOrder_Data["P35"].ToString().Trim();
            issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE = IssueWorkOrder_Data["P36"].ToString().Trim();
            issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue = IssueWorkOrder_Data["P37"].ToString().Trim();
            issueWorkOrderModel.str_txt_TotalContractValue_totalContractValue = IssueWorkOrder_Data["P37"].ToString().Trim();
            issueWorkOrderModel.str_Typeahead_ChargeCostCenterNumber_chargeCostCenterId = IssueWorkOrder_Data["P30"].ToString().Trim();
            issueWorkOrderModel.str_Typeahead_BusinessUnit_chargeCostCenterId = IssueWorkOrder_Data["P30"].ToString().Trim();
            issueWorkOrderModel.str_Typeahead_ChargeProjectWBSElement_chargeProjectId = IssueWorkOrder_Data["P31"].ToString().Trim();
            issueWorkOrderModel.str_Typeahead_ProjectCodeCFR_chargeProjectId = IssueWorkOrder_Data["P31"].ToString().Trim();
            issueWorkOrderModel.str_select_GLNumber_chargeGLId = IssueWorkOrder_Data["P32"].ToString().Trim();
            issueWorkOrderModel.str_select_ObjectAccount_chargeGLId = IssueWorkOrder_Data["P32"].ToString().Trim();
            issueWorkOrderModel.str_select_CompanyCode_chargedeptNumber = IssueWorkOrder_Data["P33"].ToString().Trim();
            issueWorkOrderModel.str_Typeahead_ChargeNumber_txtCharge = IssueWorkOrder_Data["P41"].ToString().Trim();
            issueWorkOrderModel.str_select_ChargeNumbersCompanyCode_deptNumber = IssueWorkOrder_Data["P33"].ToString().Trim();
            issueWorkOrderModel.str_select_CostCenter_CostCenterId = IssueWorkOrder_Data["P30"].ToString().Trim();
            issueWorkOrderModel.str_select_WBS_ProjectId = IssueWorkOrder_Data["P31"].ToString().Trim();
            issueWorkOrderModel.str_select_ChargeNumberType_ChargeNumberTypes = IssueWorkOrder_Data["P42"].ToString().Trim();
            issueWorkOrderModel.str_Date_DesiredStartDate_preferredStartDate = IssueWorkOrder_Data["P16"].ToString().Trim();

            issueWorkOrderModel.str_select_AccountCodingsAccountUnit_deptNumber = IssueWorkOrder_Data["P44"].ToString().Trim();
            issueWorkOrderModel.str_select_AccountCodingsCompany_siteLocationID = IssueWorkOrder_Data["P45"].ToString().Trim();
            issueWorkOrderModel.str_select_AccountCodingsProject_ProjectId = IssueWorkOrder_Data["P46"].ToString().Trim();
            issueWorkOrderModel.str_select_AccountCodingsActivity_ProfitCenterId = IssueWorkOrder_Data["P47"].ToString().Trim();
            issueWorkOrderModel.str_Typeahead_ChargeNumberProjectName_ChargeprogramId = IssueWorkOrder_Data["P41"].ToString().Trim();
            issueWorkOrderModel.str_Typeahead_ChargeNumberProjectNumber_ChargeCostCenterId = IssueWorkOrder_Data["P42"].ToString().Trim();
            issueWorkOrderModel.str_Typeahead_ChargeNumberPOID_ChargeProjectId = IssueWorkOrder_Data["P43"].ToString().Trim();
            issueWorkOrderModel.str_txt_EstimatedLaborandExpCost_totalContractValue = IssueWorkOrder_Data["P37"].ToString().Trim();
            issueWorkOrderModel.str_Click_TimecardApproversDelete_deleteTimecardApproverbtn = IssueWorkOrder_Data["P11"].ToString().Trim();
            issueWorkOrderModel.str_txt_SocialSecurityNumber_candidateSSN = IssueWorkOrder_Data["P48"].ToString().Trim();
            issueWorkOrderModel.str_Date_DateofBirth_DOB = IssueWorkOrder_Data["P49"].ToString().Trim();
            issueWorkOrderModel.str_select_Gender_Gender = IssueWorkOrder_Data["P50"].ToString().Trim();
            issueWorkOrderModel.str_txt_Last4digitsofssn_STID1 = IssueWorkOrder_Data["P51"].ToString().Trim();
            issueWorkOrderModel.str_select_Month_STID2 = IssueWorkOrder_Data["P52"].ToString().Trim();
            issueWorkOrderModel.str_select_Date_STID3 = IssueWorkOrder_Data["P53"].ToString().Trim();
            issueWorkOrderModel.str_Date_PrefferedStartDate_preferredStartDate = IssueWorkOrder_Data["P16"].ToString().Trim();
            issueWorkOrderModel.str_txt_ChargeNumberPA_txtChargePA = IssueWorkOrder_Data["P54"].ToString().Trim();
            issueWorkOrderModel.str_select_ChargeNumberPAA_chargeCostCenterId = IssueWorkOrder_Data["P55"].ToString().Trim();
            issueWorkOrderModel.str_Typeahead_ChargeNumberLegalEntity_ChargeorganizationID = IssueWorkOrder_Data["P56"].ToString().Trim();
            issueWorkOrderModel.str_Typeahead_ChargeNumberBusinessArea_ChargeProjectId = IssueWorkOrder_Data["P57"].ToString().Trim();
            issueWorkOrderModel.str_Typeahead_ChargeNumbernaturalAccount_ChargeGLId = IssueWorkOrder_Data["P58"].ToString().Trim();
            issueWorkOrderModel.str_Typeahead_ChargeNumberLocalAnalysis_ChargesiteLocationID = IssueWorkOrder_Data["P59"].ToString().Trim();
            issueWorkOrderModel.str_Typeahead_ChargeNumberCostCenter_ChargeCostCenterId = IssueWorkOrder_Data["P60"].ToString().Trim();
            issueWorkOrderModel.str_Typeahead_ChargeNumberInterCompany_ChargedeptNumber = IssueWorkOrder_Data["P61"].ToString().Trim();
            issueWorkOrderModel.str_Date_EndDate_endDate = IssueWorkOrder_Data["P17"].ToString().Trim();
            issueWorkOrderModel.str_Typeahead_PONumber_purchaseOrderNumber = IssueWorkOrder_Data["P29"].ToString().Trim();
            issueWorkOrderModel.str_Select_BusinessUnit_ChargeProjectId = IssueWorkOrder_Data["P57"].ToString().Trim();
            issueWorkOrderModel.str_Select_CORE_ChargeProjectId = IssueWorkOrder_Data["P57"].ToString().Trim();
            issueWorkOrderModel.str_Select_Reqtype_ChargeorganizationID = IssueWorkOrder_Data["P56"].ToString().Trim();
            issueWorkOrderModel.str_typeahead_CostCenter_ChargeCostCenterId = IssueWorkOrder_Data["P60"].ToString().Trim();
            issueWorkOrderModel.str_Typeahead_AccountCode_ChargeCostCenterId = IssueWorkOrder_Data["P60"].ToString().Trim();
            issueWorkOrderModel.str_Typeahead_Department_ChargeorganizationID = IssueWorkOrder_Data["P56"].ToString().Trim();
            issueWorkOrderModel.str_Select_Businessunit_ChargeorganizationID = IssueWorkOrder_Data["P56"].ToString().Trim();
            issueWorkOrderModel.str_Select_AccountCode_ChargeCostCenterId = IssueWorkOrder_Data["P60"].ToString().Trim();
            issueWorkOrderModel.str_typeahead_BusinessArea_ChargeCostCenterId = IssueWorkOrder_Data["P60"].ToString().Trim();
            issueWorkOrderModel.str_Txt_WorkDayID_customerTrackingNumber = IssueWorkOrder_Data["P62"].ToString().Trim();
            issueWorkOrderModel.str_Typeahead_ChargeCompanyNumber_deptNumber = IssueWorkOrder_Data["P33"].ToString().Trim();
            issueWorkOrderModel.str_Typeahead_APCostCenter_CostCenterId = IssueWorkOrder_Data["P30"].ToString().Trim();
            issueWorkOrderModel.str_Select_ChargeGLAccount_ChargeGLId = IssueWorkOrder_Data["P58"].ToString().Trim();
            issueWorkOrderModel.str_Select_HyperionCodeGLUnit_ChargeGLId = IssueWorkOrder_Data["P58"].ToString().Trim();
            issueWorkOrderModel.str_Select_ExpenseAccount_ChargeGLId = IssueWorkOrder_Data["P58"].ToString().Trim();
            issueWorkOrderModel.str_Txt_CalculatedMarkup_calculatedMarkup = IssueWorkOrder_Data["P63"].ToString().Trim();
            issueWorkOrderModel.str_Typeahead_APDepartment_ChargedeptName = IssueWorkOrder_Data["P64"].ToString().Trim();
           // issueWorkOrderModel.str_Select_BusinessUnit_ChargeorganizationID = IssueWorkOrder_Data["P56"].ToString().Trim();
            issueWorkOrderModel.str_Select_HypersionCodeGLUnit_ChargeGLId = IssueWorkOrder_Data["P58"].ToString().Trim();
            issueWorkOrderModel.str_Select_APDepartment_ChargedeptName = IssueWorkOrder_Data["P64"].ToString().Trim();

            //Added by manjusha
            issueWorkOrderModel.str_Txt_Billrate_Supplierbillrate = IssueWorkOrder_Data["P82"].ToString().Trim();
            issueWorkOrderModel.str_Txt_numberofhours_offertoHire = IssueWorkOrder_Data["P83"].ToString().Trim();
            issueWorkOrderModel.str_Txt_numberofResources_offertoHire = IssueWorkOrder_Data["P78"].ToString().Trim();
            issueWorkOrderModel.str_Txt_Estimatedcontract_offertoHire = IssueWorkOrder_Data["P84"].ToString().Trim();
            issueWorkOrderModel.str_Typeahead_Company_ChargedeptNumber = IssueWorkOrder_Data["P33"].ToString().Trim(); 
            issueWorkOrderModel.str_Typeahead_PoNumber_purchaseOrderNumber = IssueWorkOrder_Data["P29"].ToString().Trim(); 
            issueWorkOrderModel.str_txt_ActiveDirectoryID_customerTrackingNumber = IssueWorkOrder_Data["P62"].ToString().Trim();

            issueWorkOrderModel.str_Typeahead_GL_ChargeGLId = IssueWorkOrder_Data["P32"].ToString().Trim();
            issueWorkOrderModel.str_Typeahead_WBSElement_ChargeProjectId = IssueWorkOrder_Data["P31"].ToString().Trim();


            return issueWorkOrderModel;
        }

        public AcceptWorkOrderModel GetAcceptWorkOrderData(DataRow AcceptWorkOrder_Data)
        {
            AcceptWorkOrderModel acceptWorkOrderModel = new AcceptWorkOrderModel();
            acceptWorkOrderModel.strClientName = AcceptWorkOrder_Data["P3"].ToString().Trim();
            acceptWorkOrderModel.strMainMenuLink = AcceptWorkOrder_Data["P4"].ToString().Trim();
            acceptWorkOrderModel.strSubMenuLink = AcceptWorkOrder_Data["P5"].ToString().Trim();
            acceptWorkOrderModel.str_Link_ReqNumber = AcceptWorkOrder_Data["P6"].ToString().Trim();
            acceptWorkOrderModel.str_Link_CandidatesWithOffers = AcceptWorkOrder_Data["P7"].ToString().Trim();
            acceptWorkOrderModel.str_CandidateName = AcceptWorkOrder_Data["P8"].ToString().Trim();
            acceptWorkOrderModel.str_Link_AcceptWorkOrder_Data = AcceptWorkOrder_Data["P9"].ToString().Trim();
            acceptWorkOrderModel.str_Txt_homephone = AcceptWorkOrder_Data["P10"].ToString().Trim();
            acceptWorkOrderModel.str_Txt_email = AcceptWorkOrder_Data["P11"].ToString().Trim();
            acceptWorkOrderModel.str_Txt_address1 = AcceptWorkOrder_Data["P12"].ToString().Trim();
            acceptWorkOrderModel.str_Txt_address2 = AcceptWorkOrder_Data["P13"].ToString().Trim();
            acceptWorkOrderModel.str_Txt_city = AcceptWorkOrder_Data["P14"].ToString().Trim();
            acceptWorkOrderModel.str_Txt_zip = AcceptWorkOrder_Data["P15"].ToString().Trim();
            acceptWorkOrderModel.str_Select_state = AcceptWorkOrder_Data["P16"].ToString().Trim();
            acceptWorkOrderModel.str_Txt_emergencyContact1Name = AcceptWorkOrder_Data["P17"].ToString().Trim();
            acceptWorkOrderModel.str_Txt_emergencyContact1Phone = AcceptWorkOrder_Data["P18"].ToString().Trim();
            acceptWorkOrderModel.str_Txt_emergencyContact2Name = AcceptWorkOrder_Data["P19"].ToString().Trim();
            acceptWorkOrderModel.str_Txt_emergencyContact2Phone = AcceptWorkOrder_Data["P20"].ToString().Trim();
            acceptWorkOrderModel.str_Select_SCountry = AcceptWorkOrder_Data["P21"].ToString().Trim();
            acceptWorkOrderModel.str_Select_Sstate = AcceptWorkOrder_Data["P22"].ToString().Trim();
            acceptWorkOrderModel.str_Select_SCounty = AcceptWorkOrder_Data["P23"].ToString().Trim();
            acceptWorkOrderModel.str_Btn_Accept_Submit = AcceptWorkOrder_Data["P38"].ToString().Trim();
            acceptWorkOrderModel.str_Btn_AcceptWorkOrder_Data_Submit_Confirm = AcceptWorkOrder_Data["P39"].ToString().Trim();
            acceptWorkOrderModel.str_Btn_AcceptWorkOrder_Data_Submit_Confirm_Ok = AcceptWorkOrder_Data["P40"].ToString().Trim();
            acceptWorkOrderModel.str_Link_RejectWorkOrder = AcceptWorkOrder_Data["P41"].ToString().Trim();
            acceptWorkOrderModel.str_Txt_RejectWorkOrderComment = AcceptWorkOrder_Data["P42"].ToString().Trim();
            acceptWorkOrderModel.str_Button_Reject = AcceptWorkOrder_Data["P43"].ToString().Trim();
            acceptWorkOrderModel.str_Radiobtn_DoesthisresourcehaveaSocialSecurityNumber_isSSNAvailable = AcceptWorkOrder_Data["P24"].ToString().Trim();
            acceptWorkOrderModel.str_txt_SocailSecurityNumber_candidateSSN = AcceptWorkOrder_Data["P25"].ToString().Trim();
            acceptWorkOrderModel.str_txt_ConfirmSocailSecurityNumber_candidateSSNConfirm = AcceptWorkOrder_Data["P26"].ToString().Trim();
            acceptWorkOrderModel.str_Date_DateofBirth_DOB = AcceptWorkOrder_Data["P44"].ToString().Trim();
            acceptWorkOrderModel.str_Select_Race_nativeAmericanID = AcceptWorkOrder_Data["P45"].ToString().Trim();
            acceptWorkOrderModel.str_Select_Gender_Gender = AcceptWorkOrder_Data["P46"].ToString().Trim();
            acceptWorkOrderModel.str_Txt_PhoneNumber_homephone = AcceptWorkOrder_Data["P10"].ToString().Trim();
            acceptWorkOrderModel.str_Txt_Email_email = AcceptWorkOrder_Data["P11"].ToString().Trim();
            acceptWorkOrderModel.str_Txt_AddressLine1_address1 = AcceptWorkOrder_Data["P12"].ToString().Trim();
            acceptWorkOrderModel.str_Txt__AddressLine2_address2 = AcceptWorkOrder_Data["P13"].ToString().Trim();
            acceptWorkOrderModel.str_Txt_City_city = AcceptWorkOrder_Data["P14"].ToString().Trim();
            acceptWorkOrderModel.str_Txt_Zip_zip = AcceptWorkOrder_Data["P15"].ToString().Trim();
            acceptWorkOrderModel.str_Select_State_state = AcceptWorkOrder_Data["P16"].ToString().Trim();
            acceptWorkOrderModel.str_Txt_EmergencyContactName_emergencyContact1Name = AcceptWorkOrder_Data["P17"].ToString().Trim();
            acceptWorkOrderModel.str_Txt_EmergencyContactPhone_emergencyContact1Phone = AcceptWorkOrder_Data["P18"].ToString().Trim();
            acceptWorkOrderModel.str_Txt_2ndEmergencyContactName_emergencyContact2Name = AcceptWorkOrder_Data["P19"].ToString().Trim();
            acceptWorkOrderModel.str_Txt_2ndEmergencyContactPhone_emergencyContact2Phone = AcceptWorkOrder_Data["P20"].ToString().Trim();
            acceptWorkOrderModel.str_Select_Country_SCountry = AcceptWorkOrder_Data["P21"].ToString().Trim();
            acceptWorkOrderModel.str_Select_State_SState = AcceptWorkOrder_Data["P22"].ToString().Trim();
            acceptWorkOrderModel.str_Select__County_SCounty = AcceptWorkOrder_Data["P23"].ToString().Trim();
            return acceptWorkOrderModel;
        }

        public ConfirmCWModel GetConfirmCWData(DataRow ConfirmCW_Data)
        {
            ConfirmCWModel confirmCWModel = new ConfirmCWModel();
            confirmCWModel.strClientName = ConfirmCW_Data["P3"].ToString().Trim();
            confirmCWModel.strMainMenuLink = ConfirmCW_Data["P4"].ToString().Trim();
            confirmCWModel.strSubMenuLink = ConfirmCW_Data["P5"].ToString().Trim();
            confirmCWModel.str_Link_ReqNumber = ConfirmCW_Data["P6"].ToString().Trim();
            confirmCWModel.str_Link_ActionList_ViewCandidates = ConfirmCW_Data["P7"].ToString().Trim();
            confirmCWModel.str_CandidateName = ConfirmCW_Data["P8"].ToString().Trim();
            confirmCWModel.str_Link_ActionList_ConfirmCW = ConfirmCW_Data["P9"].ToString().Trim();
            confirmCWModel.str_Txt_LastName = ConfirmCW_Data["P10"].ToString().Trim();
            confirmCWModel.str_Txt_FirstName = ConfirmCW_Data["P11"].ToString().Trim();
            confirmCWModel.str_Txt_MiddleName = ConfirmCW_Data["P12"].ToString().Trim();
            confirmCWModel.str_Select_SuffixName = ConfirmCW_Data["P13"].ToString().Trim();
            confirmCWModel.str_Radio_CWUser = ConfirmCW_Data["P14"].ToString().Trim();
            confirmCWModel.str_Txt_candidateEmail = ConfirmCW_Data["P15"].ToString().Trim();
            confirmCWModel.str_Txt_SmartTrackIdentifier = ConfirmCW_Data["P14"].ToString().Trim();
            confirmCWModel.str_Txt_jobTitleName = ConfirmCW_Data["P18"].ToString().Trim();
            confirmCWModel.str_Select_programName = ConfirmCW_Data["P16"].ToString().Trim();

            confirmCWModel.str_TypeHead_deptNumber = ConfirmCW_Data["P21"].ToString().Trim();
            confirmCWModel.str_Txt_isCWuserEmail = ConfirmCW_Data["P17"].ToString().Trim();
            confirmCWModel.str_TypeHead_deptName = ConfirmCW_Data["P18"].ToString().Trim();
            confirmCWModel.str_Txt_matrixNumber = ConfirmCW_Data["P19"].ToString().Trim();
            confirmCWModel.str_Select_serviceType = ConfirmCW_Data["P20"].ToString().Trim();

            confirmCWModel.str_selectOrgId = ConfirmCW_Data["P22"].ToString().Trim();
            confirmCWModel.str_Select_serviceMethodID = ConfirmCW_Data["P24"].ToString().Trim();


            confirmCWModel.str_Txt_JobCode = ConfirmCW_Data["P24"].ToString().Trim();
            confirmCWModel.str_select_CostCenterId = ConfirmCW_Data["P25"].ToString().Trim();

            confirmCWModel.str_Select_siteLocationID = ConfirmCW_Data["P25"].ToString().Trim();
            confirmCWModel.str_Select_GLId = ConfirmCW_Data["P26"].ToString().Trim();



            confirmCWModel.str_Select_MaterialGroup = ConfirmCW_Data["P27"].ToString().Trim();
            confirmCWModel.str_selectworkLocationID = ConfirmCW_Data["P28"].ToString().Trim();
            confirmCWModel.str_Txt_hiringManagerName = ConfirmCW_Data["P29"].ToString().Trim();
            confirmCWModel.str_Txt_alternateHiringManagerName = ConfirmCW_Data["P30"].ToString().Trim();

            confirmCWModel.str_Select_reqType = ConfirmCW_Data["P31"].ToString().Trim();
            confirmCWModel.str_select_Employmenttype = ConfirmCW_Data["P32"].ToString().Trim();
            confirmCWModel.str_Txt_cwKeyWords = ConfirmCW_Data["P33"].ToString().Trim();

            confirmCWModel.str_Txt_SSN = ConfirmCW_Data["P34"].ToString().Trim();
            confirmCWModel.str_Select_Month = ConfirmCW_Data["P35"].ToString().Trim();
            confirmCWModel.str_Select_Date = ConfirmCW_Data["P36"].ToString().Trim();
            confirmCWModel.str_Select_Year = ConfirmCW_Data["P37"].ToString().Trim();




            confirmCWModel.str_Select_supplierContact = ConfirmCW_Data["P38"].ToString().Trim();
            confirmCWModel.str_Select_invoicePaymentContact = ConfirmCW_Data["P39"].ToString().Trim();
            confirmCWModel.str_AddListTxt_txtTimecardApprover = ConfirmCW_Data["P40"].ToString().Trim();
            confirmCWModel.str_DeleteListTxt_txtTimecardApprover = ConfirmCW_Data["P41"].ToString().Trim();
            confirmCWModel.str_AddListTxt_ChargeNumbers = ConfirmCW_Data["P42"].ToString().Trim();
            confirmCWModel.str_DeleteListTxt_ChargeNumbers = ConfirmCW_Data["P43"].ToString().Trim();
            confirmCWModel.str_Select_rateTypeID = ConfirmCW_Data["P44"].ToString().Trim();
            confirmCWModel.str_RadioBtn_TimeSheet_FromSTTimeSheet = ConfirmCW_Data["P45"].ToString().Trim();

            confirmCWModel.str_Select_AccountType = ConfirmCW_Data["P48"].ToString().Trim();
            confirmCWModel.str_Txt_PrefStartdate = ConfirmCW_Data["P49"].ToString().Trim();
            confirmCWModel.str_Txt_enddate = ConfirmCW_Data["P50"].ToString().Trim();


            confirmCWModel.str_RadioBtn_WarehouseWorker_directIndirect = ConfirmCW_Data["P51"].ToString().Trim();

            confirmCWModel.str_Txt_supplierRegPayRate = ConfirmCW_Data["P56"].ToString().Trim(); //Candidate Pay Rate
            confirmCWModel.str_Txt_supplierOTPayRate = ConfirmCW_Data["P57"].ToString().Trim(); //Candidate OT Pay Rate
            confirmCWModel.str_Txt_supplierRegBillRate = ConfirmCW_Data["P60"].ToString().Trim(); //Supplier Bill Rate
            confirmCWModel.str_Txt_supplierOTBillRate = ConfirmCW_Data["P61"].ToString().Trim(); //Supplier OT Bill Rate
            confirmCWModel.str_Txt_FinalBillRate = ConfirmCW_Data["P62"].ToString().Trim();//Final Bill Rate    
            confirmCWModel.str_Txt_finalOTBillRate = ConfirmCW_Data["P63"].ToString().Trim();//Final OT Bill Rate
            confirmCWModel.str_Txt_dtPayRate = ConfirmCW_Data["P64"].ToString().Trim();
            confirmCWModel.str_Txt_finalDTBillRate = ConfirmCW_Data["P65"].ToString().Trim();
            confirmCWModel.str_Txt_mspDTBillRate = ConfirmCW_Data["P66"].ToString().Trim();
            confirmCWModel.str_Txt_SupplierDTBillRate = ConfirmCW_Data["P67"].ToString().Trim();

            confirmCWModel.str_Txt_mspFeeMarkup = ConfirmCW_Data["P68"].ToString().Trim();
            confirmCWModel.str_Txt_mspFee = ConfirmCW_Data["P69"].ToString().Trim();
            confirmCWModel.str_Txt_mspOTFee = ConfirmCW_Data["P70"].ToString().Trim();
            confirmCWModel.str_Txt_weeklyRegHoursNTE = ConfirmCW_Data["P71"].ToString().Trim();
            confirmCWModel.str_Txt_weeklyOTHoursNTE = ConfirmCW_Data["P72"].ToString().Trim();
            confirmCWModel.str_Txt_yearlyRegHoursNTE = ConfirmCW_Data["P73"].ToString().Trim();
            confirmCWModel.str_Txt_totalContractValue = ConfirmCW_Data["P74"].ToString().Trim();

            confirmCWModel.str_RadioButton_RetireeRadio = ConfirmCW_Data["P75"].ToString().Trim();
            confirmCWModel.str_Txt_RetiredDate = ConfirmCW_Data["P76"].ToString().Trim();
            confirmCWModel.str_Txt_RetiredJobTitle = ConfirmCW_Data["P77"].ToString().Trim();

            confirmCWModel.str_Txt_payRateSavings = ConfirmCW_Data["P78"].ToString().Trim();
            confirmCWModel.str_Txt_supplierBillRateSavings = ConfirmCW_Data["P79"].ToString().Trim();
            confirmCWModel.str_Select_savingsTypeID = ConfirmCW_Data["P80"].ToString().Trim();

            confirmCWModel.str_Txt_oneTimeSavings = ConfirmCW_Data["P81"].ToString().Trim();
            confirmCWModel.str_Txt_savingComment = ConfirmCW_Data["P82"].ToString().Trim();
            confirmCWModel.str_Select_paycodeId = ConfirmCW_Data["P83"].ToString().Trim();
            confirmCWModel.str_Txt_payCodePayRate = ConfirmCW_Data["P84"].ToString().Trim();
            confirmCWModel.str_Txt_payCodeSupplierBillrate = ConfirmCW_Data["P85"].ToString().Trim();


            confirmCWModel.str_Select_SCountry = ConfirmCW_Data["P87"].ToString().Trim();
            confirmCWModel.str_Select_SState = ConfirmCW_Data["P88"].ToString().Trim();
            confirmCWModel.str_Select_SCounty = ConfirmCW_Data["P89"].ToString().Trim();



            confirmCWModel.str_Btn_ConfirmCW_Submit = ConfirmCW_Data["P110"].ToString().Trim();
            confirmCWModel.str_Btn_ConfirmCW_Submit_Confirm = ConfirmCW_Data["P111"].ToString().Trim();
            confirmCWModel.str_Btn_ConfirmCW_Submit_Confirm_Ok = ConfirmCW_Data["P112"].ToString().Trim();


            confirmCWModel.str_AddListTxt_GLNumbers = ConfirmCW_Data["P35"].ToString().Trim();
            confirmCWModel.str_DeleteListTxt_GLNumbers = ConfirmCW_Data["P36"].ToString().Trim();
            confirmCWModel.str_Txt_purchaseOrderNumber = ConfirmCW_Data["P37"].ToString().Trim();

            confirmCWModel.str_Txt_customerTrackingNumber = ConfirmCW_Data["P38"].ToString().Trim(); //VIP Number
            confirmCWModel.str_Txt_RadioBtn_ChargingMethod_exemptFlag = ConfirmCW_Data["P39"].ToString().Trim();
            confirmCWModel.str_Txt_customerTrackingNumber2 = ConfirmCW_Data["P40"].ToString().Trim();//NEAT ID
            confirmCWModel.str_Txt_customerTrackingNumber3 = ConfirmCW_Data["P41"].ToString().Trim();//LMP ID
            confirmCWModel.str_Txt_badgeNumber = ConfirmCW_Data["P42"].ToString().Trim();
            confirmCWModel.str_Txt_LineItem = ConfirmCW_Data["P42"].ToString().Trim();
            confirmCWModel.str_Select_ddlaborClassCode = ConfirmCW_Data["P43"].ToString().Trim();

            confirmCWModel.str_Select_dayID = ConfirmCW_Data["P45"].ToString().Trim();
            confirmCWModel.str_Select_workweek = ConfirmCW_Data["P46"].ToString().Trim();
            confirmCWModel.str_Select_shiftID = ConfirmCW_Data["P47"].ToString().Trim();

            confirmCWModel.str_Select_EngagementType = ConfirmCW_Data["P14"].ToString().Trim();
            //  DateTime dt = DateTime.ParseExact(str_Txt_PrefStartdate, "MM/dd/yyyy", null);
            //   str_Txt_PrefStartdate = dt.ToString("MM/dd/yyyy");



            confirmCWModel.str_RadioBtn_Rehire = ConfirmCW_Data["P50"].ToString().Trim();
            confirmCWModel.str_Txt_regPayRate = ConfirmCW_Data["P51"].ToString().Trim();//Proposed Pay Rate
            confirmCWModel.str_Txt_OTPayRate = ConfirmCW_Data["P52"].ToString().Trim();//Proposed OT Pay Rate
            confirmCWModel.str_Txt_regBillRate = ConfirmCW_Data["P53"].ToString().Trim(); //Proposed Bill Rate
            confirmCWModel.str_Txt_OTBillRate = ConfirmCW_Data["P54"].ToString().Trim(); //Proposed OT Bill Rate


            confirmCWModel.str_Txt_supplierMarkupRate = ConfirmCW_Data["P57"].ToString().Trim(); //Supplier Markup%


            confirmCWModel.str_Txt_mspRegBillRate = ConfirmCW_Data["P60"].ToString().Trim();//MSP Fee, MSP Rate 
            confirmCWModel.str_Txt_mspOTBillRate = ConfirmCW_Data["P61"].ToString().Trim(); //MSP OT Fee, MSP OT Rate 








            confirmCWModel.str_Select_jobCodeID = ConfirmCW_Data["P74"].ToString().Trim();

            confirmCWModel.str_Select_SecurityClearance = ConfirmCW_Data["P75"].ToString().Trim();
            confirmCWModel.str_Select_ClearanceStatus = ConfirmCW_Data["P76"].ToString().Trim();



            confirmCWModel.str_Txt_vmsRegBillRate = ConfirmCW_Data["P81"].ToString().Trim();
            confirmCWModel.str_Txt_vmsOTBillRate = ConfirmCW_Data["P82"].ToString().Trim();

            confirmCWModel.str_Radio_Btn_Indp_Cons = ConfirmCW_Data["P86"].ToString().Trim();
            confirmCWModel.str_Select_ProjectId = ConfirmCW_Data["P87"].ToString().Trim();//EPPIC Project  KeyBank  
            confirmCWModel.str_Select_ProfitCenterId = ConfirmCW_Data["P88"].ToString().Trim();//EPPIC Region  *  KeyBank   
            confirmCWModel.str_Select_spendLevelId = ConfirmCW_Data["P89"].ToString().Trim();//EPPIC Role  *  KeyBank 

            confirmCWModel.str_Radio_Referral = ConfirmCW_Data["P93"].ToString().Trim();
            confirmCWModel.str_select_Businesunit = ConfirmCW_Data["P94"].ToString().Trim();

            confirmCWModel.str_Radio_TImesheet = ConfirmCW_Data["P96"].ToString().Trim();
            confirmCWModel.str_Txt_STID = ConfirmCW_Data["P89"].ToString().Trim(); //SSN

            //Cp Chem 
            confirmCWModel.str_txt_LastName_lastName = ConfirmCW_Data["P10"].ToString().Trim();
            confirmCWModel.str_txt_LegalLastName_lastName = ConfirmCW_Data["P10"].ToString().Trim();
            confirmCWModel.str_txt_FirstName_firstName = ConfirmCW_Data["P11"].ToString().Trim();
            confirmCWModel.str_txt_LegalFirstName_firstName = ConfirmCW_Data["P11"].ToString().Trim();
            confirmCWModel.str_txt_MiddleName_middleName = ConfirmCW_Data["P12"].ToString().Trim();
            confirmCWModel.str_txt_Suffix_nameSuffix = ConfirmCW_Data["P13"].ToString().Trim();
            confirmCWModel.str_select_Suffix_nameSuffix = ConfirmCW_Data["P13"].ToString().Trim();
            confirmCWModel.str_btn_CWUseryes_isCWuser = ConfirmCW_Data["P14"].ToString().Trim();
            confirmCWModel.str_txt_CandidateEmail_candidateEmail = ConfirmCW_Data["P15"].ToString().Trim();
            confirmCWModel.str_txt_WorkingTitle_jobTitleName = ConfirmCW_Data["P18"].ToString().Trim();
            confirmCWModel.str_select_TypeofService_serviceType = ConfirmCW_Data["P20"].ToString().Trim();
            confirmCWModel.str_select_FunctionType_serviceType = ConfirmCW_Data["P20"].ToString().Trim();
            confirmCWModel.str_select_JobClassificationTos_serviceType = ConfirmCW_Data["P20"].ToString().Trim();
            confirmCWModel.str_Select_JobCategory_serviceType = ConfirmCW_Data["P20"].ToString().Trim();
            confirmCWModel.str_typeahead_POCostCenter_CostCenterId = ConfirmCW_Data["P25"].ToString().Trim();
            confirmCWModel.str_typeahead_APCostCenter_CostCenterId = ConfirmCW_Data["P25"].ToString().Trim();
            confirmCWModel.str_select_CostCenter_CostCenterId = ConfirmCW_Data["P25"].ToString().Trim();
            confirmCWModel.str_Typeahead_CostCenter_CostCenterId = ConfirmCW_Data["P25"].ToString().Trim();
            confirmCWModel.str_Typeahead_BusinessUnit_CostCenterId = ConfirmCW_Data["P25"].ToString().Trim();
            confirmCWModel.str_select_GLAccount_GLId = ConfirmCW_Data["P26"].ToString().Trim();
            confirmCWModel.str_Typeahead_GeneralLedgerAccount_GLId = ConfirmCW_Data["P26"].ToString().Trim();
            confirmCWModel.str_select_GeneralLedgerAccount_GLId = ConfirmCW_Data["P26"].ToString().Trim();
            confirmCWModel.str_select_ObjectAccount_GLId = ConfirmCW_Data["P26"].ToString().Trim();
            confirmCWModel.str_select_OrganizationName_organization = ConfirmCW_Data["P23"].ToString().Trim();
            confirmCWModel.str_select_BusinessUnit_organization = ConfirmCW_Data["P23"].ToString().Trim();
            confirmCWModel.str_select_Organization_organization = ConfirmCW_Data["P23"].ToString().Trim();
            confirmCWModel.str_select_AccountCode_organization = ConfirmCW_Data["P23"].ToString().Trim();
            confirmCWModel.str_Typeahead_WorkLocation_workLocationID = ConfirmCW_Data["P28"].ToString().Trim();
            confirmCWModel.str_Select_WorkLocation_workLocationID = ConfirmCW_Data["P28"].ToString().Trim();
            confirmCWModel.str_select_PersonnelArea_workLocationID = ConfirmCW_Data["P28"].ToString().Trim();
            confirmCWModel.str_Typeahead_HiringManager_hiringManagerName = ConfirmCW_Data["P29"].ToString().Trim();
            confirmCWModel.str_Typeahead_EngagingManager_hiringManagerName = ConfirmCW_Data["P29"].ToString().Trim();
            confirmCWModel.str_Typeahead_AltHiringManager_alternateHiringManagerName = ConfirmCW_Data["P30"].ToString().Trim();
            confirmCWModel.str_Typeahead_Supervisor_alternateHiringManagerName = ConfirmCW_Data["P30"].ToString().Trim();
            confirmCWModel.str_Typeahead_FinancialPartner_alternateHiringManagerName = ConfirmCW_Data["P30"].ToString().Trim();
            confirmCWModel.str_select_ReqType_reqType = ConfirmCW_Data["P31"].ToString().Trim();
            confirmCWModel.str_select_EmployementType_employmentTypeID = ConfirmCW_Data["P32"].ToString().Trim();
            confirmCWModel.str_txt_Keywords_cwKeyWords = ConfirmCW_Data["P33"].ToString().Trim();
            confirmCWModel.str_txt_Last4digitsofssn_STID1 = ConfirmCW_Data["P34"].ToString().Trim();
            confirmCWModel.str_select_Month_STID2 = ConfirmCW_Data["P35"].ToString().Trim();
            confirmCWModel.str_select_Date_STID3 = ConfirmCW_Data["P36"].ToString().Trim();
            confirmCWModel.str_Typeahead_Supplier_supplierName = ConfirmCW_Data["P38"].ToString().Trim();
            confirmCWModel.str_select_SupplierContact_supplierContact = ConfirmCW_Data["P39"].ToString().Trim();
            confirmCWModel.str_select_InvoicePaymentContact_invoicePaymentContact = ConfirmCW_Data["P40"].ToString().Trim();
            confirmCWModel.str_btn_TimecardApproveradd_addTimecardApproverbtn = ConfirmCW_Data["P41"].ToString().Trim();
            confirmCWModel.str_btn_TimecardApproverdelete_deleteTimecardApproverbtn = ConfirmCW_Data["P42"].ToString().Trim();
            confirmCWModel.str_select_RateType_rateTypeID = ConfirmCW_Data["P94"].ToString().Trim();
            confirmCWModel.str_txt_PONumber_purchaseOrderNumber = ConfirmCW_Data["P95"].ToString().Trim();
            confirmCWModel.str_btn_Timesheet_FromSTTimeSheet = ConfirmCW_Data["P45"].ToString().Trim();
            confirmCWModel.str_select_TimesheetStartDateoftheWeek_dayID = ConfirmCW_Data["P46"].ToString().Trim();
            confirmCWModel.str_Date_GoLiveDate_cwGoLiveDate = ConfirmCW_Data["P47"].ToString().Trim();
            confirmCWModel.str_select_AccountType_AccountType = ConfirmCW_Data["P48"].ToString().Trim();
            confirmCWModel.str_select_PayGroup_AccountType = ConfirmCW_Data["P48"].ToString().Trim();
            confirmCWModel.str_Date_AnticipatedStartDate_preferredStartDate = ConfirmCW_Data["P49"].ToString().Trim();
            confirmCWModel.str_Date_PlannedEndDate_endDate = ConfirmCW_Data["P50"].ToString().Trim();
            confirmCWModel.str_Date_StartDate_preferredStartDate = ConfirmCW_Data["P50"].ToString().Trim();
            confirmCWModel.str_btn_IndependentConsultant_IndependentConsultant = ConfirmCW_Data["P51"].ToString().Trim();
            confirmCWModel.str_txt_ProposedPayRate_regPayRate = ConfirmCW_Data["P52"].ToString().Trim();
            confirmCWModel.str_txt_ProposedOtPayRate_OTPayRate = ConfirmCW_Data["P53"].ToString().Trim();
            confirmCWModel.str_txt_ProposedBillRate_regBillRate = ConfirmCW_Data["P54"].ToString().Trim();
            confirmCWModel.str_txt_ProposedOtBillRate_OTBillRate = ConfirmCW_Data["P55"].ToString().Trim();
            confirmCWModel.str_txt_CandidatePayRate_supplierRegPayRate = ConfirmCW_Data["P56"].ToString().Trim();
            confirmCWModel.str_txt_CandidateOtPayrate_supplierOTPayRate = ConfirmCW_Data["P57"].ToString().Trim();
            confirmCWModel.str_txt_SupplierMarkup_supplierMarkupRate = ConfirmCW_Data["P58"].ToString().Trim();
            confirmCWModel.str_txt_SupplierBillRate_supplierRegBillRate = ConfirmCW_Data["P60"].ToString().Trim();
            confirmCWModel.str_txt_SupplierOtBillRate_supplierOTBillRate = ConfirmCW_Data["P61"].ToString().Trim();
            confirmCWModel.str_txt_FinalBillRate_FinalBillRate = ConfirmCW_Data["P62"].ToString().Trim();
            confirmCWModel.str_txt_FinalOtBillRate_FinalOTBillRate = ConfirmCW_Data["P63"].ToString().Trim();
            confirmCWModel.str_txt_DTPayRate_dtPayRate = ConfirmCW_Data["P64"].ToString().Trim();
            confirmCWModel.str_txt_FinalDTBillRate_finalDTBillRate = ConfirmCW_Data["P65"].ToString().Trim();
            confirmCWModel.str_txt_MSPDTBillRate_mspDTBillRate = ConfirmCW_Data["P66"].ToString().Trim();
            confirmCWModel.str_txt_MSPDoubleTimeBillRate_mspDTBillRate = ConfirmCW_Data["P66"].ToString().Trim();
            confirmCWModel.str_txt_SupplierDtBillRate_SupplierDTBillRate = ConfirmCW_Data["P67"].ToString().Trim();
            confirmCWModel.str_txt_MSPFeeMarkup_mspFeeMarkup = ConfirmCW_Data["P68"].ToString().Trim();
            confirmCWModel.str_txt_MSPFee_mspRegBillRate = ConfirmCW_Data["P69"].ToString().Trim();
            confirmCWModel.str_txt_MSPRate_mspRegBillRate = ConfirmCW_Data["P69"].ToString().Trim();
            confirmCWModel.str_txt_MSPOtFee_mspOTBillRate = ConfirmCW_Data["P70"].ToString().Trim();
            confirmCWModel.str_txt_MSPOTBillRate_mspOTBillRate = ConfirmCW_Data["P70"].ToString().Trim();
            confirmCWModel.str_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE = ConfirmCW_Data["P71"].ToString().Trim();
            confirmCWModel.str_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE = ConfirmCW_Data["P72"].ToString().Trim();
            confirmCWModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE = ConfirmCW_Data["P73"].ToString().Trim();
            confirmCWModel.str_txt_TotalContractValue_totalContractValue = ConfirmCW_Data["P74"].ToString().Trim();
            confirmCWModel.str_btn_Retiree_isRetiree = ConfirmCW_Data["P75"].ToString().Trim();
            confirmCWModel.str_Date_RetiredDate_RetiredDate = ConfirmCW_Data["P76"].ToString().Trim();
            confirmCWModel.str_txt_JobTitle_RetiredJobTitle = ConfirmCW_Data["P77"].ToString().Trim();
            confirmCWModel.str_txt_PayRateSaving_payRateSavings = ConfirmCW_Data["P78"].ToString().Trim();
            confirmCWModel.str_txt_SupplierBillRateSavings_supplierBillRateSavings = ConfirmCW_Data["P79"].ToString().Trim();
            confirmCWModel.str_select_SavingsCategory_savingsTypeID = ConfirmCW_Data["P80"].ToString().Trim();
            confirmCWModel.str_txt_OneTimeSavings_oneTimeSavings = ConfirmCW_Data["P81"].ToString().Trim();
            confirmCWModel.str_txt_SavingsCommands_savingComment = ConfirmCW_Data["P82"].ToString().Trim();
            confirmCWModel.str_select_Paycode_paycodeId = ConfirmCW_Data["P83"].ToString().Trim();
            confirmCWModel.str_txt_payrate_payCodePayRate = ConfirmCW_Data["P84"].ToString().Trim();
            confirmCWModel.str_txt_SupplierBillRate_payCodeSupplierBillrate = ConfirmCW_Data["P85"].ToString().Trim();
            confirmCWModel.str_txt_FinalBillRate_payCodeFinalBillRate = ConfirmCW_Data["P86"].ToString().Trim();
            confirmCWModel.str_select_Country_SCountry = ConfirmCW_Data["P87"].ToString().Trim();
            confirmCWModel.str_select_State_SState = ConfirmCW_Data["P88"].ToString().Trim();
            confirmCWModel.str_select_County_SCounty = ConfirmCW_Data["P89"].ToString().Trim();
            confirmCWModel.str_btn_Union_directIndirect = ConfirmCW_Data["P91"].ToString().Trim();
            confirmCWModel.str_select_UnionName_ddlaborClassCode = ConfirmCW_Data["P92"].ToString().Trim();
            confirmCWModel.str_select_HeadcountApproved_ddlaborClassCode = ConfirmCW_Data["P92"].ToString().Trim();
            confirmCWModel.str_select_SCAPosition_ddlaborClassCode = ConfirmCW_Data["P92"].ToString().Trim();
            confirmCWModel.str_select_WorkWeek_workweek = ConfirmCW_Data["P93"].ToString().Trim();
            confirmCWModel.str_select_JobCategories_serviceType = ConfirmCW_Data["P96"].ToString().Trim();
            confirmCWModel.str_txt_InternalOrder_matrixNumber = ConfirmCW_Data["P97"].ToString().Trim();
            confirmCWModel.str_txt_CT_customerTrackingNumber = ConfirmCW_Data["P98"].ToString().Trim();
            confirmCWModel.str_txt_WorkdayEmployeeID_customerTrackingNumber = ConfirmCW_Data["P98"].ToString().Trim();
            confirmCWModel.str_txt_VIPNumber_customerTrackingNumber = ConfirmCW_Data["P98"].ToString().Trim();
            confirmCWModel.str_txt_EmployeeID_customerTrackingNumber = ConfirmCW_Data["P98"].ToString().Trim();
            confirmCWModel.str_txt_UltiproID_CustomerTrackingNumber2 = ConfirmCW_Data["P99"].ToString().Trim();
            confirmCWModel.str_txt_NEATID_CustomerTrackingNumber2 = ConfirmCW_Data["P99"].ToString().Trim();
            confirmCWModel.str_btn_ExemptNonExempt_exemptFlag = ConfirmCW_Data["P100"].ToString().Trim();
            confirmCWModel.str_btn_ChargingMethod_exemptFlag = ConfirmCW_Data["P100"].ToString().Trim();
            confirmCWModel.str_select_LaborCategory_serviceMethodID = ConfirmCW_Data["P101"].ToString().Trim();
            confirmCWModel.str_txt_JobCode_JobCode = ConfirmCW_Data["P102"].ToString().Trim();
            confirmCWModel.str_select_HRCostCenter_programName = ConfirmCW_Data["P103"].ToString().Trim();
            confirmCWModel.str_select_AcessLocation_siteLocationID = ConfirmCW_Data["P104"].ToString().Trim();
            confirmCWModel.str_select_SiteLocation_siteLocationID = ConfirmCW_Data["P104"].ToString().Trim();
            confirmCWModel.str_txt_JustificationToHire_JustificationtoHire = ConfirmCW_Data["P105"].ToString().Trim();
            confirmCWModel.str_select_Shift_ShiftId = ConfirmCW_Data["P106"].ToString().Trim();
            confirmCWModel.str_Typeahead_AccountingUnit_deptNumber = ConfirmCW_Data["P107"].ToString().Trim();
            confirmCWModel.str_select_CompanyCode_deptNumber = ConfirmCW_Data["P107"].ToString().Trim();
            confirmCWModel.str_txt_Dept_deptNumber = ConfirmCW_Data["P107"].ToString().Trim();
            confirmCWModel.str_Typeahead_Team_deptNumber = ConfirmCW_Data["P107"].ToString().Trim();
            confirmCWModel.str_Select_HRDepartment_deptNumber = ConfirmCW_Data["P107"].ToString().Trim();
            confirmCWModel.str_Typeahead_AccountingUnitName_deptName = ConfirmCW_Data["P108"].ToString().Trim();
            confirmCWModel.str_txt_DeptName_deptName = ConfirmCW_Data["P108"].ToString().Trim();
            confirmCWModel.str_txt_DeptDescription_deptName = ConfirmCW_Data["P108"].ToString().Trim();
            confirmCWModel.str_txt_APDepartment_deptName = ConfirmCW_Data["P108"].ToString().Trim();
            confirmCWModel.str_txt_LegalEntity_association = ConfirmCW_Data["P109"].ToString().Trim();
            confirmCWModel.str_txt_ServiceDept_ServDept = ConfirmCW_Data["P113"].ToString().Trim();
            confirmCWModel.str_txt_ProductDept_ProDept = ConfirmCW_Data["P114"].ToString().Trim();
            confirmCWModel.str_typeahead_CostCenterNumber_chargeCostCenterNumber = ConfirmCW_Data["P115"].ToString().Trim();
            confirmCWModel.str_select_GLNumber_GLAccounts = ConfirmCW_Data["P116"].ToString().Trim();
            confirmCWModel.str_txt_ProductDept_chargeProDept = ConfirmCW_Data["P117"].ToString().Trim();
            confirmCWModel.str_txt_LegalEntity_chargeassociation = ConfirmCW_Data["P118"].ToString().Trim();
            confirmCWModel.str_txt_ServiceDept_chargeServDept = ConfirmCW_Data["P120"].ToString().Trim();
            confirmCWModel.str_select_Program_programName = ConfirmCW_Data["P122"].ToString().Trim();
            confirmCWModel.str_txt_LMPID_CustomerTrackingNumber3 = ConfirmCW_Data["P123"].ToString().Trim();
            confirmCWModel.str_txt_BadgeNumber_badgeNumber = ConfirmCW_Data["P124"].ToString().Trim();
            confirmCWModel.str_select_SecurityClearance_SecurityClearance = ConfirmCW_Data["P125"].ToString().Trim();
            confirmCWModel.str_select_ClearanceStatus_ClearanceStatus = ConfirmCW_Data["P126"].ToString().Trim();
            confirmCWModel.str_Typeahead_ProjectWBSElement_ProjectId = ConfirmCW_Data["P127"].ToString().Trim();
            confirmCWModel.str_text_ProjectCodeCFR_ProjectId = ConfirmCW_Data["P127"].ToString().Trim();
            confirmCWModel.str_Select_CORE_ProjectId = ConfirmCW_Data["P127"].ToString().Trim();
            confirmCWModel.str_text_ReasonForHire_reasonToHire = ConfirmCW_Data["P128"].ToString().Trim();
            confirmCWModel.str_text_ReasonForEngagement_reasonToHire = ConfirmCW_Data["P128"].ToString().Trim();
            confirmCWModel.str_Typeahead_ChargeProjectWBSElement_chargeProjectId = ConfirmCW_Data["P129"].ToString().Trim();
            confirmCWModel.str_Typeahead_ProjectCodeCFR_chargeProjectId = ConfirmCW_Data["P129"].ToString().Trim();
            confirmCWModel.str_select_PayCodeGroup_payCodeGroupId = ConfirmCW_Data["P130"].ToString().Trim();
            confirmCWModel.str_select_PayCode_paycodeId = ConfirmCW_Data["P131"].ToString().Trim();
            confirmCWModel.str_text_PayRate_payCodePayRate = ConfirmCW_Data["P132"].ToString().Trim();
            confirmCWModel.str_text_SupplierBillRate_payCodeSupplierBillrate = ConfirmCW_Data["P133"].ToString().Trim();
            confirmCWModel.str_text_FinalBillRate_payCodeFinalBillRate = ConfirmCW_Data["P134"].ToString().Trim();
            confirmCWModel.str_select_ObjectAccount_chargeGLId = ConfirmCW_Data["P135"].ToString().Trim();
            confirmCWModel.str_select_CompanyCode_chargedeptNumber = ConfirmCW_Data["P136"].ToString().Trim();
            confirmCWModel.str_Typeahead_BusinessUnit_chargeCostCenterId = ConfirmCW_Data["P115"].ToString().Trim();
            confirmCWModel.str_Typeahead_ChargeNumbers_txtChargeNo = ConfirmCW_Data["P137"].ToString().Trim();
            confirmCWModel.str_txt_GLNumbers_txtGLNo = ConfirmCW_Data["P138"].ToString().Trim();
            confirmCWModel.str_txt_VMSRate_vmsRegBillRate = ConfirmCW_Data["P139"].ToString().Trim();
            confirmCWModel.str_txt_VMSOTRate_vmsOTBillRate = ConfirmCW_Data["P140"].ToString().Trim();
            confirmCWModel.str_txt_MatrixNumber_matrixNumber = ConfirmCW_Data["P97"].ToString().Trim();
            confirmCWModel.str_select_FundingSource_serviceMethodID = ConfirmCW_Data["P101"].ToString().Trim();
            confirmCWModel.str_txt_JustificationforRequest_JustificationtoHire = ConfirmCW_Data["P105"].ToString().Trim();
            confirmCWModel.str_txt_GamingProcess_programName = ConfirmCW_Data["P122"].ToString().Trim();
            confirmCWModel.str_txt_POlineItem_LineItem = ConfirmCW_Data["P141"].ToString().Trim();
            confirmCWModel.str_txt_AribaReq_CustomerTrackingNumber2 = ConfirmCW_Data["P99"].ToString().Trim();
            confirmCWModel.str_select_UnionPosition_ddlaborClassCode = ConfirmCW_Data["P92"].ToString().Trim();
            confirmCWModel.str_Typeahead_ChargeNumber_txtCharge = ConfirmCW_Data["P137"].ToString().Trim();
            confirmCWModel.str_Typeahead_PurchaseOrderNumber_CostCenterId = ConfirmCW_Data["P25"].ToString().Trim();
            confirmCWModel.str_select_ChargeNumberType_ChargeNumberTypes = ConfirmCW_Data["P144"].ToString().Trim();
            confirmCWModel.str_Typeahead_Department_organization = ConfirmCW_Data["P23"].ToString().Trim();
            confirmCWModel.str_Select_Company_organization = ConfirmCW_Data["P23"].ToString().Trim();
            confirmCWModel.str_txt_Justification_JustificationtoHire = ConfirmCW_Data["P105"].ToString().Trim();
            confirmCWModel.str_select_FunctionalArea_ProfitCenterId = ConfirmCW_Data["P143"].ToString().Trim();
            confirmCWModel.str_select_WBSElement_ProjectId = ConfirmCW_Data["P127"].ToString().Trim();
            confirmCWModel.str_btn_AccountAssignmentCostCenter_AccountAssignment1 = ConfirmCW_Data["P142"].ToString().Trim();
            confirmCWModel.str_select_AccountCode_programName = ConfirmCW_Data["P122"].ToString().Trim();
            confirmCWModel.str_txt_RCCode_deptNumber = ConfirmCW_Data["P107"].ToString().Trim();
            confirmCWModel.str_txt_RCDescription_deptName = ConfirmCW_Data["P108"].ToString().Trim();
            confirmCWModel.str_select_ChargeNumbersCompany_AutoFilledChargeNoLabel1 = ConfirmCW_Data["P145"].ToString().Trim();
            confirmCWModel.str_select_ChargeNumbersAccount_AutoFilledChargeNoLabel2 = ConfirmCW_Data["P146"].ToString().Trim();
            confirmCWModel.str_Typeahead_ChargeNumbersRC_AutoFilledChargeNoLabel3 = ConfirmCW_Data["P147"].ToString().Trim();
            confirmCWModel.str_txt_ChargeNumbersMarket_AutoFilledChargeNoLabel4 = ConfirmCW_Data["P148"].ToString().Trim();
            confirmCWModel.str_txt_ChargeNumbersIssueDate_txtAutoFilledChargeNoLabel5 = ConfirmCW_Data["P149"].ToString().Trim();
            confirmCWModel.str_txt_ChargeNumbersDM_txtAutoFilledChargeNoLabel6 = ConfirmCW_Data["P150"].ToString().Trim();
            confirmCWModel.str_txt_ChargeNumbersFutureUse_txtAutoFilledChargeNoLabel7 = ConfirmCW_Data["P151"].ToString().Trim();
            confirmCWModel.str_txt_YPUID_customerTrackingNumber = ConfirmCW_Data["P98"].ToString().Trim();
            confirmCWModel.str_select_YPCompany_siteLocationID = ConfirmCW_Data["P104"].ToString().Trim();
            confirmCWModel.str_select_LabourCategory_serviceType = ConfirmCW_Data["P20"].ToString().Trim();
            confirmCWModel.str_Typeahead_ProgramManager_alternateHiringManagerName = ConfirmCW_Data["P30"].ToString().Trim();
            confirmCWModel.str_select_CoEReqType_serviceMethodID = ConfirmCW_Data["P101"].ToString().Trim();
            confirmCWModel.str_Typeahead_Branch_organization = ConfirmCW_Data["P23"].ToString().Trim();
            confirmCWModel.str_Typeahead_Department_deptNumber = ConfirmCW_Data["P107"].ToString().Trim();
            confirmCWModel.str_Typeahead_POID_ProjectId = ConfirmCW_Data["P127"].ToString().Trim();
            confirmCWModel.str_btn_HRReviewed_computerAccess = ConfirmCW_Data["P152"].ToString().Trim();
            confirmCWModel.str_txt_WorkOrderNumber_customerTrackingNumber = ConfirmCW_Data["P98"].ToString().Trim();
            confirmCWModel.str_select_TypeofAssignment_workweek = ConfirmCW_Data["P93"].ToString().Trim();
            confirmCWModel.str_select_SupplierOperationCompany_OperativeCompany = ConfirmCW_Data["P156"].ToString().Trim();
            confirmCWModel.str_Typeahead_MatrixManager_hiringManagerName = ConfirmCW_Data["P29"].ToString().Trim();
            confirmCWModel.str_Typeahead_FunctionalManager_alternateHiringManagerName = ConfirmCW_Data["P30"].ToString().Trim();
            confirmCWModel.str_select_Company_siteLocationID = ConfirmCW_Data["P104"].ToString().Trim();
            confirmCWModel.str_Select_LocationCode_siteLocationID = ConfirmCW_Data["P104"].ToString().Trim();
            confirmCWModel.str_select_EngagementType_serviceMethodID = ConfirmCW_Data["P101"].ToString().Trim();
            confirmCWModel.str_select_AccountCodingsAccountUnit_deptNumber = ConfirmCW_Data["P157"].ToString().Trim();
            confirmCWModel.str_select_AccountCodingsCompany_siteLocationID = ConfirmCW_Data["P158"].ToString().Trim();
            confirmCWModel.str_select_AccountCodingsProject_ProjectId = ConfirmCW_Data["P159"].ToString().Trim();
            confirmCWModel.str_select_AccountCodingsActivity_ProfitCenterId = ConfirmCW_Data["P160"].ToString().Trim();
            confirmCWModel.str_Typeahead_ChargeNumberProjectName_ChargeprogramId = ConfirmCW_Data["P153"].ToString().Trim();
            confirmCWModel.str_Typeahead_ChargeNumberProjectNumber_ChargeCostCenterId = ConfirmCW_Data["P154"].ToString().Trim();
            confirmCWModel.str_Typeahead_ChargeNumberPOID_ChargeProjectId = ConfirmCW_Data["P155"].ToString().Trim();
            confirmCWModel.str_select_CompanyNumber_deptNumber = ConfirmCW_Data["P21"].ToString().Trim();
            confirmCWModel.str_select_WorkdayJobTitle_jobCodeID = ConfirmCW_Data["P161"].ToString().Trim();
            confirmCWModel.str_TypeHead_EPPICProject_ProjectId = ConfirmCW_Data["P162"].ToString().Trim();
            confirmCWModel.str_Select_EPPICRole_spendLevelId = ConfirmCW_Data["P163"].ToString().Trim();
            confirmCWModel.str_select_EPPICRegion_ProfitCenterId = ConfirmCW_Data["P164"].ToString().Trim();
            confirmCWModel.str_select_EPPICResourcePool_matrixNumber = ConfirmCW_Data["P165"].ToString().Trim();
            confirmCWModel.str_radiobtn_IsRehire_FromRehire = ConfirmCW_Data["P166"].ToString().Trim();
            confirmCWModel.str_txt_CellPhone_mobilePhone = ConfirmCW_Data["P168"].ToString().Trim();
            confirmCWModel.str_txt_PhoneExtension_phoneExtension = ConfirmCW_Data["P169"].ToString().Trim();
            confirmCWModel.str_Radio_ACAD_directIndirect = ConfirmCW_Data["P170"].ToString().Trim();
            confirmCWModel.str_Date_DateofBirth_DOB = ConfirmCW_Data["P171"].ToString().Trim();
            confirmCWModel.str_txt_Street_address1 = ConfirmCW_Data["P172"].ToString().Trim();
            confirmCWModel.str_txt_SocialSecurityNumber_candidateSocialSecurityNumber = ConfirmCW_Data["P173"].ToString().Trim();
            confirmCWModel.str_txt_City_City = ConfirmCW_Data["P173"].ToString().Trim();
            confirmCWModel.str_btn_IsSSNValid_isSSNValid = ConfirmCW_Data["P174"].ToString().Trim();
            confirmCWModel.str_select_State_stateName = ConfirmCW_Data["P185"].ToString().Trim();
            confirmCWModel.str_select_CountryofCitizenship_countryName = ConfirmCW_Data["P176"].ToString().Trim();
            confirmCWModel.str_txt_ZipCode_zipcode = ConfirmCW_Data["P177"].ToString().Trim();
            confirmCWModel.str_btn_SpouseRelativesatAPS_relative = ConfirmCW_Data["P178"].ToString().Trim();
            confirmCWModel.str_select_FormerEmployee_FormallyEmployedFieldId = ConfirmCW_Data["P179"].ToString().Trim();
            confirmCWModel.str_txt_SpourseRelativeName_relativeName = ConfirmCW_Data["P180"].ToString().Trim();
            confirmCWModel.str_select_PadsBasicsforAction_padsName = ConfirmCW_Data["P181"].ToString().Trim();
            confirmCWModel.str_btn_Refferal_Radio4 = ConfirmCW_Data["P182"].ToString().Trim();
            confirmCWModel.str_date_OnSiteArrivalDate_processingDate = ConfirmCW_Data["P183"].ToString().Trim();
            confirmCWModel.str_select_Eligibilitytoworkatworklocation_eligibilityID = ConfirmCW_Data["P184"].ToString().Trim();
            confirmCWModel.str_select_PositionType_serviceType = ConfirmCW_Data["P20"].ToString().Trim();
            confirmCWModel.str_Typeahead_Leader_hiringManagerName = ConfirmCW_Data["P29"].ToString().Trim();
            confirmCWModel.str_select_UnitNumber_deptNumber = ConfirmCW_Data["P107"].ToString().Trim();
            confirmCWModel.str_Typeahead_FFDSupervisor_alternateHiringManagerName = ConfirmCW_Data["P30"].ToString().Trim();
            confirmCWModel.str_select_ACADLevel_programName = ConfirmCW_Data["P122"].ToString().Trim();
            confirmCWModel.str_select_ContractorCost_CostCenterId = ConfirmCW_Data["P25"].ToString().Trim();
            confirmCWModel.str_select_ContractorCategory_GLId = ConfirmCW_Data["P26"].ToString().Trim();
            confirmCWModel.str_Typeahead_MailStation_matrixNumber = ConfirmCW_Data["P97"].ToString().Trim();
            confirmCWModel.str_btn_ComputerAccess_computerAccess = ConfirmCW_Data["P152"].ToString().Trim();
            confirmCWModel.str_txt_RequestJustification_JustificationtoHire = ConfirmCW_Data["P105"].ToString().Trim();
            confirmCWModel.str_Radio_AccountAssignmentCostcenter_AccountAssignment1 = ConfirmCW_Data["P167"].ToString().Trim();
            confirmCWModel.str_radio_AccountAssignmentWBSElement_AccountAssignment3 = ConfirmCW_Data["P167"].ToString().Trim();
            confirmCWModel.str_Typeahead_PurchasingGroup_serviceMethodID = ConfirmCW_Data["P101"].ToString().Trim();
            confirmCWModel.str_select_PurchaseOrg_programName = ConfirmCW_Data["P122"].ToString().Trim();
            confirmCWModel.str_Typeahead_DelegateofAuthority_alternateHiringManagerName = ConfirmCW_Data["P30"].ToString().Trim();
            confirmCWModel.str_select_PlantNumber_siteLocationID = ConfirmCW_Data["P104"].ToString().Trim();
            confirmCWModel.str_select_MaterialGroup_ddlaborClassCode = ConfirmCW_Data["P92"].ToString().Trim();
            confirmCWModel.str_Typeahead_ProfitCenter_ProfitCenterId = ConfirmCW_Data["P143"].ToString().Trim();
            confirmCWModel.str_btn_CWUseryes_isCWuser1 = ConfirmCW_Data["P175"].ToString().Trim();
            confirmCWModel.str_select_TypeofService_serviceType = ConfirmCW_Data["P20"].ToString().Trim();
            confirmCWModel.str_T1_txt_Keywords_cwKeyWords = ConfirmCW_Data["P33"].ToString().Trim();
            confirmCWModel.str_Date_NeededStartDate_preferredStartDate = ConfirmCW_Data["P49"].ToString().Trim();
            confirmCWModel.str_Date_Enddate_endDate = ConfirmCW_Data["P50"].ToString().Trim();
            confirmCWModel.str_txt_CandidateOTPayRate_supplierOTPayRate = ConfirmCW_Data["P57"].ToString().Trim(); //Candidate OT Pay Rate
            confirmCWModel.str_txt_SupplierOTBillRate_supplierOTBillRate = ConfirmCW_Data["P61"].ToString().Trim(); //Supplier OT Bill Rate
            confirmCWModel.str_txt_EstimatedContractValue_totalContractValue = ConfirmCW_Data["P74"].ToString().Trim();
            confirmCWModel.str_txt_ChargeNumberPA_txtChargePA = ConfirmCW_Data["P185"].ToString().Trim();
            confirmCWModel.str_select_ChargeNumberPAA_chargeCostCenterId = ConfirmCW_Data["P186"].ToString().Trim();
            confirmCWModel.str_select_Emergencyposition_laborClassCode = ConfirmCW_Data["P187"].ToString().Trim();
            confirmCWModel.str_Typeahead_ChargeNumberLegalEntity_ChargeorganizationID = ConfirmCW_Data["P188"].ToString().Trim();
        //    confirmCWModel.str_Select_Businessunit_ChargeorganizationID = ConfirmCW_Data["P188"].ToString().Trim();
            confirmCWModel.str_Typeahead_ChargeNumberBusinessArea_ChargeProjectId = ConfirmCW_Data["P189"].ToString().Trim();
            confirmCWModel.str_Typeahead_ChargeNumbernaturalAccount_ChargeGLId = ConfirmCW_Data["P190"].ToString().Trim();
            confirmCWModel.str_Select_ExpenseAccount_ChargeGLId = ConfirmCW_Data["P190"].ToString().Trim();
            confirmCWModel.str_Select_HyperionCodeGLUnit_ChargeGLId = ConfirmCW_Data["P190"].ToString().Trim();
            confirmCWModel.str_Typeahead_ChargeNumberLocalAnalysis_ChargesiteLocationID = ConfirmCW_Data["P191"].ToString().Trim();
            confirmCWModel.str_Typeahead_ChargeNumberCostCenter_ChargeCostCenterId = ConfirmCW_Data["P192"].ToString().Trim();
            confirmCWModel.str_typeahead_BusinessArea_ChargeCostCenterId = ConfirmCW_Data["P192"].ToString().Trim();
            confirmCWModel.str_Typeahead_AccountCode_ChargeCostCenterId = ConfirmCW_Data["P192"].ToString().Trim();
            confirmCWModel.str_Typeahead_ChargeNumberInterCompany_ChargedeptNumber = ConfirmCW_Data["P193"].ToString().Trim();
            confirmCWModel.str_select_HastheNonEmployeebeenofferedACACompliantHealthCoverage_ACACompliantHealthCoverage = ConfirmCW_Data["P194"].ToString().Trim();
            confirmCWModel.str_select_ACACostPer_ACACostPer = ConfirmCW_Data["P195"].ToString().Trim();
            confirmCWModel.str_txt_ACACost_ACACost = ConfirmCW_Data["P196"].ToString().Trim();
            confirmCWModel.str_select_SupplierOperatingCompany_OperativeCompany = ConfirmCW_Data["P197"].ToString().Trim();
            confirmCWModel.str_Typeahead_EAAApprover_alternateHiringManagerName = ConfirmCW_Data["P30"].ToString().Trim();
            confirmCWModel.str_select_Division_organization = ConfirmCW_Data["P23"].ToString().Trim();
            confirmCWModel.str_select_PAA_CostCenterId = ConfirmCW_Data["P25"].ToString().Trim();
            confirmCWModel.str_txt_PA_association = ConfirmCW_Data["P109"].ToString().Trim();
            confirmCWModel.str_select_DeptProgramTaskOrder_programName = ConfirmCW_Data["P122"].ToString().Trim();
            confirmCWModel.str_select_COEBAT_ProfitCenterId = ConfirmCW_Data["P143"].ToString().Trim();
            confirmCWModel.str_Typeahead_LegalEntity_organization = ConfirmCW_Data["P23"].ToString().Trim();
            confirmCWModel.str_Typeahead_BusinessArea_ProjectId = ConfirmCW_Data["P127"].ToString().Trim();
            confirmCWModel.str_Typeahead_NaturalAccount_GLId = ConfirmCW_Data["P26"].ToString().Trim();
            confirmCWModel.str_select_LocalAnalysis_siteLocationID = ConfirmCW_Data["P104"].ToString().Trim();
            confirmCWModel.str_Typeahead_InterCompany_deptNumber = ConfirmCW_Data["P107"].ToString().Trim();
            confirmCWModel.str_select_BusinessUnit_serviceMethodID = ConfirmCW_Data["P101"].ToString().Trim();
            confirmCWModel.str_select_ServiceMethod_serviceMethodID = ConfirmCW_Data["P101"].ToString().Trim();
            confirmCWModel.str_txt_Comments_JustificationtoHire = ConfirmCW_Data["P105"].ToString().Trim();
            confirmCWModel.str_select_SmartTrackTimesheet_AccountType = ConfirmCW_Data["P48"].ToString().Trim();
            confirmCWModel.str_Typeahead_GoodsReceiptApprover_alternateHiringManagerName = ConfirmCW_Data["P30"].ToString().Trim();
            confirmCWModel.str_select_BuyerName_CostCenterId = ConfirmCW_Data["P25"].ToString().Trim();
            confirmCWModel.str_Typeahead_BusinessArea_CostCenterId = ConfirmCW_Data["P25"].ToString().Trim();
            confirmCWModel.str_txt_CompanyCode_deptNumber = ConfirmCW_Data["P107"].ToString().Trim();
            confirmCWModel.str_txt_CompanyCodedescription_deptName = ConfirmCW_Data["P18"].ToString().Trim();
            confirmCWModel.str_select_QualityAssurance_programName = ConfirmCW_Data["P103"].ToString().Trim();
            confirmCWModel.str_select_PlaceofWork_siteLocationID = ConfirmCW_Data["P104"].ToString().Trim();
            confirmCWModel.str_text_JustificationforOpening_reasonToHire = ConfirmCW_Data["P128"].ToString().Trim();
            confirmCWModel.str_Typeahead_OfficeCubicleNumber_matrixNumber = ConfirmCW_Data["P97"].ToString().Trim();
            confirmCWModel.str_txt_CandidateBillRateSavings_supplierBillRateSavings = ConfirmCW_Data["P79"].ToString().Trim();
            confirmCWModel.str_Txt_ComplianceAccessNeeded_matrixNumber = ConfirmCW_Data["P97"].ToString().Trim();
            confirmCWModel.str_select_GLBusinessUnit_GLId = ConfirmCW_Data["P26"].ToString().Trim();
            confirmCWModel.str_Select_ExpenseAccount_GLId = ConfirmCW_Data["P26"].ToString().Trim();
            confirmCWModel.str_Select_HyperionCodeGlUnit_GLId = ConfirmCW_Data["P26"].ToString().Trim();
            confirmCWModel.str_txt_CandidateFirstName_firstName = ConfirmCW_Data["P11"].ToString().Trim();
            confirmCWModel.str_txt_CandidateLastName_lastName = ConfirmCW_Data["P10"].ToString().Trim();
            confirmCWModel.str_txt_CandidateMiddleName_middleName = ConfirmCW_Data["P12"].ToString().Trim();
            confirmCWModel.str_txt_CandidateNameSuffix_nameSuffix = ConfirmCW_Data["P13"].ToString().Trim();
            confirmCWModel.str_Typeahead_SpendCategory_deptNumber = ConfirmCW_Data["P107"].ToString().Trim();
            confirmCWModel.str_Typeahead_CourseName_serviceMethodID = ConfirmCW_Data["P101"].ToString().Trim();
            confirmCWModel.str_Typeahead_OrganizationName_organization = ConfirmCW_Data["P23"].ToString().Trim();
            confirmCWModel.str_Txt_POdetailsRemoteCWWorklocationaddress_JustificationtoHire = ConfirmCW_Data["P105"].ToString().Trim();
            confirmCWModel.str_Select_Purpose_ProfitCenterId = ConfirmCW_Data["P143"].ToString().Trim();
            confirmCWModel.str_Select_Fund_siteLocationID = ConfirmCW_Data["P104"].ToString().Trim();
            confirmCWModel.str_Typeahead_PONumber_purchaseOrderNumber = ConfirmCW_Data["P95"].ToString().Trim();
            confirmCWModel.str_Select_Department_deptNumber = ConfirmCW_Data["P107"].ToString().Trim();
            confirmCWModel.str_Select_SubDivision_programName = ConfirmCW_Data["P122"].ToString().Trim();
            confirmCWModel.str_Select_ServiceMethod_serviceMethodID = ConfirmCW_Data["P101"].ToString().Trim();
            confirmCWModel.str_Typeahead_Division_GLId = ConfirmCW_Data["P26"].ToString().Trim();
            confirmCWModel.str_Select_ReqType_organization = ConfirmCW_Data["P23"].ToString().Trim();
            confirmCWModel.str_Txt_Comments_JustificationtoHire = ConfirmCW_Data["P105"].ToString().Trim();
            confirmCWModel.str_Select_BusinessUnit_ProjectId = ConfirmCW_Data["P127"].ToString().Trim();
            confirmCWModel.str_Select_AccountCode_CostCenterId = ConfirmCW_Data["P25"].ToString().Trim();
            confirmCWModel.str_Txt_WorkDayID_customerTrackingNumber = ConfirmCW_Data["P98"].ToString().Trim();
            confirmCWModel.str_txt_peopleSoftID_customerTrackingNumber = ConfirmCW_Data["P98"].ToString().Trim();
            confirmCWModel.str_Typeahead_BusinessStructure_deptNumber = ConfirmCW_Data["P107"].ToString().Trim();
            confirmCWModel.str_Select_ProductLine_siteLocationID = ConfirmCW_Data["P104"].ToString().Trim();
            confirmCWModel.str_Select_WorkerSubType_serviceMethodID = ConfirmCW_Data["P101"].ToString().Trim();
            confirmCWModel.str_Typeahead_FinanceEntity_organization = ConfirmCW_Data["P23"].ToString().Trim();
            confirmCWModel.str_Typeahead_PrimaryLocation_workLocationID = ConfirmCW_Data["P28"].ToString().Trim();
            confirmCWModel.str_Typeahead_HiringLeader_workLocationID = ConfirmCW_Data["P28"].ToString().Trim();
            confirmCWModel.str_Select_SupervisoryOrg_ProfitCenterId = ConfirmCW_Data["P143"].ToString().Trim();
            confirmCWModel.str_typeahead_CostCenter_ChargeCostCenterId = ConfirmCW_Data["P192"].ToString().Trim();
            confirmCWModel.str_Typeahead_Department_ChargeorganizationID = ConfirmCW_Data["P188"].ToString().Trim();
            confirmCWModel.str_Select_AccountCode_ChargeCostCenterId = ConfirmCW_Data["P192"].ToString().Trim();
            confirmCWModel.str_Select_BusinessUnit_ChargeProjectId = ConfirmCW_Data["P189"].ToString().Trim();
            confirmCWModel.str_Select_CORE_ChargeProjectId = ConfirmCW_Data["P189"].ToString().Trim();
            confirmCWModel.str_Select_Reqtype_ChargeorganizationID = ConfirmCW_Data["P188"].ToString().Trim();
            confirmCWModel.str_Select_CommodityCode_laborClassCode = ConfirmCW_Data["P92"].ToString().Trim();
            confirmCWModel.str_Typeahead_ChargeCompanyNumber_deptNumber = ConfirmCW_Data["P136"].ToString().Trim();
            confirmCWModel.str_Select_APCostCenter_chargeGLId = ConfirmCW_Data["P135"].ToString().Trim();
            confirmCWModel.str_Typeahead_GLAccount_chargeCostCenterId = ConfirmCW_Data["P115"].ToString().Trim();
            confirmCWModel.str_Select_Category_serviceType = ConfirmCW_Data["P20"].ToString().Trim();
            confirmCWModel.str_Typeahead_CompanyNumber_deptNumber = ConfirmCW_Data["P107"].ToString().Trim();
            confirmCWModel.str_Select_Business_organization = ConfirmCW_Data["P23"].ToString().Trim();
            confirmCWModel.str_Select_WorkerClassification_laborClassCode = ConfirmCW_Data["P92"].ToString().Trim();
            confirmCWModel.str_Typeahead_RequestOwner_hiringManagerName = ConfirmCW_Data["P29"].ToString().Trim();
            confirmCWModel.str_Typeahead_Requestor_alternateHiringManagerName = ConfirmCW_Data["P30"].ToString().Trim();
            confirmCWModel.str_Select_ChargeGLAccount_ChargeGLId = ConfirmCW_Data["P190"].ToString().Trim();
            confirmCWModel.str_btn_FormerEmployee_exEmployee = ConfirmCW_Data["P198"].ToString().Trim();
            confirmCWModel.str_Txt_FormerEmployeeDetails_exEmployeeDetails = ConfirmCW_Data["P199"].ToString().Trim();
            confirmCWModel.str_btn_FormerContigentWorker_exContractor = ConfirmCW_Data["P200"].ToString().Trim();
            confirmCWModel.str_Txt_FormerContigentWorker_exContractorDetails = ConfirmCW_Data["P201"].ToString().Trim();
            confirmCWModel.str_Txt_WorkdayID_CustomerTrackingNumber2 = ConfirmCW_Data["P99"].ToString().Trim();
            confirmCWModel.str_txt_iCIMSID_CustomerTrackingNumber2 = ConfirmCW_Data["P99"].ToString().Trim();
            confirmCWModel.str_Txt_RACFID_customerTrackingNumber = ConfirmCW_Data["P98"].ToString().Trim();
            confirmCWModel.str_txt_CommonID_customerTrackingNumber = ConfirmCW_Data["P98"].ToString().Trim();
            confirmCWModel.str_Txt_ILMID_CustomerTrackingNumber3 = ConfirmCW_Data["P123"].ToString().Trim();
            confirmCWModel.str_Select_TimeEntity_timeentry = ConfirmCW_Data["P202"].ToString().Trim();
            confirmCWModel.str_Typeahead_Division_programName = ConfirmCW_Data["P103"].ToString().Trim();
            confirmCWModel.str_btn_CWcanworkRemotely_directIndirect = ConfirmCW_Data["P91"].ToString().Trim();
            confirmCWModel.str_Txt_Justification_JustificationtoHire = ConfirmCW_Data["P105"].ToString().Trim();
            confirmCWModel.str_Typeahead_ChargeCostCenterNumber_chargeCostCenterId = ConfirmCW_Data["P115"].ToString().Trim();
            confirmCWModel.str_select_GLNumber_chargeGLId = ConfirmCW_Data["P135"].ToString().Trim();
            confirmCWModel.str_Txt_RehireDetails_exEmployeeDetails = ConfirmCW_Data["P199"].ToString().Trim();
            confirmCWModel.str_Select_GRIFeeType_MSPTracking1 = ConfirmCW_Data["P203"].ToString().Trim();
            confirmCWModel.str_Select_GRISpendType_MSPTracking2 = ConfirmCW_Data["P204"].ToString().Trim();
            confirmCWModel.str_Select_GRISpendbyIndustry_MSPTracking3 = ConfirmCW_Data["P205"].ToString().Trim();
            confirmCWModel.str_Select_GRISpendbyCountry_MSPTracking4 = ConfirmCW_Data["P206"].ToString().Trim();
            confirmCWModel.str_Select_GRISpendbyCategory_MSPTracking5 = ConfirmCW_Data["P207"].ToString().Trim();
            confirmCWModel.str_txt_SocialSecurityNumber_candidateSSN = ConfirmCW_Data["P208"].ToString().Trim();
            confirmCWModel.str_Select_Gender_Gender = ConfirmCW_Data["P209"].ToString().Trim();
            confirmCWModel.str_Select_Race_nativeAmericanName = ConfirmCW_Data["P210"].ToString().Trim();
            confirmCWModel.str_Typeahead_APDepartment_ChargedeptName = ConfirmCW_Data["P210"].ToString().Trim();
         //   confirmCWModel.str_Txt_PeopleSoftID_customerTrackingNumber = ConfirmCW_Data["P98"].ToString().Trim();
            confirmCWModel.str_Txt_Supplier_supplierName = ConfirmCW_Data["P38"].ToString().Trim();
           
            confirmCWModel.str_Select_APDepartment_deptName = ConfirmCW_Data["P108"].ToString().Trim();
          
            confirmCWModel.str_Select_HyperionCodeGlUnit_GLId = ConfirmCW_Data["P26"].ToString().Trim();

            confirmCWModel.str_Typeahead_WBSElement_ProjectId = ConfirmCW_Data["P127"].ToString().Trim();
            confirmCWModel.str_Typeahead_MatrixNumber_matrixNumber = ConfirmCW_Data["P97"].ToString().Trim();
            confirmCWModel.str_Typeahead_ProgramName_programName = ConfirmCW_Data["P122"].ToString().Trim();
            confirmCWModel.str_Typeahead_GL_ChargeGLId = ConfirmCW_Data["P190"].ToString().Trim();
            confirmCWModel.str_Typeahead_WBSElement_ChargeProjectId = ConfirmCW_Data["P129"].ToString().Trim();
            confirmCWModel.str_Txt_SavingsComment_savingComment = ConfirmCW_Data["P82"].ToString().Trim();

            confirmCWModel.str_uploadPOfile = ConfirmCW_Data["P96"].ToString().Trim();//for ceasers



            return confirmCWModel;
        }

        public SubmitToManExtendOfferMethodModel GetSubmitToManExtendOfferMethodData(DataRow ExtendOffer_Data)
        {
            SubmitToManExtendOfferMethodModel submitToManExtendOfferMethodModel = new SubmitToManExtendOfferMethodModel();
            submitToManExtendOfferMethodModel.strClientName = ExtendOffer_Data["P3"].ToString().Trim();
            submitToManExtendOfferMethodModel.strMainMenuLink = ExtendOffer_Data["P4"].ToString().Trim();
            submitToManExtendOfferMethodModel.strSubMenuLink = ExtendOffer_Data["P5"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_Link_ReqNumber = ExtendOffer_Data["P6"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_Link_ActionList_ViewCandidates = ExtendOffer_Data["P42"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_Link_ActionList_ExperienceValidation = ExtendOffer_Data["P42"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_CandidateName = ExtendOffer_Data["P8"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_Txt_Years = ExtendOffer_Data["P44"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_Link_ActionList_ExtendOffer = ExtendOffer_Data["P44"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_Txt_Months = ExtendOffer_Data["P45"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_Txt_proposedRegPayRate = ExtendOffer_Data["P45"].ToString().Trim();   //Proposed Pay Rate
            submitToManExtendOfferMethodModel.str_Txt_proposedOTPayRate = ExtendOffer_Data["P46"].ToString().Trim();//Proposed OT Pay Rate
            submitToManExtendOfferMethodModel.str_Txt_payRateMarkup = ExtendOffer_Data["P47"].ToString().Trim();//Pay Rate Markup%:
            submitToManExtendOfferMethodModel.str_Txt_proposedRegBillRate = ExtendOffer_Data["P48"].ToString().Trim();//Proposed Supplier Bill Rate:
            submitToManExtendOfferMethodModel.str_Txt_proposedOTBillRate = ExtendOffer_Data["P49"].ToString().Trim(); //Proposed Supplier OT Bill Rate:
            submitToManExtendOfferMethodModel.str_Txt_finalRegBillRate = ExtendOffer_Data["P50"].ToString().Trim();//Final Bill Rate: 
            submitToManExtendOfferMethodModel.str_Txt_finalOTBillRate = ExtendOffer_Data["P51"].ToString().Trim();//Final OT Bill Rate:  
            submitToManExtendOfferMethodModel.str_Txt_weeklyRegHoursNTE = ExtendOffer_Data["P52"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_Txt_weeklyOTHoursNTE = ExtendOffer_Data["P53"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_Txt_yearlyRegHoursNTE = ExtendOffer_Data["P54"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_Txt_totalContractValue = ExtendOffer_Data["P55"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_Txt_PrefStartdate = ExtendOffer_Data["P56"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_Txt_enddate = ExtendOffer_Data["P57"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_AddListTxt_txtTimecardApprover = ExtendOffer_Data["P58"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_DeleteListTxt_txtTimecardApprover = ExtendOffer_Data["P59"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_AddListTxt_ChargeNumbers = ExtendOffer_Data["P60"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_DeleteListTxt_ChargeNumbers = ExtendOffer_Data["P61"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_AddListTxt_GLNumbers = ExtendOffer_Data["P62"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_DeleteListTxt_GLNumbers = ExtendOffer_Data["P63"].ToString().Trim();
            //  submitToManExtendOfferMethodModel.str_Txt_ProposedSupplierOTBillRate = ExtendOffer_Data["P14"].ToString().Trim();
            //  submitToManExtendOfferMethodModel.str_Txt_proposedRegBillRate = ExtendOffer_Data["P14"].ToString().Trim();
            //  submitToManExtendOfferMethodModel.str_Txt_proposedOTBillRate = ExtendOffer_Data["P14"].ToString().Trim();
            //   submitToManExtendOfferMethodModel.str_Txt_Proposebillrate = ExtendOffer_Data["P15"].ToString().Trim();
            //  submitToManExtendOfferMethodModel.str_Txt_finalRegBillRate = ExtendOffer_Data["P15"].ToString().Trim();
            // submitToManExtendOfferMethodModel.str_Txt_proposedOTPayRate = ExtendOffer_Data["P15""].ToString().Trim();
            //   submitToManExtendOfferMethodModel.str_Txt_Proposeotbillrate = ExtendOffer_Data["P16"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_Btn_ExtendOffer_Submit = ExtendOffer_Data["P64"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_Btn_ExtendOffer_Submit_Confirm = ExtendOffer_Data["P65"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_Btn_ExtendOffer_Submit_Confirm_Ok = ExtendOffer_Data["P66"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_Txt_poNumber = ExtendOffer_Data["P67"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_Txt_ProposeDifferentRate = ExtendOffer_Data["P75"].ToString().Trim();
            //Added by manjusha
            submitToManExtendOfferMethodModel.str_Txt_Billrate_Supplierbillrate = ExtendOffer_Data["P82"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_Txt_numberofhours_offertoHire = ExtendOffer_Data["P83"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_Txt_numberofResources_offertoHire = ExtendOffer_Data["P78"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_Txt_Estimatedcontract_offertoHire = ExtendOffer_Data["P84"].ToString().Trim();
            submitToManExtendOfferMethodModel.str_Txt_IdentifiedCandidate_PayRateMarkup_markup = ExtendOffer_Data["P47"].ToString().Trim();
            return submitToManExtendOfferMethodModel;
        }

        public SubmitToManExtendOfferModel GetSubmitToManExtendOfferData(DataRow ExtendOffer_Data)
        {
            SubmitToManExtendOfferModel submitToManExtendOfferModel = new SubmitToManExtendOfferModel();
            submitToManExtendOfferModel.strClientName = ExtendOffer_Data["P3"].ToString().Trim();
            submitToManExtendOfferModel.strMainMenuLink = ExtendOffer_Data["P4"].ToString().Trim();
            submitToManExtendOfferModel.strSubMenuLink = ExtendOffer_Data["P5"].ToString().Trim();
            submitToManExtendOfferModel.str_Link_ReqNumber = ExtendOffer_Data["P6"].ToString().Trim();
            submitToManExtendOfferModel.str_Link_ActionList_ViewCandidates = ExtendOffer_Data["P7"].ToString().Trim();
            submitToManExtendOfferModel.str_Link_ActionList_ExperienceValidation = ExtendOffer_Data["P42"].ToString().Trim();
            submitToManExtendOfferModel.str_CandidateName = ExtendOffer_Data["P8"].ToString().Trim();
            submitToManExtendOfferModel.str_Txt_Years = ExtendOffer_Data["P44"].ToString().Trim();
            submitToManExtendOfferModel.str_Link_ActionList_ExtendOffer = ExtendOffer_Data["P44"].ToString().Trim();
            submitToManExtendOfferModel.str_Txt_Months = ExtendOffer_Data["P45"].ToString().Trim();
            //   submitToManExtendOfferModel.str_Txt_ProposedSupplierBillRate = ExtendOffer_Data["P12"].ToString().Trim();
            submitToManExtendOfferModel.str_Txt_proposedRegPayRate = ExtendOffer_Data["P45"].ToString().Trim();   //Proposed Pay Rate
            submitToManExtendOfferModel.str_Txt_proposedOTPayRate = ExtendOffer_Data["P46"].ToString().Trim();//Proposed OT Pay Rate
            submitToManExtendOfferModel.str_Txt_payRateMarkup = ExtendOffer_Data["P47"].ToString().Trim();//Pay Rate Markup%:
            submitToManExtendOfferModel.str_Txt_proposedRegBillRate = ExtendOffer_Data["P48"].ToString().Trim();//Proposed Supplier Bill Rate:
            submitToManExtendOfferModel.str_Txt_proposedOTBillRate = ExtendOffer_Data["P49"].ToString().Trim(); //Proposed Supplier OT Bill Rate:
            submitToManExtendOfferModel.str_Txt_finalRegBillRate = ExtendOffer_Data["P50"].ToString().Trim();//Final Bill Rate: 
            submitToManExtendOfferModel.str_Txt_finalOTBillRate = ExtendOffer_Data["P51"].ToString().Trim();//Final OT Bill Rate:  
            submitToManExtendOfferModel.str_Txt_weeklyRegHoursNTE = ExtendOffer_Data["P52"].ToString().Trim();
            submitToManExtendOfferModel.str_Txt_weeklyOTHoursNTE = ExtendOffer_Data["P53"].ToString().Trim();
            submitToManExtendOfferModel.str_Txt_yearlyRegHoursNTE = ExtendOffer_Data["P54"].ToString().Trim();
            submitToManExtendOfferModel.str_Txt_totalContractValue = ExtendOffer_Data["P55"].ToString().Trim();
            submitToManExtendOfferModel.str_Txt_PrefStartdate = ExtendOffer_Data["P56"].ToString().Trim();
            submitToManExtendOfferModel.str_Txt_enddate = ExtendOffer_Data["P57"].ToString().Trim();
            submitToManExtendOfferModel.str_AddListTxt_txtTimecardApprover = ExtendOffer_Data["P58"].ToString().Trim();
            submitToManExtendOfferModel.str_DeleteListTxt_txtTimecardApprover = ExtendOffer_Data["P59"].ToString().Trim();
            submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers = ExtendOffer_Data["P60"].ToString().Trim();
            submitToManExtendOfferModel.str_DeleteListTxt_ChargeNumbers = ExtendOffer_Data["P61"].ToString().Trim();
            submitToManExtendOfferModel.str_AddListTxt_GLNumbers = ExtendOffer_Data["P62"].ToString().Trim();
            submitToManExtendOfferModel.str_DeleteListTxt_GLNumbers = ExtendOffer_Data["P63"].ToString().Trim();
            submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit = ExtendOffer_Data["P64"].ToString().Trim();
            submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit_Confirm = ExtendOffer_Data["P65"].ToString().Trim();
            submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit_Confirm_Ok = ExtendOffer_Data["P66"].ToString().Trim();
            submitToManExtendOfferModel.str_Txt_poNumber = ExtendOffer_Data["P67"].ToString().Trim();
            submitToManExtendOfferModel.str_Txt_ProposeDifferentRate = ExtendOffer_Data["P75"].ToString().Trim();

            submitToManExtendOfferModel.str_Link_Withdrawoffer = ExtendOffer_Data["P68"].ToString().Trim();
            submitToManExtendOfferModel.str_Select_WithdrawofferReason = ExtendOffer_Data["P69"].ToString().Trim();
            submitToManExtendOfferModel.str_Txt_WithdrawofferReasoncomment = ExtendOffer_Data["P70"].ToString().Trim();
            submitToManExtendOfferModel.str_Button_Withdrawoffer = ExtendOffer_Data["P71"].ToString().Trim();
            submitToManExtendOfferModel.str_Button_Withdrawoffer_yes = ExtendOffer_Data["P72"].ToString().Trim();
            submitToManExtendOfferModel.str_Button_Withdrawoffer_ok = ExtendOffer_Data["P73"].ToString().Trim();
            //submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit = ExtendOffer_Data["P66"].ToString().Trim();
            //submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit_Confirm = ExtendOffer_Data["P67"].ToString().Trim();
            //submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit_Confirm_Ok = ExtendOffer_Data["P68"].ToString().Trim();
            //Added by manjusha
            submitToManExtendOfferModel.str_Txt_Billrate_Supplierbillrate = ExtendOffer_Data["P82"].ToString().Trim();
            submitToManExtendOfferModel.str_Txt_numberofhours_offertoHire = ExtendOffer_Data["P83"].ToString().Trim();
            submitToManExtendOfferModel.str_Txt_numberofResources_offertoHire = ExtendOffer_Data["P78"].ToString().Trim();
            submitToManExtendOfferModel.str_Txt_Estimatedcontract_offertoHire = ExtendOffer_Data["P84"].ToString().Trim();
            submitToManExtendOfferModel.str_Txt_numberofDays_offertoHire = ExtendOffer_Data["P85"].ToString().Trim();
           
            return submitToManExtendOfferModel;
        }



        //public ApproveBatchInvoiceModel GetApproveBatchInvoiceData(DataRow ApproveBatch_Invoice)
        //{
        //    ApproveBatchInvoiceModel approveBatchInvoiceModel = new ApproveBatchInvoiceModel();
        //    approveBatchInvoiceModel.strTestCaseId = ApproveBatch_Invoice["TestCaseID"].ToString().Trim();
        //    approveBatchInvoiceModel.strUserID = ApproveBatch_Invoice["P3"].ToString().Trim();
        //    approveBatchInvoiceModel.strClientName = ApproveBatch_Invoice["P5"].ToString().Trim();
        //    approveBatchInvoiceModel.strMainMenuLink = ApproveBatch_Invoice["P6"].ToString().Trim();
        //    approveBatchInvoiceModel.strSubMenuLink = ApproveBatch_Invoice["P7"].ToString().Trim();
        //    approveBatchInvoiceModel.str_btn_CreateBatch = ApproveBatch_Invoice["P8"].ToString().Trim();
        //    approveBatchInvoiceModel.str_Txt_global_filter = ApproveBatch_Invoice["P8"].ToString().Trim();
        //    approveBatchInvoiceModel.str_btn_ActionButton = ApproveBatch_Invoice["P9"].ToString().Trim();
        //    approveBatchInvoiceModel.str_link_Actionlink = ApproveBatch_Invoice["P10"].ToString().Trim();
        //    approveBatchInvoiceModel.str_Select_cboReson = ApproveBatch_Invoice["P11"].ToString().Trim();
        //    approveBatchInvoiceModel.str_Txt_TxtComments = ApproveBatch_Invoice["P12"].ToString().Trim();
        //    return approveBatchInvoiceModel;
        //}

        //public CreateBatchModel GetCreateBatchInvoiceData(DataRow CreateBatch_Invoice)
        //{
        //    CreateBatchModel createBatchModel = new CreateBatchModel();
        //    createBatchModel.strTestCaseId = CreateBatch_Invoice["TestCaseID"].ToString().Trim();
        //    createBatchModel.strUserID = CreateBatch_Invoice["P3"].ToString().Trim();
        //    createBatchModel.strClientName = CreateBatch_Invoice["P5"].ToString().Trim();
        //    createBatchModel.strMainMenuLink = CreateBatch_Invoice["P6"].ToString().Trim();
        //    createBatchModel.strSubMenuLink = CreateBatch_Invoice["P7"].ToString().Trim();
        //    createBatchModel.str_btn_CreateBatch = CreateBatch_Invoice["P9"].ToString().Trim();
        //    createBatchModel.str_Txt_CW = CreateBatch_Invoice["P10"].ToString().Trim();
        //    createBatchModel.str_Date_WeekEnding = CreateBatch_Invoice["P11"].ToString().Trim();
        //    return createBatchModel;
        //}

        //public CreateVoucherInvoiceModel GetCreateVoucherInvoiceData(DataRow CreateVoucher_Invoice)
        //{
        //    CreateVoucherInvoiceModel createVoucherInvoiceModel = new CreateVoucherInvoiceModel();
        //    createVoucherInvoiceModel.strTestCaseId = CreateVoucher_Invoice["TestCaseID"].ToString().Trim();
        //    createVoucherInvoiceModel.strUserID = CreateVoucher_Invoice["P3"].ToString().Trim();
        //    createVoucherInvoiceModel.strClientName = CreateVoucher_Invoice["P5"].ToString().Trim();
        //    createVoucherInvoiceModel.strMainMenuLink = CreateVoucher_Invoice["P6"].ToString().Trim();
        //    createVoucherInvoiceModel.strSubMenuLink = CreateVoucher_Invoice["P7"].ToString().Trim();
        //    createVoucherInvoiceModel.str_batchNumber = CreateVoucher_Invoice["P8"].ToString().Trim();
        //    createVoucherInvoiceModel.str_btn_AddNew = CreateVoucher_Invoice["P9"].ToString().Trim();
        //    createVoucherInvoiceModel.str_Txt_PANumber = CreateVoucher_Invoice["P10"].ToString().Trim();
        //    createVoucherInvoiceModel.str_Date_ReceivedDate = CreateVoucher_Invoice["P11"].ToString().Trim();
        //    createVoucherInvoiceModel.str_Txt_PAAmount = CreateVoucher_Invoice["P12"].ToString().Trim();
        //    createVoucherInvoiceModel.strSubMenuVouchers = CreateVoucher_Invoice["P15"].ToString().Trim();
        //    createVoucherInvoiceModel.str_link_Actionlink = CreateVoucher_Invoice["P16"].ToString().Trim();
        //    return createVoucherInvoiceModel;
        //}

        //public PaidVoucherInvoiceModel GetPaidVoucherInvoiceData(DataRow Paid_Vouchers_Data)
        //{
        //    PaidVoucherInvoiceModel paidVoucherInvoiceModel = new PaidVoucherInvoiceModel();
        //    paidVoucherInvoiceModel.strTestCaseId = Paid_Vouchers_Data["TestCaseID"].ToString().Trim();
        //    paidVoucherInvoiceModel.strUserID = Paid_Vouchers_Data["P3"].ToString().Trim();
        //    paidVoucherInvoiceModel.strClientName = Paid_Vouchers_Data["P5"].ToString().Trim();
        //    paidVoucherInvoiceModel.strMainMenuLink = Paid_Vouchers_Data["P6"].ToString().Trim();
        //    paidVoucherInvoiceModel.strSubMenuLink = Paid_Vouchers_Data["P7"].ToString().Trim();
        //    paidVoucherInvoiceModel.str_btn_CreateBatch = Paid_Vouchers_Data["P8"].ToString().Trim();
        //    paidVoucherInvoiceModel.str_Txt_global_filter = Paid_Vouchers_Data["P8"].ToString().Trim();
        //    paidVoucherInvoiceModel.str_Txt_checkNumber = Paid_Vouchers_Data["P9"].ToString().Trim();
        //    paidVoucherInvoiceModel.str_Date_checkDate = Paid_Vouchers_Data["P10"].ToString().Trim();
        //    paidVoucherInvoiceModel.str_btn_ActionButton = Paid_Vouchers_Data["P9"].ToString().Trim();
        //    paidVoucherInvoiceModel.str_link_Actionlink = Paid_Vouchers_Data["P10"].ToString().Trim();
        //    paidVoucherInvoiceModel.str_Select_cboReson = Paid_Vouchers_Data["P11"].ToString().Trim();
        //    paidVoucherInvoiceModel.str_Txt_TxtComments = Paid_Vouchers_Data["P12"].ToString().Trim();
        //    return paidVoucherInvoiceModel;
        //}

        public SubmitToManagerModel GetSubmitToManagerData(DataRow SubmitToManager_Data)
        {
            SubmitToManagerModel submitToManagerModel = new SubmitToManagerModel();
            submitToManagerModel.strClientName = SubmitToManager_Data["P3"].ToString().Trim();
            submitToManagerModel.strMainMenuLink = SubmitToManager_Data["P4"].ToString().Trim();
            submitToManagerModel.strSubMenuLink = SubmitToManager_Data["P5"].ToString().Trim();
            submitToManagerModel.str_Link_ReqNumber = SubmitToManager_Data["P6"].ToString().Trim();
            submitToManagerModel.str_Link_ActionList_ViewCandidates = SubmitToManager_Data["P7"].ToString().Trim();
            submitToManagerModel.str_CandidateName = SubmitToManager_Data["P8"].ToString().Trim();
            submitToManagerModel.str_Link_ActionList_SubmitToManager = SubmitToManager_Data["P9"].ToString().Trim();
            //submitToManagerModel.str_Txt_FinalBillRate = SubmitToManager_Data["P10"].ToString().Trim();
            //submitToManagerModel.str_Txt_FinalOTRate = SubmitToManager_Data["P11"].ToString().Trim();
            submitToManagerModel.str_Btn_SumitToManager_Action = SubmitToManager_Data["P12"].ToString().Trim();
            submitToManagerModel.str_Btn_SumitToManager_Action_Confirm = SubmitToManager_Data["P13"].ToString().Trim();
            submitToManagerModel.str_Btn_SumitToManager_Action_Confirm_OK = SubmitToManager_Data["P14"].ToString().Trim();
            return submitToManagerModel;
        }

        public SubmitToManOfferToHireModel GetSubmitToManOfferToHireData(DataRow OfferToHire_Data)
        {
            SubmitToManOfferToHireModel submitToManOfferToHireModel = new SubmitToManOfferToHireModel();
            submitToManOfferToHireModel.strClientName = OfferToHire_Data["P3"].ToString().Trim();
            submitToManOfferToHireModel.strMainMenuLink = OfferToHire_Data["P4"].ToString().Trim();
            submitToManOfferToHireModel.strSubMenuLink = OfferToHire_Data["P5"].ToString().Trim();
            submitToManOfferToHireModel.str_Link_ReqNumber = OfferToHire_Data["P6"].ToString().Trim();
            submitToManOfferToHireModel.str_Link_ActionList_ViewCandidates = OfferToHire_Data["P7"].ToString().Trim();
            submitToManOfferToHireModel.str_CandidateName = OfferToHire_Data["P8"].ToString().Trim();
            submitToManOfferToHireModel.str_Link_ActionList_OfferToHire = OfferToHire_Data["P17"].ToString().Trim();
            submitToManOfferToHireModel.str_Btn_OfferToHire_Continue = OfferToHire_Data["P18"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_ProposeDifferentRate = OfferToHire_Data["P19"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_Proposebillrate = OfferToHire_Data["P20"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_Proposeotbillrate = OfferToHire_Data["P21"].ToString().Trim();
            submitToManOfferToHireModel.str_Select_dayID = OfferToHire_Data["P22"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_weeklyRegHoursNTE = OfferToHire_Data["P23"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_weeklyOTHoursNTE = OfferToHire_Data["P24"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_yearlyRegHoursNTE = OfferToHire_Data["P25"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_totalContractValue = OfferToHire_Data["P26"].ToString().Trim();
            submitToManOfferToHireModel.str_RadioButton_Emailwithcontractusage = OfferToHire_Data["P27"].ToString().Trim();
            submitToManOfferToHireModel.str_Select_ddemailschedule = OfferToHire_Data["P28"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_PrefStartdate = OfferToHire_Data["P29"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_enddate = OfferToHire_Data["P30"].ToString().Trim();
            submitToManOfferToHireModel.str_AddListTxt_txtTimecardApprover = OfferToHire_Data["P31"].ToString().Trim();
            submitToManOfferToHireModel.str_DeleteListTxt_txtTimecardApprover = OfferToHire_Data["P32"].ToString().Trim();
            submitToManOfferToHireModel.str_AddListTxt_ChargeNumbers = OfferToHire_Data["P33"].ToString().Trim();
            submitToManOfferToHireModel.str_DeleteListTxt_ChargeNumbers = OfferToHire_Data["P34"].ToString().Trim();
            submitToManOfferToHireModel.str_AddListTxt_GLNumbers = OfferToHire_Data["P35"].ToString().Trim();
            submitToManOfferToHireModel.str_DeleteListTxt_GLNumbers = OfferToHire_Data["P36"].ToString().Trim();
            submitToManOfferToHireModel.str_Btn_OfferToHire_Submit = OfferToHire_Data["P37"].ToString().Trim();
            submitToManOfferToHireModel.str_Btn_OfferToHire_Submit_Confirm = OfferToHire_Data["P38"].ToString().Trim();
            submitToManOfferToHireModel.str_Btn_OfferToHire_Submit_Confirm_Ok = OfferToHire_Data["P39"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_FinancialNumber = OfferToHire_Data["P15"].ToString().Trim();
            submitToManOfferToHireModel.str_typehead_FinancialNumber_financialNumber = OfferToHire_Data["P15"].ToString().Trim();
            submitToManOfferToHireModel.str_select_GLBusinessUnit_chargeGLId = OfferToHire_Data["P75"].ToString().Trim();
            submitToManOfferToHireModel.str_Typeahead_Account_chargeCostCenterId = OfferToHire_Data["P76"].ToString().Trim();
            submitToManOfferToHireModel.str_Typeahead_OperatingUnit_chargeProfitCenterId = OfferToHire_Data["P77"].ToString().Trim();
            submitToManOfferToHireModel.str_Typeahead_DepartmentID_chargedeptNumber = OfferToHire_Data["P78"].ToString().Trim();
            submitToManOfferToHireModel.str_Typeahead_ProjectID_chargeProjectId = OfferToHire_Data["P79"].ToString().Trim();
            submitToManOfferToHireModel.str_Typeahead_WorkID_chargeprogramId = OfferToHire_Data["P80"].ToString().Trim();
            submitToManOfferToHireModel.str_select_Resource_chargespendLevelId = OfferToHire_Data["P81"].ToString().Trim();

            //Added by manjusha
            submitToManOfferToHireModel.str_Txt_Billrate_Supplierbillrate = OfferToHire_Data["P82"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_numberofhours_offertoHire = OfferToHire_Data["P83"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_numberofResources_offertoHire = OfferToHire_Data["P77"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_Estimatedcontract_offertoHire = OfferToHire_Data["P84"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_numberofDays_offertoHire = OfferToHire_Data["P85"].ToString().Trim();

            //Repository
            //Identified
            submitToManOfferToHireModel.str_Txt_payrate_ProposepayrateForMarkup = OfferToHire_Data["P90"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_OTpayrate_ProposeotpayrateForMarkup = OfferToHire_Data["P91"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_payratemarkup_supplierpayratemarkup = OfferToHire_Data["P92"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_BillRate_ProposebillrateForMarkup = OfferToHire_Data["P93"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_OTBillRate_ProposeotbillrateForMarkup = OfferToHire_Data["P94"].ToString().Trim();
            submitToManOfferToHireModel.str_Select_ChargeNumberTypes = OfferToHire_Data["P95"].ToString().Trim();
            submitToManOfferToHireModel.str_Typeahead_ChargeNumbers_txtChargeNo = OfferToHire_Data["P96"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_LastName_lastname = OfferToHire_Data["P97"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_FirstName_firstname = OfferToHire_Data["P98"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_MiddleName_middlename = OfferToHire_Data["P99"].ToString().Trim();
            submitToManOfferToHireModel.str_Select_Suffix_nameSuffix = OfferToHire_Data["P100"].ToString().Trim();
            submitToManOfferToHireModel.str_btn_UploadResume_uploadResume = OfferToHire_Data["P101"].ToString().Trim();
            submitToManOfferToHireModel.str_Radiobutton_Retiree_retiredEmployee = OfferToHire_Data["P102"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_RetireeDetails_retiredEmployeeDetails = OfferToHire_Data["P103"].ToString().Trim();
            submitToManOfferToHireModel.str_radiobutton_FormerEmployee_exEmployee = OfferToHire_Data["P104"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_FormerEmployeeDetails_exEmployeeDetails = OfferToHire_Data["P105"].ToString().Trim();
            submitToManOfferToHireModel.str_radiobutton_FormerIntern_exIntern = OfferToHire_Data["P106"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_FormerInternDetails_exInternDetails = OfferToHire_Data["P107"].ToString().Trim();
            submitToManOfferToHireModel.str_radiobutton_FormerContractor_exContractor = OfferToHire_Data["P108"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_FormerContractorDetails_exContractorDetails = OfferToHire_Data["P109"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_Justification_soleJustificationDescription = OfferToHire_Data["P110"].ToString().Trim();
            submitToManOfferToHireModel.str_btn_UploadJustification_uploadJustification = OfferToHire_Data["P111"].ToString().Trim();
            submitToManOfferToHireModel.str_Typeahead_Supplier_supplierName = OfferToHire_Data["P112"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_ContactLastName_recruiterLastName = OfferToHire_Data["P113"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_ContactFirstName_recruiterFirstName = OfferToHire_Data["P114"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_Phone_workPhone = OfferToHire_Data["P115"].ToString().Trim();
            submitToManOfferToHireModel.str_Txt_Email_workEmail = OfferToHire_Data["P116"].ToString().Trim();

            submitToManOfferToHireModel.str_Radiobuttion_FormerUSGovtMilitaryEmployee_exGovMilEmployee = OfferToHire_Data["P117"].ToString().Trim(); 
            submitToManOfferToHireModel.str_Txt_FormerUSGovtMilitaryEmployeeDetails_exGovMilEmployeeDetails = OfferToHire_Data["P118"].ToString().Trim();

            return submitToManOfferToHireModel;
        }

        //public SubmitToManOfferToHireMethodModel GetSubmitToManOfferToHireMethodData(DataRow OfferToHire_Data)
        //{
        //    SubmitToManOfferToHireMethodModel submitToManOfferToHireMethodModel = new SubmitToManOfferToHireMethodModel();
        //    submitToManOfferToHireMethodModel.strClientName = OfferToHire_Data["P3"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.strMainMenuLink = OfferToHire_Data["P4"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.strSubMenuLink = OfferToHire_Data["P5"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_Link_ReqNumber = OfferToHire_Data["P6"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_Link_ActionList_ViewCandidates = OfferToHire_Data["P7"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_CandidateName = OfferToHire_Data["P8"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_Link_ActionList_OfferToHire = OfferToHire_Data["P17"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_Btn_OfferToHire_Continue = OfferToHire_Data["P18"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_Txt_ProposeDifferentRate = OfferToHire_Data["P19"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_Txt_Proposebillrate = OfferToHire_Data["P20"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_Txt_Proposeotbillrate = OfferToHire_Data["P21"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_Select_dayID = OfferToHire_Data["P22"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_Txt_weeklyRegHoursNTE = OfferToHire_Data["P23"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_Txt_weeklyOTHoursNTE = OfferToHire_Data["P24"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_Txt_yearlyRegHoursNTE = OfferToHire_Data["P25"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_Txt_totalContractValue = OfferToHire_Data["P26"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_RadioButton_Emailwithcontractusage = OfferToHire_Data["P27"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_Select_ddemailschedule = OfferToHire_Data["P28"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_Txt_PrefStartdate = OfferToHire_Data["P29"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_Txt_enddate = OfferToHire_Data["P30"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_AddListTxt_txtTimecardApprover = OfferToHire_Data["P31"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_DeleteListTxt_txtTimecardApprover = OfferToHire_Data["P32"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_AddListTxt_ChargeNumbers = OfferToHire_Data["P33"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_DeleteListTxt_ChargeNumbers = OfferToHire_Data["P34"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_AddListTxt_GLNumbers = OfferToHire_Data["P33"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_DeleteListTxt_GLNumbers = OfferToHire_Data["P34"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_Btn_OfferToHire_Submit = OfferToHire_Data["P37"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_Btn_OfferToHire_Submit_Confirm = OfferToHire_Data["P38"].ToString().Trim();
        //    submitToManOfferToHireMethodModel.str_Btn_OfferToHire_Submit_Confirm_Ok = OfferToHire_Data["P39"].ToString().Trim();
        //    return submitToManOfferToHireMethodModel;
        //}

        //public SubmitToManExtendOfferModel GetSubmitToManExtendOfferData(DataRow ExtendOffer_Data)
        //{
        //    SubmitToManExtendOfferModel submitToManExtendOfferModel = new SubmitToManExtendOfferModel();
        //    submitToManExtendOfferModel.strClientName = ExtendOffer_Data["P3"].ToString().Trim();
        //    submitToManExtendOfferModel.strMainMenuLink = ExtendOffer_Data["P4"].ToString().Trim();
        //    submitToManExtendOfferModel.strSubMenuLink = ExtendOffer_Data["P5"].ToString().Trim();
        //    submitToManExtendOfferModel.str_Link_ReqNumber = ExtendOffer_Data["P6"].ToString().Trim();
        //    submitToManExtendOfferModel.str_Link_ActionList_ViewCandidates = ExtendOffer_Data["P7"].ToString().Trim();
        //    submitToManExtendOfferModel.str_Link_ActionList_ExperienceValidation = ExtendOffer_Data["P42"].ToString().Trim();
        //    submitToManExtendOfferModel.str_CandidateName = ExtendOffer_Data["P8"].ToString().Trim();
        //    submitToManExtendOfferModel.str_Txt_Years = ExtendOffer_Data["P44"].ToString().Trim();
        //    submitToManExtendOfferModel.str_Link_ActionList_ExtendOffer = ExtendOffer_Data["P44"].ToString().Trim();
        //    submitToManExtendOfferModel.str_Txt_Months = ExtendOffer_Data["P45"].ToString().Trim();
        //    //   submitToManExtendOfferModel.str_Txt_ProposedSupplierBillRate = ExtendOffer_Data["P12"].ToString().Trim();
        //    submitToManExtendOfferModel.str_Txt_proposedRegPayRate = ExtendOffer_Data["P45"].ToString().Trim();   //Proposed Pay Rate
        //    submitToManExtendOfferModel.str_Txt_proposedOTPayRate = ExtendOffer_Data["P46"].ToString().Trim();//Proposed OT Pay Rate
        //    submitToManExtendOfferModel.str_Txt_payRateMarkup = ExtendOffer_Data["P47"].ToString().Trim();//Pay Rate Markup%:
        //    submitToManExtendOfferModel.str_Txt_proposedRegBillRate = ExtendOffer_Data["P48"].ToString().Trim();//Proposed Supplier Bill Rate:
        //    submitToManExtendOfferModel.str_Txt_proposedOTBillRate = ExtendOffer_Data["P49"].ToString().Trim(); //Proposed Supplier OT Bill Rate:
        //    submitToManExtendOfferModel.str_Txt_finalRegBillRate = ExtendOffer_Data["P50"].ToString().Trim();//Final Bill Rate: 
        //    submitToManExtendOfferModel.str_Txt_finalOTBillRate = ExtendOffer_Data["P51"].ToString().Trim();//Final OT Bill Rate:  
        //    submitToManExtendOfferModel.str_Txt_weeklyRegHoursNTE = ExtendOffer_Data["P52"].ToString().Trim();
        //    submitToManExtendOfferModel.str_Txt_weeklyOTHoursNTE = ExtendOffer_Data["P53"].ToString().Trim();
        //    submitToManExtendOfferModel.str_Txt_yearlyRegHoursNTE = ExtendOffer_Data["P54"].ToString().Trim();
        //    submitToManExtendOfferModel.str_Txt_totalContractValue = ExtendOffer_Data["P55"].ToString().Trim();
        //    submitToManExtendOfferModel.str_Txt_PrefStartdate = ExtendOffer_Data["P56"].ToString().Trim();
        //    submitToManExtendOfferModel.str_Txt_enddate = ExtendOffer_Data["P57"].ToString().Trim();
        //    submitToManExtendOfferModel.str_AddListTxt_txtTimecardApprover = ExtendOffer_Data["P58"].ToString().Trim();
        //    submitToManExtendOfferModel.str_DeleteListTxt_txtTimecardApprover = ExtendOffer_Data["P59"].ToString().Trim();
        //    submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers = ExtendOffer_Data["P60"].ToString().Trim();
        //    submitToManExtendOfferModel.str_DeleteListTxt_ChargeNumbers = ExtendOffer_Data["P61"].ToString().Trim();
        //    submitToManExtendOfferModel.str_AddListTxt_GLNumbers = ExtendOffer_Data["P62"].ToString().Trim();
        //    submitToManExtendOfferModel.str_DeleteListTxt_GLNumbers = ExtendOffer_Data["P63"].ToString().Trim();
        //    submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit = ExtendOffer_Data["P64"].ToString().Trim();
        //    submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit_Confirm = ExtendOffer_Data["P65"].ToString().Trim();
        //    submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit_Confirm_Ok = ExtendOffer_Data["P66"].ToString().Trim();
        //    submitToManExtendOfferModel.str_Txt_poNumber = ExtendOffer_Data["P67"].ToString().Trim();
        //    submitToManExtendOfferModel.str_Txt_ProposeDifferentRate = ExtendOffer_Data["P75"].ToString().Trim();

        //    submitToManExtendOfferModel.str_Link_Withdrawoffer = ExtendOffer_Data["P68"].ToString().Trim();
        //    submitToManExtendOfferModel.str_Select_WithdrawofferReason = ExtendOffer_Data["P69"].ToString().Trim();
        //    submitToManExtendOfferModel.str_Txt_WithdrawofferReasoncomment = ExtendOffer_Data["P70"].ToString().Trim();
        //    submitToManExtendOfferModel.str_Button_Withdrawoffer = ExtendOffer_Data["P71"].ToString().Trim();
        //    submitToManExtendOfferModel.str_Button_Withdrawoffer_yes = ExtendOffer_Data["P72"].ToString().Trim();
        //    submitToManExtendOfferModel.str_Button_Withdrawoffer_ok = ExtendOffer_Data["P73"].ToString().Trim();
        //    //submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit = ExtendOffer_Data["P66"].ToString().Trim();
        //    //submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit_Confirm = ExtendOffer_Data["P67"].ToString().Trim();
        //    //submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit_Confirm_Ok = ExtendOffer_Data["P68"].ToString().Trim();

        //    return submitToManExtendOfferModel;
        //}

        //public SubmitToManExtendOfferMethodModel GetSubmitToManExtendOfferMethodData(DataRow ExtendOffer_Data)
        //{
        //    SubmitToManExtendOfferMethodModel submitToManExtendOfferMethodModel = new SubmitToManExtendOfferMethodModel();
        //    submitToManExtendOfferMethodModel.strClientName = ExtendOffer_Data["P3"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.strMainMenuLink = ExtendOffer_Data["P4"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.strSubMenuLink = ExtendOffer_Data["P5"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.str_Link_ReqNumber = ExtendOffer_Data["P6"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.str_Link_ActionList_ViewCandidates = ExtendOffer_Data["P42"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.str_Link_ActionList_ExperienceValidation = ExtendOffer_Data["P42"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.str_CandidateName = ExtendOffer_Data["P8"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.str_Txt_Years = ExtendOffer_Data["P44"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.str_Link_ActionList_ExtendOffer = ExtendOffer_Data["P44"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.str_Txt_Months = ExtendOffer_Data["P45"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.str_Txt_proposedRegPayRate = ExtendOffer_Data["P45"].ToString().Trim();   //Proposed Pay Rate
        //    submitToManExtendOfferMethodModel.str_Txt_proposedOTPayRate = ExtendOffer_Data["P46"].ToString().Trim();//Proposed OT Pay Rate
        //    submitToManExtendOfferMethodModel.str_Txt_payRateMarkup = ExtendOffer_Data["P47"].ToString().Trim();//Pay Rate Markup%:
        //    submitToManExtendOfferMethodModel.str_Txt_proposedRegBillRate = ExtendOffer_Data["P48"].ToString().Trim();//Proposed Supplier Bill Rate:
        //    submitToManExtendOfferMethodModel.str_Txt_proposedOTBillRate = ExtendOffer_Data["P49"].ToString().Trim(); //Proposed Supplier OT Bill Rate:
        //    submitToManExtendOfferMethodModel.str_Txt_finalRegBillRate = ExtendOffer_Data["P50"].ToString().Trim();//Final Bill Rate: 
        //    submitToManExtendOfferMethodModel.str_Txt_finalOTBillRate = ExtendOffer_Data["P51"].ToString().Trim();//Final OT Bill Rate:  
        //    submitToManExtendOfferMethodModel.str_Txt_weeklyRegHoursNTE = ExtendOffer_Data["P52"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.str_Txt_weeklyOTHoursNTE = ExtendOffer_Data["P53"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.str_Txt_yearlyRegHoursNTE = ExtendOffer_Data["P54"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.str_Txt_totalContractValue = ExtendOffer_Data["P55"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.str_Txt_PrefStartdate = ExtendOffer_Data["P56"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.str_Txt_enddate = ExtendOffer_Data["P57"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.str_AddListTxt_txtTimecardApprover = ExtendOffer_Data["P58"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.str_DeleteListTxt_txtTimecardApprover = ExtendOffer_Data["P59"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.str_AddListTxt_ChargeNumbers = ExtendOffer_Data["P60"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.str_DeleteListTxt_ChargeNumbers = ExtendOffer_Data["P61"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.str_AddListTxt_GLNumbers = ExtendOffer_Data["P62"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.str_DeleteListTxt_GLNumbers = ExtendOffer_Data["P63"].ToString().Trim();
        //    //  submitToManExtendOfferMethodModel.str_Txt_ProposedSupplierOTBillRate = ExtendOffer_Data["P14"].ToString().Trim();
        //    //  submitToManExtendOfferMethodModel.str_Txt_proposedRegBillRate = ExtendOffer_Data["P14"].ToString().Trim();
        //    //  submitToManExtendOfferMethodModel.str_Txt_proposedOTBillRate = ExtendOffer_Data["P14"].ToString().Trim();
        //    //   submitToManExtendOfferMethodModel.str_Txt_Proposebillrate = ExtendOffer_Data["P15"].ToString().Trim();
        //    //  submitToManExtendOfferMethodModel.str_Txt_finalRegBillRate = ExtendOffer_Data["P15"].ToString().Trim();
        //    // submitToManExtendOfferMethodModel.str_Txt_proposedOTPayRate = ExtendOffer_Data["P15""].ToString().Trim();
        //    //   submitToManExtendOfferMethodModel.str_Txt_Proposeotbillrate = ExtendOffer_Data["P16"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.str_Btn_ExtendOffer_Submit = ExtendOffer_Data["P64"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.str_Btn_ExtendOffer_Submit_Confirm = ExtendOffer_Data["P65"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.str_Btn_ExtendOffer_Submit_Confirm_Ok = ExtendOffer_Data["P66"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.str_Txt_poNumber = ExtendOffer_Data["P67"].ToString().Trim();
        //    submitToManExtendOfferMethodModel.str_Txt_ProposeDifferentRate = ExtendOffer_Data["P75"].ToString().Trim();

        //    return submitToManExtendOfferMethodModel;
        //}

        //public CreateTimesheetModel GetCreateTimesheetData(DataRow CreateTimesheet_Data)
        //{
        //    CreateTimesheetModel createTimesheetModel = new CreateTimesheetModel();
        //    createTimesheetModel.strTestCaseId = CreateTimesheet_Data["TestCaseID"].ToString().Trim();
        //    createTimesheetModel.strUserID = CreateTimesheet_Data["P1"].ToString().Trim();
        //    createTimesheetModel.strClientName = CreateTimesheet_Data["P3"].ToString().Trim();
        //    createTimesheetModel.strMainMenuLink = CreateTimesheet_Data["P4"].ToString().Trim();
        //    createTimesheetModel.strSubMenuLink = CreateTimesheet_Data["P5"].ToString().Trim();
        //    createTimesheetModel.str_Select_DefaultContent_CboWorkSchedule = CreateTimesheet_Data["P6"].ToString().Trim();
        //    createTimesheetModel.str_chkbox_DefaultContent_ChkZeroHours = CreateTimesheet_Data["P7"].ToString().Trim();
        //    createTimesheetModel.str_Task_Date = CreateTimesheet_Data["P8"].ToString().Trim();
        //    createTimesheetModel.str_ExcelSheet_TimeSheetDataName = CreateTimesheet_Data["P9"].ToString().Trim();
        //    createTimesheetModel.str_Unitnumberupdate = CreateTimesheet_Data["P10"].ToString().Trim();
        //    createTimesheetModel.str_Select_DefaultContent_CboSelect = CreateTimesheet_Data["P11"].ToString().Trim();
        //    return createTimesheetModel;
        //}

        //public TimesheetSettingsModel GetSettingsTimesheetData(DataRow SettingsTimesheet_Data)
        //{

        //    TimesheetSettingsModel TimesheetSettingsModel = new TimesheetSettingsModel();
        //    TimesheetSettingsModel.strTestCaseId = SettingsTimesheet_Data["TestCaseID"].ToString().Trim();
        //    TimesheetSettingsModel.strUserID = SettingsTimesheet_Data["P3"].ToString().Trim();
        //    TimesheetSettingsModel.strClientName = SettingsTimesheet_Data["P5"].ToString().Trim();
        //    TimesheetSettingsModel.strMainMenuLink = SettingsTimesheet_Data["P6"].ToString().Trim();
        //    TimesheetSettingsModel.strSubMenuLink = SettingsTimesheet_Data["P7"].ToString().Trim();
        //    TimesheetSettingsModel.str_Select_DefaultContent_CboWorkSchedule = SettingsTimesheet_Data["P8"].ToString().Trim();
        //    TimesheetSettingsModel.str_chkbox_DefaultContent_ChkZeroHours = SettingsTimesheet_Data["P9"].ToString().Trim();
        //    TimesheetSettingsModel.str_Task_Date = SettingsTimesheet_Data["P10"].ToString().Trim();
        //    TimesheetSettingsModel.str_ExcelSheet_TimeSheetDataName = SettingsTimesheet_Data["P11"].ToString().Trim();
        //    return TimesheetSettingsModel;
        //}


        //public CreateTimesheetMspModel GetcreateTimesheetMspData(DataRow CreateTimesheetMSP_Data)
        //{
        //    CreateTimesheetMspModel createTimesheetMspModel = new CreateTimesheetMspModel();
        //    createTimesheetMspModel.strTestCaseId = CreateTimesheetMSP_Data["TestCaseID"].ToString().Trim();
        //    createTimesheetMspModel.strUserID = CreateTimesheetMSP_Data["P3"].ToString().Trim();
        //    createTimesheetMspModel.strClientName = CreateTimesheetMSP_Data["P5"].ToString().Trim();
        //    createTimesheetMspModel.strMainMenuLink = CreateTimesheetMSP_Data["P6"].ToString().Trim();
        //    createTimesheetMspModel.strSubMenuLink = CreateTimesheetMSP_Data["P7"].ToString().Trim();
        //    createTimesheetMspModel.str_Link_WorkListAction = CreateTimesheetMSP_Data["P8"].ToString().Trim();
        //    createTimesheetMspModel.str_Select_DefaultContent_CboSelect = CreateTimesheetMSP_Data["P9"].ToString().Trim();
        //    createTimesheetMspModel.str_Txt_DefaultContent_TxtSAENumber = CreateTimesheetMSP_Data["P10"].ToString().Trim();
        //    createTimesheetMspModel.str_Txt_DefaultContent_TxtFirstName = CreateTimesheetMSP_Data["P11"].ToString().Trim();
        //    createTimesheetMspModel.str_Txt_DefaultContent_TxtLastName = CreateTimesheetMSP_Data["P12"].ToString().Trim();
        //    createTimesheetMspModel.str_Txt_DefaultContent_TxtEmailID = CreateTimesheetMSP_Data["P13"].ToString().Trim();
        //    createTimesheetMspModel.str_Tyehead_Txt_TxtApprover = CreateTimesheetMSP_Data["P14"].ToString().Trim();
        //    createTimesheetMspModel.str_Btn_DefaultContent_btnSearch = CreateTimesheetMSP_Data["P15"].ToString().Trim();
        //    createTimesheetMspModel.str_Btn_DefaultContent_btnClearSearch = CreateTimesheetMSP_Data["P16"].ToString().Trim();
        //    createTimesheetMspModel.str_Txt_Approver_Filter_Awaiting = CreateTimesheetMSP_Data["P17"].ToString().Trim();
        //    createTimesheetMspModel.str_Link_ActionList = CreateTimesheetMSP_Data["P18"].ToString().Trim();
        //    createTimesheetMspModel.str_Select_DefaultContent_CboWorkSchedule = CreateTimesheetMSP_Data["P19"].ToString().Trim();
        //    createTimesheetMspModel.str_chkbox_DefaultContent_ChkZeroHours = CreateTimesheetMSP_Data["P20"].ToString().Trim();
        //    createTimesheetMspModel.str_Task_Date = CreateTimesheetMSP_Data["P21"].ToString().Trim();
        //    createTimesheetMspModel.str_ExcelSheet_TimeSheetDataName = CreateTimesheetMSP_Data["P22"].ToString().Trim();
        //    return createTimesheetMspModel;
        //}

        //public EditOrRejectTimesheetModel GeteditOrRejectTimesheetData(DataRow Edit_RejectTimesheet_Data)
        //{
        //    EditOrRejectTimesheetModel editOrRejectTimesheetModel = new EditOrRejectTimesheetModel();
        //    editOrRejectTimesheetModel.strTestCaseId = Edit_RejectTimesheet_Data["TestCaseID"].ToString().Trim();
        //    editOrRejectTimesheetModel.strUserID = Edit_RejectTimesheet_Data["P3"].ToString().Trim();
        //    editOrRejectTimesheetModel.strClientName = Edit_RejectTimesheet_Data["P5"].ToString().Trim();
        //    editOrRejectTimesheetModel.strMainMenuLink = Edit_RejectTimesheet_Data["P6"].ToString().Trim();
        //    editOrRejectTimesheetModel.strSubMenuLink = Edit_RejectTimesheet_Data["P7"].ToString().Trim();
        //    editOrRejectTimesheetModel.str_Link_WorkListAction = Edit_RejectTimesheet_Data["P8"].ToString().Trim();
        //    editOrRejectTimesheetModel.str_Select_DefaultContent_CboSelect = Edit_RejectTimesheet_Data["P9"].ToString().Trim();
        //    editOrRejectTimesheetModel.str_Date_DefaultContent_TxtWeekendFrom = Edit_RejectTimesheet_Data["P10"].ToString().Trim();
        //    editOrRejectTimesheetModel.str_Date_DefaultContent_TxtWeekendTo = Edit_RejectTimesheet_Data["P11"].ToString().Trim();
        //    editOrRejectTimesheetModel.str_Select_DefaultContent_CboStatus = Edit_RejectTimesheet_Data["P12"].ToString().Trim();
        //    editOrRejectTimesheetModel.str_Select_DefaultContent_CboNoRecords = Edit_RejectTimesheet_Data["P13"].ToString().Trim();
        //    editOrRejectTimesheetModel.str_Btn_DefaultContent_btnSearch = Edit_RejectTimesheet_Data["P14"].ToString().Trim();
        //    editOrRejectTimesheetModel.str_txt_filtertxt = Edit_RejectTimesheet_Data["P15"].ToString().Trim();
        //    editOrRejectTimesheetModel.str_date_WeekEndDate = Edit_RejectTimesheet_Data["P16"].ToString().Trim();
        //    editOrRejectTimesheetModel.str_Link_ActionList = Edit_RejectTimesheet_Data["P17"].ToString().Trim();
        //    // editOrRejectTimesheetModel.str_Data_EditTimeSheet = Edit_RejectTimesheet_Data["P18"].ToString().Trim();
        //    // editOrRejectTimesheetModel.str_txt_TaskList = Edit_RejectTimesheet_Data["P20"].ToString().Trim();  
        //    editOrRejectTimesheetModel.str_ExcelSheet_TimeSheetDataName = Edit_RejectTimesheet_Data["P18"].ToString().Trim();
        //    editOrRejectTimesheetModel.str_Data_AddTask = Edit_RejectTimesheet_Data["P25"].ToString().Trim();
        //    editOrRejectTimesheetModel.str_btn_SubmitTimesheet = Edit_RejectTimesheet_Data["P26"].ToString().Trim();
        //    editOrRejectTimesheetModel.str_btn_SubmitTimesheet_ConfirmMsgbox = Edit_RejectTimesheet_Data["P27"].ToString().Trim();
        //    editOrRejectTimesheetModel.str_btn_SubmitTimesheet_ConfirmMsgbox_Yes = Edit_RejectTimesheet_Data["P28"].ToString().Trim();
        //    return editOrRejectTimesheetModel;
        //}

        //public RejectTimeSheetMSPModel GetRejectTimeSheetMSPData(DataRow RejectTimesheetMSP_Data)
        //{
        //    RejectTimeSheetMSPModel rejectTimeSheetMSPModel = new RejectTimeSheetMSPModel();
        //    rejectTimeSheetMSPModel.strClientName = RejectTimesheetMSP_Data["P3"].ToString().Trim();
        //    rejectTimeSheetMSPModel.strMainMenuLink = RejectTimesheetMSP_Data["P4"].ToString().Trim();
        //    rejectTimeSheetMSPModel.strSubMenuLink = RejectTimesheetMSP_Data["P5"].ToString().Trim();
        //    rejectTimeSheetMSPModel.str_Link_WorkListAction = RejectTimesheetMSP_Data["P6"].ToString().Trim();
        //    rejectTimeSheetMSPModel.str_Select_DefaultContent_CboSelect = RejectTimesheetMSP_Data["P7"].ToString().Trim();
        //    rejectTimeSheetMSPModel.str_Txt_DefaultContent_TxtName = RejectTimesheetMSP_Data["P8"].ToString().Trim();
        //    rejectTimeSheetMSPModel.str_DataTxt_DefaultContent_TxtWeekendFrom = RejectTimesheetMSP_Data["P9"].ToString().Trim();
        //    rejectTimeSheetMSPModel.str_DateTxt_DefaultContent_TxtWeekendTo = RejectTimesheetMSP_Data["P10"].ToString().Trim();
        //    rejectTimeSheetMSPModel.str_Select_DefaultContent_CboStatus = RejectTimesheetMSP_Data["P11"].ToString().Trim();
        //    rejectTimeSheetMSPModel.str_Select_DefaultContent_CboNoRecords = RejectTimesheetMSP_Data["P12"].ToString().Trim();
        //    rejectTimeSheetMSPModel.str_Btn_DefaultContent_btnSearch = RejectTimesheetMSP_Data["P13"].ToString().Trim();
        //    rejectTimeSheetMSPModel.str_Btn_DefaultContent_btnClearSearch = RejectTimesheetMSP_Data["P14"].ToString().Trim();
        //    rejectTimeSheetMSPModel.str_Txt_Approver_Filter_Awaiting = RejectTimesheetMSP_Data["P15"].ToString().Trim();
        //    rejectTimeSheetMSPModel.str_TxtCompare_WeekendingDates = RejectTimesheetMSP_Data["P16"].ToString().Trim();
        //    rejectTimeSheetMSPModel.str_Link_ActionList = RejectTimesheetMSP_Data["P17"].ToString().Trim();
        //    rejectTimeSheetMSPModel.str_Txt_DefaultContent_TxtMultilineDenied = RejectTimesheetMSP_Data["P18"].ToString().Trim();
        //    rejectTimeSheetMSPModel.str_Btn_Confirm = RejectTimesheetMSP_Data["P19"].ToString().Trim();
        //    rejectTimeSheetMSPModel.str_Btn_OK = RejectTimesheetMSP_Data["P20"].ToString().Trim();
        //    rejectTimeSheetMSPModel.str_DDL_RejectReason = RejectTimesheetMSP_Data["P21"].ToString().Trim();
        //    rejectTimeSheetMSPModel.str_Txt_RejectComment = RejectTimesheetMSP_Data["P22"].ToString().Trim();


        //    return rejectTimeSheetMSPModel;
        //}

        //public CreateExpenseModel GetCreateExpenseData(DataRow Create_Expense)
        //{
        //    CreateExpenseModel createExpenseModel = new CreateExpenseModel();
        //    createExpenseModel.strTestCaseId = Create_Expense["TestCaseID"].ToString().Trim();
        //    createExpenseModel.str_BrowserName = Create_Expense["P1"].ToString().Trim();
        //    createExpenseModel.strUserID = Create_Expense["P3"].ToString().Trim();
        //    createExpenseModel.strClientName = Create_Expense["P5"].ToString().Trim();
        //    createExpenseModel.strMainMenuLink = Create_Expense["P6"].ToString().Trim();
        //    createExpenseModel.strSubMenuLink = Create_Expense["P7"].ToString().Trim();
        //    createExpenseModel.str_Txt_CW = Create_Expense["P8"].ToString().Trim();
        //    createExpenseModel.str_Select_DDLCWs = Create_Expense["P9"].ToString().Trim();
        //    createExpenseModel.str_Select_txtChargeNumber = Create_Expense["P10"].ToString().Trim();
        //    createExpenseModel.str_Select_txtCurrency = Create_Expense["P11"].ToString().Trim();
        //    createExpenseModel.str_Txt_txtTitle = Create_Expense["P12"].ToString().Trim();
        //    createExpenseModel.str_Date_txtDateFrom = Create_Expense["P13"].ToString().Trim();
        //    createExpenseModel.str_Date_txtDateTo = Create_Expense["P14"].ToString().Trim();
        //    createExpenseModel.str_Txt_txtPurpose = Create_Expense["P15"].ToString().Trim();
        //    createExpenseModel.str_Btn_Yes_Action = Create_Expense["P17"].ToString().Trim();
        //    createExpenseModel.str_Btn_Ok_Action = Create_Expense["P18"].ToString().Trim();
        //    createExpenseModel.str_Action_List_AddItem = Create_Expense["P20"].ToString().Trim();
        //    createExpenseModel.str_Select_AddItem_txtChargeNumber = Create_Expense["P21"].ToString().Trim();
        //    createExpenseModel.str_Date_txtExpenseDate = Create_Expense["P22"].ToString().Trim();
        //    createExpenseModel.str_Select_ExpeneseCategory = Create_Expense["P23"].ToString().Trim();
        //    createExpenseModel.str_Select_expensetype = Create_Expense["P24"].ToString().Trim();
        //    createExpenseModel.str_Select_paytype = Create_Expense["P25"].ToString().Trim();
        //    createExpenseModel.str_Txt_txtQuantity = Create_Expense["P26"].ToString().Trim();
        //    createExpenseModel.str_Select_AddItem_txtCurrency = Create_Expense["P27"].ToString().Trim();
        //    createExpenseModel.str_Radio_Reimbursable = Create_Expense["P28"].ToString().Trim();
        //    createExpenseModel.str_Txt_txtAmount = Create_Expense["P31"].ToString().Trim();
        //    createExpenseModel.str_Txt_txtDescription = Create_Expense["P30"].ToString().Trim();
        //    createExpenseModel.str_Btn_Submit_Action = Create_Expense["P32"].ToString().Trim();
        //    createExpenseModel.str_Btn_DYes_Action = Create_Expense["P33"].ToString().Trim();
        //    createExpenseModel.str_Btn_DOk_Action = Create_Expense["P34"].ToString().Trim();
        //    createExpenseModel.str_Action_List_Upload = Create_Expense["P36"].ToString().Trim();
        //    createExpenseModel.str_Txt_receiptUpload = Create_Expense["P37"].ToString().Trim();
        //    createExpenseModel.str_Txt_UploadFilePath = Create_Expense["P38"].ToString().Trim();
        //    createExpenseModel.str_Action_List_UploadDoc = Create_Expense["P43"].ToString().Trim();
        //    createExpenseModel.str_Txt_Doc_receiptUpload = Create_Expense["P44"].ToString().Trim();
        //    createExpenseModel.str_Txt_Doc_UploadFilePath = Create_Expense["P45"].ToString().Trim();
        //    createExpenseModel.str_Btn_Upload = Create_Expense["P46"].ToString().Trim();
        //    createExpenseModel.str_Btn_Agree = Create_Expense["P47"].ToString().Trim();
        //    createExpenseModel.strSubMenuLink_SubmittoMSP = Create_Expense["P48"].ToString().Trim();
        //    createExpenseModel.str_Btn_SubmittoMSP = Create_Expense["P49"].ToString().Trim();
        //    createExpenseModel.str_Btn_SendReminder = Create_Expense["P50"].ToString().Trim();
        //    createExpenseModel.str_Btn_MSPConfim_Yes = Create_Expense["P51"].ToString().Trim();
        //    createExpenseModel.str_Btn_MSPConfim_Ok = Create_Expense["P52"].ToString().Trim();
        //    createExpenseModel.strSubMenuLink_Approve = Create_Expense["P53"].ToString().Trim();
        //    createExpenseModel.str_Txt_notes = Create_Expense["P54"].ToString().Trim();
        //    createExpenseModel.str_Btn_Approve = Create_Expense["P55"].ToString().Trim();
        //    createExpenseModel.str_Btn_Approve_Yes = Create_Expense["P56"].ToString().Trim();
        //    createExpenseModel.str_Btn_Approve_Ok = Create_Expense["P57"].ToString().Trim();
        //    createExpenseModel.strSubMenuLink_SubmittoCustomer = Create_Expense["P59"].ToString().Trim();

        //    createExpenseModel.str_Btn_SubmittoCustomer = Create_Expense["P60"].ToString().Trim();
        //    createExpenseModel.str_Btn_SubmittoCustomerConfim_Yes = Create_Expense["P61"].ToString().Trim();
        //    createExpenseModel.str_Btn_SubmittoCustomeronfim_Ok = Create_Expense["P62"].ToString().Trim();

        //    createExpenseModel.strSubMenuLink_CreateExpensePreApproval = Create_Expense["P66"].ToString().Trim();
        //    createExpenseModel.str_Txt_txtPreAppTitle = Create_Expense["P67"].ToString().Trim();


        //    createExpenseModel.str_Txt_txtDescription1 = Create_Expense["P71"].ToString().Trim();

        //    createExpenseModel.str_Txt_txtEstimatedAmount1 = Create_Expense["P72"].ToString().Trim();

        //    createExpenseModel.str_Txt_txtJustification = Create_Expense["P75"].ToString().Trim();

        //    createExpenseModel.str_Date_txtDateFrom_PreApproval = Create_Expense["P68"].ToString().Trim();
        //    createExpenseModel.str_Date_txtDateTo_PreApproval = Create_Expense["P69"].ToString().Trim();
        //    createExpenseModel.str_Select_AddItem_txtCurrency_PreApproval = Create_Expense["P70"].ToString().Trim();
        //    createExpenseModel.str_Btn_Yes_Action_PreApproval = Create_Expense["P78"].ToString().Trim();
        //    createExpenseModel.str_Btn_Ok_Action_PreApproval = Create_Expense["P79"].ToString().Trim();
        //    createExpenseModel.str_Action_List_SubmitforApproval = Create_Expense["P81"].ToString().Trim();
        //    createExpenseModel.str_Btn_Yes_Action_SubmitforApprPreApproval = Create_Expense["P82"].ToString().Trim();
        //    return createExpenseModel;
        //}
        ////GetApproveClientExpenseData
        //public ApproveClientExpenseModel GetApproveClientExpenseData(DataRow Approve_Client_Expense)
        //{
        //    // CreateExpenseModel createExpenseModel = new CreateExpenseModel();
        //    ApproveClientExpenseModel approveClientExpenseModel = new ApproveClientExpenseModel();
        //    approveClientExpenseModel.strTestCaseId = Approve_Client_Expense["TestCaseID"].ToString().Trim();
        //    //  approveClientExpenseModel.str_BrowserName = Approve_Client_Expense["P1"].ToString().Trim();
        //    approveClientExpenseModel.strUserID = Approve_Client_Expense["P1"].ToString().Trim();
        //    approveClientExpenseModel.strClientName = Approve_Client_Expense["P3"].ToString().Trim();
        //    approveClientExpenseModel.strMainMenuLink = Approve_Client_Expense["P4"].ToString().Trim();
        //    approveClientExpenseModel.strSubMenuLink = Approve_Client_Expense["P5"].ToString().Trim();
        //    approveClientExpenseModel.str_Txt_CW = Approve_Client_Expense["P6"].ToString().Trim();
        //    approveClientExpenseModel.str_ExpenseNumber = Approve_Client_Expense["P6"].ToString().Trim();
        //    approveClientExpenseModel.str_Select_DDLCWs = Approve_Client_Expense["P14"].ToString().Trim();
        //    approveClientExpenseModel.str_ExpenseApprover = Approve_Client_Expense["P7"].ToString().Trim();
        //    approveClientExpenseModel.strSubMenuLink_Approve = Approve_Client_Expense["P10"].ToString().Trim();
        //    approveClientExpenseModel.str_Btn_Approve = Approve_Client_Expense["P11"].ToString().Trim();
        //    approveClientExpenseModel.str_Btn_Approve_Yes = Approve_Client_Expense["P12"].ToString().Trim();
        //    approveClientExpenseModel.str_Btn_Approve_Ok = Approve_Client_Expense["P13"].ToString().Trim();


        //    return approveClientExpenseModel;
        //}

        //public CreateExpenseInvoiceModel GetCreateExpenseInvoiceData(DataRow Create_Expense_Invoice)
        //{
        //    CreateExpenseInvoiceModel createExpenseInvoiceModel = new CreateExpenseInvoiceModel();
        //    createExpenseInvoiceModel.strTestCaseId = Create_Expense_Invoice["TestCaseID"].ToString().Trim();
        //    // createExpenseInvoiceModel.str_BrowserName = Create_Expense_Invoice["P1"].ToString().Trim();
        //    createExpenseInvoiceModel.strUserID = Create_Expense_Invoice["P3"].ToString().Trim();
        //    createExpenseInvoiceModel.strClientName = Create_Expense_Invoice["P5"].ToString().Trim();
        //    createExpenseInvoiceModel.strMainMenuLink = Create_Expense_Invoice["P6"].ToString().Trim();
        //    createExpenseInvoiceModel.strSubMenuLink = Create_Expense_Invoice["P7"].ToString().Trim();
        //    createExpenseInvoiceModel.str_Txt_CW = Create_Expense_Invoice["P8"].ToString().Trim();
        //    createExpenseInvoiceModel.str_Date_txtDateFrom = Create_Expense_Invoice["P11"].ToString().Trim();

        //    createExpenseInvoiceModel.str_Txt_txtInvoiceAmt = Create_Expense_Invoice["P12"].ToString().Trim();
        //    createExpenseInvoiceModel.str_Txt_txtInvoiceNo = Create_Expense_Invoice["P13"].ToString().Trim();
        //    createExpenseInvoiceModel.str_Txt_txtComment = Create_Expense_Invoice["P14"].ToString().Trim();
        //    createExpenseInvoiceModel.str_Btn_ExternalInvoice_Yes = Create_Expense_Invoice["P16"].ToString().Trim();
        //    createExpenseInvoiceModel.strSubMenuLink_PaymentByCustomer = Create_Expense_Invoice["P18"].ToString().Trim();
        //    createExpenseInvoiceModel.str_Txt_InvoiceCheckAmountt = Create_Expense_Invoice["P21"].ToString().Trim();
        //    createExpenseInvoiceModel.str_Txt_CheckAmount = Create_Expense_Invoice["P22"].ToString().Trim();
        //    createExpenseInvoiceModel.str_Date_CheckDate = Create_Expense_Invoice["P23"].ToString().Trim();
        //    createExpenseInvoiceModel.str_Txt_txtCheckNo = Create_Expense_Invoice["P24"].ToString().Trim();
        //    createExpenseInvoiceModel.str_Txt_txtPaNumber = Create_Expense_Invoice["P25"].ToString().Trim();
        //    createExpenseInvoiceModel.str_Txt_Invoice_txtComment = Create_Expense_Invoice["P26"].ToString().Trim();
        //    createExpenseInvoiceModel.str_Btn_PaymentDetails_Yes = Create_Expense_Invoice["P28"].ToString().Trim();
        //    createExpenseInvoiceModel.strSubMenuLink_PaymentToSupplier = Create_Expense_Invoice["P30"].ToString().Trim();
        //    createExpenseInvoiceModel.str_Txt_VoucherAmount = Create_Expense_Invoice["P33"].ToString().Trim();
        //    createExpenseInvoiceModel.str_Date_VoucherDate = Create_Expense_Invoice["P34"].ToString().Trim();

        //    createExpenseInvoiceModel.str_Btn_SupplierToPayment_Yes = Create_Expense_Invoice["P36"].ToString().Trim();


        //    return createExpenseInvoiceModel;
        //}
        //public CWExtensionModel GetCWExtensionModel(DataRow Extension)
        //{
        //    CWExtensionModel cwExtensionModel = new CWExtensionModel();
        //    cwExtensionModel.strTestCaseId = Extension["TestCaseID"].ToString().Trim();
        //    // createExpenseInvoiceModel.str_BrowserName = Create_Expense_Invoice["P1"].ToString().Trim();
        //    cwExtensionModel.str_Browser_name = Extension["P1"].ToString().Trim();
        //    cwExtensionModel.strUserID = Extension["P3"].ToString().Trim();
        //    cwExtensionModel.strClientName = Extension["P5"].ToString().Trim();
        //    cwExtensionModel.strMainMenuLink = Extension["P6"].ToString().Trim();
        //    cwExtensionModel.strSubMenuLink = Extension["P7"].ToString().Trim();
        //    cwExtensionModel.str_Txt_CW = Extension["P8"].ToString().Trim();
        //    cwExtensionModel.str_Txt_VIPstartswith = Extension["P9"].ToString().Trim();
        //    cwExtensionModel.str_Txt_LastName = Extension["P10"].ToString().Trim();
        //    cwExtensionModel.str_Txt_FirstName = Extension["P11"].ToString().Trim();
        //    cwExtensionModel.str_Txt_HiringManager = Extension["P12"].ToString().Trim();
        //    cwExtensionModel.str_Txt_Supplier = Extension["P13"].ToString().Trim();
        //    cwExtensionModel.str_Select_Program = Extension["P14"].ToString().Trim();
        //    cwExtensionModel.str_Select_TypeofService = Extension["P15"].ToString().Trim();
        //    cwExtensionModel.str_Select_Active = Extension["P16"].ToString().Trim();
        //    cwExtensionModel.str_Date_txtDateFrom = Extension["P17"].ToString().Trim();
        //    cwExtensionModel.str_Date_txtDateTo = Extension["P18"].ToString().Trim();
        //    cwExtensionModel.str_Txt_Contractenddatewithindays = Extension["P19"].ToString().Trim();
        //    cwExtensionModel.str_Date_EndDateFrom = Extension["P20"].ToString().Trim();
        //    cwExtensionModel.str_Date_EndDateFromTo = Extension["P21"].ToString().Trim();
        //    cwExtensionModel.str_Select_DoNotHire = Extension["P22"].ToString().Trim();
        //    cwExtensionModel.str_Btn_Submit_Search = Extension["P23"].ToString().Trim();
        //    cwExtensionModel.str_Txt_Filter_CW = Extension["P24"].ToString().Trim();
        //    cwExtensionModel.str_SubMenu_Extension = Extension["P25"].ToString().Trim();
        //    cwExtensionModel.str_ExtEffectiveDate = Extension["P26"].ToString().Trim();
        //    cwExtensionModel.str_Txt_UploadFilePath = Extension["P27"].ToString().Trim();
        //    cwExtensionModel.str_Txt_Justification = Extension["P28"].ToString().Trim();
        //    cwExtensionModel.str_Txt_AdditionalAmt = Extension["P29"].ToString().Trim();
        //    cwExtensionModel.str_Btn_SaveALL = Extension["P30"].ToString().Trim();
        //    cwExtensionModel.str_Btn_Yes_Action_Ext = Extension["P31"].ToString().Trim();
        //    cwExtensionModel.str_Btn_Ok_Action_Ext = Extension["P32"].ToString().Trim();
        //    cwExtensionModel.str_radio_ExtendType_ = Extension["P33"].ToString().Trim();


        //    // Extend CW
        //    cwExtensionModel.str_ChargeNumber = Extension["P27"].ToString().Trim();
        //    cwExtensionModel.str_AddListTxt_txtTimecardApprover = Extension["P28"].ToString().Trim();
        //    cwExtensionModel.str_Txt_ExtendCW_AdditionalAmt = Extension["P29"].ToString().Trim();
        //    // cwExtensionModel.str_DeleteListTxt_txtTimecardApprover = Extension["P34"].ToString().Trim();
        //    cwExtensionModel.str_Txt_Comment = Extension["P30"].ToString().Trim();
        //    cwExtensionModel.str_Btn_Submit = Extension["P31"].ToString().Trim();
        //    cwExtensionModel.str_Btn_Yes_Action_ExtendCW = Extension["P32"].ToString().Trim();
        //    cwExtensionModel.str_Btn_Ok_Action_ExtendCW = Extension["P33"].ToString().Trim();
        //    cwExtensionModel.str_Del_ChargeNumber = Extension["P34"].ToString().Trim();

        //    // Update CW
        //    cwExtensionModel.str_Btn_Update_Saveall = Extension["P35"].ToString().Trim();
        //    cwExtensionModel.str_Btn_Yes_Action_ExtUpdate = Extension["P36"].ToString().Trim();
        //    cwExtensionModel.str_Btn_Ok_Action_ExtUpdate = Extension["P37"].ToString().Trim();

        //    // Extension Approve
        //    //  cwExtensionModel.str_SubMenu_Extension = Extension["P9"].ToString().Trim();

        //    // cwExtensionModel.str_SubMenu_Extension = Extension["P9"].ToString().Trim();
        //    // cwExtensionModel.str_ExtEffectiveDate = Extension["P10"].ToString().Trim();
        //    // cwExtensionModel.str_Txt_UploadFilePath = Extension["P11"].ToString().Trim();
        //    // cwExtensionModel.str_Txt_Justification = Extension["P12"].ToString().Trim(); 
        //    // cwExtensionModel.str_Btn_Ok_Action_Ext = Extension["P15"].ToString().Trim();
        //    // cwExtensionModel.str_Txt_AdditionalAmt = Extension["P16"].ToString().Trim();
        //    // cwExtensionModel.str_AddListTxt_txtTimecardApprover = Extension["P27"].ToString().Trim();
        //    // cwExtensionModel.str_DeleteListTxt_txtTimecardApprover = Extension["P17"].ToString().Trim();
        //    // cwExtensionModel.str_Txt_Comment = Extension["P18"].ToString().Trim();
        //    // cwExtensionModel.str_Btn_Yes_Action_UpdCW = Extension["P20"].ToString().Trim();
        //    // cwExtensionModel.str_Ext_Approve = Extension["P22"].ToString().Trim();
        //    cwExtensionModel.str_Ext_Approve_Comment = Extension["P26"].ToString().Trim();
        //    // cwExtensionModel.str_radio_ExtendType_ = Extension["P30"].ToString().Trim();





        //    return cwExtensionModel;
        //}
        //public RateChangeModel GetRateChangeModel(DataRow Rate_Change)
        //{
        //    RateChangeModel cwRateChangeModel = new RateChangeModel();
        //    cwRateChangeModel.strTestCaseId = Rate_Change["TestCaseID"].ToString().Trim();
        //    cwRateChangeModel.str_BrowserName = Rate_Change["P1"].ToString().Trim();
        //    cwRateChangeModel.strUserID = Rate_Change["P3"].ToString().Trim();
        //    cwRateChangeModel.strClientName = Rate_Change["P5"].ToString().Trim();
        //    cwRateChangeModel.strMainMenuLink = Rate_Change["P6"].ToString().Trim();
        //    cwRateChangeModel.strSubMenuLink = Rate_Change["P7"].ToString().Trim();
        //    cwRateChangeModel.str_Txt_SearchCW = Rate_Change["P24"].ToString().Trim();
        //    cwRateChangeModel.strSubMenuLinkclick = Rate_Change["P25"].ToString().Trim();
        //    cwRateChangeModel.str_Date_DatereadEndDate = Rate_Change["P26"].ToString().Trim();
        //    cwRateChangeModel.str_Date_txtDateFrom = Rate_Change["P27"].ToString().Trim();
        //    cwRateChangeModel.str_Txt_txtNewPayRate = Rate_Change["P28"].ToString().Trim();
        //    cwRateChangeModel.str_Txt_txtNewOTPayRate = Rate_Change["P29"].ToString().Trim();
        //    cwRateChangeModel.str_Txt_txtNewSupplierBillRate = Rate_Change["P30"].ToString().Trim();
        //    cwRateChangeModel.str_Txt_txtNewSupplierOTBillRate = Rate_Change["P31"].ToString().Trim();
        //    cwRateChangeModel.str_Txt_txtNewFinalBillRate = Rate_Change["P32"].ToString().Trim();
        //    cwRateChangeModel.str_Txt_txtNewFinalOTBillRate = Rate_Change["P33"].ToString().Trim();
        //    cwRateChangeModel.str_Txt_txtAdditionalAmount = Rate_Change["P34"].ToString().Trim();
        //    cwRateChangeModel.str_Select_NewJobTitle = Rate_Change["P35"].ToString().Trim();
        //    cwRateChangeModel.str_Txt_UploadFilePathJustificationHire = Rate_Change["P36"].ToString().Trim();
        //    cwRateChangeModel.str_Txt_JustificationforHire = Rate_Change["P37"].ToString().Trim();
        //    cwRateChangeModel.str_Btn_EnterRateChange = Rate_Change["P38"].ToString().Trim();
        //    cwRateChangeModel.str_Btn_EnterRateChange_Yes = Rate_Change["P39"].ToString().Trim();
        //    cwRateChangeModel.str_Btn_EnterRateChange_OK = Rate_Change["P40"].ToString().Trim();
        //    cwRateChangeModel.str_Timesheet = Rate_Change["P41"].ToString().Trim();
        //    cwRateChangeModel.str_Del_Timesheet = Rate_Change["P42"].ToString().Trim();
        //    cwRateChangeModel.str_ChargeNumber = Rate_Change["P43"].ToString().Trim();
        //    cwRateChangeModel.str_Del_ChargeNumber = Rate_Change["P44"].ToString().Trim();
        //    cwRateChangeModel.str_Txt_Comment = Rate_Change["P45"].ToString().Trim();
        //    cwRateChangeModel.str_Btn_Saveall = Rate_Change["P46"].ToString().Trim();
        //    cwRateChangeModel.str_Btn_Yes_Action_Ext = Rate_Change["P47"].ToString().Trim();
        //    cwRateChangeModel.str_Btn_Ok_Action_Ext = Rate_Change["P48"].ToString().Trim();



        //    return cwRateChangeModel;
        //}
        //public SearchCWModel GetSearchCWModel(DataRow Rate_Change)
        //{
        //    SearchCWModel cwsearch = new SearchCWModel();
        //    cwsearch.strTestCaseId = Rate_Change["TestCaseID"].ToString().Trim();
        //    // createExpenseInvoiceModel.str_BrowserName = Create_Expense_Invoice["P1"].ToString().Trim();
        //    cwsearch.strUserID = Rate_Change["P3"].ToString().Trim();
        //    cwsearch.strClientName = Rate_Change["P5"].ToString().Trim();
        //    cwsearch.strMainMenuLink = Rate_Change["P6"].ToString().Trim();
        //    cwsearch.strSubMenuLink = Rate_Change["P7"].ToString().Trim();
        //    cwsearch.str_Txt_CW = Rate_Change["P8"].ToString().Trim();
        //    cwsearch.str_Txt_VIPstartswith = Rate_Change["P9"].ToString().Trim();
        //    cwsearch.str_Txt_LastName = Rate_Change["P10"].ToString().Trim();
        //    cwsearch.str_Txt_FirstName = Rate_Change["P11"].ToString().Trim();
        //    cwsearch.str_Txt_HiringManager = Rate_Change["P12"].ToString().Trim();
        //    cwsearch.str_Txt_Supplier = Rate_Change["P13"].ToString().Trim();
        //    cwsearch.str_Select_Program = Rate_Change["P14"].ToString().Trim();
        //    cwsearch.str_Select_TypeofService = Rate_Change["P15"].ToString().Trim();
        //    cwsearch.str_Select_Active = Rate_Change["P16"].ToString().Trim();
        //    cwsearch.str_Date_txtDateFrom = Rate_Change["P17"].ToString().Trim();
        //    cwsearch.str_Date_txtDateTo = Rate_Change["P18"].ToString().Trim();
        //    cwsearch.str_Txt_Contractenddatewithindays = Rate_Change["P19"].ToString().Trim();
        //    cwsearch.str_Date_EndDateFrom = Rate_Change["P20"].ToString().Trim();
        //    cwsearch.str_Date_EndDateFromTo = Rate_Change["P21"].ToString().Trim();
        //    cwsearch.str_Select_DoNotHire = Rate_Change["P22"].ToString().Trim();
        //    cwsearch.str_Btn_Submit_Search = Rate_Change["P23"].ToString().Trim();


        //    return cwsearch;
        //}

        //public CWTerminationModel GetCWTerminationModel(DataRow Termination)
        //{
        //    CWTerminationModel cwTermination = new CWTerminationModel();
        //    cwTermination.strTestCaseId = Termination["TestCaseID"].ToString().Trim();

        //    cwTermination.strUserID = Termination["P3"].ToString().Trim();
        //    cwTermination.strClientName = Termination["P5"].ToString().Trim();
        //    cwTermination.strMainMenuLink = Termination["P6"].ToString().Trim();
        //    cwTermination.strSubMenuLink = Termination["P7"].ToString().Trim();
        //    cwTermination.str_Txt_CW = Termination["P8"].ToString().Trim();
        //    cwTermination.str_Txt_VIPstartswith = Termination["P9"].ToString().Trim();
        //    cwTermination.str_Txt_LastName = Termination["P10"].ToString().Trim();
        //    cwTermination.str_Txt_FirstName = Termination["P11"].ToString().Trim();
        //    cwTermination.str_Txt_HiringManager = Termination["P12"].ToString().Trim();
        //    cwTermination.str_Txt_Supplier = Termination["P13"].ToString().Trim();
        //    cwTermination.str_Select_Program = Termination["P14"].ToString().Trim();
        //    cwTermination.str_Select_TypeofService = Termination["P15"].ToString().Trim();
        //    cwTermination.str_Select_Active = Termination["P16"].ToString().Trim();
        //    cwTermination.str_Date_txtDateFrom = Termination["P17"].ToString().Trim();
        //    cwTermination.str_Date_txtDateTo = Termination["P18"].ToString().Trim();
        //    cwTermination.str_Txt_Contractenddatewithindays = Termination["P19"].ToString().Trim();
        //    cwTermination.str_Date_EndDateFrom = Termination["P20"].ToString().Trim();
        //    cwTermination.str_Date_EndDateFromTo = Termination["P21"].ToString().Trim();
        //    cwTermination.str_Select_DoNotHire = Termination["P22"].ToString().Trim();
        //    cwTermination.str_Btn_Submit_Search = Termination["P23"].ToString().Trim();
        //    cwTermination.str_Txt_SearchCW = Termination["P24"].ToString().Trim();
        //    cwTermination.strSubMenuLinkclick = Termination["P25"].ToString().Trim();
        //    cwTermination.str_Name_of_Authorizer = Termination["P26"].ToString().Trim();
        //    cwTermination.str_chk_CWNeverWorked = Termination["P27"].ToString().Trim();
        //    cwTermination.str_Date_ReleaseDate = Termination["P28"].ToString().Trim();
        //    cwTermination.str_radio_IsConfidential = Termination["P29"].ToString().Trim();
        //    cwTermination.str_radio_ExpenseReportApproved = Termination["P30"].ToString().Trim();
        //    cwTermination.str_select_PreferredMethod = Termination["P31"].ToString().Trim();
        //    cwTermination.str_radio_TypeofRelease = Termination["P32"].ToString().Trim();
        //    cwTermination.str_select_Reason = Termination["P33"].ToString().Trim();
        //    cwTermination.str_radio_WouldBringBack = Termination["P34"].ToString().Trim();
        //    cwTermination.str_Txt_Comments = Termination["P35"].ToString().Trim();
        //    cwTermination.str_Btn_Terminate = Termination["P36"].ToString().Trim();
        //    cwTermination.str_Btn_Terminate_Yes = Termination["P37"].ToString().Trim();
        //    cwTermination.str_Btn_Terminate_OK = Termination["P38"].ToString().Trim();
        //    cwTermination.str_Btn_Saveall = Termination["P39"].ToString().Trim();
        //    cwTermination.str_Btn_Yes_Action_Ext = Termination["P40"].ToString().Trim();
        //    cwTermination.str_Btn_Ok_Action_Ext = Termination["P41"].ToString().Trim();


        //    return cwTermination;
        //}

        public InterviewProcessModel GetInterviewProcessModel(DataRow Request_Interview)
        {
            InterviewProcessModel IntProcessModel = new InterviewProcessModel();
            IntProcessModel.strTestCaseId = Request_Interview["TestCaseID"].ToString().Trim();
            // createExpenseInvoiceModel.str_BrowserName = Create_Expense_Invoice["P1"].ToString().Trim();
            // IntProcessModel.str_Browser_name = Request_Interview["P1"].ToString().Trim();
            IntProcessModel.strUserID = Request_Interview["P1"].ToString().Trim();
            IntProcessModel.strClientName = Request_Interview["P3"].ToString().Trim();
            IntProcessModel.strMainMenuLink = Request_Interview["P4"].ToString().Trim();
            IntProcessModel.strSubMenuLink = Request_Interview["P5"].ToString().Trim();
            IntProcessModel.str_Link_ViewCandidates = Request_Interview["P7"].ToString().Trim();
            IntProcessModel.str_Select_Statuslist = Request_Interview["P6"].ToString().Trim();
            IntProcessModel.str_Txt_ReqNumber = Request_Interview["P6"].ToString().Trim();      //req no     
            IntProcessModel.str_Txt_CandidateName = Request_Interview["P8"].ToString().Trim();
            // IntProcessModel.str_Txt_FirstName = Request_Interview["P10"].ToString().Trim();
            IntProcessModel.str_Link_ReqInterview = Request_Interview["P9"].ToString().Trim();
            IntProcessModel.str_Date_FirChoice = Request_Interview["P10"].ToString().Trim();
            IntProcessModel.str_Select_Time1 = Request_Interview["P11"].ToString().Trim();
            IntProcessModel.str_Select_Zone1 = Request_Interview["P12"].ToString().Trim();
            IntProcessModel.str_Date_SecChoice = Request_Interview["P13"].ToString().Trim();
            IntProcessModel.str_Select_Time2 = Request_Interview["P14"].ToString().Trim();
            IntProcessModel.str_Select_Zone2 = Request_Interview["P15"].ToString().Trim();
            IntProcessModel.str_Radio_IntType = Request_Interview["P16"].ToString().Trim();
            IntProcessModel.str_Txt_Interviewer = Request_Interview["P17"].ToString().Trim();
            IntProcessModel.str_Txt_InterviewAddress = Request_Interview["P18"].ToString().Trim();
            IntProcessModel.str_Btn_RequestInterview = Request_Interview["P19"].ToString().Trim();
            IntProcessModel.str_Btn_Yes_Action_ReqInt = Request_Interview["P20"].ToString().Trim();
            IntProcessModel.str_Btn_OK_ReqInt = Request_Interview["P21"].ToString().Trim();


            return IntProcessModel;
        }

        public ScheduleInterviewModel GetScheduleInterviewModel(DataRow Schedule_Interview)
        {
            ScheduleInterviewModel ScheInterviewModel = new ScheduleInterviewModel();
            ScheInterviewModel.strTestCaseId = Schedule_Interview["TestCaseID"].ToString().Trim();
            // createExpenseInvoiceModel.str_BrowserName = Create_Expense_Invoice["P1"].ToString().Trim();
            // ScheInterviewModel.str_Browser_name = Schedule_Interview["P1"].ToString().Trim();
            ScheInterviewModel.strUserID = Schedule_Interview["P1"].ToString().Trim();
            ScheInterviewModel.strClientName = Schedule_Interview["P3"].ToString().Trim();
            ScheInterviewModel.strMainMenuLink = Schedule_Interview["P4"].ToString().Trim();
            ScheInterviewModel.strSubMenuLink = Schedule_Interview["P5"].ToString().Trim();
            //ScheInterviewModel.str_Select_Statuslist = Schedule_Interview["P8"].ToString().Trim();
            ScheInterviewModel.str_Txt_ReqNumber = Schedule_Interview["P6"].ToString().Trim();
            ScheInterviewModel.str_Link_Subcaniddates = Schedule_Interview["P7"].ToString().Trim();
            ScheInterviewModel.str_Txt_CandidateName = Schedule_Interview["P8"].ToString().Trim();
            // IntProcessModel.str_Txt_FirstName = Request_Interview["P10"].ToString().Trim();
            ScheInterviewModel.str_Link_ScheInterview = Schedule_Interview["P9"].ToString().Trim();
            ScheInterviewModel.str_Radio_Interview_Accepted = Schedule_Interview["P10"].ToString().Trim();
            ScheInterviewModel.str_Radio_ConfirmInterview = Schedule_Interview["P11"].ToString().Trim();
            ScheInterviewModel.str_Txt_PrimaryPhone = Schedule_Interview["P12"].ToString().Trim();
            ScheInterviewModel.str_Txt_SecondaryPhone = Schedule_Interview["P13"].ToString().Trim();
            ScheInterviewModel.str_Txt_Sche_Comment = Schedule_Interview["P14"].ToString().Trim();
            ScheInterviewModel.str_Btn_ScheduleInterview = Schedule_Interview["P15"].ToString().Trim();
            ScheInterviewModel.str_Btn_Yes_Action_ScheInt = Schedule_Interview["P16"].ToString().Trim();
            ScheInterviewModel.str_Btn_OK_ScheInt = Schedule_Interview["P17"].ToString().Trim();
            ScheInterviewModel.str_ScheduleDate = Schedule_Interview["P18"].ToString().Trim();



            ScheInterviewModel.str_Select_Time1 = Schedule_Interview["P19"].ToString().Trim();
            ScheInterviewModel.str_Select_Zone1 = Schedule_Interview["P20"].ToString().Trim();
            ScheInterviewModel.str_Date_SecChoice = Schedule_Interview["P21"].ToString().Trim();
            ScheInterviewModel.str_Select_Time2 = Schedule_Interview["P22"].ToString().Trim();
            ScheInterviewModel.str_Select_Zone2 = Schedule_Interview["P23"].ToString().Trim();
            ScheInterviewModel.str_Radio_IntType = Schedule_Interview["P24"].ToString().Trim();
            ScheInterviewModel.str_Txt_Interviewer = Schedule_Interview["P25"].ToString().Trim();
            ScheInterviewModel.str_Txt_InterviewAddress = Schedule_Interview["P26"].ToString().Trim();
            ScheInterviewModel.str_Btn_RequestInterview = Schedule_Interview["P27"].ToString().Trim();


            return ScheInterviewModel;
        }
        public ConfirmInterviewModel GetConfirmInterviewModel(DataRow Confirm_Interview)
        {
            ConfirmInterviewModel ConfirmIntModel = new ConfirmInterviewModel();
            ConfirmIntModel.strTestCaseId = Confirm_Interview["TestCaseID"].ToString().Trim();
            // createExpenseInvoiceModel.str_BrowserName = Create_Expense_Invoice["P1"].ToString().Trim();
            // ConfirmIntModel.str_Browser_name = Confirm_Interview["P1"].ToString().Trim();
            ConfirmIntModel.strUserID = Confirm_Interview["P1"].ToString().Trim();
            ConfirmIntModel.strClientName = Confirm_Interview["P3"].ToString().Trim();
            ConfirmIntModel.strMainMenuLink = Confirm_Interview["P4"].ToString().Trim();
            ConfirmIntModel.strSubMenuLink = Confirm_Interview["P5"].ToString().Trim();
            // ConfirmIntModel.str_Select_Statuslist = Confirm_Interview["P8"].ToString().Trim();
            ConfirmIntModel.str_Txt_ReqNumber = Confirm_Interview["P6"].ToString().Trim();
            ConfirmIntModel.str_Link_View_Candidates = Confirm_Interview["P7"].ToString().Trim();
            // ConfirmIntModel.str_Link_Subcaniddates = Confirm_Interview["P9"].ToString().Trim();
            ConfirmIntModel.str_Txt_CandidateName = Confirm_Interview["P8"].ToString().Trim();
            //// IntProcessModel.str_Txt_FirstName = Request_Interview["P10"].ToString().Trim();
            ConfirmIntModel.str_Link_ConfirmInterview = Confirm_Interview["P9"].ToString().Trim();
            ConfirmIntModel.str_Txt_Confirm_IntDate = Confirm_Interview["P10"].ToString().Trim();
            ConfirmIntModel.str_Select_SupplierTime = Confirm_Interview["P11"].ToString().Trim();
            ConfirmIntModel.str_Select_SupplierZone = Confirm_Interview["P12"].ToString().Trim();
            ConfirmIntModel.str_Txt_PrimaryPhone = Confirm_Interview["P13"].ToString().Trim();
            ConfirmIntModel.str_Txt_SecondaryPhone = Confirm_Interview["P14"].ToString().Trim();
            ConfirmIntModel.str_Txt_Sche_Comment = Confirm_Interview["P15"].ToString().Trim();
            ConfirmIntModel.str_Btn_ConfirmInterview = Confirm_Interview["P16"].ToString().Trim();
            ConfirmIntModel.str_Btn_Yes_Action_ConfirmInt = Confirm_Interview["P17"].ToString().Trim();
            ConfirmIntModel.str_Btn_OK_ConfirmInt = Confirm_Interview["P18"].ToString().Trim();



            return ConfirmIntModel;
        }

        //public CancelInterviewModel GetCancelInterviewModel(DataRow Cancel_Interview)
        //{
        //    CancelInterviewModel CancelIntModel = new CancelInterviewModel();
        //    CancelIntModel.strTestCaseId = Cancel_Interview["TestCaseID"].ToString().Trim();
        //    // createExpenseInvoiceModel.str_BrowserName = Create_Expense_Invoice["P1"].ToString().Trim();
        //    // CancelIntModel.str_Browser_name = Cancel_Interview["P1"].ToString().Trim();
        //    CancelIntModel.strUserID = Cancel_Interview["P1"].ToString().Trim();
        //    CancelIntModel.strClientName = Cancel_Interview["P3"].ToString().Trim();
        //    CancelIntModel.strMainMenuLink = Cancel_Interview["P4"].ToString().Trim();
        //    CancelIntModel.strSubMenuLink = Cancel_Interview["P5"].ToString().Trim();
        //    //CancelIntModel.str_Select_Statuslist = Cancel_Interview["P8"].ToString().Trim();
        //    CancelIntModel.str_Txt_ReqNumber = Cancel_Interview["P6"].ToString().Trim();
        //    CancelIntModel.str_Link_Viewcandidates = Cancel_Interview["P7"].ToString().Trim();
        //    CancelIntModel.str_Txt_CandidateName = Cancel_Interview["P8"].ToString().Trim();
        //    //// IntProcessModel.str_Txt_FirstName = Request_Interview["P10"].ToString().Trim();
        //    CancelIntModel.str_Link_CancelInterview = Cancel_Interview["P9"].ToString().Trim();
        //    CancelIntModel.str_Txt_Cancel_Comment = Cancel_Interview["P10"].ToString().Trim();
        //    CancelIntModel.str_Btn_CancelInterview = Cancel_Interview["P11"].ToString().Trim();
        //    CancelIntModel.str_Btn_Yes_Action_ConfirmInt = Cancel_Interview["P12"].ToString().Trim();
        //    CancelIntModel.str_Btn_OK_ConfirmInt = Cancel_Interview["P13"].ToString().Trim();




        //    return CancelIntModel;
        //}

        //public InterviewFeedbackModel GetInterviewFeedbackModel(DataRow Interview_Feedback)
        //{
        //    InterviewFeedbackModel IntFeedbackModel = new InterviewFeedbackModel();
        //    IntFeedbackModel.strTestCaseId = Interview_Feedback["TestCaseID"].ToString().Trim();
        //    // createExpenseInvoiceModel.str_BrowserName = Create_Expense_Invoice["P1"].ToString().Trim();
        //    //   IntFeedbackModel.str_Browser_name = Interview_Feedback["P1"].ToString().Trim();
        //    IntFeedbackModel.strUserID = Interview_Feedback["P1"].ToString().Trim();
        //    IntFeedbackModel.strClientName = Interview_Feedback["P3"].ToString().Trim();
        //    IntFeedbackModel.strMainMenuLink = Interview_Feedback["P4"].ToString().Trim();
        //    IntFeedbackModel.strSubMenuLink = Interview_Feedback["P5"].ToString().Trim();
        //    //CancelIntModel.str_Select_Statuslist = Cancel_Interview["P8"].ToString().Trim();
        //    IntFeedbackModel.str_Txt_ReqNumber = Interview_Feedback["P6"].ToString().Trim();
        //    IntFeedbackModel.str_Link_Viewcandidates = Interview_Feedback["P7"].ToString().Trim();
        //    IntFeedbackModel.str_Txt_CandidateName = Interview_Feedback["P8"].ToString().Trim();
        //    //// IntProcessModel.str_Txt_FirstName = Request_Interview["P10"].ToString().Trim();
        //    IntFeedbackModel.str_Link_Interview_Feedback = Interview_Feedback["P9"].ToString().Trim();
        //    IntFeedbackModel.str_Txt_Interview_Results = Interview_Feedback["P10"].ToString().Trim();
        //    IntFeedbackModel.str_Btn_InterviewFeedback = Interview_Feedback["P11"].ToString().Trim();
        //    IntFeedbackModel.str_Btn_Yes_Action_ConfirmInt = Interview_Feedback["P12"].ToString().Trim();
        //    IntFeedbackModel.str_Btn_OK_ConfirmInt = Interview_Feedback["P13"].ToString().Trim();

        //    return IntFeedbackModel;
        //}


        //public AdjustmentTimeSheetMSPModel GetAdjustmentTimeSheetMSPData(DataRow AdjustmentTimesheetMSP_Data)
        //{
        //    AdjustmentTimeSheetMSPModel adjustmentTimeSheetMSPModel = new AdjustmentTimeSheetMSPModel();
        //    adjustmentTimeSheetMSPModel.strClientName = AdjustmentTimesheetMSP_Data["P3"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.strMainMenuLink = AdjustmentTimesheetMSP_Data["P4"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.strSubMenuLink = AdjustmentTimesheetMSP_Data["P5"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_Link_WorkListAction = AdjustmentTimesheetMSP_Data["P6"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_Select_DefaultContent_CboSelect = AdjustmentTimesheetMSP_Data["P7"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_Txt_DefaultContent_TxtName = AdjustmentTimesheetMSP_Data["P8"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_DataTxt_DefaultContent_TxtWeekendFrom = AdjustmentTimesheetMSP_Data["P9"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_DateTxt_DefaultContent_TxtWeekendTo = AdjustmentTimesheetMSP_Data["P10"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_Select_DefaultContent_CboStatus = AdjustmentTimesheetMSP_Data["P11"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_Select_DefaultContent_CboNoRecords = AdjustmentTimesheetMSP_Data["P12"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_Btn_DefaultContent_btnSearch = AdjustmentTimesheetMSP_Data["P13"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_Btn_DefaultContent_btnClearSearch = AdjustmentTimesheetMSP_Data["P14"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_Txt_Approver_Filter_Awaiting = AdjustmentTimesheetMSP_Data["P15"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_TxtCompare_WeekendingDates = AdjustmentTimesheetMSP_Data["P16"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_Link_ActionList = AdjustmentTimesheetMSP_Data["P17"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_Txt_DefaultContent_TxtMultilineDenied = AdjustmentTimesheetMSP_Data["P18"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_Btn_Confirm = AdjustmentTimesheetMSP_Data["P19"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_Btn_OK = AdjustmentTimesheetMSP_Data["P20"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_DDL_RejectReason = AdjustmentTimesheetMSP_Data["P21"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_Txt_RejectComment = AdjustmentTimesheetMSP_Data["P22"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_FirstTaskUnitNo = AdjustmentTimesheetMSP_Data["P23"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_FirstTaskHoursType = AdjustmentTimesheetMSP_Data["P24"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_FirstTaskShift = AdjustmentTimesheetMSP_Data["P37"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_FirstTaskChargeNo = AdjustmentTimesheetMSP_Data["P25"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_SecondTaskUnitNo = AdjustmentTimesheetMSP_Data["P26"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_SecondTaskHoursType = AdjustmentTimesheetMSP_Data["P27"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_SecondTaskShift = AdjustmentTimesheetMSP_Data["P38"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_SecondTaskChargeNo = AdjustmentTimesheetMSP_Data["P28"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_AdjustRTHours = AdjustmentTimesheetMSP_Data["P29"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_AdjustOTHours = AdjustmentTimesheetMSP_Data["P30"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_ExistingTaskChargeNoToRemoveHours = AdjustmentTimesheetMSP_Data["P31"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_ExistingTaskChargeNoToAddHours = AdjustmentTimesheetMSP_Data["P32"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_AddHoursToExistingTask = AdjustmentTimesheetMSP_Data["P33"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_UpdateChargeNumber = AdjustmentTimesheetMSP_Data["P34"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_btn_AdjustConfYes = AdjustmentTimesheetMSP_Data["P35"].ToString().Trim();
        //    adjustmentTimeSheetMSPModel.str_btn_AdjustConfOK = AdjustmentTimesheetMSP_Data["P36"].ToString().Trim();

        //    return adjustmentTimeSheetMSPModel;
        //}


        //public EditTimeSheetModel GetEditTimeSheetData(DataRow EditTimeSheetData)
        //{
        //    EditTimeSheetModel editTimeSheetModel = new EditTimeSheetModel();
        //    editTimeSheetModel.strClientName = EditTimeSheetData["P3"].ToString().Trim();
        //    editTimeSheetModel.strMainMenuLink = EditTimeSheetData["P4"].ToString().Trim();
        //    editTimeSheetModel.strSubMenuLink = EditTimeSheetData["P5"].ToString().Trim();
        //    editTimeSheetModel.str_Link_WorkListAction = EditTimeSheetData["P6"].ToString().Trim();
        //    editTimeSheetModel.str_Select_DefaultContent_CboSelect = EditTimeSheetData["P7"].ToString().Trim();
        //    editTimeSheetModel.str_Txt_DefaultContent_TxtName = EditTimeSheetData["P8"].ToString().Trim();
        //    editTimeSheetModel.str_DataTxt_DefaultContent_TxtWeekendFrom = EditTimeSheetData["P9"].ToString().Trim();
        //    editTimeSheetModel.str_DateTxt_DefaultContent_TxtWeekendTo = EditTimeSheetData["P10"].ToString().Trim();
        //    editTimeSheetModel.str_Select_DefaultContent_CboStatus = EditTimeSheetData["P11"].ToString().Trim();
        //    editTimeSheetModel.str_Select_DefaultContent_CboNoRecords = EditTimeSheetData["P12"].ToString().Trim();
        //    editTimeSheetModel.str_Btn_DefaultContent_btnSearch = EditTimeSheetData["P13"].ToString().Trim();
        //    editTimeSheetModel.str_Btn_DefaultContent_btnClearSearch = EditTimeSheetData["P14"].ToString().Trim();
        //    editTimeSheetModel.str_Txt_Approver_Filter_Awaiting = EditTimeSheetData["P15"].ToString().Trim();
        //    editTimeSheetModel.str_TxtCompare_WeekendingDates = EditTimeSheetData["P16"].ToString().Trim();
        //    editTimeSheetModel.str_Link_ActionList = EditTimeSheetData["P17"].ToString().Trim();
        //    editTimeSheetModel.str_ExistingTaskNoToRemoveHours = EditTimeSheetData["P18"].ToString().Trim();
        //    editTimeSheetModel.str_ExistingTaskNoToAddHours = EditTimeSheetData["P19"].ToString().Trim();
        //    editTimeSheetModel.str_AddHoursToExistingTask = EditTimeSheetData["P20"].ToString().Trim();
        //    editTimeSheetModel.str_UpdateTaskNumber = EditTimeSheetData["P21"].ToString().Trim();
        //    editTimeSheetModel.str_UpdateTaskChargeNumber = EditTimeSheetData["P22"].ToString().Trim();
        //    editTimeSheetModel.str_btn_EditConfYes = EditTimeSheetData["P23"].ToString().Trim();
        //    editTimeSheetModel.str_btn_EditConfOK = EditTimeSheetData["P24"].ToString().Trim();
        //    editTimeSheetModel.str_btn_SupplierEditConfOK = EditTimeSheetData["P25"].ToString().Trim();//This is only for supplier
        //    editTimeSheetModel.str_FirstTaskUnitNumber = EditTimeSheetData["P25"].ToString().Trim();
        //    editTimeSheetModel.str_FirstTaskHoursType = EditTimeSheetData["P26"].ToString().Trim();
        //    editTimeSheetModel.str_FirstTaskChargeNumber = EditTimeSheetData["P27"].ToString().Trim();
        //    editTimeSheetModel.str_FirstTaskShift = EditTimeSheetData["P28"].ToString().Trim();
        //    return editTimeSheetModel;
        //}

        //public CopyTimesheetModel GetCopyTimesheet_Data(DataRow CopyTimesheet_Data)
        //{
        //    CopyTimesheetModel CopyTimesheetModel = new CopyTimesheetModel();
        //    CopyTimesheetModel.strTestCaseId = CopyTimesheet_Data["TestCaseID"].ToString().Trim();
        //    CopyTimesheetModel.strUserID = CopyTimesheet_Data["P1"].ToString().Trim();
        //    CopyTimesheetModel.strClientName = CopyTimesheet_Data["P3"].ToString().Trim();
        //    CopyTimesheetModel.strMainMenuLink = CopyTimesheet_Data["P4"].ToString().Trim();
        //    CopyTimesheetModel.strSubMenuLink = CopyTimesheet_Data["P5"].ToString().Trim();
        //    CopyTimesheetModel.str_Link_AwaitingApproval = CopyTimesheet_Data["P6"].ToString().Trim();
        //    CopyTimesheetModel.str_Button_search = CopyTimesheet_Data["P7"].ToString().Trim();
        //    CopyTimesheetModel.str_ExcelSheet_TimeSheetDataName = CopyTimesheet_Data["P19"].ToString().Trim();
        //    CopyTimesheetModel.str_WeekEndDate = CopyTimesheet_Data["P10"].ToString().Trim();
        //    CopyTimesheetModel.str_SelectstatusTS = CopyTimesheet_Data["P11"].ToString().Trim();
        //    CopyTimesheetModel.str_Link_CWnumberClk = CopyTimesheet_Data["P12"].ToString().Trim();
        //    CopyTimesheetModel.str_Link_Actioncopy = CopyTimesheet_Data["P13"].ToString().Trim();
        //    CopyTimesheetModel.str_chkbox_DefaultContent_ChkZeroHours = CopyTimesheet_Data["P14"].ToString().Trim();
        //    CopyTimesheetModel.str_Button_Confirm = CopyTimesheet_Data["P15"].ToString().Trim();
        //    CopyTimesheetModel.str_Button_submit = CopyTimesheet_Data["P16"].ToString().Trim();
        //    CopyTimesheetModel.str_Link_inprogress = CopyTimesheet_Data["P17"].ToString().Trim();
        //    CopyTimesheetModel.str_Link_edit = CopyTimesheet_Data["P18"].ToString().Trim();

        //    return CopyTimesheetModel;
        //}

        //public EditAdjustmentRejectTimeSheetMSPModel GetEditAdjustmentRejectTimeSheetMSPData(DataRow EditAdjustRejectmentTimesheetMSP_Data)
        //{
        //    EditAdjustmentRejectTimeSheetMSPModel editAdjustmentRejectTimeSheetMSPModel = new EditAdjustmentRejectTimeSheetMSPModel();
        //    editAdjustmentRejectTimeSheetMSPModel.strClientName = EditAdjustRejectmentTimesheetMSP_Data["P3"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.strMainMenuLink = EditAdjustRejectmentTimesheetMSP_Data["P4"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.strSubMenuLink = EditAdjustRejectmentTimesheetMSP_Data["P5"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_Link_WorkListAction = EditAdjustRejectmentTimesheetMSP_Data["P6"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_Select_DefaultContent_CboSelect = EditAdjustRejectmentTimesheetMSP_Data["P7"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_Txt_DefaultContent_TxtName = EditAdjustRejectmentTimesheetMSP_Data["P8"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_DataTxt_DefaultContent_TxtWeekendFrom = EditAdjustRejectmentTimesheetMSP_Data["P9"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_DateTxt_DefaultContent_TxtWeekendTo = EditAdjustRejectmentTimesheetMSP_Data["10"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_Select_DefaultContent_CboStatus = EditAdjustRejectmentTimesheetMSP_Data["P11"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_Select_DefaultContent_CboNoRecords = EditAdjustRejectmentTimesheetMSP_Data["P12"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_Btn_DefaultContent_btnSearch = EditAdjustRejectmentTimesheetMSP_Data["P13"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_Btn_DefaultContent_btnClearSearch = EditAdjustRejectmentTimesheetMSP_Data["P14"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_Txt_Approver_Filter_Awaiting = EditAdjustRejectmentTimesheetMSP_Data["P15"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_TxtCompare_WeekendingDates = EditAdjustRejectmentTimesheetMSP_Data["P16"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_Link_ActionList = EditAdjustRejectmentTimesheetMSP_Data["P17"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_Txt_DefaultContent_TxtMultilineDenied = EditAdjustRejectmentTimesheetMSP_Data["P18"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_Btn_Confirm = EditAdjustRejectmentTimesheetMSP_Data["P19"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_Btn_OK = EditAdjustRejectmentTimesheetMSP_Data["P20"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_DDL_RejectReason = EditAdjustRejectmentTimesheetMSP_Data["P21"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_Txt_RejectComment = EditAdjustRejectmentTimesheetMSP_Data["P22"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_FirstTaskUnitNo = EditAdjustRejectmentTimesheetMSP_Data["P23"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_FirstTaskHoursType = EditAdjustRejectmentTimesheetMSP_Data["P24"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_FirstTaskChargeNo = EditAdjustRejectmentTimesheetMSP_Data["P25"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_SecondTaskUnitNo = EditAdjustRejectmentTimesheetMSP_Data["P26"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_SecondTaskHoursType = EditAdjustRejectmentTimesheetMSP_Data["P27"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_SecondTaskChargeNo = EditAdjustRejectmentTimesheetMSP_Data["P28"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_AdjustRTHours = EditAdjustRejectmentTimesheetMSP_Data["P29"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_AdjustOTHours = EditAdjustRejectmentTimesheetMSP_Data["P30"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_ExistingTaskChargeNoToRemoveHours = EditAdjustRejectmentTimesheetMSP_Data["P31"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_ExistingTaskChargeNoToAddHours = EditAdjustRejectmentTimesheetMSP_Data["P32"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_AddHoursToExistingTask = EditAdjustRejectmentTimesheetMSP_Data["P33"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_UpdateChargeNumber = EditAdjustRejectmentTimesheetMSP_Data["P34"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_btn_AdjustConfYes = EditAdjustRejectmentTimesheetMSP_Data["P35"].ToString().Trim();
        //    editAdjustmentRejectTimeSheetMSPModel.str_btn_AdjustConfOK = EditAdjustRejectmentTimesheetMSP_Data["P36"].ToString().Trim();
        //    return editAdjustmentRejectTimeSheetMSPModel;
        //}

    }
}