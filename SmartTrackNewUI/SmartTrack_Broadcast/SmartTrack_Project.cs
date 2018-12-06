// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SmartTrack.cs" company="DCR Workforce Inc">
//   Copyright (c) DCR Workforce Inc. All rights reserved.
//   This code and information should not be copied and used outside of DCR Workforce Inc.
// </copyright>
// <summary>
//   Defines the Registration Repository.
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
            /*string strLogfilePath = System.IO.Directory.GetCurrentDirectory() + "\\Input\\SmartTrack_logfile.txt";
            string strExlInputPath = System.IO.Directory.GetCurrentDirectory() + "\\Input\\SmartTrack_Input.xlsx";
            string strExlOutputPath = System.IO.Directory.GetCurrentDirectory() + "\\Input\\SmartTrack_Output.xlsx";*/
            // Console.WriteLine(System.IO.("../Input/SmartTrack_logfile.txt"));
            ReadExcel ReadExcelHelper = new ReadExcel();
            //Create methods objects
            CommonMethods objCommonMethods = new CommonMethods();

            //Approve objCreate_Approve = new Approve();
            Broadcast objCreate_Broadcast = new Broadcast();
            KeyWordMethods kwm = new KeyWordMethods();
            

            objCommonMethods.TestCase_Result_OutPutExcel();

            string strMainSheetName = "Main$";
            // string strMainSql = "SELECT TestCaseId,NumberOfRepeats,DataSheet,Include,Url,Client,UserName FROM [" + strMainSheetName + "] where UserName = 'MSP-BC'";
            string strMainSql = "SELECT TestCaseId,NumberOfRepeats,DataSheet,Include,Url,Client,UserName,Browser FROM [" + strMainSheetName + "] where UserName = 'MSP_BC' and Run = 'Yes' and Include = 'Yes'";
            objCommonMethods.WriteLogFileBeginHeader(KeyWords.strLogfilePath);
            var MainSheetResult = new Result();
            var MSPSheetResult = new Result();
            var GetReqNumberResult = new Result();
            var TestCaseResult = new Result();
            var WriteExlResult = new Result();
            var Result_ScreenShot = new Result();
            var GetSelectedResult = new Result();
            var Result_Browser = new Result();
            Thread.Sleep(1);

            //objCommonMethods.Update_Table_Data_Database("Update ST_AL_Alert set ForceStatus=0");

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
                        string strAllorClient = drowMain[5].ToString();
                        if (strAllorClient.Trim().ToLower() == "all")
                        {
                            strSubSql = "SELECT * FROM [" + strSubSheetName + "] WHERE TestCaseId= '" + drowMain[0].ToString() + "'";
                        }
                        else
                        {
                            strSubSql = "SELECT top 1 * FROM [" + strSubSheetName + "] WHERE TestCaseId= '" + drowMain[0].ToString() + "' and P3 = '" + drowMain[5].ToString() + "'and TestExecute = 'yes'";
                        }

                        MSPSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strSubSheetName, strSubSql);
                        if (MSPSheetResult.ErrorMessage.Contains(stralreadyUsingexcel))
                        {
                            Thread.Sleep(5000);
                            MSPSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strSubSheetName, strSubSql);
                            if (MSPSheetResult.ErrorMessage.Contains(stralreadyUsingexcel))
                            {
                                Thread.Sleep(10000);
                                MSPSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strSubSheetName, strSubSql);
                                if (MSPSheetResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                {
                                }
                            }
                        }
                        string[] strDataArray = new string[5];
                        string[] strColArray = new string[5];
                        if (MSPSheetResult.dt.Rows.Count > 0)
                        {
                            strDataArray = new string[MSPSheetResult.dt.Rows[0].ItemArray.Length];
                            strColArray = new string[MSPSheetResult.dt.Rows[0].ItemArray.Length];
                        }
                        // Number of counts repated in Main sheet
                        for (int iLoop = 1; iLoop <= Convert.ToInt32(drowMain[1]); iLoop++)
                        {
                           
                            string strLoginUser = string.Empty;
                            string strLoginUser1 = string.Empty;
                            if (MSPSheetResult.dt.Rows.Count > 0)
                            {
                                //Number of testcases for each Testcase ID
                                for (int iSubRowLoop = 0; iSubRowLoop < MSPSheetResult.dt.Rows.Count; iSubRowLoop++)
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
                                    for (int c = 0; c < MSPSheetResult.dt.Rows[iSubRowLoop].ItemArray.Length; c++)
                                    {
                                        if (MSPSheetResult.dt.Columns[c].ColumnName.ToString() != "")
                                        {
                                            strColArray[c] = MSPSheetResult.dt.Columns[c].ColumnName.ToString();
                                            strDataArray[c] = MSPSheetResult.dt.Rows[iSubRowLoop][c].ToString();
                                        }
                                    }

                                    if (MSPSheetResult.dt.Rows[iSubRowLoop][0].ToString() != Constants.TestCase002)
                                    {
                                        Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
                                        string strEmail = "";

                                        strEmail = strDataArray[MSPSheetResult.dt.Columns.IndexOf("P1")];
                                       
                                        //TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driver, MSPSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), MSPSheetResult.dt.Rows[iSubRowLoop][0].ToString());
                                        stopwatch.Stop();
                                        //intWasteTime = intWasteTime + stopwatch.Elapsed.Seconds;
                                        Console.WriteLine("Login Time " + stopwatch.Elapsed.Seconds);

                                        objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "Login Time " + stopwatch.Elapsed.Seconds, 3);

                                        if (TestCaseResult.Result1 == KeyWords.Result_FAIL)
                                        {
                                            break;
                                        }
                                    }
                                    switch (MSPSheetResult.dt.Rows[iSubRowLoop][0].ToString())
                                    {
                                        case Constants.TestCase003:
                                            {
                                                string strREQNumber = MSPSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                               
                                                if (strREQNumber != "")
                                                {
                                                   // TestCaseResult = objCreate_Broadcast.Broadcast_Method(driver, MSPSheetResult.dt.Rows[iSubRowLoop], test);    
                                                    
                                                    if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                    {
                                                        string strUpdateAllSheet = "Update [All$] set P1='"+TestCaseResult.listData[0].ToString()+"'  WHERE TestCaseId= '004' and P3 ='" + MSPSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                        WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateAllSheet);

                                                        string strUpdateMSPSheet = "Update [MSP$] set TestExecute='P'  WHERE TestCaseId= '003' and P3 ='" + MSPSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "' and P6='" + strREQNumber + "'";
                                                        WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateMSPSheet);

                                                        string[] strDataArray1 = new string[5];
                                                        string[] strColArray1 = new string[5];
                                                        string strSubSql12 = "SELECT * FROM [All$] WHERE TestCaseId= '004' and P3 ='" + MSPSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
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
                                                            GetSelectedResult = ReadExcelHelper.WriteDataToExcelFileSelected(KeyWords.strExlInputPath, "Supplier", strColArray1, strDataArray1);
                                                           
                                                        }
                                                        string strUpdateSqlMain = "Update [Main$] set Run = 'Yes'  WHERE TestCaseId= '004' and Client ='" + MSPSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
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

                                                        string strExecutepath = @System.IO.Directory.GetCurrentDirectory();
                                                        if (KeyWords.strNunitConsolePath == "")
                                                        {
                                                            KeyWords.strNunitConsolePath = Constants.NunitConsolePath;
                                                            // KeyWords.strNunitConsolePath = "";
                                                        }
                                                        ProcessStartInfo start = new ProcessStartInfo();
                                                        start.Arguments = strExecutepath + Constants.NunitSupplierBinPath;
                                                        start.FileName = KeyWords.strNunitConsolePath;
                                                        // start.UseShellExecute = false;
                                                        Thread.Sleep(5000);
                                                        Process.Start(start);                                                      
                                                    }
                                                    else
                                                    {
                                                        string strUpdateMSPSheet = "Update [MSP$] set TestExecute='F'  WHERE TestCaseId= '003' and P3 ='" + MSPSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "' and P6='" + strREQNumber + "'";
                                                        WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateMSPSheet);
                                                        
                                                    }
                                                    TestCaseResult = objCommonMethods.TestCase_Result_Execution(driver, MSPSheetResult, TestCaseResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString());
                                                }
                                                else
                                                {
                                                    TestCaseResult.Result1 = KeyWords.Result_FAIL;
                                                    TestCaseResult.ErrorMessage = "Input REQ number is empty";
                                                    TestCaseResult = objCommonMethods.TestCase_Result_Execution(driver, MSPSheetResult, TestCaseResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString());
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