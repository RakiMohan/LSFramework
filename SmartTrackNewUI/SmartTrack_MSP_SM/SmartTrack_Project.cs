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
using System.IO;
using CommonFiles;

namespace SmartTrack_Automation
{
    [TestFixture]
    public class SmartTrack
    {
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
        public void TestStart()
        {
            ReadExcel ReadExcelHelper = new ReadExcel();
            //Create methods objects
            CommonMethods objCommonMethods = new CommonMethods();

            //Approve objCreate_Approve = new Approve();
            SubmitToManager objCreate_SubmitToManager = new SubmitToManager();
            KeyWordMethods kwm = new KeyWordMethods();

            objCommonMethods.TestCase_Result_OutPutExcel();

            string strMainSheetName = "Main$";
            string strMainSql = "SELECT  TestCaseId,NumberOfRepeats,DataSheet,Include,Url,Client,UserName,Interview,Browser FROM [" + strMainSheetName + "] where UserName = 'MSP_SM' and Run = 'Yes' and Include = 'Yes'";
            objCommonMethods.WriteLogFileBeginHeader(KeyWords.strLogfilePath);
            var MainSheetResult = new Result();
            var AllSheetResult = new Result();
            var GetReqNumberResult = new Result();
            var TestCaseResult = new Result();
            var WriteExlResult = new Result();
            var Result_ScreenShot = new Result();
            var GetSelectedResult = new Result();
            var UpdateSelectedResult = new Result();
            var Result_Browser = new Result();

            Thread.Sleep(1);

            objCommonMethods.Update_Table_Data_Database("Update ST_AL_Alert set ForceStatus=0");

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
                        // string[,] strColDataArray = new string[95, 95];
                        DataTable dtExlAllSheet = new DataTable();
                        string strSubSheetName = drowMain[2].ToString() + "$";
                        string strSubSql = "";
                        //string strSubSql = "SELECT * FROM [" + strSubSheetName + "] WHERE TestCaseId= '" + drowMain[0].ToString() + "'";
                        //string strSubSql = "SELECT * FROM [" + strSubSheetName + "] WHERE TestCaseId= '" + drowMain[0].ToString() + "' and P5 = '" + drowMain[6].ToString() + "'";
                        string strAllorClient = drowMain[5].ToString();
                        if (strAllorClient.Trim().ToLower() == "all")
                        {
                            strSubSql = "SELECT * FROM [" + strSubSheetName + "] WHERE TestCaseId= '" + drowMain[0].ToString() + "'";
                        }
                        else
                        {
                            strSubSql = "SELECT top 1 * FROM [" + strSubSheetName + "] WHERE TestCaseId= '" + drowMain[0].ToString() + "' and TestExecute = 'yes' and P3 = '" + drowMain[5].ToString() + "'";
                        }

                        AllSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strSubSheetName, strSubSql);
                        if (AllSheetResult.ErrorMessage.Contains(stralreadyUsingexcel))
                        {
                            Thread.Sleep(5000);
                            AllSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strSubSheetName, strSubSql);
                            if (AllSheetResult.ErrorMessage.Contains(stralreadyUsingexcel))
                            {
                                Thread.Sleep(10000);
                                AllSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strSubSheetName, strSubSql);
                                if (AllSheetResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                {
                                }
                            }
                        }
                        string[] strDataArray = new string[5];
                        string[] strColArray = new string[5];
                        if (AllSheetResult.dt.Rows.Count > 0)
                        {
                            strDataArray = new string[AllSheetResult.dt.Rows[0].ItemArray.Length];
                            strColArray = new string[AllSheetResult.dt.Rows[0].ItemArray.Length];
                        }
                        // Number of counts repated in Main sheet
                        for (int iLoop = 1; iLoop <= Convert.ToInt32(drowMain[1]); iLoop++)
                        {
                            string strLoginUser = string.Empty;
                            string strLoginUser1 = string.Empty;
                            if (AllSheetResult.dt.Rows.Count > 0)
                            {
                                string strUpdateSqlMain = "Update [Main$] set Run = 'P'  WHERE TestCaseId= '005' and Client ='" + drowMain[5].ToString() + "'";
                                WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);
                                if (WriteExlResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                {
                                    Thread.Sleep(5000);
                                    WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);
                                    if (WriteExlResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                    {
                                        Thread.Sleep(10000);
                                        WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);
                                        if (WriteExlResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                        {
                                        }
                                    }
                                }
                                //Number of testcases for each Testcase ID
                                for (int iSubRowLoop = 0; iSubRowLoop < AllSheetResult.dt.Rows.Count; iSubRowLoop++)
                                {
                                    if (iSubRowLoop == 0)
                                    {
                                        //Added new browser code
                                        KeyWords.str_Browser_Execute = drowMain[8].ToString();
                                        Result_Browser = kwm.Choose_Browser(driver, drowMain[8].ToString().ToLower());
                                        if (Result_Browser.Result1 == KeyWords.Result_PASS)
                                        {
                                            driver = Result_Browser.driver;
                                        }
                                        //if (AllSheetResult.dt.Rows[iSubRowLoop]["P1"].ToString().ToLower() == Constants.Chrome)
                                        //{
                                        //    driver = Constants.CreateChromeDriver(driver);

                                        //}
                                        //else if (AllSheetResult.dt.Rows[iSubRowLoop]["P1"].ToString().ToLower() == Constants.IE)
                                        //{
                                        //    driver = new InternetExplorerDriver(@System.IO.Directory.GetCurrentDirectory());
                                        //    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(120));
                                        //}
                                        //else
                                        //{
                                        //    //driver = new RemoteWebDriver(DesiredCapabilities.HtmlUnit());
                                        //    driver = new FirefoxDriver();
                                        //    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(120));
                                        //}
                                    }
                                    for (int c = 0; c < AllSheetResult.dt.Rows[iSubRowLoop].ItemArray.Length; c++)
                                    {
                                        if (AllSheetResult.dt.Columns[c].ColumnName.ToString() != "")
                                        {
                                            strColArray[c] = AllSheetResult.dt.Columns[c].ColumnName.ToString();
                                            strDataArray[c] = AllSheetResult.dt.Rows[iSubRowLoop][c].ToString();
                                        }
                                    }

                                    if (AllSheetResult.dt.Rows[iSubRowLoop][0].ToString() != Constants.TestCase002)
                                    {
                                        Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
                                        string strEmail = "";

                                        strEmail = strDataArray[AllSheetResult.dt.Columns.IndexOf("P1")];
                                        string strTermsConditions = "update st_lm_user set tcflag = 1 where username like '" + strEmail + "'";
                                        objCommonMethods.Update_Table_Data_Database(strTermsConditions);
                                        objCommonMethods.Validate_Password_Update(strEmail, strDataArray[AllSheetResult.dt.Columns.IndexOf("P2")]);

                                        string strUpdateSql = "Update [MSP$] set TestExecute = 'P' WHERE TestCaseId= '005' and P6 = '" + AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString() + "' and P3 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                        WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSql);
                                        if (WriteExlResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                        {
                                            Thread.Sleep(5000);
                                            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSql);
                                            if (WriteExlResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                            {
                                                Thread.Sleep(10000);
                                                WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSql);
                                                if (WriteExlResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                {
                                                }
                                            }
                                        }

                                       // TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driver, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());
                                        stopwatch.Stop();
                                        //intWasteTime = intWasteTime + stopwatch.Elapsed.Seconds;
                                        Console.WriteLine("Login Time " + stopwatch.Elapsed.Seconds);

                                        objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "Login Time " + stopwatch.Elapsed.Seconds, 3);

                                        if (TestCaseResult.Result1 == KeyWords.Result_FAIL)
                                        {
                                            break;
                                        }
                                    }
                                    switch (AllSheetResult.dt.Rows[iSubRowLoop][0].ToString())
                                    {
                                        case Constants.TestCase005:
                                            {
                                                string strREQNumber = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                string strClientSubmitUserName = AllSheetResult.dt.Rows[iSubRowLoop]["P8"].ToString();

                                                if (strREQNumber != "")
                                                {
                                                    if (AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString().ToLower() != Constants.Ryder)
                                                    {
                                                        if (AllSheetResult.dt.Rows[iSubRowLoop]["TestExecute"].ToString().ToLower() == "yes")
                                                        {
                                                            //TestCaseResult = objCreate_SubmitToManager.SubmitToManager_Method(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
                                                            // TestCaseResult.Result1 = KeyWords.Result_PASS;
                                                            if (TestCaseResult.Result1 == KeyWords.Result_FAIL)
                                                            {
                                                                if (TestCaseResult.ErrorMessage == "The given Link menu name Submit to Manager not found")
                                                                {
                                                                    TestCaseResult = kwm.list_Menu_Name_Exist(driver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, AllSheetResult.dt.Rows[iSubRowLoop]["P17"].ToString().Trim(), "");
                                                                }
                                                            }

                                                            if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                            {
                                                                if (AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString().ToLower() == Constants.APS)
                                                                {
                                                                   // TestCaseResult = objCreate_SubmitToManager.ExtendOffer_Method(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
                                                                    if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                                    {
                                                                        string[] strDataArray1 = new string[5];
                                                                        string[] strColArray1 = new string[5];
                                                                        string strSubSql12 = "SELECT * FROM [all$] WHERE TestCaseId= '009' and P3 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
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
                                                                                else if (GetSelectedResult.dt.Columns[c].ColumnName.ToString() == "P8")
                                                                                {
                                                                                    strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                                                    strDataArray1[c] = strClientSubmitUserName;
                                                                                }
                                                                                else
                                                                                {
                                                                                    strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                                                    strDataArray1[c] = GetSelectedResult.dt.Rows[0][c].ToString();
                                                                                }
                                                                            }
                                                                            UpdateSelectedResult = ReadExcelHelper.WriteDataToExcelFileSelected(KeyWords.strExlInputPath, "MSP", strColArray1, strDataArray1);
                                                                        }
                                                                        strUpdateSqlMain = "Update [Main$] set Run = 'Yes'  WHERE TestCaseId= '009' and Client ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                                        ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);

                                                                        string strUpdateSql = "Update [Supplier$] set TestExecute = 'Yes'  WHERE TestCaseId= '009' and TestExecute = 'new' and P6 = '" + strREQNumber + "' and P3 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                                        ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSql);

                                                                        kwm.Logout_Link_Click_NewUI(driver, "Logout");
                                                                        string strExecutepath = @System.IO.Directory.GetCurrentDirectory();
                                                                        if (KeyWords.strNunitConsolePath == "")
                                                                        {
                                                                            KeyWords.strNunitConsolePath = Constants.NunitConsolePath;
                                                                            // KeyWords.strNunitConsolePath = "";
                                                                        }
                                                                        ProcessStartInfo start = new ProcessStartInfo();
                                                                        start.Arguments = strExecutepath + Constants.NunitSupplierIWOBinPath;
                                                                        start.FileName = KeyWords.strNunitConsolePath;
                                                                        Process.Start(start);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    // TestCaseResult = objCreate_SubmitToManager.OfferToHire_Method(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
                                                                    // if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                                    // {
                                                                    // TestCaseResult = objCreate_SubmitToManager.ExtendOffer_Method(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
                                                                    if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                                    {
                                                                        string strSubSql12;
                                                                        string[] strDataArray1 = new string[5];
                                                                        string[] strColArray1 = new string[5];
                                                                        //Submit manager condition is passed in excel 6th case will change into 'yes'
                                                                        string strUpdateSqlMainSheet = "Update [Main$] set Run = 'Yes'  WHERE TestCaseId= '006' and Client ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                                        ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMainSheet);
                                                                        string strMainSql1 = "SELECT  TestCaseId,NumberOfRepeats,DataSheet,Include,Url,Client,UserName,Interview FROM [" + strMainSheetName + "] where UserName = 'Interview_Process' and Run = 'Yes' and Include = 'Yes'";
                                                                        MainSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strMainSheetName, strMainSql1);
                                                                        //In exel Interview colum we should mention client or MSP, then only its working. if does not want interview process interview column field mention "empty"
                                                                        if (MainSheetResult.dt.Rows[0]["Interview"].ToString() == "Client" || MainSheetResult.dt.Rows[0]["Interview"].ToString() == "MSP")
                                                                        {
                                                                            strSubSql12 = "SELECT * FROM [all$] WHERE TestCaseId= '006' and P3 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
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
                                                                                    else if (GetSelectedResult.dt.Columns[c].ColumnName.ToString() == "P8")
                                                                                    {
                                                                                        strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                                                        strDataArray1[c] = strClientSubmitUserName;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                                                        strDataArray1[c] = GetSelectedResult.dt.Rows[0][c].ToString();
                                                                                    }
                                                                                }
                                                                                if (MainSheetResult.dt.Rows[0]["Interview"].ToString() == "Client")
                                                                                {
                                                                                    GetSelectedResult = ReadExcelHelper.WriteDataToExcelFileSelected(KeyWords.strExlInputPath, "Approve", strColArray1, strDataArray1);
                                                                                }
                                                                                else
                                                                                {
                                                                                    GetSelectedResult = ReadExcelHelper.WriteDataToExcelFileSelected(KeyWords.strExlInputPath, "MSP", strColArray1, strDataArray1);

                                                                                }
                                                                            }
                                                                            strUpdateSqlMain = "Update [Main$] set Run = 'Yes'  WHERE TestCaseId= '006' and Client ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                                            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);
                                                                            if (WriteExlResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                                            {
                                                                                Thread.Sleep(5000);
                                                                                WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);
                                                                                if (WriteExlResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                                                {
                                                                                    Thread.Sleep(10000);
                                                                                    WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);
                                                                                    if (WriteExlResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                                                    {
                                                                                    }
                                                                                }

                                                                            }
                                                                            kwm.Logout_Link_Click_NewUI(driver, "Logout");
                                                                            string strExecutepath = @System.IO.Directory.GetCurrentDirectory();
                                                                            if (KeyWords.strNunitConsolePath == "")
                                                                            {
                                                                                KeyWords.strNunitConsolePath = Constants.NunitConsolePath;
                                                                                // KeyWords.strNunitConsolePath = "";
                                                                            }
                                                                            ProcessStartInfo start = new ProcessStartInfo();
                                                                            start.Arguments = strExecutepath + Constants.NunitInterviewFlowBinPath;
                                                                            start.FileName = KeyWords.strNunitConsolePath;
                                                                            Process.Start(start);

                                                                        }
                                                                        else
                                                                        {
                                                                            string strUpdateSqlInterview = "Update [Main$] set include = 'n'  WHERE TestCaseId= '006'";
                                                                            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlInterview);
                                                                            Thread.Sleep(5000);
                                                                            string strUpdateSqlInterview1 = "Update [Main$] set Run = 'P'  WHERE TestCaseId= '006' and Client ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                                            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlInterview1);


                                                                            ///////////////////////////////////////

                                                                            string strUpdateSql1 = "Update [Main$] set Run = 'yes'  WHERE TestCaseId= '007' and Client ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                                            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSql1);


                                                                            strSubSql12 = "SELECT * FROM [all$] WHERE TestCaseId= '007' and P3 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                                            GetSelectedResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "All$", strSubSql12);

                                                                            Thread.Sleep(2000);
                                                                            string strUpdateSqlInterviewyes = "Update [Main$] set include = 'yes'  WHERE TestCaseId= '006'";
                                                                            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlInterviewyes);

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
                                                                                    else if (GetSelectedResult.dt.Columns[c].ColumnName.ToString() == "P8")
                                                                                    {
                                                                                        strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                                                        strDataArray1[c] = strClientSubmitUserName;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                                                        strDataArray1[c] = GetSelectedResult.dt.Rows[0][c].ToString();
                                                                                    }
                                                                                }

                                                                                GetSelectedResult = ReadExcelHelper.WriteDataToExcelFileSelected(KeyWords.strExlInputPath, "MSP", strColArray1, strDataArray1);


                                                                            }
                                                                            strUpdateSqlMain = "Update [MSP$] set TestExecute = 'oh'  WHERE TestCaseID = '007' AND P6 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString() + "' AND P3 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                                            // strUpdateSqlMain = "Update [MSP$] set TestExecute2 = 'Yes' , TestExecute3 = 'Yes' WHERE TestCaseID = '007' AND P3 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                                            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);
                                                                            if (WriteExlResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                                            {
                                                                                Thread.Sleep(5000);
                                                                                WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);
                                                                                if (WriteExlResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                                                {
                                                                                    Thread.Sleep(10000);
                                                                                    WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);
                                                                                    if (WriteExlResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                                                    {
                                                                                    }
                                                                                }
                                                                            }



                                                                            strUpdateSqlMain = "Update [Main$] set Run = 'Yes'  WHERE TestCaseID= '007' AND Client ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                                            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);
                                                                            if (WriteExlResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                                            {
                                                                                Thread.Sleep(5000);
                                                                                WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);
                                                                                if (WriteExlResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                                                {
                                                                                    Thread.Sleep(10000);
                                                                                    WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);
                                                                                    if (WriteExlResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                                                    {
                                                                                    }
                                                                                }
                                                                            }

                                                                            kwm.Logout_Link_Click_NewUI(driver, "Logout");
                                                                            string strExecutepath = @System.IO.Directory.GetCurrentDirectory();
                                                                            if (KeyWords.strNunitConsolePath == "")
                                                                            {
                                                                                KeyWords.strNunitConsolePath = Constants.NunitConsolePath;
                                                                                // KeyWords.strNunitConsolePath = "";
                                                                            }
                                                                            ProcessStartInfo start = new ProcessStartInfo();
                                                                            start.Arguments = strExecutepath + Constants.NunitMSPOHEOBinPath;
                                                                            start.FileName = KeyWords.strNunitConsolePath;
                                                                            Process.Start(start);
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            //                                                            }
                                                        }
                                                        //else if (AllSheetResult.dt.Rows[iSubRowLoop]["TestExecute2"].ToString().ToLower() == "yes")
                                                        //{
                                                        //    if ((AllSheetResult.dt.Rows[iSubRowLoop]["P5"].ToString().ToLower() == Constants.APS) || (AllSheetResult.dt.Rows[iSubRowLoop]["P5"].ToString().ToLower() == "fabco"))
                                                        //    {
                                                        //        TestCaseResult = objCreate_SubmitToManager.ExtendOffer_Method_Full(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
                                                        //        if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                        //        {
                                                        //            string[] strDataArray1 = new string[5];
                                                        //            string[] strColArray1 = new string[5];
                                                        //            string strSubSql12 = "SELECT * FROM [all$] WHERE TestCaseId= '009' and P5 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P5"].ToString() + "'";
                                                        //            GetSelectedResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "All$", strSubSql12);
                                                        //            if (GetSelectedResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                        //            {
                                                        //                Thread.Sleep(5000);
                                                        //                GetSelectedResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "All$", strSubSql12);
                                                        //                if (GetSelectedResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                        //                {
                                                        //                    Thread.Sleep(10000);
                                                        //                    GetSelectedResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "All$", strSubSql12);
                                                        //                    if (GetSelectedResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                        //                    {
                                                        //                    }
                                                        //                }
                                                        //            }
                                                        //            if (GetSelectedResult.dt.Rows.Count > 0)
                                                        //            {
                                                        //                if (GetSelectedResult.dt.Rows.Count > 0)
                                                        //                {
                                                        //                    strDataArray1 = new string[GetSelectedResult.dt.Rows[0].ItemArray.Length];
                                                        //                    strColArray1 = new string[GetSelectedResult.dt.Rows[0].ItemArray.Length];
                                                        //                }
                                                        //                for (int c = 0; c <= GetSelectedResult.dt.Rows[0].ItemArray.Length - 1; c++)
                                                        //                {
                                                        //                    if (GetSelectedResult.dt.Columns[c].ColumnName.ToString() == "P8")
                                                        //                    {
                                                        //                        strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                        //                        strDataArray1[c] = strREQNumber;
                                                        //                    }
                                                        //                    else if (GetSelectedResult.dt.Columns[c].ColumnName.ToString() == "P10")
                                                        //                    {
                                                        //                        strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                        //                        strDataArray1[c] = strClientSubmitUserName;
                                                        //                    }
                                                        //                    else
                                                        //                    {
                                                        //                        strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                        //                        strDataArray1[c] = GetSelectedResult.dt.Rows[0][c].ToString();
                                                        //                    }
                                                        //                }
                                                        //                UpdateSelectedResult = ReadExcelHelper.WriteDataToExcelFileSelected(KeyWords.strExlInputPath, "MSP", strColArray1, strDataArray1);
                                                        //            }
                                                        //            strUpdateSqlMain = "Update [Main$] set Run = 'Yes'  WHERE TestCaseId= '009' and Client ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P5"].ToString() + "'";
                                                        //            ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);

                                                        //            string strUpdateSql = "Update [Supplier$] set TestExecute = 'Yes'  WHERE TestCaseId= '012' and TestExecute = 'new' and P8 = '" + strREQNumber + "' and P5 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P5"].ToString() + "'";
                                                        //            ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSql);

                                                        //            kwm.Logout_Link_Click_NewUI(driver, "Logout");
                                                        //            string strExecutepath = @System.IO.Directory.GetCurrentDirectory();
                                                        //            if (KeyWords.strNunitConsolePath == "")
                                                        //            {
                                                        //                KeyWords.strNunitConsolePath = Constants.NunitConsolePath;
                                                        //                // KeyWords.strNunitConsolePath = "";
                                                        //            }
                                                        //            ProcessStartInfo start = new ProcessStartInfo();
                                                        //            start.Arguments = strExecutepath + Constants.NunitSupplierIWOBinPath;
                                                        //            start.FileName = KeyWords.strNunitConsolePath;
                                                        //            Process.Start(start);
                                                        //        }
                                                        //    }
                                                        //    else
                                                        //    {
                                                        //        TestCaseResult = objCreate_SubmitToManager.OfferToHire_Method_Full(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
                                                        //        if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                        //        {
                                                        //            TestCaseResult = objCreate_SubmitToManager.ExtendOffer_Method(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
                                                        //            if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                        //            {
                                                        //                string[] strDataArray1 = new string[5];
                                                        //                string[] strColArray1 = new string[5];
                                                        //                string strSubSql12 = "SELECT * FROM [all$] WHERE TestCaseId= '008' and P5 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P5"].ToString() + "'";
                                                        //                GetSelectedResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "All$", strSubSql12);
                                                        //                if (GetSelectedResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                        //                {
                                                        //                    Thread.Sleep(5000);
                                                        //                    GetSelectedResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "All$", strSubSql12);
                                                        //                    if (GetSelectedResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                        //                    {
                                                        //                        Thread.Sleep(10000);
                                                        //                        GetSelectedResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "All$", strSubSql12);
                                                        //                        if (GetSelectedResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                        //                        {
                                                        //                        }
                                                        //                    }
                                                        //                }
                                                        //                if (GetSelectedResult.dt.Rows.Count > 0)
                                                        //                {
                                                        //                    if (GetSelectedResult.dt.Rows.Count > 0)
                                                        //                    {
                                                        //                        strDataArray1 = new string[GetSelectedResult.dt.Rows[0].ItemArray.Length];
                                                        //                        strColArray1 = new string[GetSelectedResult.dt.Rows[0].ItemArray.Length];
                                                        //                    }
                                                        //                    for (int c = 0; c <= GetSelectedResult.dt.Rows[0].ItemArray.Length - 1; c++)
                                                        //                    {
                                                        //                        if (GetSelectedResult.dt.Columns[c].ColumnName.ToString() == "P8")
                                                        //                        {
                                                        //                            strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                        //                            strDataArray1[c] = strREQNumber;
                                                        //                        }
                                                        //                        else if (GetSelectedResult.dt.Columns[c].ColumnName.ToString() == "P10")
                                                        //                        {
                                                        //                            strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                        //                            strDataArray1[c] = strClientSubmitUserName;
                                                        //                        }
                                                        //                        else
                                                        //                        {
                                                        //                            strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                        //                            strDataArray1[c] = GetSelectedResult.dt.Rows[0][c].ToString();
                                                        //                        }
                                                        //                    }
                                                        //                    UpdateSelectedResult = ReadExcelHelper.WriteDataToExcelFileSelected(KeyWords.strExlInputPath, "Supplier", strColArray1, strDataArray1);
                                                        //                }
                                                        //                strUpdateSqlMain = "Update [Main$] set Run = 'Yes'  WHERE TestCaseId= '008' and Client ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P5"].ToString() + "'";
                                                        //                ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);

                                                        //                string strUpdateSql = "Update [Supplier$] set TestExecute = 'Yes'  WHERE TestCaseId= '008' and TestExecute = 'new' and P8 = '" + strREQNumber + "' and P5 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P5"].ToString() + "'";
                                                        //                ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSql);

                                                        //                kwm.Logout_Link_Click_NewUI(driver, "Logout");
                                                        //                string strExecutepath = @System.IO.Directory.GetCurrentDirectory();
                                                        //                if (KeyWords.strNunitConsolePath == "")
                                                        //                {
                                                        //                    KeyWords.strNunitConsolePath = Constants.NunitConsolePath;
                                                        //                    // KeyWords.strNunitConsolePath = "";
                                                        //                }
                                                        //                ProcessStartInfo start = new ProcessStartInfo();
                                                        //                start.Arguments = strExecutepath + Constants.NunitSupplierAOBinPath;
                                                        //                start.FileName = KeyWords.strNunitConsolePath;
                                                        //                Process.Start(start);
                                                        //            }
                                                        //        }
                                                        //    }
                                                        //}


                                                        //else if (AllSheetResult.dt.Rows[iSubRowLoop]["TestExecute3"].ToString().ToLower() == "yes")
                                                        //{
                                                        //    TestCaseResult = objCreate_SubmitToManager.ExtendOffer_Method_Full(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
                                                        //    if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                        //    {
                                                        //        string[] strDataArray1 = new string[5];
                                                        //        string[] strColArray1 = new string[5];
                                                        //        string strSubSql12 = "SELECT * FROM [all$] WHERE TestCaseId= '008' and P5 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P5"].ToString() + "'";
                                                        //        GetSelectedResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "All$", strSubSql12);
                                                        //        if (GetSelectedResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                        //        {
                                                        //            Thread.Sleep(5000);
                                                        //            GetSelectedResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "All$", strSubSql12);
                                                        //            if (GetSelectedResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                        //            {
                                                        //                Thread.Sleep(10000);
                                                        //                GetSelectedResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "All$", strSubSql12);
                                                        //                if (GetSelectedResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                        //                {
                                                        //                }
                                                        //            }
                                                        //        }
                                                        //        if (GetSelectedResult.dt.Rows.Count > 0)
                                                        //        {
                                                        //            if (GetSelectedResult.dt.Rows.Count > 0)
                                                        //            {
                                                        //                strDataArray1 = new string[GetSelectedResult.dt.Rows[0].ItemArray.Length];
                                                        //                strColArray1 = new string[GetSelectedResult.dt.Rows[0].ItemArray.Length];
                                                        //            }
                                                        //            for (int c = 0; c <= GetSelectedResult.dt.Rows[0].ItemArray.Length - 1; c++)
                                                        //            {
                                                        //                if (GetSelectedResult.dt.Columns[c].ColumnName.ToString() == "P8")
                                                        //                {
                                                        //                    strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                        //                    strDataArray1[c] = strREQNumber;
                                                        //                }
                                                        //                else if (GetSelectedResult.dt.Columns[c].ColumnName.ToString() == "P10")
                                                        //                {
                                                        //                    strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                        //                    strDataArray1[c] = strClientSubmitUserName;
                                                        //                }
                                                        //                else
                                                        //                {
                                                        //                    strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                        //                    strDataArray1[c] = GetSelectedResult.dt.Rows[0][c].ToString();
                                                        //                }
                                                        //            }
                                                        //            GetSelectedResult = ReadExcelHelper.WriteDataToExcelFileSelected(KeyWords.strExlInputPath, "Supplier", strColArray1, strDataArray1);
                                                        //        }
                                                        //        strUpdateSqlMain = "Update [Main$] set Run = 'Yes'  WHERE TestCaseId= '008' and Client ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P5"].ToString() + "'";
                                                        //        ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);

                                                        //        string strUpdateSql = "Update [Supplier$] set TestExecute = 'Yes'  WHERE TestCaseId= '008' and TestExecute = 'new' and P8 = '" + strREQNumber + "' and P5 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P5"].ToString() + "'";
                                                        //        ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSql);

                                                        //        kwm.Logout_Link_Click_NewUI(driver, "Logout");
                                                        //        string strExecutepath = @System.IO.Directory.GetCurrentDirectory();
                                                        //        if (KeyWords.strNunitConsolePath == "")
                                                        //        {
                                                        //            KeyWords.strNunitConsolePath = Constants.NunitConsolePath;
                                                        //            // KeyWords.strNunitConsolePath = "";
                                                        //        }
                                                        //        ProcessStartInfo start = new ProcessStartInfo();
                                                        //        start.Arguments = strExecutepath + Constants.NunitSupplierAOBinPath;
                                                        //        start.FileName = KeyWords.strNunitConsolePath;
                                                        //        Process.Start(start);
                                                        //    }
                                                        //}

                                                        TestCaseResult = objCommonMethods.TestCase_Result_Execution(driver, AllSheetResult, TestCaseResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString());
                                                        kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.No);
                                                        kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.cancel);
                                                        kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, "close");
                                                    }
                                                    //else
                                                    //{
                                                    //    if (AllSheetResult.dt.Rows[iSubRowLoop]["TestExecute"].ToString().ToLower() == "yes")
                                                    //    {
                                                    //        TestCaseResult = objCreate_SubmitToManager.OfferToHire_Method_Full(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
                                                    //        // TestCaseResult.Result1 = KeyWords.Result_PASS;
                                                    //        if (TestCaseResult.Result1 == KeyWords.Result_FAIL)
                                                    //        {
                                                    //            if (TestCaseResult.ErrorMessage == "The given Link menu name Submit to Manager not found")
                                                    //            {
                                                    //                TestCaseResult = kwm.list_Menu_Name_Exist(driver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, AllSheetResult.dt.Rows[iSubRowLoop]["P19"].ToString().Trim(), "");
                                                    //            }
                                                    //        }

                                                    //        if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                    //        {
                                                    //            string[] strDataArray1 = new string[5];
                                                    //            string[] strColArray1 = new string[5];
                                                    //            string strSubSql12 = "SELECT * FROM [all$] WHERE TestCaseId= '009' and P5 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P5"].ToString() + "'";
                                                    //            GetSelectedResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "All$", strSubSql12);
                                                    //            if (GetSelectedResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                    //            {
                                                    //                Thread.Sleep(5000);
                                                    //                GetSelectedResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "All$", strSubSql12);
                                                    //                if (GetSelectedResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                    //                {
                                                    //                    Thread.Sleep(10000);
                                                    //                    GetSelectedResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "All$", strSubSql12);
                                                    //                    if (GetSelectedResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                    //                    {
                                                    //                    }
                                                    //                }
                                                    //            }
                                                    //            if (GetSelectedResult.dt.Rows.Count > 0)
                                                    //            {
                                                    //                if (GetSelectedResult.dt.Rows.Count > 0)
                                                    //                {
                                                    //                    strDataArray1 = new string[GetSelectedResult.dt.Rows[0].ItemArray.Length];
                                                    //                    strColArray1 = new string[GetSelectedResult.dt.Rows[0].ItemArray.Length];
                                                    //                }
                                                    //                for (int c = 0; c <= GetSelectedResult.dt.Rows[0].ItemArray.Length - 1; c++)
                                                    //                {
                                                    //                    if (GetSelectedResult.dt.Columns[c].ColumnName.ToString() == "P8")
                                                    //                    {
                                                    //                        strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                    //                        strDataArray1[c] = strREQNumber;
                                                    //                    }
                                                    //                    else if (GetSelectedResult.dt.Columns[c].ColumnName.ToString() == "P10")
                                                    //                    {
                                                    //                        strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                    //                        strDataArray1[c] = strClientSubmitUserName;
                                                    //                    }
                                                    //                    else
                                                    //                    {
                                                    //                        strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                    //                        strDataArray1[c] = GetSelectedResult.dt.Rows[0][c].ToString();
                                                    //                    }
                                                    //                }
                                                    //                UpdateSelectedResult = ReadExcelHelper.WriteDataToExcelFileSelected(KeyWords.strExlInputPath, "MSP", strColArray1, strDataArray1);
                                                    //            }
                                                    //            strUpdateSqlMain = "Update [Main$] set Run = 'Yes'  WHERE TestCaseId= '009' and Client ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P5"].ToString() + "'";
                                                    //            ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);

                                                    //            string strUpdateSql = "Update [Supplier$] set TestExecute = 'Yes'  WHERE TestCaseId= '012' and TestExecute = 'new' and P8 = '" + strREQNumber + "' and P5 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P5"].ToString() + "'";
                                                    //            ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSql);

                                                    //            kwm.Logout_Link_Click_NewUI(driver, "Logout");
                                                    //            string strExecutepath = @System.IO.Directory.GetCurrentDirectory();
                                                    //            if (KeyWords.strNunitConsolePath == "")
                                                    //            {
                                                    //                KeyWords.strNunitConsolePath = Constants.NunitConsolePath;
                                                    //                // KeyWords.strNunitConsolePath = "";
                                                    //            }
                                                    //            ProcessStartInfo start = new ProcessStartInfo();
                                                    //            start.Arguments = strExecutepath + Constants.NunitSupplierIWOBinPath;
                                                    //            start.FileName = KeyWords.strNunitConsolePath;
                                                    //            Process.Start(start);
                                                    //        }
                                                    //    }
                                                    //    TestCaseResult = objCommonMethods.TestCase_Result_Execution(driver, AllSheetResult, TestCaseResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString());
                                                    //    kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.No);
                                                    //    kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.cancel);
                                                    //    kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, "close");
                                                    //}
                                                }
                                                else
                                                {
                                                    TestCaseResult.Result1 = KeyWords.Result_FAIL;
                                                    TestCaseResult.ErrorMessage = "Input REQ number is empty";
                                                    TestCaseResult = objCommonMethods.TestCase_Result_Execution(driver, AllSheetResult, TestCaseResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString());
                                                }
                                                break;
                                            }

