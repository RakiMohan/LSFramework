// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SubmitCandidate.cs" company="DCR Workforce Inc">
//   Copyright (c) DCR Workforce Inc. All rights reserved.
//   This code and information should not be copied and used outside of DCR Workforce Inc.
// </copyright>
// <summary>
//   Defines the Registration Repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using SmartTrack.DataAccess.Models;
using SmartTrack.DataAccess.Repository;
using SmartTrack;


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
using System.Net;
using System.Collections;
using System.Windows.Forms;
using NUnit.Framework;
using CommonFiles;
using RelevantCodes.ExtentReports;


namespace SmartTrack_Automation
{
    // [TestClass]
    public class SubmitCandidate
    {
        public Result SubmitCandidate_Method(IWebDriver WDriver, DataRow SubmitCandidate_Data, ExtentTest logTest, String TestScenario)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);

            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            SubmitCandidateMethodModel submitCandidateMethodModel = createRequirementRepository.GetSubmitCandidateMethodData(SubmitCandidate_Data);

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitCandidateMethodModel.strClientName + "_");

            //Client selection
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
                results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitCandidateMethodModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //Thread.Sleep(000);
                    results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitCandidateMethodModel.strClientName);

                }
            }

            //Submenu click
            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitCandidateMethodModel.strClientName + "_");
            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitCandidateMethodModel.strMainMenuLink, submitCandidateMethodModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitCandidateMethodModel.strMainMenuLink, submitCandidateMethodModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitCandidateMethodModel.strClientName + "_");


            Boolean bFilterTxt = false;


            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Supplier_Submitcandidate_Reqno), kwm._WDWait);

            //Req no passed into search
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Supplier_Submitcandidate_Reqno, submitCandidateMethodModel.str_Link_ReqNumber, false);
            //results = kwm.sendText_XPath(WDriver, KeyWords.locator_ID, KeyWords.ID_Supplier_Submitcandidate_Reqno, KeyWords.ID_Txt_txtGolbalFilterReqs, submitCandidateMethodModel.str_Link_ReqNumber, false);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.sendText_XPath(WDriver, KeyWords.locator_ID, KeyWords.ID_Supplier_Submitcandidate_Reqno, KeyWords.ID_Txt_txtGolbalFilterReqs, submitCandidateMethodModel.str_Link_ReqNumber, false);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results.ErrorMessage = results.ErrorMessage + "," + " Problem Enter REQ Number in Search filed";

                }

            }
            //Thread.Sleep(5000);
            //Requirement number click
            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitCandidateMethodModel.strClientName + "_");
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Link_Requirementnumber);

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            //Search candidate
            string strSubLevel = "";
            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitCandidateMethodModel.strClientName + "_");
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitCandidateMethodModel.str_Link_SearchCandidate, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitCandidateMethodModel.str_Link_SearchCandidate, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Txt_LastName), kwm._WDWait);

            //Search Button click

           // kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Buttons_Search);

            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_Button_Addcandidatetoresumebank), kwm._WDWait);

            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Button_Addcandidatetoresumebank);
            //Add resume button click

            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Button_Addcandidatetoresumebank);
            results = Add_Resume(WDriver, SubmitCandidate_Data);

            // Wait until candidate name displayed
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_Label_Candidatename_CandidateName), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_Label_Candidatename_CandidateName), kwm._WDWait);

            // Get candidate name from application
            results = kwm.GetText_Xpath(WDriver, KeyWords.Xpath_Label_Candidatename_CandidateName);
            string CandidateName = results._Var;
            var WriteExlResult = new Result();
            ReadExcel ReadExcelHelper = new ReadExcel();

            String strUpdateSqlMain4 = "Update [MSP$] set P8 ='" + CandidateName + "'  WHERE P3 ='" + submitCandidateMethodModel.strClientName + "' and  TestCaseID <> '001' and  TestCaseID <> '003' and TestScenario ='" + TestScenario + "'";
            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain4);

            String strUpdateSqlMain5 = "Update [Supplier$] set P8 ='" + CandidateName + "'  WHERE P3 ='" + submitCandidateMethodModel.strClientName + "' and  TestCaseID <> '004' and TestScenario ='" + TestScenario + "'";
            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain5);


            results = Submit_Resume_details(WDriver, SubmitCandidate_Data, logTest, TestScenario);

            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_strSubmitCandidateSuccessfully;
            return results;
        }

        public Result Submit_Resume_details(IWebDriver driver, DataRow SubmitCandidate_Data, ExtentTest logTest, string TestScenario)
        {
            CommonMethods objCommonMethods = new CommonMethods();
            KeyWordMethods kwm = new KeyWordMethods();

            var results = new Result();
            // ArrayList listExistClients = new ArrayList { };
            List<string> listExistClients = new List<string>();
            //  CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            SubmitCandidateResumeRepository submitCandidateResumeRepository = new SubmitCandidateResumeRepository();
            SubmitCandidateResumeModel submitCandidateResumeModel = submitCandidateResumeRepository.GetSubmitCandidateResumeData(SubmitCandidate_Data);
            string strErrMsg = "";


            switch (submitCandidateResumeModel.strClientName.ToLower())
            {

                case Constants.Sts:
                    {
                        SubmitCandidatePerClient.SubmitCandidateStsClient(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);

                        break;
                    }
                //case Constants.IsGs:
                //    {
                //        SubmitCandidatePerClient.SubmitCandidateIsGsClient(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                //        break;
                //    }
                case Constants.EBS:
                    {
                        SubmitCandidatePerClient.SubmitCandidateEBS(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }
                case Constants.RMS:
                    {
                        SubmitCandidatePerClient.SubmitCandidateRMS(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }

                case Constants.STGEN:
                    {
                        SubmitCandidatePerClient.SubmitCandidateSTGEN(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }
                case Constants.STTM:
                    {
                        SubmitCandidatePerClient.SubmitCandidateSTTM(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }
                case Constants.MFC:
                    {
                        SubmitCandidatePerClient.SubmitCandidateMFC(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }
                //case Constants.NvEnergy:
                //    {
                //        SubmitCandidatePerClient.SubmitCandidateNVENERGY(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                //        break;
                //    }


                //case Constants.AmCom:
                //    {
                //        SubmitCandidatePerClient.SubmitCandidateAmCom(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                //        break;
                //    }
                //case Constants.DCR:
                //    {
                //        SubmitCandidatePerClient.SubmitCandidateDCR(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                //        break;
                //    }
                case Constants.YP:
                    {
                        SubmitCandidatePerClient.SubmitCandidateYP(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }
                //case Constants.Meritor:
                //    {
                //        SubmitCandidatePerClient.SubmitCandidateMeritor(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                //        break;
                //    }
                //case Constants.GHC:
                //    {
                //        SubmitCandidatePerClient.SubmitCandidateGHC(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                //        break;
                //    }

                //case Constants.BDA:
                //    {
                //        SubmitCandidatePerClient.SubmitCandidateBDA(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                //        break;
                //    }
                case Constants.Arkema:
                    {
                        SubmitCandidatePerClient.SubmitCandidateArkema(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }
                //case Constants.Aero:
                //    {
                //        SubmitCandidatePerClient.SubmitCandidateAero(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                //        break;
                //    }
                case Constants.Supervalu:
                    {
                        SubmitCandidatePerClient.SubmitCandidateSupervalu(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }
                case Constants.Caesars:
                    {
                        SubmitCandidatePerClient.SubmitCandidateCaesars(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }
                case Constants.Epri:
                    {
                        SubmitCandidatePerClient.SubmitCandidateEpri(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }

                //case Constants.Costco:
                //    {
                //        SubmitCandidatePerClient.SubmitCandidateCostco(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                //        break;
                //    }
                case Constants.Discover:
                    {
                        SubmitCandidatePerClient.SubmitCandidateDiscover(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }
                case Constants.Keybank:
                    {
                        SubmitCandidatePerClient.SubmitCandidateKeybank(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }
                case Constants.Welchallyn:
                    {
                        SubmitCandidatePerClient.SubmitCandidateWelchallyn(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }
                case Constants.APS:
                    {
                        SubmitCandidatePerClient.SubmitCandidateAPS(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }
                case Constants.StewartTitle:
                    {
                        SubmitCandidatePerClient.SubmitCandidateStewartTitle(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }
                case Constants.Dyncorp:
                    {
                        SubmitCandidatePerClient.SubmitCandidateDyncorp(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }
                case Constants.Altria:
                    {
                        SubmitCandidatePerClient.SubmitCandidateAltria(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }
                case Constants.Ryder:
                    {
                        SubmitCandidatePerClient.SubmitCandidateRyder(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }
                case Constants.EMERSON:
                    {
                        SubmitCandidatePerClient.SubmitCandidateEmerson(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }

                case Constants.KCPL:
                    {
                        SubmitCandidatePerClient.SubmitCandidateKCPL(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }
                case Constants.SallieMae:
                    {
                        SubmitCandidatePerClient.SubmitCandidateWorkspendSallieMae(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }
                //case Constants.DcrSallieMae:
                //    {
                //        SubmitCandidatePerClient.SubmitCandidateDcrSallieMae(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                //        break;
                //    }
                case Constants.SOF:
                    {
                        SubmitCandidatePerClient.SubmitCandidateSOF(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }
                case Constants.HillRom:
                    {
                        SubmitCandidatePerClient.SubmitCandidateHillRom(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }

                //case Constants.Martiz:
                //    {
                //        SubmitCandidatePerClient.SubmitCandidateMartiz(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                //        break;
                //    }
                case Constants.Bimbo:
                    {
                        SubmitCandidatePerClient.SubmitCandidateBimbo(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }


                case Constants.Colgate:
                    {
                        SubmitCandidatePerClient.SubmitCandidateColgate(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }

                //case Constants.STNow:
                //    {
                //        SubmitCandidatePerClient.SubmitCandidateSTNow(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                //        break;
                //    }
                case Constants.ThermoFisher:
                    {
                        SubmitCandidatePerClient.SubmitCandidateThermoFisher(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }

                case Constants.SunTrust:
                    {
                        SubmitCandidatePerClient.SubmitCandidateSunTrust(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }

                case Constants.Tufts:
                    {
                        SubmitCandidatePerClient.SubmitCandidateTufts(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }

                case Constants.PHHMortgage:
                    {
                        SubmitCandidatePerClient.SubmitCandidatePHHMortgage(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }

                case Constants.Cpchem:
                    {
                        SubmitCandidatePerClient.SubmitCandidateCpchem(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }
                case Constants.Tesla:
                    {
                        SubmitCandidatePerClient.SubmitCandidateTesla(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }
                case Constants.QuickenLoans:
                    {
                        SubmitCandidatePerClient.SubmitCandidateQuickenLoans(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);

                        break;
                    }
                case Constants.COE:
                    {
                        SubmitCandidatePerClient.SubmitCandidateCOE(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }
                case Constants.Georgetown:
                    {
                        SubmitCandidatePerClient.SubmitCandidateGeorgeTown(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);

                        break;
                    }
                case Constants.Lear:
                    {
                        SubmitCandidatePerClient.SubmitCandidatelear(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);

                        break;
                    }
                case Constants.EQT:
                    {
                        SubmitCandidatePerClient.SubmitCandidateEQT(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }
                case Constants.SIGMA:
                    {
                        SubmitCandidatePerClient.SubmitCandidateSIGMA(submitCandidateResumeModel, results, kwm, driver, objCommonMethods);
                        break;
                    }

                default:
                    {
                        break;
                    }
            }


            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
            if (submitCandidateResumeModel.str_Button_SubmitToRequirement.ToLower().Trim() == driver.FindElement(By.Id(KeyWords.ID_Button_btnSubmit)).Text.ToLower().Trim())
            {
                objCommonMethods.Action_Page_Down(driver);
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Button_btnSubmit);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(driver);
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Button_btnSubmit);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }
            else
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Given " + submitCandidateResumeModel.str_Button_SubmitToRequirement + " button name unable to find";
                return results;
            }
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
            results = kwm.Error_Msg_Read_Submit_Resume_details(driver, "//div[@" + KeyWords.locator_ID + "='" + KeyWords.ID_Error_rh_contentContainer + "']/div/div/div/ul/li");
            if (results.Result1 == KeyWords.Result_PASS)
            {
                if (results.ErrorMessage != "")
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    return results;
                }
            }


            Thread.Sleep(2000);
            // dvBeforeHigherRate
            Boolean bdvBeforeHigherRate = false;
            try
            {
                bdvBeforeHigherRate = driver.FindElement(By.Id("dvBeforeHigherRate")).Displayed;
            }
            catch
            {
                bdvBeforeHigherRate = false;
            }

            if (bdvBeforeHigherRate)
            {
                objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
                results = kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
            results = kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
            // Thread.Sleep(2000);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
            results = kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(10000);
                    results = kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                    //return results;
                }
            }

            kwm.waitForElementToBeVisible(driver, By.XPath(KeyWords.XPath_link_CandidateName), kwm._WDWait);

            // Get candidate name from application
            //results = kwm.GetText_Xpath(driver, KeyWords.XPath_link_CandidateName);
            //string CandidateName = results._Var;
            //var WriteExlResult = new Result();
            //ReadExcel ReadExcelHelper = new ReadExcel();

            //String strUpdateSqlMain4 = "Update [MSP$] set P8 ='" + CandidateName + "'  WHERE P3 ='" + submitCandidateResumeModel.strClientName + "' and  TestCaseID <> '001' and  TestCaseID <> '003' and TestScenario ='" + TestScenario + "'";
            //WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain4);

            //String strUpdateSqlMain5 = "Update [Supplier$] set P8 ='" + CandidateName + "'  WHERE P3 ='" + submitCandidateResumeModel.strClientName + "' and  TestCaseID <> '004' and TestScenario ='" + TestScenario + "'";
            //WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain5);


            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = strErrMsg;
            return results;
        }

        public Result Add_Resume(IWebDriver driver, DataRow SubmitCandidate_Data)
        {
            CommonMethods objCommonMethods = new CommonMethods();
            KeyWordMethods kwm = new KeyWordMethods();
            var results = new Result();
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            SubmitCandidateAddResume submitCandidateAddResume = createRequirementRepository.GetSubmitCandidateAddResumeData(SubmitCandidate_Data);
            string strErrMsg = "";
            kwm._WDWait = kwm.WebDriver_Wait_Handler(driver, 20);

            kwm.waitForElementToBeVisible(driver, By.Id(KeyWords.ID_Txt_LastName_LastName), kwm._WDWait);
            kwm.waitForElementToBeClickable(driver, By.Id(KeyWords.ID_Txt_LastName_LastName), kwm._WDWait);

            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateAddResume.strClientName + "_");
            //try
            //{
            //    new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_Txt_LastName_LastName))));
            //}
            //catch
            //{
            //    // Thread.Sleep(2000);
            //    try
            //    {
            //        new WebDriverWait(driver, TimeSpan.FromSeconds(200)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_Txt_LastName_LastName))));
            //    }
            //    catch
            //    {
            //        results.Result1 = KeyWords.Result_FAIL;
            //        results.ErrorMessage = "Problem failed  unable to find the SSN field";
            //        return results;
            //    }
            //}

            //Last digits of ssn -- it is availabel for SunTrust          

            if (submitCandidateAddResume.str_Txt_Last4DigitsSSN != "")
            {
                kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Txt_SSN);
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Txt_SSN, submitCandidateAddResume.str_Txt_Last4DigitsSSN, false);
            }
            //Last Name
            if (submitCandidateAddResume.str_Txt_LastName_LastName != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Txt_LastName_LastName, submitCandidateAddResume.str_Txt_LastName_LastName, false);
            }
            else
            {
                results = kwm.GetNameFromReqNumber("LN", submitCandidateAddResume.str_Link_ReqNumber);
                if (results.Result1 == KeyWords.Result_PASS)
                {
                    //SubmitCandidate_Data["P11"] = results.ErrorMessage;
                    kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Txt_LastName_LastName, results.ErrorMessage, false);
                }

            }
            //FirstName
            if (submitCandidateAddResume.str_Txt_FirstName_FirstName != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Txt_FirstName_FirstName, submitCandidateAddResume.str_Txt_FirstName_FirstName, false);
            }
            else
            {
                results = kwm.GetNameFromReqNumber("FN", submitCandidateAddResume.str_Link_ReqNumber);
                if (results.Result1 == KeyWords.Result_PASS)
                {
                    //SubmitCandidate_Data["P12"] = results.ErrorMessage;
                    kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Txt_FirstName_FirstName, results.ErrorMessage, false);
                }

            }


            //Middle Name

            //if (submitCandidateAddResume.str_Txt_MiddleName_MiddleName != "")
            //{
            //    kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Txt_MiddleName_MiddleName, submitCandidateAddResume.str_Txt_MiddleName_MiddleName, false);
            //}

            //suffix
            if (submitCandidateAddResume.str_Select_Suffix_SuffixName != "")
            {
               // results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_Select_Suffix_SuffixName, submitCandidateAddResume.str_Select_Suffix_SuffixName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                       // SelectElement se = new SelectElement(driver.FindElement(By.Id(KeyWords.ID_Select_Suffix_SuffixName))); //Selecting business unit
                      //  se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }
            else
            {
                SelectElement se = new SelectElement(driver.FindElement(By.Id(KeyWords.ID_Select_Suffix_SuffixName)));
                se.SelectByIndex(1);
            }

            // Zip Code  


            //if (submitCandidateAddResume.str_typehead_ZipCode_zipcode != "")
            //{
            //    Thread.Sleep(2000);
            //    results = kwm.select_List_typeahead(driver, KeyWords.locator_ID, KeyWords.ID_typehead_ZipCode_zipcode, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitCandidateAddResume.str_typehead_ZipCode_zipcode, submitCandidateAddResume.str_typehead_ZipCode_zipcode);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        results = kwm.select_List_typeahead_AnyOne(driver, KeyWords.locator_ID, KeyWords.ID_Select_Country, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitCandidateAddResume.str_typehead_ZipCode_zipcode, submitCandidateAddResume.str_typehead_ZipCode_zipcode);
            //        //  return results;
            //    }
            //}

            // ID_select_Country_country

            //country*
            if (!string.IsNullOrWhiteSpace(submitCandidateAddResume.str_select_Country_country))
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(driver, KeyWords.locator_ID, KeyWords.ID_select_Country_country, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitCandidateAddResume.str_select_Country_country, submitCandidateAddResume.str_select_Country_country);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(driver, KeyWords.locator_ID, KeyWords.ID_Select_State, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitCandidateAddResume.str_select_Country_country, submitCandidateAddResume.str_select_Country_country);
                    //  return results;
                }
            }


            //State *
            if (!string.IsNullOrWhiteSpace(submitCandidateAddResume.str_select_State_State))
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(driver, KeyWords.locator_ID, KeyWords.ID_Select_State_State, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitCandidateAddResume.str_select_State_State, submitCandidateAddResume.str_select_State_State);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(driver, KeyWords.locator_ID, KeyWords.ID_Select_State_State, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitCandidateAddResume.str_select_State_State, submitCandidateAddResume.str_select_State_State);
                    //  return results;
                }
            }

            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(driver);



            //Location City

            //if (!string.IsNullOrWhiteSpace(submitCandidateAddResume.str_select_Country_country))
            //{
            //    Thread.Sleep(2000);
            //    results = kwm.select_List_typeahead(driver, KeyWords.locator_ID, KeyWords.ID_select_Country_country, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitCandidateAddResume.str_select_Country_country, submitCandidateAddResume.str_select_Country_country);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        results = kwm.select_List_typeahead_AnyOne(driver, KeyWords.locator_ID, KeyWords.ID_Select_State, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitCandidateAddResume.str_select_Country_country, submitCandidateAddResume.str_select_Country_country);
            //        //  return results;
            //    }
            //}

            kwm.Action_LookInto_Element(driver, KeyWords.locator_ID, KeyWords.ID_select_City_city);
            if (submitCandidateAddResume.str_select_locationorcityLocationCity != "")
            {
                results = kwm.select_List_typeahead(driver, KeyWords.locator_ID, KeyWords.ID_select_City_city, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitCandidateAddResume.str_select_locationorcityLocationCity, submitCandidateAddResume.str_select_locationorcityLocationCity);
                // results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_City_city, submitCandidateAddResume.str_select_locationorcityLocationCity);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(driver, KeyWords.locator_ID, KeyWords.ID_select_City_city, KeyWords.locator_class, KeyWords.CL_list_typeahead, submitCandidateAddResume.str_select_locationorcityLocationCity, submitCandidateAddResume.str_select_locationorcityLocationCity);
                    //try
                    //{
                    //    SelectElement se = new SelectElement(driver.FindElement(By.Id(KeyWords.ID_select_City_city))); //Selecting business unit
                    //    se.SelectByIndex(1);
                    //}
                    //catch
                    //{
                    //    //
                    //}
                }

            }
            else
            {
                //SelectElement se = new SelectElement(driver.FindElement(By.Id(KeyWords.ID_select_City_city)));
                //se.SelectByIndex(1);
            }

            // Zip/ Postal Code


            //Available
            if (submitCandidateAddResume.str_RadioButton_Available != "")
            {
                if (submitCandidateAddResume.str_RadioButton_Available.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_RadioButton_Available_Available);
                    kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Txt_AvailableDate);
                    results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateAddResume.str_Txt_AvailableDate);

                }
                else
                {
                    kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_RadioButton_Available_no);
                }

            }
            //ATSID
            if (submitCandidateAddResume.str_Txt_ATSID != "")
            {
                kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Txt_ATSIDField);
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Txt_ATSIDField, submitCandidateAddResume.str_Txt_ATSID, false);
            }

            // Past/Present Military Employment
            if (submitCandidateAddResume.str_Radio_Employement != "")
            {
                if (submitCandidateAddResume.str_Radio_Employement.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Radio_Employement_Yes);
                    kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Txt_Military_Employment, submitCandidateAddResume.str_Txt_Employement, false);
                }
                else
                {
                    kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Radio_Employement_NO);
                }

            }

            objCommonMethods.Action_Page_Down(driver);

            ////upload path
            //if (submitCandidateAddResume.str_Txt_UploadFilePath != "")
            //{

            //    if (File.Exists(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateAddResume.str_Txt_UploadFilePath))
            //    {
            //        if (submitCandidateAddResume.str_BrowserName.ToLower() != Constants.Chrome)
            //        {
            //            kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Link_btnresumeupload);
            //        }

            //        // Thread.Sleep(3000);

            //        try
            //        {
            //            kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Link_btnresumeupload);
            //            driver.FindElement(By.Name(KeyWords.NAME_Link_qqfile)).SendKeys(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateAddResume.str_Txt_UploadFilePath);
            //            Thread.Sleep(3000);
            //            if (submitCandidateAddResume.str_BrowserName.ToLower() == Constants.Chrome)
            //            {

            //                System.Windows.Forms.SendKeys.SendWait("{ESC}");
            //                Thread.Sleep(3000);

            //            }


            //        }
            //        catch (Exception uplod)
            //        {
            //            string strUploaderror = uplod.Message;
            //        }
            //    }
            //    else
            //    {
            //        objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "The given resume path not find" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateAddResume.str_Txt_UploadFilePath, 3);
            //    }
            //}

            // Mahesh Resume Upload

            if (submitCandidateAddResume.str_Txt_UploadFilePath != "")
            {

                if (File.Exists(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateAddResume.str_Txt_UploadFilePath))
                {

                    try
                    {

                        if (KeyWords.NAME_icon_UploadResume_qqfile == "qqfile" && kwm.isElementPresent(driver, KeyWords.NAME_icon_UploadResume_qqfile))
                        {
                            //   kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Link_btnresumeupload);
                            // Thread.Sleep(30);
                            //WDriver.FindElement(By.Name(KeyWords.NAME_Link_qqfile)).Click();
                         //   kwm.click(driver, KeyWords.NAME_icon_UploadResume_qqfile, KeyWords.ID_Link_btnresumeupload);
                            // driver.FindElement(By.Id(KeyWords.ID_Link_btnresumeupload)).
                            driver.FindElement(By.Name(KeyWords.NAME_Link_qqfile)).SendKeys(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateAddResume.str_Txt_UploadFilePath);
                            Thread.Sleep(1000);

                            //  Actions action = new Actions(driver);
                            //   action.SendKeys(OpenQA.Selenium.Keys.Escape);
                            //  action.SendKeys(System.Windows.Forms.Keys.Escape);
                            System.Windows.Forms.SendKeys.SendWait("{ESC}");
                            Thread.Sleep(1000);

                        }

                        else
                        {

                            if (KeyWords.NAME_icon_UploadResume_uploadResume == "uploadResume" && kwm.isElementPresent(driver, KeyWords.NAME_uploadresume))
                            {
                                kwm.click(driver, KeyWords.NAME_uploadresume, KeyWords.ID_Link_btnresumeupload);
                                driver.FindElement(By.Name(KeyWords.NAME_uploadresume)).SendKeys(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateAddResume.str_Txt_UploadFilePath);
                                Thread.Sleep(1000);

                                //  Actions action = new Actions(driver);
                                //   action.SendKeys(OpenQA.Selenium.Keys.Escape);
                                //  action.SendKeys(System.Windows.Forms.Keys.Escape);
                                System.Windows.Forms.SendKeys.SendWait("{ESC}");
                                Thread.Sleep(1000);
                            }
                        }


                    }


                    catch (Exception uplod)
                    {
                        string strUploaderror = uplod.Message;
                    }
                }
                else
                {
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "The given resume path not find" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateAddResume.str_Txt_UploadFilePath, 3);
                }

            }

            objCommonMethods.Action_Page_Down(driver);

            //Speaks more than one language?
            if (submitCandidateAddResume.str_select_Languages != "")
            {
                if (submitCandidateAddResume.str_select_Languages.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Rdio_Language);
                    if (submitCandidateAddResume.str_select_Languages == "yes")
                    {
                        Thread.Sleep(1000);

                        kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Selectlanguage);

                        kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Selectlanguagechckbox);
                    }
                }
                else
                {
                    kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Rdio_Language);
                }

            }

            if (submitCandidateAddResume.str_Button_Save.ToLower().Trim() == Constants.SaveandContinue)
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Button_saveandcontinue_btnSubmit);
            }
            else
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Given Save button name unable to find";
                return results;
            }
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                return results;
            }
            //WDriver.FindElement(By.Id("btnSubmit")).Click();

            for (int z = 1; z < 10; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = driver.FindElement(By.XPath("//*[@id='PleaseWaitPopup']/div/table/tbody/tr/td")).Enabled;
                }
                catch
                {
                    strValue = true;
                }

                //  Console.WriteLine("z -----> " + z);
                //  Console.WriteLine("strValue -----> " + strValue);
                Thread.Sleep(1000);
                if (!strValue)
                {
                    break;
                }

            }

            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id("dvAfterSave"))));
            }
            catch
            {
                //
            }
            Boolean blndvAfterSave = false;
            try
            {
                blndvAfterSave = driver.FindElement(By.Id("dvAfterSave")).Displayed;
            }
            catch
            {
                blndvAfterSave = false;
            }

            if (!blndvAfterSave)
            {
                try
                {
                    blndvAfterSave = driver.FindElement(By.Id("dvAfterSave")).Displayed;
                }
                catch
                {
                    blndvAfterSave = false;
                }
            }

            results = kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, submitCandidateAddResume.str_Button_SaveConfirmOK);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(3000);
                try
                {
                    new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.PresenceOfAllElementsLocatedBy((By.Id("dvAfterSave"))));
                }
                catch
                {
                    //
                }
                results = kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, submitCandidateAddResume.str_Button_SaveConfirmOK);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, submitCandidateAddResume.str_Button_SaveConfirmOK);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = strErrMsg;
            return results;
        }


        public Result Mass_Upload_Candidate(IWebDriver WDriver, DataRow SubmitCandidate_Data)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            SubmitCandidateMethodModel submitCandidateMethodModel = createRequirementRepository.GetSubmitCandidateMethodData(SubmitCandidate_Data);


            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitCandidateMethodModel.strClientName + "_");
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
                results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitCandidateMethodModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //Thread.Sleep(000);
                    results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitCandidateMethodModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitCandidateMethodModel.strClientName + "_");
            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitCandidateMethodModel.strMainMenuLink, submitCandidateMethodModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitCandidateMethodModel.strMainMenuLink, submitCandidateMethodModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            //   objCommonMethods.SaveScreenShot_EachPage(WDriver, submitCandidateMethodModel.strClientName + "_");

            if (KeyWords.str_link_REQ_NUMBER != "")
            {

            }

            //   Thread.Sleep(10000);
            //   Thread.Sleep(5000);
            Boolean bFilterTxt = false;

            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.XPath(KeyWords.ID_Txt_Filter_HistoryTableViewSuppReqs_filter))));
            }
            catch
            {

                for (int iFTxt = 0; iFTxt < 100; iFTxt++)
                {
                    try
                    {
                        bFilterTxt = WDriver.FindElement(By.XPath(KeyWords.ID_Txt_Filter_HistoryTableViewSuppReqs_filter)).Enabled;
                    }
                    catch
                    {
                        bFilterTxt = false;
                    }
                    if (bFilterTxt)
                        break;
                }
            }
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtGolbalFilterReqs);
            results = kwm.sendText_XPath(WDriver, KeyWords.locator_XPath, KeyWords.ID_Txt_Filter_HistoryTableViewSuppReqs_filter, KeyWords.ID_Txt_txtGolbalFilterReqs, submitCandidateMethodModel.str_Link_ReqNumber, false);

            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.sendText_XPath(WDriver, KeyWords.locator_XPath, KeyWords.ID_Txt_Filter_HistoryTableViewSuppReqs_filter, KeyWords.ID_Txt_txtGolbalFilterReqs, submitCandidateMethodModel.str_Link_ReqNumber, false);

                if (results.Result1 == KeyWords.Result_FAIL)
                {

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtGolbalFilterReqs, submitCandidateMethodModel.str_Link_ReqNumber, false);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results.ErrorMessage = results.ErrorMessage + "," + " Problem Enter REQ Number in Search filed";
                        //   return results;
                    }
                }
            }
            //  objCommonMethods.SaveScreenShot_EachPage(WDriver, submitCandidateMethodModel.strClientName + "_");
            try
            {
                WDriver.FindElement(By.LinkText(submitCandidateMethodModel.str_Link_ReqNumber)).Click();
            }
            catch
            {
                Thread.Sleep(100);
                try
                {
                    WDriver.FindElement(By.LinkText(submitCandidateMethodModel.str_Link_ReqNumber)).Click();
                }
                catch
                {
                    // Console.WriteLine(bFlag);
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given Req not find " + submitCandidateMethodModel.str_Link_ReqNumber;
                    return results;
                }
            }

            string strSubLevel = "";
            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitCandidateMethodModel.strClientName + "_");
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitCandidateMethodModel.str_Link_SearchCandidate, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(10000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitCandidateMethodModel.str_Link_SearchCandidate, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            bFilterTxt = false;
            for (int iFTxt = 0; iFTxt < 100; iFTxt++)
            {
                try
                {
                    bFilterTxt = WDriver.FindElement(By.Id(KeyWords.ID_Txt_LastName)).Enabled;
                }
                catch
                {
                    kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitCandidateMethodModel.str_Link_SearchCandidate, strSubLevel);
                }
                if (bFilterTxt)
                {
                    break;
                    Thread.Sleep(3000);
                }
            }
            Thread.Sleep(3000);
            //--------------------------------------------------------------------------------------------------------------
            //// Last name

            //if (submitCandidateMethodModel.str_Txt_LastName != "")
            //{
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_LastName, submitCandidateMethodModel.str_Txt_LastName, false);
            //}
            //else
            //{
            //    results = kwm.GetNameFromReqNumber("LN", submitCandidateMethodModel.str_Link_ReqNumber);
            //    if (results.Result1 == KeyWords.Result_PASS)
            //    {
            //        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_LastName, results.ErrorMessage, false);
            //    }
            //}
            //Thread.Sleep(3000);
            //if (submitCandidateMethodModel.str_Txt_FirstName != "")
            //{
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_FirstName, submitCandidateMethodModel.str_Txt_FirstName, false);
            //}
            //else
            //{
            //    results = kwm.GetNameFromReqNumber("FN", submitCandidateMethodModel.str_Link_ReqNumber);
            //    if (results.Result1 == KeyWords.Result_PASS)
            //    {
            //        //  SubmitCandidate_Data["P12"] = results.ErrorMessage;
            //        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_FirstName, results.ErrorMessage, false);
            //    }
            //}

            //if (submitCandidateMethodModel.str_Txt_LocationCity != "")
            //{
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_LocationCity, submitCandidateMethodModel.str_Txt_LocationCity, false);
            //}

            //if (submitCandidateMethodModel.str_Select_State != "")
            //{
            //    kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_StateID, submitCandidateMethodModel.str_Select_State);
            //}

            //if (submitCandidateMethodModel.str_RadioButton_Available != "")
            //{
            //    if (submitCandidateMethodModel.str_RadioButton_Available.ToLower().Trim() == "yes")
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_RadioButton_AvailableStatus + "1");
            //    }

            //    if (submitCandidateMethodModel.str_RadioButton_Available.ToLower().Trim() == "no")
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_RadioButton_AvailableStatus + "0");
            //    }
            //}
            //if (submitCandidateMethodModel.str_Txt_ATSID != "")
            //{
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ATSIDField, submitCandidateMethodModel.str_Txt_ATSID, false);
            //}
            //if (submitCandidateMethodModel.str_Txt_Keywords != "")
            //{
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Keywords, submitCandidateMethodModel.str_Txt_Keywords, false);
            //}
            //if (submitCandidateMethodModel.str_Select_MyResumes != "")
            //{
            //    kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_MyResumesID, submitCandidateMethodModel.str_Select_MyResumes);
            //}
            //if (submitCandidateMethodModel.str_Button_Search.ToLower().Trim() == "search")
            //{
            //    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_refreshButton);
            //}
            //else
            //{
            //    results.Result1 = KeyWords.Result_FAIL;
            //    results.ErrorMessage = "Given Search button name unable to find";
            //    return results;
            //}

            //----------------------------------------------------------------------------------------

            Thread.Sleep(5000);

            // Click on Mass Upload Candidates Button
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.Id_Btn_UploadResumeBank);

            //// Click on Upload file
            // string strSubLevel1 = "";
            // results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitCandidateMethodModel.str_Link_UploadFile, strSubLevel1);
            // if (results.Result1 == KeyWords.Result_FAIL)
            // {
            //     Thread.Sleep(5000);
            //     results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitCandidateMethodModel.str_Link_UploadFile, strSubLevel1);
            //     if (results.Result1 == KeyWords.Result_FAIL)
            //     {
            //         return results;
            //     }
            // }


            // Upload path
            if (submitCandidateMethodModel.str_Link_UploadFile != "")
            {

                if (File.Exists(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateMethodModel.str_Txt_MassUploadFilePath))
                {
                    //if (submitCandidateMethodModel.str_BrowserName.ToLower() == Constants.Chrome)
                    //{
                    //    string strSubLevel1 = "";
                    //    results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitCandidateMethodModel.str_Link_UploadFile, strSubLevel1);

                    //}

                    string strSubLevel1 = "";
                    results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitCandidateMethodModel.str_Link_UploadFile, strSubLevel1);

                    // Thread.Sleep(3000);

                    try
                    {

                        // All belows actions to click on the upload icon
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Link_btnresumeupload);
                        Thread.Sleep(2000);

                        kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.xpath_Btn_FileUpload1);
                        Thread.Sleep(2000);

                        WDriver.FindElement(By.XPath("/html/body/div[12]")).Click();
                        WDriver.FindElement(By.Name("qqfile")).Click();


                        WDriver.FindElement(By.Name(KeyWords.NAME_Link_qqfile)).SendKeys(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateMethodModel.str_Txt_MassUploadFilePath);
                        Thread.Sleep(3000);
                        //  SendKeys.SendWait("By.Name(KeyWords.NAME_Link_qqfile)).SendKeys(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateMethodModel.str_Txt_MassUploadFilePath");
                        Thread.Sleep(2000);
                        System.Windows.Forms.SendKeys.SendWait("{ESC}");

                        //if (submitCandidateMethodModel.str_BrowserName.ToLower() == Constants.Chrome)
                        //{

                        //   System.Windows.Forms.SendKeys.SendWait("{ESC}");
                        //    Thread.Sleep(3000);

                        //}


                    }
                    catch (Exception upload)
                    {
                        string strUploaderror = upload.Message;
                    }
                }
                else
                {
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "The given file path not find" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateMethodModel.str_Txt_MassUploadFilePath, 3);
                }
            }

            //Comments
            if (submitCandidateMethodModel.str_Txt_Comment != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_Txt_Comment, submitCandidateMethodModel.str_Txt_Comment, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            // Click on Upload button
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_class, KeyWords.locator_class_button, submitCandidateMethodModel.str_Btn_Upload);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(3000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_class_button, submitCandidateMethodModel.str_Btn_Upload);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            // Confirmation popup with YES/NO
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitCandidateMethodModel.str_Btn_Yes_Action_MassUpload);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(3000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitCandidateMethodModel.str_Btn_Yes_Action_MassUpload);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            // Click on OK button
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitCandidateMethodModel.str_Btn_OK_MassUpload);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(13000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitCandidateMethodModel.str_Btn_OK_MassUpload);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(15000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitCandidateMethodModel.str_Btn_OK_MassUpload);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }

            // Click on Close button
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitCandidateMethodModel.str_Btn_Close_MassUpload);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(13000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitCandidateMethodModel.str_Btn_Close_MassUpload);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(15000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, submitCandidateMethodModel.str_Btn_Close_MassUpload);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitCandidateMethodModel.strClientName + "_");
            //Thread.Sleep(10000);
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_strSubmitCandidateSuccessfully;
            return results;
        }


        public Result Declinerequirement(IWebDriver WDriver, DataRow SubmitCandidate_Data, ExtentTest logTest, String TestScenario)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 10);

            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            //CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            //SubmitCandidateMethodModel submitCandidateMethodModel = createRequirementRepository.GetSubmitCandidateMethodData(SubmitCandidate_Data);
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            ScheduleInterviewModel Declinerequirementmodel = createRequirementRepository.GetScheduleInterviewModel(SubmitCandidate_Data);


            objCommonMethods.SaveScreenShot_EachPage(WDriver, Declinerequirementmodel.strClientName + "_");

            objCommonMethods.Action_Button_Escape(WDriver);

            //Client selection
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
                results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Declinerequirementmodel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //Thread.Sleep(000);
                    results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Declinerequirementmodel.strClientName);

                }
            }

            //Submenu click
            objCommonMethods.SaveScreenShot_EachPage(WDriver, Declinerequirementmodel.strClientName + "_");
            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Declinerequirementmodel.strMainMenuLink, Declinerequirementmodel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Declinerequirementmodel.strMainMenuLink, Declinerequirementmodel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, Declinerequirementmodel.strClientName + "_");


            Boolean bFilterTxt = false;


            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Supplier_Submitcandidate_Reqno), kwm._WDWait);

            //Req no passed into search
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Supplier_Submitcandidate_Reqno, Declinerequirementmodel.str_Txt_ReqNumber, false);
            //results = kwm.sendText_XPath(WDriver, KeyWords.locator_ID, KeyWords.ID_Supplier_Submitcandidate_Reqno, KeyWords.ID_Txt_txtGolbalFilterReqs, submitCandidateMethodModel.str_Link_ReqNumber, false);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.sendText_XPath(WDriver, KeyWords.locator_ID, KeyWords.ID_Supplier_Submitcandidate_Reqno, KeyWords.ID_Txt_txtGolbalFilterReqs, Declinerequirementmodel.str_Txt_ReqNumber, false);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results.ErrorMessage = results.ErrorMessage + "," + " Problem Enter REQ Number in Search filed";

                }

            }
            //Thread.Sleep(5000);
            //Requirement number click
            objCommonMethods.SaveScreenShot_EachPage(WDriver, Declinerequirementmodel.strClientName + "_");
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Link_Requirementnumber);


            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_SuplierDeclineAL), kwm._WDWait);
            //*[@class='reqDecline']
            if (kwm.isElementDisplayedByXPath(WDriver, KeyWords.Xpath_SuplierDeclineAL))
            {
                kwm.click_Xpath(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_SuplierDeclineAL);

                kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Select_Declinepopup), kwm._WDWait);

                //selecting drop down
                results = kwm.selectDropDown(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Declinepopup, Declinerequirementmodel.str_Select_Reason);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Declinepopup);

                }
                //add comment


                kwm.click_Xpath(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Decline_Button);

                //kwm.waitForElementToBeClickable(WDriver, By.XPath("//span[contains(text(),'Decline Requisition')]"), kwm._WDWait);
                Boolean t = kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_button_declineyes), kwm._WDWait);

                results = kwm.click_Xpath(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_button_declineyes);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(6000);
                    results = kwm.click_Xpath(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_button_declineyes);

                }

                Thread.Sleep(3000);
                kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_button_Decline_ok), kwm._WDWait);
                results = kwm.click_Xpath(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_button_Decline_ok);
            }

            else
            {

                kwm.waitforelementandclick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_RollbackDeclineAL, By.XPath(KeyWords.Xpath_RollbackDeclineAL), kwm._WDWait);

                //selecting drop down
                // kwm.selectDropDown(WDriver,KeyWords.locator_XPath,KeyWords.Xpath_RollbackDeclineAL,
                ///kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Declinepopup);

                results = kwm.selectDropDown(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Declinepopup, Declinerequirementmodel.str_Select_Reason);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Declinepopup);
                }


                //add commet
                kwm.sendText(WDriver, KeyWords.locator_XPath, "//textarea[@id='Comment']", Declinerequirementmodel.str_Text_comment, false, " ", "");

                kwm.click_Xpath(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_button_Rollbackdecline);
                //click on YES button
                results = kwm.waitforelementandclick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_button_rollbackdeclineYES, By.XPath(KeyWords.Xpath_button_rollbackdeclineYES), kwm._WDWait);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(3000);
                    results = kwm.waitforelementandclick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_button_rollbackdeclineYES, By.XPath(KeyWords.Xpath_button_rollbackdeclineYES), kwm._WDWait);

                }

                //click on ok button
                results = kwm.waitforelementandclick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_button_rollbackdeclineOK, By.XPath(KeyWords.Xpath_button_rollbackdeclineOK), kwm._WDWait);

            }


            return results;

        }


        public Result Addcandidatetoresumebank(IWebDriver WDriver, DataRow SubmitCandidate_Data, ExtentTest logTest, String TestScenario)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 10);

            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            SubmitCandidateMethodModel submitCandidateMethodModel = createRequirementRepository.GetSubmitCandidateMethodData(SubmitCandidate_Data);

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitCandidateMethodModel.strClientName + "_");

            objCommonMethods.Action_Button_Escape(WDriver);

            //Client selection
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
                results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitCandidateMethodModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //Thread.Sleep(000);
                    results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitCandidateMethodModel.strClientName);

                }
            }

            //navigate to main menu and click on resume bank 
            kwm.mouserovertomainmenu(WDriver);

            results = kwm.waitforelementandclick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_ResumeBanknavigation, By.XPath(KeyWords.Xpath_ResumeBanknavigation), kwm._WDWait);
            // results = kwm.click_Xpath(WDriver, KeyWords.locator_XPath, "//li[@aria-label='Resume Bank']//span");
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                //Thread.Sleep(000);
                return results;
            }

            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Button_Addcandidatetoresumebank);
            //Add resume button click

            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Button_Addcandidatetoresumebank);
            results = Add_Resume(WDriver, SubmitCandidate_Data);
            String lastname = results.ErrorMessage1;

            //waiting for the search 
            kwm.waitforelementandclick(WDriver, KeyWords.locator_ID, KeyWords.id_searchCandidatename_candidateName, By.Id(KeyWords.id_searchCandidatename_candidateName), kwm._WDWait);

            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.id_searchCandidatename_candidateName, results.ErrorMessage1, false, "", "");

            kwm.waitForElementInvisible(WDriver, By.XPath(KeyWords.Xpath_searchcandidate_secondrow), kwm._WDWait);

            String Candiadtefullname = kwm.GetText_Xpath(WDriver, KeyWords.Xpath_searchcandidate_firstrow)._Var;

            if (Candiadtefullname.Contains(lastname))
            {
                ReportHandler._getChildTest().Log(LogStatus.Pass, "Added candidate " + Candiadtefullname + "is populting in resumebank grid");

            }
            else
            {
                ReportHandler._getChildTest().Log(LogStatus.Fail, "Added candidate NOT populated in the Resume bank list " + Candiadtefullname);


            }

            var WriteExlResult = new Result();
            ReadExcel ReadExcelHelper = new ReadExcel();

            String strUpdateSqlMain4 = "Update [MSP$] set P8 ='" + Candiadtefullname + "'  WHERE P3 ='" + submitCandidateMethodModel.strClientName + "' and  TestCaseID <> '001' and  TestCaseID <> '003' and TestScenario ='" + TestScenario + "'";
            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain4);

            String strUpdateSqlMain5 = "Update [Supplier$] set P8 ='" + Candiadtefullname + "'  WHERE P3 ='" + submitCandidateMethodModel.strClientName + "' and  TestCaseID <> '004' and TestScenario ='" + TestScenario + "'";
            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain5);

            //added for supplier actions 

            String strUpdateSqlMain6 = "Update [Supplier$] set P61 ='" + Candiadtefullname + "'  WHERE P3 ='" + submitCandidateMethodModel.strClientName + "' and  TestCaseID = '004' and TestScenario ='" + TestScenario + "'";
            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain6);



            return results;


        }
        

        public Result WithdrawCandidate(IWebDriver WDriver, DataRow SubmitCandidate_Data, ExtentTest logTest, String TestScenario)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 30);

            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            //CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            //SubmitCandidateMethodModel submitCandidateMethodModel = createRequirementRepository.GetSubmitCandidateMethodData(SubmitCandidate_Data);

            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            ScheduleInterviewModel Schedule_Interview_Model = createRequirementRepository.GetScheduleInterviewModel(SubmitCandidate_Data);


            objCommonMethods.SaveScreenShot_EachPage(WDriver, Schedule_Interview_Model.strClientName + "_");

            //Client selection
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

                }
            }

            //Submenu click
            objCommonMethods.SaveScreenShot_EachPage(WDriver, Schedule_Interview_Model.strClientName + "_");
            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Schedule_Interview_Model.strMainMenuLink, Schedule_Interview_Model.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Schedule_Interview_Model.strMainMenuLink, Schedule_Interview_Model.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, Schedule_Interview_Model.strClientName + "_");


            //passing candidate name in to list 
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_Searchcandiadte_search), kwm._WDWait);
            String lastnamefromexcel = Schedule_Interview_Model.str_Txt_CandidateName.Split(',')[1].Substring(1, Schedule_Interview_Model.str_Txt_CandidateName.Split(',')[1].Length - 5);
            kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Searchcandiadte_search, lastnamefromexcel, false, "", "");
            Thread.Sleep(3000);
            //waiting for invisible of second row 
            kwm.waitForElementInvisible(WDriver, By.XPath(KeyWords.Xpath_searchcandidate_candidatespage_secondrow), kwm._WDWait);
            kwm.click_Xpath(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_searchcandidate_candidatespage_firstrow);
            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='pageTitle']"), kwm._WDWait);

            //list menu click 
            objCommonMethods.SaveScreenShot_EachPage(WDriver, Schedule_Interview_Model.strClientName + "_");
            String strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Schedule_Interview_Model.str_Link_Subcaniddates, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Schedule_Interview_Model.str_Link_Subcaniddates, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            //wait for the popup 

            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='WithdrawReason']"), kwm._WDWait);

            //selecting the reason and 
            results = kwm.selectDynamicDropdownByName(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Withdrwreason_WithdrawReason);

            if (results.Result1 == KeyWords.Result_FAIL)
            {
                kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Withdrwreason_WithdrawReason);

            }

            //click on withdraw button
            kwm.click_Xpath(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_button_withdraw);

            kwm.waitforelementandclick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_button_Withdraw_YES, By.XPath(KeyWords.Xpath_button_Withdraw_YES), kwm._WDWait);
            kwm.waitforelementandclick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_button_Withdraw_OK, By.XPath(KeyWords.Xpath_button_Withdraw_OK), kwm._WDWait);

            return results;

        }


        public Result Rollbackwithdrawncandidate(IWebDriver WDriver, DataRow SubmitCandidate_Data, ExtentTest logTest, String TestScenario)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);

            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            //CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            //SubmitCandidateMethodModel submitCandidateMethodModel = createRequirementRepository.GetSubmitCandidateMethodData(SubmitCandidate_Data);

            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            ScheduleInterviewModel Schedule_Interview_Model = createRequirementRepository.GetScheduleInterviewModel(SubmitCandidate_Data);


            objCommonMethods.SaveScreenShot_EachPage(WDriver, Schedule_Interview_Model.strClientName + "_");

            //Client selection
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

                }
            }

            //Submenu click
            objCommonMethods.SaveScreenShot_EachPage(WDriver, Schedule_Interview_Model.strClientName + "_");
            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Schedule_Interview_Model.strMainMenuLink, Schedule_Interview_Model.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, Schedule_Interview_Model.strMainMenuLink, Schedule_Interview_Model.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, Schedule_Interview_Model.strClientName + "_");


            //passing candidate name in to list 
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_Searchwithdrawncandidate), kwm._WDWait);

            String lastnamefromexcel = Schedule_Interview_Model.str_Txt_CandidateName.Split(',')[1].Substring(1, Schedule_Interview_Model.str_Txt_CandidateName.Split(',')[1].Length - 5);
            kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Searchwithdrawncandidate, lastnamefromexcel, false, "", "");
            Thread.Sleep(3000);
            //waiting for invisible of second row 
            kwm.waitForElementInvisible(WDriver, By.XPath(KeyWords.Xpath_searchWithdrawn_secondrow), kwm._WDWait);
            kwm.click_Xpath(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Searchwithdrawn_firstrow);
            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='pageTitle']"), kwm._WDWait);

            //list menu click 
            objCommonMethods.SaveScreenShot_EachPage(WDriver, Schedule_Interview_Model.strClientName + "_");
            String strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Schedule_Interview_Model.str_Link_Subcaniddates, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, Schedule_Interview_Model.str_Link_Subcaniddates, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            //wait for the popup 

            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='WithdrawReason']"), kwm._WDWait);

            //selecting the reason and 
            //results = kwm.selectDynamicDropdownByName(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Withdrwreason_WithdrawReason);
            results = kwm.selectDropDown(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Withdrwreason_WithdrawReason, Schedule_Interview_Model.str_Select_Reason);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Withdrwreason_WithdrawReason);

            }

            //click on withdraw button
            kwm.click_Xpath(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_button_withdraw);

            kwm.waitforelementandclick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_button_Withdraw_YES, By.XPath(KeyWords.Xpath_button_Withdraw_YES), kwm._WDWait);
            results = kwm.waitforelementandclick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_button_Withdraw_OK, By.XPath(KeyWords.Xpath_button_Withdraw_OK), kwm._WDWait);

            return results;





        }


        public Result SubmitCandidate_SaveasDraft(IWebDriver WDriver, DataRow SubmitCandidate_SaveasDraft, ExtentTest logTest, String TestScenario)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);

            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            SubmitCandidateMethodModel submitCandidateMethodModel = createRequirementRepository.GetSubmitCandidateMethodData(SubmitCandidate_SaveasDraft);

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitCandidateMethodModel.strClientName + "_");

            //Client selection
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
                results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitCandidateMethodModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //Thread.Sleep(000);
                    results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitCandidateMethodModel.strClientName);

                }
            }

            //Submenu click
            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitCandidateMethodModel.strClientName + "_");
            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitCandidateMethodModel.strMainMenuLink, submitCandidateMethodModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitCandidateMethodModel.strMainMenuLink, submitCandidateMethodModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitCandidateMethodModel.strClientName + "_");


            Boolean bFilterTxt = false;


            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Supplier_Submitcandidate_Reqno), kwm._WDWait);

            //Req no passed into search
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Supplier_Submitcandidate_Reqno, submitCandidateMethodModel.str_Link_ReqNumber, false);
            //results = kwm.sendText_XPath(WDriver, KeyWords.locator_ID, KeyWords.ID_Supplier_Submitcandidate_Reqno, KeyWords.ID_Txt_txtGolbalFilterReqs, submitCandidateMethodModel.str_Link_ReqNumber, false);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.sendText_XPath(WDriver, KeyWords.locator_ID, KeyWords.ID_Supplier_Submitcandidate_Reqno, KeyWords.ID_Txt_txtGolbalFilterReqs, submitCandidateMethodModel.str_Link_ReqNumber, false);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results.ErrorMessage = results.ErrorMessage + "," + " Problem Enter REQ Number in Search filed";

                }

            }
            //Thread.Sleep(5000);
            //Requirement number click
            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitCandidateMethodModel.strClientName + "_");
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Link_Requirementnumber);

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            //Search candidate
            string strSubLevel = "";
            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitCandidateMethodModel.strClientName + "_");
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitCandidateMethodModel.str_Link_SearchCandidate, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, submitCandidateMethodModel.str_Link_SearchCandidate, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Txt_LastName), kwm._WDWait);

            //Search Button click

            // kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Buttons_Search);

            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_Button_Addcandidatetoresumebank), kwm._WDWait);

            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Button_Addcandidatetoresumebank);
            //Add resume button click

            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Button_Addcandidatetoresumebank);
            results = Add_Resume(WDriver, SubmitCandidate_SaveasDraft);


            // Wait until candidate name displayed
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_btn_SaveasDraftandClose_btnSave), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_btn_SaveasDraftandClose_btnSave), kwm._WDWait);

            //Save as Draft Button 
            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_SaveasDraftandClose_btnSave);

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_btn_SaveasDraftandClose_btnSave), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_btn_SaveasDraftandClose_btnSave), kwm._WDWait);

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitCandidateMethodModel.strClientName + "_");
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(10000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                    //return results;
                }
            }

            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_strSubmitCandidateSuccessfully;
            return results;
        }

        public Result SubmitCandidate_DraftEditandSubmit(IWebDriver WDriver, DataRow SubmitCandidate_DraftEditandSubmit, ExtentTest logTest, String TestScenario)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);

            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            SubmitCandidateMethodModel submitCandidateMethodModel = createRequirementRepository.GetSubmitCandidateMethodData(SubmitCandidate_DraftEditandSubmit);

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitCandidateMethodModel.strClientName + "_");

            //Client selection
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
                results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitCandidateMethodModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //Thread.Sleep(000);
                    results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitCandidateMethodModel.strClientName);

                }
            }

            //Submenu click
            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitCandidateMethodModel.strClientName + "_");
            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitCandidateMethodModel.strMainMenuLink, submitCandidateMethodModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, submitCandidateMethodModel.strMainMenuLink, submitCandidateMethodModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitCandidateMethodModel.strClientName + "_");


            Boolean bFilterTxt = false;


            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Txt_SearchCand), kwm._WDWait);


            //Candidate Name 
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_SearchCand, submitCandidateMethodModel.str_Txt_SearchCand, false);
            //results = kwm.sendText_XPath(WDriver, KeyWords.locator_ID, KeyWords.ID_Supplier_Submitcandidate_Reqno, KeyWords.ID_Txt_txtGolbalFilterReqs, submitCandidateMethodModel.str_Link_ReqNumber, false);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_SearchCand, submitCandidateMethodModel.str_Txt_SearchCand, false);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results.ErrorMessage = results.ErrorMessage + "," + " Problem Enter REQ Number in Search filed";

                }

            }

            //Requirement 
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_DraftRequirementNUmber_CLSRNumber, submitCandidateMethodModel.str_DraftRequirementNUmber_CLSRNumber, false);
            //results = kwm.sendText_XPath(WDriver, KeyWords.locator_ID, KeyWords.ID_Supplier_Submitcandidate_Reqno, KeyWords.ID_Txt_txtGolbalFilterReqs, submitCandidateMethodModel.str_Link_ReqNumber, false);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_DraftRequirementNUmber_CLSRNumber, submitCandidateMethodModel.str_DraftRequirementNUmber_CLSRNumber, false);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results.ErrorMessage = results.ErrorMessage + "," + " Problem Enter REQ Number in Search filed";

                }

            }


            //Thread.Sleep(5000);
            //Requirement number click
            objCommonMethods.SaveScreenShot_EachPage(WDriver, submitCandidateMethodModel.strClientName + "_");
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Link_Draftsubmission);

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_DraftRequirementNUmber_CLSRNumber), kwm._WDWait);
            results = Submit_Resume_details(WDriver, SubmitCandidate_DraftEditandSubmit, logTest, TestScenario);








            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_strSubmitCandidateSuccessfully;
            return results;
        }

       


    }
}