// --------------------------------------------------------------------------------------------------------------------
//<copyright file="CreateRequirement.cs" company="DCR Workforce Inc">
//   Copyright (c) DCR Workforce Inc. All rights reserved.
//   This code and information should not be copied and used outside of DCR Workforce Inc.
// </copyright>
// <summary>
//   Builds the Container for the Autofac IOC.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using SmartTrack.DataAccess.Models;
using SmartTrack.DataAccess.Repository;
using SmartTrack;

namespace SmartTrack
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SmartTrack_Automation;
    using System;
    using System.Threading;
    using System.Windows.Forms;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections.ObjectModel;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using System.Text.RegularExpressions;
    using System.IO;
    using System.Data;
    using System.Configuration;
    using System.Net;
    using System.Collections;
    using CommonFiles;
    using RelevantCodes.ExtentReports;


    public class CreateRequirementPerClientJobTab
    {

        #region SunTrust
        public static void ClientRequirementSunTrust(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {



            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_T2_select_LaborCategory_typeofServiceID), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_T2_select_LaborCategory_typeofServiceID), kwm._WDWait);

            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");

            //Labor Category *

            if (createRequirementModel.str_T2_select_LaborCategory_typeofServiceID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_LaborCategory_typeofServiceID, createRequirementModel.str_T2_select_LaborCategory_typeofServiceID);

                if (results.Result1 == KeyWords.Result_FAIL)
                {


                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_selecttypeofServiceID, createRequirementModel.strSelectTypeofService);
                    SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_selecttypeofServiceID))); //Locating select list
                    se.SelectByIndex(1);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {

                        results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_selecttypeofServiceID);
                    }
                }
            }


            Thread.Sleep(100);
            //Job Title *
            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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

            //Gl Account - Disabled
            if (createRequirementModel.str_T2_Select_GLAccount_GLIdJD != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Select_GLAccount_GLIdJD, createRequirementModel.str_T2_Select_GLAccount_GLIdJD);

                if (results.Result1 == KeyWords.Result_FAIL)
                {


                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Select_GLAccount_GLIdJD, createRequirementModel.str_T2_Select_GLAccount_GLIdJD);
                    SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_Select_GLAccount_GLIdJD))); //Locating select list
                    se.SelectByIndex(1);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {

                        results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Select_GLAccount_GLIdJD);
                    }
                }
            }

            //Business or Organization Name * - Disabeld
            if (createRequirementModel.str_T2_Select_Business_organizationID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Select_Business_organizationID, createRequirementModel.str_T2_Select_Business_organizationID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {

                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Select_Business_organizationID, 1);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Select_Business_organizationID);
                    }
                }
            }


            //Job Descripition
            //createRequirementModel.strTextAreaJobDescription

            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Desired Skills

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false, KeyWords.Type_Table);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false, KeyWords.Type_Table);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID, KeyWords.Type_table_radio_button);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID, KeyWords.Type_Table);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID, KeyWords.Type_Table);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false, KeyWords.Type_Table);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue, KeyWords.Type_table_radio_button);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse, KeyWords.Type_table_radio_button);


            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse, KeyWords.Type_table_radio_button);
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue, KeyWords.Type_table_radio_button);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency, KeyWords.Type_Popup);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    ////div class    ui-dialog-buttonset

                    //results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.strButton_Recurring_Frequency_MSG_Box_Action_Button);
                    //if (results.Result1 == KeyWords.Result_FAIL)
                    //{
                    //    //  return results;
                    //}
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse, KeyWords.Type_table_radio_button);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Travel Required 
            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue, KeyWords.Type_radio_button);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelLocation_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelDescription_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse, KeyWords.Type_radio_button);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse, KeyWords.Type_radio_button);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //OT Multipler - Disabled 



            //Shift:
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID);
                }
            }

            //Travel and Ancillary Expenses

            if (createRequirementModel.str_T2_btn_TravelandAncillaryExpensesyes_expenses != "")
            {
                if (createRequirementModel.strRadiobtnRateNegotiable.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesyes_expensesTrue, KeyWords.Type_radio_button);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    if (createRequirementModel.str_T2_txt_EstimatedExpenseAmountperResource_expenseFixedAmount != "")
                    {
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesNO_expensesFalse, createRequirementModel.str_T2_txt_EstimatedExpenseAmountperResource_expenseFixedAmount, true);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesNO_expensesFalse, KeyWords.Type_radio_button);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
            }
            else
            {

                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesNO_expensesFalse, KeyWords.Type_radio_button);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }







            //Use Start and End Date, assuming 40 hours per week + anticipated OT
            if (createRequirementModel.str_T2_btn_RateInformation_rdtypeoption == "1")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateInformation_rdtypeoption1, KeyWords.Type_radio_button);
            }
            //Estimated Number of Hours per Resource for the Contract Period
            if (createRequirementModel.str_T2_btn_RateInformation_rdtypeoption == "2")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateInformation_rdtypeoption3, KeyWords.Type_radio_button);
            }
            //Use Start and End Date, assuming less than 40 hours per week
            if (createRequirementModel.str_T2_btn_RateInformation_rdtypeoption == "3")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateInformation_rdtypeoption2, KeyWords.Type_radio_button);
            }
            //No calculation needed (flat dollar amount entered for full labor and expense cost)
            if (createRequirementModel.str_T2_btn_RateInformation_rdtypeoption == "4")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateInformation_rdtypeoption4, KeyWords.Type_radio_button);
            }

            ///Estimated # of Regular Hours/Week:
            if (createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Estimated Total # of Hours      approvedTotalHours
            if (createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_EstimatedTotalofHours_approvedTotalHours, createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }






            //Rate Type   rateTypeID



            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Not to Exceed Bill Rate
            if (createRequirementModel.str_T2_Txt_NottoExceedBillRate_billRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Txt_NottoExceedBillRate_billRateHigh, createRequirementModel.str_T2_Txt_NottoExceedBillRate_billRateHigh, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }


            //Estimated Contract Value
            if (createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_t2_txt_EstimatedContractValue_estContractValue, createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }







        }
        #endregion SunTrust
        public static void ClientRequirementColgate(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_JobCategories_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_SaveContinue_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_T2_select_JobCategories_typeofServiceID), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_T2_select_JobCategories_typeofServiceID), kwm._WDWait);

            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");

            //job Categories *

            if (createRequirementModel.str_T2_select_JobCategories_typeofServiceID != "")
            {
                results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_JobCategories_typeofServiceID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {

                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_JobCategories_typeofServiceID, createRequirementModel.str_T2_select_JobCategories_typeofServiceID);
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_JobCategories_typeofServiceID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Job Title

            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
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

            //Job Description 


            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);

            for (int z = 1; z < 500; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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
                Thread.Sleep(500);
            }


            //Skill Mandatory
            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //SKill Desired
            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }


            //SKill Name
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }


            //Skill Description

            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //SKill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Years

            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            //Additional Information Data
            // category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                    //  return results;
                }
            }

            // Description

            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            //objCommonMethods.Action_Page_Down(WDriver);
            //IJavaScriptExecutor jse = (IJavaScriptExecutor)WDriver;
            //jse.ExecuteScript("window.scrollBy(0,250)", "");
            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    ////div class    ui-dialog-buttonset

                    //results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.strButton_Recurring_Frequency_MSG_Box_Action_Button);
                    //if (results.Result1 == KeyWords.Result_FAIL)
                    //{
                    //    //  return results;
                    //}
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            //Exempt/Non-Exempt

            if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Exempt_exemptTrue);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
            }


            //Shift
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID);
                }
            }



            //Travel and Ancillary Expenses

            if (createRequirementModel.str_T2_btn_TravelandAncillaryExpensesyes_expenses != "")
            {
                if (createRequirementModel.strRadiobtnRateNegotiable.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesyes_expensesTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    if (createRequirementModel.str_T2_txt_EstimatedExpenseAmountperResource_expenseFixedAmount != "")
                    {
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesNO_expensesFalse, createRequirementModel.str_T2_txt_EstimatedExpenseAmountperResource_expenseFixedAmount, true);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesNO_expensesFalse);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
            }
            else
            {

                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesNO_expensesFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);

            //Use Start and End Date, assuming 40 hours per week + anticipated OT
            if (createRequirementModel.str_T2_Radiobutton_strTxt_ContractValueCalculation_rdtypeoption1 == "1")
            {
                kwm.click(WDriver, KeyWords.locator_ID, "rdtypeoption1");
            }
            //Estimated Number of Hours per Resource for the Contract Period
            if (createRequirementModel.str_T2_Radiobutton_strTxt_ContractValueCalculation_rdtypeoption2 == "2")
            {
                kwm.click(WDriver, KeyWords.locator_ID, "rdtypeoption3");
            }
            //Use Start and End Date, assuming less than 40 hours per week
            if (createRequirementModel.str_T2_Radiobutton_strTxt_ContractValueCalculation_rdtypeoption3 == "3")
            {
                kwm.click(WDriver, KeyWords.locator_ID, "rdtypeoption2");
            }
            //No calculation needed (flat dollar amount entered for full labor and expense cost)
            if (createRequirementModel.str_T2_Radiobutton_strTxt_ContractValueCalculation_rdtypeoption4 == "4")
            {
                kwm.click(WDriver, KeyWords.locator_ID, "rdtypeoption4");
            }









            //Anticipated average OT per week:     hasOTHours
            if (createRequirementModel.str_T2_txt_AnticipatedaverageOTperweek_hasOTHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_AnticipatedaverageOTperweek_hasOTHours, createRequirementModel.str_T2_txt_AnticipatedaverageOTperweek_hasOTHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            ///Estimated # of Regular Hours/Week:
            if (createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Estimated Total # of Hours      approvedTotalHours
            if (createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_EstimatedTotalofHours_approvedTotalHours, createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }






            //Rate Type   rateTypeID



            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }








            objCommonMethods.Action_Page_Down(WDriver);
            IJavaScriptExecutor jse1 = (IJavaScriptExecutor)WDriver;
            jse1.ExecuteScript("window.scrollBy(0,250)", "");



            // Bill Rate Range: 

            //Billrate  Min
            if (createRequirementModel.str_T2_txt_Billratelow_billRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow, createRequirementModel.str_T2_txt_Billratelow_billRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }




            //Billrate  Max
            if (createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //Estimated Total Labor and Expense Cost:
            if (createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_t2_txt_EstimatedContractValue_estContractValue, createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


        }

        public static void ClientRequirementCpchem(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_SaveContinue_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID), kwm._WDWait);

            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");

            //Type of Service *

            if (createRequirementModel.str_T2_Select_TypeofService_typeofServiceID != "")
            {
                results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_TypeofService_typeofServiceID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {

                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_TypeofService_typeofServiceID, createRequirementModel.str_T2_Select_TypeofService_typeofServiceID);
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Job Title

            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
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

            //Job Description 


            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            for (int z = 1; z < 500; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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
                Thread.Sleep(500);
            }


            //Skill Mandatory
            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //SKill Desired
            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //SKill Name
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }


            //Skill Description

            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //SKill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Years

            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            //Additional Information Data
            // category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                    //  return results;
                }
            }

            // Description

            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)WDriver;
            jse.ExecuteScript("window.scrollBy(0,250)", "");
            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    ////div class    ui-dialog-buttonset

                    //results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.strButton_Recurring_Frequency_MSG_Box_Action_Button);
                    //if (results.Result1 == KeyWords.Result_FAIL)
                    //{
                    //    //  return results;
                    //}
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            //Exempt/Non-Exempt

            if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Exempt_exemptTrue);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
            }

            //Ot Allowed

            if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otTrue);
                    //Ot Limitation

                    if (createRequirementModel.str_T2_Radiobutton_OtLimitation_OtLimit.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitTrue);

                        //Maximum Overtime Hours Approved per week: *

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, createRequirementModel.str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, false);
                        //is pre approval required when ot hrs exceeds
                        if (createRequirementModel.str_T2_Radiobutton_OtPerTrue_OtpreTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreTrue);
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreFalse);
                        }

                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitFalse);
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                }

            }


            //Travel Required
            if (createRequirementModel.str_T2_Radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.strRadiobtnTravelRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue);
                    //Travel Location
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelLocation_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    //Travel Description
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelDescription_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                }

            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);

            }


            //Use Start and End Date, assuming 40 hours per week + anticipated OT
            if (createRequirementModel.str_T2_Radiobutton_strTxt_ContractValueCalculation_rdtypeoption1 == "1")
            {
                kwm.click(WDriver, KeyWords.locator_ID, "rdtypeoption1");
            }
            //Estimated Number of Hours per Resource for the Contract Period
            if (createRequirementModel.str_T2_Radiobutton_strTxt_ContractValueCalculation_rdtypeoption2 == "2")
            {
                kwm.click(WDriver, KeyWords.locator_ID, "rdtypeoption3");
            }
            //Use Start and End Date, assuming less than 40 hours per week
            if (createRequirementModel.str_T2_Radiobutton_strTxt_ContractValueCalculation_rdtypeoption3 == "3")
            {
                kwm.click(WDriver, KeyWords.locator_ID, "rdtypeoption2");
            }
            //No calculation needed (flat dollar amount entered for full labor and expense cost)
            if (createRequirementModel.str_T2_Radiobutton_strTxt_ContractValueCalculation_rdtypeoption4 == "4")
            {
                kwm.click(WDriver, KeyWords.locator_ID, "rdtypeoption4");
            }









            //Anticipated average OT per week:     hasOTHours
            if (createRequirementModel.str_T2_txt_AnticipatedaverageOTperweek_hasOTHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_AnticipatedaverageOTperweek_hasOTHours, createRequirementModel.str_T2_txt_AnticipatedaverageOTperweek_hasOTHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            ///Estimated # of Regular Hours/Week:
            if (createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Estimated Total # of Hours      approvedTotalHours
            if (createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_EstimatedTotalofHours_approvedTotalHours, createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }






            //Rate Type   rateTypeID



            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }








            objCommonMethods.Action_Page_Down(WDriver);
            IJavaScriptExecutor jse1 = (IJavaScriptExecutor)WDriver;
            jse1.ExecuteScript("window.scrollBy(0,250)", "");



            // Bill Rate Range: 

            //Billrate  Min
            if (createRequirementModel.str_T2_txt_Billratelow_billRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow, createRequirementModel.str_T2_txt_Billratelow_billRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }




            //Billrate  Max
            if (createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //Estimated Total Labor and Expense Cost:
            if (createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_t2_txt_EstimatedContractValue_estContractValue, createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


        }

        public static void CreateRequirementCaesars(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_SaveContinue_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}

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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_PopUpWIN_ui_dialog_title_PleaseWaitPopup)).Displayed;
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

            //Job Descripition
            //createRequirementModel.strTextAreaJobDescription

            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Ideal Candidate

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false, KeyWords.Type_Table);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false, KeyWords.Type_Table);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID, KeyWords.Type_table_radio_button);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID, KeyWords.Type_Table);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID, KeyWords.Type_Table);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false, KeyWords.Type_Table);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue, KeyWords.Type_table_radio_button);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse, KeyWords.Type_table_radio_button);                
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse, KeyWords.Type_table_radio_button);
            }
            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue, KeyWords.Type_table_radio_button);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    ////div class    ui-dialog-buttonset

                    //results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.strButton_Recurring_Frequency_MSG_Box_Action_Button);
                    //if (results.Result1 == KeyWords.Result_FAIL)
                    //{
                    //    //  return results;
                    //}
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse, KeyWords.Type_table_radio_button);
                }

              
            }
            objCommonMethods.Action_Page_Down(WDriver);

            //Interview Required 
            if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interTrue, KeyWords.Type_radio_button);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interFalse,KeyWords.Type_radio_button);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interFalse, KeyWords.Type_radio_button);
            }

            //Travel Required 
            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue, KeyWords.Type_radio_button);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelLocation_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelDescription_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse, KeyWords.Type_radio_button);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse, KeyWords.Type_radio_button);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //OT Allowed

            if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otTrue, KeyWords.Type_radio_button);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    if (createRequirementModel.str_T2_Radiobutton_OtLimitation_OtLimit.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitTrue, KeyWords.Type_radio_button);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, createRequirementModel.str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }

                        if (createRequirementModel.str_T2_Radiobutton_OtPerTrue_OtpreTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreTrue, KeyWords.Type_radio_button);
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreFalse, KeyWords.Type_radio_button);
                        }
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitFalse, KeyWords.Type_radio_button);
                    }
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse, KeyWords.Type_radio_button);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse, KeyWords.Type_radio_button);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Exempt/Non Exempt *
            if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Exempt_exemptTrue, KeyWords.Type_radio_button);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse, KeyWords.Type_radio_button);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse, KeyWords.Type_radio_button);
            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Shift
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID);
                }
            }

            if (createRequirementModel.strtxtEstWeeklyHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_EstWeeklyHours, createRequirementModel.strtxtEstWeeklyHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            Thread.Sleep(2000);
            try
            {
                WDriver.FindElement(By.XPath(KeyWords.Xpath_RadioBtn_rdtypeoption)).Click();
            }
            catch
            {
                //
            }
            try
            {
                WDriver.FindElement(By.XPath(KeyWords.Xpath_RadioBtn_rdtypeoption1)).Click();
            }
            catch
            {
                //
            }
            objCommonMethods.Action_Page_Down(WDriver);

            ///Estimated # of Regular Hours/Week:
            if (createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Estimated Total # of Hours      approvedTotalHours
            if (createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_EstimatedTotalofHours_approvedTotalHours, createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }



            objCommonMethods.Action_Page_Down(WDriver);


            //Rate Type   rateTypeID



            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }








            objCommonMethods.Action_Page_Down(WDriver);
            IJavaScriptExecutor jse1 = (IJavaScriptExecutor)WDriver;
            jse1.ExecuteScript("window.scrollBy(0,250)", "");

            // Pay Rate Range: 

            //Payrate  Min
            if (createRequirementModel.str_T2_txt_PayRateLow_payRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_PayRateLow_payRateLow, createRequirementModel.str_T2_txt_PayRateLow_payRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }




            //Payrate  Max
            if (createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T2_txt_PayRateHigh_payRateHigh, createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Bill Rate Range: 

            ////Billrate  Min
            //if (createRequirementModel.str_T2_txt_Billratelow_billRateLow != "")
            //{
            //    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow, createRequirementModel.str_T2_txt_Billratelow_billRateLow, true);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        //  return results;
            //    }
            //}




            //Billrate  Max
            //if (createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh != "")
            //{

            //    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, true);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        // return results;
            //    }
            //}


            //Estimated Total Labor and Expense Cost:
            //if (createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue != "")
            //{
            //    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_t2_txt_EstimatedContractValue_estContractValue, createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue, true);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        // return results;
            //    }
            //}
            // Bill Rate Range: 

            var WriteExlResult = new Result();
            ReadExcel ReadExcelHelper = new ReadExcel();

            results = kwm.GetText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow);
            String strUpdateSqlMain_minvalue = "Update [MSP$] set P61 ='" + results.ErrorMessage + "'  WHERE P3 ='" + createRequirementModel.strClientName + "' and TestScenario ='001' and TestCaseID = '001'";
            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain_minvalue);


            results = kwm.GetText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh);
            String strUpdateSqlMain_maxvalue = "Update [MSP$] set P62 ='" + results.ErrorMessage + "'  WHERE P3 ='" + createRequirementModel.strClientName + "' and TestScenario ='001' and TestCaseID = '001'";
            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain_maxvalue);

            //objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, " value is not matched: " + estimatedValue + "", 3);
            results = kwm.GetText(WDriver, KeyWords.locator_ID, KeyWords.ID_t2_txt_EstimatedContractValue_estContractValue);
            String strUpdateSqlMain_ECV = "Update [MSP$] set P63 ='" + results.ErrorMessage + "'  WHERE P3 ='" + createRequirementModel.strClientName + "' and TestScenario ='001' and TestCaseID = '001'";
            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain_ECV);
            createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue = results.ErrorMessage;
            //Estimated value calculation
            results = kwm.Estimatedcontractorvalue(WDriver, createRequirementModel.str_T1_Date_EndDate_enddate, createRequirementModel.str_T1_Txt_NumberofResources_noofresources, "40", "7", createRequirementModel.strtxtBillRateMax);

            if (results._Var == createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue)
            {
                ReportHandler._getChildTest().Log(LogStatus.Pass, "Contract Value is matched in Review & Submit tab");
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, " value is  matched: ", 3);
            }
            else
            {
                ReportHandler._getChildTest().Log(LogStatus.Fail, "Contract Value is not mismatch in Review & Submit tab");
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, " value is not matched: ", 3);
            }
		
            //Rate Negotiable 
            if (createRequirementModel.str_T2_Radiobutton_RateNegotiable_rateNego != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_RateNegotiable_rateNego.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_RateNegotiable_rateNegoTrue, KeyWords.Type_radio_button);


                    //Submit resumes with higher rates?
                    if (createRequirementModel.str_T2_Radiobutton_SubmitResumeswithHigherRates_rateCon.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_SubmitResumeswithHigherRates_rateConTrue, KeyWords.Type_radio_button);

                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_SubmitResumeswithHigherRates_rateConFalse, KeyWords.Type_radio_button);
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_RateNegotiable_rateNegoFalse, KeyWords.Type_radio_button);
                }

            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_RateNegotiable_rateNegoFalse, KeyWords.Type_radio_button);

            }


        }

        public static void CreateRequirementDyncorp(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}


            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID), kwm._WDWait);

            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");

            //Type of Service *
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
            }


            Thread.Sleep(100);
            //Job Title *
            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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

            //createRequirementModel.strTextAreaJobDescription
            //Job description 
            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Skill Desired

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //Interview Required 
            if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Travel Required 
            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelLocation_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelDescription_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //OT Allowed

            if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    if (createRequirementModel.str_T2_Radiobutton_OtLimitation_OtLimit.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitTrue);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, createRequirementModel.str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }

                        if (createRequirementModel.str_T2_Radiobutton_OtPerTrue_OtpreTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreTrue);
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreFalse);
                        }
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitFalse);
                    }
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);


            //Shift
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //% Amount 

            if (createRequirementModel.str_T2_Amount_shiftDiffPercent != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Amount_shiftDiffPercent, createRequirementModel.str_T2_Amount_shiftDiffPercent, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Rate Type   rateTypeID

            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }
            //PayRate Min *
            if (createRequirementModel.str_T2_txt_PayRateLow_payRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_PayRateLow_payRateLow, createRequirementModel.str_T2_txt_PayRateLow_payRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //PayRate Max *
            if (createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T2_txt_PayRateHigh_payRateHigh, createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Bill rate - Min - Disabled

            //Bill rate - Max - Disabled

            //Estimated Contract Value -  Disabled

        }

        #region Keybank
        public static void ClientRequirementKeybank(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(500);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}

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
            }


            Thread.Sleep(500);
            //Job Title
            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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
                Thread.Sleep(500);
            }

            //Job Description

            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            // Upload Job Description: -- Non Manditory field

            // Enter file name to save the recording: -- Non Manditory field


            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }


            // SKill Desired
            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }


            // Mandatory (Yes/No)

            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    ////div class    ui-dialog-buttonset

                    //results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.strButton_Recurring_Frequency_MSG_Box_Action_Button);
                    //if (results.Result1 == KeyWords.Result_FAIL)
                    //{
                    //    //  return results;
                    //}
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            // objCommonMethods.Action_Page_Down(WDriver);

            //Interview Required 
            if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Travel Required 
            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelLocation_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelDescription_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //OT Allowed

            if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    if (createRequirementModel.str_T2_Radiobutton_OtLimitation_OtLimit.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitTrue);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, createRequirementModel.str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }

                        if (createRequirementModel.str_T2_Radiobutton_OtPerTrue_OtpreTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreTrue);
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreFalse);
                        }
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitFalse);
                    }
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //Shift:
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Use Start and End Date, assuming 40 hours per week + anticipated OT
            if (createRequirementModel.strTxt_ContractValueCalculation_rdtypeoption == "1")
            {
                kwm.click(WDriver, KeyWords.locator_ID, "rdtypeoption1");
            }
            //Estimated Number of Hours per Resource for the Contract Period
            if (createRequirementModel.strTxt_ContractValueCalculation_rdtypeoption == "2")
            {
                kwm.click(WDriver, KeyWords.locator_ID, "rdtypeoption3");
            }
            //Use Start and End Date, assuming less than 40 hours per week
            if (createRequirementModel.strTxt_ContractValueCalculation_rdtypeoption == "3")
            {
                kwm.click(WDriver, KeyWords.locator_ID, "rdtypeoption2");
            }
            //No calculation needed (flat dollar amount entered for full labor and expense cost)
            if (createRequirementModel.strTxt_ContractValueCalculation_rdtypeoption == "4")
            {
                kwm.click(WDriver, KeyWords.locator_ID, "rdtypeoption4");
            }


            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Rate Type   rateTypeID

            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }
            //Bill Rate min *
            if (createRequirementModel.str_T2_txt_Billratelow_billRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow, createRequirementModel.str_T2_txt_Billratelow_billRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
            //Bill Rate max *
            if (createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Button_Tab(WDriver);
            //Estimated Contract Value *
            if (createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_t2_txt_EstimatedContractValue_estContractValue, createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

        }
        #endregion Keybank


        public static void CreateRequirementAltria(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_SaveContinue_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}


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
            }

            Thread.Sleep(100);
            if (createRequirementModel.str_T2_Typeahead_JobCategory_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobCategory_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobCategory_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobCategory_txtJobTitle);
                //  Thread.Sleep(2000);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobCategory_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobCategory_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobCategory_txtJobTitle);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobCategory_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, "a");
                        // return results;
                    }
                }
            }


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_PopUpWIN_ui_dialog_title_PleaseWaitPopup)).Displayed;
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

            //Assignment Description
            if (createRequirementModel.str_T2_txt_AssignmentDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_AssignmentDescription_jobDescription, createRequirementModel.str_T2_txt_AssignmentDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Skill Desired

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            objCommonMethods.Action_Button_Tab(WDriver);
            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(WDriver);
            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //  objCommonMethods.Action_Page_Down(WDriver);
            //Interview Required 
            if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Travel Required 
            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelLocation_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelDescription_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //OT Allowed

            if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    if (createRequirementModel.str_T2_Radiobutton_OtLimitation_OtLimit.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitTrue);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, createRequirementModel.str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }

                        if (createRequirementModel.str_T2_Radiobutton_OtPerTrue_OtpreTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreTrue);
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreFalse);
                        }
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitFalse);
                    }
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Shift
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //% Amount 

            if (createRequirementModel.str_T2_Amount_shiftDiffPercent != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Amount_shiftDiffPercent, createRequirementModel.str_T2_Amount_shiftDiffPercent, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Rate Type   rateTypeID

            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Bill Rate Min *
            if (createRequirementModel.str_T2_txt_Billratelow_billRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow, createRequirementModel.str_T2_txt_Billratelow_billRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Bill Rate Max *
            if (createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Estimated Contract Value - Disabled 
            //if (createRequirementModel.strtxtEstimatedContractValue != "")
            //{
            //    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_estContractValue, createRequirementModel.strtxtEstimatedContractValue, false);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        // return results;
            //    }
            //}


        }

        public static void CreateRequirementDiscover(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_SaveContinue_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}


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
            }

            //Job Title
            Thread.Sleep(100);
            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_PopUpWIN_ui_dialog_title_PleaseWaitPopup)).Displayed;
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

            //Job Descripition
            //createRequirementModel.strTextAreaJobDescription

            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Ideal Candidate

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    ////div class    ui-dialog-buttonset

                    //results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.strButton_Recurring_Frequency_MSG_Box_Action_Button);
                    //if (results.Result1 == KeyWords.Result_FAIL)
                    //{
                    //    //  return results;
                    //}
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Interview Required 
            if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Travel Required 
            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelLocation_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelDescription_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //OT Allowed

            if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    if (createRequirementModel.str_T2_Radiobutton_OtLimitation_OtLimit.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitTrue);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, createRequirementModel.str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }

                        if (createRequirementModel.str_T2_Radiobutton_OtPerTrue_OtpreTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreTrue);
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreFalse);
                        }
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitFalse);
                    }
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Exempt/Non Exempt *
            if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Exempt_exemptTrue);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
            }


            //Shift
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID);
                }
            }
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_t2_txt_EstimatedContractValue_estContractValue);

            if (createRequirementModel.strtxtEstWeeklyHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_EstWeeklyHours, createRequirementModel.strtxtEstWeeklyHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            Thread.Sleep(2000);
            try
            {
                WDriver.FindElement(By.XPath(KeyWords.Xpath_RadioBtn_rdtypeoption)).Click();
            }
            catch
            {
                //
            }
            try
            {
                WDriver.FindElement(By.XPath(KeyWords.Xpath_RadioBtn_rdtypeoption1)).Click();
            }
            catch
            {
                //
            }
            objCommonMethods.Action_Page_Down(WDriver);

            ///Estimated # of Regular Hours/Week:
            if (createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Estimated Total # of Hours      approvedTotalHours
            if (createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_EstimatedTotalofHours_approvedTotalHours, createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }






            //Rate Type   rateTypeID



            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }








            // objCommonMethods.Action_Page_Down(WDriver);
            //IJavaScriptExecutor jse1 = (IJavaScriptExecutor)WDriver;
            //jse1.ExecuteScript("window.scrollBy(0,250)", "");

            //objCommonMethods.Action_Page_Down(WDriver);

            // Bill Rate Range: 

            //Billrate  Min
            if (createRequirementModel.str_T2_txt_Billratelow_billRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow, createRequirementModel.str_T2_txt_Billratelow_billRateLow, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }




            //Billrate  Max
            if (createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //Estimated Total Labor and Expense Cost:
            if (createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_t2_txt_EstimatedContractValue_estContractValue, createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }




        }

        public static void CreateRequirementWelchallyn(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_FunctionType_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}


            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_T2_select_FunctionType_typeofServiceID), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_T2_select_FunctionType_typeofServiceID), kwm._WDWait);

            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");

            //Function Type *
            if (createRequirementModel.str_T2_select_FunctionType_typeofServiceID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_FunctionType_typeofServiceID, createRequirementModel.str_T2_select_FunctionType_typeofServiceID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_FunctionType_typeofServiceID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Job Title *
            Thread.Sleep(100);
            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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

            //Job Description

            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Ideal Candidate
            if (createRequirementModel.str_T2_txt_IdealCandidate_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_IdealCandidate_skillDescDesired, createRequirementModel.str_T2_txt_IdealCandidate_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    ////div class    ui-dialog-buttonset

                    //results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.strButton_Recurring_Frequency_MSG_Box_Action_Button);
                    //if (results.Result1 == KeyWords.Result_FAIL)
                    //{
                    //    //  return results;
                    //}
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            // objCommonMethods.Action_Page_Down(WDriver);

            //Interview Required 
            if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Travel Required 
            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelLocation_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelDescription_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //OT Allowed

            if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    if (createRequirementModel.str_T2_Radiobutton_OtLimitation_OtLimit.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitTrue);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, createRequirementModel.str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }

                        if (createRequirementModel.str_T2_Radiobutton_OtPerTrue_OtpreTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreTrue);
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreFalse);
                        }
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitFalse);
                    }
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Exempt/Non Exempt *
            if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Exempt_exemptTrue);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Shift
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //% Amount 

            if (createRequirementModel.str_T2_Amount_shiftDiffPercent != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Amount_shiftDiffPercent, createRequirementModel.str_T2_Amount_shiftDiffPercent, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Rate Type   rateTypeID

            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }
            //Bill Rate min *
            if (createRequirementModel.str_T2_txt_Billratelow_billRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow, createRequirementModel.str_T2_txt_Billratelow_billRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
            //Bill Rate max *
            if (createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Button_Tab(WDriver);
            //Estimated Contract Value *
            if (createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_t2_txt_EstimatedContractValue_estContractValue, createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


        }

       
        #region KCPL
        public static void CreateRequirementKCPL(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (kwm.isElementDisplayed(WDriver, KeyWords.ID_selecttypeofServiceID))
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID), kwm._WDWait);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");

            // Type of Service *
            if (createRequirementModel.str_T2_Select_TypeofService_typeofServiceID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_TypeofService_typeofServiceID, createRequirementModel.str_T2_Select_TypeofService_typeofServiceID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_TypeofService_typeofServiceID, createRequirementModel.str_T2_Select_TypeofService_typeofServiceID);
                }
            }
            Thread.Sleep(1000);

            // Job Title *
            if (createRequirementModel.str_T2_TypeHead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_TypeHead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_TypeHead_JobTitle_txtJobTitle, createRequirementModel.str_T2_TypeHead_JobTitle_txtJobTitle);
                //  Thread.Sleep(2000);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_TypeHead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_TypeHead_JobTitle_txtJobTitle, createRequirementModel.str_T2_TypeHead_JobTitle_txtJobTitle);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_TypeHead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, "a");
                        // return results;
                    }
                }
            }

            // Job Description *
            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            ////Upload Job Description
            //if (createRequirementModel.str_Txt_UploadFilePath != "")
            //{

            //    if (File.Exists(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + createRequirementModel.str_Txt_UploadFilePath))
            //    {
            //        if (createRequirementModel.strBrowserName.ToLower() != Constants.Chrome)
            //        {
            //            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Link_btnresumeupload);
            //        }
            //        try
            //        {
            //            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Link_btnresumeupload_reuirement);
            //            WDriver.FindElement(By.Name(KeyWords.NAME_Link_qqfile)).SendKeys(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + createRequirementModel.str_Txt_UploadFilePath);
            //            Thread.Sleep(3000);
            //            if (createRequirementModel.strBrowserName.ToLower() == Constants.Chrome)
            //            {
            //                System.Windows.Forms.SendKeys.SendWait("{ESC}");
            //                Thread.Sleep(3000);
            //            }
            //        }
            //        catch (Exception uplod)
            //        {
            //            string strUploaderror = uplod.Message;
            //        }
            //        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Link_btnresume_sendsupplier);
            //        //Submit button for Upload job description
            //        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_class, KeyWords.locator_class_button, createRequirementModel.str_Txt_MailStation);
            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            results = kwm.select_Button(WDriver, KeyWords.locator_class, KeyWords.locator_class_button, createRequirementModel.str_Txt_MailStation);
            //            // return results;
            //        }
            //    }
            //    else
            //    {
            //        objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "The given resume path not find" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + createRequirementModel.str_Txt_UploadFilePath, 3);
            //    }
            //}

            //objCommonMethods.Action_Page_Down(WDriver);
            Thread.Sleep(2000);

            // Skills / Experience / Education
            // Desired
            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                    // return results;
                }
            }


            // Skill Matrix (+)
            // Skill Name
            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            // Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            // Level (1-5, 5 being the highest)
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            // Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }


            objCommonMethods.Action_Page_Down(WDriver);
            Thread.Sleep(2000);

            //Special Needs
            // Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            // Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);

                    //return results;
                }
            }

            // Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);
                }
            }

            // Recurring
            objCommonMethods.Action_Page_Down(WDriver);
            if (createRequirementModel.str_T2_Radiobutton_Recurring_recurringScheduleFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Recurring_recurringScheduleFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.strSelect_Recurring_Frequency_MSG_Box);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.strButton_Recurring_Frequency_MSG_Box_Action_Button);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            Thread.Sleep(2000);

            // Regular Use of a Company's Vehicle
            if (createRequirementModel.str_T2_Radio_RegularUseofaCompanyVehicle != "")
            {
                if (createRequirementModel.str_T2_Radio_RegularUseofaCompanyVehicle.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radio_interTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radio_interTrue);
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radio_interFalse);
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radio_interFalse);
                }
            }

            // Travel Required *
            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelLocation_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelDescription_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
            }
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                // return results;
            }

            // OT Required *
            if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed != "")
            {
                if (createRequirementModel.strRadiobtnOTAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    if (createRequirementModel.strRadiobtn_OT_Limitation.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitTrue);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, createRequirementModel.str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }

                        if (createRequirementModel.strRadiobtn_otPreTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreTrue);
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreFalse);
                        }
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitFalse);
                    }
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Exempt/Non-Exempt *
            if (createRequirementModel.str_T2_Radio_ExemptNonExempt != "")
            {
                if (createRequirementModel.str_T2_Radio_ExemptNonExempt.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radio_exemptTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radio_exemptTrue);
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radio_exemptFalse);
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radio_exemptFalse);
                }
            }


            // Mileage Reimbursement * 

            if (createRequirementModel.str_T2_Radio_MileageReimbursement != "")
            {
                if (createRequirementModel.str_T2_Radio_MileageReimbursement.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radio_perdiemTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radio_perdiemTrue);
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radio_perdiemFalse);
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radio_perdiemFalse);
                }
            }

            // Travel and Ancillary Expenses *
            if (createRequirementModel.str_T2_btn_TravelandAncillaryExpensesyes_expenses != "")
            {
                if (createRequirementModel.strRadiobtnRateNegotiable.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesyes_expensesTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    if (createRequirementModel.str_T2_txt_EstimatedExpenseAmountperResource_expenseFixedAmount != "")
                    {
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesNO_expensesFalse, createRequirementModel.str_T2_txt_EstimatedExpenseAmountperResource_expenseFixedAmount, true);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesNO_expensesFalse);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesNO_expensesFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
        }
        #endregion KCPL


        public static void ClientRequirementTesla(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_JobCategories_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_SaveContinue_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}


            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_T2_select_JobCategories_typeofServiceID), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_T2_select_JobCategories_typeofServiceID), kwm._WDWait);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");

            //Type of Service *

            if (createRequirementModel.str_T2_select_JobCategories_typeofServiceID != "")
            {
                results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_JobCategories_typeofServiceID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {

                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_JobCategories_typeofServiceID, createRequirementModel.str_T2_select_JobCategories_typeofServiceID);
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_JobCategories_typeofServiceID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Job Title

            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
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

            //Job Description 


            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            for (int z = 1; z < 500; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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
                Thread.Sleep(500);
            }


            //Skill Mandatory
            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //SKill Desired
            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
            objCommonMethods.Action_Button_Tab(WDriver);
            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(WDriver);

            //SKill Name
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }


            //Skill Description

            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //SKill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Years

            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            //Additional Information Data
            // category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                    //  return results;
                }
            }

            // Description

            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            //objCommonMethods.Action_Page_Down(WDriver);
            //IJavaScriptExecutor jse = (IJavaScriptExecutor)WDriver;
            //jse.ExecuteScript("window.scrollBy(0,250)", "");
            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    ////div class    ui-dialog-buttonset

                    //results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.strButton_Recurring_Frequency_MSG_Box_Action_Button);
                    //if (results.Result1 == KeyWords.Result_FAIL)
                    //{
                    //    //  return results;
                    //}
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            //Exempt/Non-Exempt

            if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Exempt_exemptTrue);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
            }


            //Shift
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID);
                }
            }



            //Travel and Ancillary Expenses

            if (createRequirementModel.str_T2_btn_TravelandAncillaryExpensesyes_expenses != "")
            {
                if (createRequirementModel.strRadiobtnRateNegotiable.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesyes_expensesTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    if (createRequirementModel.str_T2_txt_EstimatedExpenseAmountperResource_expenseFixedAmount != "")
                    {
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesNO_expensesFalse, createRequirementModel.str_T2_txt_EstimatedExpenseAmountperResource_expenseFixedAmount, true);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesNO_expensesFalse);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
            }
            else
            {

                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesNO_expensesFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);

            //Use Start and End Date, assuming 40 hours per week + anticipated OT
            if (createRequirementModel.str_T2_Radiobutton_strTxt_ContractValueCalculation_rdtypeoption1 == "1")
            {
                kwm.click(WDriver, KeyWords.locator_ID, "rdtypeoption1");
            }
            //Estimated Number of Hours per Resource for the Contract Period
            if (createRequirementModel.str_T2_Radiobutton_strTxt_ContractValueCalculation_rdtypeoption2 == "2")
            {
                kwm.click(WDriver, KeyWords.locator_ID, "rdtypeoption3");
            }
            //Use Start and End Date, assuming less than 40 hours per week
            if (createRequirementModel.str_T2_Radiobutton_strTxt_ContractValueCalculation_rdtypeoption3 == "3")
            {
                kwm.click(WDriver, KeyWords.locator_ID, "rdtypeoption2");
            }
            //No calculation needed (flat dollar amount entered for full labor and expense cost)
            if (createRequirementModel.str_T2_Radiobutton_strTxt_ContractValueCalculation_rdtypeoption4 == "4")
            {
                kwm.click(WDriver, KeyWords.locator_ID, "rdtypeoption4");
            }









            //Anticipated average OT per week:     hasOTHours
            if (createRequirementModel.str_T2_txt_AnticipatedaverageOTperweek_hasOTHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_AnticipatedaverageOTperweek_hasOTHours, createRequirementModel.str_T2_txt_AnticipatedaverageOTperweek_hasOTHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            ///Estimated # of Regular Hours/Week:
            if (createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Estimated Total # of Hours      approvedTotalHours
            if (createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_EstimatedTotalofHours_approvedTotalHours, createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }






            //Rate Type   rateTypeID



            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }








            objCommonMethods.Action_Page_Down(WDriver);
            IJavaScriptExecutor jse1 = (IJavaScriptExecutor)WDriver;
            jse1.ExecuteScript("window.scrollBy(0,250)", "");



            // Bill Rate Range: 

            //Billrate  Min
            if (createRequirementModel.str_T2_txt_Billratelow_billRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow, createRequirementModel.str_T2_txt_Billratelow_billRateLow, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }




            //Billrate  Max
            if (createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //Estimated Total Labor and Expense Cost:
            if (createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_t2_txt_EstimatedContractValue_estContractValue, createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


        }

        #region Epri
        public static void CreateRequirementEpri(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (kwm.isElementDisplayed(WDriver, KeyWords.ID_selecttypeofServiceID))
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);
            //    }
            //}


            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID), kwm._WDWait);


            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");

            // Type of Service *
            if (createRequirementModel.str_T2_Select_TypeofService_typeofServiceID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_TypeofService_typeofServiceID, createRequirementModel.str_T2_Select_TypeofService_typeofServiceID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_TypeofService_typeofServiceID, createRequirementModel.str_T2_Select_TypeofService_typeofServiceID);
                }
            }
            Thread.Sleep(1000);

            // Job Title *
            if (createRequirementModel.str_T2_TypeHead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_TypeHead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_TypeHead_JobTitle_txtJobTitle, createRequirementModel.str_T2_TypeHead_JobTitle_txtJobTitle);
                //  Thread.Sleep(2000);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_TypeHead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_TypeHead_JobTitle_txtJobTitle, createRequirementModel.str_T2_TypeHead_JobTitle_txtJobTitle);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_TypeHead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, "a");
                        // return results;
                    }
                }
            }


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    //strValue = WDriver.FindElement(By.Id(KeyWords.ID_PopUpWIN_ui_dialog_title_PleaseWaitPopup)).Displayed;
                    strValue = kwm.isElementDisplayed(WDriver, KeyWords.ID_PopUpWIN_ui_dialog_title_PleaseWaitPopup);
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

            // Job Description *
            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            ////Upload Job Description
            //if (createRequirementModel.str_Txt_UploadFilePath != "")
            //{

            //    if (File.Exists(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + createRequirementModel.str_Txt_UploadFilePath))
            //    {
            //        if (createRequirementModel.strBrowserName.ToLower() != Constants.Chrome)
            //        {
            //            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Link_btnresumeupload);
            //        }
            //        try
            //        {
            //            kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Link_btnresumeupload_reuirement);
            //            WDriver.FindElement(By.Name(KeyWords.NAME_Link_qqfile)).SendKeys(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + createRequirementModel.str_Txt_UploadFilePath);
            //            Thread.Sleep(3000);
            //            if (createRequirementModel.strBrowserName.ToLower() == Constants.Chrome)
            //            {
            //                System.Windows.Forms.SendKeys.SendWait("{ESC}");
            //                Thread.Sleep(3000);
            //            }
            //        }
            //        catch (Exception uplod)
            //        {
            //            string strUploaderror = uplod.Message;
            //        }
            //        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Link_btnresume_sendsupplier);
            //        //Submit button for Upload job description
            //        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_class, KeyWords.locator_class_button, createRequirementModel.str_Txt_MailStation);
            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            results = kwm.select_Button(WDriver, KeyWords.locator_class, KeyWords.locator_class_button, createRequirementModel.str_Txt_MailStation);
            //            // return results;
            //        }
            //    }
            //    else
            //    {
            //        objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "The given resume path not find" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + createRequirementModel.str_Txt_UploadFilePath, 3);
            //    }
            //}

            // Skills / Experience / Education
            // Mandatory
            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            // Ideal Candidate
            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            // Skill Matrix (+)
            // Skill Name
            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            // Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            // Level (1-5, 5 being the highest)
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            // Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Special Needs
            // Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            // Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);

                    //return results;
                }
            }

            // Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Recurring
            objCommonMethods.Action_Page_Down(WDriver);
            if (createRequirementModel.str_T2_Radiobutton_Recurring_recurringScheduleFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Recurring_recurringScheduleFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.strSelect_Recurring_Frequency_MSG_Box);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    //div class    ui-dialog-buttonset

                    results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.strButton_Recurring_Frequency_MSG_Box_Action_Button);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            Thread.Sleep(2000);
            // Interview Required
            if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Travel Required
            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            // Exempt/Non-Exempt 

            // OT Allowed
            if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed != "")
            {
                if (createRequirementModel.strRadiobtnOTAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    if (createRequirementModel.strRadiobtn_OT_Limitation.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitTrue);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, createRequirementModel.str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }

                        if (createRequirementModel.strRadiobtn_otPreTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreTrue);
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreFalse);
                        }
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitFalse);
                    }
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Shift:
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.strselectShift);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.strselectShift);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //% Amount 
            if (createRequirementModel.str_T2_Amount_shiftDiffPercent != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Amount_shiftDiffPercent, createRequirementModel.str_T2_Amount_shiftDiffPercent, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Pay Rate *
            //Payrate  Min
            if (createRequirementModel.str_T2_txt_PayRateLow_payRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_PayRateLow_payRateLow, createRequirementModel.str_T2_txt_PayRateLow_payRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Payrate  Max
            if (createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T2_txt_PayRateHigh_payRateHigh, createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Bill Rate *
            //Billrate  Min
            if (createRequirementModel.str_T2_txt_Billratelow_billRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow, createRequirementModel.str_T2_txt_Billratelow_billRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Billrate  Max
            if (createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            objCommonMethods.Action_Button_Tab(WDriver);
            //Estimated Contract Value *
            if (createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_t2_txt_EstimatedContractValue_estContractValue, createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Rate Negotiable  
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T2_btn_RateNegotiable_rateNego))
            {
                if (createRequirementModel.str_T2_btn_RateNegotiable_rateNego.ToLower().Equals(KeyWords.str_String_Compare_direct))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateNegotiable_rateNegoTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateNegotiable_rateNegoFalse);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }
        }
        #endregion Epri


        #region EBS
        public static void CreateRequirementEBSClient(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_SaveContinue_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}


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
            }

            Thread.Sleep(100);
            //Job Title *
            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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

            //createRequirementModel.strTextAreaJobDescription
            //Job description 
            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Upload Job Description: -- non manditory field

            // Enter file name to save the recording:  -- non manditory field

            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Skill Desired

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //Interview Required 
            if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Travel Required 
            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelLocation_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelDescription_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //OT Allowed

            if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    if (createRequirementModel.str_T2_Radiobutton_OtLimitation_OtLimit.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitTrue);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, createRequirementModel.str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }

                        if (createRequirementModel.str_T2_Radiobutton_OtPerTrue_OtpreTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreTrue);
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreFalse);
                        }
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitFalse);
                    }
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Exempt/Non Exempt *
            if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Exempt_exemptTrue);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
            }

            //Shift
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //% Amount 

            if (createRequirementModel.str_T2_Amount_shiftDiffPercent != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Amount_shiftDiffPercent, createRequirementModel.str_T2_Amount_shiftDiffPercent, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Rate Type   rateTypeID

            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }
            //PayRate Min *
            if (createRequirementModel.str_T2_txt_PayRateLow_payRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_PayRateLow_payRateLow, createRequirementModel.str_T2_txt_PayRateLow_payRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //PayRate Max *
            if (createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T2_txt_PayRateHigh_payRateHigh, createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Rate Negotiable  
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T2_btn_RateNegotiable_rateNego))
            {
                if (createRequirementModel.str_T2_btn_RateNegotiable_rateNego.ToLower().Equals(KeyWords.str_String_Compare_direct))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateNegotiable_rateNegoTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateNegotiable_rateNegoFalse);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }

        }
        #endregion

        public static void CreateRequirementAPS(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_PositionType_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_SaveContinue_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_T2_select_PositionType_typeofServiceID), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_T2_select_PositionType_typeofServiceID), kwm._WDWait);

            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");
            //Position Type *
            if (createRequirementModel.str_T2_select_PositionType_typeofServiceID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_PositionType_typeofServiceID, createRequirementModel.str_T2_select_PositionType_typeofServiceID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_PositionType_typeofServiceID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Job Title
            Thread.Sleep(100);
            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_PopUpWIN_ui_dialog_title_PleaseWaitPopup)).Displayed;
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

            //Job Description
            //createRequirementModel.strTextAreaJobDescription

            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Upload Job Description  -- non manditory field

            //Skill Required

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Desired

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);

            //Skill Name
            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false, KeyWords.Type_Table);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false, KeyWords.Type_Table);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID, KeyWords.Type_table_radio_button);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID,KeyWords.Type_Table);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }


            // Mandatory (Yes/No) P47 -- sheet column number
            
            if (createRequirementModel.str_Radiobtn_SkillMatrixMandatory_skillRequiredTrue != "")
            {
                if (createRequirementModel.str_Radiobtn_SkillMatrixMandatory_skillRequiredTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radiobtn_SkillMatrixMandatory_skillRequiredTrue, KeyWords.Type_table_radio_button);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radiobtn_SkillMatrixMandatory_skillRequiredFalse, KeyWords.Type_table_radio_button);
                }

            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radiobtn_SkillMatrixMandatory_skillRequiredFalse, KeyWords.Type_table_radio_button);
            }

            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID, KeyWords.Type_Table);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false,KeyWords.Type_Table);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue, KeyWords.Type_radio_button, KeyWords.Type_table_radio_button);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse, KeyWords.Type_table_radio_button);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse, KeyWords.Type_table_radio_button);


            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue, KeyWords.Type_Table);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency,KeyWords.Type_Popup);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    ////div class    ui-dialog-buttonset

                    //results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.strButton_Recurring_Frequency_MSG_Box_Action_Button);
                    //if (results.Result1 == KeyWords.Result_FAIL)
                    //{
                    //    //  return results;
                    //}
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse, KeyWords.Type_table_radio_button);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_PopUp_Button_ReccuringFrequency_Submit, "", KeyWords.Class_PopUp_Button_Submit);
            }


            //Use Start and End Date, assuming 40 hours per week
            if (createRequirementModel.str_T2_Radiobutton_strTxt_ContractValueCalculation_rdtypeoption1 == "1")
            {
                kwm.click(WDriver, KeyWords.locator_ID, "rdtypeoption1");
            }
            //Use total estimated hours for the entire contract
            if (createRequirementModel.str_T2_Radiobutton_strTxt_ContractValueCalculation_rdtypeoption2 == "2")
            {
                kwm.click(WDriver, KeyWords.locator_ID, "rdtypeoption3");
            }
            //Use Start and End Date, assuming a different estimated hours per week
            if (createRequirementModel.str_T2_Radiobutton_strTxt_ContractValueCalculation_rdtypeoption3 == "3")
            {
                kwm.click(WDriver, KeyWords.locator_ID, "rdtypeoption2");
            }
            //No calculation needed 
            if (createRequirementModel.str_T2_Radiobutton_strTxt_ContractValueCalculation_rdtypeoption4 == "4")
            {
                kwm.click(WDriver, KeyWords.locator_ID, "rdtypeoption4");
            }


            ///Estimated # of Regular Hours/Week:
            if (createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Approved Total # of Hours
            if (createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_EstimatedTotalofHours_approvedTotalHours, createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            


            //Rate Type   rateTypeID

            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }
            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            objCommonMethods.Action_Page_Down(WDriver);
            IJavaScriptExecutor jse1 = (IJavaScriptExecutor)WDriver;
            jse1.ExecuteScript("window.scrollBy(0,250)", "");



            // Bill Rate Range: 

            //Billrate  Min
            if (createRequirementModel.str_T2_txt_Billratelow_billRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow, createRequirementModel.str_T2_txt_Billratelow_billRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }




            //Billrate  Max
            if (createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //Estimated Contract Value:
            if (createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_t2_txt_EstimatedContractValue_estContractValue, createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

        }


        public static void ClientRequirementHillRom(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods, CreateRequirementModelLabel createRequirementModelLabel)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_JobClassification_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_SaveContinue_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}


            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_T2_select_JobClassification_typeofServiceID), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_T2_select_JobClassification_typeofServiceID), kwm._WDWait);

            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");

            //Job Classification *

            if (createRequirementModel.str_T2_select_JobClassification_typeofServiceID != "")
            {
                results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_JobClassification_typeofServiceID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {

                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_JobClassification_typeofServiceID, createRequirementModel.str_T2_select_JobClassification_typeofServiceID);
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_JobClassification_typeofServiceID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Job Title *
            Thread.Sleep(100);
            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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

            //Job Description

            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Ideal Candidate
            if (createRequirementModel.str_T2_txt_IdealCandidate_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_IdealCandidate_skillDescDesired, createRequirementModel.str_T2_txt_IdealCandidate_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
                results = kwm.lableComparision(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID, createRequirementModelLabel.str_T2_Radiobtn_Level_skillLevelID);
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
            }
            //Travel Required
            if (createRequirementModel.strRadiobtnTravelRequired != "")
            {
                if (createRequirementModel.strRadiobtnTravelRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_travelTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_travelLocation, createRequirementModel.strtxtTravelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_travelDescription, createRequirementModel.strtxtTravelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_travelFalse);
               
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_travelFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            //Ot Allowed

            if (createRequirementModel.strRadiobtnOTAllowed != "")
            {
                if (createRequirementModel.strRadiobtnOTAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_otTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    if (createRequirementModel.strRadiobtn_OT_Limitation.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_otLimitTrue);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_otHoursLimit, createRequirementModel.strTxt_otHoursLimit, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }

                        if (createRequirementModel.strRadiobtn_otPreTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_otPreTrue);
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_otPreFalse);

                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //  return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_otLimitFalse);

                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_otFalse);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radio_otFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            objCommonMethods.Action_Page_Down(WDriver);
            //  actions3.SendKeys(OpenQA.Selenium.Keys.Tab).Perform();

            ///Estimated # of Regular Hours/Week:
            if (createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Estimated Total # of Hours      approvedTotalHours
            if (createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_EstimatedTotalofHours_approvedTotalHours, createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Rate Type   rateTypeID

            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Bill Rate min *
            if (createRequirementModel.str_T2_txt_Billratelow_billRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow, createRequirementModel.str_T2_txt_Billratelow_billRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
            //Bill Rate max *
            if (createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Button_Tab(WDriver);
            //Estimated Contract Value *
            if (createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_t2_txt_EstimatedContractValue_estContractValue, createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }




        }

        public static void CreateRequirementSOF(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(500);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}

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
            }


            Thread.Sleep(500);
            //Job Title
            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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
                Thread.Sleep(500);
            }

            //createRequirementModel.strTextAreaJobDescription
            //Job Description
            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }
            //Desired
            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    ////div class    ui-dialog-buttonset

                    //results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.strButton_Recurring_Frequency_MSG_Box_Action_Button);
                    //if (results.Result1 == KeyWords.Result_FAIL)
                    //{
                    //    //  return results;
                    //}
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Interview Required

            objCommonMethods.Select_Radio_Button_ID(WDriver, KeyWords.ID_T2_Radiobutton_InterviewRequired_interviewRequired, "Yes");


            if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button_ID(WDriver, KeyWords.ID_T2_Radiobutton_InterviewRequired_interviewRequired, "Yes");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button_ID(WDriver, KeyWords.ID_T2_Radiobutton_InterviewRequired_interviewRequired, "No");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
            }
            else
            {
                results = objCommonMethods.Select_Radio_Button_ID(WDriver, KeyWords.ID_T2_Radiobutton_InterviewRequired_interviewRequired, "No");
            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Travel required

            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelLocation_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelDescription_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
            }
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                // return results;
            }



            //Ot Allowed

            if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otTrue);
                    //Ot Limitation

                    if (createRequirementModel.str_T2_Radiobutton_OtLimitation_OtLimit.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitTrue);

                        //Maximum Overtime Hours Approved per week: *

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, createRequirementModel.str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, false);
                        //is pre approval required when ot hrs exceeds
                        if (createRequirementModel.str_T2_Radiobutton_OtPerTrue_OtpreTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreTrue);
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreFalse);
                        }

                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitFalse);
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                }

            }

            //Exempt/Non-Exempt

            if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Exempt_exemptTrue);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
            }
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);
            objCommonMethods.Action_Page_Down(WDriver);
            //Shift
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID);
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }
            //Rate Type   rateTypeID



            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //PayRate Low

            if (createRequirementModel.str_T2_txt_PayRateLow_payRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_PayRateLow_payRateLow, createRequirementModel.str_T2_txt_PayRateLow_payRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //PayRate High
            if (createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T2_txt_PayRateHigh_payRateHigh, createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Rate Negotiable 


            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T2_btn_RateNegotiable_rateNego))
            {
                if (createRequirementModel.str_T2_btn_RateNegotiable_rateNego.ToLower().Equals(KeyWords.str_String_Compare_direct))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateNegotiable_rateNegoTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateNegotiable_rateNegoFalse);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }

        }

        public static void ClientRequirementSTS(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(500);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}


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
            }


            Thread.Sleep(500);
            //Job Title
            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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
                Thread.Sleep(500);
            }

            //createRequirementModel.strTextAreaJobDescription
            //Job Description
            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Skill Desired

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    ////div class    ui-dialog-buttonset

                    //results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.strButton_Recurring_Frequency_MSG_Box_Action_Button);
                    //if (results.Result1 == KeyWords.Result_FAIL)
                    //{
                    //    //  return results;
                    //}
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Interview Required

            objCommonMethods.Select_Radio_Button_ID(WDriver, KeyWords.ID_T2_Radiobutton_InterviewRequired_interviewRequired, "Yes");


            if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button_ID(WDriver, KeyWords.ID_T2_Radiobutton_InterviewRequired_interviewRequired, "Yes");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button_ID(WDriver, KeyWords.ID_T2_Radiobutton_InterviewRequired_interviewRequired, "No");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
            }
            else
            {
                results = objCommonMethods.Select_Radio_Button_ID(WDriver, KeyWords.ID_T2_Radiobutton_InterviewRequired_interviewRequired, "No");
            }

            //Travel required

            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelLocation_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelDescription_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
            }
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                // return results;
            }



            //Ot Allowed

            if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otTrue);
                    //Ot Limitation

                    if (createRequirementModel.str_T2_Radiobutton_OtLimitation_OtLimit.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitTrue);

                        //Maximum Overtime Hours Approved per week: *

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, createRequirementModel.str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, false);
                        //is pre approval required when ot hrs exceeds
                        if (createRequirementModel.str_T2_Radiobutton_OtPerTrue_OtpreTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreTrue);
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreFalse);
                        }

                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitFalse);
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                }

            }

            //Exempt/Non-Exempt

            if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Exempt_exemptTrue);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
            }
            Thread.Sleep(2000);
            objCommonMethods.Action_Button_Tab(WDriver);
            objCommonMethods.Action_Page_Down(WDriver);

            //Shift
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID);
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }






            //Rate Type   rateTypeID



            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //PayRate Low

            if (createRequirementModel.str_T2_txt_PayRateLow_payRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_PayRateLow_payRateLow, createRequirementModel.str_T2_txt_PayRateLow_payRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //PayRate High
            if (createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T2_txt_PayRateHigh_payRateHigh, createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Rate Negotiable 


            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T2_btn_RateNegotiable_rateNego))
            {
                if (createRequirementModel.str_T2_btn_RateNegotiable_rateNego.ToLower().Equals(KeyWords.str_String_Compare_direct))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateNegotiable_rateNegoTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateNegotiable_rateNegoFalse);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }





        }

        public static void CreateRequirementStewartTitle(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(500);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}


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
            }


            Thread.Sleep(500);
            //Job Title
            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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
                Thread.Sleep(500);
            }

            //Assignment Description
            if (createRequirementModel.str_T2_txt_AssignmentDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_AssignmentDescription_jobDescription, createRequirementModel.str_T2_txt_AssignmentDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Skill Desired

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            objCommonMethods.Action_Button_Tab(WDriver);
            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(WDriver);
            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //  objCommonMethods.Action_Page_Down(WDriver);
            //Interview Required 
            if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Travel Required 
            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelLocation_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelDescription_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Exempt/Non Exempt *
            if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Exempt_exemptTrue);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
            }

            //Travel and Ancillary Expenses

            if (createRequirementModel.str_T2_btn_TravelandAncillaryExpensesyes_expenses != "")
            {
                if (createRequirementModel.strRadiobtnRateNegotiable.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesyes_expensesTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    if (createRequirementModel.str_T2_txt_EstimatedExpenseAmountperResource_expenseFixedAmount != "")
                    {
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesNO_expensesFalse, createRequirementModel.str_T2_txt_EstimatedExpenseAmountperResource_expenseFixedAmount, true);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesNO_expensesFalse);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
            }
            else
            {

                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesNO_expensesFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            //Anticipated average OT per week:     hasOTHours
            if (createRequirementModel.str_T2_txt_AnticipatedaverageOTperweek_hasOTHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_AnticipatedaverageOTperweek_hasOTHours, createRequirementModel.str_T2_txt_AnticipatedaverageOTperweek_hasOTHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            ///Estimated # of Regular Hours/Week:
            if (createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Estimated Total # of Hours      approvedTotalHours
            if (createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_EstimatedTotalofHours_approvedTotalHours, createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }






            //Rate Type   rateTypeID



            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }








            objCommonMethods.Action_Page_Down(WDriver);
            IJavaScriptExecutor jse1 = (IJavaScriptExecutor)WDriver;
            jse1.ExecuteScript("window.scrollBy(0,250)", "");



            // Bill Rate Range: 

            //Billrate  Min
            if (createRequirementModel.str_T2_txt_Billratelow_billRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow, createRequirementModel.str_T2_txt_Billratelow_billRateLow, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }




            //Billrate  Max
            if (createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //Estimated Total Labor and Expense Cost:
            if (createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_t2_txt_EstimatedContractValue_estContractValue, createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
        }

        #region ThermoFisher
        public static void CreateRequirementThermoFisher(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_SaveContinue_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}



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
            }

            //Job Title

            if (createRequirementModel.str_T2_Typeahead_JobPostingTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobPostingTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobPostingTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobPostingTitle_txtJobTitle);
                //  Thread.Sleep(2000);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobPostingTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobPostingTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobPostingTitle_txtJobTitle);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobPostingTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, "a");
                        // return results;
                    }
                }
            }


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_PopUpWIN_ui_dialog_title_PleaseWaitPopup)).Displayed;
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

            //Job Descripition
            //createRequirementModel.strTextAreaJobDescription

            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Ideal Candidate

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    ////div class    ui-dialog-buttonset

                    //results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.strButton_Recurring_Frequency_MSG_Box_Action_Button);
                    //if (results.Result1 == KeyWords.Result_FAIL)
                    //{
                    //    //  return results;
                    //}
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Candidate Meeting    

            if (createRequirementModel.str_T2_btn_CandidateMeeting_inter != "")
            {
                if (createRequirementModel.str_T2_btn_CandidateMeeting_inter.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_CandidateMeeting_interTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_CandidateMeeting_interFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            //Travel Required 
            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelLocation_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelDescription_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //OT Allowed

            if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    if (createRequirementModel.str_T2_Radiobutton_OtLimitation_OtLimit.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitTrue);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, createRequirementModel.str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }

                        if (createRequirementModel.str_T2_Radiobutton_OtPerTrue_OtpreTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreTrue);
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreFalse);
                        }
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitFalse);
                    }
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Exempt/Non Exempt *
            if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Exempt_exemptTrue);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
            }

            //Work Shift
            if (createRequirementModel.str_T2_Select_Workshift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Select_Workshift_shiftID, createRequirementModel.str_T2_Select_Workshift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_Select_Workshift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }




            //objCommonMethods.Action_Page_Down(WDriver);
            //  actions3.SendKeys(OpenQA.Selenium.Keys.Tab).Perform();
            kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh);
            ///Estimated # of Regular Hours/Week:
            if (createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Estimated Total # of Hours      approvedTotalHours
            if (createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_EstimatedTotalofHours_approvedTotalHours, createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Rate Type   rateTypeID

            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }



            //Bill Rate min *
            if (createRequirementModel.str_T2_txt_Billratelow_billRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow, createRequirementModel.str_T2_txt_Billratelow_billRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
            //Bill Rate max *
            if (createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Button_Tab(WDriver);
            //Estimated Contract Value *
            if (createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_t2_txt_EstimatedContractValue_estContractValue, createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


        }
        #endregion ThermoFisher

        public static void CreateRequirementRMS(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}


            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID), kwm._WDWait);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");

            //Type of Service *
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
            }


            Thread.Sleep(100);
            //Job Title *
            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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

            //createRequirementModel.strTextAreaJobDescription
            //Job description 
            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            // Upload Job Description: -- Non manditory field

            // Enter file name to save the recording:  -- Non Manditory field

            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Skill Desired

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            // Skill Mandatory (Yes/No)


            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    ////div class    ui-dialog-buttonset

                    //results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.strButton_Recurring_Frequency_MSG_Box_Action_Button);
                    //if (results.Result1 == KeyWords.Result_FAIL)
                    //{
                    //    //  return results;
                    //}
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);

            //Interview Required 
            if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Travel Required 
            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelLocation_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelDescription_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //OT Allowed

            if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    if (createRequirementModel.str_T2_Radiobutton_OtLimitation_OtLimit.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitTrue);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, createRequirementModel.str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }

                        if (createRequirementModel.str_T2_Radiobutton_OtPerTrue_OtpreTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreTrue);
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreFalse);
                        }
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitFalse);
                    }
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Exempt/Non Exempt *
            if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Exempt_exemptTrue);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
            }

            //Shift
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //% Amount 

            if (createRequirementModel.str_T2_Amount_shiftDiffPercent != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Amount_shiftDiffPercent, createRequirementModel.str_T2_Amount_shiftDiffPercent, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Rate Type   rateTypeID

            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }
            //PayRate Min *
            if (createRequirementModel.str_T2_txt_PayRateLow_payRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_PayRateLow_payRateLow, createRequirementModel.str_T2_txt_PayRateLow_payRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //PayRate Max *
            if (createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T2_txt_PayRateHigh_payRateHigh, createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Rate Negotiable  
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T2_btn_RateNegotiable_rateNego))
            {
                if (createRequirementModel.str_T2_btn_RateNegotiable_rateNego.ToLower().Equals(KeyWords.str_String_Compare_direct))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateNegotiable_rateNegoTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateNegotiable_rateNegoFalse);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }

        }

        public static void CreateRequirementQuickenLoans(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_Select_JobCategory_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_SaveContinue_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}



            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_T2_Select_JobCategory_typeofServiceID), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_T2_Select_JobCategory_typeofServiceID), kwm._WDWait);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");



            //Job Category 
            if (createRequirementModel.str_T2_Select_JobCategory_typeofServiceID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Select_JobCategory_typeofServiceID, createRequirementModel.str_T2_Select_JobCategory_typeofServiceID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_Select_JobCategory_typeofServiceID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            Thread.Sleep(100);
            //Job Title *
            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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

            //createRequirementModel.strTextAreaJobDescription
            //Job description 
            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Skill Desired

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //Travel required

            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelLocation_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelDescription_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
            }
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                // return results;
            }


            //Exempt/Non Exempt *
            if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Exempt_exemptTrue);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
            }

            //Hours
            if (createRequirementModel.str_T2_Select_Hours_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Select_Hours_shiftID, createRequirementModel.str_T2_Select_Hours_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_Select_Hours_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Travel and Ancillary Expenses

            if (createRequirementModel.str_T2_btn_TravelandAncillaryExpenses_expenses != "")
            {
                if (createRequirementModel.strRadiobtnRateNegotiable.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpenses_expensesTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    if (createRequirementModel.str_T2_txt_EstimatedExpenseAmountperResourceforContractPeriod_expenseFixedAmount != "")
                    {
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_EstimatedExpenseAmountperResourceforContractPeriod_expenseFixedAmount, createRequirementModel.str_T2_txt_EstimatedExpenseAmountperResourceforContractPeriod_expenseFixedAmount, true);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpenses_expensesFalse);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
            }
            else
            {

                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpenses_expensesFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            objCommonMethods.Action_Page_Down(WDriver);

            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Rate Type   rateTypeID

            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }
            //BillRate Min *
            if (createRequirementModel.str_T2_txt_Billratelow_billRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow, createRequirementModel.str_T2_txt_Billratelow_billRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //BillRate Max *
            if (createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Estimated Contract Value - Disbaled

            //Salary Range Min

            if (createRequirementModel.str_T2_txt_SalaryRangeMin_MinConversionSalary != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SalaryRangeMin_MinConversionSalary, createRequirementModel.str_T2_txt_SalaryRangeMin_MinConversionSalary, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Salary Range Max *
            if (createRequirementModel.str_T2_txt_SalaryRangeMax_MaxConversionSalary != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SalaryRangeMax_MaxConversionSalary, createRequirementModel.str_T2_txt_SalaryRangeMax_MaxConversionSalary, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }



        }

        #region MFC
        public static void CreateRequirementMFC(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID), kwm._WDWait);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");


            //Type of Service *
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
            }


            Thread.Sleep(100);
            //Job Title *
            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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

            //createRequirementModel.strTextAreaJobDescription
            //Job description 
            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Skill Desired

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //Interview Required 
            if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Travel Required 
            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelLocation_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelDescription_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //OT Allowed

            if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    if (createRequirementModel.str_T2_Radiobutton_OtLimitation_OtLimit.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitTrue);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, createRequirementModel.str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }

                        if (createRequirementModel.str_T2_Radiobutton_OtPerTrue_OtpreTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreTrue);
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreFalse);
                        }
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitFalse);
                    }
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Exempt/Non Exempt *
            if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Exempt_exemptTrue);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
            }

            //Shift
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //% Amount 

            if (createRequirementModel.str_T2_Amount_shiftDiffPercent != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Amount_shiftDiffPercent, createRequirementModel.str_T2_Amount_shiftDiffPercent, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Rate Type   rateTypeID

            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }
            //PayRate Min *
            if (createRequirementModel.str_T2_txt_PayRateLow_payRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_PayRateLow_payRateLow, createRequirementModel.str_T2_txt_PayRateLow_payRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //PayRate Max *
            if (createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T2_txt_PayRateHigh_payRateHigh, createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Rate Negotiable  
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T2_btn_RateNegotiable_rateNego))
            {
                if (createRequirementModel.str_T2_btn_RateNegotiable_rateNego.ToLower().Equals(KeyWords.str_String_Compare_direct))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateNegotiable_rateNegoTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateNegotiable_rateNegoFalse);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }
            // objCommonMethods.Action_Page_Down(WDriver);


        }
        #endregion MFC

        public static void CreateRequirementBimbo(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_LaborCategory_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}



            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_T2_select_LaborCategory_typeofServiceID), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_T2_select_LaborCategory_typeofServiceID), kwm._WDWait);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");

            //Labor Category *
            if (createRequirementModel.str_T2_select_LaborCategory_typeofServiceID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_LaborCategory_typeofServiceID, createRequirementModel.str_T2_select_LaborCategory_typeofServiceID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_LaborCategory_typeofServiceID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }


            Thread.Sleep(100);
            //Job Title *
            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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

            //createRequirementModel.strTextAreaJobDescription
            //Job description 
            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Skill Desired

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            Thread.Sleep(2000);
            //objCommonMethods.Action_Page_Down(WDriver);

            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            objCommonMethods.Action_Button_Tab(WDriver);
            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(WDriver);

            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Special Needs - Frequency
            if (createRequirementModel.strRadiobtnFrequency != "")
            {
                if (createRequirementModel.strRadiobtnFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radiobtn_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_ddlFrequency, createRequirementModel.strSelect_Recurring_Frequency_MSG_Box);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    //div class    ui-dialog-buttonset

                    results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.strButton_Recurring_Frequency_MSG_Box_Action_Button);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radiobtn_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Is this a replacement requisition
            if (createRequirementModel.str_T2_btn_Isthisareplacementrequisition_directIndirect != "")
            {
                if (createRequirementModel.str_T2_btn_Isthisareplacementrequisition_directIndirect.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_Isthisareplacementrequisition_directIndirectTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Requisition_association, createRequirementModel.str_T2_txt_Requisition_association, false);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_Isthisareplacementrequisition_directIndirectFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_Isthisareplacementrequisition_directIndirectFalse);
            }
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                // return results;
            }


            //Are there unionized workers at this location?  

            if (createRequirementModel.str_T2_btn_Arethereunionizedworkersatthislocation_UnauthorizedWorker != "")
            {
                if (createRequirementModel.str_T2_btn_Arethereunionizedworkersatthislocation_UnauthorizedWorker.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_Arethereunionizedworkersatthislocation_UnauthorizedWorkerTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }


                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_Arethereunionizedworkersatthislocation_UnauthorizedWorkerFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_Arethereunionizedworkersatthislocation_UnauthorizedWorkerFalse);
            }
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                // return results;
            }

            //CBA Contract
            if (createRequirementModel.str_T2_txt_CBAContract_CollectiveBargainingAgreementCode != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_CBAContract_CollectiveBargainingAgreementCode, createRequirementModel.str_T2_txt_CBAContract_CollectiveBargainingAgreementCode, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Is the position expected to be longer than 13 weeks
            if (createRequirementModel.str_T2_btn_Isthepositionexpectedtobelongerthan13weeks_interviewRequired != "")
            {
                if (createRequirementModel.str_T2_btn_Isthepositionexpectedtobelongerthan13weeks_interviewRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_Isthepositionexpectedtobelongerthan13weeks_interviewRequiredTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }


                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_Isthepositionexpectedtobelongerthan13weeks_interviewRequiredFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_Isthepositionexpectedtobelongerthan13weeks_interviewRequiredFalse);
            }
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                // return results;
            }

            //Exempt/Non-Exempt - Disabled

            //Shift
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //Is there a shift differential
            if (createRequirementModel.str_T2_btn_Isthereashiftdifferential_shift != "")
            {
                if (createRequirementModel.str_T2_btn_Isthereashiftdifferential_shift.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_Isthereashiftdifferential_shiftTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }


                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_Isthereashiftdifferential_shiftFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_Isthereashiftdifferential_shiftFalse);
            }
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                // return results;
            }

            //Amount

            if (createRequirementModel.str_T2_txt_Amount_shiftDiffAmount != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Amount_shiftDiffAmount, createRequirementModel.str_T2_txt_Amount_shiftDiffAmount, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Working Hours
            if (createRequirementModel.str_T2_txt_Workinghours_shiftDiffPercent != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Workinghours_shiftDiffPercent, createRequirementModel.str_T2_txt_Workinghours_shiftDiffPercent, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Is Travel Required
            if (createRequirementModel.str_T2_btn_IsTravelRequired_expenses != "")
            {
                if (createRequirementModel.str_T2_btn_IsTravelRequired_expenses.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_IsTravelRequired_expensesTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }


                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_Istravelrequired_expensesFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_Istravelrequired_expensesFalse);
            }
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                // return results;
            }

            //Anticipated average OT per week:     hasOTHours
            if (createRequirementModel.str_T2_txt_AnticipatedaverageOTperweek_hasOTHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_AnticipatedaverageOTperweek_hasOTHours, createRequirementModel.str_T2_txt_AnticipatedaverageOTperweek_hasOTHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Estimated # of Regular Hours/Week - Disabled

            //Estimated Total # of Hours - Disbaled

            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }






            //Rate Type   rateTypeID



            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }


            //PayRate Low

            if (createRequirementModel.str_T2_txt_PayRateLow_payRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_PayRateLow_payRateLow, createRequirementModel.str_T2_txt_PayRateLow_payRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //PayRate High
            if (createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T2_txt_PayRateHigh_payRateHigh, createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }


            //Bill rate Range -Disabled

            //Estimated Contract Value Disabled



        }

        public static void CreateRequirementGeorgetown(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_SaveContinue_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}

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
            }

            Thread.Sleep(100);
            //Job Title *
            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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

            //createRequirementModel.strTextAreaJobDescription
            //Job description 
            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Skill Desired

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }





            //Exempt/Non Exempt *
            if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Exempt_exemptTrue);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
            }

            //Shift
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);

            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Rate Type   rateTypeID

            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Payrate  Min
            if (createRequirementModel.str_T2_txt_PayRateLow_payRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_PayRateLow_payRateLow, createRequirementModel.str_T2_txt_PayRateLow_payRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }




            //Payrate  Max
            if (createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T2_txt_PayRateHigh_payRateHigh, createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //BillRate Min *
            if (createRequirementModel.str_T2_txt_Billratelow_billRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow, createRequirementModel.str_T2_txt_Billratelow_billRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //BillRate Max *
            if (createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }



        }
        
        public static void CreateRequirementCOE(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_LaborCategory_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_T2_select_LaborCategory_typeofServiceID), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_T2_select_LaborCategory_typeofServiceID), kwm._WDWait);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");


            //Labor Category *
            if (createRequirementModel.str_T2_select_LaborCategory_typeofServiceID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_LaborCategory_typeofServiceID, createRequirementModel.str_T2_select_LaborCategory_typeofServiceID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_LaborCategory_typeofServiceID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }


            Thread.Sleep(100);
            //Job Title *
            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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

            //createRequirementModel.strTextAreaJobDescription
            //Job description 
            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Skill Desired

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            Thread.Sleep(2000);
            //objCommonMethods.Action_Page_Down(WDriver);

            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            objCommonMethods.Action_Button_Tab(WDriver);
            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(WDriver);

            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            //objCommonMethods.Action_Page_Down(WDriver);
            //Interview Required 
            if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Is this a replacement Requistion 

            if (createRequirementModel.str_T2_btn_Isthisareplacementrequistion_directIndirectTrue != "")
            {
                if (createRequirementModel.str_T2_btn_Isthisareplacementrequistion_directIndirectTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_Isthisareplacementrequistion_directIndirectTrue);

                    if (results.Result1 == KeyWords.Result_PASS)
                    {

                        if (createRequirementModel.str_T2_txt_IsthisareplacementrequistionRequistion_association != "")
                        {
                            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_IsthisareplacementrequistionRequistion_association, createRequirementModel.str_T2_txt_IsthisareplacementrequistionRequistion_association, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //  return results;
                            }
                        }
                    }

                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_Isthisareplacementrequistion_directIndirectFalse);
                    }
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_Isthisareplacementrequistion_directIndirectFalse);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
            }
            //Shift - Disabled

            //Is On-Call Required? *

            if (createRequirementModel.str_T2_btn_IsOnCallRequired_shiftTrue != "")
            {
                if (createRequirementModel.str_T2_btn_IsOnCallRequired_shiftTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_IsOnCallRequired_shiftTrue);

                    if (results.Result1 == KeyWords.Result_PASS)
                    {

                        if (createRequirementModel.str_T2_txt_IsOnCallRequiredAmount_shiftDiffAmount != "")
                        {
                            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_IsOnCallRequiredAmount_shiftDiffAmount, createRequirementModel.str_T2_txt_IsOnCallRequiredAmount_shiftDiffAmount, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //  return results;
                            }
                        }
                    }

                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_IsOnCallRequired_shiftFalse);
                    }
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_IsOnCallRequired_shiftFalse);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
            }


            objCommonMethods.Action_Page_Down(WDriver);


            //Anticipated average OT Per Week 
            if (createRequirementModel.str_T2_txt_AnticipatedaverageOTperweek_hasOTHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_AnticipatedaverageOTperweek_hasOTHours, createRequirementModel.str_T2_txt_AnticipatedaverageOTperweek_hasOTHours, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Estimated # of Regular Hours/Week: - Disabled

            //Estimated Total # of Hours - Disabled


            //Currency   

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Rate Type   rateTypeID

            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            objCommonMethods.Action_Page_Down(WDriver);

            //Bill rate range Min
            if (createRequirementModel.str_T2_txt_BillRateRange_billRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_BillRateRange_billRateLow, createRequirementModel.str_T2_txt_BillRateRange_billRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
            //Bill rate Range Max
            if (createRequirementModel.str_T2_txt_BillRateRange_billRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_BillRateRange_billRateHigh, createRequirementModel.str_T2_txt_BillRateRange_billRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Estimated Labor and Exp Cost - Disabled



        }
        
        public static void ClientRequirementTufts(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_SaveContinue_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}

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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_PopUpWIN_ui_dialog_title_PleaseWaitPopup)).Displayed;
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

            //Job Descripition
            //createRequirementModel.strTextAreaJobDescription

            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Ideal Candidate

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    ////div class    ui-dialog-buttonset

                    //results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.strButton_Recurring_Frequency_MSG_Box_Action_Button);
                    //if (results.Result1 == KeyWords.Result_FAIL)
                    //{
                    //    //  return results;
                    //}
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);

            //Interview Required 
            if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //OT Allowed

            if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    if (createRequirementModel.str_T2_Radiobutton_OtLimitation_OtLimit.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitTrue);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, createRequirementModel.str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }

                        if (createRequirementModel.str_T2_Radiobutton_OtPerTrue_OtpreTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreTrue);
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreFalse);
                        }
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitFalse);
                    }
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Exempt/Non Exempt *
            if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Exempt_exemptTrue);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
            }




            //Shift:
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID);
                }
            }

            //Travel and Ancillary Expenses

            if (createRequirementModel.str_T2_btn_TravelandAncillaryExpensesyes_expenses != "")
            {
                if (createRequirementModel.strRadiobtnRateNegotiable.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesyes_expensesTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    if (createRequirementModel.str_T2_txt_EstimatedExpenseAmountperResource_expenseFixedAmount != "")
                    {
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesNO_expensesFalse, createRequirementModel.str_T2_txt_EstimatedExpenseAmountperResource_expenseFixedAmount, true);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesNO_expensesFalse);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
            }
            else
            {

                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesNO_expensesFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Use Start and End Date, assuming 40 hours per week + anticipated OT
            if (createRequirementModel.strTxt_ContractValueCalculation_rdtypeoption == "1")
            {
                kwm.click(WDriver, KeyWords.locator_ID, "rdtypeoption1");
            }
            //Estimated Number of Hours per Resource for the Contract Period
            if (createRequirementModel.strTxt_ContractValueCalculation_rdtypeoption == "2")
            {
                kwm.click(WDriver, KeyWords.locator_ID, "rdtypeoption3");
            }
            //Use Start and End Date, assuming less than 40 hours per week
            if (createRequirementModel.strTxt_ContractValueCalculation_rdtypeoption == "3")
            {
                kwm.click(WDriver, KeyWords.locator_ID, "rdtypeoption2");
            }
            //No calculation needed (flat dollar amount entered for full labor and expense cost)
            if (createRequirementModel.strTxt_ContractValueCalculation_rdtypeoption == "4")
            {
                kwm.click(WDriver, KeyWords.locator_ID, "rdtypeoption4");
            }



            //Anticipated average OT per week:     hasOTHours
            if (createRequirementModel.str_T2_txt_AnticipatedaverageOTperweek_hasOTHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_AnticipatedaverageOTperweek_hasOTHours, createRequirementModel.str_T2_txt_AnticipatedaverageOTperweek_hasOTHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            ///Estimated # of Regular Hours/Week:
            if (createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Estimated Total # of Hours      approvedTotalHours
            if (createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_EstimatedTotalofHours_approvedTotalHours, createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }






            //Rate Type   rateTypeID



            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }








            objCommonMethods.Action_Page_Down(WDriver);
            IJavaScriptExecutor jse1 = (IJavaScriptExecutor)WDriver;
            jse1.ExecuteScript("window.scrollBy(0,250)", "");



            // Bill Rate Range: 

            //Billrate  Min
            if (createRequirementModel.str_T2_txt_Billratelow_billRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow, createRequirementModel.str_T2_txt_Billratelow_billRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }




            //Billrate  Max
            if (createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //Estimated Total Labor and Expense Cost:
            if (createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_t2_txt_EstimatedContractValue_estContractValue, createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

        }

        public static void ClientRequirementPHHMortgage(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_JobClassification_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_SaveContinue_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_T2_select_JobClassification_typeofServiceID), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_T2_select_JobClassification_typeofServiceID), kwm._WDWait);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");

            //Job Classification *

            if (createRequirementModel.str_T2_select_JobClassification_typeofServiceID != "")
            {
                results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_JobClassification_typeofServiceID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {

                        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_JobClassification_typeofServiceID, createRequirementModel.str_T2_select_JobClassification_typeofServiceID);
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_JobClassification_typeofServiceID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Job Title *
            Thread.Sleep(100);
            if (createRequirementModel.str_T2_Typeahead_JobCategory_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobCategory_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobCategory_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobCategory_txtJobTitle);
                //  Thread.Sleep(2000);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobCategory_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobCategory_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobCategory_txtJobTitle);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobCategory_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, "a");
                        // return results;
                    }
                }
            }


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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

            //Job Description

            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Ideal Candidate
            if (createRequirementModel.str_T2_txt_IdealCandidate_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_IdealCandidate_skillDescDesired, createRequirementModel.str_T2_txt_IdealCandidate_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            //Travel Required 
            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelLocation_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelDescription_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //OT Allowed

            if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    if (createRequirementModel.str_T2_Radiobutton_OtLimitation_OtLimit.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitTrue);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, createRequirementModel.str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }

                        if (createRequirementModel.str_T2_Radiobutton_OtPerTrue_OtpreTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreTrue);
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreFalse);
                        }
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitFalse);
                    }
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Exempt/Non Exempt *
            if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Exempt_exemptTrue);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
            }

            //Shift
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }


            objCommonMethods.Action_Page_Down(WDriver);
            //  actions3.SendKeys(OpenQA.Selenium.Keys.Tab).Perform();

            ///Estimated # of Regular Hours/Week:
            if (createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Estimated Total # of Hours      approvedTotalHours
            if (createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_EstimatedTotalofHours_approvedTotalHours, createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Rate Type   rateTypeID

            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            // Pay Rate Range: 

            //Payrate  Min
            if (createRequirementModel.str_T2_txt_PayRateLow_payRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_PayRateLow_payRateLow, createRequirementModel.str_T2_txt_PayRateLow_payRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }




            //Payrate  Max
            if (createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T2_txt_PayRateHigh_payRateHigh, createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            //Bill Rate min *
            if (createRequirementModel.str_T2_txt_Billratelow_billRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow, createRequirementModel.str_T2_txt_Billratelow_billRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
            //Bill Rate max *
            if (createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Button_Tab(WDriver);
            //Estimated Contract Value *
            if (createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_t2_txt_EstimatedContractValue_estContractValue, createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



        }

        public static void CreateRequirementSTGEN(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_SaveContinue_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}

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
            }

            Thread.Sleep(100);
            //Job Title *
            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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

            //createRequirementModel.strTextAreaJobDescription
            //Job description 
            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Upload Job Description:  -- Non Manditory field

            // Enter File name to save the recording:  -- Non Manditory field


            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Skill Desired

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            // Skill Mandatory(Yes/No)

            //Special Needs Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //Interview Required 
            if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Travel Required 
            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelLocation_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelDescription_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //OT Allowed

            if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    if (createRequirementModel.str_T2_Radiobutton_OtLimitation_OtLimit.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitTrue);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, createRequirementModel.str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }

                        if (createRequirementModel.str_T2_Radiobutton_OtPerTrue_OtpreTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreTrue);
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreFalse);
                        }
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitFalse);
                    }
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Exempt/Non Exempt *
            if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Exempt_exemptTrue);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
            }

            //Shift
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //% Amount 

            if (createRequirementModel.str_T2_Amount_shiftDiffPercent != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Amount_shiftDiffPercent, createRequirementModel.str_T2_Amount_shiftDiffPercent, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Rate Type   rateTypeID

            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }
            //PayRate Min *
            if (createRequirementModel.str_T2_txt_PayRateLow_payRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_PayRateLow_payRateLow, createRequirementModel.str_T2_txt_PayRateLow_payRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //PayRate Max *
            if (createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T2_txt_PayRateHigh_payRateHigh, createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Rate Negotiable  
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T2_btn_RateNegotiable_rateNego))
            {
                if (createRequirementModel.str_T2_btn_RateNegotiable_rateNego.ToLower().Equals(KeyWords.str_String_Compare_direct))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateNegotiable_rateNegoTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateNegotiable_rateNegoFalse);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }
        }

        #region Supervalu
        public static void CreateRequirementSupervalu(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_SaveContinue_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}

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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_PopUpWIN_ui_dialog_title_PleaseWaitPopup)).Displayed;
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

            //Job Descripition
            //createRequirementModel.strTextAreaJobDescription

            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Ideal Candidate

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    ////div class    ui-dialog-buttonset

                    //results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.strButton_Recurring_Frequency_MSG_Box_Action_Button);
                    //if (results.Result1 == KeyWords.Result_FAIL)
                    //{
                    //    //  return results;
                    //}
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);

            //Interview Required 
            if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Travel Required 
            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelLocation_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelDescription_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //OT Allowed

            if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    if (createRequirementModel.str_T2_Radiobutton_OtLimitation_OtLimit.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitTrue);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, createRequirementModel.str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }

                        if (createRequirementModel.str_T2_Radiobutton_OtPerTrue_OtpreTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreTrue);
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreFalse);
                        }
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitFalse);
                    }
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Exempt/Non Exempt *
            if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Exempt_exemptTrue);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Shift
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID);
                }
            }

            if (createRequirementModel.strtxtEstWeeklyHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_EstWeeklyHours, createRequirementModel.strtxtEstWeeklyHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            Thread.Sleep(2000);
            try
            {
                WDriver.FindElement(By.XPath(KeyWords.Xpath_RadioBtn_rdtypeoption)).Click();
            }
            catch
            {
                //
            }
            try
            {
                WDriver.FindElement(By.XPath(KeyWords.Xpath_RadioBtn_rdtypeoption1)).Click();
            }
            catch
            {
                //
            }
            objCommonMethods.Action_Page_Down(WDriver);

            ///Estimated # of Regular Hours/Week:
            if (createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Estimated Total # of Hours      approvedTotalHours
            if (createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_EstimatedTotalofHours_approvedTotalHours, createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }



            objCommonMethods.Action_Page_Down(WDriver);


            //Rate Type   rateTypeID



            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }








            objCommonMethods.Action_Page_Down(WDriver);
            IJavaScriptExecutor jse1 = (IJavaScriptExecutor)WDriver;
            jse1.ExecuteScript("window.scrollBy(0,250)", "");

            // Pay Rate Range: 

            //Payrate  Min
            if (createRequirementModel.str_T2_txt_PayRateLow_payRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_PayRateLow_payRateLow, createRequirementModel.str_T2_txt_PayRateLow_payRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }




            //Payrate  Max
            if (createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T2_txt_PayRateHigh_payRateHigh, createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Bill Rate Range: 

            //Billrate  Min
            if (createRequirementModel.str_T2_txt_Billratelow_billRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow, createRequirementModel.str_T2_txt_Billratelow_billRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }




            //Billrate  Max
            if (createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //Estimated Total Labor and Expense Cost:
            if (createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_t2_txt_EstimatedContractValue_estContractValue, createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }




        }
        #endregion Supervalu

        #region Emerson
        public static void CreateRequirementEmerson(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID), kwm._WDWait);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");

            //Type of Service *
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
            }


            Thread.Sleep(100);
            //Job Title *
            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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

            //createRequirementModel.strTextAreaJobDescription
            //Job description 
            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Skill Desired

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(WDriver);

            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //Interview Required 
            if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //OT Allowed

            if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    if (createRequirementModel.str_T2_Radiobutton_OtLimitation_OtLimit.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitTrue);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, createRequirementModel.str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }

                        if (createRequirementModel.str_T2_Radiobutton_OtPerTrue_OtpreTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreTrue);
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreFalse);
                        }
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitFalse);
                    }
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Exempt/Non Exempt *
            if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Exempt_exemptTrue);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
            }

            //Shift
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Rate Type   rateTypeID

            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            objCommonMethods.Action_Page_Down(WDriver);

            if (createRequirementModel.str_T2_txt_Billratelow_billRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow, createRequirementModel.str_T2_txt_Billratelow_billRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
            if (createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_BillrateHigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //estimated Contract Value - Disabled



        }
        #endregion Emerson

        public static void CreateRequirementArkema(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(500);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}

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
            }


            Thread.Sleep(500);
            //Job Title
            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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
                Thread.Sleep(500);
            }

            Thread.Sleep(2000);

            //createRequirementModel.strTextAreaJobDescription
            //Job Description
            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }
            //Desired
            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    ////div class    ui-dialog-buttonset

                    //results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.strButton_Recurring_Frequency_MSG_Box_Action_Button);
                    //if (results.Result1 == KeyWords.Result_FAIL)
                    //{
                    //    //  return results;
                    //}
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);

            //Interview Required

            objCommonMethods.Select_Radio_Button_ID(WDriver, KeyWords.ID_T2_Radiobutton_InterviewRequired_interviewRequired, "Yes");


            if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button_ID(WDriver, KeyWords.ID_T2_Radiobutton_InterviewRequired_interviewRequired, "Yes");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button_ID(WDriver, KeyWords.ID_T2_Radiobutton_InterviewRequired_interviewRequired, "No");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
            }
            else
            {
                results = objCommonMethods.Select_Radio_Button_ID(WDriver, KeyWords.ID_T2_Radiobutton_InterviewRequired_interviewRequired, "No");
            }


            objCommonMethods.Action_Page_Down(WDriver);
            //Travel required

            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelLocation_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelDescription_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
            }
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                // return results;
            }


            //Ot Allowed

            if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otTrue);
                    //Ot Limitation

                    if (createRequirementModel.str_T2_Radiobutton_OtLimitation_OtLimit.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitTrue);

                        //Maximum Overtime Hours Approved per week: *

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, createRequirementModel.str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, false);
                        //is pre approval required when ot hrs exceeds
                        if (createRequirementModel.str_T2_Radiobutton_OtPerTrue_OtpreTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreTrue);
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreFalse);
                        }

                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitFalse);
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                }

            }


            //Exempt/Non Exempt *
            if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Exempt_exemptTrue);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Shift
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID);
                }
            }

            //% Amount 

            if (createRequirementModel.str_T2_Amount_shiftDiffPercent != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Amount_shiftDiffPercent, createRequirementModel.str_T2_Amount_shiftDiffPercent, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Estimated # of Hours/Week Disabled

            //Approved Total # of Hours - Disabled

            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Rate Type   rateTypeID

            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }


            //Payrate  Min
            if (createRequirementModel.str_T2_txt_PayRateLow_payRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_PayRateLow_payRateLow, createRequirementModel.str_T2_txt_PayRateLow_payRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }




            //Payrate  Max
            if (createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T2_txt_PayRateHigh_payRateHigh, createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Bill Rate Range: 

            //Billrate  Min
            if (createRequirementModel.str_T2_txt_Billratelow_billRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow, createRequirementModel.str_T2_txt_Billratelow_billRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }




            //Billrate  Max
            if (createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Estimated Contract Value
            if (createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_t2_txt_EstimatedContractValue_estContractValue, createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //Rate Negotiable 


            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T2_btn_RateNegotiable_rateNego))
            {
                if (createRequirementModel.str_T2_btn_RateNegotiable_rateNego.ToLower().Equals(KeyWords.str_String_Compare_direct))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateNegotiable_rateNegoTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateNegotiable_rateNegoFalse);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }

        }

        #region Workspend-sallieMae
        public static void CreateRequirementSallieMae(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_SaveContinue_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}

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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_PopUpWIN_ui_dialog_title_PleaseWaitPopup)).Displayed;
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

            //Job Descripition
            //createRequirementModel.strTextAreaJobDescription

            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Ideal Candidate

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    ////div class    ui-dialog-buttonset

                    //results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.strButton_Recurring_Frequency_MSG_Box_Action_Button);
                    //if (results.Result1 == KeyWords.Result_FAIL)
                    //{
                    //    //  return results;
                    //}
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);

            //Interview Required 
            if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Travel Required 
            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelLocation_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelDescription_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //OT Allowed

            if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    if (createRequirementModel.str_T2_Radiobutton_OtLimitation_OtLimit.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitTrue);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, createRequirementModel.str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }

                        if (createRequirementModel.str_T2_Radiobutton_OtPerTrue_OtpreTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreTrue);
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreFalse);
                        }
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitFalse);
                    }
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Shift
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //% Amount 

            if (createRequirementModel.str_T2_Amount_shiftDiffPercent != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Amount_shiftDiffPercent, createRequirementModel.str_T2_Amount_shiftDiffPercent, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Rate Type   rateTypeID

            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }


            objCommonMethods.Action_Page_Down(WDriver);
            //  actions3.SendKeys(OpenQA.Selenium.Keys.Tab).Perform();

            // Bill Rate Min
            if (createRequirementModel.str_T2_txt_Billratelow_billRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow, createRequirementModel.str_T2_txt_Billratelow_billRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            // Bill Rate Max
            if (createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_BillrateHigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Estimated Contract Value

            if (createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_t2_txt_EstimatedContractValue_estContractValue, createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

        }
        #endregion Workspend-sallieMae

       
        public static void CreateRequirementSTTM(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_SaveContinue_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}

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
            }

            Thread.Sleep(100);
            //Job Title *
            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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

            //createRequirementModel.strTextAreaJobDescription
            //Job description 
            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Skill Desired

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Special Need Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //Interview Required 
            if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Travel Required 
            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelLocation_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelDescription_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //OT Allowed

            if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    if (createRequirementModel.str_T2_Radiobutton_OtLimitation_OtLimit.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitTrue);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, createRequirementModel.str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }

                        if (createRequirementModel.str_T2_Radiobutton_OtPerTrue_OtpreTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreTrue);
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreFalse);
                        }
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitFalse);
                    }
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Exempt/Non Exempt *
            if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Exempt_exemptTrue);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
            }

            //Shift
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //% Amount 

            if (createRequirementModel.str_T2_Amount_shiftDiffPercent != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Amount_shiftDiffPercent, createRequirementModel.str_T2_Amount_shiftDiffPercent, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Rate Type   rateTypeID

            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }
            //PayRate Min *
            if (createRequirementModel.str_T2_txt_PayRateLow_payRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_PayRateLow_payRateLow, createRequirementModel.str_T2_txt_PayRateLow_payRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //PayRate Max *
            if (createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T2_txt_PayRateHigh_payRateHigh, createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Rate Negotiable  
            if (!string.IsNullOrWhiteSpace(createRequirementModel.str_T2_btn_RateNegotiable_rateNego))
            {
                if (createRequirementModel.str_T2_btn_RateNegotiable_rateNego.ToLower().Equals(KeyWords.str_String_Compare_direct))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateNegotiable_rateNegoTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateNegotiable_rateNegoFalse);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }

        }

        public static void CreateRequirementYP(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_TypeofService_typeofServiceID);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}
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
            }

            //Title
            Thread.Sleep(100);
            if (createRequirementModel.str_T2_Typeahead_Title_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_Title_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_Title_txtJobTitle, createRequirementModel.str_T2_Typeahead_Title_txtJobTitle);
                //  Thread.Sleep(2000);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_Title_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_Title_txtJobTitle, createRequirementModel.str_T2_Typeahead_Title_txtJobTitle);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_Title_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, "a");
                        // return results;
                    }
                }
            }


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_PopUpWIN_ui_dialog_title_PleaseWaitPopup)).Displayed;
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

            //Assignment Detail

            if (createRequirementModel.str_T2_Typeahead_AssignmentDetail_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_AssignmentDetail_jobDescription, createRequirementModel.str_T2_Typeahead_AssignmentDetail_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Upload Job Description
            if (createRequirementModel.str_Txt_UploadFilePath != "")
            {

                if (File.Exists(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + createRequirementModel.str_Txt_UploadFilePath))
                {
                    if (createRequirementModel.strBrowserName.ToLower() != Constants.Chrome)
                    {
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Link_btnresumeupload);
                    }
                    try
                    {
                        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Link_btnresumeupload_reuirement);
                        WDriver.FindElement(By.Name(KeyWords.NAME_Link_qqfile)).SendKeys(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + createRequirementModel.str_Txt_UploadFilePath);
                        Thread.Sleep(3000);
                        if (createRequirementModel.strBrowserName.ToLower() == Constants.Chrome)
                        {
                            System.Windows.Forms.SendKeys.SendWait("{ESC}");
                            Thread.Sleep(3000);
                        }
                    }
                    catch (Exception uplod)
                    {
                        string strUploaderror = uplod.Message;
                    }
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Link_btnresume_sendsupplier);
                    //Submit button for Upload job description
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_class, KeyWords.locator_class_button, createRequirementModel.str_Txt_MailStation);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.select_Button(WDriver, KeyWords.locator_class, KeyWords.locator_class_button, createRequirementModel.str_Txt_MailStation);
                        // return results;
                    }
                }
                else
                {
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "The given resume path not find" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + createRequirementModel.str_Txt_UploadFilePath, 3);
                }
            }

            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Skill Desired

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID, KeyWords.Type_radio_button);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory
            if (createRequirementModel.str_Radiobtn_SkillMatrixMandatory_skillRequiredTrue != "")
            {
                if (createRequirementModel.str_Radiobtn_SkillMatrixMandatory_skillRequiredTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radiobtn_SkillMatrixMandatory_skillRequiredTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radiobtn_SkillMatrixMandatory_skillRequiredFalse);
                }

            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency, KeyWords.Type_Popup);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_PopUp_Button_ReccuringFrequency_Submit, "", KeyWords.Class_PopUp_Button_Submit);
            }
            objCommonMethods.Action_Page_Down(WDriver);
            //Interview Required 
            if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_InterviewRequired_interviewRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_InterviewRequired_interFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Travel Required 
            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue, KeyWords.Type_radio_button);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelLocation_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelDescription_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse, KeyWords.Type_radio_button);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse, KeyWords.Type_radio_button);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //OT Allowed

            if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_OtAllowed_OtAllowed.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otTrue, KeyWords.Type_radio_button);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    if (createRequirementModel.str_T2_Radiobutton_OtLimitation_OtLimit.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitTrue, KeyWords.Type_radio_button);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }

                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, createRequirementModel.str_T2_txt_MaximumOvertimeHoursApprovedperweek_otHoursLimit, false);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }

                        if (createRequirementModel.str_T2_Radiobutton_OtPerTrue_OtpreTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreTrue, KeyWords.Type_radio_button);
                        }
                        else
                        {
                            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_IspreApproved_otPreFalse, KeyWords.Type_radio_button);
                        }
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            //  return results;
                        }
                    }
                    else
                    {
                        results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtLimitation_otLimitFalse, KeyWords.Type_radio_button);
                    }
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_OtAllowed_otFalse, KeyWords.Type_radio_button);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Shift
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //% Amount 

            if (createRequirementModel.str_T2_Amount_shiftDiffPercent != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Amount_shiftDiffPercent, createRequirementModel.str_T2_Amount_shiftDiffPercent, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Use Start and End Date, assuming 40 hours per week + anticipated OT
            if (createRequirementModel.str_T2_btn_RateInformation_rdtypeoption == "1")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateInformation_rdtypeoption1, KeyWords.Type_radio_button);
            }
            //Estimated Number of Hours per Resource for the Contract Period
            if (createRequirementModel.str_T2_btn_RateInformation_rdtypeoption == "2")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateInformation_rdtypeoption3, KeyWords.Type_radio_button);
            }
            //Use Start and End Date, assuming less than 40 hours per week
            if (createRequirementModel.str_T2_btn_RateInformation_rdtypeoption == "3")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateInformation_rdtypeoption2, KeyWords.Type_radio_button);
            }
            //No calculation needed (flat dollar amount entered for full labor and expense cost)
            if (createRequirementModel.str_T2_btn_RateInformation_rdtypeoption == "4")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateInformation_rdtypeoption4, KeyWords.Type_radio_button);
            }


            //Currency     currencyID

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Rate Type   rateTypeID

            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }
            //PayRate Min *
            if (createRequirementModel.str_T2_txt_PayRateLow_payRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_PayRateLow_payRateLow, createRequirementModel.str_T2_txt_PayRateLow_payRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //PayRate Max *
            if (createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T2_txt_PayRateHigh_payRateHigh, createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Estimated Contract Value
            if (createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_t2_txt_EstimatedContractValue_estContractValue, createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

        }

        public static void CreateRequirementLear(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_SaveContinue_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}

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
            }

            Thread.Sleep(100);
            //Job Title *
            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = kwm.select_List_typeahead_temp(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle, createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle);
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


            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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

            //createRequirementModel.strTextAreaJobDescription
            //Job Description 
            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Skill Desired

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Skill Matrix
            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory (Yes/No)
            if (createRequirementModel.str_T2_Radiobutton_SkillMandatory_skillRequired != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_SkillMandatory_skillRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_SkillMandatory_skillRequiredTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_SkillMandatory_skillRequiredFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Special Needs Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestart != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestart.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);

                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.str_T2_btn_RecurringFrequencySubmit);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //Travel and Ancillary Expenses

            if (createRequirementModel.str_T2_btn_TravelandAncillaryExpensesyes_expenses != "")
            {
                if (createRequirementModel.strRadiobtnRateNegotiable.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesyes_expensesTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    if (createRequirementModel.str_T2_txt_EstimatedExpenseAmountperResource_expenseFixedAmount != "")
                    {
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesNO_expensesFalse, createRequirementModel.str_T2_txt_EstimatedExpenseAmountperResource_expenseFixedAmount, true);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesNO_expensesFalse);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
            }
            else
            {

                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesNO_expensesFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            //Exempt/Non Exempt *
            if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Exempt_exemptTrue);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
            }

            //Shift
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //% Amount 

            if (createRequirementModel.str_T2_Amount_shiftDiffPercent != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Amount_shiftDiffPercent, createRequirementModel.str_T2_Amount_shiftDiffPercent, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Contract Value Calculation 
            //Use Start and End Date, assuming 40 hours per week + anticipated OT
            if (createRequirementModel.str_T2_btn_RateInformation_rdtypeoption == "1")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateInformation_rdtypeoption1);
            }
            //Estimated Number of Hours per Resource for the Contract Period
            if (createRequirementModel.str_T2_btn_RateInformation_rdtypeoption == "2")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateInformation_rdtypeoption3);
            }
            //Use Start and End Date, assuming less than 40 hours per week
            if (createRequirementModel.str_T2_btn_RateInformation_rdtypeoption == "3")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateInformation_rdtypeoption2);
            }
            //No calculation needed (flat dollar amount entered for full labor and expense cost)
            if (createRequirementModel.str_T2_btn_RateInformation_rdtypeoption == "4")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateInformation_rdtypeoption4);
            }




            //Anticipated average OT per week:   
            if (createRequirementModel.str_T2_txt_AnticipatedaverageOTperweek_hasOTHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_AnticipatedaverageOTperweek_hasOTHours, createRequirementModel.str_T2_txt_AnticipatedaverageOTperweek_hasOTHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            ///Estimated # of Regular Hours/Week:
            if (createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Estimated Total # of Hours      approvedTotalHours
            if (createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_EstimatedTotalofHours_approvedTotalHours, createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Rate Type 
            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Currency  

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            objCommonMethods.Action_Page_Down(WDriver);
            IJavaScriptExecutor jse1 = (IJavaScriptExecutor)WDriver;
            jse1.ExecuteScript("window.scrollBy(0,250)", "");

            // Bill Rate Range: 

            //Billrate  Min
            if (createRequirementModel.str_T2_txt_Billratelow_billRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow, createRequirementModel.str_T2_txt_Billratelow_billRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Billrate  Max
            if (createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //Estimated Labor and Exp Cost:
            if (createRequirementModel.str_T2_Txt_EstimatedLaborExpCost_estContractValue != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Txt_EstimatedLaborExpCost_estContractValue, createRequirementModel.str_T2_Txt_EstimatedLaborExpCost_estContractValue, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


          






        }

        #region EQT
        public static void ClientRequirementEQT(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID), kwm._WDWait);

            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");

            // Type of Service *
            if (createRequirementModel.str_T2_select_TypeofService_typeofServiceID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_TypeofService_typeofServiceID, createRequirementModel.str_T2_select_TypeofService_typeofServiceID);

                if (results.Result1 == KeyWords.Result_FAIL)
                {

                    results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_TypeofService_typeofServiceID, 2);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_TypeofService_typeofServiceID);
                    }
                }
            }

            Thread.Sleep(100);
            // Job Title *
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
            Thread.Sleep(3000);

            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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

            // Job Descripition *
            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            // Upload Job Description


            objCommonMethods.Action_Page_Down(WDriver);

            // Mandatory
            if (createRequirementModel.str_T2_txt_Mandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Mandatory_skillDescMandatory, createRequirementModel.str_T2_txt_Mandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Mandatory_skillDescMandatory, createRequirementModel.str_T2_txt_Mandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            // Desired
            if (createRequirementModel.str_T2_txt_Desired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Desired_skillDescDesired, createRequirementModel.str_T2_txt_Desired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            // SkillMatrix -- Skill Name

            if (createRequirementModel.str_T2_txt_skillName_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_skillName_skillName, createRequirementModel.str_T2_txt_skillName_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            // SkillMatrix-- Description
            if (createRequirementModel.str_T2_txt_Description_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_skillDescription, createRequirementModel.str_T2_txt_Description_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            // Skill Matrix-- Level (1-5, 5 being the highest)
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            // Skill Matrix-- Years
            if (createRequirementModel.str_T2_select_Years_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Years_skillYearsExpID, createRequirementModel.str_T2_select_Years_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            // Additional Requirements--Catgerory
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            // Additional Requirements--Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            // Additional Requirements--Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);
            }


            // Additional Requirements--Recurring
            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }


            }

            //Travel Required 
            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue);
                    // Travel Location *
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelLocation_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    // Travel Description *
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_TravelDescription_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Exempt/Non-Exempt
            if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Exempt_exemptTrue);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
            }

            // Shift
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectDynamicDropdownByValue(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID);
                }
            }

            // Rate Information (USD)--Contract Value Calculation *

            // Use Start & End Date, assuming 40 hours per week
            if (createRequirementModel.str_T2_btn_RateInformation_rdtypeoption == "1")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_UseStartEndDateassuming40hoursperweek_rdtypeoption1);

                Thread.Sleep(2000);
                //Anticipated average OT per week: *
                if (createRequirementModel.str_T2_txt_AnticipatedaverageOTperweek_hasOTHours != "")
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_AnticipatedaverageOTperweek_hasOTHours, createRequirementModel.str_T2_txt_AnticipatedaverageOTperweek_hasOTHours, true);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }

            }

            // Use total estimated hours for the entire contract
            else if (createRequirementModel.str_T2_btn_RateInformation_rdtypeoption == "2")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_Usetotalestimatedhoursfortheentirecontract_rdtypeoption2);
                Thread.Sleep(2000);
                //Estimated Total # of Hours      
                if (createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours != "")
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_EstimatedTotalofHours_approvedTotalHours, createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours, true);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }

            // Use Start & End Date, assuming a different estimated hours per week
            else if (createRequirementModel.str_T2_btn_RateInformation_rdtypeoption == "3")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_UseStartEndDateassumingadifferentestimatedhoursperweek_rdtypeoption3);
                Thread.Sleep(2000);
                // Est. # Hours/Week
                if (createRequirementModel.str_T2_txt_EstHoursWeek_EstWeeklyHours != "")
                {
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_EstHoursWeek_EstWeeklyHours, createRequirementModel.str_T2_txt_EstHoursWeek_EstWeeklyHours, true);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }
            //  No calculation needed
            else
            {
                // createRequirementModel.str_T2_btn_RateInformation_rdtypeoption == "4"
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_Nocalculationneeded_rdtypeoption4);
            }


            // Rate Type *
            if (createRequirementModel.str_T2_select_RateType_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_RateType_rateTypeID, createRequirementModel.str_T2_select_RateType_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_RateType_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            // Currency
            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }


            // Bill Rate Range *

            // Billrate  Min
            if (createRequirementModel.str_T2_txt_Billratelow_billRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow, createRequirementModel.str_T2_txt_Billratelow_billRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            // Billrate  Max
            if (createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            // Estimated Contract Value
            if (createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_t2_txt_EstimatedContractValue_estContractValue, createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

        }
        #endregion EQT

        public static void CreateRequirementSIGMA(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID)).Displayed)
            //    {
            //        break;
            //    }
            //    Thread.Sleep(100);
            //    try
            //    {
            //        kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_SaveContinue_btnSaveCont);
            //    }
            //    catch
            //    {
            //        //
            //    }
            //    if (createRequirementModel.btnOutLine_Action_Button != "")
            //    {
            //        results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

            //    }
            //}

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
            }

            Thread.Sleep(100);
            //Job Title *
            if (createRequirementModel.str_T2_Typeahead_JobTitle_txtJobTitle != "")
            {
                results = results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Typeahead_JobTitle_txtJobTitle, KeyWords.locator_class, KeyWords.CL_list_typeahead, "a");
                Thread.Sleep(1000);

                objCommonMethods.Action_Button_Tab(WDriver);
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

            Thread.Sleep(1000);
            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_T2_PopUpWINuidialogtitle_PleaseWaitPopup)).Displayed;
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

            //createRequirementModel.strTextAreaJobDescription
            //Job Description 
            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            objCommonMethods.Action_Page_Down(WDriver);
            //Skill Mandatory

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            //Skill Desired

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Skill Matrix
            //Skill Name

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Description
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level
            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Skill Level Years
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory (Yes/No)
            if (createRequirementModel.str_T2_Radiobutton_SkillMandatory_skillRequired != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_SkillMandatory_skillRequired.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_SkillMandatory_skillRequiredTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_SkillMandatory_skillRequiredFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Special Needs Category
            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Description
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Mandatory PreStart
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestart != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestart.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Recurring

            if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency != "")
            {
                if (createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.str_T2_select_Recurringfrequency_ddlFrequency);

                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.str_T2_btn_RecurringFrequencySubmit);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //Travel and Ancillary Expenses

            if (createRequirementModel.str_T2_btn_TravelandAncillaryExpensesyes_expenses != "")
            {
                if (createRequirementModel.strRadiobtnRateNegotiable.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesyes_expensesTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    if (createRequirementModel.str_T2_txt_EstimatedExpenseAmountperResource_expenseFixedAmount != "")
                    {
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesNO_expensesFalse, createRequirementModel.str_T2_txt_EstimatedExpenseAmountperResource_expenseFixedAmount, true);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }
                    }

                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesNO_expensesFalse);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                }
            }
            else
            {

                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_TravelandAncillaryExpensesNO_expensesFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            //Exempt/Non Exempt *
            if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Exempt_exemptTrue.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Exempt_exemptTrue);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_radiobutton_NonExempt_exemptFalse);
            }

            //Shift
            if (createRequirementModel.str_T2_select_Shift_shiftID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Shift_shiftID, createRequirementModel.str_T2_select_Shift_shiftID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Shift_shiftID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //% Amount 

            if (createRequirementModel.str_T2_Amount_shiftDiffPercent != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Amount_shiftDiffPercent, createRequirementModel.str_T2_Amount_shiftDiffPercent, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Contract Value Calculation 
            //Use Start and End Date, assuming 40 hours per week + anticipated OT
            if (createRequirementModel.str_T2_btn_RateInformation_rdtypeoption == "1")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateInformation_rdtypeoption1);
            }
            //Estimated Number of Hours per Resource for the Contract Period
            if (createRequirementModel.str_T2_btn_RateInformation_rdtypeoption == "2")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateInformation_rdtypeoption3);
            }
            //Use Start and End Date, assuming less than 40 hours per week
            if (createRequirementModel.str_T2_btn_RateInformation_rdtypeoption == "3")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateInformation_rdtypeoption2);
            }
            //No calculation needed (flat dollar amount entered for full labor and expense cost)
            if (createRequirementModel.str_T2_btn_RateInformation_rdtypeoption == "4")
            {
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_btn_RateInformation_rdtypeoption4);
            }




            //Anticipated average OT per week:   
            if (createRequirementModel.str_T2_txt_AnticipatedaverageOTperweek_hasOTHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_AnticipatedaverageOTperweek_hasOTHours, createRequirementModel.str_T2_txt_AnticipatedaverageOTperweek_hasOTHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            ///Estimated # of Regular Hours/Week:
            if (createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Estimated Total # of Hours      approvedTotalHours
            if (createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_EstimatedTotalofHours_approvedTotalHours, createRequirementModel.str_T2_txt_EstimatedTotalofHours_approvedTotalHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Rate Type 
            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Currency  

            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            objCommonMethods.Action_Page_Down(WDriver);
            IJavaScriptExecutor jse1 = (IJavaScriptExecutor)WDriver;
            jse1.ExecuteScript("window.scrollBy(0,250)", "");

            //Pay Range :
            //PayRate Min :
            if (createRequirementModel.str_T2_txt_PayRateLow_payRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_PayRateLow_payRateLow, createRequirementModel.str_T2_txt_PayRateLow_payRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //PayRate Max :
            if (createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T2_txt_PayRateHigh_payRateHigh, createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }




            // Bill Rate Range: 

            //Billrate  Min
            if (createRequirementModel.str_T2_txt_Billratelow_billRateLow != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratelow_billRateLow, createRequirementModel.str_T2_txt_Billratelow_billRateLow, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            //Billrate  Max
            if (createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh != "")
            {

                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //Estimated Labor and Exp Cost:
            if (createRequirementModel.str_T2_Txt_EstimatedLaborExpCost_estContractValue != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Txt_EstimatedLaborExpCost_estContractValue, createRequirementModel.str_T2_Txt_EstimatedLaborExpCost_estContractValue, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


        }


        #region Ryder
        public static void CreateRequirementRyder(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {
            for (int i = 0; i < 100; i++)
            {
                if (WDriver.FindElement(By.Id(KeyWords.ID_T2_select_TypeofService_typeofServiceID)).Displayed)
                {
                    break;
                }
                Thread.Sleep(100);
                try
                {
                    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_btnSaveCont);
                }
                catch
                {
                    //
                }
                if (createRequirementModel.btnOutLine_Action_Button != "")
                {
                    results = kwm.select_Button(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first, createRequirementModel.btnOutLine_Action_Button);

                }
            }
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
            }



            //Job Title *
            Thread.Sleep(2000);
            if (createRequirementModel.str_T2_select_JobTitle_jobTitleID != "")
            {

                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_JobTitle_jobTitleID, createRequirementModel.str_T2_select_JobTitle_jobTitleID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_JobTitle_jobTitleID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
                Thread.Sleep(2000);
            }

            //GL Account *
            Thread.Sleep(2000);
            if (createRequirementModel.str_T2_selectGLAccount_GLIdJD != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_selectGLAccount_GLIdJD, createRequirementModel.str_T2_selectGLAccount_GLIdJD);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_selectGLAccount_GLIdJD))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            for (int z = 1; z < 100; z++)
            {
                Boolean strValue = true;
                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_PopUpWIN_ui_dialog_title_PleaseWaitPopup)).Displayed;
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


            //createRequirementModel.strTextAreaJobDescription

            if (createRequirementModel.str_T2_txt_JobDescription_jobDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_JobDescription_jobDescription, createRequirementModel.str_T2_txt_JobDescription_jobDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            if (createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMandatory_skillDescMandatory, createRequirementModel.str_T2_txt_SkillMandatory_skillDescMandatory, false);
                    // return results;
                }
            }

            if (createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDesired_skillDescDesired, createRequirementModel.str_T2_txt_SkillDesired_skillDescDesired, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }

            if (createRequirementModel.str_T2_txt_SkillMatrix_skillName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillMatrix_skillName, createRequirementModel.str_T2_txt_SkillMatrix_skillName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            if (createRequirementModel.str_T2_txt_SkillDescription_skillDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_SkillDescription_skillDescription, createRequirementModel.str_T2_txt_SkillDescription_skillDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }


            //string skillLevelID = "skillLevelID" + createRequirementModel.strRadiobtnSkills_Level;
            if (createRequirementModel.str_T2_Radiobtn_Level_skillLevelID != "")
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobtn_Level_skillLevelID + createRequirementModel.str_T2_Radiobtn_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            if (createRequirementModel.str_T2_select_year_skillYearsExpID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_year_skillYearsExpID, createRequirementModel.str_T2_select_year_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            if (createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Catgerory_specialNeedCategoryID, createRequirementModel.str_T2_select_Catgerory_specialNeedCategoryID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
            if (createRequirementModel.str_T2_txt_Description_specialNeedDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Page_Down(WDriver);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Description_specialNeedDescription, createRequirementModel.str_T2_txt_Description_specialNeedDescription, false);

                    //return results;
                }
            }
            if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_mandatoryPrestartFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartTrue);
                else
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_mandatoryPrestartFalse);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(WDriver);
            if (createRequirementModel.str_T2_Radiobutton_Recurring_recurringScheduleFalse != "")
            {
                if (createRequirementModel.str_T2_Radiobutton_Recurring_recurringScheduleFalse.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }

                    results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Recurringfrequency_ddlFrequency, createRequirementModel.strSelect_Recurring_Frequency_MSG_Box);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                    //div class    ui-dialog-buttonset

                    results = kwm.Select_MSG_Button_OK_Click1(WDriver, KeyWords.locator_type, KeyWords.locator_button, createRequirementModel.strButton_Recurring_Frequency_MSG_Box_Action_Button);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_Recurring_recurringScheduleFalse);
                }

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel != "")
            {
                if (createRequirementModel.str_T2_radiobutton_TravelRequired_travel.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelTrue);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_travelLocation, createRequirementModel.str_T2_txt_TravelLocation_travelLocation, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        // return results;
                    }
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_travelDescription, createRequirementModel.str_T2_txt_TravelDescription_travelDescription, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            else
            {
                results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_Radiobutton_TravelRequired_travelFalse);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            if (createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, createRequirementModel.str_T2_txt_Estimatedofweeklyhours_EstWeeklyHours, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }
            Thread.Sleep(2000);
            try
            {
                WDriver.FindElement(By.XPath(KeyWords.Xpath_RadioBtn_rdtypeoption)).Click();
            }
            catch
            {
                //
            }
            try
            {
                WDriver.FindElement(By.XPath(KeyWords.Xpath_RadioBtn_rdtypeoption1)).Click();
            }
            catch
            {
                //
            }
            objCommonMethods.Action_Page_Down(WDriver);



            if (createRequirementModel.str_T2_select_Currency_currencyID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_Currency_currencyID, createRequirementModel.str_T2_select_Currency_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_Currency_currencyID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Rate Type   rateTypeID

            if (createRequirementModel.str_T2_select_ratetype_rateTypeID != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_select_ratetype_rateTypeID, createRequirementModel.str_T2_select_ratetype_rateTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(WDriver.FindElement(By.Id(KeyWords.ID_T2_select_ratetype_rateTypeID)));
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }

            }

            //Pay Rate: * 
            if (createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T2_txt_PayRateHigh_payRateHigh, createRequirementModel.str_T2_txt_PayRateHigh_payRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //  return results;
                }
            }



            //Bill Rate: *
            if (createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T2_txt_Billratehigh_billRateHigh, createRequirementModel.str_T2_txt_BillrateHigh_billRateHigh, true);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //Weekly Spend:- disabled

            objCommonMethods.Action_Button_Tab(WDriver);
            //Estimated Contract Value *
            if (createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_t2_txt_EstimatedContractValue_estContractValue, createRequirementModel.str_t2_txt_EstimatedContractValue_estContractValue, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


        }
        #endregion Ryder



        //Identified Requirement--Justification TAb
        public static void IdentifiedRequirementJustification(CreateRequirementModel createRequirementModel, Result results, KeyWordMethods kwm, IWebDriver WDriver, CommonMethods objCommonMethods)
        {

            @ReadExcel ReadExcelHelper = new ReadExcel();
           

            kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_T4_Txt_LastName_lastname), kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_T4_Txt_LastName_lastname), kwm._WDWait);
            objCommonMethods.SaveScreenShot_EachPage(WDriver, createRequirementModel.strClientName + "_");
            string timestamp = DateTime.Now.ToString("MMddyyyyHHmm");
            //Last Name
            if (createRequirementModel.str_T4_Txt_LastName_lastname != "")
            {

                createRequirementModel.str_T4_Txt_LastName_lastname = createRequirementModel.str_T4_Txt_LastName_lastname + timestamp;
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T4_Txt_LastName_lastname, createRequirementModel.str_T4_Txt_LastName_lastname, false);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            //First Name
            if (createRequirementModel.str_T4_Txt_FirstName_firstname != "")
            {
                createRequirementModel.str_T4_Txt_FirstName_firstname = createRequirementModel.str_T4_Txt_FirstName_firstname + timestamp;
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T4_Txt_FirstName_firstname, createRequirementModel.str_T4_Txt_FirstName_firstname, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            //Middle Name

            if (createRequirementModel.str_T4_Txt_MiddleName_middlename != "")
            {
                createRequirementModel.str_T4_Txt_MiddleName_middlename = createRequirementModel.str_T4_Txt_MiddleName_middlename + timestamp;
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T4_Txt_MiddleName_middlename, createRequirementModel.str_T4_Txt_MiddleName_middlename, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            string str_CanDidateFN_CandidateLN = "";

            if (createRequirementModel.str_T4_Txt_MiddleName_middlename != "")
            {
                str_CanDidateFN_CandidateLN = createRequirementModel.str_T4_Txt_LastName_lastname + ", " + createRequirementModel.str_T4_Txt_FirstName_firstname + " " + createRequirementModel.str_T4_Txt_MiddleName_middlename;
            }
            else
            {
                str_CanDidateFN_CandidateLN = createRequirementModel.str_T4_Txt_LastName_lastname + ", " + createRequirementModel.str_T4_Txt_FirstName_firstname;
            }
            KeyWords.str_Name_Txt_LastName_FirstName = str_CanDidateFN_CandidateLN;
            // objCommonMethods.UpdateRequirementNumber(KeyWords.str_link_REQ_NUMBER, AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString(), AllSheetResult.dt.Rows[iSubRowLoop]["TestScenario"].ToString());
            String strUpdateSqlMain_noofresources = "Update [MSP$] set P8 ='" + KeyWords.numofresources + "'  WHERE P3 ='" + createRequirementModel.strClientName + "' and TestScenario ='002' and TestCaseID = '007'";
            results = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain_noofresources);



            //Suffix

            if (createRequirementModel.str_T4_Select_Suffix_nameSuffix != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T4_Select_Suffix_nameSuffix, createRequirementModel.str_T4_Select_Suffix_nameSuffix);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //upload resume
            if (createRequirementModel.str_T4_btn_UploadResume_uploadResume != "")
            {

                if (File.Exists(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + createRequirementModel.str_T4_btn_UploadResume_uploadResume))
                {

                    try
                    {
                        String resumeId = WDriver.FindElement(By.XPath("//label[@id='uploadResumeLabel']/following::div/a")).GetAttribute("id");

                        if (KeyWords.NAME_Link_qqfile == resumeId && kwm.isElementPresent(WDriver, KeyWords.NAME_icon_UploadResume_qqfile))
                        {
                            kwm.click(WDriver, KeyWords.locator_ID, "uploadResume");


                            WDriver.FindElement(By.Name(KeyWords.NAME_Link_qqfile)).SendKeys(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + createRequirementModel.str_T4_btn_UploadResume_uploadResume);
                            Thread.Sleep(1000);
                            System.Windows.Forms.SendKeys.SendWait("{ESC}");

                            Thread.Sleep(1000);

                        }

                        else
                        {

                            if (KeyWords.NAME_uploadresume == resumeId && kwm.isElementPresent(WDriver, KeyWords.NAME_uploadresume))
                            {
                                kwm.click(WDriver, KeyWords.locator_ID, "uploadResume");

                                WDriver.FindElement(By.Name(KeyWords.NAME_uploadresume)).SendKeys(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + createRequirementModel.str_T4_btn_UploadResume_uploadResume);
                                Thread.Sleep(1000);
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
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "The given resume path not find" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + createRequirementModel.str_Txt_UploadFilePath, 3);
                }

            }
            //Former Employee *
            if (createRequirementModel.str_T4_Radiobutton_FormerEmployee_exEmployee != "")
            {
                if (createRequirementModel.str_T4_Radiobutton_FormerEmployee_exEmployee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T4_Radiobutton_FormerEmployee_exEmployeeYes);
                    Thread.Sleep(1000);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T4_Txt_FormerEmployeeDetails_exEmployeeDetails, createRequirementModel.str_T4_Txt_FormerEmployeeDetails_exEmployeeDetails, false);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T4_Radiobutton_FormerEmployee_exEmployeeNo);
                }


            }


            //Retiree *
            if (createRequirementModel.str_T4_Radiobutton_Retiree_retiredEmployee != "")
            {
                if (createRequirementModel.str_T4_Radiobutton_Retiree_retiredEmployee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T4_Radiobutton_Retiree_retiredEmployeeYes);
                    Thread.Sleep(1000);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T4_Txt_RetireeDetails_retiredEmployeeDetails, createRequirementModel.str_T4_Txt_RetireeDetails_retiredEmployeeDetails, false);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Radiobtn_Retiree_retiredEmployeeNo);
                }


            }

            //
            //Former US Govt/Military Employee *
            if (createRequirementModel.str_T4_Radiobutton_FormerUSGovtMilitaryEmployee_exGovMilEmployee != "")
            {
                if (createRequirementModel.str_T4_Radiobutton_FormerUSGovtMilitaryEmployee_exGovMilEmployee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T4_Radiobutton_FormerUSGovtMilitaryEmployee_exGovMilEmployeeYes);
                    Thread.Sleep(1000);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T4_Txt_FormerUSGovtMilitaryEmployee_exGovMilEmployeeDetails, createRequirementModel.str_T4_Txt_FormerUSGovtMilitaryEmployee_exGovMilEmployeeDetails, false);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T4_Radiobutton_FormerUSGovtMilitaryEmployee_exGovMilEmployeeNo);
                }


            }

            //Former Intern * 
            if (createRequirementModel.str_T4_Radiobutton_FormerIntern_exIntern != "")
            {
                if (createRequirementModel.str_T4_Radiobutton_FormerIntern_exIntern.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T4_Radiobutton_FormerIntern_exInternYes);
                    Thread.Sleep(1000);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T4_Txt_FormerInternDetails_exInternDetails, createRequirementModel.str_T4_Txt_FormerInternDetails_exInternDetails, false);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T4_Radiobutton_FormerIntern_exInternNo);
                }


            }
            //Former Contractor *
            if (createRequirementModel.str_T4_Radiobutton_FormerContractor_exContractor != "")
            {
                if (createRequirementModel.str_T4_Radiobutton_FormerContractor_exContractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T4_Radiobutton_FormerContractor_exContractorYes);
                    Thread.Sleep(1000);
                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T4_Txt_FormerContractorDetails_exContractorDetails, createRequirementModel.str_T4_Txt_FormerContractorDetails_exContractorDetails, false);
                }
                else
                {
                    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_T4_Radiobutton_FormerContractor_exContractorNo);
                }


            }


            //only for Altria client this condition
            if (createRequirementModel.strClientName.Trim().ToLower() == Constants.Altria)
            {

                // last day worked
                if (createRequirementModel.str_T4_lastdayWorked != "")
                {

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T4_lastdayWorked, createRequirementModel.str_T4_lastdayWorked, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(1000);
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T4_lastdayWorked, createRequirementModel.str_T4_lastdayWorked, false);

                        //return results;
                    }
                }


                // Last supervisor

                if (createRequirementModel.str_T4_lastSupervisor != "")
                {

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T4_lastSupervisor, createRequirementModel.str_T4_lastSupervisor, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(1000);
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T4_lastSupervisor, createRequirementModel.str_T4_lastSupervisor, false);

                        //return results;
                    }
                }

                // company

                if (createRequirementModel.str_T4_lastcompany != "")
                {

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T4_lastcompany, createRequirementModel.str_T4_lastcompany, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(1000);
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T4_lastcompany, createRequirementModel.str_T4_lastcompany, false);

                        //return results;
                    }
                }

                // Rehire status
                if (createRequirementModel.str_T4_lastRehireStatus != "")
                {

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T4_lastRehireStatus, createRequirementModel.str_T4_lastRehireStatus, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(1000);
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T4_lastRehireStatus, createRequirementModel.str_T4_lastRehireStatus, false);

                        //return results;
                    }
                }

                //  position
                if (createRequirementModel.str_T4_lastPosition != "")
                {

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T4_lastPosition, createRequirementModel.str_T4_lastPosition, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(1000);
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T4_lastPosition, createRequirementModel.str_T4_lastPosition, false);

                        //return results;
                    }
                }


                //  severance status
                if (createRequirementModel.str_T4_lastSeverenceStatus != "")
                {

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T4_lastSeverenceStatus, createRequirementModel.str_T4_lastSeverenceStatus, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(1000);
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T4_lastSeverenceStatus, createRequirementModel.str_T4_lastSeverenceStatus, false);

                        //return results;
                    }
                }



                //  Reason for Leaving
                if (createRequirementModel.str_T4_lastReasonforLeaving != "")
                {

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T4_lastReasonforLeaving, createRequirementModel.str_T4_lastReasonforLeaving, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(1000);
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T4_lastReasonforLeaving, createRequirementModel.str_T4_lastReasonforLeaving, false);

                        //return results;
                    }
                }


                //  Deaprtment
                if (createRequirementModel.str_T4_lastDeparment != "")
                {

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T4_lastDeparment, createRequirementModel.str_T4_lastDeparment, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(1000);
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T4_lastDeparment, createRequirementModel.str_T4_lastDeparment, false);

                        //return results;
                    }
                }


                //  description for service provided
                if (createRequirementModel.str_T4_lastServicesProvided != "")
                {

                    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T4_lastServicesProvided, createRequirementModel.str_T4_lastServicesProvided, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(1000);
                        results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.Id_T4_lastServicesProvided, createRequirementModel.str_T4_lastServicesProvided, false);

                        //return results;
                    }
                }
            }







            //Justification

            if (createRequirementModel.str_T4_Txt_Justification_soleJustificationDescription != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T4_Txt_Justification_soleJustificationDescription, createRequirementModel.str_T4_Txt_Justification_soleJustificationDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            //Upload Justification
            //Supplier *

            if (createRequirementModel.str_T4_Select_Supplier_supplierName != "")
            {
                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T4_Select_Supplier_supplierName, createRequirementModel.str_T4_Select_Supplier_supplierName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Contract Last Name
            if (createRequirementModel.str_T4_Txt_ContactLastName_recruiterLastName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T4_Txt_ContactLastName_recruiterLastName, createRequirementModel.str_T4_Txt_ContactLastName_recruiterLastName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Contract First Name
            if (createRequirementModel.str_T4_Txt_ContactFirstName_recruiterFirstName != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T4_Txt_ContactFirstName_recruiterFirstName, createRequirementModel.str_T4_Txt_ContactFirstName_recruiterFirstName, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Phone
            if (createRequirementModel.str_T4_Txt_Phone_workPhone != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T4_Txt_Phone_workPhone, createRequirementModel.str_T4_Txt_Phone_workPhone, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Email
            if (createRequirementModel.str_T4_Txt_Email_workEmail != "")
            {
                results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_T4_Txt_Email_workEmail, createRequirementModel.str_T4_Txt_Email_workEmail, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


        }



    }
}