                                        //Withdrw offer method

                                        case Constants.TestCase052:
                                            {
                                                string strEmail = "";
                                                strEmail = strDataArray[AllSheetResult.dt.Columns.IndexOf("P1")];
                                                //  string strUpdatePassword = "update ST_LM_user set password='EQoSwms3dik=',passwordChangeRequired=0,passwordRetriedCount=0,statusID=1 where userid=(Select userID from ST_LM_user where email like '" + strEmail + "')";
                                                //    objCommonMethods.Update_Table_Data_Database(strUpdatePassword);
                                                objCommonMethods.Validate_Password_Update(strEmail, strDataArray[AllSheetResult.dt.Columns.IndexOf("P2")]);
                                               // TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driver, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());

                                               // TestCaseResult = objCreate_SubmitToManager.WithDrwOffer(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
                                                if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                {
                                                    if (TestCaseResult.ErrorMessage1 != "")
                                                    {
                                                        //Requirement Number set in the input sheet
                                                        string strReq = TestCaseResult.ErrorMessage1;
                                                        //    string strUpdateSql = "Update [" + strSubSheetName + "] set P8 = '" + strReq + "' WHERE TestCaseId= '019' and P5 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P5"].ToString() + "'";

                                                        //    ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSql);
                                                        //    strUpdateSql = "Update [" + strSubSheetName + "] set P8 = '" + strReq + "' WHERE TestCaseId= '020' and P5 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P5"].ToString() + "'";

                                                        //    ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSql);
                                                    }
                                                }
                                                TestCaseResult = objCommonMethods.TestCase_Result_Execution(driver, AllSheetResult, TestCaseResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString());
                                                kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.OK);
                                                kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.No);
                                                kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.cancel);

                                                break;
                                            }
                                        default:
                                            {
                                                break;
                                            }
                                    }//Switch case End here
                                }//No of sub test cases for loop
                                driver.Close();
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