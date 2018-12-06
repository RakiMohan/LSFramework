// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Broadcast.cs" company="DCR Workforce Inc">
//   Copyright (c) DCR Workforce Inc. All rights reserved.
//   This code and information should not be copied and used outside of DCR Workforce Inc.
// </copyright>
// <summary>
//  This Constants is used
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using SmartTrack.DataAccess.Repository;
using SmartTrack.DataAccess.Models;
using SmartTrack;
namespace SmartTrack_Automation
{
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
    using System.Text.RegularExpressions;
    using System.IO;
    using System.Data;
    using System.Configuration;
    //using System.Data.OracleClient;
    using System.Net;
    //using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections;
    using System.Diagnostics;
    using OpenQA.Selenium.Interactions;
    using RelevantCodes.ExtentReports;
    using CommonFiles;

    // using SmartTrack;


    //[TestClass]
    public class Broadcast
    {
        public Result Broadcast_Method(IWebDriver WDriver, DataRow Broadcast_Data, int a)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            ReadExcel ReadExcelHelper_local = new ReadExcel();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 60);
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };
            List<string> str_list_SupplierMailId = new List<string>();
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            BroadcastModel broadcastModel = createRequirementRepository.GetBroadcastData(Broadcast_Data);
            BroadCastActions broadCastActions = new BroadCastActions();

            listExistClients = new List<string>() { Constants.Discover };
            if (listExistClients.Contains(broadcastModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Boolean bFlagDropDwon = false;
                        try
                        {
                            // bFlagDropDwon = WDriver.FindElement(By.XPath(KeyWords.XPath_supplierMenu_ClientDropDown)).Enabled;
                            bFlagDropDwon = kwm.isElementEnabledByXPath(WDriver, KeyWords.XPath_supplierMenu_ClientDropDown);
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
            if (!listExistClients.Contains(broadcastModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Boolean bFlagDropDwon = false;
                        try
                        {
                            // bFlagDropDwon = WDriver.FindElement(By.XPath(KeyWords.XPath_supplierMenu_ClientDropDown)).Enabled;
                            bFlagDropDwon = kwm.isElementEnabledByXPath(WDriver, KeyWords.XPath_supplierMenu_ClientDropDown);
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

            objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }

            //   /*  only for test 




            if (!kwm.waitForElementExists(WDriver, By.XPath("//table[@id='regReqList']//tbody//tr"), kwm._WDWait))
            {
                Thread.Sleep(2000);
            }

            //Search requirement


            kwm.sendText_XPath(WDriver, KeyWords.locator_XPath, KeyWords.XPath_SearchBox_Requirements_regReqList, broadcastModel.str_Link_ReqNumber, broadcastModel.str_Link_ReqNumber, false);
            Thread.Sleep(5000);
            //Wait for Requirement to load

            if (!kwm.waitForElementToBeVisible(WDriver, By.XPath("//table[@id='regReqList']//td/a[contains(text(),'" + broadcastModel.str_Link_ReqNumber + "')]"), kwm._WDWait))
            {
                kwm.waitForElementToBeClickable(WDriver, By.XPath("//table[@id='regReqList']//td/a[contains(text(),'" + broadcastModel.str_Link_ReqNumber + "')]"), kwm._WDWait);
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

            Thread.Sleep(5000);
            //Click on Requirement Link

            kwm.click(WDriver, KeyWords.locator_XPath, "//table[@id='regReqList']//td/a[contains(text(),'" + broadcastModel.str_Link_ReqNumber + "')]");

            //WDriver.FindElement(By.XPath("//table[@id='regReqList']//td/a[contains(text(),'" + broadcastModel.str_Link_ReqNumber + "')]")).Click();

            //wait for page to load
            kwm.waitForElementExists(WDriver, By.XPath(KeyWords.XPath_OverlayLoader), kwm._WDWait);

            //Wait for broadcast link to be Displayed
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_ActionListMenu_Broadcast_reqBroadcast), kwm._WDWait);

            //Click on Broadcast menu link
            kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.XPath_ActionListMenu_Broadcast_reqBroadcast);

            //Wait for form to load
            Thread.Sleep(1000);


            if (kwm.isElementDisplayedByXPath(WDriver, "//div[@aria-labelledby='ui-dialog-title-PleaseWaitPopup' and contains(@style,'display: none')]"))
            {
                kwm.waitForElementToBeVisible(WDriver, By.XPath("//div[@aria-labelledby='ui-dialog-title-PleaseWaitPopup' and contains(@style,'display: none')]"), kwm._WDWait);
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
            //Click on Distribution List
            if (kwm.isElementDisplayedByXPath(WDriver, KeyWords.XPath_li_DistributionList))
            {
                kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.XPath_li_DistributionList);
            }

            //Wait for dialog box 
            if (!kwm.isElementDisplayedByXPath(WDriver, KeyWords.XPath_MsgBox_DistributionListPopup))
            {
                kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_MsgBox_DistributionListPopup), kwm._WDWait);
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
            listExistClients = new List<string>() { Constants.EQT };
            if (listExistClients.Contains(broadcastModel.strClientName.ToLower()))
            {
                // Bill Rates(USD) *
                if (broadcastModel.str_txt_BillRatesUSD_ddlBillratesHigh != "")
                {
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_BillRatesUSD_ddlBillratesHigh, broadcastModel.str_txt_BillRatesUSD_ddlBillratesHigh, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_BillRatesUSD_ddlBillratesHigh, broadcastModel.str_txt_BillRatesUSD_ddlBillratesHigh, false);
                    }
                }
            }
            //wait for distrubution dropdown list
            if (kwm.isElementDisplayed(WDriver, KeyWords.ID_MsgBox_Select_DistributionList_ddlDistList))
            {
                //select the value by index in distrubution dropdown list
                //kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_MsgBox_Select_DistributionList_ddlDistList, 1);

                if (broadcastModel.strClientName.ToLower() == Constants.Welchallyn || broadcastModel.strClientName.ToLower() == Constants.Tesla)
                {
                    kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_MsgBox_Select_DistributionList_ddlDistList, broadcastModel.str_Select_DistributionList);
                }
                else
                {
                    //select the value by index in distrubution dropdown list
                    kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_MsgBox_Select_DistributionList_ddlDistList, 1);
                }


                //wait for tier dropdown to load

                kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_MsgBox_Select_Tiers_ddlTiers), kwm._WDWait);

                //select the value by index in distrubution dropdown list
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_ddlTiers, broadcastModel.str_Select_Tier);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //select the value by index in distrubution dropdown list
                    kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_MsgBox_Select_Tiers_ddlTiers, 1);
                }


                try
                {

                    //kwm.waitForElementExists(WDriver, By.Id("tblSuppliers"), kwm._WDWait);
                    //kwm.waitForElementToBeVisible(WDriver, By.Id("tblSuppliers"), kwm._WDWait);
                    Thread.Sleep(4000);
                    for (int t1 = 0; t1 < 100; t1++)
                    {
                        if (kwm.isElementDisplayed(WDriver, "tblSuppliers"))
                        {
                            Thread.Sleep(100);

                            break;
                        }

                    }


                    //Verify if the supplier table is displayed
                    if (kwm.isElementDisplayedXpath(WDriver, "//*[@id='tblSuppliers_filter']/label/input"))
                    {
                        //Move to supplier list
                        kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, "tblSuppliers");

                        objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                        //  kwm.waitForElementToBeVisible(WDriver, By.XPath("//table[@id='tblSuppliers']//tr//th[@fieldname='primaryEmail']"), kwm._WDWait);
                        //Verify Email Header is displayed
                        if (kwm.isElementDisplayedByXPath(WDriver, "//table[@id='tblSuppliers']//tbody//tr[1]//input"))
                        {
                            //   kwm.waitForElementToBeClickable(WDriver, By.XPath("//table[@id='tblSuppliers']//tr//th[@fieldname='primaryEmail']"), kwm._WDWait);
                            //Need to check if the check box is selected or not
                            //pending- end

                            if (WDriver.FindElements(By.XPath("//table[@id='tblSuppliers']//tbody//tr")).ToList().Count > 0)
                            {
                                String setEmailXpath;
                                //Get the attribute value of the email field
                                String strVal = WDriver.FindElement(By.XPath("//table[@id='tblSuppliers']//tr//th[@fieldname='primaryEmail']")).GetAttribute("style");

                                //verifying if it is displayed on the screen load or not
                                if (strVal.ToLower().Contains("display: none;"))
                                {
                                    //setEmailXpath = "//table[@id='tblSuppliers']//tbody/tr//td[@id='iconTable']";
                                    //foreach (IWebElement ele in WDriver.FindElements(By.XPath(setEmailXpath)).ToList())
                                    //{
                                    //    ele.Click();
                                    //   // Actions action = new Actions(WDriver);
                                    //    objCommonMethods.Action_Button_Enter(WDriver);
                                    //  //  action.SendKeys(Keys.Enter).Build().Perform();
                                    //    Thread.Sleep(1000);
                                    //    //Add supplier mail id's to list
                                    //    str_list_SupplierMailId.Add(kwm.GetText_Xpath(WDriver, "//table[@id='tblSuppliers']//tbody/tr/following-sibling::tr[@class='child']//span[normalize-space(text())='Email']/following-sibling::*[@class='dtr-data']")._Var);
                                    //   // action.SendKeys(Keys.Enter).Build().Perform();
                                    //    objCommonMethods.Action_Button_Enter(WDriver);
                                    //    Thread.Sleep(1000);
                                    //    ele.Click();
                                    //}
                                    kwm.jsCommand_Click(WDriver, "$('#tblSuppliers tbody tr td:first-child').click()");
                                    setEmailXpath = "//table[@id='tblSuppliers']//tbody/tr[@class='child']//span[normalize-space(text())='Email']/following-sibling::*[@class='dtr-data' and contains(text(),'@hcmondemand.net')]";
                                    //"//table[@id='tblSuppliers']//tbody/tr//td[@id='iconTable']";  
                                    foreach (IWebElement ele in WDriver.FindElements(By.XPath(setEmailXpath)).ToList())
                                    {
                                        //Add supplier mail id's to list
                                        str_list_SupplierMailId.Add(ele.Text);
                                    }
                                }
                                else
                                {
                                    setEmailXpath = "//table[@id='tblSuppliers']//tbody//tr[@role='row']//td//self::*[contains(text(),'@')]";

                                    foreach (IWebElement ele in WDriver.FindElements(By.XPath(setEmailXpath)).ToList())
                                    {
                                        //Add supplier mail id's to list
                                        str_list_SupplierMailId.Add(ele.Text);
                                    }
                                }



                                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                                //click on broadcast button
                                kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.XPath_MsgBox_Btn_Broadcast_Broadcast);

                                if (kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_MsgBox_ConfirmSuppliers_Btn_Yes_Yes), kwm._WDWait))
                                {
                                    objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                                    //click on yes button on confirm supplier popup
                                    kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.XPath_MsgBox_ConfirmSuppliers_Btn_Yes_Yes);

                                    kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_MsgBox_dlgBroadcastSent_Btn_OK_OK), kwm._WDWait);

                                    objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                                    //Click on Ok button
                                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_MsgBox_dlgBroadcastSent_Btn_OK_OK);
                                    if (results.Result1 == KeyWords.Result_FAIL)
                                    {
                                        Thread.Sleep(5000);
                                        kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_MsgBox_dlgBroadcastSent_Btn_OK_OK), kwm._WDWait);
                                        kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_MsgBox_dlgBroadcastSent_Btn_OK_OK);
                                    }
                                }
                                else
                                {
                                    objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                                    results.ErrorMessage = "Yes button is not displayed/clickable";
                                    results.Result1 = KeyWords.Result_FAIL;
                                    return results;
                                }

                            }
                            else
                            {
                                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                                results.ErrorMessage = "List count is 0 i.e no mail id's are added to the list";
                                results.Result1 = KeyWords.Result_FAIL;
                                return results;
                            }

                        }
                        else
                        {
                            objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                            results.ErrorMessage = "No Mail's displayed for the selected suppliers";
                            results.Result1 = KeyWords.Result_FAIL;
                            return results;
                        }

                    }
                    else
                    {
                        objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                        results.ErrorMessage = "Supplier table is Not displayed ";
                        results.Result1 = KeyWords.Result_FAIL;
                        return results;
                    }
                }
                catch (Exception e)
                {
                    objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                    results.ErrorMessage = e.Message;
                    results.Result1 = KeyWords.Result_FAIL;
                    return results;
                }
            }
            else
            {
                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                results.ErrorMessage = "Distribution Dropdown is not displayed/selected";
                results.Result1 = KeyWords.Result_FAIL;
                return results;

            }

            //wait for page to load
            kwm.waitForElementExists(WDriver, By.XPath(KeyWords.XPath_OverlayLoader), kwm._WDWait);

            if (!kwm.isElementDisplayedByXPath(WDriver, KeyWords.XPath_OverlayLoader))
            {
                kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_OverlayLoader), kwm._WDWait);
            }
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_ActionListMenu_BroadcastDetails_reqBroadcastDetails), kwm._WDWait);
            if (kwm.isElementDisplayedByXPath(WDriver, KeyWords.XPath_ActionListMenu_BroadcastDetails_reqBroadcastDetails))
            {
                //broadCastActions.addComments(WDriver, Broadcast_Data, "TxtComment");

                //broadCastActions.broadacastDetails(WDriver, Broadcast_Data);

                //broadCastActions.openDiscussion(WDriver, Broadcast_Data, "Gordon, James");

                //broadCastActions.ReBroadcast_Method(WDriver, Broadcast_Data);

                //broadCastActions.saveAsCatalog(WDriver, Broadcast_Data);

                //broadCastActions.recallRequisition(WDriver, Broadcast_Data);

                //broadCastActions.requeueMethod(WDriver, Broadcast_Data, "Hemphill, Jeffrey", "Gordon, James");

                //broadCastActions.cancelRequisition(WDriver, Broadcast_Data);

                //broadCastActions.changeStatus(WDriver, Broadcast_Data, "New");

                //broadCastActions.reOpenRequistion(WDriver, Broadcast_Data);

                //broadCastActions.convertRequisitionToPayroll(WDriver, Broadcast_Data);

                //broadCastActions.assignMspPoc(WDriver, Broadcast_Data);

                //broadCastActions.sendReminder(WDriver, Broadcast_Data);

                //broadCastActions.viewETKDetails(WDriver, Broadcast_Data);

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                results.ErrorMessage = "Broadcast is successfull";
                results.listData = str_list_SupplierMailId;
                results.Result1 = KeyWords.Result_PASS;
                return results;
            }
            return results;
            //----------------------------------------------------------------------------------------



            //Edit method calling 
            string strSubLevel = "./label";
            objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
            if (broadcastModel.str_Link_Edit != "")
            {
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, broadcastModel.str_Link_Edit, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(2000);
                    results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, broadcastModel.str_Link_Edit, strSubLevel);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }

            }
        }

        public Result RequisitionAge_Method(IWebDriver WDriver, DataRow Requisition_Data, int a)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            ReadExcel ReadExcelHelper_local = new ReadExcel();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 60);
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };
            List<string> str_list_SupplierMailId = new List<string>();
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            BroadcastModel broadcastModel = createRequirementRepository.GetBroadcastData(Requisition_Data);


            listExistClients = new List<string>() { Constants.Discover };
            if (listExistClients.Contains(broadcastModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Boolean bFlagDropDwon = false;
                        try
                        {
                            // bFlagDropDwon = WDriver.FindElement(By.XPath(KeyWords.XPath_supplierMenu_ClientDropDown)).Enabled;
                            bFlagDropDwon = kwm.isElementEnabledByXPath(WDriver, KeyWords.XPath_supplierMenu_ClientDropDown);
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
            if (!listExistClients.Contains(broadcastModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Boolean bFlagDropDwon = false;
                        try
                        {
                            // bFlagDropDwon = WDriver.FindElement(By.XPath(KeyWords.XPath_supplierMenu_ClientDropDown)).Enabled;
                            bFlagDropDwon = kwm.isElementEnabledByXPath(WDriver, KeyWords.XPath_supplierMenu_ClientDropDown);
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

            objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }





            if (broadcastModel.strSubMenuLink.ToLower().Contains("identified"))
            {

                if (!kwm.waitForElementExists(WDriver, By.XPath("//table[@id='IdentifiedReqList']//tbody//tr"), kwm._WDWait))
                {
                    Thread.Sleep(2000);
                }
            }
            else
            {
                if (!kwm.waitForElementExists(WDriver, By.XPath("//table[@id='regReqList']//tbody//tr"), kwm._WDWait))
                {
                    Thread.Sleep(2000);
                }
            }
            //Search requirement


            kwm.sendText_XPath(WDriver, KeyWords.locator_XPath, KeyWords.XPath_SearchBox_Requirements_regReqList, broadcastModel.str_Link_ReqNumber, broadcastModel.str_Link_ReqNumber, false);

            //Wait for Requirement to load

            if (!kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_Img_Processing), kwm._WDWait))
            {
                kwm.waitForElementToBeClickable(WDriver, By.XPath("//table[@id='regReqList']//td/a[contains(text(),'" + broadcastModel.str_Link_ReqNumber + "')]"), kwm._WDWait);
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

            //   /*  only for test 

            string RequisitionAge = kwm.ReqAge(WDriver, "Requisition Age")._Var;

            int Age = Int32.Parse(RequisitionAge);
            //Click on Requirement Link

            kwm.click(WDriver, KeyWords.locator_XPath, "//table[@id='regReqList']//td/a[contains(text(),'" + broadcastModel.str_Link_ReqNumber + "')]");

            //WDriver.FindElement(By.XPath("//table[@id='regReqList']//td/a[contains(text(),'" + broadcastModel.str_Link_ReqNumber + "')]")).Click();

            //wait for page to load
            kwm.waitForElementExists(WDriver, By.XPath(KeyWords.XPath_OverlayLoader), kwm._WDWait);

            //Wait for broadcast link to be Displayed
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_ActionListMenu_Broadcast_reqBroadcast), kwm._WDWait);

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_tabsAll);

            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Date_ApprovalLog_CreateDate);

            //kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_Date_ApprovalLog_CreateDate), kwm._WDWait);

            string Date = WDriver.FindElement(By.XPath("//*[@id='Table4']//tr[@class = 'altOdd skillrow odd']/td[1]")).Text;

            string[] date = Date.Split(' ');
            string CreatedDate = date[0];

            DateTime myDate = DateTime.ParseExact(CreatedDate, "MM/dd/yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);

            DateTime todaydate = DateTime.Now;

            int RequisitionAge_days = (todaydate.Date - myDate.Date).Days;

            if (Age == RequisitionAge_days)
            {

            }
            else
            {
                results.Result1 = KeyWords.Result_FAIL;
                return results;
            }






            try
            {

                //kwm.waitForElementExists(WDriver, By.Id("tblSuppliers"), kwm._WDWait);
                //kwm.waitForElementToBeVisible(WDriver, By.Id("tblSuppliers"), kwm._WDWait);
                Thread.Sleep(10000);
                for (int t1 = 0; t1 < 100; t1++)
                {
                    if (kwm.isElementDisplayed(WDriver, "tblSuppliers"))
                    {
                        Thread.Sleep(100);

                        break;
                    }

                }


                //Verify if the supplier table is displayed

            }
            catch (Exception e)
            {
                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                results.ErrorMessage = e.Message;
                results.Result1 = KeyWords.Result_FAIL;
                return results;
            }


            //wait for page to load
            kwm.waitForElementExists(WDriver, By.XPath(KeyWords.XPath_OverlayLoader), kwm._WDWait);

            if (!kwm.isElementDisplayedByXPath(WDriver, KeyWords.XPath_OverlayLoader))
            {
                kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_OverlayLoader), kwm._WDWait);
            }
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_ActionListMenu_BroadcastDetails_reqBroadcastDetails), kwm._WDWait);
            if (kwm.isElementDisplayedByXPath(WDriver, KeyWords.XPath_ActionListMenu_BroadcastDetails_reqBroadcastDetails))
            {

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                results.ErrorMessage = "Broadcast is successfull";
                results.listData = str_list_SupplierMailId;
                results.Result1 = KeyWords.Result_PASS;
                return results;
            }
            return results;
            //----------------------------------------------------------------------------------------




        }

        }
    }
