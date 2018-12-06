// --------------------------------------------------------------------------------------------------------------------
//<copyright file="CreateRequirementSavi.cs" company="DCR Workforce Inc">
//   Copyright (c) DCR Workforce Inc. All rights reserved.
//   This code and information should not be copied and used outside of DCR Workforce Inc.
// </copyright>
// <summary>
//   Builds the Container for the Autofac IOC.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmartTrack
{
    using System;
    using System.Collections.Generic;
    using OpenQA.Selenium;
    using System.Threading;
    using OpenQA.Selenium.Support.UI;
    using System.Data;
    using System.Configuration;
    //using System.Data.OracleClient;
    using System.Net;
    //using System.Data.OracleClient;
    //using Microsoft.VisualStudio.TestTools.UnitTesting;
    using CommonFiles;
    using SmartTrack_Automation;
    using SmartTrack.DataAccess.Models;
   // using SmartTrack.DataAccess.Models;
    using SmartTrack.DataAccess.Repository;

    public class BroadcastPerClient
        
    {
       // public static void BroadcastArkema(BroadcastModel broadcastModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods, DataRow Broadcast_Data)
       //{
       //    List<string> listExistClients = new List<string>() { };
       //    try
       //    {
       //        new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id("pageTitle"))));
       //    }
       //    catch
       //    {
       //        for (int i = 0; i < 10; i++)
       //        {
       //            try
       //            {
       //                if (WDriver.FindElement(By.Id("pageTitle")).Displayed)
       //                {
       //                    break;
       //                }
       //                Thread.Sleep(100);
       //            }
       //            catch
       //            {
       //                //
       //            }
       //        }
       //    }

       //    string strSubLevel = "./label";
       //    objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
       //    if (broadcastModel.str_Link_AddComment != "")
       //    {
       //        results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, broadcastModel.str_Link_AddComment, strSubLevel);
       //        if (results.Result1 == KeyWords.Result_FAIL)
       //        {
       //            Thread.Sleep(5000);
       //            results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, broadcastModel.str_Link_AddComment, strSubLevel);
       //            if (results.Result1 == KeyWords.Result_FAIL)
       //            {
       //              //  return results;
       //            }
       //        }
       //        objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

       //        //results = AddComment_Method(WDriver, Broadcast_Data);
       //        //if (results.Result1 == KeyWords.Result_FAIL)
       //        //{
       //        //    results = AddComment_Method(WDriver, Broadcast_Data);
       //        //    if (results.Result1 == KeyWords.Result_FAIL)
       //        //    {
       //        //    }
       //        //}
       //    }
       //    results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, broadcastModel.str_Link_Broadcast, strSubLevel);
       //    if (results.Result1 == KeyWords.Result_FAIL)
       //    {
       //        Thread.Sleep(5000);
       //        results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, broadcastModel.str_Link_Broadcast, strSubLevel);
       //        if (results.Result1 == KeyWords.Result_FAIL)
       //        {
       //          //  return results;
       //        }
       //    }

       //    objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
       //    if (broadcastModel.str_Button_BroadcastToSupplier.ToLower() == KeyWords.ID_Btn_distributionlist)
       //    {
       //        listExistClients = new List<string>() { Constants.Dyncorp, Constants.SallieMae };
       //        if (listExistClients.Contains(broadcastModel.strClientName.ToLower()))
       //        {
       //            kwm.click(WDriver, KeyWords.locator_ID, Constants.PayRateMarkup, logTest);
       //        }
       //        else
       //        {
       //            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_DistributionList);
       //        }
       //    }

       //    else if (broadcastModel.str_Button_BroadcastToSupplier.ToLower() == Constants.GeoLocation)
       //    {
       //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_GeographicalLocation);
       //    }
       //    else if (broadcastModel.str_Button_BroadcastToSupplier.ToLower() == Constants.SvmsBroadcast)
       //    {
       //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_BroadcastSVMS);
       //    }
       //    else if (broadcastModel.str_Button_BroadcastToSupplier.ToLower() == Constants.SupplierMarkup)
       //    {
       //        kwm.click(WDriver, KeyWords.locator_ID, Constants.PayRateMarkup);
       //    }
       //    else if (broadcastModel.str_Button_BroadcastToSupplier.ToLower() == KeyWords.ID_Btn_payratemarkup)
       //    {
       //        kwm.click(WDriver, KeyWords.locator_ID, Constants.PayRateMarkup);
       //    }
       //    else
       //    {
       //        results.Result1 = KeyWords.Result_FAIL;
       //        results.ErrorMessage = KeyWords.Str_Btn_BroadcastToSupplierNotFound;
       //      //  return results;
       //    }
       //    try
       //    {
       //        new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.Str_dialogWindow_dialog))));
       //    }
       //    catch
       //    {
       //        for (int z = 1; z < 50; z++)
       //        {
       //            Boolean strValue = false;
       //            try
       //            {
       //                strValue = WDriver.FindElement(By.Id(KeyWords.Str_dialogWindow_dialog)).Displayed;
       //            }
       //            catch
       //            {
       //                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_DistributionList);
       //            }

       //            if (strValue)
       //            {
       //                break;
       //            }
       //        }
       //    }

       //    try
       //    {
       //        new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.XPath(KeyWords.ID_Window_topdiv))));
       //    }
       //    catch
       //    {
       //    }

       //    try
       //    {
       //        WDriver.FindElement(By.XPath(KeyWords.ID_Window_topdiv2)).Click();
       //    }
       //    catch
       //    {
       //        ////*[@id="broadcast"]
       //        try
       //        {
       //            WDriver.FindElement(By.XPath(KeyWords.ID_Btn_broadcast)).Click();
       //        }
       //        catch
       //        {
       //            //
       //        }
       //    }

       //    //     }

       //    if (broadcastModel.str_Txt_PayRates_Min.Trim().ToLower() != "")
       //    {
       //        results = kwm.sendText_clr(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_payRateMin, broadcastModel.str_Txt_PayRates_Min);
       //        if (results.Result1 == KeyWords.Result_FAIL)
       //        {
       //            //return results;
       //        }
       //    }

       //    if (broadcastModel.str_Txt_PayRates_Max.Trim().ToLower() != "")
       //    {
       //        results = kwm.sendText_clr(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_payRateMax, broadcastModel.str_Txt_PayRates_Max);
       //        if (results.Result1 == KeyWords.Result_FAIL)
       //        {
       //            //return results;
       //        }
       //    }
       //    if (broadcastModel.str_Txt_MarkUp.Trim().ToLower() != "")
       //    {
       //        results = kwm.sendText_clr(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_lblMarkupText, broadcastModel.str_Txt_MarkUp);
       //        if (results.Result1 == KeyWords.Result_FAIL)
       //        {
       //            //return results;
       //        }
       //    }

       //   if (broadcastModel.str_Txt_BillRate_Min.Trim().ToLower() != "")
       //    {
       //        results = kwm.sendText_clr(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ddlBillratesLow, broadcastModel.str_Txt_BillRate_Min);
       //        if (results.Result1 == KeyWords.Result_FAIL)
       //        {
       //            //return results;
       //        }
       //    }
       //    if (broadcastModel.str_Txt_BillRate_Max.Trim().ToLower() != "")
       //    {
       //        results = kwm.sendText_clr(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ddlBillratesHigh, broadcastModel.str_Txt_BillRate_Max);
       //        if (results.Result1 == KeyWords.Result_FAIL)
       //        {
       //            //return results;
       //        }
       //    }

       //    //   Thread.Sleep(1000);
       //    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_ddlDistList, broadcastModel.str_Select_DistributionList);
       //    if (results.Result1 == KeyWords.Result_FAIL)
       //    {
       //        Thread.Sleep(3000);
       //        results = kwm.selectInDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_ddlDistList, broadcastModel.str_Select_DistributionList);
       //        if (results.Result1 == KeyWords.Result_FAIL)
       //        {
       //            try
       //            {
       //                SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Select_ddlDistList))); //Locating select list
       //                se.SelectByIndex(2);
       //            }
       //            catch
       //            {
       //                //
       //            }
       //        }
       //    }
       //    Thread.Sleep(2000);
       //    try
       //    {
       //        new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_Select_ddlTiers))));
       //    }
       //    catch
       //    {
       //    }

       //    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_ddlTiers, broadcastModel.str_Select_Tier);
       //    if (results.Result1 == KeyWords.Result_FAIL)
       //    {
       //        Thread.Sleep(3000);
       //        try
       //        {
       //            SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Select_ddlTiers))); //Locating select list
       //            se.SelectByIndex(1);
       //            Console.WriteLine(se);
       //        }
       //        catch
       //        {
       //            //
       //        }
       //    }

       //    //    Thread.Sleep(5000);
       //    //  Thread.Sleep(3000);
       //    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_ddlGeoLocation, broadcastModel.str_Select_GeographicalLocation);
       //    if (results.Result1 == KeyWords.Result_FAIL)
       //    {
       //        results = kwm.selectInDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_ddlGeoLocation, broadcastModel.str_Select_GeographicalLocation);
       //        if (results.Result1 == KeyWords.Result_FAIL)
       //        {
       //            try
       //            {
       //                SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Select_ddlGeoLocation))); //Locating select list
       //                se.SelectByIndex(1);
       //            }
       //            catch
       //            {
       //                //
       //            }
       //        }
       //    }
       //    // viewSuppliers
       //    listExistClients = new List<string>() { Constants.YP, Constants.Aero, Constants.APS, Constants.Fabco, Constants.Dyncorp, Constants.Ryder, Constants.SallieMae };
       //    if (listExistClients.Contains(broadcastModel.strClientName.ToLower()))
       //    {
       //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_viewSuppliers);
       //    }
       //    int intColumanEmailID = 0;
       //    // string[] listSuppliers;
       //    listExistClients = new List<string>() { Constants.YP, Constants.Aero, Constants.APS, Constants.Fabco, Constants.Dyncorp, Constants.Ryder, Constants.SallieMae };
       //    Boolean blnSupplierSelected = false;
       //    if (listExistClients.Contains(broadcastModel.strClientName.ToLower()))
       //    {
       //        // Thread.Sleep(4000);
       //        //Boolean bSelectionSupplier1 = false;
       //     //   int intColumanEmailID = 0;
       //     //   Boolean blnSupplierSelected = false;
       //        if (broadcastModel.str_CheckBox_Suppliers.ToLower() == KeyWords.str_String_Compare_all)
       //        {
       //            // Thread.Sleep(4000);
       //            // kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_CheckBox_chkSelectAll);

       //            results = kwm.Supplier_Table_CheckBox_Top10_Click(WDriver);
       //            if (results.Result1 == KeyWords.Result_FAIL)
       //            {
       //               // return results;
       //            }
       //            blnSupplierSelected = results.blnFlag;
       //        }
       //        else
       //        {
       //            intColumanEmailID = 4;
       //            results = kwm.Supplier_Table_CheckBox_Click(WDriver, broadcastModel.str_CheckBox_Suppliers, '#', '-', intColumanEmailID);
       //            if (results.Result1 == KeyWords.Result_FAIL)
       //            {
       //               // return results;
       //            }

       //            if (!results.blnFlag)
       //            {
       //                //  kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_CheckBox_chkSelectAll);
       //                results = kwm.Supplier_Table_CheckBox_Top10_Click(WDriver);
       //                if (results.Result1 == KeyWords.Result_FAIL)
       //                {
       //                   // return results;
       //                }
       //                blnSupplierSelected = results.blnFlag;
       //                // results.Result1 = KeyWords.Result_FAIL;
       //                //results.ErrorMessage = "The given supplier EmailID's are not matched";
       //                //return results;
       //            }
       //        }
       //        //  Thread.Sleep(2000);

       //        // Distribution - Select button
       //        //     listExistClients = new List<string>() {Constants.Dyncorp, Constants.Ryder };
       //        //if (listExistClients.Contains(broadcastModel.strClientName.ToLower()))
       //        //{
       //        //    kwm.click_Xpath(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Btn_SelectDistributionlist);
       //        //}

       //        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, broadcastModel.str_Button_SupplierSelection);
       //        if (results.Result1 == KeyWords.Result_FAIL)
       //        {
       //            Thread.Sleep(5000);
       //            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, broadcastModel.str_Button_SupplierSelection);
       //            if (results.Result1 == KeyWords.Result_FAIL)
       //            {
       //                Thread.Sleep(5000);
       //                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, broadcastModel.str_Button_SupplierSelection);
       //                if (results.Result1 == KeyWords.Result_FAIL)
       //                {
       //                   // return results;
       //                }
       //            }
       //        }
       //        // Thread.Sleep(3000);
       //    }
       //    else
       //    {
       //        // Thread.Sleep(4000);
       //        // Boolean bSelectionSupplier1 = false;
       //     //   int intColumanEmailID = 0;
       //      //  Boolean blnSupplierSelected = false;
       //        if (broadcastModel.str_CheckBox_Suppliers.ToLower() == KeyWords.str_String_Compare_all)
       //        {
       //            results = kwm.Supplier_Table_CheckBox_Top10_Click(WDriver);
       //            if (results.Result1 == KeyWords.Result_FAIL)
       //            {
       //               // return results;
       //            }
       //            blnSupplierSelected = results.blnFlag;

       //        }
       //        else
       //        {
       //            try
       //            {
       //                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_Tbl_tblSuppliers))));
       //            }
       //            catch
       //            {
       //            }
       //            intColumanEmailID = 3;
       //            results = kwm.Supplier_Table_CheckBox_Click(WDriver, broadcastModel.str_CheckBox_Suppliers, '#', '-', intColumanEmailID);
       //            if (results.Result1 == KeyWords.Result_FAIL)
       //            {
       //               // return results;
       //            }
       //            blnSupplierSelected = results.blnFlag;

       //        }
       //    }
           
       //    if (!blnSupplierSelected)
       //    {
       //        IWebElement element = null;
       //        element = kwm.inspect(WDriver, KeyWords.locator_ID, KeyWords.ID_CheckBox_chkSelectAll);
       //        if (element == null)
       //        {
       //            //  Console.WriteLine("I am here");

       //            Thread.Sleep(1000);
       //            objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
       //         //   Result_ScreenShot = objCommonMethods.SaveScreenShot(WDriver, "TestCase_" + Broadcast_Data[0] + "_");
       //            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, KeyWords.ID_Btn_Close);
       //            if (results.Result1 == KeyWords.Result_FAIL)
       //            {
       //                Thread.Sleep(5000);
       //                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, KeyWords.ID_Btn_Close);
       //                if (results.Result1 == KeyWords.Result_FAIL)
       //                {
       //                    //return results;
       //                }
       //            }
       //            objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
       //            results.Result1 = KeyWords.Result_FAIL;
       //            results.ErrorMessage = "No Suppiers found for the given search criteria";
       //           // if (Result_ScreenShot.Result1 == KeyWords.Result_PASS)
       //           // {
       //           //     results.ErrorMessage = results.ErrorMessage + " , " + Result_ScreenShot.ErrorMessage;
       //           // }
       //           //// return results;
       //        }
       //    }
       //    objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
       //    //  Thread.Sleep(2000);
       //    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, broadcastModel.str_Btn_Broadcast_Action);
       //    if (results.Result1 == KeyWords.Result_FAIL)
       //    {
       //        Thread.Sleep(3000);
       //        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, broadcastModel.str_Btn_Broadcast_Action);
       //        if (results.Result1 == KeyWords.Result_FAIL)
       //        {
       //           // return results;
       //        }
       //    }
       //    objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

       //    // AddComment_Method

       //    // SelectedSupplier_Broadcast_Method(
       //    // objCommonMethods.
       //    //SelectedSupplier_Broadcast_Method(WDriver, Broadcast_Data);
       //    // Thread.Sleep(2000);
       //    try
       //    {
       //        new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_dlgBox_dlgConfirmSuppliers))));
       //    }
       //    catch
       //    {
       //    }
       //    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, broadcastModel.str_Btn_Broadcast_Action_Confirm);
       //    if (results.Result1 == KeyWords.Result_FAIL)
       //    {
       //        Thread.Sleep(3000);
       //        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, broadcastModel.str_Btn_Broadcast_Action_Confirm);
       //        if (results.Result1 == KeyWords.Result_FAIL)
       //        {
       //            Thread.Sleep(3000);
       //            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, broadcastModel.str_Btn_Broadcast_Action_Confirm);
       //            if (results.Result1 == KeyWords.Result_FAIL)
       //            {
       //               // return results;
       //            }
       //        }
       //    }
       //    // Thread.Sleep(10000);
       //    objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
       //    try
       //    {
       //        new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_Tbl_tblSuppliers))));
       //    }
       //    catch
       //    {
       //    }
       //    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, broadcastModel.str_Btn_Broadcast_Req_Action_Confirm);
       //    if (results.Result1 == KeyWords.Result_FAIL)
       //    {
       //        //    dlgBroadcastSent
       //        Boolean strValue = false;
       //        for (int z = 1; z < 100; z++)
       //        {
       //            try
       //            {
       //                strValue = WDriver.FindElement(By.Id(KeyWords.ID_Window_dlgBroadcastSent)).Displayed;
       //            }
       //            catch
       //            {
       //                strValue = false;
       //            }
       //            Thread.Sleep(100);
       //            //  Console.WriteLine("z -----> " + z);
       //            //  Console.WriteLine("strValue -----> " + strValue);
       //            if (strValue)
       //            {
       //                results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, broadcastModel.str_Btn_Broadcast_Req_Action_Confirm);
       //                break;
       //            }
       //        }
       //        //Thread.Sleep(5000);
       //        if (!strValue)
       //        {
       //            results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, broadcastModel.str_Btn_Broadcast_Req_Action_Confirm);
       //            if (results.Result1 == KeyWords.Result_FAIL)
       //            {
       //                Thread.Sleep(5000);
       //                results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, broadcastModel.str_Btn_Broadcast_Req_Action_Confirm);
       //                if (results.Result1 == KeyWords.Result_FAIL)
       //                {
       //                    Thread.Sleep(5000);
       //                    results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, broadcastModel.str_Btn_Broadcast_Req_Action_Confirm);
       //                    if (results.Result1 == KeyWords.Result_FAIL)
       //                    {
       //                       // return results;
       //                    }
       //                }
       //            }
       //        }
       //    }

        
          
       //}

       // public Result AddComment_Method(IWebDriver WDriver, DataRow Broadcast_Data)
       // {
       //     KeyWordMethods kwm = new KeyWordMethods();
       //     CommonMethods objCommonMethods = new CommonMethods();
       //     CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
       //     BroadcastModel broadcastModel = createRequirementRepository.GetBroadcastData(Broadcast_Data);

       //     var results = new Result();
       //     var Result_ScreenShot = new Result();
       //     //string str_Radio_DisplayComment = Broadcast_Data["P24"].ToString().Trim();
       //     //string str_TxtArea_Comment = Broadcast_Data["P25"].ToString().Trim();
       //     //string str_Btn_Submit = Broadcast_Data["P26"].ToString().Trim();
       //     //string str_Btn_Comment_confirm_Yes = Broadcast_Data["P27"].ToString().Trim();
       //     //string str_Btn_Comment_confirm_Ok = Broadcast_Data["P28"].ToString().Trim();

       //     if (!kwm.isElementDisplayed(WDriver, KeyWords.Str_dialogWindow_dialog))
       //     {
       //         Thread.Sleep(5000);
       //     }
       //     if (!kwm.isElementDisplayed(WDriver, KeyWords.Str_dialogWindow_dialog))
       //     {
       //         results.Result1 = KeyWords.Result_FAIL;
       //         results.ErrorMessage = "Add Comment Window is not display";
       //         return results;
       //     }
       //     kwm.click(WDriver, KeyWords.locator_ID, broadcastModel.str_Radio_DisplayComment);

       //     kwm.sendText(WDriver, KeyWords.locator_ID, "TxtComment", broadcastModel.str_TxtArea_Comment, false);
       //     kwm.select_MSG_Button(WDriver, KeyWords.locator_type, "button", broadcastModel.str_Btn_Submit);

       //     if (kwm.isElementDisplayedByXPath(WDriver, "//*[@id='dialog']/div[1]/div/div/ul"))
       //     {
       //         //Thread.Sleep(5000);
       //         results = kwm.Error_Msg_Read_Submit_Resume_details(WDriver, "//*[@id='dialog']/div[1]/div/div/ul");
       //         if (results.Result1 == KeyWords.Result_PASS)
       //         {
       //             kwm.select_MSG_Button(WDriver, KeyWords.locator_type, "button", "Close");
       //             return results;
       //         }
       //     }
       //     for (int x = 0; x <= 10; x++)
       //     {

       //         //  dialog-confirmreqcomm1
       //         Thread.Sleep(1);                                    //dialog-confirmreqcomm1
       //         if (kwm.isElementDisplayedByXPath(WDriver, "//*[@id='dialog-confirmreqcomm1']"))
       //         {
       //             Thread.Sleep(200);
       //             break;
       //         }
       //     }
       //     results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, "button", broadcastModel.str_Btn_Comment_confirm_Yes);
       //     if (results.Result1 == KeyWords.Result_FAIL)
       //     {
       //         results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, "button", "Yes");
       //         if (results.Result1 == KeyWords.Result_FAIL)
       //         {
       //             //
       //         }
       //     }
       //     //if (!kwm.isElementDisplayed(WDriver, "dialog-confirmcomm2"))
       //     //{
       //     //    Thread.Sleep(5000);
       //     //}
       //     //if (!kwm.isElementDisplayed(WDriver, "dialog-confirmcomm2"))
       //     //{
       //     //    Thread.Sleep(5000);
       //     //}
       //     for (int x = 0; x <= 10; x++)
       //     {
       //         //dialog-confirmcomm2
       //         Thread.Sleep(1);                                    //dialog-confirmcomm2
       //         if (kwm.isElementDisplayedByXPath(WDriver, "//*[@id='dialog-confirmcomm2']"))
       //         {
       //             Thread.Sleep(500);
       //             break;
       //         }
       //     }


       //     results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, "button", broadcastModel.str_Btn_Comment_confirm_Ok);
       //     if (results.Result1 == KeyWords.Result_FAIL)
       //     {
       //         Thread.Sleep(2000);
       //         results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, "button", "Ok");
       //         if (results.Result1 == KeyWords.Result_FAIL)
       //         {
       //             //
       //         }
       //     }
       //     //Thread.Sleep(5000);
       //     //Thread.Sleep(5000);
       //     //kwm.select_MSG_Button(WDriver, KeyWords.locator_type, "button", broadcastModel.str_Btn_Comment_confirm_Ok);
       //     //Thread.Sleep(5000);
       //     //kwm.select_MSG_Button(WDriver, KeyWords.locator_class, "class", broadcastModel.str_Btn_Comment_confirm_Ok);
       //     //kwm.select_MSG_Button(WDriver, KeyWords.locator_type, "button", broadcastModel.str_Btn_Comment_confirm_Ok);
       //     //Thread.Sleep(5000);
       //     //Thread.Sleep(5000);
       //     //kwm.select_MSG_Button(WDriver, KeyWords.locator_type, "button", broadcastModel.str_Btn_Comment_confirm_Ok);
       //     //Thread.Sleep(5000);
       //     //kwm.select_MSG_Button(WDriver, KeyWords.locator_class, "class", broadcastModel.str_Btn_Comment_confirm_Ok);
       //     for (int z = 1; z < 50; z++)
       //     {
       //         Boolean strValue = true;
       //         try
       //         {
       //             strValue = WDriver.FindElement(By.Id(KeyWords.ID_STR_loading_message)).Displayed;
       //         }
       //         catch
       //         {
       //             strValue = true;
       //         }

       //         if (!strValue)
       //         {
       //             break;
       //         }
       //         Thread.Sleep(1000);
       //     }
       //     results.Result1 = KeyWords.Result_PASS;
       //     results.ErrorMessage = "Add Comments done Successfully";
       //     return results;
       // }
       // public Result SelectedSupplier_Broadcast_Method(IWebDriver WDriver, DataRow Broadcast_Data)
       // {
       //     KeyWordMethods kwm = new KeyWordMethods();
       //     CommonMethods objCommonMethods = new CommonMethods();
       //     ReadExcel ReadExcelHelper = new ReadExcel();
       //     var results = new Result();
       //     var results_SupplierEmail = new Result();
       //     var results_SupplierEmailStatus = new Result();
       //     var Result_ScreenShot = new Result();
       //     CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
       //     BroadcastModel broadcastModel = createRequirementRepository.GetBroadcastData(Broadcast_Data);
       //     //string str_Radio_DisplayComment = Broadcast_Data["P24"].ToString().Trim();
       //     //string str_TxtArea_Comment = Broadcast_Data["P25"].ToString().Trim();
       //     //string str_Btn_Submit = Broadcast_Data["P26"].ToString().Trim();
       //     //string str_Btn_Comment_confirm_Yes = Broadcast_Data["P27"].ToString().Trim();
       //     //string str_Btn_Comment_confirm_Ok = Broadcast_Data["P28"].ToString().Trim();

       //     if (!kwm.isElementDisplayed(WDriver, KeyWords.ID_Tbl_tblSuppliers))
       //     {
       //         Thread.Sleep(5000);
       //     }
       //     if (!kwm.isElementDisplayed(WDriver, KeyWords.ID_Tbl_tblSuppliers))
       //     {
       //         results.Result1 = KeyWords.Result_FAIL;
       //         results.ErrorMessage = KeyWords.MSG_strSupplierWindowNotdisplay;
       //         return results;
       //     }

       //     results = kwm.Selected_Email_Supplier_Count(WDriver, "//*[@id='" + KeyWords.ID_Tbl_tblSuppliers + "']/tbody/tr");
       //     if (results.Result1 == KeyWords.Result_PASS)
       //     {
       //         int intSupplierCount = 0;
       //         string s2 = "";
       //         intSupplierCount = Convert.ToInt32(results.ErrorMessage);
       //         for (int s1 = 1; s1 <= 5; s1++)
       //         {
       //             results_SupplierEmail = kwm.Get_Supplier_Email(WDriver, "//*[@id='trHeaderRow']/td[" + s1 + "]");
       //             if ((results_SupplierEmail.Result1 == KeyWords.Result_PASS) && (results_SupplierEmail.ErrorMessage == "Email"))
       //             {
       //                 // s1 = s1 + 1;
       //                 s2 = s1.ToString();
       //                 break;
       //             }
       //         }
       //         for (int s = 1; s <= intSupplierCount; s++)
       //         {
       //             string strActiveEmailSQL = "select email, statusID  from  ST_lm_user where email =";
       //             results_SupplierEmail = kwm.Get_Supplier_Email(WDriver, "//*[@id='" + KeyWords.ID_Tbl_tblSuppliers + "']/tbody/tr[" + s + "]/td[" + s2 + "]");

       //             results_SupplierEmailStatus = objCommonMethods.Get_Table_Data_Database(strActiveEmailSQL + "'" + results_SupplierEmail.ErrorMessage + "'", "statusID");
       //             if ((results_SupplierEmailStatus.Result1 == KeyWords.Result_PASS) && (Convert.ToInt32(results_SupplierEmailStatus.listData[0]) == 1))
       //             {
       //                 //Update excel testcase 4,8,10 supplier email ids here
       //                 string strUpdateSqlMain = "Update [all$] set P3 = '" + results_SupplierEmail.ErrorMessage + "'  WHERE TestCaseId= '004' and P5 ='" + Broadcast_Data["P5"].ToString() + "'";
       //                 ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);
       //                 strUpdateSqlMain = "Update [all$] set P3 = '" + results_SupplierEmail.ErrorMessage + "'  WHERE TestCaseId= '008' and P5 ='" + Broadcast_Data["P5"].ToString() + "'";
       //                 ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);
       //                 strUpdateSqlMain = "Update [all$] set P3 = '" + results_SupplierEmail.ErrorMessage + "'  WHERE TestCaseId= '010' and P5 ='" + Broadcast_Data["P5"].ToString() + "'";
       //                 ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);
       //                 break;
       //             }
       //         }
       //     }

       //     results.Result1 = KeyWords.Result_PASS;
       //     //  results.ErrorMessage = "Add Comments done Successfully";
       //     return results;
       // }


      //  public static IWebDriver driver { get; set; }
    }
}