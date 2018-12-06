// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AcceptWorkOrder.cs" company="DCR Workforce Inc">
//   Copyright (c) DCR Workforce Inc. All rights reserved.
//   This code and information should not be copied and used outside of DCR Workforce Inc.
// </copyright>
// <summary>
//   Defines the Registration Repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System.Data;
using System.Configuration;
using System.Net;
using System.Collections;
using OpenQA.Selenium;
using System.Threading;
using System;
using CommonFiles;
using SmartTrack.DataAccess.Repository;
using SmartTrack.DataAccess.Models;
using RelevantCodes.ExtentReports;
using System.Collections.Generic;

namespace SmartTrack_Automation
{
    // [TestClass]
    public class AcceptWorkOrder
    {
        public Result AcceptWorkOrder_Method(IWebDriver WDriver, DataRow AcceptWorkOrder_Data, int SupExecutionRowNo)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>();
            //ArrayList listExistClients = new ArrayList { };
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            AcceptWorkOrderModel acceptWorkOrderModel = createRequirementRepository.GetAcceptWorkOrderData(AcceptWorkOrder_Data);
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);



            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");


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
                results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptWorkOrderModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //Thread.Sleep(000);
                    results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptWorkOrderModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");
            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptWorkOrderModel.strMainMenuLink, acceptWorkOrderModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptWorkOrderModel.strMainMenuLink, acceptWorkOrderModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");

