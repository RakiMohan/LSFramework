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
    //[TestClass]
    public class Confirm_Interview
    {
        public Result Confirm_Int(IWebDriver WDriver, DataRow Confirm_Interview)
        {
            ReadExcel ReadExcelHelper = new ReadExcel();
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            // Rate_Change objRateChange = new Rate_Change();

            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            ConfirmInterviewModel Confrim_Interview_Model = createRequirementRepository.GetConfirmInterviewModel(Confirm_Interview);
            //SubmitCandidateAddResume submitCandidateAddResume = createRequirementRepository.GetSubmitCandidateAddResumeData(Confirm_Interview);


            //CLient selection
            results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Confrim_Interview_Model.strClientName);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Confrim_Interview_Model.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, Confrim_Interview_Model.strClientName + "_");
            //submenu click

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Confrim_Interview_Model.strMainMenuLink, Confrim_Interview_Model.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Confrim_Interview_Model.strMainMenuLink, Confrim_Interview_Model.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }

            // Status list
            //if (Confrim_Interview_Model.str_Select_Statuslist != "")
            //{
            //    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Statuslist, Confrim_Interview_Model.str_Select_Statuslist);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        try
            //        {
            //            SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Select_Statuslist))); //Locating select list
            //            se.SelectByIndex(0);
            //        }
            //        catch
            //        {
            //            //
            //        }
            //    }
            //    Thread.Sleep(100);
            //   // WDriver.FindElement(By.Id(KeyWords.ID_Btn_SearchBtn)).Click();
            //    Thread.Sleep(1000);
            //}


            // Data is passed into search text box
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 30);
            try
            {
                Thread.Sleep(3000);
                kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_paginate_regReqList_filter), kwm._WDWait);
                WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).Clear();

                WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).SendKeys(Confrim_Interview_Model.str_Txt_ReqNumber);
            }
            catch
            {
                try
                {
                    WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).Clear();
                    WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).SendKeys(Confrim_Interview_Model.str_Txt_ReqNumber);
                }
                catch
                {
                    //
                }
            }

            // After seraching, requirement number  click
            Thread.Sleep(2000);
            // WDriver.FindElement(By.LinkText(Confrim_Interview_Model.str_Txt_ReqNumber)).Click();

            Thread.Sleep(2000);
            // WDriver.FindElement(By.LinkText(Confrim_Interview_Model.str_Txt_ReqNumber)).Click();
            kwm.waitForElementToBeClickable(WDriver, By.LinkText(Confrim_Interview_Model.str_Txt_ReqNumber), kwm._WDWait);
            results = kwm.click(WDriver, KeyWords.locator_LinkText, Confrim_Interview_Model.str_Txt_ReqNumber);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.click(WDriver, KeyWords.locator_LinkText, Confrim_Interview_Model.str_Txt_ReqNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(2000);
                    results = kwm.click(WDriver, KeyWords.locator_LinkText, Confrim_Interview_Model.str_Txt_ReqNumber);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(2000);
                        results = kwm.click(WDriver, KeyWords.locator_LinkText, Confrim_Interview_Model.str_Txt_ReqNumber);
                    }

                }
                return results;
            }
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

            //View candidate link click
            results = kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//a[contains(text(),'" + Confrim_Interview_Model.str_Link_View_Candidates + "')]");
            
            //string strSubLevel = "./label";
           // string strSubLevel = "";
            objCommonMethods.SaveScreenShot_EachPage(WDriver, Confrim_Interview_Model.strClientName + "_");
            results = kwm.jsClick(WDriver, KeyWords.locator_XPath, "//a[contains(text(),'" + Confrim_Interview_Model.str_Link_View_Candidates + "')]");
            //results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Confrim_Interview_Model.str_Link_View_Candidates, strSubLevel);
            //if (results.Result1 == KeyWords.Result_FAIL)
            //{
            //    objCommonMethods.Action_Page_Down(WDriver);
            //    Thread.Sleep(5000);
            //    results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Confrim_Interview_Model.str_Link_View_Candidates, strSubLevel);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        return results;
            //    }
            //}
            for (int z = 1; z < 1000; z++)
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
                Thread.Sleep(100);
            }


            Thread.Sleep(1000);

            // Search Candidate Name
            if (Confrim_Interview_Model.str_Txt_CandidateName != "")
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.XPath(KeyWords.Xpath_Txt_CandidateName))));
                WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_CandidateName)).Clear();
                kwm.sendText_clr(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Txt_CandidateName, Confrim_Interview_Model.str_Txt_CandidateName);

             //   WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_CandidateName)).SendKeys(Confrim_Interview_Model.str_Txt_CandidateName);
                kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Txt_CandidateName, Confrim_Interview_Model.str_Txt_CandidateName, false);
            }

            Thread.Sleep(1000);



            // Click on Candidate Name
            if (Confrim_Interview_Model.str_Txt_CandidateName != "")
                try
                {
                    WDriver.FindElement(By.LinkText(Confrim_Interview_Model.str_Txt_CandidateName)).Click();
                }
                catch
                {
                    Thread.Sleep(100);
                    try
                    {
                        kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, Confrim_Interview_Model.str_Txt_CandidateName);
                        Thread.Sleep(1000);
                        WDriver.FindElement(By.PartialLinkText(Confrim_Interview_Model.str_Txt_CandidateName)).Click();
                    }
                    catch
                    {
                        // Console.WriteLine(bFlag);
                        results.Result1 = KeyWords.Result_FAIL;
                        results.ErrorMessage = "The given candidate name not find " + Confrim_Interview_Model.str_Txt_CandidateName;
                        return results;
                    }
                }



            Thread.Sleep(1000);




            // To check Confirm Interview link is displaying
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

            // To click on Confirm Interview link

            string strSubLevel1 = "";
            // string strSubLevel = "./label";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Confrim_Interview_Model.str_Link_ConfirmInterview, strSubLevel1);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                //added by pradeep
                Thread.Sleep(5000);
                objCommonMethods.Action_Page_Down(WDriver);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Confrim_Interview_Model.str_Link_ConfirmInterview, strSubLevel1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Confrim_Interview_Model.str_Link_ConfirmInterview, strSubLevel1);
                    return results;
                }
                //end

            }

            // Confirm Interview Window
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_Candidate_Int_DialogWindow))));
            }
            catch
            {
            }

            // Requested Interviews
            try
            {
                SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Txt_Requested_Interview))); //Locating select list
                se.SelectByIndex(0);
            }
            catch
            {
                //
            }

            // Confirmed interview Date/Time
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FirChoice);

            if (Confrim_Interview_Model.str_Txt_Confirm_IntDate != "")
            {
                
                 if (results.Result1 == KeyWords.Result_FAIL)
                 {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Confirmed_IntDate, Confrim_Interview_Model.str_Txt_Confirm_IntDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.Select_End_Date_From_Picker(WDriver, Confrim_Interview_Model.str_Txt_Confirm_IntDate);
                }
                 }
            }
            else
            {
                var today = DateTime.Now;
                var tomorrow = today.AddDays(1);
                DateTime date = tomorrow;
                Confrim_Interview_Model.str_Txt_Confirm_IntDate = date.ToString("MM/dd/yyyy");
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_SecChoice, Confrim_Interview_Model.str_Txt_Confirm_IntDate, false);
            }
            // Select Time
            if (Confrim_Interview_Model.str_Select_SupplierTime != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_TimeofInterview, Confrim_Interview_Model.str_Select_SupplierTime);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Txt_TimeofInterview))); //Locating select list
                        se.SelectByIndex(3);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            // Select Zone
            if (Confrim_Interview_Model.str_Select_SupplierZone != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ZoneofInterview, Confrim_Interview_Model.str_Select_SupplierZone);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Txt_ZoneofInterview))); //Locating select list
                        se.SelectByIndex(3);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            // Primary Phone 
            if (Confrim_Interview_Model.str_Txt_PrimaryPhone != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_PmyPhone, Confrim_Interview_Model.str_Txt_PrimaryPhone, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            // Alternate Phone 
            if (Confrim_Interview_Model.str_Txt_SecondaryPhone != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_SecPhone, Confrim_Interview_Model.str_Txt_SecondaryPhone, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            // Comment
            if (Confrim_Interview_Model.str_Txt_Sche_Comment != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ConfirmInt_Comment, Confrim_Interview_Model.str_Txt_Sche_Comment, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);

            // Confirm Interview button
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_class, KeyWords.locator_class_button, Confrim_Interview_Model.str_Btn_ConfirmInterview);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(3000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_class_button, Confrim_Interview_Model.str_Btn_ConfirmInterview);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            // To maintain error log messages in log files
            objCommonMethods.SaveScreenShot_EachPage(WDriver, Confrim_Interview_Model.strClientName + "_");
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
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Confrim_Interview_Model.str_Btn_Yes_Action_ConfirmInt);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(3000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Confrim_Interview_Model.str_Btn_Yes_Action_ConfirmInt);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            // Click on OK button
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Confrim_Interview_Model.str_Btn_OK_ConfirmInt);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(13000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Confrim_Interview_Model.str_Btn_OK_ConfirmInt);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(15000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, Confrim_Interview_Model.str_Btn_OK_ConfirmInt);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }

            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_str_Confirm_Interview_Done;
            //  results.ErrorMessage = "Invoice Batch created Successfully done  -->  " + strBatchNumberCreated;
            return results;
        }

    }
}
