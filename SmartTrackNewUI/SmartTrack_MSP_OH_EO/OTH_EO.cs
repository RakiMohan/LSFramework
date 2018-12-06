
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
//using System.Data.OracleClient;
using System.Net;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using OpenQA.Selenium.Interactions;
using CommonFiles;
using SmartTrack.DataAccess.Repository;
using SmartTrack.DataAccess.Models;
using RelevantCodes.ExtentReports;

namespace SmartTrack_Automation
{
    // [TestClass]

    public class OTH_EO
    {

        public Result OfferToHire_Method_Full(IWebDriver WDriver, DataRow OfferToHire_Data)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            SubmitToManOfferToHireModel submitToManOfferToHireModel = createRequirementRepository.GetSubmitToManOfferToHireData(OfferToHire_Data);
            WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(100));

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManOfferToHireModel.strClientName + "_");
            listExistClients = new List<string>() { Constants.Discover };
            if (listExistClients.Contains(submitToManOfferToHireModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManOfferToHireModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManOfferToHireModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Boolean bFlagDropDwon = false;
                        try
                        {
                            bFlagDropDwon = kwm.isElementEnabledByXPath(WDriver, KeyWords.XPath_supplierMenu_ClientDropDown);
                            //bFlagDropDwon = WDriver.FindElement(By.XPath(KeyWords.XPath_supplierMenu_ClientDropDown)).Enabled;
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
            if (!listExistClients.Contains(submitToManOfferToHireModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManOfferToHireModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManOfferToHireModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Boolean bFlagDropDwon = false;
                        try
                        {
                            bFlagDropDwon = kwm.isElementEnabledByXPath(WDriver, KeyWords.XPath_supplierMenu_ClientDropDown);
                            // bFlagDropDwon = WDriver.FindElement(By.XPath(KeyWords.XPath_supplierMenu_ClientDropDown)).Enabled;
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

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManOfferToHireModel.strClientName + "_");

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManOfferToHireModel.strMainMenuLink, submitToManOfferToHireModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManOfferToHireModel.strMainMenuLink, submitToManOfferToHireModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManOfferToHireModel.strClientName + "_");

            string[] separators = { " " };
            string value = results.ErrorMessage;
            string[] words;


            if (submitToManOfferToHireModel.strSubMenuLink.ToLower().Contains("identified"))
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




            //Added new code
            //try
            //{
            //    new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.XPath(KeyWords.ID_paginate_regReqList_filter))));
            //}
            //catch
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        try
            //        {
            //            if (kwm.isElementDisplayedByXPath(WDriver, KeyWords.XPath_paginate_regReqList_filter))
            //            //if (WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).Displayed)
            //            {
            //                break;
            //            }
            //            Thread.Sleep(100);
            //        }
            //        catch
            //        {
            //            //
            //        }
            //    }
            //}


      //      new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.XPath_link_Reuirementnumber_Req))));

            //Search requirement

            if (submitToManOfferToHireModel.strSubMenuLink.ToLower().Contains("identified"))
            {

                kwm.sendTextXPathOnly(WDriver, KeyWords.XPath_SearchBox_IdentifiedRequirements_regReqList, submitToManOfferToHireModel.str_Link_ReqNumber);
            }
            else
            {
                kwm.sendTextXPathOnly(WDriver,  KeyWords.XPath_SearchBox_Requirements_regReqList, submitToManOfferToHireModel.str_Link_ReqNumber);
            }




           // kwm.sendTextXPathOnly(WDriver, KeyWords.ID_paginate_regReqList_filter, submitToManOfferToHireModel.str_Link_ReqNumber);
           // Thread.Sleep(1000);

            //Wait for Requirement to load
            if (submitToManOfferToHireModel.strSubMenuLink.ToLower().Contains("identified"))
            {
                //if (kwm.waitForElementInvisible(WDriver, By.XPath(KeyWords.XPath_Img_Processing), kwm._WDWait))
                //{
              //  kwm.waitForElementToBeClickable(WDriver, By.XPath("//table[@id='IdentifiedReqList']//td/a[contains(text(),'" + broadcastModel.str_Link_ReqNumber + "')]"), kwm._WDWait);
                    //kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_IdentifiedReuirementnumber_Req), kwm._WDWait);
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(KeyWords.XPath_link_IdentifiedReuirementnumber_Req)));
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(KeyWords.XPath_link_IdentifiedReuirementnumber_Req)));
                //}
            }
            else
            {
                //if (!kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_Img_Processing), kwm._WDWait))
                //{
                //    kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_Reuirementnumber_Req), kwm._WDWait);
                //}
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(KeyWords.XPath_link_Reuirementnumber_Req)));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(KeyWords.XPath_link_Reuirementnumber_Req)));
            }



           // kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_Reuirementnumber_Req), kwm._WDWait);
            Thread.Sleep(1000);
        //    kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_link_Reuirementnumber_Req);
            if (submitToManOfferToHireModel.strSubMenuLink.ToLower().Contains("identified"))
            {
                kwm.click(WDriver, KeyWords.locator_XPath, "//table[@id='IdentifiedReqList']//td/a[contains(text(),'" + submitToManOfferToHireModel.str_Link_ReqNumber + "')]");
            }
            else
            {
                kwm.click(WDriver, KeyWords.locator_XPath, "//table[@id='regReqList']//td/a[contains(text(),'" + submitToManOfferToHireModel.str_Link_ReqNumber + "')]");
            }


            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManOfferToHireModel.strClientName + "_");
            string strSubLevel = "";
            if (!submitToManOfferToHireModel.strSubMenuLink.ToLower().Contains("identified"))
            {
            //   Thread.Sleep(10000);
            for (int z = 1; z < 500; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = kwm.isElementDisplayed(WDriver, KeyWords.ID_STR_loading_message);
                    //strValue = WDriver.FindElement(By.Id("loading-message")).Displayed;
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
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManOfferToHireModel.str_Link_ActionList_ViewCandidates);
            strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManOfferToHireModel.str_Link_ActionList_ViewCandidates, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                objCommonMethods.Action_Page_Down(WDriver);
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManOfferToHireModel.str_Link_ActionList_ViewCandidates, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            listExistClients = new List<string>() { "ryder" };
            if (listExistClients.Contains(submitToManOfferToHireModel.strClientName.ToLower()))
            {
                KeyWords.ID_ListInfo_HistoryTableViewCandidate = "HistoryTableViewCandidate";
            }

            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_link_Candidatename_ExtendOffer_candidatename), kwm._WDWait);
            results = kwm.sendTextXPathOnly(WDriver, KeyWords.XPath_Text_search_ExtendOffer_candidatename, submitToManOfferToHireModel.str_CandidateName);
            //Page loading

            for (int z = 1; z < 500; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = kwm.isElementDisplayed(WDriver, KeyWords.ID_STR_loading_message);
                    //strValue = WDriver.FindElement(By.Id("loading-message")).Displayed;
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
            //Candidate name click

            //need to added in the server
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.XPath_link_Candidatename_ExtendOffer_candidatename);

            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_link_Candidatename_ExtendOffer_candidatename), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_link_Candidatename_ExtendOffer_candidatename);
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManOfferToHireModel.strClientName + "_");

            //end


            //kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_link_Candidatename_ExtendOffer_candidatename);

            //kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);


            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManOfferToHireModel.strClientName + "_");
            if (submitToManOfferToHireModel.strClientName.ToLower().ToString() != Constants.APS)
            {
                // WDriver.FindElement(By.XPath("//span[text()='Expand All']")).Click();
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Button_Expandall_Expand);
                objCommonMethods.Action_Page_Down(WDriver);
            }


        }
            //Offer to Hire 
            Thread.Sleep(5000);
            //objCommonMethods.Action_LookInto_Element_(WDriver, submitToManOfferToHireModel.str_Link_ActionList_OfferToHire);
            strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManOfferToHireModel.str_Link_ActionList_OfferToHire, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                objCommonMethods.Action_Page_Down_javascriptexecutor(WDriver);
                Thread.Sleep(2000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManOfferToHireModel.str_Link_ActionList_OfferToHire, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManOfferToHireModel.strClientName + "_");

            // Thread.Sleep(5000);

            for (int z = 1; z < 500; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = kwm.isElementDisplayed(WDriver, KeyWords.ID_STR_loading_message);
                    //strValue = WDriver.FindElement(By.Id("loading-message")).Displayed;
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
            if (submitToManOfferToHireModel.strClientName.ToLower().ToString() == Constants.APS)
            {
                kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_Tab_Offer), kwm._WDWait);
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Tab_Offer);
            }

            // Outline Tab continue
            objCommonMethods.Action_LookInto_Element_ID(WDriver, KeyWords.ID_button_OutlineTab_btnbtnContinue);
            Thread.Sleep(1000);

            if (!submitToManOfferToHireModel.strSubMenuLink.ToLower().Contains("identified"))
            {


                if (submitToManOfferToHireModel.strClientName.ToLower().ToString() != Constants.APS)
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_button_OutlineTab_btnbtnContinue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_button_OutlineTab_btnbtnContinue);
                    }

                    objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManOfferToHireModel.strClientName + "_");

                    if (submitToManOfferToHireModel.str_Txt_ProposeDifferentRate == "Accept Rates")
                    {
                        try
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.XPath_RadioButton_AcceptRates);
                            // WDriver.FindElement(By.XPath(KeyWords.XPath_RadioButton_AcceptRates)).Click();
                        }
                        catch
                        {
                            Console.WriteLine("Click on radio button" + submitToManOfferToHireModel.str_Txt_ProposeDifferentRate);
                        }
                    }
                    //proposed diff rate
                    if (submitToManOfferToHireModel.str_Txt_ProposeDifferentRate == "Propose Different Rate")
                    {
                        try
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.XPath_RadioButton_ProposeDifferentRate);
                            // WDriver.FindElement(By.XPath(KeyWords.XPath_RadioButton_ProposeDifferentRate)).Click();
                        }
                        catch
                        {
                            Console.WriteLine("Click on radio button" + submitToManOfferToHireModel.str_Txt_ProposeDifferentRate);
                        }
                        listExistClients = new List<string>() { Constants.Supervalu, Constants.GHC, Constants.BDA, Constants.Arkema, Constants.Meritor, Constants.Epri, Constants.Caesars, Constants.Tufts };
                        if (listExistClients.Contains(submitToManOfferToHireModel.strClientName.ToLower()))
                        {
                            if (submitToManOfferToHireModel.str_Txt_Proposebillrate != "")
                                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Proposebillrate, submitToManOfferToHireModel.str_Txt_Proposebillrate, true);

                            if (submitToManOfferToHireModel.str_Txt_Proposeotbillrate != "")
                                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Proposeotbillrate, submitToManOfferToHireModel.str_Txt_Proposeotbillrate, true);
                        }

                        listExistClients = new List<string>() { Constants.SaviTechnologies, Constants.DCR, Constants.Meritor, Constants.Epri, Constants.Caesars };
                        if (listExistClients.Contains(submitToManOfferToHireModel.strClientName.ToLower()))
                        {
                            if (submitToManOfferToHireModel.str_Txt_Proposebillrate != "")
                                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ProposedFinalRegBillRate, submitToManOfferToHireModel.str_Txt_Proposebillrate, true);
                            if (submitToManOfferToHireModel.str_Txt_Proposeotbillrate != "")
                                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ProposedFinalOTBillRate, submitToManOfferToHireModel.str_Txt_Proposeotbillrate, true);
                        }
                        listExistClients = new List<string>() { Constants.RMS, Constants.STGEN, Constants.LmPinellas, Constants.NvEnergy, Constants.Meritor, Constants.Sts, Constants.IsGs, Constants.EBS, Constants.SOF, Constants.STTTM, Constants.MFC, Constants.Costco };
                        if (listExistClients.Contains(submitToManOfferToHireModel.strClientName.ToLower()))
                        {
                            if (submitToManOfferToHireModel.str_Txt_Proposebillrate != "")
                                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Proposepayrate, submitToManOfferToHireModel.str_Txt_Proposebillrate, true);
                            if (submitToManOfferToHireModel.str_Txt_Proposeotbillrate != "")
                                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Proposeotpayrate, submitToManOfferToHireModel.str_Txt_Proposeotbillrate, true);
                        }
                    }
                }

                //added by manjusha
                objCommonMethods.Action_Page_UP(WDriver);
                var WriteExlResult = new Result();
                ReadExcel ReadExcelHelper = new ReadExcel();
                kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_lable_Rates_SupplierBillrate), kwm._WDWait);
                results = kwm.GetText_Xpath(WDriver, KeyWords.Xpath_lable_Rates_SupplierBillrate);
                String strUpdateSqlMain_SupplierBillRate = "Update [MSP$] set P81 ='" + results._Var + "'  WHERE P3 ='" + submitToManOfferToHireModel.strClientName + "' and TestScenario ='001' and TestCaseID = '007'";
                WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain_SupplierBillRate);
                submitToManOfferToHireModel.str_Txt_Billrate_Supplierbillrate = results._Var;
                //Update in Extend offer page
                String strUpdateSqlMain_SupplierBillRate_EO = "Update [MSP$] set P81 ='" + submitToManOfferToHireModel.str_Txt_Billrate_Supplierbillrate + "'  WHERE P3 ='" + submitToManOfferToHireModel.strClientName + "' and TestScenario ='001' and TestCaseID = '051'";
                WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain_SupplierBillRate_EO);
                //Update in Issue work order page
                String strUpdateSqlMain_SupplierBillRate_IWO = "Update [MSP$] set P81 ='" + submitToManOfferToHireModel.str_Txt_Billrate_Supplierbillrate + "'  WHERE P3 ='" + submitToManOfferToHireModel.strClientName + "' and TestScenario ='001' and TestCaseID = '009'";
                WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain_SupplierBillRate_IWO);
                //Update in Confirm CW page
                String strUpdateSqlMain_SupplierBillRate_CW = "Update [MSP$] set P204 ='" + submitToManOfferToHireModel.str_Txt_Billrate_Supplierbillrate + "'  WHERE P3 ='" + submitToManOfferToHireModel.strClientName + "' and TestScenario ='001' and TestCaseID = '012'";
                WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain_SupplierBillRate_CW);


                //Number of hours
                results = kwm.GetText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE);
                String strUpdateSqlMain_NumofHours = "Update [MSP$] set P82 ='" + results.ErrorMessage + "'  WHERE P3 ='" + submitToManOfferToHireModel.strClientName + "' and TestScenario ='001' and TestCaseID = '007'";
                WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain_NumofHours);
                submitToManOfferToHireModel.str_Txt_numberofhours_offertoHire = results.ErrorMessage;

                //Estimated contract Vlaue
                results = kwm.GetText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue);
                String strUpdateSqlMain_EstimatedContractvalue = "Update [MSP$] set P84 ='" + results.ErrorMessage + "'  WHERE P3 ='" + submitToManOfferToHireModel.strClientName + "' and TestScenario ='001' and TestCaseID = '007'";
                WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain_EstimatedContractvalue);
                submitToManOfferToHireModel.str_Txt_Estimatedcontract_offertoHire = results.ErrorMessage;
                //Estimated Contract value in Eoffer page
                String strUpdateSqlMain_EstimatedContractvalue_EO = "Update [MSP$] set P84 ='" + submitToManOfferToHireModel.str_Txt_Estimatedcontract_offertoHire + "'  WHERE P3 ='" + submitToManOfferToHireModel.strClientName + "' and TestScenario ='001' and TestCaseID = '051'";
                WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain_EstimatedContractvalue_EO);
                //Estimated Contract value in IWO page
                String strUpdateSqlMain_EstimatedContractvalue_IWO = "Update [MSP$] set P84 ='" + submitToManOfferToHireModel.str_Txt_Estimatedcontract_offertoHire + "'  WHERE P3 ='" + submitToManOfferToHireModel.strClientName + "' and TestScenario ='001' and TestCaseID = '009'";
                WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain_EstimatedContractvalue_IWO);
                //Estimated Contract value in Confirm CW page

                String strUpdateSqlMain_EstimatedContractvalue_CW = "Update [MSP$] set P205 ='" + submitToManOfferToHireModel.str_Txt_Estimatedcontract_offertoHire + "'  WHERE P3 ='" + submitToManOfferToHireModel.strClientName + "' and TestScenario ='001' and TestCaseID = '012'";
                WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain_EstimatedContractvalue_CW);



                if (submitToManOfferToHireModel.str_Select_dayID != "")
                {
                    kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_dayID, submitToManOfferToHireModel.str_Select_dayID);
                }

                if (submitToManOfferToHireModel.str_Txt_weeklyRegHoursNTE != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_weeklyRegHoursNTE, submitToManOfferToHireModel.str_Txt_weeklyRegHoursNTE, true);

                if (submitToManOfferToHireModel.str_Txt_weeklyOTHoursNTE != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_weeklyOTHoursNTE, submitToManOfferToHireModel.str_Txt_weeklyOTHoursNTE, true);

                if (submitToManOfferToHireModel.str_Txt_yearlyRegHoursNTE != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_yearlyRegHoursNTE, submitToManOfferToHireModel.str_Txt_yearlyRegHoursNTE, true);

                if (submitToManOfferToHireModel.str_Txt_totalContractValue != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_totalContractValue, submitToManOfferToHireModel.str_Txt_totalContractValue, true);


                if (submitToManOfferToHireModel.str_RadioButton_Emailwithcontractusage.ToLower().Trim() == "yes")
                {
                    try
                    {
                        WDriver.FindElement(By.XPath(KeyWords.ID_RadioButton_Yes_rbEmailwithContractusage)).Click();
                    }
                    catch
                    {
                        Console.WriteLine("Click on radio button " + submitToManOfferToHireModel.str_RadioButton_Emailwithcontractusage);
                    }
                    if (submitToManOfferToHireModel.str_Select_ddemailschedule != "")
                    {
                        kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_ddemailschedule, submitToManOfferToHireModel.str_Select_ddemailschedule);
                    }
                }
                else
                {
                    try
                    {
                        WDriver.FindElement(By.XPath(KeyWords.ID_RadioButton_No_rbEmailwithContractusage)).Click();
                    }
                    catch
                    {
                        Console.WriteLine("Click on radio button " + submitToManOfferToHireModel.str_RadioButton_Emailwithcontractusage);
                    }
                }


                if (submitToManOfferToHireModel.str_Txt_PrefStartdate != "")
                {
                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_txtneededStartDate);
                    // results = kwm.Select_Start_Date_From_Picker(WDriver, submitToManOfferToHireModel.str_Txt_PrefStartdate);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_PrefStartdate, submitToManOfferToHireModel.str_Txt_PrefStartdate, false);
                }

                objCommonMethods.Action_Button_Tab(WDriver);
                if (submitToManOfferToHireModel.str_Txt_enddate != "")
                {
                    // results = kwm.Select_End_Date_From_Picker(WDriver, submitToManOfferToHireModel.str_Txt_enddate);
                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_txtenddate);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_enddate, submitToManOfferToHireModel.str_Txt_enddate, false);
                }

                if (submitToManOfferToHireModel.strClientName.ToLower().ToString() == Constants.APS)
                {
                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Button_Popup_ExtendOffer);
                }
                else
                {
                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_btnbtnSubmit);
                }

                objCommonMethods.Action_Page_Down(WDriver);

                listExistClients = new List<string>() { Constants.Supervalu, Constants.IsGs, Constants.Sts, Constants.SaviTechnologies, Constants.GHC, Constants.BDA, Constants.AmCom, Constants.LmPinellas, Constants.NvEnergy, Constants.DCR, Constants.KCPL };
                if (listExistClients.Contains(submitToManOfferToHireModel.strClientName.ToLower()))
                {
                    if (submitToManOfferToHireModel.str_AddListTxt_txtTimecardApprover != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManOfferToHireModel.str_AddListTxt_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            for (int r = 0; r < words.Length; r++)
                            {
                                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                                if (results.Result1 == KeyWords.Result_FAIL)
                                {
                                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                                    //  return results;
                                }
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addTimecardApproverbtn);
                            }
                        }
                    }
                }

                Thread.Sleep(5000);
                // KCPL  Charge Number *------------venky code added
                if (submitToManOfferToHireModel.strClientName.ToLower().ToString() == Constants.KCPL)
                {

                    //GL Business Unit * 
                    if (submitToManOfferToHireModel.str_select_GLBusinessUnit_chargeGLId != "")
                    {
                        kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_GLBusinessUnit_chargeGLId, submitToManOfferToHireModel.str_select_GLBusinessUnit_chargeGLId);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_GLBusinessUnit_chargeGLId, submitToManOfferToHireModel.str_select_GLBusinessUnit_chargeGLId);
                        }
                    }

                    //Account *
                    if (submitToManOfferToHireModel.str_Typeahead_Account_chargeCostCenterId != "")
                    {
                        results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_Account_chargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_Typeahead_Account_chargeCostCenterId, submitToManOfferToHireModel.str_Typeahead_Account_chargeCostCenterId);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_Account_chargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_Typeahead_Account_chargeCostCenterId, submitToManOfferToHireModel.str_Typeahead_Account_chargeCostCenterId);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_Account_chargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, "1");
                                //returnresults;
                            }
                        }
                    }
                    // Operating Unit 
                    if (submitToManOfferToHireModel.str_Typeahead_OperatingUnit_chargeProfitCenterId != "")
                    {
                        results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_OperatingUnit_chargeProfitCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_Typeahead_OperatingUnit_chargeProfitCenterId, submitToManOfferToHireModel.str_Typeahead_OperatingUnit_chargeProfitCenterId);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_OperatingUnit_chargeProfitCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_Typeahead_OperatingUnit_chargeProfitCenterId, submitToManOfferToHireModel.str_Typeahead_OperatingUnit_chargeProfitCenterId);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_OperatingUnit_chargeProfitCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, "1");
                                //returnresults;
                            }
                        }
                    }
                    // Department ID 
                    if (submitToManOfferToHireModel.str_Typeahead_DepartmentID_chargedeptNumber != "")
                    {
                        results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_DepartmentID_chargedeptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_Typeahead_DepartmentID_chargedeptNumber, submitToManOfferToHireModel.str_Typeahead_DepartmentID_chargedeptNumber);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_DepartmentID_chargedeptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_Typeahead_DepartmentID_chargedeptNumber, submitToManOfferToHireModel.str_Typeahead_DepartmentID_chargedeptNumber);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_DepartmentID_chargedeptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, "1");
                                //returnresults;
                            }
                        }
                    }
                    // Project ID
                    if (submitToManOfferToHireModel.str_Typeahead_ProjectID_chargeProjectId != "")
                    {
                        results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ProjectID_chargeProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_Typeahead_ProjectID_chargeProjectId, submitToManOfferToHireModel.str_Typeahead_ProjectID_chargeProjectId);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ProjectID_chargeProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_Typeahead_ProjectID_chargeProjectId, submitToManOfferToHireModel.str_Typeahead_ProjectID_chargeProjectId);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ProjectID_chargeProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, "1");
                                //returnresults;
                            }
                        }
                    }
                    // Work ID 
                    if (submitToManOfferToHireModel.str_Typeahead_WorkID_chargeprogramId != "")
                    {
                        results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_WorkID_chargeprogramId, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_Typeahead_WorkID_chargeprogramId, submitToManOfferToHireModel.str_Typeahead_WorkID_chargeprogramId);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_WorkID_chargeprogramId, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_Typeahead_WorkID_chargeprogramId, submitToManOfferToHireModel.str_Typeahead_WorkID_chargeprogramId);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_WorkID_chargeprogramId, KeyWords.locator_class, KeyWords.CL_list_typeahead, "1");
                                //returnresults;
                            }
                        }
                    }
                    //Resource 
                    if (submitToManOfferToHireModel.str_select_Resource_chargespendLevelId != "")
                    {
                        kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_Resource_chargespendLevelId, submitToManOfferToHireModel.str_select_Resource_chargespendLevelId);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_Resource_chargespendLevelId, submitToManOfferToHireModel.str_select_Resource_chargespendLevelId);
                        }
                    }

                    //Add charge num plus button
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_button_addchargenumber_addChargeNobtnNew);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_button_addchargenumber_addChargeNobtnNew);
                    }
                }




                objCommonMethods.Action_Page_Down(WDriver);
                if (submitToManOfferToHireModel.strClientName.ToLower().ToString() == Constants.Epri)
                {
                    // Allocate Budget Code in EPRI Client 
                    //Thread.Sleep(3000);

                    // Financial Number
                    if (submitToManOfferToHireModel.str_typehead_FinancialNumber_financialNumber != "")
                    {
                        results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_typehead_FinancialNumber_financialNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_typehead_FinancialNumber_financialNumber, submitToManOfferToHireModel.str_typehead_FinancialNumber_financialNumber);
                        Thread.Sleep(2000);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_typehead_FinancialNumber_financialNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_typehead_FinancialNumber_financialNumber, submitToManOfferToHireModel.str_typehead_FinancialNumber_financialNumber);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_typehead_FinancialNumber_financialNumber, KeyWords.locator_class, KeyWords.ID_typehead_FinancialNumber_financialNumber, "a");
                                return results;
                            }
                        }
                    }

                    // Financial Line Item Number
                    if (submitToManOfferToHireModel.str_txt_FinancialLineItemNumber_financialLineItemNumber != "")
                    {
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinancialLineItemNumber_financialLineItemNumber, "test", false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinancialLineItemNumber_financialLineItemNumber, "test", false);
                            // return results;
                        }
                    }

                    Thread.Sleep(2000);
                    objCommonMethods.Action_LookInto_Element_ID(WDriver, KeyWords.ID_txt_EstimatedContractValue_totalContractValue);

                    results = kwm.GetText(WDriver, "id", "totalContractValue");
                    //WDriver.FindElement(By.Id("totalContractValue")).GetAttribute("value");
                    string strAmount = "";
                    strAmount = results.ErrorMessage;
                    Thread.Sleep(3000);
                    objCommonMethods.Action_Page_Down(WDriver);
                    Thread.Sleep(1000);

                    //  Amount
                    if (submitToManOfferToHireModel.str_txt_Amount_financialAmount != "")
                    {
                        //WDriver.FindElement(By.Id(KeyWords.ID_txt_Amount_financialAmount)).Clear();
                        //WDriver.FindElement(By.Id(KeyWords.ID_txt_Amount_financialAmount)).SendKeys(strAmount);
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_Amount_financialAmount, strAmount, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_Amount_financialAmount, strAmount, false);
                            // return results;
                        }
                    }
                }

                //Added by manjusha
                //contract value
                results = kwm.Estimatedcontractorvalue(WDriver, submitToManOfferToHireModel.str_Txt_numberofDays_offertoHire, submitToManOfferToHireModel.str_Txt_numberofResources_offertoHire, "40", "7", submitToManOfferToHireModel.str_Txt_Billrate_Supplierbillrate);
                if (results._Var == submitToManOfferToHireModel.str_Txt_Estimatedcontract_offertoHire)
                {
                    ReportHandler._getChildTest().Log(LogStatus.Pass, "Contract Value is matched in offer to Hire");
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, " value is  matched: ", 3);
                }
                else
                {
                    ReportHandler._getChildTest().Log(LogStatus.Fail, "Contract Value is not mismatched in offer to Hire");
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, " value is not matched: ", 3);
                }

                ////////////














                // or submit click

                if (submitToManOfferToHireModel.strClientName.ToLower().ToString() == Constants.APS)
                {
                    //Extend offer Click
                    if (submitToManOfferToHireModel.str_Btn_OfferToHire_Submit.ToLower().Trim() == "extend offer")
                    {
                        results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Button_Popup_ExtendOffer);

                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_tab_second1, submitToManOfferToHireModel.str_Btn_OfferToHire_Submit);

                        }
                    }
                }

                //if (submitToManOfferToHireModel.strSubMenuLink.ToLower().Contains("identified"))
                //{
                //    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_button_RatesTab_btnbtnContinueRates);
                //    if (results.Result1 == KeyWords.Result_FAIL)
                //    {
                //        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_button_RatesTab_btnbtnContinueRates);
                //    }

               // OfferToHireIdentifiedcandidate(WDriver, OfferToHire_Data);
            }
            else
            {
                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_button_OutlineTab_btnbtnContinue);

                kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_button_OutlineTab_btnbtnContinue), kwm._WDWait);
                objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManOfferToHireModel.strClientName + "_");
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_button_OutlineTab_btnbtnContinue);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_button_OutlineTab_btnbtnContinue);
                }

                results =  OfferToHire_Identified_Candidate(WDriver, OfferToHire_Data);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            if (submitToManOfferToHireModel.str_Btn_OfferToHire_Submit.ToLower().Trim() == "submit")
            {
                if (submitToManOfferToHireModel.strSubMenuLink.ToLower().Contains("identified"))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Btn_Submit_SubmitOTHbtnSubmit);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Btn_Submit_SubmitOTHbtnSubmit);
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_btnbtnSubmit);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_btnbtnSubmit, submitToManOfferToHireModel.str_Btn_OfferToHire_Submit);
                    }
                }
            }

            Thread.Sleep(2000);
            //Yes
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManOfferToHireModel.str_Btn_OfferToHire_Submit_Confirm);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManOfferToHireModel.str_Btn_OfferToHire_Submit_Confirm);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManOfferToHireModel.str_Btn_OfferToHire_Submit_Confirm);
                }
            }
            Thread.Sleep(3000);
            //OK
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManOfferToHireModel.str_Btn_OfferToHire_Submit_Confirm_Ok);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManOfferToHireModel.str_Btn_OfferToHire_Submit_Confirm_Ok);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManOfferToHireModel.str_Btn_OfferToHire_Submit_Confirm_Ok);
                }
            }
            Thread.Sleep(2000);
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = "Offer to Hire submit";
            return results;
        }

        //public Result OfferToHire_Method(IWebDriver WDriver, DataRow OfferToHire_Data)
        //{
        //    KeyWordMethods kwm = new KeyWordMethods();
        //    CommonMethods objCommonMethods = new CommonMethods();
        //    var results = new Result();
        //    var Result_ScreenShot = new Result();
        //    List<string> listExistClients = new List<string>() { };
        //    ////string strClientName = OfferToHire_Data["P5"].ToString().Trim();
        //    ////string strMainMenuLink = OfferToHire_Data["P6"].ToString().Trim();
        //    ////string strSubMenuLink = OfferToHire_Data["P7"].ToString().Trim();
        //    ////string str_Link_ReqNumber = OfferToHire_Data["P8"].ToString().Trim();
        //    ////string str_Link_ActionList_ViewCandidates = OfferToHire_Data["P9"].ToString().Trim();
        //    ////string str_CandidateName = OfferToHire_Data["P10"].ToString().Trim();
        //    ////string str_Link_ActionList_OfferToHire = OfferToHire_Data["P19"].ToString().Trim();
        //    ////string str_Btn_OfferToHire_Continue = OfferToHire_Data["P20"].ToString().Trim();
        //    ////string str_Txt_ProposeDifferentRate = OfferToHire_Data["P21"].ToString().Trim();
        //    ////string str_Txt_Proposebillrate = OfferToHire_Data["P22"].ToString().Trim();
        //    ////string str_Txt_Proposeotbillrate = OfferToHire_Data["P23"].ToString().Trim();
        //    ////string str_Select_dayID = OfferToHire_Data["P24"].ToString().Trim();
        //    ////string str_Txt_weeklyRegHoursNTE = OfferToHire_Data["P25"].ToString().Trim();
        //    ////string str_Txt_weeklyOTHoursNTE = OfferToHire_Data["P26"].ToString().Trim();
        //    ////string str_Txt_yearlyRegHoursNTE = OfferToHire_Data["P27"].ToString().Trim();
        //    ////string str_Txt_totalContractValue = OfferToHire_Data["P28"].ToString().Trim();
        //    ////string str_RadioButton_Emailwithcontractusage = OfferToHire_Data["P29"].ToString().Trim();
        //    ////string str_Select_ddemailschedule = OfferToHire_Data["P30"].ToString().Trim();
        //    ////string str_Txt_PrefStartdate = OfferToHire_Data["P31"].ToString().Trim();
        //    ////string str_Txt_enddate = OfferToHire_Data["P32"].ToString().Trim();
        //    ////string str_AddListTxt_txtTimecardApprover = OfferToHire_Data["P33"].ToString().Trim();
        //    ////string str_DeleteListTxt_txtTimecardApprover = OfferToHire_Data["P34"].ToString().Trim();
        //    ////string str_AddListTxt_ChargeNumbers = OfferToHire_Data["P35"].ToString().Trim();
        //    ////string str_DeleteListTxt_ChargeNumbers = OfferToHire_Data["P36"].ToString().Trim();
        //    ////string str_AddListTxt_GLNumbers = OfferToHire_Data["P35"].ToString().Trim();
        //    ////string str_DeleteListTxt_GLNumbers = OfferToHire_Data["P36"].ToString().Trim();
        //    ////string str_Btn_OfferToHire_Submit = OfferToHire_Data["P39"].ToString().Trim();
        //    ////string str_Btn_OfferToHire_Submit_Confirm = OfferToHire_Data["P40"].ToString().Trim();
        //    ////string str_Btn_OfferToHire_Submit_Confirm_Ok = OfferToHire_Data["P41"].ToString().Trim();

        //    CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
        //    SubmitToManOfferToHireMethodModel submitToManOfferToHireMethodModel = createRequirementRepository.GetSubmitToManOfferToHireMethodData(OfferToHire_Data);

        //    objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManOfferToHireMethodModel.strClientName + "_");


        //    string[] words;
        //    //  Thread.Sleep(5000);
        //    string strSubLevel = "";
        //    results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManOfferToHireMethodModel.str_Link_ActionList_OfferToHire, strSubLevel);
        //    if (results.Result1 == KeyWords.Result_FAIL)
        //    {
        //        Thread.Sleep(5000);
        //        results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManOfferToHireMethodModel.str_Link_ActionList_OfferToHire, strSubLevel);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            Thread.Sleep(10000);
        //            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManOfferToHireMethodModel.str_Link_ActionList_OfferToHire, strSubLevel);
        //            if (results.Result1 == KeyWords.Result_FAIL)
        //            {
        //                Thread.Sleep(15000);
        //                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManOfferToHireMethodModel.str_Link_ActionList_OfferToHire, strSubLevel);
        //                if (results.Result1 == KeyWords.Result_FAIL)
        //                {
        //                    return results;
        //                }
        //            }
        //        }
        //    }
        //    objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManOfferToHireMethodModel.strClientName + "_");

        //    // Thread.Sleep(5000);

        //    for (int z = 1; z < 500; z++)
        //    {
        //        Boolean strValue = true;
        //        try
        //        {
        //            strValue = WDriver.FindElement(By.Id("loading-message")).Displayed;
        //        }
        //        catch
        //        {
        //            strValue = true;
        //        }

        //        //  Console.WriteLine("z -----> " + z);
        //        //  Console.WriteLine("strValue -----> " + strValue);
        //        if (!strValue)
        //        {
        //            break;
        //        }
        //        Thread.Sleep(100);
        //    }


        //    // objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManOfferToHireMethodModel.strClientName + "_");
        //    // Thread.Sleep(2000);
        //    Actions actions1 = new Actions(WDriver);
        //    actions1.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
        //    if (OfferToHire_Data["P1"].ToString().Trim().ToLower() == "chrome")
        //    {
        //        /// results = kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='btnbtnContinue']/span[2]");
        //        Actions actions = new Actions(WDriver);
        //        actions.SendKeys(Keys.PageDown).Perform();
        //        //  IWebElement button = WDriver.FindElement(By.XPath("//*[@id='btnbtnContinue']/span[2]"));
        //        //  actions.MoveToElement(button).Click().Build().Perform();
        //        try
        //        {
        //            WDriver.FindElement(By.XPath("//*[@id='btnbtnContinue']/span[2]")).Click();
        //            results.Result1 = KeyWords.Result_PASS;
        //        }
        //        catch
        //        {

        //            results.Result1 = KeyWords.Result_FAIL;
        //        }

        //    }
        //    else
        //    {
        //        results = kwm.click(WDriver, KeyWords.locator_ID, "btnbtnContinue");
        //    }

        //    //Actions actions1 = new Actions(WDriver);
        //    actions1.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
        //    //results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManOfferToHireMethodModel.str_Btn_OfferToHire_Continue);
        //    if (results.Result1 == KeyWords.Result_FAIL)
        //    {
        //        Thread.Sleep(5000);
        //        //results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManOfferToHireMethodModel.str_Btn_OfferToHire_Continue);
        //        results = kwm.click(WDriver, KeyWords.locator_ID, "btnbtnContinue");
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            Thread.Sleep(10000);
        //            results = kwm.click(WDriver, KeyWords.locator_ID, "btnbtnContinue");
        //            // results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManOfferToHireMethodModel.str_Btn_OfferToHire_Continue);
        //            if (results.Result1 == KeyWords.Result_FAIL)
        //            {
        //                return results;
        //            }
        //        }
        //    }
        //    objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManOfferToHireMethodModel.strClientName + "_");
        //    //   Thread.Sleep(10000);
        //    if (submitToManOfferToHireMethodModel.str_Txt_ProposeDifferentRate == "Accept Rates")
        //    {
        //        try
        //        {
        //            WDriver.FindElement(By.XPath(KeyWords.XPath_RadioButton_AcceptRates)).Click();
        //        }
        //        catch
        //        {
        //            // Console.WriteLine("Click on radio button" + submitToManOfferToHireMethodModel.str_Txt_ProposeDifferentRate);
        //        }
        //    }

        //    if (submitToManOfferToHireMethodModel.str_Txt_ProposeDifferentRate == "Propose Different Rate")
        //    {
        //        try
        //        {
        //            WDriver.FindElement(By.XPath(KeyWords.XPath_RadioButton_ProposeDifferentRate)).Click();
        //        }
        //        catch
        //        {
        //            // Console.WriteLine("Click on radio button" + submitToManOfferToHireMethodModel.str_Txt_ProposeDifferentRate);
        //        }
        //        listExistClients = new List<string>() { Constants.Supervalu, Constants.GHC, Constants.BDA, Constants.Arkema, Constants.Meritor, Constants.Epri, Constants.Caesars, Constants.Tufts };
        //        if (listExistClients.Contains(submitToManOfferToHireMethodModel.strClientName.ToLower()))
        //        {
        //            if (submitToManOfferToHireMethodModel.str_Txt_Proposebillrate != "")
        //                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Proposebillrate, submitToManOfferToHireMethodModel.str_Txt_Proposebillrate, true);

        //            if (submitToManOfferToHireMethodModel.str_Txt_Proposeotbillrate != "")
        //                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Proposeotbillrate, submitToManOfferToHireMethodModel.str_Txt_Proposeotbillrate, true);
        //        }

        //        listExistClients = new List<string>() { Constants.SaviTechnologies, Constants.DCR, Constants.Meritor, Constants.Epri, Constants.Caesars };
        //        if (listExistClients.Contains(submitToManOfferToHireMethodModel.strClientName.ToLower()))
        //        {
        //            if (submitToManOfferToHireMethodModel.str_Txt_Proposebillrate != "")
        //                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ProposedFinalRegBillRate, submitToManOfferToHireMethodModel.str_Txt_Proposebillrate, true);
        //            if (submitToManOfferToHireMethodModel.str_Txt_Proposeotbillrate != "")
        //                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ProposedFinalOTBillRate, submitToManOfferToHireMethodModel.str_Txt_Proposeotbillrate, true);
        //        }
        //        listExistClients = new List<string>() { Constants.RMS, Constants.STGEN, Constants.LmPinellas, Constants.NvEnergy, Constants.Meritor, Constants.Sts, Constants.IsGs, Constants.EBS, Constants.STTTM, Constants.KCPL, Constants.MFC, Constants.SOF, Constants.Costco };
        //        if (listExistClients.Contains(submitToManOfferToHireMethodModel.strClientName.ToLower()))
        //        {
        //            if (submitToManOfferToHireMethodModel.str_Txt_Proposebillrate != "")
        //                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Proposepayrate, submitToManOfferToHireMethodModel.str_Txt_Proposebillrate, true);
        //            if (submitToManOfferToHireMethodModel.str_Txt_Proposeotbillrate != "")
        //                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Proposeotpayrate, submitToManOfferToHireMethodModel.str_Txt_Proposeotbillrate, true);
        //        }
        //    }



        //    //  public static string ID_Select_dayID = "dayID";       
        //    if (submitToManOfferToHireMethodModel.str_Select_dayID != "")
        //    {
        //        kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_dayID, submitToManOfferToHireMethodModel.str_Select_dayID);
        //    }

        //    //  public static string ID_Txt_weeklyRegHoursNTE = "weeklyRegHoursNTE";
        //    if (submitToManOfferToHireMethodModel.str_Txt_weeklyRegHoursNTE != "")
        //        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_weeklyRegHoursNTE, submitToManOfferToHireMethodModel.str_Txt_weeklyRegHoursNTE, true);
        //    //  public static string ID_Txt_weeklyOTHoursNTE = "weeklyOTHoursNTE";
        //    if (submitToManOfferToHireMethodModel.str_Txt_weeklyOTHoursNTE != "")
        //        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_weeklyOTHoursNTE, submitToManOfferToHireMethodModel.str_Txt_weeklyOTHoursNTE, true);
        //    //  public static string ID_Txt_yearlyRegHoursNTE = "yearlyRegHoursNTE";
        //    if (submitToManOfferToHireMethodModel.str_Txt_yearlyRegHoursNTE != "")
        //        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_yearlyRegHoursNTE, submitToManOfferToHireMethodModel.str_Txt_yearlyRegHoursNTE, true);
        //    //  public static string ID_Txt_totalContractValue = "totalContractValue";
        //    if (submitToManOfferToHireMethodModel.str_Txt_totalContractValue != "")
        //        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_totalContractValue, submitToManOfferToHireMethodModel.str_Txt_totalContractValue, true);
        //    // // rbEmailwithContractusage ---radio


        //    if (submitToManOfferToHireMethodModel.str_RadioButton_Emailwithcontractusage.ToLower().Trim() == "yes")
        //    {
        //        try
        //        {
        //            WDriver.FindElement(By.XPath(KeyWords.ID_RadioButton_Yes_rbEmailwithContractusage)).Click();
        //        }
        //        catch
        //        {
        //            // Console.WriteLine("Click on radio button " + submitToManOfferToHireMethodModel.str_RadioButton_Emailwithcontractusage);
        //        }
        //        if (submitToManOfferToHireMethodModel.str_Select_ddemailschedule != "")
        //        {
        //            kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_ddemailschedule, submitToManOfferToHireMethodModel.str_Select_ddemailschedule);
        //        }
        //    }
        //    else
        //    {
        //        try
        //        {
        //            WDriver.FindElement(By.XPath(KeyWords.ID_RadioButton_No_rbEmailwithContractusage)).Click();
        //        }
        //        catch
        //        {
        //            // Console.WriteLine("Click on radio button " + submitToManOfferToHireMethodModel.str_RadioButton_Emailwithcontractusage);
        //        }

        //    }

        //    if (submitToManOfferToHireMethodModel.str_Txt_PrefStartdate != "")
        //    {
        //        // results = kwm.Select_Start_Date_From_Picker(WDriver, submitToManOfferToHireMethodModel.str_Txt_PrefStartdate);
        //        //  if (results.Result1 == KeyWords.Result_FAIL)
        //        //  {
        //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_txtneededStartDate);
        //        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_PrefStartdate, submitToManOfferToHireMethodModel.str_Txt_PrefStartdate, false);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            //return results;
        //        }
        //        //  }
        //    }


        //    if (submitToManOfferToHireMethodModel.str_Txt_enddate != "")
        //    {
        //        // results = kwm.Select_End_Date_From_Picker(WDriver, submitToManOfferToHireMethodModel.str_Txt_enddate);
        //        //if (results.Result1 == KeyWords.Result_FAIL)
        //        //  {
        //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_txtenddate);
        //        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_enddate, submitToManOfferToHireMethodModel.str_Txt_enddate, false);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            //return results;
        //        }
        //        // }
        //    }



        //    //if (submitToManOfferToHireMethodModel.str_Txt_FinancialNumber != "") 
        //    //{
        //    //    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_FinancialNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireMethodModel.str_Txt_FinancialNumber, submitToManOfferToHireMethodModel.str_Txt_FinancialNumber);
        //    //    Thread.Sleep(2000);
        //    //    if (results.Result1 == KeyWords.Result_FAIL)
        //    //    {
        //    //        results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireMethodModel.str_Txt_FinancialNumber, submitToManOfferToHireMethodModel.str_Txt_FinancialNumber);
        //    //        if (results.Result1 == KeyWords.Result_FAIL)
        //    //        {
        //    //            results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, "a");
        //    //            return results;
        //    //        }
        //    //    }
        //    //}

        //    ////  public static string ID_Txt_PrefStartdate = "PrefStartdate";
        //    //      if (submitToManOfferToHireMethodModel.str_Txt_PrefStartdate != "")
        //    //      {
        //    //          kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_PrefStartdate, submitToManOfferToHireMethodModel.str_Txt_PrefStartdate);
        //    //      }
        //    ////  public static string ID_Txt_enddate = "enddate";
        //    //      if (submitToManOfferToHireMethodModel.str_Txt_enddate != "")
        //    //      {
        //    //          kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_enddate, submitToManOfferToHireMethodModel.str_Txt_enddate);
        //    //      }
        //    //  public static string ID_Txt_txtTimecardApprover = "txtTimecardApprover";


        //    //     Console.WriteLine("Test1");
        //    //TImeCard Approver
        //    listExistClients = new List<string>() { Constants.Supervalu, Constants.IsGs, Constants.Sts, Constants.SaviTechnologies, Constants.GHC, Constants.BDA, Constants.AmCom, Constants.LmPinellas, Constants.NvEnergy, Constants.DCR, Constants.KCPL };
        //    if (listExistClients.Contains(submitToManOfferToHireMethodModel.strClientName.ToLower()))
        //    {
        //        if (submitToManOfferToHireMethodModel.str_AddListTxt_txtTimecardApprover != "")
        //        {
        //            string[] separators1 = { "#" };
        //            words = submitToManOfferToHireMethodModel.str_AddListTxt_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
        //            if (words.Length >= 1)
        //            {
        //                for (int r = 0; r < words.Length; r++)
        //                {
        //                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
        //                    if (results.Result1 == KeyWords.Result_FAIL)
        //                    {
        //                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
        //                        //  return results;
        //                    }
        //                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addTimecardApproverbtn);
        //                    //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
        //                }
        //            }

        //        }
        //    }
        //    //  public static string ID_Button_addTimecardApproverbtn ="addTimecardApproverbtn";
        //    //  public static string ID_Button_deleteTimecardApproverbtn = "deleteTimecardApproverbtn";
        //    //  public static string ID_ComboList_addTimecardApprover = "addTimecardApprover";
        //    //       Console.WriteLine("Test2");
        //    listExistClients = new List<string>() { Constants.Supervalu, Constants.IsGs, Constants.Sts, Constants.SaviTechnologies, Constants.GHC, Constants.BDA, Constants.AmCom, Constants.LmPinellas, Constants.NvEnergy, Constants.DCR, Constants.KCPL };
        //    if (listExistClients.Contains(submitToManOfferToHireMethodModel.strClientName.ToLower()))
        //    {
        //        if (submitToManOfferToHireMethodModel.str_DeleteListTxt_txtTimecardApprover != "")
        //        {
        //            string[] separators1 = { "#" };
        //            words = submitToManOfferToHireMethodModel.str_DeleteListTxt_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
        //            if (words.Length >= 1)
        //            {
        //                for (int r = 0; r < words.Length; r++)
        //                {


        //                    //select[@id='addTimecardApprover']/option
        //                    ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addTimecardApprover']/option"));

        //                    List<IWebElement> elements = lis_ClientNames.ToList();
        //                    //  Console.WriteLine(elements.Count);
        //                    //  Console.WriteLine("elements.Count");
        //                    for (int i = 0; i < elements.Count; i++)
        //                    {
        //                        //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
        //                        //     Console.WriteLine(elements[i].Text.ToLower().Trim());
        //                        if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
        //                        {
        //                            // Console.WriteLine(elements[i].Text.ToLower().Trim());
        //                            elements[i].Click();
        //                            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
        //                        }
        //                    }

        //                }
        //            }

        //        }
        //    }
        //    // string str_AddListTxt_ChargeNumbers = OfferToHire_Data["P28"].ToString().Trim();

        //    listExistClients = new List<string>() { Constants.YP };
        //    if (listExistClients.Contains(submitToManOfferToHireMethodModel.strClientName.ToLower()))
        //    {
        //        if (submitToManOfferToHireMethodModel.str_AddListTxt_ChargeNumbers != "")
        //        {
        //            string[] separators1 = { "#" };
        //            words = submitToManOfferToHireMethodModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
        //            if (words.Length >= 1)
        //            {
        //                string[] separators2 = { "-" };
        //                string[] words1 = submitToManOfferToHireMethodModel.str_AddListTxt_ChargeNumbers.Split(separators2, StringSplitOptions.RemoveEmptyEntries);
        //                if (words1.Length >= 1)
        //                {
        //                    for (int r1 = 0; r1 < words1.Length; r1++)
        //                    {
        //                        int n = 0;
        //                        n = 1 + r1;
        //                        if (r1 == 0)
        //                        {
        //                            if (words1[r1].ToString() != "")
        //                            {
        //                                kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), words1[r1].ToString());
        //                            }
        //                        }
        //                        if (r1 == 1)
        //                        {
        //                            if (words1[r1].ToString() != "")
        //                            {
        //                                kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), words1[r1].ToString());
        //                            }
        //                        }
        //                        if (r1 == 2)
        //                        {
        //                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
        //                            if (results.Result1 == KeyWords.Result_FAIL)
        //                            {
        //                                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
        //                                //  return results;
        //                            }
        //                        }
        //                        if (r1 == 3)
        //                        {
        //                            if (words1[r1].ToString() != "")
        //                                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), words1[r1].ToString(), false);
        //                        }
        //                        if (r1 == 4)
        //                        {
        //                            if (words1[r1].ToString() != "")
        //                                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), words1[r1].ToString(), false);
        //                        }
        //                        if (r1 == 5)
        //                        {
        //                            if (words1[r1].ToString() != "")
        //                                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), words1[r1].ToString(), false);
        //                        }
        //                        if (r1 == 6)
        //                        {
        //                            if (words1[r1].ToString() != "")
        //                                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), words1[r1].ToString(), false);
        //                        }

        //                    }
        //                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addAutoFilledChargeNobtn);
        //                    kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "No");
        //                    kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "OK");
        //                }

        //            }

        //        }
        //    }
        //    listExistClients = new List<string>() { Constants.Supervalu, Constants.NvEnergy };
        //    if (listExistClients.Contains(submitToManOfferToHireMethodModel.strClientName.ToLower()))
        //    {
        //        if (submitToManOfferToHireMethodModel.str_AddListTxt_ChargeNumbers != "")
        //        {
        //            string[] separators1 = { "#" };
        //            words = submitToManOfferToHireMethodModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
        //            if (words.Length >= 1)
        //            {
        //                string[] separators2 = { "-" };
        //                string[] words1 = submitToManOfferToHireMethodModel.str_AddListTxt_ChargeNumbers.Split(separators2, StringSplitOptions.RemoveEmptyEntries);
        //                if (words1.Length >= 1)
        //                {
        //                    for (int r1 = 0; r1 < words1.Length; r1++)
        //                    {
        //                        int n = 0;
        //                        n = 1 + r1;
        //                        if (r1 == 0)
        //                        {
        //                            if (words1[r1].ToString() != "")
        //                            {
        //                                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
        //                            }
        //                        }
        //                        if (r1 == 1)
        //                        {
        //                            if (words1[r1].ToString() != "")
        //                            {
        //                                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
        //                            }
        //                        }
        //                        if (r1 == 2)
        //                        {
        //                            if (words1[r1].ToString() != "")
        //                                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
        //                        }
        //                        if (r1 == 3)
        //                        {
        //                            if (words1[r1].ToString() != "")
        //                                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
        //                        }
        //                        if (r1 == 4)
        //                        {
        //                            if (words1[r1].ToString() != "")
        //                                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
        //                        }
        //                        if (r1 == 5)
        //                        {
        //                            if (words1[r1].ToString() != "")
        //                                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
        //                        }
        //                        if (r1 == 6)
        //                        {
        //                            if (words1[r1].ToString() != "")
        //                                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
        //                        }
        //                        if (r1 == 7)
        //                        {
        //                            if (words1[r1].ToString() != "")
        //                                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
        //                        }
        //                    }
        //                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addDivChargeNobtn);
        //                    kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "No");
        //                    kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "OK");
        //                }

        //            }

        //        }
        //    }

        //    //   Console.WriteLine("Test3");
        //    listExistClients = new List<string>() { Constants.Supervalu, "" };
        //    if (listExistClients.Contains(submitToManOfferToHireMethodModel.strClientName.ToLower()))
        //    {
        //        if (submitToManOfferToHireMethodModel.str_AddListTxt_ChargeNumbers != "")
        //        {
        //            string[] separators1 = { "#" };
        //            words = submitToManOfferToHireMethodModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
        //            if (words.Length >= 1)
        //            {
        //                string[] separators2 = { "." };
        //                string[] words1 = submitToManOfferToHireMethodModel.str_AddListTxt_ChargeNumbers.Split(separators2, StringSplitOptions.RemoveEmptyEntries);
        //                if (words1.Length >= 1)
        //                {
        //                    for (int r1 = 0; r1 < words1.Length; r1++)
        //                    {
        //                        if (r1 == 0)
        //                        {
        //                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_CostCenterNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
        //                            if (results.Result1 == KeyWords.Result_FAIL)
        //                            {
        //                                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_CostCenterNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
        //                                //  return results;
        //                            }
        //                        }
        //                        if (r1 == 1)
        //                        {
        //                            if (words1[r1].ToString() != "")
        //                            {
        //                                kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_GLAccounts, words1[r1].ToString());
        //                            }
        //                        }
        //                        if (r1 == 2)
        //                        {
        //                            if (words1[r1].ToString() != "")
        //                                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ProDept, words1[r1].ToString(), false);
        //                        }
        //                        if (r1 == 3)
        //                        {
        //                            if (words1[r1].ToString() != "")
        //                                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_association, words1[r1].ToString(), false);
        //                        }
        //                        if (r1 == 4)
        //                        {
        //                            if (words1[r1].ToString() != "")
        //                                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Location, words1[r1].ToString(), false);
        //                        }
        //                        if (r1 == 5)
        //                        {
        //                            if (words1[r1].ToString() != "")
        //                                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ServDept, words1[r1].ToString(), false);
        //                        }
        //                        if (r1 == 6)
        //                        {
        //                            if (words1[r1].ToString() != "")
        //                                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_IntComp, words1[r1].ToString(), false);
        //                        }
        //                    }
        //                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_AddCostOrgLegalGL);
        //                    kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "No");
        //                    kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "OK");
        //                }

        //            }
        //        }
        //        //     Console.WriteLine("Test4");
        //        // string str_DeleteListTxt_ChargeNumbers = OfferToHire_Data["P29"].ToString().Trim();
        //        listExistClients = new List<string>() { Constants.Supervalu, Constants.IsGs, Constants.Sts, Constants.SaviTechnologies, Constants.NvEnergy, Constants.YP };
        //        if (listExistClients.Contains(submitToManOfferToHireMethodModel.strClientName.ToLower()))
        //        {
        //            if (submitToManOfferToHireMethodModel.str_DeleteListTxt_ChargeNumbers != "")
        //            {
        //                string[] separators1 = { "#" };
        //                words = submitToManOfferToHireMethodModel.str_DeleteListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
        //                if (words.Length >= 1)
        //                {
        //                    for (int r = 0; r < words.Length; r++)
        //                    {


        //                        //select[@id='addTimecardApprover']/option
        //                        ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addChargeNo']/option"));

        //                        List<IWebElement> elements = lis_ClientNames.ToList();
        //                        //  Console.WriteLine(elements.Count);
        //                        //  Console.WriteLine("elements.Count");
        //                        for (int i = 0; i < elements.Count; i++)
        //                        {
        //                            //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
        //                            //     Console.WriteLine(elements[i].Text.ToLower().Trim());
        //                            if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
        //                            {
        //                                // Console.WriteLine(elements[i].Text.ToLower().Trim());
        //                                elements[i].Click();
        //                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteDivChargeNobtn);

        //                            }
        //                        }

        //                    }
        //                }

        //            }
        //        }
        //    }
        //    //   Console.WriteLine("Test5");
        //    listExistClients = new List<string>() { Constants.SaviTechnologies, Constants.Sts, Constants.DCR };
        //    if (listExistClients.Contains(submitToManOfferToHireMethodModel.strClientName.ToLower()))
        //    {
        //        //public static string ID_Txt_txtChargeNo = "txtChargeNo";  ID_ComboList_addChargeNo
        //        // public static string ID_Button_addChargeNobtn ="addChargeNobtn";
        //        // public static string ID_Button_deleteChargeNobtn ="deleteChargeNobtn";
        //        if (submitToManOfferToHireMethodModel.str_AddListTxt_ChargeNumbers != "")
        //        {
        //            string[] separators1 = { "#" };
        //            words = submitToManOfferToHireMethodModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
        //            if (words.Length >= 1)
        //            {
        //                for (int r = 0; r < words.Length; r++)
        //                {
        //                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtChargeNo, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
        //                    if (results.Result1 == KeyWords.Result_FAIL)
        //                    {
        //                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtChargeNo, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
        //                        //  return results;
        //                    }
        //                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addChargeNobtn);
        //                    Thread.Sleep(1000);
        //                    kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "No");
        //                    kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "OK");
        //                }
        //            }
        //        }

        //        //Adding new code for KCPl
        //        objCommonMethods.Action_Page_Down(WDriver);
        //        listExistClients = new List<string>() { Constants.KCPL };
        //        if (listExistClients.Contains(submitToManOfferToHireMethodModel.strClientName.ToLower()))
        //        {
        //            if (submitToManOfferToHireMethodModel.str_AddListTxt_ChargeNumbers != "")
        //            {
        //                string[] separators1 = { "#" };
        //                words = submitToManOfferToHireMethodModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
        //                if (words.Length >= 1)
        //                {
        //                    string[] separators2 = { "-" };
        //                    string[] words1 = submitToManOfferToHireMethodModel.str_AddListTxt_ChargeNumbers.Split(separators2, StringSplitOptions.RemoveEmptyEntries);
        //                    if (words1.Length >= 1)
        //                    {
        //                        for (int r1 = 0; r1 < words1.Length; r1++)
        //                        {
        //                            int n = 0;
        //                            n = 1 + r1;
        //                            if (r1 == 0)
        //                            {
        //                                if (words1[r1].ToString() != "")
        //                                {
        //                                    kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Chargenumberlabel, words1[r1].ToString());
        //                                }
        //                            }
        //                            //changes
        //                            if (r1 == 1)
        //                            {
        //                                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_CostCenterNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
        //                                if (results.Result1 == KeyWords.Result_FAIL)
        //                                {
        //                                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_CostCenterNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
        //                                    if (results.Result1 == KeyWords.Result_FAIL)
        //                                    {
        //                                        results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_CostCenterNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, "1");

        //                                        //  return results;
        //                                    }
        //                                }
        //                            }
        //                            if (r1 == 2)
        //                            {
        //                                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_chargeProfitCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
        //                                if (results.Result1 == KeyWords.Result_FAIL)
        //                                {
        //                                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_chargeProfitCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
        //                                    if (results.Result1 == KeyWords.Result_FAIL)
        //                                    {
        //                                        results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_chargeProfitCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, "1");

        //                                        //  return results;
        //                                    }
        //                                    //  return results;
        //                                }
        //                            }
        //                            if (r1 == 3)
        //                            {
        //                                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_chargedeptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
        //                                if (results.Result1 == KeyWords.Result_FAIL)
        //                                {
        //                                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_chargedeptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
        //                                    if (results.Result1 == KeyWords.Result_FAIL)
        //                                    {
        //                                        results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_chargedeptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, "1");

        //                                        //  return results;
        //                                    }

        //                                }
        //                            }
        //                            if (r1 == 4)
        //                            {
        //                                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_chargeProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
        //                                if (results.Result1 == KeyWords.Result_FAIL)
        //                                {
        //                                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_chargeProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
        //                                    if (results.Result1 == KeyWords.Result_FAIL)
        //                                    {
        //                                        results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_chargeProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, "1");

        //                                        //  return results;
        //                                    }

        //                                }
        //                            }
        //                            if (r1 == 5)
        //                            {
        //                                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_chargeprogramId, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
        //                                if (results.Result1 == KeyWords.Result_FAIL)
        //                                {
        //                                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_chargeprogramId, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
        //                                    if (results.Result1 == KeyWords.Result_FAIL)
        //                                    {
        //                                        results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_chargeprogramId, KeyWords.locator_class, KeyWords.CL_list_typeahead, "0");


        //                                    }
        //                                    //  return results;
        //                                }
        //                            }
        //                            if (r1 == 6)
        //                            {
        //                                if (words1[r1].ToString() != "")

        //                                    kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_chargespendLevelId, words1[r1].ToString());
        //                            }

        //                        }
        //                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addChargeNobtnNew);
        //                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addAutoFilledChargeNobtn);
        //                        kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "No");
        //                        kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "OK");
        //                    }

        //                }

        //            }
        //        }

        //        if (submitToManOfferToHireMethodModel.str_DeleteListTxt_ChargeNumbers != "")
        //        {
        //            string[] separators1 = { "#" };
        //            words = submitToManOfferToHireMethodModel.str_DeleteListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
        //            if (words.Length >= 1)
        //            {
        //                for (int r = 0; r < words.Length; r++)
        //                {


        //                    //select[@id='addTimecardApprover']/option
        //                    ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addChargeNo']/option"));

        //                    List<IWebElement> elements = lis_ClientNames.ToList();
        //                    //  Console.WriteLine(elements.Count);
        //                    //  Console.WriteLine("elements.Count");
        //                    for (int i = 0; i < elements.Count; i++)
        //                    {
        //                        //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
        //                        //     Console.WriteLine(elements[i].Text.ToLower().Trim());
        //                        if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
        //                        {
        //                            // Console.WriteLine(elements[i].Text.ToLower().Trim());
        //                            elements[i].Click();
        //                            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteChargeNobtn);
        //                        }
        //                    }

        //                }
        //            }

        //        }



        //    }
        //    listExistClients = new List<string>() { Constants.BDA, "" };
        //    if (listExistClients.Contains(submitToManOfferToHireMethodModel.strClientName.ToLower()))
        //    {
        //        //public static string ID_Txt_txtChargeNo = "txtChargeNo";  ID_ComboList_addChargeNo
        //        // public static string ID_Button_addChargeNobtn ="addChargeNobtn";
        //        // public static string ID_Button_deleteChargeNobtn ="deleteChargeNobtn";
        //        if (submitToManOfferToHireMethodModel.str_AddListTxt_ChargeNumbers != "")
        //        {
        //            string[] separators1 = { "#" };
        //            words = submitToManOfferToHireMethodModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
        //            if (words.Length >= 1)
        //            {
        //                string[] separators2 = { "-" };
        //                string[] words1 = submitToManOfferToHireMethodModel.str_AddListTxt_ChargeNumbers.Split(separators2, StringSplitOptions.RemoveEmptyEntries);
        //                if (words1.Length >= 1)
        //                {
        //                    for (int r1 = 0; r1 < words1.Length; r1++)
        //                    {
        //                        if (r1 == 1)
        //                        {
        //                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
        //                            if (results.Result1 == KeyWords.Result_FAIL)
        //                            {
        //                                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
        //                                //  return results;
        //                            }
        //                        }
        //                        if (r1 == 0)
        //                        {
        //                            if (words1[r1].ToString() != "")
        //                            {
        //                                kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_WorkLocationCode, words1[r1].ToString());
        //                            }
        //                        }

        //                    }
        //                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addDivChargeNobtn);
        //                }

        //            }
        //        }



        //        if (submitToManOfferToHireMethodModel.str_DeleteListTxt_ChargeNumbers != "")
        //        {
        //            string[] separators1 = { "#" };
        //            words = submitToManOfferToHireMethodModel.str_DeleteListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
        //            if (words.Length >= 1)
        //            {
        //                for (int r = 0; r < words.Length; r++)
        //                {


        //                    //select[@id='addTimecardApprover']/option
        //                    ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addChargeNo']/option"));

        //                    List<IWebElement> elements = lis_ClientNames.ToList();
        //                    //  Console.WriteLine(elements.Count);
        //                    //  Console.WriteLine("elements.Count");
        //                    for (int i = 0; i < elements.Count; i++)
        //                    {
        //                        //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
        //                        //     Console.WriteLine(elements[i].Text.ToLower().Trim());
        //                        if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
        //                        {
        //                            // Console.WriteLine(elements[i].Text.ToLower().Trim());
        //                            elements[i].Click();
        //                            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteChargeNobtn);
        //                        }
        //                    }

        //                }
        //            }

        //        }



        //    }
        //    listExistClients = new List<string>() { Constants.GHC, "" };
        //    if (listExistClients.Contains(submitToManOfferToHireMethodModel.strClientName.ToLower()))
        //    {
        //        //public static string ID_Txt_txtChargeNo = "txtChargeNo";  ID_ComboList_addChargeNo
        //        // public static string ID_Button_addChargeNobtn ="addChargeNobtn";
        //        // public static string ID_Button_deleteChargeNobtn ="deleteChargeNobtn";
        //        if (submitToManOfferToHireMethodModel.str_AddListTxt_ChargeNumbers != "")
        //        {
        //            string[] separators1 = { "#" };
        //            words = submitToManOfferToHireMethodModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
        //            if (words.Length >= 1)
        //            {
        //                string[] separators2 = { "-" };
        //                string[] words1 = submitToManOfferToHireMethodModel.str_AddListTxt_ChargeNumbers.Split(separators2, StringSplitOptions.RemoveEmptyEntries);
        //                if (words1.Length >= 1)
        //                {
        //                    for (int r1 = 0; r1 < words1.Length; r1++)
        //                    {
        //                        if (r1 == 0)
        //                        {
        //                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
        //                            if (results.Result1 == KeyWords.Result_FAIL)
        //                            {
        //                                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
        //                                //  return results;
        //                            }
        //                        }
        //                        if (r1 == 1)
        //                        {
        //                            if (words1[r1].ToString() != "")
        //                            {
        //                                kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_selectOrgId, words1[r1].ToString());
        //                            }
        //                        }

        //                    }
        //                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addDivChargeNobtn);
        //                }

        //            }
        //        }



        //        if (submitToManOfferToHireMethodModel.str_DeleteListTxt_ChargeNumbers != "")
        //        {
        //            string[] separators1 = { "#" };
        //            words = submitToManOfferToHireMethodModel.str_DeleteListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
        //            if (words.Length >= 1)
        //            {
        //                for (int r = 0; r < words.Length; r++)
        //                {


        //                    //select[@id='addTimecardApprover']/option
        //                    ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addChargeNo']/option"));

        //                    List<IWebElement> elements = lis_ClientNames.ToList();
        //                    //  Console.WriteLine(elements.Count);
        //                    //  Console.WriteLine("elements.Count");
        //                    for (int i = 0; i < elements.Count; i++)
        //                    {
        //                        //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
        //                        //     Console.WriteLine(elements[i].Text.ToLower().Trim());
        //                        if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
        //                        {
        //                            // Console.WriteLine(elements[i].Text.ToLower().Trim());
        //                            elements[i].Click();
        //                            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteChargeNobtn);
        //                        }
        //                    }

        //                }
        //            }

        //        }



        //    }

        //    //   Console.WriteLine("Test7");



        //    /* 
        // public static string ID_Txt_txtGLNo = "txtGLNo";
        // public static string ID_Button_addGLNobtn =" addGLNobtn";
        // public static string ID_Button_deleteGLNobtn ="deleteGLNobtn";
        // public static string ID_ComboList_addGLNo = "addGLNo";*/
        //    listExistClients = new List<string>() { Constants.SaviTechnologies, Constants.Sts, Constants.DCR };
        //    if (listExistClients.Contains(submitToManOfferToHireMethodModel.strClientName.ToLower()))
        //    {
        //        //public static string ID_Txt_txtChargeNo = "txtChargeNo";  ID_ComboList_addChargeNo
        //        // public static string ID_Button_addChargeNobtn ="addChargeNobtn";
        //        // public static string ID_Button_deleteChargeNobtn ="deleteChargeNobtn";
        //        if (submitToManOfferToHireMethodModel.str_AddListTxt_GLNumbers != "")
        //        {
        //            string[] separators1 = { "#" };
        //            words = submitToManOfferToHireMethodModel.str_AddListTxt_GLNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
        //            if (words.Length >= 1)
        //            {
        //                for (int r = 0; r < words.Length; r++)
        //                {
        //                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtGLNo, words[r], false);
        //                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addGLNobtn);
        //                    Thread.Sleep(1000);
        //                    kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "No");
        //                }
        //            }
        //        }



        //        if (submitToManOfferToHireMethodModel.str_DeleteListTxt_GLNumbers != "")
        //        {
        //            string[] separators1 = { "#" };
        //            words = submitToManOfferToHireMethodModel.str_DeleteListTxt_GLNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
        //            if (words.Length >= 1)
        //            {
        //                for (int r = 0; r < words.Length; r++)
        //                {


        //                    //select[@id='addTimecardApprover']/option
        //                    ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addGLNo']/option"));

        //                    List<IWebElement> elements = lis_ClientNames.ToList();
        //                    //  Console.WriteLine(elements.Count);
        //                    //  Console.WriteLine("elements.Count");
        //                    for (int i = 0; i < elements.Count; i++)
        //                    {
        //                        //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
        //                        //     Console.WriteLine(elements[i].Text.ToLower().Trim());
        //                        if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
        //                        {
        //                            // Console.WriteLine(elements[i].Text.ToLower().Trim());
        //                            elements[i].Click();
        //                            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteGLNobtn);
        //                        }
        //                    }

        //                }
        //            }

        //        }



        //    }

        //    //  Thread.Sleep(2000);
        //    //  Console.WriteLine(submitToManOfferToHireMethodModel.str_Btn_OfferToHire_Submit);
        //    if (submitToManOfferToHireMethodModel.str_Btn_OfferToHire_Submit.ToLower().Trim() == "submit")
        //    {
        //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_tab_second, submitToManOfferToHireMethodModel.str_Btn_OfferToHire_Submit);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_tab_second1, submitToManOfferToHireMethodModel.str_Btn_OfferToHire_Submit);
        //            if (results.Result1 == KeyWords.Result_FAIL)
        //            {
        //                return results;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        results.Result1 = KeyWords.Result_FAIL;
        //        results.ErrorMessage = "Given button name not find " + submitToManOfferToHireMethodModel.str_Btn_OfferToHire_Submit;
        //        return results;
        //    }


        //    //    results = kwm.Error_Msg_Read_Submit_Resume_details(WDriver, "//div[@" + KeyWords.locator_ID + "='" + KeyWords.ID_Button_tab_second + "']/div/div/div/ul/li");
        //    results = kwm.Error_Msg_Read_Submit_Resume_details(WDriver, "//*[@" + KeyWords.locator_ID + "='" + KeyWords.ID_Valid_Msg_Error_ulMspUserError + "']/li");
        //    if (results.Result1 == KeyWords.Result_PASS)
        //    {
        //        if (results.ErrorMessage != "")
        //        {
        //            results.Result1 = KeyWords.Result_FAIL;
        //            return results;
        //        }
        //    }

        //    //     Console.WriteLine(WDriver.FindElement(By.XPath("//div[contains(@Id,'dialog-confirmoth2')]")).Displayed);
        //    Boolean bMsgbox1 = false;
        //    Boolean bMsgbox2 = false;
        //    try
        //    {
        //        bMsgbox1 = WDriver.FindElement(By.XPath("//div[contains(@Id,'dialog-confirmoth2')]")).Displayed;
        //    }
        //    catch
        //    {
        //        bMsgbox1 = false;
        //    }
        //    try
        //    {
        //        bMsgbox2 = WDriver.FindElement(By.XPath("//span[contains(@Id,'ui-dialog-title-dialog-confirmoth2')]")).Displayed;
        //    }
        //    catch
        //    {
        //        bMsgbox2 = false;
        //    }

        //    //  Console.WriteLine(WDriver.FindElement(By.Id("dialog-confirmoth2")).Displayed);
        //    // if (WDriver.FindElement(By.Id("dialog-confirmoth2")).Displayed)
        //    //   if ((WDriver.FindElement(By.XPath("//div[contains(@Id,'dialog-confirmoth2')]")).Displayed) || (WDriver.FindElement(By.XPath("//div[contains(@Id,'dialog-confirmoth2')]/div)[2]")).Displayed))
        //    if (bMsgbox1 == true)
        //    {
        //        // Console.WriteLine(WDriver.FindElement(By.Id("dialog-confirmoth2")).Displayed);

        //        //Thread.Sleep(2000);
        //        //  Console.WriteLine("str_Btn_OfferToHire_Submit1");
        //        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManOfferToHireMethodModel.str_Btn_OfferToHire_Submit_Confirm);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            Thread.Sleep(5000);
        //            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManOfferToHireMethodModel.str_Btn_OfferToHire_Submit_Confirm);
        //            if (results.Result1 == KeyWords.Result_FAIL)
        //            {
        //                Thread.Sleep(10000);
        //                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManOfferToHireMethodModel.str_Btn_OfferToHire_Submit_Confirm);
        //                if (results.Result1 == KeyWords.Result_FAIL)
        //                {
        //                    return results;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManOfferToHireMethodModel.str_Btn_OfferToHire_Submit_Confirm);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            Thread.Sleep(5000);
        //            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManOfferToHireMethodModel.str_Btn_OfferToHire_Submit_Confirm);
        //            if (results.Result1 == KeyWords.Result_FAIL)
        //            {
        //                Thread.Sleep(10000);
        //                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManOfferToHireMethodModel.str_Btn_OfferToHire_Submit_Confirm);
        //                if (results.Result1 == KeyWords.Result_FAIL)
        //                {
        //                    return results;
        //                }
        //            }
        //        }
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            results.Result1 = KeyWords.Result_FAIL;
        //            results.ErrorMessage = "Unable to find the confirm msg box";
        //            return results;
        //        }
        //    }
        //    //  Console.WriteLine("str_Btn_OfferToHire_Submit");

        //    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManOfferToHireMethodModel.str_Btn_OfferToHire_Submit_Confirm_Ok);
        //    if (results.Result1 == KeyWords.Result_FAIL)
        //    {
        //        Thread.Sleep(5000);
        //        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManOfferToHireMethodModel.str_Btn_OfferToHire_Submit_Confirm_Ok);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            Thread.Sleep(10000);
        //            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManOfferToHireMethodModel.str_Btn_OfferToHire_Submit_Confirm_Ok);
        //            if (results.Result1 == KeyWords.Result_FAIL)
        //            {
        //                return results;
        //            }
        //        }
        //    }


        //    //      Thread.Sleep(10000);
        //    results.Result1 = KeyWords.Result_PASS;
        //    results.ErrorMessage = "Offer to Hire submit";
        //    return results;

        //}

        public Result ExtendOffer_Method_Full(IWebDriver WDriver, DataRow ExtendOffer_Data)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            SubmitToManExtendOfferModel submitToManExtendOfferModel = createRequirementRepository.GetSubmitToManExtendOfferData(ExtendOffer_Data);
            ////string strClientName = ExtendOffer_Data["P5"].ToString().Trim();
            ////string strMainMenuLink = ExtendOffer_Data["P6"].ToString().Trim();
            ////string strSubMenuLink = ExtendOffer_Data["P7"].ToString().Trim();
            ////string str_Link_ReqNumber = ExtendOffer_Data["P8"].ToString().Trim();
            ////string str_Link_ActionList_ViewCandidates = ExtendOffer_Data["P9"].ToString().Trim();
            ////string str_Link_ActionList_ExperienceValidation = ExtendOffer_Data["P44"].ToString().Trim();
            ////string str_CandidateName = ExtendOffer_Data["P10"].ToString().Trim();
            ////string str_Txt_Years = ExtendOffer_Data["P46"].ToString().Trim();
            ////string str_Link_ActionList_ExtendOffer = ExtendOffer_Data["P46"].ToString().Trim();
            ////string str_Txt_Months = ExtendOffer_Data["P47"].ToString().Trim();
            //////   string str_Txt_ProposedSupplierBillRate = ExtendOffer_Data["P12"].ToString().Trim();
            ////string str_Txt_proposedRegPayRate = ExtendOffer_Data["P47"].ToString().Trim();   //Proposed Pay Rate
            ////string str_Txt_proposedOTPayRate = ExtendOffer_Data["P48"].ToString().Trim();//Proposed OT Pay Rate
            ////string str_Txt_payRateMarkup = ExtendOffer_Data["P49"].ToString().Trim();//Pay Rate Markup%:
            ////string str_Txt_proposedRegBillRate = ExtendOffer_Data["P50"].ToString().Trim();//Proposed Supplier Bill Rate:
            ////string str_Txt_proposedOTBillRate = ExtendOffer_Data["P51"].ToString().Trim(); //Proposed Supplier OT Bill Rate:
            ////string str_Txt_finalRegBillRate = ExtendOffer_Data["P52"].ToString().Trim();//Final Bill Rate: 
            ////string str_Txt_finalOTBillRate = ExtendOffer_Data["P53"].ToString().Trim();//Final OT Bill Rate:  
            ////string str_Txt_weeklyRegHoursNTE = ExtendOffer_Data["P54"].ToString().Trim();
            ////string str_Txt_weeklyOTHoursNTE = ExtendOffer_Data["P55"].ToString().Trim();
            ////string str_Txt_yearlyRegHoursNTE = ExtendOffer_Data["P56"].ToString().Trim();
            ////string str_Txt_totalContractValue = ExtendOffer_Data["P57"].ToString().Trim();
            ////string str_Txt_PrefStartdate = ExtendOffer_Data["P58"].ToString().Trim();
            ////string str_Txt_enddate = ExtendOffer_Data["P59"].ToString().Trim();
            ////string str_AddListTxt_txtTimecardApprover = ExtendOffer_Data["P60"].ToString().Trim();
            ////string str_DeleteListTxt_txtTimecardApprover = ExtendOffer_Data["P61"].ToString().Trim();
            ////string str_AddListTxt_ChargeNumbers = ExtendOffer_Data["P62"].ToString().Trim();
            ////string str_DeleteListTxt_ChargeNumbers = ExtendOffer_Data["P63"].ToString().Trim();
            ////string str_AddListTxt_GLNumbers = ExtendOffer_Data["P64"].ToString().Trim();
            ////string str_DeleteListTxt_GLNumbers = ExtendOffer_Data["P65"].ToString().Trim();




            //  string str_Txt_ProposedSupplierOTBillRate = ExtendOffer_Data["P14"].ToString().Trim();
            //  string submitToManExtendOfferModel.str_Txt_proposedRegBillRate = ExtendOffer_Data["P14"].ToString().Trim();
            //  string submitToManExtendOfferModel.str_Txt_proposedOTBillRate = ExtendOffer_Data["P14"].ToString().Trim();

            //   string str_Txt_Proposebillrate = ExtendOffer_Data["P15"].ToString().Trim();
            //  string str_Txt_finalRegBillRate = ExtendOffer_Data["P15"].ToString().Trim();

            // string submitToManExtendOfferModel.str_Txt_proposedOTPayRate = ExtendOffer_Data["P15""].ToString().Trim();
            //   string str_Txt_Proposeotbillrate = ExtendOffer_Data["P16"].ToString().Trim();





            //string str_Btn_ExtendOffer_Submit = ExtendOffer_Data["P64"].ToString().Trim();
            //string str_Btn_ExtendOffer_Submit_Confirm = ExtendOffer_Data["P65"].ToString().Trim();
            //string str_Btn_ExtendOffer_Submit_Confirm_Ok = ExtendOffer_Data["P66"].ToString().Trim();
            //string str_Txt_poNumber = ExtendOffer_Data["P67"].ToString().Trim();

            //   Thread.Sleep(5000);
            // Requirements
            //  Console.WriteLine("I am here");
            //  WDriver.Navigate().Refresh();
            //   Thread.Sleep(5000);
            try
            {
                WDriver.Navigate().Refresh();
            }
            catch
            {
            }

            listExistClients = new List<string>() { Constants.Discover };
            if (listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManExtendOfferModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManExtendOfferModel.strClientName);
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
            if (!listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManExtendOfferModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManExtendOfferModel.strClientName);
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

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
            //if (kwm.isElementPresent(WDriver, "cboxWrapper"))
            //{
            //    objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
            //    kwm.click(WDriver, KeyWords.locator_ID, "cboxClose");
            //}
            //if (kwm.isElementPresent(WDriver, "notification-dialog"))
            //{
            //    objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
            //    kwm.click(WDriver, KeyWords.locator_class, "ui-icon ui-icon-closethick");
            //    // WDriver.FindElement(By.Id("notification-dialog")).
            //    kwm.CloseAlertAndGetItsText(WDriver);
            //}
            //objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManExtendOfferModel.strMainMenuLink, submitToManExtendOfferModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManExtendOfferModel.strMainMenuLink, submitToManExtendOfferModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
            if (submitToManExtendOfferModel.strSubMenuLink.ToLower().Trim() != "candidate with offers")
            {

                objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");

                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.ID_paginate_regReqList_filter);

                try
                {
                    WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).Clear();

                    WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).SendKeys(submitToManExtendOfferModel.str_Link_ReqNumber);
                }
                catch
                {
                    Thread.Sleep(5000);
                    try
                    {
                        WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).Clear();
                        WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).SendKeys(submitToManExtendOfferModel.str_Link_ReqNumber);
                    }
                    catch
                    {
                        //
                    }
                    Thread.Sleep(5000);
                }
                try
                {
                    Thread.Sleep(2000);
                    WDriver.FindElement(By.LinkText(submitToManExtendOfferModel.str_Link_ReqNumber)).Click();
                }
                catch
                {
                    Thread.Sleep(2000);
                    try
                    {
                        WDriver.FindElement(By.LinkText(submitToManExtendOfferModel.str_Link_ReqNumber)).Click();
                    }
                    catch
                    {
                        // Console.WriteLine(bFlag);
                        results.Result1 = KeyWords.Result_FAIL;
                        results.ErrorMessage = "The given Req not find " + submitToManExtendOfferModel.str_Link_ReqNumber;
                        return results;
                    }
                }

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
                    Thread.Sleep(100);
                }
                string strSubLevel = "";
                objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManExtendOfferModel.str_Link_ActionList_ViewCandidates);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManExtendOfferModel.str_Link_ActionList_ViewCandidates, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(15000);
                    results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManExtendOfferModel.str_Link_ActionList_ViewCandidates, strSubLevel);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }

                if (submitToManExtendOfferModel.str_CandidateName.ToLower().Trim() == "")
                {
                    results = kwm.GetNameFromReqNumber("FN", submitToManExtendOfferModel.str_Link_ReqNumber);
                    // string strCan
                    string strFN = "";
                    if (results.Result1 == KeyWords.Result_PASS)
                    {
                        strFN = results.ErrorMessage;
                    }
                    // results
                    results = kwm.GetNameFromReqNumber("LN", submitToManExtendOfferModel.str_Link_ReqNumber);
                    string strLN = "";
                    if (results.Result1 == KeyWords.Result_PASS)
                    {
                        strLN = results.ErrorMessage;
                    }

                    submitToManExtendOfferModel.str_CandidateName = strLN + ", " + strFN;
                }

                objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
                try
                {
                    WDriver.FindElement(By.XPath("//*[@id='HistoryTableViewCandidate_filter']/label/input")).SendKeys(submitToManExtendOfferModel.str_CandidateName);
                }
                catch
                {
                    try
                    {
                        WDriver.FindElement(By.XPath("//*[@id='HistoryTableViewCCandidate_filter']/label/input")).SendKeys(submitToManExtendOfferModel.str_CandidateName);
                    }
                    catch
                    {
                        //
                    }
                }

                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_LinkText, submitToManExtendOfferModel.str_CandidateName);
                objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");

                try
                {
                    WDriver.FindElement(By.LinkText(submitToManExtendOfferModel.str_CandidateName)).Click();
                }
                catch
                {
                    Thread.Sleep(100);
                    try
                    {
                        WDriver.FindElement(By.LinkText(submitToManExtendOfferModel.str_CandidateName)).Click();
                    }
                    catch
                    {
                        // Console.WriteLine(bFlag);
                        results.Result1 = KeyWords.Result_FAIL;
                        results.ErrorMessage = "The given canditate name not find " + submitToManExtendOfferModel.str_CandidateName;
                        return results;
                    }
                }
                //   Thread.Sleep(10000);
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
                    Thread.Sleep(100);
                }
                strSubLevel = "";
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManExtendOfferModel.str_Link_ActionList_ExtendOffer, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManExtendOfferModel.str_Link_ActionList_ExtendOffer, strSubLevel);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, "Requeue", strSubLevel);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                        Call_Requeue_Function(WDriver, strSubLevel);
                        results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManExtendOfferModel.str_Link_ActionList_ExtendOffer, strSubLevel);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }
                }

                Boolean bFilterTxt = false;
                for (int iFTxt = 0; iFTxt < 100; iFTxt++)
                {
                    try
                    {
                        bFilterTxt = WDriver.FindElement(By.Id("CandidateActioncontent")).Displayed;
                    }
                    catch
                    {
                        kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManExtendOfferModel.str_Link_ActionList_ExtendOffer, strSubLevel);
                    }
                    if (bFilterTxt)
                        break;
                }


                try
                {
                    WDriver.FindElement(By.XPath("//*[@id='CandidateActioncontent']/ul/li[2]/a")).Click();
                }
                catch
                {
                    //
                }

                //Proposed Pay rate option

                try
                {
                    WDriver.FindElement(By.XPath("//*[@class='tblDataFree']/tbody/tr[6]/td[1]")).Click();

                }
                catch (Exception e)
                {

                }

                if (submitToManExtendOfferModel.str_Txt_ProposeDifferentRate == "Accept Rates")
                {
                    try
                    {
                        WDriver.FindElement(By.XPath(KeyWords.XPath_RadioButton_AcceptRates)).Click();
                    }
                    catch
                    {
                        Console.WriteLine("Click on radio button" + submitToManExtendOfferModel.str_Txt_ProposeDifferentRate);
                    }
                }
                //proposed diff rate
                if (submitToManExtendOfferModel.str_Txt_ProposeDifferentRate == "Propose Different Rate")
                {
                    try
                    {
                        WDriver.FindElement(By.XPath(KeyWords.XPath_RadioButton_ProposeDifferentRate)).Click();

                        if (submitToManExtendOfferModel.str_Txt_proposedRegPayRate != "")
                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Proposebillrate, submitToManExtendOfferModel.str_Txt_proposedRegPayRate, true);

                        if (submitToManExtendOfferModel.str_Txt_proposedOTPayRate != "")
                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Proposeotbillrate, submitToManExtendOfferModel.str_Txt_proposedOTPayRate, true);
                        objCommonMethods.Action_Page_Down(WDriver);

                    }
                    catch
                    {
                        Console.WriteLine("Click on radio button" + submitToManExtendOfferModel.str_Txt_ProposeDifferentRate);
                    }

                }



                if (submitToManExtendOfferModel.str_Txt_proposedRegPayRate != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_proposedRegPayRate, submitToManExtendOfferModel.str_Txt_proposedRegPayRate, true);


                if (submitToManExtendOfferModel.str_Txt_proposedOTPayRate != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_proposedOTPayRate, submitToManExtendOfferModel.str_Txt_proposedOTPayRate, true);

                objCommonMethods.Action_Page_Down_withoutjavascriptexecutor(WDriver);

                if (submitToManExtendOfferModel.str_Txt_payRateMarkup != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_payRateMarkup, submitToManExtendOfferModel.str_Txt_payRateMarkup, true);

                if (submitToManExtendOfferModel.str_Txt_proposedRegBillRate != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_proposedRegBillRate, submitToManExtendOfferModel.str_Txt_proposedRegBillRate, true);

                if (submitToManExtendOfferModel.str_Txt_proposedOTBillRate != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_proposedOTBillRate, submitToManExtendOfferModel.str_Txt_proposedOTBillRate, true);

                if (submitToManExtendOfferModel.str_Txt_finalRegBillRate != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_finalRegBillRate, submitToManExtendOfferModel.str_Txt_finalRegBillRate, true);
                objCommonMethods.Action_Page_Down_withoutjavascriptexecutor(WDriver);

                Thread.Sleep(2000);
                if (!string.IsNullOrWhiteSpace(submitToManExtendOfferModel.str_Txt_finalOTBillRate))
                {
                    Thread.Sleep(2000);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_finalOTBillRate, submitToManExtendOfferModel.str_Txt_finalOTBillRate, false);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
                Thread.Sleep(2000);

                if (submitToManExtendOfferModel.str_Txt_weeklyRegHoursNTE != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_weeklyRegHoursNTE, submitToManExtendOfferModel.str_Txt_weeklyRegHoursNTE, true);

                if (submitToManExtendOfferModel.str_Txt_weeklyOTHoursNTE != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_weeklyOTHoursNTE, submitToManExtendOfferModel.str_Txt_weeklyOTHoursNTE, true);

                if (submitToManExtendOfferModel.str_Txt_yearlyRegHoursNTE != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_yearlyRegHoursNTE, submitToManExtendOfferModel.str_Txt_yearlyRegHoursNTE, true);

                if (submitToManExtendOfferModel.str_Txt_totalContractValue != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_totalContractValue, submitToManExtendOfferModel.str_Txt_totalContractValue, true);


                //added by manjusha eofull
                //contract value
                results = kwm.Estimatedcontractorvalue(WDriver, submitToManExtendOfferModel.str_Txt_numberofDays_offertoHire, submitToManExtendOfferModel.str_Txt_numberofResources_offertoHire, "40", "7", submitToManExtendOfferModel.str_Txt_Billrate_Supplierbillrate);

                if (results._Var == submitToManExtendOfferModel.str_Txt_Estimatedcontract_offertoHire)
                {
                    ReportHandler._getChildTest().Log(LogStatus.Pass, "Contract Value is matched in Extend Offer");
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, " value is  matched: ", 3);
                }
                else
                {
                    ReportHandler._getChildTest().Log(LogStatus.Fail, "Contract Value is not mismatched in Extend Offer");
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, " value is not matched: ", 3);
                }


                if (submitToManExtendOfferModel.str_Txt_PrefStartdate != "")
                {
                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_txtneededStartDate);
                    // results = kwm.Select_Start_Date_From_Picker(WDriver, submitToManExtendOfferModel.str_Txt_PrefStartdate);
                    //  if (results.Result1 == KeyWords.Result_FAIL)
                    //  {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_PrefStartdate, submitToManExtendOfferModel.str_Txt_PrefStartdate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                    // }
                }



                if (submitToManExtendOfferModel.str_Txt_enddate != "")
                {
                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_endDate);
                    //  results = kwm.Select_End_Date_From_Picker(WDriver, submitToManExtendOfferModel.str_Txt_enddate);
                    //  if (results.Result1 == KeyWords.Result_FAIL)
                    //   {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_enddate, submitToManExtendOfferModel.str_Txt_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                    //  }
                }


                objCommonMethods.Action_Page_Down_withoutjavascriptexecutor(WDriver);
                //poNumber
                string[] separators = { " " };
                //string value = results.ErrorMessage;
                string[] words;
                if (submitToManExtendOfferModel.str_Txt_poNumber != "")
                {
                    //kwm.sendText(WDriver, KeyWords.locator_ID, "poNumber", str_Txt_poNumber, true);
                    //  results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, "poNumber", KeyWords.locator_class, KeyWords.CL_list_typeahead, str_Txt_poNumber, str_Txt_poNumber);
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, "poNumber", KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManExtendOfferModel.str_Txt_poNumber, submitToManExtendOfferModel.str_Txt_poNumber);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, "poNumber", KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManExtendOfferModel.str_Txt_poNumber, submitToManExtendOfferModel.str_Txt_poNumber);
                        //  return results;
                    }

                }
                listExistClients = new List<string>() { Constants.Supervalu, Constants.IsGs, Constants.Sts, Constants.SaviTechnologies, Constants.GHC, Constants.BDA, Constants.AmCom, Constants.LmPinellas, Constants.NvEnergy, Constants.DCR, Constants.Meritor, Constants.APS };
                if (listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
                {
                    if (submitToManExtendOfferModel.str_AddListTxt_txtTimecardApprover != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_AddListTxt_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            for (int r = 0; r < words.Length; r++)
                            {
                                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                                if (results.Result1 == KeyWords.Result_FAIL)
                                {
                                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                                    //  return results;
                                }
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addTimecardApproverbtn);
                                //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                            }
                        }

                    }
                }

                listExistClients = new List<string>() { Constants.Supervalu, Constants.IsGs, Constants.Sts, Constants.SaviTechnologies, Constants.GHC, Constants.BDA, Constants.AmCom, Constants.LmPinellas, Constants.NvEnergy, Constants.DCR, Constants.Meritor, Constants.APS };
                if (listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
                {
                    if (submitToManExtendOfferModel.str_DeleteListTxt_txtTimecardApprover != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_DeleteListTxt_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            for (int r = 0; r < words.Length; r++)
                            {


                                //select[@id='addTimecardApprover']/option
                                ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addTimecardApprover']/option"));

                                List<IWebElement> elements = lis_ClientNames.ToList();
                                //  Console.WriteLine(elements.Count);
                                //  Console.WriteLine("elements.Count");
                                for (int i = 0; i < elements.Count; i++)
                                {
                                    //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
                                    //     Console.WriteLine(elements[i].Text.ToLower().Trim());
                                    if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                                    {
                                        // Console.WriteLine(elements[i].Text.ToLower().Trim());
                                        elements[i].Click();
                                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
                                    }
                                }

                            }
                        }

                    }
                }
                // string str_AddListTxt_ChargeNumbers = OfferToHire_Data[28"].ToString().Trim();
                listExistClients = new List<string>() { Constants.YP };
                if (listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
                {
                    if (submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            string[] separators2 = { "-" };
                            string[] words1 = submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers.Split(separators2, StringSplitOptions.RemoveEmptyEntries);
                            if (words1.Length >= 1)
                            {
                                for (int r1 = 0; r1 < words1.Length; r1++)
                                {
                                    int n = 0;
                                    n = 1 + r1;
                                    if (r1 == 0)
                                    {
                                        if (words1[r1].ToString() != "")
                                        {
                                            kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), words1[r1].ToString());
                                        }
                                    }
                                    if (r1 == 1)
                                    {
                                        if (words1[r1].ToString() != "")
                                        {
                                            kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), words1[r1].ToString());
                                        }
                                    }
                                    if (r1 == 2)
                                    {
                                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
                                        if (results.Result1 == KeyWords.Result_FAIL)
                                        {
                                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
                                            //  return results;
                                        }
                                    }
                                    if (r1 == 3)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), words1[r1].ToString(), false);
                                    }
                                    if (r1 == 4)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), words1[r1].ToString(), false);
                                    }
                                    if (r1 == 5)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), words1[r1].ToString(), false);
                                    }
                                    if (r1 == 6)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), words1[r1].ToString(), false);
                                    }

                                }
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addAutoFilledChargeNobtn);
                            }

                        }

                    }
                }
                listExistClients = new List<string>() { Constants.Supervalu, Constants.NvEnergy };
                if (listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
                {
                    if (submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            string[] separators2 = { "-" };
                            string[] words1 = submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers.Split(separators2, StringSplitOptions.RemoveEmptyEntries);
                            if (words1.Length >= 1)
                            {
                                for (int r1 = 0; r1 < words1.Length; r1++)
                                {
                                    int n = 0;
                                    n = 1 + r1;
                                    if (r1 == 0)
                                    {
                                        if (words1[r1].ToString() != "")
                                        {
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
                                        }
                                    }
                                    if (r1 == 1)
                                    {
                                        if (words1[r1].ToString() != "")
                                        {
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
                                        }
                                    }
                                    if (r1 == 2)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
                                    }
                                    if (r1 == 3)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
                                    }
                                    if (r1 == 4)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
                                    }
                                    if (r1 == 5)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
                                    }
                                    if (r1 == 6)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
                                    }
                                    if (r1 == 7)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + r1.ToString(), words1[r1].ToString(), false);
                                    }
                                }
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addDivChargeNobtn);
                            }

                        }

                    }
                }

                listExistClients = new List<string>() { Constants.Supervalu, "" };
                if (listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
                {
                    if (submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            string[] separators2 = { "." };
                            string[] words1 = submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers.Split(separators2, StringSplitOptions.RemoveEmptyEntries);
                            if (words1.Length >= 1)
                            {
                                for (int r1 = 0; r1 < words1.Length; r1++)
                                {
                                    if (r1 == 0)
                                    {
                                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_CostCenterNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
                                        if (results.Result1 == KeyWords.Result_FAIL)
                                        {
                                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_CostCenterNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
                                            //  return results;
                                        }
                                    }
                                    if (r1 == 1)
                                    {
                                        if (words1[r1].ToString() != "")
                                        {
                                            kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_GLAccounts, words1[r1].ToString());
                                        }
                                    }
                                    if (r1 == 2)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ProDept, words1[r1].ToString(), false);
                                    }
                                    if (r1 == 3)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_association, words1[r1].ToString(), false);
                                    }
                                    if (r1 == 4)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Location, words1[r1].ToString(), false);
                                    }
                                    if (r1 == 5)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ServDept, words1[r1].ToString(), false);
                                    }
                                    if (r1 == 6)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_IntComp, words1[r1].ToString(), false);
                                    }
                                }
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_AddCostOrgLegalGL);
                            }

                        }
                    }

                    listExistClients = new List<string>() { Constants.Supervalu, Constants.IsGs, Constants.Sts, Constants.NvEnergy, Constants.YP };
                    if (listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
                    {
                        if (submitToManExtendOfferModel.str_DeleteListTxt_ChargeNumbers != "")
                        {
                            string[] separators1 = { "#" };
                            words = submitToManExtendOfferModel.str_DeleteListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                            if (words.Length >= 1)
                            {
                                for (int r = 0; r < words.Length; r++)
                                {


                                    //select[@id='addTimecardApprover']/option
                                    ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addChargeNo']/option"));

                                    List<IWebElement> elements = lis_ClientNames.ToList();
                                    //  Console.WriteLine(elements.Count);
                                    //  Console.WriteLine("elements.Count");
                                    for (int i = 0; i < elements.Count; i++)
                                    {
                                        //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
                                        //     Console.WriteLine(elements[i].Text.ToLower().Trim());
                                        if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                                        {
                                            // Console.WriteLine(elements[i].Text.ToLower().Trim());
                                            elements[i].Click();
                                            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteDivChargeNobtn);

                                        }
                                    }

                                }
                            }

                        }
                    }
                }

                listExistClients = new List<string>() { Constants.SaviTechnologies, Constants.Sts, Constants.DCR };
                if (listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
                {

                    if (submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            for (int r = 0; r < words.Length; r++)
                            {
                                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtChargeNo, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                                if (results.Result1 == KeyWords.Result_FAIL)
                                {
                                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtChargeNo, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                                    //  return results;
                                }
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addChargeNobtn);
                                kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "No");
                            }
                        }
                    }



                    if (submitToManExtendOfferModel.str_DeleteListTxt_ChargeNumbers != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_DeleteListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            for (int r = 0; r < words.Length; r++)
                            {


                                //select[@id='addTimecardApprover']/option
                                ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addChargeNo']/option"));

                                List<IWebElement> elements = lis_ClientNames.ToList();
                                //  Console.WriteLine(elements.Count);
                                //  Console.WriteLine("elements.Count");
                                for (int i = 0; i < elements.Count; i++)
                                {
                                    //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
                                    //     Console.WriteLine(elements[i].Text.ToLower().Trim());
                                    if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                                    {
                                        // Console.WriteLine(elements[i].Text.ToLower().Trim());
                                        elements[i].Click();
                                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteChargeNobtn);
                                    }
                                }

                            }
                        }

                    }



                }
                listExistClients = new List<string>() { Constants.BDA, "" };
                if (listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
                {

                    if (submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            string[] separators2 = { "-" };
                            string[] words1 = submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers.Split(separators2, StringSplitOptions.RemoveEmptyEntries);
                            if (words1.Length >= 1)
                            {
                                for (int r1 = 0; r1 < words1.Length; r1++)
                                {
                                    if (r1 == 1)
                                    {
                                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
                                        if (results.Result1 == KeyWords.Result_FAIL)
                                        {
                                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
                                            //  return results;
                                        }
                                    }
                                    if (r1 == 0)
                                    {
                                        if (words1[r1].ToString() != "")
                                        {
                                            kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_WorkLocationCode, words1[r1].ToString());
                                        }
                                    }

                                }
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addDivChargeNobtn);
                            }

                        }
                    }



                    if (submitToManExtendOfferModel.str_DeleteListTxt_ChargeNumbers != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_DeleteListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            for (int r = 0; r < words.Length; r++)
                            {


                                //select[@id='addTimecardApprover']/option
                                ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addChargeNo']/option"));

                                List<IWebElement> elements = lis_ClientNames.ToList();
                                //  Console.WriteLine(elements.Count);
                                //  Console.WriteLine("elements.Count");
                                for (int i = 0; i < elements.Count; i++)
                                {
                                    //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
                                    //     Console.WriteLine(elements[i].Text.ToLower().Trim());
                                    if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                                    {
                                        // Console.WriteLine(elements[i].Text.ToLower().Trim());
                                        elements[i].Click();
                                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteChargeNobtn);
                                    }
                                }

                            }
                        }

                    }



                }
                listExistClients = new List<string>() { Constants.GHC, "" };
                if (listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
                {

                    if (submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            string[] separators2 = { "-" };
                            string[] words1 = submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers.Split(separators2, StringSplitOptions.RemoveEmptyEntries);
                            if (words1.Length >= 1)
                            {
                                for (int r1 = 0; r1 < words1.Length; r1++)
                                {
                                    if (r1 == 0)
                                    {
                                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
                                        if (results.Result1 == KeyWords.Result_FAIL)
                                        {
                                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
                                            //  return results;
                                        }
                                    }
                                    if (r1 == 1)
                                    {
                                        if (words1[r1].ToString() != "")
                                        {
                                            kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_selectOrgId, words1[r1].ToString());
                                        }
                                    }

                                }
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addDivChargeNobtn);
                            }

                        }
                    }



                    if (submitToManExtendOfferModel.str_DeleteListTxt_ChargeNumbers != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_DeleteListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            for (int r = 0; r < words.Length; r++)
                            {


                                //select[@id='addTimecardApprover']/option
                                ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addChargeNo']/option"));

                                List<IWebElement> elements = lis_ClientNames.ToList();
                                //  Console.WriteLine(elements.Count);
                                //  Console.WriteLine("elements.Count");
                                for (int i = 0; i < elements.Count; i++)
                                {
                                    //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
                                    //     Console.WriteLine(elements[i].Text.ToLower().Trim());
                                    if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                                    {
                                        // Console.WriteLine(elements[i].Text.ToLower().Trim());
                                        elements[i].Click();
                                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteChargeNobtn);
                                    }
                                }

                            }
                        }

                    }



                }

                //  Console.WriteLine("Test7");




                listExistClients = new List<string>() { Constants.SaviTechnologies, Constants.Sts, Constants.DCR };
                if (listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
                {
                    //public static string ID_Txt_txtChargeNo = "txtChargeNo";  ID_ComboList_addChargeNo
                    // public static string ID_Button_addChargeNobtn ="addChargeNobtn";
                    // public static string ID_Button_deleteChargeNobtn ="deleteChargeNobtn";
                    if (submitToManExtendOfferModel.str_AddListTxt_GLNumbers != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_AddListTxt_GLNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            for (int r = 0; r < words.Length; r++)
                            {
                                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtGLNo, words[r], false);
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addGLNobtn);
                                Thread.Sleep(1000);
                                kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "No");
                            }
                        }
                    }



                    if (submitToManExtendOfferModel.str_DeleteListTxt_GLNumbers != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_DeleteListTxt_GLNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            for (int r = 0; r < words.Length; r++)
                            {


                                //select[@id='addTimecardApprover']/option
                                ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addGLNo']/option"));

                                List<IWebElement> elements = lis_ClientNames.ToList();
                                //  Console.WriteLine(elements.Count);
                                //  Console.WriteLine("elements.Count");
                                for (int i = 0; i < elements.Count; i++)
                                {
                                    //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
                                    //     Console.WriteLine(elements[i].Text.ToLower().Trim());
                                    if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                                    {
                                        // Console.WriteLine(elements[i].Text.ToLower().Trim());
                                        elements[i].Click();
                                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteGLNobtn);
                                    }
                                }

                            }
                        }

                    }



                }
                //  Console.WriteLine("Test8");
                //      Thread.Sleep(2000);
                objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
                //   Console.WriteLine(str_Btn_ExtendOffer_Submit);
                objCommonMethods.Action_Page_Down_withoutjavascriptexecutor(WDriver);

                if (submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit.ToLower().Trim() == "extend offer")
                {
                    //results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferMethodModel.str_Btn_ExtendOffer_Submit);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit);
                    // results = kwm.select_Button1(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_tab_second, str_Btn_ExtendOffer_Submit);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_class_button, submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }
                }
                else
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Given button name not find " + submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit;
                    return results;
                }

                objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");

                objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
                Thread.Sleep(2000);
                //Yes button click
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit_Confirm);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(3000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit_Confirm);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }

                Thread.Sleep(2000);
                //ok click
                //  Console.WriteLine("str_Btn_OfferToHire_Submit");
                objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit_Confirm_Ok);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit_Confirm_Ok);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(10000);
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit_Confirm_Ok);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }
                }

                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = "Extend Offer submit";
                return results;
            }
            else
            {
                //Experience Validation check for AERO client.
                // regularCandidateListWithOffer
                //Candidate with Offers
                //  Console.WriteLine("Candidate with Offers  here test");
                //  Thread.Sleep(10000);
                objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");

                //results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManExtendOfferModel.strMainMenuLink, submitToManExtendOfferModel.strSubMenuLink);
                //if (results.Result1 == KeyWords.Result_FAIL)
                //{
                //    Thread.Sleep(5000);
                //    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManExtendOfferModel.strMainMenuLink, submitToManExtendOfferModel.strSubMenuLink);
                //    if (results.Result1 == KeyWords.Result_FAIL)
                //    {
                //        //results.ErrorMessage1 = "Unable to click on the Main menu";
                //        return results;
                //    }
                //}
                //results = kwm.Sub_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_SubMenu, submitToManExtendOfferModel.strSubMenuLink);
                //if (results.Result1 == KeyWords.Result_FAIL)
                //{
                //    Thread.Sleep(10000);
                //    results = kwm.Sub_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_SubMenu, submitToManExtendOfferModel.strSubMenuLink);
                //    if (results.Result1 == KeyWords.Result_FAIL)
                //    {
                //        //results.ErrorMessage1 = "Unable to click on the Main menu";
                //        return results;
                //    }
                //}

                //  Thread.Sleep(10000);
                Thread.Sleep(5000);
                //results = kwm.Total_Req_Links(WDriver, KeyWords.locator_ID, KeyWords.ID_List_regularCandidateListWithOffer);
                //if (results.Result1 == KeyWords.Result_FAIL)
                //{
                //    // Console.WriteLine("Problem Read total number of REQ Links");
                //    results.ErrorMessage = results.ErrorMessage + "," + " Problem Read total number of REQ Links";
                //    return results;
                //}

                // ExtendOffer_Data["Testtype"]
                if (ExtendOffer_Data["Testtype"].ToString().ToLower().Contains("identified"))
                {
                    if (!kwm.waitForElementExists(WDriver, By.XPath("//*[@id='identifiedCandidateListWithOffers_filter']//label//input"), kwm._WDWait))
                    {
                        Thread.Sleep(2000);
                    }
                    if (!kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='identifiedCandidateListWithOffers_filter']//label//input"), kwm._WDWait))
                    {
                        Thread.Sleep(2000);
                    }
                    results = kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[@id='identifiedCandidateListWithOffers_filter']//label//input");
                    kwm.sendTextXPathOnly(WDriver, "//*[@id='identifiedCandidateListWithOffers_filter']//label//input", submitToManExtendOfferModel.str_Link_ReqNumber);

                    kwm.waitForElementToBeClickable(WDriver, By.XPath("//table[@id='identifiedCandidateListWithOffers']//td/a[contains(text(),'" + submitToManExtendOfferModel.str_Link_ReqNumber + "')]"), kwm._WDWait);

                    objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");

                    kwm.click(WDriver, KeyWords.locator_XPath, "//table[@id='identifiedCandidateListWithOffers']//td/a[contains(text(),'" + submitToManExtendOfferModel.str_Link_ReqNumber + "')]");

                    objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
                }
                else
                {

                    for (int z = 1; z < 500; z++)
                    {
                        string strValue = "";
                        try
                        {
                            strValue = WDriver.FindElement(By.XPath("//*[@id='regularCandidateListWithOffer_paginate']/input")).GetAttribute("value");
                        }
                        catch
                        {
                            strValue = "";
                        }
                        //  Console.WriteLine("z -----> " + z);
                        //  Console.WriteLine("strValue -----> " + strValue);
                        if (strValue != "")
                        {
                            break;
                        }
                    }

                    int iCount = 0;
                    string strXPath = "//table[@" + KeyWords.locator_ID + "='" + KeyWords.ID_List_regularCandidateListWithOffer + "']/tbody/tr";
                    results = kwm.REQ_Link_Candidate_Count(WDriver, strXPath);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                    iCount = Convert.ToInt32(results.ErrorMessage);
                    if (submitToManExtendOfferModel.str_CandidateName.ToLower().Trim() == "")
                    {
                        results = kwm.GetNameFromReqNumber("FN", submitToManExtendOfferModel.str_Link_ReqNumber);
                        // string strCan
                        string strFN = "";
                        if (results.Result1 == KeyWords.Result_PASS)
                        {
                            strFN = results.ErrorMessage;
                        }
                        // results
                        results = kwm.GetNameFromReqNumber("LN", submitToManExtendOfferModel.str_Link_ReqNumber);
                        string strLN = "";
                        if (results.Result1 == KeyWords.Result_PASS)
                        {
                            strLN = results.ErrorMessage;
                        }

                        submitToManExtendOfferModel.str_CandidateName = strLN + ", " + strFN;
                    }
                    Thread.Sleep(5000);
                    objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
                    Boolean bFlag = false;
                    for (int i = 1; i <= iCount; i++)
                    {
                        Thread.Sleep(1000);
                        string strCandidateName_App = WDriver.FindElement(By.XPath("//table[@" + KeyWords.locator_ID + "='" + KeyWords.ID_List_regularCandidateListWithOffer + "']/tbody/tr[" + i + "]/td[2]")).Text;
                        string strReqNumber_App = WDriver.FindElement(By.XPath("//table[@" + KeyWords.locator_ID + "='" + KeyWords.ID_List_regularCandidateListWithOffer + "']/tbody/tr[" + i + "]/td[3]")).Text;
                        Console.WriteLine(strCandidateName_App);
                        Console.WriteLine(strReqNumber_App);
                        if ((submitToManExtendOfferModel.str_CandidateName.ToLower().Trim() == strCandidateName_App.ToLower().Trim()) && (strReqNumber_App == submitToManExtendOfferModel.str_Link_ReqNumber))
                        {
                            WDriver.FindElement(By.XPath("//table[@" + KeyWords.locator_ID + "='" + KeyWords.ID_List_regularCandidateListWithOffer + "']/tbody/tr[" + i + "]/td[2]/a")).Click();
                            bFlag = true;
                            break;
                        }
                    }
                    if (!bFlag)
                    {
                        Console.WriteLine(bFlag);
                        results.Result1 = KeyWords.Result_FAIL;
                        results.ErrorMessage = "The given canditate name not find " + submitToManExtendOfferModel.str_CandidateName;
                        return results;
                    }

                    objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");

                    Thread.Sleep(5000);
                    string strSubLevel = "./label";
                    results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManExtendOfferModel.str_Link_ActionList_ExperienceValidation, strSubLevel);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(15000);
                        results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManExtendOfferModel.str_Link_ActionList_ExperienceValidation, strSubLevel);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }

                    objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");



                    if (submitToManExtendOfferModel.str_Txt_Years != "")
                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_yearsInput, submitToManExtendOfferModel.str_Txt_Years, false);


                    if (submitToManExtendOfferModel.str_Txt_Months != "")
                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_monthsInput, submitToManExtendOfferModel.str_Txt_Months, false);


                    //div[@id='dialog']/fieldset/div/table/tbody/tr/td/input
                    objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
                    kwm.click(WDriver, KeyWords.locator_ID, "experience98");
                    WDriver.FindElement(By.XPath("//*[contains(@id,'experience')]")).Click();

                    objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
                    if (submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit.ToLower().Trim() == "submit")
                    {

                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit);
                        // results = kwm.select_Button1(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_tab_second, str_Btn_ExtendOffer_Submit);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                return results;
                            }
                        }
                    }
                    else
                    {
                        results.Result1 = KeyWords.Result_FAIL;
                        results.ErrorMessage = "Given button name not find " + submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit;
                        return results;
                    }

                    Thread.Sleep(2000);
                    objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
                    results = kwm.Error_Msg_Read_Submit_Resume_details(WDriver, "//div[@" + KeyWords.locator_ID + "='dialog']/div/div/div/ul/li");
                    if (results.Result1 == KeyWords.Result_PASS)
                    {
                        if (results.ErrorMessage != "")
                        {
                            kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Cancel");
                            results.Result1 = KeyWords.Result_FAIL;
                            return results;
                        }
                    }
                    // Console.WriteLine(WDriver.FindElement(By.Id("confirmDialog")).Displayed);
                    objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
                    if (WDriver.FindElement(By.Id("confirmDialog")).Displayed)
                    {
                        Console.WriteLine(WDriver.FindElement(By.Id("confirmDialog")).Displayed);

                        Thread.Sleep(2000);
                        //  Console.WriteLine("str_Btn_OfferToHire_Submit1");
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit_Confirm);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            Thread.Sleep(5000);
                            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit_Confirm);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit_Confirm);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            Thread.Sleep(15000);
                            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit_Confirm);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                return results;
                            }
                        }
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results.Result1 = KeyWords.Result_FAIL;
                            results.ErrorMessage = "Unable to find the confirm msg box";
                            return results;
                        }
                    }
                    //  Console.WriteLine("str_Btn_OfferToHire_Submit");
                    objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
                    results = kwm.Select_MSG_Button_OK_Click(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit_Confirm_Ok);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(5000);
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit_Confirm_Ok);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }
                }
                    return results;
                }
            
        }

        public Result ExtendOffer_Method(IWebDriver WDriver, DataRow ExtendOffer_Data)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            SubmitToManExtendOfferMethodModel submitToManExtendOfferMethodModel = createRequirementRepository.GetSubmitToManExtendOfferMethodData(ExtendOffer_Data);

            ////string strClientName = ExtendOffer_Data["P5"].ToString().Trim();
            ////string strMainMenuLink = ExtendOffer_Data["P6"].ToString().Trim();
            ////string strSubMenuLink = ExtendOffer_Data["P7"].ToString().Trim();
            ////string str_Link_ReqNumber = ExtendOffer_Data["P8"].ToString().Trim();
            ////string str_Link_ActionList_ViewCandidates = ExtendOffer_Data["P44"].ToString().Trim();
            ////string str_Link_ActionList_ExperienceValidation = ExtendOffer_Data["P44"].ToString().Trim();
            ////string str_CandidateName = ExtendOffer_Data["P10"].ToString().Trim();
            ////string str_Txt_Years = ExtendOffer_Data["P46"].ToString().Trim();
            ////string str_Link_ActionList_ExtendOffer = ExtendOffer_Data["P46"].ToString().Trim();
            ////string str_Txt_Months = ExtendOffer_Data["P47"].ToString().Trim();
            ////string str_Txt_proposedRegPayRate = ExtendOffer_Data["P47"].ToString().Trim();   //Proposed Pay Rate
            ////string str_Txt_proposedOTPayRate = ExtendOffer_Data["P48"].ToString().Trim();//Proposed OT Pay Rate
            ////string str_Txt_payRateMarkup = ExtendOffer_Data["P49"].ToString().Trim();//Pay Rate Markup%:
            ////string str_Txt_proposedRegBillRate = ExtendOffer_Data["P50"].ToString().Trim();//Proposed Supplier Bill Rate:
            ////string str_Txt_proposedOTBillRate = ExtendOffer_Data["P51"].ToString().Trim(); //Proposed Supplier OT Bill Rate:
            ////string str_Txt_finalRegBillRate = ExtendOffer_Data["P52"].ToString().Trim();//Final Bill Rate: 
            ////string str_Txt_finalOTBillRate = ExtendOffer_Data["P53"].ToString().Trim();//Final OT Bill Rate:  
            ////string str_Txt_weeklyRegHoursNTE = ExtendOffer_Data["P54"].ToString().Trim();
            ////string str_Txt_weeklyOTHoursNTE = ExtendOffer_Data["P55"].ToString().Trim();
            ////string str_Txt_yearlyRegHoursNTE = ExtendOffer_Data["P56"].ToString().Trim();
            ////string str_Txt_totalContractValue = ExtendOffer_Data["P57"].ToString().Trim();
            ////string str_Txt_PrefStartdate = ExtendOffer_Data["P58"].ToString().Trim();
            ////string str_Txt_enddate = ExtendOffer_Data["P59"].ToString().Trim();
            ////string str_AddListTxt_txtTimecardApprover = ExtendOffer_Data["P60"].ToString().Trim();
            ////string str_DeleteListTxt_txtTimecardApprover = ExtendOffer_Data["P61"].ToString().Trim();
            ////string str_AddListTxt_ChargeNumbers = ExtendOffer_Data["P62"].ToString().Trim();
            ////string str_DeleteListTxt_ChargeNumbers = ExtendOffer_Data["P63"].ToString().Trim();
            ////string str_AddListTxt_GLNumbers = ExtendOffer_Data["P64"].ToString().Trim();
            ////string str_DeleteListTxt_GLNumbers = ExtendOffer_Data["P65"].ToString().Trim();
            //////  string str_Txt_ProposedSupplierOTBillRate = ExtendOffer_Data["P14"].ToString().Trim();
            //////  string str_Txt_proposedRegBillRate = ExtendOffer_Data["P14"].ToString().Trim();
            //////  string str_Txt_proposedOTBillRate = ExtendOffer_Data["P14"].ToString().Trim();
            //////   string str_Txt_Proposebillrate = ExtendOffer_Data["P15"].ToString().Trim();
            //////  string str_Txt_finalRegBillRate = ExtendOffer_Data["P15"].ToString().Trim();
            ////// string str_Txt_proposedOTPayRate = ExtendOffer_Data["P15""].ToString().Trim();
            //////   string str_Txt_Proposeotbillrate = ExtendOffer_Data["P16"].ToString().Trim();
            ////string str_Btn_ExtendOffer_Submit = ExtendOffer_Data["P66"].ToString().Trim();
            ////string str_Btn_ExtendOffer_Submit_Confirm = ExtendOffer_Data["P67"].ToString().Trim();
            ////string str_Btn_ExtendOffer_Submit_Confirm_Ok = ExtendOffer_Data["P68"].ToString().Trim();
            ////string str_Txt_poNumber = ExtendOffer_Data["P69"].ToString().Trim();
            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferMethodModel.strClientName + "_");

            string[] words;
            string strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManExtendOfferMethodModel.str_Link_ActionList_ExtendOffer, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManExtendOfferMethodModel.str_Link_ActionList_ExtendOffer, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, "Requeue", strSubLevel);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                    Call_Requeue_Function(WDriver, strSubLevel);
                    results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManExtendOfferMethodModel.str_Link_ActionList_ExtendOffer, strSubLevel);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }

            Boolean bFilterTxt = false;
            for (int iFTxt = 0; iFTxt < 100; iFTxt++)
            {
                try
                {
                    bFilterTxt = WDriver.FindElement(By.Id("CandidateActioncontent")).Displayed;
                }
                catch
                {
                    kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManExtendOfferMethodModel.str_Link_ActionList_ExtendOffer, strSubLevel);
                }
                if (bFilterTxt)
                    break;
            }

            try
            {
                WDriver.FindElement(By.XPath("//*[@id='CandidateActioncontent']/ul/li[2]/a")).Click();
            }
            catch
            {
                //
            }


            if (submitToManExtendOfferMethodModel.str_Txt_proposedRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_proposedRegPayRate, submitToManExtendOfferMethodModel.str_Txt_proposedRegPayRate, true);


            if (submitToManExtendOfferMethodModel.str_Txt_proposedOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_proposedOTPayRate, submitToManExtendOfferMethodModel.str_Txt_proposedOTPayRate, true);



            if (submitToManExtendOfferMethodModel.str_Txt_payRateMarkup != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_payRateMarkup, submitToManExtendOfferMethodModel.str_Txt_payRateMarkup, true);

            if (submitToManExtendOfferMethodModel.str_Txt_proposedRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_proposedRegBillRate, submitToManExtendOfferMethodModel.str_Txt_proposedRegBillRate, true);

            if (submitToManExtendOfferMethodModel.str_Txt_proposedOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_proposedOTBillRate, submitToManExtendOfferMethodModel.str_Txt_proposedOTBillRate, true);

            if (submitToManExtendOfferMethodModel.str_Txt_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_finalRegBillRate, submitToManExtendOfferMethodModel.str_Txt_finalRegBillRate, true);
            objCommonMethods.Action_Button_Tab(WDriver);


            if (submitToManExtendOfferMethodModel.str_Txt_finalOTBillRate != "")
                Thread.Sleep(10000);
            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_finalOTBillRate, submitToManExtendOfferMethodModel.str_Txt_finalOTBillRate, true);

            if (submitToManExtendOfferMethodModel.str_Txt_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_weeklyRegHoursNTE, submitToManExtendOfferMethodModel.str_Txt_weeklyRegHoursNTE, true);

            if (submitToManExtendOfferMethodModel.str_Txt_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_weeklyOTHoursNTE, submitToManExtendOfferMethodModel.str_Txt_weeklyOTHoursNTE, true);

            if (submitToManExtendOfferMethodModel.str_Txt_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_yearlyRegHoursNTE, submitToManExtendOfferMethodModel.str_Txt_yearlyRegHoursNTE, true);

            if (submitToManExtendOfferMethodModel.str_Txt_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_totalContractValue, submitToManExtendOfferMethodModel.str_Txt_totalContractValue, true);

            //Extend offer hlf
		//Added by manjusha
			//contract value
			results = kwm.Estimatedcontractorvalue(WDriver, submitToManExtendOfferMethodModel.str_Txt_numberofDays_offertoHire, submitToManExtendOfferMethodModel.str_Txt_numberofResources_offertoHire, "40", "7", submitToManExtendOfferMethodModel.str_Txt_Billrate_Supplierbillrate);
			if (results._Var == submitToManExtendOfferMethodModel.str_Txt_Estimatedcontract_offertoHire)
			{
				ReportHandler._getChildTest().Log(LogStatus.Pass, "Contract Value is matched in  Extend Offer");
				objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, " value is  matched: ", 3);
			}
			else
			{
                ReportHandler._getChildTest().Log(LogStatus.Fail, "Contract Value is not mismatched in Extend Offer");
				objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, " value is not matched: ", 3);
			}


          //  kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_txtneededStartDate);

            if (submitToManExtendOfferMethodModel.str_Txt_PrefStartdate != "")
            {

                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_txtneededStartDate);
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_PrefStartdate, submitToManExtendOfferMethodModel.str_Txt_PrefStartdate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
                // }
            }
            objCommonMethods.Action_Page_Down_withoutjavascriptexecutor(WDriver);
            

            if (submitToManExtendOfferMethodModel.str_Txt_enddate != "")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_endDate);
                //  results = kwm.Select_End_Date_From_Picker(WDriver, submitToManExtendOfferMethodModel.str_Txt_enddate);
                //  if (results.Result1 == KeyWords.Result_FAIL)
                //   {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_enddate, submitToManExtendOfferMethodModel.str_Txt_enddate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
                //  }
            }
            objCommonMethods.Action_Button_Tab(WDriver);
            objCommonMethods.Action_Page_Down_withoutjavascriptexecutor(WDriver);
            //poNumber

            if (submitToManExtendOfferMethodModel.str_Txt_poNumber != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, "poNumber", KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManExtendOfferMethodModel.str_Txt_poNumber, submitToManExtendOfferMethodModel.str_Txt_poNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, "poNumber", KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManExtendOfferMethodModel.str_Txt_poNumber, submitToManExtendOfferMethodModel.str_Txt_poNumber);
                    //  return results;
                }

            }




            listExistClients = new List<string>() { Constants.Supervalu, Constants.IsGs, Constants.Sts, Constants.SaviTechnologies, Constants.GHC, Constants.BDA, Constants.AmCom, Constants.LmPinellas, Constants.NvEnergy, Constants.DCR, Constants.Meritor };
            if (listExistClients.Contains(submitToManExtendOfferMethodModel.strClientName.ToLower()))
            {
                if (submitToManExtendOfferMethodModel.str_AddListTxt_txtTimecardApprover != "")
                {
                    string[] separators1 = { "#" };
                    words = submitToManExtendOfferMethodModel.str_AddListTxt_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length >= 1)
                    {
                        for (int r = 0; r < words.Length; r++)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                                //  return results;
                            }
                            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addTimecardApproverbtn);
                            //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                        }
                    }

                }
            }

            listExistClients = new List<string>() { Constants.Supervalu, Constants.IsGs, Constants.Sts, Constants.SaviTechnologies, Constants.GHC, Constants.BDA, Constants.AmCom, Constants.LmPinellas, Constants.NvEnergy, Constants.DCR, Constants.Meritor };
            if (listExistClients.Contains(submitToManExtendOfferMethodModel.strClientName.ToLower()))
            {
                if (submitToManExtendOfferMethodModel.str_DeleteListTxt_txtTimecardApprover != "")
                {
                    string[] separators1 = { "#" };
                    words = submitToManExtendOfferMethodModel.str_DeleteListTxt_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length >= 1)
                    {
                        for (int r = 0; r < words.Length; r++)
                        {
                            ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addTimecardApprover']/option"));

                            List<IWebElement> elements = lis_ClientNames.ToList();
                            for (int i = 0; i < elements.Count; i++)
                            {

                                if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                                {
                                    // Console.WriteLine(elements[i].Text.ToLower().Trim());
                                    elements[i].Click();
                                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
                                }
                            }

                        }
                    }

                }
            }
            listExistClients = new List<string>() { Constants.YP };
            if (listExistClients.Contains(submitToManExtendOfferMethodModel.strClientName.ToLower()))
            {
                if (submitToManExtendOfferMethodModel.str_AddListTxt_ChargeNumbers != "")
                {
                    string[] separators1 = { "#" };
                    words = submitToManExtendOfferMethodModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length >= 1)
                    {
                        string[] separators2 = { "-" };
                        string[] words1 = submitToManExtendOfferMethodModel.str_AddListTxt_ChargeNumbers.Split(separators2, StringSplitOptions.RemoveEmptyEntries);
                        if (words1.Length >= 1)
                        {
                            for (int r1 = 0; r1 < words1.Length; r1++)
                            {
                                int n = 0;
                                n = 1 + r1;
                                if (r1 == 0)
                                {
                                    if (words1[r1].ToString() != "")
                                    {
                                        kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), words1[r1].ToString());
                                    }
                                }
                                if (r1 == 1)
                                {
                                    if (words1[r1].ToString() != "")
                                    {
                                        kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), words1[r1].ToString());
                                    }
                                }
                                if (r1 == 2)
                                {
                                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
                                    if (results.Result1 == KeyWords.Result_FAIL)
                                    {
                                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
                                        //  return results;
                                    }
                                }
                                if (r1 == 3)
                                {
                                    if (words1[r1].ToString() != "")
                                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), words1[r1].ToString(), false);
                                }
                                if (r1 == 4)
                                {
                                    if (words1[r1].ToString() != "")
                                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), words1[r1].ToString(), false);
                                }
                                if (r1 == 5)
                                {
                                    if (words1[r1].ToString() != "")
                                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), words1[r1].ToString(), false);
                                }
                                if (r1 == 6)
                                {
                                    if (words1[r1].ToString() != "")
                                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), words1[r1].ToString(), false);
                                }

                            }
                            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addAutoFilledChargeNobtn);
                        }

                    }

                }
            }
            listExistClients = new List<string>() { Constants.Supervalu, Constants.NvEnergy };
            if (listExistClients.Contains(submitToManExtendOfferMethodModel.strClientName.ToLower()))
            {
                if (submitToManExtendOfferMethodModel.str_AddListTxt_ChargeNumbers != "")
                {
                    string[] separators1 = { "#" };
                    words = submitToManExtendOfferMethodModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length >= 1)
                    {
                        string[] separators2 = { "-" };
                        string[] words1 = submitToManExtendOfferMethodModel.str_AddListTxt_ChargeNumbers.Split(separators2, StringSplitOptions.RemoveEmptyEntries);
                        if (words1.Length >= 1)
                        {
                            for (int r1 = 0; r1 < words1.Length; r1++)
                            {
                                int n = 0;
                                n = 1 + r1;
                                if (r1 == 0)
                                {
                                    if (words1[r1].ToString() != "")
                                    {
                                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
                                    }
                                }
                                if (r1 == 1)
                                {
                                    if (words1[r1].ToString() != "")
                                    {
                                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
                                    }
                                }
                                if (r1 == 2)
                                {
                                    if (words1[r1].ToString() != "")
                                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
                                }
                                if (r1 == 3)
                                {
                                    if (words1[r1].ToString() != "")
                                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
                                }
                                if (r1 == 4)
                                {
                                    if (words1[r1].ToString() != "")
                                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
                                }
                                if (r1 == 5)
                                {
                                    if (words1[r1].ToString() != "")
                                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
                                }
                                if (r1 == 6)
                                {
                                    if (words1[r1].ToString() != "")
                                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
                                }
                                if (r1 == 7)
                                {
                                    if (words1[r1].ToString() != "")
                                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + r1.ToString(), words1[r1].ToString(), false);
                                }
                            }
                            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addDivChargeNobtn);
                        }

                    }

                }
            }



            listExistClients = new List<string>() { Constants.Supervalu, "" };
            if (listExistClients.Contains(submitToManExtendOfferMethodModel.strClientName.ToLower()))
            {
                if (submitToManExtendOfferMethodModel.str_AddListTxt_ChargeNumbers != "")
                {
                    string[] separators1 = { "#" };
                    words = submitToManExtendOfferMethodModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length >= 1)
                    {
                        string[] separators2 = { "." };
                        string[] words1 = submitToManExtendOfferMethodModel.str_AddListTxt_ChargeNumbers.Split(separators2, StringSplitOptions.RemoveEmptyEntries);
                        if (words1.Length >= 1)
                        {
                            for (int r1 = 0; r1 < words1.Length; r1++)
                            {
                                if (r1 == 0)
                                {
                                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_CostCenterNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
                                    if (results.Result1 == KeyWords.Result_FAIL)
                                    {
                                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_CostCenterNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
                                        //  return results;
                                    }
                                }
                                if (r1 == 1)
                                {
                                    if (words1[r1].ToString() != "")
                                    {
                                        kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_GLAccounts, words1[r1].ToString());
                                    }
                                }
                                if (r1 == 2)
                                {
                                    if (words1[r1].ToString() != "")
                                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ProDept, words1[r1].ToString(), false);
                                }
                                if (r1 == 3)
                                {
                                    if (words1[r1].ToString() != "")
                                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_association, words1[r1].ToString(), false);
                                }
                                if (r1 == 4)
                                {
                                    if (words1[r1].ToString() != "")
                                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Location, words1[r1].ToString(), false);
                                }
                                if (r1 == 5)
                                {
                                    if (words1[r1].ToString() != "")
                                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ServDept, words1[r1].ToString(), false);
                                }
                                if (r1 == 6)
                                {
                                    if (words1[r1].ToString() != "")
                                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_IntComp, words1[r1].ToString(), false);
                                }
                            }
                            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_AddCostOrgLegalGL);
                        }

                    }
                }

                listExistClients = new List<string>() { Constants.Supervalu, Constants.IsGs, Constants.Sts, Constants.NvEnergy, Constants.YP };
                if (listExistClients.Contains(submitToManExtendOfferMethodModel.strClientName.ToLower()))
                {
                    if (submitToManExtendOfferMethodModel.str_DeleteListTxt_ChargeNumbers != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferMethodModel.str_DeleteListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            for (int r = 0; r < words.Length; r++)
                            {


                                //select[@id='addTimecardApprover']/option
                                ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addChargeNo']/option"));

                                List<IWebElement> elements = lis_ClientNames.ToList();
                                //  Console.WriteLine(elements.Count);
                                //  Console.WriteLine("elements.Count");
                                for (int i = 0; i < elements.Count; i++)
                                {
                                    //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
                                    //     Console.WriteLine(elements[i].Text.ToLower().Trim());
                                    if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                                    {
                                        // Console.WriteLine(elements[i].Text.ToLower().Trim());
                                        elements[i].Click();
                                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteDivChargeNobtn);

                                    }
                                }

                            }
                        }

                    }
                }
            }

            listExistClients = new List<string>() { Constants.SaviTechnologies, Constants.Sts, Constants.DCR };
            if (listExistClients.Contains(submitToManExtendOfferMethodModel.strClientName.ToLower()))
            {

                if (submitToManExtendOfferMethodModel.str_AddListTxt_ChargeNumbers != "")
                {
                    string[] separators1 = { "#" };
                    words = submitToManExtendOfferMethodModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length >= 1)
                    {
                        for (int r = 0; r < words.Length; r++)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtChargeNo, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtChargeNo, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                                //  return results;
                            }
                            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addChargeNobtn);
                            kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "No");
                        }
                    }
                }


                objCommonMethods.Action_Page_Down_withoutjavascriptexecutor(WDriver);
                if (submitToManExtendOfferMethodModel.str_DeleteListTxt_ChargeNumbers != "")
                {
                    string[] separators1 = { "#" };
                    words = submitToManExtendOfferMethodModel.str_DeleteListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length >= 1)
                    {
                        for (int r = 0; r < words.Length; r++)
                        {


                            //select[@id='addTimecardApprover']/option
                            ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addChargeNo']/option"));

                            List<IWebElement> elements = lis_ClientNames.ToList();
                            //  Console.WriteLine(elements.Count);
                            //  Console.WriteLine("elements.Count");
                            for (int i = 0; i < elements.Count; i++)
                            {
                                //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
                                //     Console.WriteLine(elements[i].Text.ToLower().Trim());
                                if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                                {
                                    // Console.WriteLine(elements[i].Text.ToLower().Trim());
                                    elements[i].Click();
                                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteChargeNobtn);
                                }
                            }

                        }
                    }

                }



            }
            listExistClients = new List<string>() { Constants.BDA, "" };
            if (listExistClients.Contains(submitToManExtendOfferMethodModel.strClientName.ToLower()))
            {

                if (submitToManExtendOfferMethodModel.str_AddListTxt_ChargeNumbers != "")
                {
                    string[] separators1 = { "#" };
                    words = submitToManExtendOfferMethodModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length >= 1)
                    {
                        string[] separators2 = { "-" };
                        string[] words1 = submitToManExtendOfferMethodModel.str_AddListTxt_ChargeNumbers.Split(separators2, StringSplitOptions.RemoveEmptyEntries);
                        if (words1.Length >= 1)
                        {
                            for (int r1 = 0; r1 < words1.Length; r1++)
                            {
                                if (r1 == 1)
                                {
                                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
                                    if (results.Result1 == KeyWords.Result_FAIL)
                                    {
                                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
                                        //  return results;
                                    }
                                }
                                if (r1 == 0)
                                {
                                    if (words1[r1].ToString() != "")
                                    {
                                        kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_WorkLocationCode, words1[r1].ToString());
                                    }
                                }

                            }
                            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addDivChargeNobtn);
                        }

                    }
                }



                if (submitToManExtendOfferMethodModel.str_DeleteListTxt_ChargeNumbers != "")
                {
                    string[] separators1 = { "#" };
                    words = submitToManExtendOfferMethodModel.str_DeleteListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length >= 1)
                    {
                        for (int r = 0; r < words.Length; r++)
                        {


                            //select[@id='addTimecardApprover']/option
                            ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addChargeNo']/option"));

                            List<IWebElement> elements = lis_ClientNames.ToList();
                            //  Console.WriteLine(elements.Count);
                            //  Console.WriteLine("elements.Count");
                            for (int i = 0; i < elements.Count; i++)
                            {
                                //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
                                //     Console.WriteLine(elements[i].Text.ToLower().Trim());
                                if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                                {
                                    // Console.WriteLine(elements[i].Text.ToLower().Trim());
                                    elements[i].Click();
                                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteChargeNobtn);
                                }
                            }

                        }
                    }

                }



            }
            listExistClients = new List<string>() { Constants.GHC, "" };
            if (listExistClients.Contains(submitToManExtendOfferMethodModel.strClientName.ToLower()))
            {

                if (submitToManExtendOfferMethodModel.str_AddListTxt_ChargeNumbers != "")
                {
                    string[] separators1 = { "#" };
                    words = submitToManExtendOfferMethodModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length >= 1)
                    {
                        string[] separators2 = { "-" };
                        string[] words1 = submitToManExtendOfferMethodModel.str_AddListTxt_ChargeNumbers.Split(separators2, StringSplitOptions.RemoveEmptyEntries);
                        if (words1.Length >= 1)
                        {
                            for (int r1 = 0; r1 < words1.Length; r1++)
                            {
                                if (r1 == 0)
                                {
                                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
                                    if (results.Result1 == KeyWords.Result_FAIL)
                                    {
                                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
                                        //  return results;
                                    }
                                }
                                if (r1 == 1)
                                {
                                    if (words1[r1].ToString() != "")
                                    {
                                        kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_selectOrgId, words1[r1].ToString());
                                    }
                                }

                            }
                            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addDivChargeNobtn);
                        }

                    }
                }



                if (submitToManExtendOfferMethodModel.str_DeleteListTxt_ChargeNumbers != "")
                {
                    string[] separators1 = { "#" };
                    words = submitToManExtendOfferMethodModel.str_DeleteListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length >= 1)
                    {
                        for (int r = 0; r < words.Length; r++)
                        {


                            //select[@id='addTimecardApprover']/option
                            ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addChargeNo']/option"));

                            List<IWebElement> elements = lis_ClientNames.ToList();
                            //  Console.WriteLine(elements.Count);
                            //  Console.WriteLine("elements.Count");
                            for (int i = 0; i < elements.Count; i++)
                            {
                                //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
                                //     Console.WriteLine(elements[i].Text.ToLower().Trim());
                                if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                                {
                                    // Console.WriteLine(elements[i].Text.ToLower().Trim());
                                    elements[i].Click();
                                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteChargeNobtn);
                                }
                            }

                        }
                    }

                }



            }

            //  Console.WriteLine("Test7");


            objCommonMethods.Action_Page_Down_withoutjavascriptexecutor(WDriver);

            listExistClients = new List<string>() { Constants.SaviTechnologies, Constants.Sts, Constants.DCR };
            if (listExistClients.Contains(submitToManExtendOfferMethodModel.strClientName.ToLower()))
            {
                //public static string ID_Txt_txtChargeNo = "txtChargeNo";  ID_ComboList_addChargeNo
                // public static string ID_Button_addChargeNobtn ="addChargeNobtn";
                // public static string ID_Button_deleteChargeNobtn ="deleteChargeNobtn";
                if (submitToManExtendOfferMethodModel.str_AddListTxt_GLNumbers != "")
                {
                    string[] separators1 = { "#" };
                    words = submitToManExtendOfferMethodModel.str_AddListTxt_GLNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length >= 1)
                    {
                        for (int r = 0; r < words.Length; r++)
                        {
                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtGLNo, words[r], false);
                            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addGLNobtn);
                            Thread.Sleep(1000);
                            kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "No");
                        }
                    }
                }



                if (submitToManExtendOfferMethodModel.str_DeleteListTxt_GLNumbers != "")
                {
                    string[] separators1 = { "#" };
                    words = submitToManExtendOfferMethodModel.str_DeleteListTxt_GLNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length >= 1)
                    {
                        for (int r = 0; r < words.Length; r++)
                        {


                            //select[@id='addTimecardApprover']/option
                            ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addGLNo']/option"));

                            List<IWebElement> elements = lis_ClientNames.ToList();
                            //  Console.WriteLine(elements.Count);
                            //  Console.WriteLine("elements.Count");
                            for (int i = 0; i < elements.Count; i++)
                            {
                                //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
                                //     Console.WriteLine(elements[i].Text.ToLower().Trim());
                                if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                                {
                                    // Console.WriteLine(elements[i].Text.ToLower().Trim());
                                    elements[i].Click();
                                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteGLNobtn);
                                }
                            }

                        }
                    }

                }



            }
            //  Console.WriteLine("Test8");
            //      Thread.Sleep(2000);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferMethodModel.strClientName + "_");
            objCommonMethods.Action_Page_Down_withoutjavascriptexecutor(WDriver);
            Console.WriteLine(submitToManExtendOfferMethodModel.str_Btn_ExtendOffer_Submit);
            if (submitToManExtendOfferMethodModel.str_Btn_ExtendOffer_Submit.ToLower().Trim() == "extend offer")
            {

                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferMethodModel.str_Btn_ExtendOffer_Submit);
                // results = kwm.select_Button1(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_tab_second, submitToManExtendOfferMethodModel.str_Btn_ExtendOffer_Submit);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferMethodModel.str_Btn_ExtendOffer_Submit);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }
            else
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Given button name not find " + submitToManExtendOfferMethodModel.str_Btn_ExtendOffer_Submit;
                return results;
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferMethodModel.strClientName + "_");
            results = kwm.Error_Msg_Read_Submit_Resume_details(WDriver, "//div[@" + KeyWords.locator_ID + "='" + KeyWords.ID_Button_tab_second + "']/div/div/div/ul/li");
            if (results.Result1 == KeyWords.Result_PASS)
            {
                if (results.ErrorMessage != "")
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    return results;
                }
            }
            //yes button click


            Thread.Sleep(2000);
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferMethodModel.str_Btn_ExtendOffer_Submit_Confirm);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(15000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferMethodModel.str_Btn_ExtendOffer_Submit_Confirm);
                {
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results.Result1 = KeyWords.Result_FAIL;
                        results.ErrorMessage = "Unable to find the confirm msg box";
                        return results;
                    }
                }
            }

            //Ok click
            Console.WriteLine("str_Btn_extendoffer_Submiokt");
            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferMethodModel.strClientName + "_");
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferMethodModel.str_Btn_ExtendOffer_Submit_Confirm_Ok);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferMethodModel.str_Btn_ExtendOffer_Submit_Confirm_Ok);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(10000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferMethodModel.str_Btn_ExtendOffer_Submit_Confirm_Ok);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }


            // Thread.Sleep(10000);
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = "Extend Offer submit";
            return results;


        }

        public Result Identify_ExtendOffer_Method(IWebDriver WDriver, DataRow ExtendOffer_Data)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 50);
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            SubmitToManExtendOfferModel submitToManExtendOfferModel = createRequirementRepository.GetSubmitToManExtendOfferData(ExtendOffer_Data);
         
           
            listExistClients = new List<string>() { Constants.Discover };
            if (listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManExtendOfferModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManExtendOfferModel.strClientName);
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
            if (!listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManExtendOfferModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManExtendOfferModel.strClientName);
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

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
            

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManExtendOfferModel.strMainMenuLink, submitToManExtendOfferModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManExtendOfferModel.strMainMenuLink, submitToManExtendOfferModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }
           
                objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");

                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.ID_paginate_regReqList_filter);

                if (!kwm.waitForElementExists(WDriver, By.XPath("//*[@id='identifiedCandidateListWithOffers_filter']//label//input"), kwm._WDWait))
                {
                    Thread.Sleep(2000);
                }
                if (!kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='identifiedCandidateListWithOffers_filter']//label//input"), kwm._WDWait))
                {
                    Thread.Sleep(2000);
                }
                results = kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[@id='identifiedCandidateListWithOffers_filter']//label//input");
                kwm.sendTextXPathOnly(WDriver, "//*[@id='identifiedCandidateListWithOffers_filter']//label//input", submitToManExtendOfferModel.str_CandidateName);

                kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='identifiedCandidateListWithOffers']//tbody/tr/td[2]/a[contains(text(),'" + submitToManExtendOfferModel.str_CandidateName + "')]"), kwm._WDWait);

                objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");

                results = kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='identifiedCandidateListWithOffers']//tbody/tr/td[2]/a[contains(text(),'" + submitToManExtendOfferModel.str_CandidateName + "')]");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='identifiedCandidateListWithOffers']//tbody/tr/td[2]/a[contains(text(),'" + submitToManExtendOfferModel.str_CandidateName + "')]"), kwm._WDWait);
                    Thread.Sleep(2000);
                    results = kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='identifiedCandidateListWithOffers']//tbody/tr/td[2]/a[contains(text(),'" + submitToManExtendOfferModel.str_CandidateName + "')]");

                }
                //*[@id="identifiedCandidateListWithOffers"]/tbody/tr/td[2]/a
                objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
                     
                string strSubLevel = "";
                
                

                //   Thread.Sleep(10000);
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
                    Thread.Sleep(100);
                }
                strSubLevel = "";
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManExtendOfferModel.str_Link_ActionList_ExtendOffer, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManExtendOfferModel.str_Link_ActionList_ExtendOffer, strSubLevel);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, "Requeue", strSubLevel);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                        Call_Requeue_Function(WDriver, strSubLevel);
                        results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManExtendOfferModel.str_Link_ActionList_ExtendOffer, strSubLevel);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }
                }

                Boolean bFilterTxt = false;
                for (int iFTxt = 0; iFTxt < 100; iFTxt++)
                {
                    try
                    {
                        bFilterTxt = WDriver.FindElement(By.Id("CandidateActioncontent")).Displayed;
                    }
                    catch
                    {
                        kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManExtendOfferModel.str_Link_ActionList_ExtendOffer, strSubLevel);
                    }
                    if (bFilterTxt)
                        break;
                }

                // Here get the Supplier Email and assign to this KeyWords.str_Email_Txt_Supplier then supplier email write in excel file.

                results = kwm.GetText_Xpath(WDriver, KeyWords.Xpath_txt_Extendofferpopup_Email);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    KeyWords.str_Email_Txt_Supplier = "";
                }
                else
                {
                    KeyWords.str_Email_Txt_Supplier = results._Var;
                }
            // end email assign

                try
                {
                    WDriver.FindElement(By.XPath("//*[@id='CandidateActioncontent']/ul/li[2]/a")).Click();
                }
                catch
                {
                    //
                }

                //Proposed Pay rate option

                try
                {
                    WDriver.FindElement(By.XPath("//*[@class='tblDataFree']/tbody/tr[6]/td[1]")).Click();

                }
                catch (Exception e)
                {

                }

                if (submitToManExtendOfferModel.str_Txt_ProposeDifferentRate == "Accept Rates")
                {
                    try
                    {
                        WDriver.FindElement(By.XPath(KeyWords.XPath_RadioButton_AcceptRates)).Click();
                    }
                    catch
                    {
                        Console.WriteLine("Click on radio button" + submitToManExtendOfferModel.str_Txt_ProposeDifferentRate);
                    }
                }
                //proposed diff rate
                if (submitToManExtendOfferModel.str_Txt_ProposeDifferentRate == "Propose Different Rate")
                {
                    try
                    {
                        WDriver.FindElement(By.XPath(KeyWords.XPath_RadioButton_ProposeDifferentRate)).Click();

                        if (submitToManExtendOfferModel.str_Txt_proposedRegPayRate != "")
                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Proposebillrate, submitToManExtendOfferModel.str_Txt_proposedRegPayRate, true);

                        if (submitToManExtendOfferModel.str_Txt_proposedOTPayRate != "")
                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Proposeotbillrate, submitToManExtendOfferModel.str_Txt_proposedOTPayRate, true);
                        objCommonMethods.Action_Page_Down(WDriver);

                    }
                    catch
                    {
                        Console.WriteLine("Click on radio button" + submitToManExtendOfferModel.str_Txt_ProposeDifferentRate);
                    }

                }



                if (submitToManExtendOfferModel.str_Txt_proposedRegPayRate != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_proposedRegPayRate, submitToManExtendOfferModel.str_Txt_proposedRegPayRate, true);


                if (submitToManExtendOfferModel.str_Txt_proposedOTPayRate != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_proposedOTPayRate, submitToManExtendOfferModel.str_Txt_proposedOTPayRate, true);

                objCommonMethods.Action_Page_Down_withoutjavascriptexecutor(WDriver);

                if (submitToManExtendOfferModel.str_Txt_IdentifiedCandidate_PayRateMarkup_markup != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_IdentifiedCandidate_PayRateMarkup_markup, submitToManExtendOfferModel.str_Txt_IdentifiedCandidate_PayRateMarkup_markup, true);


                if (submitToManExtendOfferModel.str_Txt_proposedRegBillRate != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_proposedRegBillRate, submitToManExtendOfferModel.str_Txt_proposedRegBillRate, true);

                if (submitToManExtendOfferModel.str_Txt_proposedOTBillRate != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_proposedOTBillRate, submitToManExtendOfferModel.str_Txt_proposedOTBillRate, true);

                if (submitToManExtendOfferModel.str_Txt_finalRegBillRate != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_finalRegBillRate, submitToManExtendOfferModel.str_Txt_finalRegBillRate, true);
                objCommonMethods.Action_Button_Tab(WDriver);
                objCommonMethods.Action_Page_Down_withoutjavascriptexecutor(WDriver);

                Thread.Sleep(2000);
                if (!string.IsNullOrWhiteSpace(submitToManExtendOfferModel.str_Txt_finalOTBillRate))
                {

                    results = kwm.sendText_clr_backspace(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_finalOTBillRate, submitToManExtendOfferModel.str_Txt_finalOTBillRate);
                    Thread.Sleep(2000);
                    objCommonMethods.Action_Button_Tab(WDriver);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
                Thread.Sleep(2000);

                if (submitToManExtendOfferModel.str_Txt_weeklyRegHoursNTE != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_weeklyRegHoursNTE, submitToManExtendOfferModel.str_Txt_weeklyRegHoursNTE, true);

                if (submitToManExtendOfferModel.str_Txt_weeklyOTHoursNTE != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_weeklyOTHoursNTE, submitToManExtendOfferModel.str_Txt_weeklyOTHoursNTE, true);

                if (submitToManExtendOfferModel.str_Txt_yearlyRegHoursNTE != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_yearlyRegHoursNTE, submitToManExtendOfferModel.str_Txt_yearlyRegHoursNTE, true);

                if (submitToManExtendOfferModel.str_Txt_totalContractValue != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_totalContractValue, submitToManExtendOfferModel.str_Txt_totalContractValue, true);


                //added by manjusha eofull
                //contract value
                results = kwm.Estimatedcontractorvalue(WDriver, submitToManExtendOfferModel.str_Txt_numberofDays_offertoHire, submitToManExtendOfferModel.str_Txt_numberofResources_offertoHire, "40", "7", submitToManExtendOfferModel.str_Txt_Billrate_Supplierbillrate);

                if (results._Var == submitToManExtendOfferModel.str_Txt_Estimatedcontract_offertoHire)
                {
                    ReportHandler._getChildTest().Log(LogStatus.Pass, "Contract Value is matched in Extend Offer");
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, " value is  matched: ", 3);
                }
                else
                {
                    ReportHandler._getChildTest().Log(LogStatus.Fail, "Contract Value is not mismatched in Extend Offer");
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, " value is not matched: ", 3);
                }


                if (submitToManExtendOfferModel.str_Txt_PrefStartdate != "")
                {
                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_txtneededStartDate);
                    // results = kwm.Select_Start_Date_From_Picker(WDriver, submitToManExtendOfferModel.str_Txt_PrefStartdate);
                    //  if (results.Result1 == KeyWords.Result_FAIL)
                    //  {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_PrefStartdate, submitToManExtendOfferModel.str_Txt_PrefStartdate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                    // }
                }



                if (submitToManExtendOfferModel.str_Txt_enddate != "")
                {
                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_endDate);
                    //  results = kwm.Select_End_Date_From_Picker(WDriver, submitToManExtendOfferModel.str_Txt_enddate);
                    //  if (results.Result1 == KeyWords.Result_FAIL)
                    //   {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_enddate, submitToManExtendOfferModel.str_Txt_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                    //  }
                }


                objCommonMethods.Action_Page_Down_withoutjavascriptexecutor(WDriver);
                //poNumber
                string[] separators = { " " };
                //string value = results.ErrorMessage;
                string[] words;
                if (submitToManExtendOfferModel.str_Txt_poNumber != "")
                {
                    //kwm.sendText(WDriver, KeyWords.locator_ID, "poNumber", str_Txt_poNumber, true);
                    //  results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, "poNumber", KeyWords.locator_class, KeyWords.CL_list_typeahead, str_Txt_poNumber, str_Txt_poNumber);
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, "poNumber", KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManExtendOfferModel.str_Txt_poNumber, submitToManExtendOfferModel.str_Txt_poNumber);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, "poNumber", KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManExtendOfferModel.str_Txt_poNumber, submitToManExtendOfferModel.str_Txt_poNumber);
                        //  return results;
                    }

                }
                listExistClients = new List<string>() { Constants.Supervalu, Constants.IsGs, Constants.Sts, Constants.SaviTechnologies, Constants.GHC, Constants.BDA, Constants.AmCom, Constants.LmPinellas, Constants.NvEnergy, Constants.DCR, Constants.Meritor, Constants.APS };
                if (listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
                {
                    if (submitToManExtendOfferModel.str_AddListTxt_txtTimecardApprover != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_AddListTxt_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            for (int r = 0; r < words.Length; r++)
                            {
                                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                                if (results.Result1 == KeyWords.Result_FAIL)
                                {
                                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                                    //  return results;
                                }
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addTimecardApproverbtn);
                                //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                            }
                        }

                    }
                }

                listExistClients = new List<string>() { Constants.Supervalu, Constants.IsGs, Constants.Sts, Constants.SaviTechnologies, Constants.GHC, Constants.BDA, Constants.AmCom, Constants.LmPinellas, Constants.NvEnergy, Constants.DCR, Constants.Meritor, Constants.APS };
                if (listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
                {
                    if (submitToManExtendOfferModel.str_DeleteListTxt_txtTimecardApprover != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_DeleteListTxt_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            for (int r = 0; r < words.Length; r++)
                            {


                                //select[@id='addTimecardApprover']/option
                                ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addTimecardApprover']/option"));

                                List<IWebElement> elements = lis_ClientNames.ToList();
                                //  Console.WriteLine(elements.Count);
                                //  Console.WriteLine("elements.Count");
                                for (int i = 0; i < elements.Count; i++)
                                {
                                    //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
                                    //     Console.WriteLine(elements[i].Text.ToLower().Trim());
                                    if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                                    {
                                        // Console.WriteLine(elements[i].Text.ToLower().Trim());
                                        elements[i].Click();
                                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
                                    }
                                }

                            }
                        }

                    }
                }
                // string str_AddListTxt_ChargeNumbers = OfferToHire_Data[28"].ToString().Trim();
                listExistClients = new List<string>() { Constants.YP };
                if (listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
                {
                    if (submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            string[] separators2 = { "-" };
                            string[] words1 = submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers.Split(separators2, StringSplitOptions.RemoveEmptyEntries);
                            if (words1.Length >= 1)
                            {
                                for (int r1 = 0; r1 < words1.Length; r1++)
                                {
                                    int n = 0;
                                    n = 1 + r1;
                                    if (r1 == 0)
                                    {
                                        if (words1[r1].ToString() != "")
                                        {
                                            kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), words1[r1].ToString());
                                        }
                                    }
                                    if (r1 == 1)
                                    {
                                        if (words1[r1].ToString() != "")
                                        {
                                            kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), words1[r1].ToString());
                                        }
                                    }
                                    if (r1 == 2)
                                    {
                                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
                                        if (results.Result1 == KeyWords.Result_FAIL)
                                        {
                                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
                                            //  return results;
                                        }
                                    }
                                    if (r1 == 3)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), words1[r1].ToString(), false);
                                    }
                                    if (r1 == 4)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), words1[r1].ToString(), false);
                                    }
                                    if (r1 == 5)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), words1[r1].ToString(), false);
                                    }
                                    if (r1 == 6)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AutoFilledChargeNoLabel + n.ToString(), words1[r1].ToString(), false);
                                    }

                                }
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addAutoFilledChargeNobtn);
                            }

                        }

                    }
                }
                listExistClients = new List<string>() { Constants.Supervalu, Constants.NvEnergy };
                if (listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
                {
                    if (submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            string[] separators2 = { "-" };
                            string[] words1 = submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers.Split(separators2, StringSplitOptions.RemoveEmptyEntries);
                            if (words1.Length >= 1)
                            {
                                for (int r1 = 0; r1 < words1.Length; r1++)
                                {
                                    int n = 0;
                                    n = 1 + r1;
                                    if (r1 == 0)
                                    {
                                        if (words1[r1].ToString() != "")
                                        {
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
                                        }
                                    }
                                    if (r1 == 1)
                                    {
                                        if (words1[r1].ToString() != "")
                                        {
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
                                        }
                                    }
                                    if (r1 == 2)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
                                    }
                                    if (r1 == 3)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
                                    }
                                    if (r1 == 4)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
                                    }
                                    if (r1 == 5)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
                                    }
                                    if (r1 == 6)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + n.ToString(), words1[r1].ToString(), false);
                                    }
                                    if (r1 == 7)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DividedChargenoLabel + r1.ToString(), words1[r1].ToString(), false);
                                    }
                                }
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addDivChargeNobtn);
                            }

                        }

                    }
                }

                listExistClients = new List<string>() { Constants.Supervalu, "" };
                if (listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
                {
                    if (submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            string[] separators2 = { "." };
                            string[] words1 = submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers.Split(separators2, StringSplitOptions.RemoveEmptyEntries);
                            if (words1.Length >= 1)
                            {
                                for (int r1 = 0; r1 < words1.Length; r1++)
                                {
                                    if (r1 == 0)
                                    {
                                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_CostCenterNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
                                        if (results.Result1 == KeyWords.Result_FAIL)
                                        {
                                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_CostCenterNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
                                            //  return results;
                                        }
                                    }
                                    if (r1 == 1)
                                    {
                                        if (words1[r1].ToString() != "")
                                        {
                                            kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_GLAccounts, words1[r1].ToString());
                                        }
                                    }
                                    if (r1 == 2)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ProDept, words1[r1].ToString(), false);
                                    }
                                    if (r1 == 3)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_association, words1[r1].ToString(), false);
                                    }
                                    if (r1 == 4)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Location, words1[r1].ToString(), false);
                                    }
                                    if (r1 == 5)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ServDept, words1[r1].ToString(), false);
                                    }
                                    if (r1 == 6)
                                    {
                                        if (words1[r1].ToString() != "")
                                            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_IntComp, words1[r1].ToString(), false);
                                    }
                                }
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_AddCostOrgLegalGL);
                            }

                        }
                    }

                    listExistClients = new List<string>() { Constants.Supervalu, Constants.IsGs, Constants.Sts, Constants.NvEnergy, Constants.YP };
                    if (listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
                    {
                        if (submitToManExtendOfferModel.str_DeleteListTxt_ChargeNumbers != "")
                        {
                            string[] separators1 = { "#" };
                            words = submitToManExtendOfferModel.str_DeleteListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                            if (words.Length >= 1)
                            {
                                for (int r = 0; r < words.Length; r++)
                                {


                                    //select[@id='addTimecardApprover']/option
                                    ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addChargeNo']/option"));

                                    List<IWebElement> elements = lis_ClientNames.ToList();
                                    //  Console.WriteLine(elements.Count);
                                    //  Console.WriteLine("elements.Count");
                                    for (int i = 0; i < elements.Count; i++)
                                    {
                                        //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
                                        //     Console.WriteLine(elements[i].Text.ToLower().Trim());
                                        if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                                        {
                                            // Console.WriteLine(elements[i].Text.ToLower().Trim());
                                            elements[i].Click();
                                            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteDivChargeNobtn);

                                        }
                                    }

                                }
                            }

                        }
                    }
                }

                listExistClients = new List<string>() { Constants.SaviTechnologies, Constants.Sts, Constants.DCR };
                if (listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
                {

                    if (submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            for (int r = 0; r < words.Length; r++)
                            {
                                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtChargeNo, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                                if (results.Result1 == KeyWords.Result_FAIL)
                                {
                                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtChargeNo, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                                    //  return results;
                                }
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addChargeNobtn);
                                kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "No");
                            }
                        }
                    }



                    if (submitToManExtendOfferModel.str_DeleteListTxt_ChargeNumbers != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_DeleteListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            for (int r = 0; r < words.Length; r++)
                            {


                                //select[@id='addTimecardApprover']/option
                                ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addChargeNo']/option"));

                                List<IWebElement> elements = lis_ClientNames.ToList();
                                //  Console.WriteLine(elements.Count);
                                //  Console.WriteLine("elements.Count");
                                for (int i = 0; i < elements.Count; i++)
                                {
                                    //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
                                    //     Console.WriteLine(elements[i].Text.ToLower().Trim());
                                    if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                                    {
                                        // Console.WriteLine(elements[i].Text.ToLower().Trim());
                                        elements[i].Click();
                                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteChargeNobtn);
                                    }
                                }

                            }
                        }

                    }



                }
                listExistClients = new List<string>() { Constants.BDA, "" };
                if (listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
                {

                    if (submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            string[] separators2 = { "-" };
                            string[] words1 = submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers.Split(separators2, StringSplitOptions.RemoveEmptyEntries);
                            if (words1.Length >= 1)
                            {
                                for (int r1 = 0; r1 < words1.Length; r1++)
                                {
                                    if (r1 == 1)
                                    {
                                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
                                        if (results.Result1 == KeyWords.Result_FAIL)
                                        {
                                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
                                            //  return results;
                                        }
                                    }
                                    if (r1 == 0)
                                    {
                                        if (words1[r1].ToString() != "")
                                        {
                                            kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_WorkLocationCode, words1[r1].ToString());
                                        }
                                    }

                                }
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addDivChargeNobtn);
                            }

                        }
                    }



                    if (submitToManExtendOfferModel.str_DeleteListTxt_ChargeNumbers != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_DeleteListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            for (int r = 0; r < words.Length; r++)
                            {


                                //select[@id='addTimecardApprover']/option
                                ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addChargeNo']/option"));

                                List<IWebElement> elements = lis_ClientNames.ToList();
                                //  Console.WriteLine(elements.Count);
                                //  Console.WriteLine("elements.Count");
                                for (int i = 0; i < elements.Count; i++)
                                {
                                    //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
                                    //     Console.WriteLine(elements[i].Text.ToLower().Trim());
                                    if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                                    {
                                        // Console.WriteLine(elements[i].Text.ToLower().Trim());
                                        elements[i].Click();
                                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteChargeNobtn);
                                    }
                                }

                            }
                        }

                    }



                }
                listExistClients = new List<string>() { Constants.GHC, "" };
                if (listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
                {

                    if (submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            string[] separators2 = { "-" };
                            string[] words1 = submitToManExtendOfferModel.str_AddListTxt_ChargeNumbers.Split(separators2, StringSplitOptions.RemoveEmptyEntries);
                            if (words1.Length >= 1)
                            {
                                for (int r1 = 0; r1 < words1.Length; r1++)
                                {
                                    if (r1 == 0)
                                    {
                                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
                                        if (results.Result1 == KeyWords.Result_FAIL)
                                        {
                                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, words1[r1].ToString(), words1[r1].ToString());
                                            //  return results;
                                        }
                                    }
                                    if (r1 == 1)
                                    {
                                        if (words1[r1].ToString() != "")
                                        {
                                            kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_selectOrgId, words1[r1].ToString());
                                        }
                                    }

                                }
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addDivChargeNobtn);
                            }

                        }
                    }



                    if (submitToManExtendOfferModel.str_DeleteListTxt_ChargeNumbers != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_DeleteListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            for (int r = 0; r < words.Length; r++)
                            {


                                //select[@id='addTimecardApprover']/option
                                ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addChargeNo']/option"));

                                List<IWebElement> elements = lis_ClientNames.ToList();
                                //  Console.WriteLine(elements.Count);
                                //  Console.WriteLine("elements.Count");
                                for (int i = 0; i < elements.Count; i++)
                                {
                                    //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
                                    //     Console.WriteLine(elements[i].Text.ToLower().Trim());
                                    if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                                    {
                                        // Console.WriteLine(elements[i].Text.ToLower().Trim());
                                        elements[i].Click();
                                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteChargeNobtn);
                                    }
                                }

                            }
                        }

                    }



                }

                //  Console.WriteLine("Test7");




                listExistClients = new List<string>() { Constants.SaviTechnologies, Constants.Sts, Constants.DCR };
                if (listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
                {
                    //public static string ID_Txt_txtChargeNo = "txtChargeNo";  ID_ComboList_addChargeNo
                    // public static string ID_Button_addChargeNobtn ="addChargeNobtn";
                    // public static string ID_Button_deleteChargeNobtn ="deleteChargeNobtn";
                    if (submitToManExtendOfferModel.str_AddListTxt_GLNumbers != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_AddListTxt_GLNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            for (int r = 0; r < words.Length; r++)
                            {
                                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtGLNo, words[r], false);
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addGLNobtn);
                                Thread.Sleep(1000);
                                kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "No");
                            }
                        }
                    }



                    if (submitToManExtendOfferModel.str_DeleteListTxt_GLNumbers != "")
                    {
                        string[] separators1 = { "#" };
                        words = submitToManExtendOfferModel.str_DeleteListTxt_GLNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 1)
                        {
                            for (int r = 0; r < words.Length; r++)
                            {


                                //select[@id='addTimecardApprover']/option
                                ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addGLNo']/option"));

                                List<IWebElement> elements = lis_ClientNames.ToList();
                                //  Console.WriteLine(elements.Count);
                                //  Console.WriteLine("elements.Count");
                                for (int i = 0; i < elements.Count; i++)
                                {
                                    //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
                                    //     Console.WriteLine(elements[i].Text.ToLower().Trim());
                                    if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                                    {
                                        // Console.WriteLine(elements[i].Text.ToLower().Trim());
                                        elements[i].Click();
                                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteGLNobtn);
                                    }
                                }

                            }
                        }

                    }



                }
                //  Console.WriteLine("Test8");
                //      Thread.Sleep(2000);
                objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
                //   Console.WriteLine(str_Btn_ExtendOffer_Submit);
                objCommonMethods.Action_Page_Down_withoutjavascriptexecutor(WDriver);

                if (submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit.ToLower().Trim() == "extend offer")
                {
                    //results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferMethodModel.str_Btn_ExtendOffer_Submit);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit);
                    // results = kwm.select_Button1(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_tab_second, str_Btn_ExtendOffer_Submit);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_class_button, submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }
                }
                else
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Given button name not find " + submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit;
                    return results;
                }

                objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");

                objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
                Thread.Sleep(2000);
                //Yes button click
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit_Confirm);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(3000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit_Confirm);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }

                Thread.Sleep(2000);
                //ok click
                //  Console.WriteLine("str_Btn_OfferToHire_Submit");
                objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit_Confirm_Ok);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit_Confirm_Ok);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(10000);
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Btn_ExtendOffer_Submit_Confirm_Ok);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }
                }

                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = "Extend Offer submit";
                return results;
            

        }


        public Result Call_Requeue_Function(IWebDriver WDriver, string strSubLevel)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();

            string bFilterTxt = "";
            for (int iFTxt = 0; iFTxt < 10; iFTxt++)
            {
                try
                {
                    bFilterTxt = WDriver.FindElement(By.Id("Span1")).GetAttribute("value");
                }
                catch
                {
                    kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, "Requeue", strSubLevel);
                }
                if (bFilterTxt == "Requeue")
                    break;
            }

            Actions actions = new Actions(WDriver);
            actions.SendKeys(Keys.PageDown).Perform();
            int iCount = WDriver.FindElements(By.XPath("//*[@id='workflowContainer']//tr//div[ not(@id='wEnd')]")).Count;

            for (int i = 1; i <= iCount; i++)
            {

                WDriver.FindElement(By.XPath("//*[@id='workflowContainer']//tr[" + i + "]//div[ not(@id='wEnd')]")).Click();

                objCommonMethods.Action_Page_Down(WDriver);
                kwm.click(WDriver, KeyWords.locator_ID, "btnRemove");
            }
            kwm.selectByIndex(WDriver, KeyWords.locator_ID, "reason", 1);
            Thread.Sleep(2000);
            kwm.click(WDriver, KeyWords.locator_ID, "btnSubmit");
            Thread.Sleep(2000);
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Unable to find Requeue Confirm Yes button ";
                    return results;
                }
            }
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "OK");
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
            }

            Thread.Sleep(5000);
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = "Requeue Done";
            return results;
        }


        //public Result WithDrwOffer(IWebDriver WDriver, DataRow ExtendOffer_Data)
        //{
        //    KeyWordMethods kwm = new KeyWordMethods();
        //    CommonMethods objCommonMethods = new CommonMethods();
        //    var results = new Result();
        //    var Result_ScreenShot = new Result();
        //    List<string> listExistClients = new List<string>() { };
        //    CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
        //    SubmitToManExtendOfferModel submitToManExtendOfferModel = createRequirementRepository.GetSubmitToManExtendOfferData(ExtendOffer_Data);
        //    string str_Btn_ExtendOffer_Submit = ExtendOffer_Data["P66"].ToString().Trim();
        //    string str_Btn_ExtendOffer_Submit_Confirm = ExtendOffer_Data["P67"].ToString().Trim();
        //    string str_Btn_ExtendOffer_Submit_Confirm_Ok = ExtendOffer_Data["P68"].ToString().Trim();
        //    string str_Txt_poNumber = ExtendOffer_Data["P69"].ToString().Trim();

        //    // Client selection
        //    listExistClients = new List<string>() { Constants.Discover };
        //    if (listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
        //    {
        //        results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManExtendOfferModel.strClientName);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            Thread.Sleep(5000);
        //            results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManExtendOfferModel.strClientName);
        //            if (results.Result1 == KeyWords.Result_FAIL)
        //            {
        //                Boolean bFlagDropDwon = false;
        //                try
        //                {
        //                    bFlagDropDwon = WDriver.FindElement(By.XPath(KeyWords.XPath_supplierMenu_ClientDropDown)).Enabled;
        //                }
        //                catch
        //                {
        //                    bFlagDropDwon = false;
        //                }
        //                if (bFlagDropDwon)
        //                    return results;
        //            }
        //        }
        //    }
        //    listExistClients = new List<string>() { Constants.Discover };
        //    if (!listExistClients.Contains(submitToManExtendOfferModel.strClientName.ToLower()))
        //    {
        //        results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManExtendOfferModel.strClientName);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            Thread.Sleep(5000);
        //            results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManExtendOfferModel.strClientName);
        //            if (results.Result1 == KeyWords.Result_FAIL)
        //            {
        //                Boolean bFlagDropDwon = false;
        //                try
        //                {
        //                    bFlagDropDwon = WDriver.FindElement(By.XPath(KeyWords.XPath_supplierMenu_ClientDropDown)).Enabled;
        //                }
        //                catch
        //                {
        //                    bFlagDropDwon = false;
        //                }
        //                if (bFlagDropDwon)
        //                    return results;
        //            }
        //        }
        //    }

        //    objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
        //    //Submenu click

        //    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManExtendOfferModel.strMainMenuLink, submitToManExtendOfferModel.strSubMenuLink);
        //    if (results.Result1 == KeyWords.Result_FAIL)
        //    {
        //        Thread.Sleep(5000);
        //        results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitToManExtendOfferModel.strMainMenuLink, submitToManExtendOfferModel.strSubMenuLink);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            //results.ErrorMessage1 = "Unable to click on the Main menu";
        //            return results;
        //        }
        //    }

        //    objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
        //    if (submitToManExtendOfferModel.strSubMenuLink.ToLower().Trim() != "candidate with offers")
        //    {
        //        objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");

        //        try
        //        {
        //            new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.XPath(KeyWords.ID_paginate_regReqList_filter))));
        //        }
        //        catch
        //        {
        //            for (int i = 0; i < 10; i++)
        //            {
        //                try
        //                {
        //                    if (WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).Displayed)
        //                    {
        //                        break;
        //                    }
        //                    Thread.Sleep(100);
        //                }
        //                catch
        //                {
        //                    //
        //                }
        //            }
        //        }

        //    }

        //    //Reuid is passed into text box
        //    try
        //    {
        //        WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).Clear();

        //        WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).SendKeys(submitToManExtendOfferModel.str_Link_ReqNumber);
        //    }
        //    catch
        //    {
        //        try
        //        {
        //            WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).Clear();
        //            WDriver.FindElement(By.XPath(KeyWords.ID_paginate_regReqList_filter)).SendKeys(submitToManExtendOfferModel.str_Link_ReqNumber);
        //        }
        //        catch
        //        {
        //            //
        //        }
        //    }
        //    Thread.Sleep(2000);
        //    //After serach Requirement click
        //    try
        //    {
        //        WDriver.FindElement(By.LinkText(submitToManExtendOfferModel.str_Link_ReqNumber)).Click();
        //    }
        //    catch
        //    {
        //        Thread.Sleep(100);
        //        try
        //        {
        //            WDriver.FindElement(By.LinkText(submitToManExtendOfferModel.str_Link_ReqNumber)).Click();
        //        }
        //        catch
        //        {
        //            // Console.WriteLine(bFlag);
        //            results.Result1 = KeyWords.Result_FAIL;
        //            results.ErrorMessage = "The given Req not find " + submitToManExtendOfferModel.str_Link_ReqNumber;
        //            return results;
        //        }
        //    }


        //    for (int z = 1; z < 500; z++)
        //    {
        //        Boolean strValue = true;
        //        try
        //        {
        //            strValue = WDriver.FindElement(By.Id("loading-message")).Displayed;
        //        }
        //        catch
        //        {
        //            strValue = true;
        //        }


        //        if (!strValue)
        //        {
        //            break;
        //        }
        //        Thread.Sleep(100);
        //    }

        //    // View candidates click
        //    string strSubLevel = "./label";
        //    objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
        //    results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManExtendOfferModel.str_Link_ActionList_ViewCandidates, strSubLevel);
        //    if (results.Result1 == KeyWords.Result_FAIL)
        //    {
        //        Thread.Sleep(15000);
        //        results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManExtendOfferModel.str_Link_ActionList_ViewCandidates, strSubLevel);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            return results;
        //        }
        //    }
        //    //
        //    if (submitToManExtendOfferModel.str_CandidateName.ToLower().Trim() == "")
        //    {
        //        results = kwm.GetNameFromReqNumber("FN", submitToManExtendOfferModel.str_Link_ReqNumber);
        //        // string strCan
        //        string strFN = "";
        //        if (results.Result1 == KeyWords.Result_PASS)
        //        {
        //            strFN = results.ErrorMessage;
        //        }
        //        // results
        //        results = kwm.GetNameFromReqNumber("LN", submitToManExtendOfferModel.str_Link_ReqNumber);
        //        string strLN = "";
        //        if (results.Result1 == KeyWords.Result_PASS)
        //        {
        //            strLN = results.ErrorMessage;
        //        }

        //        submitToManExtendOfferModel.str_CandidateName = strLN + ", " + strFN;
        //    }
        //    //Candidate is passed to text box
        //    objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
        //    try
        //    {
        //        WDriver.FindElement(By.XPath("//*[@id='HistoryTableViewCandidate_filter']/label/input")).SendKeys(submitToManExtendOfferModel.str_CandidateName);
        //    }
        //    catch
        //    {
        //        try
        //        {
        //            WDriver.FindElement(By.XPath("//*[@id='HistoryTableViewCCandidate_filter']/label/input")).SendKeys(submitToManExtendOfferModel.str_CandidateName);
        //        }
        //        catch
        //        {
        //            //
        //        }
        //    }
        //    // Click on candidate name
        //    objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");

        //    try
        //    {
        //        WDriver.FindElement(By.LinkText(submitToManExtendOfferModel.str_CandidateName)).Click();
        //    }
        //    catch
        //    {
        //        Thread.Sleep(100);
        //        try
        //        {
        //            WDriver.FindElement(By.LinkText(submitToManExtendOfferModel.str_CandidateName)).Click();
        //        }
        //        catch
        //        {
        //            // Console.WriteLine(bFlag);
        //            results.Result1 = KeyWords.Result_FAIL;
        //            results.ErrorMessage = "The given canditate name not find " + submitToManExtendOfferModel.str_CandidateName;
        //            return results;
        //        }
        //    }

        //    for (int z = 1; z < 500; z++)
        //    {
        //        Boolean strValue = true;
        //        try
        //        {
        //            strValue = WDriver.FindElement(By.Id("loading-message")).Displayed;
        //        }
        //        catch
        //        {
        //            strValue = true;
        //        }

        //        //  Console.WriteLine("z -----> " + z);
        //        //  Console.WriteLine("strValue -----> " + strValue);
        //        if (!strValue)
        //        {
        //            break;
        //        }
        //        Thread.Sleep(100);
        //    }
        //    //Withdraw offer
        //    strSubLevel = "";
        //    results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManExtendOfferModel.str_Link_Withdrawoffer, strSubLevel);
        //    if (results.Result1 == KeyWords.Result_FAIL)
        //    {
        //        Thread.Sleep(5000);
        //        results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitToManExtendOfferModel.str_Link_Withdrawoffer, strSubLevel);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            return results;
        //        }

        //    }
        //    //WithdrawReason


        //    // results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_withdrawReason, submitToManExtendOfferModel.str_Select_WithdrawofferReason);
        //    results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_withdrawReason);
        //    if (results.Result1 == KeyWords.Result_FAIL)
        //    {
        //        try
        //        {
        //            SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Select_withdrawReason))); //Locating select list
        //            se.SelectByIndex(2);
        //        }
        //        catch
        //        {
        //            //
        //        }
        //    }

        //    //Comment
        //    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Comments, submitToManExtendOfferModel.str_Txt_WithdrawofferReasoncomment, false);
        //    if (results.Result1 == KeyWords.Result_FAIL)
        //    {
        //        //  return results;
        //    }
        //    //Error msgs code
        //    results = kwm.Error_Msg_Read_Submit_Resume_details(WDriver, "//div[@" + KeyWords.locator_ID + "='dialog']/div/div/div/ul/li");
        //    if (results.Result1 == KeyWords.Result_PASS)
        //    {
        //        if (results.ErrorMessage != "")
        //        {
        //            results.Result1 = KeyWords.Result_FAIL;
        //            return results;
        //        }
        //    }
        //    //WithdrawButton Click

        //    if (submitToManExtendOfferModel.str_Button_Withdrawoffer != "")
        //    {
        //        objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
        //        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Button_Withdrawoffer);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            Thread.Sleep(5000);
        //            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Button_Withdrawoffer);
        //            if (results.Result1 == KeyWords.Result_FAIL)
        //            {
        //                Thread.Sleep(10000);
        //                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Button_Withdrawoffer);
        //                if (results.Result1 == KeyWords.Result_FAIL)
        //                {
        //                    return results;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        results.Result1 = KeyWords.Result_FAIL;
        //        results.ErrorMessage = "Accept Offer confirm button name is empty";
        //        return results;
        //    }

        //    //pop up click
        //    objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
        //    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Button_Withdrawoffer_yes);
        //    if (results.Result1 == KeyWords.Result_FAIL)
        //    {
        //        Thread.Sleep(5000);
        //        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Button_Withdrawoffer_yes);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            // return results;
        //        }
        //    }

        //    // Click Ok button
        //    objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManExtendOfferModel.strClientName + "_");
        //    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Button_Withdrawoffer_ok);
        //    if (results.Result1 == KeyWords.Result_FAIL)
        //    {
        //        Thread.Sleep(5000);
        //        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitToManExtendOfferModel.str_Button_Withdrawoffer_ok);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            // return results;
        //        }
        //    }
        //    // ExtendOffer_Method_Full(WDriver, ExtendOffer_Data);
        //    results.Result1 = KeyWords.Result_PASS;
        //    results.ErrorMessage1 = results.ErrorMessage;

        //    return results;

        //}


        public Result OfferToHire_Identified_Candidate(IWebDriver WDriver, DataRow OfferToHire_Data)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            SubmitToManOfferToHireModel submitToManOfferToHireModel = createRequirementRepository.GetSubmitToManOfferToHireData(OfferToHire_Data);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManOfferToHireModel.strClientName + "_");

             listExistClients = new List<string>() { Constants.YP };
             if (listExistClients.Contains(submitToManOfferToHireModel.strClientName.ToLower()))
             {
                 //Rate Level *
                 if (submitToManOfferToHireModel.str_Select_RateLevel_ddRateLevel != "")
                     kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_RateLevel_ddRateLevel, submitToManOfferToHireModel.str_Select_RateLevel_ddRateLevel);

             }

            //PayRate (USD)*
            if (submitToManOfferToHireModel.str_Txt_payrate_ProposepayrateForMarkup != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_payrate_ProposepayrateForMarkup, submitToManOfferToHireModel.str_Txt_payrate_ProposepayrateForMarkup, true);

            //OT Pay Rate(USD)*
            if (submitToManOfferToHireModel.str_Txt_OTpayrate_ProposeotpayrateForMarkup != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_OTpayrate_ProposeotpayrateForMarkup, submitToManOfferToHireModel.str_Txt_OTpayrate_ProposeotpayrateForMarkup, true);

            //Pay Rate Markup *
            if (submitToManOfferToHireModel.str_Txt_payratemarkup_supplierpayratemarkup != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_payratemarkup_supplierpayratemarkup, submitToManOfferToHireModel.str_Txt_payratemarkup_supplierpayratemarkup, true);

            //Bill Rate *
            if (submitToManOfferToHireModel.str_Txt_BillRate_ProposebillrateForMarkup != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_BillRate_ProposebillrateForMarkup, submitToManOfferToHireModel.str_Txt_BillRate_ProposebillrateForMarkup, true);

            //OT Bill Rate
            if (submitToManOfferToHireModel.str_Txt_OTBillRate_ProposeotbillrateForMarkup != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_OTBillRate_ProposeotbillrateForMarkup, submitToManOfferToHireModel.str_Txt_OTBillRate_ProposeotbillrateForMarkup, true);

            //Week Start
            if (submitToManOfferToHireModel.str_Select_dayID != "")
                kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_dayID, submitToManOfferToHireModel.str_Select_dayID);

            //Number of Hours per week NTE

            if (submitToManOfferToHireModel.str_Txt_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_weeklyRegHoursNTE, submitToManOfferToHireModel.str_Txt_weeklyRegHoursNTE, true);

            //Number of OT Hours Per Week NTE
            if (submitToManOfferToHireModel.str_Txt_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_weeklyOTHoursNTE, submitToManOfferToHireModel.str_Txt_weeklyOTHoursNTE, true);

            //Total Hours per Calendar Year NTE
            if (submitToManOfferToHireModel.str_Txt_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_yearlyRegHoursNTE, submitToManOfferToHireModel.str_Txt_yearlyRegHoursNTE, true);

            //Total Contract Value
            if (submitToManOfferToHireModel.str_Txt_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_totalContractValue, submitToManOfferToHireModel.str_Txt_totalContractValue, true);

            //Email With Cointract Usage
            if (submitToManOfferToHireModel.str_RadioButton_Emailwithcontractusage.ToLower().Trim() == "yes")
            {
                try
                {
                    WDriver.FindElement(By.XPath(KeyWords.ID_RadioButton_Yes_rbEmailwithContractusage)).Click();
                }
                catch
                {
                    Console.WriteLine("Click on radio button " + submitToManOfferToHireModel.str_RadioButton_Emailwithcontractusage);
                }
                if (submitToManOfferToHireModel.str_Select_ddemailschedule != "")
                {
                    kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_ddemailschedule, submitToManOfferToHireModel.str_Select_ddemailschedule);
                }
            }
            else
            {
                try
                {
                    WDriver.FindElement(By.XPath(KeyWords.ID_RadioButton_No_rbEmailwithContractusage)).Click();
                }
                catch
                {
                    Console.WriteLine("Click on radio button " + submitToManOfferToHireModel.str_RadioButton_Emailwithcontractusage);
                }
            }

            //Preferred Start Date 
            if (submitToManOfferToHireModel.str_Txt_PrefStartdate != "")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_txtneededStartDate);
                // results = kwm.Select_Start_Date_From_Picker(WDriver, submitToManOfferToHireModel.str_Txt_PrefStartdate);
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_PrefStartdate, submitToManOfferToHireModel.str_Txt_PrefStartdate, false);
            }

            objCommonMethods.Action_Button_Tab(WDriver);
            //EndDate
            if (submitToManOfferToHireModel.str_Txt_enddate != "")
            {
                // results = kwm.Select_End_Date_From_Picker(WDriver, submitToManOfferToHireModel.str_Txt_enddate);
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_txtenddate);
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_enddate, submitToManOfferToHireModel.str_Txt_enddate, false);
            }

            //Timecard Approver 
            if (submitToManOfferToHireModel.str_Typeahead_Account_chargeCostCenterId != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_AddListTxt_txtTimecardApprover, submitToManOfferToHireModel.str_AddListTxt_txtTimecardApprover);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_AddListTxt_txtTimecardApprover, submitToManOfferToHireModel.str_AddListTxt_txtTimecardApprover);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, "1");
                        //returnresults;
                    }
                }
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addTimecardApproverbtn);
            }

            //Charge NUmber Type 
            if (submitToManOfferToHireModel.str_Select_ChargeNumberTypes != "")
            {
                results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_ChargeNumberTypes);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Select_ChargeNumberTypes))); //Locating select list
                    se.SelectByIndex(1);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_ChargeNumberTypes, submitToManOfferToHireModel.str_Select_ChargeNumberTypes);
                    }
                }
            }

            //Charge Number
            if (submitToManOfferToHireModel.str_Typeahead_ChargeNumbers_txtChargeNo != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumbers_txtChargeNo, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_Typeahead_ChargeNumbers_txtChargeNo, submitToManOfferToHireModel.str_Typeahead_ChargeNumbers_txtChargeNo);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumbers_txtChargeNo, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_Typeahead_ChargeNumbers_txtChargeNo, submitToManOfferToHireModel.str_Typeahead_ChargeNumbers_txtChargeNo);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumbers_txtChargeNo, KeyWords.locator_class, KeyWords.CL_list_typeahead, "1");
                        //returnresults;
                    }
                }
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addChargeNobtn);
            }


            // KCPL  Charge Number *------------venky code added
            if (submitToManOfferToHireModel.strClientName.ToLower().ToString() == Constants.KCPL)
            {

                //GL Business Unit * 
                if (submitToManOfferToHireModel.str_select_GLBusinessUnit_chargeGLId != "")
                {
                    kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_GLBusinessUnit_chargeGLId, submitToManOfferToHireModel.str_select_GLBusinessUnit_chargeGLId);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_GLBusinessUnit_chargeGLId, submitToManOfferToHireModel.str_select_GLBusinessUnit_chargeGLId);
                    }
                }

                //Account *
                if (submitToManOfferToHireModel.str_Typeahead_Account_chargeCostCenterId != "")
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_Account_chargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_Typeahead_Account_chargeCostCenterId, submitToManOfferToHireModel.str_Typeahead_Account_chargeCostCenterId);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_Account_chargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_Typeahead_Account_chargeCostCenterId, submitToManOfferToHireModel.str_Typeahead_Account_chargeCostCenterId);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_Account_chargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, "1");
                            //returnresults;
                        }
                    }
                }
                // Operating Unit 
                if (submitToManOfferToHireModel.str_Typeahead_OperatingUnit_chargeProfitCenterId != "")
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_OperatingUnit_chargeProfitCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_Typeahead_OperatingUnit_chargeProfitCenterId, submitToManOfferToHireModel.str_Typeahead_OperatingUnit_chargeProfitCenterId);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_OperatingUnit_chargeProfitCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_Typeahead_OperatingUnit_chargeProfitCenterId, submitToManOfferToHireModel.str_Typeahead_OperatingUnit_chargeProfitCenterId);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_OperatingUnit_chargeProfitCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, "1");
                            //returnresults;
                        }
                    }
                }
                // Department ID 
                if (submitToManOfferToHireModel.str_Typeahead_DepartmentID_chargedeptNumber != "")
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_DepartmentID_chargedeptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_Typeahead_DepartmentID_chargedeptNumber, submitToManOfferToHireModel.str_Typeahead_DepartmentID_chargedeptNumber);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_DepartmentID_chargedeptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_Typeahead_DepartmentID_chargedeptNumber, submitToManOfferToHireModel.str_Typeahead_DepartmentID_chargedeptNumber);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_DepartmentID_chargedeptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, "1");
                            //returnresults;
                        }
                    }
                }
                // Project ID
                if (submitToManOfferToHireModel.str_Typeahead_ProjectID_chargeProjectId != "")
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ProjectID_chargeProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_Typeahead_ProjectID_chargeProjectId, submitToManOfferToHireModel.str_Typeahead_ProjectID_chargeProjectId);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ProjectID_chargeProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_Typeahead_ProjectID_chargeProjectId, submitToManOfferToHireModel.str_Typeahead_ProjectID_chargeProjectId);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ProjectID_chargeProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, "1");
                            //returnresults;
                        }
                    }
                }
                // Work ID 
                if (submitToManOfferToHireModel.str_Typeahead_WorkID_chargeprogramId != "")
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_WorkID_chargeprogramId, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_Typeahead_WorkID_chargeprogramId, submitToManOfferToHireModel.str_Typeahead_WorkID_chargeprogramId);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_WorkID_chargeprogramId, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_Typeahead_WorkID_chargeprogramId, submitToManOfferToHireModel.str_Typeahead_WorkID_chargeprogramId);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_WorkID_chargeprogramId, KeyWords.locator_class, KeyWords.CL_list_typeahead, "1");
                            //returnresults;
                        }
                    }
                }
                //Resource 
                if (submitToManOfferToHireModel.str_select_Resource_chargespendLevelId != "")
                {
                    kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_Resource_chargespendLevelId, submitToManOfferToHireModel.str_select_Resource_chargespendLevelId);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_Resource_chargespendLevelId, submitToManOfferToHireModel.str_select_Resource_chargespendLevelId);
                    }
                }

                //Add charge num plus button
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_button_addchargenumber_addChargeNobtnNew);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_button_addchargenumber_addChargeNobtnNew);
                }
            }






            //end 


            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_button_RatesTab_btnbtnContinueRates);

            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_button_RatesTab_btnbtnContinueRates), kwm._WDWait);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManOfferToHireModel.strClientName + "_");
            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_button_RatesTab_btnbtnContinueRates);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_button_RatesTab_btnbtnContinueRates);
            }

            //Justification Tab
            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitToManOfferToHireModel.strClientName + "_");
            //Last Name
            //Last Name
            if (submitToManOfferToHireModel.str_Txt_LastName_lastname != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_LastName_lastname, submitToManOfferToHireModel.str_Txt_LastName_lastname, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            //First Name
            if (submitToManOfferToHireModel.str_Txt_FirstName_firstname != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_FirstName_firstname, submitToManOfferToHireModel.str_Txt_FirstName_firstname, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            //Middle Name

            if (submitToManOfferToHireModel.str_Txt_MiddleName_middlename != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_MiddleName_middlename, submitToManOfferToHireModel.str_Txt_MiddleName_middlename, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            //Suffix

            if (submitToManOfferToHireModel.str_Select_Suffix_nameSuffix != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Suffix_nameSuffix, submitToManOfferToHireModel.str_Select_Suffix_nameSuffix);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //upload resume

            //Retiree *
            if (submitToManOfferToHireModel.str_Radiobutton_Retiree_retiredEmployee != "")
            {
                if (submitToManOfferToHireModel.str_Radiobutton_Retiree_retiredEmployee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radiobutton_Retiree_retiredEmployeeYes);
                    Thread.Sleep(1000);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_RetireeDetails_retiredEmployeeDetails, submitToManOfferToHireModel.str_Txt_RetireeDetails_retiredEmployeeDetails, false);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radiobutton_Retiree_retiredEmployeeNo);
                }


            }

            //Former US Govt/Military Employee
            if (submitToManOfferToHireModel.str_Radiobuttion_FormerUSGovtMilitaryEmployee_exGovMilEmployee != "")
            {
                if (submitToManOfferToHireModel.str_Radiobuttion_FormerUSGovtMilitaryEmployee_exGovMilEmployee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radiobuttion_FormerUSGovtMilitaryEmployee_exGovMilEmployeeYes);
                    Thread.Sleep(1000);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_FormerUSGovtMilitaryEmployeeDetails_exGovMilEmployeeDetails, submitToManOfferToHireModel.str_Txt_FormerUSGovtMilitaryEmployeeDetails_exGovMilEmployeeDetails, false);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radiobuttion_FormerUSGovtMilitaryEmployee_exGovMilEmployeeNo);
                }


            }

            //Former Employee *
            if (submitToManOfferToHireModel.str_radiobutton_FormerEmployee_exEmployee != "")
            {
                if (submitToManOfferToHireModel.str_radiobutton_FormerEmployee_exEmployee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_exEmployeeYes);
                    Thread.Sleep(1000);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_FormerEmployeeDetails_exEmployeeDetails, submitToManOfferToHireModel.str_Txt_FormerEmployeeDetails_exEmployeeDetails, false);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_exEmployeeNo);
                }


            }



            //Former Intern * 
            if (submitToManOfferToHireModel.str_radiobutton_FormerIntern_exIntern != "")
            {
                if (submitToManOfferToHireModel.str_radiobutton_FormerIntern_exIntern.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerIntern_exInternYes);
                    Thread.Sleep(1000);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_FormerInternDetails_exInternDetails, submitToManOfferToHireModel.str_Txt_FormerInternDetails_exInternDetails, false);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerIntern_exInternNo);
                }


            }
            //Former Contractor *
            if (submitToManOfferToHireModel.str_radiobutton_FormerContractor_exContractor != "")
            {
                if (submitToManOfferToHireModel.str_radiobutton_FormerContractor_exContractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerContractor_exContractorYes);
                    Thread.Sleep(1000);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_FormerContractorDetails_exContractorDetails, submitToManOfferToHireModel.str_Txt_FormerContractorDetails_exContractorDetails, false);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerContractor_exContractorNo);
                }


            }
            //Justification

            if (submitToManOfferToHireModel.str_Txt_Justification_soleJustificationDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Justification_soleJustificationDescription, submitToManOfferToHireModel.str_Txt_Justification_soleJustificationDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            //Upload Justification
            //Supplier *

            if (submitToManOfferToHireModel.str_Typeahead_Supplier_supplierName != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_Supplier_supplierName, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_Typeahead_Supplier_supplierName, submitToManOfferToHireModel.str_Typeahead_Supplier_supplierName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_Supplier_supplierName, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitToManOfferToHireModel.str_Typeahead_Supplier_supplierName, submitToManOfferToHireModel.str_Typeahead_Supplier_supplierName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_Supplier_supplierName, KeyWords.locator_class, KeyWords.CL_list_typeahead, "1");
                        return results;
                    }
                }

            }

            //Contact LastName
            if (submitToManOfferToHireModel.str_Txt_ContactLastName_recruiterLastName != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ContactLastName_recruiterLastName, submitToManOfferToHireModel.str_Txt_ContactLastName_recruiterLastName, false);

            //Contact FirstName
            if (submitToManOfferToHireModel.str_Txt_ContactFirstName_recruiterFirstName != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ContactFirstName_recruiterFirstName, submitToManOfferToHireModel.str_Txt_ContactFirstName_recruiterFirstName, false);

            //Phone
            if (submitToManOfferToHireModel.str_Txt_Phone_workPhone != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Phone_workPhone, submitToManOfferToHireModel.str_Txt_Phone_workPhone, false);

            //Email
            if (submitToManOfferToHireModel.str_Txt_Email_workEmail != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Email_workEmail, submitToManOfferToHireModel.str_Txt_Email_workEmail, false);



            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = "Issue Offer to Hire submit";
            return results;


        }


    }
}

