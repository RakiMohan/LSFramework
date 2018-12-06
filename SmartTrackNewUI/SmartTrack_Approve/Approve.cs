// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Approve.cs" company="DCR Workforce Inc">
//   Copyright (c) DCR Workforce Inc. All rights reserved.
//   This code and information should not be copied and used outside of DCR Workforce Inc.
// </copyright>
// <summary>
//  This Constants is used
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace SmartTrack_Automation
{
    using System;
    using System.Collections.ObjectModel;
    using OpenQA.Selenium;
    using System.Threading;
    using OpenQA.Selenium.Support.UI;
    using System.Data;
    using SmartTrack.DataAccess.Repository;
    using SmartTrack.DataAccess.Models;
    using System.Collections.Generic;
    using CommonFiles;
    using RelevantCodes.ExtentReports;


    //[TestClass]
    public class Approve
    {
        KeyWordMethods kwm = new KeyWordMethods();
        Result results = new Result();
        ApproveModel approveModel;
        CommonMethods objCommonMethods;
        string sQueueStatus;

        public Result Approve_Method(IWebDriver WDriver, DataRow Approve_Data)
        {
            //KeyWordMethods kwm = new KeyWordMethods();
            //Result result = new Result();
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
            objCommonMethods = new CommonMethods();
            var results = new Result();
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            approveModel = createRequirementRepository.GetApproveData(Approve_Data);
            IList<string> approver_list = new List<string>();
            Dictionary<string, string> dict_Approvers = new Dictionary<string, string>();
            Boolean bVal_Approved = false;


            objCommonMethods.SaveScreenShot_EachPage(WDriver, approveModel.strClientName + "_");

            List<string> listExistClients = new List<string>() { Constants.Discover, Constants.Ryder };
            if (!listExistClients.Contains(approveModel.strClientName.ToLower()))
            {
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, approveModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(100);
                    //Note: Updated the code in the below method.
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, approveModel.strClientName);
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

        rerun:
            //   click on main menu given name
            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, approveModel.strMainMenuLink, approveModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, approveModel.strMainMenuLink, approveModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //results.ErrorMessage1 = "Unable to click on the Main menu";
                    return results;
                }
            }

            if (approveModel.strSubMenuLink.ToLower().Contains("identified"))
            {
                if (!kwm.waitForElementExists(WDriver, By.XPath(KeyWords.XPath_SearchBox_IdentifiedRequirements_regReqList), kwm._WDWait))
                {
                    Thread.Sleep(2000);
                }

                //Search requirement
                kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_SearchBox_IdentifiedRequirements_regReqList, approveModel.str_Link_ReqNumber, false);

                //Wait for Requirement to load
                //if (!kwm.waitForElementExists(WDriver, By.XPath(KeyWords.XPath_Img_Processing), kwm._WDWait))
                //{
                //kwm.waitForElementToBeClickable(WDriver, By.XPath("//table[@id='IdentifiedReqList']//td/a[contains(text(),'" + approveModel.str_Link_ReqNumber + "')]"), kwm._WDWait);
                //}
                kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_Img_IdentifiedHeartBeat), kwm._WDWait);
                kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_Img_IdentifiedHeartBeat), kwm._WDWait);
                Thread.Sleep(1000);
                objCommonMethods.SaveScreenShot_EachPage(WDriver, approveModel.strClientName + "_");

                //click on Heartbeat link
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Img_IdentifiedHeartBeat);

            }
            else
            {
                //if (!kwm.waitForElementExists(WDriver, By.XPath(KeyWords.XPath_SearchBox_Requirements_regReqList), kwm._WDWait))
                //{
                //    Thread.Sleep(2000);
                //}

                kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_SearchBox_Requirements_regReqList), kwm._WDWait);
                kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_SearchBox_Requirements_regReqList), kwm._WDWait);

                //Search requirement
                kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_SearchBox_Requirements_regReqList, approveModel.str_Link_ReqNumber, false);

                //Wait for Requirement to load
                if (!kwm.waitForElementExists(WDriver, By.XPath(KeyWords.XPath_Img_Processing), kwm._WDWait))
                {
                    kwm.waitForElementToBeClickable(WDriver, By.XPath("//table[@id='regReqList']//td/a[contains(text(),'" + approveModel.str_Link_ReqNumber + "')]"), kwm._WDWait);
                }
                kwm.waitForElementToBeVisible(WDriver, By.XPath("//table[@id='regReqList']//td/a[contains(text(),'" + approveModel.str_Link_ReqNumber + "')]"), kwm._WDWait);
                kwm.waitForElementToBeClickable(WDriver, By.XPath("//table[@id='regReqList']//td/a[contains(text(),'" + approveModel.str_Link_ReqNumber + "')]"), kwm._WDWait);
                Thread.Sleep(1000);
                objCommonMethods.SaveScreenShot_EachPage(WDriver, approveModel.strClientName + "_");
                kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_Img_HeartBeat), kwm._WDWait);
                kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_Img_HeartBeat), kwm._WDWait);
                Thread.Sleep(1000);

                //click on Heartbeat link
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Img_HeartBeat);

            }


            //wait for requirement heartbeat to load
            if (!kwm.waitForElementExists(WDriver, By.XPath("//div[contains(@class,'jsplumb-connected') and not(contains(@class,'approved')) ]/*[1]"), kwm._WDWait))
            {
                kwm.waitForElementExists(WDriver, By.XPath("//div[contains(@class,'jsplumb-connected')]//strong"), kwm._WDWait);
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, approveModel.strClientName + "_");

            if (kwm.isElementDisplayedByXPath(WDriver, "//table[@id='workflowContainer']//td//div[not(contains(@class,'approved'))]/ancestor::tbody//following-sibling::*//div[not(contains(@class,'approved')) and not(@id='wEnd')]"))
            {
                //Add all the approvers to list
                foreach (IWebElement Ele in WDriver.FindElements(By.XPath("//div[contains(@class,'jsplumb-connected') and not(contains(@class,'approved')) and not(@id='wEnd')]")))
                {
                    if (Ele.GetAttribute("functioncode").Equals("0"))
                    {
                        approver_list.Add(Ele.FindElement(By.CssSelector("*")).Text);
                    }
                    else
                    {
                        String sTemp = Ele.GetAttribute("id");
                        objCommonMethods.js_Action_MouseOver_Element(WDriver, KeyWords.locator_ID, sTemp);
                        //approver_list.Add(kwm.GetText_Xpath(WDriver, "//div[@role='tooltip' and not(contains(@style,'display: none'))]//ol[1]")._Var + "@MSP");
                        approver_list.Add(kwm.GetText_Xpath(WDriver, "//div[@role='tooltip' and not(contains(@style,'display: none'))]//ol[1]")._Var);
                        objCommonMethods.js_Action_MouseLeave_Element(WDriver);

                    }



                }
            }
            else
            {

                bVal_Approved = true;
            }


            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_HearBeatMsgBox_Btn_Close_Close), kwm._WDWait);
            //Close heartBeat
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_HearBeatMsgBox_Btn_Close_Close);

            int iCount = 0;
            //Verifying if the count of the list is greater than zero
            if (approver_list.Count > 0 && !approver_list.Contains(null))
            {
                foreach (string sApproverName in approver_list)
                {
                    /*Checking the user in Client User Management*/
                    //Navigate to Administration->Client User Management
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, "Administration", "Client User Management");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(5000);
                        results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, "Administration", "Client User Management");
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //results.ErrorMessage1 = "Unable to click on the Main menu";
                            return results;
                        }
                    }

                    kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Txt_ClientUserManagement_FirstName_DefaultContent_TxtFname), kwm._WDWait);
                    kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Txt_ClientUserManagement_FirstName_DefaultContent_TxtFname), kwm._WDWait);
                    Thread.Sleep(1000);
                    if (kwm.isElementDisplayed(WDriver, KeyWords.ID_Button_ClientUserManagement_Search_btnSearchClientUser))
                    {
                        //Enter First Name
                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ClientUserManagement_FirstName_DefaultContent_TxtFname, sApproverName.Split(',')[1].Trim().Split(' ')[0], false);
                        //Enter Last Name
                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ClientUserManagement_LastName_DefaultContent_TxtBoxLname, sApproverName.Split(',')[0].Trim(), false);
                        //Click on Search button
                        results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Btn_UserManagementSearch);
                        objCommonMethods.SaveScreenShot_EachPage(WDriver, approveModel.strClientName + "_");
                    }

                    try
                    {
                        kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_Link__SearchResults_ClientUser), kwm._WDWait);
                        kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_Link__SearchResults_ClientUser), kwm._WDWait);
                        Thread.Sleep(1000);
                        objCommonMethods.Action_Page_Down(WDriver);
                        Thread.Sleep(500);
                        if (kwm.isElementDisplayed(WDriver, KeyWords.ID_MSG_UserManagement))
                        {
                            goto MSPUser;
                        }
                        if (kwm.isElementDisplayedByXPath(WDriver, KeyWords.XPath_Link__SearchResults_ClientUser))
                        {
                            Thread.Sleep(2000);
                            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Link__SearchResults_ClientUser);
                            objCommonMethods.SaveScreenShot_EachPage(WDriver, approveModel.strClientName + "_");
                        }
                        else
                        {

                            kwm.waitForElementExists(WDriver, By.XPath(KeyWords.XPath_Link__SearchResults_ClientUser), kwm._WDWait);
                            kwm.jsClick(WDriver, KeyWords.locator_CSS, "#dgrClientUsers1 tbody tr.odd td a");

                        }
                        goto ViewDesktop;
                    }
                    catch (Exception e)
                    {
                        results.ErrorMessage = "No such user(" + sApproverName + ") is available with the given data";
                        objCommonMethods.SaveScreenShot_EachPage(WDriver, approveModel.strClientName + "_");
                        results.Result1 = KeyWords.Result_FAIL;
                        results.blnResult = false;
                        return results;
                    }





                    /*If the user is not a Client User , checking if the user is an MSP in MSP User Management.*/
                //Navigate to Administration->MSP User Management
                MSPUser:
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, "Administration", "MSP User Management");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(5000);
                        results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, "Administration", "MSP User Management");
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //results.ErrorMessage1 = "Unable to click on the Main menu";
                            return results;
                        }
                    }
                    kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Txt_MSPUserManagement_FirstName_DefaultContent_TxtFirstName), kwm._WDWait);
                    kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Txt_MSPUserManagement_FirstName_DefaultContent_TxtFirstName), kwm._WDWait);
                    Thread.Sleep(1000);
                    //Added by manjusha
                    if (kwm.isElementDisplayed(WDriver, KeyWords.ID_Button_MspUserManagement_Search_btnSearchMspUser))
                    {
                        //Enter First Name
                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_MSPUserManagement_FirstName_DefaultContent_TxtFirstName, sApproverName.Split(',')[1].Trim().Split(' ')[0], false);
                        //Enter Last Name
                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_MSPUserManagement_LastName_DefaultContent_TxtLastName, sApproverName.Split(',')[0].Trim(), false);
                        //Click on Search button
                        results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Btn_UserManagementSearch);
                        objCommonMethods.SaveScreenShot_EachPage(WDriver, approveModel.strClientName + "_");
                    }

                    try
                    {
                        kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_Link__SearchResults_MSPUser), kwm._WDWait);
                        kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_Link__SearchResults_MSPUser), kwm._WDWait);
                        Thread.Sleep(1000);
                        objCommonMethods.Action_Page_Down(WDriver);
                        Thread.Sleep(500);
                        //if (kwm.isElementDisplayed(WDriver, KeyWords.ID_MSG_UserManagement))
                        //{
                        //    goto sameMSP;
                        //}
                        if (kwm.isElementDisplayedByXPath(WDriver, KeyWords.XPath_Link__SearchResults_ClientUser))
                        {
                            Thread.Sleep(2000);
                            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Link__SearchResults_ClientUser);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Link__SearchResults_MspUser);
                            }
                            objCommonMethods.SaveScreenShot_EachPage(WDriver, approveModel.strClientName + "_");
                        }
                        else
                        {

                            kwm.waitForElementExists(WDriver, By.XPath(KeyWords.XPath_Link__SearchResults_ClientUser), kwm._WDWait);
                            kwm.jsClick(WDriver, KeyWords.locator_CSS, "#dgrClientUsers1 tbody tr.odd td a");
                        }
                    }
                    catch (Exception e)
                    {
                        results.ErrorMessage = "No such user(" + sApproverName + ") is available with the given data";
                        objCommonMethods.SaveScreenShot_EachPage(WDriver, approveModel.strClientName + "_");
                        results.Result1 = KeyWords.Result_FAIL;
                        return results;
                    }

                ViewDesktop:
                    kwm.waitForElementToBeVisible(WDriver, By.Id("mainContainer_1"), kwm._WDWait);

                    try
                    {
                        kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.ID_Link_ClientUser_ViewDesktop_DefaultContent_LblViewDesktop);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            objCommonMethods.Action_Page_Down(WDriver);
                            results = kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.ID_Link_ClientUser_ViewDesktop_DefaultContent_LblViewDesktop);
                        }
                    }
                    catch (Exception e)
                    {
                        objCommonMethods.Action_Page_Down(WDriver);
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Link_ClientUser_ViewDesktop_DefaultContent_LblViewDesktop);
                        if (results.Result1 == KeyWords.Result_FAIL)
                            return results;
                    }
                    kwm.waitForElementToBeVisible(WDriver, By.XPath("//ul[@class='logoDropdown']//li//div"), kwm._WDWait);
                    objCommonMethods.SaveScreenShot_EachPage(WDriver, approveModel.strClientName + "_");


                    //   click on main menu given name
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, approveModel.strMainMenuLink, approveModel.strSubMenuLink);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(5000);
                        results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, approveModel.strMainMenuLink, approveModel.strSubMenuLink);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //results.ErrorMessage1 = "Unable to click on the Main menu";
                            return results;
                        }
                    }



                    objCommonMethods.SaveScreenShot_EachPage(WDriver, approveModel.strClientName + "_");


                    if (approveModel.strSubMenuLink.ToLower().Contains("identified"))
                    {
                        results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, approveModel.strMainMenuLink, approveModel.strSubMenuLink);
                        if (!kwm.waitForElementExists(WDriver, By.XPath(KeyWords.XPath_SearchBox_IdentifiedRequirements_regReqList), kwm._WDWait))
                        {
                            Thread.Sleep(2000);
                        }

                        //Search requirement
                        kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_SearchBox_IdentifiedRequirements_regReqList, approveModel.str_Link_ReqNumber, false);
                        objCommonMethods.SaveScreenShot_EachPage(WDriver, approveModel.strClientName + "_");
                        //Wait for Requirement to load
                        if (!kwm.waitForElementExists(WDriver, By.XPath(KeyWords.XPath_Img_Processing), kwm._WDWait))
                        {
                            if (kwm.waitForElementToBeClickable(WDriver, By.XPath("//table[@id='IdentifiedReqList']//td[2]/a"), kwm._WDWait))
                            {
                                results.ErrorMessage = "Requirement Link is displayed and clickable";
                            }
                            else
                            {
                                if (!kwm.isElementDisplayedByXPath(WDriver, "//table[@id='IdentifiedReqList']//td[2]/a"))
                                {
                                    objCommonMethods.SaveScreenShot_EachPage(WDriver, approveModel.strClientName + "_");
                                    throw new Exception("Requirement link is not displayed for the client user");
                                }
                            }
                        }
                        //click on the retrieved requirement
                        WDriver.FindElement(By.XPath("//table[@id='IdentifiedReqList']//td[2]/a")).Click();

                    }
                    else
                    {
                        //if (!kwm.waitForElementExists(WDriver, By.XPath(KeyWords.XPath_SearchBox_Requirements_regReqList), kwm._WDWait))
                        //{
                        //    Thread.Sleep(2000);
                        //}
                        kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_SearchBox_Requirements_regReqList), kwm._WDWait);
                        kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_SearchBox_Requirements_regReqList), kwm._WDWait);


                        //Search requirement
                        kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.XPath_SearchBox_Requirements_regReqList, approveModel.str_Link_ReqNumber, false);
                        objCommonMethods.SaveScreenShot_EachPage(WDriver, approveModel.strClientName + "_");
                        //Wait for Requirement to load
                        if (!kwm.waitForElementExists(WDriver, By.XPath(KeyWords.XPath_Img_Processing), kwm._WDWait))
                        {
                            if (kwm.waitForElementToBeClickable(WDriver, By.XPath("//table[@id='regReqList']//td[2]/a"), kwm._WDWait))
                            {
                                results.ErrorMessage = "Requirement Link is displayed and clicable";
                            }
                            else
                            {
                                if (!kwm.isElementDisplayedByXPath(WDriver, "//table[@id='regReqList']//td[2]/a"))
                                {
                                    objCommonMethods.SaveScreenShot_EachPage(WDriver, approveModel.strClientName + "_");
                                    throw new Exception("Requirement link is not displayed for the client user");
                                }
                            }
                        }
                        //click on the retrieved requirement
                        WDriver.FindElement(By.XPath("//table[@id='regReqList']//td[2]/a")).Click();

                    }


                    //check (or) wait for approve link
                    kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_Link_Approve_reqApprove), kwm._WDWait);

                    objCommonMethods.SaveScreenShot_EachPage(WDriver, approveModel.strClientName + "_");

                    if (approveModel.str_Link_Approve.ToLower().Contains("approve"))
                    {
                        Approver_Approve(WDriver);

                    }
                    else
                    {
                      //  Approver_Reject(WDriver);
                        iCount++;
                        break;
                    }

                    objCommonMethods.SaveScreenShot_EachPage(WDriver, approveModel.strClientName + "_");

                    //click on Return Link
                    if (!sApproverName.Contains("@"))
                    {
                        kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Link_Return);
                    }
                    //Wait till the page gets loaded
                    kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_list_LogoDropdown), kwm._WDWait);
                    objCommonMethods.SaveScreenShot_EachPage(WDriver, approveModel.strClientName + "_");
                    iCount++;
                    if (!sQueueStatus.ToLower().Contains("approval"))
                    {
                        break;
                    }

                }

                if (approver_list.Count != iCount)
                {
                    goto rerun;
                }

            }
            else if (bVal_Approved)
            {
                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = KeyWords.MSG_strApprovesuccessfully;
                return results;
            }
            else
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Approver List is not available";
                return results;

            }

            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_strApprovesuccessfully;
            return results;
        }
        
        public void Approver_Approve(IWebDriver WDriver)
        {
            try
            {
                //Click on Approve Link
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Link_Approve_reqApprove);

                //Wait for popup to get loaded
                kwm.waitForElementToBeVisible(WDriver, By.Id("reqActionContent"), kwm._WDWait);
                if (!kwm.isElementDisplayed(WDriver, "reqActionContent")) //IsElementDisplayed method find an element with ID
                {
                    kwm.waitForElementToBeVisible(WDriver, By.Id("reqActionContent"), kwm._WDWait);
                }

                // Enter Approve comment
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_TxtComment, approveModel.str_Link_ReqNumber + " :Approver comment", false);

                objCommonMethods.SaveScreenShot_EachPage(WDriver, approveModel.strClientName + "_");
                //Click on approve button on message box
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_MsgBox_Btn_Approve_Approve);

                //Wait for Confirm Approve popup(1) to get loaded
                kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_MsgBox_Btn_ConfirmApprove_Yes_Yes), kwm._WDWait);
                if (!kwm.isElementDisplayedByXPath(WDriver, KeyWords.XPath_MsgBox_Btn_ConfirmApprove_Yes_Yes))
                {
                    kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_MsgBox_Btn_ConfirmApprove_Yes_Yes), kwm._WDWait);
                }
                objCommonMethods.SaveScreenShot_EachPage(WDriver, approveModel.strClientName + "_");
                //Click on [Yes]
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_MsgBox_Btn_ConfirmApprove_Yes_Yes);

                //Wait for Confirm Approve popup(2) to get loaded
                kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_MsgBox_Btn_ConfirmApprove_OK_OK), kwm._WDWait);
                if (!kwm.isElementDisplayedByXPath(WDriver, KeyWords.XPath_MsgBox_Btn_ConfirmApprove_OK_OK))
                {
                    kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_MsgBox_Btn_ConfirmApprove_OK_OK), kwm._WDWait);
                }
                objCommonMethods.SaveScreenShot_EachPage(WDriver, approveModel.strClientName + "_");
                //Click on [Ok]
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_MsgBox_Btn_ConfirmApprove_OK_OK);
                ReportHandler._getChildTest().Log(LogStatus.Pass, "Requisition approved successfully by : " + kwm.GetText_Xpath(WDriver, "//div[@id='desktopView']/strong")._Var);
                //Wait for page to load
                kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_Label_QueueStatus), kwm._WDWait);
                //get the status
                sQueueStatus = kwm.GetText_Xpath(WDriver, KeyWords.XPath_Label_QueueStatus)._Var;
                ReportHandler._getChildTest().Log(LogStatus.Pass, "Requisition Status :" + sQueueStatus);

            }
            catch (Exception e)
            {
                ReportHandler._getChildTest().Log(LogStatus.Error, e.Message);
            }
        }

        public void Approver_Reject(IWebDriver WDriver)
        {
            try
            {
                //Click on Reject Link
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Link_Reject_reqReject);

                //Wait for popup to get loaded
                kwm.waitForElementToBeVisible(WDriver, By.Id("reqActionContent"), kwm._WDWait);
                if (!kwm.isElementDisplayed(WDriver, "reqActionContent")) //IsElementDisplayed method find an element with ID
                {
                    kwm.waitForElementToBeVisible(WDriver, By.Id("reqActionContent"), kwm._WDWait);
                }

                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_RejectPopup_Select_ReasonToReject_RejectReason, approveModel.str_ID_RejectPopup_Select_ReasonToReject_RejectReason);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_RejectPopup_Select_ReasonToReject_RejectReason, 1);
                }

                // Enter Reject comment
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_TxtComment, approveModel.str_Link_ReqNumber + " :Approver comment", false);

                objCommonMethods.SaveScreenShot_EachPage(WDriver, approveModel.strClientName + "_");
                //Click on Reject button on message box
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_RejectPopup_Btn_Reject);

                //Wait for Confirm Approve popup(1) to get loaded
                kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPATH_RejectPopup_Btn_Reject_Yes), kwm._WDWait);
                if (!kwm.isElementDisplayedByXPath(WDriver, KeyWords.XPATH_RejectPopup_Btn_Reject_Yes))
                {
                    kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPATH_RejectPopup_Btn_Reject_Yes), kwm._WDWait);
                }
                objCommonMethods.SaveScreenShot_EachPage(WDriver, approveModel.strClientName + "_");
                //Click on [Yes]
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_RejectPopup_Btn_Reject_Yes);

                //Wait for Confirm Approve popup(2) to get loaded
                kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPATH_RejectPopup_Btn_Reject_Ok), kwm._WDWait);
                if (!kwm.isElementDisplayedByXPath(WDriver, KeyWords.XPATH_RejectPopup_Btn_Reject_Ok))
                {
                    kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPATH_RejectPopup_Btn_Reject_Ok), kwm._WDWait);
                }
                objCommonMethods.SaveScreenShot_EachPage(WDriver, approveModel.strClientName + "_");
                //Click on [Ok]
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPATH_RejectPopup_Btn_Reject_Ok);
                ReportHandler._getChildTest().Log(LogStatus.Pass, "Requisition Rejected by : " + kwm.GetText_Xpath(WDriver, "//div[@id='desktopView']/strong")._Var);
                //Wait for page to load
                kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_Label_QueueStatus), kwm._WDWait);
                //get the status
                sQueueStatus = kwm.GetText_Xpath(WDriver, KeyWords.XPath_Label_QueueStatus)._Var;
                ReportHandler._getChildTest().Log(LogStatus.Pass, "Requisition Status :" + sQueueStatus);

            }
            catch (Exception e)
            {
                ReportHandler._getChildTest().Log(LogStatus.Error, e.Message);
            }
        }

    }

}