// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AcceptOffer.cs" company="DCR Workforce Inc">
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
using CommonFiles;
using SmartTrack.DataAccess.Repository;
using SmartTrack.DataAccess.Models;
using RelevantCodes.ExtentReports;

namespace SmartTrack_Automation
{
    // [TestClass]
    public class AcceptOffer
    {
        public Result AcceptOffer_Method(IWebDriver WDriver, DataRow AcceptOffer_Data)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            AcceptOfferModel acceptOfferModel = createRequirementRepository.GetAcceptOfferData(AcceptOffer_Data);
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 150);


            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");

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
                results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptOfferModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //Thread.Sleep(000);
                    results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptOfferModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptOfferModel.strMainMenuLink, acceptOfferModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptOfferModel.strMainMenuLink, acceptOfferModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }
            string strSubLevel = "";
            //*[@id="HistoryTableViewWO"]/tbody/tr/td[1]/a
            if ("candidates with offers" != acceptOfferModel.strSubMenuLink.ToLower().ToString())
            {
               

                objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");


                // Wait for element
                kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Supplier_Submitcandidate_Reqno), kwm._WDWait);

                //Req no passed into search

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Supplier_Submitcandidate_Reqno, acceptOfferModel.str_Link_ReqNumber, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText_XPath(WDriver, KeyWords.locator_ID, KeyWords.ID_Supplier_Submitcandidate_Reqno, KeyWords.ID_Txt_txtGolbalFilterReqs, acceptOfferModel.str_Link_ReqNumber, false);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results.ErrorMessage = results.ErrorMessage + "," + " Problem Enter REQ Number in Search filed";

                    }

                }
                //Thread.Sleep(5000);
                //Requirement number click
                objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_Link_Requirementnumber);

                kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);

                //Candidate with offers link click 
                strSubLevel = "";
                objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, acceptOfferModel.str_Link_CandidatesWithOffers, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, acceptOfferModel.str_Link_CandidatesWithOffers, strSubLevel);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Txt_Filter_HistoryTableViewSuppReqs_filter1), kwm._WDWait);
            //Open the candidates page and Candidate name passed into search box
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Filter_HistoryTableViewSuppReqs_filter1, acceptOfferModel.str_CandidateName, false);

            

            kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='HistoryTableViewWO']/tbody/tr/td//a[contains(text(),'" + acceptOfferModel.str_CandidateName + "')]"), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='HistoryTableViewWO']/tbody/tr/td//a[contains(text(),'" + acceptOfferModel.str_CandidateName + "')]"), kwm._WDWait);
            objCommonMethods.Action_Button_Tab(WDriver);
            Thread.Sleep(2000);
            kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='HistoryTableViewWO']/tbody/tr/td//a[contains(text(),'" + acceptOfferModel.str_CandidateName + "')]");

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);


            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
            //accept offer
            //Loading message
            for (int z = 1; z < 50; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(Constants.LoadingMessage)).Displayed;
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

            // RejectOffer_Method(WDriver, AcceptOffer_Data);
            strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, acceptOfferModel.str_Link_AcceptOffer, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, acceptOfferModel.str_Link_AcceptOffer, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }



            // CandidateActioncontent
            bool bFilterTxt = false;
            for (int iFTxt = 0; iFTxt < 100; iFTxt++)
            {
                try
                {
                    bFilterTxt = WDriver.FindElement(By.Id("CandidateActioncontent")).Displayed;
                }
                catch
                {
                    kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, acceptOfferModel.str_Link_AcceptOffer, strSubLevel);
                }
                if (bFilterTxt)
                    break;
            }

            listExistClients = new List<string>() { "supervalu", "aero", "arkema", "meritor", "yp", "dcr", "amcom", "nv energy", "savi technologies", "sts", "is&gs", "bda", "ghc", "ebs", "mst", "stgen", "stttm", "mfc", "epri", "caesars", "costco", "discover", "keybank", "welch allyn", "stewart title" };
            if (listExistClients.Contains(acceptOfferModel.strClientName.ToLower()))
            {
                if (acceptOfferModel.str_Txt_SmartTrackIdentifier != "")
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_STID, acceptOfferModel.str_Txt_SmartTrackIdentifier, false);
            }

            if (acceptOfferModel.str_Txt_candidateSSN != "")
            {
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_candidateSSN, acceptOfferModel.str_Txt_candidateSSN, false);
            }


            if (acceptOfferModel.str_Date_DOB != "")
            {

                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_DOB);
                Thread.Sleep(1000);
                kwm.Select_Date_Picker_DOB(WDriver, acceptOfferModel.str_Date_DOB);
            }


            results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Country, acceptOfferModel.str_Select_Country);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Select_State), kwm._WDWait);
            //Select state
            results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_State, acceptOfferModel.str_Select_state);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Select_County), kwm._WDWait);
            //Select county
            results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_County, acceptOfferModel.str_Select_County);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1);
         //   results = kwm.sendText(WDriver, KeyWords.locator_ID, "STID", acceptOfferModel.str_Txt_Email, false);

            // objCommonMethods.Action_Page_Down(WDriver);
            if (acceptOfferModel.str_Btn_Accept_Submit.ToLower().Trim() == "accept")
            {
                objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Btn_Accept_Submit);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Btn_Accept_Submit);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }
            else
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Given button name not find " + acceptOfferModel.str_Btn_Accept_Submit;
                return results;
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
            results = kwm.Error_Msg_Read_Submit_Resume_details(WDriver, "//div[@" + KeyWords.locator_ID + "='dialog']/div/div/div/ul/li");
            if (results.Result1 == KeyWords.Result_PASS)
            {
                if (results.ErrorMessage != "")
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    return results;
                }
            }
            //Accept offer button click 
            if (WDriver.FindElement(By.Id("dvBeforeAcceptOffer")).Displayed)
            {

                if (acceptOfferModel.str_Btn_AcceptOffer_Submit_Confirm != "")
                {
                    objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Btn_AcceptOffer_Submit_Confirm);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(5000);
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Btn_AcceptOffer_Submit_Confirm);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            Thread.Sleep(10000);
                            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Btn_AcceptOffer_Submit_Confirm);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                return results;
                            }
                        }
                    }
                }
                else
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Accept Offer confirm button name is empty";
                    return results;
                }
            }
            else
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Unable to find the confirm msg box";
                return results;
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Btn_AcceptOffer_Submit_Confirm_Ok);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Btn_AcceptOffer_Submit_Confirm_Ok);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(10000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Btn_AcceptOffer_Submit_Confirm_Ok);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results.Result1 = KeyWords.Result_PASS;
                        return results;
                    }
                }
            }


            //   Thread.Sleep(10000);
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = "Accept Offer submit";
            return results;
        }

        //public Result Indentify_AcceptOffer_Method(IWebDriver WDriver, DataRow AcceptOffer_Data)
        //{
        //    KeyWordMethods kwm = new KeyWordMethods();
        //    CommonMethods objCommonMethods = new CommonMethods();
        //    var results = new Result();
        //    var Result_ScreenShot = new Result();
        //    List<string> listExistClients = new List<string>() { };
        //    CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
        //    AcceptOfferModel acceptOfferModel = createRequirementRepository.GetAcceptOfferData(AcceptOffer_Data);
        //    kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 150);


        //    objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");

        //    Boolean bFlagDropDwon = false;
        //    try
        //    {
        //        bFlagDropDwon = WDriver.FindElement(By.XPath(KeyWords.XPath_supplierMenu_ClientDropDown)).Enabled;
        //    }
        //    catch
        //    {
        //        bFlagDropDwon = false;
        //    }
        //    if (bFlagDropDwon)
        //    {
        //        results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptOfferModel.strClientName);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            //Thread.Sleep(000);
        //            results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptOfferModel.strClientName);
        //            if (results.Result1 == KeyWords.Result_FAIL)
        //            {
        //                return results;
        //            }
        //        }
        //    }
        //    objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
        //    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptOfferModel.strMainMenuLink, acceptOfferModel.strSubMenuLink);
        //    if (results.Result1 == KeyWords.Result_FAIL)
        //    {
        //        Thread.Sleep(5000);
        //        results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptOfferModel.strMainMenuLink, acceptOfferModel.strSubMenuLink);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            return results;
        //        }
        //    }
        //    string strSubLevel = "";

        //    objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");

        //    kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Txt_Filter_HistoryTableViewSuppReqs_filter1), kwm._WDWait);
        //    //Open the candidates page and Candidate name passed into search box
        //    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Filter_HistoryTableViewSuppReqs_filter1, acceptOfferModel.str_CandidateName, false);



        //    kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='HistoryTableViewWO']/tbody/tr/td//a[contains(text(),'" + acceptOfferModel.str_CandidateName + "')]"), kwm._WDWait);
        //    kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='HistoryTableViewWO']/tbody/tr/td//a[contains(text(),'" + acceptOfferModel.str_CandidateName + "')]"), kwm._WDWait);
        //    objCommonMethods.Action_Button_Tab(WDriver);
        //    Thread.Sleep(2000);
        //    kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='HistoryTableViewWO']/tbody/tr/td//a[contains(text(),'" + acceptOfferModel.str_CandidateName + "')]");

        //    kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);


        //    objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
        //    //accept offer
        //    //Loading message
        //    for (int z = 1; z < 50; z++)
        //    {
        //        Boolean strValue = true;
        //        try
        //        {
        //            strValue = WDriver.FindElement(By.Id(Constants.LoadingMessage)).Displayed;
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

        //    // RejectOffer_Method(WDriver, AcceptOffer_Data);
        //    strSubLevel = "";
        //    results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, acceptOfferModel.str_Link_AcceptOffer, strSubLevel);
        //    if (results.Result1 == KeyWords.Result_FAIL)
        //    {
        //        Thread.Sleep(5000);
        //        results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, acceptOfferModel.str_Link_AcceptOffer, strSubLevel);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            return results;
        //        }
        //    }



        //    // CandidateActioncontent
        //    bool bFilterTxt = false;
        //    for (int iFTxt = 0; iFTxt < 100; iFTxt++)
        //    {
        //        try
        //        {
        //            bFilterTxt = WDriver.FindElement(By.Id("LastName")).Displayed;
        //        }
        //        catch
        //        {
        //            kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, acceptOfferModel.str_Link_AcceptOffer, strSubLevel);
        //        }
        //        if (bFilterTxt)
        //            break;
        //    }

        //    //Last Name
        //    if (acceptOfferModel.str_Txt_LastName_LastName != "")
        //        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_LastName_LastName, acceptOfferModel.str_Txt_LastName_LastName, true);

        //    //First Name
        //    if (acceptOfferModel.str_Txt_FirstName_FirstName != "")
        //        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_FirstName_FirstName, acceptOfferModel.str_Txt_FirstName_FirstName, true);

        //    //Middle Name
        //    if (acceptOfferModel.str_txt_MiddleName_MiddleName != "")
        //        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MiddleName_MiddleName, acceptOfferModel.str_txt_MiddleName_MiddleName, true);

        //    //Suffix
        //    if (acceptOfferModel.str_Select_SuffixName_SuffixName != "")
        //        kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_SuffixName_SuffixName, acceptOfferModel.str_Select_SuffixName_SuffixName);


        //    //Available
        //    if (acceptOfferModel.str_Radio_Available_Available != "")
        //    {
        //        if (acceptOfferModel.str_Radio_Available_Available.ToLower().Equals(KeyWords.str_String_Compare_yes))
        //        {
        //            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_Available_AvailableYes);
        //            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Available_AvailableDate);
        //            results = kwm.Select_Start_Date_From_Picker(WDriver, acceptOfferModel.str_Date_Available_AvailableDate);

        //        }
        //        else
        //        {
        //            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_Available_AvailableNo);
        //        }

        //    }

        //    //Permanant Location 
        //    if (acceptOfferModel.str_Txt_PermanatLocation_LocationCity != "")
        //        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_PermanatLocation_LocationCity, acceptOfferModel.str_Txt_PermanatLocation_LocationCity, true);

        //    //State
        //    if (acceptOfferModel.str_Select_State_StatesID != "")
        //        kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_State_StatesID, acceptOfferModel.str_Select_State_StatesID);

        //    //Recruiter
        //    if (acceptOfferModel.str_Select_Recruiter_RecruiterName != "")
        //        kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Recruiter_RecruiterName, acceptOfferModel.str_Select_Recruiter_RecruiterName);

        //    //Keywords
        //    if (acceptOfferModel.str_Txt_Keywords_Keywords != "")
        //        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Keywords_Keywords, acceptOfferModel.str_Txt_Keywords_Keywords, true);

        //    //Resume 

        //    //Retiree
        //    //YP Holdings or AT&T Retiree
        //    if (acceptOfferModel.str_Radiobutton_Retiree_RetireeRadio != "")
        //    {
        //        if (acceptOfferModel.str_Radiobutton_Retiree_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
        //        {
        //            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radiobutton_Retiree_RetireeRadio1);

        //            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_RetiredDate_RetiredDate);

        //            if (acceptOfferModel.str_Date_RetiredDate_RetiredDate != "")
        //            {
        //                results = kwm.Select_Start_Date_From_Picker(WDriver, acceptOfferModel.str_Date_RetiredDate_RetiredDate);
        //                if (results.Result1 == KeyWords.Result_FAIL)
        //                {
        //                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_RetiredDate_RetiredDate, acceptOfferModel.str_Date_RetiredDate_RetiredDate, false);
        //                    if (results.Result1 == KeyWords.Result_FAIL)
        //                    {
        //                        //return results;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                results = kwm.Select_Date_In_DatePicker(WDriver, acceptOfferModel.str_Date_RetiredDate_RetiredDate);
        //            }

        //        }
        //        else
        //        {

        //            results = objCommonMethods.Select_Radio_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_RadioButton_Retiree_RetireeRadio0);

        //        }

        //        //Job Title 
        //        if (acceptOfferModel.str_txt_RetireeJobTitle_RetiredJobTitle != "")
        //        {
        //            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_RetireeJobTitle_RetiredJobTitle, acceptOfferModel.str_txt_RetireeJobTitle_RetiredJobTitle, false);
        //        }

        //    }

        //    //Skill Year
        //    if (acceptOfferModel.str_select_YearsExperience_skillYearsExpID != "")
        //    {
        //        Thread.Sleep(3000);
        //        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, acceptOfferModel.str_select_YearsExperience_skillYearsExpID);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            Thread.Sleep(5000);
        //            results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, acceptOfferModel.str_select_YearsExperience_skillYearsExpID);
        //            if (results.Result1 == KeyWords.Result_FAIL)
        //            {
        //                //return results;
        //            }
        //        }
        //    }
        //    Thread.Sleep(2000);

        //    //Skill Level
        //    if (acceptOfferModel.str_radiobutton_Level_skillLevelID != "")
        //    {
        //        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + acceptOfferModel.str_radiobutton_Level_skillLevelID);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            //return results;
        //        }
        //    }

        //    //Comments
        //    if (acceptOfferModel.str_txt_Comments_supplierComments != "")
        //    {
        //        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, acceptOfferModel.str_txt_Comments_supplierComments, false);
        //    }

        //    //Past/Present Miltary Employement
        //    if (acceptOfferModel.str_Radio_PastPresentMilitaryEmployment_Employment != "")
        //    {
        //        if (acceptOfferModel.str_Radio_PastPresentMilitaryEmployment_Employment.ToLower().Equals(KeyWords.str_String_Compare_yes))
        //        {
        //            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_PastPresentMilitaryEmployment_Employment1);
        //            {
        //                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_PastPresentMilitaryEmployment_EmploymentDetails, acceptOfferModel.str_Txt_PastPresentMilitaryEmployment_EmploymentDetails, false);
        //            }
        //        }
        //        else
        //        {
        //            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_PastPresentMilitaryEmployment_Employment0);
        //        }

        //    }


        //    //Former Employee

        //    if (acceptOfferModel.str_radiobutton_FormerEmployee_ExperienceRadio != "")
        //    {
        //        if (acceptOfferModel.str_radiobutton_FormerEmployee_ExperienceRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
        //        {
        //            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

        //            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1);

        //            if (acceptOfferModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
        //            {
        //                results = kwm.Select_Start_Date_From_Picker(WDriver, acceptOfferModel.str_Date_FromerEmployeeFromDate_fromDate1);
        //                if (results.Result1 == KeyWords.Result_FAIL)
        //                {
        //                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, acceptOfferModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
        //                    if (results.Result1 == KeyWords.Result_FAIL)
        //                    {
        //                        //return results;
        //                    }
        //                }
        //            }
        //            //else
        //            //{
        //            //    results = kwm.Select_Date_In_DatePicker(WDriver, acceptOfferModel.str_Date_FromerEmployeeToDate_toDate1);
        //            //}

        //            //To Date

        //            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeToDate_toDate1);

        //            if (acceptOfferModel.str_Date_FromerEmployeeToDate_toDate1 != "")
        //            {
        //                results = kwm.Select_End_Date_From_Picker(WDriver, acceptOfferModel.str_Date_FromerEmployeeToDate_toDate1);


        //                if (results.Result1 == KeyWords.Result_FAIL)
        //                {
        //                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeToDate_toDate1, acceptOfferModel.str_Date_FromerEmployeeToDate_toDate1, false);
        //                }

        //            }

        //            //Job Title 
        //            if (acceptOfferModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
        //            {
        //                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, acceptOfferModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
        //            }

        //            // Supervisor
        //            if (acceptOfferModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
        //            {
        //                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, acceptOfferModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
        //            }



        //        }
        //        else
        //        {

        //            results = objCommonMethods.Select_Radio_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio0);

        //        }
        //    }
        //    else
        //    {

        //        Thread.Sleep(2000);
        //        results = objCommonMethods.Select_Radio_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio0);
        //    }

        //    //Former Contractor 
        //    if (acceptOfferModel.str_radiobutton_FromerContractor_contractor != "")
        //    {
        //        if (acceptOfferModel.str_radiobutton_FromerContractor_contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
        //        {
        //            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FromerContractor_contractor1);

        //            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractor_fromDateContractor1);

        //            if (acceptOfferModel.str_Date_FormerContractor_fromDateContractor1 != "")
        //            {
        //                results = kwm.Select_Start_Date_From_Picker(WDriver, acceptOfferModel.str_Date_FormerContractor_fromDateContractor1);
        //                if (results.Result1 == KeyWords.Result_FAIL)
        //                {
        //                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractor_fromDateContractor1, acceptOfferModel.str_Date_FormerContractor_fromDateContractor1, false);
        //                    if (results.Result1 == KeyWords.Result_FAIL)
        //                    {
        //                        //return results;
        //                    }
        //                }
        //            }
        //            //else
        //            //{
        //            //    results = kwm.Select_Date_In_DatePicker(WDriver, acceptOfferModel.str_Date_FromerEmployeeToDate_toDate1);
        //            //}

        //            //To Date

        //            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractor_toDateContractor1);

        //            if (acceptOfferModel.str_Date_FormerContractor_toDateContractor1 != "")
        //            {
        //                results = kwm.Select_End_Date_From_Picker(WDriver, acceptOfferModel.str_Date_FormerContractor_toDateContractor1);


        //                if (results.Result1 == KeyWords.Result_FAIL)
        //                {
        //                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractor_toDateContractor1, acceptOfferModel.str_Date_FormerContractor_toDateContractor1, false);
        //                }

        //            }

        //            //Job Title 
        //            if (acceptOfferModel.str_txt_FromerContractorJobTitle_jobTitle != "")
        //            {
        //                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FromerContractorJobTitle_jobTitle, acceptOfferModel.str_txt_FromerContractorJobTitle_jobTitle, false);
        //            }

        //            // Supervisor
        //            if (acceptOfferModel.str_txt_FromerContractorSupervisor_supervisorName != "")
        //            {
        //                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, acceptOfferModel.str_txt_FromerContractorSupervisor_supervisorName, false);
        //            }



        //        }
        //        else
        //        {

        //            results = objCommonMethods.Select_Radio_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FromerContractor_contractor0);

        //        }
        //    }
        //    else
        //    {

        //        Thread.Sleep(2000);
        //        results = objCommonMethods.Select_Radio_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FromerContractor_contractor0);
        //    }


        //    //Candidate Pay rate 
        //    if (acceptOfferModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
        //        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, acceptOfferModel.str_txt_CandidatePayRate_supplierRegPayRate, true);


        //    //Candidate OT Pay rate 
        //    if (acceptOfferModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
        //        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, acceptOfferModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);



        //    //Bill rate 
        //    if (acceptOfferModel.str_txt_BillRate_supplierRegBillRate != "")
        //        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_BillRate_supplierRegBillRate, acceptOfferModel.str_txt_BillRate_supplierRegBillRate, true);


        //    //OT Bill rate
        //    if (acceptOfferModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
        //        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, acceptOfferModel.str_txt_SupplierOTBillRate_supplierOTBillRate, true);

        //    //Last 4 Diguts of SSN
        //    if (acceptOfferModel.str_txt_Last4DigitsofSSN_STID1 != "")
        //    {
        //        kwm.sendText_clr_backspace(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, acceptOfferModel.str_txt_Last4DigitsofSSN_STID1);
        //    }

        //    //MOnth 
        //    if (acceptOfferModel.str_select_SSNMonth_STID2 != "")
        //        kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, acceptOfferModel.str_select_SSNMonth_STID2);

        //    //Date 
        //    if (acceptOfferModel.str_select_SSNDate_STID3 != "")
        //        kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, acceptOfferModel.str_select_SSNDate_STID3);



        //    // objCommonMethods.Action_Page_Down(WDriver);
        //    if (acceptOfferModel.str_Btn_Accept_Submit.ToLower().Trim() == "accept offer")
        //    {
        //        objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
        //        results = kwm.click(WDriver, KeyWords.locator_ID, "btnSubmit");

        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            results = kwm.click(WDriver, KeyWords.locator_ID, "btnSubmit");
        //            if (results.Result1 == KeyWords.Result_FAIL)
        //            {
        //                return results;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        results.Result1 = KeyWords.Result_FAIL;
        //        results.ErrorMessage = "Given button name not find " + acceptOfferModel.str_Btn_Accept_Submit;
        //        return results;
        //    }

        //    objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
        //    results = kwm.Error_Msg_Read_Submit_Resume_details(WDriver, "//*[@id='ulMspUserError']/li");
        //    if (results.Result1 == KeyWords.Result_PASS)
        //    {
        //        if (results.ErrorMessage != "")
        //        {
        //            results.Result1 = KeyWords.Result_FAIL;
        //            return results;
        //        }
        //    }
        //    //Accept offer button click 
        //    //if (WDriver.FindElement(By.Id("dvBeforeAcceptOffer")).Displayed)
        //    //{

        //    if (acceptOfferModel.str_Btn_AcceptOffer_Submit_Confirm != "")
        //    {
        //        objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
        //        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Btn_AcceptOffer_Submit_Confirm);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            Thread.Sleep(5000);
        //            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Btn_AcceptOffer_Submit_Confirm);
        //            if (results.Result1 == KeyWords.Result_FAIL)
        //            {
        //                Thread.Sleep(10000);
        //                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Btn_AcceptOffer_Submit_Confirm);
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
        //    //  }
        //    //else
        //    //{
        //    //    results.Result1 = KeyWords.Result_FAIL;
        //    //    results.ErrorMessage = "Unable to find the confirm msg box";
        //    //    return results;
        //    //}

        //    objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
        //    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Btn_AcceptOffer_Submit_Confirm_Ok);
        //    if (results.Result1 == KeyWords.Result_FAIL)
        //    {
        //        Thread.Sleep(5000);
        //        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Btn_AcceptOffer_Submit_Confirm_Ok);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            Thread.Sleep(10000);
        //            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Btn_AcceptOffer_Submit_Confirm_Ok);
        //            if (results.Result1 == KeyWords.Result_FAIL)
        //            {
        //                results.Result1 = KeyWords.Result_PASS;
        //                return results;
        //            }
        //        }
        //    }


        //    //   Thread.Sleep(10000);
        //    results.Result1 = KeyWords.Result_PASS;
        //    results.ErrorMessage = "Accept Offer submit";
        //    return results;
        //}


        public Result Identify_AcceptOffer_Method(IWebDriver WDriver, DataRow AcceptOffer_Data)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            AcceptOfferModel acceptOfferModel = createRequirementRepository.GetAcceptOfferData(AcceptOffer_Data);
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 150);


            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");

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
                results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptOfferModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //Thread.Sleep(000);
                    results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptOfferModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptOfferModel.strMainMenuLink, acceptOfferModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptOfferModel.strMainMenuLink, acceptOfferModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }
            string strSubLevel = "";

            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Txt_Filter_HistoryTableViewSuppReqs_filter1), kwm._WDWait);
            //Open the candidates page and Candidate name passed into search box
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Filter_HistoryTableViewSuppReqs_filter1, acceptOfferModel.str_CandidateName, false);



            kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@id='HistoryTableViewWO']/tbody/tr/td//a[contains(text(),'" + acceptOfferModel.str_CandidateName + "')]"), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath("//*[@id='HistoryTableViewWO']/tbody/tr/td//a[contains(text(),'" + acceptOfferModel.str_CandidateName + "')]"), kwm._WDWait);
            objCommonMethods.Action_Button_Tab(WDriver);
            Thread.Sleep(2000);
            kwm.click(WDriver, KeyWords.locator_XPath, "//*[@id='HistoryTableViewWO']/tbody/tr/td//a[contains(text(),'" + acceptOfferModel.str_CandidateName + "')]");

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);


            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
            //accept offer
            //Loading message
            for (int z = 1; z < 50; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(Constants.LoadingMessage)).Displayed;
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

            // RejectOffer_Method(WDriver, AcceptOffer_Data);
            strSubLevel = "";
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, acceptOfferModel.str_Link_AcceptOffer, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, acceptOfferModel.str_Link_AcceptOffer, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }



            // CandidateActioncontent
            bool bFilterTxt = false;
            for (int iFTxt = 0; iFTxt < 100; iFTxt++)
            {
                try
                {
                    bFilterTxt = WDriver.FindElement(By.Id("LastName")).Displayed;
                }
                catch
                {
                    kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, acceptOfferModel.str_Link_AcceptOffer, strSubLevel);
                }
                if (bFilterTxt)
                    break;
            }

            //Last Name
            if (acceptOfferModel.str_Txt_LastName_LastName != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_LastName_LastName, acceptOfferModel.str_Txt_LastName_LastName, true);

            //First Name
            if (acceptOfferModel.str_Txt_FirstName_FirstName != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_FirstName_FirstName, acceptOfferModel.str_Txt_FirstName_FirstName, true);

            //Middle Name
            if (acceptOfferModel.str_txt_MiddleName_MiddleName != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MiddleName_MiddleName, acceptOfferModel.str_txt_MiddleName_MiddleName, true);

            //Suffix
            if (acceptOfferModel.str_Select_SuffixName_SuffixName != "")
                kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_SuffixName_SuffixName, acceptOfferModel.str_Select_SuffixName_SuffixName);


            //Available
            if (acceptOfferModel.str_Radio_Available_Available != "")
            {
                if (acceptOfferModel.str_Radio_Available_Available.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_Available_AvailableYes);
                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Available_AvailableDate);
                    results = kwm.Select_Start_Date_From_Picker(WDriver, acceptOfferModel.str_Date_Available_AvailableDate);

                }
                else
                {
                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_Available_AvailableNo);
                }

            }

            //Permanant Location 
            if (acceptOfferModel.str_Txt_PermanatLocation_LocationCity != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_PermanatLocation_LocationCity, acceptOfferModel.str_Txt_PermanatLocation_LocationCity, true);

            //State
            if (acceptOfferModel.str_Select_State_StatesID != "")
                kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_State_StatesID, acceptOfferModel.str_Select_State_StatesID);

            //Recruiter
            if (acceptOfferModel.str_Select_Recruiter_RecruiterName != "")
                kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Recruiter_RecruiterName, acceptOfferModel.str_Select_Recruiter_RecruiterName);

            //Keywords
            if (acceptOfferModel.str_Txt_Keywords_Keywords != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Keywords_Keywords, acceptOfferModel.str_Txt_Keywords_Keywords, true);

            //Resume 

            //Retiree
            //YP Holdings or AT&T Retiree
            if (acceptOfferModel.str_Radiobutton_Retiree_RetireeRadio != "")
            {
                if (acceptOfferModel.str_Radiobutton_Retiree_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radiobutton_Retiree_RetireeRadio1);

                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_RetiredDate_RetiredDate);

                    if (acceptOfferModel.str_Date_RetiredDate_RetiredDate != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(WDriver, acceptOfferModel.str_Date_RetiredDate_RetiredDate);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_RetiredDate_RetiredDate, acceptOfferModel.str_Date_RetiredDate_RetiredDate, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(WDriver, acceptOfferModel.str_Date_RetiredDate_RetiredDate);
                    }

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_RadioButton_Retiree_RetireeRadio0);

                }

                //Job Title 
                if (acceptOfferModel.str_txt_RetireeJobTitle_RetiredJobTitle != "")
                {
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_RetireeJobTitle_RetiredJobTitle, acceptOfferModel.str_txt_RetireeJobTitle_RetiredJobTitle, false);
                }

            }

            //Skill Year
            if (acceptOfferModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, acceptOfferModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, acceptOfferModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            //Skill Level
            if (acceptOfferModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + acceptOfferModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Comments
            if (acceptOfferModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, acceptOfferModel.str_txt_Comments_supplierComments, false);
            }

            //Past/Present Miltary Employement
            if (acceptOfferModel.str_Radio_PastPresentMilitaryEmployment_Employment != "")
            {
                if (acceptOfferModel.str_Radio_PastPresentMilitaryEmployment_Employment.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_PastPresentMilitaryEmployment_Employment1);
                    {
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_PastPresentMilitaryEmployment_EmploymentDetails, acceptOfferModel.str_Txt_PastPresentMilitaryEmployment_EmploymentDetails, false);
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_PastPresentMilitaryEmployment_Employment0);
                }

            }



            //Former Employee

            if (acceptOfferModel.str_radiobutton_FormerEmployee_ExperienceRadio != "")
            {
                if (acceptOfferModel.str_radiobutton_FormerEmployee_ExperienceRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1);

                    //if (acceptOfferModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    //{
                    //    results = kwm.Select_Start_Date_From_Picker(WDriver, acceptOfferModel.str_Date_FromerEmployeeFromDate_fromDate1);
                    //    if (results.Result1 == KeyWords.Result_FAIL)
                    //    {
                    //        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, acceptOfferModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                    //        if (results.Result1 == KeyWords.Result_FAIL)
                    //        {
                    //            //return results;
                    //        }
                    //    }
                    //}
                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1);
                    if (acceptOfferModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today.AddMonths(-1));
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, acceptOfferModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {

                                //return results;                
                            }
                        }
                    }
                    //else
                    //{
                    //    results = kwm.Select_Date_In_DatePicker(WDriver, acceptOfferModel.str_Date_FromerEmployeeToDate_toDate1);
                    //}

                    //To Date

                    //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeToDate_toDate1);

                    //if (acceptOfferModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    //{
                    //    results = kwm.Select_End_Date_From_Picker(WDriver, acceptOfferModel.str_Date_FromerEmployeeToDate_toDate1);


                    //    if (results.Result1 == KeyWords.Result_FAIL)
                    //    {
                    //        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeToDate_toDate1, acceptOfferModel.str_Date_FromerEmployeeToDate_toDate1, false);
                    //    }

                    //}

                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeToDate_toDate1);
                    if (acceptOfferModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeToDate_toDate1, acceptOfferModel.str_Date_FromerEmployeeToDate_toDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {

                                //return results;                
                            }
                        }
                    }

                    //Job Title 
                    if (acceptOfferModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_txt_FromerEmployeeJobTitle_jobTitle, acceptOfferModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (acceptOfferModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_txt_FromerEmployeeSupervisor_supervisorName, acceptOfferModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio0);

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio0);
            }

            //Former Contractor 
            if (acceptOfferModel.str_radiobutton_FromerContractor_contractor != "")
            {
                if (acceptOfferModel.str_radiobutton_FromerContractor_contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FromerContractor_contractor1);


                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractor_fromDateContractor1);
                    if (acceptOfferModel.str_Date_FormerContractor_fromDateContractor1 != "")
                    {
                        results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today.AddMonths(-1));
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractor_fromDateContractor1, acceptOfferModel.str_Date_FormerContractor_fromDateContractor1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {

                                //return results;                
                            }
                        }
                    }

                    //if (acceptOfferModel.str_Date_FormerContractor_fromDateContractor1 != "")
                    //{
                    //    results = kwm.Select_Start_Date_From_Picker(WDriver, acceptOfferModel.str_Date_FormerContractor_fromDateContractor1);
                    //    if (results.Result1 == KeyWords.Result_FAIL)
                    //    {
                    //        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractor_fromDateContractor1, acceptOfferModel.str_Date_FormerContractor_fromDateContractor1, false);
                    //        if (results.Result1 == KeyWords.Result_FAIL)
                    //        {
                    //            //return results;
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    results = kwm.Select_Date_In_DatePicker(WDriver, acceptOfferModel.str_Date_FromerEmployeeToDate_toDate1);
                    //}

                    //To Date

                    //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractor_toDateContractor1);

                    //if (acceptOfferModel.str_Date_FormerContractor_toDateContractor1 != "")
                    //{
                    //    results = kwm.Select_End_Date_From_Picker(WDriver, acceptOfferModel.str_Date_FormerContractor_toDateContractor1);


                    //    if (results.Result1 == KeyWords.Result_FAIL)
                    //    {
                    //        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractor_toDateContractor1, acceptOfferModel.str_Date_FormerContractor_toDateContractor1, false);
                    //    }

                    //}

                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractor_toDateContractor1);
                    if (acceptOfferModel.str_Date_FormerContractor_toDateContractor1 != "")
                    {
                        results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractor_toDateContractor1, acceptOfferModel.str_Date_FormerContractor_toDateContractor1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {

                                //return results;                
                            }
                        }
                    }

                    //Job Title 
                    if (acceptOfferModel.str_txt_FromerContractorJobTitle_jobTitle != "")
                    {
                        kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_txt_FromerContarctorJobTitle_jobTitle, acceptOfferModel.str_txt_FromerContractorJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (acceptOfferModel.str_txt_FromerContractorSupervisor_supervisorName != "")
                    {
                        kwm.sendText(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_txt_FromercontarctorSupervisor_supervisorName, acceptOfferModel.str_txt_FromerContractorSupervisor_supervisorName, false);
                    }
                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FromerContractor_contractor0);

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FromerContractor_contractor0);
            }



            //Candidate Pay rate 
            if (acceptOfferModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, acceptOfferModel.str_txt_CandidatePayRate_supplierRegPayRate, true);


            //Candidate OT Pay rate 
            if (acceptOfferModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, acceptOfferModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);



            //Bill rate 
            if (acceptOfferModel.str_txt_BillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_BillRate_supplierRegBillRate, acceptOfferModel.str_txt_BillRate_supplierRegBillRate, true);


            //OT Bill rate
            if (acceptOfferModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, acceptOfferModel.str_txt_SupplierOTBillRate_supplierOTBillRate, true);

            //Last 4 Diguts of SSN
            if (acceptOfferModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                kwm.sendText_clr_backspace(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, acceptOfferModel.str_txt_Last4DigitsofSSN_STID1);
            }

            //MOnth 
            if (acceptOfferModel.str_select_SSNMonth_STID2 != "")
                kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, acceptOfferModel.str_select_SSNMonth_STID2);

            //Date 
            if (acceptOfferModel.str_select_SSNDate_STID3 != "")
                kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, acceptOfferModel.str_select_SSNDate_STID3);
            
            //Employment Type   
            if (acceptOfferModel.str_select_EmployementType_employmentTypeID != "")   
            {
                kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_EmployementType_employmentTypeID, acceptOfferModel.str_select_EmployementType_employmentTypeID);   
            }


            // objCommonMethods.Action_Page_Down(WDriver);
            if (acceptOfferModel.str_Btn_Accept_Submit.ToLower().Trim() == "accept offer")
            {
                objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
                results = kwm.click(WDriver, KeyWords.locator_ID, "btnSubmit");

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, "btnSubmit");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }
            else
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Given button name not find " + acceptOfferModel.str_Btn_Accept_Submit;
                return results;
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
            results = kwm.Error_Msg_Read_Submit_Resume_details(WDriver, "//*[@id='ulMspUserError']/li");
            if (results.Result1 == KeyWords.Result_PASS)
            {
                if (results.ErrorMessage != "")
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    return results;
                }
            }
            //Accept offer button click 
            //if (WDriver.FindElement(By.Id("dvBeforeAcceptOffer")).Displayed)
            //{

            if (acceptOfferModel.str_Btn_AcceptOffer_Submit_Confirm != "")
            {
                objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
                kwm.waitForElementToBeVisible(WDriver, By.XPath("//div[@id='dvConfirmBefore']//div[@aria-live='polite']//label"), kwm._WDWait);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Btn_AcceptOffer_Submit_Confirm);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Btn_AcceptOffer_Submit_Confirm);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(10000);
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Btn_AcceptOffer_Submit_Confirm);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }
                }
            }
            else
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Accept Offer confirm button name is empty";
                return results;
            }
            //  }
            //else
            //{
            //    results.Result1 = KeyWords.Result_FAIL;
            //    results.ErrorMessage = "Unable to find the confirm msg box";
            //    return results;
            //}

            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
            kwm.waitForElementToBeVisible(WDriver, By.XPath("//div[@id='dvConfirmAfter']//div[@aria-live='polite']//label"), kwm._WDWait);
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Btn_AcceptOffer_Submit_Confirm_Ok);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Btn_AcceptOffer_Submit_Confirm_Ok);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(10000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Btn_AcceptOffer_Submit_Confirm_Ok);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results.Result1 = KeyWords.Result_PASS;
                        return results;
                    }
                }
            }


            //   Thread.Sleep(10000);
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = "Accept Offer submit";
            return results;
        }

        public Result RejectOffer_Method(IWebDriver WDriver, DataRow AcceptOffer_Data)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };
            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
            AcceptOfferModel acceptOfferModel = createRequirementRepository.GetAcceptOfferData(AcceptOffer_Data);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
            kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 150);


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
                results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptOfferModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //Thread.Sleep(000);
                    results = kwm.SupplierClient_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptOfferModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
            results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptOfferModel.strMainMenuLink, acceptOfferModel.strSubMenuLink);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, acceptOfferModel.strMainMenuLink, acceptOfferModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Supplier_Submitcandidate_Reqno), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Supplier_Submitcandidate_Reqno), kwm._WDWait);

            //Requirement number is passed into text box
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Supplier_Submitcandidate_Reqno, acceptOfferModel.str_Link_ReqNumber, false);

            if (results.Result1 == KeyWords.Result_FAIL)
            {
                results.ErrorMessage = results.ErrorMessage + "," + " Problem Enter REQ Number in Search filed";
                return results;
            }


            try
            {
                WDriver.FindElement(By.LinkText(acceptOfferModel.str_Link_ReqNumber)).Click();
            }
            catch
            {
                Thread.Sleep(100);
                try
                {
                    WDriver.FindElement(By.LinkText(acceptOfferModel.str_Link_ReqNumber)).Click();
                }
                catch
                {
                    // Console.WriteLine(bFlag);
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given Req Number not find " + acceptOfferModel.str_Link_ReqNumber;
                    return results;
                }
            }

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);

            //Candidates With Offers

            string strSubLevel = "";
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, acceptOfferModel.str_Link_CandidatesWithOffers, strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, acceptOfferModel.str_Link_CandidatesWithOffers, strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }
            Thread.Sleep(1000);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");

            kwm.waitForElementToBeVisible(WDriver, By.LinkText(acceptOfferModel.str_CandidateName), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.LinkText(acceptOfferModel.str_CandidateName), kwm._WDWait);


            //Cnaidate name click 

            if (acceptOfferModel.str_CandidateName.ToLower().Trim() == "")
            {
                results = kwm.GetNameFromReqNumber("FN", acceptOfferModel.str_Link_ReqNumber);
                // string strCan
                string strFN = "";
                if (results.Result1 == KeyWords.Result_PASS)
                {
                    strFN = results.ErrorMessage;
                }
                // results
                results = kwm.GetNameFromReqNumber("LN", acceptOfferModel.str_Link_ReqNumber);
                string strLN = "";
                if (results.Result1 == KeyWords.Result_PASS)
                {
                    strLN = results.ErrorMessage;
                }

                acceptOfferModel.str_CandidateName = strLN + ", " + strFN;
            }

            try
            {
                WDriver.FindElement(By.LinkText(acceptOfferModel.str_CandidateName)).Click();
            }
            catch
            {
                Thread.Sleep(1000);
                try
                {
                    WDriver.FindElement(By.LinkText(acceptOfferModel.str_CandidateName)).Click();
                }
                catch
                {
                    // Console.WriteLine(bFlag);
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given canditate name not find " + acceptOfferModel.str_CandidateName;
                    return results;
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");

            // Rejet work order link click 
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_List_listMenu1), kwm._WDWait);
            strSubLevel = "";
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, "Reject Offer", strSubLevel);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, "Reject Offer", strSubLevel);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }
            Thread.Sleep(2000);

            //Reject Offer Reason 
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Select_RejectOfferReason), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Select_RejectOfferReason), kwm._WDWait);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
            if (acceptOfferModel.str_Select_RejectOfferReason != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_RejectOfferReason, acceptOfferModel.str_Select_RejectOfferReason);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Select_RejectOfferReason))); //Selecting business unit
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }
            else
            {
                SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Select_RejectOfferReason)));
                se.SelectByIndex(1);
            }
            //Comment

            if (acceptOfferModel.str_Txt_RejectOfferReason_Comment != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_RejectOfferComment, acceptOfferModel.str_Txt_RejectOfferReason_Comment, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            results = kwm.Error_Msg_Read_Submit_Resume_details(WDriver, "//div[@" + KeyWords.locator_ID + "='dialog']/div/div/div/ul/li");
            if (results.Result1 == KeyWords.Result_PASS)
            {
                if (results.ErrorMessage != "")
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    return results;
                }
            }

            //Reject Button Click
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");

            if (acceptOfferModel.str_Button_RejectOfferReason != "")
            {
                objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Button_RejectOfferReason);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Button_RejectOfferReason);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(10000);
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Button_RejectOfferReason);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }
                }
            }
            else
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Accept Offer confirm button name is empty";
                return results;
            }


            //pop up click
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.Xpath_RejectOffer_Yes), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.Xpath_RejectOffer_Yes), kwm._WDWait);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Button_RejectOfferYes);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Button_RejectOfferYes);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Click Ok button
            kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_RejectOffer_Ok), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_RejectOffer_Ok), kwm._WDWait);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, acceptOfferModel.strClientName + "_");
            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Button_RejectOfferOK);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Thread.Sleep(5000);
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, acceptOfferModel.str_Button_RejectOfferOK);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage1 = results.ErrorMessage;
            //results.ErrorMessage = "Invoice Batch created Successfully done  -->  " + strBatchNumberCreated;
            return results;
        }




    }
}