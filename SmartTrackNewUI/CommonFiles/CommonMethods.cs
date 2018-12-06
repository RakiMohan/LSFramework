// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonMethods.cs" company="DCR Workforce Inc">
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
using System.Data.OleDb;
using System.Data;
using System.Configuration;
//using System.Data.OracleClient;
using System.Net;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Data.SqlClient;
using OpenQA.Selenium.Interactions;
using RelevantCodes.ExtentReports;
using CommonFiles;
using SmartTrack_Automation;
using System.Collections;

namespace SmartTrack_Automation
{
    // [TestClass]
    public class CommonMethods
    {

        ReadExcel ReadExcelHelper = new ReadExcel();

        // CreateRequirement objCreate_Requirement = new CreateRequirement();
        public void WriteLogFileBeginHeader(string strLogfilePath)
        {
            //try
            //{
            //    Process[] proc = Process.GetProcessesByName("utorrent");
            //    proc.Kill();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}

            DateTime time = DateTime.Now;             // Use current time
            StreamWriter sw;
            if (!File.Exists(strLogfilePath))
            {
                sw = File.CreateText(strLogfilePath);
                sw.Flush();
                sw.Close();

                sw = File.AppendText(strLogfilePath);
                sw.WriteLine("Start Log File: " + time.ToString("F"));
                sw.Flush();
                sw.Close();
            }
            else if (File.Exists(strLogfilePath))
            {

                sw = File.AppendText(strLogfilePath);
                sw.WriteLine("Start Log File: " + time.ToString("F"));
                sw.Flush();
                sw.Close();
            }


        }
        public void WriteLogFileEndHeader(string strLogfilePath)
        {


            DateTime time = DateTime.Now;             // Use current time
            StreamWriter sw;
            if (!File.Exists(strLogfilePath))
            {
                sw = File.CreateText(strLogfilePath);
                sw.Close();
                //File.Create(strLogfilePath);
                sw = File.AppendText(strLogfilePath);
                sw.WriteLine("End Log File: " + time.ToString("F"));
                sw.Flush();
                sw.Close();
            }
            else if (File.Exists(strLogfilePath))
            {
                sw = File.AppendText(strLogfilePath);
                sw.WriteLine("End Log File: " + time.ToString("F"));
                sw.Flush();
                sw.Close();
            }



        }
        public void WriteLogFileTestCaseErrorResult(string strLogfilePath, string strMsg, int iErrorOrWarning)
        {

            StreamWriter sw = File.AppendText(strLogfilePath);

            if (iErrorOrWarning == 1)
            {
                sw.WriteLine("ERROR: " + strMsg.ToString());
            }
            if (iErrorOrWarning == 2)
            {
                sw.WriteLine("WARNING: " + strMsg.ToString());
            }
            if (iErrorOrWarning == 3)
            {
                sw.WriteLine("INFO: " + strMsg.ToString());
            }
            sw.Flush();
            sw.Close();
        }

        public void WriteLogFileTestCaseHeaders(string strLogfilePath, string TestID, int StartOrEnd)
        {
            DateTime time = DateTime.Now;
            StreamWriter sw = File.AppendText(strLogfilePath);
            if (StartOrEnd == 1)
            {
                sw.WriteLine("Start Test Case: " + TestID + " : [" + time.ToString("F") + "]");
            }
            if (StartOrEnd == 2)
            {
                sw.WriteLine("End Test Case: " + TestID + " : [" + time.ToString("F") + "]");
            }
            sw.Flush();
            sw.Close();
        }

        public Result WriteLogFileTestCaseHeaders(string strLogfilePath, string strMsg, int iOption, string strCreateFile)
        {



            var results1 = new Result();
            StreamWriter sw;

            if ((!File.Exists(strLogfilePath) && strCreateFile.ToUpper() == "YES"))
            {
                // File.Delete(strLogfilePath);
                Thread.Sleep(1000);
                //File.CreateText(strLogfilePath);
                sw = File.CreateText(strLogfilePath);
                sw.Close();
            }
            Thread.Sleep(1000);
            sw = File.AppendText(strLogfilePath);


            // write a line of text to the file
            if (iOption == 1)
            {
                sw.WriteLine("Start Info " + strMsg);
            }
            if (iOption == 2)
            {
                sw.WriteLine("End Info " + strMsg);
            }


            // close the stream
            sw.Flush();
            sw.Close();
            return results1;


        }


        public Result Login_Reports(IWebDriver WDriver, DataRow LoginData)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            var results = new Result();
            var resultsDatabse = new Result();

            // WDriver = new FirefoxDriver();
            // driver = WDriver;
            try
            {
                WDriver.Manage().Window.Maximize();
            }
            catch
            {
                // Thread.Sleep(5000);
                try
                {
                    WDriver.Manage().Window.Maximize();
                }
                catch
                {
                    //
                }
            }
            string strBrowser = LoginData["Browser"].ToString();
            string strGotoUrl = KeyWords.str_App_Url;
            string userid = LoginData["Email"].ToString();
            string pwd = LoginData["Password"].ToString();



            try
            {
                WDriver.Navigate().GoToUrl(strGotoUrl);
            }
            catch
            {
                //Thread.Sleep(5000);
                try
                {
                    WDriver.Navigate().GoToUrl(strGotoUrl); ;
                }
                catch
                {
                    //
                }
            }





            //  WDriver.Navigate().GoToUrl(strGotoUrl);
            //   System.Threading.Thread.Sleep(5000);


            //   Thread.Sleep(100);

            try
            {
                WDriver.Manage().Window.Maximize();
            }
            catch
            {
                Thread.Sleep(500);
                try
                {
                    WDriver.Manage().Window.Maximize();
                }
                catch
                {
                    //
                }
            }

