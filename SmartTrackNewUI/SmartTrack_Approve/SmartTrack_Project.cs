// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SmartTrack_APP.cs" company="DCR Workforce Inc">
//   Copyright (c) DCR Workforce Inc. All rights reserved.
//   This code and information should not be copied and used outside of DCR Workforce Inc.
// </copyright>
// <summary>
//  This Constants is used
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace SmartTrack_Automation
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using System;
    using System.Data;
    using System.Diagnostics;
    using System.Threading;

    using CommonFiles;

    [TestFixture]

    //  [TestCase]

    public class SmartTrack_APP
    {
        //[TestFixtureSetUp]
        //public void setup()
        //{
        //   string[] args = Environment.GetCommandLineArgs();
        //   foreach (string arg in args)
        //   {
        //     // process my command line arguments
        //       if (arg.Contains("//"))
        //       {
        //           Console.WriteLine("arg[1]");
        //           Console.WriteLine(arg[1]);
        //       }
        //       // do something
        //   }
        //}
        public static IWebDriver driver;

        [SetUp]
        public void SetupTest()
        {
            //driver = new ChromeDriver();
            //driver = new FirefoxDriver();
        }

        [TearDown]
        public void TeardownTest()
        {
            // driver.Quit();
        }

        [Test]
        public void TestStart_APP()
        {
            ReadExcel ReadExcelHelper = new ReadExcel();
            //Create methods objects
            CommonMethods objCommonMethods = new CommonMethods();

            Approve objCreate_Approve = new Approve();

            KeyWordMethods kwm = new KeyWordMethods();

            objCommonMethods.TestCase_Result_OutPutExcel();
            string strMainSheetName = "Main$";
            string strMainSql = "SELECT TestCaseId,NumberOfRepeats,DataSheet,Include,Url,Client,UserName,Browser FROM [" + strMainSheetName + "] where UserName = 'Approver' and Run = 'Yes' and Include = 'Yes'";

            objCommonMethods.WriteLogFileBeginHeader(KeyWords.strLogfilePath);
            var MainSheetResult = new Result();
            var ApproveSheetResult = new Result();
            var GetReqNumberResult = new Result();
            var TestCaseResult = new Result();
            var WriteExlResult = new Result();
            var Result_ScreenShot = new Result();
            var GetSelectedResult = new Result();
            var Result_Browser = new Result();
            
            Thread.Sleep(1);

           // TestCaseResult = objCommonMethods.Update_Table_Data_Database("Update ST_AL_Alert set ForceStatus=0");

            MainSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strMainSheetName, strMainSql);
            string stralreadyUsingexcel = "The Microsoft Office Access database engine cannot open or write to the file";// ''. It is already opened exclusively by another user, or you need permission to view and write its data";
            if (MainSheetResult.ErrorMessage.Contains(stralreadyUsingexcel))
            {
                Thread.Sleep(5000);
                MainSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strMainSheetName, strMainSql);
                if (MainSheetResult.ErrorMessage.Contains(stralreadyUsingexcel))
                {
                    Thread.Sleep(10000);
                    MainSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strMainSheetName, strMainSql);
                    if (MainSheetResult.ErrorMessage.Contains(stralreadyUsingexcel))
                    {
                    }
                }
            }
            if (MainSheetResult.Result1 == "Pass")
            {
                foreach (DataRow drowMain in MainSheetResult.dt.Rows)
                {
                    // Testcase Id include "Yes" in input && Testcase Id is empty checking
                    if ((drowMain[3].ToString().ToUpper() == "YES") && (drowMain[0].ToString() != null) && (drowMain[2].ToString().Trim() != "") && (Convert.ToInt32(drowMain[1]) > 0))
                    {
                        // Reading the All  sheet selected Testcase ID
                        //Adding new code for supplier new design
                        KeyWords.LoginUser_Role = drowMain[2].ToString();

                        KeyWords.str_App_Url = drowMain[4].ToString();                       
                        DataTable dtExlAllSheet = new DataTable();
                        string strSubSheetName = drowMain[2].ToString() + "$";
                        string strSubSql = "";                       
                        string strAllorClient = drowMain[5].ToString();
                        if (strAllorClient.Trim().ToLower() == "all")
                        {
                            strSubSql = "SELECT * FROM [" + strSubSheetName + "] WHERE TestCaseId= '" + drowMain[0].ToString() + "'";
                        }
                        else
                        {
                            strSubSql = "SELECT top 1 * FROM [" + strSubSheetName + "] WHERE TestCaseId= '" + drowMain[0].ToString() + "' and P3 = '" + drowMain[5].ToString() + "'and TestExecute = 'yes'";
                        }

                        ApproveSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strSubSheetName, strSubSql);
                        if (ApproveSheetResult.ErrorMessage.Contains(stralreadyUsingexcel))
                        {
                            Thread.Sleep(5000);
                            ApproveSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strSubSheetName, strSubSql);
                            if (ApproveSheetResult.ErrorMessage.Contains(stralreadyUsingexcel))
                            {
                                Thread.Sleep(10000);
                                ApproveSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strSubSheetName, strSubSql);
                                if (ApproveSheetResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                {
                                }
                            }
                        }
                        string[] strDataArray = new string[5];
                        string[] strColArray = new string[5];
                        if (ApproveSheetResult.dt.Rows.Count > 0)
                        {
                            strDataArray = new string[ApproveSheetResult.dt.Rows[0].ItemArray.Length];
                            strColArray = new string[ApproveSheetResult.dt.Rows[0].ItemArray.Length];
                        }
                        // Number of counts repated in Main sheet
                        for (int iLoop = 1; iLoop <= Convert.ToInt32(drowMain[1]); iLoop++)
                        {
                            //string strUpdateSqlMain = "Update [Main$] set Run = 'P'  WHERE TestCaseId= '002' and Client ='" + drowMain[5].ToString() + "'";
                            //ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);
                            string strLoginUser = string.Empty;
                            string strLoginUser1 = string.Empty;
                            if (ApproveSheetResult.dt.Rows.Count > 0)
                            {
                                //Number of testcases for each Testcase ID
                                for (int iSubRowLoop = 0; iSubRowLoop < ApproveSheetResult.dt.Rows.Count; iSubRowLoop++)
                                {
                                    if (iSubRowLoop == 0)
                                    {
                                        //Added new browser code
                                        KeyWords.str_Browser_Execute = drowMain[7].ToString();
                                        Result_Browser = kwm.Choose_Browser(driver, drowMain[7].ToString().ToLower());
                                        if (Result_Browser.Result1 == KeyWords.Result_PASS)
                                        {
                                            driver = Result_Browser.driver;
                                        }

                                       
                                    }
                                    for (int c = 0; c < ApproveSheetResult.dt.Rows[iSubRowLoop].ItemArray.Length; c++)
                                    {
                                        if (ApproveSheetResult.dt.Columns[c].ColumnName.ToString() != "")
                                        {
                                            strColArray[c] = ApproveSheetResult.dt.Columns[c].ColumnName.ToString();
                                            strDataArray[c] = ApproveSheetResult.dt.Rows[iSubRowLoop][c].ToString();
                                        }
                                    }

                                    Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
                                    //TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driver, ApproveSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), ApproveSheetResult.dt.Rows[iSubRowLoop][0].ToString());

                                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "Login Time " + stopwatch.Elapsed.Seconds, 3);

                                    switch (ApproveSheetResult.dt.Rows[iSubRowLoop][0].ToString())
                                    {
                                        case Constants.TestCase002:
                                            {
                                                string strREQNumber = ApproveSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                Console.WriteLine(strREQNumber);
                                                if (strREQNumber != "")
                                                {
                                                 //   TestCaseResult = objCreate_Approve.Approve_Method(driver, ApproveSheetResult.dt.Rows[iSubRowLoop], test);
                                                    //TestCaseResult = objCommonMethods.Get_Table_Data_Database("select count(*) ApproveCout from ST_MS_WF_ReqWorkflow where requirementid= (select requirementid from ST_MS_Requirement where CLSRNumber='" + strREQNumber + "')", "ApproveCout");
                                                   
                                                    if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                    {
                                                        string strUpdateSql = "Update [approve$] set TestExecute = 'P'  WHERE TestCaseId= '002' and P6 = '" + strREQNumber + "' and P3 ='" + ApproveSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                        WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSql);
                                                        //Previous code is available at the bottom the file.
                                                    
                                                        string[] strDataArray1 = new string[5];
                                                        string[] strColArray1 = new string[5];
                                                        string strSubSql12 = "SELECT * FROM [all$] WHERE TestCaseId= '003' and P3 ='" + ApproveSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                        GetSelectedResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "All$", strSubSql12);
                                                        if (GetSelectedResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                        {
                                                            Thread.Sleep(5000);
                                                            GetSelectedResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "All$", strSubSql12);
                                                            if (GetSelectedResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                            {
                                                                Thread.Sleep(10000);
                                                                GetSelectedResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "All$", strSubSql12);
                                                                if (GetSelectedResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                                {
                                                                }
                                                            }
                                                        }
                                                        if (GetSelectedResult.dt.Rows.Count > 0)
                                                        {
                                                            if (GetSelectedResult.dt.Rows.Count > 0)
                                                            {
                                                                strDataArray1 = new string[GetSelectedResult.dt.Rows[0].ItemArray.Length];
                                                                strColArray1 = new string[GetSelectedResult.dt.Rows[0].ItemArray.Length];
                                                            }
                                                            for (int c = 0; c <= GetSelectedResult.dt.Rows[0].ItemArray.Length - 1; c++)
                                                            {
                                                                if (GetSelectedResult.dt.Columns[c].ColumnName.ToString() == "P6")
                                                                {
                                                                    strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                                    strDataArray1[c] = strREQNumber;
                                                                }
                                                                else
                                                                {
                                                                    strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                                    strDataArray1[c] = GetSelectedResult.dt.Rows[0][c].ToString();
                                                                }
                                                            }
                                                           Result UpdateSelectedResult = ReadExcelHelper.WriteDataToExcelFileSelected(KeyWords.strExlInputPath, "MSP", strColArray1, strDataArray1);
                                                        }
                                                        string strUpdateSqlMain = "Update [Main$] set Run = 'Yes'  WHERE TestCaseId= '003' and Client ='" + ApproveSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                        ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);

                                                        strUpdateSqlMain = "Update [MSP$] set TestExecute = 'Yes'  WHERE TestCaseId= '003' and P6 = '" + strREQNumber + "' and P3 ='" + ApproveSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                        ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);

                                                        kwm.Logout_Link_Click_NewUI(driver, "Logout");
                                                        string strExecutepath = @System.IO.Directory.GetCurrentDirectory();
                                                        if (KeyWords.strNunitConsolePath == "")
                                                        {
                                                            KeyWords.strNunitConsolePath = Constants.NunitConsolePath;
                                                        }
                                                        ProcessStartInfo start = new ProcessStartInfo();
                                                        start.Arguments = strExecutepath + Constants.NunitBroadCastBinPath;
                                                        start.FileName = KeyWords.strNunitConsolePath;
                                                        Process.Start(start);  


                                                    }
                                                    else
                                                    {
                                                        TestCaseResult.Result1 = KeyWords.Result_FAIL;
                                                        TestCaseResult.ErrorMessage = "Unable to connect to database or some other problem";
                                                        TestCaseResult = objCommonMethods.TestCase_Result_Execution(driver, ApproveSheetResult, TestCaseResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString());
                                                    }
                                                }
                                                else
                                                {
                                                    TestCaseResult.Result1 = KeyWords.Result_FAIL;
                                                    TestCaseResult.ErrorMessage = "Input REQ number is empty";
                                                    TestCaseResult = objCommonMethods.TestCase_Result_Execution(driver, ApproveSheetResult, TestCaseResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString());
                                                }
                                                break;
                                            }

                                        default:
                                            {
                                                break;
                                            }
                                    }//Switch case End here
                                }//No of sub test cases for loop
                                driver.Quit();
                            }
                            else
                            {
                                // Selected testcase id input data not avalibale
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine(MainSheetResult.ErrorMessage);
                objCommonMethods.WriteLogFileTestCaseHeaders(KeyWords.strLogfilePath, MainSheetResult.ErrorMessage, 1, "yes");
                objCommonMethods.WriteLogFileTestCaseHeaders(KeyWords.strLogfilePath, MainSheetResult.ErrorMessage, 2, "no");
            }
            objCommonMethods.WriteLogFileEndHeader(KeyWords.strLogfilePath);
        }
    }
}

