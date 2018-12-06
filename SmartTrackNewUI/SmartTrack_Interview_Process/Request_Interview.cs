using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;
//using System.Text.RegularExpressions;
using System.IO;
using System.Data;
using System.Configuration;
// using System.Data.OracleClient;
using System.Net;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
// using CommonFiles;
using SmartTrack.DataAccess.Repository;
using SmartTrack.DataAccess.Models;
using RelevantCodes.ExtentReports;
// using Microsoft.VisualStudio.TestTools.UnitTesting;
//using SmartTrack_Automation;

namespace SmartTrack_Automation
{
    // [TestClass]
    public class Request_Interview
    {
        public Result Req_Interview(IWebDriver WDriver, DataRow Request_Interview)
        {
            ReadExcel ReadExcelHelper = new ReadExcel();
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            // Rate_Change objRateChange = new Rate_Change();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 30);
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            InterviewProcessModel Interview_Process_Model = createRequirementRepository.GetInterviewProcessModel(Request_Interview);
            SubmitCandidateAddResume submitCandidateAddResume = createRequirementRepository.GetSubmitCandidateAddResumeData(Request_Interview);
            // Menu selection

            results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Interview_Process_Model.strClientName);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Interview_Process_Model.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    //  return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, Interview_Process_Model.strClientName + "_");

            //Submenu click

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Interview_Process_Model.strMainMenuLink, Interview_Process_Model.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Interview_Process_Model.strMainMenuLink, Interview_Process_Model.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }

            // Data is passed into search text box