            for (int z = 1; z < 500; z++)
            {
                Boolean strValue = false;

                try
                {
                    strValue = WDriver.FindElement(By.Id(KeyWords.ID_txtEmailAddress)).Displayed;
                }
                catch
                {
                    strValue = false;
                }
                //  Console.WriteLine("z -----> " + z);
                //  Console.WriteLine("strValue -----> " + strValue);
                if (strValue)
                {
                    break;
                }


            }
            Thread.Sleep(5000);
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txtEmailAddress, userid, false);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                return results;
            }
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txtPassword, pwd, false);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                return results;
            }

            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btnLogin);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                return results;
            }
            Thread.Sleep(5000);
            // Console.WriteLine("Testing Login error msg");
            if (kwm.isElementPresent(WDriver, KeyWords.ID_DefaultContent_errorPanel))
            {
                // Console.WriteLine("Testing Login error msg1");
                results = kwm.Get_Err_Login(WDriver, KeyWords.locator_ID, KeyWords.ID_DefaultContent_lblError);
                if (results.Result1 == KeyWords.Result_PASS)
                {
                    if (results.ErrorMessage != "")
                    {
                        results.Result1 = KeyWords.Result_FAIL;
                        return results;
                    }

                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            Boolean bFlag = false;
            for (int i = 1; i < 200; i++)
            {
                Thread.Sleep(100);

                if (kwm.isElementDisplayed(WDriver, KeyWords.ID_Menu_gnmenu))
                {
                    bFlag = true;
                    Thread.Sleep(100);
                    //  Console.WriteLine("i count ---> ");
                    //  Console.WriteLine(i);

                }
                if (bFlag)
                    break;
            }
            if (bFlag)
            {
                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = KeyWords.MSG_strLoginsuccessfully;
                return results;
            }
            if (!kwm.isElementPresent(WDriver, KeyWords.ID_Menu_gnmenu))
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = KeyWords.MSG_strLoginTakingLongTime;
                return results;
            }
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_strLoginsuccessfully;
            return results;
        }

        public void _CheckRehireEligibility(IWebDriver WDriver, KeyWordMethods kwm)
        {
            try
            {
                kwm.jsClick(WDriver, KeyWords.locator_CSS, KeyWords.CSS_Link_CheckRehireEligibility);
                kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_Popup_CheckRehireEligibility), kwm._WDWait);
                if (kwm.isElementDisplayedByXPath(WDriver, KeyWords.XPath_Popup_CheckRehireEligibility))
                {
                    // Action_Page_Down(WDriver);
                    Thread.Sleep(2000);
                    kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_Popup_CheckRehireEligibility), kwm._WDWait);
                    kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.XPath_MsgBox_Button_UpdateRehireEligibility);

                    kwm.waitForElementExists(WDriver, By.XPath(KeyWords.XPath_MsgBox_Label_RehireEligibility), kwm._WDWait);
                    if (kwm.isElementDisplayedByXPath(WDriver, KeyWords.XPath_MsgBox_Label_RehireEligibility))
                    {
                        kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_RadioBtn_RehireEligible_Yes);
                        //   kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_MsgBox_Select_Reason_Reason, 1);// Removed from application

                        // Wait for PID text box is clickable
                        kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Txt_PID_PID), kwm._WDWait);
                        kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Txt_PID_PID), kwm._WDWait);

                        // Enter PID number in PID text box
                        DateTime date = DateTime.Now;
                        string TimeValue = date.ToString("yyyymmdd_hhmmss");
                        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_PID_PID, TimeValue, false);


                        kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_MsgBox_Button_Submit), kwm._WDWait);
                        Thread.Sleep(2000);
                        kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.XPath_MsgBox_Button_Submit);

                        kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_MsgBox_Button_Yes), kwm._WDWait);

                        if (kwm.isElementDisplayedByXPath(WDriver, KeyWords.XPath_MsgBox_Button_Yes))
                        {
                            kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_MsgBox_Button_Yes);

                            kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_MsgBox_Button_Ok), kwm._WDWait);
                            if (kwm.isElementDisplayedByXPath(WDriver, KeyWords.XPath_MsgBox_Button_Ok))
                            {
                                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_MsgBox_Button_Ok);

                            }
                            else
                            {
                                Console.WriteLine("unable to find Ok button");
                            }

                        }
                        else
                        {
                            Console.WriteLine("unable to find Yes button");
                        }



                    }
                    else
                    {
                        Console.WriteLine("unable to find ");
                    }

                }


            }
            catch (Exception e)
            {
                string screenShotPath = CommonMethods.Capture(WDriver);
                ReportHandler._ChildTest.Log(LogStatus.Info, "Snapshot below: " + ReportHandler._ChildTest.AddScreenCapture(screenShotPath));
                WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, e.Message, 3);

            }

        }

        public Result Login_NewApp(IWebDriver WDriver, DataRow LoginData)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            var results = new Result();
            var resultsDatabse = new Result();

            // WDriver = new FirefoxDriver();
            // driver = WDriver;
            try
            {
                WDriver.Manage().Window.Maximize();
            }
            catch
            {
                // Thread.Sleep(5000);
                try
                {
                    WDriver.Manage().Window.Maximize();
                }
                catch
                {
                    //
                }
            }
            //  string strBrowser = LoginData["P1"].ToString();
            string strGotoUrl = KeyWords.str_App_Url;
            string userid = LoginData["P1"].ToString();
            string pwd = LoginData["P2"].ToString();



            try
            {
                WDriver.Navigate().GoToUrl(strGotoUrl);
            }
            catch
            {
                //Thread.Sleep(5000);
                try
                {
                    WDriver.Navigate().GoToUrl(strGotoUrl); ;
                }
                catch
                {
                    //
                }
            }





            //  WDriver.Navigate().GoToUrl(strGotoUrl);
            //   System.Threading.Thread.Sleep(5000);


            //   Thread.Sleep(100);

            try
            {
                WDriver.Manage().Window.Maximize();
            }
            catch
            {
                Thread.Sleep(500);
                try
                {
                    WDriver.Manage().Window.Maximize();
                }
                catch
                {
                    //
                }
            }

            //for (int z = 1; z < 500; z++)
            //{
            //    Boolean strValue = false;

            //    try
            //    {
            //        strValue = WDriver.FindElement(By.Id(KeyWords.ID_txtEmailAddress)).Displayed;
            //    }
            //    catch
            //    {
            //        strValue = false;
            //    }
            //    //  Console.WriteLine("z -----> " + z);
            //    //  Console.WriteLine("strValue -----> " + strValue);
            //    if (strValue)
            //    {
            //        break;
            //    }


            //}
            //   Thread.Sleep(5000);
            //ImplicitTwentySeconds(WDriver);
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(120)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txtEmailAddress))));
            }
            catch
            {
                try
                {
                    new WebDriverWait(WDriver, TimeSpan.FromSeconds(120)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_txtEmailAddress))));
                }
                catch
                {
                    //
                }
            }
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txtEmailAddress, userid, false);

            if (results.Result1 == KeyWords.Result_FAIL)
            {
                return results;
            }
            //ImplicitTwentySeconds(WDriver);
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txtPassword, pwd, false);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                return results;
            }
            //ImplicitTwentySeconds(WDriver);
            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btnLogin);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                return results;
            }
            // Thread.Sleep(5000);
            // Implicitt(WDriver);
            //ImplicitThirtySeconds(WDriver);
            // Console.WriteLine("Testing Login error msg");
            if (kwm.isElementPresent(WDriver, KeyWords.ID_btnLogin))
            {
                Thread.Sleep(5000);
            }
            if (kwm.isElementPresent(WDriver, KeyWords.ID_DefaultContent_errorPanel))
            {
                // Console.WriteLine("Testing Login error msg1");
                results = kwm.Get_Err_Login(WDriver, KeyWords.locator_ID, KeyWords.ID_DefaultContent_lblError);
                if (results.Result1 == KeyWords.Result_PASS)
                {
                    if (results.ErrorMessage != "")
                    {
                        results.Result1 = KeyWords.Result_FAIL;
                        return results;
                    }

                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            Boolean bFlag = false;
            for (int i = 1; i < 200; i++)
            {
                Thread.Sleep(100);

                // if (kwm.isElementDisplayed(WDriver, KeyWords.ID_Menu_gnmenu))

                //Added new method as per new ui change
                if (kwm.isElementDisplayedXpath(WDriver, KeyWords.ID_Menu_gnmenu))
                {
                    bFlag = true;
                    Thread.Sleep(100);
                    //  Console.WriteLine("i count ---> ");
                    //  Console.WriteLine(i);

                }
                if (bFlag)
                    break;
            }
            if (bFlag)
            {
                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = KeyWords.MSG_strLoginsuccessfully;
                return results;
            }
            if (!kwm.isElementPresent(WDriver, KeyWords.ID_Menu_gnmenu))
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = KeyWords.MSG_strLoginTakingLongTime;
                return results;
            }
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_strLoginsuccessfully;
            return results;
        }

        public Result Supplier_Login_NewApp(IWebDriver WDriver, DataRow LoginData)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            var results = new Result();
            var resultsDatabse = new Result();


            //  string strBrowser = LoginData["P1"].ToString();
            string strGotoUrl = KeyWords.str_App_Url2;
            string userid = LoginData["P1"].ToString();
            string pwd = LoginData["P2"].ToString();
            string client = LoginData["P3"].ToString();

            try
            {
                WDriver.Navigate().GoToUrl(strGotoUrl);
            }
            catch
            {
                //Thread.Sleep(5000);
                try
                {
                    WDriver.Navigate().GoToUrl(strGotoUrl); ;
                }
                catch
                {
                    //
                }
            }



            try
            {
                WDriver.Manage().Window.Maximize();
            }
            catch
            {
                Thread.Sleep(500);
                try
                {
                    WDriver.Manage().Window.Maximize();
                }
                catch
                {
                    //
                }
            }


            // ImplicitTwentySeconds(WDriver);
            try
            {
                new WebDriverWait(WDriver, TimeSpan.FromSeconds(120)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_Supplier_Email))));
            }
            catch
            {
                try
                {
                    new WebDriverWait(WDriver, TimeSpan.FromSeconds(120)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.ID_Supplier_Email))));
                }
                catch
                {
                    //
                }
            }

            //Email ID
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Supplier_Email, userid, false);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                return results;
            }
            //ImplicitTwentySeconds(WDriver);

            //Password
            results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Supplier_Password, pwd, false);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                return results;
            }
            //ImplicitTwentySeconds(WDriver);

            // Login Button 
            results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.button_supplier_login);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                return results;
            }

            Thread.Sleep(1000);
            // ImplicitTwentySeconds(WDriver);
            Thread.Sleep(3000);
            kwm.waitForPageToLoad(WDriver, kwm._WDWait);
            kwm.waitForElementToBeClickable(WDriver, By.XPath("//div[@id='landingPage']"), kwm._WDWait);
            List<string> supplierclients = new List<string>() { Constants.Discover, Constants.APS };
            if (!supplierclients.Contains(client.ToLower()))
            //if (client.ToLower() != Constants.Discover)
            {
                Boolean blnHomeIconDisplay = false;


                blnHomeIconDisplay = kwm.isElementDisplayed(WDriver, "openHome");

                if (blnHomeIconDisplay)
                {
                    //return results;
                }
                else
                {
                    try
                    {
                        new WebDriverWait(WDriver, TimeSpan.FromSeconds(120)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.Txt_Supplier_Search))));
                    }
                    catch
                    {
                        try
                        {
                            new WebDriverWait(WDriver, TimeSpan.FromSeconds(120)).Until(ExpectedConditions.ElementExists((By.Id(KeyWords.Txt_Supplier_Search))));
                        }
                        catch
                        {
                            //
                        }
                    }
                    //Text is Passed into Text box

                    //Code to handle 'Sallie Mae' client selection
                    if (client.ToLower().ToString() == "sallie mae")
                    {
                        try
                        {
                            WDriver.FindElement(By.Id(KeyWords.Txt_Supplier_Search)).SendKeys("Workspend-" + client);
                        }
                        catch
                        {
                        }

                    }
                    else
                    {
                        try
                        {
                            WDriver.FindElement(By.Id(KeyWords.Txt_Supplier_Search)).SendKeys(client);
                        }
                        catch
                        {
                        }
                    }
                    Thread.Sleep(3000);
                    //WDriver.FindElement(By.XPath("//p[@class='card-text'][contains(text(),'-" + client + "')]")).Click();
                    try
                    {
                        WDriver.FindElement(By.XPath("//div[contains(@class,'text-center') and not(contains(@style, 'display: none'))]//p[@class='card-text']")).Click();
                    }
                    catch
                    {
                    }

                    Thread.Sleep(3000);
                    // Implicitt(WDriver);
                    //ImplicitThirtySeconds(WDriver);

                    // Click on CLient

                    // Console.WriteLine("Testing Login error msg");
                    if (kwm.isElementPresent(WDriver, KeyWords.ID_btnLogin))
                    {
                        Thread.Sleep(5000);
                    }
                }
            }
            if (kwm.isElementPresent(WDriver, KeyWords.ID_DefaultContent_errorPanel))
            {
                // Console.WriteLine("Testing Login error msg1");
                results = kwm.Get_Err_Login(WDriver, KeyWords.locator_ID, KeyWords.ID_DefaultContent_lblError);
                if (results.Result1 == KeyWords.Result_PASS)
                {
                    if (results.ErrorMessage != "")
                    {
                        results.Result1 = KeyWords.Result_FAIL;
                        return results;
                    }

                }
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    return results;
                }
            }

            Boolean bFlag = false;
            for (int i = 1; i < 200; i++)
            {
                Thread.Sleep(100);

                // if (kwm.isElementDisplayed(WDriver, KeyWords.ID_Menu_gnmenu))

                //Added new method as per new ui change
                if (kwm.isElementDisplayedXpath(WDriver, KeyWords.ID_Menu_gnmenu))
                {
                    bFlag = true;
                    Thread.Sleep(100);
                    //  Console.WriteLine("i count ---> ");
                    //  Console.WriteLine(i);

                }
                if (bFlag)
                    break;
            }
            if (bFlag)
            {
                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = KeyWords.MSG_strLoginsuccessfully;
                return results;
            }
            if (!kwm.isElementPresent(WDriver, KeyWords.ID_Menu_gnmenu))
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = KeyWords.MSG_strLoginTakingLongTime;
                return results;
            }
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_strLoginsuccessfully;
            return results;
        }

        //public Result Login(IWebDriver WDriver, DataRow LoginData)
        //{
        //    KeyWordMethods kwm = new KeyWordMethods();
        //    var results = new Result();
        //    var resultsDatabse = new Result();

        //   // WDriver = new FirefoxDriver();
        //   // driver = WDriver;
        //    try
        //    {
        //        WDriver.Manage().Window.Maximize();
        //    }
        //    catch
        //    {
        //        Thread.Sleep(10000);
        //        try
        //        {
        //            WDriver.Manage().Window.Maximize();
        //        }
        //        catch
        //        {
        //            //
        //        }
        //    }
        //    string strBrowser = LoginData["P1"].ToString();
        //    string strGotoUrl = LoginData["P2"].ToString();
        //    string userid = LoginData["P3"].ToString();
        //    string pwd = LoginData["P4"].ToString();



        //    try
        //    {
        //        WDriver.Navigate().GoToUrl(strGotoUrl);
        //    }
        //    catch
        //    {
        //        Thread.Sleep(10000);
        //        try
        //        {
        //            WDriver.Navigate().GoToUrl(strGotoUrl); ;
        //        }
        //        catch
        //        {
        //            //
        //        }
        //    }





        //  //  WDriver.Navigate().GoToUrl(strGotoUrl);
        //    System.Threading.Thread.Sleep(5000);


        //    Thread.Sleep(1000);

        //    try
        //    {
        //        WDriver.Manage().Window.Maximize();
        //    }
        //    catch
        //    {
        //        Thread.Sleep(10000);
        //        try
        //        {
        //            WDriver.Manage().Window.Maximize();
        //        }
        //        catch
        //        {
        //            //
        //        }
        //    }

        //    Thread.Sleep(1000);
        //    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txtEmailAddress, userid, false);
        //    if (results.Result1 == KeyWords.Result_FAIL)
        //    {
        //        return results;
        //    }
        //    results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txtPassword, pwd, false);
        //    if (results.Result1 == KeyWords.Result_FAIL)
        //    {
        //        return results;
        //    }

        //    results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btnLogin);
        //    if (results.Result1 == KeyWords.Result_FAIL)
        //    {
        //        return results;
        //    }
        //    Thread.Sleep(5000);
        //   // Console.WriteLine("Testing Login error msg");
        //    if (kwm.isElementPresent(WDriver, KeyWords.ID_lblError))
        //    {
        //       // Console.WriteLine("Testing Login error msg1");
        //        results = kwm.Get_Err_Login(WDriver, KeyWords.locator_ID, KeyWords.ID_lblError);
        //        if (results.Result1 == KeyWords.Result_PASS)
        //        {
        //            if (results.ErrorMessage != "")
        //            {
        //                results.Result1 = KeyWords.Result_FAIL;
        //                return results;
        //            }

        //        }
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            return results;
        //        }
        //    }



        //    Thread.Sleep(10000);


        //    if (!kwm.isElementPresent(WDriver, KeyWords.STR_Txt_LogOut))
        //    {
        //        Thread.Sleep(10000);
        //    }
        //    if (!kwm.isElementPresent(WDriver, KeyWords.STR_Txt_LogOut))
        //    {
        //        Thread.Sleep(10000);
        //    }
        //    if (!kwm.isElementPresent(WDriver, KeyWords.STR_Txt_LogOut))
        //    {
        //        results.Result1 = KeyWords.Result_FAIL;
        //        results.ErrorMessage = KeyWords.MSG_strLoginTakingLongTime;
        //        return results;
        //    }
        //    results.Result1 = KeyWords.Result_PASS;
        //    results.ErrorMessage = KeyWords.MSG_strLoginsuccessfully;
        //    return results;
        //}

        private string CloseAlertAndGetItsText(IWebDriver driver)
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();

                alert.Accept();

                alert.Dismiss();

                return alert.Text;
            }
            finally
            {
                //acceptNextAlert = true;
            }
        }

        public Result selectdatefrompicker(IWebDriver driver, String givendat, String datepickid, String monthid, String yearid)
        {

            var results = new Result();
            try
            {

                results.Result1 = KeyWords.Result_PASS;
                TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                String currenttime1 = indianTime.ToString("MM/dd/yyyy");

                DateTime currenttime = Convert.ToDateTime(currenttime1);
                DateTime giventime = Convert.ToDateTime(givendat);
                int result = DateTime.Compare(giventime, currenttime);

                if (result >= 0)
                {
                    try
                    {
                        givendat.Trim();
                        DateTime d = Convert.ToDateTime(givendat);
                        String day = d.Day.ToString();
                        int Month = d.Month - 1;
                        String Year = d.Year.ToString();

                        //  driver.FindElement(By.Id(datepickid)).Click();
                        // click(driver, "CssSelector", "img.ui-datepicker-trigger");
                        Thread.Sleep(5000);

                        new SelectElement(driver.FindElement(By.XPath("//select[@class='" + yearid + "']"))).SelectByValue(Year);
                        new SelectElement(driver.FindElement(By.XPath("//select[@class='" + monthid + "']"))).SelectByValue(Convert.ToString(Month));
                        Thread.Sleep(3000);

                        //  driver.FindElementByLinkText(day).Click(); 
                        Thread.Sleep(4000);
                        return results;
                    }
                    catch
                    {
                        results.Result1 = KeyWords.Result_FAIL;
                        results.ErrorMessage = "Error encountered while selecting date from datepicker.";
                        return results;
                    }


                }
                else
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Given date is less than the current date...";
                    return results;
                }
            }
            catch
            {
                var res = new Result();
                results.Result1 = KeyWords.Result_FAIL;
                res.ErrorMessage = "Error encountered while selecting date from datepicker.";
                return res;
            }
        }

        /// <summary>
        /// This will Take the screen shot of the webpage and will save it at particular location
        /// </summary>      
        ///<param name="screenshotFirstName"></param>
        public Result SaveScreenShot(IWebDriver driver, string screenshotFirstName)
        {
            var results = new Result();
            var folderLocation = "";
            var filename1 = "";
            try
            {

                folderLocation = System.IO.Directory.GetCurrentDirectory() + "\\ScreenShot\\";
                //     Console.WriteLine(folderLocation);
                if (!Directory.Exists(folderLocation))
                {
                    Directory.CreateDirectory(folderLocation);
                }
                folderLocation = folderLocation + DateTime.Now.ToString("ddMMyyyy");
                //     Console.WriteLine(folderLocation);

                if (KeyWords.strScreenShootPath == "")
                {
                    for (int i = 1; i < 1000; i++)
                    {
                        if (!Directory.Exists(folderLocation))
                        {
                            Directory.CreateDirectory(folderLocation);
                            KeyWords.strScreenShootPath = folderLocation.ToString() + "\\";
                            break;
                        }
                        filename1 = folderLocation + "_" + i.ToString();
                        if (!Directory.Exists(filename1))
                        {
                            Directory.CreateDirectory(filename1);
                            KeyWords.strScreenShootPath = filename1.ToString() + "\\";
                            break;
                        }
                    }

                }


                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var filename = new StringBuilder(KeyWords.strScreenShootPath);
                filename.Append(screenshotFirstName);
                filename.Append(DateTime.Now.ToString("dd-MM-yyyy_HH_mm_ss"));
                filename.Append(".png");
                //  Console.WriteLine(filename.ToString());
                //screenshot.SaveAsFile(filename.ToString(), System.Drawing.Imaging.ImageFormat.Png);
                screenshot.SaveAsFile(filename.ToString(), ScreenshotImageFormat.Png);

                filename1 = filename.ToString();

            }
            catch
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem screen shot error";
                return results;
            }
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = filename1.ToString();
            return results;
        }

        /// <summary>
        /// This will Take the screen shot of the webpage and will save it at particular location
        /// </summary>      
        ///<param name="screenshotFirstName"></param>
        public Result SaveScreenShot_EachPage(IWebDriver driver, string screenshotFirstName)
        {
            var results = new Result();
            var folderLocation = "";
            var filename1 = "";
            try
            {

                folderLocation = System.IO.Directory.GetCurrentDirectory() + "\\Input\\EachPageScreen\\";
                //folderLocation = "D:\\STAUTO\\SMARTTrack70MAIN\\SMARTTrack-MAIN-Automation\\SmartTrackAutomation-New\\SmartTrack\\Input\\EachPageScreen";
                //     Console.WriteLine(folderLocation);
                if (!Directory.Exists(folderLocation))
                {
                    Directory.CreateDirectory(folderLocation);
                }
                //   folderLocation = folderLocation + DateTime.Now.ToString("ddMMyyyy");
                //     Console.WriteLine(folderLocation);



                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var filename = new StringBuilder(folderLocation);
                filename.Append(screenshotFirstName);
                filename.Append(DateTime.Now.ToString("dd-MM-yyyy_HH_mm_ss"));
                filename.Append(".png");
                //  Console.WriteLine(filename.ToString());
                screenshot.SaveAsFile(filename.ToString(), ScreenshotImageFormat.Png);
                filename1 = filename.ToString();

            }
            catch
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem screen shot error";
                return results;
            }
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = filename1.ToString();
            return results;
        }

        //public Result TestCase_Login_Execution(IWebDriver driver, Result AllSheetResult, string strLogfilePath, string strExlOutputPath, int iSubRowLoop, string[] strColArray, string[] strDataArray, int iLoop, string NumberOfRepeats)
        //{
        //    KeyWordMethods kwm = new KeyWordMethods();
        //    var TestCaseResult = new Result();
        //    var Result_ScreenShot = new Result();
        //    var WriteExlResult = new Result();
        //    var resultsDatabse = new Result();

        //    WriteLogFileTestCaseHeaders(strLogfilePath, AllSheetResult.dt.Rows[iSubRowLoop][0].ToString(), 1);
        //    KeyWords.str_Browser_Execute = AllSheetResult.dt.Rows[iSubRowLoop]["P1"].ToString();
        //    Thread.Sleep(3000);
        //    if (iSubRowLoop != 0)
        //    {
        //        if (KeyWords.strLoginUser != AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString())
        //        {
        //            kwm.Logout_Link_Click_NewUI(driver,"Logout");
        //            Thread.Sleep(3000);
        //            KeyWords.strLoginUser = AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString();
        //            TestCaseResult = Login(driver, AllSheetResult.dt.Rows[iSubRowLoop]);

        //            if (TestCaseResult.Result1 == KeyWords.Result_FAIL)
        //            {
        //                Result_ScreenShot = SaveScreenShot(driver, "TestCase_" + AllSheetResult.dt.Rows[iSubRowLoop][0].ToString() + "_");
        //                if (Result_ScreenShot.Result1 == KeyWords.Result_PASS)
        //                {
        //                    TestCaseResult.ErrorMessage = TestCaseResult.ErrorMessage + " , " + Result_ScreenShot.ErrorMessage;
        //                    WriteExlResult = ReadExcelHelper.WriteDataToExcelFile(strExlOutputPath, strColArray, strDataArray, iLoop.ToString(), NumberOfRepeats.ToString(), TestCaseResult.Result1, TestCaseResult.ErrorMessage);
        //                }
        //                else
        //                {
        //                    WriteLogFileTestCaseErrorResult(strLogfilePath, Result_ScreenShot.ErrorMessage, 2);
        //                    WriteExlResult = ReadExcelHelper.WriteDataToExcelFile(strExlOutputPath, strColArray, strDataArray, iLoop.ToString(), NumberOfRepeats.ToString(), TestCaseResult.Result1, TestCaseResult.ErrorMessage);
        //                }

        //                WriteLogFileTestCaseErrorResult(strLogfilePath, TestCaseResult.ErrorMessage, 1);
        //                WriteLogFileTestCaseHeaders(strLogfilePath, AllSheetResult.dt.Rows[iSubRowLoop][0].ToString(), 2);
        //                iSubRowLoop = AllSheetResult.dt.Rows.Count;
        //                TestCaseResult.Result1 = KeyWords.Result_FAIL;
        //                return TestCaseResult;
        //            }
        //        }
        //    }
        //    if (iSubRowLoop == 0)
        //    {

        //        KeyWords.strLoginUser = AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString();
        //        TestCaseResult = Login(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
        //        //driver.FindElement(By.CssSelector("strong")).Click();
        //        if (TestCaseResult.Result1 == KeyWords.Result_FAIL)
        //        {
        //            Result_ScreenShot = SaveScreenShot(driver, "TestCase_" + AllSheetResult.dt.Rows[iSubRowLoop][0].ToString() + "_");
        //            if (Result_ScreenShot.Result1 == KeyWords.Result_PASS)
        //            {
        //                TestCaseResult.ErrorMessage = TestCaseResult.ErrorMessage + " , " + Result_ScreenShot.ErrorMessage;
        //                WriteExlResult = ReadExcelHelper.WriteDataToExcelFile(strExlOutputPath, strColArray, strDataArray, iLoop.ToString(), NumberOfRepeats.ToString(), TestCaseResult.Result1, TestCaseResult.ErrorMessage);
        //            }
        //            else
        //            {
        //                WriteLogFileTestCaseErrorResult(strLogfilePath, Result_ScreenShot.ErrorMessage, 2);
        //                WriteExlResult = ReadExcelHelper.WriteDataToExcelFile(strExlOutputPath, strColArray, strDataArray, iLoop.ToString(), NumberOfRepeats.ToString(), TestCaseResult.Result1, TestCaseResult.ErrorMessage);
        //            }
        //            WriteLogFileTestCaseErrorResult(strLogfilePath, TestCaseResult.ErrorMessage, 1);
        //            WriteLogFileTestCaseHeaders(strLogfilePath, AllSheetResult.dt.Rows[iSubRowLoop][0].ToString(), 2);
        //            iSubRowLoop = AllSheetResult.dt.Rows.Count;
        //            TestCaseResult.Result1 = KeyWords.Result_FAIL;
        //            return TestCaseResult;
        //        }
        //    }
        //    TestCaseResult.Result1 = KeyWords.Result_PASS;
        //    TestCaseResult.ErrorMessage = KeyWords.MSG_strLoginsuccessfully;
        //    return TestCaseResult;
        //}

        public Result TestCase_Login_Execution_NewApp(IWebDriver driver, Result AllSheetResult, string strLogfilePath, string strExlOutputPath, int iSubRowLoop, string[] strColArray, string[] strDataArray, int iLoop, string NumberOfRepeats, string strTestcaseNumber)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            // var MainSheetResult = new Result();
            var TestCaseResult = new Result();
            var Result_ScreenShot = new Result();
            var WriteExlResult = new Result();
            var resultsDatabse = new Result();


            WriteLogFileTestCaseHeaders(strLogfilePath, AllSheetResult.dt.Rows[iSubRowLoop][0].ToString(), 1);
            //  KeyWords.str_Browser_Execute = AllSheetResult.dt.Rows[iSubRowLoop]["P1"].ToString();
           // Thread.Sleep(3000);
            //if (iSubRowLoop != 0)
            //{
            //    if (KeyWords.strLoginUser != AllSheetResult.dt.Rows[iSubRowLoop]["P1"].ToString())
            //    {
            //        kwm.Logout_Link_Click_NewUI(driver, "Logout");
            //        Thread.Sleep(3000);
            //        KeyWords.strLoginUser = AllSheetResult.dt.Rows[iSubRowLoop]["P1"].ToString();
            //        TestCaseResult = Login_NewApp(driver, AllSheetResult.dt.Rows[iSubRowLoop]);

            //        if (TestCaseResult.Result1 == KeyWords.Result_FAIL)
            //        {
            //            Result_ScreenShot = SaveScreenShot(driver, "TestCase_" + AllSheetResult.dt.Rows[iSubRowLoop][0].ToString() + "_");
            //            if (Result_ScreenShot.Result1 == KeyWords.Result_PASS)
            //            {
            //                TestCaseResult.ErrorMessage = TestCaseResult.ErrorMessage + " , " + Result_ScreenShot.ErrorMessage;
            //                WriteExlResult = ReadExcelHelper.WriteDataToExcelFile(strExlOutputPath, strColArray, strDataArray, iLoop.ToString(), NumberOfRepeats.ToString(), TestCaseResult.Result1, TestCaseResult.ErrorMessage);
            //            }
            //            else
            //            {
            //                WriteLogFileTestCaseErrorResult(strLogfilePath, Result_ScreenShot.ErrorMessage, 2);
            //                WriteExlResult = ReadExcelHelper.WriteDataToExcelFile(strExlOutputPath, strColArray, strDataArray, iLoop.ToString(), NumberOfRepeats.ToString(), TestCaseResult.Result1, TestCaseResult.ErrorMessage);
            //            }

            //            WriteLogFileTestCaseErrorResult(strLogfilePath, TestCaseResult.ErrorMessage, 1);
            //            WriteLogFileTestCaseHeaders(strLogfilePath, AllSheetResult.dt.Rows[iSubRowLoop][0].ToString(), 2);
            //            iSubRowLoop = AllSheetResult.dt.Rows.Count;
            //            TestCaseResult.Result1 = KeyWords.Result_FAIL;
            //            return TestCaseResult;
            //        }
            //    }
            //}
            if (iSubRowLoop == 0)
            {
                //if (strTestcaseNumber == "00x")
                //{
                //    TestCaseResult = Get_Table_Data_Database("select a.approveremail from ST_MS_WF_ReqQueue a join ST_MS_WF_ReqWorkflow b on a.requirementid=b.requirementid and b.reqapproverid =a.reqsenttoapproverid where b.requirementid=21081 and b.clientid=21", "approveremail");
                //    string iUserID = "";
                //    if (TestCaseResult.listData.Count >= 1)
                //    {
                //        iUserID = TestCaseResult.listData[0];
                //    }
                //}
                //else
                //{
                    KeyWords.strLoginUser = AllSheetResult.dt.Rows[iSubRowLoop]["P1"].ToString();


                    if (KeyWords.LoginUser_Role == "Supplier")
                    {
                        if (KeyWords.str_App_Url2 == "")
                        {
                            Thread.Sleep(1000);
                            TestCaseResult = Login_NewApp(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
                        }
                        else
                        {
                            TestCaseResult = Supplier_Login_NewApp(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
                        }


                    }
                    else
                    {
                        Thread.Sleep(1000);
                        TestCaseResult = Login_NewApp(driver, AllSheetResult.dt.Rows[iSubRowLoop]);
                    }
                    //kwm.Logout_Link_Click_NewUI(driver, "Logout");
                    //driver.FindElement(By.CssSelector("strong")).Click();
                    if (TestCaseResult.Result1 == KeyWords.Result_FAIL)
                    {
                        Result_ScreenShot = SaveScreenShot(driver, "TestCase_" + AllSheetResult.dt.Rows[iSubRowLoop][0].ToString() + "_");
                        if (Result_ScreenShot.Result1 == KeyWords.Result_PASS)
                        {
                            TestCaseResult.ErrorMessage = TestCaseResult.ErrorMessage + " , " + Result_ScreenShot.ErrorMessage;
                            WriteExlResult = ReadExcelHelper.WriteDataToExcelFile(strExlOutputPath, strColArray, strDataArray, iLoop.ToString(), NumberOfRepeats.ToString(), TestCaseResult.Result1, TestCaseResult.ErrorMessage);
                        }
                        else
                        {
                            WriteLogFileTestCaseErrorResult(strLogfilePath, Result_ScreenShot.ErrorMessage, 2);
                            WriteExlResult = ReadExcelHelper.WriteDataToExcelFile(strExlOutputPath, strColArray, strDataArray, iLoop.ToString(), NumberOfRepeats.ToString(), TestCaseResult.Result1, TestCaseResult.ErrorMessage);
                        }
                        WriteLogFileTestCaseErrorResult(strLogfilePath, TestCaseResult.ErrorMessage, 1);
                        WriteLogFileTestCaseHeaders(strLogfilePath, AllSheetResult.dt.Rows[iSubRowLoop][0].ToString(), 2);
                        iSubRowLoop = AllSheetResult.dt.Rows.Count;
                        TestCaseResult.Result1 = KeyWords.Result_FAIL;
                        return TestCaseResult;
                    }
                
            }
            TestCaseResult.Result1 = KeyWords.Result_PASS;
            TestCaseResult.ErrorMessage = KeyWords.MSG_strLoginsuccessfully;
            return TestCaseResult;
        }

        public Result TestCase_Login_Execution_NewApp_Approver(IWebDriver driver, Result AllSheetResult, string strLogfilePath, string strExlOutputPath, int iSubRowLoop, string[] strColArray, string[] strDataArray, int iLoop, string NumberOfRepeats, int iApproveLoop)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            var TestCaseResult = new Result();
            var Result_ScreenShot = new Result();
            var WriteExlResult = new Result();
            var resultsDatabse = new Result();

            WriteLogFileTestCaseHeaders(strLogfilePath, AllSheetResult.dt.Rows[iSubRowLoop][0].ToString(), 1);
            KeyWords.str_Browser_Execute = AllSheetResult.dt.Rows[iSubRowLoop]["P1"].ToString();
            //Thread.Sleep(3000);
            if (iApproveLoop != 1)
            {
                if (KeyWords.strLoginUser != AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString())
                {
                    kwm.Logout_Link_Click_NewUI(driver, "Logout");
                    Thread.Sleep(3000);
                    KeyWords.strLoginUser = AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString();
                    TestCaseResult = Login_NewApp(driver, AllSheetResult.dt.Rows[iSubRowLoop]);

                    if (TestCaseResult.Result1 == KeyWords.Result_FAIL)
                    {
                        Result_ScreenShot = SaveScreenShot(driver, "TestCase_" + AllSheetResult.dt.Rows[iSubRowLoop][0].ToString() + "_");
                        if (Result_ScreenShot.Result1 == KeyWords.Result_PASS)
                        {
                            TestCaseResult.ErrorMessage = TestCaseResult.ErrorMessage + " , " + Result_ScreenShot.ErrorMessage;
                            WriteExlResult = ReadExcelHelper.WriteDataToExcelFile(strExlOutputPath, strColArray, strDataArray, iLoop.ToString(), NumberOfRepeats.ToString(), TestCaseResult.Result1, TestCaseResult.ErrorMessage);
                        }
                        else
                        {
                            WriteLogFileTestCaseErrorResult(strLogfilePath, Result_ScreenShot.ErrorMessage, 2);
                            WriteExlResult = ReadExcelHelper.WriteDataToExcelFile(strExlOutputPath, strColArray, strDataArray, iLoop.ToString(), NumberOfRepeats.ToString(), TestCaseResult.Result1, TestCaseResult.ErrorMessage);
                        }

                        WriteLogFileTestCaseErrorResult(strLogfilePath, TestCaseResult.ErrorMessage, 1);
                        WriteLogFileTestCaseHeaders(strLogfilePath, AllSheetResult.dt.Rows[iSubRowLoop][0].ToString(), 2);
                        iSubRowLoop = AllSheetResult.dt.Rows.Count;
                        TestCaseResult.Result1 = KeyWords.Result_FAIL;
                        return TestCaseResult;
                    }
                }
            }
            if (iApproveLoop == 1)
            {

                KeyWords.strLoginUser = AllSheetResult.dt.Rows[iSubRowLoop]["P3"].ToString();
                TestCaseResult = Login_NewApp(driver, AllSheetResult.dt.Rows[iSubRowLoop]);

                //kwm.Logout_Link_Click_NewUI(driver, "Logout");
                //driver.FindElement(By.CssSelector("strong")).Click();
                if (TestCaseResult.Result1 == KeyWords.Result_FAIL)
                {
                    Result_ScreenShot = SaveScreenShot(driver, "TestCase_" + AllSheetResult.dt.Rows[iSubRowLoop][0].ToString() + "_");
                    if (Result_ScreenShot.Result1 == KeyWords.Result_PASS)
                    {
                        TestCaseResult.ErrorMessage = TestCaseResult.ErrorMessage + " , " + Result_ScreenShot.ErrorMessage;
                        WriteExlResult = ReadExcelHelper.WriteDataToExcelFile(strExlOutputPath, strColArray, strDataArray, iLoop.ToString(), NumberOfRepeats.ToString(), TestCaseResult.Result1, TestCaseResult.ErrorMessage);
                    }
                    else
                    {
                        WriteLogFileTestCaseErrorResult(strLogfilePath, Result_ScreenShot.ErrorMessage, 2);
                        WriteExlResult = ReadExcelHelper.WriteDataToExcelFile(strExlOutputPath, strColArray, strDataArray, iLoop.ToString(), NumberOfRepeats.ToString(), TestCaseResult.Result1, TestCaseResult.ErrorMessage);
                    }
                    WriteLogFileTestCaseErrorResult(strLogfilePath, TestCaseResult.ErrorMessage, 1);
                    WriteLogFileTestCaseHeaders(strLogfilePath, AllSheetResult.dt.Rows[iSubRowLoop][0].ToString(), 2);
                    iSubRowLoop = AllSheetResult.dt.Rows.Count;
                    TestCaseResult.Result1 = KeyWords.Result_FAIL;
                    return TestCaseResult;

                }
            }
            TestCaseResult.Result1 = KeyWords.Result_PASS;
            TestCaseResult.ErrorMessage = KeyWords.MSG_strLoginsuccessfully;
            return TestCaseResult;
        }

        public Result TestCase_Result_Execution(IWebDriver driver, Result AllSheetResult, Result TestCaseResult, string strLogfilePath, string strExlOutputPath, int iSubRowLoop, string[] strColArray, string[] strDataArray, int iLoop, string NumberOfRepeats)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            //var TestCaseResult = new Result();
            var Result_ScreenShot = new Result();
            var WriteExlResult = new Result();
            var resultsDatabse = new Result();


            if (TestCaseResult.Result1 == KeyWords.Result_PASS)
            {
                WriteLogFileTestCaseErrorResult(strLogfilePath, TestCaseResult.ErrorMessage, 3);
                WriteExlResult = ReadExcelHelper.WriteDataToExcelFile(strExlOutputPath, strColArray, strDataArray, iLoop.ToString(), NumberOfRepeats, TestCaseResult.Result1, TestCaseResult.ErrorMessage);
            }
            else
            {
                Result_ScreenShot = SaveScreenShot(driver, "TestCase_" + AllSheetResult.dt.Rows[iSubRowLoop][0].ToString() + "_");
                if (Result_ScreenShot.Result1 == KeyWords.Result_PASS)
                {
                    TestCaseResult.ErrorMessage = TestCaseResult.ErrorMessage + " , " + Result_ScreenShot.ErrorMessage;
                    WriteExlResult = ReadExcelHelper.WriteDataToExcelFile(strExlOutputPath, strColArray, strDataArray, iLoop.ToString(), NumberOfRepeats, TestCaseResult.Result1, TestCaseResult.ErrorMessage);
                }
                else
                {
                    WriteLogFileTestCaseErrorResult(strLogfilePath, Result_ScreenShot.ErrorMessage, 2);
                    WriteExlResult = ReadExcelHelper.WriteDataToExcelFile(strExlOutputPath, strColArray, strDataArray, iLoop.ToString(), NumberOfRepeats, TestCaseResult.Result1, TestCaseResult.ErrorMessage);
                }
                WriteLogFileTestCaseErrorResult(strLogfilePath, TestCaseResult.ErrorMessage, 1);
            }
            if (WriteExlResult.Result1 == KeyWords.Result_FAIL)
            {
                // Write a msg to log file
                // write a log file code
                WriteLogFileTestCaseErrorResult(strLogfilePath, WriteExlResult.ErrorMessage, 3);
            }
            WriteLogFileTestCaseHeaders(strLogfilePath, AllSheetResult.dt.Rows[iSubRowLoop][0].ToString(), 2);

            if (iSubRowLoop == AllSheetResult.dt.Rows.Count - 1)
            {
                //  Console.WriteLine("I am clicking on logout link1");
                if (KeyWords.blnFlagLogout == true)
                {
                    kwm.Logout_Link_Click_NewUI(driver, "Logout");
                }
                Thread.Sleep(5000);
            }
            TestCaseResult.Result1 = KeyWords.Result_PASS;
            return TestCaseResult;
        }

        public static string Capture(IWebDriver driver)
        {
            DateTime date1 = DateTime.Now;
            string screenShotName = date1.ToString("yyyyMMMddHHmmss");

            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "ErrorScreenshots\\" + screenShotName + ".png";
            string localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return localpath;
        }

        public void TestCase_Result_OutPutExcel_Old()
        {
            string strprojectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string strLogfilePath = strprojectPath + "\\Input\\SmartTrack_logfile.txt";
            string sourceDirFile = strprojectPath + "\\Input\\MainFiles\\SmartTrack_Output.xlsx";
            string targetDirFile = strprojectPath + "\\Input\\SmartTrack_Output.xlsx";
            String strFullDateTime = DateTime.Now.ToString("dd-MM-yyyy_HH_mm_ss");

            if (KeyWords.strExlOutputPath == "")
            {

                targetDirFile = targetDirFile.Substring(0, targetDirFile.Length - 5) + "_" + strFullDateTime + ".xlsx";
                // targetDirFile = targetDirFile 
                if (!File.Exists(targetDirFile))
                {
                    File.Copy(sourceDirFile, targetDirFile, true);
                    FileInfo myFile = new FileInfo(targetDirFile);
                    myFile.IsReadOnly = false;
                    KeyWords.strExlOutputPath = targetDirFile.ToString();
                }



            }
            if (KeyWords.strLogfilePath == "")
            {
                KeyWords.strLogfilePath = strLogfilePath.Substring(0, strLogfilePath.Length - 4) + "_" + strFullDateTime + ".txt";
            }
            string strUpdateSql = "Update [Output$] set OutputExcel = '" + KeyWords.strExlOutputPath + "', OutputLogfile = '" + KeyWords.strLogfilePath + "'  WHERE SNO= '001'";

            ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSql);
            TestCase_Result_OutPutExcel();
        }
        public void TestCase_Result_OutPutExcel_Reports()
        {
            string strprojectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string strLogfilePath = strprojectPath + "\\Input\\SmartTrack_logfile.txt";
            string sourceDirFile = strprojectPath + "\\Input\\MainFiles\\SmartTrack_Output.xlsx";
            string targetDirFile = strprojectPath + "\\Input\\SmartTrack_Output.xlsx";
            String strFullDateTime = DateTime.Now.ToString("dd-MM-yyyy_HH_mm_ss");

            if (KeyWords.strExlOutputPath == "")
            {

                targetDirFile = targetDirFile.Substring(0, targetDirFile.Length - 5) + "_" + strFullDateTime + ".xlsx";
                // targetDirFile = targetDirFile 
                if (!File.Exists(targetDirFile))
                {
                    File.Copy(sourceDirFile, targetDirFile, true);
                    FileInfo myFile = new FileInfo(targetDirFile);
                    myFile.IsReadOnly = false;
                    KeyWords.strExlOutputPath = targetDirFile.ToString();
                }



            }
            if (KeyWords.strLogfilePath == "")
            {
                KeyWords.strLogfilePath = strLogfilePath.Substring(0, strLogfilePath.Length - 4) + "_" + strFullDateTime + ".txt";
            }
            string strUpdateSql = "Update [Output$] set OutputExcel = '" + KeyWords.strExlOutputPath + "', OutputLogfile = '" + KeyWords.strLogfilePath + "'  WHERE SNO= '001'";

            ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSql);
            TestCase_Result_OutPutExcel_ReportsRead();
        }

        public void TestCase_Result_OutPutExcel_ReportsRead()
        {
            var results = new Result();
            string strSubSql = "SELECT * FROM [Output$] WHERE SNO= '001'";
            // Console.WriteLine(KeyWords.strExlInputPath);
            results = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlReportsInputPath, "Output$", strSubSql);
            string stralreadyUsingexcel = "The Microsoft Office Access database engine cannot open or write to the file ";//''. It is already opened exclusively by another user, or you need permission to view and write its data";
            if (results.ErrorMessage.Contains(stralreadyUsingexcel))
            {
                Thread.Sleep(5000);
                results = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlReportsInputPath, "Output$", strSubSql);
                if (results.ErrorMessage.Contains(stralreadyUsingexcel))
                {
                    Thread.Sleep(10000);
                    results = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlReportsInputPath, "Output$", strSubSql);

                }
            }
            // KeyWords.strExlOutputPath = results.dt.Rows[0]["InputExcel"].ToString();
            KeyWords.strExlOutputPath = results.dt.Rows[0]["OutputExcel"].ToString();
            KeyWords.strLogfilePath = results.dt.Rows[0]["OutputLogfile"].ToString();
            KeyWords.strNunitConsolePath = results.dt.Rows[0]["NunitConsoleFilePath"].ToString();
            KeyWords.str_Database_IPNAME = results.dt.Rows[0]["DBIP_NAME"].ToString();
            //  Console.WriteLine(KeyWords.strExlOutputPath);
            //  Console.WriteLine(KeyWords.strLogfilePath);

        }

        //public Result ChooseETK(IWebDriver driver, string RequisitionType, string ETKOption, WebDriverWait _WDWait)
        //{
        //    KeyWordMethods kwm = new KeyWordMethods();

        //    var results = new Result();
        //    try
        //    {
        //        if (ETKOption.Trim().ToUpper().ToString().Equals("YES"))
        //        {
        //            kwm.click_Xpath(driver, KeyWords.locator_XPath, KeyWords.XPath_Btn_ETKYes_confirmationBypassETKDialog);

        //            results.Result1 = KeyWords.Result_PASS;
        //        }
        //        else
        //        {
        //            kwm.click_Xpath(driver, KeyWords.locator_XPath, KeyWords.XPath_Btn_ETKNo_confirmationBypassETKDialog);


        //            if (RequisitionType.Contains("Regular"))
        //            {
        //                // Wait until 1st question is displayed
        //                kwm.waitForElementToBeVisible(driver, By.XPath(KeyWords.XPath_1stQueYes), _WDWait);
        //                kwm.waitForElementToBeClickable(driver, By.XPath(KeyWords.XPath_1stQueYes), _WDWait);
        //                Thread.Sleep(1000);

        //                // Choose First Question 
        //                kwm.click_Xpath(driver, KeyWords.locator_XPath, KeyWords.XPath_1stQueYes);
        //                kwm.waitForElementToBeVisible(driver, By.XPath(KeyWords.XPath_2ndQueGoogler), _WDWait);
        //                kwm.waitForElementToBeClickable(driver, By.XPath(KeyWords.XPath_2ndQueGoogler), _WDWait);
        //                Thread.Sleep(1000);

        //                // Choose Second Question
        //                kwm.click_Xpath(driver, KeyWords.locator_XPath, KeyWords.XPath_2ndQueGoogler);
        //                kwm.waitForElementToBeVisible(driver, By.XPath(KeyWords.XPath_3rdQueYes), _WDWait);
        //                kwm.waitForElementToBeClickable(driver, By.XPath(KeyWords.XPath_3rdQueYes), _WDWait);
        //                Thread.Sleep(1000);

        //                // Choose Third Question
        //                kwm.click_Xpath(driver, KeyWords.locator_XPath, KeyWords.XPath_3rdQueYes);
        //                kwm.waitForElementToBeVisible(driver, By.XPath(KeyWords.XPath_4thQueNo), _WDWait);
        //                kwm.waitForElementToBeClickable(driver, By.XPath(KeyWords.XPath_4thQueNo), _WDWait);
        //                Thread.Sleep(1000);

        //                // Choose Fourth Question
        //                kwm.click_Xpath(driver, KeyWords.locator_XPath, KeyWords.XPath_4thQueNo);
        //                kwm.waitForElementToBeVisible(driver, By.XPath(KeyWords.XPath_5thQueNo), _WDWait);
        //                kwm.waitForElementToBeClickable(driver, By.XPath(KeyWords.XPath_5thQueNo), _WDWait);
        //                Thread.Sleep(1000);

        //                // Choose 5th Question
        //                kwm.click_Xpath(driver, KeyWords.locator_XPath, KeyWords.XPath_5thQueNo);
        //                Thread.Sleep(2000);

        //                results.Result1 = KeyWords.Result_PASS;
        //            }
        //            else if (RequisitionType.Contains("Identified"))
        //            {
        //               // Wait until 1st question is displayed
        //                kwm.waitForElementToBeVisible(driver, By.XPath(KeyWords.XPath_1stQueYes), _WDWait);
        //                kwm.waitForElementToBeClickable(driver, By.XPath(KeyWords.XPath_1stQueYes), _WDWait);
        //                Thread.Sleep(1000);

        //                // Choose First Question 
        //                kwm.click_Xpath(driver, KeyWords.locator_XPath, KeyWords.XPath_1stQueYes);
        //                kwm.waitForElementToBeVisible(driver, By.XPath(KeyWords.XPath_2ndQueGoogler), _WDWait);
        //                kwm.waitForElementToBeClickable(driver, By.XPath(KeyWords.XPath_2ndQueGoogler), _WDWait);
        //                Thread.Sleep(1000);

        //                // Choose Second Question
        //                kwm.click_Xpath(driver, KeyWords.locator_XPath, KeyWords.XPath_2ndQueGoogler);
        //                kwm.waitForElementToBeVisible(driver, By.XPath(KeyWords.XPath_3rdQueYes), _WDWait);
        //                kwm.waitForElementToBeClickable(driver, By.XPath(KeyWords.XPath_3rdQueYes), _WDWait);
        //                Thread.Sleep(1000);

        //                // Choose Third Question
        //                kwm.click_Xpath(driver, KeyWords.locator_XPath, KeyWords.XPath_3rdQueYes);
        //                kwm.waitForElementToBeVisible(driver, By.XPath(KeyWords.XPath_4thQueNo), _WDWait);
        //                kwm.waitForElementToBeClickable(driver, By.XPath(KeyWords.XPath_4thQueNo), _WDWait);
        //                Thread.Sleep(1000);

        //                // Choose Fourth Question
        //                kwm.click_Xpath(driver, KeyWords.locator_XPath, KeyWords.XPath_4thQueNo);
        //                kwm.waitForElementToBeVisible(driver, By.XPath(KeyWords.XPath_5thQueYes), _WDWait);
        //                kwm.waitForElementToBeClickable(driver, By.XPath(KeyWords.XPath_5thQueYes), _WDWait);
        //                Thread.Sleep(1000);

        //                // Choose 5th Question
        //                kwm.click_Xpath(driver, KeyWords.locator_XPath, KeyWords.XPath_5thQueYes);
        //                Thread.Sleep(2000);

        //                results.Result1 = KeyWords.Result_PASS;
        //            }
        //            else if (RequisitionType.Contains("Template"))
        //            {
        //                results.Result1 = KeyWords.Result_PASS;
        //            }

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        logTest.Log(LogStatus.Error, e.Message);
        //        results.Result1 = KeyWords.Result_FAIL;
        //        results.ErrorMessage = "Clicking on ChooseETK Element Failed ";
        //        string screenShotPath = CommonMethods.Capture(driver);
        //        logTest.Log(LogStatus.Info, "Snapshot below: " + logTest.AddScreenCapture(screenShotPath));
        //        WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, e.Message, 3);
        //        results.ErrorMessage1 = e.Message;
        //        return results;
        //    }
        //    return results;
        //}

        public Result js_Action_MouseOver_Element(IWebDriver driver, String Locator, string strElement)
        {
            var results = new Result();
            try
            {
                IWebElement element = null;
                switch (Locator.ToLower())
                {
                    case "id": element = driver.FindElement(By.Id(strElement)); break;
                    case "xpath": element = driver.FindElement(By.XPath(strElement)); break;
                    case "name": element = driver.FindElement(By.Name(strElement)); break;
                    default: break;
                }

                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                string sScript = "if(document.createEvent){var evObj = document.createEvent('MouseEvents');evObj.initEvent('mouseover',true, false); arguments[0].dispatchEvent(evObj);}";
                jse.ExecuteScript(sScript, element);
                results.Result1 = KeyWords.Result_PASS;
                return results;
            }
            catch (Exception ex)
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = ex.Message;
                return results;
            }
            return null;
        }

        public Result js_Action_MoveTo_Element(IWebDriver driver, String Locator, String strelement)
        {
            var results = new Result();
            try
            {
                IWebElement element = null;
                switch (Locator.ToLower())
                {
                    case "id": element = driver.FindElement(By.Id(strelement)); break;
                    case "xpath": element = driver.FindElement(By.XPath(strelement)); break;
                    case "name": element = driver.FindElement(By.Name(strelement)); break;
                    default: break;
                }

                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                jse.ExecuteScript("arguments[0].scrollIntoView(true);", element);
                results.Result1 = KeyWords.Result_PASS;
                return results;
            }
            catch (Exception ex)
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = ex.Message;
                return results;
            }
        }

        public void TestCase_Result_OutPutExcel()
        {
            var results = new Result();
            string strSubSql = "SELECT * FROM [Output$] WHERE SNO= '001'";
            // Console.WriteLine(KeyWords.strExlInputPath);
            results = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "Output$", strSubSql);
            string stralreadyUsingexcel = "The Microsoft Office Access database engine cannot open or write to the file ";//''. It is already opened exclusively by another user, or you need permission to view and write its data";
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                Console.WriteLine("results.ErrorMessage  --- >" + results.ErrorMessage);
                if (results.ErrorMessage.Contains(stralreadyUsingexcel))
                {
                    Thread.Sleep(5000);
                    results = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "Output$", strSubSql);
                    if (results.ErrorMessage.Contains(stralreadyUsingexcel))
                    {
                        Thread.Sleep(10000);
                        results = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "Output$", strSubSql);

                    }
                }
                else
                {
                    results = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "Output$", strSubSql);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Console.WriteLine("results.ErrorMessage  --- >" + results.ErrorMessage);
                        if (results.ErrorMessage.Contains(stralreadyUsingexcel))
                        {
                            Thread.Sleep(5000);
                            results = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "Output$", strSubSql);
                            if (results.ErrorMessage.Contains(stralreadyUsingexcel))
                            {
                                Thread.Sleep(10000);
                                results = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, "Output$", strSubSql);

                            }
                        }
                    }
                }
            }
            // KeyWords.strExlOutputPath = results.dt.Rows[0]["InputExcel"].ToString();
            KeyWords.strExlOutputPath = results.dt.Rows[0]["OutputExcel"].ToString();
            KeyWords.strLogfilePath = results.dt.Rows[0]["OutputLogfile"].ToString();
            // KeyWords.strNunitConsolePath = results.dt.Rows[0]["NunitConsoleFilePath"].ToString();
            KeyWords.str_Database_IPNAME = results.dt.Rows[0]["DBIP_NAME"].ToString();
            KeyWords.str_Database_UserNamePassword = results.dt.Rows[0]["DB_USERNAME_PWD"].ToString();


            //  Console.WriteLine(KeyWords.strExlOutputPath);
            //  Console.WriteLine(KeyWords.strLogfilePath);

        }


        public Result Get_Table_Data_Database(string strDataBaseQuery, string strCloName)
        {
            var results = new Result();
            results.Result1 = "Pass";
            // Data Source=10.0.0.29;Initial Catalog=STV70R12_QAMAIN;User ID=stwebuser
            //  "Data Source=10.0.0.29;Initial Catalog=STV70R12_QAMAIN;User ID=stwebuser;Password=dv$#2345q";
            if (KeyWords.str_Database_IPNAME == "")
            {
                KeyWords.str_Database_connStr = "Data Source=10.0.2.29;Initial Catalog=STV70R12_QAMAIN;User ID=stwebuser;Password=dv$#2345q";
            }
            else
            {
                KeyWords.str_Database_connStr = KeyWords.str_Database_IPNAME + ";" + KeyWords.str_Database_UserNamePassword;
            }
            //string connStr =  "data source=10.0.0.29;initial catalog=STV70R12_QAMAIN;user ID=stwebuser;password=dv$#2345q;min pool size=1;max pool size=100;pooling=false";
            try
            {
                SqlConnection conn = new SqlConnection(KeyWords.str_Database_connStr);

                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    //cmd.CommandText = "Update sparam set para_val = 'N' where lender_id = 8143 and para_name = 'SH_PER_VER_PP'";
                    cmd.CommandText = strDataBaseQuery;
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<String> arrayDataList = new List<String>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
                            //    reader.GetString(1));
                            //arrayDataList.Add(reader["ChargeNumber"].ToString());
                            arrayDataList.Add(reader[strCloName].ToString());

                        }

                    }
                    else
                    {
                        // Console.WriteLine("No rows found.");
                        results.Result1 = KeyWords.Result_FAIL;
                        results.ErrorMessage = "No rows found.";
                        return results;
                    }
                    reader.Close();
                    results.Result1 = KeyWords.Result_PASS;
                    results.listData = arrayDataList;
                    return results;




                }

            }
            catch (Exception e)
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = e.Message;
                //return results;
            }
            return results;
        }

        public Result Update_Table_Data_Database(string strDataBaseQuery)
        {
            var results = new Result();
            results.Result1 = KeyWords.Result_PASS;
            if (KeyWords.str_Database_IPNAME == "")
            {
                KeyWords.str_Database_connStr = "Data Source=10.0.0.29;Initial Catalog=STV70R12_QAMAIN;User ID=stwebuser;Password=dv$#2345q";
            }
            else
            {
                KeyWords.str_Database_connStr = KeyWords.str_Database_IPNAME + ";" + KeyWords.str_Database_UserNamePassword;
            }
            try
            {
                SqlConnection conn = new SqlConnection(KeyWords.str_Database_connStr);

                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    //cmd.CommandText = "Update sparam set para_val = 'N' where lender_id = 8143 and para_name = 'SH_PER_VER_PP'";
                    cmd.CommandText = strDataBaseQuery;
                    cmd.CommandType = CommandType.Text;

                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)
                    {
                        conn.Close();
                        results.Result1 = KeyWords.Result_PASS;
                        //  return results;
                    }
                    else
                    {
                        conn.Close();
                        results.Result1 = KeyWords.Result_FAIL;
                        results.ErrorMessage = i.ToString();

                    }
                    return results;
                }

            }
            catch (Exception e)
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = e.Message;
                //return results;
            }
            return results;
        }

        public Result Delete_OB_Table_Data_Database(string strDataBaseQuery)
        {
            var results = new Result();
            results.Result1 = KeyWords.Result_PASS;
            if (KeyWords.str_Database_IPNAME == "")
            {
                KeyWords.str_Database_connStr = "Data Source=10.0.0.29;Initial Catalog=STV70R12_QAMAIN;User ID=stwebuser;Password=dv$#2345q";
            }
            else
            {
                KeyWords.str_Database_connStr = KeyWords.str_Database_IPNAME + ";" + KeyWords.str_Database_UserNamePassword;
            }
            try
            {
                SqlConnection conn = new SqlConnection(KeyWords.str_Database_connStr);

                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    //cmd.CommandText = "Update sparam set para_val = 'N' where lender_id = 8143 and para_name = 'SH_PER_VER_PP'";
                    cmd.CommandText = strDataBaseQuery;
                    cmd.CommandType = CommandType.Text;

                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)
                    {
                        conn.Close();
                        results.Result1 = KeyWords.Result_PASS;
                        //  return results;
                    }
                    else
                    {
                        conn.Close();
                        results.Result1 = KeyWords.Result_FAIL;
                        results.ErrorMessage = i.ToString();

                    }
                    return results;
                }

            }
            catch (Exception e)
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = e.Message;
                //return results;
            }
            return results;
        }


        public Result Validate_Password_Update(string strEmail, string strExcelPassword)
        {
            var results = new Result();
            results.Result1 = "Pass";
            var PasswordResult = new Result();
            string strGetPassword = "Select password from St_lm_user where email = '" + strEmail + "'";
            PasswordResult = Get_Table_Data_Database(strGetPassword, "password");
            if (PasswordResult.Result1 == KeyWords.Result_PASS)
            {
                string strCreatePassword = SmartTrack_Automation.PasswordEncryption.CreateHash(strExcelPassword);
                Boolean bPasswordValidate = SmartTrack_Automation.PasswordEncryption.ValidatePassword(strExcelPassword, strCreatePassword);
                if (!bPasswordValidate)
                {

                    string strUpdatePassword = "update ST_LM_user set password='" + strCreatePassword + "',passwordChangeRequired=0,passwordRetriedCount=0,statusID=1 where userid=(Select userID from ST_LM_user where email like '" + strEmail + "')";
                    Update_Table_Data_Database(strUpdatePassword);
                }
                if (bPasswordValidate)
                {

                    string strUpdatePassword = "update ST_LM_user set password='" + strCreatePassword + "',passwordChangeRequired=0,passwordRetriedCount=0,statusID=1 where userid=(Select userID from ST_LM_user where email like '" + strEmail + "')";
                    Update_Table_Data_Database(strUpdatePassword);
                }
            }

            return results;
        }

        public Boolean Action_Page_Down(IWebDriver driver)
        {

            try
            {
                Actions actions1 = new Actions(driver);
                actions1.SendKeys(Keys.PageDown).Build().Perform();
                actions1.Release();
                // IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                //jse.ExecuteScript("window.scrollBy(0,250)", "");


                return true;

            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Boolean Action_MoveToElement(IWebDriver driver, string target)
        {

            try
            {
                IWebElement element = driver.FindElement(By.Id(target));
                Actions actions1 = new Actions(driver);
                // actions1.SendKeys(Keys.PageDown).Build().Perform();
                actions1.MoveToElement(element).Build().Perform();
                actions1.Release();
                // IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                //jse.ExecuteScript("window.scrollBy(0,250)", "");


                return true;

            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Boolean Action_Button_Backspace(IWebDriver driver)
        {

            try
            {
                Actions actions1 = new Actions(driver);
                actions1.SendKeys(Keys.Backspace).Perform();

                return true;

            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                return false;
            }
        }


        public Boolean Action_Button_Tab(IWebDriver driver)
        {

            try
            {
                Actions actions1 = new Actions(driver);
                actions1.SendKeys(Keys.Tab).Perform();

                return true;

            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                return false;
            }
        }


        public Boolean Action_Button_BackSpace(IWebDriver driver)
        {

            try
            {
                Actions actions1 = new Actions(driver);
                actions1.SendKeys(Keys.Backspace).Perform();

                return true;

            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Boolean Action_Button_Escape(IWebDriver driver)
        {

            try
            {
                Actions actions1 = new Actions(driver);
                actions1.SendKeys(Keys.Escape).Perform();

                return true;

            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                return false;
            }
        }


        public Boolean Action_Button_Enter(IWebDriver driver)
        {

            try
            {
                Actions actions1 = new Actions(driver);
                actions1.SendKeys(Keys.Enter).Perform();

                return true;

            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Boolean Action_Page_UP(IWebDriver driver)
        {

            try
            {
                Actions actions1 = new Actions(driver);
                actions1.SendKeys(Keys.PageUp).Perform();
                // actions1.SendKeys(Keys.PageDown).Perform();
                actions1.Release();


                return true;

            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Boolean Action_Page_Down_ScrollUp(IWebDriver driver)
        {

            try
            {
                Actions actions1 = new Actions(driver);
                actions1.SendKeys(Keys.ArrowUp).Perform();
                actions1.Release();


                return true;

            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                return false;
            }
        }


        public Boolean Action_Page_Down_withoutjavascriptexecutor(IWebDriver driver)
        {

            try
            {
                Actions actions1 = new Actions(driver);
                actions1.SendKeys(Keys.PageDown).Perform();
                actions1.Release();

                //IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                //jse.ExecuteScript("window.scrollBy(0,250)", "");
                //jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

                return true;

            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                return false;
            }
        }


        public Boolean Action_Page_Down_javascriptexecutor(IWebDriver driver)
        {

            try
            {
                Actions actions1 = new Actions(driver);
                actions1.SendKeys(Keys.PageDown).Perform();
                actions1.Release();

                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                jse.ExecuteScript("window.scrollBy(0,250)", "");
                jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

                return true;

            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                return false;
            }
        }


        public Result Select_Radio_Button(IWebDriver driver, string strname, string strvalue)
        {
            var results = new Result();
            results.Result1 = "PASS";
            KeyWordMethods kwm = new KeyWordMethods();
            kwm.Action_LookInto_Element(driver, KeyWords.locator_Name, strname);
            try
            {
                driver.FindElement(By.XPath("//*[@name='" + strname + "' and @type='radio' and @value='" + strvalue + "']")).Click();
                results.Result1 = "PASS";
            }
            catch
            {
                results.Result1 = "FAIL";
                results.ErrorMessage = "Unable to select the Radio button";
            }
            return results;
        }

        public Result Select_Radio_Button_ID(IWebDriver driver, string strID, string strvalue)
        {
            var results = new Result();
            results.Result1 = "PASS";
            KeyWordMethods kwm = new KeyWordMethods();
            kwm.Action_LookInto_Element(driver, KeyWords.locator_ID, strID);
            try
            {
                driver.FindElement(By.XPath("//input[@id='" + strID + "' and @value='" + strvalue + "']")).Click();
                results.Result1 = "PASS";
            }
            catch
            {
                results.Result1 = "FAIL";
                results.ErrorMessage = "Unable to select the Radio button";
            }
            return results;
        }



        //public static ITimeouts ImplicitTenSeconds(IWebDriver driver)
        //{
        //    return driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(120);
        //}

        //public static ITimeouts ImplicitFiveSeconds(IWebDriver driver)
        //{
        //    return driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 5));
        //}

        //public static ITimeouts ImplicitFifteenSeconds(IWebDriver driver)
        //{
        //    return driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 15));
        //}

        ///* public static ITimeouts ImplicitTwentySeconds(IWebDriver driver)
        // {
        //     return driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 20));
        // }*/

        //public static ITimeouts ImplicitTwentyFiveSeconds(IWebDriver driver)
        //{
        //    return driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 25));
        //}

        /*  public static ITimeouts ImplicitThirtySeconds(IWebDriver driver)
          {
              return driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
          }
          */
        public static Boolean Loading_Message_Check(IWebDriver driver)
        {





            Boolean strValue = true;

            for (int z = 1; z < 500; z++)
            {

                try
                {
                    strValue = driver.FindElement(By.Id(KeyWords.ID_STR_loading_message)).Displayed;
                }
                catch
                {
                    //  strValue = true;
                }

                //  Console.WriteLine("z -----> " + z);
                //  Console.WriteLine("strValue -----> " + strValue);
                if (!strValue)
                {
                    break;
                }
                //  Thread.Sleep(100);
            }
            if (!strValue)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool ElementIsDisplayed(IWebDriver driver, By by)
        {
            try
            {
                if (driver.FindElement(by).Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        public void UpdateRequirementNumber(string ReqNumber, string ClientName, string TestScenario)
        {
            var WriteExlResult = new Result();
            ReadExcel ReadExcelHelper = new ReadExcel();

            String strUpdateSqlMain = "Update [MSP$] set P6 ='" + ReqNumber + "'  WHERE P3 ='" + ClientName + "' and TestScenario ='" + TestScenario + "' and TestCaseID <> '001'";
            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);

            String strUpdateSqlMain2 = "Update [Approve$] set P6 ='" + ReqNumber + "'  WHERE P3 ='" + ClientName + "' and TestScenario ='" + TestScenario + "'";
            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain2);


            String strUpdateSqlMain3 = "Update [Supplier$] set P6 ='" + ReqNumber + "'  WHERE P3 ='" + ClientName + "' and TestScenario ='" + TestScenario + "'";
            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain3);
        }


        public void UpdateCandidateName(string CandidateName, string ClientName, string TestScenario)
        {
            var WriteExlResult = new Result();
            ReadExcel ReadExcelHelper = new ReadExcel();

            String strUpdateSqlMain = "Update [MSP$] set P8 ='" + CandidateName + "'  WHERE P3 ='" + ClientName + "' and TestScenario ='" + TestScenario + "' and TestCaseID <> '001'";
            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);

            //String strUpdateSqlMain2 = "Update [Approve$] set P8 ='" + CandidateName + "'  WHERE P3 ='" + ClientName + "' and TestScenario ='" + TestScenario + "'";
            //WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain2);


            String strUpdateSqlMain3 = "Update [Supplier$] set P8 ='" + CandidateName + "'  WHERE P3 ='" + ClientName + "' and TestScenario ='" + TestScenario + "'";
            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain3);
        }

        public void UpdateSupplierEmail(string CandidateName, string ClientName, string TestScenario)
        {
            var WriteExlResult = new Result();
            ReadExcel ReadExcelHelper = new ReadExcel();

            //String strUpdateSqlMain = "Update [MSP$] set P1 ='" + CandidateName + "'  WHERE P3 ='" + ClientName + "' and TestScenario ='" + TestScenario + "' and TestCaseID <> '001'";
            //WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);

            //String strUpdateSqlMain2 = "Update [Approve$] set P1 ='" + CandidateName + "'  WHERE P3 ='" + ClientName + "' and TestScenario ='" + TestScenario + "'";
            //WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain2);


            String strUpdateSqlMain3 = "Update [Supplier$] set P1 ='" + CandidateName + "'  WHERE P3 ='" + ClientName + "' and TestScenario ='" + TestScenario + "'";
            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain3);
        }


        public Result Action_LookInto_Element_ID(IWebDriver driver, String strelement)
        {
            var results = new Result();
            try
            {
                IWebElement element = driver.FindElement(By.Id(strelement));

                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                jse.ExecuteScript("arguments[0].scrollIntoView(true);", element);
                results.Result1 = KeyWords.Result_PASS;
                return results;
            }
            catch (Exception ex)
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = ex.Message;
                return results;
            }
        }


        public void UpdateScriptStatus(int status, string ClientName, string TestScenario)
        {
            var WriteExlResult = new Result();
            ReadExcel ReadExcelHelper = new ReadExcel();

            String strUpdateSqlMain4 = "Update [MSP$] set TestExecute ='" + status + "'  WHERE P3 ='" + ClientName + "' and TestScenario ='" + TestScenario + "'";
            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain4);

            String strUpdateSqlMain5 = "Update [Supplier$] set TestExecute ='" + status + "'  WHERE P3 ='" + ClientName + "' and TestScenario ='" + TestScenario + "'";
            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain5);

            String strUpdateSqlMain6 = "Update [Approve$] set TestExecute ='" + status + "'  WHERE P3 ='" + ClientName + "' and TestScenario ='" + TestScenario + "'";
            WriteExlResult = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain6);

        }

        public Boolean Action_Button_ShiftTab(IWebDriver driver)
        {
            try
            {
                Actions actions1 = new Actions(driver);
                actions1.SendKeys("+{TAB}").Perform();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean Action_Page_ArrowDown(IWebDriver driver)
        {

            try
            {
                Actions actions1 = new Actions(driver);
                actions1.SendKeys(Keys.ArrowDown).Perform();
                actions1.Release();


                return true;

            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);		
                return false;
            }
        }

        public Result js_Action_MouseLeave_Element(IWebDriver driver)
        { 
            var results = new Result();
            try 
            { 
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                string sScript = "$(\"div[class='popover fade right in']\").attr('style','display: none')";
                jse.ExecuteScript(sScript);
                results.Result1 = KeyWords.Result_PASS;
                return results;
            }
            catch (Exception ex)
            { 
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = ex.Message; 
                return results;
            }
           
        }

        //public Result Action_LookInto_Element(IWebDriver driver, String Locator, String strelement)
        //{
        //    var results = new Result();
        //    try
        //    {
        //        IWebElement element = null;
        //        switch (Locator.ToLower())
        //        {
        //            case "id": element = driver.FindElement(By.Id(strelement)); break;
        //            case "xpath": element = driver.FindElement(By.XPath(strelement)); break;
        //            case "name": element = driver.FindElement(By.Name(strelement)); break;
        //            case "linktext": element = driver.FindElement(By.PartialLinkText(strelement)); break;
        //            default: break;
        //        }

        //        IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
        //        jse.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        //        results.Result1 = KeyWords.Result_PASS;
        //        ReportHandler._ChildTest.Log(LogStatus.Pass, "Focus on the element successfully.");
        //        return results;
        //    }
        //    catch (Exception ex)
        //    {
        //        ReportHandler._ChildTest.Log(LogStatus.Fail, ex.Message);
        //        ReportHandler._ChildTest.Log(LogStatus.Info, ex.StackTrace);
        //        results.Result1 = KeyWords.Result_FAIL;
        //        results.ErrorMessage = ex.Message;
        //        return results;
        //    }
        //}


        public Result ActionListSortingOrderVerification(IWebDriver WDriver)
        {
            KeyWordMethods kwm = new KeyWordMethods();
            var results = new Result();
            var Result_ScreenShot = new Result();
            List<string> listExistClients = new List<string>() { };
          
            // Get data from Action list
            int ActionlistCount = WDriver.FindElements(By.XPath("//*[@id='listMenu1']/li")).Count();
            ArrayList Actionlist = new ArrayList();
            for (int i = 1; i <= ActionlistCount; i++)
            {
                Actionlist.Add(WDriver.FindElement(By.XPath("//*[@id='listMenu1']/li[" + i + "]")).Text);
            }
            Boolean IsActionlistSorted = true;
            for (int j = 1; j < Actionlist.Count; j++)
            {
                if (Actionlist[j - 1].ToString().CompareTo(Actionlist[j].ToString()) > 0)
                {
                    IsActionlistSorted = false;
                    break;
                }
            }

            if (IsActionlistSorted == false)
            {
                results._Var = KeyWords.Result_FAIL;
                results.ErrorMessage = "Action list is not sorting order";
                return results;
            }


            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = "Action list is sorting order";
            return results;

        }

        
    }


    public static class Extensions
    {
        public static ReadOnlyCollection<IWebElement> FindAllWhenAvailable(this IWebDriver @this, By locator)
        {

            @this.WaitUntilExists(locator);
            return @this.FindElements(locator);
        }

        public static IWebElement FindWhenAvailable(this IWebDriver @this, By locator)
        {

            @this.WaitUntilExists(locator);
            return @this.FindElement(locator);
        }

        public static void WaitUntilExists(this IWebDriver @this, By locator)
        {

            bool strValue;

            try
            {
                new WebDriverWait(@this, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementExists(locator));
                strValue = @this.FindElement(locator).Displayed;
            }
            catch
            {
                strValue = false;
            }

            if (!strValue)
            {
                var ex = new Exception("Errors reported: Element not found");
                throw ex;

            }
        }


        public class GetScreenShot
        {
            public static string Capture(IWebDriver driver, string screenShotName)
            {
                ITakesScreenshot ts = (ITakesScreenshot)driver;
                Screenshot screenshot = ts.GetScreenshot();
                string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "ErrorScreenshots\\" + screenShotName + ".png";
                string localpath = new Uri(finalpth).LocalPath;
                screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
                return localpath;
            }
        }




    }
}

