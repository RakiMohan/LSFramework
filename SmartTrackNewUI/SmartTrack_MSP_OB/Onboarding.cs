
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
using OpenQA.Selenium.Interactions;

using System.Collections;
using SmartTrack.DataAccess.Repository;
using SmartTrack.DataAccess.Models;
using CommonFiles;
using RelevantCodes.ExtentReports;

namespace SmartTrack_Automation
{
    //  [TestClass]
    public class Onboarding
    {
        KeyWordMethods kwm = new KeyWordMethods();
        CommonMethods objCommonMethods = new CommonMethods();
        Result results = new Result();
        Result Result_ScreenShot = new Result();
        ArrayList listExistClients = new ArrayList { };
        public Result Onboarding_Method(IWebDriver WDriver, DataRow Onboarding_Data, int SupExecutionRowNo)
        {
          
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
           
            WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));
            string strClientName = Onboarding_Data["P3"].ToString().Trim();
            string strMainMenuLink = Onboarding_Data["P4"].ToString().Trim();
            string strSubMenuLink = Onboarding_Data["P5"].ToString().Trim();
            string str_Link_ReqNumber = Onboarding_Data["P6"].ToString().Trim();
            string str_Link_CandidatesWithOffers = Onboarding_Data["P7"].ToString().Trim();
            string str_CandidateName = Onboarding_Data["P8"].ToString().Trim();
            string str_Link_Onboarding_Data = Onboarding_Data["P9"].ToString().Trim();

            string str_Txt_TrainingNames = Onboarding_Data["P14"].ToString().Trim();
            string str_Txt_TrainingStatus = Onboarding_Data["P15"].ToString().Trim();
            string str_Txt_TrainingComments = Onboarding_Data["P16"].ToString().Trim();
            string str_Txt_TrainMsgAction = Onboarding_Data["P17"].ToString().Trim();
            string str_Txt_TrainUpdateStatus = Onboarding_Data["P18"].ToString().Trim();
            string str_Txt_TrainStatusUpdate = Onboarding_Data["P19"].ToString().Trim();
            string str_Txt_DocsNames = Onboarding_Data["P20"].ToString().Trim();
            string str_Txt_DocsStatus = Onboarding_Data["P21"].ToString().Trim();
            string str_Txt_DocsComments = Onboarding_Data["P21"].ToString().Trim();

            string str_Txt_DocsMsgAction = Onboarding_Data["P24"].ToString().Trim();
            string str_Txt_DocsUpdateStatus = Onboarding_Data["P25"].ToString().Trim();
            string str_Txt_DocsStatusUpdate = Onboarding_Data["P26"].ToString().Trim();

            string str_Txt_ComplianceNames = Onboarding_Data["P27"].ToString().Trim();
            string str_Txt_ComplianceStatus = Onboarding_Data["P28"].ToString().Trim();
            string str_Txt_ComplianceComments = Onboarding_Data["P29"].ToString().Trim();
            string str_Txt_ComplianceMsgAction = Onboarding_Data["P30"].ToString().Trim();
            string str_Txt_ComplianceUpdateStatus = Onboarding_Data["P31"].ToString().Trim();
            string str_Txt_ComplianceStatusUpdate = Onboarding_Data["P32"].ToString().Trim();

            string str_Btn_Accept_Submit = Onboarding_Data["P38"].ToString().Trim();
            string str_Btn_Onboarding_Data_Submit_Confirm = Onboarding_Data["P39"].ToString().Trim();
            string str_Btn_Onboarding_Data_Submit_Confirm_Ok = Onboarding_Data["P40"].ToString().Trim();
            string str_Btn_Submit = "Submit";
            //Thread.Sleep(5000);
            // Requirements


