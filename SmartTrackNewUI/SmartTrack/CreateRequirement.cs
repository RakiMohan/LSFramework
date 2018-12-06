// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateRequirement.cs" company="DCR Workforce Inc">
//   Copyright (c) DCR Workforce Inc. All rights reserved.
//   This code and information should not be copied and used outside of DCR Workforce Inc.
// </copyright>
// <summary>
//  This Constants is used
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using SmartTrack.DataAccess.Models;
using SmartTrack.DataAccess.Repository;
using SmartTrack;
namespace SmartTrack_Automation
{
    using System;
    using OpenQA.Selenium;
    using System.Threading;
    using System.Data;
    using System.Collections;
    using System.Diagnostics;
    using OpenQA.Selenium.Support.UI;
    using OpenQA.Selenium.Interactions;
    using CommonFiles;
    using System.Collections.Generic;
    using RelevantCodes.ExtentReports;


    // [TestClass]
    public class CreateRequirement : IRepoBuilder
    {
        IWebDriver WDriver;
        CreateRequirementModel createRequirementModel;
        @ReadExcel ReadExcelHelper = new ReadExcel();
        //public KeyWordMethods kwm = new KeyWordMethods();

        CommonMethods objCommonMethods;
        Result results;
        List<string> listExistClients;
        DataRow Req_Data;
        KeyWordMethods kwm;
        
        //public KeyWordMethods kwmd = getKWM();
        public CreateRequirement(IWebDriver _WDriver, KeyWordMethods _kwm, CommonMethods _cmn,DataRow dr)
        {
            this.WDriver = _WDriver;
            this.kwm = _kwm;
            this.objCommonMethods = _cmn;
            this.Req_Data = dr;
            buildRepository(dr);
            setWebdriverWait();
            objCommonMethods = new CommonMethods();
            results = new Result();
            listExistClients = new List<string>();
        }

        public CreateRequirement()
        {

            throw new ArgumentNullException("instantiate the parameterised constructor of this class");          
            
        }
        
        public void CreateReqExec()
        {

            Console.WriteLine("Create Requirement");
        }

