// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SmartTrack.cs" company="DCR Workforce Inc">
//   Copyright (c) DCR Workforce Inc. All rights reserved.
//   This code and information should not be copied and used outside of DCR Workforce Inc.
// </copyright>
// <summary>
//  This Constants is used
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace SmartTrack_Automation
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using System.Data.OleDb;
    using System.Data;
    using OpenQA.Selenium.Remote;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;
    using CommonFiles;
    using SmartTrack_Automation;
    using RelevantCodes.ExtentReports;
    using System.Xml;
    using System.IO;

    
    
    
    public class SmartTrack
    {
        public static IWebDriver driver;
        public static IWebDriver driverApp;
        public static IWebDriver driverSup;
        public static IWebDriver driverClient;
        public ExtentReports extent, LabelReport;
        public static int MSPexecutionNo = 0;
        public static int SupexecutionNo = 0;
        public static int ClientexecutionNo = 0;
        public static Boolean ScenarioStatus = true;
        public static string screenShotPath = "";
        public ExtentTest parent;
        public ExtentTest child;
        public string reportPath = "";

        //[SetUp]
        public void StartReport()
        {
            
            Thread.Sleep(100);
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath; // project path of your solution
            DateTime date1 = DateTime.Now;
            string report_number = date1.ToString("yyyyMMMddHHmmss");
            string reportPath = projectPath + "Reports\\" + report_number + ".html";
            //string reportPath = projectPath + "Reports\\testreport5.html";

            // true if you want to append data to the report.  Replace existing report with new report.  False to create new report each time
            extent = new ExtentReports(reportPath, false);
            extent.AddSystemInfo("Host Name", "localhost")
                .AddSystemInfo("Environment", "QA")
                .AddSystemInfo("User Name", "Automation Team");

            extent.LoadConfig(projectPath + "extent-config.xml");
            string labelReportPath = projectPath + "LabelReports\\" + "LabelReport_" + report_number + ".html";

            LabelReport = new ExtentReports(labelReportPath, false);
            LabelReport.AddSystemInfo("Host Name", "localhost")
                .AddSystemInfo("Environment", "QA")
                .AddSystemInfo("User Name", "Automation Team");

            LabelReport.LoadConfig(projectPath + "lbl-config.xml");


        }

        public ExtentReports StartLabelReport()
        {

            return null;
        }
        //[SetUp]
        public void SetupTest()
        {
            //driver = new ChromeDriver();
            //driver = new FirefoxDriver();
        }

        //[Test]
        public void TestStart()
        {
            ReadExcel ReadExcelHelper = new ReadExcel();
            CommonMethods objCommonMethods = new CommonMethods();
            KeyWordMethods kwm = new KeyWordMethods();
            Approve objApprove = new Approve();
            Broadcast objCreate_Broadcast = new Broadcast();
            SubmitCandidate objCreate_SubmitCandidate = new SubmitCandidate();
            SubmitToManager objCreate_SubmitToManager = new SubmitToManager();
            Request_Interview objerequestinter = new Request_Interview();
            Schedule_Interview schduleinterview = new Schedule_Interview();
            Confirm_Interview confirminterview = new Confirm_Interview();
            OTH_EO objOTH_EO = new OTH_EO();
            AcceptOffer accepectoffer = new AcceptOffer();
            IssueWorkOrder objCreate_IssueWorkOrder = new IssueWorkOrder();
            AcceptWorkOrder objCreate_AcceptWorkOrder = new AcceptWorkOrder();
            Onboarding objCreate_Onboarding = new Onboarding();
            ConfirmCW objCreate_ConfirmCW = new ConfirmCW();
            var MainMasterSheetResult = new Result();
            var MasterSheetResult = new Result();
            KeyWords.LabelDictionary = new Dictionary<string, string>();
            CreateRequirement objCreate_Requirement;
           // CreateRequirement objCreate_Requirement = new CreateRequirement(ChooseBrowser1(driver, "chrome"), kwm, objCommonMethods);
            string strMainMasterSql = "SELECT ClientID,ClientName,RunMode,Url1,Url2,BrowserMSP,BrowserAPP,BrowserSUP,Results FROM [" + KeyWords.strMasterSheetName + "] where RunMode = 'Yes'";
            MainMasterSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath_Master, KeyWords.strMasterSheetName, strMainMasterSql);
            if (MainMasterSheetResult.Result1 == "Pass")
            {

                foreach (DataRow drowMainMaster in MainMasterSheetResult.dt.Rows)
                {
                    KeyWords.str_App_Url = drowMainMaster["Url1"].ToString();
                    KeyWords.str_App_Url2 = drowMainMaster["Url2"].ToString();

                    string sDirFile = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Input\\all_clients_input_data\\" + drowMainMaster["ClientName"].ToString().Trim()+".xlsx";
                    if (drowMainMaster["ClientName"].ToString() != "" && File.Exists(sDirFile))
                    {
                        KeyWords.strExlInputPath = sDirFile;


                        string strMasterSql = "SELECT TestScenarioID,RunMode,Client,Description FROM [" + KeyWords.strMasterSheetName + "] where RunMode = 'Yes'";
                        MasterSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, KeyWords.strMasterSheetName, strMasterSql);
                        if (MasterSheetResult.Result1 == "Pass")
                        {
                            foreach (DataRow drowMaster in MasterSheetResult.dt.Rows)
                            {
                                MSPexecutionNo = 0;
                                SupexecutionNo = 0;
                                ClientexecutionNo = 0;
                                if ((drowMaster[1].ToString().ToUpper() == "YES") && (drowMaster[0].ToString() != null) && (drowMaster[2].ToString().Trim() != ""))
                                {
                                    string TestScenarioId = drowMaster[3].ToString();
                                    /*Loading XML based on client*/
                                    string currentPath = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                                    string XMLPath = currentPath.Substring(0, currentPath.LastIndexOf("packages"));
                                    string projectPath = new Uri(XMLPath).LocalPath; // project path of your solution
                                    if (ReportHandler._IsLabelReportRequired)
                                    {
                                        KeyWords.XMLFilePath = projectPath + @"SmartTrack.DataAccess\Labels\" + drowMaster[2].ToString() + ".xml";
                                        KeyWords._isXMLLoaded = kwm._XMLReader();
                                    }
                                    /*-- End of loading*/
                                    objCommonMethods.TestCase_Result_OutPutExcel_Old();
                                    string strMainSql = "SELECT TestCaseId,NumberOfRepeats,DataSheet,Include,UserName FROM [" + KeyWords.strMainSheetName + "] where TestScenario = '" + drowMaster[0].ToString() + "' and Include ='yes'";
                                    objCommonMethods.WriteLogFileBeginHeader(KeyWords.strLogfilePath);
                                    var MainSheetResult = new Result();
                                    var SubSheetResult2 = new Result();
                                    var AllSheetResult = new Result();
                                    var AllSheetResultL = new Result();
                                    var OutPutSheetResult = new Result();
                                    var GetReqNumberResult = new Result();
                                    var GetSelectedResult = new Result();
                                    var TestCaseResult = new Result();
                                    var WriteExlResult = new Result();
                                    var Result_ScreenShot = new Result();
                                    var Result_Browser = new Result();
                                    var Result_BrowserApp = new Result();
                                    var Result_BrowserSup = new Result();

                                    //TestCaseResult = objCommonMethods.Update_Table_Data_Database("Update ST_AL_Alert set ForceStatus=0");
                                    MainSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, KeyWords.strMainSheetName, strMainSql);
                                    if (MainSheetResult.ErrorMessage.Contains(Messages.FileAlreadyUsed))
                                    {
                                        Thread.Sleep(5000);
                                        MainSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, KeyWords.strMainSheetName, strMainSql);
                                        if (MainSheetResult.ErrorMessage.Contains(Messages.FileAlreadyUsed))
                                        {
                                            Thread.Sleep(10000);
                                            MainSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, KeyWords.strMainSheetName, strMainSql);
                                            if (MainSheetResult.ErrorMessage.Contains(Messages.FileAlreadyUsed))
                                            {
                                            }
                                        }
                                    }
                                    // parent = extent.StartTest(drowMaster[0].ToString()+" Test Scenario execution for Client : "+ drowMaster[2].ToString());
                                    ReportHandler._ParentTest = extent.StartTest(drowMaster[0].ToString() + " Test Scenario execution for Client : " + drowMaster[2].ToString());
                                    //if (ReportHandler._IsLabelReportRequired)
                                    ReportHandler._LblParent = LabelReport.StartTest("Label Verification within Automation Flow for Client : " + drowMaster[2].ToString());

                                    //var child= extent.StartTest;
                                    if (MainSheetResult.Result1 == "Pass")
                                    {

                                        int CaseNumber = 0;
                                        foreach (DataRow drowMain in MainSheetResult.dt.Rows)
                                        {
                                            string strClientLogin = "";
                                            CaseNumber = CaseNumber + 1;  // Every time we increase the case number value 
                                            int ScriptExecutionStatus = 0;
                                            int ScriptPreviousRowNo = 0;
                                            int ScriptOldStatus = 0;
                                            if (CaseNumber != MainSheetResult.dt.Rows.Count)  // it is useful to print status as zero once we reached last row 
                                            {
                                                int CurrentRow = CaseNumber - 1;  // case number starts with 1 but selected data sheet (through query) starts with zero
                                                ScriptExecutionStatus = Int32.Parse(MainSheetResult.dt.Rows[CurrentRow][0].ToString());// Get test case number from Main sheet. If script do not come to this block the value is zero
                                            }

                                            if ((drowMain[3].ToString().ToUpper() == "YES") && (drowMain[0].ToString() != null) && (drowMain[2].ToString().Trim() != "") && (Convert.ToInt32(drowMain[1]) > 0))
                                            {
                                                // Reading the All  sheet selected Testcase ID
                                                //Adding new code for supplier new design
                                                KeyWords.LoginUser_Role = drowMain[2].ToString();

                                              //  KeyWords.str_App_Url = drowMaster[4].ToString();
                                              //  KeyWords.str_App_Url2 = drowMaster[5].ToString();
                                                string strSubSheetName = drowMain[2].ToString() + "$";
                                                string strSubSql = "";
                                                string strSubSqlL = "";
                                                string strAllorClient = drowMain[2].ToString();
                                                //string UserRole = drowMain[5].ToString();
                                                if (strAllorClient.Trim().ToLower() == "all")
                                                {
                                                    strSubSql = "SELECT * FROM [" + strSubSheetName + "] WHERE TestCaseId= '" + drowMain[0].ToString() + "' and TestScenario = '" + drowMaster[0].ToString() + "'";
                                                    //      strSubSqlL = "SELECT * FROM [" + strSubSheetName + "] WHERE TestCaseId= '" + drowMain[0].ToString() + "L" + "' and TestScenario = '" + drowMaster[0].ToString() + "'";
                                                    /// strSubSqlL = "SELECT * FROM [" + strSubSheetName + "] WHERE TestCaseId= '" + drowMain[0].ToString() + "L" + "'";
                                                }
                                                else
                                                {
                                                    strSubSql = "SELECT * FROM [" + strSubSheetName + "] WHERE TestCaseId= '" + drowMain[0].ToString() + "' and P3 = '" + drowMaster[2].ToString() + "' and TestScenario = '" + drowMaster[0].ToString() + "'";
                                                    //    strSubSqlL = "SELECT * FROM [" + strSubSheetName + "] WHERE TestCaseId= '" + drowMain[0].ToString() + "L" + "' and P3 = '" + drowMaster[2].ToString() + "' and TestScenario = '" + drowMaster[0].ToString() + "'";
                                                    //    strSubSqlL = "SELECT * FROM [" + strSubSheetName + "] WHERE TestCaseId= '" + drowMain[0].ToString() + "L" + "' and P3 = '" + drowMain[5].ToString() + "'";
                                                }

                                                AllSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strSubSheetName, strSubSql);
                                                //  AllSheetResultL = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strSubSheetName, strSubSqlL);
                                                if (AllSheetResult.ErrorMessage.Contains(Messages.FileAlreadyUsed))
                                                {
                                                    Thread.Sleep(5000);
                                                    AllSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strSubSheetName, strSubSql);
                                                    //   AllSheetResultL = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strSubSheetName, strSubSqlL);
                                                    if (AllSheetResult.ErrorMessage.Contains(Messages.FileAlreadyUsed))
                                                    {
                                                        Thread.Sleep(10000);
                                                        AllSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strSubSheetName, strSubSql);
                                                        //       AllSheetResultL = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strSubSheetName, strSubSqlL);
                                                        if (AllSheetResult.ErrorMessage.Contains(Messages.FileAlreadyUsed))
                                                        {
                                                        }
                                                    }
                                                }
                                                string[] strDataArray = new string[5];
                                                string[] strColArray = new string[5];
                                                string[] strDataArrayL = new string[5];
                                                string[] strColArrayL = new string[5];
                                                if (AllSheetResult.dt.Rows.Count > 0)
                                                {
                                                    strDataArray = new string[AllSheetResult.dt.Rows[0].ItemArray.Length];
                                                    strColArray = new string[AllSheetResult.dt.Rows[0].ItemArray.Length];
                                                }
                                                //if (AllSheetResultL.dt.Rows.Count > 0)
                                                //{
                                                //    strDataArrayL = new string[AllSheetResultL.dt.Rows[0].ItemArray.Length];
                                                //    strColArrayL = new string[AllSheetResultL.dt.Rows[0].ItemArray.Length];
                                                //}
                                                // Get script old execution status  
                                                //int OldRowNumber = CaseNumber - 1;
                                                ScriptOldStatus = Int32.Parse(AllSheetResult.dt.Rows[0]["TestExecute"].ToString());// Get script old status from data sheet like MSP, supplier and Approver
                                                if (CaseNumber != 1)// Initial value for casenumber is 1 , if value is 1 we do not minus 2 from it. This time it is first case and scriptpreviousRowNo is zero
                                                {
                                                    int CurrentRow = CaseNumber - 2;// We need previous value thats why we decres minus 2 from value because it's starts with zero
                                                    ScriptPreviousRowNo = Int32.Parse(MainSheetResult.dt.Rows[CurrentRow][0].ToString());// Get the previousrowno value from mainsheet
                                                }

                                                // Number of counts repated in Main sheet
                                                for (int iLoop = 1; iLoop <= Convert.ToInt32(drowMain[1]); iLoop++)
                                                {
                                                    string strLoginUser = string.Empty;
                                                    string strLoginUser1 = string.Empty;
                                                    if (AllSheetResult.dt.Rows.Count > 0)
                                                    {
                                                        //
                                                        for (int iSubRowLoop = 0; iSubRowLoop < AllSheetResult.dt.Rows.Count; iSubRowLoop++)
                                                        {
                                                            if (iSubRowLoop == 0)
                                                            {

                                                                if (Result_BrowserApp.Result1 == KeyWords.Result_PASS)
                                                                {
                                                                    driverApp = Result_BrowserApp.driver;
                                                                }
                                                            }

                                                            int ExeStatus = 0;
                                                            string ExecutionStatus = AllSheetResult.dt.Rows[iSubRowLoop]["TestExecute"].ToString();
                                                            if (ExecutionStatus == "")
                                                            {
                                                                ExeStatus = 0;
                                                            }
                                                            else
                                                            {
                                                                ExeStatus = Convert.ToInt32(ExecutionStatus);
                                                            }

                                                            if (AllSheetResult.dt.Rows[iSubRowLoop][0].ToString() != Constants.TestCase002)
                                                            {
                                                                Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
                                                                string strEmail = "";

                                                                strEmail = strDataArray[AllSheetResult.dt.Columns.IndexOf("P1")];
                                                                //string strTermsConditions = "update st_lm_user set tcflag = 1 where username like '" + strEmail + "'";


                                                                // objCommonMethods.Update_Table_Data_Database(strTermsConditions);

                                                                //  objCommonMethods.Validate_Password_Update(strEmail, strDataArray[AllSheetResult.dt.Columns.IndexOf("P2")]);

                                                                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "Login Time " + stopwatch.Elapsed.Seconds, 3);

                                                                if (TestCaseResult.Result1 == KeyWords.Result_FAIL)
                                                                {
                                                                    break;
                                                                }
                                                            }


                                                            switch (drowMain[0].ToString())
                                                            {
                                                                case Constants.TestCase001:

                                                                    if (ScriptOldStatus == ScriptPreviousRowNo)
                                                                    {

                                                                        ReportHandler._ChildTest = extent.StartTest("001 : Requisition Creation");
                                                                        //  if (ReportHandler._IsLabelReportRequired) ;
                                                                        ReportHandler._LblChild = LabelReport.StartTest("Create Requirement");
                                                                        if (MSPexecutionNo == 0)
                                                                        {
                                                                            strClientLogin = AllSheetResult.dt.Rows[0]["P1"].ToString();
                                                                            driver = ChooseBrowser1(driver, drowMainMaster["BrowserMSP"].ToString());
                                                                            TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driver, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());
                                                                        }

                                                                        //TestCaseResult = objCreate_Requirement.Create_Requirement(driver, AllSheetResult.dt.Rows[iSubRowLoop], AllSheetResult.dt.Rows[iSubRowLoop]);
                                                                        Thread.Sleep(1000);
                                                                        if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                                        {
                                                                            ReportHandler._getChildTest().Log(LogStatus.Pass, "Requisition Created successfully : " + KeyWords.str_link_REQ_NUMBER);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            //  if (ReportHandler._IsLabelReportRequired)
                                                                            ReportHandler._getLblParentTest().AppendChild(ReportHandler._getLblChildTest());
                                                                            //extent.EndTest(parent);
                                                                            objCommonMethods.UpdateCandidateName(KeyWords.str_Name_Txt_LastName_FirstName, AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString(), AllSheetResult.dt.Rows[iSubRowLoop]["TestScenario"].ToString());
                                                                            objCommonMethods.UpdateRequirementNumber(KeyWords.str_link_REQ_NUMBER, AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString(), AllSheetResult.dt.Rows[iSubRowLoop]["TestScenario"].ToString());
                                                                            objCommonMethods.UpdateScriptStatus(ScriptExecutionStatus, AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString(), AllSheetResult.dt.Rows[iSubRowLoop]["TestScenario"].ToString());
                                                                            MSPexecutionNo = 1;
                                                                        }
                                                                        else
                                                                        {
                                                                            ScenarioStatus = false;
                                                                            ReportHandler._getChildTest().Log(LogStatus.Fail, TestCaseResult.ErrorMessage);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            //   if (ReportHandler._IsLabelReportRequired)
                                                                            ReportHandler._getLblParentTest().AppendChild(ReportHandler._getLblChildTest());
                                                                            //extent.EndTest(parent);
                                                                        }
                                                                        //     GetResult();
                                                                    }
                                                                    break;

                                                                case Constants.TestCase002:

                                                                    if (ScriptOldStatus == ScriptPreviousRowNo)
                                                                    {
                                                                        ReportHandler._ChildTest = extent.StartTest("002 : Approve the reqirement");
                                                                        if (strClientLogin != AllSheetResult.dt.Rows[0]["P1"].ToString())
                                                                        {
                                                                            //  MSPexecutionNo = 0;
                                                                            kwm.Logout_Link_Click(driver);
                                                                            Thread.Sleep(5000);
                                                                            TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driver, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());

                                                                        }
                                                                        if (MSPexecutionNo == 0)
                                                                        {
                                                                            driver = ChooseBrowser1(driver, drowMainMaster["BrowserMSP"].ToString());
                                                                            TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driver, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());
                                                                        }

                                                                        string strREQNumber = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                                        if (KeyWords.str_link_REQ_NUMBER == "")
                                                                        {
                                                                            KeyWords.str_link_REQ_NUMBER = strREQNumber;
                                                                        }
                                                                        if (strREQNumber != "")
                                                                        {
                                                                            TestCaseResult = objApprove.Approve_Method(driver, AllSheetResult.dt.Rows[iSubRowLoop]);

                                                                            if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                                            {
                                                                                ReportHandler._getChildTest().Log(LogStatus.Pass, "Requisition is approved successfully : " + KeyWords.str_link_REQ_NUMBER);
                                                                                ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());


                                                                                //extent.EndTest(parent);
                                                                                objCommonMethods.UpdateScriptStatus(ScriptExecutionStatus, AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString(), AllSheetResult.dt.Rows[iSubRowLoop]["TestScenario"].ToString());
                                                                                MSPexecutionNo = 1;
                                                                            }
                                                                            else
                                                                            {
                                                                                ScenarioStatus = false;
                                                                                ReportHandler._getChildTest().Log(LogStatus.Fail, TestCaseResult.ErrorMessage);
                                                                                ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());

                                                                                // extent.EndTest(parent);
                                                                            }
                                                                        }

                                                                        // GetResult();
                                                                    }
                                                                    break;

                                                                case Constants.TestCase003:
                                                                    if (ScriptOldStatus == ScriptPreviousRowNo)
                                                                    {
                                                                        ReportHandler._ChildTest = extent.StartTest("003 : Broadcast the Requisition");
                                                                        if (MSPexecutionNo == 0)
                                                                        {
                                                                            driver = ChooseBrowser1(driver, drowMainMaster["BrowserMSP"].ToString());
                                                                            TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driver, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());
                                                                        }
                                                                        TestCaseResult = objCreate_Broadcast.Broadcast_Method(driver, AllSheetResult.dt.Rows[iSubRowLoop], MSPexecutionNo);
                                                                        Thread.Sleep(2000);
                                                                        if (KeyWords.str_link_REQ_NUMBER == "")
                                                                        {
                                                                            KeyWords.str_link_REQ_NUMBER = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                                        }
                                                                        if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                                        {
                                                                            String strUpdateSqlMain2 = "Update [Supplier$] set P1 ='" + TestCaseResult.listData[0] + "'  WHERE P3 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "' and TestScenario ='" + AllSheetResult.dt.Rows[iSubRowLoop]["TestScenario"].ToString() + "'";
                                                                            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain2);

                                                                            ReportHandler._getChildTest().Log(LogStatus.Pass, "Broadcast the Requisition successfully :" + KeyWords.str_link_REQ_NUMBER);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            //extent.EndTest(parent);
                                                                            objCommonMethods.UpdateScriptStatus(ScriptExecutionStatus, AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString(), AllSheetResult.dt.Rows[iSubRowLoop]["TestScenario"].ToString());
                                                                            MSPexecutionNo = 1;
                                                                        }
                                                                        else
                                                                        {
                                                                            ScenarioStatus = false;
                                                                            ReportHandler._getChildTest().Log(LogStatus.Fail, TestCaseResult.ErrorMessage);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            // extent.EndTest(parent);
                                                                        }
                                                                        //  GetResult();
                                                                    }

                                                                    break;

                                                                case Constants.TestCase004:
                                                                    if (ScriptOldStatus == ScriptPreviousRowNo)
                                                                    {
                                                                        ReportHandler._ChildTest = extent.StartTest("004 : Submit Candidate");
                                                                        if (SupexecutionNo == 0)
                                                                        {
                                                                            driverSup = ChooseBrowser1(driverSup, drowMainMaster["BrowserSUP"].ToString());
                                                                            TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driverSup, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());
                                                                        }
                                                                        TestCaseResult = objCreate_SubmitCandidate.SubmitCandidate_Method(driverSup, AllSheetResult.dt.Rows[iSubRowLoop], child, AllSheetResult.dt.Rows[iSubRowLoop]["TestScenario"].ToString());
                                                                        if (KeyWords.str_link_REQ_NUMBER == "")
                                                                        {
                                                                            KeyWords.str_link_REQ_NUMBER = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                                        }
                                                                        if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                                        {
                                                                            SupexecutionNo = 1;
                                                                            ReportHandler._getChildTest().Log(LogStatus.Pass, "Submit Candidate successfully :" + KeyWords.str_link_REQ_NUMBER);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            // extent.EndTest(parent);
                                                                            objCommonMethods.UpdateScriptStatus(ScriptExecutionStatus, AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString(), AllSheetResult.dt.Rows[iSubRowLoop]["TestScenario"].ToString());
                                                                        }
                                                                        else
                                                                        {
                                                                            ScenarioStatus = false;
                                                                            ReportHandler._getChildTest().Log(LogStatus.Fail, TestCaseResult.ErrorMessage);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            // extent.EndTest(parent);
                                                                        }
                                                                    }
                                                                    break;

                                                                case Constants.TestCase005:
                                                                    if (ScriptOldStatus == ScriptPreviousRowNo)
                                                                    {
                                                                        ReportHandler._ChildTest = extent.StartTest("005 : Submit to Manager");
                                                                        if (MSPexecutionNo == 0)
                                                                        {
                                                                            driver = ChooseBrowser1(driver, drowMainMaster["BrowserMSP"].ToString());
                                                                            TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driver, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());
                                                                        }
                                                                        TestCaseResult = objCreate_SubmitToManager.SubmitToManager_Method(driver, AllSheetResult.dt.Rows[iSubRowLoop], MSPexecutionNo);
                                                                        if (KeyWords.str_link_REQ_NUMBER == "")
                                                                        {
                                                                            KeyWords.str_link_REQ_NUMBER = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                                        }
                                                                        if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                                        {
                                                                            ReportHandler._getChildTest().Log(LogStatus.Pass, "Submited to Manager successfully : " + KeyWords.str_link_REQ_NUMBER);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            // extent.EndTest(parent);

                                                                            objCommonMethods.UpdateScriptStatus(ScriptExecutionStatus, AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString(), AllSheetResult.dt.Rows[iSubRowLoop]["TestScenario"].ToString());
                                                                            MSPexecutionNo = 1;
                                                                        }
                                                                        else
                                                                        {
                                                                            ScenarioStatus = false;
                                                                            ReportHandler._getChildTest().Log(LogStatus.Fail, TestCaseResult.ErrorMessage);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            //  extent.EndTest(parent);
                                                                        }
                                                                    }
                                                                    break;

                                                                case Constants.TestCase006:
                                                                    if (ScriptOldStatus == ScriptPreviousRowNo)
                                                                    {
                                                                        ReportHandler._ChildTest = extent.StartTest("006 : Request Interview");
                                                                        if (MSPexecutionNo == 0)
                                                                        {
                                                                            driver = ChooseBrowser1(driver, drowMainMaster["BrowserMSP"].ToString());
                                                                            TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driver, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());
                                                                        }
                                                                        TestCaseResult = objerequestinter.Req_Interview(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
                                                                        if (KeyWords.str_link_REQ_NUMBER == "")
                                                                        {
                                                                            KeyWords.str_link_REQ_NUMBER = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                                        }
                                                                        if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                                        {
                                                                            ReportHandler._getChildTest().Log(LogStatus.Pass, "Requested Interview Successfully : " + KeyWords.str_link_REQ_NUMBER);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            // extent.EndTest(parent);

                                                                            objCommonMethods.UpdateScriptStatus(ScriptExecutionStatus, AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString(), AllSheetResult.dt.Rows[iSubRowLoop]["TestScenario"].ToString());
                                                                            MSPexecutionNo = 1;
                                                                        }
                                                                        else
                                                                        {
                                                                            ScenarioStatus = false;
                                                                            ReportHandler._getChildTest().Log(LogStatus.Fail, TestCaseResult.ErrorMessage);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            //  extent.EndTest(parent);
                                                                        }
                                                                    }
                                                                    break;
                                                                case Constants.TestCase047:
                                                                    if (ScriptOldStatus == ScriptPreviousRowNo)
                                                                    {
                                                                        ReportHandler._ChildTest = extent.StartTest("047 : Schedule Interview");
                                                                        if (SupexecutionNo == 0)
                                                                        {
                                                                            driverSup = ChooseBrowser1(driverSup, drowMainMaster["BrowserSUP"].ToString());
                                                                            TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driverSup, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());
                                                                        }
                                                                        TestCaseResult = schduleinterview.Sche_Interview(driverSup, AllSheetResult.dt.Rows[iSubRowLoop]);
                                                                        if (KeyWords.str_link_REQ_NUMBER == "")
                                                                        {
                                                                            KeyWords.str_link_REQ_NUMBER = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                                        }
                                                                        if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                                        {
                                                                            SupexecutionNo = 1;
                                                                            ReportHandler._getChildTest().Log(LogStatus.Pass, "Interview Scheduled successfully : " + KeyWords.str_link_REQ_NUMBER);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            // extent.EndTest(parent);
                                                                            objCommonMethods.UpdateScriptStatus(ScriptExecutionStatus, AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString(), AllSheetResult.dt.Rows[iSubRowLoop]["TestScenario"].ToString());
                                                                        }
                                                                        else
                                                                        {
                                                                            ScenarioStatus = false;
                                                                            ReportHandler._getChildTest().Log(LogStatus.Fail, TestCaseResult.ErrorMessage);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            // extent.EndTest(parent);
                                                                        }
                                                                    }
                                                                    break;

                                                                case Constants.TestCase048:
                                                                    if (ScriptOldStatus == ScriptPreviousRowNo)
                                                                    {
                                                                        ReportHandler._ChildTest = extent.StartTest("048 : Confirm Interview");
                                                                        if (MSPexecutionNo == 0)
                                                                        {
                                                                            driver = ChooseBrowser1(driver, drowMainMaster["BrowserMSP"].ToString());
                                                                            TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driver, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());
                                                                        }
                                                                        TestCaseResult = confirminterview.Confirm_Int(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
                                                                        if (KeyWords.str_link_REQ_NUMBER == "")
                                                                        {
                                                                            KeyWords.str_link_REQ_NUMBER = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                                        }
                                                                        if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                                        {
                                                                            ReportHandler._getChildTest().Log(LogStatus.Pass, "Interview Confirmed Successfully : " + KeyWords.str_link_REQ_NUMBER);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            // extent.EndTest(parent);

                                                                            objCommonMethods.UpdateScriptStatus(ScriptExecutionStatus, AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString(), AllSheetResult.dt.Rows[iSubRowLoop]["TestScenario"].ToString());
                                                                            MSPexecutionNo = 1;
                                                                        }
                                                                        else
                                                                        {
                                                                            ScenarioStatus = false;
                                                                            ReportHandler._getChildTest().Log(LogStatus.Fail, TestCaseResult.ErrorMessage);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            // extent.EndTest(parent);
                                                                        }
                                                                    }
                                                                    break;

                                                                case Constants.TestCase007:
                                                                    if (ScriptOldStatus == ScriptPreviousRowNo)
                                                                    {
                                                                        ReportHandler._ChildTest = extent.StartTest("007 : Offer to Hire");
                                                                        if (MSPexecutionNo == 0)
                                                                        {
                                                                            driver = ChooseBrowser1(driver, drowMainMaster["BrowserMSP"].ToString());
                                                                            TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driver, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());
                                                                        }
                                                                        TestCaseResult = objOTH_EO.OfferToHire_Method_Full(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
                                                                        if (KeyWords.str_link_REQ_NUMBER == "")
                                                                        {
                                                                            KeyWords.str_link_REQ_NUMBER = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                                        }
                                                                        if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                                        {
                                                                            ReportHandler._getChildTest().Log(LogStatus.Pass, "Offer to Hire completed Successfully : " + KeyWords.str_link_REQ_NUMBER);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            //  extent.EndTest(parent);

                                                                            objCommonMethods.UpdateScriptStatus(ScriptExecutionStatus, AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString(), AllSheetResult.dt.Rows[iSubRowLoop]["TestScenario"].ToString());
                                                                            MSPexecutionNo = 1;
                                                                        }
                                                                        else
                                                                        {
                                                                            ScenarioStatus = false;
                                                                            ReportHandler._getChildTest().Log(LogStatus.Fail, TestCaseResult.ErrorMessage);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            //  extent.EndTest(parent);
                                                                        }
                                                                    }
                                                                    break;
                                                                case Constants.TestCase051:
                                                                    if (ScriptOldStatus == ScriptPreviousRowNo)
                                                                    {
                                                                        ReportHandler._ChildTest = extent.StartTest("051 : Extend Offer");
                                                                        if (MSPexecutionNo == 0)
                                                                        {
                                                                            driver = ChooseBrowser1(driver, drowMainMaster["BrowserMSP"].ToString());
                                                                            TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driver, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());
                                                                        }
                                                                        if (MSPexecutionNo == 0)
                                                                        {
                                                                            TestCaseResult = objOTH_EO.ExtendOffer_Method_Full(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
                                                                        }
                                                                        else
                                                                        {
                                                                            TestCaseResult = objOTH_EO.ExtendOffer_Method(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
                                                                        }

                                                                        if (KeyWords.str_link_REQ_NUMBER == "")
                                                                        {
                                                                            KeyWords.str_link_REQ_NUMBER = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                                        }
                                                                        if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                                        {
                                                                            ReportHandler._getChildTest().Log(LogStatus.Pass, "Extend Offer completed Successfully : " + KeyWords.str_link_REQ_NUMBER);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            //  extent.EndTest(parent);

                                                                            objCommonMethods.UpdateScriptStatus(ScriptExecutionStatus, AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString(), AllSheetResult.dt.Rows[iSubRowLoop]["TestScenario"].ToString());
                                                                            MSPexecutionNo = 1;
                                                                        }
                                                                        else
                                                                        {
                                                                            ScenarioStatus = false;
                                                                            ReportHandler._getChildTest().Log(LogStatus.Fail, TestCaseResult.ErrorMessage);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            //  extent.EndTest(parent);
                                                                        }
                                                                    }
                                                                    break;

                                                                case Constants.TestCase052:
                                                                    if (ScriptOldStatus == ScriptPreviousRowNo)
                                                                    {
                                                                        ReportHandler._ChildTest = extent.StartTest("052 : Identify Extend Offer");
                                                                        if (MSPexecutionNo == 0)
                                                                        {
                                                                            driver = ChooseBrowser1(driver, drowMainMaster["BrowserMSP"].ToString());
                                                                            TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driver, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());
                                                                        }

                                                                        TestCaseResult = objOTH_EO.Identify_ExtendOffer_Method(driver, AllSheetResult.dt.Rows[iSubRowLoop]);


                                                                        if (KeyWords.str_link_REQ_NUMBER == "")
                                                                        {
                                                                            KeyWords.str_link_REQ_NUMBER = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                                        }
                                                                        if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                                        {
                                                                            ReportHandler._getChildTest().Log(LogStatus.Pass, "Identify Extend Offer completed Successfully : " + KeyWords.str_link_REQ_NUMBER);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            //  extent.EndTest(parent);
                                                                            if (KeyWords.str_Email_Txt_Supplier != "")
                                                                            {
                                                                                objCommonMethods.UpdateSupplierEmail(KeyWords.str_Email_Txt_Supplier, AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString(), AllSheetResult.dt.Rows[iSubRowLoop]["TestScenario"].ToString());
                                                                            }
                                                                            objCommonMethods.UpdateScriptStatus(ScriptExecutionStatus, AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString(), AllSheetResult.dt.Rows[iSubRowLoop]["TestScenario"].ToString());
                                                                            MSPexecutionNo = 1;
                                                                        }
                                                                        else
                                                                        {
                                                                            ScenarioStatus = false;
                                                                            ReportHandler._getChildTest().Log(LogStatus.Fail, TestCaseResult.ErrorMessage);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            //  extent.EndTest(parent);
                                                                        }
                                                                    }
                                                                    break;
                                                                case Constants.TestCase008:
                                                                    if (ScriptOldStatus == ScriptPreviousRowNo)
                                                                    {
                                                                        ReportHandler._ChildTest = extent.StartTest("008 : Accept Offer");
                                                                        if (SupexecutionNo == 0)
                                                                        {
                                                                            driverSup = ChooseBrowser1(driverSup, drowMainMaster["BrowserSUP"].ToString());
                                                                            TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driverSup, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());
                                                                        }
                                                                        TestCaseResult = accepectoffer.AcceptOffer_Method(driverSup, AllSheetResult.dt.Rows[iSubRowLoop]);
                                                                        if (KeyWords.str_link_REQ_NUMBER == "")
                                                                        {
                                                                            KeyWords.str_link_REQ_NUMBER = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                                        }
                                                                        if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                                        {
                                                                            SupexecutionNo = 1;
                                                                            ReportHandler._getChildTest().Log(LogStatus.Pass, "Accept Offer completed successfully : " + KeyWords.str_link_REQ_NUMBER);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            //  extent.EndTest(parent);
                                                                            objCommonMethods.UpdateScriptStatus(ScriptExecutionStatus, AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString(), AllSheetResult.dt.Rows[iSubRowLoop]["TestScenario"].ToString());
                                                                        }
                                                                        else
                                                                        {
                                                                            ScenarioStatus = false;
                                                                            ReportHandler._getChildTest().Log(LogStatus.Fail, TestCaseResult.ErrorMessage);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            //   extent.EndTest(parent);
                                                                        }
                                                                    }
                                                                    break;
                                                                case Constants.TestCase053:
                                                                    if (ScriptOldStatus == ScriptPreviousRowNo)
                                                                    {
                                                                        ReportHandler._ChildTest = extent.StartTest("053 : Identify Accept Offer");
                                                                        if (SupexecutionNo == 0)
                                                                        {
                                                                            driverSup = ChooseBrowser1(driverSup, drowMainMaster["BrowserSUP"].ToString());
                                                                            TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driverSup, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());
                                                                        }
                                                                        TestCaseResult = accepectoffer.Identify_AcceptOffer_Method(driverSup, AllSheetResult.dt.Rows[iSubRowLoop]);
                                                                        if (KeyWords.str_link_REQ_NUMBER == "")
                                                                        {
                                                                            KeyWords.str_link_REQ_NUMBER = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                                        }
                                                                        if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                                        {
                                                                            SupexecutionNo = 1;
                                                                            ReportHandler._getChildTest().Log(LogStatus.Pass, "Identify Accept Offer completed successfully : " + KeyWords.str_link_REQ_NUMBER);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            //  extent.EndTest(parent);
                                                                            objCommonMethods.UpdateScriptStatus(ScriptExecutionStatus, AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString(), AllSheetResult.dt.Rows[iSubRowLoop]["TestScenario"].ToString());
                                                                        }
                                                                        else
                                                                        {
                                                                            ScenarioStatus = false;
                                                                            ReportHandler._getChildTest().Log(LogStatus.Fail, TestCaseResult.ErrorMessage);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            //   extent.EndTest(parent);
                                                                        }
                                                                    }
                                                                    break;
                                                                case Constants.TestCase009:
                                                                    if (ScriptOldStatus == ScriptPreviousRowNo)
                                                                    {
                                                                        ReportHandler._ChildTest = extent.StartTest("009 : Issue Work Order");
                                                                        if (MSPexecutionNo == 0)
                                                                        {
                                                                            driver = ChooseBrowser1(driver, drowMainMaster["BrowserMSP"].ToString());
                                                                            TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driver, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());
                                                                        }
                                                                        TestCaseResult = objCreate_IssueWorkOrder.IssueWorkOrder_Method(driver, AllSheetResult.dt.Rows[iSubRowLoop], MSPexecutionNo);
                                                                        if (KeyWords.str_link_REQ_NUMBER == "")
                                                                        {
                                                                            KeyWords.str_link_REQ_NUMBER = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                                        }
                                                                        if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                                        {
                                                                            ReportHandler._getChildTest().Log(LogStatus.Pass, "Issue Work Order completed successfully : " + KeyWords.str_link_REQ_NUMBER);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            //   extent.EndTest(parent);

                                                                            objCommonMethods.UpdateScriptStatus(ScriptExecutionStatus, AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString(), AllSheetResult.dt.Rows[iSubRowLoop]["TestScenario"].ToString());
                                                                            MSPexecutionNo = 1;
                                                                        }
                                                                        else
                                                                        {
                                                                            ScenarioStatus = false;
                                                                            ReportHandler._getChildTest().Log(LogStatus.Fail, TestCaseResult.ErrorMessage);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            //   extent.EndTest(parent);
                                                                        }
                                                                    }
                                                                    break;

                                                                case Constants.TestCase010:
                                                                    if (ScriptOldStatus == ScriptPreviousRowNo)
                                                                    {
                                                                        ReportHandler._ChildTest = extent.StartTest("010 : Accept Work Order");
                                                                        if (SupexecutionNo == 0)
                                                                        {
                                                                            driverSup = ChooseBrowser1(driverSup, drowMainMaster["BrowserSUP"].ToString());
                                                                            TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driverSup, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());
                                                                        }
                                                                        TestCaseResult = objCreate_AcceptWorkOrder.AcceptWorkOrder_Method(driverSup, AllSheetResult.dt.Rows[iSubRowLoop], SupexecutionNo);
                                                                        if (KeyWords.str_link_REQ_NUMBER == "")
                                                                        {
                                                                            KeyWords.str_link_REQ_NUMBER = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                                        }
                                                                        if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                                        {
                                                                            ReportHandler._getChildTest().Log(LogStatus.Pass, "Accept Work Order completed successfully : " + KeyWords.str_link_REQ_NUMBER);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            //   extent.EndTest(parent);

                                                                            objCommonMethods.UpdateScriptStatus(ScriptExecutionStatus, AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString(), AllSheetResult.dt.Rows[iSubRowLoop]["TestScenario"].ToString());
                                                                            SupexecutionNo = 1;
                                                                        }
                                                                        else
                                                                        {
                                                                            ScenarioStatus = false;
                                                                            ReportHandler._getChildTest().Log(LogStatus.Fail, TestCaseResult.ErrorMessage);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            //     extent.EndTest(parent);
                                                                        }
                                                                    }
                                                                    break;
                                                                case Constants.TestCase054:
                                                                    if (ScriptOldStatus == ScriptPreviousRowNo)
                                                                    {
                                                                        ReportHandler._ChildTest = extent.StartTest("010 : Identify Accept Work Order");
                                                                        if (SupexecutionNo == 0)
                                                                        {
                                                                            driverSup = ChooseBrowser1(driverSup, drowMainMaster["BrowserSUP"].ToString());
                                                                            TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driverSup, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());
                                                                        }
                                                                        TestCaseResult = objCreate_AcceptWorkOrder.Identify_AcceptWorkOrder_Method(driverSup, AllSheetResult.dt.Rows[iSubRowLoop], SupexecutionNo);
                                                                        if (KeyWords.str_link_REQ_NUMBER == "")
                                                                        {
                                                                            KeyWords.str_link_REQ_NUMBER = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                                        }
                                                                        if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                                        {
                                                                            ReportHandler._getChildTest().Log(LogStatus.Pass, "Identify Accept Work Order completed successfully : " + KeyWords.str_link_REQ_NUMBER);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            //   extent.EndTest(parent);

                                                                            objCommonMethods.UpdateScriptStatus(ScriptExecutionStatus, AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString(), AllSheetResult.dt.Rows[iSubRowLoop]["TestScenario"].ToString());
                                                                            SupexecutionNo = 1;
                                                                        }
                                                                        else
                                                                        {
                                                                            ScenarioStatus = false;
                                                                            ReportHandler._getChildTest().Log(LogStatus.Fail, TestCaseResult.ErrorMessage);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            //     extent.EndTest(parent);
                                                                        }
                                                                    }
                                                                    break;
                                                                case Constants.TestCase011:
                                                                    if (ScriptOldStatus == ScriptPreviousRowNo)
                                                                    {
                                                                        ReportHandler._ChildTest = extent.StartTest("011 : Onboarding");
                                                                        if (MSPexecutionNo == 0)
                                                                        {
                                                                            driver = ChooseBrowser1(driver, drowMainMaster["BrowserMSP"].ToString());
                                                                            TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driver, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());
                                                                        }
                                                                        TestCaseResult = objCreate_Onboarding.Onboarding_Method(driver, AllSheetResult.dt.Rows[iSubRowLoop], MSPexecutionNo);
                                                                        if (KeyWords.str_link_REQ_NUMBER == "")
                                                                        {
                                                                            KeyWords.str_link_REQ_NUMBER = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                                        }
                                                                        if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                                        {
                                                                            ReportHandler._getChildTest().Log(LogStatus.Pass, "Onboarding successfully : " + KeyWords.str_link_REQ_NUMBER);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            //   extent.EndTest(parent);

                                                                            objCommonMethods.UpdateScriptStatus(ScriptExecutionStatus, AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString(), AllSheetResult.dt.Rows[iSubRowLoop]["TestScenario"].ToString());
                                                                            MSPexecutionNo = 1;
                                                                        }
                                                                        else
                                                                        {
                                                                            ScenarioStatus = false;
                                                                            ReportHandler._getChildTest().Log(LogStatus.Fail, TestCaseResult.ErrorMessage);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            //     extent.EndTest(parent);
                                                                        }
                                                                    }
                                                                    break;




                                                                case Constants.TestCase012:
                                                                    if (ScriptOldStatus == ScriptPreviousRowNo)
                                                                    {
                                                                        ReportHandler._ChildTest = extent.StartTest("012 : Confirm CW");
                                                                        if (MSPexecutionNo == 0)
                                                                        {
                                                                            driver = ChooseBrowser1(driver, drowMainMaster["BrowserMSP"].ToString());
                                                                            TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driver, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());
                                                                        }
                                                                        TestCaseResult = objCreate_ConfirmCW.ConfirmCW_Method(driver, AllSheetResult.dt.Rows[iSubRowLoop], MSPexecutionNo);
                                                                        if (KeyWords.str_link_REQ_NUMBER == "")
                                                                        {
                                                                            KeyWords.str_link_REQ_NUMBER = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                                        }
                                                                        if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                                        {
                                                                            ReportHandler._getChildTest().Log(LogStatus.Pass, "Confirm CW successfully : " + KeyWords.str_link_REQ_NUMBER);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            //   extent.EndTest(parent);

                                                                            objCommonMethods.UpdateScriptStatus(ScriptExecutionStatus, AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString(), AllSheetResult.dt.Rows[iSubRowLoop]["TestScenario"].ToString());
                                                                            MSPexecutionNo = 1;
                                                                        }
                                                                        else
                                                                        {
                                                                            ScenarioStatus = false;
                                                                            ReportHandler._getChildTest().Log(LogStatus.Fail, TestCaseResult.ErrorMessage);
                                                                            ReportHandler._ParentTest.AppendChild(ReportHandler._getChildTest());
                                                                            //     extent.EndTest(parent);
                                                                        }
                                                                    }
                                                                    break;
                                                            }
                                                        }

                                                        // kwm.Logout_Link_Click_NewUI(driver, "Logout");
                                                        // kwm.Logout_Link_Click(driver, "Logout");

                                                    }
                                                    else
                                                    {
                                                    }
                                                    //if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                    //{
                                                    //    ReportHandler._ParentTest.Log(LogStatus.Pass, "Test Scenario : "+drowMainMaster[0].ToString() +"-- Test Case : " +drowMain[0].ToString()+" Completed Successfully : " + KeyWords.str_link_REQ_NUMBER);

                                                    //}
                                                    //else
                                                    //{
                                                    //    ReportHandler._ParentTest.Log(LogStatus.Fail, TestCaseResult.ErrorMessage);
                                                    //    //extent.EndTest(Master);
                                                    //}
                                                }
                                            }
                                        }
                                        extent.EndTest(ReportHandler._ParentTest);
                                        // if (ReportHandler._IsLabelReportRequired)
                                        LabelReport.EndTest(ReportHandler._getLblParentTest());
                                        //
                                        try
                                        {
                                            kwm.Logout_Link_Click(driver);
                                            kwm.Logout_Link_Click(driverSup);
                                            driver.Close();
                                            driverSup.Close();
                                        }
                                        catch
                                        {

                                        }
                                    }
                                    else
                                    {
                                        // Console.WriteLine(MainSheetResult.ErrorMessage);
                                        objCommonMethods.WriteLogFileTestCaseHeaders(KeyWords.strLogfilePath, MainSheetResult.ErrorMessage, 1, "yes");
                                        objCommonMethods.WriteLogFileTestCaseHeaders(KeyWords.strLogfilePath, MainSheetResult.ErrorMessage, 2, "no");
                                    }
                                    objCommonMethods.WriteLogFileEndHeader(KeyWords.strLogfilePath);
                                }

                            }
                        }//end


                    }// If end
                    else
                    {
                        //Input sheet path is empty
                    }
                }
            }
        

        }

       // [SetUp]
        public void TestExecutor()
        {
            try
            {
                Console.WriteLine("From Setup Executor");

            }catch(Exception e)
            {

            }
        }
        //[Test]
        public void test1()
        {
            Console.WriteLine("test1");
        }
       // [Test]
        public void test2()
        {
            Console.WriteLine("test2");
        }
        //[TearDown]
        //public void GetResult()
        //{
        //    var status = TestContext.CurrentContext.Result.Status;
        //    var stackTrace = "<pre>" + TestContext.CurrentContext.Result.State + "</pre>";
        //    var errorMessage = TestContext.CurrentContext.Result.ToString();

        //    if (status == NUnit.Framework.TestStatus.Failed)
        //    {
        //        ReportHandler._ParentTest.Log(LogStatus.Fail, stackTrace + errorMessage);
        //    }
        //    extent.EndTest(ReportHandler._ParentTest);

        //    LabelReport.EndTest(ReportHandler._getLblParentTest());
        //}


       // [TearDown]
        public void EndReport()
        {
            extent.Flush();
            extent.Close();

            LabelReport.Flush();
            LabelReport.Close();



        }

        

        public IWebDriver ChooseBrowser1(IWebDriver driver, string Browser)
        {
            var Result_Browser = new Result();
            //var Result_BrowserApp = new Result();
            //var Result_BrowserSup = new Result();
            KeyWordMethods kwm = new KeyWordMethods();

            Result_Browser = kwm.Choose_Browser(driver, Browser);

            if (Result_Browser.Result1 == KeyWords.Result_PASS)
            {
                driver = Result_Browser.driver;
            }
            return driver;
        }



        
    }
}