// --------------------------------------------------------------------------------------------------------------------
//<copyright file="CreateRequirementSavi.cs" company="DCR Workforce Inc">
//   Copyright (c) DCR Workforce Inc. All rights reserved.
//   This code and information should not be copied and used outside of DCR Workforce Inc.
// </copyright>
// <summary>
//   Builds the Container for the Autofac IOC.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using SmartTrack.DataAccess.Models;

namespace SmartTrack
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using RelevantCodes.ExtentReports;
    using SmartTrack_Automation;
    using System;
    using System.Threading;

    public class CreateRequirementPerClient
    {

        #region SunTrust
        public static void ClientRequirementSunTrust(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_Select_WorkerClassification_laborClassCode))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_Select_WorkerClassification_laborClassCode)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            //Worker Classification 
            if (createRequirementModel.str_T1_Select_WorkerClassification_laborClassCode != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_WorkerClassification_laborClassCode, createRequirementModel.str_T1_Select_WorkerClassification_laborClassCode);
                if (results.Result1 == KeyWords.Result_FAIL)
                {

                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_WorkerClassification_laborClassCode, 1);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_WorkerClassification_laborClassCode);
                    }

                }
            }

            //Requestor *  
            if (createRequirementModel.str_T1_Typeahead_Requestor_altHiringManager != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_altHiringManager, createRequirementModel.str_T1_Typeahead_Requestor_altHiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_altHiringManager, createRequirementModel.str_T1_Typeahead_Requestor_altHiringManager);
                }
            }


            //Request Owner  *

            if (createRequirementModel.str_T1_Typeahead_RequestOwner_hiringManager != "")
            {

                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_RequestOwner_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_RequestOwner_hiringManager, createRequirementModel.str_T1_Typeahead_RequestOwner_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(2000);
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_RequestOwner_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_RequestOwner_hiringManager, createRequirementModel.str_T1_Typeahead_RequestOwner_hiringManager);
                    //  return results;
                }
            }

            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_WorkWeek_workScheduleID);
            //Company code - this filed is disable

            if (createRequirementModel.str_T1_Typeahead_Company_deptNumber != "")
            {

                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Company_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Company_deptNumber, createRequirementModel.str_T1_Typeahead_Company_deptNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(2000);
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Company_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Company_deptNumber, createRequirementModel.str_T1_Typeahead_Company_deptNumber);
                    //  return results;
                }
            }


            //Cost Center *
            if (createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_CostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(2000);
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_CostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId);
                    //  return results;
                }
            }


            //Engagement Type * *
            if (createRequirementModel.str_T1_Select_EngagementType_serviceMethodID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_EngagementType_serviceMethodID, createRequirementModel.str_T1_Select_EngagementType_serviceMethodID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {


                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_EngagementType_serviceMethodID, 2);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_EngagementType_serviceMethodID);
                    }

                }
            }


            //Reason for Engagement Id is reasonToHireID

            if (createRequirementModel.str_T1_select_ReasonForEngagement_reasonToHireID != "")
            {
                results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasonForEngagement_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {

                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasonForEngagement_reasonToHireID, 2);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasonForEngagement_reasonToHireID, createRequirementModel.str_T1_select_ReasonForEngagement_reasonToHireID);
                    }
                }
            }

            // Number of Resources * 

            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            // Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate);

            results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                kwm.click(WDriver, KeyWords.locator_XPath, "//*[@class='ui-datepicker-calendar']//a");
            }





            //if (createRequirementModel.str_T1_Date_StartDate_neededStartDate != "")
            //{
            //    results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_StartDate_neededStartDate);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate, createRequirementModel.str_T1_Date_StartDate_neededStartDate, false);
            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            //return results;
            //        }
            //    }
            //}

            // Enddate
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);


            results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today.AddMonths(6));

            //if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            //{
            //    results = kwm.Select_End_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_EndDate_enddate);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            //return results;
            //        }
            //    }
            //}

            //Work Location *

            if (createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Work Location Address *

            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Work week

            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_select_WorkWeek_workScheduleID))
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_WorkWeek_workScheduleID, createRequirementModel.str_T1_select_WorkWeek_workScheduleID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_WorkWeek_workScheduleID);
                }
            }
        }
        #endregion SunTrust
        public static void ClientRequirementColgate(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_CreatedUserID)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            //Requestor
            if (createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                }
            }


            // Organization Name *
            if (createRequirementModel.str_T1_select_OrganizationName_organizationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_OrganizationName_organizationID, createRequirementModel.str_T1_select_OrganizationName_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {

                    SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID))); //Locating select list
                    se.SelectByIndex(1);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_OrganizationName_organizationID);
                    }
                }
            }

            //PO Number
            if (createRequirementModel.str_T1_Typeahead_PONumber_poNumber != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_PONumber_poNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_PONumber_poNumber, createRequirementModel.str_T1_Typeahead_PONumber_poNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_PONumber_poNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_PONumber_poNumber, createRequirementModel.str_T1_Typeahead_PONumber_poNumber);
                }
            }

            //Buyer Name 
            if (createRequirementModel.str_T1_Typeahead_BuyerName_CostCenterId != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_BuyerName_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_BuyerName_CostCenterId, createRequirementModel.str_T1_Typeahead_BuyerName_CostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(3000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_BuyerName_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_BuyerName_CostCenterId, createRequirementModel.str_T1_Typeahead_BuyerName_CostCenterId);
                    //  return results;
                }
            }

            //Hiring Manager *

            if (createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(2000);
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                    //  return results;
                }
            }

            //Goods Received Approver *

            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_Typeahead_GoodsReceiptApprover_altHiringManager))
            {
                Thread.Sleep(3000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_GoodsReceiptApprover_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_GoodsReceiptApprover_altHiringManager, createRequirementModel.str_T1_Typeahead_GoodsReceiptApprover_altHiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_GoodsReceiptApprover_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_GoodsReceiptApprover_altHiringManager, createRequirementModel.str_T1_Typeahead_GoodsReceiptApprover_altHiringManager);
                    //  return results;
                }
            }


            // Number of Resources * 

            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Reason to Hire *

            if (createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID != "")
            {
                results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoHire_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_ReasontoHire_reasonToHireID))); //Locating select list
                    se.SelectByIndex(2);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoHire_reasonToHireID, createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID);
                    }
                }
            }

            //Start Date *
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate);

            if (createRequirementModel.strDateAssignmentStart != "")
            {
                                          // (IWebDriver driver, DateTime dtGivenDate,ExtentTest logTest)
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate, createRequirementModel.str_T1_Date_StartDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            objCommonMethods.Action_Button_Tab(WDriver);

            Thread.Sleep(3000);
            //End Date *
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                results = kwm.Select_End_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_EndDate_enddate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {

                    }
                }
            }
            objCommonMethods.Action_Button_Tab(WDriver);
            Thread.Sleep(1000);

            //Work Location *

            if (createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Work Location Address *

            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }
            // Shift Start

            if (createRequirementModel.str_T1_Select_ShiftStart_ProfitCenterId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ShiftStart_ProfitCenterId, createRequirementModel.str_T1_Select_ShiftStart_ProfitCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {

                    SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_ShiftStart_ProfitCenterId))); //Locating select list
                    se.SelectByIndex(1);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ShiftStart_ProfitCenterId);
                    }
                }
            }
            //Shift End

            if (createRequirementModel.str_T1_select_ShiftEnd_spendLevelId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ShiftEnd_spendLevelId, createRequirementModel.str_T1_select_ShiftEnd_spendLevelId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {

                    SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_ShiftEnd_spendLevelId))); //Locating select list
                    se.SelectByIndex(1);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ShiftEnd_spendLevelId);
                    }
                }
            }



        }


        public static void ClientRequirementCpchem(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }
            //Requestor *  ID_CreatedUserID
            if (createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                }
            }



            // Organization Name *
            if (createRequirementModel.str_T1_select_OrganizationName_organizationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_OrganizationName_organizationID, createRequirementModel.str_T1_select_OrganizationName_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {

                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_OrganizationName_organizationID, 1);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.ID_T1_select_OrganizationName_organizationID, KeyWords.ID_T1_select_OrganizationName_organizationID);
                    }
                }
            }


            // Number of Resources * 

            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Hiring Manager *

            if (createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager != "")
            {
                objCommonMethods.Action_Page_Down(WDriver);
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(2000);
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                    //  return results;
                }
            }


            //Anticipated Start Date

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_AnticipatedStartDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_AnticipatedStartDate_neededStartDate != "")
            {
                results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_AnticipatedStartDate_neededStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_AnticipatedStartDate_neededStartDate, createRequirementModel.str_T1_Date_AnticipatedStartDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            else
            {
                results = kwm.Select_Date_In_DatePicker(WDriver, createRequirementModel.str_T1_Date_AnticipatedStartDate_neededStartDate);
            }

            //End Date

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate);

            if (createRequirementModel.str_T1_Date_PlannedEndDate_enddate != "")
            {
                results = kwm.Select_End_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_PlannedEndDate_enddate);


                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, createRequirementModel.strDateAssignmentEnd, false);
                }

            }
            else
            {
                results = kwm.Select_Date_End_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_PlannedEndDate_enddate);

            }


            //Work Location 

            if (createRequirementModel.str_T1_Select_Worklocation_workLocationID != "")
            {
                //Thread.Sleep(2000);
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_Worklocation_workLocationID, createRequirementModel.str_T1_Select_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectInDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_Worklocation_workLocationID, createRequirementModel.str_T1_Select_Worklocation_workLocationID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        try
                        {
                            SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_Select_Worklocation_workLocationID))); //Locating select list
                            se.SelectByIndex(1);
                        }
                        catch
                        {
                            //
                        }
                    }
                }
            }

            ////Work Location *

            //if (createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID != "")
            //{
            //    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        //  return results;
            //    }
            //}

            //Work Location Address

            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }




        }

        public static void ClientRequirementCaesars(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }
            //Organization Name 
            if (createRequirementModel.str_T1_select_OrganizationName_organizationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_OrganizationName_organizationID, createRequirementModel.str_T1_select_OrganizationName_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Department *

            if (createRequirementModel.str_T1_Typeahead_Department_deptNumber != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Department_deptNumber, createRequirementModel.str_T1_Typeahead_Department_deptNumber);
                //  Thread.Sleep(2000);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Department_deptNumber, createRequirementModel.str_T1_Typeahead_Department_deptNumber);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, "a");
                        // return results;
                    }
                }
            }
            //Department Name - Disabled
            objCommonMethods.Action_Button_Tab(WDriver);

            //Engaging Manager


            if (createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager != "")
            {
                //Thread.Sleep(3000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Engagingmanager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Engagingmanager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager);
                    //  return results;
                }
            }

            //Alternate Hiring Manager 
            if (createRequirementModel.str_T1_Typeahead_AlternateHiringManager_altHiringManager != "")
            {
                Thread.Sleep(3000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_AlternateHiringManager_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_AlternateHiringManager_altHiringManager, createRequirementModel.str_T1_Typeahead_AlternateHiringManager_altHiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_AlternateHiringManager_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_AlternateHiringManager_altHiringManager, createRequirementModel.str_T1_Typeahead_AlternateHiringManager_altHiringManager);
                    //  return results;
                }
            }


            //Union Position

            if (createRequirementModel.str_T1_select_unionPosition_laborClassCode != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_unionPosition_laborClassCode, createRequirementModel.str_T1_select_unionPosition_laborClassCode);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Priority
            if (createRequirementModel.str_T1_select_Priority_priority != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Priority_priority, createRequirementModel.str_T1_select_Priority_priority);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Work Week 
            if (createRequirementModel.str_T1_select_WorkWeek_workScheduleID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_WorkWeek_workScheduleID, createRequirementModel.str_T1_select_WorkWeek_workScheduleID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Number of resources *
            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //Gaming Process
            if (createRequirementModel.str_T1_select_GamingProcess_programId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_GamingProcess_programId, createRequirementModel.str_T1_select_GamingProcess_programId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Reason for this request
            if (createRequirementModel.str_T1_select_ReasonforthisRequest_reasonToHireID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasonforthisRequest_reasonToHireID, createRequirementModel.str_T1_select_ReasonforthisRequest_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_txtneededStartDate);

            if (createRequirementModel.str_T1_Date_NeededDate_neededStartDate != "")
            {
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Now.AddMonths(-1));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_NeededDate_neededStartDate, createRequirementModel.str_T1_Date_NeededDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                KeyWords.dtEndDate = DateTime.Today.AddDays(int.Parse(createRequirementModel.str_T1_Date_EndDate_enddate));
                results = kwm.Select_End_Date_From_Picker(WDriver, createRequirementModel.strDateAssignmentEnd);
                //if (results.Result1 == KeyWords.Result_FAIL)
                //{
                //    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                //    if (results.Result1 == KeyWords.Result_FAIL)
                //    {

                //    }
                //}
                TimeSpan date = KeyWords.dtEndDate - KeyWords.dtStartDate;
                string strdayscount = date.TotalDays.ToString();
                int idayscount = Int32.Parse(strdayscount) + 1;
                createRequirementModel.str_T1_Date_EndDate_enddate = idayscount.ToString();
            }
            //Work Location *
            if (createRequirementModel.str_T1_Select_Worklocation_workLocationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_Worklocation_workLocationID, createRequirementModel.str_T1_Select_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Justification
            if (createRequirementModel.str_T1_txt_Justification_JustificationtoHire != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_Justification_JustificationtoHire, createRequirementModel.str_T1_txt_Justification_JustificationtoHire, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
            //Work Location Address *
            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                }
            }

            // Network Access Needed  Yes
            //CAESARS client By.Name("radio6")

            if (createRequirementModel.str_T1_btn_NetworkAcessNeeded_radio6 != "")
            {
                if (createRequirementModel.str_T1_btn_NetworkAcessNeeded_radio6.ToLower() == KeyWords.str_String_Compare_yes)
                {
                    results = objCommonMethods.Select_Radio_Button(WDriver, KeyWords.Name_T1_btn_NetworkAcessNeeded_radio6, "6_11");


                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_NetwotkAcessRole_singleLine7, createRequirementModel.str_T1_txt_NetwotkAcessRole_singleLine7, false);
                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(WDriver, KeyWords.Name_T1_btn_NetworkAcessNeeded_radio6, "6_12");

                }
            }

            //if (createRequirementModel.str_Radio_NetworkAccessNeeded.ToString().ToLower() == KeyWords.str_String_Compare_yes)
            //{
            //    try
            //    {
            //        WDriver.FindElement(By.Name(KeyWords.Name_RadioBtn_radio6)).Click();
            //    }
            //    catch
            //    {
            //        //
            //    }

            //    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_singleLine7, createRequirementModel.str_Txt_NetworkAccessRole, false);
            //}
            //else
            //{
            //    try
            //    {
            //        WDriver.FindElement(By.XPath(KeyWords.Xpath_RadioBtn_radio6_2)).Click();
            //    }
            //    catch
            //    {
            //    }

            //}

            //  Caesars Email Needed Yes
            //input[@name='radio6']
            //CAESARS client By.Name("radio5")

            if (createRequirementModel.str_T1_btn_CeasarsEmailNeeded_radio5 != "")
            {
                if (createRequirementModel.str_T1_btn_CeasarsEmailNeeded_radio5.ToLower() == KeyWords.str_String_Compare_yes)
                {
                    results = objCommonMethods.Select_Radio_Button(WDriver, KeyWords.Name_T1_btn_CeasarsEmailNeeded_radio5, "5_9");
                }


                else
                {

                    results = objCommonMethods.Select_Radio_Button(WDriver, KeyWords.Name_T1_btn_CeasarsEmailNeeded_radio5, "5_10");

                }
            }

            //if (createRequirementModel.str_Radio_CaesarsEmailNeeded.ToString().ToLower() == KeyWords.str_String_Compare_yes)
            //{
            //    try
            //    {
            //        WDriver.FindElement(By.Name(KeyWords.Name_RadioBtn_radio6)).Click();
            //    }
            //    catch
            //    {
            //        //
            //    }
            //}
            //else
            //{
            //    try
            //    {
            //        WDriver.FindElement(By.XPath(KeyWords.Xpath_RadioBtn_radio5_2)).Click();
            //    }
            //    catch
            //    {
            //    }
            //}

            //  Caesars Email Needed No
            //  xpath=(//input[@name='radio6'])[2]
        }

        public static void ClientRequirementDyncorp(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_select_Divison_organizationID))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_select_Divison_organizationID)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(500);
                    }
                    catch
                    {
                    }
                }
            }
            // Division *
            if (createRequirementModel.str_T1_select_Divison_organizationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Divison_organizationID, createRequirementModel.str_T1_select_Divison_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_Divison_organizationID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            // COE/BAT
            if (createRequirementModel.str_T1_select_COEBAT_ProfitCenterId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_COEBAT_ProfitCenterId, createRequirementModel.str_T1_select_COEBAT_ProfitCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_COEBAT_ProfitCenterId))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Dept/Program/Task Order *
            if (createRequirementModel.str_T1_select_DeptProgramTaskOrder_programId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_DeptProgramTaskOrder_programId, createRequirementModel.str_T1_select_DeptProgramTaskOrder_programId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_DeptProgramTaskOrder_programId))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            // PA *   
            if (createRequirementModel.str_T1_txt_PA_association != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_PA_association, createRequirementModel.str_T1_txt_PA_association, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Requestor 

            if (createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                    //  return results;
                }
            }




            //PAA *
            if (createRequirementModel.str_T1_select_PAA_CostCenterId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_PAA_CostCenterId, createRequirementModel.str_T1_select_PAA_CostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_PAA_CostCenterId))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //HiringManager Manager *
            if (createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                    //  return results;
                }
            }

            //Manager PeopleSoft Number - Auto Populated Disabled
            if (createRequirementModel.str_T1_txt_ManagerPeopleSoftNumber_ServDept != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_ManagerPeopleSoftNumber_ServDept, createRequirementModel.str_T1_txt_ManagerPeopleSoftNumber_ServDept, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //Needed  Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_NeededDate_neededStartDate);

            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_Date_NeededDate_neededStartDate))
            {
                results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_NeededDate_neededStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_NeededDate_neededStartDate, createRequirementModel.str_T1_Date_NeededDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_Date_EndDate_enddate))
            {
                results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_NeededDate_neededStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //Number of Resources *
            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);

            //Reason to Hire *
            if (createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoHire_reasonToHireID, createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_ReasontoHire_reasonToHireID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }
            //Seciruty Clearance *
            if (createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID != "")
            {
                if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID))
                {
                    if (createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID.ToLower().Equals(KeyWords.str_String_Compare_noclearance))
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_SecurityClearance_securityClearanceLevelID, createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //return results;
                        }
                    }
                    else
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_SecurityClearance_securityClearanceLevelID, createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //return results;
                        }
                        if (createRequirementModel.str_T1_btn_CanStartwithoutClearance_txtWithout.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_CanStartwithoutClearance_txtWithoutYes);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                // return results;
                            }
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_CanStartwithoutClearance_txtWithoutNo);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                // return results;
                            }
                        }
                        if (createRequirementModel.str_T1_btn_InterimClearanceSufficient_txtSufficient.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_InterimClearanceSufficient_txtSufficientYes);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //  return results;
                            }
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_InterimClearanceSufficient_txtSufficientNo);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                // return results;
                            }
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T1_txt_PrimeContractNumber_txtContractNumber, createRequirementModel.str_T1_txt_PrimeContractNumber_txtContractNumber, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }
                        objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strBrowserName + "_");
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.str_T1_btn_SecurityClearanceDetailsMSGActionButton_Submit);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                        Thread.Sleep(3000);
                        objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strBrowserName + "_");
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.str_T1_btn_SecurityClearanceDetailsMsgwindowActionButton);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                        Thread.Sleep(3000);
                    }
                }
            }

            // US Citizenship Required *
            if (createRequirementModel.str_T1_btn_USCitizenshipRequired_laborClassCode != "")
            {
                if (createRequirementModel.str_T1_btn_USCitizenshipRequired_laborClassCode.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_USCitizenshipRequired_laborClassCode63);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_USCitizenshipRequired_laborClassCode64);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_USCitizenshipRequired_laborClassCode64);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
            //Work Location *

            if (createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Work Location Address *
            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {

                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
            //Work Week *
            if (createRequirementModel.str_T1_select_WorkWeek_workScheduleID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_WorkWeek_workScheduleID, createRequirementModel.str_T1_select_WorkWeek_workScheduleID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_WorkWeek_workScheduleID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            // EAA Approver
            if (createRequirementModel.str_T1_Typeahead_EAAApprover_altHiringManager != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_EAAApprover_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_EAAApprover_altHiringManager, createRequirementModel.str_T1_Typeahead_EAAApprover_altHiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_EAAApprover_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_EAAApprover_altHiringManager, createRequirementModel.str_T1_Typeahead_EAAApprover_altHiringManager);
                    //  return results;
                }
            }



            //Justification for Hire

            if (createRequirementModel.str_T1_txt_Justificationforhire_JustificationtoHire != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_Justificationforhire_JustificationtoHire, createRequirementModel.str_T1_txt_Justificationforhire_JustificationtoHire, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
        }


        #region Ryder
        public static void ClientRequirementRyder(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            // Organization Name *

            if (createRequirementModel.str_T1_select_OrganizationName_organizationID != "")
            {
                Thread.Sleep(2000);

                // results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, "organizationID", KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.strEngagingManager_LastName, createRequirementModel.strEngagingManager_LastName);
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_OrganizationName_organizationID, createRequirementModel.str_T1_select_OrganizationName_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Service Method *
            if (createRequirementModel.str_T1_select_ServiceMethod_serviceMethodID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ServiceMethod_serviceMethodID, createRequirementModel.str_T1_select_ServiceMethod_serviceMethodID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_ServiceMethod_serviceMethodID))); //Locating select list
                        se.SelectByIndex(2);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Location Code *
            Thread.Sleep(5000);
            if (createRequirementModel.str_T1_typehead_LocationCode_CostCenterId != "")
            {
                //results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_selectCostCenterId, createRequirementModel.str_Txt_AccountAssignment);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_typehead_LocationCode_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_typehead_LocationCode_CostCenterId, createRequirementModel.str_T1_typehead_LocationCode_CostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_typehead_LocationCode_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_typehead_LocationCode_CostCenterId, createRequirementModel.str_T1_typehead_LocationCode_CostCenterId);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Location Name - Disabled

            //Requestor -  Disabled

            Thread.Sleep(2000);
            //Engaging Manager *
            if (createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager != "")
            {

                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Engagingmanager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager);
                Thread.Sleep(2000);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Engagingmanager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, "a");
                    // return results;
                }
            }




            // Desired Start Date *
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_DesiredStartDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_DesiredStartDate_neededStartDate != "")
            {
                KeyWords.dtStartDate = DateTime.Today.AddDays(int.Parse(createRequirementModel.str_T1_Date_DesiredStartDate_neededStartDate));
                results = kwm.Select_Date_From_Picker(WDriver, KeyWords.dtStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_DesiredStartDate_neededStartDate, createRequirementModel.str_T1_Date_NeededDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            // End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                KeyWords.dtEndDate = DateTime.Today.AddDays(int.Parse(createRequirementModel.str_T1_Date_EndDate_enddate));


                //results = kwm.Select_End_Date_From_Picker(WDriver, createRequirementModel.strDateAssignmentEnd);
                results = kwm.Select_Date_From_Picker(WDriver, KeyWords.dtEndDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {

                    }
                }
            }

            TimeSpan date = KeyWords.dtEndDate - KeyWords.dtStartDate;

            string strdayscount = date.TotalDays.ToString();
            int idayscount = Int32.Parse(strdayscount) + 1;
            createRequirementModel.str_T1_Date_EndDate_enddate = idayscount.ToString();

            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_Comments_JustificationtoHire);
            //Work Location *

            if (createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);

                    //  return results;

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_selectHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                    }

                }
            }

            // Number of Resources *
            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Work Location Address *

            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                    //  return results;
                }
            }

            //Reason to Engage *
            if (createRequirementModel.str_T1_select_ReasonToEngage_reasonToHireID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoEngage_reasonToHireID, createRequirementModel.str_T1_select_ReasonToEngage_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_ReasontoEngage_reasonToHireID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Direct Fill *
            if (createRequirementModel.str_T1_select_DirectFill_laborClassCode != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_DirectFill_laborClassCode, createRequirementModel.str_T1_select_DirectFill_laborClassCode);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_DirectFill_laborClassCode))); //Locating select list
                        se.SelectByIndex(2);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            // Shift Start
            if (createRequirementModel.str_T1_Select_ShiftStart_ProfitCenterId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_ShiftStart_ProfitCenterId, createRequirementModel.str_T1_Select_ShiftStart_ProfitCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_Select_ShiftStart_ProfitCenterId))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Shift End
            if (createRequirementModel.str_T1_Select_ShiftEnd_spendLevelId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_ShiftEnd_spendLevelId, createRequirementModel.str_T1_Select_ShiftEnd_spendLevelId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_Select_ShiftEnd_spendLevelId))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Comments

            if (createRequirementModel.str_T1_txt_Comments_JustificationtoHire != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_Comments_JustificationtoHire, createRequirementModel.str_T1_txt_Comments_JustificationtoHire, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Text_Ifthespendisintheplanwhatlocationcodeappliestoit_singleLine12);



            //IT Professional/SOW Requisitions Only 

            //Does the desired skill set exist at Ryder today

            if (createRequirementModel.str_T1_btn_DoesthedesiredskillsetexistatRydertoday != "")
            {
                if (createRequirementModel.str_T1_btn_DoesthedesiredskillsetexistatRydertoday.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_T1_btn__DoesthedesiredskillsetexistatRydertoday_Yes);
                    if (results.Result1 == KeyWords.Result_PASS)
                    {
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Text_Whatisthereasonfortheinabilitytoattainthedesiredresource_singleLine10, createRequirementModel.str_T1_Text_Whatisthereasonfortheinabilitytoattainthedesiredresource_singleLine10, false);
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_T1_btn_DoesthedesiredskillsetexistatRydertoday_No);

                    if (results.Result1 == KeyWords.Result_PASS)
                    {
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Text_Whoisthedesiredresource_singleLine9, createRequirementModel.str_T1_Text_Whoisthedesiredresource_singleLine9, false);
                    }
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_T1_btn_DoesthedesiredskillsetexistatRydertoday_No);

                if (results.Result1 == KeyWords.Result_PASS)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Text_Whoisthedesiredresource_singleLine9, createRequirementModel.str_T1_Text_Whoisthedesiredresource_singleLine9, false);
                }

            }


            //Is this spend in your plan
            if (createRequirementModel.str_T1_btn_Isthisspendinyourplan != "")
            {
                if (createRequirementModel.str_T1_btn_Isthisspendinyourplan.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_T1_btn_Isthisspendinyourplan_Yes);
                    if (results.Result1 == KeyWords.Result_PASS)
                    {
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Text_Ifthespendisintheplanwhatlocationcodeappliestoit_singleLine12, createRequirementModel.str_T1_Text_Ifthespendisintheplanwhatlocationcodeappliestoit_singleLine12, false);
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_T1_btn_Isthisspendinyourplan_No);


                }

            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_T1_btn_Isthisspendinyourplan_No);

                if (results.Result1 == KeyWords.Result_PASS)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Text_Ifthespendisintheplanwhatlocationcodeappliestoit_singleLine12, createRequirementModel.str_T1_Text_Ifthespendisintheplanwhatlocationcodeappliestoit_singleLine12, false);
                }

            }

            //Have you searched for the resource in internal resource application
            if (createRequirementModel.str_T1_btn_Haveyousearchedfortheresourceininternalresourceapplication != "")
            {
                if (createRequirementModel.str_T1_btn_Haveyousearchedfortheresourceininternalresourceapplication.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_T1_btn_Haveyousearchedfortheresourceininternalresourceapplication_Yes);

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_T1_btn_Haveyousearchedfortheresourceininternalresourceapplication_No);


                }

            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_T1_btn_Haveyousearchedfortheresourceininternalresourceapplication_No);



            }



        }
        #endregion Ryder
        #region Keybank
        public static void ClientRequirementKeybank(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_select_LabourCategory_serviceMethodID))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_select_LabourCategory_serviceMethodID)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }


            // Labor Category *
            if (createRequirementModel.str_T1_select_LabourCategory_serviceMethodID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_LabourCategory_serviceMethodID, createRequirementModel.str_T1_select_LabourCategory_serviceMethodID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_LabourCategory_serviceMethodID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Requestor  *
            if (createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID != "")
            {
                //  Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                    //  return results;
                }
            }

            //Engaging Manager
            if (createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager != "")
            {
                //   Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_EngagingManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_EngagingManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager);
                    //  return results;
                }
            }

            //Supervisory Org/HR Cost Center - Disabled 

            //Company Number
            if (createRequirementModel.str_T1_Select_CompanyNumber_deptNumber != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_CompanyNumber_deptNumber, createRequirementModel.str_T1_Select_CompanyNumber_deptNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_Select_CompanyNumber_deptNumber))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }
            // venky
            Thread.Sleep(3000);

            //HR Cost Center
            if (createRequirementModel.str_T1_Select_HRCostCenter_programId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_HRCostCenter_programId, createRequirementModel.str_T1_Select_HRCostCenter_programId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_Select_HRCostCenter_programId))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            // AP Cost Center
            if (createRequirementModel.str_T1_Typeahead_APCostCenter_CostCenterId != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_APCostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_APCostCenter_CostCenterId, createRequirementModel.str_T1_Typeahead_APCostCenter_CostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_APCostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_APCostCenter_CostCenterId, createRequirementModel.str_T1_Typeahead_APCostCenter_CostCenterId);
                    //  return results;
                }
            }

            //Commodity Code
            if (createRequirementModel.str_T1_Select_CommodityCode_laborClassCode != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_CommodityCode_laborClassCode, createRequirementModel.str_T1_Select_CommodityCode_laborClassCode);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_Select_CommodityCode_laborClassCode))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_Justification_JustificationtoHire);


            //Reason for Hire *
            if (createRequirementModel.str_T1_select_ReasonForHire_reasonToHireID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasonForHire_reasonToHireID, createRequirementModel.str_T1_select_ReasonForHire_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_ReasonForHire_reasonToHireID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }


            //Number of resources

            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            // Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_StartDate_neededStartDate != "")
            {
                results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_StartDate_neededStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate, createRequirementModel.str_T1_Date_StartDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            // Enddate
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
              //  results = kwm.Select_End_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_EndDate_enddate);
                //code added for keybank client  
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Now.AddMonths(6));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //Work Location *

            if (createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Work Location Address *
            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {

                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //EPPIC Project *
            if (createRequirementModel.str_T1_Typeahead_EPPICProject_ProjectId != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_EPPICProject_ProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_EPPICProject_ProjectId, createRequirementModel.str_T1_Typeahead_EPPICProject_ProjectId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_EPPICProject_ProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_EPPICProject_ProjectId, createRequirementModel.str_T1_Typeahead_EPPICProject_ProjectId);
                    //  return results;
                }
            }

            //EPPIC Role 
            if (createRequirementModel.str_T1_Select_EPPICRole_spendLevelId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_EPPICRole_spendLevelId, createRequirementModel.str_T1_Select_EPPICRole_spendLevelId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_Select_EPPICRole_spendLevelId))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //EPPIC Region

            if (createRequirementModel.str_T1_Select_EPPICRegion_ProfitCenterId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_EPPICRegion_ProfitCenterId, createRequirementModel.str_T1_Select_EPPICRegion_ProfitCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_Select_EPPICRegion_ProfitCenterId))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }


            //EPPIC Resource Pool
            if (createRequirementModel.str_T1_Select_EPPICResourcePool_matrixNumber != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_EPPICResourcePool_matrixNumber, createRequirementModel.str_T1_Select_EPPICResourcePool_matrixNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_Select_EPPICResourcePool_matrixNumber))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }


            //Justification
            if (createRequirementModel.str_T1_txt_Justification_JustificationtoHire != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_Justification_JustificationtoHire, createRequirementModel.str_T1_txt_Justification_JustificationtoHire, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
        }
        #endregion Keybank


        public static void ClientRequirementAltria(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }
            // Requestor *   id="CreatedUserID"

            if (createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                    //  return results;
                }
            }

            // Company code *
            if (createRequirementModel.str_T1_select_CompanyCode_deptNumber != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_CompanyCode_deptNumber, createRequirementModel.str_T1_select_CompanyCode_deptNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_CompanyCode_deptNumber))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Company Name AutoPopulated

            // Account Assignment *
            if (createRequirementModel.str_T1_Radio_AccountAssignment_CostCenter_AccountAssignment1 != "")
            {
                if (createRequirementModel.str_T1_Radio_AccountAssignment_CostCenter_AccountAssignment1.ToLower().Equals(KeyWords.str_String_Compare_costcenter))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Radio_AccountAssignment_CostCenter_AccountAssignment1);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //
                    }
                    if (results.Result1 == KeyWords.Result_PASS)
                    {
                        //Cost Center *
                        Thread.Sleep(5000);
                        if (createRequirementModel.str_T1_select_CostCenter_CostCenterId != "")
                        {
                            results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_typehead_CostCenter_CostCenterId, createRequirementModel.str_T1_select_CostCenter_CostCenterId);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                try
                                {
                                    SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_typehead_CostCenter_CostCenterId))); //Locating select list
                                    se.SelectByIndex(1);
                                }
                                catch
                                {
                                    //
                                }
                            }
                        }
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Radio_AccountAssignment_WBS_AccountAssignment2);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    if (results.Result1 == KeyWords.Result_PASS)
                    {
                        //WBS Element *
                        Thread.Sleep(5000);
                        if (createRequirementModel.str_T1_select_AccountAssignmentWBS_ProjectId != "")
                        {
                            results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_AccountAssignmentWBS_ProjectId, createRequirementModel.str_T1_select_AccountAssignmentWBS_ProjectId);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                try
                                {
                                    SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_AccountAssignmentWBS_ProjectId))); //Locating select list
                                    se.SelectByIndex(1);
                                }
                                catch
                                {
                                    //
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Radio_AccountAssignment_WBS_AccountAssignment2);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
                if (results.Result1 == KeyWords.Result_PASS)
                {
                    //WBS Element *
                    Thread.Sleep(5000);
                    if (createRequirementModel.str_T1_select_AccountAssignmentWBS_ProjectId != "")
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_AccountAssignmentWBS_ProjectId, createRequirementModel.str_T1_select_AccountAssignmentWBS_ProjectId);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            try
                            {
                                SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_AccountAssignmentWBS_ProjectId))); //Locating select list
                                se.SelectByIndex(1);
                            }
                            catch
                            {
                                //
                            }
                        }
                    }
                }
            }

            //Reason to Hire *
            if (createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoHire_reasonToHireID, createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_ReasontoHire_reasonToHireID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Number of Resources *
            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            // Functional Area *
            if (createRequirementModel.str_T1_select_FunctionalArea_ProfitCenterId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_FunctionalArea_ProfitCenterId, createRequirementModel.str_T1_select_FunctionalArea_ProfitCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_FunctionalArea_ProfitCenterId))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Engaging Manager *
            if (createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_EngagingManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_EngagingManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager);
                    //  return results;
                }
            }

            //Alternate Engaging Manager

            if (createRequirementModel.str_T1_Typeahead_AlternateHiringManager_altHiringManager != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_AlternateHiringManager_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_AlternateHiringManager_altHiringManager, createRequirementModel.str_T1_Typeahead_AlternateHiringManager_altHiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_AlternateHiringManager_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_AlternateHiringManager_altHiringManager, createRequirementModel.str_T1_Typeahead_AlternateHiringManager_altHiringManager);
                    //  return results;
                }
            }

            //Start Date *
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate);

            if (createRequirementModel.strDateAssignmentStart != "")
            {
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Now.AddMonths(-1));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate, createRequirementModel.str_T1_Date_StartDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //End Date *
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Now.AddMonths(10));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {

                    }
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Work Location *
            if (createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID != "")
            {
                results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                }
            }
            //Work Location Address *
            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                }
            }
            //Justification

            if (createRequirementModel.str_T1_txt_Justification_JustificationtoHire != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_Justification_JustificationtoHire, createRequirementModel.str_T1_txt_Justification_JustificationtoHire, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
        }

        public static void ClientRequirementDiscover(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_select_BusinessUnit_organizationID))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_select_BusinessUnit_organizationID)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            //Business Unit

            if (createRequirementModel.str_T1_select_BusinessUnit_organizationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_BusinessUnit_organizationID, createRequirementModel.str_T1_select_BusinessUnit_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            //Labor Category
            if (createRequirementModel.str_T1_select_LabourCategory_serviceMethodID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_LabourCategory_serviceMethodID, createRequirementModel.str_T1_select_LabourCategory_serviceMethodID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //HR Cost Center
            if (createRequirementModel.str_T1_Typeahead_HRCostCenter_programId != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HRCostCenter_programId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HRCostCenter_programId, createRequirementModel.str_T1_Typeahead_HRCostCenter_programId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HRCostCenter_programId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HRCostCenter_programId, createRequirementModel.str_T1_Typeahead_HRCostCenter_programId);
                    //  return results;
                }
            }

            //AP Cost Center
            if (createRequirementModel.str_T1_Typeahead_APCostCenter_CostCenterId != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_APCostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_APCostCenter_CostCenterId, createRequirementModel.str_T1_Typeahead_APCostCenter_CostCenterId);
            }

            //GL Account

            if (createRequirementModel.str_T1_select_GLAccount_GLId != "")
            {
                //Thread.Sleep(2000);
                for (int i = 0; i < 100; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_select_GLAccount_GLId)).Enabled)
                        {
                            break;
                        }
                        Thread.Sleep(1000);
                    }
                    catch
                    {
                    }
                }
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_GLAccount_GLId, createRequirementModel.str_T1_select_GLAccount_GLId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_GLAccount_GLId, createRequirementModel.str_T1_select_GLAccount_GLId);
                    //  return results;
                }
            }

            //Requestor - Disabled 




            //Hiring Manager 

            if (createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                    //  return results;
                }
            }

            //Alternate Hiring Manager

            if (createRequirementModel.str_T1_Typeahead_AlternateHiringManager_altHiringManager != "")
            {
                Thread.Sleep(3000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_AlternateHiringManager_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_AlternateHiringManager_altHiringManager, createRequirementModel.str_T1_Typeahead_AlternateHiringManager_altHiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_AlternateHiringManager_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_AlternateHiringManager_altHiringManager, createRequirementModel.str_T1_Typeahead_AlternateHiringManager_altHiringManager);
                    //  return results;
                }
            }


            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_JustificationtoHire_JustificationtoHire);


            //Work Location

            if (createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Number of Resources

            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Work Location Address
            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                //results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_selectworkLocationAddress, createRequirementModel.strSelectWorkLocationAddress,false);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Reason to Hire

            if (createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoHire_reasonToHireID, createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Acess Location
            if (createRequirementModel.str_T1_select_AcessLocation_siteLocationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_AcessLocation_siteLocationID, createRequirementModel.str_T1_select_AcessLocation_siteLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_AcessLocation_siteLocationID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }
            Thread.Sleep(3000);
            //Desired Start Date
           
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_DesiredStartDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_DesiredStartDate_neededStartDate != "")
            {
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today.AddMonths(-1));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_DesiredStartDate_neededStartDate, createRequirementModel.str_T1_Date_DesiredStartDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

           

            //EndDate

           

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today.AddMonths(3));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);



            //Justification to hire 

            if (createRequirementModel.str_T1_txt_JustificationtoHire_JustificationtoHire != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_JustificationtoHire_JustificationtoHire, createRequirementModel.str_T1_txt_JustificationtoHire_JustificationtoHire, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            // Badge Access
            if (createRequirementModel.str_T1_btn_BadgeAcess_laborClassCode.ToLower().Equals(KeyWords.str_String_Compare_yes))
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_BadgeAcess_laborClassCode57);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_BadgeAcess_laborClassCode58);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            // System Access

            if (createRequirementModel.str_T1_btn_SystemAcess_directIndirect.ToLower().Equals(KeyWords.str_String_Compare_yes))
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_SystemAcess_directIndirectTrue);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_SystemAcess_directIndirectFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
        }


        public static void ClientRequirementWelchallyn(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            // Organization Name *
            if (createRequirementModel.str_T1_select_OrganizationName_organizationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_OrganizationName_organizationID, createRequirementModel.str_T1_select_OrganizationName_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            // Company code *
            if (createRequirementModel.str_T1_select_CompanyCode_deptNumber != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_CompanyCode_deptNumber, createRequirementModel.str_T1_select_CompanyCode_deptNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_CompanyCode_deptNumber))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }
            //Cost Center *
            if (createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId != "")
            {
                results = kwm.select_List_typeahead_WA(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_CostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_WA(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_CostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(5000);
                        results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_CostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId);
                        //  return results;
                    }
                }
            }

            //Project#/WBS Element

            if (createRequirementModel.str_T1_Typeahead_ProjectWBSElement_ProjectId != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_ProjectWBSElement_ProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_ProjectWBSElement_ProjectId, createRequirementModel.str_T1_Typeahead_ProjectWBSElement_ProjectId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_ProjectWBSElement_ProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_ProjectWBSElement_ProjectId, createRequirementModel.str_T1_Typeahead_ProjectWBSElement_ProjectId);
                    //  return results;
                }
            }

            //General Ledger Account *
            if (createRequirementModel.str_T1_select_GeneralLedgerAccount_GLId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_GeneralLedgerAccount_GLId, createRequirementModel.str_T1_select_GeneralLedgerAccount_GLId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_GeneralLedgerAccount_GLId))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }
            //Reason for Hire *
            if (createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoHire_reasonToHireID, createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_ReasontoHire_reasonToHireID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }
            //Work Week *
            if (createRequirementModel.str_T1_select_WorkWeek_workScheduleID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_WorkWeek_workScheduleID, createRequirementModel.str_T1_select_WorkWeek_workScheduleID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_WorkWeek_workScheduleID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }
            //Priority
            if (createRequirementModel.str_T1_select_Priority_priority != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Priority_priority, createRequirementModel.str_T1_select_Priority_priority);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_Priority_priority))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }
            objCommonMethods.Action_Button_Tab(WDriver);
            objCommonMethods.Action_Page_Down(WDriver);
            //Requestor - Disabled

            //Hiring Manager *
            if (createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                    //  return results;
                }
            }


            //Needed Date *
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_NeededDate_neededStartDate);



            if (createRequirementModel.str_T1_Date_NeededDate_neededStartDate != "")
            {
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today.AddMonths(-1));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_NeededDate_neededStartDate, createRequirementModel.str_T1_Date_NeededDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //End Date

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today.AddMonths(3));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            //objCommonMethods.Action_Page_Down(WDriver);

            //Personnel Area *
            if (createRequirementModel.str_T1_select_PersonnelArea_workLocationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_PersonnelArea_workLocationID, createRequirementModel.str_T1_select_PersonnelArea_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_PersonnelArea_workLocationID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Number of Positions *
            if (createRequirementModel.str_T1_Txt_NumberofPositions_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofPositions_noofresources, createRequirementModel.str_T1_Txt_NumberofPositions_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //Personnel Area Address
            if (createRequirementModel.str_T1_Typeahead_PersonnelAreaAddress_workLocationAddress != "")
            {
                //results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_selectworkLocationAddress, createRequirementModel.strSelectWorkLocationAddress,false);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_PersonnelAreaAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_PersonnelAreaAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_PersonnelAreaAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Request Justification 
            if (createRequirementModel.str_T1_txt_RequestJustification_JustificationtoHire != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_RequestJustification_JustificationtoHire, createRequirementModel.str_T1_txt_RequestJustification_JustificationtoHire, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
        }
    
        public static void ClientRequirementKCPL(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_selectHiringManager))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (kwm.isElementDisplayed(WDriver, KeyWords.ID_selectHiringManager))
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            //Hiring Manager *
            if (createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                    //  return results;
                }
            }

            // GL Business Unit *
            if (createRequirementModel.str_T1_select_GLBusinessUnit_GLId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_GLBusinessUnit_GLId, createRequirementModel.str_T1_select_GLBusinessUnit_GLId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_GLBusinessUnit_GLId, createRequirementModel.str_T1_select_GLBusinessUnit_GLId);
                }
            }
            else
            {
                SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_GLBusinessUnit_GLId)));
                se.SelectByIndex(1);
            }

            //Compliance Access Needed *
            if (createRequirementModel.str_T1_Select_ComplianceAccessNeeded_matrixNumber != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_ComplianceAccessNeeded_matrixNumber, createRequirementModel.str_T1_Select_ComplianceAccessNeeded_matrixNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_ComplianceAccessNeeded_matrixNumber, createRequirementModel.str_T1_Select_ComplianceAccessNeeded_matrixNumber);
                }

            }
            else
            {
                SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_Select_ComplianceAccessNeeded_matrixNumber)));
                se.SelectByIndex(1);
            }

            //Engagement Type *
            if (createRequirementModel.str_T1_select_EngagementType_serviceMethodID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_EngagementType_serviceMethodID, createRequirementModel.str_T1_select_EngagementType_serviceMethodID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_EngagementType_serviceMethodID, createRequirementModel.str_T1_select_EngagementType_serviceMethodID);
                }
            }
            else
            {
                SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_EngagementType_serviceMethodID)));
                se.SelectByIndex(1);
            }

            //Reason for Engagement *
            if (createRequirementModel.str_T1_select_ReasonForEngagement_reasonToHireID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasonForEngagement_reasonToHireID, createRequirementModel.str_T1_select_ReasonForEngagement_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasonForEngagement_reasonToHireID, createRequirementModel.str_T1_select_ReasonForEngagement_reasonToHireID);
                }
            }

            else
            {
                SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_ReasonForEngagement_reasonToHireID)));
                se.SelectByIndex(1);
            }

            //Number of Resources *
            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                }
            }
            Thread.Sleep(3000);
            objCommonMethods.Action_Page_Down(WDriver);
            // Start Date *
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_datepicker_NeededDate_neededStartDate);
            if (createRequirementModel.str_datepicker_NeededDate_neededStartDate != "")
            {
                results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_datepicker_NeededDate_neededStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_datepicker_NeededDate_neededStartDate, createRequirementModel.str_datepicker_NeededDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            // End Date *          
            if (createRequirementModel.str_datepicker_EndDate_enddate == "3")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_3Months_Radio_3);
            }
            else if (createRequirementModel.strDateAssignmentEnd == "6")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_6Months_Radio_6);
            }
            else
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_9Months_Radio_9);
            }


            //Work Location *
            if (createRequirementModel.str_T1_select_WorkLocation_workLocationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_Worklocation_workLocationID, createRequirementModel.str_T1_select_WorkLocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_Worklocation_workLocationID, createRequirementModel.str_T1_select_WorkLocation_workLocationID);
                }
            }


            Thread.Sleep(1000);
            // Work Location Address *
            if (createRequirementModel.str_T1_TypeHead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_typehead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_TypeHead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_TypeHead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_typehead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_TypeHead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_TypeHead_WorkLocationAddress_workLocationAddress);
                }
            }

            // Computer Systems Access *  

            if (createRequirementModel.str_T1_btn_ComputerSystemsAccess_ComputerSystemsAccess != "")
            {
                if (createRequirementModel.str_T1_btn_ComputerSystemsAccess_ComputerSystemsAccess.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_radio_ComputerSystemsAccess_directIndirectTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_radio_ComputerSystemsAccess_directIndirectFalse);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }


        }


        public static void ClientRequirementTesla(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }
            //Requestor *  ID_CreatedUserID
            if (createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                }
            }



            // Organization Name *
            if (createRequirementModel.str_T1_select_OrganizationName_organizationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_OrganizationName_organizationID, createRequirementModel.str_T1_select_OrganizationName_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {

                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_OrganizationName_organizationID, 1);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.ID_T1_select_OrganizationName_organizationID, KeyWords.ID_T1_select_OrganizationName_organizationID);
                    }
                }
            }




            //Hiring Manager *

            if (createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager != "")
            {
                objCommonMethods.Action_Page_Down(WDriver);
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(2000);
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                    //  return results;
                }
            }

            // Number of Resources * 

            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Reason to Hire *
            if (createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoHire_reasonToHireID, createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_ReasontoHire_reasonToHireID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Anticipated Start Date

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_AnticipatedStartDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_AnticipatedStartDate_neededStartDate != "")
            {
                results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_AnticipatedStartDate_neededStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_AnticipatedStartDate_neededStartDate, createRequirementModel.str_T1_Date_AnticipatedStartDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            else
            {
                results = kwm.Select_Date_In_DatePicker(WDriver, createRequirementModel.str_T1_Date_AnticipatedStartDate_neededStartDate);
            }

            //End Date

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate);

            if (createRequirementModel.str_T1_Date_PlannedEndDate_enddate != "")
            {
              //  results = kwm.Select_End_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_PlannedEndDate_enddate);
                //code added for tesla client     
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_T1_Enddateclick);       
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Now.AddMonths(6));

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, createRequirementModel.strDateAssignmentEnd, false);
                }

            }
            else
            {
                results = kwm.Select_Date_End_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_PlannedEndDate_enddate);

            }


            ////Work Location 

            //if (createRequirementModel.str_T1_Select_Worklocation_workLocationID != "")
            //{
            //    //Thread.Sleep(2000);
            //    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_Worklocation_workLocationID, createRequirementModel.str_T1_Select_Worklocation_workLocationID);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        results = kwm.selectInDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_Worklocation_workLocationID, createRequirementModel.str_T1_Select_Worklocation_workLocationID);
            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            try
            //            {
            //                SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_Select_Worklocation_workLocationID))); //Locating select list
            //                se.SelectByIndex(1);
            //            }
            //            catch
            //            {
            //                //
            //            }
            //        }
            //    }
            //}

            //Work Location *

            if (createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Work Location Address

            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }




        }

        #region Epri
        public static void ClientRequirementEpri(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_selectOrgId))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (kwm.isElementDisplayed(WDriver, KeyWords.ID_selectOrgId))
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }
            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");

            //Division/Sector *
            if (createRequirementModel.strSelectBusinessArea != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_selectOrgId, createRequirementModel.strSelectBusinessArea);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Charging Method *
            if (createRequirementModel.str_RadioBtn_ChargingMethod != "")
            {
                if (createRequirementModel.str_RadioBtn_ChargingMethod.ToLower().Equals(KeyWords.str_String_Compare_direct))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_directIndirectTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    if (createRequirementModel.str_Txt_AccountAssignment != "")
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_ProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_Txt_AccountAssignment, createRequirementModel.str_Txt_AccountAssignment);
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_directIndirectFalse);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    if (createRequirementModel.str_Txt_CostCenterId != "")
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_Txt_CostCenterId, createRequirementModel.str_Txt_CostCenterId);
                    }
                }
            }

            //Cost Center *
            if (createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId != "")
            {
                results = kwm.select_List_typeahead_WA(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_CostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_WA(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_CostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(5000);
                        results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_CostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId);
                        //  return results;
                    }
                }
            }

            //Engaging Manager/PM *
            if (createRequirementModel.str_T1_typehead_EngagingManagerPM_hiringManager != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_typehead_EngagingManagerPM_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_typehead_EngagingManagerPM_hiringManager, createRequirementModel.str_T1_typehead_EngagingManagerPM_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_typehead_EngagingManagerPM_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_typehead_EngagingManagerPM_hiringManager, createRequirementModel.str_T1_typehead_EngagingManagerPM_hiringManager);
                    //  return results;
                }
            }

            Thread.Sleep(2000);
            // Needed Date *
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_datepicker_NeededDate_neededStartDate);
            if (createRequirementModel.str_datepicker_NeededDate_neededStartDate != "")
            {
                results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_datepicker_NeededDate_neededStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_datepicker_NeededDate_neededStartDate, createRequirementModel.str_datepicker_NeededDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            // End Date *          
            if (createRequirementModel.str_datepicker_EndDate_enddate == "3")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_3Months_Radio_3);
            }
            else if (createRequirementModel.strDateAssignmentEnd == "6")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_6Months_Radio_6);
            }
            else
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_9Months_Radio_9);
            }

            //Justification for Opening * 
            if (createRequirementModel.str_T1_select_JustificationforOpening_reasonToHireID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_JustificationforOpening_reasonToHireID, createRequirementModel.str_T1_select_JustificationforOpening_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Quality Assurance *
            if (createRequirementModel.str_T1_Select_QualityAssurance_programId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_QualityAssurance_programId, createRequirementModel.str_T1_Select_QualityAssurance_programId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            // Page down action
            Thread.Sleep(1000);
            objCommonMethods.Action_LookInto_Element_ID(WDriver, KeyWords.ID_T1_Select_PlaceOfWork_siteLocationID);
            Thread.Sleep(100);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");

            //Place of Work *
            if (createRequirementModel.str_T1_Select_PlaceOfWork_siteLocationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_PlaceOfWork_siteLocationID, createRequirementModel.str_T1_Select_PlaceOfWork_siteLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Office/Cubicle Number
            if (createRequirementModel.str_T1_txt_OfficeCubicleNumber_matrixNumber != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_OfficeCubicleNumber_matrixNumber, createRequirementModel.str_T1_txt_OfficeCubicleNumber_matrixNumber, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_OfficeCubicleNumber_matrixNumber, createRequirementModel.str_T1_txt_OfficeCubicleNumber_matrixNumber, false);
                    //  return results;
                }
            }

            //Company code *
            if (createRequirementModel.str_T1_TypeHead_CompanyCode_deptNumber != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_TypeHead_CompanyCode_deptNumber, createRequirementModel.str_T1_TypeHead_CompanyCode_deptNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_TypeHead_CompanyCode_deptNumber, createRequirementModel.str_T1_TypeHead_CompanyCode_deptNumber);
                }
            }

            //Work Location *
            if (createRequirementModel.str_T1_select_WorkLocation_workLocationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_WorkLocation_workLocationID, createRequirementModel.str_T1_select_WorkLocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_WorkLocation_workLocationID, createRequirementModel.str_T1_select_WorkLocation_workLocationID);
                }
            }

            // Incumbent Name/Term Date
            if (createRequirementModel.str_T1_txt_IncumbentNameTermDate_JustificationtoHire != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_IncumbentNameTermDate_JustificationtoHire, createRequirementModel.str_T1_txt_IncumbentNameTermDate_JustificationtoHire, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
            Thread.Sleep(1000);
            // Work Location Address *
            if (createRequirementModel.str_T1_TypeHead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_TypeHead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_TypeHead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_TypeHead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_TypeHead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_TypeHead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_TypeHead_WorkLocationAddress_workLocationAddress);
                }
            }
            Thread.Sleep(1000);

            // EPRI Resources or Access Required? *           
            if (createRequirementModel.str_RadioBtn_Radio1 != "")
            {
                if (createRequirementModel.str_RadioBtn_Radio1.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    kwm.click(WDriver, KeyWords.locator_Name, KeyWords.Name_RadioBtn_radio1);
                }
                else
                {
                    kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_RadioBtn_radio1_2);
                }
            }
            else
            {
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_RadioBtn_radio1_2);
            }
            Thread.Sleep(1000);

            //  Will the CW be sourced outside of the US? *
            if (createRequirementModel.str_RadioBtn_Radio2 != "")
            {
                if (createRequirementModel.str_RadioBtn_Radio2.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    kwm.click(WDriver, KeyWords.locator_Name, KeyWords.Name_RadioBtn_radio2);
                }
                else
                {
                    kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_RadioBtn_radio2_2);
                }
            }
            else
            {
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_RadioBtn_radio2_2);
            }
            Thread.Sleep(1000);
            // Will government funds be used for this procurement? *
            if (createRequirementModel.str_RadioBtn_Radio3 != "")
            {
                if (createRequirementModel.str_RadioBtn_Radio3.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    kwm.click(WDriver, KeyWords.locator_Name, KeyWords.Name_RadioBtn_radio3);
                }
                else
                {
                    kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_RadioBtn_radio3_2);
                }
            }
            else
            {
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_RadioBtn_radio3_2);
            }
            // Will the assignment entail handling of hazardous material? *
            if (createRequirementModel.str_RadioBtn_Radio4 != "")
            {
                if (createRequirementModel.str_RadioBtn_Radio4.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    kwm.click(WDriver, KeyWords.locator_Name, KeyWords.Name_RadioBtn_radio4);
                }
                else
                {
                    kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_RadioBtn_radio4_2);
                }
            }
            else
            {
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_RadioBtn_radio4_2);
            }
        }
        #endregion Epri


        #region EBS
        public static void ClientRequirementEBS(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            //Organization Name 
            if (createRequirementModel.str_T1_select_OrganizationName_organizationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_OrganizationName_organizationID, createRequirementModel.str_T1_select_OrganizationName_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Headcount Approved 
            if (createRequirementModel.str_T1_select_HeadcountApproved_laborClassCode != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_HeadcountApproved_laborClassCode, createRequirementModel.str_T1_select_HeadcountApproved_laborClassCode);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Department *

            if (createRequirementModel.str_T1_Typeahead_Department_deptNumber != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Department_deptNumber, createRequirementModel.str_T1_Typeahead_Department_deptNumber);
                //  Thread.Sleep(2000);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Department_deptNumber, createRequirementModel.str_T1_Typeahead_Department_deptNumber);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, "a");
                        // return results;
                    }
                }
            }

            //Department Name  - Disabled
            
            if (createRequirementModel.str_T1_Txt_DepartmentName_deptName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_DepartmentName_deptName, createRequirementModel.str_T1_Txt_DepartmentName_deptName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Hiring Manager 


            if (createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager != "")
            {
                Thread.Sleep(3000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                    //  return results;
                }
            }

            //Supervisor
            if (createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager != "")
            {
                Thread.Sleep(3000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Supervisor_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager, createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Supervisor_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager, createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager);
                    //  return results;
                }
            }


            //Program 
            if (createRequirementModel.str_T1_select_Program_programId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Program_programId, createRequirementModel.str_T1_select_Program_programId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Charging Method *
            if (createRequirementModel.str_T1_btn_ChargingMethod_directIndirect != "")
            {
                if (createRequirementModel.str_T1_btn_ChargingMethod_directIndirect.ToLower().Equals(KeyWords.str_String_Compare_direct))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_ChargingMethod_directIndirectTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_ChargingMethod_directIndirectFalse);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);


            //Work Week 
            if (createRequirementModel.str_T1_select_WorkWeek_workScheduleID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_WorkWeek_workScheduleID, createRequirementModel.str_T1_select_WorkWeek_workScheduleID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Number of resources *
            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //Priority
            if (createRequirementModel.str_T1_select_Priority_priority != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Priority_priority, createRequirementModel.str_T1_select_Priority_priority);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Seciruty Clearance *
            if (createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID != "")
            {
                if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID))
                {
                    if (createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID.ToLower().Equals(KeyWords.str_String_Compare_noclearance))
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_SecurityClearance_securityClearanceLevelID, createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //return results;
                        }
                    }
                    else
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_SecurityClearance_securityClearanceLevelID, createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //return results;
                        }
                        if (createRequirementModel.str_T1_btn_CanStartwithoutClearance_txtWithout.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_CanStartwithoutClearance_txtWithoutYes);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                // return results;
                            }
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_CanStartwithoutClearance_txtWithoutNo);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                // return results;
                            }
                        }
                        if (createRequirementModel.str_T1_btn_InterimClearanceSufficient_txtSufficient.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_InterimClearanceSufficient_txtSufficientYes);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //  return results;
                            }
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_InterimClearanceSufficient_txtSufficientNo);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                // return results;
                            }
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T1_txt_PrimeContractNumber_txtContractNumber, createRequirementModel.str_T1_txt_PrimeContractNumber_txtContractNumber, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }
                        objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strBrowserName + "_");
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.str_T1_btn_SecurityClearanceDetailsMSGActionButton_Submit);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                        Thread.Sleep(3000);
                        objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strBrowserName + "_");
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.str_T1_btn_SecurityClearanceDetailsMsgwindowActionButton);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                        Thread.Sleep(3000);
                    }
                }
            }

            Thread.Sleep(5000);
            //Needed Date *
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_NeededDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_NeededDate_neededStartDate != "")
            {
                results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_NeededDate_neededStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_NeededDate_neededStartDate, createRequirementModel.str_T1_Date_NeededDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //End Date *
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                results = kwm.Select_End_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_EndDate_enddate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                    //D:\WorkingScripts\SmartTrackNewUI_Automation\bin\Debug\Input\Resumes\SampleResume.txt }
                }
            }
            // Console.WriteLine("Testing on 1");

            //Work Location *
            if (createRequirementModel.str_T1_Select_Worklocation_workLocationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_Worklocation_workLocationID, createRequirementModel.str_T1_Select_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Site Location *
            if (createRequirementModel.str_T1_select_SiteLocation_siteLocationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_SiteLocation_siteLocationID, createRequirementModel.str_T1_select_SiteLocation_siteLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Work Location Address *
            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                }
            }
        }
        #endregion


        public static void ClientRequirementAPS(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            // Organization Name *
            if (createRequirementModel.str_T1_select_OrganizationName_organizationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_OrganizationName_organizationID, createRequirementModel.str_T1_select_OrganizationName_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Engagement Type *
            if (createRequirementModel.str_T1_select_EngagementType_serviceMethodID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_EngagementType_serviceMethodID, createRequirementModel.str_T1_select_EngagementType_serviceMethodID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_EngagementType_serviceMethodID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Business Unit *(Corporate only)

            if (createRequirementModel.str_T1_select_BusinessUnit_ProjectId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_BusinessUnit_ProjectId, createRequirementModel.str_T1_select_BusinessUnit_ProjectId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_BusinessUnit_ProjectId))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Number of resources *

            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Leader
            if (createRequirementModel.str_T1_Typeahead_Leader_hiringManager != "")
            {
                Thread.Sleep(1000);
                results = kwm.select_List_typeahead_LocationAddress_New(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Leader_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Leader_hiringManager, createRequirementModel.str_T1_Typeahead_Leader_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Leader_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Leader_hiringManager, createRequirementModel.str_T1_Typeahead_Leader_hiringManager);
                    //  return results;
                }
            }

            Thread.Sleep(1000);
            //objCommonMethods.Action_Page_Down(WDriver);
            //kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_T1_select_UnitNumber_deptNumber),kwm._WDWait);
            Thread.Sleep(2000);
            // Unit Number *
            if (createRequirementModel.str_T1_select_UnitNumber_deptNumber != "")
            {

                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_UnitNumber_deptNumber, createRequirementModel.str_T1_select_UnitNumber_deptNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_UnitNumber_deptNumber))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            // Requestor * --  Disabled field

            objCommonMethods.Action_Page_Down(WDriver);
            //Po Number
            if (createRequirementModel.str_T1_Typeahead_PONumber_poNumber != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_PONumber_poNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_PONumber_poNumber, createRequirementModel.str_T1_Typeahead_PONumber_poNumber);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_PONumber_poNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_PONumber_poNumber, createRequirementModel.str_T1_Typeahead_PONumber_poNumber);
                    //  return results;
                }
            }
            // objCommonMethods.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate);

            //Start date

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_StartDate_neededStartDate != "")
            {
                results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_StartDate_neededStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate, createRequirementModel.str_T1_Date_StartDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }



            //End Date
            Thread.Sleep(3000);
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                results = kwm.Select_End_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_EndDate_enddate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                    //}
                }
                //objCommonMethods.Action_Page_Down(WDriver);
                objCommonMethods.Action_Button_Tab(WDriver);
                //FFD Supervisor (PV Only) * - Disabled
                if (kwm.isElementEnabled(WDriver, KeyWords.ID_T1_Typeahead_FFDSupervisor_altHiringManager))
                {
                    if (createRequirementModel.str_T1_Typeahead_FFDSupervisor_altHiringManager != "")
                    {
                        Thread.Sleep(3000);
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_FFDSupervisor_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_FFDSupervisor_altHiringManager, createRequirementModel.str_T1_Typeahead_FFDSupervisor_altHiringManager);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_FFDSupervisor_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_FFDSupervisor_altHiringManager, createRequirementModel.str_T1_Typeahead_FFDSupervisor_altHiringManager);
                            //  return results;
                        }
                    }
                }
                //Contractor Cost *
                if (kwm.isElementEnabled(WDriver, KeyWords.ID_T1_select_ContractorCost_CostCenterId))
                {
                    if (createRequirementModel.str_T1_select_ContractorCost_CostCenterId != "")
                    {
                        Thread.Sleep(3000);
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ContractorCost_CostCenterId, createRequirementModel.str_T1_select_ContractorCost_CostCenterId);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ContractorCost_CostCenterId, createRequirementModel.str_T1_select_ContractorCost_CostCenterId);
                            //  return results;
                        }
                    }
                }


                //objCommonMethods.Action_Page_Down(WDriver);
                //Work Location *

                if (createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID != "")
                {
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }

                //Contractor Category *

                if (createRequirementModel.str_T1_select_ContractorCatergory_GLId != "")
                {
                    //Thread.Sleep(2000);
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ContractorCatergory_GLId, createRequirementModel.str_T1_select_ContractorCatergory_GLId);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.selectInDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ContractorCatergory_GLId, createRequirementModel.str_T1_select_ContractorCatergory_GLId);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            try
                            {
                                SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_ContractorCatergory_GLId))); //Locating select list
                                se.SelectByIndex(1);
                            }
                            catch
                            {
                                //
                            }
                        }
                    }
                }


                //Work Location Address *
                if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
                {
                    //results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_selectworkLocationAddress, createRequirementModel.strSelectWorkLocationAddress,false);
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }

                //Mail Station *

                if (createRequirementModel.str_T1_Typeahead_MailStation_matrixNumber != "")
                {
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_MailStation_matrixNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_MailStation_matrixNumber, createRequirementModel.str_T1_Typeahead_MailStation_matrixNumber);
                    // results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_matrixNumber, createRequirementModel.str_Txt_MailStation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_MailStation_matrixNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_MailStation_matrixNumber, createRequirementModel.str_T1_Typeahead_MailStation_matrixNumber);
                        //results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_matrixNumber, createRequirementModel.str_Txt_MailStation, false);
                        //  return results;
                    }
                }

                //ACAD (PV Only) *- disabled

                if (createRequirementModel.str_T1_btn_ACAD_directIndirect != "")
                {
                    if (createRequirementModel.str_T1_btn_ACAD_directIndirect.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_ACAD_directIndirectTrue);
                        if (results.Result1 == KeyWords.Result_PASS)
                        {
                            //ACAD Level *
                            if (createRequirementModel.str_T1_select_ACADlevel_programId != "")
                            {
                                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ACADLevel_programId, createRequirementModel.str_T1_select_ACADlevel_programId);
                                if (results.Result1 == KeyWords.Result_FAIL)
                                {
                                    //return results;
                                }
                            }
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_ACAD_directIndirectFalse);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                }

                //ACAD Level -Disabled

                if (kwm.isElementEnabled(WDriver, KeyWords.ID_T1_select_ACADlevel_programId))
                {
                    if (createRequirementModel.str_T1_select_ACADlevel_programId != "")
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ACADlevel_programId, createRequirementModel.str_T1_select_ACADlevel_programId);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ACADlevel_programId, createRequirementModel.str_T1_select_ACADlevel_programId);
                            //  return results;
                        }
                    }
                }


                // Actions actions1 = new Actions(WDriver);
                //Thread.Sleep(3000);
                //objCommonMethods.Action_Page_Down(WDriver);
                //Thread.Sleep(3000);


                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_BadgeAcess_laborClassCode61);

                //Badge Access *
                if (createRequirementModel.str_T1_btn_BadgeAcess_laborClassCode != "")
                {
                    if (createRequirementModel.str_T1_btn_BadgeAcess_laborClassCode.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_BadgeAcess_laborClassCode61);

                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_BadgeAcess_laborClassCode62);

                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                }

                //Computer Access *

                if (createRequirementModel.str_T1_btn_ComputerAccess_computerAccess != "")
                {
                    if (createRequirementModel.str_T1_btn_ComputerAccess_computerAccess.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_ComputerAccess_computerAccessTrue);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_ComputerAccess_computerAccessFalse);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                }

                //Thread.Sleep(3000);
                //objCommonMethods.Action_Page_Down(WDriver);
                //Thread.Sleep(3000);

                //Reason to Engage *
                if (createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID != "")
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoHire_reasonToHireID, createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        try
                        {
                            SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_ReasontoHire_reasonToHireID))); //Locating select list
                            se.SelectByIndex(1);
                        }
                        catch
                        {
                            //
                        }
                    }
                }

                //CIP Acess *

                if (createRequirementModel.str_T1_select_CIPAcess_ciplocation != "")
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_CIPAcess_ciplocation, createRequirementModel.str_T1_select_CIPAcess_ciplocation);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        try
                        {
                            SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_CIPAcess_ciplocation))); //Locating select list
                            se.SelectByIndex(1);
                        }
                        catch
                        {
                            //
                        }
                    }
                }


                //Request Justification *

                if (createRequirementModel.str_T1_txt_RequestJustification_JustificationtoHire != "")
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_RequestJustification_JustificationtoHire, createRequirementModel.str_T1_txt_RequestJustification_JustificationtoHire, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }

            }
        }

        public static void ClientRequirementHillRom(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods, CreateRequirementModelLabel createRequirementModelLabel)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_select_Organization_organizationID))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_select_Organization_organizationID)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            // Organization  *
            if (createRequirementModel.str_T1_select_Organization_organizationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Organization_organizationID, createRequirementModel.str_T1_select_Organization_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_Organization_organizationID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
                results = kwm.lableComparision(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Organization_organizationID, createRequirementModelLabel.str_T1_select_Organization_organizationID);
            }
           

            //requestor - Diasbled

            //Hiring Manager *
            if (createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager != "")
            {
               
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModelLabel.str_T1_Typeahead_HiringManager_hiringManager);
                //   results = kwm.lableComparision(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, createRequirementModelLabel.str_T1_Typeahead_HiringManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                    //  return results;
                }
               // results = kwm.lableComparision(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, createRequirementModelLabel.str_T1_Typeahead_HiringManager_hiringManager);
            }


            //Financial Partner

            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_Typeahead_FinancialPartner_altHiringManager))
            {
                Thread.Sleep(3000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_FinancialPartner_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_FinancialPartner_altHiringManager, createRequirementModel.str_T1_Typeahead_FinancialPartner_altHiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_FinancialPartner_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_FinancialPartner_altHiringManager, createRequirementModel.str_T1_Typeahead_FinancialPartner_altHiringManager);
                    //  return results;
                }
            }

            //Based on hiring manager selection Business unit and company code auto populated
            //Business Unit 
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_Typeahead_BusinessUnit_CostCenterId))
            {
                Thread.Sleep(3000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_BusinessUnit_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_BusinessUnit_CostCenterId, createRequirementModel.str_T1_Typeahead_BusinessUnit_CostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_BusinessUnit_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_BusinessUnit_CostCenterId, createRequirementModel.str_T1_Typeahead_BusinessUnit_CostCenterId);
                    //  return results;
                }
            }

            //Company Code 
            if (createRequirementModel.str_T1_select_CompanyCode_deptNumber != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_CompanyCode_deptNumber, createRequirementModel.str_T1_select_CompanyCode_deptNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_CompanyCode_deptNumber))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
                results = kwm.lableComparision(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_CompanyCode_deptNumber, createRequirementModel.str_T1_select_CompanyCode_deptNumber);
            }

            //Object Account *
            if (createRequirementModel.str_T1_select_ObjectAccount_GLId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ObjectAccount_GLId, createRequirementModel.str_T1_select_ObjectAccount_GLId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_ObjectAccount_GLId))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
                results = kwm.lableComparision(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ObjectAccount_GLId, createRequirementModelLabel.str_T1_select_ObjectAccount_GLId);
            }


            //Projectcode/cfr

            if (createRequirementModel.str_T1_text_ProjectCodeCFR_ProjectId != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_text_ProjectCodeCFR_ProjectId, createRequirementModel.str_T1_text_ProjectCodeCFR_ProjectId, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_text_ProjectCodeCFR_ProjectId, createRequirementModel.str_T1_text_ProjectCodeCFR_ProjectId, false);
                    //return results;
                }

            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Reason for Engagement *


            if (createRequirementModel.str_T1_select_ReasonForEngagement_reasonToHireID != "")
            {
                results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasonForEngagement_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_ReasonForEngagement_reasonToHireID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Number of Positions 

            if (createRequirementModel.str_T1_Txt_NumberofPositions_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofPositions_noofresources, createRequirementModel.str_T1_Txt_NumberofPositions_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
                results = kwm.lableComparision(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofPositions_noofresources, createRequirementModelLabel.str_T1_Txt_NumberofPositions_noofresources);
            }

            //Work Week
            Thread.Sleep(1000);
            //Work Week *
            if (createRequirementModel.str_T1_select_WorkWeek_workScheduleID != "")
            {
                results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_WorkWeek_workScheduleID);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_WorkWeek_workScheduleID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Work Location 
            if (createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }


            // Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_StartDate_neededStartDate != "")
            {
                results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_StartDate_neededStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate, createRequirementModel.str_T1_Date_StartDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
                results = kwm.lableComparision(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate, createRequirementModelLabel.str_T1_Date_StartDate_neededStartDate);
            }

            //End Date

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_StartDate_neededStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //Request Justification

            if (createRequirementModel.str_T1_txt_RequestJustification_JustificationtoHire != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_RequestJustification_JustificationtoHire, createRequirementModel.str_T1_txt_RequestJustification_JustificationtoHire, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);



        }

        public static void ClientRequirementSOF(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            // Organization Name

            if (createRequirementModel.str_T1_select_OrganizationName_organizationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_OrganizationName_organizationID, createRequirementModel.str_T1_select_OrganizationName_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Department

            if (createRequirementModel.str_T1_Typeahead_Department_deptNumber != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Department_deptNumber, createRequirementModel.str_T1_Typeahead_Department_deptNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Department_deptNumber, createRequirementModel.str_T1_Typeahead_Department_deptNumber);
                    //  return results;
                }
            }

            //Department Description - Disabled

            // Funding Source

            if (createRequirementModel.str_T1_txt_FundingSource_matrixNumber != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_FundingSource_matrixNumber, createRequirementModel.str_T1_txt_FundingSource_matrixNumber, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_FundingSource_matrixNumber, createRequirementModel.str_T1_txt_FundingSource_matrixNumber, false);
                    //  return results;
                }
            }

            //SCA Position

            if (createRequirementModel.str_T1_select_SCAPosition_laborClassCode != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_SCAPosition_laborClassCode, createRequirementModel.str_T1_select_SCAPosition_laborClassCode);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Hiring Manager
            if (createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                    //  return results;
                }
            }

            // Supervisior
            if (createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager != "")
            {
                Thread.Sleep(3000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Supervisor_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager, createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Supervisor_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager, createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager);
                    //  return results;
                }
            }

            // Program
            if (createRequirementModel.str_T1_select_Program_programId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Program_programId, createRequirementModel.str_T1_select_Program_programId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            // Charging Method
            if (createRequirementModel.str_T1_btn_ChargingMethod_directIndirect != "")
            {
                if (createRequirementModel.str_T1_btn_ChargingMethod_directIndirect.ToLower().Equals(KeyWords.str_String_Compare_direct))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_ChargingMethod_directIndirectTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_ChargingMethod_directIndirectFalse);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Work Week
            if (createRequirementModel.str_T1_select_WorkWeek_workScheduleID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_WorkWeek_workScheduleID, createRequirementModel.str_T1_select_WorkWeek_workScheduleID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            //Number of Resources
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_Txt_NumberofResources_noofresources))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Priority
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_select_Priority_priority))
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Priority_priority, createRequirementModel.str_T1_select_Priority_priority);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Security Clearance
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID))
            {
                if (createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID.ToLower().Equals(KeyWords.str_String_Compare_noclearance))
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_SecurityClearance_securityClearanceLevelID, createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
                else
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_SecurityClearance_securityClearanceLevelID, createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                    if (createRequirementModel.str_T1_btn_CanStartwithoutClearance_txtWithout.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_CanStartwithoutClearance_txtWithoutYes);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_CanStartwithoutClearance_txtWithoutNo);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }
                    }
                    if (createRequirementModel.str_T1_btn_InterimClearanceSufficient_txtSufficient.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_InterimClearanceSufficient_txtSufficientYes);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_InterimClearanceSufficient_txtSufficientNo);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T1_txt_PrimeContractNumber_txtContractNumber, createRequirementModel.str_T1_txt_PrimeContractNumber_txtContractNumber, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strBrowserName + "_");
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.str_T1_btn_SecurityClearanceDetailsMSGActionButton_Submit);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    Thread.Sleep(3000);
                    objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strBrowserName + "_");
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.str_T1_btn_SecurityClearanceDetailsMsgwindowActionButton);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    Thread.Sleep(3000);
                }
            }

            //Needed Date *
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_NeededDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_NeededDate_neededStartDate != "")
            {
                results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_NeededDate_neededStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_NeededDate_neededStartDate, createRequirementModel.str_T1_Date_NeededDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //End Date *
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                results = kwm.Select_End_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_EndDate_enddate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                    //D:\WorkingScripts\SmartTrackNewUI_Automation\bin\Debug\Input\Resumes\SampleResume.txt }
                }
            }
            // Work Location
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_Select_Worklocation_workLocationID))
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_Worklocation_workLocationID, createRequirementModel.str_T1_Select_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Site Location 
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_select_SiteLocation_siteLocationID))
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_SiteLocation_siteLocationID, createRequirementModel.str_T1_select_SiteLocation_siteLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Work Location Address
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress))
            {
                results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
        }
        
        public static void ClientRequirementSTS(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID))));
            }
            catch
            {
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "Select Orginazation taking more then 300 sec", 3);
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }
            //Organisation Name 
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_select_OrganizationName_organizationID))
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_OrganizationName_organizationID, createRequirementModel.str_T1_select_OrganizationName_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Department
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_Typeahead_Department_deptNumber))
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Department_deptNumber, createRequirementModel.str_T1_Typeahead_Department_deptNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Department_deptNumber, createRequirementModel.str_T1_Typeahead_Department_deptNumber);
                    //  return results;
                }
            }

            //Department Name - Disabled

            //Funding Resource
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_txt_FundingSource_matrixNumber))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_FundingSource_matrixNumber, createRequirementModel.str_T1_txt_FundingSource_matrixNumber, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Headcount Approved
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_select_HeadcountApproved_laborClassCode))
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_HeadcountApproved_laborClassCode, createRequirementModel.str_T1_select_HeadcountApproved_laborClassCode);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Hiring Manager
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager))
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                    //  return results;
                }
            }

            //Alternate Hiring Manager
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_Typeahead_AlternateHiringManager_altHiringManager))
            {
                Thread.Sleep(3000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_AlternateHiringManager_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_AlternateHiringManager_altHiringManager, createRequirementModel.str_T1_Typeahead_AlternateHiringManager_altHiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_AlternateHiringManager_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_AlternateHiringManager_altHiringManager, createRequirementModel.str_T1_Typeahead_AlternateHiringManager_altHiringManager);
                    //  return results;
                }
            }

            //Program
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_select_Program_programId))
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Program_programId, createRequirementModel.str_T1_select_Program_programId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            objCommonMethods.Action_Button_Tab(WDriver);
            objCommonMethods.Action_Page_Down(WDriver);
            //Charging method 
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_btn_ChargingMethod_directIndirect))
            {
                if (createRequirementModel.str_T1_btn_ChargingMethod_directIndirect.ToLower().Equals(KeyWords.str_String_Compare_direct))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_ChargingMethod_directIndirectTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_ChargingMethod_directIndirectFalse);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }

            //Work Week
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_select_WorkWeek_workScheduleID))
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_WorkWeek_workScheduleID, createRequirementModel.str_T1_select_WorkWeek_workScheduleID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Number of Resources
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_Txt_NumberofResources_noofresources))
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Priority
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_select_Priority_priority))
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Priority_priority, createRequirementModel.str_T1_select_Priority_priority);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Security Clearance

            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID))
            {
                if (createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID.ToLower().Equals(KeyWords.str_String_Compare_noclearance))
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_SecurityClearance_securityClearanceLevelID, createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
                else
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_SecurityClearance_securityClearanceLevelID, createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                    if (createRequirementModel.str_T1_btn_CanStartwithoutClearance_txtWithout.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_CanStartwithoutClearance_txtWithoutYes);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_CanStartwithoutClearance_txtWithoutNo);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }
                    }
                    if (createRequirementModel.str_T1_btn_InterimClearanceSufficient_txtSufficient.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_InterimClearanceSufficient_txtSufficientYes);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_InterimClearanceSufficient_txtSufficientNo);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T1_txt_PrimeContractNumber_txtContractNumber, createRequirementModel.str_T1_txt_PrimeContractNumber_txtContractNumber, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strBrowserName + "_");
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.str_T1_btn_SecurityClearanceDetailsMSGActionButton_Submit);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    Thread.Sleep(3000);
                    objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strBrowserName + "_");
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.str_T1_btn_SecurityClearanceDetailsMsgwindowActionButton);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    Thread.Sleep(3000);
                }
            }

            //  Thread.Sleep(5000);
            //Needed  Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_NeededDate_neededStartDate);

            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_Date_NeededDate_neededStartDate))
            {
                results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_NeededDate_neededStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_NeededDate_neededStartDate, createRequirementModel.str_T1_Date_NeededDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_Date_EndDate_enddate))
            {
                results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_NeededDate_neededStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            // Console.WriteLine("Testing on 1");
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_Select_Worklocation_workLocationID))
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_Worklocation_workLocationID, createRequirementModel.str_T1_Select_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Site Location 
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_select_SiteLocation_siteLocationID))
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_SiteLocation_siteLocationID, createRequirementModel.str_T1_select_SiteLocation_siteLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Work Location Address
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress))
            {
                results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
        }

        public static void ClientRequirementStewartTitle(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_select_Organization_organizationID))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_selectOrgId)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }
            // Organization *
            if (createRequirementModel.str_T1_select_Organization_organizationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Organization_organizationID, createRequirementModel.str_T1_select_Organization_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_Organization_organizationID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Engagement Type *
            if (createRequirementModel.str_T1_select_EngagementType_serviceMethodID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_EngagementType_serviceMethodID, createRequirementModel.str_T1_select_EngagementType_serviceMethodID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_EngagementType_serviceMethodID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Requestor  *
            if (createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                    //  return results;
                }
            }

            //Engaging Manager *
            if (createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_EngagingManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_EngagingManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager);
                    //  return results;
                }
            }

            // Account Unit *
            if (createRequirementModel.str_T1_Select_AccountUnit_deptNumber != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_AccountUnit_deptNumber, createRequirementModel.str_T1_Select_AccountUnit_deptNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_Select_AccountUnit_deptNumber))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            objCommonMethods.Action_Button_Tab(WDriver);
            Thread.Sleep(3000);
            //Company *
            if (createRequirementModel.str_T1_Select_Company_siteLocationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_Company_siteLocationID, createRequirementModel.str_T1_Select_Company_siteLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_Select_Company_siteLocationID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Project# * - Disabled

            //Activity# * - Disabled

            //Needed Date *
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_NeededDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_NeededDate_neededStartDate != "")
            {

                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today.AddMonths(3));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_NeededDate_neededStartDate, createRequirementModel.str_T1_Date_NeededDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //End Date *
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                results = kwm.Select_End_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_EndDate_enddate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }

                }
            }

            objCommonMethods.Action_Page_Down(WDriver);

            //Work Location *
            if (createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                    //  return results;
                }
            }



            //Work Location Address *
            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                }
            }
            //Reason to Enagagement *
            if (createRequirementModel.str_T1_select_ReasonForEngagement_reasonToHireID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasonForEngagement_reasonToHireID, createRequirementModel.str_T1_select_ReasonForEngagement_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_ReasonForEngagement_reasonToHireID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }
            //Number of Resources *
            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            //Justification

            if (createRequirementModel.str_T1_txt_Justification_JustificationtoHire != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_Justification_JustificationtoHire, createRequirementModel.str_T1_txt_Justification_JustificationtoHire, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
        }

        #region ThermoFisher
        public static void ClientRequirementThermoFisher(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_Typeahead_HiringManager_hiringManager))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_Typeahead_HiringManager_hiringManager)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }
            //Requestor *  ID_CreatedUserID  Disbale
            if (createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                }
            }


            //Hiring Manager *

            if (createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager != "")
            {

                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(2000);
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                    //  return results;
                }
            }


            Thread.Sleep(2000);
            //Supervisor Org

            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_Select_SupervisorOrg_ProfitCenterId))
            {
                Thread.Sleep(2000);
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_SupervisorOrg_ProfitCenterId, createRequirementModel.str_T1_Select_SupervisorOrg_ProfitCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_SupervisorOrg_ProfitCenterId, 2);
                    // return results;
                }
            }

            //if (createRequirementModel.str_T1_Select_SupervisorOrg_ProfitCenterId != "")
            //{
            //    results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_SupervisorOrg_ProfitCenterId);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {

            //        results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_SupervisorOrg_ProfitCenterId, 2);

            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_SupervisorOrg_ProfitCenterId);
            //        }


            //    }
            //}
            objCommonMethods.Action_Button_Tab(WDriver);
            //Cost Center *
            if (createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId != "")
            {

                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_CostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(2000);
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_CostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId);
                    //  return results;
                }
            }



            //Finance Entity * organizationID
            if (createRequirementModel.str_T1_Typeahead_FinanceEntity_organizationID != "")
            {
                Thread.Sleep(2000);

                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_FinanceEntity_organizationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_FinanceEntity_organizationID, createRequirementModel.str_T1_Typeahead_FinanceEntity_organizationID);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_FinanceEntity_organizationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_FinanceEntity_organizationID, createRequirementModel.str_T1_Typeahead_FinanceEntity_organizationID);

                }
            }


            //Business Structure *   deptNumber
            if (createRequirementModel.str_T1_Typeahead_BusinessStructure_deptNumber != "")
            {

                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_BusinessStructure_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_BusinessStructure_deptNumber, createRequirementModel.str_T1_Typeahead_BusinessStructure_deptNumber);


                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_BusinessStructure_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_BusinessStructure_deptNumber, createRequirementModel.str_T1_Typeahead_BusinessStructure_deptNumber);

                }
            }


            //Target Start Date *

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_TargetStartDate_neededStartDate);

            if (createRequirementModel.strDateAssignmentStart != "")
            {
                results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_TargetStartDate_neededStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_TargetStartDate_neededStartDate, createRequirementModel.str_T1_Date_TargetStartDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            else
            {
                results = kwm.Select_Date_In_DatePicker(WDriver, createRequirementModel.str_T1_Date_TargetStartDate_neededStartDate);
            }

            //Target End Date *

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_TargetEnddate_enddate);

            if (createRequirementModel.strDateAssignmentEnd != "")
            {
                results = kwm.Select_End_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_TargetEnddate_enddate);


                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_TargetEnddate_enddate, createRequirementModel.str_T1_Date_TargetEnddate_enddate, false);
                }

            }
            else
            {
                results = kwm.Select_Date_End_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_TargetEnddate_enddate);

            }

            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_Justification_JustificationtoHire);
            //Primary Location *    workLocationID

            if (createRequirementModel.str_T1_Typeahead_PrimaryLocation_workLocationID != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_PrimaryLocation_workLocationID, createRequirementModel.str_T1_Typeahead_PrimaryLocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_PrimaryLocation_workLocationID, createRequirementModel.str_T1_Typeahead_PrimaryLocation_workLocationID);
                }
            }





            //Primary Location Address *    workLocationAddress
            if (createRequirementModel.str_T1_Typeahead_PrimaryLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_PrimaryLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_PrimaryLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_PrimaryLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_PrimaryLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_PrimaryLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_PrimaryLocationAddress_workLocationAddress);
                }
            }


            //product Line 
            if (createRequirementModel.str_T1_Typeahead_ProductLine_siteLocationID != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_ProductLine_siteLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_ProductLine_siteLocationID, createRequirementModel.str_T1_Typeahead_ProductLine_siteLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_ProductLine_siteLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_ProductLine_siteLocationID, createRequirementModel.str_T1_Typeahead_ProductLine_siteLocationID);
                }
            }


            // Number of Resources * 

            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Reason to Engage *

            if (createRequirementModel.str_T1_select_ReasonforthisRequest_reasonToHireID != "")
            {
                results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasonforthisRequest_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {

                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasonforthisRequest_reasonToHireID, 2);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasonforthisRequest_reasonToHireID);
                    }


                }
            }

            //Direct Fill *  
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_Select_DirectFill_laborClassCode))
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_DirectFill_laborClassCode, createRequirementModel.str_T1_Select_DirectFill_laborClassCode);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //Worker Sub - Type *    serviceMethodID
            if (createRequirementModel.str_T1_Select_WorkerSubType_serviceMethodID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_WorkerSubType_serviceMethodID, createRequirementModel.str_T1_Select_WorkerSubType_serviceMethodID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {

                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_WorkerSubType_serviceMethodID, 2);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_WorkerSubType_serviceMethodID);
                    }

                }
            }

            //Justification      JustificationtoHire

            if (createRequirementModel.str_T1_Txt_Justification_JustificationtoHire != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_Justification_JustificationtoHire, createRequirementModel.str_T1_Txt_Justification_JustificationtoHire, false);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //
                }
            }

            //Time Type *   workScheduleID

            if (createRequirementModel.str_T1_Select_TimeType_workScheduleID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_TimeType_workScheduleID, createRequirementModel.str_T1_Select_TimeType_workScheduleID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {

                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_TimeType_workScheduleID, 2);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_TimeType_workScheduleID);
                    }


                }
            }

        }
        #endregion ThermoFisher

        public static void ClientRequirementRMS(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            //Organization Name *
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_select_OrganizationName_organizationID))
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_OrganizationName_organizationID, createRequirementModel.str_T1_select_OrganizationName_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //Headcount Approved
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_select_HeadcountApproved_laborClassCode))
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_HeadcountApproved_laborClassCode, createRequirementModel.str_T1_select_HeadcountApproved_laborClassCode);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Department *

            if (createRequirementModel.str_T1_Typeahead_Department_deptNumber != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Department_deptNumber, createRequirementModel.str_T1_Typeahead_Department_deptNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Department_deptNumber, createRequirementModel.str_T1_Typeahead_Department_deptNumber);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, "a");
                        // return results;
                    }
                }
            }

            //Department Name - Disabled 


            //Hiring Manager *
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager))
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                    //  return results;
                }
            }

            //Supervisor *
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager))
            {
                Thread.Sleep(3000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Supervisor_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager, createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Supervisor_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager, createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager);
                    //  return results;
                }
            }

            //program *
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_select_Program_programId))
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Program_programId, createRequirementModel.str_T1_select_Program_programId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            //Charging Method *
            if (createRequirementModel.str_T1_btn_ChargingMethod_directIndirect != "")
            {
                if (createRequirementModel.str_T1_btn_ChargingMethod_directIndirect.ToLower().Equals(KeyWords.str_String_Compare_direct))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_ChargingMethod_directIndirectTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_ChargingMethod_directIndirectFalse);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);
            Thread.Sleep(2000);
            //Work Week *
            if (createRequirementModel.str_T1_select_WorkWeek_workScheduleID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_WorkWeek_workScheduleID, createRequirementModel.str_T1_select_WorkWeek_workScheduleID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Number of resources *
            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //Priority
            if (createRequirementModel.str_T1_select_Priority_priority != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Priority_priority, createRequirementModel.str_T1_select_Priority_priority);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Seciruty Clearance *
            if (createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID != "")
            {
                if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID))
                {
                    if (createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID.ToLower().Equals(KeyWords.str_String_Compare_noclearance))
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_SecurityClearance_securityClearanceLevelID, createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //return results;
                        }
                    }
                    else
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_SecurityClearance_securityClearanceLevelID, createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //return results;
                        }
                        if (createRequirementModel.str_T1_btn_CanStartwithoutClearance_txtWithout.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_CanStartwithoutClearance_txtWithoutYes);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                // return results;
                            }
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_CanStartwithoutClearance_txtWithoutNo);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                // return results;
                            }
                        }
                        if (createRequirementModel.str_T1_btn_InterimClearanceSufficient_txtSufficient.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_InterimClearanceSufficient_txtSufficientYes);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //  return results;
                            }
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_InterimClearanceSufficient_txtSufficientNo);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                // return results;
                            }
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T1_txt_PrimeContractNumber_txtContractNumber, createRequirementModel.str_T1_txt_PrimeContractNumber_txtContractNumber, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }
                        objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strBrowserName + "_");
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.str_T1_btn_SecurityClearanceDetailsMSGActionButton_Submit);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                        Thread.Sleep(3000);
                        objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strBrowserName + "_");
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.str_T1_btn_SecurityClearanceDetailsMsgwindowActionButton);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                        Thread.Sleep(3000);
                    }
                }
            }

            Thread.Sleep(5000);
            //Needed Date *
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_NeededDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_NeededDate_neededStartDate != "")
            {
                results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_NeededDate_neededStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_NeededDate_neededStartDate, createRequirementModel.str_T1_Date_NeededDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //End Date *
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                results = kwm.Select_End_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_EndDate_enddate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }

                }
            }
            // Console.WriteLine("Testing on 1");

            //Work Location *
            if (createRequirementModel.str_T1_Select_Worklocation_workLocationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_Worklocation_workLocationID, createRequirementModel.str_T1_Select_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Site Location 
            if (createRequirementModel.str_T1_select_SiteLocation_siteLocationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_SiteLocation_siteLocationID, createRequirementModel.str_T1_select_SiteLocation_siteLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Work Location Address *
            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, false);
                }
            }
        }


        public static void ClientRequirementQuickenLoans(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_Typeahead_Requestor_altHiringManager))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_Typeahead_Requestor_altHiringManager)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            //Requestor 
            if (createRequirementModel.str_T1_Typeahead_Requestor_altHiringManager != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_altHiringManager, createRequirementModel.str_T1_Typeahead_Requestor_altHiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_altHiringManager, createRequirementModel.str_T1_Typeahead_Requestor_altHiringManager);
                    //  return results;
                }
            }


            // Hiring Leader
            if (createRequirementModel.str_T1_Typeahead_HiringLeader_hiringManager != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringLeader_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringLeader_hiringManager, createRequirementModel.str_T1_Typeahead_HiringLeader_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringLeader_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringLeader_hiringManager, createRequirementModel.str_T1_Typeahead_HiringLeader_hiringManager);
                    //  return results;
                }
            }

            //Company
            if (createRequirementModel.str_T1_Select_Company_organizationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_Company_organizationID, createRequirementModel.str_T1_Select_Company_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_Select_Company_organizationID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }



            //Business Area 
            if (createRequirementModel.str_T1_Typeahead_BusinessArea_CostCenterId != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_BusinessArea_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_BusinessArea_CostCenterId, createRequirementModel.str_T1_Typeahead_BusinessArea_CostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_BusinessArea_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_BusinessArea_CostCenterId, createRequirementModel.str_T1_Typeahead_BusinessArea_CostCenterId);
                    //  return results;
                }
            }



            //Team
            if (createRequirementModel.str_T1_Typeahead_Team_deptNumber != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Team_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Team_deptNumber, createRequirementModel.str_T1_Typeahead_Team_deptNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Team_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Team_deptNumber, createRequirementModel.str_T1_Typeahead_Team_deptNumber);
                    //  return results;
                }
            }

            //Engagement Type
            if (createRequirementModel.str_T1_Select_EngagementType_serviceMethodID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_EngagementType_serviceMethodID, createRequirementModel.str_T1_Select_EngagementType_serviceMethodID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_Select_EngagementType_serviceMethodID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }


            //Expense Amount
            if (createRequirementModel.str_T1_Select_ExpenseAmount_GLId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_ExpenseAmount_GLId, createRequirementModel.str_T1_Select_ExpenseAmount_GLId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_Select_ExpenseAmount_GLId))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }






            //Number of Resources *
            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_Justification_JustificationtoHire);


            // Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_StartDate_neededStartDate != "")
            {
                results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_StartDate_neededStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate, createRequirementModel.str_T1_Date_StartDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            // Enddate
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                results = kwm.Select_End_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_EndDate_enddate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            Thread.Sleep(2000);


            //Work Location 
            if (createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                    //  return results;
                }
            }


            // Work Location Address 
            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead_LocationAddress_New(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Reason for Request 
            if (createRequirementModel.str_T1_Select_ReasonforRequest_reasonToHireID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_ReasonforRequest_reasonToHireID, createRequirementModel.str_T1_Select_ReasonforRequest_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_Select_ReasonforRequest_reasonToHireID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }



            //Justification 
            if (createRequirementModel.str_T1_txt_Justification_JustificationtoHire != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_Justification_JustificationtoHire, createRequirementModel.str_T1_txt_Justification_JustificationtoHire, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Network
            //Is Developer

            if (createRequirementModel.str_T1_btn_IsDeveloper != "")
            {
                if (createRequirementModel.str_T1_btn_IsDeveloper.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_T1_btn_IsDeveloper_yes);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_T1_btn_IsDeveloper_No);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_T1_btn_IsDeveloper_No);
            }


            //Need PC or Mac

            if (createRequirementModel.str_T1_btn_NeedPCorMac != "")
            {
                if (createRequirementModel.str_T1_btn_IsDeveloper.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_T1_btn_NeedPCorMac_PC);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_T1_btn_NeedPCorMac_Mac);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_T1_btn_NeedPCorMac_Mac);
            }


            //Needs Laptop or Desktop 

            if (createRequirementModel.str_T1_btn_NeedsLaptoporDesktop != "")
            {
                if (createRequirementModel.str_T1_btn_IsDeveloper.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_T1_btn_NeedsLaptoporDesktop_Laptop);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_T1_btn_NeedsLaptoporDesktop_Desktop);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_T1_btn_NeedsLaptoporDesktop_Desktop);
            }


        }

        #region MFC
        public static void ClientRequirementMFC(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            //Organization Name *
            if (createRequirementModel.str_T1_select_OrganizationName_organizationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_OrganizationName_organizationID, createRequirementModel.str_T1_select_OrganizationName_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Department *
            if (createRequirementModel.str_T1_Typeahead_Department_deptNumber != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Department_deptNumber, createRequirementModel.str_T1_Typeahead_Department_deptNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Department_deptNumber, createRequirementModel.str_T1_Typeahead_Department_deptNumber);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, "a");
                        // return results;
                    }
                }
            }

            //Department Description *- Disabled

            //Funding Source 
            if (createRequirementModel.str_T1_txt_FundingSource_matrixNumber != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_FundingSource_matrixNumber, createRequirementModel.str_T1_txt_FundingSource_matrixNumber, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_FundingSource_matrixNumber, createRequirementModel.str_T1_txt_FundingSource_matrixNumber, false);
                    //  return results;
                }
            }

            //Headcount Approved 
            if (createRequirementModel.str_T1_select_HeadcountApproved_laborClassCode != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_HeadcountApproved_laborClassCode, createRequirementModel.str_T1_select_HeadcountApproved_laborClassCode);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //Hiring Manager *
            if (createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                    //  return results;
                }
            }

            //Supervisor *
            if (createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager != "")
            {
                Thread.Sleep(3000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Supervisor_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager, createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Supervisor_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager, createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager);
                    //  return results;
                }
            }

            //Program *
            if (createRequirementModel.str_T1_select_Program_programId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Program_programId, createRequirementModel.str_T1_select_Program_programId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            objCommonMethods.Action_Button_Tab(WDriver);
            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(WDriver);
            //Charging Method *
            if (createRequirementModel.str_T1_btn_ChargingMethod_directIndirect != "")
            {
                if (createRequirementModel.str_T1_btn_ChargingMethod_directIndirect.ToLower().Equals(KeyWords.str_String_Compare_direct))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_ChargingMethod_directIndirectTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_ChargingMethod_directIndirectFalse);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }

            //Work Week 
            if (createRequirementModel.str_T1_select_WorkWeek_workScheduleID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_WorkWeek_workScheduleID, createRequirementModel.str_T1_select_WorkWeek_workScheduleID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Number of resources *
            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //Priority
            if (createRequirementModel.str_T1_select_Priority_priority != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Priority_priority, createRequirementModel.str_T1_select_Priority_priority);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Seciruty Clearance *
            if (createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID != "")
            {
                if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID))
                {
                    if (createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID.ToLower().Equals(KeyWords.str_String_Compare_noclearance))
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_SecurityClearance_securityClearanceLevelID, createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //return results;
                        }
                    }
                    else
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_SecurityClearance_securityClearanceLevelID, createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //return results;
                        }
                        if (createRequirementModel.str_T1_btn_CanStartwithoutClearance_txtWithout.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_CanStartwithoutClearance_txtWithoutYes);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                // return results;
                            }
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_CanStartwithoutClearance_txtWithoutNo);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                // return results;
                            }
                        }
                        if (createRequirementModel.str_T1_btn_InterimClearanceSufficient_txtSufficient.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_InterimClearanceSufficient_txtSufficientYes);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //  return results;
                            }
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_InterimClearanceSufficient_txtSufficientNo);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                // return results;
                            }
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T1_txt_PrimeContractNumber_txtContractNumber, createRequirementModel.str_T1_txt_PrimeContractNumber_txtContractNumber, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }
                        objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strBrowserName + "_");
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.str_T1_btn_SecurityClearanceDetailsMSGActionButton_Submit);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                        Thread.Sleep(3000);
                        objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strBrowserName + "_");
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.str_T1_btn_SecurityClearanceDetailsMsgwindowActionButton);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                        Thread.Sleep(3000);
                    }
                }
            }

            Thread.Sleep(5000);
            //Needed Date *
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_NeededDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_NeededDate_neededStartDate != "")
            {
                results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_NeededDate_neededStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_NeededDate_neededStartDate, createRequirementModel.str_T1_Date_NeededDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //End Date *
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                results = kwm.Select_End_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_EndDate_enddate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                    //D:\WorkingScripts\SmartTrackNewUI_Automation\bin\Debug\Input\Resumes\SampleResume.txt }
                }
            }
            // Console.WriteLine("Testing on 1");

            //Work Location *
            if (createRequirementModel.str_T1_Select_Worklocation_workLocationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_Worklocation_workLocationID, createRequirementModel.str_T1_Select_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Site Location *
            if (createRequirementModel.str_T1_select_SiteLocation_siteLocationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_SiteLocation_siteLocationID, createRequirementModel.str_T1_select_SiteLocation_siteLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Work Location Address *
            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                }
            }
        }
        #endregion MFC


        public static void ClientRequirementBimbo(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_Typeahead_EngagingManager_hiringManager))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_Typeahead_EngagingManager_hiringManager)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            // Engaging Manager
            if (createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_EngagingManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_EngagingManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager);
                    //  return results;
                }
            }

            //requestor - Disabled

            // Legal Entity
            if (createRequirementModel.str_T1_Typeahead_LegalEntity_organizationID != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_LegalEntity_organizationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_LegalEntity_organizationID, createRequirementModel.str_T1_Typeahead_LegalEntity_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_LegalEntity_organizationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_LegalEntity_organizationID, createRequirementModel.str_T1_Typeahead_LegalEntity_organizationID);
                    //  return results;
                }
            }

            // Business Area
            if (createRequirementModel.str_T1_Typeahead_BusinessArea_ProjectId != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_BusinessArea_ProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_BusinessArea_ProjectId, createRequirementModel.str_T1_Typeahead_BusinessArea_ProjectId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_BusinessArea_ProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_BusinessArea_ProjectId, createRequirementModel.str_T1_Typeahead_BusinessArea_ProjectId);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }

            // Natural Account
            if (createRequirementModel.str_T1_Typeahead_NaturalAccount_GLId != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_NaturalAccount_GLId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_NaturalAccount_GLId, createRequirementModel.str_T1_Typeahead_NaturalAccount_GLId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_NaturalAccount_GLId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_NaturalAccount_GLId, createRequirementModel.str_T1_Typeahead_NaturalAccount_GLId);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }

            //Local Analysis
            if (createRequirementModel.str_T1_Typeahead_LocalAnalysis_siteLocationID != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_LocalAnalysis_siteLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_LocalAnalysis_siteLocationID, createRequirementModel.str_T1_Typeahead_LocalAnalysis_siteLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_LocalAnalysis_siteLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_LocalAnalysis_siteLocationID, createRequirementModel.str_T1_Typeahead_LocalAnalysis_siteLocationID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }

            //// Fiscal - Disabled
            if (createRequirementModel.str_T1_Typeahead_Fiscal_matrixNumber != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Fiscal_matrixNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Fiscal_matrixNumber, createRequirementModel.str_T1_Typeahead_Fiscal_matrixNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Fiscal_matrixNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Fiscal_matrixNumber, createRequirementModel.str_T1_Typeahead_Fiscal_matrixNumber);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }


            // Cost Center
            if (createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_CostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_CostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId);
                    //  return results;
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Intercompany
            if (createRequirementModel.str_T1_Typeahead_Intercompany_deptNumber != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Intercompany_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Intercompany_deptNumber, createRequirementModel.str_T1_Typeahead_Intercompany_deptNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Intercompany_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Intercompany_deptNumber, createRequirementModel.str_T1_Typeahead_Intercompany_deptNumber);
                    //  return results;
                }
            }

            ////Future 1 - Disabled
            //if (createRequirementModel.str_T1_Typeahead_Future1_programId != "")
            //{
            //    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Future1_programId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Future1_programId, createRequirementModel.str_T1_Typeahead_Future1_programId);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Future1_programId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Future1_programId, createRequirementModel.str_T1_Typeahead_Future1_programId);
            //        //  return results;
            //    }
            //}

            //// Future 2 - Disabled
            //if (createRequirementModel.str_T1_Typeahead_Future2_ProfitCenterId != "")
            //{
            //    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Future2_ProfitCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Future2_ProfitCenterId, createRequirementModel.str_T1_Typeahead_Future2_ProfitCenterId);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Future2_ProfitCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Future2_ProfitCenterId, createRequirementModel.str_T1_Typeahead_Future2_ProfitCenterId);
            //        //  return results;
            //    }
            //}

            // Reason to Hire
            if (createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoHire_reasonToHireID, createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_ReasontoHire_reasonToHireID)));
                    se.SelectByIndex(1);
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);

            //Type of Assignment 
            if (createRequirementModel.str_T1_select_TypeofAssignment_workScheduleID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_TypeofAssignment_workScheduleID, createRequirementModel.str_T1_select_TypeofAssignment_workScheduleID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_TypeofAssignment_workScheduleID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Number of Resources
            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {

                    // return results;
                }
            }
            // Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_StartDate_neededStartDate != "")
            {
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today.AddMonths(-1));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate, createRequirementModel.str_T1_Date_StartDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //End Date

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today.AddMonths(3));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            // Work Location
            if (createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                    //  return results;
                }
            }

            //Work Location Address - Disabled
            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                    //  return results;
                }
            }

            // Business Unit
            if (createRequirementModel.str_T1_select_BusinessUnit_serviceMethodID != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_BusinessUnit_serviceMethodID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_select_BusinessUnit_serviceMethodID, createRequirementModel.str_T1_select_BusinessUnit_serviceMethodID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_BusinessUnit_serviceMethodID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_select_BusinessUnit_serviceMethodID, createRequirementModel.str_T1_select_BusinessUnit_serviceMethodID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }

            // Emergency position
            if (createRequirementModel.str_T1_select_EmergencyPosition_laborClassCode != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_EmergencyPosition_laborClassCode, createRequirementModel.str_T1_select_EmergencyPosition_laborClassCode);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Additional Requirement Details
            if (createRequirementModel.str_T1_txt_AdditionalrequirementDetails_JustificationtoHire != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_AdditionalrequirementDetails_JustificationtoHire, createRequirementModel.str_T1_txt_AdditionalrequirementDetails_JustificationtoHire, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

        }

        public static void ClientRequirementGeorgeTown(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_Typeahead_HiringManager_hiringManager))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_Typeahead_HiringManager_hiringManager)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            //Requestor - Disabled

            // Hiring Manager
            if (createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                    //  return results;
                }
            }



            //Organization Name
            if (createRequirementModel.str_T1_Typeahead_OrganizationName_organizationID != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_OrganizationName_organizationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_OrganizationName_organizationID, createRequirementModel.str_T1_Typeahead_OrganizationName_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_OrganizationName_organizationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_OrganizationName_organizationID, createRequirementModel.str_T1_Typeahead_OrganizationName_organizationID);
                    //  return results;
                }
            }



            //Course Name
            if (createRequirementModel.str_T1_Typeahead_CourseName_serviceMethodID != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_CourseName_serviceMethodID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_CourseName_serviceMethodID, createRequirementModel.str_T1_Typeahead_CourseName_serviceMethodID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_CourseName_serviceMethodID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_CourseName_serviceMethodID, createRequirementModel.str_T1_Typeahead_CourseName_serviceMethodID);
                    //  return results;
                }
            }

            //Spend Category
            if (createRequirementModel.str_T1_Typeahead_SpendCategory_deptNumber != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_SpendCategory_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_SpendCategory_deptNumber, createRequirementModel.str_T1_Typeahead_SpendCategory_deptNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_SpendCategory_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_SpendCategory_deptNumber, createRequirementModel.str_T1_Typeahead_SpendCategory_deptNumber);
                    //  return results;
                }
            }


            //Fund
            if (createRequirementModel.str_T1_Typeahead_Fund_siteLocationID != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Fund_siteLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Fund_siteLocationID, createRequirementModel.str_T1_Typeahead_Fund_siteLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Fund_siteLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Fund_siteLocationID, createRequirementModel.str_T1_Typeahead_Fund_siteLocationID);
                    //  return results;
                }
            }

            //Purpose
            if (createRequirementModel.str_T1_Typeahead_Purpose_ProfitCenterId != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Purpose_ProfitCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Purpose_ProfitCenterId, createRequirementModel.str_T1_Typeahead_Purpose_ProfitCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Purpose_ProfitCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Purpose_ProfitCenterId, createRequirementModel.str_T1_Typeahead_Purpose_ProfitCenterId);
                    //  return results;
                }
            }

            //Cost Center
            if (createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_CostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_CostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId);
                    //  return results;
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);

            //Program Name 
            if (createRequirementModel.str_T1_Typeahead_ProgramName_programId != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_ProgramName_programId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_ProgramName_programId, createRequirementModel.str_T1_Typeahead_ProgramName_programId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_ProgramName_programId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_ProgramName_programId, createRequirementModel.str_T1_Typeahead_ProgramName_programId);
                    //  return results;
                }
            }

            //Reason to Hire *
            if (createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoHire_reasonToHireID, createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_ReasontoHire_reasonToHireID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }




            //Number of Resources *
            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_StartDate_neededStartDate != "")
            {
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today.AddMonths(-1));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate, createRequirementModel.str_T1_Date_StartDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //End Date

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today.AddMonths(3));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            Thread.Sleep(2000);


            //Work Location 
            if (createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                    //  return results;
                }
            }


            // Work Location Address 
            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead_LocationAddress_New(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }


            //PO details & Remote CW Work location address 
            if (createRequirementModel.str_T1_Txt_POdetailsRemoteCWWorklocationaddress_JustificationtoHire != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_POdetailsRemoteCWWorklocationaddress_JustificationtoHire, createRequirementModel.str_T1_Txt_POdetailsRemoteCWWorklocationaddress_JustificationtoHire, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }



        }

        public static void ClientRequirementCOE(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_Typeahead_HiringManager_hiringManager))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_Typeahead_HiringManager_hiringManager)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            // Engaging Manager
            if (createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                    //  return results;
                }
            }

            //Requestor - Disabled 

            //Program Manager
            if (createRequirementModel.str_T1_Typeahead_programManager_altHiringManager != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_programManager_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_programManager_altHiringManager, createRequirementModel.str_T1_Typeahead_programManager_altHiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_programManager_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_programManager_altHiringManager, createRequirementModel.str_T1_Typeahead_programManager_altHiringManager);
                    //  return results;
                }
            }


            //CoE Req Type *
            if (createRequirementModel.str_T1_select_CoEReqType_serviceMethodID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_CoEReqType_serviceMethodID, createRequirementModel.str_T1_select_CoEReqType_serviceMethodID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_CoEReqType_serviceMethodID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Branch
            if (createRequirementModel.str_T1_Typeahead_Branch_organizationID != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Branch_organizationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Branch_organizationID, createRequirementModel.str_T1_Typeahead_Branch_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Branch_organizationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Branch_organizationID, createRequirementModel.str_T1_Typeahead_Branch_organizationID);
                    //  return results;
                }
            }

            //Department
            if (createRequirementModel.str_T1_Typeahead_Department_deptNumber != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Department_deptNumber, createRequirementModel.str_T1_Typeahead_Department_deptNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Department_deptNumber, createRequirementModel.str_T1_Typeahead_Department_deptNumber);
                    //  return results;
                }
            }

            objCommonMethods.Action_Button_Tab(WDriver);
            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(WDriver);

            //Project Name - Disabled

            //Project Number - Disabled

            //PO ID
            if (createRequirementModel.str_T1_Typeahead_POID_ProjectId != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_POID_ProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_POID_ProjectId, createRequirementModel.str_T1_Typeahead_POID_ProjectId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_POID_ProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_POID_ProjectId, createRequirementModel.str_T1_Typeahead_POID_ProjectId);
                    //  return results;
                }
            }

            //Number of Resources *
            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_StartDate_neededStartDate != "")
            {
                results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_StartDate_neededStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate, createRequirementModel.str_T1_Date_StartDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            // Enddate
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
               // results = kwm.Select_End_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_EndDate_enddate);
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_T1_Enddateclick);
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Now.AddMonths(10));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            Thread.Sleep(2000);


            //Work Location 
                        
            if (createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID != "")
            {
                Thread.Sleep(2000);
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, 1);
                    //  return results;	
                }
            }



            // Work Location Address - disabled
            //if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            //{
            //    results = kwm.select_List_typeahead_LocationAddress_New(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        //  return results;
            //    }
            //}

            //Type of Assignment
            if (createRequirementModel.str_T1_select_TypeofAssignment_workScheduleID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_TypeofAssignment_workScheduleID, createRequirementModel.str_T1_select_TypeofAssignment_workScheduleID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_TypeofAssignment_workScheduleID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Reason to Hire *
            if (createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoHire_reasonToHireID, createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_ReasontoHire_reasonToHireID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }





            //Additional Work Location Details 
            if (createRequirementModel.str_T1_txt_AdditionalWorkLocationDetails_JustificationtoHire != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_AdditionalWorkLocationDetails_JustificationtoHire, createRequirementModel.str_T1_txt_AdditionalWorkLocationDetails_JustificationtoHire, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //HR Recieved

            //if (createRequirementModel.str_T1_btn_HRReviewed_computerAccess.ToLower().Equals(KeyWords.str_String_Compare_yes))
            //{
            //    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_HRReviewed_computerAccessTrue);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        // return results;
            //    }
            //}
            //else
            //{
            //    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_HRReviewed_computerAccessFalse);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        //  return results;
            //    }
            //}

            //    objCommonMethods.Select_Radio_Button_ID(WDriver, KeyWords.ID_T1_btn_HRReviewed_computerAccessTrue, "True");


            if (createRequirementModel.str_T1_btn_HRReviewed_computerAccess != "")
            {
                if (createRequirementModel.str_T1_btn_HRReviewed_computerAccess.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button_ID(WDriver, KeyWords.ID_T1_btn_HRReviewed_computerAccessTrue, "True");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button_ID(WDriver, KeyWords.ID_T1_btn_HRReviewed_computerAccessFalse, "False");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
            }
            else
            {
                results = objCommonMethods.Select_Radio_Button_ID(WDriver, KeyWords.ID_T1_btn_HRReviewed_computerAccessFalse, "False");
            }



        }
        
        public static void ClientRequirementTufts(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_Typeahead_HiringManager_hiringManager))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_Typeahead_HiringManager_hiringManager)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_Justification_JustificationtoHire);

            //Hiring Manager  *

            if (createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager != "")
            {


                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(2000);
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                    //  return results;
                }
            }
            Thread.Sleep(2000);
            //Requestor *  - Disabled
            if (createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {

                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                }

            }


            //Department

            if (createRequirementModel.str_T1_Typeahead_Department_organizationID != "")
            {


                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_organizationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Department_organizationID, createRequirementModel.str_T1_Typeahead_Department_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(2000);
                    results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_organizationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, "a");
                    //results = kwm.select_List_typeahead_AnyOne  (WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_organizationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Department_organizationID, createRequirementModel.str_T1_Typeahead_Department_organizationID);
                    //  return results;
                }
            }

            //Account Code*
            if (createRequirementModel.str_T1_Select_AccountCode_CostCenterId != "")
            {
                results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_AccountCode_CostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {

                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_AccountCode_CostCenterId, 2);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_AccountCode_CostCenterId, createRequirementModel.str_T1_Select_AccountCode_CostCenterId);
                    }
                }
            }


            // Reason To Hire

            if (createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID != "")
            {
                results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoHire_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {

                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoHire_reasonToHireID, 2);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoHire_reasonToHireID, createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID);
                    }
                }
            }



            // Number of Resources * 

            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            // Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_StartDate_neededStartDate != "")
            {
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today.AddMonths(-1));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate, createRequirementModel.str_T1_Date_StartDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
           
            //End Date

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today.AddMonths(3));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //Work Location *

            if (createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Work Location Address *

            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Work week

            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_select_WorkWeek_workScheduleID))
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_WorkWeek_workScheduleID, createRequirementModel.str_T1_select_WorkWeek_workScheduleID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_WorkWeek_workScheduleID);
                }
            }


            // Justification to Hire


            if (createRequirementModel.str_T1_txt_Justification_JustificationtoHire != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_Justification_JustificationtoHire, createRequirementModel.str_T1_txt_Justification_JustificationtoHire, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }

            }

        }

        public static void ClientRequirementPhhMortgage(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_Typeahead_HiringManager_hiringManager))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_Typeahead_HiringManager_hiringManager)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            //Requestor *  - Disabled
            if (createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                }
            }

            //Hiring Manager  *

            if (createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager != "")
            {


                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(2000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                    //  return results;
                }
            }

            Thread.Sleep(2000);

            //Division *
            if (createRequirementModel.str_T1_Typeahead_Divison_GLId != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Divison_GLId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Divison_GLId, createRequirementModel.str_T1_Typeahead_Divison_GLId);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Divison_GLId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Divison_GLId, createRequirementModel.str_T1_Typeahead_Divison_GLId);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Divison_GLId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Divison_GLId, createRequirementModel.str_T1_Typeahead_Divison_GLId);
                    }
                }
            }


            //Req Type *
            if (createRequirementModel.str_T1_Select_ReqType_organizationID != "")
            {
                results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_ReqType_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {

                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_ReqType_organizationID, 2);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_ReqType_organizationID, createRequirementModel.str_T1_Select_ReqType_organizationID);
                    }
                }
            }

            //Cost Center *
            if (createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_CostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(2000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_CostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId, "1");
                    //  return results;
                }
            }


            // Number of Resources * 

            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //Sub Division *
            if (createRequirementModel.str_T1_Select_SubDivision_programId != "")
            {
                results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_SubDivision_programId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {

                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_SubDivision_programId, 2);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_SubDivision_programId, createRequirementModel.str_T1_Select_SubDivision_programId);
                    }
                }
            }

            //Department

            if (createRequirementModel.str_T1_Select_Department_deptNumber != "")
            {
                results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_Department_deptNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {

                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_Department_deptNumber, 2);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_Department_deptNumber, createRequirementModel.str_T1_Select_Department_deptNumber);
                    }
                }
            }

            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_Comments_JustificationtoHire);


            // Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_StartDate_neededStartDate != "")
            {
                results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_StartDate_neededStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate, createRequirementModel.str_T1_Date_StartDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            // Enddate
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                results = kwm.Select_End_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_EndDate_enddate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }



            //  objCommonMethods.Action_Page_Down(WDriver);


            //Work Location *

            if (createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            // Reason To Hire

            if (createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID != "")
            {
                results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoHire_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {

                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoHire_reasonToHireID, 2);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoHire_reasonToHireID, createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID);
                    }
                }
            }


            //Work Location Address *

            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(2000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                    //  return results;
                }

            }

            //Service Method *
            if (createRequirementModel.str_T1_select_ServiceMethod_serviceMethodID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ServiceMethod_serviceMethodID, createRequirementModel.str_T1_select_ServiceMethod_serviceMethodID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {


                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ServiceMethod_serviceMethodID, 2);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ServiceMethod_serviceMethodID);
                    }

                }
            }

            //Business Unit

            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_select_BusinessUnit_ProjectId))
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_BusinessUnit_ProjectId, createRequirementModel.str_T1_select_BusinessUnit_ProjectId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Project_ProjectId);
                }
            }

            // Justification to Hire


            if (createRequirementModel.str_T1_Txt_Comments_JustificationtoHire != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_Comments_JustificationtoHire, createRequirementModel.str_T1_Txt_Comments_JustificationtoHire, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }

            }


        }

        public static void ClientRequirementSTGEN(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            //Organization Name *
            if (createRequirementModel.str_T1_select_OrganizationName_organizationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_OrganizationName_organizationID, createRequirementModel.str_T1_select_OrganizationName_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Headcount Approved 
            if (createRequirementModel.str_T1_select_HeadcountApproved_laborClassCode != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_HeadcountApproved_laborClassCode, createRequirementModel.str_T1_select_HeadcountApproved_laborClassCode);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Department *

            if (createRequirementModel.str_T1_Typeahead_Department_deptNumber != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Department_deptNumber, createRequirementModel.str_T1_Typeahead_Department_deptNumber);
                //  Thread.Sleep(2000);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Department_deptNumber, createRequirementModel.str_T1_Typeahead_Department_deptNumber);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, "a");
                        // return results;
                    }
                }
            }

            //Department Name  - Disabled

            //Hiring Manager *
            if (createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager != "")
            {
                Thread.Sleep(3000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                    //  return results;
                }
            }

            //Supervisor *
            if (createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager != "")
            {
                Thread.Sleep(3000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Supervisor_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager, createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Supervisor_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager, createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager);
                    //  return results;
                }
            }


            //Program *
            if (createRequirementModel.str_T1_select_Program_programId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Program_programId, createRequirementModel.str_T1_select_Program_programId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Charging Method 
            if (createRequirementModel.str_T1_btn_ChargingMethod_directIndirect != "")
            {
                if (createRequirementModel.str_T1_btn_ChargingMethod_directIndirect.ToLower().Equals(KeyWords.str_String_Compare_direct))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_ChargingMethod_directIndirectTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_ChargingMethod_directIndirectFalse);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }

            //Work Week *
            if (createRequirementModel.str_T1_select_WorkWeek_workScheduleID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_WorkWeek_workScheduleID, createRequirementModel.str_T1_select_WorkWeek_workScheduleID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Number of Resources *
            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //Priority
            if (createRequirementModel.str_T1_select_Priority_priority != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Priority_priority, createRequirementModel.str_T1_select_Priority_priority);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Seciruty Clearance *
            if (createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID != "")
            {
                if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID))
                {
                    if (createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID.ToLower().Equals(KeyWords.str_String_Compare_noclearance))
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_SecurityClearance_securityClearanceLevelID, createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //return results;
                        }
                    }
                    else
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_SecurityClearance_securityClearanceLevelID, createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //return results;
                        }
                        if (createRequirementModel.str_T1_btn_CanStartwithoutClearance_txtWithout.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_CanStartwithoutClearance_txtWithoutYes);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                // return results;
                            }
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_CanStartwithoutClearance_txtWithoutNo);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                // return results;
                            }
                        }
                        if (createRequirementModel.str_T1_btn_InterimClearanceSufficient_txtSufficient.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_InterimClearanceSufficient_txtSufficientYes);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //  return results;
                            }
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_InterimClearanceSufficient_txtSufficientNo);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                // return results;
                            }
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T1_txt_PrimeContractNumber_txtContractNumber, createRequirementModel.str_T1_txt_PrimeContractNumber_txtContractNumber, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }
                        objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strBrowserName + "_");
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.str_T1_btn_SecurityClearanceDetailsMSGActionButton_Submit);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                        Thread.Sleep(3000);
                        objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strBrowserName + "_");
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.str_T1_btn_SecurityClearanceDetailsMsgwindowActionButton);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                        Thread.Sleep(3000);
                    }
                }
            }

            Thread.Sleep(5000);
            //Needed Date *
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_NeededDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_NeededDate_neededStartDate != "")
            {
                results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_NeededDate_neededStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_NeededDate_neededStartDate, createRequirementModel.str_T1_Date_NeededDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //End Date *
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                results = kwm.Select_End_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_EndDate_enddate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                    //D:\WorkingScripts\SmartTrackNewUI_Automation\bin\Debug\Input\Resumes\SampleResume.txt }
                }
            }
            // Console.WriteLine("Testing on 1");

            //Work Location *
            if (createRequirementModel.str_T1_Select_Worklocation_workLocationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_Worklocation_workLocationID, createRequirementModel.str_T1_Select_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Site Location *
            if (createRequirementModel.str_T1_select_SiteLocation_siteLocationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_SiteLocation_siteLocationID, createRequirementModel.str_T1_select_SiteLocation_siteLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Work Location Address *
            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                }
            }
        }

        #region Supervalu
        public static void ClientRequirementSupervalu(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //Boolean bFlag = false;

            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_select_CostCenter_CostCenterId))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_select_CostCenter_CostCenterId)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            //Cost Center
            if (createRequirementModel.str_T1_select_CostCenter_CostCenterId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_CostCenter_CostCenterId, createRequirementModel.str_T1_select_CostCenter_CostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_CostCenter_CostCenterId, createRequirementModel.str_T1_select_CostCenter_CostCenterId);
                    //  return results;
                }
            }

            //Store/Unit Name - Disabled

            //General Ledger Account

            if (createRequirementModel.str_T1_select_GeneralLedgerAccount_GLId != "")
            {
                //Thread.Sleep(2000);
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_GeneralLedgerAccount_GLId, createRequirementModel.str_T1_select_GeneralLedgerAccount_GLId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_GeneralLedgerAccount_GLId, createRequirementModel.str_T1_select_GeneralLedgerAccount_GLId);
                    //  return results;
                }
            }

            //Business Name
            if (createRequirementModel.str_T1_select_BusinessArea_organizationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_BusinessArea_organizationID, createRequirementModel.str_T1_select_BusinessArea_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Legal Entity
            if (createRequirementModel.str_T1_txt_LegalEntity_association != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_LegalEntity_association, createRequirementModel.str_T1_txt_LegalEntity_association, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Service Dept
            if (createRequirementModel.str_T1_txt_servicedept_ServDept != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_servicedept_ServDept, createRequirementModel.str_T1_txt_servicedept_ServDept, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Product Dept
            if (createRequirementModel.str_T1_txt_ProductDept_ProDept != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_ProductDept_ProDept, createRequirementModel.str_T1_txt_ProductDept_ProDept, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //EngagingManager
            if (createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager != "")
            {
                //  Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Engagingmanager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Engagingmanager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager);
                    //  return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //Alternate Hiring manager
            if (createRequirementModel.str_T1_select_AlternateHiringManager_altHiringManager != "")
            {
                // Thread.Sleep(3000);
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_AlternateHiringManager_altHiringManager, createRequirementModel.str_T1_select_AlternateHiringManager_altHiringManager);
                //   results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_selectAltHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.strAltEngagingManager_LastNameFirstName, createRequirementModel.strAltEngagingManager_LastNameFirstName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_AlternateHiringManager_altHiringManager, createRequirementModel.str_T1_select_AlternateHiringManager_altHiringManager);
                    //  return results;
                }
            }

            //Union

            if (createRequirementModel.str_select_UnionName_laborClassCode != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_UnionName_laborClassCode, createRequirementModel.str_select_UnionName_laborClassCode);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }


            //Priority
            if (createRequirementModel.str_T1_select_Priority_priority != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Priority_priority, createRequirementModel.str_T1_select_Priority_priority);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            // Work Week
            if (createRequirementModel.str_T1_select_WorkWeek_workScheduleID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_WorkWeek_workScheduleID, createRequirementModel.str_T1_select_WorkWeek_workScheduleID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Number of Resources
            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }






            objCommonMethods.Action_Page_Down(WDriver);

            //Reason to Hire
            //  objCommonMethods.Action_Page_Down(WDriver);
            if (createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoHire_reasonToHireID, createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Justificationto hire
            if (createRequirementModel.str_T1_txt_JustificationtoHire_JustificationtoHire != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_JustificationtoHire_JustificationtoHire, createRequirementModel.str_T1_txt_JustificationtoHire_JustificationtoHire, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Assignment Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_AssignmentStartDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_AssignmentStartDate_neededStartDate != "")
            {
                results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_AssignmentStartDate_neededStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_AssignmentStartDate_neededStartDate, createRequirementModel.str_T1_Date_AssignmentStartDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //Assignment Enddate
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_AssignmentEndDate_enddate);

            if (createRequirementModel.str_T1_Date_AssignmentEndDate_enddate != "")
            {
                results = kwm.Select_End_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_AssignmentEndDate_enddate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_AssignmentEndDate_enddate, createRequirementModel.str_T1_Date_AssignmentEndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //Work Location 
            if (createRequirementModel.str_T1_Select_Worklocation_workLocationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_Worklocation_workLocationID, createRequirementModel.str_T1_Select_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
            //organisation -disabled
            //if (createRequirementModel.strSelectOrganization != "")
            //{
            //    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_siteLocationID, createRequirementModel.strSelectOrganization);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        // return results;
            //    }
            //}
            // Work Location Address
            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead_LocationAddress_New(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }


        }
        #endregion Supervalu

        #region Emerson
        public static void ClientRequirementEmerson(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_Typeahead_Engagingmanager_hiringManager))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_Typeahead_Engagingmanager_hiringManager)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            // Engaging Manager
            if (createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Engagingmanager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Engagingmanager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager);
                    //  return results;
                }
            }

            //Requestor - Disabled 


            // Department
            if (createRequirementModel.str_T1_select_Department_organizationID != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Department_organizationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_select_Department_organizationID, createRequirementModel.str_T1_select_Department_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Department_organizationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_select_Department_organizationID, createRequirementModel.str_T1_select_Department_organizationID);
                    //  return results;
                }
            }

            //FOAPAL - Disabled

            //Work Week *
            if (createRequirementModel.str_T1_select_WorkWeek_workScheduleID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_WorkWeek_workScheduleID, createRequirementModel.str_T1_select_WorkWeek_workScheduleID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_WorkWeek_workScheduleID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Number of Resources *
            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            Thread.Sleep(2000);


            objCommonMethods.Action_Page_Down(WDriver);
            //Reason for Hire *
            if (createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoHire_reasonToHireID, createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_ReasontoHire_reasonToHireID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }




            //Purchase order Number
            if (createRequirementModel.str_T1_typehead_PurchaseOrderNumber_CostCenterId != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_typehead_PurchaseOrderNumber_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_typehead_PurchaseOrderNumber_CostCenterId, createRequirementModel.str_T1_typehead_PurchaseOrderNumber_CostCenterId);
                //  Thread.Sleep(2000);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_typehead_PurchaseOrderNumber_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_typehead_PurchaseOrderNumber_CostCenterId, createRequirementModel.str_T1_typehead_PurchaseOrderNumber_CostCenterId);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_typehead_PurchaseOrderNumber_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, "a");
                        // return results;
                    }
                }
            }

            //Work Location 
            if (createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID != "")
            {
                results = kwm.select_List_typeahead_LocationAddress_New(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }




            // Work Location Address
            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead_LocationAddress_New(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }


            // Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_StartDate_neededStartDate != "")
            {
                results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_StartDate_neededStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate, createRequirementModel.str_T1_Date_StartDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            // Enddate
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                results = kwm.Select_End_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_EndDate_enddate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //Justificationto hire
            if (createRequirementModel.str_T1_txt_JustificationtoHire_JustificationtoHire != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_JustificationtoHire_JustificationtoHire, createRequirementModel.str_T1_txt_JustificationtoHire_JustificationtoHire, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }


        }
        #endregion Emerson

        public static void ClientRequirementArkema(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_select_Organization_organizationID))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_select_Organization_organizationID)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            //Organization
            if (createRequirementModel.str_T1_select_Organization_organizationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Organization_organizationID, createRequirementModel.str_T1_select_Organization_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_Organization_organizationID))); //Locating select list
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
                try
                {
                    SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_Organization_organizationID))); //Locating select list
                    se.SelectByIndex(1);
                }
                catch
                {
                    //
                }
            }

            //Account Assignment (Cost Center or WBS Project

            if (createRequirementModel.str_T1_Radio_CostCenterOrProfitCenter_AccountAssignment1.ToLower() != "")
            {
                if (createRequirementModel.str_T1_Radio_CostCenterOrProfitCenter_AccountAssignment1.ToLower() == KeyWords.str_String_Compare_cost_center_profit_center)
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Radio_CostCenterOrProfitCenter_AccountAssignment1);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    if (results.Result1 == KeyWords.Result_PASS)
                    {
                        //Cost Center
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_CostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId);
                        //ProfitCenter
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typehead_ProfitCenter_ProfitCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typehead_ProfitCenter_ProfitCenterId, createRequirementModel.str_T1_Typehead_ProfitCenter_ProfitCenterId);
                    }
                }
                else if (createRequirementModel.str_T1_Radio_ProjectOrWBSElement_AccountAssignment3.ToLower() == KeyWords.str_String_Compare_project_wbs_element)
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Radio_ProjectOrWBSElement_AccountAssignment3);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    if (results.Result1 == KeyWords.Result_PASS)
                    {
                        //Projector WBS Element
                        results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_TypeHead_ProjectOrWBSElement_ProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_ProjectWBSElement_ProjectId, createRequirementModel.str_T1_Typeahead_ProjectWBSElement_ProjectId);
                        //  return results;
                    }
                }
            }

            //General Ledger Account
            if (createRequirementModel.str_T1_select_GeneralLedgerAccount_GLId != "")
            {
                results = kwm.Select_GLID_Choose(WDriver, createRequirementModel.str_T1_select_GeneralLedgerAccount_GLId);
                if (results.Result1 == KeyWords.Result_PASS)
                {
                    //  return results;
                }
            }

            //Purchasing Group

            if (createRequirementModel.str_T1_select_PurchasingGroup_serviceMethodID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_PurchasingGroup_serviceMethodID, createRequirementModel.str_T1_select_PurchasingGroup_serviceMethodID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_PurchasingGroup_serviceMethodID))); //Locating select list
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
                try
                {
                    SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_PurchasingGroup_serviceMethodID))); //Locating select list
                    se.SelectByIndex(1);
                }
                catch
                {
                    //
                }
            }


            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(WDriver);

            //Hiring Manager
            if (createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager != "")
            {
                //Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                        //  return results;
                    }
                }
            }



            //Delegate of Authority
            if (createRequirementModel.str_Typeahead_DelegateofAuthority_altHiringManager != "")
            {
                //Thread.Sleep(3000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_DelegateofAuthority_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_Typeahead_DelegateofAuthority_altHiringManager, createRequirementModel.str_Typeahead_DelegateofAuthority_altHiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_DelegateofAuthority_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_Typeahead_DelegateofAuthority_altHiringManager, createRequirementModel.str_Typeahead_DelegateofAuthority_altHiringManager);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_DelegateofAuthority_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_Typeahead_DelegateofAuthority_altHiringManager, createRequirementModel.str_Typeahead_DelegateofAuthority_altHiringManager);
                        //  return results;
                    }
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Reqisitioner - Disabled
            if (createRequirementModel.str_txt_Requisitioner_CreatedUserID != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txt_Requisitioner_CreatedUserID, createRequirementModel.str_txt_Requisitioner_CreatedUserID, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Material Group 

            if (createRequirementModel.str_select_MaterialGroup_laborClassCode != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_MaterialGroup_laborClassCode, createRequirementModel.str_select_MaterialGroup_laborClassCode);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_select_MaterialGroup_laborClassCode))); //Locating select list
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
                try
                {
                    SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_select_MaterialGroup_laborClassCode))); //Locating select list
                    se.SelectByIndex(1);
                }
                catch
                {
                    //
                }
            }

            //Priority
            if (createRequirementModel.str_T1_select_Priority_priority != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Priority_priority, createRequirementModel.str_T1_select_Priority_priority);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_Priority_priority))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Work Week 
            if (createRequirementModel.str_T1_select_WorkWeek_workScheduleID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_WorkWeek_workScheduleID, createRequirementModel.str_T1_select_WorkWeek_workScheduleID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_WorkWeek_workScheduleID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Number of Resources
            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //Purchase Organization
            if (createRequirementModel.str_select_PurchaseOrganization_programId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_select_PurchaseOrganization_programId, createRequirementModel.str_select_PurchaseOrganization_programId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_select_PurchaseOrganization_programId))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Needed Date *
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_NeededDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_NeededDate_neededStartDate != "")
            {
                results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_NeededDate_neededStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_NeededDate_neededStartDate, createRequirementModel.str_T1_Date_NeededDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //End Date *
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                results = kwm.Select_End_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_EndDate_enddate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }

                }
            }

            //Reason to Hire
            if (createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoHire_reasonToHireID, createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_ReasontoHire_reasonToHireID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }



            //Work Location 
            if (createRequirementModel.str_T1_Select_Worklocation_workLocationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_Worklocation_workLocationID, createRequirementModel.str_T1_Select_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_Select_Worklocation_workLocationID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Plant Number 
            if (createRequirementModel.str_Typeahead_PlantNumber_siteLocationID != "")
            {
                // Thread.Sleep(5000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_Typeahead_PlantNumber_siteLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_Typeahead_PlantNumber_siteLocationID, createRequirementModel.str_Typeahead_PlantNumber_siteLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Work Location Address
            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
        }

        #region Workspend-SallieMae
        public static void ClientRequirementSallieMae(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_Typeahead_EngagingManager_hiringManager))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_Typeahead_EngagingManager_hiringManager)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            // Engaging Manager
            if (createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_EngagingManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_EngagingManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager);
                    //  return results;
                }
            }

            //Requestor - Disabled 

            //Business Unit - Disabled

            // Cost Center
            if (createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_CostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_CostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId);
                    //  return results;
                }
            }

            // General Ledger Account
            if (createRequirementModel.str_T1_select_GeneralLedgerAccount_GLId != "")
            {
                //Thread.Sleep(2000);
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_GeneralLedgerAccount_GLId, createRequirementModel.str_T1_select_GeneralLedgerAccount_GLId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_GeneralLedgerAccount_GLId, createRequirementModel.str_T1_select_GeneralLedgerAccount_GLId);
                    //  return results;
                }
            }

            // Division 
            if (createRequirementModel.str_T1_Typeahead_Division_programId != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Division_programId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Division_programId, createRequirementModel.str_T1_Typeahead_Division_programId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Division_programId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Division_programId, createRequirementModel.str_T1_Typeahead_Division_programId);
                    //  return results;
                }
            }

            //Supervisory Org - Disbaled

            // Work Week
            if (createRequirementModel.str_T1_select_WorkWeek_workScheduleID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_WorkWeek_workScheduleID, createRequirementModel.str_T1_select_WorkWeek_workScheduleID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_WorkWeek_workScheduleID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            kwm.click(WDriver, KeyWords.locator_ID, "wizard");
            objCommonMethods.Action_Page_Down(WDriver);
            //Number of Resources
            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_StartDate_neededStartDate != "")
            {
                results = kwm.Select_Start_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_StartDate_neededStartDate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate, createRequirementModel.str_T1_Date_StartDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }



            // Enddate
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                results = kwm.Select_End_Date_From_Picker(WDriver, createRequirementModel.str_T1_Date_EndDate_enddate);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //objCommonMethods.Action_Button_Tab(WDriver);

            //Work Location 
            if (createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID != "")
            {
                results = kwm.select_List_typeahead_LocationAddress_New(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            // Work Location Address - Disbaled
            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead_LocationAddress_New(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //CW Can Work Remotely
            if (createRequirementModel.str_T1_Radiobtn_CWCanWorkRemotely_directIndirect != "")
            {
                if (createRequirementModel.str_T1_Radiobtn_CWCanWorkRemotely_directIndirect.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Radiobtn_CWCanWorkRemotely_directIndirectTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Radiobtn_CWCanWorkRemotely_directIndirectFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Reason to Hire
            if (createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoHire_reasonToHireID, createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_ReasontoHire_reasonToHireID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //IT Project Initiative - Disbaled

            //Justificationto hire
            if (createRequirementModel.str_T1_txt_JustificationtoHire_JustificationtoHire != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_JustificationtoHire_JustificationtoHire, createRequirementModel.str_T1_txt_JustificationtoHire_JustificationtoHire, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

        }
        #endregion Workspend-SallieMae

      
        public static void ClientRequirementSTTM(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            //Organization Name 
            if (createRequirementModel.str_T1_select_OrganizationName_organizationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_OrganizationName_organizationID, createRequirementModel.str_T1_select_OrganizationName_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Headcount Approved 
            if (createRequirementModel.str_T1_select_HeadcountApproved_laborClassCode != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_HeadcountApproved_laborClassCode, createRequirementModel.str_T1_select_HeadcountApproved_laborClassCode);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Department *

            if (createRequirementModel.str_T1_Typeahead_Department_deptNumber != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Department_deptNumber, createRequirementModel.str_T1_Typeahead_Department_deptNumber);
                //  Thread.Sleep(2000);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Department_deptNumber, createRequirementModel.str_T1_Typeahead_Department_deptNumber);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Department_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, "a");
                        // return results;
                    }
                }
            }

            //Department Name  - Disabled

            //Hiring Manager 


            if (createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager != "")
            {
                Thread.Sleep(3000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                    //  return results;
                }
            }

            //Supervisor
            if (createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager != "")
            {
                Thread.Sleep(3000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Supervisor_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager, createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Supervisor_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager, createRequirementModel.str_T1_Typeahead_Supervisor_altHiringManager);
                    //  return results;
                }
            }


            //Program 
            if (createRequirementModel.str_T1_select_Program_programId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Program_programId, createRequirementModel.str_T1_select_Program_programId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Charging Method *
            if (createRequirementModel.str_T1_btn_ChargingMethod_directIndirect != "")
            {
                if (createRequirementModel.str_T1_btn_ChargingMethod_directIndirect.ToLower().Equals(KeyWords.str_String_Compare_direct))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_ChargingMethod_directIndirectTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_ChargingMethod_directIndirectFalse);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }

            //Work Week 
            if (createRequirementModel.str_T1_select_WorkWeek_workScheduleID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_WorkWeek_workScheduleID, createRequirementModel.str_T1_select_WorkWeek_workScheduleID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Number of resources *
            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //Priority
            if (createRequirementModel.str_T1_select_Priority_priority != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Priority_priority, createRequirementModel.str_T1_select_Priority_priority);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Seciruty Clearance *
            if (createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID != "")
            {
                if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID))
                {
                    if (createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID.ToLower().Equals(KeyWords.str_String_Compare_noclearance))
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_SecurityClearance_securityClearanceLevelID, createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //return results;
                        }
                    }
                    else
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_SecurityClearance_securityClearanceLevelID, createRequirementModel.str_T1_select_SecurityClearance_securityClearanceLevelID);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //return results;
                        }
                        if (createRequirementModel.str_T1_btn_CanStartwithoutClearance_txtWithout.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_CanStartwithoutClearance_txtWithoutYes);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                // return results;
                            }
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_CanStartwithoutClearance_txtWithoutNo);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                // return results;
                            }
                        }
                        if (createRequirementModel.str_T1_btn_InterimClearanceSufficient_txtSufficient.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_InterimClearanceSufficient_txtSufficientYes);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //  return results;
                            }
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_InterimClearanceSufficient_txtSufficientNo);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                // return results;
                            }
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T1_txt_PrimeContractNumber_txtContractNumber, createRequirementModel.str_T1_txt_PrimeContractNumber_txtContractNumber, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }
                        objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strBrowserName + "_");
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.str_T1_btn_SecurityClearanceDetailsMSGActionButton_Submit);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                        Thread.Sleep(3000);
                        objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strBrowserName + "_");
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.str_T1_btn_SecurityClearanceDetailsMsgwindowActionButton);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                        Thread.Sleep(3000);
                    }
                }
            }

            Thread.Sleep(5000);
            // Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_StartDate_neededStartDate != "")
            {
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today.AddMonths(-1));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate, createRequirementModel.str_T1_Date_StartDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //End Date

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today.AddMonths(3));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            // Console.WriteLine("Testing on 1");

            //Work Location *
            if (createRequirementModel.str_T1_Select_Worklocation_workLocationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_Worklocation_workLocationID, createRequirementModel.str_T1_Select_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Site Location *
            if (createRequirementModel.str_T1_select_SiteLocation_siteLocationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_SiteLocation_siteLocationID, createRequirementModel.str_T1_select_SiteLocation_siteLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Work Location Address *
            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                }
            }
        }

        public static void ClientRequirementYP(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_select_OrganizationName_organizationID)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            //Organization Name 
            if (createRequirementModel.str_T1_select_OrganizationName_organizationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_OrganizationName_organizationID, createRequirementModel.str_T1_select_OrganizationName_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Service Method
            if (createRequirementModel.str_T1_select_ServiceMethod_serviceMethodID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ServiceMethod_serviceMethodID, createRequirementModel.str_T1_select_ServiceMethod_serviceMethodID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //RC Code
            if (createRequirementModel.str_T1_Typeahead_RCCode_deptNumber != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_RCCode_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_RCCode_deptNumber, createRequirementModel.str_T1_Typeahead_RCCode_deptNumber);
                //  Thread.Sleep(2000);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_RCCode_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_RCCode_deptNumber, createRequirementModel.str_T1_Typeahead_RCCode_deptNumber);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_RCCode_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, "a");
                        // return results;
                    }
                }
            }

            //RC Description - Disabled

            //Requestor
            if (createRequirementModel.str_T1_Typeahead_Requestor_hiringManager != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_hiringManager, createRequirementModel.str_T1_Typeahead_Requestor_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_hiringManager, createRequirementModel.str_T1_Typeahead_Requestor_hiringManager);
                    //  return results;
                }
            }

            //Alternate Requestor
            if (createRequirementModel.str_T1_Typeahead_AlternateRequestor_altHiringManager != "")
            {
                Thread.Sleep(3000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_AlternateRequestor_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_AlternateRequestor_altHiringManager, createRequirementModel.str_T1_Typeahead_AlternateRequestor_altHiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_AlternateRequestor_altHiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_AlternateRequestor_altHiringManager, createRequirementModel.str_T1_Typeahead_AlternateRequestor_altHiringManager);
                    //  return results;
                }
            }

            //Account Code
            if (createRequirementModel.str_T1_select_AccountCode_programId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_AccountCode_programId, createRequirementModel.str_T1_select_AccountCode_programId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_AccountCode_programId)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //justification to Hire
            if (createRequirementModel.str_T1_txt_JustificationtoHire_JustificationtoHire != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_JustificationtoHire_JustificationtoHire, createRequirementModel.str_T1_txt_JustificationtoHire_JustificationtoHire, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //Work Week 
            if (createRequirementModel.str_T1_select_WorkWeek_workScheduleID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_WorkWeek_workScheduleID, createRequirementModel.str_T1_select_WorkWeek_workScheduleID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Number of Resources - Disabled
            //if (createRequirementModel.strTxtNumberofResources != "")
            //{
            //    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txtnoofresources, createRequirementModel.strTxtNumberofResources, false);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        // return results;
            //    }
            //}

            objCommonMethods.Action_Page_Down(WDriver);
            //Needed Date *
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_NeededDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_NeededDate_neededStartDate != "")
            {
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_NeededDate_neededStartDate, createRequirementModel.str_T1_Date_NeededDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //End Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today.AddDays(60));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }


            //Work Location  
            if (createRequirementModel.str_T1_Select_Worklocation_workLocationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_Worklocation_workLocationID, createRequirementModel.str_T1_Select_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //YP Company
            if (createRequirementModel.str_T1_select_YPCompany_siteLocationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_YPCompany_siteLocationID, createRequirementModel.str_T1_select_YPCompany_siteLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Work Location Address
            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Reason to Hire 
            if (createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoHire_reasonToHireID, createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
        }

        public static void ClientRequirementLear(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_Typeahead_HiringManager_hiringManager))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_Typeahead_HiringManager_hiringManager)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }



            // Hiring Manager
            if (createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager, createRequirementModel.str_T1_Typeahead_HiringManager_hiringManager);
                    //  return results;
                }
            }

            // Requestor
            if (createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                    //  return results;
                }
            }

            //HR Department 
            if (createRequirementModel.str_T1_Select_HRDepartment_deptNumber != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_HRDepartment_deptNumber, createRequirementModel.str_T1_Select_HRDepartment_deptNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_Select_HRDepartment_deptNumber))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Location Code
            if (createRequirementModel.str_T1_Select_LocationCode_siteLocationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_LocationCode_siteLocationID, createRequirementModel.str_T1_Select_LocationCode_siteLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_Select_LocationCode_siteLocationID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Account Code 
            if (createRequirementModel.str_T1_Typeahead_AccountCode_CostCenterId != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_AccountCode_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_AccountCode_CostCenterId, createRequirementModel.str_T1_Typeahead_AccountCode_CostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_AccountCode_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_AccountCode_CostCenterId, createRequirementModel.str_T1_Typeahead_AccountCode_CostCenterId);
                    //  return results;
                }
            }



            //Hypersion Code /GL Unit
            if (createRequirementModel.str_T1_Select_HypersionCodeGLUnit_GLId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_HypersionCodeGLUnit_GLId, createRequirementModel.str_T1_Select_HypersionCodeGLUnit_GLId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_Select_HypersionCodeGLUnit_GLId))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Business Unit
            if (createRequirementModel.str_T1_Select_BusinessUnit_organizationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_BusinessUnit_organizationID, createRequirementModel.str_T1_Select_BusinessUnit_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_Select_BusinessUnit_organizationID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Number of Resources *
            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //AP Department 
            if (createRequirementModel.str_T1_Typeahead_APDepartment_deptName != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_APDepartment_deptName, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_APDepartment_deptName, createRequirementModel.str_T1_Typeahead_APDepartment_deptName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_APDepartment_deptName, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_APDepartment_deptName, createRequirementModel.str_T1_Typeahead_APDepartment_deptName);
                    //  return results;
                }
            }

            //CORE
            if (createRequirementModel.str_T1_Select_CORE_ProjectId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_CORE_ProjectId, createRequirementModel.str_T1_Select_CORE_ProjectId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_Select_CORE_ProjectId))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }





            // Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_StartDate_neededStartDate != "")
            {
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today.AddMonths(-1));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate, createRequirementModel.str_T1_Date_StartDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //End Date

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today.AddMonths(3));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            Thread.Sleep(2000);


            //Work Location 
            if (createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                    //  return results;
                }
            }


            // Work Location Address 
            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead_LocationAddress_New(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Reason for Hire *
            if (createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoHire_reasonToHireID, createRequirementModel.str_T1_select_ReasonForHire_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_ReasonForHire_reasonToHireID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }



        }

        #region EQT
        public static void ClientRequirementEQT(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_Typeahead_Engagingmanager_hiringManager))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_Typeahead_Engagingmanager_hiringManager)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            // Requestor *  
            if (createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                }
            }

            // Engaging Manager *
            if (createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Engagingmanager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Engagingmanager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager);
                    //  return results;
                }
            }

            // Company *
            if (createRequirementModel.str_T1_Typeahead_Company_deptNumber != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Company_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Company_deptNumber, createRequirementModel.str_T1_Typeahead_Company_deptNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(2000);
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Company_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Company_deptNumber, createRequirementModel.str_T1_Typeahead_Company_deptNumber);
                    //  return results;
                }
            }

            // Business Unit *   
            if (createRequirementModel.str_T1_Typeahead_BusinessUnit_organizationID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_BusinessUnit_organizationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_BusinessUnit_organizationID, createRequirementModel.str_T1_Typeahead_BusinessUnit_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_BusinessUnit_organizationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_BusinessUnit_organizationID, createRequirementModel.str_T1_Typeahead_BusinessUnit_organizationID);
                    //  return results;
                }
            }

            // Object Account *
            if (createRequirementModel.str_T1_Typeahead_ObjectAccount_GLId != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_ObjectAccount_GLId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_ObjectAccount_GLId, createRequirementModel.str_T1_Typeahead_ObjectAccount_GLId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_ObjectAccount_GLId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_ObjectAccount_GLId, createRequirementModel.str_T1_Typeahead_ObjectAccount_GLId);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }

            // Group
            if (createRequirementModel.str_T1_Select_Group_serviceMethodID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_Group_serviceMethodID, createRequirementModel.str_T1_Select_Group_serviceMethodID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_Group_serviceMethodID, 2);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Select_Group_serviceMethodID);
                    }

                }
            }

            // Work Week *
            Thread.Sleep(5000);
            if (createRequirementModel.str_T1_select_WorkWeek_ProjectId != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_WorkWeek_ProjectId, createRequirementModel.str_T1_select_WorkWeek_ProjectId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_WorkWeek_ProjectId, 2);
                }
            }

            // Reason to Engage *
            if (createRequirementModel.str_T1_select_ReasontoEngage_reasonToHireID != "")
            {
                results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoEngage_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {

                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoEngage_reasonToHireID, 2);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoEngage_reasonToHireID, createRequirementModel.str_T1_select_ReasontoEngage_reasonToHireID);
                    }
                }
            }

            // Start Date *
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate);

            results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                kwm.click(WDriver, KeyWords.locator_XPath, "//*[@class='ui-datepicker-calendar']//a");
            }

            // Enddate *           
            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today.AddMonths(3));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);
                    results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today.AddMonths(6));
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);
                        results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today.AddMonths(9));
                    }
                }
            }

            // Number of Resources *
            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Work Location *
            if (createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            // Work Location Address *
            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Justification
            if (createRequirementModel.str_T1_txt_Justification_JustificationtoHire != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_Justification_JustificationtoHire, createRequirementModel.str_T1_txt_Justification_JustificationtoHire, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            // Does the CW have IT or Facilities needs? *
            if (createRequirementModel.str_T1_select_DoestheCWhaveITorFacilitiesneeds_siteLocationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_DoestheCWhaveITorFacilitiesneeds_siteLocationID, createRequirementModel.str_T1_select_DoestheCWhaveITorFacilitiesneeds_siteLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_DoestheCWhaveITorFacilitiesneeds_siteLocationID, 2);

                }
            }

            // Will CW Access PII? *
            if (createRequirementModel.str_T1_btn_WillCWAccessPII_laborClassCode != "")
            {
                if (createRequirementModel.str_T1_btn_WillCWAccessPII_laborClassCode.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_WillCWAccessPII_laborClassCode79);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_WillCWAccessPII_laborClassCode80);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_btn_WillCWAccessPII_laborClassCode80);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }



        }
        #endregion EQT

        public static void ClientRequirementSIGMA(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_T1_Typeahead_HiringManager_hiringManager))));
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_Typeahead_HiringManager_hiringManager)).Displayed)
                        {
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }
            }

            // Requestor
            if (createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Requestor_CreatedUserID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID, createRequirementModel.str_T1_Typeahead_Requestor_CreatedUserID);
                    //  return results;
                }
            }


            // Engaging Manager
            if (createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_EngagingManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_EngagingManager_hiringManager, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager, createRequirementModel.str_T1_Typeahead_EngagingManager_hiringManager);
                    //  return results;
                }
            }


            //Service Method *
            if (createRequirementModel.str_T1_select_ServiceMethod_serviceMethodID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ServiceMethod_serviceMethodID, createRequirementModel.str_T1_select_ServiceMethod_serviceMethodID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_ServiceMethod_serviceMethodID))); //Locating select list
                        se.SelectByIndex(2);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Organization Name
            if (createRequirementModel.str_T1_Typeahead_OrganizationName_organizationID != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_OrganizationName_organizationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_OrganizationName_organizationID, createRequirementModel.str_T1_Typeahead_OrganizationName_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_OrganizationName_organizationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_OrganizationName_organizationID, createRequirementModel.str_T1_Typeahead_OrganizationName_organizationID);
                    //  return results;
                }
            }

            //Company
            if (createRequirementModel.str_T1_Typeahead_Company_deptNumber != "")
            {

                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Company_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Company_deptNumber, createRequirementModel.str_T1_Typeahead_Company_deptNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(2000);
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Company_deptNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Company_deptNumber, createRequirementModel.str_T1_Typeahead_Company_deptNumber);
                    //  return results;
                }
            }

            //Cost Center *
            if (createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId != "")
            {
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_CostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(2000);
                    results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_CostCenter_CostCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId, createRequirementModel.str_T1_Typeahead_CostCenter_CostCenterId);
                    //  return results;
                }
            }

            //GL Account

            if (createRequirementModel.str_T1_select_GLAccount_GLId != "")
            {
                //Thread.Sleep(2000);
                for (int i = 0; i < 100; i++)
                {
                    try
                    {
                        if (WDriver.FindElement(By.Id(KeyWords.ID_T1_select_GLAccount_GLId)).Enabled)
                        {
                            break;
                        }
                        Thread.Sleep(1000);
                    }
                    catch
                    {
                    }
                }
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_GLAccount_GLId, createRequirementModel.str_T1_select_GLAccount_GLId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_GLAccount_GLId, createRequirementModel.str_T1_select_GLAccount_GLId);
                    //  return results;
                }
            }




            //Profit Center
            if (createRequirementModel.str_T1_Typehead_ProfitCenter_ProfitCenterId != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typehead_ProfitCenter_ProfitCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typehead_ProfitCenter_ProfitCenterId, createRequirementModel.str_T1_Typehead_ProfitCenter_ProfitCenterId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typehead_ProfitCenter_ProfitCenterId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typehead_ProfitCenter_ProfitCenterId, createRequirementModel.str_T1_Typehead_ProfitCenter_ProfitCenterId);
                    //  return results;
                }
            }

            //WBS Element 
            if (createRequirementModel.str_T1_Typeahead_WBSElement_ProjectId != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WBSElement_ProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WBSElement_ProjectId, createRequirementModel.str_T1_Typeahead_WBSElement_ProjectId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WBSElement_ProjectId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WBSElement_ProjectId, createRequirementModel.str_T1_Typeahead_WBSElement_ProjectId);
                    //  return results;
                }
            }

            //Matrix Number 
            if (createRequirementModel.str_T1_Typeahead_MatrixNumber_matrixNumber != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_MatrixNumber_matrixNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_MatrixNumber_matrixNumber, createRequirementModel.str_T1_Typeahead_MatrixNumber_matrixNumber);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_MatrixNumber_matrixNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_MatrixNumber_matrixNumber, createRequirementModel.str_T1_Typeahead_MatrixNumber_matrixNumber);
                    //  return results;
                }
            }

            //Program Name 

            if (createRequirementModel.str_T1_Typeahead_ProgramName_programId != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_ProgramName_programId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_ProgramName_programId, createRequirementModel.str_T1_Typeahead_ProgramName_programId);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_ProgramName_programId, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_ProgramName_programId, createRequirementModel.str_T1_Typeahead_ProgramName_programId);
                    //  return results;
                }
            }

            // Start Date
            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate);

            if (createRequirementModel.str_T1_Date_StartDate_neededStartDate != "")
            {
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today.AddMonths(-1));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_StartDate_neededStartDate, createRequirementModel.str_T1_Date_StartDate_neededStartDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //End Date

            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate);

            if (createRequirementModel.str_T1_Date_EndDate_enddate != "")
            {
                results = kwm.Select_Date_From_Picker(WDriver, DateTime.Today.AddMonths(3));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Date_EndDate_enddate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            //Work Location 
            if (createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID != "")
            {
                Thread.Sleep(2000);
                results = kwm.select_List_typeahead(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_Worklocation_workLocationID, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID, createRequirementModel.str_T1_Typeahead_Worklocation_workLocationID);
                    //  return results;
                }
            }


            // Work Location Address 
            if (createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress != "")
            {
                results = kwm.select_List_typeahead_LocationAddress(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_WorkLocationAddress_workLocationAddress, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress, createRequirementModel.str_T1_Typeahead_WorkLocationAddress_workLocationAddress);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Reason for Hire *
            if (createRequirementModel.str_T1_select_ReasontoHire_reasonToHireID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_ReasontoHire_reasonToHireID, createRequirementModel.str_T1_select_ReasonForHire_reasonToHireID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T1_select_ReasonForHire_reasonToHireID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }



            //Number of Resources *
            if (createRequirementModel.str_T1_Txt_NumberofResources_noofresources != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Txt_NumberofResources_noofresources, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            //Justification
            if (createRequirementModel.str_T1_txt_Justification_JustificationtoHire != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_txt_Justification_JustificationtoHire, createRequirementModel.str_T1_txt_Justification_JustificationtoHire, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

        }


    }
}