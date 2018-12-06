// --------------------------------------------------------------------------------------------------------------------
//<copyright file="ConfirmCW.cs" company="DCR Workforce Inc">
//   Copyright (c) DCR Workforce Inc. All rights reserved.
//   This code and information should not be copied and used outside of DCR Workforce Inc.
// </copyright>
// <summary>
//   Builds the Container for the Autofac IOC.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using SmartTrack;
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
using SmartTrack.DataAccess.Repository;
using SmartTrack.DataAccess.Models;
using CommonFiles;
using RelevantCodes.ExtentReports;

namespace SmartTrack_Automation
{
    // [TestClass]
    public class ConfirmCW
    {
        public Result ConfirmCW_Method(IWebDriver WDriver, DataRow ConfirmCW_Data, int SupExecutionRowNo)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            ConfirmCWModel confirmCWModel = createRequirementRepository.GetConfirmCWData(ConfirmCW_Data);
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
           


            listExistClients = new List<string>() { Constants.Discover };
            if (listExistClients.Contains(confirmCWModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, confirmCWModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, confirmCWModel.strClientName);
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
            if (!listExistClients.Contains(confirmCWModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, confirmCWModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, confirmCWModel.strClientName);
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

            objCommonMethods.SaveScreenShot_EachPage(WDriver, confirmCWModel.strClientName + "_");

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, confirmCWModel.strMainMenuLink, confirmCWModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, confirmCWModel.strMainMenuLink, confirmCWModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, confirmCWModel.strClientName + "_");
            string strSubLevel = "";
            if (confirmCWModel.strSubMenuLink.ToLower().Trim() != "candidate with offers")
            {

                try
                {
                    new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.XPath(KeyWords.XPath_paginate_regReqList_filter))));
                }
                catch
                {
                    for (int i = 0; i < 10; i++)
                    {
                        try
                        {
                            if (WDriver.FindElement(By.XPath(KeyWords.XPath_paginate_regReqList_filter)).Displayed)
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

                bool waiting = kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_SearchBox_Requirements_regReqList), kwm._WDWait);
                if (!waiting)
                {
                    kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_SearchBox_Requirements_regReqList), kwm._WDWait);
                }

                //Requirement number passed into search text box


                kwm.sendTextXPathOnly(WDriver, KeyWords.ID_paginate_regReqList_filter, confirmCWModel.str_Link_ReqNumber);
                //Wait until reuirement link or record is displaying
                kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_link_Reuirementnumber_Req), kwm._WDWait);

                //added for discover - to wait until the invisible of second row         
                bool CWtimewait = kwm.waitForElementInvisible(WDriver, By.XPath(KeyWords.XPath_secondrow), kwm._WDWait);
                if (!CWtimewait)
                {
                    kwm.waitForElementInvisible(WDriver, By.XPath(KeyWords.XPath_secondrow), kwm._WDWait);
                }

                //Requirement number click

                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + confirmCWModel.str_Link_ReqNumber + "')]");
                kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + confirmCWModel.str_Link_ReqNumber + "')]"), kwm._WDWait);
                Thread.Sleep(2000);
                results = kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='regReqList']/tbody/tr/td//a[contains(text(),'" + confirmCWModel.str_Link_ReqNumber + "')]");
                //Wait until left menu is loading
                kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);

                objCommonMethods.SaveScreenShot_EachPage(WDriver, confirmCWModel.strClientName + "_");


                //View candidate link click
                 strSubLevel = "";
                objCommonMethods.SaveScreenShot_EachPage(WDriver, confirmCWModel.strClientName + "_");
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, confirmCWModel.str_Link_ActionList_ViewCandidates, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, confirmCWModel.str_Link_ActionList_ViewCandidates, strSubLevel);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }


                //Wait for view candidates results page
                kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_txt_viewcanddates_Search), kwm._WDWait);
                kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_txt_viewcanddates_Search), kwm._WDWait);
                //Candidate name passed into text box
                results = kwm.sendTextXPathOnly(WDriver, KeyWords.XPath_txt_viewcanddates_Search, confirmCWModel.str_CandidateName);
                kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_Candidatename_MSP), kwm._WDWait);
                kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_link_Candidatename_MSP), kwm._WDWait);
                //Candidate name click
                //  kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_link_Candidatename_MSP);
                Thread.Sleep(3000);
                if (confirmCWModel.str_CandidateName != "")
                    try
                    {
                        // string strXpath_CandidateNameLink = "//table[contains(@id,'HistoryTable')]//td//a[text()[normalize-space()= '" + confirmCWModel.str_CandidateName + "']]";
                        string strXpath_CandidateNameLink = "//table[contains(@id,'regularCandidateListWithOffer')]//td//a[text()[normalize-space()= '" + confirmCWModel.str_CandidateName + "']]";
                        kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, strXpath_CandidateNameLink);
                        kwm.waitForElementToBeClickable(WDriver, By.XPath(strXpath_CandidateNameLink), kwm._WDWait);
                        //Candidate name click			
                        kwm.click(WDriver, KeyWords.locator_XPath, strXpath_CandidateNameLink);
                        //   WDriver.FindElement(By.LinkText(confirmCWModel.str_CandidateName)).Click();
                    }
                    catch
                    {
                        Thread.Sleep(100);
                        try
                        {
                            WDriver.FindElement(By.LinkText(confirmCWModel.str_CandidateName)).Click();
                        }
                        catch
                        {
                            // Console.WriteLine(bFlag);
                            results.Result1 = KeyWords.Result_FAIL;
                            results.ErrorMessage = "The given candidate name not find " + confirmCWModel.str_CandidateName;
                            return results;
                        }
                    }
                kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);


                objCommonMethods.SaveScreenShot_EachPage(WDriver, confirmCWModel.strClientName + "_");


                //Wait for view candidates results page
                //kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_Pageload_Candidatestable_MSP), kwm._WDWait);
                //Candidate name passed into text box
                //results = kwm.sendTextXPathOnly(WDriver, KeyWords.XPath_txt_viewcanddates_Search, confirmCWModel.str_CandidateName);

                //kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_link_Candidatename_MSP), kwm._WDWait);
                //Candidate name click
                //kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_link_Candidatename_MSP);

                //kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            }
            if (confirmCWModel.strSubMenuLink.ToLower().Trim() == "candidate with offers")
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
                kwm.sendTextXPathOnly(WDriver, "//*[@id='identifiedCandidateListWithOffers_filter']//label//input", confirmCWModel.str_CandidateName);

                kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='identifiedCandidateListWithOffers']//tbody/tr/td[2]/a[contains(text(),'" + confirmCWModel.str_CandidateName + "')]"), kwm._WDWait);

                objCommonMethods.SaveScreenShot_EachPage(WDriver, confirmCWModel.strClientName + "_");

                results = kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='identifiedCandidateListWithOffers']//tbody/tr/td[2]/a[contains(text(),'" + confirmCWModel.str_CandidateName + "')]");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='identifiedCandidateListWithOffers']//tbody/tr/td[2]/a[contains(text(),'" + confirmCWModel.str_CandidateName + "')]"), kwm._WDWait);
                    Thread.Sleep(2000);
                    results = kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='identifiedCandidateListWithOffers']//tbody/tr/td[2]/a[contains(text(),'" + confirmCWModel.str_CandidateName + "')]");
                
                }
                
                //*[@id="identifiedCandidateListWithOffers"]/tbody/tr/td[2]/a
                objCommonMethods.SaveScreenShot_EachPage(WDriver, confirmCWModel.strClientName + "_");
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, confirmCWModel.strClientName + "_");

            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, confirmCWModel.str_Link_ActionList_ConfirmCW, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(1000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, confirmCWModel.str_Link_ActionList_ConfirmCW, strSubLevel);
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
                    strValue = WDriver.FindElement(By.Id("lastName")).Displayed;
                }
                catch
                {
                    kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, confirmCWModel.str_Link_ActionList_ConfirmCW, strSubLevel);
                }
                //  Console.WriteLine("z -----> " + z);
                //  Console.WriteLine("strValue -----> " + strValue);
                if (strValue)
                {
                    break;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, confirmCWModel.strClientName + "_");
            //    Thread.Sleep(10000);
            kwm.click(WDriver, KeyWords.locator_ID, "tabsExpandCollapse");
            //for (int z = 1; z < 100; z++)
            //{
            //    objCommonMethods.Action_Page_UP(WDriver);
            //    Thread.Sleep(1000);
            //    objCommonMethods.Action_Page_UP(WDriver);
            //    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_tabsAll);
            //    Thread.Sleep(1000);
            //    string strImgName = "";
            //    try
            //    {
            //        strImgName = WDriver.FindElement(By.XPath("//*[@id='tabsAll']/img")).GetAttribute("src");
            //    }
            //    catch
            //    {
            //        strImgName = "";
            //    }
            //    //  Console.WriteLine("z -----> " + z);
            //    //  Console.WriteLine("strValue -----> " + strValue);
            //    if (strImgName.Contains("minusBlue-20.png"))
            //    {
            //        break;
            //    }
            //}


            objCommonMethods.SaveScreenShot_EachPage(WDriver, confirmCWModel.strClientName + "_");



            switch (confirmCWModel.strClientName.ToLower())
            {

                case Constants.Sts:
                    {
                        ConfirmPerClient.ConfirmSTS(confirmCWModel, results, kwm, WDriver, objCommonMethods);

                        break;
                    }
                //case Constants.IsGs:
                //    {
                //        ConfirmPerClient.ConfirmISGS(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                //        break;
                //    }
                case Constants.EBS:
                    {
                        ConfirmPerClient.ConfirmEBS(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.RMS:
                    {
                        ConfirmPerClient.ConfirmRMS(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                case Constants.STGEN:
                    {
                        ConfirmPerClient.ConfirmSTGEN(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.STTM:
                    {
                        ConfirmPerClient.ConfirmSTTM(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.MFC:
                    {
                        ConfirmPerClient.ConfirmMFC(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                //case Constants.NvEnergy:
                //    {
                //        ConfirmPerClient.ConfirmNVENERGY(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                //        break;
                //    }


                //case Constants.AmCom:
                //    {
                //        ConfirmPerClient.ConfirmAmCom(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                //        break;
                //    }
                //case Constants.DCR:
                //    {
                //        ConfirmPerClient.ConfirmDCR(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                //        break;
                //    }
              
                //case Constants.Meritor:
                //    {
                //        ConfirmPerClient.ConfirmMeritor(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                //        break;
                //    }
                //case Constants.GHC:
                //    {
                //        ConfirmPerClient.ConfirmGHC(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                //        break;
                //    }

                //case Constants.BDA:
                //    {
                //        ConfirmPerClient.ConfirmBDA(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                //        break;
                //    }
                case Constants.Arkema:
                    {
                        ConfirmPerClient.ConfirmArkema(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                //case Constants.Aero:
                //    {
                //        ConfirmPerClient.ConfirmAero(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                //        break;
                //    }
                case Constants.Supervalu:
                    {
                        ConfirmPerClient.ConfirmSupervalu(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Caesars:
                    {
                        ConfirmPerClient.ConfirmCaesars(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Epri:
                    {
                        ConfirmPerClient.ConfirmEpri(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                //case Constants.Costco:
                //    {
                //        ConfirmPerClient.ConfirmCostco(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                //        break;
                //    }
                case Constants.Discover:
                    {
                        ConfirmPerClient.ConfirmDiscover(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Keybank:
                    {
                        ConfirmPerClient.ConfirmKeybank(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Welchallyn:
                    {
                        ConfirmPerClient.ConfirmWelchallyn(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.APS:
                    {
                        ConfirmPerClient.ConfirmAPS(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.StewartTitle:
                    {
                        ConfirmPerClient.ConfirmStewartTitle(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Dyncorp:
                    {
                        ConfirmPerClient.ConfirmDyncorp(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Altria:
                    {
                        ConfirmPerClient.ConfirmAltria(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Ryder:
                    {
                        ConfirmPerClient.ConfirmRyder(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.KCPL:
                    {
                        ConfirmPerClient.ConfirmKCPL(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                case Constants.EMERSON:
                    {
                        ConfirmPerClient.ConfirmEmerson(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.SallieMae:
                    {
                        ConfirmPerClient.ConfirmSallieMae(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                //case Constants.DcrSallieMae:
                //    {
                //        ConfirmPerClient.ConfirmDcrSallieMae(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                //        break;
                //    }
                case Constants.SOF:
                    {
                        ConfirmPerClient.ConfirmSOF(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                case Constants.HillRom:
                    {
                        ConfirmPerClient.ConfirmHillRom(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Bimbo:
                    {
                        ConfirmPerClient.ConfirmBimbo(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                //case Constants.Martiz:
                //    {
                //        ConfirmPerClient.ConfirmMartiz(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                //        break;
                //    }
                case Constants.Colgate:
                    {
                        ConfirmPerClient.ConfirmColgate(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                //case Constants.STNow:
                //    {
                //        ConfirmPerClient.ConfirmSTNow(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                //        break;
                //    }
                case Constants.ThermoFisher:
                    {
                        ConfirmPerClient.ConfirmThermoFisher(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                case Constants.SunTrust:
                    {
                        ConfirmPerClient.ConfirmSunTrust(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Tufts:
                    {
                        ConfirmPerClient.ConfirmTufts(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                case Constants.PHHMortgage:
                    {
                        ConfirmPerClient.ConfirmPHHMortgage(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                case Constants.Cpchem:
                    {
                        ConfirmPerClient.ConfirmCpchem(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                case Constants.Tesla:
                    {
                        ConfirmPerClient.ConfirmTesla(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.COE:
                    {
                        ConfirmPerClient.ConfirmCOE(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Georgetown:
                    {
                        ConfirmPerClient.ConfirmGeorgetown(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.QuickenLoans:
                    {
                        ConfirmPerClient.ConfirmQuickenLoans(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.YP:
                    {
                        ConfirmPerClient.ConfirmYP(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Lear:
                    {
                        ConfirmPerClient.ConfirmLear(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.EQT:
                    {
                        ConfirmPerClient.ConfirmEQT(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.SIGMA:
                    {
                        ConfirmPerClient.ConfirmSIGMA(confirmCWModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            objCommonMethods.Action_Page_Down(WDriver);

            objCommonMethods.SaveScreenShot_EachPage(WDriver, confirmCWModel.strClientName + "_");
            if (confirmCWModel.str_Btn_ConfirmCW_Submit.ToLower().Trim() != "Confirm CW")
            {

                results = kwm.click(WDriver, KeyWords.locator_ID, "UpdateCWButton");

                //   results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, confirmCWModel.str_Btn_ConfirmCW_Submit);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.click(WDriver, KeyWords.locator_ID, "UpdateCWButton");
                    //  results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, confirmCWModel.str_Btn_ConfirmCW_Submit);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }
            else
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Given button name not find " + confirmCWModel.str_Btn_ConfirmCW_Submit;
                return results;
            }


            objCommonMethods.SaveScreenShot_EachPage(WDriver, confirmCWModel.strClientName + "_");
            results = kwm.Error_Msg_Read_Submit_Resume_details(WDriver, "//div[@" + KeyWords.locator_ID + "='ulMspUserError']/li");
            if (results.Result1 == KeyWords.Result_PASS)
            {
                if (results.ErrorMessage != "")
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    return results;
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, confirmCWModel.strClientName + "_");
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 10);

            kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[contains(@" + KeyWords.locator_type + ", '" + KeyWords.locator_button + "') and text()='" + confirmCWModel.str_Btn_ConfirmCW_Submit_Confirm.Trim() + "']"), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[contains(@" + KeyWords.locator_type + ", '" + KeyWords.locator_button + "') and text()='" + confirmCWModel.str_Btn_ConfirmCW_Submit_Confirm.Trim() + "']"), kwm._WDWait);
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, confirmCWModel.str_Btn_ConfirmCW_Submit_Confirm);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, confirmCWModel.str_Btn_ConfirmCW_Submit_Confirm);

            }
           


            Thread.Sleep(2000);

            objCommonMethods.SaveScreenShot_EachPage(WDriver, confirmCWModel.strClientName + "_");


            kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[contains(@" + KeyWords.locator_type + ", '" + KeyWords.locator_button + "') and text()='" + confirmCWModel.str_Btn_ConfirmCW_Submit_Confirm_Ok.Trim() + "']"), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[contains(@" + KeyWords.locator_type + ", '" + KeyWords.locator_button + "') and text()='" + confirmCWModel.str_Btn_ConfirmCW_Submit_Confirm_Ok.Trim() + "']"), kwm._WDWait);
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, confirmCWModel.str_Btn_ConfirmCW_Submit_Confirm_Ok);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(2000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, confirmCWModel.str_Btn_ConfirmCW_Submit_Confirm_Ok);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            //  Thread.Sleep(10000);
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = "Confirm CW";
            return results;

        }
    }
}