            Thread.Sleep(2000);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.ID_paginate_regReqList_filter), kwm._WDWait);
            kwm.sendTextXPathOnly(WDriver, KeyWords.ID_paginate_regReqList_filter, Interview_Process_Model.str_Select_Statuslist);
            //try
            //{
            //    Thread.Sleep(2000);
            //    WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).Clear();

            //    WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).SendKeys(Interview_Process_Model.str_Select_Statuslist);
            //}
            //catch
            //{
            //    try
            //    {
            //        WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).Clear();
            //        WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).SendKeys(Interview_Process_Model.str_Select_Statuslist);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //}

            // After seraching, requirement number  click
            Thread.Sleep(2000);
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 30);//new wait written
            kwm.waitForElementToBeClickable(WDriver, By.LinkText(Interview_Process_Model.str_Select_Statuslist), kwm._WDWait);

            //  WDriver.FindElement(By.LinkText(Interview_Process_Model.str_Select_Statuslist)).Click();

            kwm.jsClick(WDriver, KeyWords.locator_XPath, "//a[contains(text(),'" + Interview_Process_Model.str_Select_Statuslist + "')]");
            //Loading message
            for (int z = 1; z < 500; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id("loading-message")).Displayed;
                }
                catch
                {
                    strValue = true;
                }

                //  Console.WriteLine("z -----> " + z);
                //  Console.WriteLine("strValue -----> " + strValue);
                if (!strValue)
                {
                    break;
                }
                Thread.Sleep(1000);
            }
            //kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//a[contains(text(),'" + Interview_Process_Model.str_Link_ViewCandidates + "')]");
            //View candidate link click

            string strSubLevel = "";
            objCommonMethods.SaveScreenShot_EachPage(WDriver, Interview_Process_Model.strClientName + "_");
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, Interview_Process_Model.str_Link_ViewCandidates);

            try
            {

                results = kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[@class='reqCandidate']//a[contains(normalize-space(),'" + Interview_Process_Model.str_Link_ViewCandidates + "')]");
            }
            catch (Exception)
            {                

                try
                {
                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[@class='reqCandidate']//a[contains(normalize-space(),'" + Interview_Process_Model.str_Link_ViewCandidates + "')]");
                }
                catch (Exception)
                {

                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given View Candidate Text not find " + Interview_Process_Model.str_Link_ViewCandidates;
                    return results;
                }
            }


            //results = kwm.jsClick(WDriver, KeyWords.locator_XPath, "//a[contains(text(),'" + Interview_Process_Model.str_Link_ViewCandidates + "')]");
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Interview_Process_Model.str_Link_ViewCandidates, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                objCommonMethods.Action_Page_Down_javascriptexecutor(WDriver);
                Thread.Sleep(1000);
               
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Interview_Process_Model.str_Link_ViewCandidates, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_Txt_CandidateName), kwm._WDWait);
            Thread.Sleep(1000);
            kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_CandidateName, Interview_Process_Model.str_Txt_CandidateName);

            Thread.Sleep(1000);

            // Search Candidate Name
            //if (Interview_Process_Model.str_Txt_CandidateName != "")
            //{
            //    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_CandidateName)).Clear();

            //    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_CandidateName)).SendKeys(Interview_Process_Model.str_Txt_CandidateName);
            //}

            Thread.Sleep(1000);

            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_Txt_CandidateName), kwm._WDWait);

            string strXpath_CandidateNameLink = "//*[@id='HistoryTableViewCandidate']//td//a[text()[normalize-space()= '" + Interview_Process_Model.str_Txt_CandidateName + "']]";
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, strXpath_CandidateNameLink);
            //Candidate name click			
            kwm.click(WDriver, KeyWords.locator_XPath, strXpath_CandidateNameLink);
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);

            // Click on Candidate Name
            //if (Interview_Process_Model.str_Txt_CandidateName != "")
            //    objCommonMethods.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, Interview_Process_Model.str_Txt_CandidateName);
            //    try
            //    {

            //        WDriver.FindElement(By.LinkText(Interview_Process_Model.str_Txt_CandidateName)).Click();
            //    }
            //    catch
            //    {
            //        Thread.Sleep(100);
            //        try
            //        {
            //            WDriver.FindElement(By.LinkText(Interview_Process_Model.str_Txt_CandidateName)).Click();
            //        }
            //        catch
            //        {
            //            // Console.WriteLine(bFlag);
            //            results.Result1 = KeyWords.Result_FAIL;
            //            results.ErrorMessage = "The given candidate name not find " + Interview_Process_Model.str_Txt_CandidateName;
            //            return results;
            //        }
            //    }


            // To check Request Interview link is displaying
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_List_listMenu1))));
            }
            catch
            {
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "Action list is not displayed", 3);
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_List_listMenu1)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            // To click on Request Interview link 

            //string strSubLevel = "";
            string strSubLevel1 = "";
            string strXpath_ListMenu = "//*[@id='listMenu1']//li[text()[normalize-space()= '" + Interview_Process_Model.str_Link_ReqInterview + "']]";
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, strXpath_ListMenu);
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Interview_Process_Model.str_Link_ReqInterview, strSubLevel1);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Interview_Process_Model.str_Link_ReqInterview, strSubLevel1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            /// Interview
            Boolean bFlagConf = false;
            try
            {
                bFlagConf = WDriver.FindElement(By.Id(KeyWords.ID_Candidate_Int_DialogPopup)).Enabled;
            }
            catch
            {
                bFlagConf = false;
            }
            if (bFlagConf)
            {
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(3000);
                    IAlert promptAlert = WDriver.SwitchTo().Alert();
                    promptAlert.Accept();
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }



            // Request Candidate Interview Window
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_Candidate_Int_DialogWindow))));
            }
            catch
            {

            }

            // 1st Choice(Date)
            //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FirChoice);


            //Thread.Sleep(2000);

            //if (Interview_Process_Model.str_Date_FirChoice == "")
            //{
            //    //results = kwm.Select_End_Date_From_Picker(WDriver, createRequirementModel.strDateAssignmentEnd);
            //    // if (results.Result1 == KeyWords.Result_FAIL)
            //    // {
            //   // results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FirChoice, Interview_Process_Model.str_Date_FirChoice, false);
            //    results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        //return results;
            //    }
            //    // }
            //}
            //else
            //{

            //    var today = DateTime.Now;
            //    var tomorrow = today.AddDays(1);
            //    DateTime date = tomorrow;
            //    Interview_Process_Model.str_Date_FirChoice = date.ToString("MM/dd/yyyy");
            //    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FirChoice, Interview_Process_Model.str_Date_FirChoice, false);
            //}


            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FirChoice);

            if (Interview_Process_Model.str_Date_FirChoice == "")
            {
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }

            }
            else
            {
                DateTime date = DateTime.Today;
                Interview_Process_Model.str_Date_FirChoice = date.ToString("MM/dd/yyyy");
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FirChoice, Interview_Process_Model.str_Date_FirChoice, false);
            }

            // Select Time1
            if (Interview_Process_Model.str_Select_Time1 != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Time1, Interview_Process_Model.str_Select_Time1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Select_Time1))); //Locating select list
                        se.SelectByIndex(3);
                    }
                    catch
                    {
                        //
                    }
                }
            }


            // Select Zone1
            if (Interview_Process_Model.str_Select_Zone1 != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Zone1, Interview_Process_Model.str_Select_Zone1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Select_Zone1))); //Locating select list
                        se.SelectByIndex(3);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            // 2nd Choice(Date)
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_SecChoice);

            if (Interview_Process_Model.str_Date_SecChoice == "")
            {
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Now.AddDays(1));
                // if (results.Result1 == KeyWords.Result_FAIL)
                // {
                //results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_SecChoice, Interview_Process_Model.str_Date_SecChoice, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
                // }
            }
            else
            {
                DateTime date = DateTime.Today;
                Interview_Process_Model.str_Date_SecChoice = date.ToString("MM/dd/yyyy");
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_SecChoice, Interview_Process_Model.str_Date_SecChoice, false);
            }


            // Select Time2
            if (Interview_Process_Model.str_Select_Time2 != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Time2, Interview_Process_Model.str_Select_Time2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Select_Time2))); //Locating select list
                        se.SelectByIndex(3);
                    }
                    catch
                    {
                        //
                    }
                }
            }


            // Select Zone2
            if (Interview_Process_Model.str_Select_Zone2 != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Zone2, Interview_Process_Model.str_Select_Zone2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Select_Zone2))); //Locating select list
                        se.SelectByIndex(3);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            // Interview Type(Radio Button)

            if (Interview_Process_Model.str_Radio_IntType != "")
            {
                if (Interview_Process_Model.str_Radio_IntType.Equals(KeyWords.str_String_PersonInterview))
                {
                    Thread.Sleep(3000);
                    results = objCommonMethods.Select_Radio_Button(WDriver, "interviewtype", "1");

                }

                else if (Interview_Process_Model.str_Radio_IntType.Equals(KeyWords.str_String_PhoneScreen))
                {
                    results = objCommonMethods.Select_Radio_Button(WDriver, "interviewtype", "2");

                }
                else if (Interview_Process_Model.str_Radio_IntType.Equals(KeyWords.str_String_Skype))
                {

                    results = objCommonMethods.Select_Radio_Button(WDriver, "interviewtype", "3");

                }
                else if (Interview_Process_Model.str_Radio_IntType.Equals(KeyWords.str_String_WebEx))
                {

                    results = objCommonMethods.Select_Radio_Button(WDriver, "interviewtype", "4");

                }
            }
            else if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = objCommonMethods.Select_Radio_Button(WDriver, "interviewtype", "2");
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(WDriver, "interviewtype", "2");
            }

            // Select Interviewer
            if (Interview_Process_Model.str_Txt_Interviewer != "")
            {
                string[] separators1 = { "#" };
                String[] words = Interview_Process_Model.str_Txt_Interviewer.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Sel_Interviewer, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Sel_Interviewer, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Sel_Interviewer, KeyWords.locator_class, KeyWords.CL_list_typeahead, "a");
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Btn_AddInterview);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }

            }

            // Instructions
            if (Interview_Process_Model.str_Txt_InterviewAddress != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Interview_Address, Interview_Process_Model.str_Txt_InterviewAddress, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            // Request Interview button
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_class, KeyWords.locator_class_button, Interview_Process_Model.str_Btn_RequestInterview);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(3000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_class_button, Interview_Process_Model.str_Btn_RequestInterview);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            // To maintain error log messages in log files
            objCommonMethods.SaveScreenShot_EachPage(WDriver, Interview_Process_Model.strClientName + "_");
            results = kwm.Error_Msg_Read_Submit_Resume_details(WDriver, "//*[@" + KeyWords.locator_ID + "='ulMspUserError']/li");

            //results = kwm.Error_Msg_Read_Submit_Resume_details(WDriver, "//div[@" + KeyWords.locator_ID + "= KeyWords.ID_Error_Valmessages]/div/ul/li");

            if (results.Result1 == KeyWords.Result_PASS)
            {
                if (results.ErrorMessage != "")
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    return results;
                }
            }

            Thread.Sleep(500);

            // Confirmation popup with YES/NO
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Interview_Process_Model.str_Btn_Yes_Action_ReqInt);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(3000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Interview_Process_Model.str_Btn_Yes_Action_ReqInt);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            // Click on OK button
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Interview_Process_Model.str_Btn_OK_ReqInt);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(13000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Interview_Process_Model.str_Btn_OK_ReqInt);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(15000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Interview_Process_Model.str_Btn_OK_ReqInt);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }

            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage1 = KeyWords.MSG_str_Request_Interview_Done;
            //  results.ErrorMessage = "Invoice Batch created Successfully done  -->  " + strBatchNumberCreated;
            return results;
        }

        public Result Feedback(IWebDriver WDriver, DataRow Candidate_Feedback)
        {
            ReadExcel ReadExcelHelper = new ReadExcel();
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            // Rate_Change objRateChange = new Rate_Change();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 30);
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            InterviewProcessModel Interview_Process_Model = createRequirementRepository.GetInterviewProcessModel(Candidate_Feedback);
            SubmitCandidateAddResume submitCandidateAddResume = createRequirementRepository.GetSubmitCandidateAddResumeData(Candidate_Feedback);
            // Menu selection

            results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Interview_Process_Model.strClientName);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Interview_Process_Model.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    //  return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, Interview_Process_Model.strClientName + "_");

            //Submenu click

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Interview_Process_Model.strMainMenuLink, Interview_Process_Model.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Interview_Process_Model.strMainMenuLink, Interview_Process_Model.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }

            // Data is passed into search text box

            Thread.Sleep(2000);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.ID_paginate_regReqList_filter), kwm._WDWait);
            kwm.sendTextXPathOnly(WDriver, KeyWords.ID_paginate_regReqList_filter, Interview_Process_Model.str_Select_Statuslist);
            //try
            //{
            //    Thread.Sleep(2000);
            //    WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).Clear();

            //    WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).SendKeys(Interview_Process_Model.str_Select_Statuslist);
            //}
            //catch
            //{
            //    try
            //    {
            //        WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).Clear();
            //        WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).SendKeys(Interview_Process_Model.str_Select_Statuslist);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //}

            // After seraching, requirement number  click
            Thread.Sleep(2000);
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 30);//new wait written
            kwm.waitForElementToBeClickable(WDriver, By.LinkText(Interview_Process_Model.str_Select_Statuslist), kwm._WDWait);

            //  WDriver.FindElement(By.LinkText(Interview_Process_Model.str_Select_Statuslist)).Click();

            kwm.jsClick(WDriver, KeyWords.locator_XPath, "//a[contains(text(),'" + Interview_Process_Model.str_Select_Statuslist + "')]");
            //Loading message
            for (int z = 1; z < 500; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id("loading-message")).Displayed;
                }
                catch
                {
                    strValue = true;
                }

                //  Console.WriteLine("z -----> " + z);
                //  Console.WriteLine("strValue -----> " + strValue);
                if (!strValue)
                {
                    break;
                }
                Thread.Sleep(1000);
            }
            //kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//a[contains(text(),'" + Interview_Process_Model.str_Link_ViewCandidates + "')]");
            //View candidate link click

            string strSubLevel = "";
            objCommonMethods.SaveScreenShot_EachPage(WDriver, Interview_Process_Model.strClientName + "_");
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, Interview_Process_Model.str_Link_ViewCandidates);

            try
            {

                results = kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[@class='reqCandidate']//a[contains(normalize-space(),'" + Interview_Process_Model.str_Link_ViewCandidates + "')]");
            }
            catch (Exception)
            {

                try
                {
                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[@class='reqCandidate']//a[contains(normalize-space(),'" + Interview_Process_Model.str_Link_ViewCandidates + "')]");
                }
                catch (Exception)
                {

                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given View Candidate Text not find " + Interview_Process_Model.str_Link_ViewCandidates;
                    return results;
                }
            }


            //results = kwm.jsClick(WDriver, KeyWords.locator_XPath, "//a[contains(text(),'" + Interview_Process_Model.str_Link_ViewCandidates + "')]");
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Interview_Process_Model.str_Link_ViewCandidates, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                objCommonMethods.Action_Page_Down_javascriptexecutor(WDriver);
                Thread.Sleep(1000);

                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Interview_Process_Model.str_Link_ViewCandidates, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_Txt_CandidateName), kwm._WDWait);
            Thread.Sleep(1000);
            kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_CandidateName, Interview_Process_Model.str_Txt_CandidateName);

            Thread.Sleep(1000);

            // Search Candidate Name
            //if (Interview_Process_Model.str_Txt_CandidateName != "")
            //{
            //    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_CandidateName)).Clear();

            //    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_CandidateName)).SendKeys(Interview_Process_Model.str_Txt_CandidateName);
            //}

            Thread.Sleep(1000);

            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_Txt_CandidateName), kwm._WDWait);

            string strXpath_CandidateNameLink = "//*[@id='HistoryTableViewCandidate']//td//a[text()[normalize-space()= '" + Interview_Process_Model.str_Txt_CandidateName + "']]";
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, strXpath_CandidateNameLink);
            //Candidate name click			
            kwm.click(WDriver, KeyWords.locator_XPath, strXpath_CandidateNameLink);
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);

            // Click on Candidate Name
            //if (Interview_Process_Model.str_Txt_CandidateName != "")
            //    objCommonMethods.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, Interview_Process_Model.str_Txt_CandidateName);
            //    try
            //    {

            //        WDriver.FindElement(By.LinkText(Interview_Process_Model.str_Txt_CandidateName)).Click();
            //    }
            //    catch
            //    {
            //        Thread.Sleep(100);
            //        try
            //        {
            //            WDriver.FindElement(By.LinkText(Interview_Process_Model.str_Txt_CandidateName)).Click();
            //        }
            //        catch
            //        {
            //            // Console.WriteLine(bFlag);
            //            results.Result1 = KeyWords.Result_FAIL;
            //            results.ErrorMessage = "The given candidate name not find " + Interview_Process_Model.str_Txt_CandidateName;
            //            return results;
            //        }
            //    }


            // To check Request Interview link is displaying
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_List_listMenu1))));
            }
            catch
            {
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "Action list is not displayed", 3);
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_List_listMenu1)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            // To click on Request Interview link 

            //string strSubLevel = "";
            string strSubLevel1 = "";
            string strXpath_ListMenu = "//*[@id='listMenu1']//li[text()[normalize-space()= '" + Interview_Process_Model.str_Link_Feedback + "']]";
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, strXpath_ListMenu);
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Interview_Process_Model.str_Link_Feedback, strSubLevel1);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Interview_Process_Model.str_Link_Feedback, strSubLevel1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }






            // Feedback
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_Candidate_Int_DialogWindow))));
            }
            catch
            {

            }

            //Reason 
            if (Interview_Process_Model.str_Radiobutton_Feedback_Reason != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, "//div[@role='radiogroup']//div[" + Interview_Process_Model.str_Radiobutton_Feedback_Reason + "]//label/input");

            }
            else
            {

                results = kwm.click(WDriver, KeyWords.locator_XPath, "//div[@role='radiogroup']//div[1]//label/input");
            }


            //Comment*
            if (Interview_Process_Model.str_Txt_Comment_txtComments != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Comment_txtComments, Interview_Process_Model.str_Txt_Comment_txtComments, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }



            objCommonMethods.Action_Page_Down(WDriver);
            //Send Feedback button
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_class, KeyWords.locator_class_button, Interview_Process_Model.str_Btn_RequestInterview);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(3000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_class_button, Interview_Process_Model.str_Btn_RequestInterview);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            // To maintain error log messages in log files
            objCommonMethods.SaveScreenShot_EachPage(WDriver, Interview_Process_Model.strClientName + "_");
            results = kwm.Error_Msg_Read_Submit_Resume_details(WDriver, "//*[@" + KeyWords.locator_ID + "='ulMspUserError']/li");

            //results = kwm.Error_Msg_Read_Submit_Resume_details(WDriver, "//div[@" + KeyWords.locator_ID + "= KeyWords.ID_Error_Valmessages]/div/ul/li");

            if (results.Result1 == KeyWords.Result_PASS)
            {
                if (results.ErrorMessage != "")
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    return results;
                }
            }

            Thread.Sleep(500);

            // Confirmation popup with YES/NO
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Interview_Process_Model.str_Btn_Yes_Action_ReqInt);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(3000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Interview_Process_Model.str_Btn_Yes_Action_ReqInt);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            // Click on OK button
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Interview_Process_Model.str_Btn_OK_ReqInt);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(13000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Interview_Process_Model.str_Btn_OK_ReqInt);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(15000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Interview_Process_Model.str_Btn_OK_ReqInt);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }

            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage1 = KeyWords.MSG_str_Request_Interview_Done;
            //  results.ErrorMessage = "Invoice Batch created Successfully done  -->  " + strBatchNumberCreated;
            return results;
        }

        public Result Reschedule_Interview(IWebDriver WDriver, DataRow Request_Interview)
        {
            ReadExcel ReadExcelHelper = new ReadExcel();
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            // Rate_Change objRateChange = new Rate_Change();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 30);
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            InterviewProcessModel Interview_Process_Model = createRequirementRepository.GetInterviewProcessModel(Request_Interview);
            SubmitCandidateAddResume submitCandidateAddResume = createRequirementRepository.GetSubmitCandidateAddResumeData(Request_Interview);
            // Menu selection

            results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Interview_Process_Model.strClientName);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Interview_Process_Model.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    //  return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, Interview_Process_Model.strClientName + "_");

            //Submenu click

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Interview_Process_Model.strMainMenuLink, Interview_Process_Model.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Interview_Process_Model.strMainMenuLink, Interview_Process_Model.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }

            // Data is passed into search text box

            Thread.Sleep(2000);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.ID_paginate_regReqList_filter), kwm._WDWait);
            kwm.sendTextXPathOnly(WDriver, KeyWords.ID_paginate_regReqList_filter, Interview_Process_Model.str_Select_Statuslist);
            //try
            //{
            //    Thread.Sleep(2000);
            //    WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).Clear();

            //    WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).SendKeys(Interview_Process_Model.str_Select_Statuslist);
            //}
            //catch
            //{
            //    try
            //    {
            //        WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).Clear();
            //        WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).SendKeys(Interview_Process_Model.str_Select_Statuslist);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //}

            // After seraching, requirement number  click
            Thread.Sleep(2000);
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 30);//new wait written
            kwm.waitForElementToBeClickable(WDriver, By.LinkText(Interview_Process_Model.str_Select_Statuslist), kwm._WDWait);

            //  WDriver.FindElement(By.LinkText(Interview_Process_Model.str_Select_Statuslist)).Click();

            kwm.jsClick(WDriver, KeyWords.locator_XPath, "//a[contains(text(),'" + Interview_Process_Model.str_Select_Statuslist + "')]");
            //Loading message
            for (int z = 1; z < 500; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id("loading-message")).Displayed;
                }
                catch
                {
                    strValue = true;
                }

                //  Console.WriteLine("z -----> " + z);
                //  Console.WriteLine("strValue -----> " + strValue);
                if (!strValue)
                {
                    break;
                }
                Thread.Sleep(1000);
            }
            //kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//a[contains(text(),'" + Interview_Process_Model.str_Link_ViewCandidates + "')]");
            //View candidate link click

            string strSubLevel = "";
            objCommonMethods.SaveScreenShot_EachPage(WDriver, Interview_Process_Model.strClientName + "_");
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, Interview_Process_Model.str_Link_ViewCandidates);

            try
            {

                results = kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[@class='reqCandidate']//a[contains(normalize-space(),'" + Interview_Process_Model.str_Link_ViewCandidates + "')]");
            }
            catch (Exception)
            {

                try
                {
                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[@class='reqCandidate']//a[contains(normalize-space(),'" + Interview_Process_Model.str_Link_ViewCandidates + "')]");
                }
                catch (Exception)
                {

                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given View Candidate Text not find " + Interview_Process_Model.str_Link_ViewCandidates;
                    return results;
                }
            }


            //results = kwm.jsClick(WDriver, KeyWords.locator_XPath, "//a[contains(text(),'" + Interview_Process_Model.str_Link_ViewCandidates + "')]");
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Interview_Process_Model.str_Link_ViewCandidates, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                objCommonMethods.Action_Page_Down_javascriptexecutor(WDriver);
                Thread.Sleep(1000);

                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Interview_Process_Model.str_Link_ViewCandidates, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_Txt_CandidateName), kwm._WDWait);
            Thread.Sleep(1000);
            kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_CandidateName, Interview_Process_Model.str_Txt_CandidateName);

            Thread.Sleep(1000);

            // Search Candidate Name
            //if (Interview_Process_Model.str_Txt_CandidateName != "")
            //{
            //    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_CandidateName)).Clear();

            //    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_CandidateName)).SendKeys(Interview_Process_Model.str_Txt_CandidateName);
            //}

            Thread.Sleep(1000);

            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_Txt_CandidateName), kwm._WDWait);

            string strXpath_CandidateNameLink = "//*[@id='HistoryTableViewCandidate']//td//a[text()[normalize-space()= '" + Interview_Process_Model.str_Txt_CandidateName + "']]";
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, strXpath_CandidateNameLink);
            //Candidate name click			
            kwm.click(WDriver, KeyWords.locator_XPath, strXpath_CandidateNameLink);
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);

            // Click on Candidate Name
            //if (Interview_Process_Model.str_Txt_CandidateName != "")
            //    objCommonMethods.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, Interview_Process_Model.str_Txt_CandidateName);
            //    try
            //    {

            //        WDriver.FindElement(By.LinkText(Interview_Process_Model.str_Txt_CandidateName)).Click();
            //    }
            //    catch
            //    {
            //        Thread.Sleep(100);
            //        try
            //        {
            //            WDriver.FindElement(By.LinkText(Interview_Process_Model.str_Txt_CandidateName)).Click();
            //        }
            //        catch
            //        {
            //            // Console.WriteLine(bFlag);
            //            results.Result1 = KeyWords.Result_FAIL;
            //            results.ErrorMessage = "The given candidate name not find " + Interview_Process_Model.str_Txt_CandidateName;
            //            return results;
            //        }
            //    }


            // To check Request Interview link is displaying
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_List_listMenu1))));
            }
            catch
            {
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "Action list is not displayed", 3);
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_List_listMenu1)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            // To click on Request Interview link 

            //string strSubLevel = "";
            string strSubLevel1 = "";
            string strXpath_ListMenu = "//*[@id='listMenu1']//li[text()[normalize-space()= '" + Interview_Process_Model.str_Link_ReqInterview + "']]";
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, strXpath_ListMenu);
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Interview_Process_Model.str_Link_ReqInterview, strSubLevel1);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Interview_Process_Model.str_Link_ReqInterview, strSubLevel1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            /// Interview
            Boolean bFlagConf = false;
            try
            {
                bFlagConf = WDriver.FindElement(By.Id(KeyWords.ID_Candidate_Int_DialogPopup)).Enabled;
            }
            catch
            {
                bFlagConf = false;
            }
            if (bFlagConf)
            {
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(3000);
                    IAlert promptAlert = WDriver.SwitchTo().Alert();
                    promptAlert.Accept();
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }



            // Request Candidate Interview Window
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_Candidate_Int_DialogWindow))));
            }
            catch
            {

            }

            // 1st Choice(Date)
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FirChoice);


            Thread.Sleep(2000);

            if (Interview_Process_Model.str_Date_FirChoice == "")
            {
                //results = kwm.Select_End_Date_From_Picker(WDriver, createRequirementModel.strDateAssignmentEnd);
                // if (results.Result1 == KeyWords.Result_FAIL)
                // {
                // results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FirChoice, Interview_Process_Model.str_Date_FirChoice, false);
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
                // }
            }
            else
            {

                var today = DateTime.Now;
                var tomorrow = today.AddDays(1);
                DateTime date = tomorrow;
                Interview_Process_Model.str_Date_FirChoice = date.ToString("MM/dd/yyyy");
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FirChoice, Interview_Process_Model.str_Date_FirChoice, false);
            }

            // Select Time1
            if (Interview_Process_Model.str_Select_Time1 != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Time1, Interview_Process_Model.str_Select_Time1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Select_Time1))); //Locating select list
                        se.SelectByIndex(3);
                    }
                    catch
                    {
                        //
                    }
                }
            }


            // Select Zone1
            if (Interview_Process_Model.str_Select_Zone1 != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Zone1, Interview_Process_Model.str_Select_Zone1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Select_Zone1))); //Locating select list
                        se.SelectByIndex(3);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            // 2nd Choice(Date)
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_SecChoice);

            if (Interview_Process_Model.str_Date_SecChoice == "")
            {
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Now.AddDays(1));
                // if (results.Result1 == KeyWords.Result_FAIL)
                // {
                //results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_SecChoice, Interview_Process_Model.str_Date_SecChoice, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
                // }
            }
            else
            {
                DateTime date = DateTime.Today;
                Interview_Process_Model.str_Date_SecChoice = date.ToString("MM/dd/yyyy");
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_SecChoice, Interview_Process_Model.str_Date_SecChoice, false);
            }


            // Select Time2
            if (Interview_Process_Model.str_Select_Time2 != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Time2, Interview_Process_Model.str_Select_Time2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Select_Time2))); //Locating select list
                        se.SelectByIndex(3);
                    }
                    catch
                    {
                        //
                    }
                }
            }


            // Select Zone2
            if (Interview_Process_Model.str_Select_Zone2 != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Zone2, Interview_Process_Model.str_Select_Zone2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Select_Zone2))); //Locating select list
                        se.SelectByIndex(3);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            // Interview Type(Radio Button)

            if (Interview_Process_Model.str_Radio_IntType != "")
            {
                if (Interview_Process_Model.str_Radio_IntType.Equals(KeyWords.str_String_PersonInterview))
                {
                    Thread.Sleep(3000);
                    results = objCommonMethods.Select_Radio_Button(WDriver, "interviewtype", "1");

                }

                else if (Interview_Process_Model.str_Radio_IntType.Equals(KeyWords.str_String_PhoneScreen))
                {
                    results = objCommonMethods.Select_Radio_Button(WDriver, "interviewtype", "2");

                }
                else if (Interview_Process_Model.str_Radio_IntType.Equals(KeyWords.str_String_Skype))
                {

                    results = objCommonMethods.Select_Radio_Button(WDriver, "interviewtype", "3");

                }
                else if (Interview_Process_Model.str_Radio_IntType.Equals(KeyWords.str_String_WebEx))
                {

                    results = objCommonMethods.Select_Radio_Button(WDriver, "interviewtype", "4");

                }
            }
            else if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = objCommonMethods.Select_Radio_Button(WDriver, "interviewtype", "2");
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(WDriver, "interviewtype", "2");
            }

            // Select Interviewer
            if (Interview_Process_Model.str_Txt_Interviewer != "")
            {
                string[] separators1 = { "#" };
                String[] words = Interview_Process_Model.str_Txt_Interviewer.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Sel_Interviewer, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Sel_Interviewer, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Sel_Interviewer, KeyWords.locator_class, KeyWords.CL_list_typeahead, "a");
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Btn_AddInterview);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }

            }

            // Instructions
            if (Interview_Process_Model.str_Txt_InterviewAddress != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Interview_Address, Interview_Process_Model.str_Txt_InterviewAddress, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            // Request Interview button
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_class, KeyWords.locator_class_button, Interview_Process_Model.str_Btn_RequestInterview);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(3000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_class_button, Interview_Process_Model.str_Btn_RequestInterview);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            // To maintain error log messages in log files
            objCommonMethods.SaveScreenShot_EachPage(WDriver, Interview_Process_Model.strClientName + "_");
            results = kwm.Error_Msg_Read_Submit_Resume_details(WDriver, "//*[@" + KeyWords.locator_ID + "='ulMspUserError']/li");

            //results = kwm.Error_Msg_Read_Submit_Resume_details(WDriver, "//div[@" + KeyWords.locator_ID + "= KeyWords.ID_Error_Valmessages]/div/ul/li");

            if (results.Result1 == KeyWords.Result_PASS)
            {
                if (results.ErrorMessage != "")
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    return results;
                }
            }

            Thread.Sleep(500);

            // Confirmation popup with YES/NO
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Interview_Process_Model.str_Btn_Yes_Action_ReqInt);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(3000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Interview_Process_Model.str_Btn_Yes_Action_ReqInt);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            // Click on OK button
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Interview_Process_Model.str_Btn_OK_ReqInt);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(13000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Interview_Process_Model.str_Btn_OK_ReqInt);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(15000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Interview_Process_Model.str_Btn_OK_ReqInt);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }

            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage1 = KeyWords.MSG_str_Request_Interview_Done;
            //  results.ErrorMessage = "Invoice Batch created Successfully done  -->  " + strBatchNumberCreated;
            return results;
        }

        public Result Candidate_Withdraw(IWebDriver WDriver, DataRow Candidate_Feedback)
        {
            ReadExcel ReadExcelHelper = new ReadExcel();
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            // Rate_Change objRateChange = new Rate_Change();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 30);
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            InterviewProcessModel Interview_Process_Model = createRequirementRepository.GetInterviewProcessModel(Candidate_Feedback);
            SubmitCandidateAddResume submitCandidateAddResume = createRequirementRepository.GetSubmitCandidateAddResumeData(Candidate_Feedback);
            // Menu selection

            results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Interview_Process_Model.strClientName);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Interview_Process_Model.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    //  return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, Interview_Process_Model.strClientName + "_");

            //Submenu click

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Interview_Process_Model.strMainMenuLink, Interview_Process_Model.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Interview_Process_Model.strMainMenuLink, Interview_Process_Model.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }

            // Data is passed into search text box

            Thread.Sleep(2000);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.ID_paginate_regReqList_filter), kwm._WDWait);
            kwm.sendTextXPathOnly(WDriver, KeyWords.ID_paginate_regReqList_filter, Interview_Process_Model.str_Select_Statuslist);
            //try
            //{
            //    Thread.Sleep(2000);
            //    WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).Clear();

            //    WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).SendKeys(Interview_Process_Model.str_Select_Statuslist);
            //}
            //catch
            //{
            //    try
            //    {
            //        WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).Clear();
            //        WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).SendKeys(Interview_Process_Model.str_Select_Statuslist);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //}

            // After seraching, requirement number  click
            Thread.Sleep(2000);
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 30);//new wait written
            kwm.waitForElementToBeClickable(WDriver, By.LinkText(Interview_Process_Model.str_Select_Statuslist), kwm._WDWait);

            //  WDriver.FindElement(By.LinkText(Interview_Process_Model.str_Select_Statuslist)).Click();

            kwm.jsClick(WDriver, KeyWords.locator_XPath, "//a[contains(text(),'" + Interview_Process_Model.str_Select_Statuslist + "')]");
            //Loading message
            for (int z = 1; z < 500; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id("loading-message")).Displayed;
                }
                catch
                {
                    strValue = true;
                }

                //  Console.WriteLine("z -----> " + z);
                //  Console.WriteLine("strValue -----> " + strValue);
                if (!strValue)
                {
                    break;
                }
                Thread.Sleep(1000);
            }
            //kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//a[contains(text(),'" + Interview_Process_Model.str_Link_ViewCandidates + "')]");
            //View candidate link click

            string strSubLevel = "";
            objCommonMethods.SaveScreenShot_EachPage(WDriver, Interview_Process_Model.strClientName + "_");
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, Interview_Process_Model.str_Link_ViewCandidates);

            try
            {

                results = kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[@class='reqCandidate']//a[contains(normalize-space(),'" + Interview_Process_Model.str_Link_ViewCandidates + "')]");
            }
            catch (Exception)
            {

                try
                {
                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[@class='reqCandidate']//a[contains(normalize-space(),'" + Interview_Process_Model.str_Link_ViewCandidates + "')]");
                }
                catch (Exception)
                {

                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given View Candidate Text not find " + Interview_Process_Model.str_Link_ViewCandidates;
                    return results;
                }
            }


            //results = kwm.jsClick(WDriver, KeyWords.locator_XPath, "//a[contains(text(),'" + Interview_Process_Model.str_Link_ViewCandidates + "')]");
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Interview_Process_Model.str_Link_ViewCandidates, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                objCommonMethods.Action_Page_Down_javascriptexecutor(WDriver);
                Thread.Sleep(1000);

                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Interview_Process_Model.str_Link_ViewCandidates, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_Txt_CandidateName), kwm._WDWait);
            Thread.Sleep(1000);
            kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_CandidateName, Interview_Process_Model.str_Txt_CandidateName);

            Thread.Sleep(1000);

            // Search Candidate Name
            //if (Interview_Process_Model.str_Txt_CandidateName != "")
            //{
            //    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_CandidateName)).Clear();

            //    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_CandidateName)).SendKeys(Interview_Process_Model.str_Txt_CandidateName);
            //}

            Thread.Sleep(1000);

            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_Txt_CandidateName), kwm._WDWait);

            string strXpath_CandidateNameLink = "//*[@id='HistoryTableViewCandidate']//td//a[text()[normalize-space()= '" + Interview_Process_Model.str_Txt_CandidateName + "']]";
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, strXpath_CandidateNameLink);
            //Candidate name click			
            kwm.click(WDriver, KeyWords.locator_XPath, strXpath_CandidateNameLink);
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);

            // Click on Candidate Name
            //if (Interview_Process_Model.str_Txt_CandidateName != "")
            //    objCommonMethods.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, Interview_Process_Model.str_Txt_CandidateName);
            //    try
            //    {

            //        WDriver.FindElement(By.LinkText(Interview_Process_Model.str_Txt_CandidateName)).Click();
            //    }
            //    catch
            //    {
            //        Thread.Sleep(100);
            //        try
            //        {
            //            WDriver.FindElement(By.LinkText(Interview_Process_Model.str_Txt_CandidateName)).Click();
            //        }
            //        catch
            //        {
            //            // Console.WriteLine(bFlag);
            //            results.Result1 = KeyWords.Result_FAIL;
            //            results.ErrorMessage = "The given candidate name not find " + Interview_Process_Model.str_Txt_CandidateName;
            //            return results;
            //        }
            //    }


            // To check Request Interview link is displaying
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_List_listMenu1))));
            }
            catch
            {
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "Action list is not displayed", 3);
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_List_listMenu1)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            // To click on Request Interview link 

            //string strSubLevel = "";
            string strSubLevel1 = "";
            string strXpath_ListMenu = "//*[@id='listMenu1']//li[text()[normalize-space()= '" + Interview_Process_Model.str_Link_Withdrawcandidate + "']]";
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, strXpath_ListMenu);
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Interview_Process_Model.str_Link_Withdrawcandidate, strSubLevel1);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Interview_Process_Model.str_Link_Withdrawcandidate, strSubLevel1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }







            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_Candidate_Int_DialogWindow))));
            }
            catch
            {

            }

            //Withdraw Reason
            if (Interview_Process_Model.str_Txt_WithdrawReason_reasonid != "")
            {
                results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_WithdrawReason_reasonid);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Txt_WithdrawReason_reasonid))); //Locating select list
                    se.SelectByIndex(2);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_WithdrawReason_reasonid, Interview_Process_Model.str_Txt_WithdrawReason_reasonid);
                    }
                }
            }


            //Comment*
            if (Interview_Process_Model.str_Txt_Comment_txtComments != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Comment_txtComments, Interview_Process_Model.str_Txt_Comment_txtComments, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }



            objCommonMethods.Action_Page_Down(WDriver);
            //Withdraw button
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_class, KeyWords.locator_class_button, Interview_Process_Model.str_Btn_RequestInterview);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(3000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_class_button, Interview_Process_Model.str_Btn_RequestInterview);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            // To maintain error log messages in log files
            objCommonMethods.SaveScreenShot_EachPage(WDriver, Interview_Process_Model.strClientName + "_");
            results = kwm.Error_Msg_Read_Submit_Resume_details(WDriver, "//*[@" + KeyWords.locator_ID + "='ulMspUserError']/li");

            //results = kwm.Error_Msg_Read_Submit_Resume_details(WDriver, "//div[@" + KeyWords.locator_ID + "= KeyWords.ID_Error_Valmessages]/div/ul/li");

            if (results.Result1 == KeyWords.Result_PASS)
            {
                if (results.ErrorMessage != "")
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    return results;
                }
            }

            Thread.Sleep(500);

            // Confirmation popup with YES/NO
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Interview_Process_Model.str_Btn_Yes_Action_ReqInt);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(3000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Interview_Process_Model.str_Btn_Yes_Action_ReqInt);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            // Click on OK button
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Interview_Process_Model.str_Btn_OK_ReqInt);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(13000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Interview_Process_Model.str_Btn_OK_ReqInt);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(15000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Interview_Process_Model.str_Btn_OK_ReqInt);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }

            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage1 = KeyWords.MSG_str_Request_Interview_Done;
            //  results.ErrorMessage = "Invoice Batch created Successfully done  -->  " + strBatchNumberCreated;
            return results;
        }

    }
}
