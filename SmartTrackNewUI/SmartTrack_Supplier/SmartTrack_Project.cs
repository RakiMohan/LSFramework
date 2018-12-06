// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SmartTrack.cs" company="DCR Workforce Inc">
//   Copyright (c) DCR Workforce Inc. All rights reserved.
//   This code and information should not be copied and used outside of DCR Workforce Inc.
// </copyright>
// <summary>
//   Defines the Registration Repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
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
            /*string strLogfilePath = System.IO.Directory.GetCurrentDirectory() + "\\Input\\SmartTrack_logfile.txt";
            string strExlInputPath = System.IO.Directory.GetCurrentDirectory() + "\\Input\\SmartTrack_Input.xlsx";
            string strExlOutputPath = System.IO.Directory.GetCurrentDirectory() + "\\Input\\SmartTrack_Output.xlsx";*/

            // Console.WriteLine(System.IO.("../Input/SmartTrack_logfile.txt"));
            ReadExcel ReadExcelHelper = new ReadExcel();
            //Create methods objects
            CommonMethods objCommonMethods = new CommonMethods();

            //Approve objCreate_Approve = new Approve();
            SubmitCandidate objCreate_SubmitCandidate = new SubmitCandidate();
            KeyWordMethods kwm = new KeyWordMethods();

            objCommonMethods.TestCase_Result_OutPutExcel();

            string strMainSheetName = "Main$";
            // string strMainSql = "SELECT TestCaseId,NumberOfRepeats,DataSheet,Include,Url,Client,UserName FROM [" + strMainSheetName + "] where UserName = 'Supplier'";
            string strMainSql = "SELECT TestCaseId,NumberOfRepeats,DataSheet,Include,Url,Client,UserName,NumOfCan,WhereToStart,Browser FROM [" + strMainSheetName + "] where UserName = 'Supplier' and Run = 'Yes' and Include = 'Yes'";
            objCommonMethods.WriteLogFileBeginHeader(KeyWords.strLogfilePath);
            var MainSheetResult = new Result();
            var AllSheetResult = new Result();
            var GetReqNumberResult = new Result();
            var TestCaseResult = new Result();
            var WriteExlResult = new Result();
            var Result_ScreenShot = new Result();
            var GetSelectedResult = new Result();
            var Result_Browser = new Result();
            //TestCaseResult = objCommonMethods.Get_Table_Data_Database("select a.approveremail from ST_MS_WF_ReqQueue a join ST_MS_WF_ReqWorkflow b on a.requirementid=b.requirementid and b.reqapproverid =a.reqsenttoapproverid where b.requirementid=21081 and b.clientid=21", "approveremail");
            //string iUserID = "";
            //if (TestCaseResult.listData.Count >= 1)
            //{
            //    iUserID = TestCaseResult.listData[0];
            //}
            Thread.Sleep(1);

           // objCommonMethods.Update_Table_Data_Database("Update ST_AL_Alert set ForceStatus=0");

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
                            string strUpdateSqlMain = "";
                          //string strUpdateSqlMain = "Update [Main$] set Run = 'P'  WHERE TestCaseId= '004' and Client ='" + drowMain[5].ToString() + "'";
                          //  ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);
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
                            string strLoginUser = string.Empty;
                            string strLoginUser1 = string.Empty;
                            if (AllSheetResult.dt.Rows.Count > 0)
                            {
                                //Number of testcases for each Testcase ID
                                for (int iSubRowLoop = 0; iSubRowLoop < AllSheetResult.dt.Rows.Count; iSubRowLoop++)
                                {
                                    if (iSubRowLoop == 0)
                                    {

                                        //Added new browser code

                                        KeyWords.str_Browser_Execute = drowMain[9].ToString();
                                        Result_Browser = kwm.Choose_Browser(driver, drowMain[9].ToString().ToLower());
                                        if (Result_Browser.Result1 == KeyWords.Result_PASS)
                                        {
                                            driver = Result_Browser.driver;
                                        }


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

                                        //strEmail = strDataArray[AllSheetResult.dt.Columns.IndexOf("P1")];
                                        //string strTermsConditions = "update st_lm_user set tcflag = 1 where username like '" + strEmail + "'";
                                        //objCommonMethods.Update_Table_Data_Database(strTermsConditions);

                                        //string strUpdatePassword = "update ST_LM_user set password='1000:oizAooy3v/3An1IToW/BUy58z5/WTScb:sx3jU4Aa+iSJ5N+zFwT6x5aV3gTr5ju4',passwordRetriedCount=0,statusID=1 where userid=(Select userID from ST_LM_user where email like '" + strEmail + "')";
                                        //objCommonMethods.Update_Table_Data_Database(strUpdatePassword);
                                       // objCommonMethods.Validate_Password_Update(strEmail, strDataArray[AllSheetResult.dt.Columns.IndexOf("P2")]);                
                                        // string strUpdatePassword = "update ST_LM_user set password='EQoSwms3dik=',passwordChangeRequired=0,passwordRetriedCount=0,statusID=1 where userid=(Select userID from ST_LM_user where email like '" + strEmail + "')";
                                        //   objCommonMethods.Update_Table_Data_Database(strUpdatePassword);
                                        // objCommonMethods.Validate_Password_Update(strEmail, strDataArray[AllSheetResult.dt.Columns.IndexOf("P4")]);
                                        string strUpdateSql = "";
                                    //    string strUpdateSql = "Update [Supplier$] set TestExecute = 'P'  WHERE TestCaseId= '004' and P6 = '" + AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString() + "' and P3 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                        // ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSql);
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
                                        //TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driver, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());
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
                                        case Constants.TestCase004:
                                            {
                                                int intNumRep = 0;
                                                int iWhereToStart = 1;
                                                try
                                                {
                                                    string st = drowMain[7].ToString();
                                                    intNumRep = Convert.ToInt32(drowMain[7].ToString());
                                                }
                                                catch
                                                {
                                                    intNumRep = 1;
                                                }
                                                try
                                                {
                                                    string wheretost = drowMain[8].ToString();
                                                    iWhereToStart = Convert.ToInt32(drowMain[8].ToString());
                                                }
                                                catch
                                                {
                                                    iWhereToStart = 1;
                                                }
                                                for (int iloopUser = 1; iloopUser <= intNumRep; iloopUser++)
                                                {
                                                    var results = new Result();
                                                    string strClientSubmitUserName = "";
                                                    string strClientSubmitUserNameLN = "";
                                                    string strClientSubmitUserNameFN = "";

                                                    int iWhereLoop = 0;
                                                    string strREQNumber = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                    // string[] separators = { "#" };
                                                    // string[] words = strREQNumber.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                                                    results = kwm.GetNameFromReqNumber("LN", strREQNumber);
                                                    if (results.Result1 == KeyWords.Result_PASS)
                                                    {
                                                        strClientSubmitUserNameLN = results.ErrorMessage;
                                                        AllSheetResult.dt.Rows[iSubRowLoop]["P9"] = strClientSubmitUserNameLN;
                                                    }
                                                    results = kwm.GetNameFromReqNumber("FN", strREQNumber);
                                                    if (results.Result1 == KeyWords.Result_PASS)
                                                    {
                                                        strClientSubmitUserNameFN = results.ErrorMessage;

                                                        AllSheetResult.dt.Rows[iSubRowLoop]["P10"] = strClientSubmitUserNameFN;
                                                    }

                                                    if (intNumRep == 1)
                                                    {
                                                        KeyWords.blnFlagLogout = true;
                                                    }
                                                    else
                                                    {
                                                        KeyWords.blnFlagLogout = false;
                                                    }
                                                    if (intNumRep == iloopUser)
                                                    {
                                                        KeyWords.blnFlagLogout = true;
                                                    }

                                                    if (iloopUser != 1)
                                                    {
                                                        if (iWhereToStart > 1)
                                                        {
                                                            iWhereLoop = iWhereToStart + iloopUser;

                                                            strClientSubmitUserNameLN = strClientSubmitUserNameLN + "_" + iWhereLoop.ToString();
                                                            strClientSubmitUserNameFN = strClientSubmitUserNameFN + "_" + iWhereLoop.ToString();
                                                        }
                                                        else
                                                        {
                                                            strClientSubmitUserNameLN = strClientSubmitUserNameLN + "_" + iloopUser.ToString();
                                                            strClientSubmitUserNameFN = strClientSubmitUserNameFN + "_" + iloopUser.ToString();
                                                        }
                                                        AllSheetResult.dt.Rows[iSubRowLoop]["P9"] = strClientSubmitUserNameLN;
                                                        AllSheetResult.dt.Rows[iSubRowLoop]["P10"] = strClientSubmitUserNameFN;
                                                    }
                                                    else
                                                    {
                                                        if (intNumRep >= 1)
                                                        {
                                                            if (iWhereToStart > 1)
                                                            {
                                                                iWhereLoop = iWhereToStart + iloopUser - 1;

                                                                strClientSubmitUserNameLN = strClientSubmitUserNameLN + "_" + iWhereLoop.ToString();
                                                                strClientSubmitUserNameFN = strClientSubmitUserNameFN + "_" + iWhereLoop.ToString();
                                                            }
                                                            else
                                                            {
                                                                strClientSubmitUserNameLN = strClientSubmitUserNameLN + "_" + iloopUser.ToString();
                                                                strClientSubmitUserNameFN = strClientSubmitUserNameFN + "_" + iloopUser.ToString();
                                                            }
                                                            AllSheetResult.dt.Rows[iSubRowLoop]["P9"] = strClientSubmitUserNameLN;
                                                            AllSheetResult.dt.Rows[iSubRowLoop]["P10"] = strClientSubmitUserNameFN;
                                                        }
                                                    }
                                                    strClientSubmitUserName = strClientSubmitUserNameLN + ", " + strClientSubmitUserNameFN;
                                                    if (strREQNumber != "")
                                                    {        
                                                
                                                        //*******submit candidate method calling***********
                                                        //TestCaseResult = objCreate_SubmitCandidate.SubmitCandidate_Method(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
                                                       //*********************** End of submit candidate 

                                                     //   TestCaseResult = objCreate_SubmitCandidate.Mass_Upload_Candidate(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
                                                        if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                        {
                                                            string[] strDataArray1 = new string[5];
                                                            string[] strColArray1 = new string[5];
                                                            //In main sheet Run column update as P
                                                            string strUpdateSqlMain1 = "Update [Main$] set Run = 'P'  WHERE TestCaseId= '004' and Client ='" + drowMain[5].ToString() + "'";
                                                            ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain1);
                                                           string  strUpdateSql = "Update [Supplier$] set TestExecute = 'P'  WHERE TestCaseId= '004' and P6 = '" + AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString() + "' and P3 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                           ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSql);
                                                            string strSubSql12 = "SELECT * FROM [MSP$] WHERE TestCaseId= '005' and P3 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                            GetSelectedResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "MSP$", strSubSql12);
                                                            if (GetSelectedResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                            {
                                                                Thread.Sleep(5000);
                                                                GetSelectedResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "MSP$", strSubSql12);
                                                                if (GetSelectedResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                                {
                                                                    Thread.Sleep(10000);
                                                                    GetSelectedResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "MSP$", strSubSql12);
                                                                    if (GetSelectedResult.ErrorMessage.Contains(stralreadyUsingexcel))
                                                                    {
                                                                    }
                                                                }
                                                            }
                                                            //  Console.WriteLine(strSubSql12);
                                                            if (GetSelectedResult.dt.Rows.Count > 0)
                                                            {
                                                                if (GetSelectedResult.dt.Rows.Count > 0)
                                                                {
                                                                    strDataArray1 = new string[GetSelectedResult.dt.Rows[0].ItemArray.Length];
                                                                    strColArray1 = new string[GetSelectedResult.dt.Rows[0].ItemArray.Length];
                                                                }
                                                                for (int c = 0; c <= GetSelectedResult.dt.Rows[0].ItemArray.Length - 1; c++)
                                                                {
                                                                    if (GetSelectedResult.dt.Columns[c].ColumnName.ToString() != "")
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
                                                                }
                                                                GetSelectedResult = ReadExcelHelper.WriteDataToExcelFileSelected(KeyWords.strExlInputPath, "MSP", strColArray1, strDataArray1);
                                                            }
                                                            strUpdateSqlMain = "Update [Main$] set Run = 'Yes'  WHERE TestCaseId= '005' and Client ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                            //ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);
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
                                                            }
                                                            ProcessStartInfo start = new ProcessStartInfo();
                                                            start.Arguments = strExecutepath + Constants.NunitMSPSMBinPath;
                                                            start.FileName = KeyWords.strNunitConsolePath;
                                                            start.UseShellExecute = false;
                                                            Process.Start(start);                                                           
                                                        }
                                                        else
                                                        {
                                                            kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.No);
                                                            kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.cancel);
                                                            kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, "close");
                                                        }

                                                        TestCaseResult = objCommonMethods.TestCase_Result_Execution(driver, AllSheetResult, TestCaseResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString());
                                                    }
                                                    else
                                                    {
                                                        TestCaseResult.Result1 = KeyWords.Result_FAIL;
                                                        TestCaseResult.ErrorMessage = "Input REQ number is empty";
                                                        TestCaseResult = objCommonMethods.TestCase_Result_Execution(driver, AllSheetResult, TestCaseResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString());
                                                    }
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