        public Result Create_Requirement(IWebDriver WDriver, DataRow REQ_Data)
        {
            //@ReadExcel ReadExcelHelper = new ReadExcel();
            //KeyWordMethods kwm = new KeyWordMethods();
            //CommonMethods objCommonMethods = new CommonMethods();
            //var results = new Result();
            //List<string> listExistClients = new List<string>();
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
            createRequirementModel = createRequirementRepository.GetCreateRequirementData(REQ_Data);
            //   CreateRequirementModel createRequirementModel = createRequirementRepository.GetCreateRequirementData(REQ_Data, REQ_DataL);
            //CreateRequirementModel createRequirementModelLabel = createRequirementRepository.GetCreateRequirementData(REQ_DataL);
            // CreateRequirementModel createRequirementModel = createRequirementRepository.GetCreateRequirementData(REQ_Data);


            //     CreateRequirementRepositoryLabel createRequirementRepositoryLabel = new CreateRequirementRepositoryLabel();
            //     CreateRequirementModelLabel createRequirementModelLabel = createRequirementRepositoryLabel.GetCreateRequirementData(REQ_DataL);
            var Questions_Data = new Result();

            //Client selection


            listExistClients = new List<string>() { Constants.Discover };
            if (listExistClients.Contains(createRequirementModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strClientName);
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
            if (!listExistClients.Contains(createRequirementModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strClientName);
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

            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");
            //Submenu


            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strMainMenuLink, createRequirementModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(1000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strMainMenuLink, createRequirementModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot(WDriver, createRequirementModel.strClientName + "_");
            // kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_Btn_ETKYes_confirmationBypassETKDialog), kwm._WDWait);

            // objCommonMethods.ChooseETK(WDriver, createRequirementModel.strNewRequisition);

            // objCommonMethods.ChooseETK(WDriver, createRequirementModel.strSelectRequisitionType, createRequirementModel.str_btn_ETKOption, kwm._WDWait);

            // kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_ETKpopup_yes);
            //Select Requisition

            //kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[text()='" + createRequirementModel.strSelectRequisitionType + "']"), kwm._WDWait);
            //kwm.select_RequisitionType(WDriver, createRequirementModel.strSelectRequisitionType);

            // Identified candidate 
            if (createRequirementModel.strSelectRequisitionType.ToLower().Contains("identified") || createRequirementModel.strSelectRequisitionType.ToLower().Contains("payrolled"))
            {
                kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[text()='" + createRequirementModel.strSelectRequisitionType + "']"), kwm._WDWait);
                kwm.select_RequisitionType(WDriver, createRequirementModel.strSelectRequisitionType);

                kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_btn_NewIdentifiedCandidate_btnNewCandidate), kwm._WDWait);
                kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_btn_NewIdentifiedCandidate_btnNewCandidate), kwm._WDWait);
                Thread.Sleep(500);
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_NewIdentifiedCandidate_btnNewCandidate);
            }
            else
            {
                kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@class='instedEM' and text()='" + createRequirementModel.strSelectRequisitionType + "']"), kwm._WDWait);
                kwm.select_RequisitionType(WDriver, createRequirementModel.strSelectRequisitionType);
            }

            //Create New Requistion
            kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[text()='" + createRequirementModel.strNewRequisition + "']"), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[text()='" + createRequirementModel.strNewRequisition + "']"), kwm._WDWait);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[text()='" + createRequirementModel.strNewRequisition + "']");
            Thread.Sleep(500);
            kwm.select_RequisitionType(WDriver, createRequirementModel.strNewRequisition);



            CreateRequirement_Clients(WDriver, createRequirementModel, kwm, results, objCommonMethods);

            //// Justification tab for Identified candidate requisition -- works only for Identified candidate
            //if (createRequirementModel.strSelectRequisitionType.ToLower().Contains("identified") || createRequirementModel.strSelectRequisitionType.ToLower().Contains("payrolled"))
            //{

            //    CreateRequirementPerClientJobTab.IdentifiedRequirementJustification(createRequirementModel, results, kwm, WDriver, objCommonMethods);

            //}
            //else
            //{
            //    //Pre screen questions
            //    kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Button_PrescreenQuestion_guidelines_guidelineAccepted), kwm._WDWait);
            //    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_PrescreenQuestion_guidelines_guidelineAccepted, KeyWords.Type_Button);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Button_PrescreenQuestion_guidelines_guidelineAccepted), kwm._WDWait);
            //        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_PrescreenQuestion_guidelines_guidelineAccepted, KeyWords.Type_Button);

            //    }
            //}


            //if (createRequirementModel.strSelectRequisitionType.ToLower().Contains("identified") || createRequirementModel.strSelectRequisitionType.ToLower().Contains("payrolled"))
            //{
            //    kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_btn_JustificationSaveandContinue_btnCandidateSaveAndContinue), kwm._WDWait);
            //    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_JustificationSaveandContinue_btnCandidateSaveAndContinue);
            //    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_JustificationSaveandContinue_btnCandidateSaveAndContinue);
            //}



            //Thread.Sleep(2000);
            //objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strBrowserName + "_");
            ////Requirement submit tab
            ////    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ReviewSubmit);
            //kwm.waitForElementExists(WDriver, By.Id(KeyWords.ID_WorkFlow_workflowContainer), kwm._WDWait);
            ////kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_WorkFlow_workflowContainer), kwm._WDWait);
            //Thread.Sleep(2000);
            //kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Button_ReviewSubmit), kwm._WDWait);
            //kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ReviewSubmit);
            //Thread.Sleep(2000);
            //results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ReviewSubmit, KeyWords.Type_Button);
            //if (results.Result1 == KeyWords.Result_FAIL)
            //{
            //    kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Button_ReviewSubmit), kwm._WDWait);
            //    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ReviewSubmit);

            //    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ReviewSubmit, KeyWords.Type_Button);
            //}
            ////Get the Requirement number

            //objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strBrowserName + "_");


            //for (int req = 0; req < 30; req++)
            //{
            //    results = kwm.Get_Req_Number(WDriver, KeyWords.locator_class, KeyWords.ID_link_txt_Req_Number);
            //    if ((results.Result1 == KeyWords.Result_PASS) && (results.ErrorMessage1 != ""))
            //    {
            //        KeyWords.str_link_REQ_NUMBER = results.ErrorMessage;
            //        results.ErrorMessage1 = results.ErrorMessage;
            //        results.ErrorMessage = results.ErrorMessage + " " + KeyWords.MSG_strCreateRequirementssuccessfully;
            //        // return results;
            //        break;
            //    }
            //    Thread.Sleep(1000);
            //    if (req > 5)
            //    {
            //        if (kwm.isElementPresent(WDriver, KeyWords.ID_Error_ulMspUserError))
            //        {
            //            break;
            //        }
            //    }
            //}
            if (kwm.isElementPresent(WDriver, KeyWords.ID_Error_ulMspUserError))
            {
                results = kwm.Error_Msg_Read(WDriver, KeyWords.locator_ID, KeyWords.ID_Error_ulMspUserError);
                if (results.Result1 == KeyWords.Result_PASS)
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    if (results.ErrorMessage == "")
                    {
                        results.ErrorMessage = KeyWords.MSG_strRequirementNumberNotCreated;
                    }
                }
                return results;
            }

            if (createRequirementModel.strSelectRequisitionType.ToLower().Contains("identified") || createRequirementModel.strSelectRequisitionType.ToLower().Contains("payrolled"))
            {
                // Click on Main menu and sub memnu click (Administration --> Supplier User Management)
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, "Administration", "Supplier User Management");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(1000);
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, "Administration", "Supplier User Management");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }

                //Enter supplier name in supplier text box
                kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_txt_Supplier_TxtSupplier), kwm._WDWait);
                kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_txt_Supplier_TxtSupplier), kwm._WDWait);
                // commented icecream related code
                // kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_Supplier_TxtSupplier,createRequirementModel.str_Select_Supplier_supplierName, false);


                // Click on Search button
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_Searchbutton_DefaultContent_Lblsrch);


                // Get Supplier mail id and paste it in to excel file
                try
                {
                    kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_Link_SearchResults_SupplierUser), kwm._WDWait);
                    kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_Link_SearchResults_SupplierUser), kwm._WDWait);
                    Thread.Sleep(1000);
                    objCommonMethods.Action_Page_Down(WDriver);
                    Thread.Sleep(500);

                    // Get first page suppliers count
                    int SuppliersCount = WDriver.FindElements(By.XPath(KeyWords.XPath_Link_SearchResults_SupplierUser)).Count;
                    for (int i = 1; i <= SuppliersCount; i++)
                    {
                        var WriteExlResult = new Result();
                        string SupplierName = WDriver.FindElement(By.XPath("//table[@id='dgrSupplierusers']//tr[" + i + "]/td[2]")).Text;
                        if (SupplierName.Contains("@hcmondemand.net"))
                        {
                            String strUpdateSqlMain2 = "Update [Supplier$] set P1 ='" + SupplierName + "'  WHERE P3 ='" + "Google" + "' and TestScenario ='" + "004" + "'";
                            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain2);
                            break;
                        }
                    }

                }
                catch (Exception e)
                {
                    // results.ErrorMessage = "No such user(" + createRequirementModel.str_Select_Supplier_supplierName + ") is available with the given data";
                    objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");
                    results.Result1 = KeyWords.Result_FAIL;
                    return results;
                }



            }

            //Thread.Sleep(5000);
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_strCreateRequirementssuccessfully;
            return results;
        }

        public Result Requirement_SaveAsDraft(IWebDriver WDriver, DataRow REQ_Data)
        {
            var results = new Result();
            try
            {
                CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
                kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
                createRequirementModel = createRequirementRepository.GetCreateRequirementData(REQ_Data);
                //   CreateRequirementModel createRequirementModel = createRequirementRepository.GetCreateRequirementData(REQ_Data, REQ_DataL);
                //CreateRequirementModel createRequirementModelLabel = createRequirementRepository.GetCreateRequirementData(REQ_DataL);
                // CreateRequirementModel createRequirementModel = createRequirementRepository.GetCreateRequirementData(REQ_Data);


                //     CreateRequirementRepositoryLabel createRequirementRepositoryLabel = new CreateRequirementRepositoryLabel();
                //     CreateRequirementModelLabel createRequirementModelLabel = createRequirementRepositoryLabel.GetCreateRequirementData(REQ_DataL);
                var Questions_Data = new Result();

                //Client selection


                listExistClients = new List<string>() { Constants.Discover };
                if (listExistClients.Contains(createRequirementModel.strClientName.ToLower()))
                {
                    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(5000);
                        results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strClientName);
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
                if (!listExistClients.Contains(createRequirementModel.strClientName.ToLower()))
                {
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(5000);
                        results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strClientName);
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

                objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");
                //Submenu


                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strMainMenuLink, createRequirementModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(1000);
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strMainMenuLink, createRequirementModel.strSubMenuLink);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
                kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@class='instedEM' and text()='" + createRequirementModel.strSelectRequisitionType + "']"), kwm._WDWait);
                kwm.select_RequisitionType(WDriver, createRequirementModel.strSelectRequisitionType);
                //Create New Requistion
                kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[text()='" + createRequirementModel.strNewRequisition + "']"), kwm._WDWait);
                kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[text()='" + createRequirementModel.strNewRequisition + "']"), kwm._WDWait);
                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[text()='" + createRequirementModel.strNewRequisition + "']");
                Thread.Sleep(500);
                kwm.select_RequisitionType(WDriver, createRequirementModel.strNewRequisition);

                objCommonMethods.SaveScreenShot(WDriver, createRequirementModel.strClientName + "_");
                kwm.waitForPageToLoad(WDriver, kwm._WDWait);
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_tab_JobDescription);
                kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle), kwm._WDWait);
                //Job Title
                if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
                {
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
                    //  Thread.Sleep(2000);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, "a");
                            // return results;
                        }
                    }
                }

                kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_T2_Button_SaveAsDraftAndClose_btnJobSaveAndClose), kwm._WDWait);

                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Button_SaveAsDraftAndClose_btnJobSaveAndClose);

                kwm.waitForPageToLoad(WDriver, kwm._WDWait);



            }
            catch (Exception e)
            {

            }
            return results;

        }

        public void Requirement_EditDraft(IWebDriver WDriver, DataRow REQ_Data)
        {

            try
            {
                KeyWordMethods kwm = new KeyWordMethods();
                CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
                kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
                CreateRequirementModel createRequirementModel = createRequirementRepository.GetCreateRequirementData(REQ_Data);
                //Requirements In Progress page
                if (kwm.isElementDisplayedXpath(WDriver, KeyWords.XPATH_H1_Title_RequirementInProgress))
                {
                    if (!kwm.isElementDisplayedXpath(WDriver, KeyWords.XPATH_AlertMessage_ReqInProgress))
                    {
                        kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPATH_Txt_Search_RequirementsInProgress), kwm._WDWait);
                        kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Txt_Search_RequirementsInProgress, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, false);

                        if (kwm.isElementDisplayedXpath(WDriver, "//table[@id='HistoryTableViewProgReg']//tbody//tr[1]"))
                        {
                            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_Link_ContinueToEdit), kwm._WDWait);
                            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Link_ContinueToEdit);
                            ReportHandler._getChildTest().Log(LogStatus.Pass, "Clicked on Edit icon successfully");
                        }
                        else
                        {
                            ReportHandler._getChildTest().Log(LogStatus.Fail, "No Records available for the given search");
                        }
                    }
                    else
                    {
                        ReportHandler._getChildTest().Log(LogStatus.Fail, "No Requirement in draft" + kwm.GetText_Xpath(WDriver, KeyWords.XPATH_AlertMessage_ReqInProgress)._Var);
                    }

                }
            }
            catch (Exception e)
            {
                ReportHandler._getChildTest().Log(LogStatus.Error, e.Message);

            }
        }

        public void Requirement_DeleteDraft(IWebDriver WDriver, DataRow REQ_Data)
        {
            try
            {
                KeyWordMethods kwm = new KeyWordMethods();
                CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
                kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
                CreateRequirementModel createRequirementModel = createRequirementRepository.GetCreateRequirementData(REQ_Data);
                //Requirements In Progress page
                if (kwm.isElementDisplayedXpath(WDriver, KeyWords.XPATH_H1_Title_RequirementInProgress))
                {
                    if (!kwm.isElementDisplayedXpath(WDriver, KeyWords.XPATH_AlertMessage_ReqInProgress))
                    {
                        kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPATH_Txt_Search_RequirementsInProgress), kwm._WDWait);
                        kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Txt_Search_RequirementsInProgress, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, false);

                        if (kwm.isElementDisplayedXpath(WDriver, "//table[@id='HistoryTableViewProgReg']//tbody//tr[1]"))
                        {
                            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_Link_ContinueToDelete);
                            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPATH_DeleteDraft_Popup_Btn_Yes), kwm._WDWait);
                            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_DeleteDraft_Popup_Btn_Yes);
                            ReportHandler._getChildTest().Log(LogStatus.Pass, "Deleted the requirement draft successfully");
                        }
                        else
                        {
                            ReportHandler._getChildTest().Log(LogStatus.Fail, "No Records available for the given search");
                        }
                    }
                    else
                    {
                        ReportHandler._getChildTest().Log(LogStatus.Fail, "No Requirement in draft" + kwm.GetText_Xpath(WDriver, KeyWords.XPATH_AlertMessage_ReqInProgress)._Var);
                    }

                }
            }
            catch (Exception e)
            {
                ReportHandler._getChildTest().Log(LogStatus.Error, e.Message);
            }

        }

        public Result CreateRequirementFromDraft(IWebDriver WDriver, DataRow REQ_Data)
        {
            var results = new Result();
            try
            {
                Requirement_SaveAsDraft(WDriver, REQ_Data);
                ReportHandler._getChildTest().Log(ReportHandler._getChildTest().GetCurrentStatus(), "Save as Draft: " + ReportHandler._getChildTest().GetCurrentStatus().ToString());
                Requirement_EditDraft(WDriver, REQ_Data);
                ReportHandler._getChildTest().Log(ReportHandler._getChildTest().GetCurrentStatus(), "Edit Draft : " + ReportHandler._getChildTest().GetCurrentStatus().ToString());
                CreateRequirement_Clients(WDriver, createRequirementModel, kwm, results, objCommonMethods);
                ReportHandler._getChildTest().Log(ReportHandler._getChildTest().GetCurrentStatus(), "Create Requirement : " + ReportHandler._getChildTest().GetCurrentStatus().ToString());
                results.Result1 = ReportHandler._getChildTest().GetCurrentStatus().ToString();

            }
            catch (Exception e)
            {
                results.Result1 = KeyWords.Result_FAIL;
                ReportHandler._getChildTest().Log(LogStatus.Error, e.Message);
            }
            return results;
        }

        public Result DraftRequirement_Delete(IWebDriver WDriver, DataRow REQ_Data)
        {
            var results = new Result();
            try
            {
                Requirement_SaveAsDraft(WDriver, REQ_Data);
                ReportHandler._getChildTest().Log(ReportHandler._getChildTest().GetCurrentStatus(), " Save as Draft : " + ReportHandler._getChildTest().GetCurrentStatus().ToString());
                Requirement_DeleteDraft(WDriver, REQ_Data);
                ReportHandler._getChildTest().Log(ReportHandler._getChildTest().GetCurrentStatus(), " Delete Draft : " + ReportHandler._getChildTest().GetCurrentStatus().ToString());
                results.Result1 = ReportHandler._getChildTest().GetCurrentStatus().ToString();

            }
            catch (Exception e)
            {
                results.Result1 = KeyWords.Result_FAIL;
                ReportHandler._getChildTest().Log(LogStatus.Error, e.Message);
            }
            return results;

        }

        public Result CreateRequirement_Clients(IWebDriver WDriver, CreateRequirementModel createRequirementModel, KeyWordMethods kwm, Result results, CommonMethods objCommonMethods)
        {
            //var results = new Result();
            switch (createRequirementModel.strClientName.ToLower().ToString())
            {

                case Constants.SunTrust:
                    {
                        CreateRequirementPerClient.ClientRequirementSunTrust(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.ClientRequirementSunTrust(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Colgate:
                    {
                        CreateRequirementPerClient.ClientRequirementColgate(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.ClientRequirementColgate(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Ryder:
                    {
                        CreateRequirementPerClient.ClientRequirementRyder(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont);
                        CreateRequirementPerClientJobTab.CreateRequirementRyder(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Cpchem:
                    {
                        CreateRequirementPerClient.ClientRequirementCpchem(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.ClientRequirementCpchem(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Caesars:
                    {
                        CreateRequirementPerClient.ClientRequirementCaesars(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementCaesars(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Dyncorp:
                    {
                        CreateRequirementPerClient.ClientRequirementDyncorp(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementDyncorp(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Keybank:
                    {
                        CreateRequirementPerClient.ClientRequirementKeybank(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.ClientRequirementKeybank(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                case Constants.Altria:
                    {
                        CreateRequirementPerClient.ClientRequirementAltria(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.ClientRequirementKeybank(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Discover:
                    {
                        CreateRequirementPerClient.ClientRequirementDiscover(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementDiscover(createRequirementModel, results, kwm, WDriver, objCommonMethods);

                        break;
                    }

                case Constants.Welchallyn:
                    {
                        CreateRequirementPerClient.ClientRequirementWelchallyn(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementWelchallyn(createRequirementModel, results, kwm, WDriver, objCommonMethods);

                        break;
                    }

                case Constants.KCPL:
                    {
                        CreateRequirementPerClient.ClientRequirementKCPL(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementKCPL(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Tesla:
                    {
                        CreateRequirementPerClient.ClientRequirementTesla(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.ClientRequirementTesla(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Epri:
                    {
                        CreateRequirementPerClient.ClientRequirementEpri(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementEpri(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.EBS:
                    {
                        CreateRequirementPerClient.ClientRequirementEBS(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementEBSClient(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                case Constants.APS:
                    {
                        CreateRequirementPerClient.ClientRequirementAPS(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementAPS(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;

                    }

                case Constants.HillRom:
                    {
                        //   CreateRequirementPerClient.ClientRequirementHillRom(createRequirementModel, results, kwm, WDriver, objCommonMethods, createRequirementModelLabel);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        //   CreateRequirementPerClientJobTab.ClientRequirementHillRom(createRequirementModel, results, kwm, WDriver, objCommonMethods, createRequirementModelLabel);
                        break;
                    }

                case Constants.SOF:
                    {
                        CreateRequirementPerClient.ClientRequirementSOF(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementSOF(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                case Constants.Sts:
                    {
                        CreateRequirementPerClient.ClientRequirementSTS(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.ClientRequirementSTS(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                case Constants.StewartTitle:
                    {
                        CreateRequirementPerClient.ClientRequirementStewartTitle(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementStewartTitle(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.ThermoFisher:
                    {
                        CreateRequirementPerClient.ClientRequirementThermoFisher(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementThermoFisher(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.RMS:
                    {
                        CreateRequirementPerClient.ClientRequirementRMS(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementRMS(createRequirementModel, results, kwm, WDriver, objCommonMethods);


                        break;

                    }
                case Constants.QuickenLoans:
                    {
                        CreateRequirementPerClient.ClientRequirementQuickenLoans(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementQuickenLoans(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                case Constants.MFC:
                    {
                        CreateRequirementPerClient.ClientRequirementMFC(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementMFC(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                case Constants.Bimbo:
                    {
                        CreateRequirementPerClient.ClientRequirementBimbo(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementBimbo(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Georgetown:
                    {
                        CreateRequirementPerClient.ClientRequirementGeorgeTown(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementGeorgetown(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                case Constants.COE:
                    {
                        CreateRequirementPerClient.ClientRequirementCOE(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementCOE(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Tufts:
                    {
                        CreateRequirementPerClient.ClientRequirementTufts(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.ClientRequirementTufts(createRequirementModel, results, kwm, WDriver, objCommonMethods);


                        break;

                    }
                case Constants.PHHMortgage:
                    {
                        CreateRequirementPerClient.ClientRequirementPhhMortgage(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.ClientRequirementPHHMortgage(createRequirementModel, results, kwm, WDriver, objCommonMethods);


                        break;

                    }
                case Constants.STGEN:
                    {
                        CreateRequirementPerClient.ClientRequirementSTGEN(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementSTGEN(createRequirementModel, results, kwm, WDriver, objCommonMethods);


                        break;

                    }
                case Constants.Supervalu:
                    {
                        CreateRequirementPerClient.ClientRequirementSupervalu(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementSupervalu(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                case Constants.EMERSON:
                    {
                        CreateRequirementPerClient.ClientRequirementEmerson(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementEmerson(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Arkema:
                    {
                        CreateRequirementPerClient.ClientRequirementArkema(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementArkema(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.SallieMae:
                    {
                        CreateRequirementPerClient.ClientRequirementSallieMae(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementSallieMae(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                case Constants.STTM:
                    {
                        CreateRequirementPerClient.ClientRequirementSTTM(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementSTTM(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.YP:
                    {
                        CreateRequirementPerClient.ClientRequirementYP(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementYP(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Lear:
                    {
                        CreateRequirementPerClient.ClientRequirementLear(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementLear(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.EQT:
                    {
                        CreateRequirementPerClient.ClientRequirementEQT(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont);
                        CreateRequirementPerClientJobTab.ClientRequirementEQT(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.SIGMA:
                    {
                        CreateRequirementPerClient.ClientRequirementSIGMA(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont);
                        CreateRequirementPerClientJobTab.CreateRequirementSIGMA(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            objCommonMethods.SaveScreenShot(WDriver, createRequirementModel.strBrowserName + "_");

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Assignment_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);

            //Manjusha Added Code Estimated Contraced Value calculation
            //Number of resuroses write into excel in Offer to hire , extend offer, confirm cw
            results = kwm.GetText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources);
            KeyWords.numofresources = results.ErrorMessage;
            String strUpdateSqlMain_noofresources = "Update [MSP$] set P77 ='" + KeyWords.numofresources + "'  WHERE P3 ='" + createRequirementModel.strClientName + "' and TestScenario ='001' and TestCaseID = '007'";
            results = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain_noofresources);


            //Date difference is enter in excel
            KeyWords.date = results.ErrorMessage;
            String strUpdateSqlMain_Date = "Update [MSP$] set P85 ='" + createRequirementModel.str_T1_Date_EndDate_enddate + "'  WHERE P3 ='" + createRequirementModel.strClientName + "' and TestScenario ='001' and TestCaseID = '007'";
            results = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain_Date);


            //Extend offer

            String strUpdateSqlMain_noofresourcesEO = "Update [MSP$] set P78 ='" + KeyWords.numofresources + "'  WHERE P3 ='" + createRequirementModel.strClientName + "' and TestScenario ='001' and TestCaseID = '051'";
            results = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain_noofresourcesEO);

            //Date difference is enter in excel
            KeyWords.date = results.ErrorMessage;
            String strUpdateSqlMain_Date_EO = "Update [MSP$] set P85 ='" + createRequirementModel.str_T1_Date_EndDate_enddate + "'  WHERE P3 ='" + createRequirementModel.strClientName + "' and TestScenario ='001' and TestCaseID = '009'";
            results = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain_Date_EO);

            //Issue work order
            String strUpdateSqlMain_noofresourcesIWO = "Update [MSP$] set P78 ='" + KeyWords.numofresources + "'  WHERE P3 ='" + createRequirementModel.strClientName + "' and TestScenario ='001' and TestCaseID = '009'";
            results = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain_noofresourcesIWO);

            //Date difference is enter in excel

            String strUpdateSqlMain_Date_IWO = "Update [MSP$] set P85 ='" + createRequirementModel.str_T1_Date_EndDate_enddate + "'  WHERE P3 ='" + createRequirementModel.strClientName + "' and TestScenario ='001' and TestCaseID = '051'";
            results = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain_Date_IWO);
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Assignment_btn_SaveContinue_btnSaveCont);

            //cofirm cw
            String strUpdateSqlMain_noofresourcesCW = "Update [MSP$] set P201 ='" + KeyWords.numofresources + "'  WHERE P3 ='" + createRequirementModel.strClientName + "' and TestScenario ='001' and TestCaseID = '012'";
            results = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain_noofresourcesCW);

            String strUpdateSqlMain_Date_CW = "Update [MSP$] set P202 ='" + createRequirementModel.str_T1_Date_EndDate_enddate + "'  WHERE P3 ='" + createRequirementModel.strClientName + "' and TestScenario ='001' and TestCaseID = '012'";
            results = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain_Date_CW);



            //Work Flow Tab
            Thread.Sleep(2000);
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_WorkFlow_workflowContainer), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_WorkFlow_workflowContainer), kwm._WDWait);


            // Click on Guidelince check box
            if (createRequirementModel.strChkbox_guidelineAccepted.ToLower().Equals("yes"))
            {
                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_WorkFlow_guidelines_guidelineAccepted);
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_WorkFlow_guidelines_guidelineAccepted);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_WorkFlow_guidelines_guidelineAccepted), kwm._WDWait);
                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_WorkFlow_guidelines_guidelineAccepted);
                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_WorkFlow_guidelines_guidelineAccepted);

                }
            }


            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Button_WorkFlow_guidelines_guidelineAccepted), kwm._WDWait);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_WorkFlow_guidelines_guidelineAccepted);
            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_WorkFlow_guidelines_guidelineAccepted, KeyWords.Type_Button);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Button_WorkFlow_guidelines_guidelineAccepted), kwm._WDWait);
                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_WorkFlow_guidelines_guidelineAccepted);
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_WorkFlow_guidelines_guidelineAccepted);

            }

            //Screen shot

            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strBrowserName + "_");

            // Justification tab for Identified candidate requisition -- works only for Identified candidate
            if (createRequirementModel.strSelectRequisitionType.ToLower().Contains("identified") || createRequirementModel.strSelectRequisitionType.ToLower().Contains("payrolled"))
            {

                CreateRequirementPerClientJobTab.IdentifiedRequirementJustification(createRequirementModel, results, kwm, WDriver, objCommonMethods);

            }
            else
            {
                //Pre screen questions
                kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Button_PrescreenQuestion_guidelines_guidelineAccepted), kwm._WDWait);
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_PrescreenQuestion_guidelines_guidelineAccepted, KeyWords.Type_Button);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Button_PrescreenQuestion_guidelines_guidelineAccepted), kwm._WDWait);
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_PrescreenQuestion_guidelines_guidelineAccepted, KeyWords.Type_Button);

                }
            }


            if (createRequirementModel.strSelectRequisitionType.ToLower().Contains("identified") || createRequirementModel.strSelectRequisitionType.ToLower().Contains("payrolled"))
            {
                kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_btn_JustificationSaveandContinue_btnCandidateSaveAndContinue), kwm._WDWait);
                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_JustificationSaveandContinue_btnCandidateSaveAndContinue);
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_JustificationSaveandContinue_btnCandidateSaveAndContinue);
            }



            Thread.Sleep(2000);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strBrowserName + "_");
            //Requirement submit tab
            //    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ReviewSubmit);
            kwm.waitForElementExists(WDriver, By.Id(KeyWords.ID_WorkFlow_workflowContainer), kwm._WDWait);
            //kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_WorkFlow_workflowContainer), kwm._WDWait);
            Thread.Sleep(2000);
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Button_ReviewSubmit), kwm._WDWait);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ReviewSubmit);
            Thread.Sleep(2000);
            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ReviewSubmit, KeyWords.Type_Button);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Button_ReviewSubmit), kwm._WDWait);
                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ReviewSubmit);

                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ReviewSubmit, KeyWords.Type_Button);
            }
            //Get the Requirement number

            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strBrowserName + "_");


            for (int req = 0; req < 30; req++)
            {
                results = kwm.Get_Req_Number(WDriver, KeyWords.locator_class, KeyWords.ID_link_txt_Req_Number);
                if ((results.Result1 == KeyWords.Result_PASS) && (results.ErrorMessage1 != ""))
                {
                    KeyWords.str_link_REQ_NUMBER = results.ErrorMessage;
                    results.ErrorMessage1 = results.ErrorMessage;
                    results.ErrorMessage = results.ErrorMessage + " " + KeyWords.MSG_strCreateRequirementssuccessfully;
                    // return results;
                    break;
                }
                Thread.Sleep(1000);
                if (req > 5)
                {
                    if (kwm.isElementPresent(WDriver, KeyWords.ID_Error_ulMspUserError))
                    {
                        break;
                    }
                }
            }
            results.Result1 = KeyWords.Result_PASS;
            return results;
            //if (kwm.isElementPresent(WDriver, KeyWords.ID_Error_ulMspUserError))
            //{
            //    results = kwm.Error_Msg_Read(WDriver, KeyWords.locator_ID, KeyWords.ID_Error_ulMspUserError);
            //    if (results.Result1 == KeyWords.Result_PASS)
            //    {
            //        results.Result1 = KeyWords.Result_FAIL;
            //        if (results.ErrorMessage == "")
            //        {
            //            results.ErrorMessage = KeyWords.MSG_strRequirementNumberNotCreated;
            //        }
            //    }

            //}
        }


        public Result Edit_Requirement(IWebDriver WDriver, DataRow REQ_Data, DataRow REQ_DataL)
        {
            @ReadExcel ReadExcelHelper = new ReadExcel();
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            List<string> listExistClients = new List<string>();
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
            CreateRequirementModel createRequirementModel = createRequirementRepository.GetCreateRequirementData(REQ_Data);
            CreateRequirementModel createRequirementModelLabel = createRequirementRepository.GetCreateRequirementData(REQ_DataL);

            var Questions_Data = new Result();

            //Client selection
            listExistClients = new List<string>() { Constants.Discover };
            if (listExistClients.Contains(createRequirementModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strClientName);
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
            if (!listExistClients.Contains(createRequirementModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strClientName);
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

            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");
            //Submenu
            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strMainMenuLink, createRequirementModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(1000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strMainMenuLink, createRequirementModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot(WDriver, createRequirementModel.strClientName + "_");

            // Enter Requirement number in Search Text box
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.ID_paginate_regReqList_filter), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.ID_paginate_regReqList_filter), kwm._WDWait);

            kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.ID_paginate_regReqList_filter, createRequirementModel.strSelectRequisitionType, false);

            // Click on Requirement Number

            kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@aria-label='Requirement#: " + createRequirementModel.strSelectRequisitionType + "']/a"), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@aria-label='Requirement#: " + createRequirementModel.strSelectRequisitionType + "']/a"), kwm._WDWait);

            kwm.click(WDriver, KeyWords.locator_XPath, "//*[@aria-label='Requirement#: " + createRequirementModel.strSelectRequisitionType + "']/a");

            // Click on Edit link
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_EditLink), kwm._WDWait);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_EditLink);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_EditLink);



            switch (createRequirementModel.strClientName.ToLower().ToString())
            {

                case Constants.SunTrust:
                    {
                        CreateRequirementPerClient.ClientRequirementSunTrust(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.ClientRequirementSunTrust(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Colgate:
                    {
                        CreateRequirementPerClient.ClientRequirementColgate(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.ClientRequirementColgate(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Ryder:
                    {
                        CreateRequirementPerClient.ClientRequirementRyder(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont);
                        CreateRequirementPerClientJobTab.CreateRequirementRyder(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Cpchem:
                    {
                        CreateRequirementPerClient.ClientRequirementCpchem(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.ClientRequirementCpchem(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Caesars:
                    {
                        CreateRequirementPerClient.ClientRequirementCaesars(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementCaesars(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Dyncorp:
                    {
                        CreateRequirementPerClient.ClientRequirementDyncorp(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementDyncorp(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Keybank:
                    {
                        CreateRequirementPerClient.ClientRequirementKeybank(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.ClientRequirementKeybank(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                case Constants.Altria:
                    {
                        CreateRequirementPerClient.ClientRequirementAltria(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.ClientRequirementKeybank(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Discover:
                    {
                        CreateRequirementPerClient.ClientRequirementDiscover(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementDiscover(createRequirementModel, results, kwm, WDriver, objCommonMethods);

                        break;
                    }

                case Constants.Welchallyn:
                    {
                        CreateRequirementPerClient.ClientRequirementWelchallyn(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementWelchallyn(createRequirementModel, results, kwm, WDriver, objCommonMethods);

                        break;
                    }

                case Constants.KCPL:
                    {
                        CreateRequirementPerClient.ClientRequirementKCPL(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementKCPL(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Tesla:
                    {
                        CreateRequirementPerClient.ClientRequirementTesla(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.ClientRequirementTesla(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Epri:
                    {
                        CreateRequirementPerClient.ClientRequirementEpri(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementEpri(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.EBS:
                    {
                        CreateRequirementPerClient.ClientRequirementEBS(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementEBSClient(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                case Constants.APS:
                    {
                        CreateRequirementPerClient.ClientRequirementAPS(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementAPS(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;

                    }

                case Constants.HillRom:
                    {
                        //   CreateRequirementPerClient.ClientRequirementHillRom(createRequirementModel, results, kwm, WDriver, objCommonMethods, createRequirementModelLabel);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        //   CreateRequirementPerClientJobTab.ClientRequirementHillRom(createRequirementModel, results, kwm, WDriver, objCommonMethods, createRequirementModelLabel);
                        break;
                    }

                case Constants.SOF:
                    {
                        CreateRequirementPerClient.ClientRequirementSOF(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementSOF(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                case Constants.Sts:
                    {
                        CreateRequirementPerClient.ClientRequirementSTS(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.ClientRequirementSTS(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                case Constants.StewartTitle:
                    {
                        CreateRequirementPerClient.ClientRequirementStewartTitle(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementStewartTitle(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.ThermoFisher:
                    {
                        CreateRequirementPerClient.ClientRequirementThermoFisher(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementThermoFisher(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.RMS:
                    {
                        CreateRequirementPerClient.ClientRequirementRMS(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementRMS(createRequirementModel, results, kwm, WDriver, objCommonMethods);


                        break;

                    }
                case Constants.QuickenLoans:
                    {
                        CreateRequirementPerClient.ClientRequirementQuickenLoans(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementQuickenLoans(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                case Constants.MFC:
                    {
                        CreateRequirementPerClient.ClientRequirementMFC(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementMFC(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                case Constants.Bimbo:
                    {
                        CreateRequirementPerClient.ClientRequirementBimbo(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementBimbo(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Georgetown:
                    {
                        CreateRequirementPerClient.ClientRequirementGeorgeTown(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementGeorgetown(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                case Constants.COE:
                    {
                        CreateRequirementPerClient.ClientRequirementCOE(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementCOE(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Tufts:
                    {
                        CreateRequirementPerClient.ClientRequirementTufts(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.ClientRequirementTufts(createRequirementModel, results, kwm, WDriver, objCommonMethods);


                        break;

                    }
                case Constants.PHHMortgage:
                    {
                        CreateRequirementPerClient.ClientRequirementPhhMortgage(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.ClientRequirementPHHMortgage(createRequirementModel, results, kwm, WDriver, objCommonMethods);


                        break;

                    }
                case Constants.STGEN:
                    {
                        CreateRequirementPerClient.ClientRequirementSTGEN(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementSTGEN(createRequirementModel, results, kwm, WDriver, objCommonMethods);


                        break;

                    }
                case Constants.Supervalu:
                    {
                        CreateRequirementPerClient.ClientRequirementSupervalu(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementSupervalu(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                case Constants.EMERSON:
                    {
                        CreateRequirementPerClient.ClientRequirementEmerson(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementEmerson(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Arkema:
                    {
                        CreateRequirementPerClient.ClientRequirementArkema(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementArkema(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.SallieMae:
                    {
                        CreateRequirementPerClient.ClientRequirementSallieMae(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementSallieMae(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }

                case Constants.STTM:
                    {
                        CreateRequirementPerClient.ClientRequirementSTTM(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementSTTM(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.YP:
                    {
                        CreateRequirementPerClient.ClientRequirementYP(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementYP(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.Lear:
                    {
                        CreateRequirementPerClient.ClientRequirementLear(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);
                        CreateRequirementPerClientJobTab.CreateRequirementLear(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.EQT:
                    {
                        CreateRequirementPerClient.ClientRequirementEQT(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont);
                        CreateRequirementPerClientJobTab.ClientRequirementEQT(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                case Constants.SIGMA:
                    {
                        CreateRequirementPerClient.ClientRequirementSIGMA(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Outline_btn_SaveContinue_btnSaveCont);
                        CreateRequirementPerClientJobTab.CreateRequirementSIGMA(createRequirementModel, results, kwm, WDriver, objCommonMethods);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            objCommonMethods.SaveScreenShot(WDriver, createRequirementModel.strBrowserName + "_");

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Assignment_btn_SaveContinue_btnSaveCont, KeyWords.Type_Button);

            //Manjusha Added Code Estimated Contraced Value calculation
            //Number of resuroses write into excel in Offer to hire , extend offer, confirm cw
            results = kwm.GetText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources);
            KeyWords.numofresources = results.ErrorMessage;


            //Work Flow Tab
            Thread.Sleep(2000);
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_WorkFlow_workflowContainer), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_WorkFlow_workflowContainer), kwm._WDWait);


            // Click on Guidelince check box
            if (createRequirementModel.strChkbox_guidelineAccepted.ToLower().Equals("yes"))
            {
                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_WorkFlow_guidelines_guidelineAccepted);
                // results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_WorkFlow_guidelines_guidelineAccepted);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_WorkFlow_guidelines_guidelineAccepted), kwm._WDWait);
                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_WorkFlow_guidelines_guidelineAccepted);
                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_WorkFlow_guidelines_guidelineAccepted);

                }
            }


            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Button_WorkFlow_guidelines_guidelineAccepted), kwm._WDWait);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_WorkFlow_guidelines_guidelineAccepted);
            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_WorkFlow_guidelines_guidelineAccepted, KeyWords.Type_Button);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Button_WorkFlow_guidelines_guidelineAccepted), kwm._WDWait);
                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_WorkFlow_guidelines_guidelineAccepted);
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_WorkFlow_guidelines_guidelineAccepted);

            }

            //Screen shot

            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strBrowserName + "_");

            // Justification tab for Identified candidate requisition -- works only for Identified candidate
            if (createRequirementModel.strSelectRequisitionType.ToLower().Contains("identified") || createRequirementModel.strSelectRequisitionType.ToLower().Contains("payrolled"))
            {

                CreateRequirementPerClientJobTab.IdentifiedRequirementJustification(createRequirementModel, results, kwm, WDriver, objCommonMethods);

            }
            else
            {
                //Pre screen questions
                kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Button_PrescreenQuestion_guidelines_guidelineAccepted_Edit), kwm._WDWait);
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_PrescreenQuestion_guidelines_guidelineAccepted_Edit, KeyWords.Type_Button);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Button_PrescreenQuestion_guidelines_guidelineAccepted_Edit), kwm._WDWait);
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_PrescreenQuestion_guidelines_guidelineAccepted_Edit, KeyWords.Type_Button);

                }
            }


            if (createRequirementModel.strSelectRequisitionType.ToLower().Contains("identified") || createRequirementModel.strSelectRequisitionType.ToLower().Contains("payrolled"))
            {
                kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_btn_JustificationSaveandContinue_btnCandidateSaveAndContinue), kwm._WDWait);
                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_JustificationSaveandContinue_btnCandidateSaveAndContinue);
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_JustificationSaveandContinue_btnCandidateSaveAndContinue);
            }



            Thread.Sleep(2000);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strBrowserName + "_");
            //Requirement submit tab
            //    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ReviewSubmit);
            kwm.waitForElementExists(WDriver, By.Id(KeyWords.ID_WorkFlow_workflowContainer), kwm._WDWait);
            //kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_WorkFlow_workflowContainer), kwm._WDWait);
            Thread.Sleep(2000);
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Button_ReviewSubmit), kwm._WDWait);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ReviewSubmit);
            Thread.Sleep(2000);
            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ReviewSubmit, KeyWords.Type_Button);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Button_ReviewSubmit), kwm._WDWait);
                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ReviewSubmit);

                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_ReviewSubmit, KeyWords.Type_Button);
            }
            //Get the Requirement number

            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strBrowserName + "_");

            // Click on yes button under confirmaiton popup
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_Button_Yes), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_Button_Yes), kwm._WDWait);

            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Button_Yes);

            if (kwm.isElementPresent(WDriver, KeyWords.ID_Error_ulMspUserError))
            {
                results = kwm.Error_Msg_Read(WDriver, KeyWords.locator_ID, KeyWords.ID_Error_ulMspUserError);
                if (results.Result1 == KeyWords.Result_PASS)
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    if (results.ErrorMessage == "")
                    {
                        results.ErrorMessage = KeyWords.MSG_strRequirementNumberNotCreated;
                    }
                }
                return results;
            }

            // Wait until edit requirement completed
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_EditLink), kwm._WDWait);
            Thread.Sleep(1000);

            //Thread.Sleep(5000);
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_strCreateRequirementssuccessfully;
            return results;
        }

        //Manjusha
        //menu and submenu method
        public Result Menu_SubMenu(IWebDriver WDriver, DataRow REQ_Data, DataRow REQ_DataL)
        {
            @ReadExcel ReadExcelHelper = new ReadExcel();
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            List<string> listExistClients = new List<string>();
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
            CreateRequirementModel createRequirementModel = createRequirementRepository.GetCreateRequirementData(REQ_Data);


            //Client selection


            listExistClients = new List<string>() { Constants.Discover };
            if (listExistClients.Contains(createRequirementModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strClientName);
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
            if (!listExistClients.Contains(createRequirementModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strClientName);
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

            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");
            //Submenu


            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strMainMenuLink, createRequirementModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(1000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strMainMenuLink, createRequirementModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            objCommonMethods.SaveScreenShot(WDriver, createRequirementModel.strClientName + "_");

            // Identified candidate 
            if (createRequirementModel.strSelectRequisitionType.ToLower().Contains("identified") || createRequirementModel.strSelectRequisitionType.ToLower().Contains("payrolled"))
            {
                kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[text()='" + createRequirementModel.strSelectRequisitionType + "']"), kwm._WDWait);
                kwm.select_RequisitionType(WDriver, createRequirementModel.strSelectRequisitionType);

                kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_btn_NewIdentifiedCandidate_btnNewCandidate), kwm._WDWait);
                kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_btn_NewIdentifiedCandidate_btnNewCandidate), kwm._WDWait);
                Thread.Sleep(500);
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_NewIdentifiedCandidate_btnNewCandidate);
            }
            else
            {
                kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@class='instedEM' and text()='" + createRequirementModel.strSelectRequisitionType + "']"), kwm._WDWait);
                kwm.select_RequisitionType(WDriver, createRequirementModel.strSelectRequisitionType);
            }

            //Create New Requistion
            kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[text()='" + createRequirementModel.strNewRequisition + "']"), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[text()='" + createRequirementModel.strNewRequisition + "']"), kwm._WDWait);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[text()='" + createRequirementModel.strNewRequisition + "']");
            Thread.Sleep(500);

            results = kwm.select_RequisitionType(WDriver, createRequirementModel.strNewRequisition);


            return results;
        }


        // saveasMy template code (full method)
        public Result SaveAsMyTemplate(IWebDriver WDriver, DataRow REQ_Data, DataRow REQ_DataL)
        {
            @ReadExcel ReadExcelHelper = new ReadExcel();
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            List<string> listExistClients = new List<string>();
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
            CreateRequirementModel createRequirementModel = createRequirementRepository.GetCreateRequirementData(REQ_Data);
            //cleint and submenu

            results = Menu_SubMenu(WDriver, REQ_Data, REQ_DataL);

            //Create Requirement Save as My template


            results = CreateReqTemplateButton(WDriver, REQ_Data, REQ_DataL);

            //My requirement Templates-Edit template
            results = EditReqTemplate(WDriver, REQ_Data, REQ_DataL);

            results = CreateRequirement_Clients(WDriver, createRequirementModel, kwm, results, objCommonMethods);


            return results;
        }


        //Existing Requirement code(full method)
        public Result RequirementExist(IWebDriver WDriver, DataRow REQ_Data, DataRow REQ_DataL)
        {
            @ReadExcel ReadExcelHelper = new ReadExcel();
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            List<string> listExistClients = new List<string>();
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
            CreateRequirementModel createRequirementModel = createRequirementRepository.GetCreateRequirementData(REQ_Data);
            //cleint and submenu

            results = Menu_SubMenu(WDriver, REQ_Data, REQ_DataL);

            //Exists Req page call 


            results = ExisitingRequirementPage(WDriver, REQ_Data, REQ_DataL);



            return results;
        }


        //Create Req-From Temapte-search template-Req creation
        public Result RequiremntFromTemplate(IWebDriver WDriver, DataRow REQ_Data, DataRow REQ_DataL)
        {
            @ReadExcel ReadExcelHelper = new ReadExcel();
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            List<string> listExistClients = new List<string>();
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
            CreateRequirementModel createRequirementModel = createRequirementRepository.GetCreateRequirementData(REQ_Data);

            //cleint and submenu

            results = Menu_SubMenu(WDriver, REQ_Data, REQ_DataL);
            //from template page calling

            FromTemplatePage(WDriver, REQ_Data, REQ_DataL);
            //Req creation code

            results = CreateRequirement_Clients(WDriver, createRequirementModel, kwm, results, objCommonMethods);

            ReportHandler._getChildTest().Log(LogStatus.Pass, "Through From Template Requirement is created selected Successfully");

            return results;
        }

        //Cancel requirement
        public Result RequirementCancel(IWebDriver WDriver, DataRow REQ_Data, DataRow REQ_DataL)
        {
            @ReadExcel ReadExcelHelper = new ReadExcel();
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            List<string> listExistClients = new List<string>();
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
            CreateRequirementModel createRequirementModel = createRequirementRepository.GetCreateRequirementData(REQ_Data);

            //cleint and submenu

            results = Menu_SubMenu(WDriver, REQ_Data, REQ_DataL);
            //cancel Req
            results = OutlineCancelButton(WDriver, REQ_Data, REQ_Data);

            ReportHandler._getChildTest().Log(LogStatus.Pass, "Requirement is cancelled ");
            return results;
        }

        //Navigateto Requirement-job description tab-submit template in review and submit tab -enter template name
        public Result CreateReqTemplateButton(IWebDriver WDriver, DataRow REQ_Data, DataRow REQ_DataL)
        {
            @ReadExcel ReadExcelHelper = new ReadExcel();
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            List<string> listExistClients = new List<string>();
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
            CreateRequirementModel createRequirementModel = createRequirementRepository.GetCreateRequirementData(REQ_Data);

            //Navigate to job description Tab
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_JobDescriptionTab), kwm._WDWait);
            results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_JobDescriptionTab);

            //type of service

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID), kwm._WDWait);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");


            //Type of Service

            if (createRequirementModel.str_T2_Select_TypeofService_typeofServiceID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_TypeofService_typeofServiceID, createRequirementModel.str_T2_Select_TypeofService_typeofServiceID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_TypeofService_typeofServiceID);
                }
            }

            //Job Title
            Thread.Sleep(100);
            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
                //  Thread.Sleep(2000);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, "a");
                        // return results;
                    }
                }
            }


            //Navigate to Review and submit Tab
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Tab_Reviewandsubmit);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Tab_Reviewandsubmit);
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.Id_btnSaveAsTemplate), kwm._WDWait);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.Id_btnSaveAsTemplate);
            Thread.Sleep(2000);
            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.Id_btnSaveAsTemplate, KeyWords.Type_Button);
            //Enter save as my template name
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.Id_Txt_TemplateName), kwm._WDWait);

            String timeStamp = DateTime.Now.ToString("MMddyyyyHHmm");

            //Enter text in Template 
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_Txt_TemplateName, timeStamp, false);
            //templatename write into excel
            String strUpdateSqlMain_templateName = "Update [MSP$] set P98 ='" + timeStamp + "'  WHERE P3 ='" + createRequirementModel.strClientName + "' and TestScenario ='010' and TestCaseID = '001'";
            results = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain_templateName);

            String strUpdateSqlMain_templateName1 = "Update [MSP$] set P98 ='" + timeStamp + "'  WHERE P3 ='" + createRequirementModel.strClientName + "' and TestScenario ='011' and TestCaseID = '001'";
            results = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain_templateName1);

            //Submit Button

            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.strbtnReviewSubmit_Action_Button);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.strbtnReviewSubmit_Action_Button);
            }

            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_Link_MyreuirementTemplates), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Link_MyreuirementTemplates);

            ReportHandler._getChildTest().Log(LogStatus.Pass, "Template Created successfully successfully");
            return results;
        }

        //edit template 
        public Result EditReqTemplate(IWebDriver WDriver, DataRow REQ_Data, DataRow REQ_DataL)
        {
            @ReadExcel ReadExcelHelper = new ReadExcel();
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            List<string> listExistClients = new List<string>();
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
            CreateRequirementModel createRequirementModel = createRequirementRepository.GetCreateRequirementData(REQ_Data);
            //search template name
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_Search_Myreuistiontemplatesearch), kwm._WDWait);
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_TemplateTable_Edit), kwm._WDWait);
            results = kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Search_Myreuistiontemplatesearch, createRequirementModel.strbtnSaveasMytemplate_Action_Button, false);
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_TemplateTable_Edit), kwm._WDWait);
            //Edit click 
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_TemplateTable_Edit);
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_btntab_first), kwm._WDWait);
            ReportHandler._getChildTest().Log(LogStatus.Pass, "Clicked on Edit icon successfully");

            return results;
        }

        // from Template page code 
        public Result FromTemplatePage(IWebDriver WDriver, DataRow REQ_Data, DataRow REQ_DataL)
        {
            @ReadExcel ReadExcelHelper = new ReadExcel();
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            List<string> listExistClients = new List<string>();
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
            CreateRequirementModel createRequirementModel = createRequirementRepository.GetCreateRequirementData(REQ_Data);
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Btn_searchButton), kwm._WDWait);


            //search button click
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Btn_searchButton);

            kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[text()='" + createRequirementModel.strbtnSaveasMytemplate_Action_Button + "']/preceding-sibling::input[starts-with(@id,'tempSelect')]"), kwm._WDWait);
            //List of templates selection

            kwm.click(WDriver, KeyWords.locator_XPath, "//*[text()='" + createRequirementModel.strbtnSaveasMytemplate_Action_Button + "']/preceding-sibling::input[starts-with(@id,'tempSelect')]");

            //search button click

            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Button_SelectTemplate);

            ReportHandler._getChildTest().Log(LogStatus.Pass, "From Template is selected Successfully");

            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_OutlineTab), kwm._WDWait);

            return results;
        }


        //Cancel requirement from Ouline tab 

        public Result OutlineCancelButton(IWebDriver WDriver, DataRow REQ_Data, DataRow REQ_DataL)
        {
            @ReadExcel ReadExcelHelper = new ReadExcel();
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            List<string> listExistClients = new List<string>();
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
            CreateRequirementModel createRequirementModel = createRequirementRepository.GetCreateRequirementData(REQ_Data);
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_OutlineTab), kwm._WDWait);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.Id_Button_Cancel);
            //cancel button click
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.Id_Button_Cancel);
            //waiting for lable
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_Cancel_yes), kwm._WDWait);
            //click button yes
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Cancel_yes);

            return results;
        }


        //Exisiting requirement page


        public Result ExisitingRequirementPage(IWebDriver WDriver, DataRow REQ_Data, DataRow REQ_DataL)
        {
            @ReadExcel ReadExcelHelper = new ReadExcel();
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            List<string> listExistClients = new List<string>();
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
            CreateRequirementModel createRequirementModel = createRequirementRepository.GetCreateRequirementData(REQ_Data);
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Btn_searchButton), kwm._WDWait);


            //search button click
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Btn_searchButton);

            kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[contains(text(),'" + createRequirementModel.str_requirementnumber_Exist + "')]/preceding-sibling::td/label/input[@name='reqSelect']"), kwm._WDWait);
            //List ofRequirement  selection

            kwm.click(WDriver, KeyWords.locator_XPath, "//*[contains(text(),'" + createRequirementModel.str_requirementnumber_Exist + "')]/preceding-sibling::td/label/input[@name='reqSelect']");

            //Seelct Template click

            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Btn_ExistRequirement_SelectRequirement);

            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_OutlineTab), kwm._WDWait);
            //Select priority


            //Navigate to JOb description Tab
            kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Priority_priority, 1);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Priority_priority, createRequirementModel.str_T1_select_Priority_priority);

            }

            //Navigate to 
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_JobDescriptionTab), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_JobDescriptionTab);
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Txt_txtJobTitle), kwm._WDWait);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_PayRateLow_payRateLow);
            //Pay Rate--low
            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_PayRateLow_payRateLow, createRequirementModel.str_T2_txt_PayRateLow_payRateLow, false, "", "");

            //Pay Rate--high
            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T2_txt_PayRateHigh_payRateHigh, createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh, false, "", "");

            //Bill Rate--low

            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow, createRequirementModel.str_T2_txt_Billratelow_billRateLow, false, "", "");

            //Bill Rate--High

            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, false, "", "");

            //Review and submit tab 

            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Tab_Reviewandsubmit);

            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Tab_Reviewandsubmit);
            //CLick submit 
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_saveandcontinue_btnSubmit);
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_saveandcontinue_btnSubmit);

            ReportHandler._getChildTest().Log(LogStatus.Pass, "Existing Requirement is Created Successfully");

            return results;
        }

        #region GenericFunctions
        
        public void buildRepository(DataRow dr)
        {
            try
            {
                CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
                this.createRequirementModel = createRequirementRepository.GetCreateRequirementData(dr);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public void NavigateTo()
        {
            try
            {
                listExistClients = new List<string>() { Constants.Discover };
                if (listExistClients.Contains(createRequirementModel.strClientName.ToLower()))
                {
                    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(5000);
                        results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strClientName);
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
                                results.blnResult = false;
                        }
                    }
                }
                listExistClients = new List<string>() { Constants.Discover };
                if (!listExistClients.Contains(createRequirementModel.strClientName.ToLower()))
                {
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(5000);
                        results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strClientName);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            Boolean bFlagDropDwon = false;
                            try
                            {
                                results.blnResult = kwm.isElementEnabledByXPath(WDriver, KeyWords.XPath_supplierMenu_ClientDropDown);
                                // bFlagDropDwon = WDriver.FindElement(By.XPath(KeyWords.XPath_supplierMenu_ClientDropDown)).Enabled;
                            }
                            catch
                            {
                                results.blnResult = false;
                            }
                            
                        }
                    }
                }

                objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");
                //Submenu


                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strMainMenuLink, createRequirementModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(1000);
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, createRequirementModel.strMainMenuLink, createRequirementModel.strSubMenuLink);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results.blnResult = false;
                        
                    }
                }

                objCommonMethods.SaveScreenShot(WDriver, createRequirementModel.strClientName + "_");
                // kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_Btn_ETKYes_confirmationBypassETKDialog), kwm._WDWait);

                // objCommonMethods.ChooseETK(WDriver, createRequirementModel.strNewRequisition);

                // objCommonMethods.ChooseETK(WDriver, createRequirementModel.strSelectRequisitionType, createRequirementModel.str_btn_ETKOption, kwm._WDWait);

                // kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_ETKpopup_yes);
                //Select Requisition

                //kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[text()='" + createRequirementModel.strSelectRequisitionType + "']"), kwm._WDWait);
                //kwm.select_RequisitionType(WDriver, createRequirementModel.strSelectRequisitionType);

                // Identified candidate 
                if (createRequirementModel.strSelectRequisitionType.ToLower().Contains("identified") || createRequirementModel.strSelectRequisitionType.ToLower().Contains("payrolled"))
                {
                    kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[text()='" + createRequirementModel.strSelectRequisitionType + "']"), kwm._WDWait);
                    kwm.select_RequisitionType(WDriver, createRequirementModel.strSelectRequisitionType);

                    kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_btn_NewIdentifiedCandidate_btnNewCandidate), kwm._WDWait);
                    kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_btn_NewIdentifiedCandidate_btnNewCandidate), kwm._WDWait);
                    Thread.Sleep(500);
                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_NewIdentifiedCandidate_btnNewCandidate);
                }
                else
                {
                    kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@class='instedEM' and text()='" + createRequirementModel.strSelectRequisitionType + "']"), kwm._WDWait);
                    kwm.select_RequisitionType(WDriver, createRequirementModel.strSelectRequisitionType);
                }

                //Create New Requistion
                kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[text()='" + createRequirementModel.strNewRequisition + "']"), kwm._WDWait);
                kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[text()='" + createRequirementModel.strNewRequisition + "']"), kwm._WDWait);
                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[text()='" + createRequirementModel.strNewRequisition + "']");
                
                kwm.select_RequisitionType(WDriver, createRequirementModel.strNewRequisition);
            }catch(Exception e)
            {
                throw e;
            }
        }
        
        public void setWebdriverWait()
        {
            this.kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
        }

        public void setWebdriverWait(int wait_Seconds)
        {
            this.kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, wait_Seconds);
        }

        
        #endregion

        #region Execution_Suite
        public static void TC1_CreateRequirement_EmptyMandatoryFields()
        {
            
            
        }
        #endregion













        
    }
}