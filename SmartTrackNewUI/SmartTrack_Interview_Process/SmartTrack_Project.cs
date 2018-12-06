// --------------------------------------------------------------------------------------------------------------------
//<copyright file="SmartTrack_Project.cs" company="DCR Workforce Inc">
//   Copyright (c) DCR Workforce Inc. All rights reserved.
//   This code and information should not be copied and used outside of DCR Workforce Inc.
// </copyright>
// <summary>
//   Builds the Container for the Autofac IOC.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Text;
//using System.Text.RegularExpressions;
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
// using SmartTrack_Interview_Process;

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
            KeyWordMethods kwm = new KeyWordMethods();
            Request_Interview objCreate_Request_Int = new Request_Interview();
            Schedule_Interview objCreate_Schedule_Int = new Schedule_Interview();
            Confirm_Interview objCreate_Confirm_Int = new Confirm_Interview();
            

            objCommonMethods.TestCase_Result_OutPutExcel_Old();

            string strMainSheetName = "Main$";
            string strMainSql = "SELECT TestCaseId,NumberOfRepeats,DataSheet,Include,Url,Client,UserName,Run,Interview,Browser FROM [" + strMainSheetName + "] where UserName = 'Interview_Process'";
            objCommonMethods.WriteLogFileBeginHeader(KeyWords.strLogfilePath);
            var MainSheetResult = new Result();
            var AllSheetResult = new Result();
            var GetReqNumberResult = new Result();
            var GetSelectedResult = new Result();
            var TestCaseResult = new Result();
            var WriteExlResult = new Result();
            var Result_ScreenShot = new Result();
            var clientSheetResult = new Result();
            var Result_Browser = new Result();

            Thread.Sleep(1);
            TestCaseResult = objCommonMethods.Update_Table_Data_Database("Update ST_AL_Alert set ForceStatus=0");
            string stralreadyUsingexcel = "The Microsoft Office Access database engine cannot open or write to the file";// ''. It is already opened exclusively by another user, or you need permission to view and write its data";

            MainSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strMainSheetName, strMainSql);
            if (MainSheetResult.Result1 == "Pass")
            {
                foreach (DataRow drowMain in MainSheetResult.dt.Rows)
                {
                    if ((drowMain[3].ToString().ToUpper() == "YES") && (drowMain[0].ToString() != null) && (drowMain[2].ToString().Trim() != "") && (Convert.ToInt32(drowMain[1]) > 0))
                    {
                        string strSubSheetName = drowMain[2].ToString() + "$";
                        // Reading the All  sheet selected Testcase ID
                        //Adding new code for supplier new design
                        KeyWords.LoginUser_Role = drowMain[2].ToString();

                        // if (MainSheetResult.dt.Rows[0]["Interview"].ToString() == "Client")
                        if (drowMain[8].ToString().ToLower() == "client")
                        {
                            strSubSheetName = "Approve" + "$";
                        }
                        else
                        {

                        }
                        KeyWords.str_App_Url = drowMain[4].ToString();
                        DataTable dtExlAllSheet = new DataTable();
                        string strSubSql = "";
                        string strAllorClient = drowMain[5].ToString();
                        if (strAllorClient.Trim().ToLower() == "all")
                        {
                            strSubSql = "SELECT * FROM [" + strSubSheetName + "] WHERE TestCaseId= '" + drowMain[0].ToString() + "'";
                        }
                        else
                        {
                            strSubSql = "SELECT * FROM [" + strSubSheetName + "] WHERE TestCaseId= '" + drowMain[0].ToString() + "' and P3 = '" + drowMain[5].ToString() + "' and TestExecute = 'yes'";
                        }

                        AllSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strSubSheetName, strSubSql);
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


                                    switch (AllSheetResult.dt.Rows[iSubRowLoop][0].ToString())
                                    {
                                        case Constants.TestCase006:
                                            {
                                                string strSheetName = "";
                                                string strMSPForwardInterviewToSupplier = "";
                                                foreach (DataRow drowMain1 in AllSheetResult.dt.Rows)
                                                {
                                                    //string strMainSql1 = "SELECT TestCaseId,NumberOfRepeats,NumOfCan,DataSheet,Include,Url,Client,UserName,Run FROM [" + strMainSheetName + "] where NumOfCan = 'Client'";
                                                    //MainSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strMainSheetName, strMainSql1);
                                                    if ((drowMain[8].ToString().ToUpper() == "CLIENT"))
                                                    {
                                                        strSheetName = drowMain[8].ToString();

                                                        strSubSql = "SELECT top 1 * FROM [Approve$] WHERE TestCaseId= '" + drowMain[0].ToString() + "' and P3 = '" + drowMain[5].ToString() + "'and TestExecute = 'yes'";
                                                        clientSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strSubSheetName, strSubSql);
                                                        string strReqNumber = "";
                                                        if (clientSheetResult.Result1 == KeyWords.Result_Pass)
                                                        {
                                                            strReqNumber = clientSheetResult.dt.Rows[0]["P6"].ToString();
                                                        }
                                                        //KeyWords.strApp_Url = drowMain1[4].ToString();
                                                        // string strSubSheetName = drowMain[2].ToString() + "$";
                                                        //string strSubSql = "";t

                                                        //***************************************************

                                                        string strEmail = "";
                                                        TestCaseResult = objCommonMethods.Get_Table_Data_Database("select U.email from ST_MS_Requirement R JOIN VW_ST_MS_ReqManagers rm ON r.requirementID=RM.requirementID join ST_LM_User U ON RM.hiringManagerID=U.userID WHERE  R.CLSRNumber='" + strReqNumber + "'", "Email");
                                                        if (TestCaseResult.listData.Count >= 0)
                                                        {
                                                            strEmail = TestCaseResult.listData[0];
                                                        }
                                                        //***************************************************

                                                        //strEmail = strDataArray[AllSheetResult.dt.Columns.IndexOf("P3")];

                                                        AllSheetResult.dt.Rows[iSubRowLoop]["P1"] = strEmail;

                                                        //***********
                                                        string strUpdatePassword = "update ST_LM_user set password='1000:oizAooy3v/3An1IToW/BUy58z5/WTScb:sx3jU4Aa+iSJ5N+zFwT6x5aV3gTr5ju4',passwordRetriedCount=0,statusID=1 where userid=(Select userID from ST_LM_user where email like '" + strEmail + "')";
                                                        objCommonMethods.Update_Table_Data_Database(strUpdatePassword);
                                                        //**************************************

                                                        //   objCommonMethods.Validate_Password_Update(strEmail, strDataArray[AllSheetResult.dt.Columns.IndexOf("P4")]);

                                                        //*****************
                                                    //    TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driver, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());
                                                        //*****************

                                                        // To update the Test Execute column with 'P'. It avoids running old data.
                                                        string strUpdateSql = "Update [Approve$] set TestExecute = 'P'  WHERE TestCaseId= '006' and P6 = '" + AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString() + "' and P3 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                        WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSql);


                                                        // After Manager Login - Need to check the settings in PM), about the Forward to supplier action

                                                        String ClientName = clientSheetResult.dt.Rows[0]["P3"].ToString();


                                                        TestCaseResult = objCommonMethods.Get_Table_Data_Database("select ct.isMSPForwardInterviewToSupplier,c.Name from ST_PM_CandidateInterviewSettingDetails ct inner join st_lm_client c  on c.clientID=ct .clientID where c.Name ='" + ClientName + "'", "isMSPForwardInterviewToSupplier");

                                                        // TestCaseResult = objCommonMethods.Get_Table_Data_Database("select isMSPForwardInterviewToSupplier from ST_PM_CandidateInterviewSettingDetails where clientid=20", "isMSPForwardInterviewToSupplier");

                                                        if (TestCaseResult.listData.Count >= 0)
                                                        {
                                                            strMSPForwardInterviewToSupplier = TestCaseResult.listData[0];
                                                        }

                                                        if (strMSPForwardInterviewToSupplier == "True")
                                                        {
                                                            // then the supplier will directly receive the interview request (Skip Forward interview to supplier)
                                                            // updating the Include Yes - No in "Forward interview to Supplier" 
                                                            string strUpdateSqlMain = "Update [Main$] set include = 'n'  WHERE TestCaseId= '046'";
                                                            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);
                                                            // drowMain[3].ToString().ToUpper() = "NO";  
                                                            MainSheetResult.dt.Rows[1][3] = "No";
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        strSheetName = drowMain[8].ToString();

                                                        string strUpdateSqlMain = "Update [Main$] set include = 'n'  WHERE TestCaseId= '046'";
                                                        WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);
                                                        MainSheetResult.dt.Rows[1][3] = "No";
                                                       // TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driver, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());

                                                        // To update the Test Execute column with the 'P'. To avoid the executing old data.
                                                        string strUpdateSql = "Update [MSP$] set TestExecute = 'P'  WHERE TestCaseId= '006' and P6 = '" + AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString() + "' and P3 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                        WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSql);

                                                        break;
                                                    }
                                                }
                                                //request interview 
                                               // TestCaseResult = objCreate_Request_Int.Req_Interview(driver, AllSheetResult.dt.Rows[iSubRowLoop]);

                                                if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                {

                                                    string strUpdateSqlMain = "Update [Main$] set Run = 'P'  WHERE TestCaseId= '006' and Client ='" + drowMain[5].ToString() + "'";
                                                    WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);

                                                    if ((strSheetName.ToString().ToUpper() == "CLIENT"))
                                                    {
                                                        if (strMSPForwardInterviewToSupplier == "True")
                                                        {
                                                            string[] strDataArray1 = new string[5];
                                                            string[] strColArray1 = new string[5];
                                                            string strSubSql12 = "SELECT * FROM [all$] WHERE TestCaseId= '047' and P3 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                            GetSelectedResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "All$", strSubSql12);

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
                                                                            strDataArray1[c] = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                                        }
                                                                        else if (GetSelectedResult.dt.Columns[c].ColumnName.ToString() == "P8")
                                                                        {
                                                                            strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                                            strDataArray1[c] = AllSheetResult.dt.Rows[iSubRowLoop]["P8"].ToString();
                                                                        }
                                                                        else
                                                                        {
                                                                            strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                                            strDataArray1[c] = GetSelectedResult.dt.Rows[0][c].ToString();
                                                                        }
                                                                    }
                                                                }
                                                                GetSelectedResult = ReadExcelHelper.WriteDataToExcelFileSelected(KeyWords.strExlInputPath, "Supplier", strColArray1, strDataArray1);
                                                            }

                                                        }
                                                        if (strMSPForwardInterviewToSupplier == "False")
                                                        {
                                                            string[] strDataArray1 = new string[5];
                                                            string[] strColArray1 = new string[5];
                                                            string strSubSql12 = "SELECT * FROM [all$] WHERE TestCaseId= '046' and P3 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                            GetSelectedResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "All$", strSubSql12);

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
                                                                            strDataArray1[c] = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                                        }
                                                                        else if (GetSelectedResult.dt.Columns[c].ColumnName.ToString() == "P8")
                                                                        {
                                                                            strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                                            strDataArray1[c] = AllSheetResult.dt.Rows[iSubRowLoop]["P8"].ToString();
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

                                                        }


                                                    }
                                                    if (strSheetName.ToString() == "MSP")
                                                    {
                                                        string[] strDataArray1 = new string[5];
                                                        string[] strColArray1 = new string[5];
                                                        string strSubSql12 = "SELECT * FROM [all$] WHERE TestCaseId= '047' and P3 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                        GetSelectedResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "All$", strSubSql12);

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
                                                                        strDataArray1[c] = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                                    }
                                                                    else if (GetSelectedResult.dt.Columns[c].ColumnName.ToString() == "P8")
                                                                    {
                                                                        strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                                        strDataArray1[c] = AllSheetResult.dt.Rows[iSubRowLoop]["P8"].ToString();
                                                                    }
                                                                    else
                                                                    {
                                                                        strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                                        strDataArray1[c] = GetSelectedResult.dt.Rows[0][c].ToString();
                                                                    }
                                                                }
                                                            }
                                                            GetSelectedResult = ReadExcelHelper.WriteDataToExcelFileSelected(KeyWords.strExlInputPath, "Supplier", strColArray1, strDataArray1);
                                                        }

                                                    }
                                                    if (TestCaseResult.ErrorMessage1 != "")
                                                    {
                                                        //Requirement Number set in the input sheet
                                                        string strReq = TestCaseResult.ErrorMessage1;
                                                    }
                                                }

                                                TestCaseResult = objCommonMethods.TestCase_Result_Execution(driver, AllSheetResult, TestCaseResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString());
                                                //kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.OK);
                                                //kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.No);
                                                //kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.cancel);
                                                //objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, TestCaseResult.ErrorMessage1, 3);
                                                MainSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strMainSheetName, strMainSql);

                                                break;
                                            }
                                        case Constants.TestCase046:
                                            {
                                               // TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driver, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());

                                                // To update the Test Execute column with 'P'. It avoids running old data.                                                      
                                                string strUpdateSql = "Update [MSP$] set TestExecute = 'P'  WHERE TestCaseId= '046' and P6 = '" + AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString() + "' and P3 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSql);

                                              //  TestCaseResult = objCreate_Forward_Int.Forward_Interview_To_Supp(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
                                                if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                {

                                                    ////// Write the data into Supplier sheet  ///////

                                                    string[] strDataArray1 = new string[5];
                                                    string[] strColArray1 = new string[5];
                                                    string strSubSql12 = "SELECT * FROM [all$] WHERE TestCaseId= '047' and P3 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                    GetSelectedResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "All$", strSubSql12);

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
                                                                    strDataArray1[c] = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                                }
                                                                else if (GetSelectedResult.dt.Columns[c].ColumnName.ToString() == "P8")
                                                                {
                                                                    strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                                    strDataArray1[c] = AllSheetResult.dt.Rows[iSubRowLoop]["P8"].ToString();
                                                                }
                                                                else
                                                                {
                                                                    strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                                    strDataArray1[c] = GetSelectedResult.dt.Rows[0][c].ToString();
                                                                }
                                                            }
                                                        }
                                                        GetSelectedResult = ReadExcelHelper.WriteDataToExcelFileSelected(KeyWords.strExlInputPath, "Supplier", strColArray1, strDataArray1);
                                                    }

                                                    ///// Complete  /////////
                                                    if (TestCaseResult.ErrorMessage1 != "")
                                                    {
                                                        //Requirement Number set in the input sheet
                                                        string strReq = TestCaseResult.ErrorMessage1;
                                                    }
                                                }
                                                TestCaseResult = objCommonMethods.TestCase_Result_Execution(driver, AllSheetResult, TestCaseResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString());
                                                //kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.OK);
                                                //kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.No);
                                                //kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.cancel);
                                                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, TestCaseResult.ErrorMessage1, 3);

                                                break;
                                            }
                                        case Constants.TestCase047:
                                            {
                                               // TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driver, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());

                                                // To update the Test Execute column with 'P'. It avoids running old data.                                                      
                                                string strUpdateSql = "Update [Supplier$] set TestExecute = 'P'  WHERE TestCaseId= '047' and P6 = '" + AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString() + "' and P3 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSql);

                                            //    TestCaseResult = objCreate_Schedule_Int.Sche_Interview(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
                                                if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                {

                                                    //// Write the data into MSP sheet  /////


                                                    string[] strDataArray1 = new string[5];
                                                    string[] strColArray1 = new string[5];
                                                    string strSubSql12 = "SELECT * FROM [all$] WHERE TestCaseId= '048' and P3 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                    GetSelectedResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "All$", strSubSql12);

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
                                                                    strDataArray1[c] = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                                }
                                                                else if (GetSelectedResult.dt.Columns[c].ColumnName.ToString() == "P8")
                                                                {
                                                                    strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                                    strDataArray1[c] = AllSheetResult.dt.Rows[iSubRowLoop]["P8"].ToString();
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
                                                    //// Completed writing data  //////

                                                    if (TestCaseResult.ErrorMessage1 != "")
                                                    {
                                                        //Requirement Number set in the input sheet

                                                        //*****Commenting this code for positive execution  **********

                                                        //string strReq = TestCaseResult.ErrorMessage1;
                                                        //string Number3 = "";
                                                        //TestCaseResult = objCommonMethods.Get_Table_Data_Database("select SkipConfirmInterview from ST_PM_CandidateInterviewSettingDetails where clientid=20", "SkipConfirmInterview");
                                                        //Number3 = TestCaseResult.listData[0];

                                                        //if (Number3 == "True")
                                                        //{
                                                        //    // then the supplier will directly receive the interview request (Skip Forward interview to supplier)
                                                        //    // updating the Include Yes - No in "Forward interview to Supplier" 
                                                        //    string strUpdateSqlMain = "Update [Main$] set include = 'n'  WHERE TestCaseId= '048'";
                                                        //    WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);
                                                        //}
                                                        //break;

                                                        //*****Commenting this code for positive execution  **********
                                                    }
                                                }
                                                TestCaseResult = objCommonMethods.TestCase_Result_Execution(driver, AllSheetResult, TestCaseResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString());
                                                //kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.OK);
                                                //kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.No);
                                                //kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.cancel);
                                                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, TestCaseResult.ErrorMessage1, 3);
                                                MainSheetResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strMainSheetName, strMainSql);

                                                break;
                                            }
                                        case Constants.TestCase048:
                                            {
                                                string strREQNumber = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                string strClientSubmitUserName = AllSheetResult.dt.Rows[iSubRowLoop]["P8"].ToString();

                                              //  TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driver, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());

                                                string strUpdateSql = "Update [MSP$] set TestExecute = 'P'  WHERE TestCaseId= '048' and P6 = '" + AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString() + "' and P3 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSql);

                                              //  TestCaseResult = objCreate_Confirm_Int.Confirm_Int(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
                                                if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                {
                                                    if (TestCaseResult.ErrorMessage1 != "")
                                                    {
                                                        //6th case status changed to 'P'
                                                        string strUpdateSql1 = "Update [Main$] set Run = 'P'  WHERE TestCaseId= '006' and Client ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                        WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSql1);

                                                        //// Write the 007 case data to MSP sheet ////////////
                                                        string[] strDataArray1 = new string[5];
                                                        string[] strColArray1 = new string[5];
                                                        string strSubSql12 = "SELECT * FROM [all$] WHERE TestCaseId= '007' and P3 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                        GetSelectedResult = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "All$", strSubSql12);

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
                                                                        strDataArray1[c] = AllSheetResult.dt.Rows[iSubRowLoop]["P6"].ToString();
                                                                    }
                                                                    else if (GetSelectedResult.dt.Columns[c].ColumnName.ToString() == "P8")
                                                                    {
                                                                        strColArray1[c] = GetSelectedResult.dt.Columns[c].ColumnName.ToString();
                                                                        strDataArray1[c] = AllSheetResult.dt.Rows[iSubRowLoop]["P8"].ToString();
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

                                                        string strUpdateSqlMainSheet = "Update [Main$] set Run = 'Yes'  WHERE TestCaseId= '007' and Client ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
                                                        ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMainSheet);

                                                        // Completed the write data /////
                                                        //Requirement Number set in the input sheet
                                                        string strReq = TestCaseResult.ErrorMessage1;
                                                        string strUpdateSqlMain;
                                                        strUpdateSqlMain = "Update [MSP$] set TestExecute = 'oh' WHERE TestCaseID= '007' and P3 ='" + AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString() + "'";
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
                                                    }
                                                }
                                                TestCaseResult = objCommonMethods.TestCase_Result_Execution(driver, AllSheetResult, TestCaseResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString());
                                                //kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.OK);
                                                //kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.No);
                                                //kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.cancel);

                                                if (TestCaseResult.ErrorMessage == null)
                                                {
                                                    TestCaseResult.ErrorMessage = "Empty";
                                                }

                                                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, TestCaseResult.ErrorMessage, 3);

                                                break;
                                            }

                                        case Constants.TestCase049:
                                            {
                                               // TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driver, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());

                                              //  TestCaseResult = objCreate_Cancel_Int.Can_Interview(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
                                                if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                {
                                                    if (TestCaseResult.ErrorMessage1 != "")
                                                    {
                                                        //Requirement Number set in the input sheet
                                                        string strReq = TestCaseResult.ErrorMessage1;
                                                    }
                                                }
                                                TestCaseResult = objCommonMethods.TestCase_Result_Execution(driver, AllSheetResult, TestCaseResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString());
                                                //kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.OK);
                                                //kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.No);
                                                //kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.cancel);

                                                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, TestCaseResult.ErrorMessage1, 3);
                                                break;
                                            }
                                        case Constants.TestCase050:
                                            {
                                                string strEmail = "";
                                                TestCaseResult = objCommonMethods.Get_Table_Data_Database("select b.email from st_ms_requirement a join st_lm_user b on a.requestorid=b.userid where clsrnumber='ARK-REQ-0417'", "Email");
                                                if (TestCaseResult.listData.Count >= 0)
                                                {
                                                    strEmail = TestCaseResult.listData[0];
                                                }
                                                AllSheetResult.dt.Rows[iSubRowLoop]["P3"] = strEmail;

                                                //***********
                                                string strUpdatePassword = "update ST_LM_user set password='1000:oizAooy3v/3An1IToW/BUy58z5/WTScb:sx3jU4Aa+iSJ5N+zFwT6x5aV3gTr5ju4',passwordRetriedCount=0,statusID=1 where userid=(Select userID from ST_LM_user where email like '" + strEmail + "')";
                                                objCommonMethods.Update_Table_Data_Database(strUpdatePassword);
                                         //       TestCaseResult = objCommonMethods.TestCase_Login_Execution_NewApp(driver, AllSheetResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString(), AllSheetResult.dt.Rows[iSubRowLoop][0].ToString());
                                               // TestCaseResult = objCreate_Int_Feedback.Int_Feedback(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
                                                if (TestCaseResult.Result1 == KeyWords.Result_PASS)
                                                {
                                                    if (TestCaseResult.ErrorMessage1 != "")
                                                    {
                                                        //Requirement Number set in the input sheet
                                                        string strReq = TestCaseResult.ErrorMessage1;
                                                    }
                                                }
                                                TestCaseResult = objCommonMethods.TestCase_Result_Execution(driver, AllSheetResult, TestCaseResult, KeyWords.strLogfilePath, KeyWords.strExlOutputPath, iSubRowLoop, strColArray, strDataArray, iLoop, drowMain[1].ToString());
                                                //kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.OK);
                                                //kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.No);
                                                //kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, Constants.cancel);

                                                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, TestCaseResult.ErrorMessage1, 3);
                                                break;
                                            }


                                        default:
                                            {
                                                break;
                                            }
                                    }//Switch case End here
                                }//No of sub test cases for loop                               

                                //break;

                                kwm.Logout_Link_Click_NewUI(driver, "Logout");
                                driver.Close();

                                string strExecutepath = @System.IO.Directory.GetCurrentDirectory();
                                if (KeyWords.strNunitConsolePath == "")
                                {
                                    KeyWords.strNunitConsolePath = Constants.NunitConsolePath;
                                }
                                ProcessStartInfo start = new ProcessStartInfo();
                                start.Arguments = strExecutepath + Constants.NunitMSPOHEOBinPath;
                                start.FileName = KeyWords.strNunitConsolePath;
                                Process.Start(start);
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