// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IssueWorkOrder.cs" company="DCR Workforce Inc">
//   Copyright (c) DCR Workforce Inc. All rights reserved.
//   This code and information should not be copied and used outside of DCR Workforce Inc.
// </copyright>
// <summary>
//   Defines the Registration Repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
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
using OpenQA.Selenium.Interactions;
using CommonFiles;
using SmartTrack.DataAccess.Repository;
using SmartTrack.DataAccess.Models;
using SmartTrack;
using RelevantCodes.ExtentReports;

namespace SmartTrack_Automation
{
    // [TestClass]Edit
    public class IssueWorkOrder
    {
        public Result IssueWorkOrder_Method(IWebDriver WDriver, DataRow IssueWorkOrder_Data, int MSPExecutionRowNO)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            IssueWorkOrderModel issueWorkOrderModel = createRequirementRepository.GetIssueWorkOrderData(IssueWorkOrder_Data);
            ReadExcel ReadExcelHelper = new ReadExcel();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, issueWorkOrderModel.strClientName + "_");
            listExistClients = new List<string>() { Constants.Discover };
            if (listExistClients.Contains(issueWorkOrderModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, issueWorkOrderModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, issueWorkOrderModel.strClientName);
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
            if (!listExistClients.Contains(issueWorkOrderModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, issueWorkOrderModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, issueWorkOrderModel.strClientName);
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

            objCommonMethods.SaveScreenShot_EachPage(WDriver, issueWorkOrderModel.strClientName + "_");
            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, issueWorkOrderModel.strMainMenuLink, issueWorkOrderModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, issueWorkOrderModel.strMainMenuLink, issueWorkOrderModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, issueWorkOrderModel.strClientName + "_");
            string strSubLevel = "";
            if (issueWorkOrderModel.strSubMenuLink.ToLower().Trim() != "candidate with offers")
            {

                try
                {
                    new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.XPath(KeyWords.ID_paginate_regReqList_filter))));
                }
                catch
                {
                    for (int i = 0; i < 10; i++)
                    {
                        try
                        {
                            if (WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).Displayed)
                            {
                                break;
                            }
                            Thread.Sleep(100);
                        }
                        catch
                        {
                            //
                        }
                    }
                }
                //Requirement number passed into search text box

                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.XPath(KeyWords.XPath_link_Reuirementnumber_Req))));
                kwm.sendTextXPathOnly(WDriver, KeyWords.ID_paginate_regReqList_filter, issueWorkOrderModel.str_Link_ReqNumber);
                //Wait until reuirement link or record is displaying
                Thread.Sleep(1000);
                kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_link_Reuirementnumber_Req), kwm._WDWait);
                Thread.Sleep(1000);

                //Requirement number click
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_link_Reuirementnumber_Req);
                //Wait until left menu is loading
                kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);

                objCommonMethods.SaveScreenShot_EachPage(WDriver, issueWorkOrderModel.strClientName + "_");


                //View candidate link click
                strSubLevel = "";
                objCommonMethods.SaveScreenShot_EachPage(WDriver, issueWorkOrderModel.strClientName + "_");
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, issueWorkOrderModel.str_Link_ActionList_ViewCandidates, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {

                    objCommonMethods.Action_Page_Down(WDriver);
                    Thread.Sleep(2000);
                    results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, issueWorkOrderModel.str_Link_ActionList_ViewCandidates, strSubLevel);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
                //Wait for view candidates results page
                kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_Pageload_Candidatestable_MSP), kwm._WDWait);
                //Candidate name passed into text box
                results = kwm.sendTextXPathOnly(WDriver, KeyWords.XPath_txt_viewcanddates_Search, issueWorkOrderModel.str_CandidateName);
                Thread.Sleep(2000);
                kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_link_Candidatename_MSP), kwm._WDWait);
                //Candidate name click
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_link_Candidatename_MSP);

                kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);

            }

            if (issueWorkOrderModel.strSubMenuLink.ToLower().Trim() == "candidate with offers")
            {
                //*[@id="identifiedCandidateListWithOffers_filter"]/label/input
                if (!kwm.waitForElementExists(WDriver, By.XPath("//*[@id='identifiedCandidateListWithOffers_filter']//label//input"), kwm._WDWait))
                {
                    Thread.Sleep(2000);
                }
                if (!kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='identifiedCandidateListWithOffers_filter']//label//input"), kwm._WDWait))
                {
                    Thread.Sleep(2000);
                }
                results = kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[@id='identifiedCandidateListWithOffers_filter']//label//input");
                kwm.sendTextXPathOnly(WDriver, "//*[@id='identifiedCandidateListWithOffers_filter']//label//input", issueWorkOrderModel.str_CandidateName);

                kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='identifiedCandidateListWithOffers']//tbody/tr/td[2]/a[contains(text(),'" + issueWorkOrderModel.str_CandidateName + "')]"), kwm._WDWait);

                objCommonMethods.SaveScreenShot_EachPage(WDriver, issueWorkOrderModel.strClientName + "_");

                results = kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='identifiedCandidateListWithOffers']//tbody/tr/td[2]/a[contains(text(),'" + issueWorkOrderModel.str_CandidateName + "')]");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='identifiedCandidateListWithOffers']//tbody/tr/td[2]/a[contains(text(),'" + issueWorkOrderModel.str_CandidateName + "')]"), kwm._WDWait);
                    Thread.Sleep(2000);
                    results = kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='identifiedCandidateListWithOffers']//tbody/tr/td[2]/a[contains(text(),'" + issueWorkOrderModel.str_CandidateName + "')]");

                }
                //*[@id="identifiedCandidateListWithOffers"]/tbody/tr/td[2]/a
                objCommonMethods.SaveScreenShot_EachPage(WDriver, issueWorkOrderModel.strClientName + "_");
            }

           

           


            string strValue1 = "";


            objCommonMethods.SaveScreenShot_EachPage(WDriver, issueWorkOrderModel.strClientName + "_");

            if ((issueWorkOrderModel.str_Link_ActionList_IssueWorkOrder.ToLower().Trim() == "issue work order" || issueWorkOrderModel.str_Link_ActionList_IssueWorkOrder.ToLower().Trim() == "issue engagement"))
            {

                kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);

                // IssueWorkOrder_EditCandidateInfo(WDriver, IssueWorkOrder_Data);


                strSubLevel = "";
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, issueWorkOrderModel.str_Link_ActionList_IssueWorkOrder, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, issueWorkOrderModel.str_Link_ActionList_IssueWorkOrder, strSubLevel);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }

                //Wait for IWO results page
                kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_lable_canddatesname_IWO), kwm._WDWait);


                objCommonMethods.SaveScreenShot_EachPage(WDriver, issueWorkOrderModel.strClientName + "_");


                //Click on Expand All button
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Btn_EXPANDALL_tabsExpandCollapse);

                // Inserting new code by clients list
                switch (issueWorkOrderModel.strClientName.ToLower())
                {

                    case Constants.Sts:
                        {
                            IssueWorkOrderPerClient.IWO_STS(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);

                            break;
                        }
                    //case Constants.IsGs:
                    //    {
                    //        IssueWorkOrderPerClient.IWO_ISGS(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                    //        break;
                    //    }
                    case Constants.EBS:
                        {
                            IssueWorkOrderPerClient.IWO_EBS(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    case Constants.RMS:
                        {
                            IssueWorkOrderPerClient.IWO_RMS(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }

                    case Constants.STGEN:
                        {
                            IssueWorkOrderPerClient.IWO_STGEN(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    case Constants.STTM:
                        {
                            IssueWorkOrderPerClient.IWO_STTM(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    case Constants.MFC:
                        {
                            IssueWorkOrderPerClient.IWO_MFC(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    //case Constants.NvEnergy:
                    //    {
                    //        IssueWorkOrderPerClient.IWO_NVENERGY(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                    //        break;
                    //    }

                    //case Constants.DCR:
                    //    {
                    //        IssueWorkOrderPerClient.IWO_DCR(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                    //        break;
                    //    }
                    case Constants.YP:
                        {
                            IssueWorkOrderPerClient.IWO_YP(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    //case Constants.Meritor:
                    //    {
                    //        IWO_PerClient.IWO_Meritor(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                    //        break;
                    //    }
                    //case Constants.GHC:
                    //    {
                    //        IssueWorkOrderPerClient.IWO_GHC(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                    //        break;
                    //    }

                    //case Constants.BDA:
                    //    {
                    //        IssueWorkOrderPerClient.IWO_BDA(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                    //        break;
                    //    }
                    case Constants.Arkema:
                        {
                            IssueWorkOrderPerClient.IWO_Arkema(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    //case Constants.Aero:
                    //    {
                    //        IssueWorkOrderPerClient.IWO_Aero(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                    //        break;
                    //    }
                    case Constants.Supervalu:
                        {
                            IssueWorkOrderPerClient.IWO_Supervalue(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    case Constants.Caesars:
                        {
                            IssueWorkOrderPerClient.IWO_Caesars(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    case Constants.Epri:
                        {
                            IssueWorkOrderPerClient.IWO_Epri(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }

                    //case Constants.Costco:
                    //    {
                    //        IssueWorkOrderPerClient.IWO_Costco(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                    //        break;
                    //    }
                    case Constants.Discover:
                        {
                            IssueWorkOrderPerClient.IWO_Discover(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    case Constants.Keybank:
                        {
                            IssueWorkOrderPerClient.IWO_Keybank(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    case Constants.Welchallyn:
                        {
                            IssueWorkOrderPerClient.IWO_Welchallyn(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    case Constants.APS:
                        {
                            IssueWorkOrderPerClient.IWO_APS(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    case Constants.StewartTitle:
                        {
                            IssueWorkOrderPerClient.IWO_StewartTitle(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    case Constants.Dyncorp:
                        {
                            IssueWorkOrderPerClient.IWO_Dyncorp(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    case Constants.Altria:
                        {
                            IssueWorkOrderPerClient.IWO_Altria(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    case Constants.Ryder:
                        {
                            IssueWorkOrderPerClient.IWO_Ryder(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    case Constants.KCPL:
                        {
                            IssueWorkOrderPerClient.IWO_KCPL(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }

                    case Constants.EMERSON:
                        {
                            IssueWorkOrderPerClient.IWO_Emerson(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    case Constants.SallieMae:
                        {
                            IssueWorkOrderPerClient.IWO_SallieMae(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    //case Constants.DcrSallieMae:
                    //    {
                    //        IssueWorkOrderPerClient.IWO_DcrSallieMae(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                    //        break;
                    //    }
                    case Constants.SOF:
                        {
                            IssueWorkOrderPerClient.IWO_SOF(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }

                    case Constants.HillRom:
                        {
                            IssueWorkOrderPerClient.IWO_HillRom(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    //case Constants.STNow:
                    //    {
                    //        IssueWorkOrderPerClient.IWO_STNow(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                    //        break;
                    //    }
                    case Constants.ThermoFisher:
                        {
                            IssueWorkOrderPerClient.IWO_ThermoFisher(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    case Constants.Colgate:
                        {
                            IssueWorkOrderPerClient.IWO_Colgate(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    case Constants.COE:
                        {
                            IssueWorkOrderPerClient.IWO_COE(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    case Constants.Bimbo:
                        {
                            IssueWorkOrderPerClient.IWO_Bimbo(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    case Constants.Georgetown:
                        {
                            IssueWorkOrderPerClient.IWO_Georgetown(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    case Constants.PHHMortgage:
                        {
                            IssueWorkOrderPerClient.IWO_PHHMortgage(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    case Constants.Tufts:
                        {
                            IssueWorkOrderPerClient.IWO_Tufts(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    case Constants.Tesla:
                        {
                            IssueWorkOrderPerClient.IWO_Tesla(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    case Constants.SunTrust:
                        {
                            IssueWorkOrderPerClient.IWO_SunTrust(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    case Constants.Cpchem:
                        {
                            IssueWorkOrderPerClient.IWO_Cpchem(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    case Constants.QuickenLoans:
                        {
                            IssueWorkOrderPerClient.IWO_QuickenLoans(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }

                    case Constants.Lear:
                        {
                            IssueWorkOrderPerClient.IWO_Lear(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    case Constants.EQT:
                        {
                            IssueWorkOrderPerClient.IWO_EQT(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }

                    case Constants.SIGMA:
                        {
                            IssueWorkOrderPerClient.IWO_SIGMA(issueWorkOrderModel, results, kwm, WDriver, objCommonMethods);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                // Ending Swith method
                objCommonMethods.SaveScreenShot_EachPage(WDriver, issueWorkOrderModel.strClientName + "_");
                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.Id_Button_Issueworkorder);

                if ((issueWorkOrderModel.str_Btn_IssueWorkOrder_Submit.ToLower().Trim() == "issue work order" || issueWorkOrderModel.str_Btn_IssueWorkOrder_Submit.ToLower().Trim() == "issue engagement"))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.Id_Button_Issueworkorder);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.Id_Button_Issueworkorder);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }
                }
                else
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Given button name not find " + issueWorkOrderModel.str_Btn_IssueWorkOrder_Submit;
                    return results;
                }

                objCommonMethods.SaveScreenShot_EachPage(WDriver, issueWorkOrderModel.strClientName + "_");
                results = kwm.Error_Msg_Read_Submit_Resume_details(WDriver, "//div[@" + KeyWords.locator_ID + "='contentDiv']/div/div/div/ul/li");
                if (results.Result1 == KeyWords.Result_PASS)
                {
                    if (results.ErrorMessage != "")
                    {
                        results.Result1 = KeyWords.Result_FAIL;
                        return results;
                    }
                }
                objCommonMethods.SaveScreenShot_EachPage(WDriver, issueWorkOrderModel.strClientName + "_");

                Boolean bDisplayed = false;
                try
                {
                    bDisplayed = WDriver.FindElement(By.Id("dialog-confirmIssue")).Displayed;
                }
                catch
                {
                    bDisplayed = false;
                }


                if (bDisplayed)
                {
                    Thread.Sleep(2000);
                 
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Btn_IssueWorkOrder_Submit_Confirm);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(15000);
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Btn_IssueWorkOrder_Submit_Confirm);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }
                }
                else
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Unable to find the confirm msg box";
                    return results;
                }
                objCommonMethods.SaveScreenShot_EachPage(WDriver, issueWorkOrderModel.strClientName + "_");
                kwm.waitForElementToBeVisible(WDriver, By.XPath("//div[@id='dialog-confirmIssue1']//div[@aria-live='polite']//label"), kwm._WDWait);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Btn_IssueWorkOrder_Submit_Confirm_Ok);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(15000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Btn_IssueWorkOrder_Submit_Confirm_Ok);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }

              

                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = "Issue Work Order";
                return results;
            }
            else
            {
                strSubLevel = "";
                objCommonMethods.SaveScreenShot_EachPage(WDriver, issueWorkOrderModel.strClientName + "_");
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, issueWorkOrderModel.str_Link_ActionList_IssueWorkOrder, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, issueWorkOrderModel.str_Link_ActionList_IssueWorkOrder, strSubLevel);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
                objCommonMethods.SaveScreenShot_EachPage(WDriver, issueWorkOrderModel.strClientName + "_");
                if (issueWorkOrderModel.str_Btn_IssueWorkOrder_Submit.ToLower().Trim() == "approve")
                {
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Btn_IssueWorkOrder_Submit);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Btn_IssueWorkOrder_Submit);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }
                }
                else
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Given button name not find " + issueWorkOrderModel.str_Btn_IssueWorkOrder_Submit;
                    return results;
                }

                objCommonMethods.SaveScreenShot_EachPage(WDriver, issueWorkOrderModel.strClientName + "_");
                results = kwm.Error_Msg_Read_Submit_Resume_details(WDriver, "//div[@" + KeyWords.locator_ID + "='contentDiv']/div/div/div/ul/li");
                if (results.Result1 == KeyWords.Result_PASS)
                {
                    if (results.ErrorMessage != "")
                    {
                        results.Result1 = KeyWords.Result_FAIL;
                        return results;
                    }
                }
                objCommonMethods.SaveScreenShot_EachPage(WDriver, issueWorkOrderModel.strClientName + "_");
                if (WDriver.FindElement(By.Id("dialog-confirmIssue")).Displayed)
                {
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Btn_IssueWorkOrder_Submit_Confirm);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(15000);
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Btn_IssueWorkOrder_Submit_Confirm);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }
                }
                else
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Unable to find the confirm msg box";
                    return results;
                }
                objCommonMethods.SaveScreenShot_EachPage(WDriver, issueWorkOrderModel.strClientName + "_");
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Btn_IssueWorkOrder_Submit_Confirm_Ok);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(15000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Btn_IssueWorkOrder_Submit_Confirm_Ok);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }



                //    results = CancelWorkOrder_Method(WDriver, IssueWorkOrder_Data); 


                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = "Approve Work Order";
                return results;
            }
        }

        
        public Result IssueWorkOrder_EditCandidateInfo(IWebDriver WDriver, DataRow IssueWorkOrder_Data)
        {

            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            IssueWorkOrderModel issueWorkOrderModel = createRequirementRepository.GetIssueWorkOrderData(IssueWorkOrder_Data);

            //Edit candidate information link click
            string strSubLevel = "./label";

            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, issueWorkOrderModel.str_Link_issueworkorder_Editcandidateinfo, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, issueWorkOrderModel.str_Link_issueworkorder_Editcandidateinfo, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }
            Thread.Sleep(1000);

            //Save button Click
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


                if (!strValue)
                {
                    break;
                }
                Thread.Sleep(100);
            }

            WDriver.FindElement(By.Id(KeyWords.ID_Button_btnSubmit)).Click();


            //Error msgs code
            //results = kwm.Error_Msg_Read_Submit_Resume_details(WDriver, "//div[@" + KeyWords.locator_ID + "='dialog']/div/div/div/ul/li");
            //if (results.Result1 == KeyWords.Result_PASS)
            //{
            //    if (results.ErrorMessage != "")
            //    {
            //        results.Result1 = KeyWords.Result_FAIL;
            //        return results;
            //    }
            //}

            // Click on ok button
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Button_issueworkorder_Editcandidateinfo_OK);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Button_issueworkorder_Editcandidateinfo_OK);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(10000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Button_issueworkorder_Editcandidateinfo_OK);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }

            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = "Edit Work Order information";
            return results;
        }


        public Result CancelWorkOrder_Method(IWebDriver WDriver, DataRow IssueWorkOrder_Data, int MSPExecutionRowNO)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            IssueWorkOrderModel issueWorkOrderModel = createRequirementRepository.GetIssueWorkOrderData(IssueWorkOrder_Data);


            Navigation_To_CandidateDetails_through_CandidateWithOffers(WDriver, IssueWorkOrder_Data, MSPExecutionRowNO);


            //Cancel work order click
            string strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, issueWorkOrderModel.str_Link_CancelWorkOrder, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, issueWorkOrderModel.str_Link_CancelWorkOrder, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }
            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = false;
                try
                {
                    strValue = WDriver.FindElement(By.Id("contentDiv")).Displayed;
                }
                catch
                {
                    kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, issueWorkOrderModel.str_Link_ActionList_IssueWorkOrder, strSubLevel);
                }

                if (strValue)
                {
                    break;
                }
            }


            // Cancel work order tab
            Thread.Sleep(2000);

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_tabsAll);


            objCommonMethods.Action_LookInto_Element_ID(WDriver, KeyWords.ID_Select_IssueworkordercancelReason);

            // Cancel Reason
            results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_IssueworkordercancelReason);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                try
                {
                    SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Select_IssueworkordercancelReason))); //Locating select list
                    se.SelectByIndex(2);
                }
                catch
                {
                    //
                }
            }

            //Cancel comment

            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Comments, issueWorkOrderModel.str_Txt_CancelWorkOrdercomment, false);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                //  return results;
            }

            //Cancel Work order buttons

            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(WDriver);
            Thread.Sleep(2000);



            results = kwm.click(WDriver, KeyWords.locator_ID, "IssueworkButton");

            //  WDriver.FindElement(By.XPath(KeyWords.Xpath_Button_Issueworkordercancel)).Click();

            //Error msgs code
            //results = kwm.Error_Msg_Read_Submit_Resume_details(WDriver, "//div[@" + KeyWords.locator_ID + "='dialog']/div/div/div/ul/li");
            //if (results.Result1 == KeyWords.Result_PASS)
            //{
            //    if (results.ErrorMessage != "")
            //    {
            //        results.Result1 = KeyWords.Result_FAIL;
            //        return results;
            //    }
            //}

            // Click on yes button
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Button_CancelWorkOrderbutton_yes);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Button_CancelWorkOrderbutton_yes);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(10000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Button_CancelWorkOrderbutton_yes);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }
            Thread.Sleep(2000);

            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Btn_ExtendOffer_Submit_Confirm_Ok);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Btn_ExtendOffer_Submit_Confirm_Ok);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(10000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Btn_ExtendOffer_Submit_Confirm_Ok);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }
            //  Thread.Sleep(10000);


            // Wait for Issuework order link will display
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            results = kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, issueWorkOrderModel.str_Link_ActionList_IssueWorkOrder);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                return results;
            }

            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = "Cancel Work Order";
            return results;

        }


        public Result Navigation_To_CandidateDetails_through_CandidateWithOffers(IWebDriver WDriver, DataRow SubmitToManager_Data, int MspExecutionNo)
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

            //Move to candidate with offeres link
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
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_CandidateWithoffers_Search), kwm._WDWait);
            results = kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_CandidateWithoffers_Search, submitToManagerModel.str_CandidateName, false);
            Thread.Sleep(2000);

            kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[starts-with(@aria-label,'Candidate Name: " + submitToManagerModel.str_CandidateName + "')]"), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[starts-with(@aria-label,'Candidate Name: " + submitToManagerModel.str_CandidateName + "')]"), kwm._WDWait);

            //Candidate name click
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManagerModel.str_CandidateName);
            kwm.click(WDriver, KeyWords.locator_XPath, "//*[starts-with(@aria-label,'Candidate Name: " + submitToManagerModel.str_CandidateName + "')]/a");

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);

            objCommonMethods.SaveScreenShot(WDriver, submitToManagerModel.strClientName + "_");

            // Click on Expand all link
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ExpandAll_tabsAll);
            Thread.Sleep(2000);


            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_strSubmitToManagerSuccessfully;
            return results;
        }


        public Result CandidateNoShow_And_RollBackNoShow(IWebDriver WDriver, DataRow IssueWorkOrder_Data, int MSPExecutionRowNO)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            IssueWorkOrderModel issueWorkOrderModel = createRequirementRepository.GetIssueWorkOrderData(IssueWorkOrder_Data);


            Navigation_To_CandidateDetails_through_CandidateWithOffers(WDriver, IssueWorkOrder_Data, MSPExecutionRowNO);


            //Click on Candidate No Show
            string strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, "Candidate No Show", strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, issueWorkOrderModel.str_Link_CancelWorkOrder, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            // Check Candidate is a No Show
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_check_CandidateNoShow_candidateIsNoShow), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_check_CandidateNoShow_candidateIsNoShow), kwm._WDWait);

            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_check_CandidateNoShow_candidateIsNoShow);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                return results;
            }

            // Enter Comment
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Candidate_Comment, "Candidate no show comment", false);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                //  return results;
            }

            // Click on Submit button
            results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_btn_CandidateNoShow_Submit);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                return results;
            }



            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_btn_CandidateNoShow_Yes), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_btn_CandidateNoShow_Yes), kwm._WDWait);
            // Click on yes button
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Button_CancelWorkOrderbutton_yes);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(10000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Button_CancelWorkOrderbutton_yes);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }
            Thread.Sleep(2000);

            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_btn_CandidateNoShow_OK), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_btn_CandidateNoShow_OK), kwm._WDWait);
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Btn_ExtendOffer_Submit_Confirm_Ok);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(10000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Btn_ExtendOffer_Submit_Confirm_Ok);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }


            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            Thread.Sleep(1000);

            // Verify candidate status
            results = kwm.GetText_Xpath(WDriver, KeyWords.Xpath_Label_CandidateStatus);
            String CandidateStatus = results._Var;
            if (CandidateStatus == "Candidate No-Show")
            {
            }
            else
            {
                return results;
            }



            // RollBack No Show -- starts here



            //Click on Candidate No Show
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, "RollBack No Show", strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, issueWorkOrderModel.str_Link_CancelWorkOrder, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            // Check Candidate is a No Show
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Check_RollbackNoshow), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Check_RollbackNoshow), kwm._WDWait);

            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Check_RollbackNoshow);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                return results;
            }

            // Enter Comment
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Candidate_Comment, "Candidate no show comment", false);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                //  return results;
            }

            // Click on Rollback no show
            results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_btn_CandidateRollbacknoshow_RollBackNoShow);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                return results;
            }



            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_btn_CandidateNoShow_Yes), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_btn_CandidateNoShow_Yes), kwm._WDWait);
            // Click on yes button
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Button_CancelWorkOrderbutton_yes);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(10000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Button_CancelWorkOrderbutton_yes);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }
            Thread.Sleep(2000);

            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_btn_CandidateRollbacknoshow_OK), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_btn_CandidateRollbacknoshow_OK), kwm._WDWait);
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Btn_ExtendOffer_Submit_Confirm_Ok);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(10000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, issueWorkOrderModel.str_Btn_ExtendOffer_Submit_Confirm_Ok);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }

            // 
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);

            // Verify candidate status
            results = kwm.GetText_Xpath(WDriver, KeyWords.Xpath_Label_CandidateStatus);
            CandidateStatus = results._Var;
            if (CandidateStatus == "WO Accepted")
            {
            }
            else
            {
                return results;
            }



            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = "Cancel Work Order";
            return results;

        }


    }
}