            // Wait for element
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Supplier_Submitcandidate_Reqno), kwm._WDWait);

            //Req no passed into search
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Supplier_Submitcandidate_Reqno, acceptWorkOrderModel.str_Link_ReqNumber, false);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.sendText_XPath(WDriver, KeyWords.locator_ID, KeyWords.ID_Supplier_Submitcandidate_Reqno, KeyWords.ID_Txt_txtGolbalFilterReqs, acceptWorkOrderModel.str_Link_ReqNumber, false);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results.ErrorMessage = results.ErrorMessage + "," + " Problem Enter REQ Number in Search filed";

                }

            }

            //Requirement number click
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Link_Requirementnumber);

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);



            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");
            string strSubLevel = "";
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, acceptWorkOrderModel.str_Link_CandidatesWithOffers, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, acceptWorkOrderModel.str_Link_CandidatesWithOffers, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Txt_Filter_HistoryTableViewSuppReqs_filter1), kwm._WDWait);
            //Open the candidates page and Candidate name passed into search box
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Filter_HistoryTableViewSuppReqs_filter1, acceptWorkOrderModel.str_CandidateName, false);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_Link_Requirementnumber_supplier), kwm._WDWait);
            Thread.Sleep(4000);
            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Link_Requirementnumber_supplier);

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);


            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");
            //accept offer


            strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, acceptWorkOrderModel.str_Link_AcceptWorkOrder_Data, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, acceptWorkOrderModel.str_Link_AcceptWorkOrder_Data, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            //For DFS Client new Feilds Added
            if (acceptWorkOrderModel.strClientName.ToString().ToLower() == Constants.Discover)
            {
                //Does this resource have a Social Security Number?
                if (acceptWorkOrderModel.str_Radiobtn_DoesthisresourcehaveaSocialSecurityNumber_isSSNAvailable != "")
                {
                    if (acceptWorkOrderModel.str_Radiobtn_DoesthisresourcehaveaSocialSecurityNumber_isSSNAvailable.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radiobtn_DoesthisresourcehaveaSocialSecurityNumber_isSSNAvailable1);


                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SocailSecurityNumber_candidateSSN, acceptWorkOrderModel.str_txt_SocailSecurityNumber_candidateSSN, false);

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_ConfirmSocailSecurityNumber_candidateSSNConfirm, acceptWorkOrderModel.str_txt_ConfirmSocailSecurityNumber_candidateSSNConfirm, false);

                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radiobtn_DoesthisresourcehaveaSocialSecurityNumber_isSSNAvailable0);
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radiobtn_DoesthisresourcehaveaSocialSecurityNumber_isSSNAvailable0);

                }

                objCommonMethods.Action_Page_Down(WDriver);

            }
            else if (acceptWorkOrderModel.strClientName.ToString().ToLower() == Constants.QuickenLoans)
            {
                //Socail Security Number 
                if (acceptWorkOrderModel.str_txt_SocailSecurityNumber_candidateSSN != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SocailSecurityNumber_candidateSSN, acceptWorkOrderModel.str_txt_SocailSecurityNumber_candidateSSN, false);

                //DOB
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_DateofBirth_DOB);

                if (acceptWorkOrderModel.str_Date_DateofBirth_DOB != "")
                {
                    results = kwm.Select_Date_In_DatePicker(WDriver, acceptWorkOrderModel.str_Date_DateofBirth_DOB);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_DateofBirth_DOB, acceptWorkOrderModel.str_Date_DateofBirth_DOB, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //return results;
                        }
                    }
                }

                //Race
                if (acceptWorkOrderModel.str_Select_Race_nativeAmericanID != "")
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Race_nativeAmericanID, acceptWorkOrderModel.str_Select_Race_nativeAmericanID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        try
                        {
                            results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Race_nativeAmericanID, acceptWorkOrderModel.str_Select_Race_nativeAmericanID);
                        }
                        catch
                        {
                            //
                        }
                    }
                }

                //Gender
                if (acceptWorkOrderModel.str_Select_Gender_Gender != "")
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Gender_Gender, acceptWorkOrderModel.str_Select_Gender_Gender);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        try
                        {
                            results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Gender_Gender, acceptWorkOrderModel.str_Select_Gender_Gender);
                        }
                        catch
                        {
                            //
                        }
                    }
                }


                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_emergencyContact2Phone);
            }

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Txt_homephone), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_homephone);

            // Phone Number
            if (acceptWorkOrderModel.str_Txt_PhoneNumber_homephone != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_PhoneNumber_homephone, acceptWorkOrderModel.str_Txt_PhoneNumber_homephone, false);

            // Email *
            DateTime date1 = DateTime.Now;
            string timeStamp = date1.ToString("HHmmssffff");
            if (acceptWorkOrderModel.str_Txt_Email_email != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Email_email, timeStamp + acceptWorkOrderModel.str_Txt_Email_email, false);

            // Address Line 1
            if (acceptWorkOrderModel.str_Txt_AddressLine1_address1 != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AddressLine1_address1, acceptWorkOrderModel.str_Txt_AddressLine1_address1, false);

            // Address Line 2
            if (acceptWorkOrderModel.str_Txt__AddressLine2_address2 != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt__AddressLine2_address2, acceptWorkOrderModel.str_Txt__AddressLine2_address2, false);

            // City
            if (acceptWorkOrderModel.str_Txt_City_city != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_City_city, acceptWorkOrderModel.str_Txt_City_city, false);
            // State
            if (acceptWorkOrderModel.str_Select_State_state != "")
                kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_State_state, acceptWorkOrderModel.str_Select_State_state);
            // Zip
            if (acceptWorkOrderModel.str_Txt_Zip_zip != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Zip_zip, acceptWorkOrderModel.str_Txt_Zip_zip, false);

            // Emergency Contact Name
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_EmergencyContactName_emergencyContact1Name);
            if (acceptWorkOrderModel.str_Txt_EmergencyContactName_emergencyContact1Name != "")
            {
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_EmergencyContactName_emergencyContact1Name, acceptWorkOrderModel.str_Txt_EmergencyContactName_emergencyContact1Name, false);
            }

            // Emergency Contact Phone
            if (acceptWorkOrderModel.str_Txt_EmergencyContactPhone_emergencyContact1Phone != "")
            {
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_EmergencyContactPhone_emergencyContact1Phone, acceptWorkOrderModel.str_Txt_EmergencyContactPhone_emergencyContact1Phone, false);
            }

            // 2nd Emergency Contact Name
            if (acceptWorkOrderModel.str_Txt_2ndEmergencyContactName_emergencyContact2Name != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_2ndEmergencyContactName_emergencyContact2Name, acceptWorkOrderModel.str_Txt_2ndEmergencyContactName_emergencyContact2Name, false);

            // 2nd Emergency Contact Phone
            if (acceptWorkOrderModel.str_Txt_2ndEmergencyContactPhone_emergencyContact2Phone != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_2ndEmergencyContactPhone_emergencyContact2Phone, acceptWorkOrderModel.str_Txt_2ndEmergencyContactPhone_emergencyContact2Phone, false);

            // Preferred Sales Tax Location //
            // Country *
            results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Country_SCountry, acceptWorkOrderModel.str_Select_Country_SCountry);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Country_SCountry, acceptWorkOrderModel.str_Select_Country_SCountry);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            // State *
            results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_State_SState, acceptWorkOrderModel.str_Select_State_SState);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_State_SState, acceptWorkOrderModel.str_Select_State_SState);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            // County *
            results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_SCounty, acceptWorkOrderModel.str_Select_SCounty);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Select_SCounty), kwm._WDWait);
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_SCounty, acceptWorkOrderModel.str_Select_SCounty);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }






            //if (acceptWorkOrderModel.str_Txt_homephone != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_homephone, acceptWorkOrderModel.str_Txt_homephone, false);

            //if (acceptWorkOrderModel.str_Txt_email != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_email, acceptWorkOrderModel.str_Txt_email, false);

            //if (acceptWorkOrderModel.str_Txt_address1 != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_address1, acceptWorkOrderModel.str_Txt_address1, false);

            //if (acceptWorkOrderModel.str_Txt_address2 != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_address2, acceptWorkOrderModel.str_Txt_address2, false);

            //if (acceptWorkOrderModel.str_Txt_city != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_city, acceptWorkOrderModel.str_Txt_city, false);

            //objCommonMethods.Action_Page_Down(WDriver);

            //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_zip);
            //if (acceptWorkOrderModel.str_Txt_zip != "")
            //{

            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_zip, acceptWorkOrderModel.str_Txt_zip, false);
            //}

            //if (acceptWorkOrderModel.str_Select_state != "")
            //    kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_state, acceptWorkOrderModel.str_Select_state);

            //if (acceptWorkOrderModel.str_Txt_emergencyContact1Name != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_emergencyContact1Name, acceptWorkOrderModel.str_Txt_emergencyContact1Name, false);

            //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_emergencyContact1Phone);
            //if (acceptWorkOrderModel.str_Txt_emergencyContact1Phone != "")
            //{
            //    kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Txt_emergencyContact1Phone), kwm._WDWait);
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_emergencyContact1Phone, acceptWorkOrderModel.str_Txt_emergencyContact1Phone, false);
            //}

            //if (acceptWorkOrderModel.str_Txt_emergencyContact2Name != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_emergencyContact2Name, acceptWorkOrderModel.str_Txt_emergencyContact2Name, false);

            //if (acceptWorkOrderModel.str_Txt_emergencyContact2Phone != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_emergencyContact2Phone, acceptWorkOrderModel.str_Txt_emergencyContact2Phone, false);




            objCommonMethods.Action_Button_Tab(WDriver);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");
            if (acceptWorkOrderModel.str_Btn_Accept_Submit.ToLower().Trim() == "accept")
            {
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptWorkOrderModel.str_Btn_Accept_Submit);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptWorkOrderModel.str_Btn_Accept_Submit);

                }
            }
            else
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Given button name not find " + acceptWorkOrderModel.str_Btn_Accept_Submit;
                return results;
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");
            results = kwm.Error_Msg_Read_Submit_Resume_details(WDriver, "//div[@" + KeyWords.locator_ID + "='dialog']/div/div/div/ul/li");
            if (results.Result1 == KeyWords.Result_PASS)
            {
                if (results.ErrorMessage != "")
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    return results;
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");
            Thread.Sleep(2000);
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptWorkOrderModel.str_Btn_AcceptWorkOrder_Data_Submit_Confirm);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(1000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptWorkOrderModel.str_Btn_AcceptWorkOrder_Data_Submit_Confirm);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(1000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptWorkOrderModel.str_Btn_AcceptWorkOrder_Data_Submit_Confirm);

                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptWorkOrderModel.str_Btn_AcceptWorkOrder_Data_Submit_Confirm_Ok);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptWorkOrderModel.str_Btn_AcceptWorkOrder_Data_Submit_Confirm_Ok);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptWorkOrderModel.str_Btn_AcceptWorkOrder_Data_Submit_Confirm_Ok);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }

            //  Thread.Sleep(10000);
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = "Accept Work Order Submit";
            return results;
        }

        public Result Identify_AcceptWorkOrder_Method(IWebDriver WDriver, DataRow AcceptWorkOrder_Data, int SupExecutionRowNo)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            //ArrayList listExistClients = new ArrayList { };
            List<string> listExistClients = new List<string>();
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            AcceptWorkOrderModel acceptWorkOrderModel = createRequirementRepository.GetAcceptWorkOrderData(AcceptWorkOrder_Data);
         //   AcceptWorkOrderModel acceptWorkOrderModel_Lablel = createRequirementRepository.GetAcceptWorkOrderData(AcceptWorkOrder_Data_label);
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);



            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");


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
                results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptWorkOrderModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //Thread.Sleep(000);
                    results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptWorkOrderModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");
            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptWorkOrderModel.strMainMenuLink, acceptWorkOrderModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptWorkOrderModel.strMainMenuLink, acceptWorkOrderModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");


            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Txt_Filter_HistoryTableViewSuppReqs_filter1), kwm._WDWait);
            //Open the candidates page and Candidate name passed into search box
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Filter_HistoryTableViewSuppReqs_filter1, acceptWorkOrderModel.str_CandidateName, false);



            kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='HistoryTableViewWO']/tbody/tr/td//a[contains(text(),'" + acceptWorkOrderModel.str_CandidateName + "')]"), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='HistoryTableViewWO']/tbody/tr/td//a[contains(text(),'" + acceptWorkOrderModel.str_CandidateName + "')]"), kwm._WDWait);
            objCommonMethods.Action_Button_Tab(WDriver);
            Thread.Sleep(2000);
            kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='HistoryTableViewWO']/tbody/tr/td//a[contains(text(),'" + acceptWorkOrderModel.str_CandidateName + "')]");
            //*[@id="identifiedCandidateListWithOffers"]/tbody/tr/td[2]/a
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");


            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");
            string strSubLevel = "";
            

           
            //accept offer


            strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, acceptWorkOrderModel.str_Link_AcceptWorkOrder_Data, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, acceptWorkOrderModel.str_Link_AcceptWorkOrder_Data, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            //For DFS Client new Feilds Added
            if (acceptWorkOrderModel.strClientName.ToString().ToLower() == Constants.Discover)
            {
                //Does this resource have a Social Security Number?
                if (acceptWorkOrderModel.str_Radiobtn_DoesthisresourcehaveaSocialSecurityNumber_isSSNAvailable != "")
                {
                    if (acceptWorkOrderModel.str_Radiobtn_DoesthisresourcehaveaSocialSecurityNumber_isSSNAvailable.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radiobtn_DoesthisresourcehaveaSocialSecurityNumber_isSSNAvailable1);


                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SocailSecurityNumber_candidateSSN, acceptWorkOrderModel.str_txt_SocailSecurityNumber_candidateSSN, false);

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_ConfirmSocailSecurityNumber_candidateSSNConfirm, acceptWorkOrderModel.str_txt_ConfirmSocailSecurityNumber_candidateSSNConfirm, false);

                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radiobtn_DoesthisresourcehaveaSocialSecurityNumber_isSSNAvailable0);
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radiobtn_DoesthisresourcehaveaSocialSecurityNumber_isSSNAvailable0);

                }

                objCommonMethods.Action_Page_Down(WDriver);

            }
            else if (acceptWorkOrderModel.strClientName.ToString().ToLower() == Constants.QuickenLoans)
            {
                //Socail Security Number 
                if (acceptWorkOrderModel.str_txt_SocailSecurityNumber_candidateSSN != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SocailSecurityNumber_candidateSSN, acceptWorkOrderModel.str_txt_SocailSecurityNumber_candidateSSN, false);

                //DOB
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_DateofBirth_DOB);

                if (acceptWorkOrderModel.str_Date_DateofBirth_DOB != "")
                {
                    results = kwm.Select_Date_In_DatePicker(WDriver, acceptWorkOrderModel.str_Date_DateofBirth_DOB);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_DateofBirth_DOB, acceptWorkOrderModel.str_Date_DateofBirth_DOB, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //return results;
                        }
                    }
                }

                //Race
                if (acceptWorkOrderModel.str_Select_Race_nativeAmericanID != "")
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Race_nativeAmericanID, acceptWorkOrderModel.str_Select_Race_nativeAmericanID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        try
                        {
                            results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Race_nativeAmericanID, acceptWorkOrderModel.str_Select_Race_nativeAmericanID);
                        }
                        catch
                        {
                            //
                        }
                    }
                }

                //Gender
                if (acceptWorkOrderModel.str_Select_Gender_Gender != "")
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Gender_Gender, acceptWorkOrderModel.str_Select_Gender_Gender);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        try
                        {
                            results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Gender_Gender, acceptWorkOrderModel.str_Select_Gender_Gender);
                        }
                        catch
                        {
                            //
                        }
                    }
                }


                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_emergencyContact2Phone);
            }

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Txt_homephone), kwm._WDWait);
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_homephone);

            // Phone Number
            if (acceptWorkOrderModel.str_Txt_PhoneNumber_homephone != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_PhoneNumber_homephone, acceptWorkOrderModel.str_Txt_PhoneNumber_homephone, false);

            // Email *
            DateTime date1 = DateTime.Now;
            string timeStamp = date1.ToString("HHmmssffff");
            if (acceptWorkOrderModel.str_Txt_Email_email != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Email_email, timeStamp + acceptWorkOrderModel.str_Txt_Email_email, false);

            // Address Line 1
            if (acceptWorkOrderModel.str_Txt_AddressLine1_address1 != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_AddressLine1_address1, acceptWorkOrderModel.str_Txt_AddressLine1_address1, false);

            // Address Line 2
            if (acceptWorkOrderModel.str_Txt__AddressLine2_address2 != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt__AddressLine2_address2, acceptWorkOrderModel.str_Txt__AddressLine2_address2, false);

            // City
            if (acceptWorkOrderModel.str_Txt_City_city != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_City_city, acceptWorkOrderModel.str_Txt_City_city, false);
            // State
             listExistClients = new List<string>() { Constants.QuickenLoans };
             if (listExistClients.Contains(acceptWorkOrderModel.strClientName.ToLower()))
             {
                 results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_State_state, KeyWords.locator_class, KeyWords.CL_list_typeahead, "a");
             }
             else
             {

                 if (acceptWorkOrderModel.str_Select_State_state != "")
                 {
                     kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_State_state, acceptWorkOrderModel.str_Select_State_state);
                 }
             }
            // Zip
            if (acceptWorkOrderModel.str_Txt_Zip_zip != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Zip_zip, acceptWorkOrderModel.str_Txt_Zip_zip, false);

            // Emergency Contact Name
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_EmergencyContactName_emergencyContact1Name);
            if (acceptWorkOrderModel.str_Txt_EmergencyContactName_emergencyContact1Name != "")
            {
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_EmergencyContactName_emergencyContact1Name, acceptWorkOrderModel.str_Txt_EmergencyContactName_emergencyContact1Name, false);
            }

            // Emergency Contact Phone
            if (acceptWorkOrderModel.str_Txt_EmergencyContactPhone_emergencyContact1Phone != "")
            {
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_EmergencyContactPhone_emergencyContact1Phone, acceptWorkOrderModel.str_Txt_EmergencyContactPhone_emergencyContact1Phone, false);
            }

            // 2nd Emergency Contact Name
            if (acceptWorkOrderModel.str_Txt_2ndEmergencyContactName_emergencyContact2Name != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_2ndEmergencyContactName_emergencyContact2Name, acceptWorkOrderModel.str_Txt_2ndEmergencyContactName_emergencyContact2Name, false);

            // 2nd Emergency Contact Phone
            if (acceptWorkOrderModel.str_Txt_2ndEmergencyContactPhone_emergencyContact2Phone != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_2ndEmergencyContactPhone_emergencyContact2Phone, acceptWorkOrderModel.str_Txt_2ndEmergencyContactPhone_emergencyContact2Phone, false);

            // Preferred Sales Tax Location //
            // Country *
            results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Country_SCountry, acceptWorkOrderModel.str_Select_Country_SCountry);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Country_SCountry, acceptWorkOrderModel.str_Select_Country_SCountry);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            // State *
            results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_State_SState, acceptWorkOrderModel.str_Select_State_SState);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_State_SState, acceptWorkOrderModel.str_Select_State_SState);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            // County *
            results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_SCounty, acceptWorkOrderModel.str_Select_SCounty);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Select_SCounty), kwm._WDWait);
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_SCounty, acceptWorkOrderModel.str_Select_SCounty);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }






            //if (acceptWorkOrderModel.str_Txt_homephone != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_homephone, acceptWorkOrderModel.str_Txt_homephone, false);

            //if (acceptWorkOrderModel.str_Txt_email != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_email, acceptWorkOrderModel.str_Txt_email, false);

            //if (acceptWorkOrderModel.str_Txt_address1 != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_address1, acceptWorkOrderModel.str_Txt_address1, false);

            //if (acceptWorkOrderModel.str_Txt_address2 != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_address2, acceptWorkOrderModel.str_Txt_address2, false);

            //if (acceptWorkOrderModel.str_Txt_city != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_city, acceptWorkOrderModel.str_Txt_city, false);

            //objCommonMethods.Action_Page_Down(WDriver);

            //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_zip);
            //if (acceptWorkOrderModel.str_Txt_zip != "")
            //{

            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_zip, acceptWorkOrderModel.str_Txt_zip, false);
            //}

            //if (acceptWorkOrderModel.str_Select_state != "")
            //    kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_state, acceptWorkOrderModel.str_Select_state);

            //if (acceptWorkOrderModel.str_Txt_emergencyContact1Name != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_emergencyContact1Name, acceptWorkOrderModel.str_Txt_emergencyContact1Name, false);

            //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_emergencyContact1Phone);
            //if (acceptWorkOrderModel.str_Txt_emergencyContact1Phone != "")
            //{
            //    kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Txt_emergencyContact1Phone), kwm._WDWait);
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_emergencyContact1Phone, acceptWorkOrderModel.str_Txt_emergencyContact1Phone, false);
            //}

            //if (acceptWorkOrderModel.str_Txt_emergencyContact2Name != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_emergencyContact2Name, acceptWorkOrderModel.str_Txt_emergencyContact2Name, false);

            //if (acceptWorkOrderModel.str_Txt_emergencyContact2Phone != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_emergencyContact2Phone, acceptWorkOrderModel.str_Txt_emergencyContact2Phone, false);




            objCommonMethods.Action_Button_Tab(WDriver);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");
            if (acceptWorkOrderModel.str_Btn_Accept_Submit.ToLower().Trim() == "accept")
            {
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptWorkOrderModel.str_Btn_Accept_Submit);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptWorkOrderModel.str_Btn_Accept_Submit);

                }
            }
            else
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Given button name not find " + acceptWorkOrderModel.str_Btn_Accept_Submit;
                return results;
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");
            results = kwm.Error_Msg_Read_Submit_Resume_details(WDriver, "//div[@" + KeyWords.locator_ID + "='dialog']/div/div/div/ul/li");
            if (results.Result1 == KeyWords.Result_PASS)
            {
                if (results.ErrorMessage != "")
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    return results;
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");
            Thread.Sleep(2000);
            kwm.waitForElementToBeVisible(WDriver, By.XPath("//div[@id='dvBeforeAcceptWorkOrder']//div[@aria-live='polite']//label"), kwm._WDWait);
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptWorkOrderModel.str_Btn_AcceptWorkOrder_Data_Submit_Confirm);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(1000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptWorkOrderModel.str_Btn_AcceptWorkOrder_Data_Submit_Confirm);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(1000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptWorkOrderModel.str_Btn_AcceptWorkOrder_Data_Submit_Confirm);

                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");
            kwm.waitForElementToBeVisible(WDriver, By.XPath("//div[@id='dvAfterAcceptWorkOrder']//div[@aria-live='polite']//label"), kwm._WDWait);
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptWorkOrderModel.str_Btn_AcceptWorkOrder_Data_Submit_Confirm_Ok);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptWorkOrderModel.str_Btn_AcceptWorkOrder_Data_Submit_Confirm_Ok);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptWorkOrderModel.str_Btn_AcceptWorkOrder_Data_Submit_Confirm_Ok);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }

            //  Thread.Sleep(10000);
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = "Accept Work Order Submit";
            return results;
        }


        public Result RejectWorkOrder_Method(IWebDriver WDriver, DataRow AcceptWorkOrder_Data, int SupExecutionRowNo)
        {

            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            //ArrayList listExistClients = new ArrayList { };
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            AcceptWorkOrderModel acceptWorkOrderModel = createRequirementRepository.GetAcceptWorkOrderData(AcceptWorkOrder_Data);
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 100);

            // CLient selection
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");


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
                results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptWorkOrderModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //Thread.Sleep(000);
                    results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptWorkOrderModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }
            //SUbmenu click

            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");
            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptWorkOrderModel.strMainMenuLink, acceptWorkOrderModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptWorkOrderModel.strMainMenuLink, acceptWorkOrderModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");
            Thread.Sleep(2000);
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Supplier_Submitcandidate_Reqno), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Supplier_Submitcandidate_Reqno), kwm._WDWait);

            //Requirement number is passed into text box
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Supplier_Submitcandidate_Reqno, acceptWorkOrderModel.str_Link_ReqNumber, false);

            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results.ErrorMessage = results.ErrorMessage + "," + " Problem Enter REQ Number in Search filed";
                return results;
            }


            try
            {
                WDriver.FindElement(By.LinkText(acceptWorkOrderModel.str_Link_ReqNumber)).Click();
            }
            catch
            {
                Thread.Sleep(100);
                try
                {
                    WDriver.FindElement(By.LinkText(acceptWorkOrderModel.str_Link_ReqNumber)).Click();
                }
                catch
                {
                    // Console.WriteLine(bFlag);
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given Req Number not find " + acceptWorkOrderModel.str_Link_ReqNumber;
                    return results;
                }
            }

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);

            //Candidates With Offers

            string strSubLevel = "";
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, acceptWorkOrderModel.str_Link_CandidatesWithOffers, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, acceptWorkOrderModel.str_Link_CandidatesWithOffers, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }
            Thread.Sleep(1000);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");

            kwm.waitForElementToBeVisible(WDriver, By.LinkText(acceptWorkOrderModel.str_CandidateName), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.LinkText(acceptWorkOrderModel.str_CandidateName), kwm._WDWait);


            //Cnaidate name click 

            if (acceptWorkOrderModel.str_CandidateName.ToLower().Trim() == "")
            {
                results = kwm.GetNameFromReqNumber("FN", acceptWorkOrderModel.str_Link_ReqNumber);
                // string strCan
                string strFN = "";
                if (results.Result1 == KeyWords.Result_PASS)
                {
                    strFN = results.ErrorMessage;
                }
                // results
                results = kwm.GetNameFromReqNumber("LN", acceptWorkOrderModel.str_Link_ReqNumber);
                string strLN = "";
                if (results.Result1 == KeyWords.Result_PASS)
                {
                    strLN = results.ErrorMessage;
                }

                acceptWorkOrderModel.str_CandidateName = strLN + ", " + strFN;
            }

            try
            {
                WDriver.FindElement(By.LinkText(acceptWorkOrderModel.str_CandidateName)).Click();
            }
            catch
            {
                Thread.Sleep(1000);
                try
                {
                    WDriver.FindElement(By.LinkText(acceptWorkOrderModel.str_CandidateName)).Click();
                }
                catch
                {
                    // Console.WriteLine(bFlag);
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given canditate name not find " + acceptWorkOrderModel.str_CandidateName;
                    return results;
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");

            // Rejet work order link click 
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            strSubLevel = "";
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptWorkOrderModel.strClientName + "_");
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, acceptWorkOrderModel.str_Link_RejectWorkOrder, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, acceptWorkOrderModel.str_Link_RejectWorkOrder, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }
            Thread.Sleep(2000);
            //Reject Work Order Reason *
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Select_RejectworkorderReason), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Select_RejectworkorderReason), kwm._WDWait);
            results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_RejectworkorderReason);


            Thread.Sleep(2000);

            //Comment

            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_RejectOfferComment, acceptWorkOrderModel.str_Txt_RejectWorkOrderComment, false);
            Thread.Sleep(2000);
            //Cancel Work Order Button Click

            results = kwm.select_Button(WDriver, KeyWords.locator_class, KeyWords.locator_class_button, acceptWorkOrderModel.str_Button_Reject);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_class, KeyWords.locator_class_button, acceptWorkOrderModel.str_Button_Reject);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            //Yes button click in Pop up

            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_RejectWorkOrder_yes), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_RejectWorkOrder_yes), kwm._WDWait);
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptWorkOrderModel.str_Btn_AcceptWorkOrder_Data_Submit_Confirm);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptWorkOrderModel.str_Btn_AcceptWorkOrder_Data_Submit_Confirm);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            //Ok button click
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_RejectWorkOrder_Ok), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_RejectWorkOrder_Ok), kwm._WDWait);

            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptWorkOrderModel.str_Btn_AcceptWorkOrder_Data_Submit_Confirm_Ok);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptWorkOrderModel.str_Btn_AcceptWorkOrder_Data_Submit_Confirm_Ok);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            // Enter candidate name in search field

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Txt_Filter_HistoryTableViewSuppReqs_filter1), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Txt_Filter_HistoryTableViewSuppReqs_filter1), kwm._WDWait);
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Filter_HistoryTableViewSuppReqs_filter1, acceptWorkOrderModel.str_CandidateName, false);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Filter_HistoryTableViewSuppReqs_filter1, acceptWorkOrderModel.str_CandidateName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }


            // Click on Candidate Name link
            try
            {
                WDriver.FindElement(By.LinkText(acceptWorkOrderModel.str_CandidateName)).Click();
            }
            catch
            {
                Thread.Sleep(1000);
                try
                {
                    WDriver.FindElement(By.LinkText(acceptWorkOrderModel.str_CandidateName)).Click();
                }
                catch
                {
                    // Console.WriteLine(bFlag);
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given canditate name not find " + acceptWorkOrderModel.str_CandidateName;
                    return results;
                }
            }

            // Get Requirement status from application
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_Label_CandidateStatus), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_Label_CandidateStatus), kwm._WDWait);
            results = kwm.GetText_Xpath(WDriver, KeyWords.Xpath_Label_CandidateStatus);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results = kwm.GetText_Xpath(WDriver, KeyWords.Xpath_Label_CandidateStatus);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            // Status comparision
            String ActualStatus = results._Var;
            if (ActualStatus == "WO Rejected")
            {

            }
            else
            {
                results.Result1 = KeyWords.Result_FAIL;
                return results;
            }



            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = "Reject Work Order Submit";
            return results;
        }

    }
}