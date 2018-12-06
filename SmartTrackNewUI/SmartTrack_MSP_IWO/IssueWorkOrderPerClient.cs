// --------------------------------------------------------------------------------------------------------------------
//<copyright file="IssueWorkOrderPerClient.cs" company="DCR Workforce Inc">
//   Copyright (c) DCR Workforce Inc. All rights reserved.
//   This code and information should not be copied and used outside of DCR Workforce Inc.
// </copyright>
// <summary>
//   Builds the Container for the Autofac IOC.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using SmartTrack.DataAccess.Models;
using RelevantCodes.ExtentReports;

namespace SmartTrack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections.ObjectModel;
    using System.Threading;
    using CommonFiles;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SmartTrack_Automation;
    using OpenQA.Selenium.Interactions;

    public class IssueWorkOrderPerClient
    {
   
        public static void IWO_SunTrust(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
           // kwm.click(WDriver, KeyWords.locator_ID, "tabsExpandCollapse");

            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_TimecardApprovers_addTimecardApproverbtn);

            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "" && issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != null)
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }

            //GL/CostCenter
            //GL Account - Disabled 
            if (issueWorkOrderModel.str_Select_ChargeGLAccount_ChargeGLId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_ChargeGLAccount_ChargeGLId, issueWorkOrderModel.str_Select_ChargeGLAccount_ChargeGLId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Cost Center 
            if (issueWorkOrderModel.str_typeahead_CostCenter_ChargeCostCenterId != "")
            {
                Thread.Sleep(3000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_typeahead_CostCenter_ChargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_typeahead_CostCenter_ChargeCostCenterId, issueWorkOrderModel.str_typeahead_CostCenter_ChargeCostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_typeahead_CostCenter_ChargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_typeahead_CostCenter_ChargeCostCenterId, issueWorkOrderModel.str_typeahead_CostCenter_ChargeCostCenterId);
                    //  return results;
                }
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_ChargeNumberADD_AddChargeNumber);
            }



            //Needed Start Date
           

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate))
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate);
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate, issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            objCommonMethods.Action_Button_Tab(WDriver);

            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);

            //supplierRegBillRate
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, true);

            // supplierOTBillRate - Disabled
            if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, true);
            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);

            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, false);





            //Calculated Markup   
            if (issueWorkOrderModel.str_Txt_CalculatedMarkup_calculatedMarkup != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_CalculatedMarkup_calculatedMarkup, issueWorkOrderModel.str_Txt_CalculatedMarkup_calculatedMarkup, true);


            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_HoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);

            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_OThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);

            //Estimated Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);

            //
        }
                
        public static void IWO_Colgate(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
           // kwm.click(WDriver, KeyWords.locator_ID, "tabsExpandCollapse");
            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }




            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }
            //Needed Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate, issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);


            //Supplier Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, false);
            //Supplier OT Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, false);



            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);
            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);
            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Estimated Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);


            //
        }

        public static void IWO_Cpchem(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

          //  kwm.click(WDriver, KeyWords.locator_ID, "tabsExpandCollapse");
            objCommonMethods.Action_Page_Down(WDriver);

            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }

            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }
            //Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_AnticipatedStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_AnticipatedStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_AnticipatedStartDate_preferredStartDate, issueWorkOrderModel.str_Date_AnticipatedStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            //Po Number *
            if (issueWorkOrderModel.str_Txt_PoNumber_purchaseOrderNumber != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_PoNumber_purchaseOrderNumber, issueWorkOrderModel.str_Txt_PoNumber_purchaseOrderNumber, true);
            //Candidate OT Pay Rate 

            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //str_Txt_supplierRegBillRate
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, true);
            // str_Txt_supplierOTBillRate
            if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, true);





            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);

            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);

            //Supplier markup -Disabled
            if (issueWorkOrderModel.str_txt_IW_SupplierMarkup_supplierMarkupRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierMarkup_supplierMarkupRate, issueWorkOrderModel.str_txt_IW_SupplierMarkup_supplierMarkupRate, true);

            //mspFeeMarkup
            if (issueWorkOrderModel.str_txt_MspFee_mspFeeMarkup != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MspFeemarkup_mspFeeMarkup, issueWorkOrderModel.str_txt_MspFee_mspFeeMarkup, false);
            //MSP Fee
            if (issueWorkOrderModel.str_txt_MspFee_mspRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MspFee_mspRegBillRate, issueWorkOrderModel.str_txt_MspFee_mspRegBillRate, true);
            //MSP OT Fee 
            if (issueWorkOrderModel.str_txt_MspOtFee_mspOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MspOtFee_mspOTBillRate, issueWorkOrderModel.str_txt_MspOtFee_mspOTBillRate, true);
            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);

            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Estimated Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);

            //
        }

        public static void IWO_Caesars(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }
            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_Txt_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }
            //Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_txtneededStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Txt_PrefStartdate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_PrefStartdate, issueWorkOrderModel.str_Txt_PrefStartdate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_txtenddate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Txt_enddate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_enddate, issueWorkOrderModel.str_Txt_enddate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            //Needed Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate, issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);

            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);

            ////Estimated  Contract Value
            //if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);


            ///Added by manjusha

            //contract value
            results = kwm.Estimatedcontractorvalue(WDriver, issueWorkOrderModel.str_Txt_numberofDays_offertoHire, issueWorkOrderModel.str_Txt_numberofResources_offertoHire, "40", "7", issueWorkOrderModel.str_Txt_Billrate_Supplierbillrate);
            if (results._Var == issueWorkOrderModel.str_Txt_Estimatedcontract_offertoHire)
            {
                ReportHandler._getChildTest().Log(LogStatus.Pass, "Contract Value is matched in Work Order");
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, " value is  matched: ", 3);
            }
            else
            {
                ReportHandler._getChildTest().Log(LogStatus.Fail, "Contract Value is not mismatched in Work Order");
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, " value is not matched: ", 3);
            }
        }

        public static void IWO_Dyncorp(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }

            //Charge Number
            //Charge Number PA
            if (issueWorkOrderModel.str_txt_ChargeNumberPA_txtChargePA != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_ChargeNumberPA_txtChargePA, issueWorkOrderModel.str_txt_ChargeNumberPA_txtChargePA, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Charge Number PAA
            if (issueWorkOrderModel.str_select_ChargeNumberPAA_chargeCostCenterId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_ChargeNumberPAA_chargeCostCenterId, issueWorkOrderModel.str_select_ChargeNumberPAA_chargeCostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_select_ChargeNumberPAA_chargeCostCenterId))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_ChargeNumberAdd_addChargeNobtnNew);
            }



            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_Txt_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }
            //Needed Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate, issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);
            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);
            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Estimated Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);


            //
        }


        #region KeyBank
        public static void IWO_Keybank(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

       //     kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_EXPANDALL_tabsExpandCollapse);

            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversAdd_addTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }

            //Charge Number
            //Company Number 

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Typeahead_ChargeCompanyNumber_deptNumber))
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeCompanyNumber_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeCompanyNumber_deptNumber, issueWorkOrderModel.str_Typeahead_ChargeCompanyNumber_deptNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeCompanyNumber_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeCompanyNumber_deptNumber, issueWorkOrderModel.str_Typeahead_ChargeCompanyNumber_deptNumber);
                    //  return results;
                }
            }

            //AP Cost Center
            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Typeahead_APCostCenter_CostCenterId))
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_APCostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_APCostCenter_CostCenterId, issueWorkOrderModel.str_Typeahead_APCostCenter_CostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_APCostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_APCostCenter_CostCenterId, issueWorkOrderModel.str_Typeahead_APCostCenter_CostCenterId);
                    //  return results;
                }
            }

            //GL Account - Disbaled 
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_ChargeNumberAdd_AddCostOrgLegalGL);



            //Needed Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate, issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);

            //Supplier Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, false);

            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);

            objCommonMethods.Action_Button_Tab(WDriver);
            objCommonMethods.Action_Page_Down(WDriver);
            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);

            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue);
            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Estimated Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);



            //
        }
        #endregion KeyBank

        public static void IWO_Discover(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //kwm.click(WDriver, KeyWords.locator_ID, "tabsExpandCollapse");
            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }
            //Charge Number
            if (issueWorkOrderModel.str_AddListTxt_ChargeNumbers != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
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
                    }
                }
            }
            //Delete charge Number
            if (issueWorkOrderModel.str_DeleteListTxt_ChargeNumbers != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_DeleteListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addChargeNo']/option"));

                        List<IWebElement> elements = lis_ClientNames.ToList();
                        for (int i = 0; i < elements.Count; i++)
                        {
                            if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                            {
                                elements[i].Click();
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteChargeNobtn);
                            }
                        }
                    }
                }
            }

            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }



            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);

            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);

            //if (issueWorkOrderModel.str_Txt_mspFeeMarkup != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_mspFeeMarkup, issueWorkOrderModel.str_Txt_mspFeeMarkup, false);
            ////MSP Fee
            //if (issueWorkOrderModel.str_Txt_mspRegBillRate != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_mspRegBillRate, issueWorkOrderModel.str_Txt_mspRegBillRate, true);
            ////MSP OT Fee 
            //if (issueWorkOrderModel.str_Txt_mspOTBillRate != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_mspOTBillRate, issueWorkOrderModel.str_Txt_mspOTBillRate, true);
            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);

            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Estimated Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);

            //
        }

        public static void IWO_Welchallyn(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }

            //Charge Number 


            //Cost Center Number 
            if (issueWorkOrderModel.str_Typeahead_ChargeCostCenterNumber_chargeCostCenterId != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeCostCenterNumber_chargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeCostCenterNumber_chargeCostCenterId, issueWorkOrderModel.str_Typeahead_ChargeCostCenterNumber_chargeCostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeCostCenterNumber_chargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeCostCenterNumber_chargeCostCenterId, issueWorkOrderModel.str_Typeahead_ChargeCostCenterNumber_chargeCostCenterId);

                }
            }

            //Project#/WBS Element
            if (issueWorkOrderModel.str_Typeahead_ChargeProjectWBSElement_chargeProjectId != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeProjectWBSElement_chargeProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeProjectWBSElement_chargeProjectId, issueWorkOrderModel.str_Typeahead_ChargeProjectWBSElement_chargeProjectId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeProjectWBSElement_chargeProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeProjectWBSElement_chargeProjectId, issueWorkOrderModel.str_Typeahead_ChargeProjectWBSElement_chargeProjectId);

                }
            }

            //GL Number 
            if (issueWorkOrderModel.str_select_GLNumber_chargeGLId != "")
            {

                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_HeadcountApproved_laborClassCode, issueWorkOrderModel.str_select_GLNumber_chargeGLId);
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_ChargeNumberAdd_addChargeNobtnNew);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_Txt_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }
            //Needed Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate, issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);
            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);

            //mspFeeMarkup
            if (issueWorkOrderModel.str_txt_MspFee_mspFeeMarkup != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MspFeemarkup_mspFeeMarkup, issueWorkOrderModel.str_txt_MspFee_mspFeeMarkup, false);
            //MSP Fee
            if (issueWorkOrderModel.str_txt_MSPRate_mspRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MSPRate_mspRegBillRate, issueWorkOrderModel.str_txt_MSPRate_mspRegBillRate, true);
            //MSP OT Fee 
            if (issueWorkOrderModel.str_txt_MSPOTRate_mspOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MSPOTRate_mspOTBillRate, issueWorkOrderModel.str_txt_MSPOTRate_mspOTBillRate, true);
            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Total Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);

            //
        }

        #region IWO_KCPL
        public static void IWO_KCPL(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {

                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Click_TimecardApproversAdd_addTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }
            //Delete Time Crad Approver
            if (issueWorkOrderModel.str_Click_TimecardApproversDelete_deleteTimecardApproverbtn != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_Click_TimecardApproversDelete_deleteTimecardApproverbtn.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
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
                                elements[i].Click();
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Click_TimecardApproversDelete_deleteTimecardApproverbtn);
                            }
                        }
                    }
                }
            }

            //kwm._WDWait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_btn_EXPANDALL_tabsExpandCollapse))));
            //// Click on Expand All
            //try
            //{
            //    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_EXPANDALL_tabsExpandCollapse);
            //}
            //catch (Exception)
            //{

            //    try
            //    {
            //        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_EXPANDALL_tabsExpandCollapse);
            //    }
            //    catch (Exception)
            //    {

            //        //throw;
            //    }
            //}
            objCommonMethods.Action_LookInto_Element_ID(WDriver, KeyWords.ID_Date_NeededStartDate_preferredStartDate);
            //Charge Number
            if (issueWorkOrderModel.str_AddListTxt_ChargeNumbers != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
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
                    }
                }
            }
            //Delete charge Number
            if (issueWorkOrderModel.str_DeleteListTxt_ChargeNumbers != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_DeleteListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addChargeNo']/option"));

                        List<IWebElement> elements = lis_ClientNames.ToList();
                        for (int i = 0; i < elements.Count; i++)
                        {
                            if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                            {
                                elements[i].Click();
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteChargeNobtn);
                            }
                        }
                    }
                }
            }
            //Gl Numbers
            if (issueWorkOrderModel.str_AddListTxt_GLNumbers != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_AddListTxt_GLNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
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

            if (issueWorkOrderModel.str_DeleteListTxt_GLNumbers != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_DeleteListTxt_GLNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addGLNo']/option"));

                        List<IWebElement> elements = lis_ClientNames.ToList();
                        for (int i = 0; i < elements.Count; i++)
                        {
                            if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                            {
                                elements[i].Click();
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteGLNobtn);
                            }
                        }
                    }
                }
            }

            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_Txt_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }

            //Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_DesiredStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_DesiredStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_DesiredStartDate_preferredStartDate, issueWorkOrderModel.str_Date_DesiredStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);

            //Candidate OT Pay Rate 
            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);

            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);

            //mspFeeMarkup
            if (issueWorkOrderModel.str_txt_MspFee_mspFeeMarkup != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MspFeemarkup_mspFeeMarkup, issueWorkOrderModel.str_txt_MspFee_mspFeeMarkup, false);

            //MSP Fee
            if (issueWorkOrderModel.str_txt_MspOtFee_mspOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MspFee_mspRegBillRate, issueWorkOrderModel.str_txt_MspOtFee_mspOTBillRate, true);

            //MSP OT Fee 
            if (issueWorkOrderModel.str_Txt_mspOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MSPOTBillRate_mspOTBillRate, issueWorkOrderModel.str_Txt_mspOTBillRate, true);

            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_Txt_weeklyRegHoursNTE, false);

            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_Txt_weeklyOTHoursNTE, false);

            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);

            //Estimated Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);

        }
        #endregion IWO_KCPL

        public static void IWO_Tesla(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }

            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }
            //Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_StartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_StartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_StartDate_preferredStartDate, issueWorkOrderModel.str_Date_StartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            //Po Number *
            if (issueWorkOrderModel.str_Txt_PoNumber_purchaseOrderNumber != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_PoNumber_purchaseOrderNumber, issueWorkOrderModel.str_Txt_PoNumber_purchaseOrderNumber, true);
            //Candidate OT Pay Rate 

            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //str_Txt_supplierRegBillRate
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, true);
            // str_Txt_supplierOTBillRate
            if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, true);





            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);

            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);

            ////Supplier markup -Disabled
            //if (issueWorkOrderModel.str_txt_SupplierMarkup_supplierMarkupRate != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierMarkup_supplierMarkupRate, issueWorkOrderModel.str_txt_SupplierMarkup_supplierMarkupRate, true);

            ////mspFeeMarkup
            //if (issueWorkOrderModel.str_txt_MspFee_mspFeeMarkup != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MspFeemarkup_mspFeeMarkup, issueWorkOrderModel.str_txt_MspFee_mspFeeMarkup, false);
            ////MSP Fee
            //if (issueWorkOrderModel.str_txt_MspFee_mspRegBillRate != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MspFee_mspRegBillRate, issueWorkOrderModel.str_txt_MspFee_mspRegBillRate, true);
            ////MSP OT Fee 
            //if (issueWorkOrderModel.str_txt_MspOtFee_mspOTBillRate != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MspOtFee_mspOTBillRate, issueWorkOrderModel.str_txt_MspOtFee_mspOTBillRate, true);
            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);

            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Estimated Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);

            //
        }

        #region Altria
        public static void IWO_Altria(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }
            //Charge Number
            //Company Code 
            if (issueWorkOrderModel.str_select_ChargeNumbersCompanyCode_deptNumber != "")
            {

                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_ChargeNumbersCompanyCode_deptNumber, issueWorkOrderModel.str_select_ChargeNumbersCompanyCode_deptNumber);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Cost Center Number 
            if (issueWorkOrderModel.str_select_CostCenter_CostCenterId != "")
            {

                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_CostCenter_CostCenterId, issueWorkOrderModel.str_select_CostCenter_CostCenterId);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            if (issueWorkOrderModel.str_select_WBS_ProjectId != "")
            {

                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_WBS_ProjectId, issueWorkOrderModel.str_select_WBS_ProjectId);
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_ChargeNumberAdd_AddCostOrgLegalGL);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_Txt_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }
            //Desired Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_DesiredStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_DesiredStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_DesiredStartDate_preferredStartDate, issueWorkOrderModel.str_Date_DesiredStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);
            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);

            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);

            //Estimated Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);

            //
        }
        #endregion

        #region IWO_Epri
        public static void IWO_Epri(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //TimecardApprover_Add Card Approver
            // venky added 2nd condition
            if (issueWorkOrderModel.str_AddListTxt_txtTimecardApprover != "" && issueWorkOrderModel.str_AddListTxt_txtTimecardApprover == null)
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_AddListTxt_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
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
            //Delete Time Crad Approver
            if (issueWorkOrderModel.str_DeleteListTxt_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_DeleteListTxt_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
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
                                elements[i].Click();
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
                            }
                        }
                    }
                }
            }

            kwm._WDWait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_btn_EXPANDALL_tabsExpandCollapse))));
            // Click on Expand All
            try
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_EXPANDALL_tabsExpandCollapse);
            }
            catch (Exception)
            {

                try
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_EXPANDALL_tabsExpandCollapse);
                }
                catch (Exception)
                {

                    //throw;
                }
            }
            objCommonMethods.Action_LookInto_Element_ID(WDriver, KeyWords.ID_Date_NeededStartDate_preferredStartDate);

            //Start Date
            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate, issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            //End Date
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }


            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);
            //Candidate OT Pay Rate 
            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Supplier Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, false);
            //Supplier OT Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, false);

            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);
            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);

            //mspFeeMarkup
            if (issueWorkOrderModel.str_txt_MspFee_mspFeeMarkup != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MspFeemarkup_mspFeeMarkup, issueWorkOrderModel.str_txt_MspFee_mspFeeMarkup, false);
            //MSP Fee
            if (issueWorkOrderModel.str_txt_MSPRate_mspRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MSPRate_mspRegBillRate, issueWorkOrderModel.str_txt_MSPRate_mspRegBillRate, true);
            //MSP OT Fee 
            if (issueWorkOrderModel.str_txt_MSPOTRate_mspOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MSPOTRate_mspOTBillRate, issueWorkOrderModel.str_txt_MSPOTRate_mspOTBillRate, true);
            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Total Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);
            //
        }
        #endregion IWO_Epri

        public static void IWO_EBS(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
           // kwm.click(WDriver, KeyWords.locator_ID, "tabsExpandCollapse");
            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }
            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Needed Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate, issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Supplier Markup% 

            if (issueWorkOrderModel.str_txt_IW_SupplierMarkup_supplierMarkupRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierMarkup_supplierMarkupRate, issueWorkOrderModel.str_txt_IW_SupplierMarkup_supplierMarkupRate, true);
            //Supplier Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, false);
            //Supplier OT Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, false);
            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);
            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);

        }
        
        public static void IWO_APS(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_AddListTxt_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_AddListTxt_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
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
            //Delete Time Crad Approver
            if (issueWorkOrderModel.str_DeleteListTxt_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_DeleteListTxt_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
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
                                elements[i].Click();
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
                            }
                        }
                    }
                }
            }
            //Charge Number
            if (issueWorkOrderModel.str_AddListTxt_ChargeNumbers != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
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
                    }
                }
            }
            //Delete charge Number
            if (issueWorkOrderModel.str_DeleteListTxt_ChargeNumbers != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_DeleteListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addChargeNo']/option"));

                        List<IWebElement> elements = lis_ClientNames.ToList();
                        for (int i = 0; i < elements.Count; i++)
                        {
                            if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                            {
                                elements[i].Click();
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteChargeNobtn);
                            }
                        }
                    }
                }
            }
            //Gl Numbers
            if (issueWorkOrderModel.str_AddListTxt_GLNumbers != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_AddListTxt_GLNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
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

            if (issueWorkOrderModel.str_DeleteListTxt_GLNumbers != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_DeleteListTxt_GLNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addGLNo']/option"));

                        List<IWebElement> elements = lis_ClientNames.ToList();
                        for (int i = 0; i < elements.Count; i++)
                        {
                            if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                            {
                                elements[i].Click();
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteGLNobtn);
                            }
                        }
                    }
                }
            }
            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_Txt_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }
            //Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_txtneededStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Txt_PrefStartdate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_PrefStartdate, issueWorkOrderModel.str_Txt_PrefStartdate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_txtenddate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Txt_enddate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_enddate, issueWorkOrderModel.str_Txt_enddate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            //Candidate Pay Rate
            if (issueWorkOrderModel.str_Txt_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_supplierRegPayRate, issueWorkOrderModel.str_Txt_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_Txt_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_supplierOTPayRate, issueWorkOrderModel.str_Txt_supplierOTPayRate, true);

            //Final Bill Rate  
            if (issueWorkOrderModel.str_Txt_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_finalRegBillRate, issueWorkOrderModel.str_Txt_finalRegBillRate, true);

            //Final OT Bill Rate
            if (issueWorkOrderModel.str_Txt_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_finalOTBillRate, issueWorkOrderModel.str_Txt_finalOTBillRate, true);
            //mspFeeMarkup
            if (issueWorkOrderModel.str_Txt_mspFeeMarkup != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_mspFeeMarkup, issueWorkOrderModel.str_Txt_mspFeeMarkup, false);
            //MSP Fee
            if (issueWorkOrderModel.str_Txt_mspRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_mspRegBillRate, issueWorkOrderModel.str_Txt_mspRegBillRate, true);
            //MSP OT Fee 
            if (issueWorkOrderModel.str_Txt_mspOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_mspOTBillRate, issueWorkOrderModel.str_Txt_mspOTBillRate, true);
            //Hours Per Week NTE
            if (issueWorkOrderModel.str_Txt_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_weeklyRegHoursNTE, issueWorkOrderModel.str_Txt_weeklyRegHoursNTE, false);

            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_Txt_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_weeklyOTHoursNTE, issueWorkOrderModel.str_Txt_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_Txt_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_yearlyRegHoursNTE, issueWorkOrderModel.str_Txt_yearlyRegHoursNTE, false);
            //Estimated Contract Value
            if (issueWorkOrderModel.str_Txt_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_totalContractValue, issueWorkOrderModel.str_Txt_totalContractValue, false);

            //
        }

        public static void IWO_HillRom(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //kwm.click(WDriver, KeyWords.locator_ID, "tabsExpandCollapse");
            objCommonMethods.Action_Page_Down(WDriver);
            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }

            //Charge Number
            //Business Unit 
            if (issueWorkOrderModel.str_Typeahead_BusinessUnit_chargeCostCenterId != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_BusinessUnit_chargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_BusinessUnit_chargeCostCenterId, issueWorkOrderModel.str_Typeahead_BusinessUnit_chargeCostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_BusinessUnit_chargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_BusinessUnit_chargeCostCenterId, issueWorkOrderModel.str_Typeahead_BusinessUnit_chargeCostCenterId);

                }
            }

            //Object Account

            if (issueWorkOrderModel.str_select_ObjectAccount_chargeGLId != "")
            {

                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_ObjectAccount_chargeGLId, issueWorkOrderModel.str_select_ObjectAccount_chargeGLId);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Project Code/ CFR
            if (issueWorkOrderModel.str_Typeahead_ProjectCodeCFR_chargeProjectId != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ProjectCodeCFR_chargeProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ProjectCodeCFR_chargeProjectId, issueWorkOrderModel.str_Typeahead_ProjectCodeCFR_chargeProjectId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ProjectCodeCFR_chargeProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ProjectCodeCFR_chargeProjectId, issueWorkOrderModel.str_Typeahead_ProjectCodeCFR_chargeProjectId);

                }
            }

            //Company Code 
            if (issueWorkOrderModel.str_select_CompanyCode_chargedeptNumber != "")
            {

                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_CompanyCode_chargedeptNumber, issueWorkOrderModel.str_select_CompanyCode_chargedeptNumber);
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_ChargeNumberAdd_addChargeNobtnNew);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_Txt_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }
            //Needed Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate, issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);
            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);

            //mspFeeMarkup
            if (issueWorkOrderModel.str_txt_MspFee_mspFeeMarkup != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MspFeemarkup_mspFeeMarkup, issueWorkOrderModel.str_txt_MspFee_mspFeeMarkup, false);
            //MSP Fee
            if (issueWorkOrderModel.str_txt_MSPRate_mspRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MSPRate_mspRegBillRate, issueWorkOrderModel.str_txt_MSPRate_mspRegBillRate, true);
            //MSP OT Fee 
            if (issueWorkOrderModel.str_txt_MSPOTRate_mspOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MSPOTRate_mspOTBillRate, issueWorkOrderModel.str_txt_MSPOTRate_mspOTBillRate, true);
            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Total Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);

        }

        public static void IWO_SOF(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //kwm.click(WDriver, KeyWords.locator_ID, "tabsExpandCollapse");
            objCommonMethods.Action_Page_Down(WDriver);

            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }

            }
            ////Delete Time Crad Approver
            //if (issueWorkOrderModel.str_DeleteListTxt_txtTimecardApprover != "")
            //{
            //    string[] separators1 = { "#" };
            //    string[] words = issueWorkOrderModel.str_DeleteListTxt_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
            //    if (words.Length >= 1)
            //    {
            //        for (int r = 0; r < words.Length; r++)
            //        {
            //            ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addTimecardApprover']/option"));

            //            List<IWebElement> elements = lis_ClientNames.ToList();
            //            for (int i = 0; i < elements.Count; i++)
            //            {
            //                if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
            //                {
            //                    elements[i].Click();
            //                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteTimecardApproverbtn);
            //                }
            //            }
            //        }
            //    }
            //}
            ////Charge Number
            //if (issueWorkOrderModel.str_AddListTxt_ChargeNumbers != "")
            //{
            //    string[] separators1 = { "#" };
            //    string[] words = issueWorkOrderModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
            //    if (words.Length >= 1)
            //    {
            //        for (int r = 0; r < words.Length; r++)
            //        {
            //            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtChargeNo, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
            //            if (results.Result1 == KeyWords.Result_FAIL)
            //            {
            //                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtChargeNo, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
            //                //  return results;
            //            }
            //            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addChargeNobtn);
            //        }
            //    }
            //}
            ////Delete charge Number
            //if (issueWorkOrderModel.str_DeleteListTxt_ChargeNumbers != "")
            //{
            //    string[] separators1 = { "#" };
            //    string[] words = issueWorkOrderModel.str_DeleteListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
            //    if (words.Length >= 1)
            //    {
            //        for (int r = 0; r < words.Length; r++)
            //        {
            //            ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addChargeNo']/option"));

            //            List<IWebElement> elements = lis_ClientNames.ToList();
            //            for (int i = 0; i < elements.Count; i++)
            //            {
            //                if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
            //                {
            //                    elements[i].Click();
            //                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteChargeNobtn);
            //                }
            //            }
            //        }
            //    }
            //}
            ////Gl Numbers
            //if (issueWorkOrderModel.str_AddListTxt_GLNumbers != "")
            //{
            //    string[] separators1 = { "#" };
            //    string[] words = issueWorkOrderModel.str_AddListTxt_GLNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
            //    if (words.Length >= 1)
            //    {
            //        for (int r = 0; r < words.Length; r++)
            //        {
            //            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtGLNo, words[r], false);
            //            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_addGLNobtn);
            //            Thread.Sleep(1000);
            //            kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "No");
            //        }
            //    }
            //}

            //if (issueWorkOrderModel.str_DeleteListTxt_GLNumbers != "")
            //{
            //    string[] separators1 = { "#" };
            //    string[] words = issueWorkOrderModel.str_DeleteListTxt_GLNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
            //    if (words.Length >= 1)
            //    {
            //        for (int r = 0; r < words.Length; r++)
            //        {
            //            ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addGLNo']/option"));

            //            List<IWebElement> elements = lis_ClientNames.ToList();
            //            for (int i = 0; i < elements.Count; i++)
            //            {
            //                if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
            //                {
            //                    elements[i].Click();
            //                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteGLNobtn);
            //                }
            //            }
            //        }
            //    }
            //}
            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }
            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Needed Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate, issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Supplier Markup% 

            if (issueWorkOrderModel.str_txt_IW_SupplierMarkup_supplierMarkupRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierMarkup_supplierMarkupRate, issueWorkOrderModel.str_txt_IW_SupplierMarkup_supplierMarkupRate, true);
            //Supplier Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, false);
            //Supplier OT Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, false);
            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);
            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);

            //MSP Fee
            if (issueWorkOrderModel.str_txt_MSPRate_mspRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MSPRate_mspRegBillRate, issueWorkOrderModel.str_txt_MSPRate_mspRegBillRate, true);
            //MSP OT Fee 
            if (issueWorkOrderModel.str_txt_MSPOTRate_mspOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MSPOTRate_mspOTBillRate, issueWorkOrderModel.str_txt_MSPOTRate_mspOTBillRate, true);

            //Total Contract Value
            if (issueWorkOrderModel.str_txt_TotalContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_IW_TotalContractValue_totalContractValue, issueWorkOrderModel.str_txt_TotalContractValue_totalContractValue, false);

            //
        }

        public static void IWO_STS(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }


            //Gl Numbers
            if (issueWorkOrderModel.str_txt_GLNumbers_txtGLNo != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_GLNumbers_txtGLNo.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_GLNumbers_txtGLNo, words[r], false);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_GLNumberAdd_addGLNobtn);
                        Thread.Sleep(1000);
                        kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "No");
                    }
                }
            }

            //if (issueWorkOrderModel.str_DeleteListTxt_GLNumbers != "")
            //{
            //    string[] separators1 = { "#" };
            //    string[] words = issueWorkOrderModel.str_DeleteListTxt_GLNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
            //    if (words.Length >= 1)
            //    {
            //        for (int r = 0; r < words.Length; r++)
            //        {
            //            ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addGLNo']/option"));

            //            List<IWebElement> elements = lis_ClientNames.ToList();
            //            for (int i = 0; i < elements.Count; i++)
            //            {
            //                if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
            //                {
            //                    elements[i].Click();
            //                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteGLNobtn);
            //                }
            //            }
            //        }
            //    }
            //}
            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }


            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Needed Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate, issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Supplier Markup% 

            if (issueWorkOrderModel.str_txt_IW_SupplierMarkup_supplierMarkupRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierMarkup_supplierMarkupRate, issueWorkOrderModel.str_txt_IW_SupplierMarkup_supplierMarkupRate, true);
            //Supplier Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, false);
            //Supplier OT Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, false);
            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);
            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);

            //MSP Fee
            if (issueWorkOrderModel.str_txt_MSPRate_mspRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MSPRate_mspRegBillRate, issueWorkOrderModel.str_txt_MSPRate_mspRegBillRate, true);
            //MSP OT Fee 
            if (issueWorkOrderModel.str_txt_MSPOTRate_mspOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MSPOTRate_mspOTBillRate, issueWorkOrderModel.str_txt_MSPOTRate_mspOTBillRate, true);

            //Total Contract Value
            if (issueWorkOrderModel.str_txt_TotalContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_IW_TotalContractValue_totalContractValue, issueWorkOrderModel.str_txt_TotalContractValue_totalContractValue, false);




        }
        
        public static void IWO_StewartTitle(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }

            //Charge Number (Account Codings)
            //Account Unit
            if (issueWorkOrderModel.str_select_AccountCodingsAccountUnit_deptNumber != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_AccountCodingsAccountUnit_deptNumber, issueWorkOrderModel.str_select_AccountCodingsAccountUnit_deptNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_select_AccountCodingsAccountUnit_deptNumber))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Company
            if (issueWorkOrderModel.str_select_AccountCodingsCompany_siteLocationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_AccountCodingsCompany_siteLocationID, issueWorkOrderModel.str_select_AccountCodingsCompany_siteLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_select_AccountCodingsCompany_siteLocationID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Project - Disabled
            if (issueWorkOrderModel.str_select_AccountCodingsProject_ProjectId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_AccountCodingsProject_ProjectId, issueWorkOrderModel.str_select_AccountCodingsProject_ProjectId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_select_AccountCodingsProject_ProjectId))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Activity - Disabled
            if (issueWorkOrderModel.str_select_AccountCodingsActivity_ProfitCenterId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_AccountCodingsActivity_ProfitCenterId, issueWorkOrderModel.str_select_AccountCodingsActivity_ProfitCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_select_AccountCodingsActivity_ProfitCenterId))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_AccountCodingsadd_AddCostOrgLegalGL);
            }



            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_Txt_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }
            ////Needed Start Date
            //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate);

            //if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate))
            //{
            //    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate, issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate, false);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //    }
            //}
            ////End Date
            //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            //if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            //{
            //    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //    }
            //}

            ////Candidate Pay Rate
            //if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            ////Candidate OT Pay Rate 

            //if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            ////Final Bill Rate  
            //if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            //Thread.Sleep(2000);
            //objCommonMethods.Action_Button_Tab(WDriver);
            ////Final OT Bill Rate
            //if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);
            ////Number of standardhours per week- Disabled

            ////Supplier Markup% 

            //if (issueWorkOrderModel.str_txt_IW_SupplierMarkup_supplierMarkupRate != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierMarkup_supplierMarkupRate, issueWorkOrderModel.str_txt_IW_SupplierMarkup_supplierMarkupRate, true);
            ////Supplier Bill Rate
            //if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, false);
            ////Supplier OT Bill Rate
            //if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, false);

        }

        #region IWO_ThermoFisher
        public static void IWO_ThermoFisher(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

           // kwm.click(WDriver, KeyWords.locator_ID, "tabsExpandCollapse");

            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_TimecardApprovers_addTimecardApproverbtn);
            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }
            //Charge Number
            //Cost Center 
            if (issueWorkOrderModel.str_typeahead_CostCenter_ChargeCostCenterId != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_typeahead_CostCenter_ChargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_typeahead_CostCenter_ChargeCostCenterId, issueWorkOrderModel.str_typeahead_CostCenter_ChargeCostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_typeahead_CostCenter_ChargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_typeahead_CostCenter_ChargeCostCenterId, issueWorkOrderModel.str_typeahead_CostCenter_ChargeCostCenterId);
                    //  return results;
                }
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_ChargeNumberADD_AddChargeNumber);
            }

            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);


            //Needed Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate, issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            objCommonMethods.Action_Button_Tab(WDriver);

            //Work Day ID
            if (issueWorkOrderModel.str_Txt_WorkDayID_customerTrackingNumber != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_WorkDayID_customerTrackingNumber, issueWorkOrderModel.str_Txt_WorkDayID_customerTrackingNumber, true);

            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Supplier Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, false);
            //Supplier OT Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, false);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate);

            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);

            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, false);

            //MSP Fee%
            if (issueWorkOrderModel.str_txt_MspFee_mspFeeMarkup != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MspFeemarkup_mspFeeMarkup, issueWorkOrderModel.str_txt_MspFee_mspFeeMarkup, false);
            //MSP Fee
            if (issueWorkOrderModel.str_txt_MspFee_mspRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MspFee_mspRegBillRate, issueWorkOrderModel.str_txt_MspFee_mspRegBillRate, false);
            //MSP OT Fee 
            if (issueWorkOrderModel.str_txt_MspOtFee_mspOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MspOtFee_mspOTBillRate, issueWorkOrderModel.str_txt_MspOtFee_mspOTBillRate, false);
            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Estimated Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);


            //
        }
        #endregion IWO_ThermoFisher

        public static void IWO_RMS(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

            //kwm.click(WDriver, KeyWords.locator_ID, "tabsExpandCollapse");
            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }
            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Needed Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate, issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Supplier Markup% 

            if (issueWorkOrderModel.str_txt_IW_SupplierMarkup_supplierMarkupRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierMarkup_supplierMarkupRate, issueWorkOrderModel.str_txt_IW_SupplierMarkup_supplierMarkupRate, true);
            //Supplier Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, false);
            //Supplier OT Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, false);
            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);
            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);

            //
        }


        public static void IWO_QuickenLoans(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

           // kwm.click(WDriver, KeyWords.locator_ID, "tabsExpandCollapse");
            objCommonMethods.Action_Page_Down(WDriver);
            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }

            //Business Area/ Expense Amount

            //Business Area 
            if (issueWorkOrderModel.str_typeahead_BusinessArea_ChargeCostCenterId != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_typeahead_BusinessArea_ChargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_typeahead_BusinessArea_ChargeCostCenterId, issueWorkOrderModel.str_typeahead_BusinessArea_ChargeCostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_typeahead_BusinessArea_ChargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_typeahead_BusinessArea_ChargeCostCenterId, issueWorkOrderModel.str_typeahead_BusinessArea_ChargeCostCenterId);
                    //  return results;
                }
            }

            //Expense Account
            if (issueWorkOrderModel.str_Select_ExpenseAccount_ChargeGLId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_ExpenseAccount_ChargeGLId, issueWorkOrderModel.str_Select_ExpenseAccount_ChargeGLId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Select_ExpenseAccount_ChargeGLId))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_ChargeNumberADD_AddChargeNumber);
            }



            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }


            //Needed Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate, issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //PO Number 
            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Typeahead_PONumber_purchaseOrderNumber))
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_PONumber_purchaseOrderNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_PONumber_purchaseOrderNumber, issueWorkOrderModel.str_Typeahead_PONumber_purchaseOrderNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_PONumber_purchaseOrderNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_PONumber_purchaseOrderNumber, issueWorkOrderModel.str_Typeahead_PONumber_purchaseOrderNumber);
                    //  return results;
                }
            }

            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Supplier Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, false);
            //Supplier OT Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, false);
            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);
            objCommonMethods.Action_Page_Down(WDriver);
            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);


            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);

            //Estimated Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);



        }

        #region IWO_MFC
        public static void IWO_MFC(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

            //kwm.click(WDriver, KeyWords.locator_ID, "tabsExpandCollapse");
         //   Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(WDriver);
            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }


            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }
            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            objCommonMethods.Action_Page_Down(WDriver);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Needed Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate, issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            objCommonMethods.Action_Button_Tab(WDriver);

            objCommonMethods.Action_Page_Down(WDriver);
            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Supplier Markup% 

            if (issueWorkOrderModel.str_txt_IW_SupplierMarkup_supplierMarkupRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierMarkup_supplierMarkupRate, issueWorkOrderModel.str_txt_IW_SupplierMarkup_supplierMarkupRate, true);
            //Supplier Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, false);
            //Supplier OT Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, false);
            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);

            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);
            objCommonMethods.Action_Button_Tab(WDriver);

            objCommonMethods.Action_Button_Tab(WDriver);
            objCommonMethods.Action_Page_Down(WDriver);
            //MSP Fee
            if (issueWorkOrderModel.str_txt_MSPRate_mspRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MSPRate_mspRegBillRate, issueWorkOrderModel.str_txt_MSPRate_mspRegBillRate, true);
            //MSP OT Fee 
            if (issueWorkOrderModel.str_txt_MSPOTRate_mspOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MSPOTRate_mspOTBillRate, issueWorkOrderModel.str_txt_MSPOTRate_mspOTBillRate, true);

            //Total Contract Value
            if (issueWorkOrderModel.str_txt_TotalContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_IW_TotalContractValue_totalContractValue, issueWorkOrderModel.str_txt_TotalContractValue_totalContractValue, false);

            //
        }
        #endregion IWO_MFC

        public static void IWO_Bimbo(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Charge Number
            //Charge Number Legal Entity
            if (issueWorkOrderModel.str_Typeahead_ChargeNumberLegalEntity_ChargeorganizationID != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumberLegalEntity_ChargeorganizationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeNumberLegalEntity_ChargeorganizationID, issueWorkOrderModel.str_Typeahead_ChargeNumberLegalEntity_ChargeorganizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumberLegalEntity_ChargeorganizationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeNumberLegalEntity_ChargeorganizationID, issueWorkOrderModel.str_Typeahead_ChargeNumberLegalEntity_ChargeorganizationID);
                    //  return results;
                }
            }

            //Charge Number Business Area
            if (issueWorkOrderModel.str_Typeahead_ChargeNumberBusinessArea_ChargeProjectId != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumberBusinessArea_ChargeProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeNumberBusinessArea_ChargeProjectId, issueWorkOrderModel.str_Typeahead_ChargeNumberBusinessArea_ChargeProjectId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumberBusinessArea_ChargeProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeNumberBusinessArea_ChargeProjectId, issueWorkOrderModel.str_Typeahead_ChargeNumberBusinessArea_ChargeProjectId);
                    //  return results;
                }
            }

            //Charge Number Natural Account 
            if (issueWorkOrderModel.str_Typeahead_ChargeNumbernaturalAccount_ChargeGLId != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumbernaturalAccount_ChargeGLId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeNumbernaturalAccount_ChargeGLId, issueWorkOrderModel.str_Typeahead_ChargeNumbernaturalAccount_ChargeGLId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumbernaturalAccount_ChargeGLId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeNumbernaturalAccount_ChargeGLId, issueWorkOrderModel.str_Typeahead_ChargeNumbernaturalAccount_ChargeGLId);
                    //  return results;
                }
            }

            //Local Analysis
            if (issueWorkOrderModel.str_Typeahead_ChargeNumberLocalAnalysis_ChargesiteLocationID != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumberLocalAnalysis_ChargesiteLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeNumberLocalAnalysis_ChargesiteLocationID, issueWorkOrderModel.str_Typeahead_ChargeNumberLocalAnalysis_ChargesiteLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumberLocalAnalysis_ChargesiteLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeNumberLocalAnalysis_ChargesiteLocationID, issueWorkOrderModel.str_Typeahead_ChargeNumberLocalAnalysis_ChargesiteLocationID);
                    //  return results;
                }
            }

            //Fiscal - Disabled

            //Cost Center
            if (issueWorkOrderModel.str_Typeahead_ChargeNumberCostCenter_ChargeCostCenterId != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumberCostCenter_ChargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeNumberCostCenter_ChargeCostCenterId, issueWorkOrderModel.str_Typeahead_ChargeNumberCostCenter_ChargeCostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumberCostCenter_ChargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeNumberCostCenter_ChargeCostCenterId, issueWorkOrderModel.str_Typeahead_ChargeNumberCostCenter_ChargeCostCenterId);
                    //  return results;
                }
            }

            //InterCompany
            if (issueWorkOrderModel.str_Typeahead_ChargeNumberInterCompany_ChargedeptNumber != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumberInterCompany_ChargedeptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeNumberInterCompany_ChargedeptNumber, issueWorkOrderModel.str_Typeahead_ChargeNumberInterCompany_ChargedeptNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumberInterCompany_ChargedeptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeNumberInterCompany_ChargedeptNumber, issueWorkOrderModel.str_Typeahead_ChargeNumberInterCompany_ChargedeptNumber);
                    //  return results;
                }
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_ChargeNumberADD_AddChargeNumber);
            }

            //Future 1 - Disabled

            //Future 2 - Disabled






            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_Txt_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }
            //Desired Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_DesiredStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_DesiredStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_DesiredStartDate_preferredStartDate, issueWorkOrderModel.str_Date_DesiredStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);
            //Supplier Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, false);
            //Supplier OT Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, false);
            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);
            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);


            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);

            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Estimated Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);


        }

        public static void IWO_Georgetown(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

          //  kwm.click(WDriver, KeyWords.locator_ID, "tabsExpandCollapse");
            objCommonMethods.Action_Page_Down(WDriver);
            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }


            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }


            //Needed Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate, issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //PO Number 
            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Typeahead_PONumber_purchaseOrderNumber))
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_PONumber_purchaseOrderNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_PONumber_purchaseOrderNumber, issueWorkOrderModel.str_Typeahead_PONumber_purchaseOrderNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_PONumber_purchaseOrderNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_PONumber_purchaseOrderNumber, issueWorkOrderModel.str_Typeahead_PONumber_purchaseOrderNumber);
                    //  return results;
                }
            }

            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Supplier Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, false);
            //Supplier OT Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, false);
            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);
            objCommonMethods.Action_Page_Down(WDriver);
            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);


            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Estimated Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);






        }

        public static void IWO_COE(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversAdd_addTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }

            //Charge Number Project Name
            if (issueWorkOrderModel.str_Typeahead_ChargeNumberProjectName_ChargeprogramId != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumberProjectName_ChargeprogramId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeNumberProjectName_ChargeprogramId, issueWorkOrderModel.str_Typeahead_ChargeNumberProjectName_ChargeprogramId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumberProjectName_ChargeprogramId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeNumberProjectName_ChargeprogramId, issueWorkOrderModel.str_Typeahead_ChargeNumberProjectName_ChargeprogramId);
                    //  return results;
                }
            }

            //Charge Number project Number 
            if (issueWorkOrderModel.str_Typeahead_ChargeNumberProjectNumber_ChargeCostCenterId != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumberProjectNumber_ChargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeNumberProjectNumber_ChargeCostCenterId, issueWorkOrderModel.str_Typeahead_ChargeNumberProjectNumber_ChargeCostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumberProjectNumber_ChargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeNumberProjectNumber_ChargeCostCenterId, issueWorkOrderModel.str_Typeahead_ChargeNumberProjectNumber_ChargeCostCenterId);
                    //  return results;
                }
            }

            //Charge Number PO ID
            if (issueWorkOrderModel.str_Typeahead_ChargeNumberPOID_ChargeProjectId != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumberPOID_ChargeProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeNumberPOID_ChargeProjectId, issueWorkOrderModel.str_Typeahead_ChargeNumberPOID_ChargeProjectId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumberPOID_ChargeProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeNumberPOID_ChargeProjectId, issueWorkOrderModel.str_Typeahead_ChargeNumberPOID_ChargeProjectId);
                    //  return results;
                }

                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_ChargeNumberADD_AddChargeNumber);
            }





            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }
            //Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_StartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_StartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_StartDate_preferredStartDate, issueWorkOrderModel.str_Date_StartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Supplier Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, false);
            //Supplier OT Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, false);



            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);
            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);

            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);

            //Estimated Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedLaborandExpCost_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedLaborandExpCost_totalContractValue, issueWorkOrderModel.str_txt_EstimatedLaborandExpCost_totalContractValue, false);

        }
        
        public static void IWO_PHHMortgage(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

           // kwm.click(WDriver, KeyWords.locator_ID, "tabsExpandCollapse");

            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_TimecardApprovers_addTimecardApproverbtn);
            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }

            //Charge Number 
            //Business Unit
            if (issueWorkOrderModel.str_Select_BusinessUnit_ChargeProjectId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_BusinessUnit_ChargeProjectId, issueWorkOrderModel.str_Select_BusinessUnit_ChargeProjectId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Select_BusinessUnit_ChargeProjectId))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Req type 
            if (issueWorkOrderModel.str_Select_Reqtype_ChargeorganizationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Reqtype_ChargeorganizationID, issueWorkOrderModel.str_Select_Reqtype_ChargeorganizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_Select_Reqtype_ChargeorganizationID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Cost Center 
            if (issueWorkOrderModel.str_typeahead_CostCenter_ChargeCostCenterId != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_typeahead_CostCenter_ChargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_typeahead_CostCenter_ChargeCostCenterId, issueWorkOrderModel.str_typeahead_CostCenter_ChargeCostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_typeahead_CostCenter_ChargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_typeahead_CostCenter_ChargeCostCenterId, issueWorkOrderModel.str_typeahead_CostCenter_ChargeCostCenterId);
                    //  return results;
                }
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_ChargeNumberADD_AddChargeNumber);
            }

            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);


            //Needed Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate, issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            objCommonMethods.Action_Button_Tab(WDriver);

            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Supplier Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, false);
            //Supplier OT Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, false);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate);

            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);

            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);

            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue);
            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Estimated Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);


        }

        public static void IWO_Tufts(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
           // kwm.click(WDriver, KeyWords.locator_ID, "tabsExpandCollapse");
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_TimecardApprovers_addTimecardApproverbtn);
            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }


            //Charge Number
            //Department 
            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Typeahead_Department_ChargeorganizationID))
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_Department_ChargeorganizationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_Department_ChargeorganizationID, issueWorkOrderModel.str_Typeahead_Department_ChargeorganizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_Department_ChargeorganizationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_Department_ChargeorganizationID, issueWorkOrderModel.str_Typeahead_Department_ChargeorganizationID);
                    //  return results;
                }
            }

            //Account Code 
            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Select_AccountCode_ChargeCostCenterId))
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_AccountCode_ChargeCostCenterId, issueWorkOrderModel.str_Select_AccountCode_ChargeCostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_ChargeNumberADD_AddChargeNumber);
            }



            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);


            //Needed Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate, issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            objCommonMethods.Action_Button_Tab(WDriver);

            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Supplier Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, false);
            //Supplier OT Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, false);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate);

            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);

            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);

            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue);
            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Estimated Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);

            //
        }

        public static void IWO_STGEN(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {


            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }
            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Needed Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate, issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Supplier Markup% 

            if (issueWorkOrderModel.str_txt_IW_SupplierMarkup_supplierMarkupRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierMarkup_supplierMarkupRate, issueWorkOrderModel.str_txt_IW_SupplierMarkup_supplierMarkupRate, true);
            //Supplier Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, false);
            //Supplier OT Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, false);
            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);
            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);

        }

        #region IWO_Emerson
        public static void IWO_Emerson(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversAdd_addTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }

            //Charge Number Type
            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_select_ChargeNumberType_ChargeNumberTypes))
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_ChargeNumberType_ChargeNumberTypes, issueWorkOrderModel.str_select_ChargeNumberType_ChargeNumberTypes);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Charge Number 
            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Typeahead_ChargeNumber_txtCharge))
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumber_txtCharge, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeNumber_txtCharge, issueWorkOrderModel.str_Typeahead_ChargeNumber_txtCharge);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumber_txtCharge, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeNumber_txtCharge, issueWorkOrderModel.str_Typeahead_ChargeNumber_txtCharge);
                    //  return results;
                }
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_ChargeNumberAdd_addChargeNobtnNew);
            }



            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_Txt_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }
            //Desired Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_DesiredStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_DesiredStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_DesiredStartDate_preferredStartDate, issueWorkOrderModel.str_Date_DesiredStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);
            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);

            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);

            //Estimated Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);

        }
        #endregion IWO_Emerson

        #region IWO_Supervalu
        public static void IWO_Supervalue(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }

            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_ServiceDept_ServDept);
            //Charge Number
            if (issueWorkOrderModel.str_AddListTxt_ChargeNumbers != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
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
                    }
                }
            }
            //Delete charge Number
            if (issueWorkOrderModel.str_DeleteListTxt_ChargeNumbers != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_DeleteListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addChargeNo']/option"));

                        List<IWebElement> elements = lis_ClientNames.ToList();
                        for (int i = 0; i < elements.Count; i++)
                        {
                            if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                            {
                                elements[i].Click();
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteChargeNobtn);
                            }
                        }
                    }
                }
            }

            //Actions actions2 = new Actions(WDriver);
            //actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            //IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_Txt_supplierRegPayRate));
            //try
            //{
            //    actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            //}
            //catch
            //{
            //    //
            //}
          //  kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Tab_Workorderdetails);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate);
            //Needed Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate, issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //Assignmenet End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_AssignmentEndDate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_AssignmentEndDate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_AssignmentEndDate_endDate, issueWorkOrderModel.str_Date_AssignmentEndDate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //  actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);

            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_mspFeeMarkup);
            if (issueWorkOrderModel.str_Txt_mspFeeMarkup != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_mspFeeMarkup, issueWorkOrderModel.str_Txt_mspFeeMarkup, false);
            //MSP Fee
            if (issueWorkOrderModel.str_Txt_mspRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_mspRegBillRate, issueWorkOrderModel.str_Txt_mspRegBillRate, true);
            //MSP OT Fee 
            if (issueWorkOrderModel.str_Txt_mspOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_mspOTBillRate, issueWorkOrderModel.str_Txt_mspOTBillRate, true);
            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Estimated Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);


        }
        #endregion IWO_Supervalu

        public static void IWO_Arkema(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
           // kwm.click(WDriver, KeyWords.locator_ID, "tabsExpandCollapse");
            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }

            //Charge Number Type
            if (issueWorkOrderModel.str_select_ChargeNumberType_ChargeNumberTypes != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_ChargeNumberType_ChargeNumberTypes, issueWorkOrderModel.str_select_ChargeNumberType_ChargeNumberTypes);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_select_ChargeNumberType_ChargeNumberTypes))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }


            //Charge Number
            if (issueWorkOrderModel.str_Typeahead_ChargeNumbers_txtChargeNo != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_Typeahead_ChargeNumbers_txtChargeNo.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumbers_txtChargeNo, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumbers_txtChargeNo, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_ChargeNumberAdd_AddCostOrgLegalGL);
                    }
                }
            }
            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_Txt_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }
            //Needed Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate, issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);
            objCommonMethods.Action_Page_Down(WDriver);
            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);

            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);

            //Supplier Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, false);
            //Supplier OT Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, false);
            objCommonMethods.Action_Page_Down(WDriver);

            //mspFeeMarkup
            if (issueWorkOrderModel.str_txt_MspFee_mspFeeMarkup != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MspFeemarkup_mspFeeMarkup, issueWorkOrderModel.str_txt_MspFee_mspFeeMarkup, false);

            //MSP Fee
            if (issueWorkOrderModel.str_txt_MspFee_mspRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MspFee_mspRegBillRate, issueWorkOrderModel.str_txt_MspFee_mspRegBillRate, true);


            //MSP OT Fee 
            if (issueWorkOrderModel.str_txt_MspOtFee_mspOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MspOtFee_mspOTBillRate, issueWorkOrderModel.str_txt_MspOtFee_mspOTBillRate, true);
            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);

            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);

            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);

            objCommonMethods.Action_Page_Down(WDriver);
            //Estimated Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);

        }

        #region IWO-Workspend-SallieMae
        public static void IWO_SallieMae(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

         //   kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_EXPANDALL_tabsExpandCollapse);

            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversAdd_addTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }


            //Charge Number
            //Business Unit - Disbaled


            //Cost Center 
            if (issueWorkOrderModel.str_Typeahead_ChargeCostCenterNumber_chargeCostCenterId != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeCostCenterNumber_chargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeCostCenterNumber_chargeCostCenterId, issueWorkOrderModel.str_Typeahead_ChargeCostCenterNumber_chargeCostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeCostCenterNumber_chargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_ChargeCostCenterNumber_chargeCostCenterId, issueWorkOrderModel.str_Typeahead_ChargeCostCenterNumber_chargeCostCenterId);

                }
            }

            //IT Project ID - Disabled 



            //GL Number 
            if (issueWorkOrderModel.str_select_GLNumber_chargeGLId != "")
            {

                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_HeadcountApproved_laborClassCode, issueWorkOrderModel.str_select_GLNumber_chargeGLId);
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_ChargeNumberAdd_addChargeNobtnNew);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //Needed Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate, issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);


            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Supplier Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, false);
            //Supplier OT Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, false);
            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);
            objCommonMethods.Action_Page_Down(WDriver);
            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue);

            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Estimated Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);


            //
        }
        #endregion IWO-WorkspendSallieMae
        
        public static void IWO_STTM(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

          
            objCommonMethods.Action_Page_Down(WDriver);
            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }
            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Needed Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate, issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Supplier Markup% 

            if (issueWorkOrderModel.str_txt_IW_SupplierMarkup_supplierMarkupRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierMarkup_supplierMarkupRate, issueWorkOrderModel.str_txt_IW_SupplierMarkup_supplierMarkupRate, true);
            //Supplier Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, false);
            //Supplier OT Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, false);
            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);
            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);
        }

        public static void IWO_YP(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }
            //Charge Number
            if (issueWorkOrderModel.str_Typeahead_ChargeNumbers_txtChargeNo != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_Typeahead_ChargeNumbers_txtChargeNo.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumbers_txtChargeNo, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_ChargeNumbers_txtChargeNo, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_ChargeNumberAdd_AddCostOrgLegalGL);
                    }
                }
            }

            //Gl Numbers
            if (issueWorkOrderModel.str_txt_GLNumbers_txtGLNo != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_GLNumbers_txtGLNo.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_GLNumbers_txtGLNo, words[r], false);
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_GLNumberAdd_addGLNobtn);
                        Thread.Sleep(1000);
                        kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "No");
                    }
                }
            }

            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_Txt_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }
            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);

            //Total Contract Value
            if (issueWorkOrderModel.str_txt_TotalContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_IW_TotalContractValue_totalContractValue, issueWorkOrderModel.str_txt_TotalContractValue_totalContractValue, false);




            //Needed Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_NeededStartDate_preferredStartDate, issueWorkOrderModel.str_Date_NeededStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            //Markup - Disabled 

            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate - Disabled

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);


            //Supplier Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, false);
            //Supplier OT Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, false);

            objCommonMethods.Action_Page_Down(WDriver);



            //
        }

        public static void IWO_Lear(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

            // kwm.click(WDriver, KeyWords.locator_ID, "tabsExpandCollapse");
            objCommonMethods.Action_Page_Down(WDriver);
            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }

            //Charge Number

            //Business Unit *
            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Select_Businessunit_ChargeorganizationID))
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_BusinessUnit_ChargeorganizationID, issueWorkOrderModel.str_Select_Businessunit_ChargeorganizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }

            }

            //Hyperion Code/GL Unit *
            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Select_HypersionCodeGLUnit_ChargeGLId))
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_HypersionCodeGLUnit_ChargeGLId, issueWorkOrderModel.str_Select_HypersionCodeGLUnit_ChargeGLId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }

            }

            //CORE *
            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Select_CORE_ChargeProjectId))
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_CORE_ChargeProjectId, issueWorkOrderModel.str_Select_CORE_ChargeProjectId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }

            }

            //AP Department *
            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Select_APDepartment_ChargedeptName))
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_APDepartment_ChargedeptName, issueWorkOrderModel.str_Select_APDepartment_ChargedeptName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }

            }

            //Account Code *
            if (issueWorkOrderModel.str_Typeahead_AccountCode_ChargeCostCenterId != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_AccountCode_ChargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_AccountCode_ChargeCostCenterId, issueWorkOrderModel.str_Typeahead_AccountCode_ChargeCostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_AccountCode_ChargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_AccountCode_ChargeCostCenterId, issueWorkOrderModel.str_Typeahead_AccountCode_ChargeCostCenterId);
                    //  return results;
                }
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_ChargeNumberADD_AddChargeNumber);
            }





            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }


            //Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_StartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_StartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_StartDate_preferredStartDate, issueWorkOrderModel.str_Date_StartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);

            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Supplier Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, false);
            //Supplier OT Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, false);
            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);
            objCommonMethods.Action_Page_Down(WDriver);
            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);


            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours per Calendar year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Estimated Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);



        }



        #region EQT
        public static void IWO_EQT(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }


            // Company *
            if (issueWorkOrderModel.str_Typeahead_Company_ChargedeptNumber != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_Company_ChargedeptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_Company_ChargedeptNumber, issueWorkOrderModel.str_Typeahead_Company_ChargedeptNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_Company_ChargedeptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_Company_ChargedeptNumber, issueWorkOrderModel.str_Typeahead_Company_ChargedeptNumber);
                    //  return results;
                }
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_ChargeNumberADD_AddChargeNumber);
            }


            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_Date_DesiredStartDate_preferredStartDate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }




            // Desired Start Date *
            //kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_DesiredStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_DesiredStartDate_preferredStartDate))
            {


                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_DesiredStartDate_preferredStartDate, issueWorkOrderModel.str_Date_DesiredStartDate_preferredStartDate, false);
                }
            }
            // End Date *
            // kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }

            // PO Number     
            if (issueWorkOrderModel.str_Typeahead_PoNumber_purchaseOrderNumber != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_PoNumber_purchaseOrderNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_PoNumber_purchaseOrderNumber, issueWorkOrderModel.str_Typeahead_PoNumber_purchaseOrderNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_PoNumber_purchaseOrderNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_PoNumber_purchaseOrderNumber, issueWorkOrderModel.str_Typeahead_PoNumber_purchaseOrderNumber);
                }
            }

            // Active Directory ID
            if (issueWorkOrderModel.str_txt_ActiveDirectoryID_customerTrackingNumber != "")
            {
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_ActiveDirectoryID_customerTrackingNumber, issueWorkOrderModel.str_txt_ActiveDirectoryID_customerTrackingNumber, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_ActiveDirectoryID_customerTrackingNumber, issueWorkOrderModel.str_txt_ActiveDirectoryID_customerTrackingNumber, false);
                }
            }






            // Candidate Pay Rate (USD) *
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            // Candidate OT Pay Rate (USD) *
            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);
            // Supplier Bill Rate (USD) *
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, false);
            // Supplier OT Bill Rate (USD) *
            if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, false);
            // Final Bill Rate (USD) *
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);
            // Final OT Bill Rate (USD) *
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);

            //Supplier Markup% 
            if (issueWorkOrderModel.str_txt_IW_SupplierMarkup_supplierMarkupRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierMarkup_supplierMarkupRate, issueWorkOrderModel.str_txt_IW_SupplierMarkup_supplierMarkupRate, true);



            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);


            //Total Contract Value
            if (issueWorkOrderModel.str_txt_TotalContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_IW_TotalContractValue_totalContractValue, issueWorkOrderModel.str_txt_TotalContractValue_totalContractValue, false);




        }
        #endregion EQT


        public static void IWO_SIGMA(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

            // kwm.click(WDriver, KeyWords.locator_ID, "tabsExpandCollapse");
            objCommonMethods.Action_Page_Down(WDriver);
            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_TimecardApproversDelete_deleteTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }

            //Charge Number

            //Cost Center 
            if (issueWorkOrderModel.str_typeahead_CostCenter_ChargeCostCenterId != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_typeahead_CostCenter_ChargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_typeahead_CostCenter_ChargeCostCenterId, issueWorkOrderModel.str_typeahead_CostCenter_ChargeCostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_typeahead_CostCenter_ChargeCostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_typeahead_CostCenter_ChargeCostCenterId, issueWorkOrderModel.str_typeahead_CostCenter_ChargeCostCenterId);
                    //  return results;
                }

            }

            //GL
            if (issueWorkOrderModel.str_Typeahead_GL_ChargeGLId != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_GL_ChargeGLId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_GL_ChargeGLId, issueWorkOrderModel.str_Typeahead_GL_ChargeGLId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_GL_ChargeGLId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_GL_ChargeGLId, issueWorkOrderModel.str_Typeahead_GL_ChargeGLId);
                    //  return results;
                }

            }



            //WBS Element  *
            if (issueWorkOrderModel.str_Typeahead_WBSElement_ChargeProjectId != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_WBSElement_ChargeProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_WBSElement_ChargeProjectId, issueWorkOrderModel.str_Typeahead_WBSElement_ChargeProjectId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_WBSElement_ChargeProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, issueWorkOrderModel.str_Typeahead_WBSElement_ChargeProjectId, issueWorkOrderModel.str_Typeahead_WBSElement_ChargeProjectId);
                    //  return results;
                }
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_ChargeNumberADD_AddChargeNumber);
            }





            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }


            //Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_StartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_StartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_StartDate_preferredStartDate, issueWorkOrderModel.str_Date_StartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);

            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Supplier Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, issueWorkOrderModel.str_txt_SupplierBillRate_supplierRegBillRate, false);
            //Supplier OT Bill Rate
            if (issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, issueWorkOrderModel.str_txt_SupplierOTBillRate_supplierOTBillRate, false);
            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);
            objCommonMethods.Action_Page_Down(WDriver);
            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);

            //Supplier Markup% 
            if (issueWorkOrderModel.str_txt_IW_SupplierMarkup_supplierMarkupRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierMarkup_supplierMarkupRate, issueWorkOrderModel.str_txt_IW_SupplierMarkup_supplierMarkupRate, true);


            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE, false);
            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE, false);
            //Total Hours per Calendar year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Estimated Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);



        }

        #region Ryder
        public static void IWO_Ryder(IssueWorkOrderModel issueWorkOrderModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

            //TimecardApprover_Add Card Approver
            if (issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_txt_TimecardApprovers_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {

                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TimecardApprovers_txtTimecardApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, words[r].ToString(), words[r].ToString());
                            //  return results;
                        }
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Click_TimecardApproversAdd_addTimecardApproverbtn);
                        //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_txtTimecardApprover, "");
                    }
                }
            }

            //Delete Time Crad Approver
            if (issueWorkOrderModel.str_Click_TimecardApproversDelete_deleteTimecardApproverbtn != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_Click_TimecardApproversDelete_deleteTimecardApproverbtn.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
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
                                elements[i].Click();
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Click_TimecardApproversDelete_deleteTimecardApproverbtn);
                            }
                        }
                    }
                }
            }
            //Charge Number
            if (issueWorkOrderModel.str_AddListTxt_ChargeNumbers != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
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
                    }
                }
            }
            //Delete charge Number
            if (issueWorkOrderModel.str_DeleteListTxt_ChargeNumbers != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_DeleteListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addChargeNo']/option"));

                        List<IWebElement> elements = lis_ClientNames.ToList();
                        for (int i = 0; i < elements.Count; i++)
                        {
                            if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                            {
                                elements[i].Click();
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteChargeNobtn);
                            }
                        }
                    }
                }
            }
            //Gl Numbers
            if (issueWorkOrderModel.str_AddListTxt_GLNumbers != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_AddListTxt_GLNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
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

            if (issueWorkOrderModel.str_DeleteListTxt_GLNumbers != "")
            {
                string[] separators1 = { "#" };
                string[] words = issueWorkOrderModel.str_DeleteListTxt_GLNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 1)
                {
                    for (int r = 0; r < words.Length; r++)
                    {
                        ICollection<IWebElement> lis_ClientNames = WDriver.FindElements(By.XPath("//select[@id='addGLNo']/option"));

                        List<IWebElement> elements = lis_ClientNames.ToList();
                        for (int i = 0; i < elements.Count; i++)
                        {
                            if (elements[i].Text.ToLower().Trim().EndsWith(words[r].ToString().ToLower().Trim()))
                            {
                                elements[i].Click();
                                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_deleteGLNobtn);
                            }
                        }
                    }
                }
            }
            Actions actions2 = new Actions(WDriver);
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            IWebElement scroll = WDriver.FindElement(By.Id(KeyWords.ID_Txt_supplierRegPayRate));
            try
            {
                actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
            catch
            {
                //
            }

            //Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_DesiredStartDate_preferredStartDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_DesiredStartDate_preferredStartDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_DesiredStartDate_preferredStartDate, issueWorkOrderModel.str_Date_DesiredStartDate_preferredStartDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate);

            if (!string.IsNullOrWhiteSpace(issueWorkOrderModel.str_Date_Enddate_endDate))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Date_Enddate_endDate, issueWorkOrderModel.str_Date_Enddate_endDate, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                }
            }
            actions2.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            //Candidate Pay Rate
            if (issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, issueWorkOrderModel.str_txt_CandidatePayRate_supplierRegPayRate, true);
            //Candidate OT Pay Rate 

            if (issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, issueWorkOrderModel.str_txt_CandidateOTPayRate_supplierOTPayRate, true);

            //Final Bill Rate  
            if (issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalBillRate_finalRegBillRate, issueWorkOrderModel.str_txt_FinalBillRate_finalRegBillRate, true);

            //Final OT Bill Rate
            if (issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_FinalOTBillRate_finalOTBillRate, issueWorkOrderModel.str_txt_FinalOTBillRate_finalOTBillRate, true);
            //mspFeeMarkup
            if (issueWorkOrderModel.str_txt_MspFee_mspFeeMarkup != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MspFeemarkup_mspFeeMarkup, issueWorkOrderModel.str_txt_MspFee_mspFeeMarkup, false);
            //MSP Fee
            if (issueWorkOrderModel.str_txt_MspOtFee_mspOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MspFee_mspRegBillRate, issueWorkOrderModel.str_txt_MspOtFee_mspOTBillRate, true);
            //MSP OT Fee 
            if (issueWorkOrderModel.str_Txt_mspOTBillRate != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_MSPOTBillRate_mspOTBillRate, issueWorkOrderModel.str_Txt_mspOTBillRate, true);


            //Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_HoursperweekNTE_weeklyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofHoursperweekNTE_weeklyRegHoursNTE, issueWorkOrderModel.str_Txt_weeklyRegHoursNTE, false);

            //	OT Hours Per Week NTE
            if (issueWorkOrderModel.str_txt_OThoursperweekNTE_weeklyOTHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_NumberofOThoursperweekNTE_weeklyOTHoursNTE, issueWorkOrderModel.str_Txt_weeklyOTHoursNTE, false);
            //Total Hours Per Calendar Year NTE
            if (issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, issueWorkOrderModel.str_txt_TotalHoursperCalendaryearNTE_yearlyRegHoursNTE, false);
            //Estimated Contract Value
            if (issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue != "")
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_EstimatedContractValue_totalContractValue, issueWorkOrderModel.str_txt_EstimatedContractValue_totalContractValue, false);

            //
            //
        }
        #endregion Ryder


        public static void TimecardApprover_Add(IssueWorkOrderModel issueWorkOrderModel, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods, Result results)
        {
            string[] words;
            if (issueWorkOrderModel.str_AddListTxt_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                words = issueWorkOrderModel.str_AddListTxt_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
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
        public static void TimecardApprover_Delete(IssueWorkOrderModel issueWorkOrderModel, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods, Result results)
        {
            string[] words;
            if (issueWorkOrderModel.str_DeleteListTxt_txtTimecardApprover != "")
            {
                string[] separators1 = { "#" };
                words = issueWorkOrderModel.str_DeleteListTxt_txtTimecardApprover.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
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
        public static void Chargenumber_Add(IssueWorkOrderModel issueWorkOrderModel, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods, Result results)
        {
            string[] words;
            string[] separators1 = { "#" };
            words = issueWorkOrderModel.str_AddListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
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
                }
            }
        }
        public static void Chargenumber_Delete(IssueWorkOrderModel issueWorkOrderModel, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods, Result results)
        {
            string[] words;
            string[] separators1 = { "#" };
            words = issueWorkOrderModel.str_DeleteListTxt_ChargeNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
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
        public static void GLnumber_Add(IssueWorkOrderModel issueWorkOrderModel, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods, Result results)
        {
            string[] words;
            string[] separators1 = { "#" };
            words = issueWorkOrderModel.str_AddListTxt_GLNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
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
        public static void GLnumber_Delete(IssueWorkOrderModel issueWorkOrderModel, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods, Result results)
        {
            string[] words;
            string[] separators1 = { "#" };
            words = issueWorkOrderModel.str_DeleteListTxt_GLNumbers.Split(separators1, StringSplitOptions.RemoveEmptyEntries);
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

}