            results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, strClientName);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, strClientName + "_");
            //SUbmenu 

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, strMainMenuLink, strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, strMainMenuLink, strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, strClientName + "_");

            //Wait for element

            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Search_CWName))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_txt_Search_CWName)).Displayed)
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
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_txt_Search_CWName))));
            wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_txt_Search_CWName))));
            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_Search_CWName, str_CandidateName, false);

            Thread.Sleep(2000);

            wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//a[contains(text(),'" + str_CandidateName + "')]"))));
            wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath("//a[contains(text(),'" + str_CandidateName + "')]"))));

            //Candidate name click
            kwm.click(WDriver, KeyWords.locator_XPath, "//a[contains(text(),'" + str_CandidateName + "')]");

            objCommonMethods.SaveScreenShot_EachPage(WDriver, strClientName + "_");
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Expand_tabsExpandCollapse), kwm._WDWait);
            //Exapnd Button click in top of the page
            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Expand_tabsExpandCollapse);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                WDriver.FindElement(By.XPath("//*[@id='tabsAll']/span[2]")).Click();
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, strClientName + "_");

            //Asset Section

            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[@id='Asset_accord_update']//table");
            Thread.Sleep(1000);


            int Asset = WDriver.FindElement(By.XPath("//*[@id='Asset_accord_update']//table")).FindElements(By.TagName("td")).Count;
            Thread.Sleep(1000);
            if (Asset >= 1)
            {
                int assetrecord = WDriver.FindElement(By.XPath("//*[@id='AssetAccord']/tbody")).FindElements(By.TagName("tr")).Count;
                Thread.Sleep(1000);
                for (int statuscount = 1; statuscount <= assetrecord; statuscount++)
                {

                    String status = WDriver.FindElement(By.XPath("//*[@id='AssetAccord']/tbody/tr[" + statuscount + "]/td[2]")).Text;
                    if (status != "Completed")
                    {
                        for (int assets = 1; assets <= assetrecord; assets++)
                        {
                            try
                            {
                                ////following-sibling :: a[@wtitle='Update Status']
                                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[@id='AssetAccord']//tr[" + assets + "]");
                                Thread.Sleep(5000);
                                //	kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='AssetAccord']//tr[" + assets + "]//following-sibling :: a[@wtitle='Update Status']"), kwm._WDWait);
                                kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='AssetAccord']//tr[" + assets + "]"), kwm._WDWait);
                                Thread.Sleep(5000);
                                WDriver.FindElement(By.XPath("//*[@id='AssetAccord']//tr[" + assets + "]//following-sibling :: a[@wtitle='Update Status']")).Click();
                                //WDriver.FindElement(By.XPath("(//*[@aria-label=': Send ReminderUpdate StatusAsset Delete'][" + assets + "]//a[@wtitle='Update Status']")).Click();
                                Thread.Sleep(2000);
                                kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Select_appStatus), kwm._WDWait);
                                kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_appStatus, "Completed");
                                Thread.Sleep(1000);
                                if (results.Result1 == KeyWords.Result_FAIL)
                                {
                                    kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_appStatus, 1);
                                }

                                Thread.Sleep(2000);

                                kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, str_Btn_Submit);
                                Thread.Sleep(5000);
                                //	kwm.waitForElementToBeVisible(WDriver, By.XPath("//div[@id='dialog_AssetUpdateStatusMSPYesNo']"), kwm._WDWait);
                                kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
                                Thread.Sleep(5000);
                                //kwm.waitForElementToBeVisible(WDriver, By.XPath("//div[@id='dialog_AssetUpdateStatusMSPOk']"), kwm._WDWait);
                                //kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                                // Click on OK button
                                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                                if (results.Result1 == KeyWords.Result_FAIL)
                                {
                                    Thread.Sleep(2000);
                                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "OK");
                                    if (results.Result1 == KeyWords.Result_FAIL)
                                    {
                                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                                        if (results.Result1 == KeyWords.Result_FAIL)
                                        {

                                            return results;
                                        }
                                    }
                                }
                                Thread.Sleep(1000);
                                kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='accordionPin']"), kwm._WDWait);
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_tabsAll);
                                Thread.Sleep(2000);

                            }
                            catch (Exception e)
                            {

                            }
                        }
                    }
                }
            }
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[@id='Train_accord_update']//table");

            //Training code started

            int training = WDriver.FindElement(By.XPath("//*[@id='Train_accord_update']//table")).FindElements(By.TagName("td")).Count;

            if (training >= 1)
            {
                int trainingrecord = WDriver.FindElement(By.XPath("//*[@id='TrainAccord']/tbody")).FindElements(By.TagName("tr")).Count;
                Thread.Sleep(1000);
                for (int statuscount = 1; statuscount <= trainingrecord; statuscount++)
                {
                    String status = WDriver.FindElement(By.XPath("//*[@id='TrainAccord']/tbody/tr[" + statuscount + "]/td[3]")).Text;
                    if (status != "Completed")
                    {

                        for (int trainings = 1; trainings <= trainingrecord; trainings++)
                        {
                            try
                            {
                                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[@id='TrainAccord']//tr[" + trainings + "]//following-sibling :: a[@wtitle='Update Status']");
                                Thread.Sleep(5000);
                                //kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='TrainAccord']//tr[" + trainings + "]//following-sibling :: a[@wtitle='Update Status']"), kwm._WDWait);
                                kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='TrainAccord']//tr[" + trainings + "]"), kwm._WDWait);
                                Thread.Sleep(5000);
                                WDriver.FindElement(By.XPath("//*[@id='TrainAccord']//tr[" + trainings + "]//following-sibling :: a[@wtitle='Update Status']")).Click();
                                kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Select_appStatus), kwm._WDWait);
                                kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_appStatus, 1);
                                Thread.Sleep(2000);
                                kwm.sendText(WDriver, KeyWords.locator_ID, "TxtComments", "Completed", false);
                                //kwm.waitForElementToBeVisible(WDriver, By.XPath("//div[@aria-labelledby='ui-dialog-title-dialog']//button[contains(text(),'Submit')]"), kwm._WDWait);
                                kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, str_Txt_TrainMsgAction);
                                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, str_Txt_TrainUpdateStatus);
                                if (results.Result1 == KeyWords.Result_FAIL)
                                {

                                    kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, str_Txt_TrainUpdateStatus);
                                    Thread.Sleep(5000);
                                }
                                Thread.Sleep(3000);
                                //kwm.waitForElementToBeVisible(WDriver, By.XPath("//div[@id='dialog_TrainingUpdateStatusYesNo']"), kwm._WDWait);
                                kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
                                //kwm.waitForElementToBeVisible(WDriver, By.XPath("//div[@id='dialog_TrainingUpdateStatusOk']"), kwm._WDWait);
                                Thread.Sleep(3000);

                                // click on Ok button

                                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");

                                if (results.Result1 == KeyWords.Result_FAIL)
                                {
                                    Thread.Sleep(2000);
                                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "OK");
                                    if (results.Result1 == KeyWords.Result_FAIL)
                                    {
                                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                                        if (results.Result1 == KeyWords.Result_FAIL)
                                        {

                                            return results;
                                        }
                                    }
                                }

                                kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='accordionPin']"), kwm._WDWait);
                                Thread.Sleep(1000);

                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_tabsAll);

                            }
                            catch (Exception e)
                            {

                            }
                        }

                    }
                }
            }



            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "Document_accord_update//table");
            objCommonMethods.SaveScreenShot_EachPage(WDriver, strClientName + "_");

            //Document code started

            int intDocCount = WDriver.FindElement(By.XPath("//*[@id='Document_accord_update']//table")).FindElements(By.TagName("td")).Count;
            if (intDocCount >= 1)
            {
                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[@id='DocAccord']/tbody/tr/td[3]");
                Thread.Sleep(1000);
                int Docsrecord = WDriver.FindElement(By.XPath("//*[@id='DocAccord']//tbody")).FindElements(By.TagName("tr")).Count;


                /* 
                 * click on mass update if and only if mass update button is diplayed 
                     
                 * otherwise it will goes to else part and for loop will execute
                 
                 */
                if (kwm.isElementDisplayed(WDriver, "Txtmassdocmtbtn"))
                {

                    // check all buttons
                    kwm.click(WDriver, KeyWords.locator_ID, "ckbDocmtCheckAll");

                    // click on Mass buton
                    kwm.click(WDriver, KeyWords.locator_ID, "Txtmassdocmtbtn");


                    wait.Until(ExpectedConditions.ElementIsVisible((By.Id("CmbMassDocStatus"))));
                    wait.Until(ExpectedConditions.ElementToBeClickable((By.Id("CmbMassDocStatus"))));

                    // select complted 
                    results = kwm.select(WDriver, KeyWords.locator_ID, "CmbMassDocStatus", "Completed");

                    // click on Submit
                    kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Submit");

                    // click on Yes button

                    Thread.Sleep(2000);
                    kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");

                    // click on Ok button

                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(2000);
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "OK");
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {

                                return results;
                            }
                        }
                    }


                }

                else
                {
                    for (int statuscount = 1; statuscount <= Docsrecord; statuscount++)
                    {
                        String status = WDriver.FindElement(By.XPath("//*[@id='DocAccord']/tbody/tr[" + statuscount + "]/td[3]")).Text;

                        if (status != "Completed")
                        {

                            for (int Document = 1; Document <= Docsrecord; Document++)
                            {
                                try
                                {


                                    //kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[@id='DocAccord']//tr[" + Document + "]");
                                    Thread.Sleep(2000);
                                    kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='DocAccord']//tr[" + Document + "]//following-sibling :: a[@wtitle='Update Status']"), kwm._WDWait);
                                    // kwm.Action_MoveElement(WDriver,"//*[@id='DocAccord']//tr[" + Document + "]//following-sibling :: a[@wtitle='Update Status']");

                                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[@id='DocAccord']//tr[" + Document + "]//following-sibling :: a[@wtitle='Update Status']");
                                    // WDriver.FindElement(By.XPath("//*[@id='DocAccord']//tr[" + Document + "]//following-sibling :: a[@wtitle='Update Status']")).Click();

                                    kwm.jsClick(WDriver, KeyWords.locator_XPath, "//*[@id='DocAccord']//tr[" + Document + "]//following-sibling :: a[@wtitle='Update Status']");

                                    kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Select_appStatus), kwm._WDWait);
                                    kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_appStatus, "Completed");
                                    Thread.Sleep(2000);
                                    //Template Id
                                    kwm.sendText(WDriver, KeyWords.locator_ID, "TxtTemplateId", "1234", false);
                                    Thread.Sleep(1000);
                                    //Comment
                                    kwm.sendText(WDriver, KeyWords.locator_ID, "TxtComments", "Completed", false);
                                    //kwm.waitForElementToBeVisible(WDriver, By.XPath("//div[@aria-labelledby='ui-dialog-title-dialog']//button[contains(text(),'Submit')]"), kwm._WDWait);
                                    kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, str_Txt_TrainMsgAction);

                                    if (results.Result1 == KeyWords.Result_FAIL)
                                    {

                                        kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, str_Txt_TrainMsgAction);
                                        Thread.Sleep(5000);
                                    }

                                    //kwm.waitForElementToBeVisible(WDriver, By.XPath("//div[@id='dialog_DocUpdateStatusMSPYesNo']"), kwm._WDWait);
                                    Thread.Sleep(5000);
                                    kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
                                    //	kwm.waitForElementToBeVisible(WDriver, By.XPath("//div[@id='dialog_DocUpdateStatusMSPOk']"), kwm._WDWait);
                                    Thread.Sleep(5000);

                                    // click on Ok button

                                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");

                                    if (results.Result1 == KeyWords.Result_FAIL)
                                    {
                                        Thread.Sleep(2000);
                                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "OK");
                                        if (results.Result1 == KeyWords.Result_FAIL)
                                        {
                                            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                                            if (results.Result1 == KeyWords.Result_FAIL)
                                            {

                                                return results;
                                            }
                                        }
                                    }
                                    kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='accordionPin']"), kwm._WDWait);
                                    Thread.Sleep(2000);
                                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_tabsAll);
                                    Thread.Sleep(2000);
                                }
                                catch (Exception e)
                                {

                                }
                            }

                        }
                    }
                }
                Thread.Sleep(2000);
                kwm.Action_LookInto_Element(WDriver,KeyWords.locator_ID, KeyWords.ID_tabsAll);
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_tabsAll);
                Thread.Sleep(2000);
            }


            //Starting of Compliance

            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[@id='Compliance_accord_update']//table");
            int Compliance = WDriver.FindElement(By.XPath("//*[@id='Compliance_accord_update']//table")).FindElements(By.TagName("td")).Count;
            Thread.Sleep(1000);
            if (Compliance >= 1)
            {
                int compliancerecords = WDriver.FindElement(By.XPath("//*[@id='ComplianceAccord']/tbody")).FindElements(By.TagName("tr")).Count;
                for (int statuscount = 1; statuscount <= compliancerecords; statuscount++)
                {
                    String complianceStatus = WDriver.FindElement(By.XPath("//*[@id='ComplianceAccord']/tbody/tr[" + statuscount + "]/td[2]")).Text;
                    if (complianceStatus != "Completed")
                    {

                        for (int compliance = 1; compliance <= compliancerecords; compliance++)
                        {
                            try
                            {


                                ////following-sibling ::a[@wtitle='Compliance Details']
                                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[@id='ComplianceAccord']//tbody//tr[" + compliance + "]");
                                Thread.Sleep(5000);
                                //kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='ComplianceAccord']//tbody//tr[" + compliance + "]//following-sibling ::a[@wtitle='Compliance Details']"), kwm._WDWait);

                                WDriver.FindElement(By.XPath("//*[@id='ComplianceAccord']//tbody//tr[" + compliance + "]//following-sibling ::a[@wtitle='Override Status']")).Click();

                                kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Select_appStatus), kwm._WDWait);
                                //kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_appStatus, "Completed");

                                kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_appStatus, 1);
                                Thread.Sleep(1500);
                                //Comment
                                kwm.sendText(WDriver, KeyWords.locator_ID, "TxtComments", "Completed", false);
                                kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, str_Btn_Submit);
                                Thread.Sleep(5000);
                                //kwm.waitForElementToBeVisible(WDriver, By.XPath("//div[@id='dialog_ComplianceUpdateStatusMSPYesNo']"), kwm._WDWait);
                                kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
                                //kwm.waitForElementToBeVisible(WDriver, By.XPath("//div[@id='dialog_ComplianceUpdateStatusMSPOk']"), kwm._WDWait);
                                Thread.Sleep(5000);
                               
                                // click on Ok button

                                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");

                                if (results.Result1 == KeyWords.Result_FAIL)
                                {
                                    Thread.Sleep(2000);
                                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "OK");
                                    if (results.Result1 == KeyWords.Result_FAIL)
                                    {
                                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                                        if (results.Result1 == KeyWords.Result_FAIL)
                                        {

                                            return results;
                                        }
                                    }
                                }
                                kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='accordionPin']"), kwm._WDWait);
                                Thread.Sleep(2000);
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_tabsAll);
                                Thread.Sleep(2000);
                            }
                            catch (Exception e)
                            {

                            }
                        }
                    }
                }
            }
            //End of Compliance

            objCommonMethods.SaveScreenShot_EachPage(WDriver, strClientName + "_");

            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = "Onboarding completed";
            return results;
        }

        //configuration code call
        public Result OnboardingConfiguration(IWebDriver WDriver, DataRow Onboarding_Data, int SupExecutionRowNo)
        {
          
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
            
            WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));
            OnboardingRepository OnboardingRepository = new OnboardingRepository();
            OnBoardingModel OnBoardingModel = OnboardingRepository.GetOnBoardingModel(Onboarding_Data);
            //AssetConfiguration(WDriver, Onboarding_Data, SupExecutionRowNo);
            //TrainingConfiguration(WDriver, Onboarding_Data, SupExecutionRowNo);
            DocumentConfiguration(WDriver, Onboarding_Data, SupExecutionRowNo);
            ComplianceConfiguration(WDriver, Onboarding_Data, SupExecutionRowNo);

            return results;
        }

        public Result AssetConfiguration(IWebDriver WDriver, DataRow Onboarding_Data, int SupExecutionRowNo)
        {
            
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
           
            WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));
            OnboardingRepository OnboardingRepository = new OnboardingRepository();
            OnBoardingModel OnBoardingModel = OnboardingRepository.GetOnBoardingModel(Onboarding_Data);

            results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, OnBoardingModel.strClientName);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, OnBoardingModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, OnBoardingModel.strClientName + "_");
            //SUbmenu 

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, OnBoardingModel.strMainMenuLink, OnBoardingModel.strAssetLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, OnBoardingModel.strMainMenuLink, OnBoardingModel.strAssetLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, OnBoardingModel.strClientName + "_");

            //Asset configuration code 

            //Assert creation 
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Button_CreateAsset), kwm._WDWait);
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, OnBoardingModel.strAssetCategoryLink, "");
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Button_CreateAsset), kwm._WDWait);
            //Create category button click
            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_CreateAsset);
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Txt_CategoryName), kwm._WDWait);
            //Enter Category Name
            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_CategoryName, OnBoardingModel.strCategoryName, false);
            //Description
            kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Txt_AsserCategorytDesccription, OnBoardingModel.strCategoryDescription, false);

            //submit
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Cancel_yes);
            //yes
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_button_category_yes), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_button_category_yes);
            //ok
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_button_category_yes), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_button_category_yes);

            ReportHandler._getChildTest().Log(LogStatus.Pass, "Asset Category is created Successfully");

            //Asset category code ends here


            //Asset type code
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, OnBoardingModel.strAssertTypelink, "");
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Button_CreateAsset), kwm._WDWait);
            //Create Assert Type button click
            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_CreateAsset);
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Txt_AssetType), kwm._WDWait);
            //Enter Assert Type Name
            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AssetType, OnBoardingModel.strAssertType, false);
            //Select category
            results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_select_AssetCategory);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_select_AssetCategory, 1);
            }

            //Description
            kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Txt_AsserCategorytDesccription, OnBoardingModel.strCategoryDescription, false);

            //submit
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Cancel_yes);
            //yes
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_button_category_yes), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_button_category_yes);
            //ok
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_button_category_yes), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_button_category_yes);
            ReportHandler._getChildTest().Log(LogStatus.Pass, "Asset Type is created Successfully");
            //Asset Type ends here

            //Assets code 

            //Asset type code
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, OnBoardingModel.strActionAssetLink, "");
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Button_CreateAsset), kwm._WDWait);
            //Create Assert Type button click
            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_CreateAsset);
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Txt_AssetName), kwm._WDWait);
            //Asset Name
            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AssetName, OnBoardingModel.strActionAssetName, false);
            //Asset category
            results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_select_AssetCategory);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_select_AssetCategory, 1);
            }
            //Asset Type
            results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_XPath, KeyWords.ID_Select_AssetType);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_AssetType, 1);
            }
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Cancel_yes);
            //submit
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Cancel_yes);
            //yes
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_button_category_yes), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_button_category_yes);
            //ok
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_button_category_yes), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_button_category_yes);

            ReportHandler._getChildTest().Log(LogStatus.Pass, "Asset code is created Successfully");

            //End of Asset configuration code 





            return results;
        }

        public Result TrainingConfiguration(IWebDriver WDriver, DataRow Onboarding_Data, int SupExecutionRowNo)
        {
            
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
           
            WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));
            OnboardingRepository OnboardingRepository = new OnboardingRepository();
            OnBoardingModel OnBoardingModel = OnboardingRepository.GetOnBoardingModel(Onboarding_Data);

            results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, OnBoardingModel.strClientName);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, OnBoardingModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, OnBoardingModel.strClientName + "_");
            //SUbmenu 

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, OnBoardingModel.strMainMenuLink, OnBoardingModel.strOnboardingTraining);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, OnBoardingModel.strMainMenuLink, OnBoardingModel.strOnboardingTraining);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, OnBoardingModel.strClientName + "_");



            //Training  creation 
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Button_Tarining), kwm._WDWait);
            //Tarinign Button click
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_Tarining);
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Txt_TrainingName), kwm._WDWait);
            //Enter Training  Name
            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_TrainingName, OnBoardingModel.strTrainingname, false);
            //Description
            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_TrainingDescription, OnBoardingModel.strTrainingDescription, false);
            //pre submit

            if (OnBoardingModel.strPreSubmit != "")
            {
                if (OnBoardingModel.strPreSubmit.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_PreSubmitYes);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_PreSubmitNo);
                }

            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_PreSubmitNo);
            }

            //Mandatory all cws
            if (OnBoardingModel.strallCWs != "")
            {
                if (OnBoardingModel.strallCWs.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_allCWyes);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_allCWNO);
                }

            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_allCWNO);
            }
            //Mandatory Pre-Start *
            if (OnBoardingModel.strPreStart != "")
            {
                if (OnBoardingModel.strPreStart.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_PreStartyes);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_PreStartno);
                }

            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_PreStartno);
            }
            //Recurring *
            if (OnBoardingModel.strRecurring != "")
            {
                if (OnBoardingModel.strRecurring.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_Recurringyes);

                    //frequency
                    results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_select_RecurringFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_select_RecurringFrequency, 1);
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_Recurringno);
                }

            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_Recurringno);
            }

            //submit
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Cancel_yes);
            //yes
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_Button_Training_Popup_Yes), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Button_Training_Popup_Yes);
            //ok
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_Button_Training_Popup_Ok), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Button_Training_Popup_Ok);


            //End of Asset configuration code 

            return results;
        }

        public Result DocumentConfiguration(IWebDriver WDriver, DataRow Onboarding_Data, int SupExecutionRowNo)
        {
           
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
            
            WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));
            OnboardingRepository OnboardingRepository = new OnboardingRepository();
            OnBoardingModel OnBoardingModel = OnboardingRepository.GetOnBoardingModel(Onboarding_Data);

            results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, OnBoardingModel.strClientName);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, OnBoardingModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, OnBoardingModel.strClientName + "_");
            //Submenu 

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, OnBoardingModel.strMainMenuLink, OnBoardingModel.strOnboardingDocumentlink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, OnBoardingModel.strMainMenuLink, OnBoardingModel.strOnboardingDocumentlink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, OnBoardingModel.strClientName + "_");



            //Document creation 
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_button_CreateDocument), kwm._WDWait);
            //Document Button click
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_button_CreateDocument);
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Txt_Document), kwm._WDWait);
            //Enter Document Name
            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Document, OnBoardingModel.strDocument, false);
            //Document Type
            results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DocumentType);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_DocumentType, 1);
            }
            //Expiry Days
            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ExpiryDays, OnBoardingModel.strExpiryDays, false);
            objCommonMethods.Action_Button_Tab(WDriver);
            //pre submit

            if (OnBoardingModel.strDocPreSubmit != "")
            {
                if (OnBoardingModel.strDocPreSubmit.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.ID_Radio_DocPreSubmitYes);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.ID_Radio_DocPreSubmitNo);
                }

            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.ID_Radio_DocPreSubmitNo);
            }


            //Mandatory Pre-Start *
            if (OnBoardingModel.strDocPreStart != "")
            {
                if (OnBoardingModel.strDocPreStart.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.ID_Radio_DocPreStartYes);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.ID_Radio_DocPreStartNo);
                }

            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.ID_Radio_DocPreStartNo);
            }
            //Admin Override Allowed *
            if (OnBoardingModel.strAdminOverirdeAllowed != "")
            {
                if (OnBoardingModel.strAdminOverirdeAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_AdminOverrideAllowedYes);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_AdminOverrideAllowedNo);
                }

            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_AdminOverrideAllowedNo);
            }
            //Document Upload Required

            if (OnBoardingModel.strDocumentUploadRequired != "")
            {
                if (OnBoardingModel.strDocumentUploadRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_DocumentUploadRequiredYes);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_DocumentUploadRequiredNo);
                }

            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_DocumentUploadRequiredNo);
            }
            //submit
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Cancel_yes);
            //yes
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_Button_Con_Document_PopupYes), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Button_Con_Document_PopupYes);
            //ok
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_Button_Con_Document_PopupOk), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Button_Con_Document_PopupOk);


            //End of Documentation configuration code 

            return results;
        }

        public Result ComplianceConfiguration(IWebDriver WDriver, DataRow Onboarding_Data, int SupExecutionRowNo)
        {
            
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
           
            WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));
            OnboardingRepository OnboardingRepository = new OnboardingRepository();
            OnBoardingModel OnBoardingModel = OnboardingRepository.GetOnBoardingModel(Onboarding_Data);

            results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, OnBoardingModel.strClientName);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, OnBoardingModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, OnBoardingModel.strClientName + "_");
            //Submenu 

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, OnBoardingModel.strMainMenuLink, OnBoardingModel.strOnboardingCompliancelink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, OnBoardingModel.strMainMenuLink, OnBoardingModel.strOnboardingCompliancelink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, OnBoardingModel.strClientName + "_");



            //Compliance creation 
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_button_CreateCompliance), kwm._WDWait);
            //Compliance Button click
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_button_CreateCompliance);
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Txt_Compliance), kwm._WDWait);
            //Enter Compliance Name
            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Compliance, OnBoardingModel.strComplainceName, false);
            //Compliance  Type
            results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ComplianceType);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ComplianceType, 1);
            }
            //Compliance Description
            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ComplianceDescription, OnBoardingModel.strComplainceDescription, false);
            //Step configuartion 

            if (OnBoardingModel.strstepconfigurationname != "")
            {
                //Step Name
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ComplianceStepName, OnBoardingModel.strstepconfigurationname, false);
                //Approved by Msp	
                if (OnBoardingModel.strstepconfigurationbymsp.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_ComplianceStepNameApproveyes);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_ComplianceStepNameApproveNo);
                }

            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_ComplianceStepNameApproveNo);
            }

            //Package Configuration
            if (OnBoardingModel.strpkgconfigurationname != "")
            {
                //Package configuration Name

                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_CompliancePkgName, OnBoardingModel.strpkgconfigurationname, false);

                if (OnBoardingModel.strpkgconfigurationindefinite.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_CompliancePkgNameyes);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_CompliancePkgNameNo);
                }

                //Expiry Days

                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_CompliancePkgExpiryDays, OnBoardingModel.strpkgconfigurationExpirydays, false);

            }


            //Admin Override Allowed *
            if (OnBoardingModel.strComplianceAdminOverirdeAllowed != "")
            {
                if (OnBoardingModel.strComplianceAdminOverirdeAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_AdminOverrideAllowedyes);
                    //Over ride reason
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_AdminOverrideReason, OnBoardingModel.strComplianceAdminOverirdeReasons, false);

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_AdminOverrideAllowed);
                }

            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_AdminOverrideAllowed);
            }
            //pre submit

            if (OnBoardingModel.strCompliancePreSubmit != "")
            {
                if (OnBoardingModel.strCompliancePreSubmit.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_CompliancePresubmityes);

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_CompliancePresubmitNo);
                }

            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_CompliancePresubmitNo);
            }
            //Mandatory Pre start

            if (OnBoardingModel.strCompliancePreStart != "")
            {
                if (OnBoardingModel.strCompliancePreStart.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_CompliancePrestartyes);

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_CompliancePrestartno);
                }

            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_CompliancePrestartno);
            }
            //Document Upload Required

            if (OnBoardingModel.strCompliancetUploadRequired != "")
            {
                if (OnBoardingModel.strCompliancetUploadRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_ComplianceDocuploadRequiredyes);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_ComplianceDocuploadRequiredNo);
                }

            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_ComplianceDocuploadRequiredNo);
            }
            //submit
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Cancel_yes);
            //yes
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_Button_Compliancepopupyes), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Button_Compliancepopupyes);
            //ok
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_Button_Compliancepopupok), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Button_Compliancepopupok);


            //End of Compliance configuration code 

            return results;
        }

        #region Training
        public Result OnBoarding_AddTraining(IWebDriver WDriver, DataRow Onboarding_Data)
        {

            try
            {
                kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 30);
                WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));
                OnboardingRepository repo_OnBoarding = new OnboardingRepository();
                OnBoardingModel obj_OnboardingModel = repo_OnBoarding.GetOnBoardingModel(Onboarding_Data);
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, obj_OnboardingModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, obj_OnboardingModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }

                objCommonMethods.SaveScreenShot_EachPage(WDriver, obj_OnboardingModel.strClientName + "_");
                //Submenu 

                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, obj_OnboardingModel.strMainMenuLink, obj_OnboardingModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, obj_OnboardingModel.strMainMenuLink, obj_OnboardingModel.strSubMenuLink);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }
                objCommonMethods.SaveScreenShot_EachPage(WDriver, obj_OnboardingModel.strClientName + "_");

                //Wait for element

                try
                {
                    new WebDriverWait(WDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Search_CWName))));
                }
                catch
                {
                    for (int i = 0; i < 10; i++)
                    {
                        try
                        {
                            if (WDriver.FindElement(By.Id(KeyWords.ID_txt_Search_CWName)).Displayed)
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
                Thread.Sleep(2000);
                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_txt_Search_CWName))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_txt_Search_CWName))));
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_Search_CWName, obj_OnboardingModel.str_CandidateName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto errormessage;
                Thread.Sleep(2000);

                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//a[contains(text(),'" + obj_OnboardingModel.str_CandidateName + "')]"))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath("//a[contains(text(),'" + obj_OnboardingModel.str_CandidateName + "')]"))));

                //Candidate name click
                results = kwm.click(WDriver, KeyWords.locator_XPath, "//a[contains(text(),'" + obj_OnboardingModel.str_CandidateName + "')]");
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto errormessage;

                objCommonMethods.SaveScreenShot_EachPage(WDriver, obj_OnboardingModel.strClientName + "_");
                kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Link_Onboarding_ActionListMenu_AddTraining), kwm._WDWait);
                //Click on Add Training link
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Link_Onboarding_ActionListMenu_AddTraining);
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto errormessage;

                //Wait for popup to load
                kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Select_AddTrainingPopup_Training_CmbTraining), kwm._WDWait);

                //Select Training from dropdown
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_AddTrainingPopup_Training_CmbTraining, obj_OnboardingModel.str_Select_AddTrainingPopup_Training_CmbTraining);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_AddTrainingPopup_Training_CmbTraining, 1);
                    if (results.Result1 == KeyWords.Result_FAIL)
                        goto errormessage;
                    else
                        obj_OnboardingModel.str_Select_AddTrainingPopup_Training_CmbTraining = results._Var;
                }

                //CLick on Submit
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_AddTrainingPopup_Submit);
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto errormessage;

                if (!kwm.isElementDisplayedXpath(WDriver, KeyWords.XPATH_AlertMsg_Popup))
                {
                    //Wait for Yes
                    kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_AddTrainingPopup_Yes), kwm._WDWait);
                    //CLick on Yes
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_AddTrainingPopup_Yes);
                    if (results.Result1 == KeyWords.Result_FAIL)
                        goto errormessage;
                    //Wait for Ok
                    kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_AddTrainingPopup_Ok), kwm._WDWait);
                    //CLick on Ok
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_AddTrainingPopup_Ok);
                    if (results.Result1 == KeyWords.Result_FAIL)
                        goto errormessage;
                }
                else
                {
                    ReportHandler._getChildTest().Log(LogStatus.Fail, "Showing error message : " + kwm.GetText_Xpath(WDriver, "//div[@role='alert' and not(contains(@style,'display: none'))]//li")._Var);
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_AddTrainingPopup_Close);
                    if (results.Result1 == KeyWords.Result_FAIL)
                        goto errormessage;
                }
                kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Expand_tabsExpandCollapse), kwm._WDWait);

                //click on Expand all
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Expand_tabsExpandCollapse);
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto errormessage;
                if (kwm.isElementDisplayed(WDriver, "TrainAccord"))
                {
                    String sStatus = kwm.GetText_Xpath(WDriver, KeyWords.XPATH_Btn_TrainingAccordin_Status(obj_OnboardingModel.str_Select_AddTrainingPopup_Training_CmbTraining))._Var;

                    if (!sStatus.ToLower().Equals("completed"))
                    {
                        //SendReminder for the added training
                        results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_TrainingAccordin_SendReminder(obj_OnboardingModel.str_Select_AddTrainingPopup_Training_CmbTraining));
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;

                        //Wait for Reminder popup
                        kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_SendReminderPopup_Yes), kwm._WDWait);

                        //Click on Yes on Reminder popup
                        results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_SendReminderPopup_Yes);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;

                        //Wait for Ok button popup
                        kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_SendReminderPopup_Ok), kwm._WDWait);

                        //Click on Yes on Reminder popup
                        results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_SendReminderPopup_Ok);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;

                        //Click on status symbol
                        results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_TrainingAccordin_UpdateStatus(obj_OnboardingModel.str_Select_AddTrainingPopup_Training_CmbTraining));
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;

                        //Wait for Update status popup
                        kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Select_UpdateStatusPopup_Status_appStatus), kwm._WDWait);
                        //Select from Status dropdown
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_UpdateStatusPopup_Status_appStatus, obj_OnboardingModel.str_Select_UpdateStatusPopup_Status_appStatus);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_UpdateStatusPopup_Status_appStatus, 1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;

                        //Enter Comments
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_UpdateStatusPopup_Commnets_TxtComments, obj_OnboardingModel.str_Txt_UpdateStatusPopup_Commnets_TxtComments, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;

                        //Click on Submit
                        results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_UpdateStatusPopup_Submit);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;
                        //Wait for Yes on onboarding popup
                        kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_Training_UpdateStatusPopup_Yes), kwm._WDWait);

                        //Click on Yes
                        results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_Training_UpdateStatusPopup_Yes);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;

                        //Wait for OK
                        kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_Training_UpdateStatusPopup_Ok), kwm._WDWait);

                        //Click on Ok
                        results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_Training_UpdateStatusPopup_Ok);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;
                        kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Expand_tabsExpandCollapse), kwm._WDWait);
                        //click on expand all button
                        if (kwm.isElementDisplayedXpath(WDriver, KeyWords.XPATH_Btn_ExpandCollapse))
                        {
                            //click on Expand all
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Expand_tabsExpandCollapse);
                            if (results.Result1 == KeyWords.Result_FAIL)
                                goto errormessage;
                        }
                        //update the status
                        ReportHandler._getChildTest().Log(ReportHandler._getChildTest().GetCurrentStatus(), "Updated the status to -" + kwm.GetText_Xpath(WDriver, KeyWords.XPATH_Btn_TrainingAccordin_Status(obj_OnboardingModel.str_Select_AddTrainingPopup_Training_CmbTraining))._Var);
                    }
                    else
                    {
                        //Get the status
                        ReportHandler._getChildTest().Log(LogStatus.Info, "Status to -" + sStatus);
                    }
                    results._Var = obj_OnboardingModel.str_Select_AddTrainingPopup_Training_CmbTraining;
                }
                else
                {
                    ReportHandler._getChildTest().Log(LogStatus.Fail, "No Training details are found");
                }
            errormessage:
                if (results.Result1 == KeyWords.Result_FAIL)
                    ReportHandler._getChildTest().Log(LogStatus.Fail, "Error Message :" + results.ErrorMessage);
            }
            catch (Exception e)
            {
                ReportHandler._getChildTest().Log(LogStatus.Error, e.Message);
            }
            return results;
        }

        public Result OnBoarding_DeleteTraining(IWebDriver WDriver, DataRow Onboarding_Data)
        {
            try
            {
                results = OnBoarding_AddTraining(WDriver, Onboarding_Data);
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto ErrorMessage;
                else
                {
                    //Delete Training
                    results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_TrainingAccordin_Delete(results._Var));
                    if (results.Result1 == KeyWords.Result_FAIL)
                        goto ErrorMessage;
                    //Wait for delete Training popup
                    kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_DeleteTrainingPopup_Yes), kwm._WDWait);
                    //click on Yes
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_DeleteTrainingPopup_Yes);
                    if (results.Result1 == KeyWords.Result_FAIL)
                        goto ErrorMessage;
                    //Wait for Ok on Training popup
                    kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_DeleteTrainingPopup_Ok), kwm._WDWait);
                    //click on Yes
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_DeleteTrainingPopup_Ok);
                    if (results.Result1 == KeyWords.Result_FAIL)
                        goto ErrorMessage;
                }

            ErrorMessage:
                if (results.Result1 == KeyWords.Result_FAIL)
                    ReportHandler._getChildTest().Log(LogStatus.Fail, "Error Message :" + results.ErrorMessage);

            }
            catch (Exception e)
            {
                ReportHandler._getChildTest().Log(LogStatus.Error, e.Message);
            }

            return results;
        }
        #endregion

        #region Asset
        public Result OnBoarding_AddAsset(IWebDriver WDriver, DataRow Onboarding_Data)
        {
            try
            {
                kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 30);
                WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));
                OnboardingRepository repo_OnBoarding = new OnboardingRepository();
                OnBoardingModel obj_OnboardingModel = repo_OnBoarding.GetOnBoardingModel(Onboarding_Data);
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, obj_OnboardingModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, obj_OnboardingModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }

                objCommonMethods.SaveScreenShot_EachPage(WDriver, obj_OnboardingModel.strClientName + "_");
                //Submenu 

                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, obj_OnboardingModel.strMainMenuLink, obj_OnboardingModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, obj_OnboardingModel.strMainMenuLink, obj_OnboardingModel.strSubMenuLink);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }
                objCommonMethods.SaveScreenShot_EachPage(WDriver, obj_OnboardingModel.strClientName + "_");

                //Wait for element

                try
                {
                    new WebDriverWait(WDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Search_CWName))));
                }
                catch
                {
                    for (int i = 0; i < 10; i++)
                    {
                        try
                        {
                            if (WDriver.FindElement(By.Id(KeyWords.ID_txt_Search_CWName)).Displayed)
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
                Thread.Sleep(2000);
                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_txt_Search_CWName))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_txt_Search_CWName))));
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_Search_CWName, obj_OnboardingModel.str_CandidateName, false);

                Thread.Sleep(2000);

                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//a[contains(text(),'" + obj_OnboardingModel.str_CandidateName + "')]"))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath("//a[contains(text(),'" + obj_OnboardingModel.str_CandidateName + "')]"))));

                //Candidate name click
                results = kwm.click(WDriver, KeyWords.locator_XPath, "//a[contains(text(),'" + obj_OnboardingModel.str_CandidateName + "')]");
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto errormessage;
                objCommonMethods.SaveScreenShot_EachPage(WDriver, obj_OnboardingModel.strClientName + "_");
                kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Link_Onboarding_ActionListMenu_AddAsset), kwm._WDWait);
                //Click on Add Asset link
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Link_Onboarding_ActionListMenu_AddAsset);
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto errormessage;
                //Wait for popup to load
                kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Select_AddAssetPopup_AssetCategory_CmbAssetCategory), kwm._WDWait);

                //Select Asset Category from dropdown
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_AddAssetPopup_AssetCategory_CmbAssetCategory, obj_OnboardingModel.str_ID_Select_AddAssetPopup_AssetCategory_CmbAssetCategory);
                if (results.Result1 == KeyWords.Result_FAIL)
                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_AddAssetPopup_AssetCategory_CmbAssetCategory, 1);
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto errormessage;
                //Select Asset Type from dropdown
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_AddAssetPopup_AssetType_CmbAssetType, obj_OnboardingModel.str_ID_Select_AddAssetPopup_AssetType_CmbAssetType);
                if (results.Result1 == KeyWords.Result_FAIL)
                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_AddAssetPopup_AssetType_CmbAssetType, 1);
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto errormessage;
                //Select Asset from dropdown
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_AddAssetPopup_Asset_CmdAsset, obj_OnboardingModel.str_ID_Select_AddAssetPopup_Asset_CmdAsset);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_AddAssetPopup_Asset_CmdAsset, 1);
                    if (results.Result1 == KeyWords.Result_FAIL)
                        goto errormessage;
                    else
                        obj_OnboardingModel.str_ID_Select_AddAssetPopup_Asset_CmdAsset = results._Var;
                }
                //Comments
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AddAssetPopup_Comment_TxtAssetcomment, obj_OnboardingModel.str_ID_Txt_AddAssetPopup_Comment_TxtAssetcomment, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto errormessage;
                //CLick on Submit
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_AddAssetPopup_Submit);
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto errormessage;
                //Wait for Yes
                kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_AddAssetPopup_Yes), kwm._WDWait);
                //CLick on Yes
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_AddAssetPopup_Yes);
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto errormessage;
                if (!kwm.isElementDisplayedXpath(WDriver, KeyWords.XPATH_AlertMsg_Popup))
                {
                    //Wait for Ok
                    kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_AddAssetPopup_Ok), kwm._WDWait);
                    //CLick on Ok
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_AddAssetPopup_Ok);
                    if (results.Result1 == KeyWords.Result_FAIL)
                        goto errormessage;
                }
                else
                {
                    ReportHandler._getChildTest().Log(LogStatus.Fail, "Showing error message : " + kwm.GetText_Xpath(WDriver, "//div[@role='alert' and not(contains(@style,'display: none'))]//p")._Var);
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_AddAssetPopup_Close);
                    if (results.Result1 == KeyWords.Result_FAIL)
                        goto errormessage;
                }

                kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Expand_tabsExpandCollapse), kwm._WDWait);

                //click on Expand all
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Expand_tabsExpandCollapse);
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto errormessage;

                if (kwm.isElementDisplayed(WDriver, "AssetAccord"))
                {
                    String sStatus = kwm.GetText_Xpath(WDriver, KeyWords.XPATH_Btn_AssetAccordin_Status(obj_OnboardingModel.str_ID_Select_AddAssetPopup_Asset_CmdAsset))._Var;

                    if (!sStatus.ToLower().Equals("completed"))
                    {
                        //SendReminder for the added asset
                        results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_AssetAccordin_SendReminder(obj_OnboardingModel.str_ID_Select_AddAssetPopup_Asset_CmdAsset));
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;
                        //Wait for Reminder popup
                        kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_SendReminderPopup_Yes), kwm._WDWait);

                        //Click on Yes on Reminder popup
                        results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_SendReminderPopup_Yes);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;

                        //Wait for Ok button popup
                        kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_SendReminderPopup_Ok), kwm._WDWait);

                        //Click on Yes on Reminder popup
                        results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_SendReminderPopup_Ok);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;

                        //Click on status symbol
                        results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_AssetAccordin_UpdateStatus(obj_OnboardingModel.str_ID_Select_AddAssetPopup_Asset_CmdAsset));
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;

                        //Wait for Update status popup
                        kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Select_UpdateStatusPopup_Status_appStatus), kwm._WDWait);
                        //Select from Status dropdown
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_UpdateStatusPopup_Status_appStatus, obj_OnboardingModel.str_Select_UpdateStatusPopup_Status_appStatus);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_UpdateStatusPopup_Status_appStatus, 1);
                        //Enter Comments
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_UpdateStatusPopup_Commnets_TxtComments, obj_OnboardingModel.str_Txt_UpdateStatusPopup_Commnets_TxtComments, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;
                        //Click on Submit
                        results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_UpdateStatusPopup_Submit);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;
                        //Wait for Yes on onboarding popup
                        kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_Asset_UpdateStatusPopup_Yes), kwm._WDWait);

                        //Click on Yes
                        results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_Asset_UpdateStatusPopup_Yes);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;
                        //Wait for OK
                        kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_Asset_UpdateStatusPopup_Ok), kwm._WDWait);

                        //Click on Ok
                        results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_Asset_UpdateStatusPopup_Ok);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;
                        kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Expand_tabsExpandCollapse), kwm._WDWait);
                        //click on expand all button
                        if (kwm.isElementDisplayedXpath(WDriver, KeyWords.XPATH_Btn_ExpandCollapse))
                        {
                            //click on Expand all
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Expand_tabsExpandCollapse);
                            if (results.Result1 == KeyWords.Result_FAIL)
                                goto errormessage;
                        }


                        //update the status
                        ReportHandler._getChildTest().Log(ReportHandler._getChildTest().GetCurrentStatus(), "Updated the status to -" + kwm.GetText_Xpath(WDriver, KeyWords.XPATH_Btn_AssetAccordin_Status(obj_OnboardingModel.str_ID_Select_AddAssetPopup_Asset_CmdAsset))._Var);


                    }
                    else
                    {
                        //Get the status
                        ReportHandler._getChildTest().Log(LogStatus.Info, "Status to -" + sStatus);
                    }
                    results._Var = obj_OnboardingModel.str_ID_Select_AddAssetPopup_Asset_CmdAsset;
                }
                else
                {
                    ReportHandler._getChildTest().Log(LogStatus.Fail, "No Asset details are found");
                }
            errormessage:
                if (results.Result1 == KeyWords.Result_FAIL)
                    ReportHandler._getChildTest().Log(LogStatus.Fail, "Error Message :" + results.ErrorMessage);
            }
            catch (Exception e)
            {
                ReportHandler._getChildTest().Log(LogStatus.Error, e.Message);
            }
            return results;
        }

        public Result OnBoarding_DeleteAsset(IWebDriver WDriver, DataRow Onboarding_Data)
        {
            try
            {
                results = OnBoarding_AddAsset(WDriver, Onboarding_Data);
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto ErrorMessage;
                else
                {
                    //Delete Asset
                    results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_AssetAccordin_Delete(results._Var));
                    if (results.Result1 == KeyWords.Result_FAIL)
                        goto ErrorMessage;
                    //Wait for delete asset popup
                    kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_DeleteAssetPopup_Yes), kwm._WDWait);
                    //click on Yes
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_DeleteAssetPopup_Yes);
                    if (results.Result1 == KeyWords.Result_FAIL)
                        goto ErrorMessage;
                    //Wait for Ok on asset popup
                    kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_DeleteAssetPopup_Ok), kwm._WDWait);
                    //click on Yes
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_DeleteAssetPopup_Ok);
                    if (results.Result1 == KeyWords.Result_FAIL)
                        goto ErrorMessage;
                }

            ErrorMessage:
                if (results.Result1 == KeyWords.Result_FAIL)
                    ReportHandler._getChildTest().Log(LogStatus.Fail, "Error Message :" + results.ErrorMessage);

            }
            catch (Exception e)
            {
                ReportHandler._getChildTest().Log(LogStatus.Error, e.Message);
            }

            return results;
        }
        #endregion

        #region Document
        public Result OnBoarding_AddDocument(IWebDriver WDriver, DataRow Onboarding_Data)
        {

            try
            {
                kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 30);
                WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));
                OnboardingRepository repo_OnBoarding = new OnboardingRepository();
                OnBoardingModel obj_OnboardingModel = repo_OnBoarding.GetOnBoardingModel(Onboarding_Data);
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, obj_OnboardingModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, obj_OnboardingModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }

                objCommonMethods.SaveScreenShot_EachPage(WDriver, obj_OnboardingModel.strClientName + "_");
                //Submenu 

                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, obj_OnboardingModel.strMainMenuLink, obj_OnboardingModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, obj_OnboardingModel.strMainMenuLink, obj_OnboardingModel.strSubMenuLink);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }
                objCommonMethods.SaveScreenShot_EachPage(WDriver, obj_OnboardingModel.strClientName + "_");

                //Wait for element

                try
                {
                    new WebDriverWait(WDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Search_CWName))));
                }
                catch
                {
                    for (int i = 0; i < 10; i++)
                    {
                        try
                        {
                            if (WDriver.FindElement(By.Id(KeyWords.ID_txt_Search_CWName)).Displayed)
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
                Thread.Sleep(2000);
                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_txt_Search_CWName))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_txt_Search_CWName))));
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_Search_CWName, obj_OnboardingModel.str_CandidateName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto errormessage;
                Thread.Sleep(2000);

                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//a[contains(text(),'" + obj_OnboardingModel.str_CandidateName + "')]"))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath("//a[contains(text(),'" + obj_OnboardingModel.str_CandidateName + "')]"))));

                //Candidate name click
                results = kwm.click(WDriver, KeyWords.locator_XPath, "//a[contains(text(),'" + obj_OnboardingModel.str_CandidateName + "')]");
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto errormessage;

                objCommonMethods.SaveScreenShot_EachPage(WDriver, obj_OnboardingModel.strClientName + "_");
                kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Link_Onboarding_ActionListMenu_AddDocument), kwm._WDWait);
                //Click on Add Document link
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Link_Onboarding_ActionListMenu_AddDocument);
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto errormessage;

                //Wait for popup to load
                kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Select_AddDocumentPopup_Document_Cmbdocument), kwm._WDWait);

                //Select Document Name from dropdown
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_AddDocumentPopup_Document_Cmbdocument, obj_OnboardingModel.str_ID_Select_AddDocumentPopup_Document_Cmbdocument);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_AddDocumentPopup_Document_Cmbdocument, 1);
                    if (results.Result1 == KeyWords.Result_FAIL)
                        goto errormessage;
                    obj_OnboardingModel.str_ID_Select_AddDocumentPopup_Document_Cmbdocument = results._Var.Trim();
                }
                WDriver.FindElement(By.Name("upload")).SendKeys(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + obj_OnboardingModel.str_Txt_Document_UploadFilePath);
                //CLick on Submit
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_AddDocumentPopup_Submit);
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto errormessage;

                if (!kwm.isElementDisplayedXpath(WDriver, KeyWords.XPATH_AlertMsg_Popup))
                {
                    //Wait for Yes
                    kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_AddDocumentPopup_Yes), kwm._WDWait);
                    //CLick on Yes
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_AddDocumentPopup_Yes);
                    if (results.Result1 == KeyWords.Result_FAIL)
                        goto errormessage;
                    //Wait for Ok
                    kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_AddDocumentPopup_Ok), kwm._WDWait);
                    //CLick on Ok
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_AddDocumentPopup_Ok);
                    if (results.Result1 == KeyWords.Result_FAIL)
                        goto errormessage;
                }
                else
                {
                    ReportHandler._getChildTest().Log(LogStatus.Fail, "Showing error message : " + kwm.GetText_Xpath(WDriver, "//div[@role='alert' and not(contains(@style,'display: none'))]//li")._Var);
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_AddDocumentPopup_Close);
                    if (results.Result1 == KeyWords.Result_FAIL)
                        goto errormessage;
                }

                kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Expand_tabsExpandCollapse), kwm._WDWait);
                //click on Expand all
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Expand_tabsExpandCollapse);
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto errormessage;
                if (kwm.isElementDisplayed(WDriver, "DocAccord"))
                {
                    String sStatus = kwm.GetText_Xpath(WDriver, KeyWords.XPATH_Btn_DocumentAccordin_Status(obj_OnboardingModel.str_ID_Select_AddDocumentPopup_Document_Cmbdocument))._Var;

                    if (!sStatus.ToLower().Equals("completed"))
                    {
                        //SendReminder for the added Document
                        results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_DocumentAccordin_SendReminder(obj_OnboardingModel.str_ID_Select_AddDocumentPopup_Document_Cmbdocument));
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;

                        //Wait for Reminder popup
                        kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_SendReminderPopup_Yes), kwm._WDWait);

                        //Click on Yes on Reminder popup
                        results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_SendReminderPopup_Yes);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;

                        //Wait for Ok button popup
                        kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_SendReminderPopup_Ok), kwm._WDWait);

                        //Click on Yes on Reminder popup
                        results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_SendReminderPopup_Ok);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;
                        kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Expand_tabsExpandCollapse), kwm._WDWait);
                        //click on expand all button
                        if (kwm.isElementDisplayedXpath(WDriver, KeyWords.XPATH_Btn_ExpandCollapse))
                        {
                            //click on Expand all
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Expand_tabsExpandCollapse);
                            if (results.Result1 == KeyWords.Result_FAIL)
                                goto errormessage;
                        }
                        //Click on Extend Expiration Days symbol
                        results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_DocumentAccordin_ExtendExpiryDays(obj_OnboardingModel.str_ID_Select_AddDocumentPopup_Document_Cmbdocument));
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;
                        //Wait for Update status popup
                        kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Txt_ExtendExpiryDaysPopup_ExtendExpirationDays_expiryDays), kwm._WDWait);
                        //Enter Expiration Days
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ExtendExpiryDaysPopup_ExtendExpirationDays_expiryDays, obj_OnboardingModel.str_ID_Txt_ExtendExpiryDaysPopup_ExtendExpirationDays_expiryDays, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;
                        //Click on Extend
                        results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_ExtendExpiryDaysPopup_Extend);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;
                        //Wait For Yes
                        kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_ExtendExpiryDaysPopup_Yes), kwm._WDWait);
                        //Click on Yes
                        results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_ExtendExpiryDaysPopup_Yes);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;
                        //Wait for Ok
                        kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_ExtendExpiryDaysPopup_Ok), kwm._WDWait);
                        //Click on Ok
                        results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_ExtendExpiryDaysPopup_Ok);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;

                        kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Expand_tabsExpandCollapse), kwm._WDWait);
                        try
                        {
                            //click on expand all button
                            if (WDriver.FindElement(By.XPath(KeyWords.XPATH_Btn_ExpandCollapse)).Displayed)
                            {
                                //click on Expand all
                                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Expand_tabsExpandCollapse);
                                if (results.Result1 == KeyWords.Result_FAIL)
                                    goto errormessage;
                            }
                        }
                        catch (Exception e)
                        {
                            //update the status
                            ReportHandler._getChildTest().Log(ReportHandler._getChildTest().GetCurrentStatus(), "Tabs Expand/Collapse : " + kwm.GetText_Xpath(WDriver, "//span[@id='tabsExpandCollapse']")._Var);
                        }

                        //update the status
                        ReportHandler._getChildTest().Log(ReportHandler._getChildTest().GetCurrentStatus(), "Extended Expiry Date -" + kwm.GetText_Xpath(WDriver, KeyWords.XPATH_Lbl_DocumentAccordin_ExpiryDate(obj_OnboardingModel.str_ID_Select_AddDocumentPopup_Document_Cmbdocument))._Var);

                        //wait for status icon
                        //kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_DocumentAccordin_UpdateStatus(obj_OnboardingModel.str_ID_Select_AddDocumentPopup_Document_Cmbdocument)), kwm._WDWait);
                        //Click on status symbol
                        results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_DocumentAccordin_UpdateStatus(obj_OnboardingModel.str_ID_Select_AddDocumentPopup_Document_Cmbdocument));
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;

                        //Wait for Update status popup
                        kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Select_UpdateStatusPopup_Status_appStatus), kwm._WDWait);
                        //Select from Status dropdown
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_UpdateStatusPopup_Status_appStatus, obj_OnboardingModel.str_Select_UpdateStatusPopup_Status_appStatus);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_UpdateStatusPopup_Status_appStatus, 1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;

                        //Enter Comments
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_UpdateStatusPopup_Commnets_TxtComments, obj_OnboardingModel.str_Txt_UpdateStatusPopup_Commnets_TxtComments, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;

                        //Click on Submit
                        results = kwm.jsCommand_Click(WDriver, KeyWords.JS_Popup_Submit);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;
                        //Wait for Yes on onboarding popup
                        kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_Document_UpdateStatusPopup_Yes), kwm._WDWait);

                        //Click on Yes
                        results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_Document_UpdateStatusPopup_Yes);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;

                        //Wait for OK
                        kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_Document_UpdateStatusPopup_Ok), kwm._WDWait);

                        //Click on Ok
                        results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_Document_UpdateStatusPopup_Ok);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;

                        kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Expand_tabsExpandCollapse), kwm._WDWait);
                        //click on expand all button
                        if (kwm.isElementDisplayedXpath(WDriver, KeyWords.XPATH_Btn_ExpandCollapse))
                        {
                            //click on Expand all
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Expand_tabsExpandCollapse);
                            if (results.Result1 == KeyWords.Result_FAIL)
                                goto errormessage;
                        }

                        kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, "DocAccord");
                        //update the status
                        ReportHandler._getChildTest().Log(ReportHandler._getChildTest().GetCurrentStatus(), "Updated the status to -" + kwm.GetText_Xpath(WDriver, KeyWords.XPATH_Btn_DocumentAccordin_Status(obj_OnboardingModel.str_ID_Select_AddDocumentPopup_Document_Cmbdocument))._Var);

                        //click on Resubmit document
                        results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_DocumentAccordin_Resubmit(obj_OnboardingModel.str_ID_Select_AddDocumentPopup_Document_Cmbdocument));
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;
                        //Wait for popup to load
                        kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Txt_ResubmitDocPopup_Comments_txtResubmitComment), kwm._WDWait);
                        //Upload document
                        if (obj_OnboardingModel.str_Txt_Document_UploadFilePath != "")
                        {

                            if (File.Exists(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + obj_OnboardingModel.str_Txt_Document_UploadFilePath))
                            {

                                if (kwm.isElementPresent(WDriver, KeyWords.ID_Btn_ResubmitDocPopup_UploadDoucment_uploaddocfile))
                                {
                                    string spath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + obj_OnboardingModel.str_Txt_Document_UploadFilePath;
                                    ////   kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Link_btnresumeupload);
                                    //// Thread.Sleep(30);
                                    ////WDriver.FindElement(By.Name(KeyWords.NAME_Link_qqfile)).Click();
                                    ////   kwm.click(driver, KeyWords.NAME_icon_UploadResume_qqfile, KeyWords.ID_Link_btnresumeupload);
                                    //// driver.FindElement(By.Id(KeyWords.ID_Link_btnresumeupload)).
                                    //kwm.click(WDriver, KeyWords.NAME_uploadresume, KeyWords.ID_Link_btnresumeupload);
                                    //WDriver.FindElement(By.Id("txtUploadFile")).SendKeys(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + obj_OnboardingModel.str_Txt_Document_UploadFilePath);
                                    //Thread.Sleep(1000);

                                    ////  Actions action = new Actions(driver);
                                    ////   action.SendKeys(OpenQA.Selenium.Keys.Escape);
                                    ////  action.SendKeys(System.Windows.Forms.Keys.Escape);
                                    //System.Windows.Forms.SendKeys.SendWait("{ESC}");
                                    //Thread.Sleep(1000);
                                    kwm.click(WDriver, KeyWords.locator_ID, "uploaddocfile");
                                    System.Windows.Forms.SendKeys.SendWait(spath);
                                    System.Windows.Forms.SendKeys.SendWait("{Enter}");

                                    //System.Windows.Forms.SendKeys.SendWait(@"C:\SMARTTrack-MAIN-Automation-cwcreation\Scenarios\SmartTrackNewUI\SmartTrack\Input\Resumes\SampleResume.txt");
                                    //System.Windows.Forms.SendKeys.SendWait(@"{Enter}");
                                    //string spath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + obj_OnboardingModel.str_Txt_Document_UploadFilePath;

                                }

                            }
                            else
                            {
                                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "The given resume path not find" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + obj_OnboardingModel.str_Txt_Document_UploadFilePath, 3);
                            }

                        }
                        //Enter comments
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ResubmitDocPopup_Comments_txtResubmitComment, obj_OnboardingModel.str_ID_Txt_ResubmitDocPopup_Comments_txtResubmitComment, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;
                        //Click on Resubmit button
                        results = kwm.jsCommand_Click(WDriver, KeyWords.JS_ResubmitDocPopup_Resubmmit);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;
                        //Wait for Confirmation Popup - Yes Button
                        kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_ResubmitDocPopup_Yes), kwm._WDWait);
                        //Click on Yes
                        results = kwm.jsCommand_Click(WDriver, KeyWords.JS_ResubmitDocPopup_Yes);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;
                        //Wait for Submission Popup - Ok Button
                        kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_ResubmitDocPopup_Ok), kwm._WDWait);
                        //Click on Ok
                        results = kwm.jsCommand_Click(WDriver, KeyWords.JS_ResubmitDocPopup_Ok);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;
                        kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Expand_tabsExpandCollapse), kwm._WDWait);
                        //click on expand all button
                        if (kwm.isElementDisplayedXpath(WDriver, "//span[@id='tabsExpandCollapse' and text()='Expand All']"))
                        {
                            //click on Expand all
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Expand_tabsExpandCollapse);
                            if (results.Result1 == KeyWords.Result_FAIL)
                                goto errormessage;
                        }
                        //update the status
                        ReportHandler._getChildTest().Log(ReportHandler._getChildTest().GetCurrentStatus(), "Updated the status to -" + kwm.GetText_Xpath(WDriver, KeyWords.XPATH_Btn_DocumentAccordin_Status(obj_OnboardingModel.str_ID_Select_AddDocumentPopup_Document_Cmbdocument))._Var);
                    }
                    else
                    {
                        //Get the status
                        ReportHandler._getChildTest().Log(LogStatus.Info, "Status to -" + sStatus);
                    }
                    results._Var = obj_OnboardingModel.str_Select_AddTrainingPopup_Training_CmbTraining;
                }
                else
                {
                    ReportHandler._getChildTest().Log(LogStatus.Fail, "No Document details are found");
                }
            errormessage:
                if (results.Result1 == KeyWords.Result_FAIL)
                    ReportHandler._getChildTest().Log(LogStatus.Fail, "Error Message :" + results.ErrorMessage);
            }
            catch (Exception e)
            {
                ReportHandler._getChildTest().Log(LogStatus.Error, e.Message);
            }
            return results;
        }

        public Result OnBoarding_DeleteDocument(IWebDriver WDriver, DataRow Onboarding_Data)
        {
            try
            {
                results = OnBoarding_AddDocument(WDriver, Onboarding_Data);
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto ErrorMessage;
                else
                {
                    //Delete Document
                    results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_DocumentAccordin_Delete(results._Var));
                    if (results.Result1 == KeyWords.Result_FAIL)
                        goto ErrorMessage;
                    //Wait for delete document popup
                    kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_DeleteDocumentPopup_Yes), kwm._WDWait);
                    //click on Yes
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_DeleteDocumentPopup_Yes);
                    if (results.Result1 == KeyWords.Result_FAIL)
                        goto ErrorMessage;
                    //Wait for Ok on document popup
                    kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_DeleteDocumentPopup_Ok), kwm._WDWait);
                    //click on Ok
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_DeleteDocumentPopup_Ok);
                    if (results.Result1 == KeyWords.Result_FAIL)
                        goto ErrorMessage;
                }

            ErrorMessage:
                if (results.Result1 == KeyWords.Result_FAIL)
                    ReportHandler._getChildTest().Log(LogStatus.Fail, "Error Message :" + results.ErrorMessage);

            }
            catch (Exception e)
            {
                ReportHandler._getChildTest().Log(LogStatus.Error, e.Message);
            }

            return results;
        }
        #endregion

        #region Compliance
        public Result OnBoarding_AddCompliance(IWebDriver WDriver, DataRow Onboarding_Data)
        {

            try
            {
                kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 30);
                WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));
                OnboardingRepository repo_OnBoarding = new OnboardingRepository();
                OnBoardingModel obj_OnboardingModel = repo_OnBoarding.GetOnBoardingModel(Onboarding_Data);
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, obj_OnboardingModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, obj_OnboardingModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }

                objCommonMethods.SaveScreenShot_EachPage(WDriver, obj_OnboardingModel.strClientName + "_");
                //Submenu 

                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, obj_OnboardingModel.strMainMenuLink, obj_OnboardingModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, obj_OnboardingModel.strMainMenuLink, obj_OnboardingModel.strSubMenuLink);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }
                objCommonMethods.SaveScreenShot_EachPage(WDriver, obj_OnboardingModel.strClientName + "_");

                //Wait for element

                try
                {
                    new WebDriverWait(WDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Search_CWName))));
                }
                catch
                {
                    for (int i = 0; i < 10; i++)
                    {
                        try
                        {
                            if (WDriver.FindElement(By.Id(KeyWords.ID_txt_Search_CWName)).Displayed)
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
                Thread.Sleep(2000);
                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_txt_Search_CWName))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_txt_Search_CWName))));
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_Search_CWName, obj_OnboardingModel.str_CandidateName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto errormessage;
                Thread.Sleep(2000);

                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//a[contains(text(),'" + obj_OnboardingModel.str_CandidateName + "')]"))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath("//a[contains(text(),'" + obj_OnboardingModel.str_CandidateName + "')]"))));

                //Candidate name click
                results = kwm.click(WDriver, KeyWords.locator_XPath, "//a[contains(text(),'" + obj_OnboardingModel.str_CandidateName + "')]");
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto errormessage;

                objCommonMethods.SaveScreenShot_EachPage(WDriver, obj_OnboardingModel.strClientName + "_");
                kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Link_Onboarding_ActionListMenu_AddCompliance), kwm._WDWait);
                //Click on Add Compliance link
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Link_Onboarding_ActionListMenu_AddCompliance);
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto errormessage;

                //Wait for popup to load
                kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Select_AddCompliancePopup_Compliance_CmbCompliance), kwm._WDWait);

                //Select Compliance from dropdown
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_AddCompliancePopup_Compliance_CmbCompliance, obj_OnboardingModel.str_ID_Select_AddCompliancePopup_Compliance_CmbCompliance);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_AddCompliancePopup_Compliance_CmbCompliance, 1);
                    if (results.Result1 == KeyWords.Result_FAIL)
                        goto errormessage;
                    else
                        obj_OnboardingModel.str_ID_Select_AddCompliancePopup_Compliance_CmbCompliance = results._Var;
                }
                //CLick on Submit
                results = kwm.jsCommand_Click(WDriver, KeyWords.JS_Popup_Submit);
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto errormessage;

                if (!kwm.isElementDisplayedXpath(WDriver, KeyWords.XPATH_AlertMsg_Popup))
                {
                    //Wait for Yes
                    kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_AddCompliancePopup_Yes), kwm._WDWait);
                    //CLick on Yes
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_AddCompliancePopup_Yes);
                    if (results.Result1 == KeyWords.Result_FAIL)
                        goto errormessage;
                    //Wait for Ok
                    kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_AddCompliancePopup_Ok), kwm._WDWait);
                    //CLick on Ok
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_AddCompliancePopup_Ok);
                    if (results.Result1 == KeyWords.Result_FAIL)
                        goto errormessage;
                }
                else
                {
                    ReportHandler._getChildTest().Log(LogStatus.Fail, "Showing error message : " + kwm.GetText_Xpath(WDriver, "//div[@role='alert' and not(contains(@style,'display: none'))]//li")._Var);
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_AddCompliancePopup_Close);
                    if (results.Result1 == KeyWords.Result_FAIL)
                        goto errormessage;
                }

                kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Expand_tabsExpandCollapse), kwm._WDWait);
                //click on Expand all
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Expand_tabsExpandCollapse);
                if (results.Result1 == KeyWords.Result_FAIL)
                    goto errormessage;
                if (kwm.isElementDisplayed(WDriver, "ComplianceAccord"))
                {

                    if (kwm.isElementDisplayedXpath(WDriver, KeyWords.XPATH_Btn_ComplianceAccordin_UpdateStatus(obj_OnboardingModel.str_ID_Select_AddCompliancePopup_Compliance_CmbCompliance)))
                    {
                        //Click on status symbol
                        results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_ComplianceAccordin_UpdateStatus(obj_OnboardingModel.str_ID_Select_AddCompliancePopup_Compliance_CmbCompliance));
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;

                        //Wait for Update status popup
                        kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Select_UpdateStatusPopup_Status_appStatus), kwm._WDWait);

                        //Select from Status dropdown
                        results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_UpdateStatusPopup_Status_appStatus, 1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;

                        //Enter Comments
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_UpdateStatusPopup_Commnets_TxtComments, obj_OnboardingModel.str_Txt_UpdateStatusPopup_Commnets_TxtComments, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;

                        //Click on Submit
                        results = kwm.jsCommand_Click(WDriver, KeyWords.JS_Popup_Submit);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;
                        //Wait for Yes on onboarding popup
                        kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_Compliance_UpdateStatusPopup_Yes), kwm._WDWait);

                        //Click on Yes
                        results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_Compliance_UpdateStatusPopup_Yes);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;

                        //Wait for OK
                        kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Btn_Compliance_UpdateStatusPopup_Ok), kwm._WDWait);

                        //Click on Ok
                        results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Btn_Compliance_UpdateStatusPopup_Ok);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            goto errormessage;


                    }
                    else
                    {
                        //Get the status
                        ReportHandler._getChildTest().Log(LogStatus.Info, "Update Status link for the compliance is not found");
                    }
                    results._Var = obj_OnboardingModel.str_Select_AddTrainingPopup_Training_CmbTraining;
                }
                else
                {
                    ReportHandler._getChildTest().Log(LogStatus.Fail, "No Compliance details are found");
                }
            errormessage:
                if (results.Result1 == KeyWords.Result_FAIL)
                    ReportHandler._getChildTest().Log(LogStatus.Fail, "Error Message :" + results.ErrorMessage);
            }
            catch (Exception e)
            {
                ReportHandler._getChildTest().Log(LogStatus.Error, e.Message);
            }
            return results;
        }
        #endregion

        public Result Onboarding_ActionList(IWebDriver WDriver, DataRow Onboarding_Data)
        {

            OnBoarding_DeleteTraining(WDriver, Onboarding_Data);
            OnBoarding_DeleteAsset(WDriver, Onboarding_Data);
            OnBoarding_DeleteDocument(WDriver, Onboarding_Data);
            OnBoarding_AddCompliance(WDriver, Onboarding_Data);
            return results;
        }

        public Result pauseonboarding(IWebDriver WDriver, DataRow Onboarding_Data, int SupExecutionRowNo)
        {
         
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
           
            WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(30));


            OnboardingRepository repo_OnBoarding = new OnboardingRepository();
           
            OnBoardingModel pauseonboardingmodel = repo_OnBoarding.GetOnBoardingModel(Onboarding_Data);
            //      
            // Requirements


            results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, pauseonboardingmodel.strClientName);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, pauseonboardingmodel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, pauseonboardingmodel.strClientName + "_");
            //SUbmenu 

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, pauseonboardingmodel.strMainMenuLink, pauseonboardingmodel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, pauseonboardingmodel.strMainMenuLink, pauseonboardingmodel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, pauseonboardingmodel.strClientName + "_");

            //Wait for element

            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Search_CWName))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_txt_Search_CWName)).Displayed)
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
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_txt_Search_CWName))));
            wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_txt_Search_CWName))));
            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_Search_CWName, pauseonboardingmodel.str_CandidateName, false);

            Thread.Sleep(2000);

            wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//a[contains(text(),'" + pauseonboardingmodel.str_CandidateName + "')]"))));
            wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath("//a[contains(text(),'" + pauseonboardingmodel.str_CandidateName + "')]"))));

            //Candidate name click
            kwm.click(WDriver, KeyWords.locator_XPath, "//a[contains(text(),'" + pauseonboardingmodel.str_CandidateName + "')]");

            objCommonMethods.SaveScreenShot_EachPage(WDriver, pauseonboardingmodel.strClientName + "_");
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Expand_tabsExpandCollapse), kwm._WDWait);

            ////////////need to chage IDS for this 

            //list menu click 
            objCommonMethods.SaveScreenShot_EachPage(WDriver, pauseonboardingmodel.strClientName + "_");
            String strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, pauseonboardingmodel.str_Actionlist, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, pauseonboardingmodel.str_Actionlist, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            //wait for the popup 

            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_select_reasonforpause_Cmbpausereason), kwm._WDWait);

            //selecting the reason and 
            results = kwm.selectDropDown(WDriver, KeyWords.locator_ID, KeyWords.ID_select_reasonforpause_Cmbpausereason, pauseonboardingmodel.str_ID_select_Reasontopauseonboarding_Cmbpausereason);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_select_reasonforpause_Cmbpausereason);

            }


            //enteringh text in commengt
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Pauseonbardingcomment_Txtpausereasoncomment, pauseonboardingmodel.str_ID_Text_Comment_Txtpausereasoncomment, false, "", "");

            //click on withdraw button
            kwm.click_Xpath(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_button_withdraw);

            kwm.waitforelementandclick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_pauseonbaording_YES, By.XPath(KeyWords.Xpath_pauseonbaording_YES), kwm._WDWait);
            kwm.waitforelementandclick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_pauseonbaording_OK, By.XPath(KeyWords.Xpath_pauseonbaording_OK), kwm._WDWait);

            return results;







        }

        public Result Resumeonboarding(IWebDriver WDriver, DataRow Onboarding_Data, int SupExecutionRowNo)
        {
           
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
            
            WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(30));


            OnboardingRepository repo_OnBoarding = new OnboardingRepository();
            OnBoardingModel pauseonboardingmodel = repo_OnBoarding.GetOnBoardingModel(Onboarding_Data);
            
            //      
            // Requirements


            results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, pauseonboardingmodel.strClientName);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, pauseonboardingmodel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, pauseonboardingmodel.strClientName + "_");
            //SUbmenu 

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, pauseonboardingmodel.strMainMenuLink, pauseonboardingmodel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, pauseonboardingmodel.strMainMenuLink, pauseonboardingmodel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, pauseonboardingmodel.strClientName + "_");

            //Wait for element

            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Search_CWName))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_txt_Search_CWName)).Displayed)
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
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_txt_Search_CWName))));
            wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_txt_Search_CWName))));
            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_Search_CWName, pauseonboardingmodel.str_CandidateName, false);

            Thread.Sleep(2000);

            wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//a[contains(text(),'" + pauseonboardingmodel.str_CandidateName + "')]"))));
            wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath("//a[contains(text(),'" + pauseonboardingmodel.str_CandidateName + "')]"))));

            //Candidate name click
            kwm.click(WDriver, KeyWords.locator_XPath, "//a[contains(text(),'" + pauseonboardingmodel.str_CandidateName + "')]");

            objCommonMethods.SaveScreenShot_EachPage(WDriver, pauseonboardingmodel.strClientName + "_");
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Expand_tabsExpandCollapse), kwm._WDWait);

            ////////////need to chage IDS for this 

            //list menu click 
            objCommonMethods.SaveScreenShot_EachPage(WDriver, pauseonboardingmodel.strClientName + "_");
            String strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, pauseonboardingmodel.str_Actionlist, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, pauseonboardingmodel.str_Actionlist, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            //wait for the popup 

            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Select_Reasonforcancellatio_Cmbcancelreason), kwm._WDWait);

            //selecting the reason and 
            results = kwm.selectDropDown(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Reasonforcancellatio_Cmbcancelreason, pauseonboardingmodel.str_ID_select_Reasontopauseonboarding_Cmbpausereason);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Reasonforcancellatio_Cmbcancelreason);

            }


            //enteringh text in commengt
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_Text_reasoncomment_Txtreasononboardcomment, pauseonboardingmodel.str_ID_Text_Comment_Txtpausereasoncomment, false, "", "");

            //click on withdraw button
            kwm.click_Xpath(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_button_withdraw);
            //click on YES button 
            kwm.waitforelementandclick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Button_Cancelonboarding_YES, By.XPath(KeyWords.Xpath_Button_Cancelonboarding_YES), kwm._WDWait);
            //click on OK Button
            kwm.waitforelementandclick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Button_Cancelonboarding_OK, By.XPath(KeyWords.Xpath_Button_Cancelonboarding_OK), kwm._WDWait);

            return results;
        }

        public Result Cancelonboarding(IWebDriver WDriver, DataRow Onboarding_Data, int SupExecutionRowNo)
        {
           
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
           
            WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(30));


            OnboardingRepository repo_OnBoarding = new OnboardingRepository();
            OnBoardingModel pauseonboardingmodel = repo_OnBoarding.GetOnBoardingModel(Onboarding_Data);
                
            // Requirements


            results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, pauseonboardingmodel.strClientName);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, pauseonboardingmodel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, pauseonboardingmodel.strClientName + "_");
            //SUbmenu 

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, pauseonboardingmodel.strMainMenuLink, pauseonboardingmodel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, pauseonboardingmodel.strMainMenuLink, pauseonboardingmodel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, pauseonboardingmodel.strClientName + "_");

            //Wait for element

            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Search_CWName))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_txt_Search_CWName)).Displayed)
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
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_txt_Search_CWName))));
            wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_txt_Search_CWName))));
            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_Search_CWName, pauseonboardingmodel.str_CandidateName, false);

            Thread.Sleep(2000);

            wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//a[contains(text(),'" + pauseonboardingmodel.str_CandidateName + "')]"))));
            wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath("//a[contains(text(),'" + pauseonboardingmodel.str_CandidateName + "')]"))));

            //Candidate name click
            kwm.click(WDriver, KeyWords.locator_XPath, "//a[contains(text(),'" + pauseonboardingmodel.str_CandidateName + "')]");

            objCommonMethods.SaveScreenShot_EachPage(WDriver, pauseonboardingmodel.strClientName + "_");
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Expand_tabsExpandCollapse), kwm._WDWait);

            //list menu click 
            objCommonMethods.SaveScreenShot_EachPage(WDriver, pauseonboardingmodel.strClientName + "_");
            String strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, pauseonboardingmodel.str_Actionlist, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, pauseonboardingmodel.str_Actionlist, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            //wait for the popup 

            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Text_Resumeonboarding_Txtresumecomment), kwm._WDWait);


            //enteringh text in commengt
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Text_Resumeonboarding_Txtresumecomment, pauseonboardingmodel.str_ID_Text_Comment_Txtpausereasoncomment, false, "", "");

            //click on withdraw button
            kwm.click_Xpath(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_button_withdraw);

            //click on YES button
            kwm.waitforelementandclick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Button_Resumeonboarding_YES, By.XPath(KeyWords.Xpath_Button_Resumeonboarding_YES), kwm._WDWait);
            //click on OK Button
            kwm.waitforelementandclick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Bubtton_Resumeonboarding_OK, By.XPath(KeyWords.Xpath_Bubtton_Resumeonboarding_OK), kwm._WDWait);

            return results;


        }


        public Result Submitinformation(IWebDriver WDriver, DataRow Onboarding_Data, int SupExecutionRowNo)
        {
            
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);
         
            WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(30));


            OnboardingRepository repo_OnBoarding = new OnboardingRepository();
         
            OnBoardingModel OnBoardingModel = repo_OnBoarding.GetOnBoardingModel(Onboarding_Data);
            //      
            // Requirements


            results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, OnBoardingModel.strClientName);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, OnBoardingModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, OnBoardingModel.strClientName + "_");
            //SUbmenu 

            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, OnBoardingModel.strMainMenuLink, OnBoardingModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, OnBoardingModel.strMainMenuLink, OnBoardingModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, OnBoardingModel.strClientName + "_");

            //Wait for element

            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Search_CWName))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_txt_Search_CWName)).Displayed)
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
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_txt_Search_CWName))));
            wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_txt_Search_CWName))));
            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_Search_CWName, OnBoardingModel.str_CandidateName, false);

            Thread.Sleep(2000);

            wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//a[contains(text(),'" + OnBoardingModel.str_CandidateName + "')]"))));
            wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath("//a[contains(text(),'" + OnBoardingModel.str_CandidateName + "')]"))));

            //Candidate name click
            kwm.click(WDriver, KeyWords.locator_XPath, "//a[contains(text(),'" + OnBoardingModel.str_CandidateName + "')]");

            objCommonMethods.SaveScreenShot_EachPage(WDriver, OnBoardingModel.strClientName + "_");
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Expand_tabsExpandCollapse), kwm._WDWait);

            //list menu click 
            objCommonMethods.SaveScreenShot_EachPage(WDriver, OnBoardingModel.strClientName + "_");
            String strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, OnBoardingModel.str_Actionlist, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                objCommonMethods.Action_Page_Down(WDriver);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, OnBoardingModel.str_Actionlist, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            //wait for the popup 

            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_onboardingheder), kwm._WDWait);

            //Is the new hire a retail teller or sales employee? *
            if (OnBoardingModel.str_select_Isthenrewhire_YES.ToLower().Equals(KeyWords.str_String_Compare_yes))
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_isthenewhire_YES);
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_isthenewhire_No);
            }

            //Phone Required *

            if (OnBoardingModel.str_select_phonerequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_phonerequired_YES);
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_phonerequired_NO);
            }

            //Phone Exists on New Hire's Desk *
            if (OnBoardingModel.str_select_PhoneExistsonNewHireDesk.ToLower().Equals(KeyWords.str_String_Compare_yes))
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_isthenewhire_YES);
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_isthenewhire_No);
            }

            //Existing Phone Number *
            if (OnBoardingModel.str_select_PhoneExistsonNewHireDesk != "")
            {
                kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Text_Existingphonenumber, OnBoardingModel.str_select_PhoneExistsonNewHireDesk, false, "", "");
                // results = kwm.sendText_XPath(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_isthenewhire_YES);
            }

            //Name Assigned to Existing Phone *
            if (OnBoardingModel.str_text_NameAssignedtoExistingPhone != "")
            {
                kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Text_NameAssignedtoExistingPhone, OnBoardingModel.str_text_NameAssignedtoExistingPhone, false, "", "");
                // results = kwm.sendText_XPath(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_isthenewhire_YES);
            }

            //softphone required
            if (OnBoardingModel.str_Select_SoftphoneRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_btn_Softphonerequired_YES);
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_btn_Softphonerequired_NO);
            }

            //PC Required *
            if (OnBoardingModel.str_Select_PCrequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_select_PCrequired_YES);
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Select_PCrequired_NO);
            }


            //submit to click on ok button
            results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_btn_Submit_Submitinformation);

            //click on YES button
            kwm.waitforelementandclick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Btn_Submitinformation_YES, By.XPath(KeyWords.Xpath_Btn_Submitinformation_YES), kwm._WDWait);
            //click on OK Button
            kwm.waitforelementandclick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Btn_Submitinformation_Ok, By.XPath(KeyWords.Xpath_Btn_Submitinformation_Ok), kwm._WDWait);


            return results;


        }


    }
}
