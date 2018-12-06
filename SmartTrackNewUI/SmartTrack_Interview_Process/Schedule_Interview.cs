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
    //  [TestClass]
    public class Schedule_Interview
    {
        public Result Sche_Interview(IWebDriver WDriver, DataRow Schedule_Interview)
        {
            ReadExcel ReadExcelHelper = new ReadExcel();
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            // Rate_Change objRateChange = new Rate_Change();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 30);
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            ScheduleInterviewModel Schedule_Interview_Model = createRequirementRepository.GetScheduleInterviewModel(Schedule_Interview);
            // SubmitCandidateAddResume submitCandidateAddResume = createRequirementRepository.GetSubmitCandidateAddResumeData(Schedule_Interview);

            objCommonMethods.SaveScreenShot_EachPage(WDriver, Schedule_Interview_Model.strClientName + "_");

            //CLient selection
            Boolean bFlagDropDwon = false;
            try
            {
                bFlagDropDwon = WDriver.FindElement(By.XPath(KeyWords.XPath_supplierMenu_ClientDropDown)).Enabled;
            }
            catch
            {
                bFlagDropDwon = false;
            }
            if (bFlagDropDwon)
            {
                results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Schedule_Interview_Model.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //Thread.Sleep(000);
                    results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Schedule_Interview_Model.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }
            // Select Main & Sub Menu's
            objCommonMethods.SaveScreenShot_EachPage(WDriver, Schedule_Interview_Model.strClientName + "_");

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Schedule_Interview_Model.strMainMenuLink, Schedule_Interview_Model.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Schedule_Interview_Model.strMainMenuLink, Schedule_Interview_Model.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }



            // Search Requirement number
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_Txt_SearchReq))));
                Thread.Sleep(2000);
                WDriver.FindElement(By.Id(KeyWords.ID_Txt_SearchReq)).Clear();

                WDriver.FindElement(By.Id(KeyWords.ID_Txt_SearchReq)).SendKeys(Schedule_Interview_Model.str_Txt_ReqNumber);
            }
            catch
            {
                try
                {
                    WDriver.FindElement(By.Id(KeyWords.ID_Txt_SearchReq)).Clear();
                    WDriver.FindElement(By.Id(KeyWords.ID_Txt_SearchReq)).SendKeys(Schedule_Interview_Model.str_Txt_ReqNumber);
                }
                catch
                {
                    //
                }
            }
            Thread.Sleep(1000);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, Schedule_Interview_Model.str_Txt_ReqNumber);
            // Click on Requirement number
            if (Schedule_Interview_Model.str_Txt_ReqNumber != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_LinkText, Schedule_Interview_Model.str_Txt_ReqNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//td[@class=' wrapNormal']//a[contains(text(),'" + Schedule_Interview_Model.str_Txt_ReqNumber + "')]");
                    results = kwm.click(WDriver, KeyWords.locator_LinkText, Schedule_Interview_Model.str_Txt_ReqNumber);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results.Result1 = KeyWords.Result_FAIL;
                        results.ErrorMessage = "The given CW number not find " + Schedule_Interview_Model.str_Txt_ReqNumber;
                        return results;
                    }
                }

            }
            else
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "The given CW number is empty ";
                return results;
            }



            // To check Submitted candidates link is displaying
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.XPath(KeyWords.Xpath_Link_SubmittedCand))));
            }
            catch
            {
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "Submitted candidates link is not displayed", 3);
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.XPath(KeyWords.Xpath_Link_SubmittedCand)).Displayed)
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

            // To click on Submitted candidates link
            string strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_Link_SubmittedCandidate, Schedule_Interview_Model.str_Link_Subcaniddates, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_Link_SubmittedCandidate, Schedule_Interview_Model.str_Link_Subcaniddates, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            // Search Candidate Name
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_Txt_SearchCand))));
                Thread.Sleep(2000);
                WDriver.FindElement(By.Id(KeyWords.ID_Txt_SearchCand)).Clear();

                WDriver.FindElement(By.Id(KeyWords.ID_Txt_SearchCand)).SendKeys(Schedule_Interview_Model.str_Txt_CandidateName);
            }
            catch
            {
                try
                {
                    WDriver.FindElement(By.Id(KeyWords.ID_Txt_SearchCand)).Clear();
                    WDriver.FindElement(By.Id(KeyWords.ID_Txt_SearchCand)).SendKeys(Schedule_Interview_Model.str_Txt_CandidateName);
                }
                catch
                {
                    //
                }
            }
            Thread.Sleep(200);



            // Click on Candidate Name
            if (Schedule_Interview_Model.str_Txt_CandidateName != "")
                try
                {
                    WDriver.FindElement(By.LinkText(Schedule_Interview_Model.str_Txt_CandidateName)).Click();
                }
                catch
                {
                    Thread.Sleep(100);
                    try
                    {
                        WDriver.FindElement(By.PartialLinkText(Schedule_Interview_Model.str_Txt_CandidateName)).Click();
                    }
                    catch
                    {
                        // Console.WriteLine(bFlag);
                        results.Result1 = KeyWords.Result_FAIL;
                        results.ErrorMessage = "The given candidate name not find " + Schedule_Interview_Model.str_Txt_CandidateName;
                        return results;
                    }
                }


            // To check Schedule Interview link is displaying
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

            // To click on Schedule interview link

            string strSubLevel1 = "";
            // string strSubLevel = "./label";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Schedule_Interview_Model.str_Link_ScheInterview, strSubLevel1);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Schedule_Interview_Model.str_Link_ScheInterview, strSubLevel1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            // Schedule Interview Window
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_Candidate_Int_DialogWindow))));
            }
            catch
            {
            }

            // Interview Accepted(Radio button)
            if (Schedule_Interview_Model.str_Radio_Interview_Accepted != "")
            {
                if (Schedule_Interview_Model.str_Radio_Interview_Accepted.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(WDriver, "AcceptedRadio", "1");

                    // Confirm Interview Schedule
                    if (Schedule_Interview_Model.str_Radio_ConfirmInterview != "")
                    {
                        if (Schedule_Interview_Model.str_Radio_ConfirmInterview.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = objCommonMethods.Select_Radio_Button(WDriver, "ConfirmInterview", "1");

                        }

                        else
                        {
                            Thread.Sleep(1000);
                            results = objCommonMethods.Select_Radio_Button(WDriver, "ConfirmInterview", "3");
                            Thread.Sleep(1000);

                            //Date
                            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Schedule_ScheduleDate);

                            if (Schedule_Interview_Model.str_ScheduleDate != "")
                            {
                                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today);
                                if (results.Result1 == KeyWords.Result_FAIL)
                                {
                                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Schedule_ScheduleDate, Schedule_Interview_Model.str_ScheduleDate, false);
                                    if (results.Result1 == KeyWords.Result_FAIL)
                                    {
                                        //return results;
                                    }
                                }
                            }

                            //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ScheduleDate);
                            //DateTime today = DateTime.Now;
                            //DateTime date = today.AddDays(1);
                            //Schedule_Interview_Model.str_ScheduleDate = date.ToString("MM/dd/yyyy");

                            //  results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_ScheFirChoice, Schedule_Interview_Model.str_ScheduleDate, false);
                            Thread.Sleep(2000);

                            // Select Time1
                            if (Schedule_Interview_Model.str_Select_Time1 != "")
                            {
                                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_ScheTime, Schedule_Interview_Model.str_Select_Time1);
                                if (results.Result1 == KeyWords.Result_FAIL)
                                {
                                    try
                                    {
                                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Select_ScheTime))); //Locating select list
                                        se.SelectByIndex(3);
                                    }
                                    catch
                                    {
                                        //
                                    }
                                }
                            }


                            // Select Zone1
                            if (Schedule_Interview_Model.str_Select_Zone1 != "")
                            {
                                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_ScheZone, Schedule_Interview_Model.str_Select_Zone1);
                                if (results.Result1 == KeyWords.Result_FAIL)
                                {
                                    try
                                    {
                                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Select_ScheZone))); //Locating select list
                                        se.SelectByIndex(3);
                                    }
                                    catch
                                    {
                                        //
                                    }
                                }
                            }

                            //Time Zone

                            if (Schedule_Interview_Model.str_Select_TimeZone_ScheduleZone != "")
                            {
                                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_TimeZone_ScheduleZone, Schedule_Interview_Model.str_Select_TimeZone_ScheduleZone);
                                if (results.Result1 == KeyWords.Result_FAIL)
                                {
                                    try
                                    {
                                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Select_TimeZone_ScheduleZone))); //Locating select list
                                        se.SelectByIndex(3);
                                    }
                                    catch
                                    {
                                        //
                                    }
                                }
                            }



                            //  kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_ScheduleTime);

                            //if (Interview_Process_Model.str_Date_FirChoice != "")
                            //{
                            //    //results = kwm.Select_End_Date_From_Picker(WDriver, createRequirementModel.strDateAssignmentEnd);
                            //    // if (results.Result1 == KeyWords.Result_FAIL)
                            //    // {
                            //    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FirChoice, Interview_Process_Model.str_Date_FirChoice, false);
                            //    if (results.Result1 == KeyWords.Result_FAIL)
                            //    {
                            //        //return results;
                            //    }
                            //    // }
                            //}
                            //else
                            //{
                            //    DateTime date = DateTime.Today;
                            //    Interview_Process_Model.str_Date_FirChoice = date.ToString("MM/dd/yyyy");
                            //    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FirChoice, Interview_Process_Model.str_Date_FirChoice, false);

                            //}

                        }

                    }
                    else
                    {

                        results = objCommonMethods.Select_Radio_Button(WDriver, "ConfirmInterview", "2");
                    }
                }

                else
                {
                    results = objCommonMethods.Select_Radio_Button(WDriver, "AcceptedRadio", "0");
                    Thread.Sleep(1000);
                    // Reject reason
                    SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Select_RejectReason))); //Locating select list
                    se.SelectByIndex(1);
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(WDriver, "AcceptedRadio", "0");
                Thread.Sleep(1000);
                // Reject reason
                SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Select_RejectReason))); //Locating select list
                se.SelectByIndex(1);

            }


            Thread.Sleep(2000);
            // Primary Phone
            if (Schedule_Interview_Model.str_Txt_PrimaryPhone != "")
            {

                results = kwm.sendText_clr_backspace_phone(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_PrimaryPhone, Schedule_Interview_Model.str_Txt_PrimaryPhone);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
            Thread.Sleep(2000);
            // Alternate Phone
            if (Schedule_Interview_Model.str_Txt_SecondaryPhone != "")
            {

                results = kwm.sendText_clr_backspace_phone(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AlternatePhone, Schedule_Interview_Model.str_Txt_SecondaryPhone);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            // Comment
            if (Schedule_Interview_Model.str_Txt_Sche_Comment != "")
            {

                results = kwm.sendText_clr_backspace(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_SchInterview_Comment, Schedule_Interview_Model.str_Txt_Sche_Comment);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);

            // Schedule Interview button
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_class, KeyWords.locator_class_button, Schedule_Interview_Model.str_Btn_ScheduleInterview);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(3000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_class_button, Schedule_Interview_Model.str_Btn_ScheduleInterview);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    WDriver.FindElement(By.Id(KeyWords.ID_Btn_RejectInterview)).Click();

                }
            }

            // To maintain error log messages in log files
            objCommonMethods.SaveScreenShot_EachPage(WDriver, Schedule_Interview_Model.strClientName + "_");
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


            // Confirmation popup with YES/NO
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Schedule_Interview_Model.str_Btn_Yes_Action_ScheInt);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(3000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Schedule_Interview_Model.str_Btn_Yes_Action_ScheInt);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            // Click on OK button
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Schedule_Interview_Model.str_Btn_OK_ScheInt);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(13000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Schedule_Interview_Model.str_Btn_OK_ScheInt);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(15000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Schedule_Interview_Model.str_Btn_OK_ScheInt);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }

            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage1 = KeyWords.MSG_str_Schedule_Interview_Done;
            //  results.ErrorMessage = "Invoice Batch created Successfully done  -->  " + strBatchNumberCreated;
            return results;
        }

    }
}
