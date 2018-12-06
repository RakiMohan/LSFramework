
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;
using System.Configuration;
using System.Net;
using System.Collections;
using OpenQA.Selenium.Interactions;
using CommonFiles;
using SmartTrack.DataAccess.Repository;
using SmartTrack.DataAccess.Models;
using RelevantCodes.ExtentReports;

namespace SmartTrack_Automation
{
    // [TestClass]

    public class SubmitToManager
    {
        public Result SubmitToManager_Method(IWebDriver WDriver, DataRow SubmitToManager_Data, int MspExecutionNo)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };


            SubmitManagerRepository submitmanagerRepository = new SubmitManagerRepository();
            SubmitToManagerModel submitToManagerModel = submitmanagerRepository.GetSubmitToManagerData(SubmitToManager_Data);
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            //Client selection
            listExistClients = new List<string>() { Constants.Discover };
            if (listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }
            listExistClients = new List<string>() { Constants.Discover };
            if (!listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_RequistionSearch_regReqList_filter), kwm._WDWait);

            kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_RequistionSearch_regReqList_filter, submitToManagerModel.str_Link_ReqNumber, false);
            Thread.Sleep(1000);
            //objCommonMethods.Action_Button_Tab(WDriver);
            kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);

            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);
            Thread.Sleep(1000);
            //Requirement number click
            kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            //View Submitted Candidates link click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_Link_ActionList_ViewCandidates);
            objCommonMethods.Action_Page_Down(WDriver);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            string strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);

            }

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_ViewCandidatename), kwm._WDWait);
            results = kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Txt_search_Viewcandidatename, submitToManagerModel.str_CandidateName, false);

            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_ViewCandidatename), kwm._WDWait);

            //Candidate name click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_CandidateName);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_link_ViewCandidatename);

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ExpandAll_tabsAll);
            //objCommonMethods._CheckRehireEligibility(WDriver, kwm);
            Thread.Sleep(5000);
            objCommonMethods.Action_Page_Down(WDriver);
            objCommonMethods.Action_Page_Down(WDriver);
            string strXpath_ListMenu = "//*[@id='listMenu1']//li[text()[normalize-space()= '" + submitToManagerModel.str_Link_ActionList_SubmitToManager + "']]";
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, strXpath_ListMenu);
            //     kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_Link_ActionList_SubmitToManager);
            objCommonMethods.Action_Page_Down(WDriver);
            objCommonMethods.Action_Page_Down(WDriver);
            Thread.Sleep(1000);
            //Submit Manager
            strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_SubmitToManager, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_SubmitToManager, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Txt_SubmittothefollowingManagers_txtManager), kwm._WDWait);
            //Submit to Manager click

            results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Button_SubmitToManager);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Button_SubmitToManager);
            }
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_SubmitManager_Popup_Yes), kwm._WDWait);
            //Yes

            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_SubmitManager_Popup_Yes);


            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");

            //OK
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_SubmitManager_Popup_OK), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_SubmitManager_Popup_OK), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_SubmitManager_Popup_OK);



            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_strSubmitToManagerSuccessfully;
            return results;
        }

        public Result EditCandidateInfo(IWebDriver WDriver, DataRow SubmitToManager_Data, int MspExecutionNo)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };

            SubmitManagerRepository submitmanagerRepository = new SubmitManagerRepository();
            SubmitToManagerModel submitToManagerModel = submitmanagerRepository.GetSubmitToManagerData(SubmitToManager_Data);
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");

            results = Navigation_To_CandidateDetails(WDriver, SubmitToManager_Data, MspExecutionNo);


            // Click on Eidt Candidate Info link
            String strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, "Edit Candidate Info", strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);
            }


            // Wait until Canidadet info page displays
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_txt_LastName_LastName), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_txt_LastName_LastName), kwm._WDWait);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            // Update middle name
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_MiddleName_MiddleName, "mName", false);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(1000);
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_MiddleName_MiddleName, "mName", false);
            }

            ////upload resume
            //if (submitToManagerModel.str_UploadResume != "")
            //{

            //    if (File.Exists(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitToManagerModel.str_UploadResume))
            //    {

            //        try
            //        {
            //            //String resumeId = WDriver.FindElement(By.XPath("//label[@id='uploadResumeLabel']/following::div/a")).GetAttribute("id");


            //                kwm.click(WDriver, KeyWords.locator_ID, "btnresumeupload");


            //                WDriver.FindElement(By.Name(KeyWords.NAME_Link_qqfile)).SendKeys(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitToManagerModel.str_UploadResume);
            //                Thread.Sleep(1000);
            //                System.Windows.Forms.SendKeys.SendWait("{ESC}");
            //                Thread.Sleep(1000);

            //        }
            //        catch (Exception uplod)
            //        {
            //            string strUploaderror = uplod.Message;
            //        }
            //    }
            //    else
            //    {
            //        objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "The given resume path not find" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitToManagerModel.str_UploadResume, 3);
            //    }

            //}


            // Click on Save button
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_Save_btnSubmit);


            // Click on OK buttton
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_btn_OK), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_btn_OK), kwm._WDWait);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_btn_OK);

            // Wait until Edit candidate info link displays
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_ActionList), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_ActionList), kwm._WDWait);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            // Verify middle name furction in candidate details page
            results = kwm.GetText_Xpath(WDriver, KeyWords.Xpath_CandidateNameLink);
            String[] CandidateName = results._Var.Split(' ');
            if (CandidateName[2] == "mName")
            {
                // both are same and middle name displayed as expected.
            }
            else
            {
                results.Result1 = KeyWords.Result_FAIL;
                return results;
            }
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");

            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_strSubmitToManagerSuccessfully;
            return results;
        }

        public Result Navigation_To_CandidateDetails(IWebDriver WDriver, DataRow SubmitToManager_Data, int MspExecutionNo)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };

            SubmitManagerRepository submitmanagerRepository = new SubmitManagerRepository();
            SubmitToManagerModel submitToManagerModel = submitmanagerRepository.GetSubmitToManagerData(SubmitToManager_Data);
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            //Client selection
            listExistClients = new List<string>() { Constants.Discover };
            if (listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }
            listExistClients = new List<string>() { Constants.Discover };
            if (!listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_RequistionSearch_regReqList_filter), kwm._WDWait);

            kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_RequistionSearch_regReqList_filter, submitToManagerModel.str_Link_ReqNumber, false);
            Thread.Sleep(1000);
            //objCommonMethods.Action_Button_Tab(WDriver);
            kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);

            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);
            Thread.Sleep(1000);
            //Requirement number click
            kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            //View Submitted Candidates link click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_Link_ActionList_ViewCandidates);
            objCommonMethods.Action_Page_Down(WDriver);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            string strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);

            }

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_ViewCandidatename), kwm._WDWait);
            results = kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Txt_search_Viewcandidatename, submitToManagerModel.str_CandidateName, false);

            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_ViewCandidatename), kwm._WDWait);

            //Candidate name click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_CandidateName);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_link_ViewCandidatename);

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ExpandAll_tabsAll);
            //objCommonMethods._CheckRehireEligibility(WDriver, kwm);
            Thread.Sleep(5000);


            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_strSubmitToManagerSuccessfully;
            return results;
        }


        public Result AddtoDoNotSubmitList_Method(IWebDriver WDriver, DataRow SubmitToManager_Data, int MspExecutionNo)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };


            SubmitManagerRepository submitmanagerRepository = new SubmitManagerRepository();
            SubmitToManagerModel submitToManagerModel = submitmanagerRepository.GetSubmitToManagerData(SubmitToManager_Data);
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            //Client selection
            listExistClients = new List<string>() { Constants.Discover };
            if (listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }
            listExistClients = new List<string>() { Constants.Discover };
            if (!listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_RequistionSearch_regReqList_filter), kwm._WDWait);

            kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_RequistionSearch_regReqList_filter, submitToManagerModel.str_Link_ReqNumber, false);
            Thread.Sleep(1000);
            //objCommonMethods.Action_Button_Tab(WDriver);
            kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);

            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);
            Thread.Sleep(1000);
            //Requirement number click
            kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            //View Submitted Candidates link click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_Link_ActionList_ViewCandidates);
            objCommonMethods.Action_Page_Down(WDriver);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            string strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);

            }

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_ViewCandidatename), kwm._WDWait);
            results = kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Txt_search_Viewcandidatename, submitToManagerModel.str_CandidateName, false);

            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_ViewCandidatename), kwm._WDWait);

            //Candidate name click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_CandidateName);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_link_ViewCandidatename);

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ExpandAll_tabsAll);
            //objCommonMethods._CheckRehireEligibility(WDriver, kwm);
            Thread.Sleep(5000);
            objCommonMethods.Action_Page_Down(WDriver);

            // Common Code


            // Add to Do Not Submit List Method
            string strXpath_ListMenu = "//*[@id='listMenu1']//li[text()[normalize-space()= '" + submitToManagerModel.str_Link_ActionList_AddtoDoNotSubmitList + "']]";
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, strXpath_ListMenu);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_Link_ActionList_AddtoDoNotSubmitList);
            objCommonMethods.Action_Page_Down(WDriver);
            Thread.Sleep(1000);
            // Add to Do Not Submit List
            strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_AddtoDoNotSubmitList, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_AddtoDoNotSubmitList, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            // Reason *
            kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Reason_ReasonId, submitToManagerModel.str_Select_Reason_ReasonId);

            // Comment *
            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_text_Comments_txtComments, submitToManagerModel.str_text_Comments_txtComments, false);

            // Add to Do Not Submit List_Button
            results = kwm.click(WDriver, KeyWords.locator_XPath, "//button[@class='btn btn-sm btn-primary'][text()[normalize-space()='" + submitToManagerModel.str_button_AddtoDoNotSubmitList + "']]");
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, "//button[@class='btn btn-sm btn-primary'][text()[normalize-space()='" + submitToManagerModel.str_button_AddtoDoNotSubmitList + "']]");
            }


            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_AddtoDoNotSubmitList_Popup_Yes), kwm._WDWait);
            //Yes
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_AddtoDoNotSubmitList_Popup_Yes);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            //OK
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_AddtoDoNotSubmitList_Popup_OK), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_AddtoDoNotSubmitList_Popup_OK), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_AddtoDoNotSubmitList_Popup_OK);

            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_strSubmitToManagerSuccessfully;
            return results;
        }

        public Result RecallfromDoNotSubmitList_Method(IWebDriver WDriver, DataRow SubmitToManager_Data, int MspExecutionNo)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };


            SubmitManagerRepository submitmanagerRepository = new SubmitManagerRepository();
            SubmitToManagerModel submitToManagerModel = submitmanagerRepository.GetSubmitToManagerData(SubmitToManager_Data);
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            //Client selection
            listExistClients = new List<string>() { Constants.Discover };
            if (listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }
            listExistClients = new List<string>() { Constants.Discover };
            if (!listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_RequistionSearch_regReqList_filter), kwm._WDWait);

            kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_RequistionSearch_regReqList_filter, submitToManagerModel.str_Link_ReqNumber, false);
            Thread.Sleep(1000);
            //objCommonMethods.Action_Button_Tab(WDriver);
            kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);

            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);
            Thread.Sleep(1000);
            //Requirement number click
            kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            //View Submitted Candidates link click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_Link_ActionList_ViewCandidates);
            objCommonMethods.Action_Page_Down(WDriver);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            string strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);

            }

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_ViewCandidatename), kwm._WDWait);
            results = kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Txt_search_Viewcandidatename, submitToManagerModel.str_CandidateName, false);

            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_ViewCandidatename), kwm._WDWait);

            //Candidate name click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_CandidateName);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_link_ViewCandidatename);

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ExpandAll_tabsAll);
            //objCommonMethods._CheckRehireEligibility(WDriver, kwm);
            Thread.Sleep(5000);
            objCommonMethods.Action_Page_Down(WDriver);

            // Common Code


            // Recall from Do Not Submit List Method
            string strXpath_ListMenu = "//*[@id='listMenu1']//li[text()[normalize-space()= '" + submitToManagerModel.str_Link_ActionList_RecallfromDoNotSubmitList + "']]";
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, strXpath_ListMenu);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_Link_ActionList_AddtoDoNotSubmitList);
            objCommonMethods.Action_Page_Down(WDriver);
            Thread.Sleep(1000);
            // Recall from Do Not Submit List
            strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_AddtoDoNotSubmitList, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_AddtoDoNotSubmitList, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            // Reason *
            kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Reason_ReasonId, submitToManagerModel.str_Select_Reason_ReasonId);

            // Comment *
            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_text_Comments_txtComments, submitToManagerModel.str_text_Comments_txtComments, false);

            // Add to Do Not Submit List_Button
            results = kwm.click(WDriver, KeyWords.locator_XPath, "//button[@class='btn btn-sm btn-primary'][text()[normalize-space()='" + submitToManagerModel.str_button_RecallfromDoNotSubmitList + "']]");
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, "//button[@class='btn btn-sm btn-primary'][text()[normalize-space()='" + submitToManagerModel.str_button_AddtoDoNotSubmitList + "']]");
            }


            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_RecallfromDoNotSubmitList_Popup_Yes), kwm._WDWait);
            //Yes
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_RecallfromDoNotSubmitList_Popup_Yes);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            //OK
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_RecallfromDoNotSubmitList_Popup_OK), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_RecallfromDoNotSubmitList_Popup_OK), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_RecallfromDoNotSubmitList_Popup_OK);

            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_strSubmitToManagerSuccessfully;
            return results;
        }

        public Result Feedback_Method(IWebDriver WDriver, DataRow SubmitToManager_Data, int MspExecutionNo)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };


            SubmitManagerRepository submitmanagerRepository = new SubmitManagerRepository();
            SubmitToManagerModel submitToManagerModel = submitmanagerRepository.GetSubmitToManagerData(SubmitToManager_Data);
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            //Client selection
            listExistClients = new List<string>() { Constants.Discover };
            if (listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }
            listExistClients = new List<string>() { Constants.Discover };
            if (!listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_RequistionSearch_regReqList_filter), kwm._WDWait);

            kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_RequistionSearch_regReqList_filter, submitToManagerModel.str_Link_ReqNumber, false);
            Thread.Sleep(1000);
            //objCommonMethods.Action_Button_Tab(WDriver);
            kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);

            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);
            Thread.Sleep(1000);
            //Requirement number click
            kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            //View Submitted Candidates link click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_Link_ActionList_ViewCandidates);
            objCommonMethods.Action_Page_Down(WDriver);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            string strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);

            }

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_ViewCandidatename), kwm._WDWait);
            results = kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Txt_search_Viewcandidatename, submitToManagerModel.str_CandidateName, false);

            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_ViewCandidatename), kwm._WDWait);

            //Candidate name click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_CandidateName);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_link_ViewCandidatename);

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ExpandAll_tabsAll);
            //objCommonMethods._CheckRehireEligibility(WDriver, kwm);
            Thread.Sleep(5000);
            objCommonMethods.Action_Page_Down(WDriver);

            // Common Code


            // Feedback Method
            string strXpath_ListMenu = "//*[@id='listMenu1']//li[text()[normalize-space()= '" + submitToManagerModel.str_Link_ActionList_Feedback + "']]";
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, strXpath_ListMenu);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_Link_ActionList_Feedback);
            objCommonMethods.Action_Page_Down(WDriver);
            Thread.Sleep(1000);
            // Click on Feedback 
            strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_Feedback, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_Feedback, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            // Reason *
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_btn_radio_Doesnotmeetmyrequirement, "//input[@name='rbfeedbackId' and @value='551']");

            // Comment *
            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_text_Comments_txtComments, submitToManagerModel.str_text_Comments_txtComments, false);

            // Add to Do Not Submit List_Button
            results = kwm.click(WDriver, KeyWords.locator_XPath, "//button[@class='btn btn-sm btn-primary'][text()[normalize-space()='" + submitToManagerModel.str_button_SendFeedback + "']]");
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, "//button[@class='btn btn-sm btn-primary'][text()[normalize-space()='" + submitToManagerModel.str_button_SendFeedback + "']]");
            }


            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_Feedback_Popup_Yes), kwm._WDWait);
            //Yes
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Feedback_Popup_Yes);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            //OK
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_Feedback_Popup_OK), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_Feedback_Popup_OK), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Feedback_Popup_OK);

            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_strSubmitToManagerSuccessfully;
            return results;
        }

        public Result ShortList_Method(IWebDriver WDriver, DataRow SubmitToManager_Data, int MspExecutionNo)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };


            SubmitManagerRepository submitmanagerRepository = new SubmitManagerRepository();
            SubmitToManagerModel submitToManagerModel = submitmanagerRepository.GetSubmitToManagerData(SubmitToManager_Data);
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            //Client selection
            listExistClients = new List<string>() { Constants.Discover };
            if (listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }
            listExistClients = new List<string>() { Constants.Discover };
            if (!listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_RequistionSearch_regReqList_filter), kwm._WDWait);

            kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_RequistionSearch_regReqList_filter, submitToManagerModel.str_Link_ReqNumber, false);
            Thread.Sleep(1000);
            //objCommonMethods.Action_Button_Tab(WDriver);
            kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);

            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);
            Thread.Sleep(1000);
            //Requirement number click
            kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            //View Submitted Candidates link click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_Link_ActionList_ViewCandidates);
            objCommonMethods.Action_Page_Down(WDriver);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            string strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);

            }

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_ViewCandidatename), kwm._WDWait);
            results = kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Txt_search_Viewcandidatename, submitToManagerModel.str_CandidateName, false);

            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_ViewCandidatename), kwm._WDWait);

            //Candidate name click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_CandidateName);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_link_ViewCandidatename);

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ExpandAll_tabsAll);
            //objCommonMethods._CheckRehireEligibility(WDriver, kwm);
            Thread.Sleep(5000);
            objCommonMethods.Action_Page_Down(WDriver);

            // Common Code


            // ShortList Method
            string strXpath_ListMenu = "//*[@id='listMenu1']//li[text()[normalize-space()= '" + submitToManagerModel.str_Link_ActionList_Shortlist + "']]";
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, strXpath_ListMenu);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_Link_ActionList_Shortlist);
            objCommonMethods.Action_Page_Down(WDriver);
            Thread.Sleep(1000);
            // Click on ShortList link 
            strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_Shortlist, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_Shortlist, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            // Shortlist_Button
            results = kwm.click(WDriver, KeyWords.locator_XPath, "//button[@class='btn btn-sm btn-primary'][text()[normalize-space()='" + submitToManagerModel.str_button_Shortlist + "']]");
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, "//button[@class='btn btn-sm btn-primary'][text()[normalize-space()='" + submitToManagerModel.str_button_Shortlist + "']]");
            }


            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_Shortlist_Popup_Yes), kwm._WDWait);
            //Yes
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Shortlist_Popup_Yes);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            //OK
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_Shortlist_Popup_OK), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_Shortlist_Popup_OK), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Shortlist_Popup_OK);

            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_strSubmitToManagerSuccessfully;
            return results;
        }

        public Result UnShortList_Method(IWebDriver WDriver, DataRow SubmitToManager_Data, int MspExecutionNo)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };


            SubmitManagerRepository submitmanagerRepository = new SubmitManagerRepository();
            SubmitToManagerModel submitToManagerModel = submitmanagerRepository.GetSubmitToManagerData(SubmitToManager_Data);
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            //Client selection
            listExistClients = new List<string>() { Constants.Discover };
            if (listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }
            listExistClients = new List<string>() { Constants.Discover };
            if (!listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_RequistionSearch_regReqList_filter), kwm._WDWait);

            kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_RequistionSearch_regReqList_filter, submitToManagerModel.str_Link_ReqNumber, false);
            Thread.Sleep(1000);
            //objCommonMethods.Action_Button_Tab(WDriver);
            kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);

            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);
            Thread.Sleep(1000);
            //Requirement number click
            kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            //View Submitted Candidates link click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_Link_ActionList_ViewCandidates);
            objCommonMethods.Action_Page_Down(WDriver);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            string strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);

            }

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_ViewCandidatename), kwm._WDWait);
            results = kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Txt_search_Viewcandidatename, submitToManagerModel.str_CandidateName, false);

            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_ViewCandidatename), kwm._WDWait);

            //Candidate name click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_CandidateName);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_link_ViewCandidatename);

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ExpandAll_tabsAll);
            //objCommonMethods._CheckRehireEligibility(WDriver, kwm);
            Thread.Sleep(5000);
            objCommonMethods.Action_Page_Down(WDriver);

            // Common Code


            // UnShortList Method
            string strXpath_ListMenu = "//*[@id='listMenu1']//li[text()[normalize-space()= '" + submitToManagerModel.str_Link_ActionList_UnShortlist + "']]";
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, strXpath_ListMenu);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_Link_ActionList_UnShortlist);
            objCommonMethods.Action_Page_Down(WDriver);
            Thread.Sleep(1000);
            // Click on ShortList link 
            strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_UnShortlist, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_UnShortlist, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            // Shortlist_Button
            results = kwm.click(WDriver, KeyWords.locator_XPath, "//button[@class='btn btn-sm btn-primary'][text()[normalize-space()='" + submitToManagerModel.str_button_UnShortlist + "']]");
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, "//button[@class='btn btn-sm btn-primary'][text()[normalize-space()='" + submitToManagerModel.str_button_UnShortlist + "']]");
            }


            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_UnShortlist_Popup_Yes), kwm._WDWait);
            //Yes
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_UnShortlist_Popup_Yes);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            //OK
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_UnShortlist_Popup_OK), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_UnShortlist_Popup_OK), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_UnShortlist_Popup_OK);

            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_strSubmitToManagerSuccessfully;
            return results;
        }

        public Result RequestResubmission_Method(IWebDriver WDriver, DataRow SubmitToManager_Data, int MspExecutionNo)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };


            SubmitManagerRepository submitmanagerRepository = new SubmitManagerRepository();
            SubmitToManagerModel submitToManagerModel = submitmanagerRepository.GetSubmitToManagerData(SubmitToManager_Data);
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            //Client selection
            listExistClients = new List<string>() { Constants.Discover };
            if (listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }
            listExistClients = new List<string>() { Constants.Discover };
            if (!listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_RequistionSearch_regReqList_filter), kwm._WDWait);

            kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_RequistionSearch_regReqList_filter, submitToManagerModel.str_Link_ReqNumber, false);
            Thread.Sleep(1000);
            //objCommonMethods.Action_Button_Tab(WDriver);
            kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);

            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);
            Thread.Sleep(1000);
            //Requirement number click
            kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            //View Submitted Candidates link click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_Link_ActionList_ViewCandidates);
            objCommonMethods.Action_Page_Down(WDriver);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            string strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);

            }

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_ViewCandidatename), kwm._WDWait);
            results = kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Txt_search_Viewcandidatename, submitToManagerModel.str_CandidateName, false);

            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_ViewCandidatename), kwm._WDWait);

            //Candidate name click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_CandidateName);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_link_ViewCandidatename);

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ExpandAll_tabsAll);
            //objCommonMethods._CheckRehireEligibility(WDriver, kwm);o
            Thread.Sleep(5000);
            objCommonMethods.Action_Page_Down(WDriver);

            // Common Code


            // Request Resubmission Method
            string strXpath_ListMenu = "//*[@id='listMenu1']//li[text()[normalize-space()= '" + submitToManagerModel.str_Link_ActionList_RequestResubmission + "']]";
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, strXpath_ListMenu);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_Link_ActionList_RequestResubmission);
            objCommonMethods.Action_Page_Down(WDriver);
            Thread.Sleep(1000);
            // Click on Request Resubmission link 
            strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_RequestResubmission, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_RequestResubmission, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            // Justification *
            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_text_Justification_txtComments, submitToManagerModel.str_text_Justification_txtComments, false);

            // Request Resubmission submit_Button
            results = kwm.click(WDriver, KeyWords.locator_XPath, "//button[@class='btn btn-sm btn-primary'][text()[normalize-space()='" + submitToManagerModel.str_button_RequestResubmission + "']]");
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, "//button[@class='btn btn-sm btn-primary'][text()[normalize-space()='" + submitToManagerModel.str_button_RequestResubmission + "']]");
            }



            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_RequestResubmission_Popup_Yes), kwm._WDWait);
            //Yes
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_RequestResubmission_Popup_Yes);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            //OK
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_UnShortlist_Popup_OK), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_UnShortlist_Popup_OK), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_UnShortlist_Popup_OK);

            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_strSubmitToManagerSuccessfully;
            return results;
        }

        public Result InitiateOnboarding_Method(IWebDriver WDriver, DataRow SubmitToManager_Data, int MspExecutionNo)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };


            SubmitManagerRepository submitmanagerRepository = new SubmitManagerRepository();
            SubmitToManagerModel submitToManagerModel = submitmanagerRepository.GetSubmitToManagerData(SubmitToManager_Data);
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            //Client selection
            listExistClients = new List<string>() { Constants.Discover };
            if (listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }
            listExistClients = new List<string>() { Constants.Discover };
            if (!listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_RequistionSearch_regReqList_filter), kwm._WDWait);

            kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_RequistionSearch_regReqList_filter, submitToManagerModel.str_Link_ReqNumber, false);
            Thread.Sleep(1000);
            //objCommonMethods.Action_Button_Tab(WDriver);
            kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);

            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);
            Thread.Sleep(1000);
            //Requirement number click
            kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            //View Submitted Candidates link click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_Link_ActionList_ViewCandidates);
            objCommonMethods.Action_Page_Down(WDriver);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            string strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);

            }

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_ViewCandidatename), kwm._WDWait);
            results = kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Txt_search_Viewcandidatename, submitToManagerModel.str_CandidateName, false);

            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_ViewCandidatename), kwm._WDWait);

            //Candidate name click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_CandidateName);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_link_ViewCandidatename);

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ExpandAll_tabsAll);
            //objCommonMethods._CheckRehireEligibility(WDriver, kwm);o
            Thread.Sleep(5000);
            objCommonMethods.Action_Page_Down(WDriver);

            // Common Code


            // Initiate Onboarding Method
            string strXpath_ListMenu = "//*[@id='listMenu1']//li[text()[normalize-space()= '" + submitToManagerModel.str_Link_ActionList_InitiateOnboarding + "']]";
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, strXpath_ListMenu);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_Link_ActionList_InitiateOnboarding);
            objCommonMethods.Action_Page_Down(WDriver);
            Thread.Sleep(1000);
            // Click on Initiate Onboarding link 
            strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_InitiateOnboarding, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_InitiateOnboarding, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            // Configuration Rule*  
            kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_ConfigurationRule_onboardConfigID, submitToManagerModel.str_select_ConfigurationRule_onboardConfigID);

            // Initiate Onboarding submit_Button
            results = kwm.click(WDriver, KeyWords.locator_XPath, "//button[@class='btn btn-sm btn-primary'][text()[normalize-space()='" + submitToManagerModel.str_button_InitiateOnboarding + "']]");
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, "//button[@class='btn btn-sm btn-primary'][text()[normalize-space()='" + submitToManagerModel.str_button_InitiateOnboarding + "']]");
            }



            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_InitiateOnboarding_Popup_Yes), kwm._WDWait);
            //Yes
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_InitiateOnboarding_Popup_Yes);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            //OK
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_InitiateOnboarding_Popup_OK), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_InitiateOnboarding_Popup_OK), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_InitiateOnboarding_Popup_OK);

            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_strSubmitToManagerSuccessfully;
            return results;
        }

        public Result SubmittedManagerDetail_Method(IWebDriver WDriver, DataRow SubmitToManager_Data, int MspExecutionNo)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };


            SubmitManagerRepository submitmanagerRepository = new SubmitManagerRepository();
            SubmitToManagerModel submitToManagerModel = submitmanagerRepository.GetSubmitToManagerData(SubmitToManager_Data);
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            //Client selection
            listExistClients = new List<string>() { Constants.Discover };
            if (listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }
            listExistClients = new List<string>() { Constants.Discover };
            if (!listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_RequistionSearch_regReqList_filter), kwm._WDWait);

            kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_RequistionSearch_regReqList_filter, submitToManagerModel.str_Link_ReqNumber, false);
            Thread.Sleep(1000);
            //objCommonMethods.Action_Button_Tab(WDriver);
            kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);

            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);
            Thread.Sleep(1000);
            //Requirement number click
            kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            //View Submitted Candidates link click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_Link_ActionList_ViewCandidates);
            objCommonMethods.Action_Page_Down(WDriver);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            string strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);

            }

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_ViewCandidatename), kwm._WDWait);
            results = kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Txt_search_Viewcandidatename, submitToManagerModel.str_CandidateName, false);

            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_ViewCandidatename), kwm._WDWait);

            //Candidate name click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_CandidateName);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_link_ViewCandidatename);

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ExpandAll_tabsAll);
            //objCommonMethods._CheckRehireEligibility(WDriver, kwm);o
            Thread.Sleep(5000);
            objCommonMethods.Action_Page_Down(WDriver);

            // Common Code


            // Submitted Manager Detail Method
            string strXpath_ListMenu = "//*[@id='listMenu1']//li[text()[normalize-space()= '" + submitToManagerModel.str_Link_ActionList_SubmittedManagerDetail + "']]";
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, strXpath_ListMenu);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_Link_ActionList_SubmittedManagerDetail);
            objCommonMethods.Action_Page_Down(WDriver);
            Thread.Sleep(1000);
            // Click on Submitted Manager Detail link 
            strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_SubmittedManagerDetail, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_SubmittedManagerDetail, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            // Submitted Manager Detail Cancel_Button
            results = kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='dialog']/following-sibling::div/div/button[text()='" + submitToManagerModel.str_button_SubmittedManagerDetail_Cancel + "']");
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='dialog']/following-sibling::div/div/button[text()='" + submitToManagerModel.str_button_SubmittedManagerDetail_Cancel + "']");
            }



            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_strSubmitToManagerSuccessfully;
            return results;
        }

        public Result SubmittoAdditionalManagers_Method(IWebDriver WDriver, DataRow SubmitToManager_Data, int MspExecutionNo)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };


            SubmitManagerRepository submitmanagerRepository = new SubmitManagerRepository();
            SubmitToManagerModel submitToManagerModel = submitmanagerRepository.GetSubmitToManagerData(SubmitToManager_Data);
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            //Client selection
            listExistClients = new List<string>() { Constants.Discover };
            if (listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }
            listExistClients = new List<string>() { Constants.Discover };
            if (!listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_RequistionSearch_regReqList_filter), kwm._WDWait);

            kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_RequistionSearch_regReqList_filter, submitToManagerModel.str_Link_ReqNumber, false);
            Thread.Sleep(1000);
            //objCommonMethods.Action_Button_Tab(WDriver);
            kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);

            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);
            Thread.Sleep(1000);
            //Requirement number click
            kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            //View Submitted Candidates link click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_Link_ActionList_ViewCandidates);
            objCommonMethods.Action_Page_Down(WDriver);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            string strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);

            }

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_ViewCandidatename), kwm._WDWait);
            results = kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Txt_search_Viewcandidatename, submitToManagerModel.str_CandidateName, false);

            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_ViewCandidatename), kwm._WDWait);

            //Candidate name click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_CandidateName);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_link_ViewCandidatename);

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ExpandAll_tabsAll);
            //objCommonMethods._CheckRehireEligibility(WDriver, kwm);o
            Thread.Sleep(5000);
            objCommonMethods.Action_Page_Down(WDriver);

            // Common Code


            // Submit to Additional Managers Method
            string strXpath_ListMenu = "//*[@id='listMenu1']//li[text()[normalize-space()= '" + submitToManagerModel.str_Link_ActionList_SubmittoAdditionalManagers + "']]";
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, strXpath_ListMenu);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_Link_ActionList_SubmittoAdditionalManagers);
            objCommonMethods.Action_Page_Down(WDriver);
            Thread.Sleep(1000);
            // Click on Submit to Additional Managers link 
            strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_SubmittoAdditionalManagers, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_SubmittoAdditionalManagers, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            // Submit to Additional Managers * 
            kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_typeahead_SubmittoAdditionalManagers_txtManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManagerModel.str_typeahead_SubmittoAdditionalManagers_txtManager, submitToManagerModel.str_typeahead_SubmittoAdditionalManagers_txtManager);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_typeahead_SubmittoAdditionalManagers_txtManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManagerModel.str_typeahead_SubmittoAdditionalManagers_txtManager, submitToManagerModel.str_typeahead_SubmittoAdditionalManagers_txtManager);
            }
            Thread.Sleep(2000);
            // Add button
            results = kwm.click(WDriver, KeyWords.locator_XPath, "//a[@aria-label='Submit to Additional Managers Add']");





            //Submit to Additional Managers submit_Button
            results = kwm.click(WDriver, KeyWords.locator_XPath, "//button[@class='btn btn-sm btn-primary'][text()[normalize-space()='" + submitToManagerModel.str_button_SubmittoManager + "']]");
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, "//button[@class='btn btn-sm btn-primary'][text()[normalize-space()='" + submitToManagerModel.str_button_SubmittoManager + "']]");
            }



            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_InitiateOnboarding_Popup_Yes), kwm._WDWait);
            //Yes
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_InitiateOnboarding_Popup_Yes);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            //OK
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_InitiateOnboarding_Popup_OK), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_InitiateOnboarding_Popup_OK), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_InitiateOnboarding_Popup_OK);

            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_strSubmitToManagerSuccessfully;
            return results;
        }

        public Result SubmitCandidateReject_Method(IWebDriver WDriver, DataRow SubmitToManager_Data, int MspExecutionNo)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };


            SubmitManagerRepository submitmanagerRepository = new SubmitManagerRepository();
            SubmitToManagerModel submitToManagerModel = submitmanagerRepository.GetSubmitToManagerData(SubmitToManager_Data);
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            //Client selection
            listExistClients = new List<string>() { Constants.Discover };
            if (listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }
            listExistClients = new List<string>() { Constants.Discover };
            if (!listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_RequistionSearch_regReqList_filter), kwm._WDWait);

            kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_RequistionSearch_regReqList_filter, submitToManagerModel.str_Link_ReqNumber, false);
            Thread.Sleep(1000);
            //objCommonMethods.Action_Button_Tab(WDriver);
            kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);

            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);
            Thread.Sleep(1000);
            //Requirement number click
            kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            //View Submitted Candidates link click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_Link_ActionList_ViewCandidates);
            objCommonMethods.Action_Page_Down(WDriver);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            string strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);

            }

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_ViewCandidatename), kwm._WDWait);
            results = kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Txt_search_Viewcandidatename, submitToManagerModel.str_CandidateName, false);

            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_ViewCandidatename), kwm._WDWait);

            //Candidate name click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_CandidateName);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_link_ViewCandidatename);

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ExpandAll_tabsAll);
            //objCommonMethods._CheckRehireEligibility(WDriver, kwm);o
            Thread.Sleep(5000);
            objCommonMethods.Action_Page_Down(WDriver);

            // Common Code


            // Reject Method
            string strXpath_ListMenu = "//*[@id='listMenu1']//li[text()[normalize-space()= '" + submitToManagerModel.str_Link_ActionList_Reject + "']]";
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, strXpath_ListMenu);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_Link_ActionList_Reject);
            objCommonMethods.Action_Page_Down(WDriver);
            Thread.Sleep(1000);
            // Click on Reject link 
            strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_Reject, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_Reject, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            // Reject Reason *
            kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_RejectReason_ReasonId, submitToManagerModel.str_Select_RejectReason_ReasonId);

            // Reject Type *
            kwm.click(WDriver, KeyWords.locator_XPath, "//input[@id='rbOptReject' and @value='1']");

            // Comment *
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Comment_txtComments, submitToManagerModel.str_Txt_Comment_txtComments, false);



            // Reject Reason_Button
            results = kwm.click(WDriver, KeyWords.locator_XPath, "//button[@class='btn btn-sm btn-primary'][text()[normalize-space()='" + submitToManagerModel.str_button_Reject + "']]");
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, "//button[@class='btn btn-sm btn-primary'][text()[normalize-space()='" + submitToManagerModel.str_button_Reject + "']]");
            }



            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_InitiateOnboarding_Popup_Yes), kwm._WDWait);
            //Yes
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_InitiateOnboarding_Popup_Yes);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            //OK
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_InitiateOnboarding_Popup_OK), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_InitiateOnboarding_Popup_OK), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_InitiateOnboarding_Popup_OK);

            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_strSubmitToManagerSuccessfully;
            return results;
        }

        public Result AddCandidatetoBucket_Method(IWebDriver WDriver, DataRow AddCandidatetoBucket_Method, int MspExecutionNo)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };


            SubmitManagerRepository submitmanagerRepository = new SubmitManagerRepository();
            SubmitToManagerModel submitToManagerModel = submitmanagerRepository.GetSubmitToManagerData(AddCandidatetoBucket_Method);
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            //Client selection
            listExistClients = new List<string>() { Constants.Discover };
            if (listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }
            listExistClients = new List<string>() { Constants.Discover };
            if (!listExistClients.Contains(submitToManagerModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
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
                            return results;
                    }
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManagerModel.strMainMenuLink, submitToManagerModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManagerModel.strClientName + "_");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_RequistionSearch_regReqList_filter), kwm._WDWait);

            kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_RequistionSearch_regReqList_filter, submitToManagerModel.str_Link_ReqNumber, false);
            Thread.Sleep(1000);
            //objCommonMethods.Action_Button_Tab(WDriver);
            kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);

            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]"), kwm._WDWait);
            Thread.Sleep(1000);
            //Requirement number click
            kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + submitToManagerModel.str_Link_ReqNumber + "')]");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            //View Submitted Candidates link click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_Link_ActionList_ViewCandidates);
            objCommonMethods.Action_Page_Down(WDriver);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            string strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_ViewCandidates, strSubLevel);

            }

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_Text_Clientsearch_candidatename), kwm._WDWait);
            results = kwm.sendTextXPathOnly(WDriver, KeyWords.XPath_Text_Clientsearch_candidatename, submitToManagerModel.str_CandidateName);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Click_ClickCandidate);

            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_Click_ClickCandidate), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Click_ClickCandidate);
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);




            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ExpandAll_tabsAll);
            //objCommonMethods._CheckRehireEligibility(WDriver, kwm);
            Thread.Sleep(5000);
            objCommonMethods.Action_Page_Down(WDriver);
            objCommonMethods.Action_Page_Down(WDriver);
            string strXpath_ListMenu = "//*[@id='listMenu1']//li[text()[normalize-space()= '" + submitToManagerModel.str_Link_ActionList_SubmitToManager + "']]";
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, strXpath_ListMenu);
            //     kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_Link_ActionList_SubmitToManager);
            objCommonMethods.Action_Page_Down(WDriver);
            objCommonMethods.Action_Page_Down(WDriver);
            Thread.Sleep(1000);
            //Submit Manager
            strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_SubmitToManager, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManagerModel.str_Link_ActionList_SubmitToManager, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");
            //kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Txt_SubmittothefollowingManagers_txtManager), kwm._WDWait);
            //Submit to Manager click

            string timeStamp = DateTime.Now.ToString("HHmmssffff");


            string comment = "";
            //Comment
            if (submitToManagerModel.str_Txt_Comment_txtComments != "")



                comment = timeStamp + submitToManagerModel.str_Txt_Comment_txtComments;

            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Comment_txtComments, comment, false);

            results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Button_Submit);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Button_Submit);
            }

            // Confirmation popup with YES/NO
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManagerModel.str_Btn_SumitToManager_Action_Confirm);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(3000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManagerModel.str_Btn_SumitToManager_Action_Confirm);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            // Click on OK button
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManagerModel.str_Btn_SumitToManager_Action_Confirm_OK);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(13000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManagerModel.str_Btn_SumitToManager_Action_Confirm_OK);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(15000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManagerModel.str_Btn_SumitToManager_Action_Confirm_OK);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }


            //Verification starts 
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Button_ExpandAll_tabsAll), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ExpandAll_tabsAll);

            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Comment_Verification_addCandidatetobucket);
            //  results = kwm.GetText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Comment_Verification_addCandidatetobucket);

            string test = WDriver.FindElement(By.XPath("//div[@id='DataTables_Table_4_wrapper']//tr[@class='altOdd skillrow odd']//td[contains(@aria-label,'Comment') and not(@class='lastChildPR')]")).Text;



            if (test == comment)
            {

                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = KeyWords.MSG_strSubmitToManagerSuccessfully;
                return results;
            }
            else
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Failed";
                return results;

            }
        }




    }
}

