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
    using System;
    using System.Threading;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SmartTrack_Automation;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    public class SubmitCandidatePerClient
    {


       
       
        public static void SubmitCandidateSunTrust(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {

            // ID_select_skillYearsExpID
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_Txt_Comments_lbljustificationDescription))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_Txt_Comments_lbljustificationDescription)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            //Comments 
            if (submitCandidateResumeModel.str_Txt_Comments_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Txt_Comments_lbljustificationDescription, submitCandidateResumeModel.str_Txt_Comments_lbljustificationDescription, false);
            }


            kwm.Action_MoveElement(driver, KeyWords.ID_select_Employmenttype_employmentTypeID);
            //Employement Type
            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_Select_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }


            kwm.click(driver, KeyWords.locator_ID, "rh_contentContainer");
            objCommonMethods.Action_Button_Tab(driver);


            //Skill year
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            //Skill Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Comments
            if (submitCandidateResumeModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
            }


            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }

            //IS Candidate a former Company Contigent Worker
            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }


            Thread.Sleep(2000);
            //Candidate pay rate

            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }
            //Not -to- Exceed Bill rate
            if (submitCandidateResumeModel.str_Txt_NottoExceedBillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Txt_NottoExceedBillRate_supplierRegBillRate, submitCandidateResumeModel.str_Txt_NottoExceedBillRate_supplierRegBillRate, false);
            }

            //Ot Bill Rate - Disabled

            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.Action_Button_Tab(driver);
            //objCommonMethods.Action_Button_Tab(driver);

            //Last 4 Digits of SSN
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                Random rand = new Random();
                string RandomNumberVal = rand.Next(1000, 9999) + "";
                Thread.Sleep(3000);
                results = kwm.sendText_clr(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, RandomNumberVal);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Year
            if (submitCandidateResumeModel.str_select_SSNYear_STID4 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNYear_STID4, submitCandidateResumeModel.str_select_SSNYear_STID4);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }
        
        public static void SubmitCandidateColgate(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {

            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            //Employment Type 
            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            objCommonMethods.Action_Button_Tab(driver);
            objCommonMethods.Action_Page_Down(driver);


            //Skill year
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            //Skill Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Comments
            if (submitCandidateResumeModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
            }

            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            //Thread.Sleep(5000);

            //objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }

            Thread.Sleep(1500);
            objCommonMethods.Action_Page_Down(driver);

            //Candidate Pay Rate *
            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }
            //Candidate OT Pay Rate * 
            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }
            //Bill Rate *
            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_BillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }
            //OT Bill Rate * 
            if (submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_OTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate, false);
            }
            objCommonMethods.Action_Button_Tab(driver);

            objCommonMethods.Action_Page_Down(driver);
            //Last 4 Digits of SSN
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                Thread.Sleep(3000);
                results = kwm.sendText_clr(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Year
            if (submitCandidateResumeModel.str_select_SSNYear_STID4 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNYear_STID4, submitCandidateResumeModel.str_select_SSNYear_STID4);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }

        public static void SubmitCandidateCpchem(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {

            // ID_select_skillYearsExpID
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_select_Employmenttype_employmentTypeID))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_select_Employmenttype_employmentTypeID)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }
            objCommonMethods.Action_Page_Down(driver);
            Thread.Sleep(2000);

            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            //Employment Type
            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            // objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            objCommonMethods.Action_Page_Down(driver);

            //  }

            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }




            objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }




            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToString().ToLower() == "yes")
            {
                //kwm.click(driver, KeyWords.locator_ID, "contractor1");

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");
            }
            else if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToString().ToLower() == "yes")
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }
            else
            {
                // kwm.click(driver, KeyWords.locator_ID, "contractor0");
                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            Thread.Sleep(1500);

            objCommonMethods.Action_Page_Down(driver);


            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }

            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }

            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }

            if (submitCandidateResumeModel.str_txt_BillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierOTBillRate, false);
            }

            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.Action_Button_Tab(driver);
            //objCommonMethods.Action_Button_Tab(driver);

            //Last 4 Digits of SSN
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                Thread.Sleep(3000);
                results = kwm.sendText_clr(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Year
            if (submitCandidateResumeModel.str_select_SSNYear_STID4 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNYear_STID4, submitCandidateResumeModel.str_select_SSNYear_STID4);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }
        
        public static void SubmitCandidateCaesars(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_select_Employmenttype_employmentTypeID))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_select_Employmenttype_employmentTypeID)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }
            objCommonMethods.Action_Page_Down(driver);
            Thread.Sleep(2000);
            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            //Employment Type
            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            // objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }


            //  }

            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            Thread.Sleep(5000);

            //objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }

            objCommonMethods.Action_Page_Down(driver);
            Thread.Sleep(2000);


            //if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToString().ToLower() == "yes")
            //{
            //    //kwm.click(driver, KeyWords.locator_ID, "contractor1");

            //    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");
            //}
            //else if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToString().ToLower() == "yes")
            //{
            //    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            //}
            //else
            //{
            //    // kwm.click(driver, KeyWords.locator_ID, "contractor0");
            //    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            //}

            Thread.Sleep(1500);



            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }

            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }

            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }

            if (submitCandidateResumeModel.str_txt_BillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierOTBillRate, false);
            }

            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.Action_Button_Tab(driver);
            //objCommonMethods.Action_Button_Tab(driver);

            //Last 4 Digits of SSN
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                Thread.Sleep(3000);
                results = kwm.sendText_clr(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Year
            if (submitCandidateResumeModel.str_select_SSNYear_STID4 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNYear_STID4, submitCandidateResumeModel.str_select_SSNYear_STID4);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }

        public static void SubmitCandidateDyncorp(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            //Employment Type 
            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            objCommonMethods.Action_Button_Tab(driver);
            objCommonMethods.Action_Page_Down(driver);


            //Skill year
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            //Skill Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Comments
            if (submitCandidateResumeModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
            }

            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            //Thread.Sleep(5000);

            //objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }

            Thread.Sleep(1500);
            objCommonMethods.Action_Page_Down(driver);

            //Candidate Pay Rate *
            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }
            //Candidate OT Pay Rate * 
            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }
            //Bill Rate *
            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_BillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }
            //OT Bill Rate * 
            if (submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_OTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate, false);
            }
            objCommonMethods.Action_Button_Tab(driver);

            objCommonMethods.Action_Page_Down(driver);
            //Last 4 Digits of SSN
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                Thread.Sleep(3000);
                results = kwm.sendText_clr(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Year
            if (submitCandidateResumeModel.str_select_SSNYear_STID4 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNYear_STID4, submitCandidateResumeModel.str_select_SSNYear_STID4);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }


        #region KeyBank
        public static void SubmitCandidateKeybank(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_select_Employmenttype_employmentTypeID))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_select_Employmenttype_employmentTypeID)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            //justification code added for keybank        
            //Justification      
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }
            objCommonMethods.Action_Page_Down(driver);
            //Employment Type *

            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }





            // Former Employee *
            if (submitCandidateResumeModel.str_radiobutton_FormerEmployee_ExperienceRadio1.ToString().ToLower() == "yes")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Button_Tab(driver);
                    objCommonMethods.Action_Page_Down(driver);
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        objCommonMethods.Action_Button_Tab(driver);
                        objCommonMethods.Action_Page_Down(driver);
                        results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    }

                }

                // added newly pradeep
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);

                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeToDate_toDate1, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1, false);

                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);

                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                //end
            }
            else
            {
                kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio0);
            }




            //  }

            //if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToString().ToLower() == "yes")
            //{
            //    kwm.click(driver, KeyWords.locator_ID, "ExperienceRadio1");
            //}
            //else
            //{
            //    kwm.click(driver, KeyWords.locator_ID, "ExperienceRadio0");
            //}

            //strRadiobtnFormer_Contractor-old one
            //str_radiobutton_FormerContractor_contractor1

            if (submitCandidateResumeModel.str_radiobutton_FormerContractor_contractor1.ToString().ToLower() == "yes")
            {
                kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FromerContractor_contractor1);

                // added newly pradeep
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractor_fromDateContractor1, submitCandidateResumeModel.str_Date_FormerContractor_fromDateContractor1, false);

                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractor_toDateContractor1, submitCandidateResumeModel.str_Date_FormerContractor_toDateContractor1, false);

                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerContractorJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerContractorJobTitle_jobTitle, false);

                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerContractorSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerContractorSupervisor_supervisorName, false);
                //end



            }
            else
            {
                kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FromerContractor_contractor0);
            }

            //added by pradeep 
            //needsto add code for retire 

            if (submitCandidateResumeModel.str_radiobutton_retiree_RetireeRadio1.ToString().ToLower() == "yes")
            {
                kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_retiree_RetireeRadio1);

                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_RetiredDate_RetiredDate, submitCandidateResumeModel.str_Date_RetiredDate_RetiredDate, false);

                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_RetiredJobTitle_RetiredJobTitle, submitCandidateResumeModel.str_txt_RetiredJobTitle_RetiredJobTitle, false);


            }

            else
            {
                kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_retiree_RetireeRadio0);
            }

            //end
            ///



            objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }

            //if (submitCandidateResumeModel.str_Txt_CandidateOTPayRate != "")
            //{
            //    kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Txt_supplierOTPayRate, submitCandidateResumeModel.str_Txt_CandidateOTPayRate, false);
            //}

            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }

            //if (submitCandidateResumeModel.str_Txt_OTBillRate != "")
            //{
            //    kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Txt_supplierOTBillRate, submitCandidateResumeModel.str_Txt_OTBillRate, false);
            //}
            objCommonMethods.Action_Button_Tab(driver);

            Thread.Sleep(3000);
            objCommonMethods.Action_Page_Down(driver);
            //    submitCandidateResumeModel.str_Txt_STID = "";
            //Last 4 Digits of SSN
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                Thread.Sleep(3000);
                results = kwm.sendText_clr(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Year
            if (submitCandidateResumeModel.str_select_SSNYear_STID4 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNYear_STID4, submitCandidateResumeModel.str_select_SSNYear_STID4);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }
        #endregion KeyBank


        public static void SubmitCandidateAltria(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_select_Employmenttype_employmentTypeID)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            objCommonMethods.Action_Page_Down(driver);
            Thread.Sleep(2000);
            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            // objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }


            //  }

            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            Thread.Sleep(5000);

            //objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }

            objCommonMethods.Action_Page_Down(driver);
            Thread.Sleep(2000);


            //if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToString().ToLower() == "yes")
            //{
            //    //kwm.click(driver, KeyWords.locator_ID, "contractor1");

            //    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");
            //}
            //else if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToString().ToLower() == "yes")
            //{
            //    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            //}
            //else
            //{
            //    // kwm.click(driver, KeyWords.locator_ID, "contractor0");
            //    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            //}

            Thread.Sleep(1500);



            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }

            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }

            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }

            if (submitCandidateResumeModel.str_txt_BillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierOTBillRate, false);
            }

            //if (submitCandidateResumeModel.str_Txt_STID != "")
            //{
            //    kwm.sendText(driver, KeyWords.locator_ID, "STID", submitCandidateResumeModel.str_Txt_STID, false);
            //}
            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(driver);
            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(driver);
            //    submitCandidateResumeModel.str_Txt_STID = "";
            string stemp = "";
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(0, 4);
            }
            catch
            {
            }
            //results = kwm.GetText(driver, KeyWords.locator_ID, "STID1");
            //Random random = new Random();
            //if (results.ErrorMessage == "")
            //{
            //    if (stemp == "")
            //    {
            //        int randomNumber = random.Next(1000, 9999);
            //        stemp = randomNumber.ToString();
            //    }

            //    kwm.sendText(driver, KeyWords.locator_ID, "STID1", stemp, false);
            //}

            Random random = new Random();
            if (stemp == "")
            {
                int randomNumber = random.Next(1000, 9999);
                stemp = randomNumber.ToString();
            }
            driver.FindElement(By.Id("STID1")).Clear();
            kwm.sendText(driver, KeyWords.locator_ID, "STID1", stemp, true);
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(4, 2);
            }
            catch
            {
                stemp = "";
            }

            results = kwm.select(driver, KeyWords.locator_ID, "STID2", stemp);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                // stemp = submitCandidateResumeModel.str_Txt_STID.Substring(4, 5);
                kwm.selectByIndex(driver, KeyWords.locator_ID, "STID2", 2);
            }
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(6, 2);
            }
            catch
            {
                stemp = "";
            }

            results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_Select_STID3, stemp);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                kwm.selectByIndex(driver, KeyWords.locator_ID, "STID3", 2);
            }

            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }

        public static void SubmitCandidateDiscover(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {
            try
            {
                //decrease the wait -added for discover
                new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_select_Employmenttype_employmentTypeID))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_select_Employmenttype_employmentTypeID)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            //justification added for discover
            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            objCommonMethods.Action_Page_Down(driver);


            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            objCommonMethods.Action_Button_Tab(driver);
            objCommonMethods.Action_Page_Down(driver);
            Thread.Sleep(2000);
            // objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }


            //  }

            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            Thread.Sleep(5000);

            //objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }

            objCommonMethods.Action_Page_Down(driver);
            Thread.Sleep(2000);


            //if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToString().ToLower() == "yes")
            //{
            //    //kwm.click(driver, KeyWords.locator_ID, "contractor1");

            //    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");
            //}
            //else if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToString().ToLower() == "yes")
            //{
            //    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            //}
            //else
            //{
            //    // kwm.click(driver, KeyWords.locator_ID, "contractor0");
            //    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            //}

            Thread.Sleep(1500);



            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }

            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }

            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }

            if (submitCandidateResumeModel.str_txt_BillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierOTBillRate, false);
            }

            //if (submitCandidateResumeModel.str_Txt_STID != "")
            //{
            //    kwm.sendText(driver, KeyWords.locator_ID, "STID", submitCandidateResumeModel.str_Txt_STID, false);
            //}
            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(driver);
            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(driver);
            //    submitCandidateResumeModel.str_Txt_STID = "";
            string stemp = "";
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(0, 4);
            }
            catch
            {
            }
            //results = kwm.GetText(driver, KeyWords.locator_ID, "STID1");
            //Random random = new Random();
            //if (results.ErrorMessage == "")
            //{
            //    if (stemp == "")
            //    {
            //        int randomNumber = random.Next(1000, 9999);
            //        stemp = randomNumber.ToString();
            //    }

            //    kwm.sendText(driver, KeyWords.locator_ID, "STID1", stemp, false);
            //}

            Random random = new Random();
            if (stemp == "")
            {
                int randomNumber = random.Next(1000, 9999);
                stemp = randomNumber.ToString();
            }
            driver.FindElement(By.Id("STID1")).Clear();
            kwm.sendText(driver, KeyWords.locator_ID, "STID1", stemp, true);
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(4, 2);
            }
            catch
            {
                stemp = "";
            }

            results = kwm.select(driver, KeyWords.locator_ID, "STID2", stemp);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                // stemp = submitCandidateResumeModel.str_Txt_STID.Substring(4, 5);
                kwm.selectByIndex(driver, KeyWords.locator_ID, "STID2", 2);
            }
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(6, 2);
            }
            catch
            {
                stemp = "";
            }

            results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_Select_STID3, stemp);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                kwm.selectByIndex(driver, KeyWords.locator_ID, "STID3", 2);
            }

            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }

        public static void SubmitCandidateWelchallyn(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            //Employment Type 
            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            objCommonMethods.Action_Button_Tab(driver);
            objCommonMethods.Action_Page_Down(driver);


            //Skill year
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            //Skill Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Comments
            if (submitCandidateResumeModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
            }

            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            //Thread.Sleep(5000);

            //objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }

            Thread.Sleep(1500);
            objCommonMethods.Action_Page_Down(driver);

            //Candidate Pay Rate *
            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }
            //Candidate OT Pay Rate * 
            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }
            //Bill Rate *
            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_BillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }
            //OT Bill Rate * 
            if (submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_OTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate, false);
            }


            objCommonMethods.Action_Page_Down(driver);

            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(driver);
            //Thread.Sleep(2000);
            //objCommonMethods.Action_Page_Down(driver);
            //    submitCandidateResumeModel.str_Txt_STID = "";
            string stemp = "";
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(0, 4);
            }
            catch
            {
            }
            //results = kwm.GetText(driver, KeyWords.locator_ID, "STID1");
            //Random random = new Random();
            //if (results.ErrorMessage == "")
            //{
            //    if (stemp == "")
            //    {
            //        int randomNumber = random.Next(1000, 9999);
            //        stemp = randomNumber.ToString();
            //    }

            //    kwm.sendText(driver, KeyWords.locator_ID, "STID1", stemp, false);
            //}

            Random random = new Random();
            if (stemp == "")
            {
                int randomNumber = random.Next(1000, 9999);
                stemp = randomNumber.ToString();
            }
            driver.FindElement(By.Id("STID1")).Clear();
            kwm.sendText(driver, KeyWords.locator_ID, "STID1", stemp, true);
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(4, 2);
            }
            catch
            {
                stemp = "";
            }

            results = kwm.select(driver, KeyWords.locator_ID, "STID2", stemp);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                // stemp = submitCandidateResumeModel.str_Txt_STID.Substring(4, 5);
                kwm.selectByIndex(driver, KeyWords.locator_ID, "STID2", 2);
            }
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(6, 2);
            }
            catch
            {
                stemp = "";
            }

            results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_Select_STID3, stemp);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                kwm.selectByIndex(driver, KeyWords.locator_ID, "STID3", 2);
            }

            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");


        }

        #region SubmitCandidateKCPL
        public static void SubmitCandidateKCPL(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = kwm.isElementEnabled(driver, KeyWords.ID_RadioButton_RetireeYes);
                        //strValue = driver.FindElement(By.Id(KeyWords.ID_RadioButton_RetireeYes)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }
            // Justification to submit the candidate for this requirement/ requisition (max 500 characters)
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
                }
            }
            //Employeement Type *
            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(1000);
                    results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_EmployementType_employmentTypeID, submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID);
                    //return results;
                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            // Skill Description
            objCommonMethods.Action_LookInto_Element_ID(driver, KeyWords.ID_select_YearsExperience_skillYearsExpID);
            Thread.Sleep(3000);

            for (int i = 2; i <= 6; i++)
            {
                // Years Experience
                results = kwm.select(driver, KeyWords.locator_XPath, "//*[@id='skillmatrixtable']//child::tr[" + i + "]//following-sibling::select", submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                Thread.Sleep(500);
                // Level 1     2     3     4     5	
                results = kwm.click(driver, KeyWords.locator_XPath, "//*[@id='skillmatrixtable']//child::tr[" + i + "]//following-sibling::input[2]");
                Thread.Sleep(500);
                // Comments
                kwm.sendText(driver, KeyWords.locator_XPath, "//*[@id='skillmatrixtable']//child::tr[" + i + "]//following-sibling::input[@type='text']", submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
            }

            // Former Employee *
            if (submitCandidateResumeModel.str_radiobutton_FormerEmployee_ExperienceRadio1.ToString().ToLower() == "yes")
            {
                kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeToDate_toDate1, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1, false);
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                //end
            }
            else
            {
                kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio0);
            }

            Thread.Sleep(3000);
            // Former Contractor *
            if (submitCandidateResumeModel.str_radiobutton_FormerContractor_contractor1.ToString().ToLower() == "yes")
            {
                kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FromerContractor_contractor1);
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractor_fromDateContractor1, submitCandidateResumeModel.str_ID_Date_FormerContractor_fromDateContractor1, false);
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractor_toDateContractor1, submitCandidateResumeModel.str_Date_FormerContractor_toDateContractor1, false);
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerContractorJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerContractorJobTitle_jobTitle, false);
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerContractorSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerContractorSupervisor_supervisorName, false);
                //end

            }
            else
            {
                kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FromerContractor_contractor0);
            }
            Thread.Sleep(2000);

            // Retiree    
            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToString().ToLower() == "yes")
            {
                kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_EPRIRetiree_RetireeRadio1);
                Thread.Sleep(1000);
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_RetiredDate_RetiredDate, submitCandidateResumeModel.str_txt_RetiredDate_RetiredDate, false);
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_JobTitle_RetiredJobTitle, submitCandidateResumeModel.str_txt_JobTitle_RetiredJobTitle, false);

            }
            else
            {
                kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_EPRIRetiree_RetireeRadio0);
            }

            objCommonMethods.Action_Page_Down(driver);
            // Candidate Pay Rate
            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }
            // Candidate OT Pay Rate
            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }
            // Bill Rate
            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }
            // 	OT Bill Rate
            if (submitCandidateResumeModel.str_txt_BillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierOTBillRate, false);
            }
            objCommonMethods.Action_Page_Down(driver);


            Thread.Sleep(2000);
            Random random = new Random();

            // Last 4 Digits of SSN *
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                string stemp = "";
                int randomNumber = random.Next(1000, 9999);
                stemp = randomNumber.ToString();
                objCommonMethods.Action_Button_Tab(driver);
                Thread.Sleep(1000);
                objCommonMethods.Action_Button_ShiftTab(driver);
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, stemp, false);
            }
            else
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1, true);
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
        }
        #endregion SubmitCandidateKCPL

        public static void SubmitCandidateTesla(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {

            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_select_Employmenttype_employmentTypeID))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_select_Employmenttype_employmentTypeID)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            kwm.isElementDisplayed(driver, KeyWords.ID_txt_Justification_lbljustificationDescription);

            kwm.waitForElementToBeClickable(driver, By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription), kwm._WDWait);

            // Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {

                results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);

                if (results.Result1 == KeyWords.Result_FAIL)
                {

                }
            }

            // Employee Type
            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            objCommonMethods.Action_Page_Down(driver);
            Thread.Sleep(2000);
            // objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }


            //  }

            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }




            objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }




            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToString().ToLower() == "yes")
            {
                //kwm.click(driver, KeyWords.locator_ID, "contractor1");

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");
            }
            else if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToString().ToLower() == "yes")
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }
            else
            {
                // kwm.click(driver, KeyWords.locator_ID, "contractor0");
                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            Thread.Sleep(1500);




            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }

            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }

            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }

            if (submitCandidateResumeModel.str_txt_BillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierOTBillRate, false);
            }

            objCommonMethods.Action_Button_Tab(driver);

            objCommonMethods.Action_Page_Down(driver);
            //Last 4 Digits of SSN
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                Thread.Sleep(3000);
                results = kwm.sendText_clr_backspace(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Year
            if (submitCandidateResumeModel.str_select_SSNYear_STID4 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNYear_STID4, submitCandidateResumeModel.str_select_SSNYear_STID4);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }


            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }

        #region Epri
        public static void SubmitCandidateEpri(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {

                        //strValue = driver.FindElement(By.Id(KeyWords.ID_select_Employmenttype_employmentTypeID)).Enabled;
                        strValue = kwm.isElementEnabled(driver, KeyWords.ID_select_Employmenttype_employmentTypeID);
                    }
                    catch
                    {
                        strValue = false;
                    }
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }
            // Justification to submit the candidate for this requirement/ requisition (max 500 characters)
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
                }
            }
            Thread.Sleep(1000);

            //Employment Type *
            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            objCommonMethods.Action_Button_Tab(driver);


            // Years Experience
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            // Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            objCommonMethods.Action_Page_Down(driver);
            Thread.Sleep(2000);
            //Comments
            if (submitCandidateResumeModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
                    //return results;
                }
            }


            // Former Employee *
            if (submitCandidateResumeModel.str_radiobutton_FormerEmployee_ExperienceRadio1.ToString().ToLower() == "yes")
            {
                kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                // added newly pradeep
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeToDate_toDate1, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1, false);
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                //end
            }
            else
            {
                kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio0);
            }
            //objCommonMethods.Action_Page_Down(driver);
            Thread.Sleep(3000);

            // Former Contractor *
            if (submitCandidateResumeModel.str_radiobutton_FormerContractor_contractor1.ToString().ToLower() == "yes")
            {
                kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FromerContractor_contractor1);

                // added newly pradeep
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractor_fromDateContractor1, submitCandidateResumeModel.str_ID_Date_FormerContractor_fromDateContractor1, false);
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractor_toDateContractor1, submitCandidateResumeModel.str_Date_FormerContractor_toDateContractor1, false);
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerContractorJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerContractorJobTitle_jobTitle, false);
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerContractorSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerContractorSupervisor_supervisorName, false);
                //end

            }
            else
            {
                kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FromerContractor_contractor0);
            }
            Thread.Sleep(2000);
            //EPRI Retiree    
            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToString().ToLower() == "yes")
            {
                kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_EPRIRetiree_RetireeRadio1);
                Thread.Sleep(1000);
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_RetiredDate_RetiredDate, submitCandidateResumeModel.str_txt_RetiredDate_RetiredDate, false);
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_JobTitle_RetiredJobTitle, submitCandidateResumeModel.str_txt_JobTitle_RetiredJobTitle, false);

            }
            else
            {
                kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_EPRIRetiree_RetireeRadio0);
            }

            Thread.Sleep(3000);
            objCommonMethods.Action_Page_Down(driver);
            // Candidate Pay Rate
            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }
            // Candidate OT Pay Rate
            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }
            // Bill Rate
            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }
            // 	OT Bill Rate
            if (submitCandidateResumeModel.str_txt_BillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierOTBillRate, false);
            }
            objCommonMethods.Action_Page_Down(driver);

            Thread.Sleep(3000);
            Random random = new Random();

            // Last 4 Digits of SSN *
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                string stemp = "";
                int randomNumber = random.Next(1000, 9999);
                stemp = randomNumber.ToString();
                objCommonMethods.Action_Button_Tab(driver);
                Thread.Sleep(1000);
                objCommonMethods.Action_Button_ShiftTab(driver);
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, stemp, false);
            }
            else
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1, true);
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
        }
        #endregion Epri

        public static void SubmitCandidateEBS(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            objCommonMethods.Action_Page_Down(driver);


            //Skill year
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            //Skill Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Comments
            if (submitCandidateResumeModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
            }


            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            Thread.Sleep(5000);

            //objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }



            Thread.Sleep(1500);
            // objCommonMethods.Action_Page_Down(driver);

            //Candidate Pay Rate *
            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }
            //Candidate OT Pay Rate * 
            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }
            //Bill Rate *
            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_BillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }
            //OT Bill Rate * 
            if (submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_OTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate, false);
            }


            objCommonMethods.Action_Page_Down(driver);

            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(driver);
            //Thread.Sleep(2000);
            //objCommonMethods.Action_Page_Down(driver);
            //    submitCandidateResumeModel.str_Txt_STID = "";
            string stemp = "";
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(0, 4);
            }
            catch
            {
            }
            //results = kwm.GetText(driver, KeyWords.locator_ID, "STID1");
            //Random random = new Random();
            //if (results.ErrorMessage == "")
            //{
            //    if (stemp == "")
            //    {
            //        int randomNumber = random.Next(1000, 9999);
            //        stemp = randomNumber.ToString();
            //    }

            //    kwm.sendText(driver, KeyWords.locator_ID, "STID1", stemp, false);
            //}

            Random random = new Random();
            if (stemp == "")
            {
                int randomNumber = random.Next(1000, 9999);
                stemp = randomNumber.ToString();
            }
            driver.FindElement(By.Id("STID1")).Clear();
            kwm.sendText(driver, KeyWords.locator_ID, "STID1", stemp, true);
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(4, 2);
            }
            catch
            {
                stemp = "";
            }

            results = kwm.select(driver, KeyWords.locator_ID, "STID2", stemp);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                // stemp = submitCandidateResumeModel.str_Txt_STID.Substring(4, 5);
                kwm.selectByIndex(driver, KeyWords.locator_ID, "STID2", 2);
            }
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(6, 2);
            }
            catch
            {
                stemp = "";
            }

            results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_Select_STID3, stemp);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                kwm.selectByIndex(driver, KeyWords.locator_ID, "STID3", 2);
            }

            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }

        public static void SubmitCandidateAPS(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_CandidateEmail_Email))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_txt_CandidateEmail_Email)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }


                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            String timeStamp1;
            DateTime date2 = DateTime.Now;
            timeStamp1 = date2.ToString("HHmmssffff");
            //Candidate Email
            if (submitCandidateResumeModel.str_txt_CandidateEmail_Email != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateEmail_Email, timeStamp1 + submitCandidateResumeModel.str_txt_CandidateEmail_Email, false);
            }

            //Gender 
            results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_Gender_Gender, submitCandidateResumeModel.str_select_Gender_Gender);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(driver.FindElement(By.Id(KeyWords.ID_select_Gender_Gender))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Cell Phone
            if (submitCandidateResumeModel.str_txt_CellPhone_mobilePhone != "")
            {
                Thread.Sleep(1000);
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CellPhone_mobilePhone, submitCandidateResumeModel.str_txt_CellPhone_mobilePhone, false);
            }

            //Social Security Number 
            if (submitCandidateResumeModel.str_txt_SocialSecurityNumber_candidateSSN != "")
            {

                string timeStamp;
                DateTime date1 = DateTime.Now;
                timeStamp = date1.ToString("HHmmssffff");
                submitCandidateResumeModel.str_txt_SocialSecurityNumber_candidateSSN = timeStamp;
                //  submitCandidateResumeModel.str_txt_SocialSecurityNumber_candidateSSN = submitCandidateResumeModel.str_txt_SocialSecurityNumber_candidateSSN;
                Thread.Sleep(3000);
                Boolean blnSSNdisplay = false;
                try
                {
                    blnSSNdisplay = driver.FindElement(By.Id(KeyWords.ID_txt_SocialSecurityNumber_candidateSSN)).Displayed;
                }
                catch
                {
                    blnSSNdisplay = false;
                }
                if (blnSSNdisplay)
                    kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SocialSecurityNumber_candidateSSN, submitCandidateResumeModel.str_txt_SocialSecurityNumber_candidateSSN, false);
            }



            // Date Of Birth 
            kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Date_DateofBirth_dob);

            if (submitCandidateResumeModel.str_Date_DateofBirth_dob != "")
            {
                results = kwm.Select_Date_From_Picker(driver, DateTime.Today.AddYears(-20));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_DateofBirth_dob, submitCandidateResumeModel.str_Date_DateofBirth_dob, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }


            //is ssn valid
            if (submitCandidateResumeModel.str_radiobutton_isssnvalid != "")
            {
                if (submitCandidateResumeModel.str_radiobutton_isssnvalid.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_XPath, KeyWords.xpath_radiobutton_isssnvalid_true);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //
                    }
                }
                else
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.xpath_radiobutton_isssnvalid_false);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }





            // Country of Citizenship
            results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_CountryofCitizenship_country, submitCandidateResumeModel.str_select_CountryofCitizenship_country);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(driver.FindElement(By.Id(KeyWords.ID_select_CountryofCitizenship_country))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }
            objCommonMethods.Action_Button_Tab(driver);
            objCommonMethods.Action_Page_Down_withoutjavascriptexecutor(driver);

            //Street
            if (submitCandidateResumeModel.str_txt_Street_address1 != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Street_address1, submitCandidateResumeModel.str_txt_Street_address1, false);
            }

            //City
            if (submitCandidateResumeModel.str_txt_City_city != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_City_city, submitCandidateResumeModel.str_txt_City_city, false);
            }

            //State
            results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_State_state, submitCandidateResumeModel.str_select_State_state);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(driver.FindElement(By.Id(KeyWords.ID_select_State_state))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Zip
            if (submitCandidateResumeModel.str_txt_Zip_zipcode != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Zip_zipcode, submitCandidateResumeModel.str_txt_Zip_zipcode, true);
            }



            //Spouse/Relatives at APS? *
            if (submitCandidateResumeModel.str_radiobutton_SpouseRelativesatAPS != "")
            {
                if (submitCandidateResumeModel.str_radiobutton_SpouseRelativesatAPS.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_XPath, KeyWords.xpath_radiobutton_SpouseRelativesatAPS_True);
                    Thread.Sleep(2000);
                    kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SpouseRelativesName_relativeName, submitCandidateResumeModel.str_txt_SpouseRelativesName_relativeName, false);

                }
                else
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.xpath_radiobutton_spouseRelativesatAPS_False);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }

            //PADS Basis for Action (PV Only) *
            results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_PADSBasisforAction_padsID, submitCandidateResumeModel.str_select_PADSBasisforAction_padsID);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(driver.FindElement(By.Id(KeyWords.ID_select_PADSBasisforAction_padsID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //On Site Arrival Date
            kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Date_OnSiteArrivalDate_processingDate);

            if (submitCandidateResumeModel.str_Date_OnSiteArrivalDate_processingDate != "")
            {
                results = kwm.Select_Date_From_Picker(driver, DateTime.Today.AddDays(-1));
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_OnSiteArrivalDate_processingDate, submitCandidateResumeModel.str_Date_OnSiteArrivalDate_processingDate, false);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            Thread.Sleep(2000);

            kwm.Action_LookInto_Element(driver, KeyWords.locator_XPath, KeyWords.xpath_radiobutton_Referral_True);
            //Referral
            if (submitCandidateResumeModel.str_btn_Referral_Yes_No != "")
            {
                if (submitCandidateResumeModel.str_btn_Referral_Yes_No.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_XPath, KeyWords.xpath_radiobutton_Referral_True);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //
                    }
                }
                else
                {
                    results = kwm.click(driver, KeyWords.locator_XPath, KeyWords.xpath_radiobutton_Referral_False);

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //  return results;
                    }
                }
            }

            //Former Employee
            results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_FormerEmployee_isFormallyEmployeed, submitCandidateResumeModel.str_select_FormerEmployee_isFormallyEmployeed);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(driver.FindElement(By.Id(KeyWords.ID_select_FormerEmployee_isFormallyEmployeed))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }

            //Native American (Fossil Only) *
            results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_NativeAmericanFossilOnly_nativeAmericanID, submitCandidateResumeModel.str_select_NativeAmericanFossilOnly_nativeAmericanID);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(driver.FindElement(By.Id(KeyWords.ID_select_NativeAmericanFossilOnly_nativeAmericanID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }


            // Eligibility to work at work location  - Missing ------- id: eligibilityID
            results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_Eligibilitytoworkatworklocation_eligibilityID, submitCandidateResumeModel.str_select_Eligibilitytoworkatworklocation_eligibilityID);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    try
                    {
                        SelectElement se = new SelectElement(driver.FindElement(By.Id(KeyWords.ID_select_Eligibilitytoworkatworklocation_eligibilityID))); //Locating select list
                        se.SelectByIndex(1);
                    }
                    catch
                    {
                        //
                    }
                }
            }


            //Resume 
            if (submitCandidateResumeModel.str_Txt_UploadFilePath != "")
            {

                if (File.Exists(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateResumeModel.str_Txt_UploadFilePath))
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
                            driver.FindElement(By.Name(KeyWords.NAME_Link_qqfile)).SendKeys(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateResumeModel.str_Txt_UploadFilePath);
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
                                driver.FindElement(By.Name(KeyWords.NAME_uploadresume)).SendKeys(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateResumeModel.str_Txt_UploadFilePath);
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
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "The given resume path not find" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateResumeModel.str_Txt_UploadFilePath, 3);
                }

            }


            Thread.Sleep(2000);
            //Justification to submit the candidate for this requirement/ requisition
            if (submitCandidateResumeModel.str_Txt_Justificationtosubmitthecandidateforthisrequirementrequisition_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Txt_Justificationtosubmitthecandidateforthisrequirementrequisition_lbljustificationDescription, submitCandidateResumeModel.str_Txt_Justificationtosubmitthecandidateforthisrequirementrequisition_lbljustificationDescription, false);
            }






            // Years Experience
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            // Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            objCommonMethods.Action_Page_Down(driver);

            // Candidate Pay Rate
            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }


            // Bill Rate
            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_BillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }

            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.Action_Button_Tab(driver);
            //objCommonMethods.Action_Button_Tab(driver);

            //Last 4 Digits of SSN
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                Thread.Sleep(3000);
                results = kwm.sendText_clr(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Year
            if (submitCandidateResumeModel.str_select_SSNYear_STID4 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNYear_STID4, submitCandidateResumeModel.str_select_SSNYear_STID4);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }

        public static void SubmitCandidateHillRom(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            //Employment Type 
            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            objCommonMethods.Action_Button_Tab(driver);
            objCommonMethods.Action_Page_Down(driver);


            //Skill year
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            //Skill Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Comments
            if (submitCandidateResumeModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
            }

            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            //Thread.Sleep(5000);

            //objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //objCommonMethods.Action_Page_Down(driver);
            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }

            Thread.Sleep(1500);
            objCommonMethods.Action_Page_Down(driver);

            //Candidate Pay Rate *
            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }
            //Candidate OT Pay Rate * 
            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }
            //Bill Rate *
            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_BillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }
            //OT Bill Rate * 
            if (submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_OTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate, false);
            }


            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.Action_Button_Tab(driver);
            //objCommonMethods.Action_Button_Tab(driver);

            //Last 4 Digits of SSN
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                Thread.Sleep(3000);
                results = kwm.sendText_clr(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Year
            if (submitCandidateResumeModel.str_select_SSNYear_STID4 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNYear_STID4, submitCandidateResumeModel.str_select_SSNYear_STID4);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }
        
        public static void SubmitCandidateSOF(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {
            // ID_select_skillYearsExpID
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            objCommonMethods.Action_Page_Down(driver);
            //Skill year
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            //Skill Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Comments
            if (submitCandidateResumeModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
            }


            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            Thread.Sleep(5000);

            //objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }



            Thread.Sleep(1500);
            // objCommonMethods.Action_Page_Down(driver);

            //Candidate Pay Rate *
            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }
            //Candidate OT Pay Rate * 
            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }
            //Bill Rate *
            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_BillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }
            //OT Bill Rate * 
            if (submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_OTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate, false);
            }


            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.Action_Button_Tab(driver);
            //objCommonMethods.Action_Button_Tab(driver);

            //Last 4 Digits of SSN
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                Thread.Sleep(3000);
                results = kwm.sendText_clr(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Year
            if (submitCandidateResumeModel.str_select_SSNYear_STID4 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNYear_STID4, submitCandidateResumeModel.str_select_SSNYear_STID4);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }
        
        public static void SubmitCandidateStsClient(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {
            // ID_select_skillYearsExpID
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            objCommonMethods.Action_Page_Down(driver);


            //Skill year
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            //Skill Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Comments
            if (submitCandidateResumeModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
            }


            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            Thread.Sleep(5000);

            //objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }



            Thread.Sleep(1500);
            // objCommonMethods.Action_Page_Down(driver);

            //Candidate Pay Rate *
            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }
            //Candidate OT Pay Rate * 
            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }
            //Bill Rate *
            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_BillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }
            //OT Bill Rate * 
            if (submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_OTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate, false);
            }


            objCommonMethods.Action_Page_Down(driver);

            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(driver);
            //Thread.Sleep(2000);
            //objCommonMethods.Action_Page_Down(driver);
            //    submitCandidateResumeModel.str_Txt_STID = "";
            string stemp = "";
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(0, 4);
            }
            catch
            {
            }
            //results = kwm.GetText(driver, KeyWords.locator_ID, "STID1");
            //Random random = new Random();
            //if (results.ErrorMessage == "")
            //{
            //    if (stemp == "")
            //    {
            //        int randomNumber = random.Next(1000, 9999);
            //        stemp = randomNumber.ToString();
            //    }

            //    kwm.sendText(driver, KeyWords.locator_ID, "STID1", stemp, false);
            //}

            Random random = new Random();
            if (stemp == "")
            {
                int randomNumber = random.Next(1000, 9999);
                stemp = randomNumber.ToString();
            }
            driver.FindElement(By.Id("STID1")).Clear();
            kwm.sendText(driver, KeyWords.locator_ID, "STID1", stemp, true);
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(4, 2);
            }
            catch
            {
                stemp = "";
            }

            results = kwm.select(driver, KeyWords.locator_ID, "STID2", stemp);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                // stemp = submitCandidateResumeModel.str_Txt_STID.Substring(4, 5);
                kwm.selectByIndex(driver, KeyWords.locator_ID, "STID2", 2);
            }
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(6, 2);
            }
            catch
            {
                stemp = "";
            }

            results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_Select_STID3, stemp);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                kwm.selectByIndex(driver, KeyWords.locator_ID, "STID3", 2);
            }

            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }

        public static void SubmitCandidateStewartTitle(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_select_Employmenttype_employmentTypeID)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            objCommonMethods.Action_Button_Tab(driver);
            Thread.Sleep(2000);

            //Employement Type
            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //requistion Click
            results = kwm.click(driver, KeyWords.locator_ID, "CLSRNumber");
            // objCommonMethods.Action_Button_Tab(driver);
            Thread.Sleep(2000);


            objCommonMethods.Action_Page_Down(driver);

            //YearsExperience
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            Thread.Sleep(2000);
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }


            //  }

            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            Thread.Sleep(5000);

            //objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }
            Thread.Sleep(1500);



            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }

            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }

            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }

            if (submitCandidateResumeModel.str_txt_BillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierOTBillRate, false);
            }
            objCommonMethods.Action_Button_Tab(driver);
            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(driver);





            //Last 4 Digits of SSN
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                Thread.Sleep(3000);
                results = kwm.sendText_clr(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            objCommonMethods.Action_Button_Tab(driver);
            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Year
            if (submitCandidateResumeModel.str_select_SSNYear_STID4 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNYear_STID4, submitCandidateResumeModel.str_select_SSNYear_STID4);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }

        #region ThermoFisher
        public static void SubmitCandidateThermoFisher(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {

            // ID_select_skillYearsExpID
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_Select_employmentTypeID))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_Select_employmentTypeID)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            Thread.Sleep(2000);
            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            kwm.Action_MoveElement(driver, KeyWords.ID_select_Employmenttype_employmentTypeID);
            //Employement Type
            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_Select_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            kwm.click(driver, KeyWords.locator_ID, "rh_contentContainer");
            objCommonMethods.Action_Button_Tab(driver);


            //Skill year
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            //Skill Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Comments
            if (submitCandidateResumeModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
            }


            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            Thread.Sleep(5000);



            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }



            Thread.Sleep(1500);
            objCommonMethods.Action_Page_Down(driver);

            //Candidate Pay Rate *
            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }
            //Candidate OT Pay Rate * 
            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }
            //Bill Rate *
            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_BillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }
            //OT Bill Rate * 
            if (submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_OTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate, false);
            }


            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.Action_Button_Tab(driver);
            //objCommonMethods.Action_Button_Tab(driver);

            //Last 4 Digits of SSN
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                Thread.Sleep(3000);
                results = kwm.sendText_clr(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Year
            if (submitCandidateResumeModel.str_select_SSNYear_STID4 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNYear_STID4, submitCandidateResumeModel.str_select_SSNYear_STID4);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }
        #endregion ThermoFisher

        public static void SubmitCandidateRMS(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {
            // ID_select_skillYearsExpID
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            objCommonMethods.Action_Page_Down(driver);


            //Skill year
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            //Skill Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Comments
            if (submitCandidateResumeModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
            }


            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            Thread.Sleep(5000);

            //objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }



            Thread.Sleep(1500);
            // objCommonMethods.Action_Page_Down(driver);

            //Candidate Pay Rate *
            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }
            //Candidate OT Pay Rate * 
            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }
            //Bill Rate *
            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_BillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }
            //OT Bill Rate * 
            if (submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_OTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate, false);
            }


            objCommonMethods.Action_Page_Down(driver);

            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(driver);
            //Thread.Sleep(2000);
            //objCommonMethods.Action_Page_Down(driver);
            //    submitCandidateResumeModel.str_Txt_STID = "";
            string stemp = "";
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(0, 4);
            }
            catch
            {
            }
            //results = kwm.GetText(driver, KeyWords.locator_ID, "STID1");
            //Random random = new Random();
            //if (results.ErrorMessage == "")
            //{
            //    if (stemp == "")
            //    {
            //        int randomNumber = random.Next(1000, 9999);
            //        stemp = randomNumber.ToString();
            //    }

            //    kwm.sendText(driver, KeyWords.locator_ID, "STID1", stemp, false);
            //}

            Random random = new Random();
            if (stemp == "")
            {
                int randomNumber = random.Next(1000, 9999);
                stemp = randomNumber.ToString();
            }
            driver.FindElement(By.Id("STID1")).Clear();
            kwm.sendText(driver, KeyWords.locator_ID, "STID1", stemp, true);
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(4, 2);
            }
            catch
            {
                stemp = "";
            }

            results = kwm.select(driver, KeyWords.locator_ID, "STID2", stemp);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                // stemp = submitCandidateResumeModel.str_Txt_STID.Substring(4, 5);
                kwm.selectByIndex(driver, KeyWords.locator_ID, "STID2", 2);
            }
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(6, 2);
            }
            catch
            {
                stemp = "";
            }

            results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_Select_STID3, stemp);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                kwm.selectByIndex(driver, KeyWords.locator_ID, "STID3", 2);
            }

            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }

        public static void SubmitCandidateQuickenLoans(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {

            // ID_select_skillYearsExpID
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Email_Email))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_txt_Email_Email)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            String timeStamp;
            // String timeStamp = GetTimestamp(DateTime.Now);
            DateTime date1 = DateTime.Now;
            timeStamp = date1.ToString("HHmmssffff");

            //Email
            if (submitCandidateResumeModel.str_txt_Email_Email != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Email_Email, timeStamp + submitCandidateResumeModel.str_txt_Email_Email, false);
            }


            Thread.Sleep(2000);
            //Comment
            if (submitCandidateResumeModel.str_Txt_Comments_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Txt_Comments_lbljustificationDescription, submitCandidateResumeModel.str_Txt_Comments_lbljustificationDescription, false);
            }

            kwm.Action_LookInto_Element(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID);
            kwm.Action_MoveElement(driver, KeyWords.ID_select_Employmenttype_employmentTypeID);

            //Employement Type
            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_Select_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            kwm.click(driver, KeyWords.locator_ID, "rh_contentContainer");
            objCommonMethods.Action_Button_Tab(driver);


            //Skill year
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            //Skill Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Comments
            if (submitCandidateResumeModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
            }


            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            Thread.Sleep(5000);



            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }




            Thread.Sleep(1500);
            objCommonMethods.Action_Page_Down(driver);

            //Candidate Pay Rate *
            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }
            //Candidate OT Pay Rate * 
            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }
            //Bill Rate *
            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_BillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }
            //OT Bill Rate * 
            if (submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_OTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate, false);
            }


            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.Action_Button_Tab(driver);
            //objCommonMethods.Action_Button_Tab(driver);

            //Last 4 Digits of SSN
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                Thread.Sleep(3000);
                results = kwm.sendText_clr(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Year
            if (submitCandidateResumeModel.str_select_SSNYear_STID4 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNYear_STID4, submitCandidateResumeModel.str_select_SSNYear_STID4);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }

        #region MFC
        public static void SubmitCandidateMFC(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {
            // ID_select_skillYearsExpID
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            objCommonMethods.Action_Page_Down(driver);


            //Skill year
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            //Skill Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Comments
            if (submitCandidateResumeModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
            }


            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            Thread.Sleep(5000);

            //objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }



            Thread.Sleep(1500);
            // objCommonMethods.Action_Page_Down(driver);

            //Candidate Pay Rate *
            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }
            //Candidate OT Pay Rate * 
            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }
            //Bill Rate *
            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_BillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }
            //OT Bill Rate * 
            if (submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_OTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate, false);
            }


            objCommonMethods.Action_Page_Down(driver);

            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(driver);
            //Thread.Sleep(2000);
            //objCommonMethods.Action_Page_Down(driver);
            //    submitCandidateResumeModel.str_Txt_STID = "";
            string stemp = "";
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(0, 4);
            }
            catch
            {
            }
            //results = kwm.GetText(driver, KeyWords.locator_ID, "STID1");
            //Random random = new Random();
            //if (results.ErrorMessage == "")
            //{
            //    if (stemp == "")
            //    {
            //        int randomNumber = random.Next(1000, 9999);
            //        stemp = randomNumber.ToString();
            //    }

            //    kwm.sendText(driver, KeyWords.locator_ID, "STID1", stemp, false);
            //}

            Random random = new Random();
            if (stemp == "")
            {
                int randomNumber = random.Next(1000, 9999);
                stemp = randomNumber.ToString();
            }
            driver.FindElement(By.Id("STID1")).Clear();
            kwm.sendText(driver, KeyWords.locator_ID, "STID1", stemp, true);
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(4, 2);
            }
            catch
            {
                stemp = "";
            }

            results = kwm.select(driver, KeyWords.locator_ID, "STID2", stemp);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                // stemp = submitCandidateResumeModel.str_Txt_STID.Substring(4, 5);
                kwm.selectByIndex(driver, KeyWords.locator_ID, "STID2", 2);
            }
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(6, 2);
            }
            catch
            {
                stemp = "";
            }

            results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_Select_STID3, stemp);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                kwm.selectByIndex(driver, KeyWords.locator_ID, "STID3", 2);
            }

            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }
        #endregion MFC

        public static void SubmitCandidateBimbo(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }
            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }


            //Employeement Type

            if (submitCandidateResumeModel.str_Select_employmentTypeID != "")
            {
                results = kwm.selectDynamicDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_Select_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_Select_employmentTypeID, submitCandidateResumeModel.str_Select_employmentTypeID);
                }
            }


            driver.FindElement(By.Id("CLSRNumber")).Click();
            objCommonMethods.Action_Page_Down(driver);
            Thread.Sleep(2000);
            //HastheNonEmployeebeenofferedACACompliantHealthCoverage
            if (submitCandidateResumeModel.str_select_HastheNonEmployeebeenofferedACACompliantHealthCoverage_ACACompliantHealthCoverage != "")
            {
                results = kwm.selectDynamicDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_HastheNonEmployeebeenofferedACACompliantHealthCoverage_ACACompliantHealthCoverage);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_HastheNonEmployeebeenofferedACACompliantHealthCoverage_ACACompliantHealthCoverage, submitCandidateResumeModel.str_select_HastheNonEmployeebeenofferedACACompliantHealthCoverage_ACACompliantHealthCoverage);
                }
            }

            //ACA Cost Per
            if (submitCandidateResumeModel.str_select_ACACostPer_ACACostPer != "")
            {
                results = kwm.selectDynamicDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_ACACostPer_ACACostPer);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_ACACostPer_ACACostPer, submitCandidateResumeModel.str_select_ACACostPer_ACACostPer);
                }
            }

            //ACA Cost
            if (submitCandidateResumeModel.str_txt_ACACost_ACACost != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_ACACost_ACACost, submitCandidateResumeModel.str_txt_ACACost_ACACost, false);
            }

            //Supplier Operating Company
            if (submitCandidateResumeModel.str_select_SupplierOperatingCompany_OperativeCompany != "")
            {
                results = kwm.selectDynamicDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_SupplierOperatingCompany_OperativeCompany);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_SupplierOperatingCompany_OperativeCompany, submitCandidateResumeModel.str_select_SupplierOperatingCompany_OperativeCompany);
                }
            }

            //Skill year
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            //Skill Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Comments
            if (submitCandidateResumeModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
            }


            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            Thread.Sleep(5000);

            //objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }



            Thread.Sleep(1500);
            objCommonMethods.Action_Page_Down(driver);

            //Candidate Pay Rate *
            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }
            //Candidate OT Pay Rate * 
            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }
            //Bill Rate *
            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_BillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }
            //OT Bill Rate * 
            if (submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_OTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate, false);
            }

            objCommonMethods.Action_Page_Down(driver);

            objCommonMethods.Action_Button_Tab(driver);
            objCommonMethods.Action_Button_Tab(driver);

            //Last 4 Digits of SSN
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                Thread.Sleep(3000);
                results = kwm.sendText_clr(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Year
            if (submitCandidateResumeModel.str_select_SSNYear_STID4 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNYear_STID4, submitCandidateResumeModel.str_select_SSNYear_STID4);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");



        }

        public static void SubmitCandidateGeorgeTown(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {

            // ID_select_skillYearsExpID
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_Select_employmentTypeID))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_Select_employmentTypeID)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            Thread.Sleep(2000);
            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            //Employement Type
            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_Select_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            kwm.click(driver, KeyWords.locator_ID, "rh_contentContainer");
            objCommonMethods.Action_Button_Tab(driver);


            //Skill year
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            //Skill Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Comments
            if (submitCandidateResumeModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
            }


            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            Thread.Sleep(5000);



            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }



            Thread.Sleep(1500);
            objCommonMethods.Action_Page_Down(driver);

            //Candidate Pay Rate *
            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }
            //Candidate OT Pay Rate * 
            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }
            //Bill Rate *
            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_BillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }
            //OT Bill Rate * 
            if (submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_OTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate, false);
            }


            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.Action_Button_Tab(driver);
            //objCommonMethods.Action_Button_Tab(driver);

            //Last 4 Digits of SSN
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                Thread.Sleep(3000);
                results = kwm.sendText_clr(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Year
            if (submitCandidateResumeModel.str_select_SSNYear_STID4 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNYear_STID4, submitCandidateResumeModel.str_select_SSNYear_STID4);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }

        public static void SubmitCandidateCOE(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {

            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_select_Employmenttype_employmentTypeID)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            objCommonMethods.Action_Button_Tab(driver);
            Thread.Sleep(2000);

            //Employement Type
            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //requistion Click
            results = kwm.click(driver, KeyWords.locator_ID, "CLSRNumber");
            // objCommonMethods.Action_Button_Tab(driver);
            Thread.Sleep(2000);


            objCommonMethods.Action_Page_Down(driver);
            //Supplier Operations Company
            if (submitCandidateResumeModel.str_select_SupplierOperationsCompany_OperativeCompany != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_SupplierOperationsCompany_OperativeCompany, submitCandidateResumeModel.str_select_SupplierOperationsCompany_OperativeCompany);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            // objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }


            //  }

            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            Thread.Sleep(5000);

            //objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }

            //objCommonMethods.Action_Page_Down(driver);
            //Thread.Sleep(2000);


            //if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToString().ToLower() == "yes")
            //{
            //    //kwm.click(driver, KeyWords.locator_ID, "contractor1");

            //    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");
            //}
            //else if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToString().ToLower() == "yes")
            //{
            //    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            //}
            //else
            //{
            //    // kwm.click(driver, KeyWords.locator_ID, "contractor0");
            //    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            //}

            Thread.Sleep(1500);



            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }

            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }

            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }

            if (submitCandidateResumeModel.str_txt_BillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierOTBillRate, false);
            }

            objCommonMethods.Action_Page_Down(driver);

            objCommonMethods.Action_Button_Tab(driver);
            objCommonMethods.Action_Button_Tab(driver);

            //Last 4 Digits of SSN
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                Thread.Sleep(3000);
                results = kwm.sendText_clr(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Year
            if (submitCandidateResumeModel.str_select_SSNYear_STID4 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNYear_STID4, submitCandidateResumeModel.str_select_SSNYear_STID4);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }

        public static void SubmitCandidatePHHMortgage(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {
            // ID_select_skillYearsExpID
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            //Employement Type
            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_Select_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            kwm.click(driver, KeyWords.locator_ID, "rh_contentContainer");
            objCommonMethods.Action_Button_Tab(driver);


            //Skill year
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            //Skill Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Comments
            if (submitCandidateResumeModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
            }


            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            Thread.Sleep(5000);



            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }



            Thread.Sleep(1500);
            objCommonMethods.Action_Page_Down(driver);

            //Candidate Pay Rate *
            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }
            //Candidate OT Pay Rate * 
            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }
            //Bill Rate *
            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_BillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }
            //OT Bill Rate * 
            if (submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_OTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate, false);
            }


            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.Action_Button_Tab(driver);
            //objCommonMethods.Action_Button_Tab(driver);

            //Last 4 Digits of SSN
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                Thread.Sleep(3000);
                results = kwm.sendText_clr(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Year
            if (submitCandidateResumeModel.str_select_SSNYear_STID4 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNYear_STID4, submitCandidateResumeModel.str_select_SSNYear_STID4);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }

        public static void SubmitCandidateTufts(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            //Employement Type
            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_Select_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            kwm.click(driver, KeyWords.locator_ID, "rh_contentContainer");
            objCommonMethods.Action_Button_Tab(driver);


            //Skill year
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            //Skill Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Comments
            if (submitCandidateResumeModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
            }


            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            Thread.Sleep(5000);



            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }



            Thread.Sleep(1500);
            objCommonMethods.Action_Page_Down(driver);

            //Candidate Pay Rate *
            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }
            //Candidate OT Pay Rate * 
            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }
            //Bill Rate *
            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_BillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }
            objCommonMethods.Action_Button_Tab(driver);
            Thread.Sleep(2000);
            //OT Bill Rate * 
            if (submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_OTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate, false);
            }


            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.Action_Button_Tab(driver);
            //objCommonMethods.Action_Button_Tab(driver);

            //Last 4 Digits of SSN
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                Thread.Sleep(3000);
                results = kwm.sendText_clr(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Year
            if (submitCandidateResumeModel.str_select_SSNYear_STID4 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNYear_STID4, submitCandidateResumeModel.str_select_SSNYear_STID4);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }

        public static void SubmitCandidateSTGEN(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {
            // ID_select_skillYearsExpID
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            objCommonMethods.Action_Page_Down(driver);


            //Skill year
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            //Skill Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Comments
            if (submitCandidateResumeModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
            }


            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            Thread.Sleep(5000);

            //objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }



            Thread.Sleep(1500);
            // objCommonMethods.Action_Page_Down(driver);

            //Candidate Pay Rate *
            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }
            //Candidate OT Pay Rate * 
            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }
            //Bill Rate *
            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_BillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }
            //OT Bill Rate * 
            if (submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_OTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate, false);
            }


            objCommonMethods.Action_Page_Down(driver);

            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(driver);
            //Thread.Sleep(2000);
            //objCommonMethods.Action_Page_Down(driver);
            //    submitCandidateResumeModel.str_Txt_STID = "";
            string stemp = "";
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(0, 4);
            }
            catch
            {
            }
            //results = kwm.GetText(driver, KeyWords.locator_ID, "STID1");
            //Random random = new Random();
            //if (results.ErrorMessage == "")
            //{
            //    if (stemp == "")
            //    {
            //        int randomNumber = random.Next(1000, 9999);
            //        stemp = randomNumber.ToString();
            //    }

            //    kwm.sendText(driver, KeyWords.locator_ID, "STID1", stemp, false);
            //}

            Random random = new Random();
            if (stemp == "")
            {
                int randomNumber = random.Next(1000, 9999);
                stemp = randomNumber.ToString();
            }
            driver.FindElement(By.Id("STID1")).Clear();
            kwm.sendText(driver, KeyWords.locator_ID, "STID1", stemp, true);
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(4, 2);
            }
            catch
            {
                stemp = "";
            }

            results = kwm.select(driver, KeyWords.locator_ID, "STID2", stemp);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                // stemp = submitCandidateResumeModel.str_Txt_STID.Substring(4, 5);
                kwm.selectByIndex(driver, KeyWords.locator_ID, "STID2", 2);
            }
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(6, 2);
            }
            catch
            {
                stemp = "";
            }

            results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_Select_STID3, stemp);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                kwm.selectByIndex(driver, KeyWords.locator_ID, "STID3", 2);
            }

            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }

        #region Supervalu
        public static void SubmitCandidateSupervalu(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_select_Employmenttype_employmentTypeID))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_select_Employmenttype_employmentTypeID)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }


            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            objCommonMethods.Action_Page_Down(driver);
            Thread.Sleep(2000);
            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            // objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }


            //  }

            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            Thread.Sleep(5000);

            //objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }

            objCommonMethods.Action_Page_Down(driver);
            Thread.Sleep(2000);


            //if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToString().ToLower() == "yes")
            //{
            //    //kwm.click(driver, KeyWords.locator_ID, "contractor1");

            //    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");
            //}
            //else if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToString().ToLower() == "yes")
            //{
            //    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            //}
            //else
            //{
            //    // kwm.click(driver, KeyWords.locator_ID, "contractor0");
            //    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            //}

            Thread.Sleep(1500);



            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }

            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }

            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }

            if (submitCandidateResumeModel.str_txt_BillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierOTBillRate, false);
            }

            //if (submitCandidateResumeModel.str_Txt_STID != "")
            //{
            //    kwm.sendText(driver, KeyWords.locator_ID, "STID", submitCandidateResumeModel.str_Txt_STID, false);
            //}
            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(driver);
            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(driver);
            //    submitCandidateResumeModel.str_Txt_STID = "";
            string stemp = "";
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(0, 4);
            }
            catch
            {
            }
            //results = kwm.GetText(driver, KeyWords.locator_ID, "STID1");
            //Random random = new Random();
            //if (results.ErrorMessage == "")
            //{
            //    if (stemp == "")
            //    {
            //        int randomNumber = random.Next(1000, 9999);
            //        stemp = randomNumber.ToString();
            //    }

            //    kwm.sendText(driver, KeyWords.locator_ID, "STID1", stemp, false);
            //}

            Random random = new Random();
            if (stemp == "")
            {
                int randomNumber = random.Next(1000, 9999);
                stemp = randomNumber.ToString();
            }
            driver.FindElement(By.Id("STID1")).Clear();
            kwm.sendText(driver, KeyWords.locator_ID, "STID1", stemp, true);
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(4, 2);
            }
            catch
            {
                stemp = "";
            }

            results = kwm.select(driver, KeyWords.locator_ID, "STID2", stemp);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                // stemp = submitCandidateResumeModel.str_Txt_STID.Substring(4, 5);
                kwm.selectByIndex(driver, KeyWords.locator_ID, "STID2", 2);
            }
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(6, 2);
            }
            catch
            {
                stemp = "";
            }

            results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_Select_STID3, stemp);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                kwm.selectByIndex(driver, KeyWords.locator_ID, "STID3", 2);
            }

            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }
        #endregion Supervalu

        #region Emerson
        public static void SubmitCandidateEmerson(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {

            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_select_Employmenttype_employmentTypeID)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            objCommonMethods.Action_Page_Down(driver);
            Thread.Sleep(2000);
            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            // objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }


            //  }

            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            Thread.Sleep(5000);

            //objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }

            objCommonMethods.Action_Page_Down(driver);
            Thread.Sleep(2000);


            //if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToString().ToLower() == "yes")
            //{
            //    //kwm.click(driver, KeyWords.locator_ID, "contractor1");

            //    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");
            //}
            //else if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToString().ToLower() == "yes")
            //{
            //    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            //}
            //else
            //{
            //    // kwm.click(driver, KeyWords.locator_ID, "contractor0");
            //    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            //}

            Thread.Sleep(1500);



            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }

            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }

            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }

            if (submitCandidateResumeModel.str_txt_BillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierOTBillRate, false);
            }

            //if (submitCandidateResumeModel.str_Txt_STID != "")
            //{
            //    kwm.sendText(driver, KeyWords.locator_ID, "STID", submitCandidateResumeModel.str_Txt_STID, false);
            //}
            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(driver);
            Thread.Sleep(2000);
            objCommonMethods.Action_Page_Down(driver);
            //    submitCandidateResumeModel.str_Txt_STID = "";
            string stemp = "";
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(0, 4);
            }
            catch
            {
            }
            //results = kwm.GetText(driver, KeyWords.locator_ID, "STID1");
            //Random random = new Random();
            //if (results.ErrorMessage == "")
            //{
            //    if (stemp == "")
            //    {
            //        int randomNumber = random.Next(1000, 9999);
            //        stemp = randomNumber.ToString();
            //    }

            //    kwm.sendText(driver, KeyWords.locator_ID, "STID1", stemp, false);
            //}

            Random random = new Random();
            if (stemp == "")
            {
                int randomNumber = random.Next(1000, 9999);
                stemp = randomNumber.ToString();
            }
            driver.FindElement(By.Id("STID1")).Clear();
            kwm.sendText(driver, KeyWords.locator_ID, "STID1", stemp, true);
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(4, 2);
            }
            catch
            {
                stemp = "";
            }

            results = kwm.select(driver, KeyWords.locator_ID, "STID2", stemp);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                // stemp = submitCandidateResumeModel.str_Txt_STID.Substring(4, 5);
                kwm.selectByIndex(driver, KeyWords.locator_ID, "STID2", 2);
            }
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(6, 2);
            }
            catch
            {
                stemp = "";
            }

            results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_Select_STID3, stemp);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                kwm.selectByIndex(driver, KeyWords.locator_ID, "STID3", 2);
            }

            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }
        #endregion Emerson

        public static void SubmitCandidateArkema(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            //Employment Type 
            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            objCommonMethods.Action_Button_Tab(driver);
            objCommonMethods.Action_Page_Down(driver);


            //Skill year
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            //Skill Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Comments
            if (submitCandidateResumeModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
            }

            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            //Thread.Sleep(5000);

            //objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }

            Thread.Sleep(1500);
            objCommonMethods.Action_Page_Down(driver);

            //Candidate Pay Rate *
            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }
            //Candidate OT Pay Rate * 
            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }
            //Bill Rate *
            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_BillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }
            //OT Bill Rate * 
            if (submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_OTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate, false);
            }
            objCommonMethods.Action_Button_Tab(driver);

            objCommonMethods.Action_Page_Down(driver);

            //Last 4 Digits of SSN
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                Thread.Sleep(3000);
                results = kwm.sendText_clr(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Year
            if (submitCandidateResumeModel.str_select_SSNYear_STID4 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNYear_STID4, submitCandidateResumeModel.str_select_SSNYear_STID4);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }


        #region Workspend-SallieMae
        public static void SubmitCandidateWorkspendSallieMae(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {


            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_select_Employmenttype_employmentTypeID)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            objCommonMethods.Action_Page_Down(driver);
            Thread.Sleep(2000);
            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            kwm.click(driver, KeyWords.locator_ID, "rh_contentContainer");
            objCommonMethods.Action_Button_Tab(driver);


            //Skill year
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            //Skill Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Comments
            if (submitCandidateResumeModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
            }


            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            Thread.Sleep(5000);

            //objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            kwm.Action_LookInto_Element(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3);
            Thread.Sleep(1500);
            // objCommonMethods.Action_Page_Down(driver);

            //Candidate Pay Rate *
            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }
            //Candidate OT Pay Rate * 
            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }
            //Bill Rate *
            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_BillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }
            //OT Bill Rate * 
            if (submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_OTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate, false);
            }


            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.Action_Button_Tab(driver);
            //objCommonMethods.Action_Button_Tab(driver);

            //Last 4 Digits of SSN
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                Thread.Sleep(3000);
                results = kwm.sendText_clr(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Year
            if (submitCandidateResumeModel.str_select_SSNYear_STID4 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNYear_STID4, submitCandidateResumeModel.str_select_SSNYear_STID4);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }
        #endregion Workspend-SallieMae

        public static void SubmitCandidateSTTM(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            objCommonMethods.Action_Page_Down(driver);


            //Skill year
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            //Skill Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Comments
            if (submitCandidateResumeModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
            }


            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }


            Thread.Sleep(5000);

            //objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.strRadiobtnFormer_Contractor != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "1");

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }

            //Retiree

            if (submitCandidateResumeModel.str_RadioButton_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "1");
                    //If select yes below code is working

                    //Retired Data

                    DateTime date = DateTime.Today;
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredDate)).SendKeys("date");

                    //Job Title
                    driver.FindElement(By.Id(KeyWords.ID_Txt_RetiredJobTitle)).SendKeys("test");

                }
                else
                {
                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
                }

            }
            else
            {
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }



            Thread.Sleep(1500);
            // objCommonMethods.Action_Page_Down(driver);

            //Candidate Pay Rate *
            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }
            //Candidate OT Pay Rate * 
            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }
            //Bill Rate *
            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_BillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }
            //OT Bill Rate * 
            if (submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_OTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate, false);
            }


            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.Action_Button_Tab(driver);
            //objCommonMethods.Action_Button_Tab(driver);

            //Last 4 Digits of SSN
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                Thread.Sleep(3000);
                results = kwm.sendText_clr(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                kwm.waitForElementToBeClickable(driver, By.Id(KeyWords.ID_select_SSNMonth_STID2), kwm._WDWait);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                kwm.waitForElementToBeClickable(driver, By.Id(KeyWords.ID_select_SSNDate_STID3), kwm._WDWait);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Year
            if (submitCandidateResumeModel.str_select_SSNYear_STID4 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNYear_STID4, submitCandidateResumeModel.str_select_SSNYear_STID4);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }

        public static void SubmitCandidateYP(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {
            // ID_select_skillYearsExpID
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_txt_Justification_lbljustificationDescription)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            //Justification 
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            objCommonMethods.Action_Page_Down(driver);
            //Skill year
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            //Skill Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Comments
            if (submitCandidateResumeModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
            }

            //PriorYPHoldingsorATTemployee

            if (submitCandidateResumeModel.str_btn_PriorYPHoldingsorATTemployee_ExperienceRadio != "")
            {
                if (submitCandidateResumeModel.str_btn_PriorYPHoldingsorATTemployee_ExperienceRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_btn_PriorYPHoldingsorATTemployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_PriorYPHoldingsorATTemployee_FromDate);

                    if (submitCandidateResumeModel.str_Date_PriorYPHoldingsorATTemployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_PriorYPHoldingsorATTemployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_PriorYPHoldingsorATTemployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_PriorYPHoldingsorATTemployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_PriorYPHoldingsorATTemployeeFromDate_fromDate1);
                    }

                    //To Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_PriorYPHoldingsorATTemployee_ToDate);

                    if (submitCandidateResumeModel.str_Date_PriorYPHoldingsorATTemployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_PriorYPHoldingsorATTemployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_PriorYPHoldingsorATTemployeeToDate_toDate1, submitCandidateResumeModel.str_Date_PriorYPHoldingsorATTemployeeToDate_toDate1, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_PriorYPHoldingsorATTemployeeTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_PriorYPHoldingsorATTemployeeTitle_jobTitle, submitCandidateResumeModel.str_txt_PriorYPHoldingsorATTemployeeTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_PriorYPHoldingsorATTemployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_PriorYPHoldingsorATTemployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_PriorYPHoldingsorATTemployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }

            //Prior YP Holdings or AT&T contractor
            if (submitCandidateResumeModel.str_btn_PriorYPHoldingsorATTcontractor_contractor != "")
            {
                if (submitCandidateResumeModel.str_btn_PriorYPHoldingsorATTcontractor_contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_btn_PriorYPHoldingsorATTcontractor_contractor1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_PriorYPHoldingsorATTcontractor_FromDate);

                    if (submitCandidateResumeModel.str_Date_PriorYPHoldingsorATTcontractorFromDate_fromDateContractor1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_PriorYPHoldingsorATTcontractorFromDate_fromDateContractor1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_PriorYPHoldingsorATTcontractorFromDate_fromDateContractor1, submitCandidateResumeModel.str_Date_PriorYPHoldingsorATTcontractorFromDate_fromDateContractor1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_PriorYPHoldingsorATTcontractorToDate_toDateContractor1);
                    }

                    //To Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_PriorYPHoldingsorATTcontractor_ToDate);

                    if (submitCandidateResumeModel.str_Date_PriorYPHoldingsorATTcontractorToDate_toDateContractor1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_PriorYPHoldingsorATTcontractorToDate_toDateContractor1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_PriorYPHoldingsorATTcontractorToDate_toDateContractor1, submitCandidateResumeModel.str_Date_PriorYPHoldingsorATTcontractorToDate_toDateContractor1, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_PriorYPHoldingsorATTcontractorTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_PriorYPHoldingsorATTcontractorTitle_jobTitle, submitCandidateResumeModel.str_txt_PriorYPHoldingsorATTcontractorTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_PriorYPHoldingsorATTcontractorSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_PriorYPHoldingsorATTcontractorSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ContractorRadio", "0");
            }


            Thread.Sleep(5000);

            //YP Holdings or AT&T Retiree
            if (submitCandidateResumeModel.str_btn_YPHoldingsorATTRetiree_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_btn_YPHoldingsorATTRetiree_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_btn_YPHoldingsorATTRetiree_RetireeRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_YPHoldingsorATTRetiree_RetiredDate);

                    if (submitCandidateResumeModel.str_Date_YPHoldingsorATTRetireeRetiredDate_RetiredDate != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_YPHoldingsorATTRetireeRetiredDate_RetiredDate);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_YPHoldingsorATTRetireeRetiredDate_RetiredDate, submitCandidateResumeModel.str_Date_YPHoldingsorATTRetireeRetiredDate_RetiredDate, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_YPHoldingsorATTRetireeRetiredDate_RetiredDate);
                    }

                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "RetireeRadio", "0");

                }

                //Job Title 
                if (submitCandidateResumeModel.str_txt_YPHoldingsorATTRetireeTitle_RetiredJobTitle != "")
                {
                    kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_YPHoldingsorATTRetireeTitle_RetiredJobTitle, submitCandidateResumeModel.str_txt_YPHoldingsorATTRetireeTitle_RetiredJobTitle, false);
                }





            }





            //if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToString().ToLower() == "yes")
            //{
            //    kwm.click(driver, KeyWords.locator_ID, "ExperienceRadio1");
            //}
            //else
            //{
            //    kwm.click(driver, KeyWords.locator_ID, "ExperienceRadio0");
            //}

            //if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToString().ToLower() == "yes")
            //{
            //    kwm.click(driver, KeyWords.locator_ID, "contractor1");
            //}
            //else
            //{
            //    kwm.click(driver, KeyWords.locator_ID, "contractor0");
            //}

            //objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.str_Txt_CandidatePayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Txt_supplierRegPayRate, submitCandidateResumeModel.str_Txt_CandidatePayRate, false);
            }

            if (submitCandidateResumeModel.str_Txt_CandidateOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Txt_supplierOTPayRate, submitCandidateResumeModel.str_Txt_CandidateOTPayRate, false);
            }

            if (submitCandidateResumeModel.str_Txt_BillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Txt_supplierRegBillRate, submitCandidateResumeModel.str_Txt_BillRate, false);
            }

            if (submitCandidateResumeModel.str_Txt_OTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Txt_supplierOTBillRate, submitCandidateResumeModel.str_Txt_OTBillRate, false);
            }

            //if (submitCandidateResumeModel.str_Txt_STID != "")
            //{
            //    kwm.sendText(driver, KeyWords.locator_ID, "STID", submitCandidateResumeModel.str_Txt_STID, false);
            //}

            objCommonMethods.Action_Page_Down(driver);

            objCommonMethods.Action_Button_Tab(driver);
            objCommonMethods.Action_Button_Tab(driver);

            //Last 4 Digits of SSN
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                Thread.Sleep(3000);
                results = kwm.sendText_clr(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Year
            if (submitCandidateResumeModel.str_select_SSNYear_STID4 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNYear_STID4, submitCandidateResumeModel.str_select_SSNYear_STID4);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            ////    submitCandidateResumeModel.str_Txt_STID = "";
            //string stemp = "";
            //try
            //{
            //    stemp = submitCandidateResumeModel.str_Txt_STID.Substring(0, 4);
            //}
            //catch
            //{
            //}
            ////results = kwm.GetText(driver, KeyWords.locator_ID, "STID1");
            ////Random random = new Random();
            ////if (results.ErrorMessage == "")
            ////{
            ////    if (stemp == "")
            ////    {
            ////        int randomNumber = random.Next(1000, 9999);
            ////        stemp = randomNumber.ToString();
            ////    }

            ////    kwm.sendText(driver, KeyWords.locator_ID, "STID1", stemp, false);
            ////}

            //Random random = new Random();
            //if (stemp == "")
            //{
            //    int randomNumber = random.Next(1000, 9999);
            //    stemp = randomNumber.ToString();
            //}
            //driver.FindElement(By.Id("STID1")).Clear();
            //kwm.sendText(driver, KeyWords.locator_ID, "STID1", stemp, true);
            //try
            //{
            //    stemp = submitCandidateResumeModel.str_Txt_STID.Substring(4, 2);
            //}
            //catch
            //{
            //    stemp = "";
            //}

            //results = kwm.select(driver, KeyWords.locator_ID, "STID2", stemp);
            //if (results.Result1 == KeyWords.Result_FAIL)
            //{
            //    // stemp = submitCandidateResumeModel.str_Txt_STID.Substring(4, 5);
            //    kwm.selectByIndex(driver, KeyWords.locator_ID, "STID2", 2);
            //}
            //try
            //{
            //    stemp = submitCandidateResumeModel.str_Txt_STID.Substring(6, 2);
            //}
            //catch
            //{
            //    stemp = "";
            //}

            //results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_Select_STID3, stemp);
            //if (results.Result1 == KeyWords.Result_FAIL)
            //{
            //    kwm.selectByIndex(driver, KeyWords.locator_ID, "STID3", 2);
            //}

            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }

        public static void SubmitCandidatelear(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {

            // ID_select_skillYearsExpID
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_Select_employmentTypeID))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_Select_employmentTypeID)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            //Resume 
            if (submitCandidateResumeModel.str_Txt_UploadFilePath != "")
            {

                if (File.Exists(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateResumeModel.str_Txt_UploadFilePath))
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
                            driver.FindElement(By.Name(KeyWords.NAME_Link_qqfile)).SendKeys(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateResumeModel.str_Txt_UploadFilePath);
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
                                driver.FindElement(By.Name(KeyWords.NAME_uploadresume)).SendKeys(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateResumeModel.str_Txt_UploadFilePath);
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
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "The given resume path not find" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateResumeModel.str_Txt_UploadFilePath, 3);
                }

            }


            Thread.Sleep(2000);
            //Justification to submit the candidate for this requirement/ requisition
            if (submitCandidateResumeModel.str_Txt_Justificationtosubmitthecandidateforthisrequirementrequisition_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Txt_Justificationtosubmitthecandidateforthisrequirementrequisition_lbljustificationDescription, submitCandidateResumeModel.str_Txt_Justificationtosubmitthecandidateforthisrequirementrequisition_lbljustificationDescription, false);
            }

            //Upload Additional Documents
            if (submitCandidateResumeModel.str_Txt_UploadAdditionalDocument != "")
            {

                if (File.Exists(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateResumeModel.str_Txt_UploadAdditionalDocument))
                {

                    try
                    {

                        if (KeyWords.NAME_uploadAdditionalDocuments_resumedocumentsInput == "resumedocumentsInput" && kwm.isElementPresent(driver, KeyWords.NAME_uploadAdditionalDocuments_resumedocumentsInput))
                        {
                            //   kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Link_btnresumeupload);
                            // Thread.Sleep(30);
                            //WDriver.FindElement(By.Name(KeyWords.NAME_Link_qqfile)).Click();
                            //   kwm.click(driver, KeyWords.NAME_icon_UploadResume_qqfile, KeyWords.ID_Link_btnresumeupload);
                            // driver.FindElement(By.Id(KeyWords.ID_Link_btnresumeupload)).
                            driver.FindElement(By.Name(KeyWords.NAME_Link_qqfile)).SendKeys(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateResumeModel.str_Txt_UploadAdditionalDocument);
                            Thread.Sleep(1000);

                            //  Actions action = new Actions(driver);
                            //   action.SendKeys(OpenQA.Selenium.Keys.Escape);
                            //  action.SendKeys(System.Windows.Forms.Keys.Escape);
                            System.Windows.Forms.SendKeys.SendWait("{ESC}");
                            Thread.Sleep(1000);

                        }

                        //else
                        //{

                        //    if (KeyWords.NAME_icon_UploadResume_uploadResume == "uploadResume" && kwm.isElementPresent(driver, KeyWords.NAME_uploadresume))
                        //    {
                        //        kwm.click(driver, KeyWords.NAME_uploadresume, KeyWords.ID_Link_btnresumeupload);
                        //        driver.FindElement(By.Name(KeyWords.NAME_uploadresume)).SendKeys(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateResumeModel.str_Txt_UploadAdditionalDocument);
                        //        Thread.Sleep(1000);

                        //        Actions action = new Actions(driver);
                        //        action.SendKeys(OpenQA.Selenium.Keys.Escape);
                        //        action.SendKeys(System.Windows.Forms.Keys.Escape);
                        //        System.Windows.Forms.SendKeys.SendWait("{ESC}");
                        //        Thread.Sleep(1000);
                        //    }
                        //}


                    }


                    catch (Exception uplod)
                    {
                        string strUploaderror = uplod.Message;
                    }
                }
                else
                {
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "The given resume path not find" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateResumeModel.str_Txt_UploadAdditionalDocument, 3);
                }

            }



            //Employement Type
            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_Select_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            kwm.click(driver, KeyWords.locator_ID, "rh_contentContainer");
            objCommonMethods.Action_Button_Tab(driver);


            //Skill year
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            //Skill Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Comments
            if (submitCandidateResumeModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
            }


            //Previous Employee

            if (submitCandidateResumeModel.str_Radiobutton_PreviousEmployee_ExperienceRadio != "")
            {
                if (submitCandidateResumeModel.str_Radiobutton_PreviousEmployee_ExperienceRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Radiobutton_PreviousEmployee_ExperienceRadio1);


                    kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Date_PreviousEmployeeFromDate_fromDate1);

                    if (submitCandidateResumeModel.str_Date_PreviousEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_PreviousEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_PreviousEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_PreviousEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_PreviousEmployeeFromDate_fromDate1);
                    }

                    //End Date


                    kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Date_PreviousEmployeeToDate_toDate1);

                    if (submitCandidateResumeModel.str_Date_PreviousEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_PreviousEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_PreviousEmployeeToDate_toDate1, submitCandidateResumeModel.str_Date_PreviousEmployeeToDate_toDate1, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_Previousemployeejobtitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Previousemployeejobtitle_jobTitle, submitCandidateResumeModel.str_txt_Previousemployeejobtitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_PreviousemployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_PreviousemployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_PreviousemployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button_ID(driver, KeyWords.ID_Radiobutton_PreviousEmployee_ExperienceRadio0, "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button_ID(driver, KeyWords.ID_Radiobutton_PreviousEmployee_ExperienceRadio0, "0");
            }


            Thread.Sleep(2000);

            //Previous CW

            if (submitCandidateResumeModel.str_Radiobutton_PreviousCW_contractor != "")
            {
                if (submitCandidateResumeModel.str_Radiobutton_PreviousCW_contractor.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Radiobutton_PreviousCW_contractor1);


                    kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Date_PreviousCW_fromDateContractor1);

                    if (submitCandidateResumeModel.str_Date_PreviousCW_fromDateContractor1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_PreviousCW_fromDateContractor1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_PreviousCW_fromDateContractor1, submitCandidateResumeModel.str_Date_PreviousCW_fromDateContractor1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_PreviousCW_fromDateContractor1);
                    }

                    //End Date


                    kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Date_PreviousCW_toDateContractor1);

                    if (submitCandidateResumeModel.str_Date_PreviousCW_toDateContractor1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_PreviousCW_toDateContractor1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_PreviousCW_toDateContractor1, submitCandidateResumeModel.str_Date_PreviousCW_toDateContractor1, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_Txt_PreviousCWjobtitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Txt_PreviousCWjobtitle_jobTitle, submitCandidateResumeModel.str_Txt_PreviousCWjobtitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_Txt_PreviousCWSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Txt_PreviousCWSupervisor_supervisorName, submitCandidateResumeModel.str_Txt_PreviousCWSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button_ID(driver, KeyWords.ID_Radiobutton_PreviousCW_contractor0, "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button_ID(driver, KeyWords.ID_Radiobutton_PreviousCW_contractor0, "0");
            }



            //Retiree
            if (submitCandidateResumeModel.str_RadioButton_Retiree_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_Retiree_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Radiobutton_PreviousCW_contractor1);


                    kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Date_RetiredDate_RetiredDate);

                    if (submitCandidateResumeModel.str_Date_RetiredDate_RetiredDate != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_RetiredDate_RetiredDate);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_RetiredDate_RetiredDate, submitCandidateResumeModel.str_Date_RetiredDate_RetiredDate, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_RetiredDate_RetiredDate);
                    }


                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_RetireeJobTitle_RetiredJobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_RetireeJobTitle_RetiredJobTitle, submitCandidateResumeModel.str_txt_RetireeJobTitle_RetiredJobTitle, false);
                    }


                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button_ID(driver, KeyWords.ID_RadioButton_Retiree_RetireeRadio0, "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, KeyWords.ID_RadioButton_Retiree_RetireeRadio0, "0");
            }

            //In which currency do you want to submit the candidate ?
            if (submitCandidateResumeModel.str_Select_InWhichCurrencydoyouwanttosubmittheCandidate_currencyID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_Select_InWhichCurrencydoyouwanttosubmittheCandidate_currencyID, submitCandidateResumeModel.str_Select_InWhichCurrencydoyouwanttosubmittheCandidate_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }



            Thread.Sleep(1500);
            objCommonMethods.Action_Page_Down(driver);

            //Candidate Pay Rate *
            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }
            //Candidate OT Pay Rate * 
            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }
            //Bill Rate *
            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_BillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }
            //OT Bill Rate * 
            if (submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_OTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate, false);
            }


            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.Action_Button_Tab(driver);
            //objCommonMethods.Action_Button_Tab(driver);

            //Last 4 Digits of SSN
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                Thread.Sleep(3000);
                results = kwm.sendText_clr(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Year
            if (submitCandidateResumeModel.str_select_SSNYear_STID4 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNYear_STID4, submitCandidateResumeModel.str_select_SSNYear_STID4);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }

        #region EQT
        public static void SubmitCandidateEQT(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {


            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_Txt_Comments_lbljustificationDescription))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_Txt_Comments_lbljustificationDescription)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            // Justification
            if (submitCandidateResumeModel.str_Txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_Txt_Justification_lbljustificationDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            // Upload Additional Documents:



            // Employment Type *
            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_Select_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_Select_employmentTypeID);
                }
            }

            // Skill year
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }

            Thread.Sleep(2000);
            // Skill Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Comments
            if (submitCandidateResumeModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
            }

            //Former Employee *
            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    // From Date *
                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        Thread.Sleep(500);
                        kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Date_FormerEmployeeFromDate_fromDate1);
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FormerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Date_FormerEmployeeFromDate_fromDate1);
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    // To Date *

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Date_FormerEmployeeToDate_toDate1);
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FormerEmployeeToDate_toDate1, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1, false);
                        }

                    }

                    // Job Title *
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_XPath, KeyWords.Xpath_txt_FromerEmployeeJobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_XPath, KeyWords.Xpath_txt_FromerEmployeeSupervisor, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor, false);
                    }

                    // Former Contractor
                    if (submitCandidateResumeModel.strRadiobtnFormer_Contractor.ToString().ToLower() == "yes")
                    {
                        results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_RadioButton_contractorYes);

                        // From Date *
                        if (submitCandidateResumeModel.str_Date_FormerContractor_fromDateContractor1 != "")
                        {
                            kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractorFromDate_fromDateContractor1);

                            results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FormerContractor_fromDateContractor1);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractor_fromDateContractor1, submitCandidateResumeModel.str_Date_FormerContractor_fromDateContractor1, false);
                                if (results.Result1 == KeyWords.Result_FAIL)
                                {
                                    //return results;
                                }
                            }
                        }
                        else
                        {
                            results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FormerContractor_fromDateContractor1);
                        }

                        // To Date *

                        if (submitCandidateResumeModel.str_Date_FormerContractor_toDateContractor1 != "")
                        {
                            kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractorToDate_toDateContractor1);
                            results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FormerContractor_toDateContractor1);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractor_toDateContractor1, submitCandidateResumeModel.str_Date_FormerContractor_toDateContractor1, false);
                            }

                        }

                        else
                        {
                            results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FormerContractor_toDateContractor1);
                        }

                        // Job Title 
                        if (submitCandidateResumeModel.str_txt_FromerContractorJobTitle_jobTitle != "")
                        {
                            kwm.sendText(driver, KeyWords.locator_XPath, KeyWords.Xpath_txt_FromerContractorJobTitle, submitCandidateResumeModel.str_txt_FromerContractorJobTitle_jobTitle, false);
                        }

                        // Supervisor
                        if (submitCandidateResumeModel.str_txt_FromerContractorSupervisor_supervisorName != "")
                        {
                            kwm.sendText(driver, KeyWords.locator_XPath, KeyWords.Xpath_txt_FromerContractorSupervisor, submitCandidateResumeModel.str_txt_FromerContractorSupervisor_supervisorName, false);
                        }


                    }
                    else
                    {
                        kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_RadioButton_contractorNo);
                    }


                    //Retiree

                    if (submitCandidateResumeModel.str_radiobutton_retiree_RetireeRadio1.ToString().ToLower() == "yes")
                    {
                        kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_retiree_RetireeRadio1);

                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_RetiredDate_RetiredDate, submitCandidateResumeModel.str_Date_RetiredDate_RetiredDate, false);

                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_RetiredJobTitle_RetiredJobTitle, submitCandidateResumeModel.str_txt_RetiredJobTitle_RetiredJobTitle, false);


                    }

                    else
                    {
                        kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_retiree_RetireeRadio0);
                    }



                    Thread.Sleep(2000);
                    //Candidate Pay Rate *
                    if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
                    }
                    //Candidate OT Pay Rate * 
                    if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
                    }
                    //Bill Rate *
                    if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_BillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
                    }
                    //OT Bill Rate * 
                    if (submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_OTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate, false);
                    }

                    objCommonMethods.Action_Page_Down(driver);
                    objCommonMethods.Action_Button_Tab(driver);
                    //objCommonMethods.Action_Button_Tab(driver);

                    //Last 4 Digits of SSN
                    if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
                    {
                        Random rand = new Random();
                        string RandomNumberVal = rand.Next(1000, 9999) + "";
                        Thread.Sleep(3000);
                        results = kwm.sendText_clr(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, RandomNumberVal);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }
                    }

                    // Birth Month *
                    if (submitCandidateResumeModel.str_select_BirthMonth_STID2 != "")
                    {
                        results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_BirthMonth_STID2, submitCandidateResumeModel.str_select_BirthMonth_STID2);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }
                    }

                    // Birth Day *
                    if (submitCandidateResumeModel.str_select_BirthDay_STID3 != "")
                    {
                        results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_BirthDay_STID3, submitCandidateResumeModel.str_select_BirthDay_STID3);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            // return results;
                        }
                    }


                    objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");

                }
            }
        }
        #endregion EQT


        public static void SubmitCandidateSIGMA(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {

            // ID_select_skillYearsExpID
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_Select_employmentTypeID))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_Select_employmentTypeID)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            //Resume 
            if (submitCandidateResumeModel.str_Txt_UploadFilePath != "")
            {

                if (File.Exists(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateResumeModel.str_Txt_UploadFilePath))
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
                            driver.FindElement(By.Name(KeyWords.NAME_Link_qqfile)).SendKeys(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateResumeModel.str_Txt_UploadFilePath);
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
                                driver.FindElement(By.Name(KeyWords.NAME_uploadresume)).SendKeys(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateResumeModel.str_Txt_UploadFilePath);
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
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "The given resume path not find" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateResumeModel.str_Txt_UploadFilePath, 3);
                }

            }


            Thread.Sleep(2000);
            //Justification *
            if (submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justification_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justification_lbljustificationDescription, false);
            }

            //Upload Additional Documents
            if (submitCandidateResumeModel.str_Txt_UploadAdditionalDocument != "")
            {

                if (File.Exists(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateResumeModel.str_Txt_UploadAdditionalDocument))
                {

                    try
                    {

                        if (KeyWords.NAME_uploadAdditionalDocuments_resumedocumentsInput == "resumedocumentsInput" && kwm.isElementPresent(driver, KeyWords.NAME_uploadAdditionalDocuments_resumedocumentsInput))
                        {
                            //   kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Link_btnresumeupload);
                            // Thread.Sleep(30);
                            //WDriver.FindElement(By.Name(KeyWords.NAME_Link_qqfile)).Click();
                            //   kwm.click(driver, KeyWords.NAME_icon_UploadResume_qqfile, KeyWords.ID_Link_btnresumeupload);
                            // driver.FindElement(By.Id(KeyWords.ID_Link_btnresumeupload)).
                            driver.FindElement(By.Name(KeyWords.NAME_Link_qqfile)).SendKeys(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateResumeModel.str_Txt_UploadAdditionalDocument);
                            Thread.Sleep(1000);

                            //  Actions action = new Actions(driver);
                            //   action.SendKeys(OpenQA.Selenium.Keys.Escape);
                            //  action.SendKeys(System.Windows.Forms.Keys.Escape);
                            System.Windows.Forms.SendKeys.SendWait("{ESC}");
                            Thread.Sleep(1000);

                        }

                        //else
                        //{

                        //    if (KeyWords.NAME_icon_UploadResume_uploadResume == "uploadResume" && kwm.isElementPresent(driver, KeyWords.NAME_uploadresume))
                        //    {
                        //        kwm.click(driver, KeyWords.NAME_uploadresume, KeyWords.ID_Link_btnresumeupload);
                        //        driver.FindElement(By.Name(KeyWords.NAME_uploadresume)).SendKeys(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateResumeModel.str_Txt_UploadAdditionalDocument);
                        //        Thread.Sleep(1000);

                        //        Actions action = new Actions(driver);
                        //        action.SendKeys(OpenQA.Selenium.Keys.Escape);
                        //        action.SendKeys(System.Windows.Forms.Keys.Escape);
                        //        System.Windows.Forms.SendKeys.SendWait("{ESC}");
                        //        Thread.Sleep(1000);
                        //    }
                        //}


                    }


                    catch (Exception uplod)
                    {
                        string strUploaderror = uplod.Message;
                    }
                }
                else
                {
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "The given resume path not find" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + submitCandidateResumeModel.str_Txt_UploadAdditionalDocument, 3);
                }

            }



            //Employement Type
            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_Select_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            kwm.click(driver, KeyWords.locator_ID, "rh_contentContainer");
            objCommonMethods.Action_Button_Tab(driver);


            //Skill year
            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }
            Thread.Sleep(2000);

            //Skill Level
            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //Comments
            if (submitCandidateResumeModel.str_txt_Comments_supplierComments != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Comments_supplierComments, submitCandidateResumeModel.str_txt_Comments_supplierComments, false);
            }


            //Former Employee

            if (submitCandidateResumeModel.strRadiobtnFormer_Employee != "")
            {
                if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_FromDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);
                    }

                    //End Date

                    kwm.click(driver, KeyWords.locator_XPath, KeyWords.Xpath_Date_FormerEmployeeFromDate_ToDate);

                    if (submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_T1_Date_PlannedEndDate_enddate, submitCandidateResumeModel.strDateAssignmentEnd, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, "ExperienceRadio", "0");
            }




            Thread.Sleep(2000);

            //Former Contractor 

            if (submitCandidateResumeModel.str_radiobutton_FormerContractor_contractor1 != "")
            {
                if (submitCandidateResumeModel.str_radiobutton_FormerContractor_contractor1.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FromerContractor_contractor1);


                    kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractor_fromDateContractor1);

                    if (submitCandidateResumeModel.str_Date_FormerContractor_fromDateContractor1 != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FormerContractor_fromDateContractor1);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractor_fromDateContractor1, submitCandidateResumeModel.str_Date_FormerContractor_fromDateContractor1, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_FormerContractor_fromDateContractor1);
                    }

                    //End Date


                    kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractor_toDateContractor1);

                    if (submitCandidateResumeModel.str_Date_FormerContractor_toDateContractor1 != "")
                    {
                        results = kwm.Select_End_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_FormerContractor_toDateContractor1);


                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractor_toDateContractor1, submitCandidateResumeModel.str_Date_FormerContractor_toDateContractor1, false);
                        }

                    }

                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_FromerContractorJobTitle_jobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerContractorJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerContractorJobTitle_jobTitle, false);
                    }

                    // Supervisor
                    if (submitCandidateResumeModel.str_txt_FromerContractorSupervisor_supervisorName != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerContractorSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerContractorSupervisor_supervisorName, false);
                    }



                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button_ID(driver, KeyWords.ID_radiobutton_FromerContractor_contractor0, "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button_ID(driver, KeyWords.ID_radiobutton_FromerContractor_contractor0, "0");
            }



            //Retiree
            if (submitCandidateResumeModel.str_RadioButton_Retiree_RetireeRadio != "")
            {
                if (submitCandidateResumeModel.str_RadioButton_Retiree_RetireeRadio.ToLower().Equals(KeyWords.str_String_Compare_yes))
                {
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Radiobutton_PreviousCW_contractor1);


                    kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_Date_RetiredDate_RetiredDate);

                    if (submitCandidateResumeModel.str_Date_RetiredDate_RetiredDate != "")
                    {
                        results = kwm.Select_Start_Date_From_Picker(driver, submitCandidateResumeModel.str_Date_RetiredDate_RetiredDate);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            results = kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_RetiredDate_RetiredDate, submitCandidateResumeModel.str_Date_RetiredDate_RetiredDate, false);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                //return results;
                            }
                        }
                    }
                    else
                    {
                        results = kwm.Select_Date_In_DatePicker(driver, submitCandidateResumeModel.str_Date_RetiredDate_RetiredDate);
                    }


                    //Job Title 
                    if (submitCandidateResumeModel.str_txt_RetireeJobTitle_RetiredJobTitle != "")
                    {
                        kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_RetireeJobTitle_RetiredJobTitle, submitCandidateResumeModel.str_txt_RetireeJobTitle_RetiredJobTitle, false);
                    }


                }
                else
                {

                    results = objCommonMethods.Select_Radio_Button_ID(driver, KeyWords.ID_RadioButton_Retiree_RetireeRadio0, "0");

                }
            }
            else
            {

                Thread.Sleep(2000);
                results = objCommonMethods.Select_Radio_Button(driver, KeyWords.ID_RadioButton_Retiree_RetireeRadio0, "0");
            }

            //In which currency do you want to submit the candidate ?
            if (submitCandidateResumeModel.str_Select_InWhichCurrencydoyouwanttosubmittheCandidate_currencyID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_Select_InWhichCurrencydoyouwanttosubmittheCandidate_currencyID, submitCandidateResumeModel.str_Select_InWhichCurrencydoyouwanttosubmittheCandidate_currencyID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }



            Thread.Sleep(1500);
            objCommonMethods.Action_Page_Down(driver);

            //Candidate Pay Rate *
            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }
            //Candidate OT Pay Rate * 
            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }
            //Bill Rate *
            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_BillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }
            //OT Bill Rate * 
            if (submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_OTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate, false);
            }


            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.Action_Button_Tab(driver);
            //objCommonMethods.Action_Button_Tab(driver);

            //Last 4 Digits of SSN
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                Thread.Sleep(3000);
                results = kwm.sendText_clr(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Year
            if (submitCandidateResumeModel.str_select_SSNYear_STID4 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNYear_STID4, submitCandidateResumeModel.str_select_SSNYear_STID4);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }



            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }

        #region Ryder
        public static void SubmitCandidateRyder(SubmitCandidateResumeModel submitCandidateResumeModel, Result results, KeyWordMethods kwm, IWebDriver driver, CommonMethods objCommonMethods)
        {


            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(300)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_select_Employmenttype_employmentTypeID))));
            }
            catch
            {
                for (int z = 1; z < 10; z++)
                {
                    Boolean strValue = false;
                    try
                    {
                        strValue = driver.FindElement(By.Id(KeyWords.ID_select_Employmenttype_employmentTypeID)).Enabled;
                    }
                    catch
                    {
                        strValue = false;
                    }

                    //  Console.WriteLine("z -----> " + z);
                    //  Console.WriteLine("strValue -----> " + strValue);
                    Thread.Sleep(100);
                    if (strValue)
                    {
                        break;
                    }
                }
            }

            // Justification to submit the candidate for this requirement/ requisition (max 500 characters) * 
            if (submitCandidateResumeModel.str_txt_Justificationtosubmitthecandidateforthisrequirementrequisitionmax500characters_lbljustificationDescription != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_Justificationtosubmitthecandidateforthisrequirementrequisitionmax500characters_lbljustificationDescription, submitCandidateResumeModel.str_txt_Justificationtosubmitthecandidateforthisrequirementrequisitionmax500characters_lbljustificationDescription, false);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            // Employment Type - id: employmentTypeID (Dropdown)

            if (submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID != "")
            {
                results = kwm.selectInDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_select_Employmenttype_employmentTypeID, submitCandidateResumeModel.str_select_Employmenttype_employmentTypeID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }
            objCommonMethods.Action_Page_Down(driver);


            if (submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID != "")
            {
                Thread.Sleep(3000);
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_YearsExperience_skillYearsExpID, submitCandidateResumeModel.str_select_YearsExperience_skillYearsExpID);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //return results;
                    }
                }
            }


            if (submitCandidateResumeModel.str_radiobutton_Level_skillLevelID != "")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_Level_skillLevelID + submitCandidateResumeModel.str_radiobutton_Level_skillLevelID);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    //return results;
                }
            }

            //// Ryder Retiree
            //if (submitCandidateResumeModel.strRadiobtnFormer_Employee.ToString().ToLower() == "yes")
            //{
            //    kwm.click(driver, KeyWords.locator_ID, "RetireeRadio1");
            //}
            //else
            //{
            //    kwm.click(driver, KeyWords.locator_ID, "RetireeRadio0");
            //}

            // Years Experience
            //if (submitCandidateResumeModel.strSelectSkills_Years != "")
            //{
            //    Thread.Sleep(3000);
            //    results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_skillYearsExpID, submitCandidateResumeModel.strSelectSkills_Years);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        Thread.Sleep(5000);
            //        results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_skillYearsExpID, submitCandidateResumeModel.strSelectSkills_Years);
            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            return results;
            //        }
            //    }
            //}

            // Level
            //if (submitCandidateResumeModel.strRadiobtnSkills_Level != "")
            //{
            //    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_RadioBtnskillLevelID + submitCandidateResumeModel.strRadiobtnSkills_Level);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        //return results;
            //    }
            //}

            // Former Employee 
            if (submitCandidateResumeModel.str_radiobutton_FormerEmployee_ExperienceRadio1.ToString().ToLower() == "yes")
            {
                results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    objCommonMethods.Action_Button_Tab(driver);
                    objCommonMethods.Action_Page_Down(driver);
                    results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        objCommonMethods.Action_Button_Tab(driver);
                        objCommonMethods.Action_Page_Down(driver);
                        results = kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio1);

                    }

                }

                // added newly pradeep
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeFromDate_fromDate1, submitCandidateResumeModel.str_Date_FromerEmployeeFromDate_fromDate1, false);

                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FromerEmployeeToDate_toDate1, submitCandidateResumeModel.str_Date_FromerEmployeeToDate_toDate1, false);

                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerEmployeeJobTitle_jobTitle, false);

                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerEmployeeSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerEmployeeSupervisor_supervisorName, false);
                //end
            }
            else
            {
                kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FormerEmployee_ExperienceRadio0);
            }


            if (submitCandidateResumeModel.str_radiobutton_FormerContractor_contractor1.ToString().ToLower() == "yes")
            {
                kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FromerContractor_contractor1);

                // added newly pradeep
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractor_fromDateContractor1, submitCandidateResumeModel.str_Date_FormerContractor_fromDateContractor1, false);

                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_FormerContractor_toDateContractor1, submitCandidateResumeModel.str_Date_FormerContractor_toDateContractor1, false);

                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerContractorJobTitle_jobTitle, submitCandidateResumeModel.str_txt_FromerContractorJobTitle_jobTitle, false);

                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_FromerContractorSupervisor_supervisorName, submitCandidateResumeModel.str_txt_FromerContractorSupervisor_supervisorName, false);
                //end



            }
            else
            {
                kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_FromerContractor_contractor0);
            }

            //added by pradeep 
            //needsto add code for retire 

            if (submitCandidateResumeModel.str_radiobutton_retiree_RetireeRadio1.ToString().ToLower() == "yes")
            {
                kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_retiree_RetireeRadio1);

                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_Date_RetiredDate_RetiredDate, submitCandidateResumeModel.str_Date_RetiredDate_RetiredDate, false);

                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_RetiredJobTitle_RetiredJobTitle, submitCandidateResumeModel.str_txt_RetiredJobTitle_RetiredJobTitle, false);


            }

            else
            {
                kwm.click(driver, KeyWords.locator_ID, KeyWords.ID_radiobutton_retiree_RetireeRadio0);
            }
            objCommonMethods.Action_Page_Down(driver);


            //7 day prior form completed / HOS document(s)? *




            //  Copy of currently valid CDL with necessary endorsements? *


            //    Copy of currently valid Medical Examiner's Certificate Card?


            //      Copy of current Motor Vehicle Record (within the last 90 days)?


            //Copy of current Certificate of Motor Vehicle Violations / Annual Review?


            //Copy of Pre-employment drug test completion?


            //Copy of completed Employment Application from Driver Leasing Service w/ SSN?


            //Copy of verification of prior driving experience?


            //Copy of work history verification(s) - 3 years previous?

            //Copy of currently valid HazMat training certificate - within 3 years previous?Edit QuestionDelete Question


            List<string> radiobttnryder = new List<string>();


            string[] names = { submitCandidateResumeModel.str_radiobtn_HOSdocuments, submitCandidateResumeModel.str_radiobtn_CDLwithnecessaryendorsements, submitCandidateResumeModel.str_radiobtn_CurrentlyvalidMedicalExaminer, submitCandidateResumeModel.str_radiobtn_MotorVehicleRecord, submitCandidateResumeModel.str_radiobtn_CertificateofMotorVehicleViolations, submitCandidateResumeModel.str_radiobtn_Preemploymentdrugtestcompletion, submitCandidateResumeModel.str_radiobtn_ApplicationfromDriverLeasingService, submitCandidateResumeModel.str_radiobtn_verificationofpriordrivingexperience, submitCandidateResumeModel.str_radiobtn_workhistoryverification, submitCandidateResumeModel.str_radiobtn_HazMattrainingcertificate };
            radiobttnryder.AddRange(names);

            try
            {
                // bool bFlag = false;
                //ICollection<IWebElement> lis_Button_Names = driver.FindElements(By.XPath("//*[contains(@" + locator + ", '" + target + "') and text()!='']"));
                List<IWebElement> lis_Button_Names = driver.FindElements(By.XPath("//*[@class='multipleChoiceTable']")).ToList();
                // List<IWebElement> elements = lis_Button_Names.ToList();
                // Console.WriteLine(elements.Count);
                for (int i = 0; i <= lis_Button_Names.Count; i++)
                {
                    //without checking with input values
                    int count = i + 1;

                    driver.FindElement(By.XPath("//div[contains(@class,'insideSection')][" + count + "]//span[contains(text(),'" + radiobttnryder[i] + "')]//preceding-sibling::input")).Click();


                    // driver.FindElement(By.XPath("//*[@class='radio-inline label--radio']//span[contains(text(),'" + radiobttnryder[i] + "')]//preceding-sibling::input[" + i + 1 + "]")).Click();

                    ////to check with yes or no
                    //if (radiobttnryder[i].ToLower().Equals("yes"))
                    //{

                    //    driver.FindElement(By.XPath("//*[@class='radio-inline label--radio']//span[contains(text(),'Yes')]//preceding-sibling::input[" + i + 1 + "]"));
                    //}
                    //else if (radiobttnryder[i].ToLower().Equals("no"))
                    //{
                    //    driver.FindElement(By.XPath("//*[@class='radio-inline label--radio']//span[contains(text(),'No')]//preceding-sibling::input[" + i + 1 + "]"));
                    //}


                }

            }
            catch (Exception ex)
            {

            }




            // Candidate Pay Rate
            objCommonMethods.Action_Page_Down(driver);

            if (submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidatePayRate_supplierRegPayRate, submitCandidateResumeModel.str_txt_CandidatePayRate_supplierRegPayRate, false);
            }

            // Candidate OT Pay Rate
            if (submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_CandidateOTPayRate_supplierOTPayRate, submitCandidateResumeModel.str_txt_CandidateOTPayRate_supplierOTPayRate, false);
            }

            // Bill Rate
            if (submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierBillRate_supplierRegBillRate, submitCandidateResumeModel.str_txt_BillRate_supplierRegBillRate, false);
            }

            // 	OT Bill Rate
            if (submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate != "")
            {
                kwm.sendText(driver, KeyWords.locator_ID, KeyWords.ID_txt_SupplierOTBillRate_supplierOTBillRate, submitCandidateResumeModel.str_txt_OTBillRate_supplierOTBillRate, false);
            }

            objCommonMethods.Action_Page_Down(driver);

            string stemp = "";
            try
            {
                stemp = submitCandidateResumeModel.str_Txt_STID.Substring(0, 4);
            }
            catch
            {
            }
            //results = kwm.GetText(driver, KeyWords.locator_ID, "STID1");
            //Random random = new Random();
            //if (results.ErrorMessage == "")
            //{
            //    if (stemp == "")
            //    {
            //        int randomNumber = random.Next(1000, 9999);
            //        stemp = randomNumber.ToString();
            //    }

            //    kwm.sendText(driver, KeyWords.locator_ID, "STID1", stemp, false);
            //}
            objCommonMethods.Action_Button_Tab(driver);

            Thread.Sleep(3000);
            objCommonMethods.Action_Page_Down(driver);
            //    submitCandidateResumeModel.str_Txt_STID = "";
            //Last 4 Digits of SSN
            if (submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1 != "")
            {
                Thread.Sleep(3000);
                results = kwm.sendText_clr(driver, KeyWords.locator_ID, KeyWords.ID_txt_Last4DigitsofSSN_STID1, submitCandidateResumeModel.str_txt_Last4DigitsofSSN_STID1);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Month
            if (submitCandidateResumeModel.str_select_SSNMonth_STID2 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNMonth_STID2, submitCandidateResumeModel.str_select_SSNMonth_STID2);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Date
            if (submitCandidateResumeModel.str_select_SSNDate_STID3 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNDate_STID3, submitCandidateResumeModel.str_select_SSNDate_STID3);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }

            //Year
            if (submitCandidateResumeModel.str_select_SSNYear_STID4 != "")
            {
                results = kwm.select(driver, KeyWords.locator_ID, KeyWords.ID_select_SSNYear_STID4, submitCandidateResumeModel.str_select_SSNYear_STID4);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    // return results;
                }
            }
            objCommonMethods.Action_Page_Down(driver);
            objCommonMethods.SaveScreenShot_EachPage(driver, submitCandidateResumeModel.strClientName + "_");
        }
        #endregion Ryder


    }
}