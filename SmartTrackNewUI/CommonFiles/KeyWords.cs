using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace SmartTrack_Automation
{
    //  [TestClass]
    public class KeyWords
    {
        //public static string str_Database_UserNamePassword = "User ID=stwebuser;Password=dv$#2345q";
        public static string str_Database_UserNamePassword = "User ID=STWebUser_QA;Password=qa!@12#$5";
        public static string str_Database_IPNAME = "";
        // public static string str_Database_connStr = "Data Source=10.0.0.34;Initial Catalog=STV70R12_DEV6;User ID=stwebuser;Password=dv$#2345q";
        //public static string str_Database_connStr = "Data Source=10.0.0.29;Initial Catalog=STV70R12_QAMAIN;User ID=stwebuser;Password=dv$#2345q";


        public static string str_Database_connStr = "";
        //  public static string str_Database_connStr = "Data Source=10.0.0.29;Initial Catalog=STV70R12_STAGING_NEW;User ID=stwebuser;Password=dv$#2345q";
        //  public static TextReader tr = File.OpenText(@"D:\DCR\SMARTTrack-MAIN-Automation\SmartTrackNewUI_Automation\TextFile1.txt");

        //   public static string str_Database_connStr =tr.ReadLine();



        public static string strLogfilePath = "";

        //public static string strExlInputPath = "D:\\DCR\\SMARTTrack-MAIN-Automation\\SmartTrackNewUI_Multi\\bin\\Debug\\Input\\SmartTrack_Input.xlsx";
        //  string strprojectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        public static string strExlInputPath_Master = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Input\\SmartTrack_Master.xlsx";
        public static string strExlReportsInputPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Input\\Reports.xlsx";
        public static string strExlInputPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Input\\SmartTrack_Input.xlsx";
        public static string strMasterSheetName = "Master$";
        public static string strMainSheetName = "Main$";
        public static string strExlOutputPath = "";
        public static string strScreenShootPath = "";
        //public static string strExlOutputPath1 = "";
        public static string strNunitConsolePath = "";
        public static string str_link_REQ_NUMBER = "";

        public static string str_Browser_Execute = "";
        public static string str_App_Url = "";
        public static string strLoginUser = string.Empty;
        public static string LoginUser_Role = "";

        public static string Result_PASS = "PASS";
        public static string Result_Pass = "Pass";
        public static string Result_FAIL = "FAIL";
        public static string locator_Name = "Name";
        public static string locator_ID = "id";
        public static string locator_className = "className";
        public static string locator_class = "class";
        public static string locator_type = "type";
        public static string locator_button = "button";
        public static string locator_class_button = "btn btn-sm btn-primary";
        public static string locator_class_button_div = "btn-group pull-righty";
        public static string locator_XPath = "XPath";
        // "//div[@id='ajCallContainer']/div/a/img";

        public static string ID_Btn_distributionlist = "distribution list";
        public static string ID_Btn_payratemarkup = "pay rate markup";

        public static string Str_dialogWindow_dialog = "dialog";

        public static string Str_Btn_BroadcastToSupplierNotFound = "Given button name Broadcast To Supplier not found";

        public static string locator_CSS = "CssSelector";
        public static string locator_LinkText = "LinkText";
        public static string locator_PartialLinkText = "PartialLinkText";
        public static string ID_STR_loading_message = "loading-message";
        //Logout link using by CSS
        //public static string CSS_Link_logout = "strong";
        public static string CSS_Link_logout = "//span[@class='sprite logoutSprite pull-left']/following-sibling::span[@class='d-inline']";
        public static string str_String_Compare_quickpickfromacatalog = "quick pick from a catalog";
        public static string str_String_Compare_globaltemplates = "global templates";
        public static string str_String_Compare_AllTemplates = "All Templates";
        public static string str_String_Compare_optAllTemplate = "optAllTemplate";


        public static string ID_Window_topdiv = "//*[@id='topdiv']/ul/li/a";

        public static string ID_Window_topdiv2 = "//*[@id='topdiv']/ul/li[2]/a";

        public static string ID_Btn_broadcast = "//*[@id='broadcast']";

        public static string Xpath_Btn_SelectDistributionlist = "//*[@class='btn btn-sm btn-primary']";




        public static string Name_RadioBtn_radio1 = "radio1";
        public static string Xpath_RadioBtn_radio1_2 = "(//input[@name='radio1'])[2]";
        public static string Name_RadioBtn_radio2 = "radio2";
        public static string Xpath_RadioBtn_radio2_2 = "(//input[@name='radio2'])[2]";
        public static string Name_RadioBtn_radio3 = "radio3";
        public static string Xpath_RadioBtn_radio3_2 = "(//input[@name='radio3'])[2]";
        public static string Name_RadioBtn_radio4 = "radio4";
        public static string Xpath_RadioBtn_radio4_2 = "(//input[@name='radio4'])[2]";
        public static string Name_RadioBtn_radio5 = "radio5";
        public static string Xpath_RadioBtn_radio5_2 = "(//input[@name='radio5'])[2]";
        public static string Name_RadioBtn_radio6 = "radio6";
        public static string Xpath_RadioBtn_radio6_2 = "(//input[@name='radio6'])[2]";


        public static string ID_Txt_singleLine7 = "singleLine7";
        public static string ID_RadioBtn_AccountAssignment1 = "AccountAssignment1";
        public static string ID_RadioBtn_AccountAssignment2 = "AccountAssignment2";
        public static string ID_Select_txtServiceType = "txtServiceType";
        public static string ID_Tbl_tblSuppliers = "tblSuppliers";

        public static string ID_Btn_Close = "Close";
        public static string ID_Window_dlgBroadcastSent = "dlgBroadcastSent";
        public static string ID_Window_BroadcastAlert = "ui-dialog-title-dlgBroadcastSent";




        public static string str_String_Compare_all = "all";
        public static string str_String_Compare_yes = "yes";
        public static string str_String_Compare_Voluntary = "yes";
        public static string str_String_Compare_direct = "direct";
        public static string str_String_Compare_noclearance = "no clearance";
        public static string str_String_Compare_costcenter = "cost center";


        public static string str_String_Compare_cost_center_profit_center = "cost center/profit center";
        public static string str_String_Compare_project_wbs_element = "project#/wbs element";




        public static string CSS_Img_Click = "a.etksrc > img";

        public static string CSS_frmButtonContainer_Click = "#frmButtonContainer > input[name=\"submit\"]";

        public static string Xpath_frmButtonContainer_Click = "//*[@id='frmButtonContainer']/input";

        public static string Xpath_tblJobTitle = "//*[@id='tblJobTitle']/tbody/tr[2]/td[1]/input";

        public static string ID_txtEmailAddress = "DefaultContent_TxtEmailAddress";

        public static string ID_txtPassword = "DefaultContent_TxtPassword";
        public static string ID_btnLogin = "DefaultContent_btnLog";
        public static string ID_lblError = "DefaultContent_LblError";
        public static string ID_MainMenu = "sfMainMenu";
        // public static string ID_SubMenu = "sfSubMenu";
        public static string ID_SubMenu = "subLinks";

        public static string ID_Search_regReqList_filter = "//*[@id='WorkspaceMSPListGrid_filter']/label/input";
        public static string ID_select_laborClassCode = "laborClassCode";

        public static string ID_Date_trainingStartDate = "trainingStartDate";
        public static string ID_CreatedUserID = "CreatedUserID";

        public static string ID_MenuItem = "ui-active-menuitem";
        public static string ID_btnGo = "btnGo";
        public static string ID_selectCostCenterId = "CostCenterId";
        public static string ID_selectGLId = "GLId";
        public static string ID_selectOrgId = "organizationID";
        //New Clients
        public static string ID_T1_Select_WorkerClassification_laborClassCode = "laborClassCode";
        public static string ID_T1_Typeahead_Requestor_CreatedUserID = "CreatedUserID";
        public static string ID_T1_select_OrganizationName_organizationID = "organizationID";
        public static string ID_T1_select_Organization_organizationID = "organizationID";
        public static string ID_T1_select_AccountCode_organizationID = "organizationID";
        public static string ID_T1_select_BusinessUnit_organizationID = "organizationID";
        public static string ID_T1_select_BusinessArea_organizationID = "organizationID";
        public static string ID_T1_select_ServiceMethod_serviceMethodID = "serviceMethodID";
        public static string ID_T1_select_EngagementType_serviceMethodID = "serviceMethodID";
        public static string ID_T1_select_LabourCategory_serviceMethodID = "serviceMethodID";
        public static string ID_T1_Typeahead_HRCostCenter_programId = "programId";
        public static string ID_T1_select_Program_programId = "programId";
        public static string ID_T1_select_ACADlevel_programId = "programId";
        public static string ID_T1_txt_LegalEntity_association = "association";
        public static string ID_T1_txt_servicedept_ServDept = "ServDept";
        public static string ID_T1_btn_BadgeAcess_laborClassCode61 = "laborClassCode61";
        public static string ID_T1_btn_BadgeAcess_laborClassCode62 = "laborClassCode62";
        public static string ID_T1_btn_ComputerAccess_computerAccessTrue = "computerAccessTrue";
        public static string ID_T1_btn_ComputerAccess_computerAccessFalse = "computerAccessFalse";
        public static string ID_T1_select_BusinessUnit_ProjectId = "ProjectId";
        public static string ID_T1_Typeahead_ProjectWBSElement_ProjectId = "ProjectId";
        public static string ID_T1_text_ProjectCodeCFR_ProjectId = "ProjectId";
        public static string ID_T1_Typeahead_AccountingUnit_deptNumber = "deptNumber";
        public static string ID_T1_select_UnitNumber_deptNumber = "deptNumber";
        public static string ID_T1_select_CompanyCode_deptNumber = "deptNumber";
        public static string ID_T1_Typeahead_Department_deptNumber = "deptNumber";
        public static string ID_T1_Typeahead_AccountUnitName_deptName = "deptName";
        public static string ID_T1_Typeahead_APCostCenter_CostCenterId = "CostCenterId";
        public static string ID_T1_select_CostCenter_CostCenterId = "CostCenterId";
        public static string ID_T1_Typeahead_CostCenter_CostCenterId = "CostCenterId";
        public static string ID_T1_select_ContractorCost_CostCenterId = "CostCenterId";
        public static string ID_T1_Typeahead_BusinessUnit_CostCenterId = "CostCenterId";
        public static string ID_T1_select_GLAccount_GLId = "GLId";
        public static string ID_T1_select_ContractorCatergory_GLId = "GLId";
        public static string ID_T1_select_GeneralLedgerAccount_GLId = "GLId";
        public static string ID_T1_select_ObjectAccount_GLId = "GLId";
        public static string ID_T1_Txt_NumberofResources_noofresources = "noofresources";
        public static string ID_T1_Txt_NumberofPositions_noofresources = "noofresources";
        public static string ID_T1_btn_Union_directIndirectTrue = "directIndirectTrue";
        public static string ID_T1_btn_Union_directIndirectFalse = "directIndirectFalse";
        public static string ID_T1_btn_ChargingMethod_directIndirectTrue = "directIndirectTrue";
        public static string ID_T1_btn_ChargingMethod_directIndirectFalse = "directIndirectFalse";
        public static string ID_T1_select_UnionName_laborClassCode = "laborClassCode";
        public static string ID_T1_select_HeadcountApproved_laborClassCode = "laborClassCode";
        public static string ID_T1_select_SCAPosition_laborClassCode = "laborClassCode";
        public static string ID_T1_Typeahead_HiringManager_hiringManager = "hiringManager";
        public static string ID_T1_Typeahead_Leader_hiringManager = "hiringManager";
        public static string ID_T1_Typeahead_Engagingmanager_hiringManager = "hiringManager";
        public static string ID_T1_select_Priority_priority = "priority";
        public static string ID_T1_Typeahead_AlternateHiringManager_altHiringManager = "altHiringManager";
        public static string ID_T1_select_AlternateHiringManager_altHiringManager = "altHiringManager";
        public static string ID_T1_Typeahead_FFDSupervisor_altHiringManager = "altHiringManager";
        public static string ID_T1_Typeahead_Supervisor_altHiringManager = "altHiringManager";
        public static string ID_T1_Typeahead_FinancialPartner_altHiringManager = "altHiringManager";
        public static string ID_T1_Typeahead_PONumber_poNumber = "poNumber";
        public static string ID_T1_select_SecurityClearance_securityClearanceLevelID = "securityClearanceLevelID";
        public static string ID_T1_select_ReasontoHire_reasonToHireID = "reasonToHireID";
        public static string ID_T1_select_ReasonForEngagement_reasonToHireID = "reasonToHireID";
        public static string ID_T1_select_CIPAcess_ciplocation = "ciplocation";
        public static string ID_T1_select_AcessLocation_siteLocationID = "siteLocationID";
        public static string ID_T1_select_SiteLocation_siteLocationID = "siteLocationID";
        public static string ID_T1_Date_DesiredStartDate_neededStartDate = "neededStartDate";
        public static string ID_T1_select_WorkWeek_workScheduleID = "workScheduleID";
        public static string ID_T1_Date_AnticipatedStartDate_neededStartDate = "neededStartDate";
        public static string ID_T1_Date_AssignmentStartDate_neededStartDate = "neededStartDate";
        public static string ID_T1_Date_StartDate_neededStartDate = "neededStartDate";
        public static string ID_T1_Date_NeededDate_neededStartDate = "neededStartDate";
        public static string ID_T1_btn_BadgeAcess_laborClassCode57 = "laborClassCode57";
        public static string ID_T1_btn_BadgeAcess_laborClassCode58 = "laborClassCode58";
        public static string ID_T1_txt_JustificationtoHire_JustificationtoHire = "JustificationtoHire";
        public static string ID_T1_txt_PatientNameandOtherDetails_JustificationtoHire = "JustificationtoHire";
        public static string ID_T1_txt_RequestJustification_JustificationtoHire = "JustificationtoHire";
        public static string ID_T1_btn_SystemAcess_directIndirectTrue = "directIndirectTrue";
        public static string ID_T1_btn_SystemAcess_directIndirectFalse = "directIndirectFalse";
        public static string ID_T1_Date_PlannedEndDate_enddate = "enddate";
        public static string ID_T1_Date_AssignmentEndDate_enddate = "enddate";
        public static string ID_T1_Date_EndDate_enddate = "enddate";
        public static string ID_T1_txt_ProductDept_ProDept = "ProDept";
        public static string ID_T1_Typeahead_Worklocation_workLocationID = "workLocationID";
        public static string ID_T1_Select_Worklocation_workLocationID = "workLocationID";
        public static string ID_T1_select_PersonnelArea_workLocationID = "workLocationID";
        public static string ID_T1_Typeahead_MailStation_matrixNumber = "matrixNumber";
        public static string ID_T1_txt_FundingSource_matrixNumber = "matrixNumber";
        public static string ID_T1_btn_ACAD_directIndirectTrue = "directIndirectTrue";
        public static string ID_T1_btn_ACAD_directIndirectFalse = "directIndirectFalse";
        public static string ID_T1_Typeahead_WorkLocationAddress_workLocationAddress = "workLocationAddress";
        public static string ID_T1_Typeahead_PersonnelAreaAddress_workLocationAddress = "workLocationAddress";
        public static string ID_T1_btn_CanStartwithoutClearance_txtWithoutYes = "txtWithoutYes";
        public static string ID_T1_btn_CanStartwithoutClearance_txtWithoutNo = "txtWithoutNo";
        public static string ID_T1_btn_InterimClearanceSufficient_txtSufficientYes = "txtSufficientYes";
        public static string ID_T1_btn_InterimClearanceSufficient_txtSufficientNo = "txtSufficientNo";
        public static string Id_T1_txt_PrimeContractNumber_txtContractNumber = "txtContractNumber";
        //public static string ID_T1_Select_WorkerClassification_laborClassCode = "laborClassCode";
        public static string ID_T1_Typeahead_Requestor_altHiringManager = "altHiringManager";
        public static string ID_T1_Typeahead_RequestOwner_hiringManager = "hiringManager";
        //public static string ID_T1_Typeahead_Company_deptNumber = "deptNumber";
        public static string ID_T1_Select_EngagementType_serviceMethodID = "serviceMethodID";
        public static string ID_T2_Select_GLAccount_GLIdJD = "GLIdJD";
        public static string ID_T2_select_JobCategories_typeofServiceID = "typeofServiceID";
        public static string ID_T2_select_TypeofService_typeofServiceID = "typeofServiceID";
        public static string ID_T2_select_PositionType_typeofServiceID = "typeofServiceID";
        public static string ID_T2_select_FunctionType_typeofServiceID = "typeofServiceID";
        public static string ID_T2_select_JobClassification_typeofServiceID = "typeofServiceID";
        public static string ID_T2_btn_SaveContinue_btnSaveCont = "btnSaveCont";
        public static string ID_T2_Typeahead_JobTitle_txtJobTitle = "txtJobTitle";
        public static string ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup = "ui-dialog-title-PleaseWaitPopup";
        public static string ID_T2_txt_JobDescription_jobDescription = "jobDescription";
        public static string ID_T2_txt_SkillMandatory_skillDescMandatory = "skillDescMandatory";
        public static string ID_T2_txt_SkillDesired_skillDescDesired = "skillDescDesired";
        public static string ID_T2_txt_IdealCandidate_skillDescDesired = "skillDescDesired";
        public static string ID_T2_txt_SkillMatrix_skillName = "skillName";
        public static string ID_T2_txt_SkillDescription_skillDescription = "skillDescription";
        public static string ID_T2_Radiobtn_Level_skillLevelID = "skillLevelID";
        public static string ID_T2_select_year_skillYearsExpID = "skillYearsExpID";
        public static string ID_T2_select_Catgerory_specialNeedCategoryID = "specialNeedCategoryID";
        public static string ID_T2_txt_Description_specialNeedDescription = "specialNeedDescription";
        public static string ID_T2_Radiobutton_mandatoryPrestartTrue = "mandatoryPrestartTrue";
        public static string ID_T2_Radiobutton_mandatoryPrestartFalse = "mandatoryPrestartFalse";
        public static string ID_T2_Radiobutton_Recurring_recurringScheduleTrue = "recurringScheduleTrue";
        public static string ID_T2_select_Recurringfrequency_ddlFrequency = "ddlFrequency";
        public static string ID_T2_Radiobutton_Recurring_recurringScheduleFalse = "recurringScheduleFalse";
        public static string ID_T2_Radiobutton_InterviewRequired_interviewRequired = "interviewRequired";
        public static string ID_T2_Radiobutton_InterviewRequired_interTrue = "interTrue";
        public static string ID_T2_Radiobutton_InterviewRequired_interFalse = "interFalse";
        public static string ID_T2_Radiobutton_Exempt_exemptTrue = "exemptTrue";
        public static string ID_T2_radiobutton_NonExempt_exemptFalse = "exemptFalse";
        public static string ID_T2_Radiobutton_OtAllowed_otTrue = "otTrue";
        public static string ID_T2_Radiobutton_OtAllowed_otFalse = "otFalse";
        public static string ID_T2_Radiobutton_OtLimitation_otLimitTrue = "otLimitTrue";
        public static string ID_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit = "otHoursLimit";
        public static string ID_T2_Radiobutton_IspreApproved_otPreTrue = "otPreTrue";
        public static string ID_T2_Radiobutton_IspreApproved_otPreFalse = "otPreFalse";
        public static string ID_T2_Radiobutton_OtLimitation_otLimitFalse = "otLimitFalse";
        public static string ID_T2_select_Shift_shiftID = "shiftID";
        public static string ID_T2_Amount_shiftDiffPercent = "shiftDiffPercent";
        public static string ID_T2_btn_TravelandAncillaryExpensesyes_expensesTrue = "expensesTrue";
        public static string ID_T2_btn_TravelandAncillaryExpensesNO_expensesFalse = "expensesFalse";
        public static string ID_T2_txt_EstimatedExpenseAmountperResource_expenseFixedAmount = "expenseFixedAmount";
        public static string ID_T2_Radiobutton_TravelRequired_travelTrue = "travelTrue";
        public static string ID_T2_Radiobutton_TravelRequired_travelFalse = "travelFalse";
        public static string ID_T2_txt_TravelLocation_travelLocation = "travelLocation";
        public static string ID_T2_txt_TravelDescription_travelDescription = "travelDescription";
        public static string ID_T2_txt_AnticipatedaverageOTperweek_hasOTHours = "hasOTHours";
        public static string ID_T2_txt_Estimatedofweeklyhours_EstWeeklyHours = "EstWeeklyHours";
        public static string ID_T2_txt_EstimatedTotalofHours_approvedTotalHours = "approvedTotalHours";
        public static string ID_T2_select_Currency_currencyID = "currencyID";
        public static string ID_T2_select_ratetype_rateTypeID = "rateTypeID";
        public static string ID_T2_txt_PayRateLow_payRateLow = "payRateLow";
        public static string Id_T2_txt_PayRateHigh_payRateHigh = "payRateHigh";
        public static string ID_T2_txt_Billratelow_billRateLow = "billRateLow";
        public static string ID_T2_txt_Billratehigh_billRateHigh = "billRateHigh";
        public static string ID_t2_txt_EstimatedContractValue_estContractValue = "estContractValue";
        public static string ID_T2_txt_totalContractValue_estContractValue = "estContractValue";
        public static string ID_T2_btn_RateNegotiable_rateNegoTrue = "rateNegoTrue";
        public static string ID_T2_btn_RateNegotiable_rateNegoFalse = "rateNegoFalse";
        public static string ID_T2_btn_tab_second = "tab_second";
        public static string ID_T2_select_LaborCategory_typeofServiceID = "typeofServiceID";
        public static string ID_T3_btn_tab_third = "tab_third";
        public static string ID_T4_btn_tab_fourth = "tab_fourth";
        public static string ID_T5_btn_tab_fifth = "tab_fifth";
        public static string ID_T3_guidelines_guidelineAccepted = "guidelineAccepted";
        public static string ID_T3_SaveContinue_btnGuidelineSaveAndContinue = "btnGuidelineSaveAndContinue";
        public static string ID_T4_btn_SaveContinue_btnQuestionsSaveAndContinue = "btnQuestionsSaveAndContinue";
        public static string ID_select_Employmenttype_employmentTypeID = "employmentTypeID";
        public static string ID_select_YearsExperience_skillYearsExpID = "skillYearsExpID";
        public static string ID_radiobutton_Level_skillLevelID = "skillLevelID";
        public static string ID_radiobutton_FormerEmployee_ExperienceRadio0 = "ExperienceRadio0";
        public static string ID_radiobutton_FormerEmployee_ExperienceRadio1 = "ExperienceRadio1";
        public static string ID_Date_FromerEmployeeFromDate_fromDate1 = "fromDate1";
        public static string ID_Date_FromerEmployeeToDate_toDate1 = "toDate1";
        public static string ID_txt_FromerEmployeeJobTitle_jobTitle = "jobTitle";
        public static string ID_txt_FromerEmployeeSupervisor_supervisorName = "supervisorName";
        public static string ID_radiobutton_FromerContractor_contractor0 = "contractor0";
        public static string ID_radiobutton_FromerContractor_contractor1 = "contractor1";
        public static string ID_Date_FormerContractor_fromDateContractor1 = "fromDateContractor1";
        public static string ID_Date_FormerContractor_toDateContractor1 = "toDateContractor1";
        public static string ID_txt_FromerContractorJobTitle_jobTitle = "jobTitle";
        public static string ID_txt_FromerContractorSupervisor_supervisorName = "supervisorName";
        public static string ID_radiobutton_retiree_RetireeRadio0 = "RetireeRadio0";
        public static string ID_radiobutton_retiree_RetireeRadio1 = "RetireeRadio1";
        public static string ID_Date_RetiredDate_RetiredDate = "RetiredDate";
        public static string ID_txt_RetiredJobTitle_RetiredJobTitle = "RetiredJobTitle";
        public static string ID_txt_CandidateEmail_Email = "Email";
        public static string ID_select_Gender_Gender = "Gender";
        public static string ID_txt_CellPhone_mobilePhone = "mobilePhone";
        public static string ID_txt_SocialSecurityNumber_candidateSSN = "candidateSSN";
        public static string ID_Date_DateofBirth_dob = "dob";
        public static string ID_select_CountryofCitizenship_country = "country";
        public static string ID_txt_Street_address1 = "address1";
        public static string ID_txt_City_city = "city";
        public static string ID_select_State_state = "state";
        public static string ID_txt_Zip_zipcode = "zipcode";
        public static string ID_select_PADSBasisforAction_padsID = "padsID";
        public static string ID_txt_SpouseRelativesName_relativeName = "relativeName";
        public static string ID_Date_OnSiteArrivalDate_processingDate = "processingDate";
        public static string ID_select_FormerEmployee_isFormallyEmployeed = "isFormallyEmployeed";
        public static string ID_select_NativeAmericanFossilOnly_nativeAmericanID = "nativeAmericanID";
        public static string ID_select_Eligibilitytoworkatworklocation_eligibilityID = "eligibilityID";
        public static string ID_txt_Justification_lbljustificationDescription = "lbljustificationDescription";
        //public static string ID_T1_Select_WorkerClassification_laborClassCode = "laborClassCode";
        //public static string ID_T1_Typeahead_Requestor_altHiringManager = "altHiringManager";
        //public static string ID_T1_Typeahead_RequestOwner_hiringManager = "hiringManager";
        public static string ID_T1_Typeahead_Company_deptNumber = "deptNumber";
        //public static string ID_T1_Select_EngagementType_serviceMethodID = "serviceMethodID";
        //public static string ID_T2_Select_GLAccount_GLIdJD = "GLIdJD";
        public static string ID_T2_Select_Business_organizationID = "organizationID";
        public static string ID_T2_btn_RateInformation_rdtypeoption1 = "rdtypeoption1";
        public static string ID_T2_btn_RateInformation_rdtypeoption2 = "rdtypeoption2";
        public static string ID_T2_btn_RateInformation_rdtypeoption3 = "rdtypeoption3";
        public static string ID_T2_btn_RateInformation_rdtypeoption4 = "rdtypeoption4";
        public static string ID_T2_Txt_NottoExceedBillRate_billRateHigh = "billRateHigh";


        //public static string ID_txt_CandidatePayRate_supplierRegPayRate = "supplierRegPayRate";
        //public static string ID_txt_CandidateOTPayRate_supplierOTPayRate = "supplierOTPayRate";
        //public static string ID_txt_BillRate_supplierRegBillRate = "supplierRegBillRate";
        public static string ID_txt_OTBillRate_supplierOTBillRate = "supplierOTBillRate";
        public static string ID_txt_Comments_supplierComments = "supplierComments";
        public static string Xpath_Date_FormerEmployeeFromDate_FromDate = "//*[@id='priorExperienceTable']/tbody/tr[2]/td[1]/img";
        public static string Xpath_Date_FormerEmployeeFromDate_ToDate = "//*[@id='priorExperienceTable']/tbody/tr[2]/td[2]/img";
        //Issue Work Order Po Number
        public static string ID_txt_TimecardApprovers_txtTimecardApprover = "txtTimecardApprover";
        public static string ID_btn_TimecardApproversAdd_addTimecardApproverbtn = "addTimecardApproverbtn";
        public static string ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn = "deleteTimecardApproverbtn";
        public static string ID_Typeahead_ChargeCostCenterNumber_chargeCostCenterId = "chargeCostCenterId";
        public static string ID_Typeahead_BusinessUnit_chargeCostCenterId = "chargeCostCenterId";
        public static string ID_Typeahead_ChargeProjectWBSElement_chargeProjectId = "chargeProjectId";
        public static string ID_Typeahead_ProjectCodeCFR_chargeProjectId = "chargeProjectId";
        public static string ID_select_GLNumber_chargeGLId = "chargeGLId";
        public static string ID_select_ObjectAccount_chargeGLId = "chargeGLId";
        public static string ID_select_CompanyCode_chargedeptNumber = "chargedeptNumber";
        public static string ID_btn_ChargeNumberAdd_addChargeNobtnNew = "addChargeNobtnNew";
        public static string ID_btn_ChargeNumberDelete_deleteChargeNobtnNew = "deleteChargeNobtnNew";
        public static string ID_txt_CandidatePayRate_supplierRegPayRate = "supplierRegPayRate";
        public static string ID_Date_StartDate_preferredStartDate = "preferredStartDate";
        public static string ID_Date_AnticipatedStartDate_preferredStartDate = "preferredStartDate";
        public static string ID_Date_NeededStartDate_preferredStartDate = "preferredStartDate";
        public static string ID_Date_Enddate_endDate = "endDate";
        public static string ID_Date_AssignmentEndDate_endDate = "endDate";
        public static string ID_Txt_PoNumber_purchaseOrderNumber = "purchaseOrderNumber";
        public static string ID_txt_CandidateOTPayRate_supplierOTPayRate = "supplierOTPayRate";
        public static string ID_txt_SupplierBillRate_supplierRegBillRate = "supplierRegBillRate";
        public static string ID_txt_BillRate_supplierRegBillRate = "supplierRegBillRate";
        public static string ID_txt_SupplierOTBillRate_supplierOTBillRate = "supplierOTBillRate";
        public static string ID_txt_FinalBillRate_finalRegBillRate = "finalRegBillRate";
        public static string ID_txt_FinalOTBillRate_finalOTBillRate = "finalOTBillRate";
        public static string ID_txt_SupplierMarkup_supplierMarkupRate = "supplierMarkupRate";
        public static string ID_txt_MspFeemarkup_mspFeeMarkup = "mspFeeMarkup";
        public static string ID_txt_MspFee_mspRegBillRate = "mspRegBillRate";
        public static string ID_txt_MSPRate_mspRegBillRate = "mspRegBillRate";
        public static string ID_txt_MspOtFee_mspOTBillRate = "mspOTBillRate";
        public static string ID_txt_MSPOTRate_mspOTBillRate = "mspOTBillRate";
        public static string ID_txt_MSPOTBillRate_mspOTBillRate = "mspOTBillRate";
        public static string ID_txt_HoursperweekNTE_weeklyRegHoursNTE = "weeklyRegHoursNTE";
        public static string ID_txt_OThoursperweekNTE_weeklyOTHoursNTE = "weeklyOTHoursNTE";
        public static string ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE = "yearlyRegHoursNTE";
        public static string ID_txt_EstimatedContractValue_totalContractValue = "totalContractValue";
        public static string ID_txt_IW_TotalContractValue_totalContractValue = "totalContractValue";
        public static string ID_txt_GLNumbers_txtGLNo = "txtGLNo";
        public static string ID_btn_GLNumberAdd_addGLNobtn = "addGLNobtn";
        public static string ID_btn_GLNumberDelete_deleteGLNobtn = "deleteGLNobtn";




        //Confirm CW
        public static string ID_txt_LastName_lastName = "lastName";
        public static string ID_txt_LegalLastName_lastName = "lastName";
        public static string ID_txt_LegalFirstName_firstName = "firstName";
        public static string ID_txt_FirstName_firstName = "firstName";
        public static string ID_txt_MiddleName_middleName = "middleName";
        public static string ID_txt_Suffix_nameSuffix = "nameSuffix";
        public static string ID_select_Suffix_nameSuffix = "nameSuffix";
        public static string ID_btn_CWUseryes_isCWuser1 = "isCWuser1";
        public static string ID_btn_CWUserNo_isCWuser0 = "isCWuser0";
        public static string ID_txt_CandidateEmail_candidateEmail = "candidateEmail";
        public static string ID_txt_LegalEntity_association = "association";
        public static string ID_txt_WorkingTitle_jobTitleName = "jobTitleName";
        public static string ID_select_TypeofService_serviceType = "serviceType";
        public static string ID_select_FunctionType_serviceType = "serviceType";
        public static string ID_select_JobClassificationTos_serviceType = "serviceType";
        public static string ID_select_OrganizationName_organization = "organization";
        public static string ID_select_BusinessUnit_organization = "organization";
        public static string ID_select_AccountCode_organization = "organization";
        public static string ID_select_BusinessArea_organization = "organization";
        public static string ID_select_Organization_organization = "organization";
        public static string ID_txt_JobCode_JobCode = "JobCode";
        public static string ID_txt_ServiceDept_ServDept = "ServDept";
        public static string ID_txt_ProductDept_ProDept = "ProDept";
        public static string ID_typeahead_POCostCenter_CostCenterId = "CostCenterId";
        public static string ID_typeahead_APCostCenter_CostCenterId = "CostCenterId";
        public static string ID_select_CostCenter_CostCenterId = "CostCenterId";
        public static string ID_Typeahead_CostCenter_CostCenterId = "CostCenterId";
        public static string ID_Typeahead_BusinessUnit_CostCenterId = "CostCenterId";
        public static string ID_select_JobCategories_serviceType = "serviceType";
        public static string ID_select_Typeofservice_serviceType = "serviceType";
        public static string ID_txt_InternalOrder_matrixNumber = "matrixNumber";
        public static string ID_txt_CT_customerTrackingNumber = "customerTrackingNumber";
        public static string ID_txt_EmployeeID_customerTrackingNumber = "customerTrackingNumber";
        public static string ID_txt_VIPNumber_customerTrackingNumber = "customerTrackingNumber";
        public static string ID_txt_WorkdayEmployeeID_customerTrackingNumber = "customerTrackingNumber";
        public static string ID_txt_UltiproID_CustomerTrackingNumber2 = "CustomerTrackingNumber2";
        public static string ID_txt_NEATID_CustomerTrackingNumber2 = "CustomerTrackingNumber2";
        public static string ID_txt_LMPID_CustomerTrackingNumber3 = "CustomerTrackingNumber3";
        public static string ID_select_PayGroup_AccountType = "AccountType";
        public static string ID_txt_BadgeNumber_badgeNumber = "badgeNumber";
        //public static string ID_select_AccountType_AccountType = "AccountType";
        public static string ID_select_Program_programName = "programName";
        public static string ID_select_GLAccount_GLId = "GLId";
        public static string ID_Typeahead_GeneralLedgerAccount_GLId = "GLId";
        public static string ID_select_GeneralLedgerAccount_GLId = "GLId";
        public static string ID_select_ObjectAccount_GLId = "GLId";
        public static string ID_btn_ExemptNonExempt_exemptFlag = "exemptFlag";
        public static string ID_btn_ChargingMethod_exemptFlag = "exemptFlag";
        public static string ID_Typeahead_WorkLocation_workLocationID = "workLocationID";
        public static string ID_Select_WorkLocation_workLocationID = "workLocationID";
        public static string ID_select_AcessLocation_siteLocationID = "siteLocationID";
        public static string ID_select_PersonnelArea_workLocationID = "workLocationID";
        public static string ID_Typeahead_HiringManager_hiringManagerName = "hiringManagerName";
        public static string ID_txt_JustificationToHire_JustificationtoHire = "JustificationtoHire";
        public static string ID_Typeahead_EngagingManager_hiringManagerName = "hiringManagerName";
        public static string ID_Typeahead_AltHiringManager_alternateHiringManagerName = "alternateHiringManagerName";
        public static string ID_Typeahead_Supervisor_alternateHiringManagerName = "alternateHiringManagerName";
        public static string ID_Typeahead_FinancialPartner_alternateHiringManagerName = "alternateHiringManagerName";
        public static string ID_select_ReqType_reqType = "reqType";
        public static string ID_txt_Keywords_cwKeyWords = "cwKeyWords";
        public static string ID_select_EmployementType_employmentTypeID = "employmentTypeID";
        public static string ID_txt_Last4DigitsofSSN_STID1 = "STID1";
        //   public static string ID_txt_Last4digitsofssn_STID1 = "STID1";
        public static string ID_select_SSNMonth_STID2 = "STID2";
        public static string ID_select_SSNDate_STID3 = "STID3";
        public static string ID_select_SSNYear_STID4 = "STID4";
        public static string ID_select_Month_STID2 = "STID2";
        public static string ID_select_Date_STID3 = "STID3";
        public static string ID_Typeahead_Supplier_supplierName = "supplierName";
        public static string ID_select_SupplierContact_supplierContact = "supplierContact";
        public static string ID_select_InvoicePaymentContact_invoicePaymentContact = "invoicePaymentContact";
        public static string ID_txt_TimecardApprover_txtTimecardApprover = "txtTimecardApprover";
        public static string ID_btn_TimecardApproveradd_addTimecardApproverbtn = "addTimecardApproverbtn";
        public static string ID_btn_TimecardApproverdelete_deleteTimecardApproverbtn = "deleteTimecardApproverbtn";
        public static string ID_typeahead_CostCenterNumber_chargeCostCenterNumber = "chargeCostCenterNumber";
        public static string ID_select_GLNumber_GLAccounts = "GLAccounts";
        public static string ID_txt_LegalEntity_chargeassociation = "chargeassociation";
        public static string ID_txt_ProductDept_chargeProDept = "chargeProDept";
        public static string ID_txt_Location_Location = "Location";
        public static string ID_txt_ServiceDept_chargeServDept = "chargeServDept";
        public static string ID_txt_InterCompany_IntComp = "IntComp";
        public static string ID_btn_ChargeNumberAdd_AddCostOrgLegalGL = "AddCostOrgLegalGL";
        public static string ID_btn_ChargeNumberDelete_deleteDivChargeNobtn = "deleteDivChargeNobtn";
        public static string ID_select_RateType_rateTypeID = "rateTypeID";
        public static string ID_btn_Union_directIndirect = "directIndirect";
        public static string ID_select_Timesheetstartdayoftheweek_dayID = "dayID";
        public static string ID_select_UnionName_ddlaborClassCode = "ddlaborClassCode";
        public static string ID_select_HeadcountApproved_ddlaborClassCode = "ddlaborClassCode";
        public static string ID_select_SCAPosition_ddlaborClassCode = "ddlaborClassCode";
        public static string ID_txt_PONumber_purchaseOrderNumber = "purchaseOrderNumber";
        public static string ID_btn_Timesheet_FromSTTimeSheet = "FromSTTimeSheet";
        public static string ID_select_TimesheetStartDateoftheWeek_dayID = "dayID";
        public static string ID_Date_GoLiveDate_cwGoLiveDate = "cwGoLiveDate";
        public static string ID_select_AccountType_AccountType = "AccountType";
        public static string ID_select_Shift_ShiftId = "ShiftId";
        public static string ID_select_WorkWeek_workweek = "workweek";
        //  public static string ID_Date_AnticipatedStartDate_preferredStartDate = "preferredStartDate";
        // public static string ID_Date_StartDate_preferredStartDate = "preferredStartDate";
        public static string ID_Date_PlannedEndDate_endDate = "endDate";
        public static string ID_btn_IndependentConsultant_IndependentConsultant = "IndependentConsultant";
        public static string ID_txt_ProposedPayRate_regPayRate = "regPayRate";
        public static string ID_txt_ProposedOtPayRate_OTPayRate = "OTPayRate";
        public static string ID_txt_ProposedBillRate_regBillRate = "regBillRate";
        public static string ID_txt_ProposedOtBillRate_OTBillRate = "OTBillRate";
        //    public static string ID_txt_CandidatePayRate_supplierRegPayRate = "supplierRegPayRate";
        public static string ID_txt_CandidateOtPayrate_supplierOTPayRate = "supplierOTPayRate";
        //  public static string ID_txt_SupplierMarkup_supplierMarkupRate = "supplierMarkupRate";
        //public static string ID_txt_SupplierBillRate_supplierRegBillRate = "supplierRegBillRate";
        public static string ID_txt_SupplierOtBillRate_supplierOTBillRate = "supplierOTBillRate";
        public static string ID_txt_FinalBillRate_FinalBillRate = "FinalBillRate";
        public static string ID_txt_FinalOtBillRate_FinalOTBillRate = "FinalOTBillRate";
        public static string ID_txt_DTPayRate_dtPayRate = "dtPayRate";
        public static string ID_txt_FinalDTBillRate_finalDTBillRate = "finalDTBillRate";
        public static string ID_txt_MSPDoubleTimeBillRate_mspDTBillRate = "mspDTBillRate";
        public static string ID_txt_MSPDTBillRate_mspDTBillRate = "mspDTBillRate";
        public static string ID_txt_SupplierDtBillRate_SupplierDTBillRate = "SupplierDTBillRate";
        public static string ID_txt_MSPFeeMarkup_mspFeeMarkup = "mspFeeMarkup";
        public static string ID_txt_MSPFee_mspRegBillRate = "mspRegBillRate";
        public static string ID_txt_MSPOtFee_mspOTBillRate = "mspOTBillRate";
        public static string ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE = "weeklyRegHoursNTE";
        public static string ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE = "weeklyOTHoursNTE";
        // public static string ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE = "yearlyRegHoursNTE";
        public static string ID_txt_TotalContractValue_totalContractValue = "totalContractValue";
        public static string ID_btn_Retiree_isRetiree = "isRetiree";
        //public static string ID_Date_RetiredDate_RetiredDate = "RetiredDate";
        public static string ID_txt_JobTitle_RetiredJobTitle = "RetiredJobTitle";
        public static string ID_txt_PayRateSaving_payRateSavings = "payRateSavings";
        public static string ID_txt_SupplierBillRateSavings_supplierBillRateSavings = "supplierBillRateSavings";
        public static string ID_select_SavingsCategory_savingsTypeID = "savingsTypeID";
        public static string ID_txt_OneTimeSavings_oneTimeSavings = "oneTimeSavings";
        public static string ID_txt_SavingsCommands_savingComment = "savingComment";
        public static string ID_select_Paycode_paycodeId = "paycodeId";
        public static string ID_txt_payrate_payCodePayRate = "payCodePayRate";
        public static string ID_txt_SupplierBillRate_payCodeSupplierBillrate = "payCodeSupplierBillrate";
        public static string ID_txt_FinalBillRate_payCodeFinalBillRate = "payCodeFinalBillRate";
        public static string ID_select_Country_SCountry = "SCountry";
        public static string ID_select_State_SState = "SState";
        public static string ID_select_County_SCounty = "SCounty";
        public static string ID_select_LaborCategory_serviceMethodID = "serviceMethodID";
        public static string ID_select_HRCostCenter_programName = "programName";
        public static string ID_Typeahead_AccountingUnit_deptNumber = "deptNumber";
        public static string ID_select_CompanyCode_deptNumber = "deptNumber";
        public static string ID_txt_Dept_deptNumber = "deptNumber";
        public static string ID_Typeahead_AccountingUnitName_deptName = "deptName";
        public static string ID_txt_DeptName_deptName = "deptName";
        public static string ID_txt_DeptDescription_deptName = "deptName";
        public static string ID_select_SiteLocation_siteLocationID = "siteLocationID";
        public static string ID_select_SecurityClearance_SecurityClearance = "SecurityClearance";
        public static string ID_select_ClearanceStatus_ClearanceStatus = "ClearanceStatus";
        public static string ID_Typeahead_ProjectWBSElement_ProjectId = "ProjectId";
        public static string ID_text_ProjectCodeCFR_ProjectId = "ProjectId";
        public static string ID_text_ReasonForHire_reasonToHire = "reasonToHire";
        public static string ID_text_ReasonForEngagement_reasonToHire = "reasonToHire";
        public static string ID_select_PayCodeGroup_payCodeGroupId = "payCodeGroupId";
        public static string ID_select_PayCode_paycodeId = "paycodeId";
        public static string ID_text_PayRate_payCodePayRate = "payCodePayRate";
        public static string ID_text_SupplierBillRate_payCodeSupplierBillrate = "payCodeSupplierBillrate";
        public static string ID_text_FinalBillRate_payCodeFinalBillRate = "payCodeFinalBillRate";
        public static string Xpath_PayCode_PayCode = "//*[@id='payCodeId_fromGroup']/following-sibling::div/button/span";



        //Confirm CW Timesheet 
        public static string ID_Click_Timesheet_FromSTTimeSheet = "FromSTTimeSheet";





        public static string ID_txtAssociation = "association";
        public static string ID_selectHiringManager = "hiringManager";
        public static string ID_txtHiringManager = "txtHiringManager";
        public static string ID_selectAltHiringManager = "altHiringManager";
        public static string ID_selectpriority = "priority";
        public static string ID_selectworkScheduleID = "workScheduleID";
        public static string ID_txtnoofresources = "noofresources";
        public static string ID_selectreasonToHireID = "reasonToHireID";
        public static string ID_txtJustificationtoHire = "JustificationtoHire";
        public static string ID_txtneededStartDate = "neededStartDate";
        public static string ID_txtenddate = "enddate";
        public static string ID_selectworkLocationID = "workLocationID";
        public static string ID_txt_workLocationID = "workLocationID";
        public static string ID_txt_txtSAElastName = "txtSAElastName";
        public static string ID_txt_txtReqNo = "txtReqNo";
        public static string Xpath_Select_PrefferedMethod = "//*[@id='preferredMethod']";
        public static string Xpath_Select_Reason = "//*[@id='releaseReason']";
        public static string ID_txt_txtstartDateTo = "txtstartDateTo";
        public static string ID_txt_SubmitcandidateReqNo = "ReqNo";
        //  public static string ID_Supplier_Submitcandidate_Reqno = "ReqNo";
        public static string ID_txt_txtstartDateFrom = "txtstartDateFrom";
        public static string ID_Search_startDateFrom = "startDateFrom";
        public static string ID_txt_Comp_fromatemplate = "from a template";
        public static string ID_search_startDateTo = "startDateTo";
        public static string ID_search_endDateFrom = "endDateFrom";
        public static string ID_search_endDateTo = "endDateTo";
        public static string ID_Txt_search_Contract = "endDateWithin";
        public static string ID_search_Radio_doNotAll = "doNotAll";
        public static string ID_txt_Comp_template1 = "template1";
        public static string ID_txt_Comp_template2 = "template2";
        public static string ID_txt_Comp_allrequisitions = "all requisitions";
        public static string ID_txt_Comp_fromanexistingrequisition = "from an existing requisition";
        public static string ID_txt_Comp_selecttemplate = "select template";
        public static string ID_txt_Comp_tempSelect1 = "tempSelect1";
        public static string Xpath_payratevalue = "//*[@id='currents']/table/tbody/tr[2]/td[2]/span";
        public static string Xpath_currentsce_EndDate = "//*[@id='currents']/table/tbody/tr[5]/td[4]/span";
        public static string Xpath_currentsce_PayRate = "//*[@id='currents']/table/tbody/tr[2]/td[2]/span";
        public static string Xpath_currentsce_SupplierBillRate = "//*[@id='currents']/table/tbody/tr[3]/td[2]/span";
        public static string ID_txt_POnumber = "poNumber";


        public static string ID_dlgBox_dlgConfirmSuppliers = "dlgConfirmSuppliers";
        public static string ID_btn_btnSaveCont = "btnSaveCont";
        public static string ID_selectworkLocationAddress = "workLocationAddress";
        public static string ID_btntab_first = "tab_first";
        public static string ID_selecttypeofServiceID = "typeofServiceID";
        public static string ID_txtJobTitle = "txtJobTitle";
        public static string ID_txtskillDescMandatory = "skillDescMandatory";
        public static string ID_txtskillDescDesired = "skillDescDesired";
        public static string ID_txtskillName = "skillName";
        public static string ID_txtskillDescription = "skillDescription";
        public static string ID_RadioBtnskillLevelID = "skillLevelID";
        public static string ID_select_skillYearsExpID = "skillYearsExpID";
        public static string ID_select_specialNeedCategoryID = "specialNeedCategoryID";
        public static string ID_txt_specialNeedDescription = "specialNeedDescription";
        public static string ID_Radiobtn_mandatoryPrestartTrue = "mandatoryPrestartTrue";
        public static string ID_Radiobtn_mandatoryPrestartFalse = "mandatoryPrestartFalse";
        public static string ID_Radiobtn_recurringScheduleTrue = "recurringScheduleTrue";
        public static string ID_Radiobtn_recurringScheduleFalse = "recurringScheduleFalse";
        public static string ID_Select_ddlFrequency = "ddlFrequency";
        public static string ID_Radio_interTrue = "interTrue";
        public static string ID_Radio_interFalse = "interFalse";
        public static string ID_Radio_travelTrue = "travelTrue";
        public static string ID_Radio_travelFalse = "travelFalse";
        public static string ID_Txt_travelLocation = "travelLocation";
        public static string ID_Txt_EstimatedExpenseAmount = "expenseFixedAmount";
        public static string ID_Txt_travelDescription = "travelDescription";
        public static string ID_Txt_payRateLow = "payRateLow";
        public static string ID_Txt_payRateHigh = "payRateHigh";
        public static string ID_Txt_billRateLow = "billRateLow";
        public static string ID_Txt_billRateHigh = "billRateHigh";
        public static string ID_Txt_estContractValue = "estContractValue";
        public static string ID_Radio_rateNegoTrue = "rateNegoTrue";
        public static string ID_Radio_rateNegoFalse = "rateNegoFalse";
        public static string ID_Radio_rateConTrue = "rateConTrue";
        public static string ID_Radio_rateConFalse = "rateConFalse";
        public static string ID_Radio_otTrue = "otTrue";
        public static string ID_Radio_otFalse = "otFalse";
        public static string ID_Txt_otHoursLimit = "otHoursLimit";
        public static string ID_Radio_otPreTrue = "otPreTrue";
        public static string ID_Radio_otPreFalse = "otPreFalse";
        public static string ID_Radio_otLimitTrue = "otLimitTrue";
        public static string ID_Radio_otLimitFalse = "otLimitFalse";
        public static string ID_Radio_exemptTrue = "exemptTrue";
        public static string ID_Radio_exemptFalse = "exemptFalse";
        public static string ID_Radio_MileageReimbursementTrue = "perdiemTrue";
        public static string ID_Radio_MileageReimbursementFalse = "perdiemFalse";
        public static string ID_Radio_TravelAncillary_expensesTrue = "expensesTrue";
        public static string ID_Radio_TravelAncillary_expensesFalse = "expensesFalse";
        public static string ID_Select_shiftID = "shiftID";
        public static string ID_btn_tab_second = "tab_second";
        public static string ID_btn_Saveanddarft = "txtSaveDraft";
        public static string ID_btn_tab_second_saveandcontinue = " btnJobSaveAndContinue";
        public static string ID_Chkbox_guidelineAccepted = "guidelineAccepted";
        public static string ID_Radio_defaultWorkflow = "defaultWorkflow";
        public static string ID_Radio_createNewworkflow = "createNewworkflow";
        public static string ID_btn_tab_third = "tab_third";
        public static string ID_btn_tab_fourth = "tab_fourth";
        public static string ID_btn_tab_fifth = "tab_fifth";
        public static string Xpath_txt_RequistioninprogressSearch = "//*[@id='HistoryTableViewProgReg_filter']/label/input";
        public static string Xpath_Link_EditRequistioninprogress = "//*[@id='HistoryTableViewProgReg']/tbody/tr[1]/td[10]/a[1]/img";
        public static string Xpath_btn_Requirement_SecondTab = "//*[@id='wizard']/ul/li[2]";
        public static string ID_link_txt_Req_Number = "txtFocusColour";
        // public static string ID_link_txt_Req_Number = "txtFocusColour specialLink";
        public static string ID_Err_Msg = "clear";
        public static string ID_List_regReqList_info = "regReqList_info";
        public static string ID_List_regReqList_next = "regReqList_next";
        public static string ID_List_listMenu1 = "listMenu1";
        public static string ID_List_listMenu2 = "listMenu2";
        public static string ID_ApproveRateChnage = "ApproveWithPO";
        public static string ID_Txt_TxtComment = "TxtComment";
        public static string ID_List_regReqList = "regReqList";
        public static string ID_List_GLId_chosen = "GLId_chosen";
        public static string ID_Txt_ServDept = "ServDept";
        public static string ID_Txt_ProDept = "ProDept";
        public static string ID_Radio_CWUser_Yes = "isCWuser1";
        public static string ID_Radio_CWUser_NO = "isCWuser0";
        public static string ID_CandidateEmail = "candidateEmail";
        public static string ID_Select_RejectOfferReason = "RejectOfferReason";
        // public static string ID_Txt_RejectOfferComment = "Comment";
        public static string ID_Txt_programId = "programId";

        public static string ID_Select_txtOrganization = "txtOrganization";
        public static string ID_Select_txtLocationType = "txtLocationType";

        public static string ID_Button_DistributionList = "DistributionList";
        public static string ID_Button_DistributionList_PayRateMarkup = "PayRateMarkup";
        public static string ID_Button_GeographicalLocation = "GeographicalLocation";
        public static string ID_Button_BroadcastSVMS = "BroadcastSVMS";

        public static string ID_Select_ddlDistList = "ddlDistList";
        public static string ID_Select_ddlTiers = "ddlTiers";
        public static string ID_Select_ddlGeoLocation = "ddlGeoLocation";

        public static string ID_CheckBox_chkSelectAll = "chkSelectAll";

        public static string ID_Txt_lblMarkupText = "lblMarkupText";
        public static string ID_Txt_ddlBillratesLow = "ddlBillratesLow";
        public static string ID_Txt_ddlBillratesHigh = "ddlBillratesHigh";

        public static string ID_Txt_payRateMin = "payRateMin";
        public static string ID_Txt_payRateMax = "payRateMax";

        public static string ID_Button_viewSuppliers = "viewSuppliers";
        public static string ID_CheckBox_rateLevel = "rateLevel";

        public static string ID_Table_tblSuppliers = "tblSuppliers";

        // public static string ID_Txt_txtGolbalFilterReqs = "txtGolbalFilterReqs";
        public static string ID_Txt_txtGolbalFilterReqs = "HistoryTableViewSuppReqs_filter";

        public static string ID_Txt_LastName = "LastName";
        //public static string ID_Txt_LastName1 = "lastName";
        public static string ID_Txt_FirstName = "FirstName";
        public static string ID_Txt_MiddleName = "MiddleName";
        public static string ID_Txt_CandidateEmail = "candidateEmail";
        public static string ID_Txt_LocationCity = "LocationCity";
        public static string ID_Select_StateID = "StateID";
        public static string ID_RadioButton_AvailableStatus = "AvailableStatus";
        public static string ID_Txt_ATSIDField = "ATSID";
        public static string ID_Radio_Employement_Yes = "Employment1";
        public static string ID_Radio_Employement_NO = "Employment0";
        public static string ID_Txt_Military_Employment = "EmploymentDetails";
        public static string ID_Txt_Keywords = "Keywords";
        public static string ID_Select_MyResumesID = "MyResumesID";
        public static string ID_Button_refreshButton = "refreshButton";
        public static string ID_Button_addToResumeBankButton = "addToResumeBankButton";
        public static string ID_ListInfo_resumeBankList_info = "resumeBankList_info";

        public static string ID_Select_Suffix_SuffixName = "SuffixName";
        public static string ID_select_Country_country = "Country";
        public static string ID_select_City_city = "city";
        public static string ID_Txt_SSN = "SSN";
        public static string ID_Select_SuffixName = "SuffixName";
        public static string ID_RadioButton_Available = "Available";
        public static string ID_RadioButton_Available_no = "Available0";
        public static string ID_Txt_LastName_LastName = "LastName";
        public static string ID_Txt_FirstName_FirstName = "FirstName";
        public static string ID_Txt_AvailableDate = "AvailableDate";
        public static string ID_RadioButton_Available_Available = "Available1";
        public static string ID_Button_saveandcontinue_btnSubmit = "btnSubmit";
        public static string ID_Select_StatesID = "StatesID";
        public static string ID_Select_RecruiterName = "RecruiterName";
        public static string NAME_icon_UploadResume_uploadResume = "uploadResume";
        public static string NAME_uploadresume = "uploadResume";
        public static string NAME_icon_UploadResume_qqfile = "qqfile";
        public static string ID_RadioButton_Employment = "Employment";//1 or 0
        //public static string ID_Select_securityClearanceLevelID = "securityClearanceLevelID";
        public static string ID_RadioButton_Security = "Security";
        public static string ID_Txt_ATSID = "ATSID";
        public static string ID_Txt_Available = "Available1";
        public static string ID_Rdio_Language = "language";
        public static string ID_Selectlanguage = "languageID";
        public static string Xpath_Selectlanguage = "//*[@id='divlanguage']/div/div/button/b";
        public static string Xpath_Selectlanguagechckbox = "//*[@id='divlanguage']/div/div/ul/li[2]/a/label/input";

        public static string ID_Link_btnresumeupload = "btnresumeupload";
        public static string ID_Link_btnresumeupload_reuirement = "btnjobdocupload";
        public static string ID_Link_btnresume_sendsupplier = "SendtoSuppliersyes";
        public static string ID_Button_btnSubmit = "btnSubmit";

        public static string Id_btnSaveAsTemplate = "btnSaveAsTemplate";
        public static string Id_Txt_TemplateName = "templateName";


        public static string NAME_Link_qqfile = "qqfile";

        public static string ID_RadioButton_RetireeRadio = "RetireeRadio";
        public static string ID_RadioButton_RetireeYes = "RetireeRadio1";
        public static string ID_RadioButton_RetireeNo = "RetireeRadio0";

        public static string ID_Txt_RetiredDate = "RetiredDate";
        public static string ID_Txt_RetiredJobTitle = "RetiredJobTitle";
        public static string ID_Txt_supplierComments = "supplierComments";
        public static string ID_RadioButton_ExperienceRadio = "ExperienceRadio";
        public static string ID_RadioButton_ExperienceRadioYes = "ExperienceRadio1";
        public static string ID_RadioButton_ExperienceRadioNo = "ExperienceRadio0";
        public static string ID_Txt_fromDate1 = "fromDate1";
        public static string ID_Txt_toDate1 = "toDate1";
        public static string ID_Txt_jobTitle = "jobTitle";
        public static string ID_Txt_supervisorName = "supervisorName";

        public static string ID_RadioButton_contractor = "contractor";
        public static string ID_RadioButton_contractorYes = "contractor1";
        public static string ID_RadioButton_contractorNo = "contractor0";
        public static string ID_Txt_fromDateContractor1 = "fromDateContractor1";
        public static string ID_Txt_toDateContractor1 = "toDateContractor1";
        // jobTitle
        public static string ID_Txt_finalRegBillRate = "finalRegBillRate";
        public static string ID_Txt_finalOTBillRate = "finalOTBillRate";
        public static string ID_List_ApproverList = "ApproverList";
        public static string ID_Txt_proposedRegPayRate = "proposedRegPayRate";
        public static string ID_Txt_proposedOTPayRate = "proposedOTPayRate";
        public static string ID_Txt_payRateMarkup = "payRateMarkup";
        public static string ID_Txt_FinalOTBillRate_ConfirmCW = "FinalOTBillRate";

        public static string ID_Select_employmentTypeID = "employmentTypeID";
        public static string ID_Select_ACA_Compliant_HealthID = "ACACompliantHealthCoverage";
        public static string ID_Select_ACA_Cost_PerID = "ACACostPer";
        public static string ID_Txt_ACA_CostID = "ACACost";

        public static string ID_Txt_supplierRegPayRate = "supplierRegPayRate";
        public static string ID_Txt_supplierOTPayRate = "supplierOTPayRate";
        public static string ID_Txt_supplierRegBillRate = "supplierRegBillRate";
        public static string ID_Txt_supplierOTBillRate = "supplierOTBillRate";
        public static string ID_Txt_supplierMarkupRate = "supplierMarkupRate";


        public static string ID_Error_rh_contentContainer = "rh_contentContainer";

        public static string ID_ListInfo_HistoryTableViewSuppReqs = "HistoryTableViewSuppReqs";
        public static string ID_ListInfo_HistoryTableViewCandidate = "HistoryTableViewCandidate";
        public static string ID_ListInfo_HistoryTableViewDiscoverCandidate = "HistoryTableViewCCandidate";


        public static string ID_Txt_DateId1 = "DateId1";
        //public static string XPath_Img_DateId1 = "/div[@id='CandidateActioncontent']/table/tbody/tr[4]/td[2]/img";
        public static string ID_Txt_DateId2 = "DateId2";
        // public static string XPath_Img_DateId2 = "//div[@id='CandidateActioncontent']/table/tbody/tr[5]/td[2]/img";
        public static string ID_Select_Time1 = "Time1";
        public static string ID_Select_Time2 = "Time2";
        public static string ID_Select_Zone1 = "Zone1";
        public static string ID_Select_Zone2 = "Zone2";
        public static string ID_Radio_interviewtype = "interviewtype";
        public static string ID_Radio_interviewtype1 = "interviewtype1";
        public static string ID_TxtTypeHead_approveInput = "approveInput";
        public static string ID_List_addInterviewer = "addInterviewer";
        public static string ID_TxtArea_InterviewAddress = "InterviewAddress";
        public static string ID_Button_addInterviewerbtn = "addInterviewerbtn";
        public static string ID_Chk_CWNeverWorked = "chkCWNeverWorked";
        public static string ID_Button_deleteInterviewerbtn = "deleteInterviewerbtn";
        public static string Radio_Btn_Name_UseDefaultWorkflow = "Use Default Workflow";
        public static string Radio_Btn_Name_CreateNewWorkflow = "Create New Workflow";
        public static string ID_Select_jobCodeID = "jobCodeID";






        public static string CL_ShowAllClient = "styled-select";
        public static string CL_DisplayAllClient = "ui-autocomplete ui-menu ui-widget ui-widget-content ui-corner-all";
        //public static string CL_list_typeahead = "list-typeahead";
        //public static string CL_list_typeahead = "list-typeahead shadow";


        public static string CSS_Date_datepicker_trigger = "img.ui-datepicker-trigger";
        public static string XPATH_Date_datepicker_trigger = "//*[@id='proposed']/table/tbody/tr[6]/td[2]/img";
        public static string CSS_Date_datepicker_year = "select.ui-datepicker-year";
        public static string CSS_Date_datepicker_month = "select.ui-datepicker-month";
        //  public static string CSS_Date_datepicker_trigger = "img.ui-datepicker-trigger";




        public static string XPath_RadioButton_AcceptRates = "(//input[@name='rbPayRate'])[1]";
        public static string XPath_RadioButton_ProposeDifferentRate = "(//input[@name='rbPayRate'])[2]";



        public static string ID_Txt_Proposebillrate = "Proposebillrate";
        public static string ID_Txt_Proposeotbillrate = "Proposeotbillrate";
        public static string ID_Select_dayID = "dayID";
        public static string ID_Txt_weeklyRegHoursNTE = "weeklyRegHoursNTE";
        public static string ID_Txt_weeklyOTHoursNTE = "weeklyOTHoursNTE";
        public static string ID_Txt_yearlyRegHoursNTE = "yearlyRegHoursNTE";
        public static string ID_Txt_totalContractValue = "totalContractValue";
        // rbEmailwithContractusage ---radio
        public static string ID_RadioButton_Yes_rbEmailwithContractusage = "(//input[@name='rbEmailwithContractusage'])[1]";
        public static string ID_RadioButton_No_rbEmailwithContractusage = "(//input[@name='rbEmailwithContractusage'])[2]";
        public static string ID_Select_ddemailschedule = "ddemailschedule";
        public static string ID_Txt_PrefStartdate = "PrefStartdate";
        public static string ID_Txt_enddate = "enddate";
        public static string ID_Txt_txtTimecardApprover = "txtTimecardApprover";
        public static string ID_Button_addTimecardApproverbtn = "addTimecardApproverbtn";
        public static string ID_Button_deleteTimecardApproverbtn = "deleteTimecardApproverbtn";
        public static string ID_ComboList_addTimecardApprover = "addTimecardApprover";
        public static string ID_Txt_CostCenterNumber = "CostCenterNumber";
        public static string ID_Select_GLAccounts = "GLAccounts";
        // public static string ID_Txt_ProDept = "ProDept";
        public static string ID_Txt_association = "association";
        public static string ID_Txt_Location = "Location";
        //  public static string ID_Txt_ServDept = "ServDept";
        public static string ID_Txt_IntComp = "IntComp";
        public static string ID_Button_AddCostOrgLegalGL = "AddCostOrgLegalGL";
        public static string ID_Button_deleteDivChargeNobtn = "deleteDivChargeNobtn";
        public static string ID_ComboList_addChargeNo = "addChargeNo";
        public static string ID_Button_btnbtnSubmit = "btnbtnSubmit";//
        public static string ID_Button_tab_second = "tab_second";//btnbtnSubmit
        public static string ID_Button_tab_second1 = "tab_second1";//btnbtnSubmit
        public static string ID_Valid_Msg_Error_ulMspUserError = "ulMspUserError";//btnbtnSubmit



        public static string ID_Select_jobTitleID = "jobTitleID";
        public static string ID_Select_KCPLjobTitleID = "txtJobTitle";
        public static string ID_Select_GLIdJD = "GLIdJD";
        public static string ID_Txt_Comments_lbljustificationDescription = "lbljustificationDescription";
        public static string ID_Txt_NottoExceedBillRate_supplierRegBillRate = "supplierRegBillRate";

        public static string ID_PopUpWIN_ui_dialog_title_PleaseWaitPopup = "ui-dialog-title-PleaseWaitPopup";
        public static string ID_Txt_jobDescription = "jobDescription";

        public static string ID_Btn_Submit = "Submit";
        public static string ID_Btn_searchButton1 = "searchButton1";

        public static string ID_Btn_selectcatalog = "select catalog";


        public static string ID_Txt_Proposepayrate = "Proposepayrate";
        public static string ID_Txt_Proposeotpayrate = "Proposeotpayrate";
        public static string ID_Select_Chargenumberlabel = "chargeGLId";
        public static string ID_Select_CostCenterNumber = "chargeCostCenterId";
        public static string ID_Select_chargeProfitCenterId = "chargeProfitCenterId";
        public static string ID_Select_chargedeptNumber = "chargedeptNumber";
        public static string ID_Select_chargeProjectId = "chargeProjectId";
        public static string ID_Select_chargeprogramId = "chargeprogramId";
        public static string ID_Select_chargespendLevelId = "chargespendLevelId";
        public static string ID_Button_addChargeNobtnNew = "addChargeNobtnNew";
        public static string ID_Txt_ProposedFinalRegBillRate = "ProposedFinalRegBillRate";
        public static string ID_Txt_ProposedFinalOTBillRate = "ProposedFinalOTBillRate";
        public static string ID_Txt_txtChargeNo = "txtChargeNo";
        public static string ID_Button_addChargeNobtn = "addChargeNobtn";
        public static string ID_Button_deleteChargeNobtn = "deleteChargeNobtn";
        public static string ID_Txt_txtGLNo = "txtGLNo";
        public static string ID_Button_addGLNobtn = "addGLNobtn";
        public static string ID_Button_deleteGLNobtn = "deleteGLNobtn";
        public static string ID_ComboList_addGLNo = "addGLNo";
        //div[@id='tab_second']/div/button

        public static string ID_Txt_vmsRegBillRate = "vmsRegBillRate";
        public static string ID_Txt_vmsOTBillRate = "vmsOTBillRate";
        public static string ID_Txt_mspRegBillRate = "mspRegBillRate";
        public static string ID_Txt_mspOTBillRate = "mspOTBillRate";
        public static string ID_Txt_purchaseOrderNumber = "purchaseOrderNumber";
        public static string ID_BtnLink_uploadPO = "uploadPO";
        public static string ID_Txt_proposedFinalOTBillRate = "proposedFinalOTBillRate";




        public static string ID_Select_ChargeNumberTypes = "ChargeNumberTypes";
        public static string ID_Button_addDivChargeNobtn = "addDivChargeNobtn";
        public static string ID_Select_WorkLocationCode = "WorkLocationCode";

        public static string ID_Txt_DividedChargenoLabel = "DividedChargenoLabel";//1 to 8
        public static string ID_Txt_AutoFilledChargeNoLabel = "AutoFilledChargeNoLabel";//1 to 7

        public static string ID_Button_addAutoFilledChargeNobtn = "addAutoFilledChargeNobtn";

        public static string ID_tabsAll = "tabsAll";
        public static string ID_Expand_tabsExpandCollapse = "tabsExpandCollapse";

        public static string ID_Txt_mspFeeMarkup = "mspFeeMarkup";
        //public static string ID_Txt_mspRegBillRate = "mspRegBillRate";
        // public static string ID_Txt_mspOTBillRate = "mspOTBillRate";


        public static string ID_Txt_proposedRegBillRate = "proposedRegBillRate";
        public static string ID_Txt_proposedOTBillRate = "proposedOTBillRate";
        public static string ID_Txt_preferredStartDate = "preferredStartDate";
        public static string ID_Txt_endDate = "endDate";


        public static string ID_Txt_homephone = "homephone";
        public static string ID_Txt_email = "email";
        public static string ID_Txt_address1 = "address1";
        public static string ID_Txt_address2 = "address2";
        public static string ID_Txt_city = "city";
        public static string ID_Txt_zip = "zip";
        public static string ID_Select_state = "state";


        public static string ID_Txt_emergencyContact1Name = "emergencyContact1Name";
        public static string ID_Txt_emergencyContact1Phone = "emergencyContact1Phone";
        public static string ID_Txt_emergencyContact2Name = "emergencyContact2Name";
        public static string ID_Txt_emergencyContact2Phone = "emergencyContact2Phone";

        //addDivChargeNobtn
        //deleteDivChargeNobtn

        public static string ID_Select_appStatus = "appStatus";
        public static string ID_Txt_TxtUploadFile = "TxtUploadFile";
        public static string ID_Txt_TxtComments = "TxtComments";

        public static string ID_ListGrid_WorkspaceMSPListGrid = "WorkspaceMSPListGrid";
        public static string ID_ListGrid_TrainAccord = "TrainAccord";
        public static string ID_ListGrid_DocAccord = "DocAccord";
        public static string ID_ListGrid_ComplianceAccord = "ComplianceAccord";


        //public static string XPath_RequisitionType = "//*[@id='ajCallContainer']/div[1]/table/tbody/tr/td[1]/ul/li";
        //public static string XPath_RequisitionType = ".//*[@id='ajCallContainer']/div/table/tbody/tr/td[1]/ul/li[3]";
        public static string XPath_RequisitionType = "//*[@id='ajCallContainer']/div/div[2]/div/div[2]/ul/li";
        public static string XPath_create_RequisitionType = "//*[@id='etkresult']/li";
        // public static string XPath_create_RequisitionType = "//*[@id='etkresult']/li/label/span[2]";
        public static string XPath_RequisitionType_NVEnergy = "//*[@id='ajCallContainer']/div[3]/table/tbody/tr/td/ul/li";
        // public static string XPath_RequisitionType1 = "//*[@id='ajCallContainer']/div[1]/table/tbody/tr/td[1]/ul/li";



        public static string STR_Txt_LogOut = "Log Out";

        // Client Name --> Savi Technologies
        public static string ID_Txt_deptName = "deptName";
        public static string ID_Select_serviceMethodID = "serviceMethodID";
        public static string ID_Txt_deptNumber = "deptNumber";
        public static string ID_Txt_ProjectName = "ProjectName";
        public static string ID_Txt_matrixNumber = "matrixNumber";
        public static string ID_Select_laborClassCode = "laborClassCode";
        public static string ID_Select_programId = "programId";
        public static string ID_Select_directIndirectTrue = "directIndirectTrue";
        public static string ID_Select_directIndirectFalse = "directIndirectFalse";
        public static string ID_Radio_BadgeAccessYes = "laborClassCode57";
        public static string ID_Radio_BadgeAccessNo = "laborClassCode58";
        public static string ID_Radio_Yes_laborClassCode61 = "laborClassCode61";
        public static string ID_Radio_No_laborClassCode62 = "laborClassCode62";
        public static string ID_Radio_Yes_laborClassCode63 = "laborClassCode63";
        public static string ID_Radio_No_laborClassCode64 = "laborClassCode64";

        public static string ID_Radio_Yes_computerAccessTrue = "computerAccessTrue";
        public static string ID_Radio_No_computerAccessFalse = "computerAccessFalse";
        public static string ID_Radio_Yes_ComputerSystemsAccessTrue = "directIndirectTrue";
        public static string ID_Radio_No_ComputerSystemsAccessTrue = "directIndirectFalse";

        //""
        public static string ID_Select_securityClearanceLevelID = "securityClearanceLevelID";
        public static string ID_RadioBtn_CanStartWithoutClearance_Yes = "txtWithoutYes";
        public static string ID_RadioBtn_CanStartWithoutClearance_No = "txtWithoutNo";
        public static string ID_RadioBtn_InterimClearanceSufficient_Yes = "txtSufficientYes";
        public static string ID_RadioBtn_InterimClearanceSufficient_No = "txtSufficientNo";
        public static string ID_Txt_ContractNumber = "txtContractNumber";

        public static string ID_Select_siteLocationID = "siteLocationID";
        public static string ID_type_siteLocationID = "siteLocationID";




        public static string ID_RadioBtn_AccountAssignment = "AccountAssignment";

        public static string ID_Txt_STID = "STID";
        public static string ID_Txt_STID1 = "STID1";


        public static string ID_Txt_jobTitleName = "jobTitleName";
        public static string ID_selectreasonToHire = "reasonToHire";
        public static string ID_Select_Organization = "organization";
        public static string ID_Txt_IndependentConsultant = "IndependentConsultant";
        public static string ID_Select_programName = "programName";
        public static string ID_Select_serviceType = "serviceType";
        public static string ID_Select_reqType = "reqType";
        public static string ID_Txt_JobCode = "JobCode";
        public static string ID_Txt_hiringManagerName = "hiringManagerName";
        public static string ID_Txt_alternateHiringManagerName = "alternateHiringManagerName";
        public static string ID_Txt_cwKeyWords = "cwKeyWords";

        public static string ID_Txt_cwRateType = "rateTypeID";
        public static string ID_Select_supplierContact = "supplierContact";
        public static string ID_Select_invoicePaymentContact = "invoicePaymentContact";
        public static string ID_Txt_customerTrackingNumber = "customerTrackingNumber";
        public static string ID_Txt_customerTrackingNumber2 = "CustomerTrackingNumber2";
        public static string ID_Txt_customerTrackingNumber3 = "CustomerTrackingNumber3";
        public static string ID_RadioBtn_ChargingMethod_exemptFlag = "exemptFlag";
        public static string ID_RadioBtn_Retiree_isRetiree = "isRetiree";
        public static string ID_RadioBtn_Rehire = "exEmployee";

        public static string ID_RadioBtn_TimeSheet_FromSTTimeSheet = "FromSTTimeSheet";
        public static string ID_Txt_badgeNumber = "badgeNumber";
        public static string ID_Select_ddlaborClassCode = "ddlaborClassCode";
        public static string ID_Select_AccountType = "AccountType";
        public static string ID_Select_workweek = "workweek";
        public static string ID_Txt_regPayRate = "regPayRate";
        public static string ID_Txt_OTPayRate = "OTPayRate";
        public static string ID_Txt_regBillRate = "regBillRate";
        public static string ID_Txt_OTBillRate = "OTBillRate";
        public static string ID_Txt_FinalBillRate = "FinalBillRate";
        public static string ID_Select_SecurityClearance = "SecurityClearance";
        public static string ID_Select_ClearanceStatus = "ClearanceStatus";
        public static string ID_Txt_payRateSavings = "payRateSavings";
        public static string ID_Txt_supplierBillRateSavings = "supplierBillRateSavings";
        public static string ID_Txt_oneTimeSavings = "oneTimeSavings";
        public static string ID_Txt_savingComment = "savingComment";
        public static string ID_Txt_finalDTBillRate = "finalDTBillRate";
        public static string ID_Txt_dtPayRate = "dtPayRate";
        public static string ID_Txt_mspDTBillRate = "mspDTBillRate";
        public static string ID_Txt_SupplierDTBillRate = "SupplierDTBillRate";

        public static string ID_Txt_LineItem = "LineItem";
        public static string ID_RadioBtn_WarehouseWorker_directIndirect = "directIndirect";




        public static string ID_Txt_yearsInput = "yearsInput";
        public static string ID_Txt_monthsInput = "monthsInput";



        public static string ID_List_regularCandidateListWithOffer = "regularCandidateListWithOffer";

        public static string ID_Txt_CostCenterId = "CostCenterId";
        public static string ID_Txt_ProfitCenterId = "ProfitCenterId";
        public static string ID_Txt_ProjectId = "ProjectId";
        public static string ID_Txt_GLId_chosen = "GLId_chosen";

        public static string ID_RadioBtn_SpecificIndividualRequired_Yes = "q261";
        public static string ID_RadioBtn_SpecificIndividualRequired_No = "q262";

        public static string ID_Btn_SpecificIndividualRequired = "frmButtonContainer";

        // Service Method ---> ID --> serviceMethodID ---> Select dropdown
        // deptNumber---->ID -----> deptNumber--->type head
        // matrixNumber ---->ID ----->Funding Source  ----> Txt Box
        //laborClassCode  --->ID ----->Headcount Approved ----> Select dropdown
        //programId ---->ID ---->Program  ---->Select dropdown
        //directIndirectTrue --->ID--->Charging Method ----> Radio Button
        //directIndirectFalse --->ID--->Charging Method ----> Radio Button
        //siteLocationID ---->ID ---->Work Region ---->Select dropdown
        //skillRequiredTrue ---> ID ----> Mandatory (Yes/No) ----> Radio Button
        //skillRequiredFalse ---> ID ----> Mandatory (Yes/No) ----> Radio Button


        // public static string CSS_Date_StartDate = "//div[@id='tab_first']/table/tbody/tr[7]/td[2]";
        public static string XPath_Date_EndDate = "(//img[@alt='...'])[2]";
        public static string ID_select_BuyerName_CostCenterId = "CostCenterId";
        public static string XPath_secondrow = "//*[@id='regReqList']/tbody/tr[2]";
        public static string ID_Typeahead_GoodsReceiptApprover_alternateHiringManagerName = "alternateHiringManagerName";
        

        //Effective Date            --> effectiveDate -- ID
        // Date Image //*[@id="proposed"]/table/tbody/tr[1]/td[2]/img
        //New Pay Rate              --> newPayRate -- ID
        //New OT Pay Rate           --> newOTPayRate -- ID
        //New Supplier Bill Rate    --> newRegBillRate -- ID 
        //New Supplier OT Bill Rate --> newOTBillRate -- ID
        //New MSP Fee               --> newMSPRegBillRate -- ID
        //New MSP OT Fee            --> newMSPOTBillRate -- ID
        //New Final Bill Rate       --> newfinalRegBillRate  disable field -- ID
        //New Final OT Bill Rate    --> newfinalOTBillRate   disable field -- ID
        //Additional Amount         --> additonalContractValue -- ID
        //New Job Title             --> txtJobTitle -- ID
        //Justification             --> justification -- ID
        //Upload Justification      --> uploadJustification -- NAME


        public static string ID_Txt_effectiveDate = "effectiveDate";
        public static string ID_Txt_releaseDate = "releaseDate";
        public static string ID_Txt_newPayRate = "newPayRate";
        public static string ID_Txt_newOTPayRate = "newOTPayRate";
        public static string ID_Txt_newRegBillRate = "newRegBillRate";
        public static string ID_Txt_newOTBillRate = "newOTBillRate";
        public static string ID_Txt_newMSPRegBillRate = "newMSPRegBillRate";
        public static string ID_Txt_newMSPOTBillRate = "newMSPOTBillRate";
        public static string ID_Txt_newfinalRegBillRate = "newfinalRegBillRate";
        public static string ID_Txt_newfinalOTBillRate = "newfinalOTBillRate";
        public static string ID_Txt_additonalContractValue = "additonalContractValue";
        public static string ID_Txt_txtJobTitle = "txtJobTitle";
        public static string ID_Txt_justification = "justification";
        public static string Name_Img_uploadJustification = "uploadJustification";
        public static string ID_Btn_searchButton = "searchButton";
        public static string ID_Txt_ResultCWMSP_filter = "ResultCWMSP_filter";
        public static string ID_TableInfo_ResultCWMSP_info = "ResultCWMSP_info";
        public static string XPath_Dilog_dialog = "//*[@id='dialog']/div[1]";
        public static string ID_Txt_PayRateMarkup = "PayRateMarkup";
        public static string ID_ChkBox_preApproved = "preApproved";
        public static string ID_Txt_newEndDate = "newEndDate";
        public static string ID_Radio_Active = "allActive";

        public static string ID_Txt_EstWeeklyHours = "EstWeeklyHours";
        public static string ID_Txt_approvedTotalHours = "approvedTotalHours";
        public static string ID_link_linkhere = "linkhere";
        public static string ID_ChkBox_btnGuidelineSaveAndContinue = "btnGuidelineSaveAndContinue";
        public static string ID_btn_btnQuestionsSaveAndContinue = "btnQuestionsSaveAndContinue";



        public static string Xpath_RadioBtn_rdtypeoption = "//*[contains(@id,'rdtypeoption')]";

        public static string Xpath_RadioBtn_rdtypeoption1 = "//*[@id='rdtypeoption1']";


        //  "cost center"


        public static string str_search_Text = "search";
        public static string ID_Txt_tblJobTitle = "tblJobTitle";
        public static string ID_Btn_submitReq = "submitReq";
        public static string ID_Btn_customizeReq = "customizeReq";
        public static string ID_Error_ulMspUserError = "ulMspUserError";
        public static string ID_Dialog_dialogconfirmapprove2_2 = "dialog-confirmapprove2-2";
        public static string ID_regReqList_paginate = "regReqList_paginate";

        public static string ID_Expense_regReqList_filter = "//*[@id='results_filter']/label/input";
        public static string ID_paginate_regReqList_filter = "//*[@id='regReqList_filter']/label/input";

        public static string Xpath_Search_Myreuistiontemplatesearch = "//*[@id='HistoryTableViewTempReg_filter']/label/input";
        public static string Xpath_link_createrequistion = "//*[@id='HistoryTableViewTempReg']/tbody/tr[1]/td[5]/a[1]/img";

        public static string ID_paginate_regReqList_paginate = "//*[@id='regReqList_paginate']/input";


        public static string ID_Txt_Filter_HistoryTableViewSuppReqs_filter = "//*[@id='HistoryTableViewSuppReqs_filter']/label/input";
        public static string ID_Supplier_Submitcandidate_Reqno = "ReqNo";

        public static string ID_Txt_Filter_HistoryTableViewSuppReqs_filter1 = "CandidateName";

        // public static string ID_Txt_Filter_HistoryTableViewSuppReqs_filter = "//div[@id='HistoryTableViewSuppReqs_filter']/label/input";

        public static string ID_HistoryTableViewSuppReqs_filter = "HistoryTableViewSuppReqs_filter";







        public static string str_search_selectrequisition = "select requisition";
        public static string Xpath_Input_tblJobTitle = "//*[@id='tblJobTitle']/tbody/tr[1]/td[1]/input";


        //Time Sheet


        public static string ID_Select_DefaultContent_CboWorkSchedule = "DefaultContent_CboWorkSchedule";
        public static string ID_ChkBox_DefaultContent_ChkZeroHours = "DefaultContent_ChkZeroHours";
        public static string ID_Txt_txtGen1 = "txtGen1";
        public static string ID_Txt_txtGen2 = "txtGen2";
        public static string ID_Txt_comment = "DefaultContent_txtTaskDescription";
        public static string ID_Select_DefaultContent_CboHoursType = "DefaultContent_CboHoursType";
        public static string ID_Select_DefaultContent_CboShifts = "DefaultContent_CboShifts";
        public static string ID_Select_DefaultContent_cboChargeNumber = "DefaultContent_cboChargeNumber";
        public static string ID_Btn_DefaultContent_btnAddTask = "DefaultContent_btnAddTask";
        public static string ID_Txt_GLAccount = "ddlGen1";
        public static string ID_Btn_DefaultContent_btnSubmit = "DefaultContent_btnSubmit";


        public static string ID_Select_DefaultContent_CboSelect = "DefaultContent_CboSelect";
        public static string ID_Txt_DefaultContent_TxtName = "DefaultContent_TxtName";
        public static string ID_Date_DefaultContent_TxtWeekendFrom = "DefaultContent_TxtWeekendFrom";
        public static string ID_Date_DefaultContent_TxtWeekendTo = "DefaultContent_TxtWeekendTo";
        public static string ID_Select_DefaultContent_CboStatus = "DefaultContent_CboStatus";
        public static string ID_Select_DefaultContent_CboNoRecords = "DefaultContent_CboNoRecords";
        public static string ID_Btn_DefaultContent_btnSearch = "DefaultContent_btnSearch";
        public static string ID_Btn_DefaultContent_btnSearchSAE = "DefaultContent_btnSearchSAE";
        public static string ID_Btn_DefaultContent_btnClearSearch = "DefaultContent_btnClearSearch";
        public static string ID_Txt_Approver_Filter_Awaiting = "Approver_Filter_Awaiting";
        public static string ID_Txt_DefaultContent_dgrAdminTS_filter = "DefaultContent_dgrAdminTS_filter";
        public static string ID_Txt_dgrAdminTS_filter = "dgrAdminTS_filter";

        public static string ID_Btn_DefaultContent_btnMassApproval = "DefaultContent_btnMassApproval";
        public static string ID_Btn_DefaultContent_btnMassReminder = "DefaultContent_btnMassReminder";

        public static string ID_Txt_DefaultContent_CW_Filter = "DefaultContent_CW_Filter";

        public static string ID_Txt_DefaultContent_TxtSAENumber = "DefaultContent_TxtSAENumber";
        public static string ID_Txt_DefaultContent_TxtFirstName = "DefaultContent_TxtFirstName";
        public static string ID_Txt_DefaultContent_TxtLastName = "DefaultContent_TxtLastName";
        public static string ID_Txt_DefaultContent_TxtEmailID = "DefaultContent_TxtEmailID";
        public static string ID_Txt_TxtApprover = "TxtApprover";

        public static string ID_Lable_DefaultContent_LblStatus = "DefaultContent_LblStatus1";
        public static string ID_DisplayText_mainContainer_1 = "mainContainer_1";
        public static string ID_DisplayText_divTimesheetEntry = "divTimesheetEntry";

        public static string ID_Txt_DefaultContent_TxtMultilineDenied = "DefaultContent_TxtMultilineDenied";

        public static string ID_Txt_CW = "CW";
        public static string ID_Txt_PO = "PO";
        public static string ID_Button_btn_Add = "btn_Add";
        public static string ID_Txt_global_filter = "global_filter";
        public static string ID_Txt_batchNumber = "batchNumber";
        public static string ID_Select_cboReson = "cboReson";
        public static string ID_Txt_PANumber = "PANumber";
        public static string ID_Txt_PAAmount = "PAAmount";
        public static string ID_Date_ReceiveDate = "ReceiveDate";
        public static string ID_Txt_checkNumber = "checkNumber";
        public static string ID_Date_checkDate = "checkDate";

        public static string ID_DefaultContent_errorPanel = "DefaultContent_errorPanel";
        public static string ID_DefaultContent_lblError = "DefaultContent_lblError";
        //public static string ID_Menu_gnmenu = "gn-menu";

        public static string ID_Menu_openHome = "openHome";
        // public static string ID_Menu_gnmenu = "imgUserProfile";
        public static string ID_Menu_gnmenu = "//span[@class='thumb-sm avatar']";
        public static string XPath_ProfileMenu_gnmenu = "//ul[@id='gn-menu']/li[9]/div/a";
        public static string XPath_ProfileMenu_gnmenu10 = "//ul[@id='gn-menu']/li[10]/div/a";
        public static string XPath_ProfileMenu = "//ul[@id='profileMenu']/li";
        //public static string XPath_ClientDropDown = "//ul[@id='gn-menu']/li[3]/a/span";
        public static string XPath_ClientDropDown = "//a[@data-menu='clientMenu']/span[@class='caret']";
        public static string XPath_ClientDropDown1 = "//*[@id='clientMenu']/li/input";
        //public static string XPath_ClientMenu = "//ul[@id='clientMenu']/li";
        public static string XPath_ClientMenu = "//*[@id='clientMenu']/li[2]/div/a";
        //public static string XPath_ClientMenu = "//ul[@id='clientMenu']/li";
        //public static string XPath_MainMenu = "//ul[@id='gn-menu']/li/a";
        public static string XPath_MainMenu = "//a[@class='gn-opener gn-icon gn-icon-menu'][@data-toggle='popover']";//As Per new Ui SOW changes with main system
        //public static string XPath_MainMenu_Open = "//*[@id='gn-menu']/li/nav/div/ul/li/span";
        // public static string XPath_MainMenu_Open = "//a[@class='gn-icon gn-parent-menu'][text()='Home']";//As Per new Ui SOW changes with main system
        public static string XPath_MainMenu_Open = "span.ico-icon.icon-library";
        public static string XPath_MainMenu_OpenReadNames = "//*[@id='gn-menu']/li[1]/nav/div/ul/li";

        //public static string XPath_supplierMenu_ClientDropDown = "//ul[@id='gn-menu']/li[4]/a/span";
        public static string XPath_supplierMenu_ClientDropDown = " //a[@data-menu='supplierMenu']/span[@class='caret']";//As Per new Ui SOW changes with main system
        public static string XPath_supplierMenu_ClientDropDown1 = "//ul[@id='gn-menu']/li[4]/a/span";
        // public static string XPath_supplierMenu = "//ul[@id='supplierMenu']/li";
        public static string XPath_supplierMenu = "//*[@id='supplierMenu']/li[2]/div/a";
        public static string XPath_supplierMenu1 = "//*[@id='supplierMenu']/li/input";
        public static string XPath_supplierMenu_Discover = "//*[@id='desktopMenu']/li";

        public static string ID_Select_spendLevelId = "spendLevelId";
        public static string ID_Select_ProfitCenterId = "ProfitCenterId";

        public static string ID_Select_STID3 = "STID3";

        public static string ID_Radio_FormerIntern_Intern1 = "Intern1";
        public static string ID_Radio_FormerIntern_Intern0 = "Intern0";
        public static string ID_Radio_FormerTVC_ContractorReadio0 = "ContractorReadio0";
        public static string ID_Radio_FormerTVC_ContractorReadio1 = "ContractorReadio1";
        public static string ID_Txt_candidateSSN = "candidateSSN";
        public static string ID_Date_DOB = "DOB";

        public static string ID_Select_Country = "Country";
        public static string ID_Select_State = "State";
        public static string ID_Select_County = "County";

        public static string ID_Select_SCountry = "SCountry";
        public static string ID_Select_SState = "SState";
        public static string ID_Select_SCounty = "SCounty";
        public static string ID_FinancialNumber = "financialNumber";


        //Expense
        public static string ID_Select_DDLCWs = "DDLCWs";
        public static string ID_Txt_txtSaeTest = "txtSaeTest";
        public static string ID_Select_txtChargeNumber = "txtChargeNumber_chosen";
        public static string ID_Select_txtCurrency = "txtCurrency";
        public static string ID_Txt_txtTitle = "txtTitle";
        public static string ID_Txt_txtPurpose = "txtPurpose";
        public static string ID_Date_txtDateFrom = "txtDateFrom";
        public static string ID_Date_txtDateTo = "txtDateTo";
        public static string ID_Btn_AddExpSubmit = "AddExpSubmit";
        public static string ID_Select_expensetype = "expensetype";
        public static string ID_Select_paytype = "paytype";
        public static string ID_Txt_txtQuantity = "txtQuantity";
        public static string ID_Txt_txtAmount = "txtAmount";
        public static string ID_Txt_txtDescription = "txtDescription";
        public static string ID_Select_ExpeneseCategory = "ExpeneseCategory";
        public static string ID_Date_txtExpenseDate = "txtExpenseDate";
        public static string ID_Txt_receiptUpload = "receiptUpload";
        public static string ID_Txt_txtInvoiceAmt = "txtInvoiceAmt";
        public static string ID_Txt_ExtInvClose = "ExtInvClose";
        public static string ID_Txt_ExtInvSubmit = "ExtInvSubmit";
        public static string ID_Txt_txtComment = "txtComment";
        public static string ID_Txt_txtInvoiceNo = "txtInvoiceNo";
        public static string ID_Chk_chkExpenseId = "chkExpenseId";
        public static string ID_Btn_ExtInvoice = "ExtInvoice";
        public static string ID_Date_txtInvoiceDate = "txtInvoiceDate";
        public static string ID_frm_frmApprove = "frmApprove";
        public static string ID_dialog_dialogconfirmsub = "dialog-confirmsub";
        public static string ID_dialog_confirmmessageapp = "ui-dialog-title-dialog-confirmmessageapp";
        public static string ID_Txt_notes = "notes";
        public static string ID_dialog_dialogconfirmmessageapprove = "dialog-confirmmessageapprove";
        public static string ID_frm_frmSubmitCustomer = "frmSubmitCustomer";

        public static string XPath_ExpNumber_accordionPin = "//*[@id='accordionPin']/div/div/table/tbody/tr[1]/td[2]";
        public static string ID_Chk_Checkbox3 = "Checkbox3";
        public static string ID_Btn_Payment = "Payment";
        public static string ID_Txt_ChkAmt = "ChkAmt";
        public static string ID_Txt_txtCheckAmount = "txtCheckAmount";
        public static string ID_Date_txtCheckDate = "txtCheckDate";
        public static string ID_Txt_txtCheckNo = "txtCheckNo";
        public static string ID_Txt_txtPaNumber = "txtPaNumber";
        public static string ID_Btn_MSPPaySubmit = "MSPPaySubmit";
        public static string XPath_SubPage_subPageContainer = "//*[@id='subPageContainer']/p";
        public static string ID_Btn_SupPaySubmit = "SupPaySubmit";
        public static string ID_Txt_txtPreAppTitle = "txtPreAppTitle";
        public static string ID_Txt_txtSae = "txtSae";

        public static string ID_Btn_AddPreApprovalItem = "AddPreApprovalItem";
        public static string ID_Txt_txtDescription1 = "txtDescription1";
        public static string ID_Txt_txtEstimatedAmount1 = "txtEstimatedAmount1";
        public static string ID_Txt_txtJustification = "txtJustification";
        public static string ID_ChkBox_txtReadChkBox = "txtReadChkBox";

        public static string ID_Btn_AddExpPreApprovalSubmit = "AddExpPreApprovalSubmit";
        public static string Xpath_link_MyreqistionTemplate = "//*[@id='result']/p[2]/a";
        public static string ID_Link_Reviewandsubmittab = "tab5";
        public static string ID_Button_Reviewcancel = "btnReviewCancel";


        public static string Xpath_txt_Rate_searchButtonExt = "//*[@id='HistoryTableViewCWRate_filter']/label/input";
        public static string Xpath_txt_termination_searchButton = "//*[@id='HistoryTableViewCWTerm_filter']/label/input";
        //  public static string ID_Txt_txtTimecardApprover = "txtTimecardApprover";
        public static string XPath_Txt_Del_TimecardApprover = "//select[@id='addTimecardApproverRchang']/option";
        //     public static string ID_Button_addTimecardApproverbtn = "addTimecardApproverbtn";
        //    public static string ID_Button_deleteTimecardApproverbtn = "deleteTimecardApproverbtn";

        // public static string ID_Chk_chkExpenseId = "chkExpenseId";



        public static bool blnFlagLogout = true;

        public static string MSG_strSupplierWindowNotdisplay = "Selected Suppliers Window is not display";
        public static string ID_Msg_NoRecordsDivMessage = "NoRecordsDivMessage";

        //Msg strings
        public static string MSG_strLoginTakingLongTime = "Login taking long time";
        public static string MSG_strLoginsuccessfully = "Login successfully";

        public static string MSG_strCreateRequirementssuccessfully = "Create Requirements successfully done";
        public static string MSG_strApprovesuccessfully = "Approve successfully done";
        public static string MSG_strRequirementNumberNotFind = "Unable to find the given requirement number";
        public static string MSG_strRequirementNumberNotCreated = "Req Number Not created";
        public static string MSG_strBroadcastSuccessfully = "Broadcast successfully done";
        public static string MSG_strSubmitCandidateSuccessfully = "Submit Candidate Successfully";
        public static string MSG_strSubmitToManagerSuccessfully = "Submit To Manager Successfully";
        public static string MSG_str_Expense_Approvesuccessfully = "Expense approve successfully done";
        public static string MSG_str_Expense_ExpandPaidsuccessfully = "Expense Invoice and Paid successfully done";
        public static string MSG_str_Request_Interview_Done = "Request interview successfully done";
        public static string MSG_str_Schedule_Interview_Done = "Schedule interview successfully done";
        public static string MSG_str_Confirm_Interview_Done = "Confirm interview successfully done";
        public static string MSG_str_Cancel_Interview_Done = "Cancel interview successfully done";
        public static string MSG_strTemplate_name = "Please enter Template Name";
        public static string MSG_EditRequirement = "Edit requirement flow ";


        // Extension/Termination/RateChange
        public static string Xpath_txt_searchButtonExt = "//*[@id='ResultCWMSP_filter']/label/input";
        public static string ID_Link_EnterExtension = "EnterExtension";
        public static string ID_Enter_Extension_DialogWindow = "ui-dialog-title-dialog";
        public static string Xpath_tab_Proposed_scenario = "//*[@id='dvEnterExtension']/div[2]/ul/li[3]";
        public static string ID_tab_Proposed_scenario = "tabProposed";
        public static string ID_ExtEffectiveDate = "effectiveDate";
        public static string Name_upload_justification = "uploadJustification";
        public static string ID_Justification = "justification";
        public static string ID_Btn_EnterExtension = "btnEnterExtension";
        public static string ID_AdditionalAmt = "additonalContractValue";
        public static string Xpath_txt_searchCWExt = "//*[@id='HistoryTableViewCWExt_filter']/label/input";
        public static string ID_Link_ExtendCW = "ExtendCW";
        public static string ID_ExtendCW_DialogWindow = "dialog";
        public static string Xpath_tab_ExtendCW_Proposed_scenario = "//*[@id='extenddiv']/div/ul/li[2]/a";
        public static string ID_NewEndDate = "newEndDate";
        public static string ID_Txt_ExtTimecardApprover = "TimeSheetApprovers";
        public static string ID_Add_Timesheet_App = "addChargeNobtn";
        public static string ID_Delete_Timesheet_App = "deleteChargeNobtn";
        public static string ID_Add_Chargenumber = "AddCostOrgLegalGL";
        public static string XPath_Select_Chargenumber = "//*[@id='addChargeNoRchang']";
        public static string ID_Delete_Chargenumber = "deleteDivChargeNobtn";
        public static string Xpath_Sel_Del_Timecard_App = "//*[@id='listTimeSheetApprovers']/option";
        public static string ID_Txt_Comment = "cwExtensionComment";
        public static string ID_Txt_RateComment = "cwRateChangeComment";
        public static string ID_Btn_ExtendCW = "btnMassConfirm";
        public static string ID_ExtCW_AdditionalAmt = "additionalContractValue";
        public static string ID_Error_Valmessages = "ulMspUserError";
        public static string ID_Btn_SaveAll_UpdateCW = "CWUpdateSaveAll";
        public static string Xpath_link_current_Scenario = "//*[@id='dialog']/div[1]/ul/li[2]/a";
        public static string Xpath_link_propsed_scenario = "//*[@id='dialog']/div[1]/ul/li[3]/a";
        public static string Xpath_link_TerminationDetail = "//*[@id='TerminateCWPin']/div/ul/li[3]/a";
        public static string Xpath_link_Process_Termination = "//*[@id='dvTerminateCW']/div[2]/ul/li[3]/a";
        public static string ID_txtJustificationtoHire1 = "justification";
        public static string ID_Select_DDLCWs1 = "CWNumber";

        public static string ID_Txt_CW_LastName = "cwLastName";
        public static string ID_Txt_CW_FirstName = "cwFirstName";
        public static string ID_Link_CW_TerminateLink = "TerminateCW";
        public static string ID_Txt_Comments = "comments";
        public static string ID_Txt_ExtApprove = "Approve";
        public static string ID_Txt_ExtApprove_Comment = "cwExtensionComment";
        public static string ID_Txt_Ext_ChargeNum = "association";
        public static string Xpath_Ext_EndDate = "//*[@id='currents']/div[1]/div[6]/div/label[2]/span";
        public static string Xpath_Extend_EndDate = "//*[@id='contract']/div[3]/div/div[2]/table/tbody/tr[4]/td[4]/span";
        //public static string ID_RadioBtn_ComputerAccess = "computerAccess";
        public static string ID_Btn_CWUpdateSaveAll = "CWUpdateSaveAll";




        //Interview Process
        public static string ID_Select_Statuslist = "StatusID";
        //public static string Xpath_Txt_CandidateName = "//*[@id='CandidateName']";
        public static string Xpath_Txt_CandidateName = "//*[@id='HistoryTableViewCandidate_filter']/label/input";
        public static string Xpath_Txt_ReqNumber = "//*[@id='Requirement']";
        public static string ID_Btn_SearchBtn = "refreshButton";
        public static string ID_Link_ReqInterview = "refreshButton";
        public static string ID_Candidate_Int_DialogWindow = "ui-dialog-title-dialog";
        public static string ID_Candidate_Int_DialogPopup = "ui-dialog-title-InterviewCountDialog";
        public static string ID_Date_FirChoice = "DateId1";
        public static string ID_Date_SecChoice = "DateId2";
        public static string str_String_PersonInterview = "In-Person Interview";
        public static string str_String_PhoneScreen = "Phone Screen";
        public static string str_String_Skype = "Skype";
        public static string str_String_WebEx = "WebEx";
        public static string ID_Txt_Sel_Interviewer = "approveInput";
        public static string ID_Btn_AddInterview = "addInterviewerbtn";
        public static string ID_Txt_Interview_Address = "InterviewAddress";
        public static string ID_Popup_Search_Processing = "tblregularcandidates_processing";
        public static string Xpath_Txt_Filter_ReqNumber = "//*[@id='regReqList_filter']/label/input";
        //  public static string Xpath_Txt_Filter_CandiateName = "//*[@id='HistoryTableViewCandidate_filter']/label/input";
        public static string Xpath_Txt_Filter_CandiateName = "//*[@type='search']";


        // Schedule Interview
        public static string Xpath_Txt_SearchSupp = "//*[@id='HistoryTableViewSuppReqs_filter']/label/input";
        public static string ID_Link_SubmittedCand = "Action2";
        public static string ID_Txt_PrimaryPhone = "PrimaryPhone";
        public static string ID_Txt_AlternatePhone = "AlternatePhone";
        public static string ID_Txt_SchInterview_Comment = "Comment";
        public static string ID_Btn_ScheduleInt = "btnScheduleInterview";
        public static string ID_Date_ScheFirChoice = "ScheduleDate";
        public static string ID_Link_SubmittedCandidate = "listMenu1";
        public static string Xpath_Txt_SearchCandidate = "//*[@id='HistoryTableViewSubmitted_filter']/label/input";
        public static string ID_Txt_Requested_Interview = "ddRequestedInterviews";
        public static string ID_Txt_Confirmed_IntDate = "DateId";
        public static string ID_Txt_TimeofInterview = "supplierSelectedTimeOfInterview";
        public static string ID_Txt_ZoneofInterview = "supplierSelectedZoneOfInterview";
        public static string ID_Txt_PmyPhone = "cnfrmphone1";
        public static string ID_Txt_SecPhone = "cnfrmphone2";
        public static string ID_Txt_ConfirmInt_Comment = "Textarea1";
        public static string ID_Txt_ScheduleDate = "ScheduleDate";
        public static string ID_Select_ScheduleTime = "ScheduleTime";
        public static string ID_Select_ScheduleZone = "ScheduleZone";
        public static string ID_Select_RejectReason = "RejectReasons";
        public static string ID_Btn_RejectInterview = "btnRejectInterview";
        public static string ID_Txt_SearchReq = "ReqNo";
        public static string ID_Txt_SearchCand = "CandidateName";
        public static string ID_Select_ScheTime = "ScheduleTime";
        public static string ID_Select_ScheZone = "ScheduleZone";

        public static string ID_Select_currencyID = "currencyID";
        public static string ID_Select_rateTypeID = "rateTypeID";


        // Cancel Interview
        public static string Xpath_Txt_CanInt_SearchReq = "//*[@id='regReqList_filter']/label/input";
        public static string ID_Link_ViewCandidates = "listMenu1";
        public static string Xpath_Txt_CanInt_SearchCan = "//*[@id='HistoryTableViewCandidate_filter']/label/input";
        public static string ID_Select_InterviewSche = "InterviewsScheduled";
        public static string ID_Txt_CanInt_Comments = "txtComments";
        // public static string ID_Select_Time1 = "Time1";
        // public static string ID_Select_Zone1 = "Zone1";

        // Interview Feedback
        public static string ID_Select_Recommendation = "ddRecommendationId";
        public static string Xpath_Txt_IntFeedback_CanSearch = "//*[@id='HistoryTableViewCCandidate_filter']/label/input";

        // Forward interview to supplier
        public static string ID_Date_FirChoiceDate = "FirstChoiceDate";
        public static string ID_Select_FirstChoiceTime = "FirstChoiceTime";
        public static string ID_Select_FirstChoiceZone = "FirstChoiceZone";
        public static string ID_Date_SecChoiceDate = "SecondChoiceDate";
        public static string ID_Select_SecChoiceTime = "SecondChoiceTime";
        public static string ID_Select_SecChoiceZone = "SecondChoiceZone";

        //Mass updation

        public static string Xpath_Table_tblMassUpdate = "//*[@id='MassResultCWMSP']/tbody/tr";
        public static string ID_Txt_Button_MassUpdation = "cwMassExtensionDirect";
        public static string Xpath_txt_Mass_searchButtonExt = "//*[@id='HistoryTableViewCWExt_filter']/label/input";
        public static string Xpath_txt_Mass_checkboxclick = "//*[@id='HistoryTableViewCWExt']/tbody/tr/td[1]/table/tbody/tr/td[1]";
        public static string Xpath_button_MassUpdatebutton = "//*[@id='selectedCWs']";

        //Mass Termination
        public static string Xpath_Table_tblMassTermination = "//*[@id='ResultCWMSP']/tbody/tr";
        public static string ID_Txt_Button_MassTermination = "cwMassTermination";
        public static string str_txt_status_Extensioncomplete = "Extension Complete";
        public static string str_txt_status_Onboardingcomplete = "Onboarding Complete";
        public static string str_txt_status_Releasecomplete = "	Release Complete";
        public static string str_txt_status_Ratechangecomplete = "Rate Change Complete";


        // Requirement Applicant Question 
        // public static string Xpath_AddSection = "//*[@id='tab_fourth']/div[1]/table/tbody/tr[1]/td/div/button";
        public static string Xpath_AddSection = " //*[@id='tab_fourth']/div[1]/div[1]/button";
        //sectionName
        public static string ID_Txt_SectionName = "sectionName";

        //Add Questions
        public static string ID_AddQuestionnder = "ddlSections";
        public static string ID_Questiontype = "questionTypeId";
        public static string ID_questionText = "questionText";
        //Reject Offer

        //  public static string ID_Select_RejectOfferReason = "RejectOfferReason";
        public static string ID_Txt_RejectOfferComment = "Comment";
        //Withdrwareason
        public static string ID_Select_withdrawReason = "withdrawReason";
        public static string ID_Select_IssueworkordercancelReason = "cancelReason";
        public static string Xpath_Button_Issueworkordercancel = "//*[@id='IssueworkButton']";
        public static string ID_Select_RejectworkorderReason = "RejectWorkOrderReason";
        public static string ID_Select_CancelReason = "CancelReason";

        //Submit Canidate(Mass Upload Candidates)
        public static string Id_Btn_UploadResumeBank = "addToUploadResumeBankButton";
        public static string xpath_Btn_FileUpload = "/html/body/div[14]";
        public static string xpath_Btn_FileUpload1 = "//*[@class='input-group-addon']";
        public static string Id_Txt_Comment = "commentsfile";

        public static string Xpath_MassTermination_EligibleCWS = "//*[@id='dvEnterTermination']/div[2]/ul/li";
        public static string ID_Chk_EligibleCWs = "check_all1";
        public static string ID_Btn_MassTermination = "btnEnterTermination";
        public static string Xpath_txt_Mass_searchTerminationButtonExt = "//*[@id='HistoryTableViewCWTerm_filter']/label/input";
        public static string Xpath_txt_MassTerminatin_checkboxclick = "//*[@id='HistoryTableViewCWTerm']/tbody/tr/td[1]";
        public static string Xpath_button_MassProcessTerminationbutton = "//*[@id='btnMassProcessTermination']";
        public static string ID_Processtermination_Comment = "terminationComments";
        public static string Xpath_serchdata_errorMsgs = "//*[@id='HistoryTableViewCWTerm']/tbody/tr/td";
        public static string ID_rehireReminderMonths = "rehireReminderMonths";

        public static string ID_txt_Supplier_TxtSupplier = "TxtSupplier";
        public static string ID_btn_Searchbutton_DefaultContent_Lblsrch = "DefaultContent_Lblsrch";
        //SUpllier login page

        public static string ID_Supplier_Email = "Email";
        public static string ID_Supplier_Password = "Password";
        public static string button_supplier_login = "login";
        public static string Txt_Supplier_Search = "filterClient";


        //Google keywords
        //Outline Tab

        public static string ID_btn_NewIdentifiedCandidate_btnNewCandidate = "btnNewCandidate";

        public static string ID_TypeHead_PrimaryManager_hiringManager = "hiringManager";
        public static string ID_TypeHead_Requestor_CreatedUserID = "CreatedUserID";
        public static string ID_Select_ReasontoHire_reasonToHireID = "reasonToHireID";
        public static string ID_Txt_BusinessJustification_JustificationtoHire = "JustificationtoHire";
        public static string ID_TypeHead_ChannelorProject_ProjectId = "ProjectId";
        public static string ID_TypeHead_GoogleCompany_organizationID = "organizationID";
        public static string ID_TypeHead_AccountCode_GLId = "GLId";
        public static string ID_TypeHead_LocationCode_deptNumber = "deptNumber";
        public static string ID_TypeHead_ProductCode_programId = "programId";
        public static string ID_TypeHead_CostCenter_CostCenterId = "CostCenterId";
        public static string ID_TypeHead_WorkLocation_workLocationID = "workLocationID";
        public static string ID_Select_WorkLocationSite_workLocationAddress = "workLocationAddress";
        public static string ID_TypeHead_AlternateManager_Japan_Only_altHiringManager = "altHiringManager";
        public static string ID_Select_LaborCategory_serviceMethodID = "serviceMethodID";
        public static string ID_Date_DesiredStartDate_neededStartDate = "neededStartDate";
        public static string XPath_Date_NexthighlightDate = "//*[@id='ui-datepicker-div']/table/tbody/tr[2]/td";
        public static string ID_DateEndDate_enddate = "enddate";
        public static string ID_NumberofResources_noofresources = "noofresources";
        public static string ID_Radio_Work_involvedinanyoftheRestricted_directIndirectTrue_Yes = "directIndirectTrue";
        public static string ID_Radio_Work_involvedinanyoftheRestricted_directIndirectFalse_No = "directIndirectFalse";
        public static string ID_Radio_BadgeAccessRequired_laborClassCode1_Yes = "laborClassCode1";
        public static string ID_Radio_BadgeAccessRequired_laborClassCode2_NO = "laborClassCode2";
        public static string ID_Radio_AccesstoHealthRelatedData_ciplocation1_Yes = "ciplocation1";
        public static string ID_Radio_AccesstoHealthRelatedData_ciplocation0_NO = "ciplocation0";
        public static string ID_Radio_SystemAccessRequired_computerAccessTrue_Yes = "computerAccessTrue";
        public static string ID_Radio_SystemAccessRequired_computerAccessFalse_NO = "computerAccessFalse";
        public static string ID_Radio_EquipmentRequired_needEquipmentTrue_Yes = "needEquipmentTrue";
        public static string ID_Radio_EquipmentRequired_needEquipmentFalse_NO = "needEquipmentFalse";
        public static string ID_Select_SelectEquipments_equipmentIds = "equipmentIds";
        public static string ID_Radio_SeatRequired_seatRequiredTrue_Yes = "seatRequiredTrue";
        public static string ID_Radio_SeatRequired_seatRequiredFalse_NO = "seatRequiredFalse";
        public static string ID_Radio_InvolvesinteractionwithGovernmentOfficials_involvesInteractionWithGovOffTrue_Yes = "involvesInteractionWithGovOffTrue";
        public static string ID_Radio_InvolvesinteractionwithGovernmentOfficials_involvesInteractionWithGovOffFalse_NO = "involvesInteractionWithGovOffFalse";
        public static string ID_Radio_AccesstoPersonalIdentifiableInformation_accessToPIITrue_Yes = "accessToPIITrue";
        public static string ID_Radio_AccesstoPersonalIdentifiableInformation_accessToPIIFalse_NO = "accessToPIIFalse";
        public static string ID_Radio_AccesstoEuropeanUnionData_accessToEUDataTrue_Yes = "accessToEUDataTrue";
        public static string ID_Radio_AccesstoEuropeanUnionData_accessToEUDataFalse_NO = "accessToEUDataFalse";
        public static string ID_Radio_WorkersRequiredtoDrive_workersReqToDriveTrue_Yes = "workersReqToDriveTrue";
        public static string ID_Radio_WorkersRequiredtoDrive_workersReqToDriveFalse_NO = "workersReqToDriveFalse";
        public static string CL_list_typeahead = "list-typeahead shadow";
        public static string ID_Outline_btn_SaveContinue_btnSaveCont = "btnSaveCont";


        //Assignment Tab

        public static string ID_Select_WorkTypeLevel1_typeofServiceGroupID = "typeofServiceGroupID";
        public static string ID_Select_WorkTypeLevel2_typeofServiceID = "typeofServiceID";
        public static string ID_Typeahead_JobTitle_txtJobTitle = "txtJobTitle";
        public static string ID_txt_JobDescription_jobDescription = "jobDescription";
        public static string ID_txt_SkillsMandatory_skillDescMandatory = "skillDescMandatory";
        public static string ID_txt_SkillsDesired_skillDescDesired = "skillDescDesired";
        public static string ID_txt_SkillMatrixSkillName_skillName = "skillName";
        public static string ID_txt_SkillMatrixDescription_skillDescription = "skillDescription";
        public static string ID_Radiobtn_SkillMatrixLevel_skillLevelID = "skillLevelID";
        public static string ID_Select_SkillMatrixYears_skillYearsExpID = "skillYearsExpID";
        public static string ID_Radiobtn_SkillMatrixMandatory_skillRequiredTrue = "skillRequiredTrue"; //For Yes
        public static string ID_Radiobtn_SkillMatrixMandatory_skillRequiredFalse = "skillRequiredFalse"; //For No
        public static string ID_Select_SkillCategory_specialNeedCategoryID = "specialNeedCategoryID";
        public static string ID_txt_SkillDescription_specialNeedDescription = "specialNeedDescription";
        public static string ID_Radiobtn_Mandatoryprestart_mandatoryPrestartTrue = "mandatoryPrestartTrue"; //For Yes
        public static string ID_Radiobtn_Mandatoryprestart_mandatoryPrestartFalse = "mandatoryPrestartFalse"; //For NO
        public static string ID_Radiobtn_SkillRecurring_recurringScheduleTrue = "recurringScheduleTrue"; //For yes
        public static string ID_radiobtn_SkillRecurring_recurringScheduleFalse = "recurringScheduleFalse"; //For No
        public static string ID_Select_SkillRecurringFrequency_ddlFrequency = "ddlFrequency";
        public static string ID_Radiobtn_TravelRequired_travelTrue = "travelTrue"; //For Yes
        public static string ID_radiobtn_TravelRequired_travelFalse = "travelFalse"; //For No
        public static string ID_txt_TravelLocation_travelLocation = "travelLocation";
        public static string ID_txt_travelDescription_travelDescription = "travelDescription";
        public static string ID_Radiobtn_TravelandAncillaryExpenses_expensesTrue = "expensesTrue"; //For Yes
        public static string ID_Radiobtn_TravelandAncillaryExpenses_expensesFalse = "expensesFalse"; //For No
        public static string ID_txt_EstimatedExpenseAmountperResourcefortheContractPeriod_expenseFixedAmount = "expenseFixedAmount";
        public static string ID_Radiobtn_InterviewAllowed_interviewRequiredTrue = "interviewRequiredTrue";
        public static string ID_Radiobtn_InterviewAllowed_interviewRequiredFalse = "interviewRequiredFalse";
        public static string ID_Radiobtn_UseStartandEndDateassumingstandardhoursbasedoncountryperweekanticipatedOT_rdtypeoption1 = "rdtypeoption1";
        public static string ID_Radiobtn_EstimatedNumberofHoursperResourcefortheContractPeriod_rdtypeoption3 = "rdtypeoption3";
        public static string ID_radiobtn_UseStartandEndDateassuminglessthanstandardhoursbasedoncountryperweek_rdtypeoption2 = "rdtypeoption2";
        public static string ID_txt_AnticipatedaverageOTperweek_hasOTHours = "hasOTHours";
        public static string ID_txt_EstimatedofRegularHoursWeek_EstWeeklyHours = "EstWeeklyHours";
        public static string ID_txt_EstimatedTotalofHours_approvedTotalHours = "approvedTotalHours";
        public static string ID_Select_Currency_currencyID = "currencyID";
        public static string ID_Select_RateTypes_rateTypeID = "rateTypeID";
        public static string ID_txt_BillRateRange_billRateLow = "billRateLow"; //Bill rate Min
        public static string ID_txt_BillRaterange_billRateHigh = "billRateHigh"; //Bill rate Max
        public static string ID_txt_EstimatedMaximumTotalLaborandExpenseCost_estContractValue = "estContractValue";
        public static string Xpath_Typeahead_CostCenterList_CostCenter = "//*[@id='costcenters']/tbody/tr/td/div";
        public static string Xpath_txt_CostCenterList_CostAllocation = "//*[@id='costcenters']/tbody/tr/td/input[@name='allocation']";
        public static string Xpath_txt_CostCenterList_Amount = "//*[@id='costcenters']/tbody/tr/td/input[@name='amount']";

        public static string ID_Assignment_btn_SaveContinue_btnSaveCont = "btnJobSaveAndContinue";
        //Wok flow
        public static string ID_WorkFlow_workflowContainer = "workflowContainer";
        public static string ID_WorkFlow_guidelines_guidelineAccepted = "guidelineAccepted";
        public static string ID_Button_WorkFlow_guidelines_guidelineAccepted = "btnGuidelineSaveAndContinue";
        public static string ID_Button_PrescreenQuestion_guidelines_guidelineAccepted = "btnQuestionsSaveAndContinue"; //btnQuestionSaveCont
        public static string ID_Button_ReviewSubmit = "btnSubmit";
        public static string XPath_T1_multiselect_SelectEquipments_equipmentIds = "//*[@id='equipmentIds']/following-sibling::div";


        // Justification Tab  -- Identified candidate
        public static string ID_txt_LastName_lastname = "lastname";
        public static string ID_txt_FirstName_firstname = "firstname";
        public static string ID_txt_MiddleName_middlename = "middlename";
        public static string ID_Select_Suffix_nameSuffix = "nameSuffix";
        public static string ID_Upload_UploadResume_uploadResume = "uploadResume";
        public static string ID_Radiobtn_FormerEmployee_exEmployeeYes = "exEmployeeYes";
        public static string ID_Radiobtn_FormerEmployee_exEmployeeNo = "exEmployeeNo";
        public static string ID_txt_FormerEmployeeDetails_exEmployeeDetails = "exEmployeeDetails";
        public static string ID_Radiobtn_FormerIntern_exInternYes = "exInternYes";
        public static string ID_Radiobtn_FormerIntern_exInternNo = "exInternNo";
        public static string ID_txt_FormerIntern_exInternDetails = "exInternDetails";
        public static string ID_Radiobtn_FormerTVC_exContractorYes = "exContractorYes";
        public static string ID_Radiobtn_FormerTVC_exContractorNo = "exContractorNo";
        public static string ID_txt_FromerTVCDetails_exContractorDetails = "exContractorDetails";
        public static string XPath_Radiobtn_IsaffiliatedtoUniversity_IsAffiliatedTrue = "//*[@name='IsAffiliated'][@id='True']";
        public static string XPath_Radiobtn_IsaffiliatedtoUniversity_IsAffiliatedFalse = "//*[@name='IsAffiliated'][@id='False']";
        public static string ID_txt_CandidatePhone_mobilePhone = "mobilePhone";
        public static string ID_txt_CandidateEmail_personalEmail = "personalEmail";
        public static string ID_txt_Comments_soleJustificationDescription = "soleJustificationDescription";

        public static string ID_Select_Supplier_supplierName = "supplierName";
        public static string ID_txt_ContactLastName_recruiterLastName = "recruiterLastName";
        public static string ID_txt_ContactFirstName_recruiterFirstName = "recruiterFirstName";
        public static string ID_txt_Phone_workPhone = "workPhone";
        public static string ID_txt_Email_workEmail = "workEmail";
        public static string ID_btn_JustificationSaveandContinue_btnCandidateSaveAndContinue = "btnCandidateSaveAndContinue";


        //ETK POP UP
        public static string Xpath_ETKpopup_yes = "//div[@aria-labelledby='ui-dialog-title-confirmationBypassETKDialog']//div//button[text()='Yes']";



        public static string XPath_Btn_ETKYes_confirmationBypassETKDialog = "//*[@id='confirmationBypassETKDialog']/following-sibling::div/div/button";
        public static string XPath_Btn_ETKNo_confirmationBypassETKDialog = "//*[@id='confirmationBypassETKDialog']/following-sibling::div/div/button[2]";

        public static string XPath_1stQueYes = "//*[text()='Yes']/preceding-sibling::input";
        public static string XPath_2ndQueGoogler = "//*[text()='Googler']/preceding-sibling::input";
        public static string XPath_3rdQueYes = "(//*[text()='Yes']/preceding-sibling::input)[2]";
        public static string XPath_4thQueNo = "(//*[text()='No']/preceding-sibling::input)[3]";
        public static string XPath_5thQueNo = "(//*[text()='No']/preceding-sibling::input)[4]";
        public static string XPath_5thQueYes = "(//*[text()='Yes']/preceding-sibling::input)[4]";

        #region Approve
        public static string XPath_SearchBox_Requirements_regReqList = "//*[@aria-controls='regReqList' and @type='search']";
        public static string XPath_SearchBox_IdentifiedRequirements_regReqList = "//*[@aria-controls='IdentifiedReqList' and @type='search']";
        public static string XPath_Img_Processing = "//*[@class='dataTables_processing' and @style='display: none;']";
        public static string XPath_Img_HeartBeat = "//table[@id='regReqList']//td//a[contains(@class,'heartbeat')]";
        public static string XPath_Img_IdentifiedHeartBeat = "//table[@id='IdentifiedReqList']//td//a[contains(@class,'heartbeat')]";
        public static string XPath_HearBeatMsgBox_Btn_Close_Close = "//div[@aria-labelledby='ui-dialog-title-dialog']//button[text()='Close']";
        public static string XPath_Link_Approve_reqApprove = "//li[@class='reqApprove']";
        public static string XPath_MsgBox_Btn_Approve_Approve = "//div[@id='dialog']//following-sibling::div//button[text()='Approve']";
        public static string XPath_MsgBox_Btn_ConfirmApprove_Yes_Yes = "//div[@aria-labelledby='ui-dialog-title-dialog-confirmapprove1']//button[text()='Yes']";
        public static string XPath_MsgBox_Btn_ConfirmApprove_No_No = "//div[@aria-labelledby='ui-dialog-title-dialog-confirmapprove1']//button[text()='No']";
        public static string XPath_MsgBox_Btn_ConfirmApprove_OK_OK = "//div[@aria-labelledby='ui-dialog-title-dialog-confirmapprove2-2']//button[text()='OK']";
        public static string XPath_Label_QueueStatus = "//div[@id='accordionPin']//label[contains(text(),'Queue Status')]//following-sibling::label";
        public static string XPath_list_LogoDropdown = "//ul/li[@class='dropdown']";
        #endregion

        public static string XPath_Link_Reject_reqReject = "//li[@class='reqReject']";
        public static string ID_RejectPopup_Select_ReasonToReject_RejectReason = "RejectReason";
        public static string XPATH_RejectPopup_Btn_Reject = "//div[@aria-labelledby='ui-dialog-title-dialog' and not(contains(@style,'display: none'))]//button[contains(@class,'primary') and text()='Reject']";
        public static string XPATH_RejectPopup_Btn_Reject_Yes = "//div[@aria-labelledby='ui-dialog-title-dialog-confirmreject1' and not(contains(@style,'display: none'))]//button[contains(@class,'primary')]"; 
        public static string XPATH_RejectPopup_Btn_Reject_Ok = "//div[@aria-labelledby='ui-dialog-title-dialog-confirmreject2' and not(contains(@style,'display: none'))]//button[contains(@class,'primary')]";
        //Ryder
        public static string ID_select_ServiceMethod_serviceMethodID = "serviceMethodID";
        public static string ID_select_SmartTrackTimesheet_AccountType = "AccountType";
        public static string ID_T2_select_JobTitle_jobTitleID = "jobTitleID";
        public static string ID_T2_selectGLAccount_GLIdJD = "GLIdJD";
        public static string ID_txt_Justificationtosubmitthecandidateforthisrequirementrequisitionmax500characters_lbljustificationDescription = "lbljustificationDescription";

        //Accept Offer
        public static string ID_Txt_PermanatLocation_LocationCity = "LocationCity";
        public static string ID_Select_State_StatesID = "StatesID";
        public static string ID_Txt_Keywords_Keywords = "Keywords";
        
        
        
        
        #region Broadcast
        public static string XPath_ActionListMenu_Broadcast_reqBroadcast = "//li[@class='reqBroadcast']";
        public static string XPath_li_DistributionList = "//div[@id='totalcontent']//li[@wtitle='Distribution List']";
        public static string XPath_MsgBox_DistributionListPopup = "//div[@aria-labelledby='ui-dialog-title-dialog']";
        public static string ID_MsgBox_Select_DistributionList_ddlDistList = "ddlDistList";
        public static string ID_MsgBox_Select_Tiers_ddlTiers = "ddlTiers";
        public static string XPath_MsgBox_Btn_Broadcast_Broadcast = "//div[@aria-labelledby='ui-dialog-title-dialog']//button[text()='Broadcast']";
        public static string XPath_MsgBox_ConfirmSuppliers_Btn_Yes_Yes = "//div[@aria-labelledby='ui-dialog-title-dlgConfirmSuppliers']//button[text()='Yes']";
        public static string XPath_MsgBox_dlgBroadcastSent_Btn_OK_OK = "//div[@aria-labelledby='ui-dialog-title-dlgBroadcastSent']//button[text()='OK']";
        public static string XPath_ActionListMenu_BroadcastDetails_reqBroadcastDetails = "//li[@class='reqBroadcastDetails']";
        public static string ID_Button_SelectSuppliers_PayRateMarkup = "PayRateMarkup";

        #endregion

        #region Adminstration
        public static string ID_Txt_ClientUserManagement_FirstName_DefaultContent_TxtFname = "DefaultContent_TxtFname";
        public static string ID_Txt_ClientUserManagement_LastName_DefaultContent_TxtBoxLname = "DefaultContent_TxtBoxLname";
        public static string ID_Button_ClientUserManagement_Search_btnSearchClientUser = "btnSearchClientUser";
        public static string XPath_Link__SearchResults_ClientUser = "//table[@id='dgrClientUsers1']//td/a";
        public static string ID_Link_ClientUser_ViewDesktop_DefaultContent_LblViewDesktop = "DefaultContent_LblViewDesktop";
        public static string XPath_Link_Return = "//span[@id='ViewDeskTopSpan']";
        public static string XPath_Link_SearchResults_SupplierUser = "//table[@id='dgrSupplierusers']//td/a";
        #endregion

        #region SubmitCandidate
        //Add Resume

        public static string ID_Txt_Supplier_Submitcandidate_Reqno = "ReqNo";
        public static string XPath_Link_Requirementnumber = "//table[@id='HistoryTableViewSuppReqs']//tr//td[2]//a";
        public static string XPath_Link_IdentifiedRequirementnumber = "//table[@id='identifiedCandidateListWithOffers']//tr//td[1]//a";
        public static string XPath_Link_IdentifiedRequirementnumber2 = "//table[@id='identifiedCandidateListWithOffers']//tr//td[2]//a";
        public static string XPath_Link_IdentifiedRequirementnumber3 = "//table[@id='HistoryTableViewICReqs']//tr//td[1]//a";
        public static string ID_Link_listMenu1 = "listMenu1";
        //public static string ID_Txt_LastName = "LastName";
        public static string XPath_Buttons_Search = "//button[@id='refreshButton']//span[contains(text(),'Search')]";
        public static string XPath_candidatename_header = "//table[@id='resumeBankList']";
        public static string XPath_Button_Addcandidatetoresumebank = "//button[@id='addToResumeBankButton'][text()[normalize-space()='Add Candidate to Resume Bank']]";
        //Add Candidate to Resume Bank
        public static string ID_txt_LastName_LastName = "LastName";
        public static string ID_txt_FirstName_FirstName = "FirstName";
        public static string ID_txt_MiddleName_MiddleName = "MiddleName";
        public static string ID_txt_NickName_NickName = "NickName";
        public static string ID_Select_SuffixName_SuffixName = "SuffixName";
        public static string ID_TypeHead_ZipCode_ZipCode = "ZipCode";
        public static string ID_TypeHead_Country_Country = "Country";
        public static string ID_TypeHead_State_State = "State";
        public static string ID_TypeHead_city_city = "city";
        public static string ID_Radio_Available_AvailableYes = "Available1";
        public static string ID_Radio_Available_AvailableNo = "Available0";
        public static string ID_Date_Available_AvailableDate = "AvailableDate";
        public static string ID_Select_Recruiter_RecruiterName = "RecruiterName";
        public static string ID_Radio_PastPresentMilitaryEmployment_Employment1 = "Employment1";
        public static string ID_Radio_PastPresentMilitaryEmployment_Employment0 = "Employment0";
        public static string ID_Txt_PastPresentMilitaryEmployment_EmploymentDetails = "EmploymentDetails";
        public static string ID_Txt_ATSID_ATSID = "ATSID";
        public static string ID_Resume_ResumeUpload_btnresumeupload = "btnresumeupload";
        public static string ID_Button_AddResumeSaveandContinueButton_btnSubmit = "btnSubmit";
        public static string NAME_Resume_Link_qqfile = "qqfile";
        public static string NAME_Resume_uploadResume = "uploadResume";
        public static string ID_PopUP_Addcandidate_OK = "dvAfterSave";


        //Submit candidte2nd page

        //public static string ID_txt_CandidateEmail_Email = "Email";
        public static string ID_txt_CandidateSummary_lbljustificationDescription = "lbljustificationDescription";
        public static string ID_Select_EmploymentType_employmentTypeID = "employmentTypeID";
        public static string ID_Select_SupplierLegalEntity_OperativeCompany = "OperativeCompany";
        public static string ID_Radio_FormerEmployeeYes_Employment1 = "Employment1";
        public static string ID_Radio_FormerEmployeeNo_Employment0 = "Employment0";
        public static string ID_Txt_FormerEmployeeUsername_EmploymentDetails = "EmploymentDetails";
        public static string ID_Txt_FormerInternUsername_InternDetails = "InternDetails";
        public static string ID_Txt_FormerTVCUsername_ContractorDetails = "ContractorDetails";
        public static string Xpath_Date_FromDate_fromDate1 = "//*[@id='priorExperienceTable']//td//img[@title='From Date']";
        public static string XPath_Date_ToDatetoDate1 = "//*[@id='priorExperienceTable']//td//img[@title='To Date']";
        public static string ID_Txt_PID_jobTitle = "jobTitle";
        public static string ID_Txt_Email_supervisorName = "supervisorName";
        public static string ID_Radio_FormerTVCYes_ContractorReadio1 = "ContractorReadio1";
        public static string ID_Radio_FormerTVCNo_ContractorReadio0 = "ContractorReadio0";
        public static string XPath_Date_FormerTVCFromDate_fromDate1 = "//*[@id='formerContractorTable']//td//img[@title='From Date']";
        public static string XPath_Date_FormerTVCToDatetoDate1 = "//*[@id='formerContractorTable']//td//img[@title='To Date']";
        public static string Xpath_Txt_FormerTVCPID_jobTitle = "//*[@id='formerContractorTable']//td//input[@id='jobTitle']";
        public static string Xpath_Txt_FormerTVCEmail_supervisorName = "//*[@id='formerContractorTable']//td//input[@id='supervisorName']";
        public static string ID_Radio_FormerInternYes_Intern1 = "Intern1";
        public static string ID_Radio_FormerInternNo_Intern0 = "Intern0";
        public static string Xpath_Date_RetireeDate_RetiredDate = "//*[@id='retireeSpanId']//img";
        public static string ID_Txt_PID_RetiredJobTitle = "RetiredJobTitle";
        public static string ID_Radio_ExemptNonExemptYes_Exempt1 = "Exempt1";
        public static string ID_Radio_ExemptNonExemptNo_Exempt0 = "Exempt0";
        public static string ID_Txt_CandidatePayRate_supplierRegPayRate = "supplierRegPayRate";
        public static string ID_Txt_CandidateOTPayRate_supplierOTPayRate = "supplierOTPayRate";
        public static string ID_Txt_BillRate_supplierRegBillRate = "supplierRegBillRate";
        public static string ID_Txt_OTBillRate_supplierOTBillRate = "supplierOTBillRate";
        public static string ID_Txt_Last4DigitsofNationalID_STID1 = "STID1";
        public static string ID_Select_BirthMonth_STID2 = "STID2";
        public static string ID_Select_BirthDay_STID3 = "STID3";
        public static string ID_Button_SubmittoRequistion_btnSubmit = "btnSubmit";
        public static string ID_Button_SubmittoRequistionPOPupYes_dvConfirmBefore = "dvConfirmBefore";
        public static string XPath_Button_SubmittoRequistionPOPupOk_dvConfirmSingleAfter = "//*[@id='dvConfirmSingleAfter']/following-sibling::div/div/button[text()='Ok']";
        public static string XPath_link_CandidateName = "//*[contains(@param,'candidateId')]";
        //public static string locator_button = "button";
        #endregion

        #region Submit Manager
        //submit manager
        public static string XPath_RequistionSearch_regReqList_filter = "//*[@id='regReqList_filter']/label/input";
        public static string XPath_RequistionSearch_regIdentifiedList_filter = "//*[@id='IdentifiedReqList_filter']/label/input";
        public static string XPath_link_Reuirementnumber_Req = "//*[@id='regReqList']/tbody/tr/td//a[@class='wrapNormal']";
        public static string XPath_link_IdentifiedReuirementnumber_Req = "//*[@id='IdentifiedReqList']/tbody/tr/td//a";
        public static string XPath_link_viewCandidate = "//li[@class='reqCandidate']";
        public static string XPath_Txt_search_Viewcandidatename = "//*[@id='HistoryTableViewCandidate_filter']//input";
        public static string XPath_link_ViewCandidatename = "//*[@id='HistoryTableViewCandidate']//td//a[@class='details']";
        public static string ID_Button_ExpandAll_tabsAll = "tabsAll";
        public static string ID_Txt_SubmittothefollowingManagers_txtManager = "txtManager";
        public static string XPath_Button_SubmitToManager = "//button[text()='Submit To Manager']";
        public static string ID_popup_yes = "dialog-confirmstm1-1";
        public static string Xpath_SubmitManager_Popup_Yes = "//*[@id='dialog-confirmstm1-1']/following-sibling::div/div/button[text()='Yes']";
        public static string Xpath_SubmitManager_Popup_OK = "//*[@id='dialog-confirmstm2-1']/following-sibling::div/div/button[contains(text(),'')]";
        #endregion

        #region Check Rehire Eligibility
        public static string CSS_Link_CheckRehireEligibility = "li[class*='RehireEligibility']";
        // public static string CSS_Link_Identified_CheckRehireEligibility = "li[class*='reqRehireEligibility']";
        public static string XPath_Popup_CheckRehireEligibility = "//*[@id='UpdateRehire']";
        public static string XPath_MsgBox_Button_UpdateRehireEligibility = "//div[@aria-labelledby='ui-dialog-title-dialog']//button[text()='Update Onboarding Eligibility']";
        public static string XPath_MsgBox_Label_RehireEligibility = "//div[@aria-labelledby='ui-dialog-title-dialog']//div[@class='mtop35']";
        public static string ID_Txt_PID_PID = "PID";
        //public static string ID_RadioBtn_RehireEligible_Yes = "IsRehireEligible28";
        public static string Xpath_RadioBtn_RehireEligible_Yes = "//*[@name='IsRehireEligible']/ancestor::label[text()=' Yes']";
        public static string ID_MsgBox_Select_Reason_Reason = "Reason";
        public static string XPath_MsgBox_Button_Submit = "//div[@aria-labelledby='ui-dialog-title-dialog']//button[text()='Submit']";
        public static string XPath_MsgBox_Button_Yes = "//div[@aria-labelledby='ui-dialog-title-Confirmation']//button[text()='Yes']";
        public static string XPath_MsgBox_Button_Ok = "//div[@aria-labelledby='ui-dialog-title-Success']//button[contains(text(),'')]";
        #endregion

        #region Interview Process
        public static string ID_Date_SelectDate_DateId1 = "DateId1";//google
        public static string ID_Date_SelectDate_DateId = "DateId";//google
        public static string ID_Date_SelectDate_DateId2 = "DateId2";//google
        public static string ID_Date_ConfirmedInterviewDate_DateId = "DateId";
        public static string ID_Txt_Requisition_ReqNo = "ReqNo";//google//Requisition#
        public static string ID_Txt_CandidateName_CandidateName = "CandidateName";//google//Candidate Name
        public static string ID_Date_Date_ScheduleDate = "ScheduleDate";
        public static string ID_Link_SubmittedCandiates_Action7 = "Action7";
        public static string ID_Link_SubmittedCandiates_reqCandidate = "//*[@class='reqCandidate']";
        public static string ID_Radio_ConfirmInterviewSchedule_ConfirmInterview = "ConfirmInterview";
        public static string ID_Radio_InterviewAccepted_AcceptedRadio = "AcceptedRadio";
        public static string ID_Select_Time_ScheduleTime = "ScheduleTime";
        public static string ID_Select_TimeZone_ScheduleZone = "ScheduleZone";
        public static string ID_Select_TimeZone_Zone1 = "Zone1";//google
        public static string ID_Select_TimeZone_Zone2 = "Zone2";//google
        public static string ID_Select_Time_Time1 = "Time1";//google
        public static string ID_Select_Time_Time2 = "Time2";//google
        public static string ID_TxtTypeHead_SelectInterviewer_approveInput = "approveInput";//google
        public static string ID_Txt_AlternatePhone_AlternatePhone = "AlternatePhone";
        public static string ID_Txt_AlternatePhone_cnfrmphone2 = "cnfrmphone2";
        public static string ID_Txt_PrimaryPhone_cnfrmphone1 = "cnfrmphone1";
        public static string ID_Txt_Comment_Textarea1 = "Textarea1";
        public static string ID_Txt_PrimaryPhone_PrimaryPhone = "PrimaryPhone";
        public static string Xpath_search_regReqList_filter = "//*[@id='regReqList_filter']/label/input";
        public static string XPath_ConIntOk_dialogconfirmmessage = "//*[@id='dialog-confirmmessage']/following-sibling::div/div/button[text()='Ok']";
        public static string Xpath_Link_SubmittedCand = "//*[contains(@wtitle,'Submitted Candidates')]";

        #endregion


        #region Offer to Hire and Extend offer
        public static string XPath_ActionListMenu_OfferToHire = "//li[@class='actOffertoHire img-hide']";
        public static string XPath_ActionListMenu_Identified_OfferToHire = "//*[@class='reqIssueOfferToHire']";

        public static string ID_Btn_Continue_btnbtnContinue = "btnbtnContinue";
        public static string ID_Btn_Continue_btnbtnContinueRates = "btnbtnContinueRates";
        public static string ID_Btn_Submit_SubmitOTHbtnSubmit = "SubmitOTHbtnSubmit";
        public static string ID_Button_TimecardApprovers_addTimecardApproverbtn = "addTimecardApproverbtn";

        ////public static string XPath_Link_Requirementnumber_supplier = "//*[@id='HistoryTableViewWO']//tbody//tr//td[@class='sorting_1']//a";
        public static string XPath_Pageload_Candidatestable_MSP = "//*[@id='regularCandidateListWithOffer']//tbody";
        public static string XPath_link_Candidatename_MSP = "//*[@id='regularCandidateListWithOffer']//td[@class='all sorting_1']//a";
        public static string XPath_txt_viewcanddates_Search = "//*[@id='regularCandidateListWithOffer_filter']//label//input";
        public static string XPath_lable_canddatesname_IWO = "//*[@id='accordionPin']//label[@class='btn-block bold' and contains(text(),'Candidate Name')]";
        //public static string XPath_lable_canddatesEmail_IWO = "//*[@id='accordion']//label[@class='btn-block  bold' and contains(text(),'Email')]";
        public static string Id_Button_Issueworkorder = "IssueworkButton";
        public static string ID_typeahead_CostCenter_ChargeCostCenterId = "ChargeCostCenterId";
        public static string ID_btn_ChargeNumberADD_AddChargeNumber = "AddChargeNumber";

        public static string ID_Select_ChargeGLAccount_ChargeGLId = "ChargeGLId";
        public static string ID_Txt_CalculatedMarkup_calculatedMarkup = "calculatedMarkup";

        //public static string XPath_RequistionSearch_regReqList_filter = "//*[@id='regReqList_filter']/label/input";
        //public static string XPath_link_Reuirementnumber_Req = "//*[@id='regReqList']/tbody/tr/td//a[@class='underline']";
        //public static string XPath_link_viewCandidate = "//li[@class='reqCandidate']";
        //public static string XPath_Txt_search_Viewcandidatename = "//*[@id='HistoryTableViewCandidate_filter']//input";
        //public static string XPath_link_ViewCandidatename = "//*[@id='HistoryTableViewCandidate']//td//a[@class='details']";
        //public static string ID_Button_ExpandAll_tabsAll = "tabsAll";
        public static string ID_Btn_CrossValidateChargeNumber_ValidateChargeNumber = "ValidateChargeNumber";
        public static string XPath_Popup_CrossValidationResponse_Status = "//div[@aria-labelledby='ui-dialog-title-Results']//table[@id='GlobalValidationResultTable']//td[2]";
        public static string XPath_Popup_Button_CrossValidationResponse_OK = "//div[@aria-labelledby='ui-dialog-title-Results']//button[text()='OK']";
        public static string ID_Btn_OfferToHire_Submit_btnbtnSubmit = "btnbtnSubmit";
        public static string ID_Txt_PreferredTitle_PreferredTitle = "PreferredTitle";
        public static string ID_Txt_PreferredTitle_WorkingTitle = "WorkingTitle";
        public static string XPath_PopUp_CandidateOffer_Yes = "//div[@aria-labelledby='ui-dialog-title-dialog-confirmoth2' and not(contains(@style,'display'))]//button[text()='Yes']";
        public static string XPath_PopUp_IdentifiedCandidateOffer_Yes = "//div[@aria-labelledby='ui-dialog-title-dialog-confirmissueoth2' and not(contains(@style,'display'))]//button[text()='Yes']";
        public static string XPath_PopUp_CandidateOffer_OK = "//div[@aria-labelledby='ui-dialog-title-dialog-confirmothafteroth' and not(contains(@style,'display'))]//button[text()='OK']";

        public static string XPath_txt_IdentifiedCandidateSearch = "//*[@aria-controls='identifiedCandidateListWithOffers' and @type='search']";
        public static string XPath_Link_IdentifiedCadidatName = "//*[@id='identifiedCandidateListWithOffers']/tbody/tr[1]/td[2]/a";
        public static string XPath_ActionListMenu_ExtendOffer = "//li[@class='actExtendOffer']";
        public static string XPath_MsgBox_button_ExtendOffer_ExtendOffer = "//div[@aria-labelledby='ui-dialog-title-dialog']//button[text()='Extend Offer']";
        public static string XPath_PopUp_Btn_ExtendOffer_Yes = "//div[@aria-labelledby='ui-dialog-title-dialog-ConfirmExtend']//button[text()='Yes']";
        public static string XPath_PopUp_Btn_ExtendOffer_OK = "//div[@aria-labelledby='ui-dialog-title-dialog-ConfirmExtend2']//button[text()='OK']";
        #endregion

        #region Accept Offer
        public static string XPath_Link_Requirementnumber_supplier = "//*[@id='HistoryTableViewWO']//tbody//tr//td[@class='sorting_1']//a";
        public static string ID_Select_Country_Country = "Country";
        public static string ID_Select_State_State = "State";
        public static string ID_Select_County_County = "County";
        public static string ID_Txt_PrimeSupplier_ChildSupplierName = "ChildSupplierName";
        public static string ID_Select_Country_SCountry = "SCountry";
        public static string ID_Select_State_SState = "SState";
        public static string ID_Select_SCountry_SCounty = "SCounty";
        // public static string ID_FinancialNumber = "financialNumber";
        public static string Xpath_btn_Accpectoffer = "//*[contains(@type,'button') and text()='Accept']";
        public static string Xpath_btn_Yes = "//*[contains(@type,'button') and text()='Yes']";
        public static string Xpath_btn_ok = "//*[contains(@type,'button') and text()='Ok']";
        public static string XPath_btn_AcceptYes_dvBeforeAcceptOffer = "//*[@id='dvBeforeAcceptOffer']/following-sibling::div/div/button[text()='Yes']";
        public static string XPath_btn_AcceptOk_dvAfterAcceptOffer = "//*[@id='dvAfterAcceptOffer']/following-sibling::div/div/button[text()='Ok']";
        public static string XPath_btn_AcceptYes_dvConfirmBefore = "//*[@id='dvConfirmBefore']/following-sibling::div/div/button[text()='Yes']";
        public static string XPath_btn_AcceptOk_dvConfirmAfter = "//*[@id='dvConfirmAfter']/following-sibling::div/div/button[text()='Ok']";
        public static string XPath_btn_AcceptYes_dvBeforeAcceptWorkOrder = "//*[@id='dvBeforeAcceptWorkOrder']/following-sibling::div/div/button[text()='Yes']";
        public static string XPath_btn_AcceptOk_dvAfterAcceptWorkOrder = "//*[@id='dvAfterAcceptWorkOrder']/following-sibling::div/div/button[text()='Ok']";
        public static string ID_Btn_ConfirmYes_dvBeforeAcceptOffer = "dvBeforeAcceptOffer";
        // public static string ID_Btn_ConfirmOk_dvAfterAcceptWorkOrder = "dvAfterAcceptWorkOrder";
        public static string ID_Btn_ConfirmYes_dvBeforeAcceptWorkOrder = "dvBeforeAcceptWorkOrder";
        public static string ID_Btn_ConfirmOk_dvAfterAcceptWorkOrder = "dvAfterAcceptWorkOrder";
        public static string ID_T1_select_ShiftEnd_spendLevelId = "spendLevelId";
        public static string ID_T1_Typeahead_BuyerName_CostCenterId = "CostCenterId";
        public static string ID_T1_Typeahead_GoodsReceiptApprover_altHiringManager = "altHiringManager";
        public static string ID_T1_select_ShiftStart_ProfitCenterId = "ProfitCenterId";

        public static string ID_Txt_PhoneNumber_cellphone = "cellphone";//cellphone
        public static string ID_Txt_CandidateEmail_email = "email";
        public static string ID_Txt_AddressLine1_address1 = "address1";
        public static string ID_Txt_AddressLine2_address2 = "address2";
        public static string ID_Txt_City_city = "city";
        public static string ID_Txt_Zip_zip = "zip";
        public static string ID_Select_State_state = "state";
        public static string ID_Radiobtn_DoesthisresourcehaveaSocialSecurityNumber_isSSNAvailable1 = "isSSNAvailable1";
        public static string ID_Radiobtn_DoesthisresourcehaveaSocialSecurityNumber_isSSNAvailable0 = "isSSNAvailable0";
        public static string ID_txt_SocailSecurityNumber_candidateSSN = "candidateSSN";
        public static string ID_txt_ConfirmSocailSecurityNumber_candidateSSNConfirm = "candidateSSNConfirm";

        public static string ID_Txt_EmergencyContactName_emergencyContact1Name = "emergencyContact1Name";
        public static string ID_Txt_EmergencyContactPhone_emergencyContact1Phone = "emergencyContact1Phone";
        public static string ID_Txt_2ndEmergencyContactName_emergencyContact2Name = "emergencyContact2Name";
        public static string ID_Txt_2ndEmergencyContactPhone_emergencyContact2Phone = "emergencyContact2Phone";

        #endregion


        public static string XPath_Tab_Offer = "//a[text()='Offer']";
        public static string ID_button_OutlineTab_btnbtnContinue = "btnbtnContinue";
        public static string ID_button_RatesTab_btnbtnContinueRates = "btnbtnContinueRates";
        
        public static string ID_select_GLBusinessUnit_chargeGLId = "chargeGLId";
        public static string XPath_Button_Popup_ExtendOffer = "//div[@class='ui-dialog-buttonset']//button[text()='Extend Offer']";
        public static string ID_Typeahead_Account_chargeCostCenterId = "chargeCostCenterId";
        public static string ID_Typeahead_OperatingUnit_chargeProfitCenterId = "chargeProfitCenterId";
        public static string ID_Typeahead_DepartmentID_chargedeptNumber = "chargedeptNumber";
        public static string ID_Typeahead_ProjectID_chargeProjectId = "chargeProjectId";
        public static string ID_Typeahead_WorkID_chargeprogramId = "chargeprogramId";
        public static string ID_select_Resource_chargespendLevelId = "chargespendLevelId";
        public static string ID_button_addchargenumber_addChargeNobtnNew = "addChargeNobtnNew";
        public static string ID_typehead_FinancialNumber_financialNumber = "financialNumber";
        public static string ID_txt_FinancialLineItemNumber_financialLineItemNumber = "financialLineItemNumber";
        public static string ID_txt_Amount_financialAmount = "financialAmount";
        public static string XPath_link_Candidatename_ExtendOffer_candidatename = "//*[@id='HistoryTableViewCandidate']//td[3]//a";
        public static string XPath_Text_search_ExtendOffer_candidatename = "//*[@id='HistoryTableViewCandidate_filter']//input";
        public static string XPath_Button_Expandall_Expand = "//span[text()='Expand All']";

        public static string ID_txt_Search_CWName = "CWName";

        //CP Chem New 
        public static string ID_txt_Last4digitsofssn_STID1 = "STID1";
        public static string str_App_Url2 = "";

        //Caesars
        //public static string ID_T1_Typeahead_Engagingmanager_hiringManager = "hiringManager";
        public static string ID_T1_select_unionPosition_laborClassCode = "laborClassCode";
        public static string ID_T1_select_GamingProcess_programId = "programId";
        public static string ID_T1_select_ReasonforthisRequest_reasonToHireID = "reasonToHireID";
        public static string ID_T1_txt_Justification_JustificationtoHire = "JustificationtoHire";
        public static string Name_T1_btn_NetworkAcessNeeded_radio6 = "radio6";
        public static string ID_T1_txt_NetwotkAcessRole_singleLine7 = "singleLine7";
        public static string Name_T1_btn_CeasarsEmailNeeded_radio5 = "radio5";
        public static string ID_txt_JustificationforRequest_JustificationtoHire = "JustificationtoHire";
        public static string ID_txt_GamingProcess_programName = "programName";
        public static string ID_txt_AribaReq_CustomerTrackingNumber2 = "CustomerTrackingNumber2";
        public static string ID_txt_POlineItem_LineItem = "LineItem";
        public static string ID_select_UnionPosition_ddlaborClassCode = "ddlaborClassCode";


        //Dyncorp 
        public static string ID_T1_select_Divison_organizationID = "organizationID";
        public static string ID_T1_select_COEBAT_ProfitCenterId = "ProfitCenterId";
        public static string ID_T1_select_DeptProgramTaskOrder_programId = "programId";
        public static string ID_T1_txt_PA_association = "association";
        public static string ID_T1_select_PAA_CostCenterId = "CostCenterId";
        public static string ID_T1_txt_ManagerPeopleSoftNumber_ServDept = "ServDept";
        public static string ID_T1_btn_USCitizenshipRequired_laborClassCode63 = "laborClassCode63";
        public static string ID_T1_btn_USCitizenshipRequired_laborClassCode64 = "laborClassCode64";
        public static string ID_T1_Typeahead_EAAApprover_altHiringManager = "altHiringManager";
        public static string ID_T1_txt_Justificationforhire_JustificationtoHire = "JustificationtoHire";

        public static string ID_txt_ChargeNumberPA_txtChargePA = "txtChargePA";
        public static string ID_select_ChargeNumberPAA_chargeCostCenterId = "chargeCostCenterId";
        public static string ID_Typeahead_EAAApprover_alternateHiringManagerName = "alternateHiringManagerName";
        public static string ID_select_Division_organization = "organization";
        public static string ID_select_DeptProgramTaskOrder_programName = "programName";
        public static string ID_select_PAA_CostCenterId = "CostCenterId";
        public static string ID_txt_PA_association = "association";
        public static string ID_select_COEBAT_ProfitCenterId = "ProfitCenterId";
        public static string ID_Txt_Justification_JustificationtoHire = "JustificationtoHire";

        public static string ID_Btn_EXPANDALL_tabsExpandCollapse = "tabsExpandCollapse";
        // KeyBank Client
        public static string ID_Select_CommodityCode_laborClassCode = "laborClassCode";
        public static string ID_Select_APCostCenter_chargeGLId = "chargeGLId";
        public static string ID_Typeahead_GLAccount_chargeCostCenterId = "chargeCostCenterId";
        public static string ID_btn_IsRehire_FromRehire = "FromRehire";
        public static string ID_TypeHead_EPPICProject_ProjectId = "ProjectId";//keybank
        public static string ID_select_EPPICRegion_ProfitCenterId = "ProfitCenterId";//key bank
        public static string ID_select_EPPICResourcePool_matrixNumber = "matrixNumber";
        public static string ID_Select_EPPICRole_spendLevelId = "spendLevelId";
        public static string ID_Select_WorkdayJobTitle_jobCodeID = "jobCodeID";
        // public static string ID_txt_Last4digitsofssn_STID1 = "STID1";
        public static string ID_typehead_EngagingManager_hiringManagerName = "hiringManagerName";
        public static string ID_select_CompanyNumber_deptNumber = "deptNumber";
        public static string ID_T1_select_CommodityCode_laborClassCode = "laborClassCode";
        public static string ID_T1_Select_CompanyNumber_deptNumber = "deptNumber";
        public static string ID_T1_Select_HRCostCenter_programId = "programId";
        public static string ID_T1_Select_CommodityCode_laborClassCode = "laborClassCode";
        public static string ID_T1_Typeahead_EPPICProject_ProjectId = "ProjectId";
        public static string ID_T1_Select_EPPICRegion_ProfitCenterId = "ProfitCenterId";
        public static string ID_T1_Select_EPPICResourcePool_matrixNumber = "matrixNumber";
        public static string ID_T1_select_ReasonForHire_reasonToHireID = "reasonToHireID";
        //  public static string ID_T1_txt_Justification_JustificationtoHire = "JustificationtoHire";
        public static string ID_T1_Typeahead_EngagingManager_hiringManager = "hiringManager";
        public static string ID_T1_Select_EPPICRole_spendLevelId = "spendLevelId";
        public static string ID_Typeahead_ChargeCompanyNumber_deptNumber = "deptNumber";
        public static string ID_Typeahead_APCostCenter_CostCenterId = "CostCenterId";



        //Altria
        public static string ID_T1_Radio_AccountAssignment_CostCenter_AccountAssignment1 = "AccountAssignment1";
        public static string ID_T1_Radio_AccountAssignment_WBS_AccountAssignment2 = "AccountAssignment2";
        public static string ID_T2_Typeahead_JobCategory_txtJobTitle = "txtJobTitle";
        public static string ID_T1_typehead_CostCenter_CostCenterId = "CostCenterId";
        public static string ID_T1_select_AccountAssignmentWBS_ProjectId = "ProjectId";
        public static string ID_T1_select_FunctionalArea_ProfitCenterId = "ProfitCenterId";
        //  public static string ID_T1_Typeahead_EngagingManager_hiringManager = "hiringManager";
        //  public static string ID_T1_txt_Justification_JustificationtoHire = "JustificationtoHire";
        public static string ID_T2_txt_AssignmentDescription_jobDescription = "jobDescription";
        public static string ID_btn_AccountAssignmentWBS_AccountAssignment2 = "AccountAssignment2";
        public static string ID_select_WBSElement_ProjectId = "ProjectId";
        public static string ID_select_FunctionalArea_ProfitCenterId = "ProfitCenterId";
        public static string ID_txt_Justification_JustificationtoHire = "JustificationtoHire";
        public static string Xpath_Label_Candidatename_CandidateName = "//*[@id='CandidateName']";

        #region KCPL
        public static string ID_T1_select_GLBusinessUnit_GLId = "GLId";
        public static string ID_T1_Select_ComplianceAccessNeeded_matrixNumber = "matrixNumber";
        public static string ID_T2_TypeHead_JobTitle_txtJobTitle = "txtJobTitle";
        public static string ID_T2_Radio_interTrue = "interTrue";
        public static string ID_T2_Radio_interFalse = "interFalse";
        public static string ID_T2_Radio_exemptTrue = "exemptTrue";
        public static string ID_T2_Radio_exemptFalse = "exemptFalse";
        public static string ID_T2_Radio_perdiemTrue = "perdiemTrue";
        public static string ID_T2_Radio_perdiemFalse = "perdiemFalse";
        public static string ID_datepicker_NeededDate_neededStartDate = "neededStartDate";
        public static string ID_3Months_Radio_3 = "3";
        public static string ID_6Months_Radio_6 = "6";
        public static string ID_9Months_Radio_9 = "9";
        public static string ID_T1_radio_ComputerSystemsAccess_directIndirectTrue = "directIndirectTrue";
        public static string ID_T1_radio_ComputerSystemsAccess_directIndirectFalse = "directIndirectFalse";
        public static string ID_T1_typehead_WorkLocationAddress_workLocationAddress = "workLocationAddress";
        //   public static string ID_T2_Select_TypeofService_typeofServiceID = "typeofServiceID";


        public static string ID_radiobutton_EPRIRetiree_RetireeRadio1 = "RetireeRadio1";
        public static string ID_Click_TimecardApproversAdd_addTimecardApproverbtn = "addTimecardApproverbtn";
        public static string ID_txt_CandidateLastName_lastName = "lastName";
        public static string ID_txt_CandidateFirstName_firstName = "firstName";
        public static string ID_txt_CandidateMiddleName_middleName = "middleName";
        public static string ID_txt_CandidateNameSuffix_nameSuffix = "nameSuffix";
        public static string ID_txt_RetiredDate_RetiredDate = "RetiredDate";
        public static string ID_radiobutton_EPRIRetiree_RetireeRadio0 = "RetireeRadio0";
        public static string ID_select_EngagementType_serviceMethodID = "serviceMethodID";
        public static string ID_select_GLBusinessUnit_GLId = "GLId";
        public static string ID_Txt_ComplianceAccessNeeded_matrixNumber = "matrixNumber";
        //  public static string ID_txt_Last4digitsofssn_STID1 = "STID1";
        public static string ID_txt_CandidateBillRateSavings_supplierBillRateSavings = "supplierBillRateSavings";
        public static string ID_Click_TimecardApproversDelete_deleteTimecardApproverbtn = "deleteTimecardApproverbtn";
        public static string XPath_btn_IndependentConsultant_IndependentConsultant = "//input[@id='IndependentConsultant'])[2]";


        #endregion
        public static string ID_select_ChargeNumbersCompanyCode_deptNumber = "deptNumber";
        public static string ID_select_WBS_ProjectId = "ProjectId";

        // EPRI
        public static string ID_select_PlaceofWork_siteLocationID = "programName";
        public static string ID_txt_CompanyCodedescription_deptName = "deptName";
        public static string ID_T1_select_JustificationforOpening_reasonToHireID = "reasonToHireID";
        public static string ID_T1_Select_PlaceOfWork_siteLocationID = "siteLocationID";
        public static string ID_T1_Select_QualityAssurance_programId = "programId";
        public static string ID_T1_select_WorkLocation_workLocationID = "workLocationID";
        public static string ID_T1_txt_IncumbentNameTermDate_JustificationtoHire = "JustificationtoHire";
        public static string ID_T1_txt_OfficeCubicleNumber_matrixNumber = "cwMatrixNumber";
        public static string ID_T1_TypeHead_CompanyCode_deptNumber = "deptNumber";
        public static string ID_T1_typehead_EngagingManagerPM_hiringManager = "hiringManager";
        public static string ID_T1_TypeHead_WorkLocationAddress_workLocationAddress = "workLocationAddress";
        public static string ID_text_JustificationforOpening_reasonToHire = "programName";
        public static string ID_txt_CompanyCode_deptNumber = "deptNumber";
        public static string ID_select_QualityAssurance_programName = "programName";
        public static string ID_Typeahead_OfficeCubicleNumber_matrixNumber = "programName";
        public static string XPath_text_Amount = " //*[@id='POmatrixtable']/tbody/tr[1]/td[4]/input";
        //    public static string Xpath_Tab_ContractDetails = "//h3[text()[normalize-space()='Contract Details']]";


        //Aps client

        public static string ID_txt_PhoneExtension_phoneExtension = "phoneExtension";

        public static string ID_T1_select_ACADLevel_programId = "programId";
        public static string ID_select_PositionType_serviceType = "serviceType";
        public static string ID_Typeahead_Leader_hiringManagerName = "hiringManagerName";
        public static string ID_btn_SpouseRelativesatAPS_relativeTrue = "relativeTrue";
        public static string ID_btn_SpouseRelativesatAPS_relativeFalse = "relativeFalse";
        public static string ID_Radio_ACAD_directIndirect1 = "directIndirect1";
        public static string ID_Radio_ACAD_directIndirect0 = "directIndirect0";
        public static string ID_btn_Refferal_Radio4 = "Radio4";
        public static string ID_select_UnitNumber_deptNumber = "deptNumber";
        public static string ID_Typeahead_FFDSupervisor_alternateHiringManagerName = "alternateHiringManagerName";
        public static string ID_select_ACADLevel_programName = "programName";
        public static string ID_select_ContractorCost_CostCenterId = "CostCenterId";
        //     public static string ID_select_EngagementType_serviceMethodID = "serviceMethodID";
        public static string ID_Typeahead_MailStation_matrixNumber = "matrixNumber";
        public static string ID_btn_ComputerAccess_computerAccessTrue = "computerAccessTrue";
        public static string ID_btn_ComputerAccess_computerAccessFalse = "computerAccessFalse";
        public static string ID_select_ContractorCategory_GLId = "GLId";
        public static string ID_txt_RequestJustification_JustificationtoHire = "JustificationtoHire";
        public static string ID_Date_DateofBirth_DOB = "DOB";
        public static string ID_btn_IsSSNValid_isSSNValidTrue = "isSSNValidTrue";
        public static string ID_btn_IsSSNValid_isSSNValidFalse = "isSSNValidFalse";
        public static string ID_txt_SocialSecurityNumber_candidateSocialSecurityNumber = "candidateSocialSecurityNumber";
        public static string ID_select_State_stateName = "stateName";
        public static string ID_select_CountryofCitizenship_countryName = "countryName";
        public static string ID_txt_ZipCode_zipcode = "zipcode";
        public static string ID_select_FormerEmployee_FormallyEmployedFieldId = "FormallyEmployedFieldId";
        public static string ID_txt_SpourseRelativeName_relativeName = "relativeName";
        public static string ID_select_PadsBasicsforAction_padsName = "padsName";
        public static string ID_date_OnSiteArrivalDate_processingDate = "processingDate";

        public static string ID_select_AccountCodingsAccountUnit_deptNumber = "deptNumber";
        public static string ID_select_AccountCodingsCompany_siteLocationID = "siteLocationID";
        public static string ID_select_AccountCodingsProject_ProjectId = "ProjectId";
        public static string ID_select_AccountCodingsActivity_ProfitCenterId = "ProfitCenterId";
        public static string ID_btn_AccountCodingsadd_AddCostOrgLegalGL = "AddCostOrgLegalGL";
        public static string ID_T1_Select_Company_siteLocationID = "siteLocationID";
        public static string ID_select_Company_siteLocationID = "siteLocationID";
        public static string ID_T1_Select_AccountUnit_deptNumber = "deptNumber";

        // ThermoFisher
        public static string ID_Select_ProductLine_siteLocationID = "siteLocationID";
        public static string ID_Select_SupervisoryOrg_ProfitCenterId = "ProfitCenterId";
        public static string ID_Txt_WorkDayID_customerTrackingNumber = "customerTrackingNumber";
        public static string ID_Typeahead_BusinessStructure_deptNumber = "deptNumber";
        public static string ID_Typeahead_FinanceEntity_organization = "organization";
        public static string ID_Typeahead_PrimaryLocation_workLocationID = "workLocationID";
        public static string ID_Select_WorkerSubType_serviceMethodID = "serviceMethodID";
        public static string ID_T1_Select_SupervisorOrg_ProfitCenterId = "ProfitCenterId";
        public static string ID_T1_Typeahead_FinanceEntity_organizationID = "organizationID";
        public static string ID_T1_Typeahead_BusinessStructure_deptNumber = "deptNumber";
        public static string ID_T1_Date_TargetStartDate_neededStartDate = "neededStartDate";
        public static string ID_T1_Date_TargetEnddate_enddate = "enddate";
        public static string ID_T1_Typeahead_PrimaryLocation_workLocationID = "workLocationID";
        public static string ID_T1_Typeahead_PrimaryLocationAddress_workLocationAddress = "workLocationAddress";
        public static string ID_T1_Typeahead_ProductLine_siteLocationID = "siteLocationID";
        public static string ID_T1_Select_DirectFill_laborClassCode = "laborClassCode";
        public static string ID_T1_Select_WorkerSubType_serviceMethodID = "serviceMethodID";
        public static string ID_T1_Txt_Justification_JustificationtoHire = "JustificationtoHire";
        public static string ID_T1_Select_TimeType_workScheduleID = "workScheduleID";
        public static string ID_T2_Typeahead_JobPostingTitle_txtJobTitle = "txtJobTitle";
        public static string ID_T2_btn_CandidateMeeting_interTrue = "interTrue";
        public static string ID_T2_btn_CandidateMeeting_interFalse = "interFalse";
        public static string ID_T2_Select_Workshift_shiftID = "shiftID";


        //Bimbo
        public static string ID_T1_Typeahead_LegalEntity_organizationID = "organizationID";
        public static string ID_T1_Typeahead_BusinessArea_ProjectId = "ProjectId";
        public static string ID_T1_Typeahead_NaturalAccount_GLId = "GLId";
        public static string ID_T1_Typeahead_LocalAnalysis_siteLocationID = "siteLocationID";
        public static string ID_T1_Typeahead_Fiscal_matrixNumber = "matrixNumber";
        public static string ID_T1_Typeahead_Intercompany_deptNumber = "deptNumber";
        public static string ID_T1_select_TypeofAssignment_workScheduleID = "workScheduleID";
        public static string ID_T1_select_EmergencyPosition_laborClassCode = "laborClassCode";
        public static string ID_T1_txt_AdditionalrequirementDetails_JustificationtoHire = "JustificationtoHire";
        public static string ID_T2_btn_Isthisareplacementrequisition_directIndirectTrue = "directIndirectTrue";
        public static string ID_T2_btn_Isthisareplacementrequisition_directIndirectFalse = "directIndirectFalse";
        public static string ID_T2_txt_Requisition_association = "association";
        public static string ID_T2_btn_Arethereunionizedworkersatthislocation_UnauthorizedWorkerTrue = "UnauthorizedWorkerTrue";
        public static string ID_T2_btn_Arethereunionizedworkersatthislocation_UnauthorizedWorkerFalse = "UnauthorizedWorkerFalse";
        public static string ID_T2_txt_CBAContract_CollectiveBargainingAgreementCode = "CollectiveBargainingAgreementCode";
        public static string ID_T2_btn_Isthepositionexpectedtobelongerthan13weeks_interviewRequiredTrue = "interviewRequiredTrue";
        public static string ID_T2_btn_Isthepositionexpectedtobelongerthan13weeks_interviewRequiredFalse = "interviewRequiredFalse";
        public static string ID_T2_btn_Isthereashiftdifferential_shiftTrue = "shiftTrue";
        public static string ID_T2_btn_Isthereashiftdifferential_shiftFalse = "shiftFalse";
        public static string ID_T2_txt_Amount_shiftDiffAmount = "shiftDiffAmount";
        public static string ID_T2_txt_Workinghours_shiftDiffPercent = "shiftDiffPercent";
        public static string ID_T2_btn_IsTravelRequired_expensesTrue = "expensesTrue";
        public static string ID_T2_btn_Istravelrequired_expensesFalse = "expensesFalse";
        public static string ID_T1_select_BusinessUnit_serviceMethodID = "serviceMethodID";
        public static string ID_select_HastheNonEmployeebeenofferedACACompliantHealthCoverage_ACACompliantHealthCoverage = "ACACompliantHealthCoverage";
        public static string ID_select_ACACostPer_ACACostPer = "ACACostPer";
        public static string ID_txt_ACACost_ACACost = "ACACost";
        public static string ID_select_SupplierOperatingCompany_OperativeCompany = "OperativeCompany";
        public static string ID_Typeahead_ChargeNumberLegalEntity_ChargeorganizationID = "ChargeorganizationID";
        public static string ID_Typeahead_ChargeNumberBusinessArea_ChargeProjectId = "ChargeProjectId";
        public static string ID_Typeahead_ChargeNumbernaturalAccount_ChargeGLId = "ChargeGLId";
        public static string ID_Typeahead_ChargeNumberLocalAnalysis_ChargesiteLocationID = "ChargesiteLocationID";
        public static string ID_Typeahead_ChargeNumberCostCenter_ChargeCostCenterId = "ChargeCostCenterId";
        public static string ID_Typeahead_ChargeNumberInterCompany_ChargedeptNumber = "ChargedeptNumber";
        public static string ID_select_LabourCategory_serviceType = "serviceType";
        public static string ID_Typeahead_LegalEntity_organization = "organization";
        public static string ID_Typeahead_BusinessArea_ProjectId = "ProjectId";
        public static string ID_Typeahead_NaturalAccount_GLId = "GLId";
        public static string ID_select_LocalAnalysis_siteLocationID = "siteLocationID";
        public static string ID_Typeahead_InterCompany_deptNumber = "deptNumber";
        public static string ID_select_BusinessUnit_serviceMethodID = "serviceMethodID";
        public static string ID_select_Emergencyposition_laborClassCode = "laborClassCode";

        //Georgetown

        public static string ID_T1_Typeahead_OrganizationName_organizationID = "organizationID";
        public static string ID_T1_Typeahead_CourseName_serviceMethodID = "serviceMethodID";
        public static string ID_T1_Typeahead_SpendCategory_deptNumber = "deptNumber";
        public static string ID_T1_Typeahead_Fund_siteLocationID = "siteLocationID";
        public static string ID_T1_Typeahead_Purpose_ProfitCenterId = "ProfitCenterId";
        public static string ID_T1_Typeahead_ProgramName_programId = "programId";
        public static string ID_T1_Txt_POdetailsRemoteCWWorklocationaddress_JustificationtoHire = "JustificationtoHire";
        //     public static string ID_Typeahead_PONumber_purchaseOrderNumber = "purchaseOrderNumber";
        public static string ID_Typeahead_SpendCategory_deptNumber = "deptNumber";
        public static string ID_Typeahead_CourseName_serviceMethodID = "serviceMethodID";
        public static string ID_Typeahead_OrganizationName_organization = "organization";
        public static string ID_Txt_WorkingTitle_jobTitleName = "jobTitleName";
        public static string ID_Txt_POdetailsRemoteCWWorklocationaddress_JustificationtoHire = "JustificationtoHire";
        public static string ID_Select_Purpose_ProfitCenterId = "ProfitCenterId";
        public static string ID_Select_Fund_siteLocationID = "siteLocationID";


        //Added by manjuhsa COE client
        public static string ID_select_SupplierOperationsCompany_OperativeCompany = "OperativeCompany";
        public static string ID_Typeahead_ChargeNumberProjectName_ChargeprogramId = "ChargeprogramId";
        public static string ID_Typeahead_ChargeNumberProjectNumber_ChargeCostCenterId = "ChargeCostCenterId";
        public static string ID_Typeahead_ChargeNumberPOID_ChargeProjectId = "ChargeProjectId";
        public static string ID_txt_EstimatedLaborandExpCost_totalContractValue = "totalContractValue";
        public static string ID_T2_btn_Isthisareplacementrequistion_directIndirectTrue = "directIndirectTrue";
        public static string ID_T2_btn_Isthisareplacementrequistion_directIndirectFalse = "directIndirectFalse";
        public static string ID_T2_txt_IsthisareplacementrequistionRequistion_association = "association";
        public static string ID_T2_btn_IsOnCallRequired_shiftTrue = "shiftTrue";
        public static string ID_T2_btn_IsOnCallRequired_shiftFalse = "shiftFalse";
        public static string ID_T2_txt_IsOnCallRequiredAmount_shiftDiffAmount = "shiftDiffAmount";
        public static string ID_T1_Typeahead_programManager_altHiringManager = "altHiringManager";
        public static string ID_T2_txt_BillRateRange_billRateLow = "billRateLow";
        public static string ID_T2_txt_BillRateRange_billRateHigh = "billRateHigh";
        public static string ID_T1_btn_HRReviewed_computerAccessTrue = "computerAccessTrue";
        public static string ID_T1_btn_HRReviewed_computerAccessFalse = "computerAccessFalse";
        public static string ID_T1_select_CoEReqType_serviceMethodID = "serviceMethodID";
        public static string ID_T1_Typeahead_Branch_organizationID = "organizationID";
        public static string ID_T1_Typeahead_POID_ProjectId = "ProjectId";
        //  public static string ID_T1_select_TypeofAssignment_workScheduleID = "workScheduleID";
        public static string ID_T1_txt_AdditionalWorkLocationDetails_JustificationtoHire = "JustificationtoHire";
        // public static string ID_select_LabourCategory_serviceType = "serviceType";
        public static string ID_Typeahead_ProgramManager_alternateHiringManagerName = "alternateHiringManagerName";
        public static string ID_select_CoEReqType_serviceMethodID = "serviceMethodID";
        public static string ID_Typeahead_Branch_organization = "organization";
        public static string ID_Typeahead_Department_deptNumber = "deptNumber";
        public static string ID_Typeahead_POID_ProjectId = "ProjectId";
        public static string ID_btn_HRReviewed_computerAccessTrue = "computerAccessTrue";
        public static string ID_btn_HRReviewed_computerAccessFalse = "computerAccessFalse";
        public static string ID_txt_WorkOrderNumber_customerTrackingNumber = "customerTrackingNumber";
        public static string ID_select_TypeofAssignment_workweek = "workweek";
        public static string ID_select_SupplierOperationCompany_OperativeCompany = "OperativeCompany";


        //phhmortage
        public static string ID_T1_Typeahead_Divison_GLId = "GLId";
        public static string ID_T1_Select_ReqType_organizationID = "organizationID";
        public static string ID_T1_Select_SubDivision_programId = "programId";
        public static string ID_T1_Select_Department_deptNumber = "deptNumber";
        public static string ID_T1_Txt_Comments_JustificationtoHire = "JustificationtoHire";
        public static string ID_T1_select_Project_ProjectId = "ProjectId";
        public static string ID_Txt_Comments_JustificationtoHire = "JustificationtoHire";
        public static string ID_Select_Department_deptNumber = "deptNumber";
        public static string ID_Select_SubDivision_programName = "programName";
        public static string ID_Select_ServiceMethod_serviceMethodID = "serviceMethodID";
        public static string ID_Select_ReqType_organization = "organization";
        public static string ID_Select_BusinessUnit_ProjectId = "ProjectId";
        public static string ID_Typeahead_Division_GLId = "GLId";


        //tufts
        public static string ID_T1_Typeahead_Department_organizationID = "organizationID";
        public static string ID_T1_Select_AccountCode_CostCenterId = "CostCenterId";
        public static string ID_Typeahead_Department_organization = "organization";
        public static string ID_Select_AccountCode_CostCenterId = "CostCenterId";
        public static string ID_Select_BusinessUnit_ChargeProjectId = "ChargeProjectId";
        public static string ID_Select_Reqtype_ChargeorganizationID = "ChargeorganizationID";
        //    public static string ID_typeahead_CostCenter_ChargeCostCenterId = "ChargeCostCenterId";
        public static string ID_Typeahead_Department_ChargeorganizationID = "ChargeorganizationID";
        public static string ID_Select_AccountCode_ChargeCostCenterId = "ChargeCostCenterId";
        public static string ID_Typeahead_ChargeNumbers_txtChargeNo = "txtChargeNo";



        // Supervalu
        //   public static string Xpath_Tab_Workorderdetails = "//*[@id='accordion']//h3//span[@class='accordianPlus icon-plus4']";

        // Emerson
        public static string ID_select_ChargeNumberType_ChargeNumberTypes = "ChargeNumberTypes";
        public static string ID_T1_select_Department_organizationID = "organizationID";
        public static string ID_T1_typehead_PurchaseOrderNumber_CostCenterId = "CostCenterId";
        public static string ID_T2_txt_BillrateHigh_billRateHigh = "billRateHigh";
        public static string ID_Typeahead_ChargeNumber_txtCharge = "txtCharge";
        // public static string ID_Typeahead_Department_organization = "organization";

        //Added by manjusha for arkema client
        //   public static string ID_select_ChargeNumberType_ChargeNumberTypes = "ChargeNumberTypes";
        //    public static string ID_Typeahead_ChargeNumbers_txtChargeNo = "txtChargeNo";
        public static string ID_T1_Radio_CostCenterOrProfitCenter_AccountAssignment1 = "AccountAssignment1";
        public static string ID_T1_Typehead_ProfitCenter_ProfitCenterId = "ProfitCenterId";
        public static string ID_T1_Radio_ProjectOrWBSElement_AccountAssignment3 = "AccountAssignment3";
        public static string ID_T1_TypeHead_ProjectOrWBSElement_ProjectId = "ProjectId";
        public static string ID_T1_select_PurchasingGroup_serviceMethodID = "serviceMethodID";
        public static string ID_Typeahead_DelegateofAuthority_altHiringManager = "altHiringManager";
        public static string ID_txt_Requisitioner_CreatedUserID = "CreatedUserID";
        public static string ID_select_MaterialGroup_laborClassCode = "laborClassCode";
        public static string ID_select_PurchaseOrganization_programId = "programId";
        public static string ID_Typeahead_PlantNumber_siteLocationID = "siteLocationID";
        public static string ID_Radio_AccountAssignmentCostcenter_AccountAssignment1 = "AccountAssignment1";
        public static string ID_radio_AccountAssignmentWBSElement_AccountAssignment3 = "AccountAssignment3";
        public static string ID_Typeahead_PurchasingGroup_serviceMethodID = "serviceMethodID";
        public static string ID_Typeahead_DelegateofAuthority_alternateHiringManagerName = "alternateHiringManagerName";
        public static string ID_select_PurchaseOrg_programName = "programName";
        public static string ID_select_PlantNumber_siteLocationID = "siteLocationID";
        public static string ID_select_MaterialGroup_ddlaborClassCode = "ddlaborClassCode";

        //Keywords for Workspend-SallieMae 

        public static string ID_T1_Typeahead_Division_programId = "programId";
        public static string ID_Typeahead_Division_programName = "programName";
        //   public static string ID_T2_txt_BillrateHigh_billRateHigh = "billRateHigh";
        public static string ID_T1_Radiobtn_CWCanWorkRemotely_directIndirectFalse = "directIndirectFalse";
        public static string ID_T1_Radiobtn_CWCanWorkRemotely_directIndirectTrue = "directIndirectTrue";
        public static string ID_btn_CWcanworkRemotely_directIndirect1 = "directIndirect1";
        public static string ID_btn_CWcanworkRemotely_directIndirect0 = "directIndirect0";
        public static string ID_btn_Rehire_exEmployee = "exEmployee";
        public static string ID_Txt_RehireDetails_exEmployeeDetails = "exEmployeeDetails";
        public static string ID_btn_Rehirebtn_exEmployeeButton1 = "exEmployeeButton1";

        //End of Keywords for Workspend-SallieMae


        // Issue Work Order 


        //  public s2

        #region Issue Work Order
        public static string Xpath_CandidateWithoffers_Search = "//*[@id='regularCandidateListWithOffer_filter']//input";
        public static string Xpath_Link_CandidateWithoffers_CandidateName = "//*[@id='regularCandidateListWithOffer']//tr//td[@class='sorting_1']//a";
        public static string Xpath_IssueWorkOrder_Tabsall = "//*[@id='stdIconsContainer']//a[@id='tabsAll']";
        public static string Xpath_IssueWorkOrder_Popup_Yes = "//*[@id='dialog-confirmIssue']/following-sibling::div/div/button[text()='Yes']";
        public static string Xpath_IssueWorkOrder_Popup_OK = "//*[@id='dialog-confirmIssue1']/following-sibling::div/div/button/span";
        public static string ID_IssueWorkOrder_tabsAll = "tabsAll";
        public static string ID_Date_DesiredStartDate_preferredStartDate = "preferredStartDate";
        public static string Id_Button_Issueworkorder_IssueworkButton = "IssueworkButton";
        public static string XPath_paginate_regReqList_filter = "//*[@id='regReqList_filter']/label/input";
        public static string ID_btn_EXPANDALL_tabsExpandCollapse = "tabsExpandCollapse";

        #endregion



        #region screen Loaders
        public static string XPath_OverlayLoader = "//div[@id='loading-overlay' and @style='display: none;']";
        #endregion

        #region MT
        public static string ID_T1_typehead_LocationCode_CostCenterId = "CostCenterId";
        public static string ID_T1_txt_Comments_JustificationtoHire = "JustificationtoHire";
        public static string ID_T1_select_ReasontoEngage_reasonToHireID = "reasonToHireID";
        public static string ID_T1_select_DirectFill_laborClassCode = "laborClassCode";
        public static string ID_T1_Select_ShiftStart_ProfitCenterId = "ProfitCenterId";
        public static string ID_T1_Select_ShiftEnd_spendLevelId = "spendLevelId";
        public static string ID_T2_Txt_WeeklySpend_WeeklySpendValue = "WeeklySpendValue";
        public static string ID_T1_Text_Ifthespendisintheplanwhatlocationcodeappliestoit_singleLine12 = "singleLine12";
        public static string Xpath_T1_btn__DoesthedesiredskillsetexistatRydertoday_Yes = "//*[@specialconditiontext='RyderDesiredSkillsRadio']/following::span[contains(text(),'Yes')]";
        public static string Xpath_T1_btn_DoesthedesiredskillsetexistatRydertoday_No = "//*[@specialconditiontext='RyderDesiredSkillsRadio']/following::span[contains(text(),'No')]";
        public static string ID_T1_Text_Whoisthedesiredresource_singleLine9 = "singleLine9";
        public static string ID_T1_Text_Whatisthereasonfortheinabilitytoattainthedesiredresource_singleLine10 = "singleLine10";
        public static string Xpath_T1_btn_Isthisspendinyourplan_Yes = "//*[@specialconditiontext='RyderSpendPlanRadio']/following::span[contains(text(),'Yes')]";
        public static string Xpath_T1_btn_Isthisspendinyourplan_No = "//*[@specialconditiontext='RyderSpendPlanRadio']/following::span[contains(text(),'No')]";

        public static string Xpath_T1_btn_Haveyousearchedfortheresourceininternalresourceapplication_Yes = "//*[@name='radio13']/following::span[contains(text(),'Yes')]";
        public static string Xpath_T1_btn_Haveyousearchedfortheresourceininternalresourceapplication_No = "//*[@name='radio13']/following::span[contains(text(),'No')]";

        //Quicken Loans 
        public static string ID_T1_Typeahead_HiringLeader_hiringManager = "hiringManager";
        public static string ID_T1_Select_Company_organizationID = "organizationID";
        public static string ID_T1_Typeahead_BusinessArea_CostCenterId = "CostCenterId";
        public static string ID_T1_Typeahead_Team_deptNumber = "deptNumber";
        public static string ID_T1_Select_ExpenseAmount_GLId = "GLId";
        public static string ID_T1_Select_ReasonforRequest_reasonToHireID = "reasonToHireID";
        public static string Xpath_T1_btn_IsDeveloper_yes = "//*[@name='radio14']/following::span[contains(text(),'Yes')]";
        public static string Xpath_T1_btn_IsDeveloper_No = "//*[@name='radio14']/following::span[contains(text(),'No')]";
        public static string Xpath_T1_btn_NeedPCorMac_PC = "//*[@name='radio15']/following::span[contains(text(),'PC')]";
        public static string Xpath_T1_btn_NeedPCorMac_Mac = "//*[@name='radio15']/following::span[contains(text(),'Mac')]";
        public static string Xpath_T1_btn_NeedsLaptoporDesktop_Laptop = "//*[@name='radio16']/following::span[contains(text(),'Laptop')]";
        public static string Xpath_T1_btn_NeedsLaptoporDesktop_Desktop = "//*[@name='radio16']/following::span[contains(text(),'Desktop')]";
        public static string ID_T2_Select_JobCategory_typeofServiceID = "typeofServiceID";
        public static string ID_T2_Select_Hours_shiftID = "shiftID";
        public static string ID_T2_btn_TravelandAncillaryExpenses_expensesTrue = "expensesTrue";
        public static string ID_T2_btn_TravelandAncillaryExpenses_expensesFalse = "expensesFalse";
        public static string ID_T2_txt_EstimatedExpenseAmountperResourceforContractPeriod_expenseFixedAmount = "expenseFixedAmount";
        public static string ID_T2_txt_SalaryRangeMin_MinConversionSalary = "MinConversionSalary";
        public static string ID_T2_txt_SalaryRangeMax_MaxConversionSalary = "MaxConversionSalary";
        public static string ID_txt_Email_Email = "Email";


        //Issue Work order
        public static string ID_typeahead_BusinessArea_ChargeCostCenterId = "ChargeCostCenterId";
        public static string ID_Select_ExpenseAccount_ChargeGLId = "ChargeGLId";
        public static string ID_Typeahead_PONumber_purchaseOrderNumber = "purchaseOrderNumber";
        //Confirm CW
        public static string ID_Select_JobCategory_serviceType = "serviceType";
        public static string ID_Typeahead_Team_deptNumber = "deptNumber";
        public static string ID_Select_Company_organization = "organization";
        public static string ID_Typeahead_BusinessArea_CostCenterId = "CostCenterId";
        public static string ID_Select_ExpenseAccount_GLId = "GLId";
        public static string ID_Typeahead_HiringLeader_workLocationID = "workLocationID";
        public static string ID_Select_GRIFeeType_MSPTracking1 = "MSPTracking1";
        public static string ID_Select_GRISpendType_MSPTracking2 = "MSPTracking2";
        public static string ID_Select_GRISpendbyIndustry_MSPTracking3 = "MSPTracking3";
        public static string ID_Select_GRISpendbyCountry_MSPTracking4 = "MSPTracking4";
        public static string ID_Select_GRISpendbyCategory_MSPTracking5 = "MSPTracking5";
        public static string ID_Select_Race_nativeAmericanName = "nativeAmericanName";
        public static string ID_txt_iCIMSID_CustomerTrackingNumber2 = "CustomerTrackingNumber2";
        public static string ID_txt_CommonID_customerTrackingNumber = "customerTrackingNumber";

        public static string ID_Select_Category_serviceType = "serviceType";
        public static string ID_Typeahead_CompanyNumber_deptNumber = "deptNumber";
        public static string ID_Select_Business_organization = "organization";
        public static string ID_Select_WorkerClassification_laborClassCode = "laborClassCode";
        public static string ID_Typeahead_RequestOwner_hiringManagerName = "hiringManagerName";
        public static string ID_Typeahead_Requestor_alternateHiringManagerName = "alternateHiringManagerName";
        public static string ID_btn_FormerEmployee_exEmployee = "exEmployee";
        public static string ID_Txt_FormerEmployeeDetails_exEmployeeDetails = "exEmployeeDetails";
        public static string ID_btn_FormerContigentWorker_exContractor = "exContractor";
        public static string ID_Txt_FormerContigentWorker_exContractorDetails = "exContractorDetails";
        public static string ID_btn_FormerEmployeeSubmit_exEmployeeButton1 = "exEmployeeButton1";
        public static string ID_btn_FormerContigentWorkerSubmit_exContractorButton1 = "exContractorButton1";
        public static string ID_Txt_WorkdayID_CustomerTrackingNumber2 = "CustomerTrackingNumber2";
        public static string ID_Txt_RACFID_customerTrackingNumber = "customerTrackingNumber";
        public static string ID_Txt_ILMID_CustomerTrackingNumber3 = "CustomerTrackingNumber3";
        public static string ID_Select_TimeEntity_timeentry = "timeentry";


        //Accept Work Order
        public static string ID_Select_Race_nativeAmericanID = "nativeAmericanID";
        #endregion

        #region YP
        public static string ID_T1_select_YPCompany_siteLocationID = "siteLocationID";
        public static string ID_T1_Typeahead_RCCode_deptNumber = "deptNumber";
        public static string ID_T1_Typeahead_Requestor_hiringManager = "hiringManager";
        public static string ID_T1_Typeahead_AlternateRequestor_altHiringManager = "altHiringManager";
        public static string ID_T1_select_AccountCode_programId = "programId";
        public static string ID_T2_Typeahead_Title_txtJobTitle = "txtJobTitle";
        public static string ID_T2_Typeahead_AssignmentDetail_jobDescription = "jobDescription";
        public static string ID_btn_PriorYPHoldingsorATTemployee_ExperienceRadio0 = "ExperienceRadio0";
        public static string ID_btn_PriorYPHoldingsorATTemployee_ExperienceRadio1 = "ExperienceRadio1";
        public static string ID_Date_PriorYPHoldingsorATTemployeeFromDate_fromDate1 = "fromDate1";
        public static string ID_Date_PriorYPHoldingsorATTemployeeToDate_toDate1 = "toDate1";
        public static string ID_txt_PriorYPHoldingsorATTemployeeTitle_jobTitle = "jobTitle";
        public static string ID_txt_PriorYPHoldingsorATTemployeeSupervisor_supervisorName = "supervisorName";
        public static string ID_btn_PriorYPHoldingsorATTcontractor_contractor0 = "contractor0";
        public static string ID_btn_PriorYPHoldingsorATTcontractor_contractor1 = "contractor1";
        public static string ID_Date_PriorYPHoldingsorATTcontractorFromDate_fromDateContractor1 = "fromDateContractor1";
        public static string ID_Date_PriorYPHoldingsorATTcontractorToDate_toDateContractor1 = "toDateContractor1";
        public static string ID_txt_PriorYPHoldingsorATTcontractorTitle_jobTitle = "jobTitle";
        public static string ID_txt_PriorYPHoldingsorATTcontractorSupervisor_supervisorName = "supervisorName";
        public static string ID_btn_YPHoldingsorATTRetiree_RetireeRadio0 = "RetireeRadio0";
        public static string ID_btn_YPHoldingsorATTRetiree_RetireeRadio1 = "RetireeRadio1";
        public static string ID_Date_YPHoldingsorATTRetireeRetiredDate_RetiredDate = "RetiredDate";
        public static string ID_txt_YPHoldingsorATTRetireeTitle_RetiredJobTitle = "RetiredJobTitle";
        public static string Xpath_Date_PriorYPHoldingsorATTemployee_FromDate = "//*[@id = 'fromDate1']/following-sibling::img";
        public static string Xpath_Date_PriorYPHoldingsorATTemployee_ToDate = "//*[@id = 'toDate1']/following-sibling::img";
        public static string Xpath_Date_PriorYPHoldingsorATTcontractor_FromDate = "//*[@id = 'fromDateContractor1']/following-sibling::img";
        public static string Xpath_Date_PriorYPHoldingsorATTcontractor_ToDate = "//*[@id = 'toDateContractor1']/following-sibling::img";
        public static string Xpath_Date_YPHoldingsorATTRetiree_RetiredDate = "//*[@id = 'RetiredDate']/following-sibling::img";
        public static string ID_select_AccountCode_programName = "programName";
        public static string ID_txt_RCCode_deptNumber = "deptNumber";
        public static string ID_txt_RCDescription_deptName = "deptName";
        public static string ID_select_YPCompany_siteLocationID = "siteLocationID";
        public static string ID_select_ChargeNumbersCompany_AutoFilledChargeNoLabel1 = "AutoFilledChargeNoLabel1";
        public static string ID_select_ChargeNumbersAccount_AutoFilledChargeNoLabel2 = "AutoFilledChargeNoLabel2";
        public static string ID_Typeahead_ChargeNumbersRC_AutoFilledChargeNoLabel3 = "AutoFilledChargeNoLabel3";
        public static string ID_txt_ChargeNumbersMarket_AutoFilledChargeNoLabel4 = "AutoFilledChargeNoLabel4";
        public static string ID_txt_ChargeNumbersIssueDate_txtAutoFilledChargeNoLabel5 = "txtAutoFilledChargeNoLabel5";
        public static string ID_txt_ChargeNumbersDM_txtAutoFilledChargeNoLabel6 = "txtAutoFilledChargeNoLabel6";
        public static string ID_txt_ChargeNumbersFutureUse_txtAutoFilledChargeNoLabel7 = "txtAutoFilledChargeNoLabel7";
        public static string ID_btn_ChargeNumberAdd_ID_Button_addAutoFilledChargeNobtn = "ID_Button_addAutoFilledChargeNobtn";
        public static string ID_txt_YPUID_customerTrackingNumber = "customerTrackingNumber";
        

        public static string XPath_PopUp_Button_ReccuringFrequency_Submit = "//div[@aria-labelledby='ui-dialog-title-dialog']//button[@class='btn btn-sm btn-primary']";
        public static string Class_PopUp_Button_Submit = "btn btn-sm btn-primary";
        public static string Type_Popup = "popup";
        public static string Type_radio_button = "raidobutton";


        public static DateTime dtStartDate, dtEndDate, datediff;
        public static string date, Payratesmin = "10", payratemax = "12";
        //Review and submit 
        // Modified for ECV calculations
        public static string Xpath_T5_StartDate = "//span[@id='lblneededStartDate']";
        public static string Xpath_T5_EndDate = "//span[@id='lblenddate']";
        public static string Xpath_T5_PayRateRange = "//span[@id='lblpayRateHigh']";
        public static string Xpath_T5_BillRateRange = "//span[@id= 'lblbillRateHigh']";
        public static string Xpath_T5_EstimatedContractValue = "//span[@id='lblestContractValue']";

        //Approve page xpaths
        public static string Xpath_Lable_Date_StartDate = "//*[@id='accordionPin']//label[contains(text(),'Needed Date')]/following-sibling::label";
        public static string Xpath_Lable_Date_EndDate = "//*[@id='accordionPin']//label[contains(text(),'End Date')]/following-sibling::label";
        public static string Xpath_Lable_Rates_PayRate = "//div[@class='row clearfixDetails']//div//label[contains(text(),' Pay Rate')]//following-sibling::label";
        public static string Xpath_Lable_Rates_BillRate = "//div[@class='row clearfixDetails']//div//label[contains(text(),' Bill Rate')]//following-sibling::label";
        public static string Xpath_Lable_Rates_ContarctValue = "//div[@class='row clearfixDetails']//div//label[contains(text(),' Contract value')]//following-sibling::label";

        //offer to Hire 
        public static string Xpath_lable_Rates_SupplierBillrate = "//*[@id='tab_second1']//label[contains(text(),'Supplier Bill Rate')]//following-sibling::label";
        public static string supplierBillrate, numofhours, numofresources;
	





        //Lear 
        public static string ID_T1_Select_HRDepartment_deptNumber = "deptNumber";
        public static string ID_T1_Select_LocationCode_siteLocationID = "siteLocationID";
        public static string ID_T1_Typeahead_AccountCode_CostCenterId = "CostCenterId";
        public static string ID_T1_Select_HypersionCodeGLUnit_GLId = "GLId";
        public static string ID_T1_Select_BusinessUnit_organizationID = "organizationID";
        public static string ID_T1_Typeahead_APDepartment_deptName = "deptName";
        public static string ID_T1_Select_CORE_ProjectId = "ProjectId";
        public static string ID_T2_Txt_EstimatedLaborExpCost_estContractValue = "estContractValue";

        //Broadcast 
        public static string ID_txt_BillRate_ddlBillratesLow = "ddlBillratesLow";
        public static string ID_txt_BillRate_ddlBillratesHigh = "ddlBillratesHigh";
        public static string ID_Select_GeographicalLocation_ddlGeoLocation = "ddlGeoLocation";
        public static string ID_txt_MaximumNumberofSubmissions_maxNoOfSubmissions = "maxNoOfSubmissions";
        public static string ID_Radiobutton_Submissionslimitedbysupplier_isSubmissionPerSupplierYes = "isSubmissionPerSupplierYes";
        public static string ID_Radiobutton_Submissionslimitedbysupplier_isSubmissionPerSupplierNo = "isSubmissionPerSupplierNo";

        //Candidate submission
        public static string ID_Txt_Justificationtosubmitthecandidateforthisrequirementrequisition_lbljustificationDescription = "lbljustificationDescription";
        public static string ID_Radiobutton_PreviousEmployee_ExperienceRadio0 = "ExperienceRadio0";
        public static string ID_Radiobutton_PreviousEmployee_ExperienceRadio1 = "ExperienceRadio1";
        public static string ID_Date_PreviousEmployeeFromDate_fromDate1 = "fromDate1";
        public static string ID_Date_PreviousEmployeeToDate_toDate1 = "toDate1";
        public static string ID_txt_Previousemployeejobtitle_jobTitle = "jobTitle";
        public static string ID_txt_PreviousemployeeSupervisor_supervisorName = "supervisorName";
        public static string ID_Radiobutton_PreviousCW_contractor1 = "contractor1";
        public static string ID_Radiobutton_PreviousCW_contractor0 = "contractor0";
        public static string ID_Date_PreviousCW_fromDateContractor1 = "fromDateContractor1";
        public static string ID_Date_PreviousCW_toDateContractor1 = "toDateContractor1";
        public static string ID_Txt_PreviousCWjobtitle_jobTitle = "jobTitle";
        public static string ID_Txt_PreviousCWSupervisor_supervisorName = "supervisorName";
        public static string ID_RadioButton_Retiree_RetireeRadio0 = "RetireeRadio0";
        public static string ID_Radiobutton_Retiree_RetireeRadio1 = "RetireeRadio1";
        //public static string ID_Date_RetiredDate_RetiredDate = "RetiredDate";
        public static string ID_txt_RetireeJobTitle_RetiredJobTitle = "RetiredJobTitle";
        public static string ID_Select_InWhichCurrencydoyouwanttosubmittheCandidate_currencyID = "currencyID";
        public static string ID_Txt_MiddleName_MiddleName = "MiddleName";
        public static string ID_Txt_ZipPostalCode_ZipCode = "ZipCode";
        public static string ID_Date_Schedule_ScheduleDate = "ScheduleDate";

        //Issue Work Order 
        public static string ID_Select_BusinessUnit_ChargeorganizationID = "ChargeorganizationID";
        public static string ID_Select_HypersionCodeGLUnit_ChargeGLId = "ChargeGLId";
        public static string ID_Select_CORE_ChargeProjectId = "ChargeProjectId";
        public static string ID_Select_APDepartment_ChargedeptName = "ChargedeptName";
        public static string ID_Typeahead_AccountCode_ChargeCostCenterId = "ChargeCostCenterId";

        //Confirm CW
        public static string ID_Select_HRDepartment_deptNumber = "deptNumber";
        public static string ID_Select_APDepartment_deptName = "deptName";
        public static string ID_Select_HyperionCodeGLUnit_GLId = "GLId";
        public static string ID_Select_CORE_ProjectId = "ProjectId";
        public static string ID_Select_LocationCode_siteLocationID = "siteLocationID";
        public static string ID_Txt_Supplier_supplierName = "supplierName";
        public static string ID_Select_HyperionCodeGLUnit_ChargeGLId = "ChargeGLId";
        public static string ID_Typeahead_APDepartment_ChargedeptName = "ChargedeptName";
        public static string ID_Txt_PeopleSoftID_customerTrackingNumber = "customerTrackingNumber";

        public static string ID_T2_Radiobutton_SkillMandatory_skillRequiredTrue = "skillRequiredTrue";
        public static string ID_T2_Radiobutton_SkillMandatory_skillRequiredFalse = "skillRequiredFalse";
        public static string NAME_uploadAdditionalDocuments_resumedocumentsInput = "resumedocumentsInput";

        public static string ID_T2_Radiobutton_RateNegotiable_rateNegoTrue = "rateNegoTrue";
        public static string ID_T2_Radiobutton_RateNegotiable_rateNegoFalse = "rateNegoFalse";
        public static string ID_T2_Radiobutton_SubmitResumeswithHigherRates_rateConTrue = "rateConTrue";
        public static string ID_T2_Radiobutton_SubmitResumeswithHigherRates_rateConFalse = "rateConFalse";

        //APS
        public static string xpath_radiobutton_isssnvalid_true = "//*[@name='isSSNValid' and @type='radio' and @value='True']";
        public static string xpath_radiobutton_isssnvalid_false = "//*[@name='isSSNValid' and @type='radio' and @value='False']";
        public static string xpath_radiobutton_SpouseRelativesatAPS_True = "//*[@name='relative' and @type='radio' and @value='True']";
        public static string xpath_radiobutton_spouseRelativesatAPS_False = "//*[@name='relative' and @type='radio' and @value='False']";
        public static string xpath_radiobutton_Referral_True = "//*[@name='referral' and @type='radio' and @value='True']";
        public static string xpath_radiobutton_Referral_False = "//*[@name='referral' and @type='radio' and @value='False']";

        //EQT
        public static string ID_T1_Typeahead_ObjectAccount_GLId = "GLId";
        public static string ID_T1_Select_Group_serviceMethodID = "serviceMethodID";
        public static string ID_T1_select_WorkWeek_ProjectId = "ProjectId";
        public static string ID_T1_select_DoestheCWhaveITorFacilitiesneeds_siteLocationID = "siteLocationID";
        public static string ID_T1_btn_WillCWAccessPII_laborClassCode79 = "laborClassCode79";
        public static string ID_T1_btn_WillCWAccessPII_laborClassCode80 = "laborClassCode80";
        public static string ID_T2_select_RateType_rateTypeID = "rateTypeID";
        public static string ID_T2_txt_Mandatory_skillDescMandatory = "skillDescMandatory";
        public static string ID_T2_txt_Desired_skillDescDesired = "skillDescDesired";
        public static string ID_T2_txt_skillName_skillName = "skillName";
        public static string ID_T2_txt_Description_skillDescription = "skillDescription";
        public static string ID_T2_select_Years_skillYearsExpID = "skillYearsExpID";
        public static string ID_T2_btn_UseStartEndDateassuming40hoursperweek_rdtypeoption1 = "rdtypeoption1";
        public static string ID_T2_btn_Usetotalestimatedhoursfortheentirecontract_rdtypeoption2 = "rdtypeoption2";
        public static string ID_T2_btn_UseStartEndDateassumingadifferentestimatedhoursperweek_rdtypeoption3 = "rdtypeoption3";
        public static string ID_T2_btn_Nocalculationneeded_rdtypeoption4 = "rdtypeoption4";
        public static string ID_T2_txt_EstHoursWeek_EstWeeklyHours = "EstWeeklyHours";
        public static string ID_T1_Typeahead_BusinessUnit_organizationID = "organizationID";
        public static string ID_txt_BillRatesUSD_ddlBillratesHigh = "ddlBillratesHigh";
        public static string ID_Txt_Justification_lbljustificationDescription = "lbljustificationDescription";
        public static string ID_select_BirthMonth_STID2 = "STID2";
        public static string ID_select_BirthDay_STID3 = "STID3";
        public static string ID_Typeahead_PoNumber_purchaseOrderNumber = "purchaseOrderNumber";
        public static string ID_Typeahead_Company_ChargedeptNumber = "ChargedeptNumber";
        public static string ID_txt_ActiveDirectoryID_customerTrackingNumber = "customerTrackingNumber";
        public static string ID_Txt_PhoneNumber_homephone = "homephone";
        public static string ID_Txt_Email_email = "email";
        public static string ID_Txt__AddressLine2_address2 = "address2";
        public static string Xpath_txt_FromerEmployeeJobTitle = "//tr[@class='altOdd priorExperienceRow']//input[@id='jobTitle']";
        public static string Xpath_txt_FromerEmployeeSupervisor = "//tr[@class='altOdd priorExperienceRow']//input[@id='supervisorName']";
        public static string Xpath_txt_FromerContractorJobTitle = "//tr[@class='altOdd formerContractorRow']//input[@id='jobTitle']";
        public static string Xpath_txt_FromerContractorSupervisor = "//tr[@class='altOdd formerContractorRow']//input[@id='supervisorName']";
        public static string ID_Date_FormerEmployeeFromDate_fromDate1 = "fromDate1";
        public static string ID_Date_FormerEmployeeToDate_toDate1 = "toDate1";
        public static string ID_Date_FormerContractorFromDate_fromDateContractor1 = "fromDateContractor1"; 
        public static string ID_Date_FormerContractorToDate_toDateContractor1 = "toDateContractor1";
        public static string ID_Select_Gender_Gender = "Gender";

        //Sigma        
        public static string ID_T1_Typeahead_WBSElement_ProjectId = "ProjectId";
        public static string ID_T1_Typeahead_MatrixNumber_matrixNumber = "matrixNumber";
        public static string ID_Typeahead_GL_ChargeGLId = "ChargeGLId";
        public static string ID_Typeahead_WBSElement_ChargeProjectId = "ChargeProjectId";
        public static string ID_Typeahead_MatrixNumber_matrixNumber = "matrixNumber";
        public static string ID_Typeahead_WBSElement_ProjectId = "ProjectId";
        public static string ID_Typeahead_ProgramName_programName = "programName";
        public static string ID_Txt_SavingsComment_savingComment = "savingComment";


        //Keywords
        public static string str_Name_Txt_LastName_FirstName = "";
        public static string str_Email_Txt_Supplier = "";
        //Identified
        public static string ID_T4_Txt_LastName_lastname = "lastname";
        public static string ID_T4_Txt_FirstName_firstname = "firstname";
        public static string ID_T4_Txt_MiddleName_middlename = "middlename";
        public static string ID_T4_Select_Suffix_nameSuffix = "nameSuffix";
        public static string ID_T4_btn_UploadResume_uploadResume = "uploadResume";
        public static string ID_T4_Radiobutton_FormerEmployee_exEmployeeYes = "exEmployeeYes";
        public static string ID_T4_Radiobutton_FormerEmployee_exEmployeeNo = "exEmployeeNo";
        public static string ID_T4_Txt_FormerEmployeeDetails_exEmployeeDetails = "exEmployeeDetails";
        public static string ID_T4_Radiobutton_Retiree_retiredEmployeeYes = "retiredEmployeeYes";
        public static string ID_T4_Radiobutton_Retiree_retiredEmployeeNo = "retiredEmployeeNo";
        public static string ID_T4_Txt_RetireeDetails_retiredEmployeeDetails = "retiredEmployeeDetails";
        public static string ID_T4_Radiobutton_FormerIntern_exInternYes = "exInternYes";
        public static string ID_T4_Radiobutton_FormerIntern_exInternNo = "exInternNo";
        public static string ID_T4_Txt_FormerInternDetails_exInternDetails = "exInternDetails";
        public static string ID_T4_Radiobutton_FormerContractor_exContractorYes = "exContractorYes";
        public static string ID_T4_Radiobutton_FormerContractor_exContractorNo = "exContractorNo";
        public static string ID_T4_Txt_FormerContractorDetails_exContractorDetails = "exContractorDetails";
        public static string ID_T4_Txt_Justification_soleJustificationDescription = "soleJustificationDescription";
        public static string ID_T4_btn_UploadJustification_uploadJustification = "uploadJustification";
        public static string ID_T4_Select_Supplier_supplierName = "supplierName";
        public static string ID_Radiobtn_Retiree_retiredEmployeeNo = "retiredEmployeeNo";

        // keywords added for Altria

        public static string Id_T4_lastdayWorked = "lastdayWorked";
        public static string Id_T4_lastSupervisor = "lastSupervisor";
        public static string Id_T4_lastcompany = "lastcompany";
        public static string Id_T4_lastRehireStatus = "lastRehireStatus";
        public static string Id_T4_lastPosition = "lastPosition";
        public static string Id_T4_lastSeverenceStatus = "lastSeverenceStatus";
        public static string Id_T4_lastReasonforLeaving = "lastReasonforLeaving";
        public static string Id_T4_lastDeparment = "lastDeparment";
        public static string Id_T4_lastServicesProvided = "lastServicesProvided";

        //Issue offer to hire
        public static string ID_Txt_payrate_ProposepayrateForMarkup = "ProposepayrateForMarkup";
        public static string ID_Txt_OTpayrate_ProposeotpayrateForMarkup = "ProposeotpayrateForMarkup";
        public static string ID_Txt_payratemarkup_supplierpayratemarkup = "supplierpayratemarkup";
        public static string ID_Txt_BillRate_ProposebillrateForMarkup = "ProposebillrateForMarkup";
        public static string ID_Txt_OTBillRate_ProposeotbillrateForMarkup = "ProposeotbillrateForMarkup";
        public static string ID_btn_Offertohiresaveandcontinue_btnbtnContinueRates = "btnbtnContinueRates";
        public static string ID_Txt_LastName_lastname = "lastname";
        public static string ID_Txt_FirstName_firstname = "firstname";
        public static string ID_Txt_MiddleName_middlename = "middlename";
        //public static string ID_Select_Suffix_nameSuffix = "nameSuffix";
        public static string ID_btn_UploadResume_uploadResume = "uploadResume";
        public static string ID_Radiobutton_Retiree_retiredEmployeeYes = "retiredEmployeeYes";
        public static string ID_Radiobutton_Retiree_retiredEmployeeNo = "retiredEmployeeNo";
        public static string ID_Txt_RetireeDetails_retiredEmployeeDetails = "retiredEmployeeDetails";
        public static string ID_radiobutton_FormerEmployee_exEmployeeYes = "exEmployeeYes";
        public static string ID_radiobutton_FormerEmployee_exEmployeeNo = "exEmployeeNo";
        //public static string ID_Txt_FormerEmployeeDetails_exEmployeeDetails = "exEmployeeDetails";
        public static string ID_radiobutton_FormerIntern_exInternYes = "exInternYes";
        public static string ID_radiobutton_FormerIntern_exInternNo = "exInternNo";
        public static string ID_Txt_FormerInternDetails_exInternDetails = "exInternDetails";
        public static string ID_radiobutton_FormerContractor_exContractorYes = "exContractorYes";
        public static string ID_radiobutton_FormerContractor_exContractorNo = "exContractorNo";
        public static string ID_Txt_FormerContractorDetails_exContractorDetails = "exContractorDetails";
        public static string ID_Txt_Justification_soleJustificationDescription = "soleJustificationDescription";
        public static string ID_btn_UploadJustification_uploadJustification = "uploadJustification";
        //public static string ID_Typeahead_Supplier_supplierName = "supplierName";
        public static string ID_Txt_ContactLastName_recruiterLastName = "recruiterLastName";
        public static string ID_Txt_ContactFirstName_recruiterFirstName = "recruiterFirstName";
        public static string ID_Txt_Phone_workPhone = "workPhone";
        public static string ID_Txt_Email_workEmail = "workEmail";
        public static string ID_T1_Txt_DepartmentName_deptName = "deptName";
        public static string ID_T4_Radiobutton_FormerUSGovtMilitaryEmployee_exGovMilEmployeeYes = "exGovMilEmployeeYes";
        public static string ID_T4_Radiobutton_FormerUSGovtMilitaryEmployee_exGovMilEmployeeNo = "exGovMilEmployeeNo";
        public static string ID_T4_Txt_FormerUSGovtMilitaryEmployee_exGovMilEmployeeDetails = "exGovMilEmployeeDetails";
        public static string ID_T4_Txt_ContactLastName_recruiterLastName = "recruiterLastName";
        public static string ID_T4_Txt_ContactFirstName_recruiterFirstName = "recruiterFirstName";
        public static string ID_T4_Txt_Phone_workPhone = "workPhone";
        public static string ID_T4_Txt_Email_workEmail = "workEmail";
        public static string ID_Radiobuttion_FormerUSGovtMilitaryEmployee_exGovMilEmployeeYes = "exGovMilEmployeeYes";
        public static string ID_Radiobuttion_FormerUSGovtMilitaryEmployee_exGovMilEmployeeNo = "exGovMilEmployeeNo";
        public static string ID_Txt_FormerUSGovtMilitaryEmployeeDetails_exGovMilEmployeeDetails = "exGovMilEmployeeDetails";
        public static string ID_Txt_IdentifiedCandidate_PayRateMarkup_markup = "markup";
        public static string Xpath_txt_Extendofferpopup_Email = "//label[contains(text(),'Email')]//following-sibling::label";
        public static string Xpath_upload_Uploadpofiles = "//a[@id='uploadPO']";
        public static string ID_txt_SecurityClearnance_securityClearanceLevelID = "securityClearanceLevelID";
        public static string Xpath_txt_FromercontarctorSupervisor_supervisorName = "//*[@id='formerContractorTable']//td//input[@id='supervisorName']";
        // STGEN
        public static string Xpath_txt_FromerEmployeeJobTitle_jobTitle = "//*[@id='priorExperienceTable']//td//input[@id='jobTitle']";
        public static string Xpath_txt_FromerContarctorJobTitle_jobTitle = "//*[@id='formerContractorTable']//td//input[@id='jobTitle']";
        public static string Xpath_txt_FromerEmployeeSupervisor_supervisorName = "//*[@id='priorExperienceTable']//td//input[@id='supervisorName']";
        public static string Xpath_T1_Enddateclick = "//*[@aria-label='enddate Calendar']";

        //offer to hire - Yp
        public static string ID_Select_RateLevel_ddRateLevel = "ddRateLevel";

        //added by manjusha		
        public static string ID_Button_MspUserManagement_Search_btnSearchMspUser = "btnSearchMSPUser";	
        public static string XPath_Link__SearchResults_MspUser = "//table[@id='dgrmspusers']//td/a";

        //Added by manjusha for approve		
        public static string ID_Txt_MSPUserManagement_FirstName_DefaultContent_TxtFirstName = "DefaultContent_TxtFirstName";
        public static string ID_Txt_MSPUserManagement_LastName_DefaultContent_TxtLastName = "DefaultContent_TxtLastName";
        public static string XPath_Link__SearchResults_MSPUser = "//table[@id='dgrmspusers']//td/a";
        public static string ID_MSG_UserManagement = "DefaultContent_divErrorReports";		
        public  static string XPath_Btn_UserManagementSearch = "//button[contains(@id,'btnSearch')]";


        public static string ID_T2_Button_SaveAsDraftAndClose_btnJobSaveAndClose = "btnJobSaveAndClose";
        public static string XPATH_H1_Title_RequirementInProgress = "//h1[@class='title-bg']";
        public static string XPATH_tab_JobDescription = "//li[@tabid='tab_second' and contains(text(),'Job Description')]";
        public static string XPATH_Txt_Search_RequirementsInProgress = "//div[@id='HistoryTableViewProgReg_filter']//input";
        public static string XPATH_Table_HistoryTableViewProgReg = "//table[@id='HistoryTableViewProgReg']//tbody//tr[1]"; 
        public static string XPATH_Link_ContinueToEdit = "//table[@id='HistoryTableViewProgReg']//tbody//tr[1]//td/a[@wtitle=' Continue to Edit']";
        public static string XPATH_Link_ContinueToDelete = "//table[@id='HistoryTableViewProgReg']//tbody//tr[1]//td/a[@wtitle=' Delete']";
        public static string XPATH_DeleteDraft_Popup_Btn_Yes = "//div[@aria-labelledby='ui-dialog-title-dialog' and not(contains(@style,'display: none'))]//button[contains(@class,'primary')]";
        public static string XPATH_AlertMessage_ReqInProgress = "//div[@id='subPageContainer']//div[@role='alert']";



        public static string Xpath_EditLink = "//*[@class='reqEdit']/a";
        public static string ID_Button_PrescreenQuestion_guidelines_guidelineAccepted_Edit = "btnQuestionSaveCont";
        public static string Xpath_Button_Yes = "//*[@id='reqSubmiteDialog']/following::div/div/button[text()='Yes']";
        public static string ID_btn_Save_btnSubmit = "btnSubmit"; 
        public static string Xpath_btn_OK = "//*[@id='dvAfterSave']/following::div/div/button[text()='Ok']";
        public static string XPath_ActionList = "//*[starts-with(@class,'actEditCandidateInfo')]"; 
        public static string Xpath_CandidateNameLink = "//*[text()='Candidate Name']/following::label";

        //Added by manjusha for action matrix

        public static string Xpath_TemplateTable_Edit = "//table[@id='HistoryTableViewTempReg']//tr//td//a[@wtitle=' Create Requisition']";
        public static string Xpath_OutlineTab = "//*[@tabid='tab_first']";
        public static string Xpath_JobDescriptionTab = "//*[@tabid='tab_second']";
        public static string Xpath_Tab_Reviewandsubmit = "//*[@tabid='tab_fifth']";
        public static string Xpath_Link_MyreuirementTemplates = "//*[@id='result']//p//a";
        public static string Xpath_Radio_ListTemplates = "//form[@id='frmSelectTemplate']//li//label//input[@name='tempSelect1']";
        public static string XPath_Button_SelectTemplate = "//form[@id='frmSelectTemplate']//a";
        public static string Id_Button_Cancel = "txtCancel";
        public static string Xpath_CancelPopup = "//div[@id='dvConfirmation']//label";
        public static string XPath_Cancel_yes = "//div[@aria-labelledby='ui-dialog-title-dialog' and not(contains(@style,'display: none'))]//button[contains(@class,'primary')]";
        public static string ID_Button_CreateAsset = "btnCreateNew";
        public static string ID_Txt_CategoryName = "assetCategoryName";
        public static string XPath_Txt_AsserCategorytDesccription = "//textarea[@id='description']";
        public static string ID_button_category_yes = "Confirm_yes";
        public static string ID_Txt_AssetType = "assetTypeName";
        public static string ID_select_AssetCategory = "assetCategoryID";
        public static string ID_Txt_AssetName = "assetName";
        public static string ID_Select_AssetType = "//select[@fieldname='assetTypeID']";
        public static string Xpath_Button_Training_Popup_Yes = "//div[@aria-labelledby='ui-dialog-title-dialog-TrainingConfirm1' and not(contains(@style,'display: none'))]//button[contains(@class,'primary')]";
        public static string Xpath_Button_Training_Popup_Ok = "//div[@aria-labelledby='ui-dialog-title-dialog-TrainingConfirm2' and not(contains(@style,'display: none'))]//button[contains(@class,'primary')]";

        //training
        public static string ID_Button_Tarining = "btnCreateTraining";
        public static string ID_Txt_TrainingName = "TxtTrainingName";
        public static string ID_Txt_TrainingDescription = "TxtCategoryDescription";
        public static string ID_Radio_PreSubmitYes = "rblMandPresubmitYes";
        public static string ID_Radio_PreSubmitNo = "rblMandPresubmitNo";
        public static string ID_Radio_allCWyes = "rblMandallYes";
        public static string ID_Radio_allCWNO = "rblMandallNo";
        public static string ID_Radio_PreStartyes = "rblMandPrestartYes";
        public static string ID_Radio_PreStartno = "rblMandPrestartNo";
        public static string ID_Radio_Recurringyes = "rblRecurringYes";
        public static string ID_Radio_Recurringno = "rblRecurringNo";
        public static string ID_select_RecurringFrequency = "Cmbfrequency";


        //Document
        public static string ID_Txt_Document = "txtDocument";
        public static string ID_Txt_DocumentType = "ddldocType";
        public static string ID_Txt_ExpiryDays = "txtExpiryDays";
        public static string ID_Radio_DocPreSubmitYes = "//div[@aria-labelledby='radiogp2']//input[@id='rblMandpresubmitYes']";
        public static string ID_Radio_DocPreSubmitNo = "//div[@aria-labelledby='radiogp2']//input[@id='rblMandpresubmitNo']";
        public static string ID_Radio_DocPreStartYes = "//div[@aria-labelledby='radiogp3']//input[@id='rblMandPrestartYes']";
        public static string ID_Radio_DocPreStartNo = "//div[@aria-labelledby='radiogp3']//input[@id='rblMandPrestartNo']";
        public static string ID_Radio_AdminOverrideAllowedYes = "rblAdminOverrideYes";
        public static string ID_Radio_AdminOverrideAllowedNo = "rblAdminOverrideNo";
        public static string ID_button_CreateDocument = "btnCreateDocument";
        public static string ID_Radio_DocumentUploadRequiredYes = "rblDocupdreqdYes";
        public static string ID_Radio_DocumentUploadRequiredNo = "rblDocupdreqdNo";
        public static string Xpath_Button_Con_Document_PopupYes = "//div[@id='dialog-DocumentConfirm1']//following-sibling ::div//button[@class='btn btn-sm btn-primary']";
        public static string Xpath_Button_Con_Document_PopupOk = "//div[@id='dialog-DocumentConfirm2']//following-sibling ::div//button[@class='btn btn-sm btn-primary']";
        //compliance
        public static string ID_button_CreateCompliance = "btnCreateCompliance";
        public static string ID_Txt_Compliance = "txtCompliance";
        public static string ID_Txt_ComplianceType = "ddlComplianceType";
        public static string ID_Txt_ComplianceDescription = "TxtComplianceDescription";
        public static string ID_Txt_ComplianceStepName = "complianceStepName";
        public static string ID_Radio_ComplianceStepNameApproveyes = "complianceStepMSPApproveTrue";
        public static string ID_Radio_ComplianceStepNameApproveNo = "complianceStepMSPApproveFalse";
        public static string ID_Txt_CompliancePkgName = "packageName";
        public static string ID_Radio_CompliancePkgNameyes = "indefiniteExpiryTrue";
        public static string ID_Radio_CompliancePkgNameNo = "indefiniteExpiryFalse";
        public static string ID_Txt_CompliancePkgExpiryDays = "expiryDays";
        public static string ID_Radio_AdminOverrideReason = "overrideReason";
        public static string ID_Radio_AdminOverrideAllowedyes = "rblAdminOverrideYes";
        public static string ID_Radio_AdminOverrideAllowed = "rblAdminOverrideNo";
        public static string ID_Radio_CompliancePresubmityes = "rblMandpresubmitYes";
        public static string ID_Radio_CompliancePresubmitNo = "rblMandpresubmitNo";
        public static string ID_Radio_CompliancePrestartyes = "rblMandPrestartYes";
        public static string ID_Radio_CompliancePrestartno = "rblMandPrestartNo";
        public static string ID_Radio_ComplianceDocuploadRequiredyes = "rblComplianceupdreqdYes";
        public static string ID_Radio_ComplianceDocuploadRequiredNo = "rblComplianceupdreqdNo";
        public static string Xpath_Button_Compliancepopupyes = "//div[@id='dialog-confirmCreateCompliance1']//following-sibling ::div//button[@class='btn btn-sm btn-primary']";
        public static string Xpath_Button_Compliancepopupok = "//div[@id='dialog-confirmCreateCompliance2']//following-sibling ::div//button[@class='btn btn-sm btn-primary']";
        public static string XPath_Btn_ExistRequirement_SelectRequirement = "//form[@id='frmSelectRequirement']//div//button";

        public static string Xpath_RejectWorkOrder_yes = "//*[@id='dvBeforeRejectWorkOrder']/following::div//button[text()='Yes']"; 
        public static string Xpath_RejectWorkOrder_Ok = "//*[@id='dvAfterRejectWorkOrder']/following::div//button[text()='Ok']";
        public static string Xpath_Label_CandidateStatus = "//*[contains(text(),'Status')]/following-sibling::label/span";
        public static string Xpath_RejectOffer_Yes = "//*[@id='dvBeforeRejectOffer']/following::div/div/button[text()='Yes']";
        public static string XPath_RejectOffer_Ok = "//*[@id='dvAfterRejectOffer']/following::div/div/button[text()='Ok']";

        public static string Xpath_btn_CandidateNoShow_Submit = "//*[@id='dialog']/following::div/button[text()='Submit']";
        public static string Xpath_btn_CandidateNoShow_Yes = "(//*[@id='dialog-confirmnoshow']/following::div/button[text()='Yes'])[last()]"; 
        public static string Xpath_btn_CandidateNoShow_OK = "//*[@id='dialog-confirmnoshow2']/following::div//button[text()='Ok']";
        public static string ID_Check_RollbackNoshow = "rollbackCandidatenoshow";
        public static string Xpath_btn_CandidateRollbacknoshow_RollBackNoShow = "//*[@id='dialog']/following::div/button[text()='RollBack No Show']";
        public static string Xpath_btn_CandidateRollbacknoshow_OK = "(//*[@id='dialog-confirmnoshow2']/following::div//button[text()='Ok'])[last()]";
        public static string ID_check_CandidateNoShow_candidateIsNoShow = "candidateIsNoShow";
        public static string ID_Txt_Candidate_Comment = "Comment";
        //supplier Action list keyword
        public static string Xpath_SuplierDeclineAL = "//*[@class='reqDecline']";
        public static string ID_Select_Declinepopup = "DeclineReason";
        public static string Xpath_button_declineyes = "//div[@id='dvBeforeDecline']//following::button[1]";
        public static string Xpath_button_Decline_ok = "//div[@id='dvAfterDecline']//following::button[1]";
        public static string Xpath_RollbackDeclineAL = "//*[@class='reqRollBackDecline']";
        public static string Xpath_button_Rollbackdecline = "//button[contains(text(),'Rollback Decline')]";
        public static string Xpath_button_rollbackdeclineYES = "//span[contains(text(),'Rollback Declined Requirement')]//following::button[1]";
        public static string Xpath_button_rollbackdeclineOK = "//label[contains(text(),'has been Rollbacked')]//parent::div//following::div//button";
        public static string Xpath_Decline_Button = "//span[@class='icon-thumbsdown']";
        public static string Xpath_ResumeBanknavigation = "//li[@aria-label='Resume Bank']//span";
        public static string id_searchCandidatename_candidateName = "candidateName";
        public static string Xpath_searchcandidate_secondrow = "//*[@aria-describedby='resumeBankList_info']//tr[2]";
        public static string Xpath_searchcandidate_candidatespage_secondrow = "//*[@id='tblregularcandidates']//tr[2]";
        public static string Xpath_searchcandidate_firstrow = "//td[@class=' wrapNormal']";
        public static string Xpath_searchcandidate_candidatespage_firstrow = "//td[contains(@aria-label,'Candidate Name')]//a";

        public static string Xpath_candidatepagetitle = "//span[@id='pageTitle']";
        public static string Xpath_Action_Editcandidateinfo = "//li[@class='resumeEditCandidate']";
        public static string Xpath_Searchcandiadte_search = "//*[@id='tblregularcandidates']//input[@id='CandidateName']";
        public static string ID_Select_Withdrwreason_WithdrawReason = "WithdrawReason";
        public static string Xpath_button_withdraw = "//div[@aria-labelledby='ui-dialog-title-dialog']//button[1]";
        public static string Xpath_button_Withdraw_YES = "//div[@aria-labelledby='ui-dialog-title-dvBeforeWithdraw' and not(contains(@style,'display: none;'))]//button[1]";
        public static string Xpath_button_Withdraw_OK = "//div[@aria-labelledby='ui-dialog-title-dvAfterWithdraw']//button[1]";

        public static string Xpath_Searchwithdrawncandidate = "//*[@id='HistoryTableViewWithdrawn']//input[@id='CandidateName']";
        public static string Xpath_searchWithdrawn_secondrow = "//*[@id='HistoryTableViewWithdrawn']//tr[2]";
        public static string Xpath_Searchwithdrawn_firstrow = "//*[@id='HistoryTableViewWithdrawn']//tr[1]//td[1]//a";

        public static string Xpath_Myworkspace_Req_firstreqwithapprovalstatus = "//*[@id='regReqList']/tbody/tr/td[2]/a";

        public static string Xpath_Myworkspace_Req_searchreqnumber = "//*[@id='regReqSearchList']/tbody/tr/td[2]/a";

        public static string Id_SendRemainder_emailList = "emailList";

        public static string Xpath_Myworkspace_Req_sendReminder = "//*[@id='listMenu1']//li/a[contains(text(),'Send Reminder')]";


        public static string Xpath_Myworkspace_Req_reque = "//*[@id='listMenu1']//li/a[contains(text(),'Requeue')]";

        public static string Xpath_Myworkspace_Req_rebroadcast = "//*[@id='listMenu1']//li/a[contains(text(),'Rebroadcast')]";

        public static string Xpath_Myworkspace_Req_addcomments = "//*[@id='listMenu1']//li/a[contains(text(),'Add Comment')]";

        public static string Xpath_Myworkspace_Req_broadCastDetails = "//*[@id='listMenu1']//li/a[contains(text(),'Broadcast Details')]";

        public static string Xpath_Myworkspace_Req_edit = "//*[@id='listMenu1']//li/a[contains(text(),'Edit')]";

        public static string Xpath_Myworkspace_Req_saveascatalog = "//*[@id='listMenu1']//li/a[contains(text(),'Save As Catalog')]";

        public static string Xpath_Myworkspace_Req_ReOpenrequirement = "//*[@id='listMenu1']//li/a[contains(text(),'Re-Open req')]";

        public static string Xpath_Myworkspace_Req_recallRequisition = "//*[@id='listMenu1']//li/a[contains(text(),'Recall Req')]";

        public static string Xpath_Myworkspace_Req_AssignMSPPointofContact = "//*[@id='listMenu1']//li/a[contains(text(),'Assign MSP Point of Contact')]";

        public static string Xpath_Myworkspace_Req_ChangeStatus = "//*[@id='listMenu1']//li/a[contains(text(),'Change Status')]";

        public static string Xpath_Myworkspace_Req_convertReqtopayrolled = "//*[@id='listMenu1']//li/a[contains(text(),'To Payrolled')]";

        public static string Xpath_Myworkspace_Req_Cancel = "//*[@id='listMenu1']//li/a[contains(text(),'Cancel')]";

        public static string Xpath_Myworkspace_Req_OpenDiscussion = "//*[@id='listMenu1']//li/a[contains(text(),'Open Discussion')]";

        public static string Xpath_Myworkspace_Req_viewETKDetails = "//*[@id='listMenu1']//li/a[contains(text(),'View ETK Details')]";

        public static string ID_returnList = "returnList";

        public static string Xpath_Myworkspace_Nodataavaialble = "//*[@id='regReqList']//td[contains(text(),'No data available in table')]";

        public static string ID_saveascatalaog_NameCatalog = "NameCatalog";

        public static string ID_assignmspoc_txtassignmsppoc = "txtassignmsppoc";

        public static string Xpath_Closebutton = "//*[@id='dlgSendEmailInfo']/following::div/button[text()='Close']";

        public static string Xpath_Closebutton_saveascatalog = "//*[@id='dialog']/following::div/button[text()='Close']";

        public static string Xpath_Ok_button = "//*[@id='dialog-success']/following::div/button";

        public static string Xpath_Ok_button_cancelconfirm = "//*[@id='cancel-confirmcancel2']/following::div/button";

        public static string Xpath_Ok_button_msppoc = "//*[@id='dialog-confirmmsg']/following::div/button";

        public static string Xpath_Ok_button_SaveCatalogSuccessDialog = "//*[@id='SaveCatalogSuccessDialog']/following::div/button";

        public static string Xpath_Ok_button_dialog_confirmcomm2 = "//*[@id='dialog-confirmcomm2']/following::div/button";

        public static string Xpath_Ok_button_dialog_confirmreopen2 = "//*[@id='dialog-confirmreopen2']/following::div/button";

        public static string Xpath_Ok_button_dialog_confirmstatus2 = "//*[@id='dialog-confirmstatus2']/following::div/button";

        public static string Xpath_Yes_button = "//div[@aria-labelledby='ui-dialog-title-dialog-confirm']//button[text()='Yes']";

        public static string Xpath_Yes_button_cancelconfirm = "//*[@id='cancel-confirmcancel1']/following::div/button[text()='Yes']";

        public static string Xpath_Yes_button_dialog_confirmreqcomm1 = "//*[@id='dialog-confirmreqcomm1']/following::div/button[text()='Yes']";

        public static string Xpath_Yes_button_dialog_reqSubmiteDialog = "//*[@id='Convert2PayrolledDialog']/following::div/button[text()='Yes']";

        public static string Xpath_Yes_button_dialog_confirmstatus1 = "//*[@id='dialog-confirmstatus1']/following::div/button[text()='Yes']";

        public static string Xpath_Yes_button_dialog_confirmmsg = "//*[@id='dialog-confirmmsg']/following::div/button[text()='Yes']";

        public static string Xpath_Yes_button_dialog_confirmreopen1 = "//*[@id='dialog-confirmreopen1']/following::div/button[text()='Yes']";

        public static string Xpath_Yes_button_dialog_OpenDiscussion = "//*[@id='confirmationDialog']/following::div/button[text()='Yes']";

        public static string Xpath_Submit_button = "//*[@id='dialog-success']/following::div/button[text()='Submit']";

        public static string Xpath_Submit_button_dialog_confirmstatus1temp = "//*[@id='dialog-confirmstatus1temp']/following::div/button[text()='Submit']";

        public static string Xpath_button_Submit = "//*[@id='dialog']/following::div/button[text()='Submit']";

        public static string ID_T5_btn_tab5 = "tab5";

        public static string Xpath_requeueList_button = "//*[contains(@id,'approver')][1]";

        public static string ID_btn_removeRequeue_btnRemove = "btnRemove";

        public static string XPath_Link_SearchResult_CW = "//*[@id='accordionPin']/div/div/div/label[2]";

        public static string ID_select_statuschange_ddlReqStatus = "ddlReqStatus";

        public static string ID_button_btnSearchReq = "btnSearchReq";

        public static string ID_Txt_changestatus_Comments = "TxtComment";

        public static string XPath_Link_Search_CW = "//*[@id='regReqSearchList_filter']//input";

        public static string Xpath_requeueList_addApprover = "//div[@class='approverTypeAhead']/input";

        public static string ID_addButton_addNextButton = "addNextButton";

        public static string ID_addButton_btnUpdate = "btnUpdate";

        public static string ID_str_RecallReason = "RecallReason";

        public static string ID_str_proposedStartDate = "proposedStartDate";

        public static string ID_str_propesedStartTime = "propesedStartTime";

        public static string ID_str_proposedEndDate = "propesedEndDate";

        public static string ID_str_propesedEndTime = "propesedEndTime";

        public static string ID_T1_Typeahead_hosts_hiringManager = "hiringManager";

        public static string ID_addButton_hosts_hiringManager = "addManagerbtn";

        // venky
        public static string ID_Select_Reason_ReasonId = "ReasonId";
        public static string ID_text_Comments_txtComments = "txtComments";
        public static string ID_text_Justification_txtComments = "txtComments";
        public static string ID_select_ConfigurationRule_onboardConfigID = "onboardConfigID";
        public static string ID_typeahead_SubmittoAdditionalManagers_txtManager = "txtManager";


        public static string Xpath_btn_radio_Doesnotmeetmyrequirement = " //input[@name='rbfeedbackId' and @value='551']";
        public static string Xpath_btn_radio_Meetsmyrequirement = " //input[@name='rbfeedbackId' and @value='552']";
        public static string Xpath_btn_radio_Exceedsmyrequirement = " //input[@name='rbfeedbackId' and @value='553']";
        public static string Xpath_btn_radio_Other = " //input[@name='rbfeedbackId' and @value='580']";


        public static string Xpath_AddtoDoNotSubmitList_Popup_Yes = "//*[@id='dialog-confirmdonot']/following-sibling::div/div/button[text()='Yes']";
        public static string Xpath_AddtoDoNotSubmitList_Popup_OK = "//div[@aria-labelledby='ui-dialog-title-dialog-okyes' and not(contains(@style,'display: none'))]//button";


        public static string Xpath_RecallfromDoNotSubmitList_Popup_Yes = "//*[@id='dialog-confirmrecalldonot']/following-sibling::div/div/button[text()='Yes']";
        public static string Xpath_RecallfromDoNotSubmitList_Popup_OK = " //div[@aria-labelledby='ui-dialog-title-dialog-okyes'and not(contains(@style,'display: none'))]//button";


        public static string Xpath_Feedback_Popup_Yes = "//*[@id='dialog-confirmmsgfeed1']/following-sibling::div/div/button[text()='Yes']";
        public static string Xpath_Feedback_Popup_OK = "//*[@id='dialog-confirmmsgfeed2']/following::div/button[text()]";

        public static string Xpath_Shortlist_Popup_Yes = " //*[@id='dialog-confirmshort1']/following-sibling::div/div/button[text()='Yes']";
        public static string Xpath_Shortlist_Popup_OK = " //*[@id='dialog-confirmshort2']/following-sibling::div/div/button[text()]";

        public static string Xpath_UnShortlist_Popup_Yes = "  //*[@id='dialog-confirmunshort1']/following-sibling::div/div/button[text()='Yes']";
        public static string Xpath_UnShortlist_Popup_OK = " //*[@id='dialog-confirmunshort2']/following-sibling::div/div/button[text()]";

        public static string Xpath_RequestResubmission_Popup_Yes = " //*[@id='dialog-confirmdonot']/following-sibling::div/div/button[text()='Yes']";
        public static string Xpath_RequestResubmission_Popup_OK = " //*[@id='dialog-okyes']/following-sibling::div/div/button[text()]";

        public static string Xpath_InitiateOnboarding_Popup_Yes = " //*[@id='confirmationDialog']/following-sibling::div/div/button[text()='Yes']";
        public static string Xpath_InitiateOnboarding_Popup_OK = " //*[@id='successDialog']/following-sibling::div/div/button[text()]";

        public static string Xpath_SubmittoAdditionalManagers_Popup_Yes = " //*[@id='dialog-confirmfrman1']/following-sibling::div/div/button[text()='Yes']";
        public static string Xpath_SubmittoAdditionalManagers_Popup_OK = " //*[@id='dialog-confirmfrman2']/following-sibling::div/div/button[text()]";



        public static string Xpath_SubmittedManagerDetail_button_Cancel = "//*[@id='dialog']/following-sibling::div/div/button[text()]";
        public static string ID_Select_RejectReason_ReasonId = "ReasonId";
        public static string ID_Txt_Comment_txtComments = "txtComments";
        public static string Xpath_Date_ApprovalLog_CreateDate = "//*[@id='Table4']//tr[@class = 'altOdd skillrow odd']/td[1]";
        public static string ID_btn_SaveasDraftandClose_btnSave = "btnSave";
        public static string ID_DraftRequirementNUmber_CLSRNumber = "CLSRNumber";
        public static string Xpath_Link_Draftsubmission = "//*[@id='HistoryTableViewDraft']//tbody//tr//td[1]//a";
        public static string XPath_Text_Clientsearch_candidatename = "//*[@id='HistoryTableViewCCandidate_filter']//input"; 
        public static string XPath_Click_ClickCandidate = "//*[@id='HistoryTableViewCCandidate']//td[3]//a";
        public static string XPath_Button_Submit = "//button[text()='Submit']";
        public static string XPath_Comment_Verification_addCandidatetobucket = "//div[@id='DataTables_Table_4_wrapper']//tr[@class='altOdd skillrow odd']//td[contains(@aria-label,'Comment') and not(@class='lastChildPR')]";
        public static string ID_Txt_WithdrawReason_reasonid = "reasonid";

        #region OnBoarding_AddTraining
        public static string XPATH_Link_Onboarding_ActionListMenu_AddTraining = "//ul[@id='listMenu1']//a[contains(text(),'Add Training')]";
        public static string ID_Select_AddTrainingPopup_Training_CmbTraining = "CmbTraining";
        public static string XPATH_Btn_AddTrainingPopup_Submit = "//div[@aria-labelledby='ui-dialog-title-dialog' and not(contains(@style,'display: none'))]//button[contains(@class,'primary')  and text()='Submit']";
        public static string XPATH_Btn_AddTrainingPopup_Close = "//div[@aria-labelledby='ui-dialog-title-dialog' and not(contains(@style,'display: none'))]//button[contains(@class,'danger')  and text()='Close']";
        public static string XPATH_Btn_AddTrainingPopup_Yes = "//div[@aria-labelledby='ui-dialog-title-dialogWorkspaceAddTraining_Confirm1' and not(contains(@style,'display: none'))]//button[contains(@class,'primary')  and text()='Yes']";
        public static string XPATH_Btn_AddTrainingPopup_Ok = "//div[@aria-labelledby='ui-dialog-title-dialogWorkspaceAddAsset_Msg' and not(contains(@style,'display: none'))]//button[contains(@class,'primary')  and text()='Ok']";
        public static string XPATH_Btn_TrainingAccordin_SendReminder(string sTrainingDetails)
        {
            string XPATH_Btn_TrainingAccordin_SendReminder = "//table[@id='TrainAccord']//tbody//td//a[@class='trainDetails' and contains(text(),'" + sTrainingDetails + "')]//ancestor::tr//td[@class='text-right lastChildPR']//a/span[@data-original-title='Send Reminder']";
            return XPATH_Btn_TrainingAccordin_SendReminder;
        }

        public static string XPATH_Btn_TrainingAccordin_UpdateStatus(string sTrainingDetails)
        {
            string XPATH_Btn_TrainingAccordin_UpdateStatus = "//table[@id='TrainAccord']//tbody//td//a[@class='trainDetails' and contains(text(),'" + sTrainingDetails + "')]//ancestor::tr//td[@class='text-right lastChildPR']//a/span[@data-original-title='Update Status']";
            return XPATH_Btn_TrainingAccordin_UpdateStatus;
        }

        public static string ID_Select_UpdateStatusPopup_Status_appStatus = "appStatus";
        public static string ID_Txt_UpdateStatusPopup_Commnets_TxtComments = "TxtComments";
        public static string XPATH_Btn_UpdateStatusPopup_Submit = "//div[@aria-labelledby='ui-dialog-title-dialog' and not(contains(@style,'display'))]//button[text()='Submit')]";
        public static string XPATH_Btn_Training_UpdateStatusPopup_Yes = "//div[@aria-labelledby='ui-dialog-title-dialog_TrainingUpdateStatusYesNo' and not(contains(@style,'display'))]//button[text()='Yes']";
        public static string XPATH_Btn_Training_UpdateStatusPopup_Ok = "//div[@aria-labelledby='ui-dialog-title-dialog_TrainingUpdateStatusOk' and not(contains(@style,'display'))]//button[text()='Ok']";
        public static string XPATH_Btn_TrainingAccordin_Status(string sTrainingDetails)
        {
            string XPATH_Btn_TrainingAccordin_Status = "//table[@id='TrainAccord']//tbody//td//a[@class='trainDetails' and contains(text(),'" + sTrainingDetails + "')]//ancestor::tr//td[3]";
            return XPATH_Btn_TrainingAccordin_Status;
        }
        public static string XPATH_Btn_TrainingAccordin_Delete(string sInput)
        {
            string XPATH_Btn_TrainingAccordin_Delete = "//table[@id='TrainAccord']//tbody//td//a[@class='trainDetails' and contains(text(),'" + sInput + "')]//ancestor::tr//td[contains(@class,'text-right lastChildPR')]//a/span[@data-original-title='Training Delete']";
            return XPATH_Btn_TrainingAccordin_Delete;
        }
        public static string XPATH_Btn_DeleteTrainingPopup_Yes = "//div[@aria-labelledby='ui-dialog-title-dialogWorkspace_DeleteTrainingYN' and not(contains(@style,'display: none'))]//button[contains(@class,'primary')  and text()='Yes']";
        public static string XPATH_Btn_DeleteTrainingPopup_Ok = "//div[@aria-labelledby='ui-dialog-title-dialogWorkspace_DeleteTrainingok' and not(contains(@style,'display: none'))]//button[contains(@class,'primary')  and text()='Ok']";
        public static string XPATH_AlertMsg_Popup = "//div[@role='alert' and not(contains(@style,'display: none'))]";

        #endregion

        #region Asset
        public static string XPATH_Link_Onboarding_ActionListMenu_AddAsset = "//ul[@id='listMenu1']//a[contains(text(),'Add Asset')]";
        public static string ID_Select_AddAssetPopup_AssetCategory_CmbAssetCategory = "CmbAssetCategory";
        public static string ID_Select_AddAssetPopup_AssetType_CmbAssetType = "CmbAssetType";
        public static string ID_Select_AddAssetPopup_Asset_CmdAsset = "CmdAsset";
        public static string ID_Txt_AddAssetPopup_Comment_TxtAssetcomment = "TxtAssetcomment";
        public static string XPATH_Btn_AddAssetPopup_Submit = "//div[@aria-labelledby='ui-dialog-title-dialog' and not(contains(@style,'display: none'))]//button[text()='Submit']";
        public static string XPATH_Btn_AddAssetPopup_Close = "//div[@aria-labelledby='ui-dialog-title-dialog' and not(contains(@style,'display: none'))]//button[text()='Close']";
        public static string XPATH_Btn_AddAssetPopup_Yes = "//div[@aria-labelledby='ui-dialog-title-dialogWorkspaceAddAsset_Confirm1' and not(contains(@style,'display: none'))]//button[contains(@class,'primary')  and text()='Yes']";
        public static string XPATH_Btn_AddAssetPopup_Ok = "//div[@aria-labelledby='ui-dialog-title-dialogWorkspaceAddAsset_Msg' and not(contains(@style,'display: none'))]//button[contains(@class,'primary')  and text()='Ok']";
        public static string XPATH_Btn_AssetAccordin_SendReminder(string sInput)
        {
            string XPATH_Btn_AssetAccordin_SendReminder = "//table[@id='AssetAccord']//tbody//td//a[@class='assetDetails' and contains(text(),'" + sInput + "')]//ancestor::tr//td[contains(@class,'text-right lastChildPR')]//a/span[@data-original-title='Send Reminder']";
            return XPATH_Btn_AssetAccordin_SendReminder;
        }
        public static string XPATH_Btn_AssetAccordin_UpdateStatus(string sInput)
        {
            string XPATH_Btn_AssetAccordin_UpdateStatus = "//table[@id='AssetAccord']//tbody//td//a[@class='assetDetails' and contains(text(),'" + sInput + "')]//ancestor::tr//td[contains(@class,'text-right lastChildPR')]//a/span[@data-original-title='Update Status']";
            return XPATH_Btn_AssetAccordin_UpdateStatus;
        }
        public static string XPATH_Btn_Asset_UpdateStatusPopup_Yes = "//div[@aria-labelledby='ui-dialog-title-dialog_AssetUpdateStatusMSPYesNo' and not(contains(@style,'display'))]//button[text()='Yes']";
        public static string XPATH_Btn_Asset_UpdateStatusPopup_Ok = "//div[@aria-labelledby='ui-dialog-title-dialog_AssetUpdateStatusMSPOk' and not(contains(@style,'display'))]//button[text()='Ok']";
        public static string XPATH_Btn_AssetAccordin_Delete(string sInput)
        {
            string XPATH_Btn_AssetAccordin_Delete = "//table[@id='AssetAccord']//tbody//td//a[@class='assetDetails' and contains(text(),'" + sInput + "')]//ancestor::tr//td[contains(@class,'text-right lastChildPR')]//a/span[@data-original-title='Asset Delete']";
            return XPATH_Btn_AssetAccordin_Delete;
        }
        public static string XPATH_Btn_DeleteAssetPopup_Yes = "//div[@aria-labelledby='ui-dialog-title-dialogWorkspace_DeleteYN' and not(contains(@style,'display: none'))]//button[contains(@class,'primary')  and text()='Yes']";
        public static string XPATH_Btn_DeleteAssetPopup_Ok = "//div[@aria-labelledby='ui-dialog-title-dialogWorkspace_Deleteok' and not(contains(@style,'display: none'))]//button[contains(@class,'primary')  and text()='Ok']";
        public static string XPATH_Btn_AssetAccordin_Status(string sInput)
        {
            string XPATH_Btn_AssetAccordin_Status = "//table[@id='AssetAccord']//tbody//td//a[@class='assetDetails' and contains(text(),'" + sInput + "')]//ancestor::tr//td[2]";
            return XPATH_Btn_AssetAccordin_Status;
        }
        #endregion

        #region AddDocument
        public static string XPATH_Link_Onboarding_ActionListMenu_AddDocument = "//ul[@id='listMenu1']//a[contains(text(),'Add Document')]";
        public static string ID_Select_AddDocumentPopup_Document_Cmbdocument = "Cmbdocument";
        public static string XPATH_Btn_AddDocumentPopup_Submit = "//div[@aria-labelledby='ui-dialog-title-dialog' and not(contains(@style,'display: none'))]//button[contains(@class,'primary')  and text()='Submit']";
        public static string XPATH_Btn_AddDocumentPopup_Close = "//div[@aria-labelledby='ui-dialog-title-dialog' and not(contains(@style,'display: none'))]//button[contains(@class,'danger')  and text()='Close']";
        public static string XPATH_Btn_AddDocumentPopup_Yes = "//div[@aria-labelledby='ui-dialog-title-dialogWorkspaceAddDocument_Confirm1' and not(contains(@style,'display: none'))]//button[contains(@class,'primary')  and text()='Yes']";
        public static string XPATH_Btn_AddDocumentPopup_Ok = "//div[@aria-labelledby='ui-dialog-title-dialogWorkspaceAddAsset_Msg' and not(contains(@style,'display: none'))]//button[contains(@class,'primary')  and text()='Ok']";
        public static string XPATH_Btn_DocumentAccordin_SendReminder(string sInput)
        {
            string XPATH_Btn_DocumentAccordin_SendReminder = "//table[@id='DocAccord']//tbody//td//a[@class='documentDetails' and contains(text(),'" + sInput + "')]//ancestor::tr//td[contains(@class,'text-right lastChildPR')]//a/span[@data-original-title='Send Reminder']";
            return XPATH_Btn_DocumentAccordin_SendReminder;
        }
        public static string XPATH_Btn_DocumentAccordin_ExtendExpiryDays(string sInput)
        {
            string XPATH_Btn_DocumentAccordin_ExtendExpiryDays = "//table[@id='DocAccord']//tbody//td//a[@class='documentDetails' and contains(text(),'" + sInput + "')]//ancestor::tr//td[contains(@class,'text-right lastChildPR')]//a/span[@data-original-title='Extend Expiry Days']";
            return XPATH_Btn_DocumentAccordin_ExtendExpiryDays;
        }
        public static string ID_Txt_ExtendExpiryDaysPopup_ExtendExpirationDays_expiryDays = "expiryDays";
        public static string XPATH_Btn_ExtendExpiryDaysPopup_Extend = "//div[@aria-labelledby='ui-dialog-title-dialog' and not(contains(@sytle,'display: none'))]//button[contains(@class,'primary') and text()='Extend']";
        public static string XPATH_Btn_ExtendExpiryDaysPopup_Close = "//div[@aria-labelledby='ui-dialog-title-dialog' and not(contains(@sytle,'display: none'))]//button[contains(@class,'danger') and text()='Close']";
        public static string XPATH_Btn_ExtendExpiryDaysPopup_Yes = "//div[@aria-labelledby='ui-dialog-title-dialog_DocExtendExpiryMSPYesNo' and not(contains(@sytle,'display: none'))]//button[contains(@class,'primary') and text()='Yes']";
        public static string XPATH_Btn_ExtendExpiryDaysPopup_Ok = "//div[@aria-labelledby='ui-dialog-title-dialog_DocExtendExpiryMSPOk' and not(contains(@sytle,'display: none'))]//button[contains(@class,'primary') and text()='Ok']";
        public static string XPATH_Lbl_DocumentAccordin_ExpiryDate(string sInput)
        {
            string XPATH_Lbl_DocumentAccordin_ExpiryDate = "//table[@id='DocAccord']//tbody//td//a[@class='documentDetails' and contains(text(),'" + sInput + "')]//ancestor::tr//td[contains(@aria-label,'Expiry Date')]";
            return XPATH_Lbl_DocumentAccordin_ExpiryDate;
        }
        public static string XPATH_Btn_DocumentAccordin_UpdateStatus(string sInput)
        {
            string XPATH_Btn_DocumentAccordin_UpdateStatus = "//table[@id='DocAccord']//tbody//td//a[@class='documentDetails' and contains(text(),'" + sInput + "')]//ancestor::tr//td[contains(@class,'text-right lastChildPR')]//a/span[@data-original-title='Update Status']";
            return XPATH_Btn_DocumentAccordin_UpdateStatus;
        }


        //public static string XPATH_Btn_UpdateStatusPopup_Submit = "//div[@aria-labelledby='ui-dialog-title-dialog' and not(contains(@style,'display'))]//button[contains(@class,'primary') and text()='Submit']";
        public static string XPATH_Btn_Document_UpdateStatusPopup_Yes = "//div[@aria-labelledby='ui-dialog-title-dialog_DocUpdateStatusMSPYesNo' and not(contains(@style,'display'))]//button[text()='Yes']";
        public static string XPATH_Btn_Document_UpdateStatusPopup_Ok = "//div[@aria-labelledby='ui-dialog-title-dialog_DocUpdateStatusMSPOk' and not(contains(@style,'display'))]//button[text()='Ok']";
        public static string XPATH_Btn_DocumentAccordin_Resubmit(string sInput)
        {
            string XPATH_Btn_DocumentAccordin_Resubmit = "//table[@id='DocAccord']//tbody//td//a[@class='documentDetails' and contains(text(),'" + sInput + "')]//ancestor::tr//td[contains(@class,'text-right lastChildPR')]//a/span[@data-original-title='Resubmit']";
            return XPATH_Btn_DocumentAccordin_Resubmit;
        }
        public static string ID_Btn_ResubmitDocPopup_UploadDoucment_uploaddocfile = "uploaddocfile";
        public static string ID_Txt_ResubmitDocPopup_Comments_txtResubmitComment = "txtResubmitComment";

        public static string XPATH_Btn_ResubmitDocPopup_Yes = "//div[@aria-labelledby='ui-dialog-title-confirmationDialog' and not(contains(@style,'display: none'))]//button[contains(@class,'primary') and text()='Yes']";
        public static string XPATH_Btn_ResubmitDocPopup_Ok = "//div[@aria-labelledby='ui-dialog-title-successDialog' and not(contains(@style,'display: none'))]//button[contains(@class,'primary') and text()='Ok']";
        public static string XPATH_Btn_DocumentAccordin_Delete(string sInput)
        {
            string XPATH_Btn_DocumentAccordin_Delete = "//table[@id='DocAccord']//tbody//td//a[@class='documentDetails' and contains(text(),'" + sInput + "')]//ancestor::tr//td[contains(@class,'text-right lastChildPR')]//a/span[@data-original-title='Document Delete']";
            return XPATH_Btn_DocumentAccordin_Delete;
        }
        public static string XPATH_Btn_DeleteDocumentPopup_Yes = "//div[@aria-labelledby='ui-dialog-title-dialogWorkspace_DeleteDocumentYN' and not(contains(@style,'display: none'))]//button[contains(@class,'primary')  and text()='Yes']";
        public static string XPATH_Btn_DeleteDocumentPopup_Ok = "//div[@aria-labelledby='ui-dialog-title-dialogWorkspace_DeleteDocumentok' and not(contains(@style,'display: none'))]//button[contains(@class,'primary')  and text()='Ok']";
        public static string XPATH_Btn_DocumentAccordin_Status(string sInput)
        {
            string XPATH_Btn_DocumentAccordin_Status = "//table[@id='DocAccord']//tbody//td//a[@class='documentDetails' and contains(text(),'" + sInput + "')]//ancestor::tr//td[3]";
            return XPATH_Btn_DocumentAccordin_Status;
        }
        #endregion

        #region AddCompliance
        public static string XPATH_Link_Onboarding_ActionListMenu_AddCompliance = "//ul[@id='listMenu1']//a[contains(text(),'Add Compliance')]";
        public static string ID_Select_AddCompliancePopup_Compliance_CmbCompliance = "CmbCompliance";
        public static string XPATH_Btn_AddCompliancePopup_Submit = "//div[@aria-labelledby='ui-dialog-title-dialog' and not(contains(@style,'display: none'))]//button[contains(@class,'primary')  and text()='Submit']";
        public static string XPATH_Btn_AddCompliancePopup_Close = "//div[@aria-labelledby='ui-dialog-title-dialog' and not(contains(@style,'display: none'))]//button[contains(@class,'danger')  and text()='Close']";
        public static string XPATH_Btn_AddCompliancePopup_Yes = "//div[@aria-labelledby='ui-dialog-title-dialogWorkspaceAddCompliance_Confirm1' and not(contains(@style,'display: none'))]//button[contains(@class,'primary')  and text()='Yes']";
        public static string XPATH_Btn_AddCompliancePopup_Ok = "//div[@aria-labelledby='ui-dialog-title-dialogWorkspaceAddAsset_Msg' and not(contains(@style,'display: none'))]//button[contains(@class,'primary')  and text()='Ok']";
        public static string XPATH_Btn_ComplianceAccordin_UpdateStatus(string sInput)
        {
            string XPATH_Btn_ComplianceAccordin_UpdateStatus = "//table[@id='ComplianceAccord']//tbody//td//a[contains(@class,'ComplianceDetails') and contains(text(),'" + sInput + "')]//ancestor::tr//td/a[@wtitle='Override Status']";
            return XPATH_Btn_ComplianceAccordin_UpdateStatus;
        }
        public static string XPATH_Btn_Compliance_UpdateStatusPopup_Yes = "//div[@aria-labelledby='ui-dialog-title-dialog_ComplianceUpdateStatusMSPYesNo' and not(contains(@style,'display'))]//button[text()='Yes']";
        public static string XPATH_Btn_Compliance_UpdateStatusPopup_Ok = "//div[@aria-labelledby='ui-dialog-title-dialog_ComplianceUpdateStatusMSPOk' and not(contains(@style,'display'))]//button[text()='Ok']";
        #endregion

        #region SendReminder
        public static string XPATH_Btn_SendReminderPopup_Yes = "//div[@aria-labelledby='ui-dialog-title-dialogDoc_DeleteYN' and not(contains(@style,'display'))]//button[text()='Yes']";
        public static string XPATH_Btn_SendReminderPopup_Ok = "//div[@aria-labelledby='ui-dialog-title-dialogDoc-Deleteok' and not(contains(@style,'display'))]//button[text()='Ok']";
        #endregion

        public static string JS_ResubmitDocPopup_Resubmmit = "$('.ui-dialog.ui-widget.ui-widget-content.ui-draggable.ui-resizable.dialogTop:visible').find('button:contains(\"Resubmit\")').click()";
        public static string JS_ResubmitDocPopup_Yes = "$('div[aria-labelledby=\"ui-dialog-title-confirmationDialog\"]:visible').find('button:contains(\"Yes\")').click()";
        public static string JS_ResubmitDocPopup_Ok = "$('div[aria-labelledby=\"ui-dialog-title-successDialog\"]:visible').find('button:contains(\"Ok\")').click()";
        public static string JS_Popup_Submit = "$('.ui-dialog.ui-widget.ui-widget-content.ui-draggable.ui-resizable.dialogTop:visible').find('button:contains(\"Submit\")').click()";
        public static string XPATH_Btn_ExpandCollapse = "//span[@id='tabsExpandCollapse' and text()='Expand All']";

        //onboarding action list 

        public static string ID_select_reasonforpause_Cmbpausereason = "Cmbpausereason";
        public static string ID_Pauseonbardingcomment_Txtpausereasoncomment = "Txtpausereasoncomment";
        public static string Xpath_pauseonbaording_YES = "//div[@aria-labelledby='ui-dialog-title-dialogWorkspacePauseOnboarding_Confirm1' and not(contains(@style,'display: none;'))]//button[1]";
        public static string Xpath_pauseonbaording_OK = "//div[@aria-labelledby='ui-dialog-title-dialogWorkspacePauseOnboarding_Msg']//button[1]";
        public static string ID_Text_Resumeonboarding_Txtresumecomment = "Txtresumecomment";
        public static string Xpath_Button_Resumeonboarding_YES = "//div[@aria-labelledby='ui-dialog-title-dialogWorkspaceResumeOnboarding_Confirm1' and not(contains(@style,'display: none;'))]//button[1]";
        public static string Xpath_Bubtton_Resumeonboarding_OK = "//div[@aria-labelledby='ui-dialog-title-dialogWorkspaceResumeOnboarding_Msg']//button[1]";
        public static string ID_Select_Reasonforcancellatio_Cmbcancelreason = "Cmbcancelreason";
        public static string Id_Text_reasoncomment_Txtreasononboardcomment = "Txtreasononboardcomment";
        public static string Xpath_Button_Cancelonboarding_YES = "//div[@aria-labelledby='ui-dialog-title-confirmationDialog' and not(contains(@style,'display: none;'))]//button[1]";
        public static string Xpath_Button_Cancelonboarding_OK = "//div[@aria-labelledby='ui-dialog-title-successDialog']//button[1]";



        //submit information

        public static string Xpath_onboardingheder = "//*[@class='catalog-name-label title-bg']";
        public static string Xpath_isthenewhire_YES = "//label[contains(text(),'Is the new hire a')]//following-sibling::div//label[1]";
        public static string Xpath_isthenewhire_No = "//label[contains(text(),'Is the new hire a')]//following-sibling::div//label[2]";
        public static string Xpath_phonerequired_YES = "//label[contains(text(),'Phone Required')]//following-sibling::div//label[1]";
        public static string Xpath_phonerequired_NO = "//label[contains(text(),'Phone Required')]//following-sibling::div//label[2]";
        public static string Xpath_Text_Existingphonenumber = "//label[contains(text(),'Existing Phone Number')]//following-sibling::div//input";
        public static string Xpath_Text_NameAssignedtoExistingPhone = "//label[contains(text(),'Name Assigned to Existing')]//following-sibling::div//input";

        public static string Xpath_btn_Submit_Submitinformation = "//div[@class='text-right mtop20 mbottom10']//button[1]";
        public static string Xpath_Btn_Submitinformation_YES = "//div[@aria-labelledby='ui-dialog-title-confirm' and not(contains(@style,'display: none;'))]//button[1]";
        public static string Xpath_Btn_Submitinformation_Ok = "//div[@aria-labelledby='ui-dialog-title-confirm']//button[1]";
        public static string Xpath_btn_Softphonerequired_YES = "//label[contains(text(),'Softphone Required')]//following-sibling::div//label[1]";
        public static string Xpath_btn_Softphonerequired_NO = "//label[contains(text(),'Softphone Required')]//following-sibling::div//label[2]";
        public static string Xpath_select_PCrequired_YES = "//label[contains(text(),'PC Required ')]//following-sibling::div//label[1]";
        public static string Xpath_Select_PCrequired_NO = "//label[contains(text(),'PC Required ')]//following-sibling::div//label[2]";
        public static string Xpath_Select_PCtype = "//label[contains(text(),'PC Type')]//following-sibling::div//select";



        
        #endregion

        #region Framework
        public static string XMLFilePath = "";
        public static Dictionary<string, string> LabelDictionary, dict_Data;
        public static string sLabelName;
        public static Boolean _isLableCaptured = false;
        public static string Type_table_radio_button = "table_raidobutton";
        public static string Type_Table = "table";
        public static string Type_Button = "button";
        public static Boolean _isXMLLoaded=false;
        #endregion
    }

}
