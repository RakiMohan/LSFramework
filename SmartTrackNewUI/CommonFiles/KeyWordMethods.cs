// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KeyWordMethods.cs" company="DCR Workforce Inc">
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
    using System.Timers;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections.ObjectModel;
    using OpenQA.Selenium.Interactions.Internal;
    using OpenQA.Selenium.Firefox;
    using System.Threading;
    using OpenQA.Selenium.Support.UI;
    using OpenQA.Selenium.IE;
    using System.Text.RegularExpressions;
    using System.IO;
    using System.Data;
    using System.Configuration;
    //using System.;
    using System.Net;
    using System.Security.Cryptography;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using System.Collections;
    using System.Diagnostics;
    //using OpenQA.Selenium.Interactions;
    using System.Windows.Forms;
    using OpenQA.Selenium.Interactions;
    using CommonFiles;
    using OpenQA.Selenium.Opera;
    using OpenQA.Selenium.Edge;
    using OpenQA.Selenium.Remote;
    using RelevantCodes.ExtentReports;
    using System.Xml;
    // [TestClass]
    public class KeyWordMethods
    {
        
        //  public IWebDriver driver;
        CommonMethods objCommonMethods = new CommonMethods();

        Boolean _LabelCaptured()
        {
            return KeyWords._isLableCaptured;
        }

        public IWebElement inspect(IWebDriver driver, String locator, String target, out string sScreenLblName, String sType = "", String sTempVal = "")
        {

            IWebElement element = null;
            sScreenLblName = "";
            try
            {
                //driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(10));
                if (locator.Equals("id", StringComparison.InvariantCultureIgnoreCase))
                    element = driver.FindElement(By.Id(target));
                else if (locator.Equals("name", StringComparison.InvariantCultureIgnoreCase))
                    element = driver.FindElement(By.Name(target));
                else if (locator.Equals("className", StringComparison.InvariantCultureIgnoreCase))
                    element = driver.FindElement(By.ClassName(target));
                else if (locator.Equals("cssSelector", StringComparison.InvariantCultureIgnoreCase))
                    element = driver.FindElement(By.CssSelector(target));
                else if (locator.Equals("linkText", StringComparison.InvariantCultureIgnoreCase))
                    element = driver.FindElement(By.LinkText(target));
                else if (locator.Equals("partiaLinkText", StringComparison.InvariantCultureIgnoreCase))
                    element = driver.FindElement(By.PartialLinkText(target));
                else if (locator.Equals("tagName", StringComparison.InvariantCultureIgnoreCase))
                    element = driver.FindElement(By.TagName(target));
                else if (locator.Equals("xpath", StringComparison.InvariantCultureIgnoreCase))
                    element = driver.FindElement(By.XPath(target));
                else
                {
                    // Console.WriteLine("Invalid Locator");
                    return null;
                }
                //sScreenLblName = getLabelName(driver, locator, target, sType, sTempVal);
                ////if (KeyWords._isXMLLoaded)
                ////{
                ////    try
                ////    {
                ////        if (sTempVal != "")
                ////            target = sTempVal;
                ////        if (!_LabelCaptured())
                ////        {
                ////            if (KeyWords.LabelDictionary.ContainsKey(target))
                ////            {
                ////                Assert.AreEqual(sScreenLblName.Trim(), KeyWords.LabelDictionary[target].Trim(), "Labels are verified");
                ////                ReportHandler._getLblChildTest().Log(LogStatus.Pass, "Actual Label <b>->" + sScreenLblName.Trim() + "<b> && Expected Label-> <b>" + KeyWords.LabelDictionary[target].Trim() + " <b>: Matched");
                ////            }
                ////            else
                ////            {
                ////                ReportHandler._getLblChildTest().Log(LogStatus.Info, "Label Name ->" + sScreenLblName.Trim() + " : Is not available in the repository");
                ////            }

                ////        }
                ////        else
                ////            KeyWords._isLableCaptured = false;


                ////    }
                ////    catch (Exception e)
                ////    {
                ////        ReportHandler._getLblChildTest().Log(LogStatus.Error, "Actual label: " + sScreenLblName.Trim() + " & Expected Label: " + KeyWords.LabelDictionary[target].Trim() + " - Doesn't Match");
                ////        ReportHandler._getLblChildTest().Log(LogStatus.Info, e.Message);

                ////    }

                ////}
                //else
                //{
                //    ReportHandler._getLblChildTest().Log(LogStatus.Fail, sScreenLblName + "Failed to get the source to compare the labels");
                //}
                //ReportHandler._getChildTest().Log(LogStatus.Pass, "Identified Element :" + sScreenLblName);
                return element;
            }
            catch (Exception e)
            {
                ReportHandler._getChildTest().Log(LogStatus.Fail, e);
                //  Console.WriteLine("I am here null KWM");
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, e.Message, 3);
                return element;

            }

        }
        public Result click1(IWebDriver driver, String locator, String target)
        {
            Result results = new Result();
            try
            {
                IWebElement ele = inspect(driver, locator, target,out KeyWords.sLabelName);

                if (isElementPresent(driver, target))
                {

                    Thread.Sleep(2000);

                    ele.Click();
                    //  Console.WriteLine("Clicking on Element Passed");
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Clicking on Element Passed";
                    return results;
                }
                else
                {
                    // throw new Exception();
                    //  Console.WriteLine("Problem finding the Element");
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Problem finding the Element " + target;
                    return results;

                }

            }
            catch (Exception e)
            {

                // Console.WriteLine("Clicking on Element Failed");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Clicking on Element Failed " + target;
                results.ErrorMessage1 = e.Message;
                return results;
            }
        }

        public Result click(IWebDriver driver, String locator, String target, string sType = "", string sTempValue = "")
        {
            Result results = new Result();
            try
            {
                Action_LookInto_Element(driver, locator, target);
                IWebElement ele = inspect(driver, locator, target, out KeyWords.sLabelName, sType, sTempValue);

                switch (locator.ToLower())
                {
                    case "id": results.blnFlag = isElementDisplayed(driver, target);
                        break;
                    case "xpath": results.blnFlag = isElementDisplayedByXPath(driver, target);
                        break;
                    case "name": results.blnFlag = driver.FindElement(By.Name(target)).Displayed;
                        break;
                    case "linktext": results.blnFlag = driver.FindElement(By.LinkText(target)).Displayed;
                        break;
                    case "partiallinktext": results.blnFlag = driver.FindElement(By.PartialLinkText(target)).Displayed;
                        break;
                    case "cssselector": results.blnFlag = driver.FindElement(By.CssSelector(target)).Displayed;
                        break;

                    default: break;
                }
                //Changed isElementPresent to isElementDisplayed
                if (results.blnFlag)
                {
                    Thread.Sleep(1000);
                    ele.Click();
                    //Console.WriteLine("Clicking on Element Passed");
                    ReportHandler._ChildTest.Log(LogStatus.Pass, "Clicking on Element Passed :- " + target);
                    // string screenShotPath = CommonMethods.Capture(driver);
                    // ReportHandler._ChildTest.Log(LogStatus.Info, "Snapshot below: " + ReportHandler._ChildTest.AddScreenCapture(screenShotPath));
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Clicking on Element Passed";
                    return results;
                }
                else
                {
                    // throw new Exception();
                    ReportHandler._ChildTest.Log(LogStatus.Fail, "Unable to clicking on Element :- " + target);
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Problem finding the Element " + target;
                    return results;
                }
            }
            catch (Exception e)
            {

                // Console.WriteLine("Clicking on Element Failed");
                ReportHandler._ChildTest.Log(LogStatus.Error, e.Message);
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Clicking on Element Failed " + target;
                results.ErrorMessage1 = e.Message;
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, e.Message, 3);
                return results;
            }

        }

        //public Result click_Xpath(IWebDriver driver, String locator, String target)
        //{
        //    Result results = new Result();
        //    try
        //    {
        //        IWebElement ele = inspect(driver, locator, target,out KeyWords.sLabelName);
        //        objCommonMethods.Action_LookInto_Element(driver, KeyWords.locator_XPath, target);
        //        if (isElementDisplayedByXPath(driver, target))
        //        {

        //            Thread.Sleep(1000);

        //            ele.Click();
        //            //Console.WriteLine("Clicking on Element Passed");
        //            results.Result1 = KeyWords.Result_PASS;
        //            results.ErrorMessage = "Clicking on Element Passed";
        //            return results;
        //        }
        //        else
        //        {
        //            // throw new Exception();
        //            results.Result1 = KeyWords.Result_FAIL;
        //            results.ErrorMessage = "Problem finding the Element " + target;
        //            return results;

        //        }

        //    }
        //    catch (Exception e)
        //    {

        //        // Console.WriteLine("Clicking on Element Failed");
        //        results.Result1 = KeyWords.Result_FAIL;
        //        results.ErrorMessage = "Clicking on Element Failed " + target;
        //        results.ErrorMessage1 = e.Message;
        //        string screenShotPath = CommonMethods.Capture(driver);
        //        ReportHandler._ChildTest.Log(LogStatus.Info, "Snapshot below: " + ReportHandler._ChildTest.AddScreenCapture(screenShotPath));
        //        objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, e.Message, 3);
        //        return results;
        //    }
        //}

        public Result MultipleValuesSelection(IWebDriver driver, String locator, String target1, String text)
        {
            Result results = new Result();
            try
            {
                // results = VerifyElementDisplayAndEnable_XPath(driver, locator, target1);

                IWebElement ele1 = inspect(driver, locator, target1,out KeyWords.sLabelName);

                ele1.Click();
                Thread.Sleep(1000);
                String[] Values = text.Split(',');
                int ExpectedValuesCount = driver.FindElement(By.XPath(target1 + "/div/ul")).FindElements(By.TagName("li")).Count;
                for (int j = 0; j <= Values.Length - 1; j++)
                {

                    for (int i = 1; i <= ExpectedValuesCount; i++)
                    {
                        String Actualvalue = driver.FindElement(By.XPath(target1 + "/div/ul/li[" + i + "]/label")).Text;
                        if (Values[j] == Actualvalue)
                        {
                            driver.FindElement(By.XPath(target1 + "/div/ul/li[" + i + "]/label/input")).Click();
                            break;
                        }
                    }
                }

                results.Result1 = KeyWords.Result_PASS;
                return results;
            }
            catch (Exception e)
            {
                try
                {
                    // results = VerifyElementDisplayAndEnable(driver, locator, target1);

                    IWebElement ele1 = inspect(driver, locator, target1,out KeyWords.sLabelName);
                    ele1.Click();
                    Thread.Sleep(1000);
                    String[] Values = text.Split(',');
                    int ExpectedValuesCount = Values.Length;
                    for (int i = 1; i <= ExpectedValuesCount; i++)
                    {
                        String Actualvalue = driver.FindElement(By.XPath(target1 + "/div/ul/li[" + i + "]")).Text;
                        if (Values.Equals(Actualvalue))
                        {
                            driver.FindElement(By.XPath(target1 + "/div/ul/li[" + i + "]")).Click();
                        }
                    }

                    results.Result1 = KeyWords.Result_PASS;
                    return results;
                }
                catch (Exception ex)
                {
                    // Console.WriteLine("Clicking on Element Failed");
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Clicking on Element Failed " + target1;
                    results.ErrorMessage1 = e.Message;
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, ex.Message, 3);
                    return results;
                }

            }
        }


        /** Method for checking the presence of Element on the Web Page */
        public Boolean isElementPresent(IWebDriver driver, String target)
        {
            try
            {
                if (driver.PageSource.Contains(target))
                {
                    // Console.WriteLine("I am here 1");
                    return true;
                }
                else
                {
                    //  Console.WriteLine("I am here 2");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, ex.Message, 3);
                return false;
            }

        }

        public Result click_CSS(IWebDriver driver, String locator, String target)
        {
            Result results = new Result();
            try
            {




                Thread.Sleep(1000);
                if (driver.FindElement(By.CssSelector(target)).Displayed)
                {
                    driver.FindElement(By.CssSelector(target)).Click();
                    //Console.WriteLine("Clicking on Element Passed");		
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Clicking on Element Passed";
                    return results;
                }
                else
                {
                    // throw new Exception();		
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Problem finding the Element " + target;
                    return results;
                }



            }
            catch (Exception e)
            {

                // Console.WriteLine("Clicking on Element Failed");		
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Clicking on Element Failed " + target;
                results.ErrorMessage1 = e.Message;
                return results;
            }
        }

        /** Method for checking the displayed of Element on the Web Page */
        public Boolean isElementDisplayed(IWebDriver driver, String strTarget)
        {
            try
            {
                if (driver.FindElement(By.Id(strTarget)).Displayed)
                {
                    // Console.WriteLine("I am here 1");

                    return true;
                }
                else if (driver.FindElement(By.XPath(strTarget)).Displayed)
                {
                    return true;
                }
                else
                {
                    //  Console.WriteLine("I am here 2");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, ex.Message, 3);
                return false;
            }

        }

        public Boolean isElementDisplayedXpath(IWebDriver driver, String strTarget)
        {
            try
            {
                if (driver.FindElement(By.XPath(strTarget)).Displayed)
                {
                    // Console.WriteLine("I am here 1");
                    return true;
                }
                else
                {
                    //  Console.WriteLine("I am here 2");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, ex.Message, 3);
                return false;
            }

        }


        /** Method for checking the displayed of Element on the Web Page */
        public Boolean isElementDisplayedByXPath(IWebDriver driver, String strTarget)
        {
            try
            {
                if (driver.FindElement(By.XPath(strTarget)).Displayed)
                {
                    // Console.WriteLine("I am here 1");
                    return true;
                }
                else
                {
                    //  Console.WriteLine("I am here 2");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, ex.Message, 3);
                return false;
            }

        }


        /** Method for checking the Enabled of Element on the Web Page */
        public Boolean isElementEnabled(IWebDriver driver, String strTarget)
        {
            try
            {
                if (driver.FindElement(By.Id(strTarget)).Enabled)
                {
                    // Console.WriteLine("I am here 1");
                    return true;
                }
                else
                {
                    //  Console.WriteLine("I am here 2");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                return false;
            }

        }


        /** Generic Method for sending text in a textbox */
        public Boolean sendText1(IWebDriver driver, String locator, String target, String text)
        {
            try
            {
                IWebElement Text = inspect(driver, locator, target,out KeyWords.sLabelName);
                if (isElementPresent(driver, target))
                {

                    Thread.Sleep(1000);
                    Text.SendKeys(text);
                    Thread.Sleep(1000);
                    // Console.WriteLine("Text Entered successfully");
                    return true;

                }
                else
                {
                    return false;
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                //checkStatus = false;
                // Console.WriteLine("Text not entered");
                return false;

            }

        }

        /** Generic Method for sending text in a textbox */
        public Result sendKeyActions(IWebDriver driver, String locator, String target, string text)
        {
            Result result = new Result();
            try
            {
                IWebElement Text = inspect(driver, locator, target,out KeyWords.sLabelName);
                if (isElementPresent(driver, target))
                {

                    Text.Click();
                    Thread.Sleep(100);

                    Text.SendKeys(text);

                    Thread.Sleep(100);
                    // Console.WriteLine("Text Entered successfully");
                    result.Result1 = KeyWords.Result_PASS;

                    return result;

                }
                else
                {
                    result.Result1 = KeyWords.Result_FAIL;
                    result.ErrorMessage = "Unable to find the isElementPresent " + target;
                    return result;
                    // throw new Exception();                    
                }
            }
            catch (Exception)
            {
                //checkStatus = false;
                result.Result1 = KeyWords.Result_FAIL;
                result.ErrorMessage = "Text not entered " + target;
                // Console.WriteLine("Text not entered");
                return result;

            }

        }

        /** Generic Method for Get text in a textbox */
        public Result GetText(IWebDriver driver, String locator, String target, string AttributeName)
        {
            Result result = new Result();
            try
            {
                string sTemp = "";
                IWebElement Text = inspect(driver, locator, target,out KeyWords.sLabelName);
                if (isElementPresent(driver, target))
                {

                    // Text.Click();
                    Thread.Sleep(1000);
                    sTemp = Text.GetAttribute(AttributeName);

                    // Text.SendKeys(value + "");

                    Thread.Sleep(100);
                    // Console.WriteLine("Text Entered successfully");
                    result.Result1 = KeyWords.Result_PASS;
                    result.ErrorMessage = sTemp;
                    return result;

                }
                else
                {
                    result.Result1 = KeyWords.Result_FAIL;
                    result.ErrorMessage = "Unable to find the isElementPresent " + target;
                    return result;
                    // throw new Exception();                    
                }
            }
            catch (Exception)
            {
                //checkStatus = false;
                result.Result1 = KeyWords.Result_FAIL;
                result.ErrorMessage = "Text not entered " + target;
                // Console.WriteLine("Text not entered");
                return result;

            }

        }


        public Result GetDate(IWebDriver driver, String target)
        {
            Result result = new Result();
            try
            {
                int ColumnNo = 0;
                for (int i = 1; i <= 7; i++)
                {
                    string NextMondayDate = driver.FindElement(By.XPath(target + "[" + i + "]")).GetAttribute("class");
                    if (NextMondayDate == " undefined" || NextMondayDate.Contains("today"))
                    {
                        ColumnNo = i;
                        break;
                    }
                }
                DateTime today = DateTime.Today;
                DateTime nextDay;
                if (ColumnNo == 1)
                {
                    int daysUntilTuesday = ((int)DayOfWeek.Sunday - (int)today.DayOfWeek + 7) % 7;
                    nextDay = today.AddDays(daysUntilTuesday);
                    result.Result1 = nextDay + "";
                }
                else if (ColumnNo == 2)
                {
                    int daysUntilTuesday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7;
                    nextDay = today.AddDays(daysUntilTuesday);
                    result.Result1 = nextDay + "";
                }
                else if (ColumnNo == 3)
                {
                    int daysUntilTuesday = ((int)DayOfWeek.Tuesday - (int)today.DayOfWeek + 7) % 7;
                    nextDay = today.AddDays(daysUntilTuesday);
                    result.Result1 = nextDay + "";
                }
                else if (ColumnNo == 4)
                {
                    int daysUntilTuesday = ((int)DayOfWeek.Wednesday - (int)today.DayOfWeek + 7) % 7;
                    nextDay = today.AddDays(daysUntilTuesday);
                    result.Result1 = nextDay + "";
                }
                else if (ColumnNo == 5)
                {
                    int daysUntilTuesday = ((int)DayOfWeek.Thursday - (int)today.DayOfWeek + 7) % 7;
                    nextDay = today.AddDays(daysUntilTuesday);
                    result.Result1 = nextDay + "";
                }
                else if (ColumnNo == 6)
                {
                    int daysUntilTuesday = ((int)DayOfWeek.Friday - (int)today.DayOfWeek + 7) % 7;
                    nextDay = today.AddDays(daysUntilTuesday);
                    result.Result1 = nextDay + "";
                }
                else if (ColumnNo == 7)
                {
                    int daysUntilTuesday = ((int)DayOfWeek.Saturday - (int)today.DayOfWeek + 7) % 7;
                    nextDay = today.AddDays(daysUntilTuesday);
                    result.Result1 = nextDay + "";
                }

                string[] Date = result.Result1.Split(' ');
                result.Result1 = Date[0];
                return result;
            }
            catch (Exception)
            {
                //checkStatus = false;
                result.Result1 = KeyWords.Result_FAIL;
                result.ErrorMessage = "Text not entered " + target;
                string screenShotPath = CommonMethods.Capture(driver);
                ReportHandler._ChildTest.Log(LogStatus.Info, "Snapshot below: " + ReportHandler._ChildTest.AddScreenCapture(screenShotPath));
                // Console.WriteLine("Text not entered");
                return result;

            }

        }


        /** Generic Method for Get text using XPath */
        public Result GetText_Xpath(IWebDriver driver, String target)
        {
            Result result = new Result();
            try
            {
                string sTemp = "";

                sTemp = driver.FindElement(By.XPath(target)).Text;


                Thread.Sleep(100);
                // Console.WriteLine("Text Entered successfully");
                result.Result1 = KeyWords.Result_PASS;
                result._Var = sTemp;
                return result;


            }
            catch (Exception)
            {
                //checkStatus = false;
                result.Result1 = KeyWords.Result_FAIL;
                result.ErrorMessage = "Text not entered " + target;
                // Console.WriteLine("Text not entered");
                return result;

            }

        }

        /** Generic Method for sending text in a textbox */
        public Result sendText(IWebDriver driver, String locator, String target, String text, Boolean bFlagInt, string sType = "", string sTempVal = "")
        {
            Result result = new Result();

            try
            {
                IWebElement Text = inspect(driver, locator, target, out KeyWords.sLabelName, sType, sTempVal);
                Action_LookInto_Element(driver, KeyWords.locator_ID, target);
                if (isElementPresent(driver, target))
                {
                    Text.Clear();
                    Thread.Sleep(1000);
                    Text.Click();
                    Thread.Sleep(1000);

                    if (bFlagInt)
                    {
                        int value;
                        int.TryParse(text, out value);
                        Text.SendKeys(value + "");
                    }
                    else
                    {
                        Text.SendKeys(text);
                    }
                    Thread.Sleep(100);
                    // Console.WriteLine("Text Entered successfully");
                    ReportHandler._getChildTest().Log(LogStatus.Pass, "Text Entered in <b>" + KeyWords.sLabelName + "<b> : " + text);
                    result.Result1 = KeyWords.Result_PASS;
                    result._Var = KeyWords.sLabelName;
                    return result;

                }
                else if (isElementDisplayedByXPath(driver, target))
                {

                    Text.Clear();
                    Text.Click();
                    Thread.Sleep(100);
                    if (bFlagInt)
                    {
                        int value;
                        int.TryParse(text, out value);
                        Text.SendKeys(value + "");
                    }
                    else
                    {
                        Text.SendKeys(text);
                    }
                    Thread.Sleep(100);
                    // Console.WriteLine("Text Entered successfully");
                    ReportHandler._getChildTest().Log(LogStatus.Pass, "Text Entered successfully " + text + "in " + KeyWords.sLabelName);
                    result.Result1 = KeyWords.Result_PASS;
                    result._Var = KeyWords.sLabelName;
                    return result;
                }
                else
                {
                    ReportHandler._getChildTest().Log(LogStatus.Fail, "Unable to find the isElementPresent " + KeyWords.sLabelName);
                    result.Result1 = KeyWords.Result_FAIL;
                    result.ErrorMessage = "Unable to find the isElementPresent " + KeyWords.sLabelName;
                    result._Var = KeyWords.sLabelName;
                    return result;
                    // throw new Exception();                    
                }

            }
            catch (Exception ex)
            {
                //checkStatus = false;
                ReportHandler._getChildTest().Log(LogStatus.Error, ex.Message);
                result.Result1 = KeyWords.Result_FAIL;
                result.ErrorMessage = "Text not entered " + target;
                string screenShotPath = CommonMethods.Capture(driver);
                ReportHandler._getChildTest().Log(LogStatus.Info, "Snapshot below: " + ReportHandler._getChildTest().AddScreenCapture(screenShotPath));
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, ex.Message, 3);
                // Console.WriteLine("Text not entered");
                return result;

            }

        }

        /** Generic Method for sending text in a textbox */
        public Result sendTextXPath(IWebDriver driver, String locator, String Maintarget, String target, String text, Boolean bFlagInt)
        {
            Result result = new Result();
            try
            {
                IWebElement Text = inspect(driver, locator, target,out KeyWords.sLabelName);
                if (isElementPresent(driver, Maintarget))
                {
                    Text.Clear();
                    Text.Click();
                    Thread.Sleep(100);
                    if (bFlagInt)
                    {
                        int value;
                        int.TryParse(text, out value);
                        Text.SendKeys(value + "");
                    }
                    else
                    {
                        Text.SendKeys(text);
                    }
                    Thread.Sleep(100);
                    // Console.WriteLine("Text Entered successfully");
                    result.Result1 = KeyWords.Result_PASS;

                    return result;

                }
                else
                {
                    result.Result1 = KeyWords.Result_FAIL;
                    result.ErrorMessage = "Unable to find the isElementPresent " + target;
                    return result;
                    // throw new Exception();                    
                }
            }
            catch (Exception)
            {
                //checkStatus = false;
                result.Result1 = KeyWords.Result_FAIL;
                result.ErrorMessage = "Text not entered " + target;
                // Console.WriteLine("Text not entered");
                return result;

            }

        }

        public Result sendTextXPathOnly(IWebDriver driver, String target, String text)
        {
            Result result = new Result();
            try
            {

                driver.FindElement(By.XPath(target)).SendKeys(text);


                result.Result1 = KeyWords.Result_PASS;

                return result;



            }
            catch (Exception ex)
            {
                //checkStatus = false;		
                result.Result1 = KeyWords.Result_FAIL;
                result.ErrorMessage = "Text not entered " + target;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public Result sendText_clr(IWebDriver driver, String locator, String target, String text)
        {
            Result result = new Result();
            try
            {
                IWebElement Text = inspect(driver, locator, target,out KeyWords.sLabelName);
                if (isElementPresent(driver, target))
                {
                    Text.Clear();
                    Text.Click();
                    Thread.Sleep(100);


                    Text.SendKeys(text);

                    Thread.Sleep(100);
                    // Console.WriteLine("Text Entered successfully");
                    result.Result1 = KeyWords.Result_PASS;

                    return result;

                }
                else
                {
                    result.Result1 = KeyWords.Result_FAIL;
                    result.ErrorMessage = "Unable to find the isElementPresent " + target;
                    return result;
                    // throw new Exception();                    
                }
            }
            catch (Exception)
            {
                //checkStatus = false;
                result.Result1 = KeyWords.Result_FAIL;
                result.ErrorMessage = "Text not entered " + target;
                // Console.WriteLine("Text not entered");
                return result;

            }

        }

        public Result sendText_clr_backspace(IWebDriver driver, String locator, String target, String text)
        {
            Result result = new Result();
            try
            {
                IWebElement Text = inspect(driver, locator, target,out KeyWords.sLabelName);
                if (isElementPresent(driver, target))
                {
                    Text.Clear();
                    Text.Click();
                    Thread.Sleep(100);

                    for (int i = 0; i < 4; i++)
                    {

                        objCommonMethods.Action_Button_Backspace(driver);

                    }


                    Text.SendKeys(text);

                    Thread.Sleep(100);
                    // Console.WriteLine("Text Entered successfully");
                    result.Result1 = KeyWords.Result_PASS;

                    return result;

                }
                else
                {
                    result.Result1 = KeyWords.Result_FAIL;
                    result.ErrorMessage = "Unable to find the isElementPresent " + target;
                    return result;
                    // throw new Exception();                    
                }
            }
            catch (Exception)
            {
                //checkStatus = false;
                result.Result1 = KeyWords.Result_FAIL;
                result.ErrorMessage = "Text not entered " + target;
                // Console.WriteLine("Text not entered");
                return result;

            }

        }


        //* Generic Method to get text from a Label /
        public Result GetText_Label(IWebDriver driver, String locator, String target)
        {
            Result result = new Result();
            try
            {
                string sTemp = "";
                IWebElement element = inspect(driver, locator, target,out KeyWords.sLabelName);
                if (isElementPresent(driver, target))
                {

                    Thread.Sleep(1000);
                    sTemp = element.Text;
                    Thread.Sleep(100);
                    // Console.WriteLine("Text fetched successfully");
                    result.Result1 = KeyWords.Result_PASS;
                    result.ErrorMessage = sTemp;
                    return result;

                }
                else
                {
                    result.Result1 = KeyWords.Result_FAIL;
                    result.ErrorMessage = "Unable to find the isElementPresent " + target;
                    return result;
                    // throw new Exception();                    
                }
            }
            catch (Exception)
            {
                //checkStatus = false;
                result.Result1 = KeyWords.Result_FAIL;
                result.ErrorMessage = "Text not found " + target;
                // Console.WriteLine("Text not found");
                return result;

            }

        }

        public Result sendText_XPath(IWebDriver driver, String locator, String target, String targetFind, String text, Boolean bFlagInt)
        {
            Result result = new Result();
            try
            {
                IWebElement Text = inspect(driver, locator, target,out KeyWords.sLabelName);
                if (isElementDisplayedByXPath(driver, target))
                {
                    Text.Clear();
                    Text.Click();
                    Thread.Sleep(100);
                    if (bFlagInt)
                    {
                        int value;
                        int.TryParse(text, out value);
                        Text.SendKeys(value + "");
                    }
                    else
                    {
                        Text.SendKeys(text);
                    }
                    Thread.Sleep(100);
                    // Console.WriteLine("Text Entered successfully");
                    result.Result1 = KeyWords.Result_PASS;

                    return result;

                }
                else
                {
                    result.Result1 = KeyWords.Result_FAIL;
                    result.ErrorMessage = "Unable to find the isElementPresent " + target;
                    return result;
                    // throw new Exception();                    
                }
            }
            catch (Exception)
            {
                //checkStatus = false;
                result.Result1 = KeyWords.Result_FAIL;
                result.ErrorMessage = "Text not entered " + target;
                // Console.WriteLine("Text not entered");
                return result;

            }

        }


        public Result Generate_Report_Excel_PDF(IWebDriver driver, string reporttype)
        {
            var results = new Result();
            //driver.SwitchTo().Frame(0);
            try
            {
                driver.FindElement(By.XPath("//*[@id='rptvw_ctl05_ctl04_ctl00_ButtonImgDown']")).Click();
                string xpath_location = "//*[@id='rptvw_ctl05_ctl04_ctl00_Menu']/div";
                int count = driver.FindElements(By.XPath(xpath_location)).Count;
                for (int i = 1; i < count; i++)
                {
                    if (driver.FindElement(By.XPath(xpath_location + "[" + i + "]/a")).GetAttribute("title").ToUpper() == reporttype.ToUpper())
                    {
                        driver.FindElement(By.XPath(xpath_location + "[" + i + "]/a")).Click();
                    }
                }
            }
            catch (Exception ex)
            {

                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem, failed Generate_Report_Excel_PDF Method";
                results.ErrorMessage1 = ex.Message;
                return results;

            }
            //driver.SwitchTo().DefaultContent();
            //Thread.Sleep(10000);
            results.Result1 = KeyWords.Result_PASS;
            return results;

        }

        //public Result GetLabelfromGrid(IWebDriver driver, string xpath_gridlablelocation, string reportname)
        //{

        //    var results = new Result();
        //    string[] reportnames = { "Client User by Function Group", "Rights List", "Supplier User Details", "User by Right", "Supplier Information", "Approved Expense", "Activity Report", "Status Report", "Business Analysis", "Executive Dashboard" };
        //    try
        //    {
        //        if (reportnames.Contains(reportname))
        //        {
        //            try
        //            {
        //                results.ErrorMessage = driver.FindElement(By.XPath(xpath_gridlablelocation)).Text.Trim();
        //            }
        //            catch (Exception ex)
        //            {
        //                results.Result1 = KeyWords.Result_FAIL;
        //                results.ErrorMessage = "Problem in fetching the label from grid";
        //                results.ErrorMessage1 = ex.Message;
        //            }

        //            results.Result1 = KeyWords.Result_PASS;
        //            return results;
        //        }
        //        else
        //        {
        //            try
        //            {
        //                //driver.SwitchTo().Frame(0);
        //                IWebElement gridlabel = driver.FindElement(By.XPath(xpath_gridlablelocation));
        //                string stempvariable = null;
        //                //int count = gridlabel.FindElements(By.TagName("span")).Count;
        //                int count = driver.FindElements(By.XPath(xpath_gridlablelocation + "/span")).Count;
        //                //Console.WriteLine("The span tag count is: " + count);
        //                for (int i = 1; i <= count; i++)
        //                {
        //                    stempvariable = stempvariable + driver.FindElement(By.XPath(xpath_gridlablelocation + "/span[" + i + "]")).Text;

        //                }
        //                //driver.SwitchTo().DefaultContent();
        //                results.ErrorMessage = stempvariable.Trim();
        //            }
        //            catch (Exception ex)
        //            {
        //                results.Result1 = KeyWords.Result_FAIL;
        //                results.ErrorMessage = "Problem in fetching the label from grid";
        //                results.ErrorMessage1 = ex.Message;
        //            }

        //            results.Result1 = KeyWords.Result_PASS;
        //            return results;
        //        }

        //    }

        //    catch (Exception ex)
        //    {
        //        results.Result1 = KeyWords.Result_FAIL;
        //        results.ErrorMessage = "Problem occured while fetching the lable from the grid";
        //        results.ErrorMessage1 = ex.Message;
        //    }

        //    return results;
        //}

        public Result select_RequisitionType(IWebDriver driver, String strRequisitionType)
        {
            Result results = new Result();
            try
            {
                driver.FindElement(By.XPath("//*[@class='instedEM' and text()='" + strRequisitionType + "']")).Click();
                results.Result1 = KeyWords.Result_PASS;
            }
            catch (Exception e)
            {
                ReportHandler._ChildTest.Log(LogStatus.Error, "Selecting Requisition Type failed :- " + strRequisitionType);
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Selecting Requisition Type failed " + strRequisitionType;
                string screenShotPath = CommonMethods.Capture(driver);
                ReportHandler._ChildTest.Log(LogStatus.Info, "Snapshot below: " + ReportHandler._ChildTest.AddScreenCapture(screenShotPath));
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, e.Message, 3);
                return results;
            }
            return results;
        }

        public Result select_RequisitionType1(IWebDriver driver, String locator, String strRequisitionType)
        {
            Result results = new Result();
            Boolean bFlag = false;
            try
            {

                // ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@id='ajCallContainer']/div[1]/table/tbody/tr/td[1]/ul/li"));
                ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath(locator));

                List<IWebElement> elements = lis_ClientNames.ToList();

                for (int i = 0; i <= elements.Count; i++)
                {

                    if (elements[i].Text.Trim() == strRequisitionType.Trim())
                    {
                        bFlag = true;
                        elements[i].Click();

                    }
                    if (bFlag)
                    {
                        break;
                    }

                }
                if (bFlag)
                {
                    // Console.WriteLine("Selecting Requisition Type");
                    ReportHandler._ChildTest.Log(LogStatus.Pass, "Selecting Requisition Type " + strRequisitionType);
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Selecting Requisition Type";
                    return results;
                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given Requisition Type name not found");
                    ReportHandler._ChildTest.Log(LogStatus.Fail, "The given Requisition Type name not found :- " + strRequisitionType);
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given Requisition Type name not found " + strRequisitionType;
                    return results;
                }


            }
            catch (Exception)
            {
                //checkStatus = false;
                // Console.WriteLine("Selecting Requisition Type failed");
                ReportHandler._ChildTest.Log(LogStatus.Error, "Selecting Requisition Type failed :- " + strRequisitionType);
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Selecting Requisition Type failed " + strRequisitionType;
                //results.ErrorMessage1 = e.InnerException;

                return results;

            }
        }

        public Result select_client(IWebDriver driver, String locator, String target, String strClientName)
        {
            Result results = new Result();
            Boolean bFlag = false;
            try
            {
                // // Console.WriteLine("//*[@" + locator + "='" + target + "']//li");
                ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']//li"));

                List<IWebElement> elements = lis_ClientNames.ToList();

                for (int i = 0; i <= elements.Count; i++)
                {
                    //if (strClientName.ToLower().Trim() == "dcr")
                    //{
                    //    elements[i].Text.ToLower().Trim().EndsWith
                    //}

                    if (elements[i].Text.ToLower().Trim().EndsWith(strClientName.ToLower().Trim()))
                    {
                        bFlag = true;
                        elements[i].Click();
                    }
                    if (bFlag)
                    {
                        break;
                    }
                }
                if (bFlag)
                {
                    // Console.WriteLine("Selecting from a drop down client");
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Selecting from a drop down client";
                    return results;
                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given client name not found");
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given client name not found " + strClientName;
                    return results;
                }
            }
            catch (Exception)
            {
                //checkStatus = false;
                // Console.WriteLine("Selecting from a drop down failed");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Selecting from a drop down failed " + strClientName;
                return results;
            }
        }


        public Result Client_Change_Click_NewApp(IWebDriver driver, String locator, String target, String strClientName)
        {
            var results = new Result();
            Boolean bClientFind = false;
            try
            {
                try
                {
                    //driver.FindElement(By.XPath(KeyWords.XPath_ClientDropDown)).Click();
                    driver.FindElement(By.XPath("//a[@data-toggle='dropdown']/span[@class='caret']")).Click();

                    //Wait till the dropdown is loaded

                    //select value from dropdown
                    String sMenuType = driver.FindElement(By.XPath("//ul[@class='logoDropdown']//li/a[@data-toggle='dropdown']")).GetAttribute("data-menu");
                    if (sMenuType.ToLower().Contains("client".ToLower()))
                    {
                        driver.FindElement(By.XPath("//*[@id='clientMenu']//a[contains(text(),'" + strClientName + "')]")).Click();

                    }
                    else if (sMenuType.ToLower().Contains("supplier".ToLower()))
                    {
                        driver.FindElement(By.XPath("//*[@id='supplierMenu']//a[contains(text(),'" + strClientName + "')]")).Click();
                    }
                    bClientFind = true;
                }
                catch (Exception e)
                {
                    String sClientName = driver.FindElement(By.XPath("//li//div[@class='clientName']")).Text;

                    if (sClientName.ToLower().Contains(strClientName.ToLower()))

                        bClientFind = true;
                    else
                        bClientFind = false;

                }
                Thread.Sleep(2000);

                if (!bClientFind)
                {
                    ReportHandler._ChildTest.Log(LogStatus.Fail, "Unable to find the given Client name " + strClientName);
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Unable to find the given Client name " + strClientName;

                }
                else
                {
                    ReportHandler._ChildTest.Log(LogStatus.Pass, "Changed the client Name to " + strClientName);
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Changed the client Name to " + strClientName;
                }
            }
            catch (Exception exClientChange)
            {
                ReportHandler._ChildTest.Log(LogStatus.Fail, "Problem failed Client_Change_Click_NewApp Method");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed Client_Change_Click_NewApp Method";
                results.ErrorMessage1 = exClientChange.Message;
                return results;
            }
            //results.Result1 = KeyWords.Result_PASS;
            return results;
        }



        public Result Client_Change_Click_NewApp_Discover(IWebDriver driver, String locator, String target, String strClientName)
        {
            var results = new Result();
            Boolean bClientFind = false;
            try
            {

                driver.FindElement(By.XPath(KeyWords.XPath_supplierMenu_ClientDropDown)).Click();

                Thread.Sleep(2000);
                ICollection<IWebElement> lis_Menu_Names = driver.FindElements(By.XPath(KeyWords.XPath_supplierMenu_Discover));
                List<IWebElement> elements = lis_Menu_Names.ToList();
                for (int i = 0; i < elements.Count; i++)
                {
                    string strMenuName = elements[i].Text;
                    if (elements[i].Text.ToLower().Trim().EndsWith(strClientName.ToLower().Trim()))
                    {
                        bClientFind = true;
                        elements[i].Click();
                        Thread.Sleep(5000);
                    }
                    if (bClientFind)
                    {
                        break;
                    }
                }
                if (!bClientFind)
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Unable to find the given Client name " + strClientName;
                    return results;
                }
            }
            catch (Exception exClientChange)
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed Client_Change_Click_NewApp_Discover Method";
                results.ErrorMessage1 = exClientChange.Message;
                return results;
            }
            results.Result1 = KeyWords.Result_PASS;
            return results;
        }

        public Result SupplierClient_Change_Click_NewApp(IWebDriver driver, String locator, String target, String strClientName)
        {
            var results = new Result();
            Boolean bClientFind = false;
            try
            {
                try
                {
                    driver.FindElement(By.XPath(KeyWords.XPath_supplierMenu_ClientDropDown)).Click();
                }
                catch
                {
                    driver.FindElement(By.XPath(KeyWords.XPath_supplierMenu_ClientDropDown)).Click();
                }

                Thread.Sleep(2000);
                try
                {
                    //Code to handle 'Sallie Mae' client selection
                    if (strClientName.ToLower().ToString() == "sallie mae")
                    {
                        driver.FindElement(By.XPath(KeyWords.XPath_supplierMenu1)).SendKeys("Workspend-" + strClientName);
                    }
                    else
                    {
                        driver.FindElement(By.XPath(KeyWords.XPath_supplierMenu1)).Clear();

                        Thread.Sleep(1000);

                        driver.FindElement(By.XPath(KeyWords.XPath_supplierMenu1)).SendKeys(strClientName);
                    }
                    Thread.Sleep(5000);

                }
                catch
                {
                    try
                    {
                        driver.FindElement(By.XPath(KeyWords.XPath_supplierMenu_ClientDropDown)).Click();
                    }
                    catch
                    {
                        //
                    }
                }
                Thread.Sleep(2000);
                Boolean bClientMenu = false;
                for (int z = 1; z <= 100; z++)
                {

                    String StrTempXPath_SupplierMenu = KeyWords.XPath_supplierMenu + "[" + z + "]";
                    try
                    {
                        bClientMenu = driver.FindElement(By.XPath(StrTempXPath_SupplierMenu)).Displayed;
                    }
                    catch
                    {
                        bClientMenu = false;
                    }
                    if (bClientMenu)
                    {
                        KeyWords.XPath_supplierMenu = StrTempXPath_SupplierMenu;
                        break;
                    }
                }
                ICollection<IWebElement> lis_Menu_Names = driver.FindElements(By.XPath(KeyWords.XPath_supplierMenu));
                List<IWebElement> elements = lis_Menu_Names.ToList();
                for (int i = 0; i < elements.Count; i++)
                {
                    string strMenuName = elements[i].Text;
                    if (elements[i].Text.ToLower().Trim().EndsWith(strClientName.ToLower().Trim()))
                    {
                        bClientFind = true;
                        elements[i].Click();
                        Thread.Sleep(5000);
                    }
                    if (bClientFind)
                    {
                        break;
                    }
                }
                if (!bClientFind)
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Unable to find the given Client name " + strClientName;
                    return results;
                }
            }
            catch (Exception exClientChange)
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed Client_Change_Click_NewApp Method";
                results.ErrorMessage1 = exClientChange.Message;
                return results;
            }
            results.Result1 = KeyWords.Result_PASS;
            return results;
        }

        public Result Action_MoveElement(IWebDriver driver, String target)
        {
            var results = new Result();
            try
            {
                Actions actions1 = new Actions(driver);
                IWebElement element = driver.FindElement(By.Id(target));
                actions1.MoveToElement(element).Build().Perform();
                results.Result1 = KeyWords.Result_PASS;
                return results;
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                results.Result1 = KeyWords.Result_FAIL;
                return results;
            }
        }


        public Result Main_Sub_Menu_Click_NewApp(IWebDriver driver, String locator, String target, String strMainMenuName, String strSubMenuName)
        {
            var results = new Result();

            try
            {

                // This is working method
                Actions action = new Actions(driver);

                IWebElement we = driver.FindElement(By.XPath(KeyWords.XPath_MainMenu));

                action.MoveToElement(we).Build().Perform();


                Thread.Sleep(2000);

                IWebElement we1 = driver.FindElement(By.CssSelector(KeyWords.XPath_MainMenu_Open));
                action.MoveToElement(we1).Build().Perform();



                driver.FindElement(By.XPath("//a[@class='gn-icon gn-parent-menu'][text()='" + strMainMenuName + "']")).Click();


                objCommonMethods.Action_Page_Down(driver);
                Thread.Sleep(2000);

                driver.FindElement(By.XPath("//a[@class='gn-icon gn-icon-illustrator'][contains(text(),'" + "  " + strSubMenuName + "')]")).Click();

            }
            catch (Exception ex)
            {
                ReportHandler._ChildTest.Log(LogStatus.Fail, "Problem failed Main_Sub_Menu_Click_NewApp Method");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed Main_Sub_Menu_Click_NewApp Method";
                string screenShotPath = CommonMethods.Capture(driver);
                ReportHandler._ChildTest.Log(LogStatus.Info, "Snapshot below: " + ReportHandler._ChildTest.AddScreenCapture(screenShotPath));
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, ex.Message, 3);
                results.ErrorMessage1 = ex.Message;
                return results;


            }
            ReportHandler._ChildTest.Log(LogStatus.Pass, "Clicked on Main Menu and Sub-Menu :- " + strMainMenuName + " and " + strSubMenuName);

            results.Result1 = KeyWords.Result_PASS;
            return results;
        }

        public Result Main_Menu_Click_NewApp(IWebDriver driver, String locator, String target, String strMainMenuName)
        {
            var results = new Result();

            Boolean bMainMenuFind = false;

            try
            {
                Actions action = new Actions(driver);
                //IWebElement we = driver.FindElement(By.XPath("//ul[@id='gn-menu']/li/a"));
                IWebElement we = driver.FindElement(By.XPath(KeyWords.XPath_MainMenu));
                action.MoveToElement(we).Build().Perform();
                Thread.Sleep(2000);
                //  IWebElement we1 = driver.FindElement(By.XPath("//*[@id='gn-menu']/li/nav/div/ul/li/span"));
                IWebElement we1 = driver.FindElement(By.XPath(KeyWords.XPath_MainMenu_Open));
                action.MoveToElement(we1).Build().Perform();
                Thread.Sleep(2000);
                //  ICollection<IWebElement> lis_Menu_Names = driver.FindElements(By.XPath("//*[@id='gn-menu']/li[1]/nav/div/ul/li"));
                ICollection<IWebElement> lis_Menu_Names = driver.FindElements(By.XPath(KeyWords.XPath_MainMenu_OpenReadNames));
                //   ICollection<IWebElement> lis_Menu_Names = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']//li"));
                List<IWebElement> elements = lis_Menu_Names.ToList();

                for (int i = 0; i < elements.Count; i++)
                {
                    string strMenuName = elements[i].Text;
                    // strMainMenuLink = "home";
                    if (strMenuName.ToLower().Equals(strMainMenuName.ToLower()))
                    {
                        elements[i].FindElement(By.XPath("./a")).Click();
                        bMainMenuFind = true;
                        // driver.FindElement(By.XPath("//*[@id='gn-menu']/li[1]/nav/div/ul/li[" + (i + 1) + "]/a")).Click();
                        break;
                    }
                    Thread.Sleep(1000);
                }

                if (!bMainMenuFind)
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Unable to find the given Main Menu name " + strMainMenuName;
                    return results;
                }


            }
            catch (Exception)
            {
                //checkStatus = false;
                // Console.WriteLine("Problem failed Menu_Menu_Click Method");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed Main_Sub_Menu_Click_NewApp Method";
                return results;


            }
            results.Result1 = KeyWords.Result_PASS;
            return results;
        }

        public Result Main_Menu_Click(IWebDriver driver, String locator, String target, String strMainMenuName)
        {
            var results = new Result();

            Boolean bFlag = false;
            try
            {
                //// Console.WriteLine("//*[@" + locator + "='" + target + "']//li");
                ICollection<IWebElement> lis_Menu_Names = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']//li"));
                List<IWebElement> elements = lis_Menu_Names.ToList();
                for (int i = 0; i <= elements.Count; i++)
                {
                    // // Console.WriteLine(elements[i].FindElement(By.XPath("./span")).Text);
                    string strMenuName = elements[i].FindElement(By.XPath("./span")).Text;
                    int x = 0;
                    try
                    {
                        x = strMenuName.LastIndexOf(" ");
                    }
                    catch (Exception)
                    {
                        // no space in menu names
                    }
                    if (x > 0)
                    {
                        strMenuName = strMenuName.Substring(0, x);
                    }
                    // Console.WriteLine("Compare here");
                    // Console.WriteLine(strMenuName, strMainMenuName);
                    if (strMenuName.ToLower().Equals(strMainMenuName.ToLower()))
                    {
                        elements[i].FindElement(By.XPath("./span")).Click();
                        Thread.Sleep(1000);
                        bFlag = true;
                        break;
                    }

                    if (bFlag)
                    {
                        break;
                    }

                }
                if (bFlag)
                {
                    // Console.WriteLine("Click on the Main menu name " + strMainMenuName + " successfully");
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Click on the Main menu name " + strMainMenuName + " successfully";
                    return results;
                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given Main menu name " + strMainMenuName + " not found");
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given Main menu name " + strMainMenuName + " not found";
                    return results;
                }


            }
            catch (Exception)
            {
                //checkStatus = false;
                // Console.WriteLine("Problem failed Menu_Menu_Click Method");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed Main_Menu_Click Method";
                return results;


            }

        }

        public Result Sub_Menu_Click(IWebDriver driver, String locator, String target, String strSubMenuName)
        {
            var results = new Result();

            Boolean bFlag = false;
            try
            {
                //// Console.WriteLine("//*[@" + locator + "='" + target + "']//li");
                ICollection<IWebElement> lis_Menu_Names = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']//li"));
                List<IWebElement> elements = lis_Menu_Names.ToList();
                for (int i = 0; i <= elements.Count; i++)
                {
                    Console.WriteLine(elements[i].Text);
                    string strMenuName = elements[i].Text;

                    // // Console.WriteLine("Compare here");
                    Console.WriteLine(strMenuName);
                    Console.WriteLine(strSubMenuName);
                    if (strMenuName.ToLower().Equals(strSubMenuName.ToLower()))
                    {
                        elements[i].Click();
                        Thread.Sleep(1000);
                        bFlag = true;
                        break;
                    }

                    if (bFlag)
                    {
                        break;
                    }

                }
                if (bFlag)
                {
                    // Console.WriteLine("Click on the Sub menu name " + strSubMenuName + " successfully");
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Click on the Sub menu name " + strSubMenuName + " successfully";
                    return results;
                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given Sub menu name " + strSubMenuName + " not found");
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given Sub menu name " + strSubMenuName + " not found";
                    return results;
                }


            }
            catch (Exception)
            {
                //checkStatus = false;
                // Console.WriteLine("Problem failed Sub_Menu_Click Method");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed Sub_Menu_Click Method";
                return results;


            }

        }

        public Result list_Menu_Click(IWebDriver driver, String locator, String target, String strSubMenuName, String strSubLevel)
        {
            var results = new Result();

            Boolean bFlag = false;
            try
            {
                //// Console.WriteLine("//*[@" + locator + "='" + target + "']//li");
                ICollection<IWebElement> lis_Menu_Names = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']//li"));
                List<IWebElement> elements = lis_Menu_Names.ToList();
                for (int i = 0; i < elements.Count; i++)
                {
                    // // Console.WriteLine(elements[i].FindElement(By.XPath("./span")).Text);
                    string strMenuName = "";
                    if (strSubLevel == "")
                        strMenuName = elements[i].Text;
                    else
                        strMenuName = elements[i].FindElement(By.XPath(strSubLevel)).Text;

                    //strMenuName = elements[i].FindElement(By.XPath("./label")).Text;
                    // // Console.WriteLine("Compare here");
                    // // Console.WriteLine(strMenuName, strMainMenuName);
                    if (strMenuName.ToLower().Equals(strSubMenuName.ToLower()))
                    {
                        if (strSubLevel == "")
                            elements[i].Click();
                        else
                            elements[i].FindElement(By.XPath(strSubLevel)).Click();

                        Thread.Sleep(1000);
                        bFlag = true;
                        break;
                    }

                    if (bFlag)
                    {
                        break;
                    }

                }
                if (bFlag)
                {
                    // Console.WriteLine("Click on the Link menu name " + strSubMenuName + " successfully");
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Click on the Link menu name " + strSubMenuName + " successfully";
                    return results;
                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given Link menu name " + strSubMenuName + " not found");
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given Link menu name " + strSubMenuName + " not found";
                    return results;
                }


            }
            catch (Exception)
            {
                //checkStatus = false;
                // Console.WriteLine("Problem failed list_Menu_Click Method");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed list_Menu_Click Method";
                return results;


            }

        }

        public Result list_Menu_Click_Img(IWebDriver driver, String locator, String target, String strSubMenuName, String strSubLevel)
        {
            var results = new Result();

            Boolean bFlag = false;
            try
            {
                //// Console.WriteLine("//*[@" + locator + "='" + target + "']//li");
                ICollection<IWebElement> lis_Menu_Names = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']//li"));
                List<IWebElement> elements = lis_Menu_Names.ToList();
                for (int i = 0; i <= elements.Count; i++)
                {
                    // // Console.WriteLine(elements[i].FindElement(By.XPath("./span")).Text);
                    string strMenuName = "";
                    //if (strSubLevel == "")
                    strMenuName = elements[i].Text;
                    //else
                    //    strMenuName = elements[i].FindElement(By.XPath(strSubLevel)).Text;

                    //strMenuName = elements[i].FindElement(By.XPath("./label")).Text;
                    // // Console.WriteLine("Compare here");
                    // // Console.WriteLine(strMenuName, strMainMenuName);
                    if (strMenuName.ToLower().Equals(strSubMenuName.ToLower()))
                    {
                        if (strSubLevel == "")
                            elements[i].Click();
                        else
                            elements[i].FindElement(By.XPath(strSubLevel)).Click();

                        Thread.Sleep(1000);
                        bFlag = true;
                        break;
                    }

                    if (bFlag)
                    {
                        break;
                    }

                }
                if (bFlag)
                {
                    // Console.WriteLine("Click on the Link menu name " + strSubMenuName + " successfully");
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Click on the Link menu name " + strSubMenuName + " successfully";
                    return results;
                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given Link menu name " + strSubMenuName + " not found");
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given Link menu name " + strSubMenuName + " not found";
                    return results;
                }


            }
            catch (Exception)
            {
                //checkStatus = false;
                // Console.WriteLine("Problem failed list_Menu_Click Method");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed list_Menu_Click Method";
                return results;


            }

        }


        public Result list_Menu_With_ID_Click(IWebDriver driver, String locator, String target, String strSubMenuName, String strSubLevel)
        {
            var results = new Result();

            Boolean bFlag = false;
            try
            {
                //// Console.WriteLine("//*[@" + locator + "='" + target + "']//li");
                ICollection<IWebElement> lis_Menu_Names = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']//li"));
                List<IWebElement> elements = lis_Menu_Names.ToList();
                for (int i = 0; i < elements.Count; i++)
                {
                    // // Console.WriteLine(elements[i].FindElement(By.XPath("./span")).Text);
                    //  string strID = elements[i].GetAttribute("id").ToString();
                    string strMenuName = "";
                    if (strSubLevel == "")
                        strMenuName = elements[i].Text;
                    else
                        strMenuName = elements[i].FindElement(By.XPath(strSubLevel)).Text;


                    if (strMenuName.ToLower().Equals(strSubMenuName.ToLower()))
                    {
                        i = i + 1;
                        driver.FindElement(By.XPath("//*[@" + locator + "='" + target + "']//li[" + i + "]/a")).Click();

                        //driver.FindElement(By.XPath(elements[i].FindElement(By.)).Click();

                        Thread.Sleep(1000);
                        bFlag = true;
                        break;
                    }

                    if (bFlag)
                    {
                        break;
                    }

                }
                if (bFlag)
                {
                    // Console.WriteLine("Click on the Link menu name " + strSubMenuName + " successfully");
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Click on the Link menu name " + strSubMenuName + " successfully";
                    return results;
                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given Link menu name " + strSubMenuName + " not found");
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given Link menu name " + strSubMenuName + " not found";
                    return results;
                }


            }
            catch (Exception)
            {
                //checkStatus = false;
                // Console.WriteLine("Problem failed list_Menu_Click Method");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed list_Menu_Click Method";
                return results;


            }

        }

        public Result list_Tab_Name_Click(IWebDriver driver, String locator, String target, String strSubMenuName, String strSubLevel)
        {
            var results = new Result();

            Boolean bFlag = false;
            try
            {
                //// Console.WriteLine("//*[@" + locator + "='" + target + "']//li");
                ICollection<IWebElement> lis_Menu_Names = driver.FindElements(By.XPath(target));
                List<IWebElement> elements = lis_Menu_Names.ToList();
                for (int i = 0; i < elements.Count; i++)
                {
                    // // Console.WriteLine(elements[i].FindElement(By.XPath("./span")).Text);
                    //  string strID = elements[i].GetAttribute("id").ToString();
                    string strMenuName = "";
                    if (strSubLevel == "")
                        strMenuName = elements[i].Text;
                    else
                        strMenuName = elements[i].FindElement(By.XPath(strSubLevel)).Text;


                    if (strMenuName.ToLower().Equals(strSubMenuName.ToLower()))
                    {
                        i = i + 1;
                        driver.FindElement(By.XPath(target + "[" + i + "]/a")).Click();

                        //driver.FindElement(By.XPath(elements[i].FindElement(By.)).Click();

                        Thread.Sleep(1000);
                        bFlag = true;
                        break;
                    }

                    if (bFlag)
                    {
                        break;
                    }

                }
                if (bFlag)
                {
                    // Console.WriteLine("Click on the Link menu name " + strSubMenuName + " successfully");
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Click on the Link menu name " + strSubMenuName + " successfully";
                    return results;
                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given Link menu name " + strSubMenuName + " not found");
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given Link menu name " + strSubMenuName + " not found";
                    return results;
                }


            }
            catch (Exception)
            {
                //checkStatus = false;
                // Console.WriteLine("Problem failed list_Menu_Click Method");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed list_Menu_Click Method";
                return results;


            }

        }


        public Result list_Menu_Name_Exist(IWebDriver driver, String locator, String target, String strSubMenuName, String strSubLevel)
        {
            var results = new Result();

            Boolean bFlag = false;
            try
            {
                //// Console.WriteLine("//*[@" + locator + "='" + target + "']//li");
                ICollection<IWebElement> lis_Menu_Names = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']//li"));
                List<IWebElement> elements = lis_Menu_Names.ToList();
                for (int i = 0; i < elements.Count; i++)
                {
                    // // Console.WriteLine(elements[i].FindElement(By.XPath("./span")).Text);
                    string strMenuName = "";
                    if (strSubLevel == "")
                        strMenuName = elements[i].Text;
                    else
                        strMenuName = elements[i].FindElement(By.XPath(strSubLevel)).Text;

                    //strMenuName = elements[i].FindElement(By.XPath("./label")).Text;
                    // // Console.WriteLine("Compare here");
                    // // Console.WriteLine(strMenuName, strMainMenuName);
                    if (strMenuName.ToLower().Equals(strSubMenuName.ToLower()))
                    {

                        bFlag = true;
                        break;
                    }



                }
                if (bFlag)
                {
                    // Console.WriteLine("Click on the Link menu name " + strSubMenuName + " successfully");
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "The given Link menu name " + strSubMenuName + " Exists";
                    return results;
                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given Link menu name " + strSubMenuName + " not found");
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given Link menu name " + strSubMenuName + " not found";
                    return results;
                }


            }
            catch (Exception)
            {
                //checkStatus = false;
                // Console.WriteLine("Problem failed list_Menu_Click Method");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed list_Menu_Click Method";
                return results;


            }

        }

        public Result list_Menu_Click_TimeSheet(IWebDriver driver, String locator, String target, String strSubMenuName, String strSubLevel)
        {
            var results = new Result();

            Boolean bFlag = false;
            try
            {
                //// Console.WriteLine("//*[@" + locator + "='" + target + "']//li");
                ICollection<IWebElement> lis_Menu_Names = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']//li"));
                List<IWebElement> elements = lis_Menu_Names.ToList();
                for (int i = 0; i < elements.Count; i++)
                {
                    // // Console.WriteLine(elements[i].FindElement(By.XPath("./span")).Text);
                    string strMenuName = "";
                    if (strSubLevel == "")
                        strMenuName = elements[i].Text;
                    else
                        strMenuName = elements[i].FindElement(By.XPath(strSubLevel)).Text;

                    //strMenuName = elements[i].FindElement(By.XPath("./label")).Text;
                    // // Console.WriteLine("Compare here");
                    // // Console.WriteLine(strMenuName, strMainMenuName);
                    if (strMenuName.ToLower().Contains(strSubMenuName.ToLower()))
                    {
                        if (strSubLevel == "")
                        {
                            ICollection<IWebElement> lis_Menu_Names2 = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']//li[" + (i + 1) + "]"));
                            List<IWebElement> elements2 = lis_Menu_Names2.ToList();


                            string strTestid = elements2[0].GetAttribute("id");

                            driver.FindElement(By.Id(strTestid)).Click();
                            // driver.FindElement(By.Id("DefaultContent_lnkAwaitingApprovalTImeSheets")).Click();

                            Thread.Sleep(10000);

                        }
                        else
                        {
                            elements[i].FindElement(By.XPath(strSubLevel)).Click();
                        }
                        Thread.Sleep(1000);
                        bFlag = true;
                        break;
                    }

                    if (bFlag)
                    {
                        break;
                    }

                }
                if (bFlag)
                {
                    // Console.WriteLine("Click on the Link menu name " + strSubMenuName + " successfully");
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Click on the Link menu name " + strSubMenuName + " successfully";
                    return results;
                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given Link menu name " + strSubMenuName + " not found");
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given Link menu name " + strSubMenuName + " not found";
                    return results;
                }


            }
            catch (Exception)
            {
                //checkStatus = false;
                // Console.WriteLine("Problem failed list_Menu_Click Method");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed list_Menu_Click Method";
                return results;


            }

        }


        /**
     * Generic Method for selecting an option from drop down list Parameters :
     * WebElement DropDown :option to be selected    
     *	
     */
        public Result select(IWebDriver driver, String locator, String target, String value, string sType="", string sTempVal="")
        {

            var results = new Result();
            try
            {
                IWebElement element = inspect(driver, locator, target, out KeyWords.sLabelName, sType, sTempVal);
                Action_LookInto_Element(driver, locator, target);
                new SelectElement(element).SelectByText(value);

                // Console.WriteLine("Selecting from a drop down " + value + "passed");
                ReportHandler._ChildTest.Log(LogStatus.Pass, "Selecting from a drop down " + value + " passed");
                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = "Selecting from a drop down " + value + " passed";
                return results;
            }
            catch (Exception e)
            {

                // Console.WriteLine("Selecting from a drop down " + value + " failed");
                ReportHandler._ChildTest.Log(LogStatus.Error, "Selecting from a drop down " + value + " failed");
                string screenShotPath = CommonMethods.Capture(driver);
                ReportHandler._ChildTest.Log(LogStatus.Info, "Snapshot below: " + ReportHandler._ChildTest.AddScreenCapture(screenShotPath));
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, e.Message, 3);
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Selecting from a drop down " + value + " failed";
                return results;


            }
        }

        public Result selectByIndex(IWebDriver driver, String locator, String target, int index)
        {

            var results = new Result();
            try
            {
                IWebElement element = inspect(driver, locator, target,out KeyWords.sLabelName);
                Action_LookInto_Element(driver, locator, target);
                new SelectElement(element).SelectByIndex(index);

                // Console.WriteLine("Selecting from a drop down " + index + "passed");
                ReportHandler._ChildTest.Log(LogStatus.Pass, "Selecting from a drop down selectByIndex" + index + " passed");
                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = "Selecting from a drop down " + index + " passed";
                return results;
            }
            catch (Exception Ex)
            {

                // Console.WriteLine("Selecting from a drop down " + index + " failed");
                ReportHandler._ChildTest.Log(LogStatus.Error, Ex.Message);
                ReportHandler._ChildTest.Log(LogStatus.Error, "Selecting from a drop down " + index + " failed");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Selecting from a drop down " + index + " failed";
                return results;


            }
        }



        public Result selectInDropdownByValue(IWebDriver driver, String locator, String target, String val)
        {
            var results = new Result();
            try
            {
                IWebElement element = inspect(driver, locator, target,out KeyWords.sLabelName);
                SelectElement dropDown = new SelectElement(element);
                int k = dropDown.Options.Count;
                //List<WebElement> theseOptions = dropDown.Options;
                Boolean bFlag = false;
                for (int i = 0; i <= k; i++)
                {
                    string strtemp = dropDown.Options[i].Text.ToLower().Trim();

                    if (strtemp.Equals(val.ToLower()))
                    {
                        dropDown.SelectByIndex(i);
                        bFlag = true;
                    }
                    if (bFlag)
                        break;
                }
                if (bFlag)
                {
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Selecting from a drop down " + val + " passed";
                    return results;
                }
            }
            catch
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Some problem with this selectInDropdownByValue function";
                return results;
            }
            results.Result1 = KeyWords.Result_FAIL;
            results.ErrorMessage = "Selecting from a drop down " + val + " failed";
            return results;

        }
        //public Result selectDynamicDropdownByValue(IWebDriver driver, String locator, String target)
        //{
        //    var results = new Result();
        //    try
        //    {
        //        IWebElement element = inspect(driver, locator, target,out KeyWords.sLabelName);
        //        SelectElement dropDown = new SelectElement(element);
        //        IList<IWebElement> elementCount = dropDown.Options;
        //        Random rnd = new Random();
        //        int index = rnd.Next(1,elementCount.Count()-1);
        //        dropDown.SelectByIndex(index);

        //    }
        //    catch
        //    {
        //        results.Result1 = KeyWords.Result_FAIL;
        //        results.ErrorMessage = "Some problem with this selectInDropdownByValue function";
        //        return results;
        //    }
        //    results.Result1 = KeyWords.Result_FAIL;
        //   // results.ErrorMessage = "Selecting from a drop down " +  + " failed";
        //    return results;

        //}



        public Result selectDropDown(IWebDriver driver, String locator, String target, String value)
        {

            var results = new Result();
            try
            {
                driver.FindElement(By.Id(target)).Click();
                Thread.Sleep(2000);
                new SelectElement(driver.FindElement(By.Id(target))).SelectByText(value);
                // Console.WriteLine("Selecting from a drop down " + value + "passed");

                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = "Selecting from a drop down " + value + " passed";
                return results;
            }
            catch (Exception)
            {

                // Console.WriteLine("Selecting from a drop down " + value + " failed");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Selecting from a drop down " + value + " failed";
                return results;


            }
        }

        //public Result select_List_typeahead_New(IWebDriver driver, String locator, String target, String locator1, String target1, String strEnterText, String strcmpvalue)
        //{
        //    var results = new Result();
        //    try
        //    {
        //        //IWebElement element = inspect(driver, locator, target,out KeyWords.sLabelName);
        //        //  string strCmpAppValue = string.Empty;
        //        //string strCmpGivenValue = string.Empty;
        //        string[] listNames = strEnterText.Split(',');
        //        string stempnew = listNames[0];
        //        string stemp = string.Empty;
        //        string target2 = "opt";
        //        Boolean bFlag = false;

        //        for (int i = stempnew.Length-1; i <= strEnterText.Length - 1; i++)
        //        {

        //                //string[] listNames = strEnterText.Split(',');
        //                //stemp = listNames[0];
        //                stemp = stempnew.Substring(0, i);
        //                // Console.WriteLine(stemp);


        //            //stemp = stemp + strEnterText[i].ToString();

        //            sendText(driver, locator, target, stemp, false);
        //            Thread.Sleep(10000);
        //            // target1 = "list-typeahead";
        //            //  ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@" + locator1 + "='" + target1 + "']//div"));
        //            ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//div[@" + locator1 + "='" + target1 + "']//div[@" + locator1 + "='" + target2 + "']"));

        //            List<IWebElement> elements = lis_ClientNames.ToList();
        //            // Console.WriteLine(elements.Count);
        //            for (int j = 0; j <= elements.Count - 1; j++)
        //            {
        //                // j.
        //                // Console.WriteLine(elements[j].Text.Trim());
        //                // Console.WriteLine(strcmpvalue.ToLower().Trim());
        //                if (elements[j].Text.ToLower().Trim() != "")
        //                {
        //                    //bFlag = true;
        //                    Thread.Sleep(100);


        //                    if (elements[j].Text.ToLower().Trim() == "no result found")
        //                    {
        //                        i = strEnterText.Length;
        //                        bFlag = true;
        //                    }
        //                    //   strCmpAppValue = elements[j].Text;
        //                    string strCmpAppValue = Regex.Replace(elements[j].Text, @"\s", "");
        //                    strcmpvalue = Regex.Replace(strcmpvalue, @"\s", "");
        //                    bool stringEquals = String.Equals(strCmpAppValue, strcmpvalue, StringComparison.OrdinalIgnoreCase);
        //                    if (stringEquals)
        //                    {
        //                        bFlag = true;
        //                        try
        //                        {

        //                            // elements.Select(
        //                            //  Console.WriteLine(KeyWords.str_Browser_Execute.ToLower());
        //                            if (KeyWords.str_Browser_Execute.ToLower() == "mozilla")
        //                            {
        //                                elements[j].Click();
        //                                //  driver.FindElement(By.CssSelector("div.opt.optover")).Click();
        //                            }
        //                            else
        //                            {
        //                                elements[j].Click();
        //                            }
        //                        }
        //                        catch
        //                        {
        //                            //
        //                            Console.WriteLine("div.opt.optover problem");
        //                        }
        //                        //  Console.WriteLine("match");
        //                    }
        //                    if (bFlag)
        //                    {
        //                        //Inner for loop break
        //                        //    Console.WriteLine("Inner for loop break");
        //                        break;
        //                    }
        //                }
        //            }
        //            if (bFlag)
        //            {
        //                //Out for loop break
        //                //Console.WriteLine("Outer for loop break");
        //                break;
        //            }

        //        }

        //        if (bFlag)
        //        {
        //            // Console.WriteLine("Selecting " + strcmpvalue);
        //            results.Result1 = KeyWords.Result_PASS;
        //            results.ErrorMessage = "Selecting " + strcmpvalue;
        //        }
        //        else
        //        {
        //            //checkStatus = false;
        //            // Console.WriteLine("The given " + strcmpvalue + " name not found");
        //            results.Result1 = KeyWords.Result_FAIL;
        //            results.ErrorMessage = "The given " + strcmpvalue + " name not found";
        //            click(driver, locator, target);
        //        }

        //        return results;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        results.Result1 = KeyWords.Result_FAIL;
        //        results.ErrorMessage = "Selecting " + strcmpvalue + " failed";
        //        return results;
        //    }
        //}
        public Result select_List_typeahead(IWebDriver driver, String locator, String target, String locatro1, String target1, String strEnterText, String strcmpvalue, string Label="" )
        {
            // Here we are not used locator1, target1 and strcmpvalue. We have maintained for method signature perpouse.
            var results = new Result();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.ExplicitWaitTime));
            try
            {


                String[] InputData = strEnterText.Split(',');
                Action_LookInto_Element(driver, locator, target);
                driver.FindElement(By.Id(target)).Clear();
                Thread.Sleep(500);
                driver.FindElement(By.Id(target)).SendKeys(InputData[0]);
                Thread.Sleep(2000);

                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//*[@id='" + target + "']/following-sibling::div[not(contains(@style,'display: none'))]"))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath("//*[@id='" + target + "']/following-sibling::div[not(contains(@style,'display: none'))]"))));
                Thread.Sleep(1000);

                int TypeaheadlistCount = driver.FindElement(By.XPath("//*[@id='" + target + "']/following-sibling::div")).FindElements(By.TagName("div")).Count;

                for (int i = 1; i <= TypeaheadlistCount; i++)
                {
                    string ActualValue = driver.FindElement(By.XPath("//*[@id='" + target + "']/following-sibling::div/div[" + i + "]")).Text;
                    if (ActualValue == strEnterText)
                    {
                        driver.FindElement(By.XPath("//*[@id='" + target + "']/following-sibling::div/div[" + i + "]")).Click();
                        break;
                    }
                    else if (ActualValue == "No Result Found")
                    {
                        driver.FindElement(By.Id(target)).Clear();
                        Thread.Sleep(200);
                        driver.FindElement(By.Id(target)).SendKeys("a");
                        Thread.Sleep(2000);

                        wait.Until(ExpectedConditions.InvisibilityOfElementLocated((By.XPath("//*[@id='" + target + "']/following-sibling::div[contains(@style,'display: none')]"))));
                        Thread.Sleep(2000);
                        TypeaheadlistCount = 0;
                        TypeaheadlistCount = driver.FindElement(By.XPath("//*[@id='" + target + "']/following-sibling::div")).FindElements(By.TagName("div")).Count;

                        if (TypeaheadlistCount > 0)
                        {
                            driver.FindElement(By.XPath("//*[@id='" + target + "']/following-sibling::div/div[1]")).Click();
                        }
                        else
                        {
                            driver.FindElement(By.Id(target)).Clear();
                            Thread.Sleep(200);
                            driver.FindElement(By.Id(target)).SendKeys("1");
                            Thread.Sleep(2000);

                            wait.Until(ExpectedConditions.InvisibilityOfElementLocated((By.XPath("//*[@id='" + target + "']/following-sibling::div[contains(@style,'display: none')]"))));
                            Thread.Sleep(2000);

                            driver.FindElement(By.XPath("//*[@id='" + target + "']/following-sibling::div/div[1]")).Click();
                        }
                    }
                }
                ReportHandler._ChildTest.Log(LogStatus.Pass, "Selected  the given name in typehead :- " + strEnterText);
                results.blnResult = true;
                return results;
            }
            catch
            {
                try
                {
                    driver.FindElement(By.Id(target)).Clear();
                    Thread.Sleep(200);
                    driver.FindElement(By.Id(target)).SendKeys("a");
                    Thread.Sleep(2000);

                    wait.Until(ExpectedConditions.InvisibilityOfElementLocated((By.XPath("//*[@id='" + target + "']/following-sibling::div[contains(@style,'display: none')]"))));
                    Thread.Sleep(2000);

                    int TypeaheadlistCount = driver.FindElement(By.XPath("//*[@id='" + target + "']/following-sibling::div")).FindElements(By.TagName("div")).Count;

                    if (TypeaheadlistCount > 0)
                    {
                        driver.FindElement(By.XPath("//*[@id='" + target + "']/following-sibling::div/div[1]")).Click();
                    }
                    else
                    {
                        driver.FindElement(By.Id(target)).Clear();
                        Thread.Sleep(200);
                        driver.FindElement(By.Id(target)).SendKeys("1");
                        Thread.Sleep(2000);

                        wait.Until(ExpectedConditions.InvisibilityOfElementLocated((By.XPath("//*[@id='" + target + "']/following-sibling::div[contains(@style,'display: none')]"))));
                        Thread.Sleep(2000);

                        driver.FindElement(By.XPath("//*[@id='" + target + "']/following-sibling::div/div[1]")).Click();
                    }
                    ReportHandler._ChildTest.Log(LogStatus.Pass, "Unable to select given name " + strEnterText + " So we are selecting so default name");
                    results.blnResult = true;
                    return results;
                }
                catch (Exception e)
                {
                    //   Console.WriteLine(ex.Message);
                    ReportHandler._ChildTest.Log(LogStatus.Error, e.Message);
                    results.blnResult = false;
                    results.ErrorMessage = "Typeahead Selection  failed";
                    string screenShotPath = CommonMethods.Capture(driver);
                    ReportHandler._ChildTest.Log(LogStatus.Info, "Snapshot below: " + ReportHandler._ChildTest.AddScreenCapture(screenShotPath));
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, e.Message, 3);
                    return results;
                }
            }
            if (Label != "")
            {
                lableComparision(driver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_HiringManager_hiringManager, Label);
            }
            else
            {

            }
        }


        public Result select_List_typeaheadold(IWebDriver driver, String locator, String target, String locator1, String target1, String strEnterText, String strcmpvalue)
        {
            var results = new Result();
            try
            {
                //IWebElement element = inspect(driver, locator, target,out KeyWords.sLabelName);
                //  string strCmpAppValue = string.Empty;
                //string strCmpGivenValue = string.Empty;
                string[] listNames = strEnterText.Split(',');
                string stempnew = listNames[0];
                string stemp = string.Empty;
                string target2 = "opt";
                Boolean bFlag = false;
                Action_LookInto_Element(driver, locator, target);
                for (int i = stempnew.Length - 1; i <= strEnterText.Length - 1; i++)
                {

                    //string[] listNames = strEnterText.Split(',');
                    //stemp = listNames[0];
                    stemp = stempnew.Substring(0, i);
                    // Console.WriteLine(stemp);


                    //stemp = stemp + strEnterText[i].ToString();

                    sendText(driver, locator, target, stemp, false);
                    objCommonMethods.Action_Button_Backspace(driver);
                    Thread.Sleep(10000);
                    // target1 = "list-typeahead";
                    //  ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@" + locator1 + "='" + target1 + "']//div"));
                    ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//div[@" + locator1 + "='" + target1 + "']//div[@" + locator1 + "='" + target2 + "']"));

                    List<IWebElement> elements = lis_ClientNames.ToList();
                    // Console.WriteLine(elements.Count);
                    for (int j = 0; j <= elements.Count - 1; j++)
                    {
                        // j.
                        // Console.WriteLine(elements[j].Text.Trim());
                        // Console.WriteLine(strcmpvalue.ToLower().Trim());
                        if (elements[j].Text.ToLower().Trim() != "")
                        {
                            //bFlag = true;
                            Thread.Sleep(100);


                            if (elements[j].Text.ToLower().Trim() == "no result found")
                            {
                                i = strEnterText.Length;
                                bFlag = true;
                            }
                            //   strCmpAppValue = elements[j].Text;
                            string strCmpAppValue = Regex.Replace(elements[j].Text, @"\s", "");
                            strcmpvalue = Regex.Replace(strcmpvalue, @"\s", "");
                            bool stringEquals = String.Equals(strCmpAppValue, strcmpvalue, StringComparison.OrdinalIgnoreCase);
                            if (stringEquals)
                            {
                                bFlag = true;
                                try
                                {

                                    // elements.Select(
                                    //  Console.WriteLine(KeyWords.str_Browser_Execute.ToLower());
                                    if (KeyWords.str_Browser_Execute.ToLower() == "mozilla")
                                    {
                                        elements[j].Click();
                                        //  driver.FindElement(By.CssSelector("div.opt.optover")).Click();
                                    }
                                    else
                                    {
                                        elements[j].Click();
                                    }
                                }
                                catch
                                {
                                    // Console.WriteLine("div.opt.optover problem");
                                }
                                //  Console.WriteLine("match");
                            }
                            if (bFlag)
                            {
                                //Inner for loop break
                                //    Console.WriteLine("Inner for loop break");
                                break;
                            }
                        }
                    }
                    if (bFlag)
                    {
                        //Out for loop break
                        //Console.WriteLine("Outer for loop break");
                        break;
                    }

                }

                if (bFlag)
                {
                    // Console.WriteLine("Selecting " + strcmpvalue);
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Selecting " + strcmpvalue;
                    ReportHandler._ChildTest.Log(LogStatus.Pass, "Selecting typeahead -->" + strcmpvalue);
                    //string screenShotPath = CommonMethods.Capture(driver);
                    //ReportHandler._ChildTest.Log(LogStatus.Pass, "Snapshot below: " + ReportHandler._ChildTest.AddScreenCapture(screenShotPath));
                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given " + strcmpvalue + " name not found");
                    ReportHandler._ChildTest.Log(LogStatus.Fail, "The given " + strcmpvalue + " name not found in typeahead");
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given " + strcmpvalue + " name not found in typeahead";
                    click(driver, locator, target);
                }

                return results;
            }
            catch (Exception ex)
            {
                //   Console.WriteLine(ex.Message);
                ReportHandler._ChildTest.Log(LogStatus.Fail, "Selecting typeahead " + strcmpvalue + " failed");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Selecting typeahead " + strcmpvalue + " failed";
                string screenShotPath = CommonMethods.Capture(driver);
                ReportHandler._ChildTest.Log(LogStatus.Info, "Snapshot below: " + ReportHandler._ChildTest.AddScreenCapture(screenShotPath));
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, ex.Message, 3);
                return results;
            }
        }

        public Result select_List_typeahead1(IWebDriver driver, String locator, String target, String locator1, String target1, String strEnterText, String strcmpvalue)
        {
            var results = new Result();
            try
            {
                //IWebElement element = inspect(driver, locator, target,out KeyWords.sLabelName);
                //  string strCmpAppValue = string.Empty;
                //string strCmpGivenValue = string.Empty;
                string[] listNames = strEnterText.Split(',');
                string stempnew = listNames[0];
                string stemp = string.Empty;
                string target2 = "opt";
                Boolean bFlag = false;

                for (int i = stempnew.Length - 1; i <= strEnterText.Length - 1; i++)
                {

                    //string[] listNames = strEnterText.Split(',');
                    //stemp = listNames[0];
                    stemp = stempnew.Substring(0, i);
                    // Console.WriteLine(stemp);

                    //stemp = stemp + strEnterText[i].ToString();

                    sendText(driver, locator, target, stemp, false);
                    Actions action = new Actions(driver);
                    action.SendKeys("a").Build().Perform();
                    Thread.Sleep(100);
                    action.SendKeys(OpenQA.Selenium.Keys.Backspace).Build().Perform();
                    Thread.Sleep(5000);
                    // target1 = "list-typeahead";
                    //  ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@" + locator1 + "='" + target1 + "']//div"));
                    ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//div[@" + locator1 + "='" + target1 + "']//div[@" + locator1 + "='" + target2 + "']"));

                    List<IWebElement> elements = lis_ClientNames.ToList();
                    // Console.WriteLine(elements.Count);
                    for (int j = 0; j <= elements.Count - 1; j++)
                    {
                        // j.
                        // Console.WriteLine(elements[j].Text.Trim());
                        // Console.WriteLine(strcmpvalue.ToLower().Trim());
                        if (elements[j].Text.ToLower().Trim() != "")
                        {
                            //bFlag = true;
                            Thread.Sleep(100);


                            if (elements[j].Text.ToLower().Trim() == "no result found")
                            {
                                i = strEnterText.Length;
                                bFlag = true;
                            }
                            //   strCmpAppValue = elements[j].Text;
                            string strCmpAppValue = Regex.Replace(elements[j].Text, @"\s", "");
                            strcmpvalue = Regex.Replace(strcmpvalue, @"\s", "");
                            bool stringEquals = String.Equals(strCmpAppValue, strcmpvalue, StringComparison.OrdinalIgnoreCase);
                            if (stringEquals)
                            {
                                bFlag = true;
                                try
                                {

                                    // elements.Select(
                                    //  Console.WriteLine(KeyWords.str_Browser_Execute.ToLower());
                                    if (KeyWords.str_Browser_Execute.ToLower() == "mozilla")
                                    {
                                        elements[j].Click();
                                        //  driver.FindElement(By.CssSelector("div.opt.optover")).Click();
                                    }
                                    else
                                    {
                                        elements[j].Click();
                                    }
                                }
                                catch
                                {
                                    // Console.WriteLine("div.opt.optover problem");
                                }
                                //  Console.WriteLine("match");
                            }
                            if (bFlag)
                            {
                                //Inner for loop break
                                //    Console.WriteLine("Inner for loop break");
                                break;
                            }
                        }
                    }
                    if (bFlag)
                    {
                        //Out for loop break
                        //Console.WriteLine("Outer for loop break");
                        break;
                    }

                }

                if (bFlag)
                {
                    // Console.WriteLine("Selecting " + strcmpvalue);
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Selecting " + strcmpvalue;
                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given " + strcmpvalue + " name not found");
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given " + strcmpvalue + " name not found";
                    click(driver, locator, target);
                }

                return results;
            }
            catch (Exception ex)
            {
                //   Console.WriteLine(ex.Message);
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Selecting " + strcmpvalue + " failed";
                return results;
            }
        }

        public Result select_List_typeahead_OneByOne(IWebDriver driver, String locator, String target, String locator1, String target1, String strEnterText, String strcmpvalue)
        {
            var results = new Result();
            try
            {
                //IWebElement element = inspect(driver, locator, target,out KeyWords.sLabelName);
                //  string strCmpAppValue = string.Empty;
                //string strCmpGivenValue = string.Empty;
                string[] listNames = strEnterText.Split(',');
                string stempnew = listNames[0];
                string stemp = string.Empty;
                string target2 = "opt";
                Boolean bFlag = false;

                for (int i = stempnew.Length - 1; i <= strEnterText.Length - 1; i++)
                {


                    if (i == 2)
                    {
                        //string[] listNames = strEnterText.Split(',');
                        //stemp = listNames[0];
                        stemp = strEnterText.Substring(0, 2);
                        // Console.WriteLine(stemp);
                    }
                    if (i == 6)
                    {
                        results.Result1 = KeyWords.Result_FAIL;
                        results.ErrorMessage = "The given " + strcmpvalue + " name not found";
                        return results;
                    }
                    stemp = stemp + strEnterText[i].ToString();





                    sendText(driver, locator, target, stemp, false);
                    Thread.Sleep(10000);
                    // target1 = "list-typeahead";
                    //  ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@" + locator1 + "='" + target1 + "']//div"));
                    ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//div[@" + locator1 + "='" + target1 + "']//div[@" + locator1 + "='" + target2 + "']"));

                    List<IWebElement> elements = lis_ClientNames.ToList();
                    // Console.WriteLine(elements.Count);
                    for (int j = 0; j <= elements.Count - 1; j++)
                    {
                        // j.
                        // Console.WriteLine(elements[j].Text.Trim());
                        // Console.WriteLine(strcmpvalue.ToLower().Trim());
                        if (elements[j].Text.ToLower().Trim() != "")
                        {
                            //bFlag = true;
                            Thread.Sleep(100);


                            if (elements[j].Text.ToLower().Trim() == "no result found")
                            {
                                i = strEnterText.Length;
                                bFlag = true;
                            }
                            //   strCmpAppValue = elements[j].Text;
                            string strCmpAppValue = Regex.Replace(elements[j].Text, @"\s", "");
                            strcmpvalue = Regex.Replace(strcmpvalue, @"\s", "");
                            bool stringEquals = String.Equals(strCmpAppValue, strcmpvalue, StringComparison.OrdinalIgnoreCase);
                            if (stringEquals)
                            {
                                bFlag = true;
                                try
                                {

                                    // elements.Select(
                                    //  Console.WriteLine(KeyWords.str_Browser_Execute.ToLower());
                                    if (KeyWords.str_Browser_Execute.ToLower() == "mozilla")
                                    {
                                        elements[j].Click();
                                        //  driver.FindElement(By.CssSelector("div.opt.optover")).Click();
                                    }
                                    else
                                    {
                                        elements[j].Click();
                                    }
                                }
                                catch
                                {
                                    // Console.WriteLine("div.opt.optover problem");
                                }
                                //  Console.WriteLine("match");
                            }
                            if (bFlag)
                            {
                                //Inner for loop break
                                //    Console.WriteLine("Inner for loop break");
                                break;
                            }
                        }
                    }
                    if (bFlag)
                    {
                        //Out for loop break
                        //Console.WriteLine("Outer for loop break");
                        break;
                    }

                }

                if (bFlag)
                {
                    // Console.WriteLine("Selecting " + strcmpvalue);
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Selecting " + strcmpvalue;
                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given " + strcmpvalue + " name not found");
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given " + strcmpvalue + " name not found";
                    click(driver, locator, target);
                }

                return results;
            }
            catch (Exception ex)
            {
                //   Console.WriteLine(ex.Message);
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Selecting " + strcmpvalue + " failed";
                return results;
            }
        }


        public Result select_List_typeahead_WA(IWebDriver driver, String locator, String target, String locator1, String target1, String strEnterText, String strcmpvalue)
        {
            var results = new Result();
            try
            {
                //IWebElement element = inspect(driver, locator, target,out KeyWords.sLabelName);
                //  string strCmpAppValue = string.Empty;
                //string strCmpGivenValue = string.Empty;
                string stemp = string.Empty;
                string target2 = "opt";
                Boolean bFlag = false;

                for (int i = 2; i <= strEnterText.Length - 1; i++)
                {
                    if (i == 2)
                    {
                        //string[] listNames = strEnterText.Split(',');
                        //stemp = listNames[0];
                        stemp = strEnterText.Substring(0, 2);
                        // Console.WriteLine(stemp);
                    }
                    if (i == 6)
                    {
                        results.Result1 = KeyWords.Result_FAIL;
                        results.ErrorMessage = "The given " + strcmpvalue + " name not found";
                        return results;
                    }
                    stemp = stemp + strEnterText[i].ToString();

                    sendText(driver, locator, target, stemp, false);
                    Thread.Sleep(10000);
                    // target1 = "list-typeahead";
                    //  ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@" + locator1 + "='" + target1 + "']//div"));
                    ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//div[@" + locator1 + "='" + target1 + "']//div[@" + locator1 + "='" + target2 + "']"));

                    List<IWebElement> elements = lis_ClientNames.ToList();
                    // Console.WriteLine(elements.Count);
                    for (int j = 0; j <= elements.Count - 1; j++)
                    {
                        // j.
                        // Console.WriteLine(elements[j].Text.Trim());
                        // Console.WriteLine(strcmpvalue.ToLower().Trim());
                        if (elements[j].Text.ToLower().Trim() != "")
                        {
                            //bFlag = true;
                            Thread.Sleep(100);


                            if (elements[j].Text.ToLower().Trim() == "no result found")
                            {
                                i = strEnterText.Length;
                                bFlag = true;
                            }
                            //   strCmpAppValue = elements[j].Text;
                            string strCmpAppValue = Regex.Replace(elements[j].Text, @"\s", "");
                            strcmpvalue = Regex.Replace(strcmpvalue, @"\s", "");
                            bool stringEquals = String.Equals(strCmpAppValue, strcmpvalue, StringComparison.OrdinalIgnoreCase);
                            if (stringEquals)
                            {
                                bFlag = true;
                                try
                                {

                                    // elements.Select(
                                    //  Console.WriteLine(KeyWords.str_Browser_Execute.ToLower());
                                    if (KeyWords.str_Browser_Execute.ToLower() == "mozilla")
                                    {
                                        elements[j].Click();
                                        //  driver.FindElement(By.CssSelector("div.opt.optover")).Click();
                                    }
                                    else
                                    {
                                        elements[j].Click();
                                    }
                                }
                                catch
                                {
                                    //
                                    Console.WriteLine("div.opt.optover problem");
                                }
                                //  Console.WriteLine("match");
                            }
                            if (bFlag)
                            {
                                //Inner for loop break
                                //    Console.WriteLine("Inner for loop break");
                                break;
                            }
                        }
                    }
                    if (bFlag)
                    {
                        //Out for loop break
                        //Console.WriteLine("Outer for loop break");
                        break;
                    }

                }

                if (bFlag)
                {
                    // Console.WriteLine("Selecting " + strcmpvalue);
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Selecting " + strcmpvalue;
                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given " + strcmpvalue + " name not found");
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given " + strcmpvalue + " name not found";
                    click(driver, locator, target);
                }

                return results;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Selecting " + strcmpvalue + " failed";
                return results;
            }
        }

        public Result select_List_typeahead_AnyOne(IWebDriver driver, String locator, String target, String locator1, String target1, String strEnterText, String strcmpvalue)
        {
            var results = new Result();
            try
            {
                //IWebElement element = inspect(driver, locator, target,out KeyWords.sLabelName);
                //  string strCmpAppValue = string.Empty;
                //string strCmpGivenValue = string.Empty;
                string stemp = string.Empty;
                string target2 = "opt";
                Boolean bFlag = false;

                for (int i = 2; i <= strEnterText.Length - 1; i++)
                {
                    if (i == 2)
                    {
                        //string[] listNames = strEnterText.Split(',');
                        //stemp = listNames[0];
                        stemp = strEnterText.Substring(0, 2);
                        // Console.WriteLine(stemp);
                    }
                    if (i == 6)
                    {
                        ReportHandler._ChildTest.Log(LogStatus.Fail, "The given " + strcmpvalue + " name not found");
                        results.Result1 = KeyWords.Result_FAIL;
                        results.ErrorMessage = "The given " + strcmpvalue + " name not found";
                        return results;
                    }
                    stemp = stemp + strEnterText[i].ToString();

                    sendText(driver, locator, target, stemp, false);
                    Thread.Sleep(10000);
                    // target1 = "list-typeahead";
                    //  ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@" + locator1 + "='" + target1 + "']//div"));
                    ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//div[@" + locator1 + "='" + target1 + "']//div[@" + locator1 + "='" + target2 + "']"));

                    List<IWebElement> elements = lis_ClientNames.ToList();
                    // Console.WriteLine(elements.Count);
                    for (int j = 0; j <= elements.Count - 1; j++)
                    {
                        // j.
                        // Console.WriteLine(elements[j].Text.Trim());
                        // Console.WriteLine(strcmpvalue.ToLower().Trim());
                        if (elements[j].Text.ToLower().Trim() != "")
                        {
                            bFlag = true;
                            Thread.Sleep(100);


                            if (elements[j].Text.ToLower().Trim() == "no result found")
                            {
                                i = strEnterText.Length;
                                bFlag = true;
                            }

                            try
                            {

                                // elements.Select(
                                //  Console.WriteLine(KeyWords.str_Browser_Execute.ToLower());
                                if (KeyWords.str_Browser_Execute.ToLower() == "mozilla")
                                {
                                    elements[j].Click();
                                    //  driver.FindElement(By.CssSelector("div.opt.optover")).Click();
                                }
                                else
                                {
                                    elements[j].Click();
                                }
                            }
                            catch
                            {
                                //
                                Console.WriteLine("div.opt.optover problem");
                            }
                            //  Console.WriteLine("match");

                            if (bFlag)
                            {
                                //Inner for loop break
                                //    Console.WriteLine("Inner for loop break");
                                break;
                            }
                        }
                    }
                    if (bFlag)
                    {
                        //Out for loop break
                        //Console.WriteLine("Outer for loop break");
                        break;
                    }

                }

                if (bFlag)
                {
                    // Console.WriteLine("Selecting " + strcmpvalue);
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Selecting " + strcmpvalue;

                    ReportHandler._ChildTest.Log(LogStatus.Pass, "Selected  the given name in typehead :- " + strcmpvalue);
                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given " + strcmpvalue + " name not found");
                    ReportHandler._ChildTest.Log(LogStatus.Fail, "The given " + strcmpvalue + " name not found");
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given " + strcmpvalue + " name not found";

                    click(driver, locator, target);
                }

                return results;
            }
            catch (Exception ex)
            {
                ReportHandler._ChildTest.Log(LogStatus.Error, ex.Message);
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Selecting " + strcmpvalue + " failed";
                string screenShotPath = CommonMethods.Capture(driver);
                ReportHandler._ChildTest.Log(LogStatus.Info, "Snapshot below: " + ReportHandler._ChildTest.AddScreenCapture(screenShotPath));
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, ex.Message, 3);
                return results;
            }
        }

        public Result select_List_typeaheads(IWebDriver driver, String locator, String target, String strEnterText)
        {
            var results = new Result();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.ExplicitWaitTime));
            try
            {


                String[] InputData = strEnterText.Split(',');

                driver.FindElement(By.Id(target)).Clear();
                Thread.Sleep(500);
                driver.FindElement(By.Id(target)).SendKeys(InputData[0]);
                Thread.Sleep(2000);

                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//*[@id='" + target + "']/following-sibling::div[not(contains(@style,'display: none'))]"))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath("//*[@id='" + target + "']/following-sibling::div[not(contains(@style,'display: none'))]"))));
                Thread.Sleep(1000);

                int TypeaheadlistCount = driver.FindElement(By.XPath("//*[@id='" + target + "']/following-sibling::div")).FindElements(By.TagName("div")).Count;

                for (int i = 1; i <= TypeaheadlistCount; i++)
                {
                    string ActualValue = driver.FindElement(By.XPath("//*[@id='" + target + "']/following-sibling::div/div[" + i + "]")).Text;
                    if (ActualValue == strEnterText)
                    {
                        driver.FindElement(By.XPath("//*[@id='" + target + "']/following-sibling::div/div[" + i + "]")).Click();
                        break;
                    }
                }
                ReportHandler._ChildTest.Log(LogStatus.Pass, "Selected  the given name in typehead :- " + strEnterText);
                results.blnResult = true;
                return results;
            }
            catch
            {
                try
                {
                    driver.FindElement(By.Id(target)).Clear();
                    Thread.Sleep(200);
                    driver.FindElement(By.Id(target)).SendKeys("a");
                    Thread.Sleep(2000);

                    wait.Until(ExpectedConditions.InvisibilityOfElementLocated((By.XPath("//*[@id='" + target + "']/following-sibling::div[contains(@style,'display: none')]"))));
                    Thread.Sleep(2000);

                    int TypeaheadlistCount = driver.FindElement(By.XPath("//*[@id='" + target + "']/following-sibling::div")).FindElements(By.TagName("div")).Count;

                    if (TypeaheadlistCount > 0)
                    {
                        driver.FindElement(By.XPath("//*[@id='" + target + "']/following-sibling::div/div[1]")).Click();
                    }
                    else
                    {
                        driver.FindElement(By.Id(target)).Clear();
                        Thread.Sleep(200);
                        driver.FindElement(By.Id(target)).SendKeys("s");
                        Thread.Sleep(2000);

                        wait.Until(ExpectedConditions.InvisibilityOfElementLocated((By.XPath("//*[@id='" + target + "']/following-sibling::div[contains(@style,'display: none')]"))));
                        Thread.Sleep(2000);

                        driver.FindElement(By.XPath("//*[@id='" + target + "']/following-sibling::div/div[1]")).Click();
                    }
                    ReportHandler._ChildTest.Log(LogStatus.Pass, "Unable to select given name " + strEnterText + " So we are selecting so default name");
                    results.blnResult = true;
                    return results;
                }
                catch (Exception e)
                {
                    //   Console.WriteLine(ex.Message);
                    ReportHandler._ChildTest.Log(LogStatus.Error, e.Message);
                    results.blnResult = false;
                    results.ErrorMessage = "Selecting  failed";
                    string screenShotPath = CommonMethods.Capture(driver);
                    ReportHandler._ChildTest.Log(LogStatus.Info, "Snapshot below: " + ReportHandler._ChildTest.AddScreenCapture(screenShotPath));
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, e.Message, 3);
                    return results;
                }
            }
        }


        public Result select_List_typeahead_LocationAddress(IWebDriver driver, String locator, String target, String locator1, String target1, String strEnterText, String strcmpvalue)
        {
            var results = new Result();
            try
            {
                //IWebElement element = inspect(driver, locator, target,out KeyWords.sLabelName);
                //  string strCmpAppValue = string.Empty;
                //string strCmpGivenValue = string.Empty;
                string stemp = string.Empty;
                string target2 = "opt";
                Boolean bFlag = false;

                for (int i = 2; i <= strEnterText.Length - 1; i++)
                {
                    if (i == 2)
                    {
                        //string[] listNames = strEnterText.Split(',');
                        //stemp = listNames[0];
                        stemp = strEnterText.Substring(0, 2);
                        // Console.WriteLine(stemp);
                    }
                    if (i == 6)
                    {
                        results.Result1 = KeyWords.Result_FAIL;
                        results.ErrorMessage = "The given " + strcmpvalue + " name not found";
                        return results;
                    }
                    stemp = stemp + strEnterText[i].ToString();

                    sendText(driver, locator, target, stemp, false);
                    Thread.Sleep(3000);
                    // target1 = "list-typeahead";
                    //  ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@" + locator1 + "='" + target1 + "']//div"));
                    ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//div[@" + locator1 + "='" + target1 + "']//div[@" + locator1 + "='" + target2 + "']"));

                    List<IWebElement> elements = lis_ClientNames.ToList();
                    // Console.WriteLine(elements.Count);
                    for (int j = 0; j <= elements.Count - 1; j++)
                    {
                        // j.
                        // Console.WriteLine(elements[j].Text.Trim());
                        // Console.WriteLine(strcmpvalue.ToLower().Trim());
                        if (elements[j].Text.ToLower().Trim() != "")
                        {
                            //bFlag = true;
                            Thread.Sleep(1);


                            if (elements[j].Text.ToLower().Trim() == "no result found")
                            {
                                i = strEnterText.Length;
                                bFlag = true;
                            }
                            //   strCmpAppValue = elements[j].Text;
                            string strCmpAppValue = Regex.Replace(elements[j].Text, @"\s", "");
                            strcmpvalue = Regex.Replace(strcmpvalue, @"\s", "");
                            bool stringEquals = String.Equals(strCmpAppValue, strcmpvalue, StringComparison.OrdinalIgnoreCase);
                            if (i == 5)
                            {
                                bFlag = true;
                                try
                                {

                                    // elements.Select(
                                    //  Console.WriteLine(KeyWords.str_Browser_Execute.ToLower());
                                    if (KeyWords.str_Browser_Execute.ToLower() == "mozilla")
                                    {
                                        elements[j].Click();
                                        //  driver.FindElement(By.CssSelector("div.opt.optover")).Click();
                                    }
                                    else
                                    {
                                        elements[j].Click();
                                    }
                                }
                                catch
                                {
                                    //
                                    bFlag = false;
                                    //  Console.WriteLine("div.opt.optover problem");
                                }
                                //  Console.WriteLine("match");                           
                            }
                            if (stringEquals)
                            {
                                bFlag = true;
                                try
                                {

                                    // elements.Select(
                                    //  Console.WriteLine(KeyWords.str_Browser_Execute.ToLower());
                                    if (KeyWords.str_Browser_Execute.ToLower() == "mozilla")
                                    {
                                        elements[j].Click();
                                        //  driver.FindElement(By.CssSelector("div.opt.optover")).Click();
                                    }
                                    else
                                    {
                                        elements[j].Click();
                                    }
                                }
                                catch
                                {
                                    //
                                    bFlag = false;
                                    //  Console.WriteLine("div.opt.optover problem");
                                }
                                //  Console.WriteLine("match");                           
                            }
                        }
                    }
                    if (bFlag)
                    {
                        //Out for loop break
                        //Console.WriteLine("Outer for loop break");
                        break;
                    }

                }

                if (bFlag)
                {
                    // Console.WriteLine("Selecting " + strcmpvalue);
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Selecting " + strcmpvalue;
                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given " + strcmpvalue + " name not found");
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given " + strcmpvalue + " name not found";
                    click(driver, locator, target);
                }

                return results;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Selecting " + strcmpvalue + " failed";
                return results;
            }
        }

        public Result select_List_typeahead_LocationAddress_New(IWebDriver driver, String locator, String target, String locator1, String target1, String strEnterText, String strcmpvalue)
        {
            var results = new Result();
            try
            {
                //IWebElement element = inspect(driver, locator, target,out KeyWords.sLabelName);
                //  string strCmpAppValue = string.Empty;
                //string strCmpGivenValue = string.Empty;
                string stemp = string.Empty;
                string target2 = "opt";
                Boolean bFlag = false;

                for (int i = 2; i <= strEnterText.Length - 1; i++)
                {
                    //if (i == 2)
                    //{
                    //string[] listNames = strEnterText.Split(',');
                    //stemp = listNames[0];
                    stemp = strEnterText.Substring(0, strEnterText.Length - 1);
                    // Console.WriteLine(stemp);
                    //}
                    //if (i == 6)
                    //{
                    //    results.Result1 = KeyWords.Result_FAIL;
                    //    results.ErrorMessage = "The given " + strcmpvalue + " name not found";
                    //    return results;
                    //}
                    //  stemp = stemp + strEnterText[i].ToString();

                    sendText(driver, locator, target, stemp, false);
                    Thread.Sleep(3000);
                    // target1 = "list-typeahead";
                    //  ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@" + locator1 + "='" + target1 + "']//div"));
                    ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//div[@" + locator1 + "='" + target1 + "']//div[@" + locator1 + "='" + target2 + "']"));

                    List<IWebElement> elements = lis_ClientNames.ToList();
                    // Console.WriteLine(elements.Count);
                    for (int j = 0; j <= elements.Count - 1; j++)
                    {
                        // j.
                        // Console.WriteLine(elements[j].Text.Trim());
                        // Console.WriteLine(strcmpvalue.ToLower().Trim());
                        if (elements[j].Text.ToLower().Trim() != "")
                        {
                            //bFlag = true;
                            Thread.Sleep(1);


                            if (elements[j].Text.ToLower().Trim() == "no result found")
                            {
                                i = strEnterText.Length;
                                bFlag = true;
                            }
                            //   strCmpAppValue = elements[j].Text;
                            string strCmpAppValue = Regex.Replace(elements[j].Text, @"\s", "");
                            strcmpvalue = Regex.Replace(strcmpvalue, @"\s", "");
                            bool stringEquals = String.Equals(strCmpAppValue, strcmpvalue, StringComparison.OrdinalIgnoreCase);
                            if (i == 5)
                            {
                                bFlag = true;
                                try
                                {

                                    // elements.Select(
                                    //  Console.WriteLine(KeyWords.str_Browser_Execute.ToLower());
                                    if (KeyWords.str_Browser_Execute.ToLower() == "mozilla")
                                    {
                                        elements[j].Click();
                                        //  driver.FindElement(By.CssSelector("div.opt.optover")).Click();
                                    }
                                    else
                                    {
                                        elements[j].Click();
                                    }
                                }
                                catch
                                {
                                    //
                                    bFlag = false;
                                    //  Console.WriteLine("div.opt.optover problem");
                                }
                                //  Console.WriteLine("match");                           
                            }
                            if (stringEquals)
                            {
                                bFlag = true;
                                try
                                {

                                    // elements.Select(
                                    //  Console.WriteLine(KeyWords.str_Browser_Execute.ToLower());
                                    if (KeyWords.str_Browser_Execute.ToLower() == "mozilla")
                                    {
                                        elements[j].Click();
                                        //  driver.FindElement(By.CssSelector("div.opt.optover")).Click();
                                    }
                                    else
                                    {
                                        elements[j].Click();
                                    }
                                }
                                catch
                                {
                                    //
                                    bFlag = false;
                                    //  Console.WriteLine("div.opt.optover problem");
                                }
                                //  Console.WriteLine("match");                           
                            }
                        }
                    }
                    if (bFlag)
                    {
                        //Out for loop break
                        //Console.WriteLine("Outer for loop break");
                        break;
                    }

                }

                if (bFlag)
                {
                    // Console.WriteLine("Selecting " + strcmpvalue);
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Selecting " + strcmpvalue;
                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given " + strcmpvalue + " name not found");
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given " + strcmpvalue + " name not found";
                    click(driver, locator, target);
                }

                return results;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Selecting " + strcmpvalue + " failed";
                return results;
            }
        }

        public Result select_List_typeahead_temp(IWebDriver driver, String locator, String target, String locator1, String target1, String strEnterText, String strcmpvalue)
        {
            var results = new Result();
            try
            {
                string stemp = string.Empty;
                Boolean bFlag = false;

                results=sendText(driver, locator, target, strEnterText.Trim(), false);
                if(results._Var!="")
                    KeyWords._isLableCaptured = true;
                Thread.Sleep(1000);
                Actions action = new Actions(driver);
                action.SendKeys("a").Build().Perform();
                Thread.Sleep(200);
                action.SendKeys(OpenQA.Selenium.Keys.Backspace).Build().Perform();

                Thread.Sleep(5000);

                ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@" + locator1 + "='" + target1 + "']//div"));

                List<IWebElement> elements = lis_ClientNames.ToList();
                for (int j = 0; j <= elements.Count - 1; j++)
                {
                    if (elements[j].Text.ToLower().Trim() != "")
                    {
                        string strCmpAppValue = Regex.Replace(elements[j].Text, @"\s", "");
                        strcmpvalue = Regex.Replace(strcmpvalue, @"\s", "");
                        bool stringEquals = String.Equals(strCmpAppValue, strcmpvalue, StringComparison.OrdinalIgnoreCase);

                        if (stringEquals)
                        {

                            try
                            {

                                if (KeyWords.str_Browser_Execute.ToLower() == "mozilla")
                                {
                                    elements[j].Click();
                                    elements[j].SendKeys(OpenQA.Selenium.Keys.Enter);
                                }
                                else
                                {
                                    elements[j].Click();
                                }
                                bFlag = true;
                            }
                            catch
                            {
                                //
                            }


                        }
                    }
                    if (bFlag)
                    {
                        //Inner for loop break   
                        results = GetText(driver, locator, target, "value");
                        if (results.ErrorMessage == strEnterText)
                        {
                            break;
                        }
                        else
                        {
                            bFlag = false;
                        }
                    }
                }
                if (bFlag)
                {
                    ReportHandler._ChildTest.Log(LogStatus.Pass, "Selecting select_List_typeahead_temp function :- " + target);
                    results.Result1 = KeyWords.Result_PASS;
                    return results;
                }
                else
                {
                    ReportHandler._ChildTest.Log(LogStatus.Fail, "Unable to select_List_typeahead_temp function :- " + target);
                    results.Result1 = KeyWords.Result_FAIL;
                    return results;
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                ReportHandler._ChildTest.Log(LogStatus.Error, ex.Message);
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Selecting " + strcmpvalue + " failed";
                return results;
            }
        }
        public Result select_List_typeahead_temp_AnyOne(IWebDriver driver, String locator, String target, String locator1, String target1, String strEnterText)
        {
            var results = new Result();
            try
            {
                string stemp = string.Empty;
                Boolean bFlag = false;

                sendText(driver, locator, target, strEnterText.Trim(), false);
                Thread.Sleep(10000);
                ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@" + locator1 + "='" + target1 + "']//div"));

                List<IWebElement> elements = lis_ClientNames.ToList();
                for (int j = 0; j <= elements.Count - 1; j++)
                {
                    if (elements[j].Text.ToLower().Trim() != "")
                    {

                        bFlag = true;
                        try
                        {

                            if (KeyWords.str_Browser_Execute.ToLower() == "mozilla")
                            {
                                elements[j].Click();
                                elements[j].SendKeys(OpenQA.Selenium.Keys.Enter);
                            }
                            else
                            {
                                elements[j].Click();
                            }
                        }
                        catch
                        {
                            //
                        }


                    }
                    if (bFlag)
                    {
                        //Inner for loop break                           
                        break;
                    }
                }
                if (bFlag)
                {
                    ReportHandler._ChildTest.Log(LogStatus.Pass, "Selecting select_List_typeahead_temp_AnyOne function :- " + target);
                    results.Result1 = KeyWords.Result_PASS;
                    return results;
                }
                else
                {
                    ReportHandler._ChildTest.Log(LogStatus.Fail, "Unable to select_List_typeahead_temp_AnyOne function :- " + target);
                    results.Result1 = KeyWords.Result_FAIL;
                    return results;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                ReportHandler._ChildTest.Log(LogStatus.Error, ex.Message);
                results.Result1 = KeyWords.Result_FAIL;
                //  results.ErrorMessage = "Selecting " + strcmpvalue + " failed";
                return results;
            }
        }

        public string CloseAlertAndGetItsText(IWebDriver WDriver)
        {
            //bool acceptNextAlert = true;
            string strText = "";
            // Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                bool bFlag = false;


                for (int i = 1; i <= 10; i++)
                {
                    string strXpath = "(//button[@type='button'])[" + i + "]";
                    string strClose = "";
                    try
                    {
                        strClose = WDriver.FindElement(By.XPath(strXpath)).Text;
                        if (strClose == "Close")
                            bFlag = true;
                        //  Assert.AreEqual("Close", WDriver.FindElement(By.XPath(strXpath)).Text);
                        //  bFlag = true;
                        if (bFlag)
                        {
                            WDriver.FindElement(By.XPath(strXpath)).Click();
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        bFlag = false;
                        //verificationErrors.Append(e.Message);
                    }

                }

                return strText;
            }
            finally
            {
                //
            }
            // stopwatch.Stop();
        }

        public bool IsAlertPresent(IWebDriver WDriver)
        {
            try
            {
                WDriver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public Result selectDynamicDropdownByValue(IWebDriver driver, String locator, String target)
        {
            var results = new Result();
            int index = 0;
            try
            {
                IWebElement element = inspect(driver, locator, target,out KeyWords.sLabelName);
                Action_LookInto_Element(driver, locator, target);
                SelectElement dropDown = new SelectElement(element);
                IList<IWebElement> elementCount = dropDown.Options;
                Random rnd = new Random();
                index = rnd.Next(1, elementCount.Count() - 1);
                dropDown.SelectByIndex(index);

            }
            catch (Exception ex)
            {
                ReportHandler._ChildTest.Log(LogStatus.Error, ex.Message);
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Some problem with this selectInDropdownByValue function";
                return results;
            }
            ReportHandler._ChildTest.Log(LogStatus.Pass, "Selecting from a drop down by selectDynamicDropdownByValue :- " + index.ToString());
            results.Result1 = KeyWords.Result_PASS;
            // results.ErrorMessage = "Selecting from a drop down " +  + " failed";
            return results;

        }

        public Result selectDynamicDropdownByName(IWebDriver driver, String locator, String target)
        {
            var results = new Result();
            try
            {
                IWebElement element = inspect(driver, locator, target,out KeyWords.sLabelName);
                // click(driver, locator, target);
                driver.FindElement(By.CssSelector("button.ms-choice")).Click();
                driver.FindElement(By.Name("selectItemlblReqStatus")).Click();
                driver.FindElement(By.Name("selectAlllblReqStatus")).Click();
                int intcount = driver.FindElements(By.XPath("//*[@name='selectItemlblReqStatus']")).Count;
                ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@name='selectItemlblReqStatus']"));
                List<IWebElement> elements = lis_ClientNames.ToList();

                string s = "";
                for (int x = 1; x <= elements.Count; x++)
                {
                    s = driver.FindElement(By.XPath("(//input[@name='selectItemlblReqStatus'])[" + x + "]")).GetAttribute("label"); ;
                }
                //  driver.FindElement(By.XPath("(//input[@name='selectItemlblReqStatus'])[2]")).Click();


                //  elements[5].FindElement

                int intcount1 = driver.FindElements(By.XPath("//*[@name='selectItemlblColumnTitle']")).Count;
                driver.FindElement(By.XPath("(//input[@name='selectItemlblColumnTitle'])[2]")).Click();

                driver.FindElement(By.XPath("(//input[@name='selectItemlblReqStatus'])[2]")).Click();
                driver.FindElement(By.XPath("(//input[@name='selectItemlblReqStatus'])[3]")).Click();
                driver.FindElement(By.XPath("(//input[@name='selectItemlblReqStatus'])[4]")).Click();
                driver.FindElement(By.XPath("(//input[@name='selectItemlblReqStatus'])[5]")).Click();
                driver.FindElement(By.Name("selectAlllblReqStatus")).Click();


                driver.FindElement(By.XPath("(//button[@type='button'])[5]")).Click();

                // driver.FindElement(By.CssSelector("button.ms-choice")).Click();
                driver.FindElement(By.XPath("//*[@id='tblFieldData']/div[4]/div/div/div/button/div")).Click();
                driver.FindElement(By.XPath("(//input[@name='selectItemlblColumnTitle'])[2]")).Click();
                driver.FindElement(By.XPath("(//input[@name='selectItemlblColumnTitle'])[3]")).Click();
                driver.FindElement(By.XPath("(//input[@name='selectItemlblColumnTitle'])[4]")).Click();
                driver.FindElement(By.XPath("(//input[@name='selectItemlblColumnTitle'])[5]")).Click();
                driver.FindElement(By.Name("selectAlllblColumnTitle")).Click();
                driver.FindElement(By.XPath("(//button[@type='button'])[5]")).Click();




                driver.FindElement(By.XPath("(//input[@name='lblReqStatus'])[2]")).Click();
                driver.FindElement(By.XPath("(//input[@name='lblReqStatus'])[3]")).Click();
                driver.FindElement(By.XPath("(//input[@name='lblReqStatus'])[4]")).Click();
                driver.FindElement(By.XPath("(//input[@name='lblReqStatus'])[5]")).Click();
                driver.FindElement(By.XPath("(//input[@name='lblReqStatus'])[6]")).Click();
                SelectElement dropDown = new SelectElement(element);
                IList<IWebElement> elementCount = dropDown.Options;
                Random rnd = new Random();
                int index = rnd.Next(1, elementCount.Count() - 1);
                dropDown.SelectByIndex(index);

            }
            catch (Exception e)
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Some problem with this selectInDropdownByName function";
                results.ErrorMessage = e.Message;
                return results;
            }
            results.Result1 = KeyWords.Result_PASS;
            // results.ErrorMessage = "Selecting from a drop down " +  + " failed";
            return results;

        }


        public Result select_Button(IWebDriver driver, String locator, String target, String strSelectButtonName)
        {
            Result results = new Result();
            Boolean bFlag = false;
            results.Result1 = KeyWords.Result_FAIL;
            try
            {
                //ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[contains(@" + locator + ", '" + target + "') and text()='" + strSelectButtonName + "']"));
                ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']//div//button"));
                List<IWebElement> elements = lis_ClientNames.ToList();
                // Console.WriteLine(elements.Count);
                for (int j = 0; j <= elements.Count; j++)
                {
                    // Console.WriteLine(elements[j].Text.Trim());
                    //  Console.WriteLine(strSelectButtonName.Trim());
                    if (elements[j].Text.Trim() == strSelectButtonName.Trim())
                    {
                        bFlag = true;
                        try
                        {
                            elements[j].SendKeys(OpenQA.Selenium.Keys.Enter);
                            // driver.FindElement(By.CssSelector("div.opt.optover")).Click();
                        }
                        catch (Exception logBt)
                        {
                            //
                            Console.WriteLine("Save and continue error");
                            Console.WriteLine(logBt.Message);
                        }
                    }
                    if (bFlag)
                    {
                        //Inner for loop break
                        // Console.WriteLine("Button for loop break");
                        break;
                    }
                }
                if (bFlag)
                {
                    // Console.WriteLine("Click on the " + strSelectButtonName);
                    results.ErrorMessage = "Click on the " + strSelectButtonName;
                    results.Result1 = KeyWords.Result_PASS;
                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given button" + strSelectButtonName + " name not found");
                    results.ErrorMessage = "The given button" + strSelectButtonName + " name not found";
                    results.Result1 = KeyWords.Result_FAIL;
                }
                return results;
            }
            catch (Exception)
            {
                // Console.WriteLine("Click on the button " + strSelectButtonName + " failed");
                results.ErrorMessage = "Click on the button " + strSelectButtonName + " failed";
                results.Result1 = KeyWords.Result_FAIL;
                return results;
            }
        }


        public Result select_Button_Img(IWebDriver driver, String ButtonName)
        {
            Result results = new Result();
            Boolean bFlag = false;
            String Str_Addsection = "";
            results.Result1 = KeyWords.Result_FAIL;
            for (int z = 1; z <= 10; z++)
            {

                String StrTempXPath_Addsection = KeyWords.Xpath_AddSection + "[" + z + "]";
                try
                {
                    Str_Addsection = driver.FindElement(By.XPath(StrTempXPath_Addsection)).Text;
                }
                catch
                {
                    //results.ErrorMessage = "The given button " + Str_Addsection + " name not found";
                    //results.Result1 = KeyWords.Result_FAIL;

                }
                if (Str_Addsection.Equals(ButtonName))
                {
                    // KeyWords.Xpath_AddSection = StrTempXPath_Addsection;
                    //driver.FindElement(By.XPath(KeyWords.Xpath_AddSection)).Click();
                    driver.FindElement(By.XPath(StrTempXPath_Addsection)).Click();

                    break;
                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given button" + strSelectButtonName + " name not found");
                    results.ErrorMessage = "The given button" + Str_Addsection + " name not found";
                    results.Result1 = KeyWords.Result_FAIL;
                }
            }
            return results;

        }


        public Result select_Button_Invoice2(IWebDriver driver, String locator, String target, String strSelectButtonName, String strXpathExten)
        {
            Result results = new Result();
            Boolean bFlag = false;
            results.Result1 = KeyWords.Result_FAIL;
            try
            {
                ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']" + strXpathExten + ""));
                // ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']//table//tbody//tr//td"));
                List<IWebElement> elements = lis_ClientNames.ToList();

                for (int j = 0; j <= elements.Count - 1; j++)
                {

                    if (elements[j].Text.Trim() == strSelectButtonName.Trim())
                    {
                        bFlag = true;
                        try
                        {

                            driver.FindElement(By.XPath("//*[@" + locator + "='" + target + "']" + strXpathExten)).Click();

                            Thread.Sleep(1000);

                        }
                        catch (Exception)
                        {
                            //
                            bFlag = false;
                        }
                    }
                    if (bFlag)
                    {

                        break;
                    }
                }
                if (bFlag)
                {

                    results.ErrorMessage = "Click on the " + strSelectButtonName;
                    results.Result1 = KeyWords.Result_PASS;
                }
                else
                {

                    results.ErrorMessage = "The given button " + strSelectButtonName + " name not found";
                    results.Result1 = KeyWords.Result_FAIL;
                }
                return results;
            }
            catch (Exception)
            {

                results.ErrorMessage = "Click on the button " + strSelectButtonName + " failed or Exception found";
                results.Result1 = KeyWords.Result_FAIL;
                return results;
            }
        }

        public Result select_Button_Invoice(IWebDriver driver, String locator, String target, String strSelectButtonName, String strXpathExten)
        {
            Result results = new Result();
            Boolean bFlag = false;
            results.Result1 = KeyWords.Result_FAIL;
            try
            {
                ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']" + strXpathExten + ""));
                //ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']"));
                //ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']//table//tbody//tr//td"));
                List<IWebElement> elements = lis_ClientNames.ToList();

                for (int j = 0; j <= elements.Count - 1; j++)
                {

                    if (elements[j].Text.Trim() == strSelectButtonName.Trim())
                    {
                        bFlag = true;
                        try
                        {

                            driver.FindElement(By.XPath("//*[@" + locator + "='" + target + "']" + strXpathExten + "[" + (j + 1) + "]")).Click();

                            Thread.Sleep(1000);

                        }
                        catch (Exception)
                        {
                            //
                            bFlag = false;
                        }
                    }
                    if (bFlag)
                    {

                        break;
                    }
                }
                if (bFlag)
                {

                    results.ErrorMessage = "Click on the " + strSelectButtonName;
                    results.Result1 = KeyWords.Result_PASS;
                }
                else
                {

                    results.ErrorMessage = "The given button " + strSelectButtonName + " name not found";
                    results.Result1 = KeyWords.Result_FAIL;
                }
                return results;
            }
            catch (Exception)
            {

                results.ErrorMessage = "Click on the button " + strSelectButtonName + " failed or Exception found";
                results.Result1 = KeyWords.Result_FAIL;
                return results;
            }
        }

        public Result select_Button_Invoice1(IWebDriver driver, String locator, String target, String strSelectButtonName, String strXpathExten)
        {
            Result results = new Result();
            Boolean bFlag = false;
            results.Result1 = KeyWords.Result_FAIL;
            try
            {
                ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']" + strXpathExten + ""));
                // ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']//table//tbody//tr//td"));
                List<IWebElement> elements = lis_ClientNames.ToList();

                for (int j = 0; j <= elements.Count - 1; j++)
                {

                    if (elements[j].Text.Trim() == strSelectButtonName.Trim())
                    {
                        bFlag = true;
                        try
                        {

                            driver.FindElement(By.XPath("//*[@" + locator + "='" + target + "']" + strXpathExten + "[" + (j + 1) + "]//button")).Click();

                            Thread.Sleep(1000);

                        }
                        catch (Exception)
                        {
                            //

                        }
                    }
                    if (bFlag)
                    {

                        break;
                    }
                }
                if (bFlag)
                {

                    results.ErrorMessage = "Click on the " + strSelectButtonName;
                    results.Result1 = KeyWords.Result_PASS;
                }
                else
                {

                    results.ErrorMessage = "The given button " + strSelectButtonName + " name not found";
                    results.Result1 = KeyWords.Result_FAIL;
                }
                return results;
            }
            catch (Exception)
            {

                results.ErrorMessage = "Click on the button " + strSelectButtonName + " failed or Exception found";
                results.Result1 = KeyWords.Result_FAIL;
                return results;
            }
        }


        public Result select_Button_NVEnergy(IWebDriver driver, String locator, String target, String strSelectButtonName)
        {
            Result results = new Result();
            try
            {
                //IWebElement element = inspect(driver, locator, target,out KeyWords.sLabelName);

                Boolean bFlag = false;

                // sendText1(driver, locator, target, value[i].ToString());

                ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']/input"));

                List<IWebElement> elements = lis_ClientNames.ToList();
                // Console.WriteLine(elements.Count);
                for (int j = 0; j <= elements.Count; j++)
                {
                    //  Console.WriteLine(elements[j].Text.Trim());
                    if (elements[j].Text.Trim() == strSelectButtonName.Trim())
                    {
                        bFlag = true;
                        try
                        {
                            elements[j].Click();
                            // driver.FindElement(By.CssSelector("div.opt.optover")).Click();
                        }
                        catch
                        {
                            //
                        }
                    }
                    if (bFlag)
                    {
                        //Inner for loop break
                        // Console.WriteLine("Button for loop break");
                        break;
                    }
                }




                if (bFlag)
                {
                    // Console.WriteLine("Click on the " + strSelectButtonName);
                    results.ErrorMessage = "Click on the " + strSelectButtonName;
                    results.Result1 = KeyWords.Result_PASS;

                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given button" + strSelectButtonName + " name not found");
                    results.ErrorMessage = "The given button " + strSelectButtonName + " name not found";
                    results.Result1 = KeyWords.Result_FAIL;
                }

                return results;
            }
            catch (Exception)
            {
                // Console.WriteLine("Click on the button " + strSelectButtonName + " failed");
                results.ErrorMessage = "Click on the button " + strSelectButtonName + " failed";
                results.Result1 = KeyWords.Result_FAIL;
            }
            return results;
        }

        public Result select_MSG_Button_Upper(IWebDriver driver, String locator, String target, String strSelectButtonName)
        {
            Result results = new Result();
            try
            {
                //IWebElement element = inspect(driver, locator, target,out KeyWords.sLabelName);
                //  strSelectButtonName = "OK";
                Boolean bFlag = false;
                // strSelectButtonName = "sUbmit";
                //strSelectButtonName = "OK";
                // sendText1(driver, locator, target, value[i].ToString());
                //driver.findElement(By.xpath("//*[contains(@id, 'someId--popup::popupItem') and text()='" + myDesiredValue + "']"))
                //  string st = "//*[contains(@" + locator + ", '" + target + "') and text()[contains(.,'" + strSelectButtonName.Trim().ToLower() + "')]]";
                // ICollection<IWebElement> lis_ClientNames1 =driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']").FindElement(By.XPath(text()[contains(.,'test')])));
                //ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[contains(@" + locator + ", '" + target + "') and text()[contains(lower-case(.),'" + strSelectButtonName.Trim() + "')]]"));
                // ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[contains(@" + locator + ", '" + target + "') and [text()[contains(translate(., 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')," + strSelectButtonName.Trim() + "')]]]"));
                ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[contains(@" + locator + ", '" + target + "') and text()='" + strSelectButtonName.Trim().ToUpper() + "']"));
                // ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']"));

                List<IWebElement> elements = lis_ClientNames.ToList();

                for (int j = 0; j <= elements.Count; j++)
                {
                    if (elements[j].Text.ToLower().Trim() != "")
                    {

                        if (elements[j].Text.ToLower().Trim() == strSelectButtonName.ToLower().Trim())
                        {
                            bFlag = true;
                            try
                            {
                                // elements[j].SendKeys(OpenQA.Selenium.Keys.Enter);
                                elements[j].Click();
                                // driver.FindElement(By.CssSelector("div.opt.optover")).Click();
                            }
                            catch
                            {
                                //  elements[j].Click();
                                elements[j].SendKeys(OpenQA.Selenium.Keys.Enter);
                            }
                        }
                        if (bFlag)
                        {
                            //Inner for loop break
                            // Console.WriteLine("Button for loop break");
                            break;
                        }
                    }
                }




                if (bFlag)
                {
                    // Console.WriteLine("Click on the " + strSelectButtonName);
                    results.ErrorMessage = "Click on the " + strSelectButtonName;
                    results.Result1 = KeyWords.Result_PASS;

                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given button" + strSelectButtonName + " name not found");
                    results.ErrorMessage = "The given button " + strSelectButtonName + " name not found";
                    results.Result1 = KeyWords.Result_FAIL;
                }

                return results;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);

                Console.WriteLine("Click on the button " + strSelectButtonName + " failed");
                results.ErrorMessage = "Click on the button " + strSelectButtonName + " failed";
                results.Result1 = KeyWords.Result_FAIL;
            }
            return results;
        }

        public Result select_MSG_Button_Lower(IWebDriver driver, String locator, String target, String strSelectButtonName)
        {
            Result results = new Result();
            try
            {

                //IWebElement element = inspect(driver, locator, target,out KeyWords.sLabelName);
                //  strSelectButtonName = "OK";
                Boolean bFlag = false;
                // strSelectButtonName = "sUbmit";
                //strSelectButtonName = "OK";
                // sendText1(driver, locator, target, value[i].ToString());
                //driver.findElement(By.xpath("//*[contains(@id, 'someId--popup::popupItem') and text()='" + myDesiredValue + "']"))
                //  string st = "//*[contains(@" + locator + ", '" + target + "') and text()[contains(.,'" + strSelectButtonName.Trim().ToLower() + "')]]";
                // ICollection<IWebElement> lis_ClientNames1 =driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']").FindElement(By.XPath(text()[contains(.,'test')])));
                //ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[contains(@" + locator + ", '" + target + "') and text()[contains(lower-case(.),'" + strSelectButtonName.Trim() + "')]]"));
                // ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[contains(@" + locator + ", '" + target + "') and [text()[contains(translate(., 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')," + strSelectButtonName.Trim() + "')]]]"));
                ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[contains(@" + locator + ", '" + target + "') and text()='" + strSelectButtonName.Trim().ToLower() + "']"));
                // ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']"));

                List<IWebElement> elements = lis_ClientNames.ToList();

                for (int j = 0; j <= elements.Count; j++)
                {
                    if (elements[j].Text.ToLower().Trim() != "")
                    {

                        if (elements[j].Text.ToLower().Trim() == strSelectButtonName.ToLower().Trim())
                        {
                            bFlag = true;
                            try
                            {
                                // elements[j].SendKeys(OpenQA.Selenium.Keys.Enter);
                                elements[j].Click();
                                // driver.FindElement(By.CssSelector("div.opt.optover")).Click();
                            }
                            catch
                            {
                                //  elements[j].Click();
                                elements[j].SendKeys(OpenQA.Selenium.Keys.Enter);
                            }
                        }
                        if (bFlag)
                        {
                            //Inner for loop break
                            // Console.WriteLine("Button for loop break");
                            break;
                        }
                    }
                }




                if (bFlag)
                {
                    // Console.WriteLine("Click on the " + strSelectButtonName);
                    results.ErrorMessage = "Click on the " + strSelectButtonName;
                    results.Result1 = KeyWords.Result_PASS;

                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given button" + strSelectButtonName + " name not found");
                    results.ErrorMessage = "The given button " + strSelectButtonName + " name not found";
                    results.Result1 = KeyWords.Result_FAIL;
                }

                return results;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);

                Console.WriteLine("Click on the button " + strSelectButtonName + " failed");
                results.ErrorMessage = "Click on the button " + strSelectButtonName + " failed";
                results.Result1 = KeyWords.Result_FAIL;
            }
            return results;
        }


        public Result select_MSG_Button(IWebDriver driver, String locator, String target, String strSelectButtonName)
        {
            Result results = new Result();
            try
            {
                //IWebElement element = inspect(driver, locator, target,out KeyWords.sLabelName);
                //  strSelectButtonName = "OK";
                Boolean bFlag = false;
                // strSelectButtonName = "sUbmit";
                //strSelectButtonName = "OK";
                // sendText1(driver, locator, target, value[i].ToString());
                //driver.findElement(By.xpath("//*[contains(@id, 'someId--popup::popupItem') and text()='" + myDesiredValue + "']"))
                //  string st = "//*[contains(@" + locator + ", '" + target + "') and text()[contains(.,'" + strSelectButtonName.Trim().ToLower() + "')]]";
                // ICollection<IWebElement> lis_ClientNames1 =driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']").FindElement(By.XPath(text()[contains(.,'test')])));
                //ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[contains(@" + locator + ", '" + target + "') and text()[contains(lower-case(.),'" + strSelectButtonName.Trim() + "')]]"));
                // ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[contains(@" + locator + ", '" + target + "') and [text()[contains(.,'" + strSelectButtonName.Trim() + "')]]]"));
                ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[contains(@" + locator + ", '" + target + "') and text()='" + strSelectButtonName.Trim() + "']"));
                //  ICollection<IWebElement> lis_ClientNames1 = driver.FindElements(By.XPath("//*[contains(@" + locator + ", '" + target + "') and text()='" + strSelectButtonName.Trim().ToUpper() + "']"));
                // ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']"));

                List<IWebElement> elements = lis_ClientNames.ToList();

                for (int j = 0; j <= elements.Count; j++)
                {
                    if (elements[j].Text.ToLower().Trim() != "")
                    {

                        if (elements[j].Text.ToLower().Trim() == strSelectButtonName.ToLower().Trim())
                        {
                            bFlag = true;
                            try
                            {
                                // elements[j].SendKeys(OpenQA.Selenium.Keys.Enter);
                                elements[j].Click();
                                // driver.FindElement(By.CssSelector("div.opt.optover")).Click();
                            }
                            catch
                            {
                                //  elements[j].Click();
                                elements[j].SendKeys(OpenQA.Selenium.Keys.Enter);
                            }
                        }
                        if (bFlag)
                        {
                            //Inner for loop break
                            // Console.WriteLine("Button for loop break");
                            break;
                        }
                    }
                }




                if (bFlag)
                {
                    // Console.WriteLine("Click on the " + strSelectButtonName);
                    results.ErrorMessage = "Click on the " + strSelectButtonName;
                    results.Result1 = KeyWords.Result_PASS;

                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given button" + strSelectButtonName + " name not found");
                    results.ErrorMessage = "The given button " + strSelectButtonName + " name not found";
                    results.Result1 = KeyWords.Result_FAIL;
                }

                return results;
            }
            catch (Exception)
            {
                //  Console.WriteLine(exp.Message);

                //   Console.WriteLine("Click on the button " + strSelectButtonName + " failed" );
                results.ErrorMessage = "Click on the button " + strSelectButtonName + " failed";
                results.Result1 = KeyWords.Result_FAIL;
            }
            return results;
        }

        //public Result select_MSG_Button_New(IWebDriver driver, String locator, String target, String strSelectButtonName)
        //{
        //    Result results = new Result();
        //    try
        //    {

        //        Boolean bFlag = false;
        //        ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[contains(@" + locator + ", '" + target + "') and text()='" + strSelectButtonName.Trim() + "']"));
        //        ICollection<IWebElement> lis_ClientNames1 = driver.FindElements(By.XPath("//*[contains(@" + locator + ", '" + target + "') and text()='" + strSelectButtonName.Trim().ToUpper() + "']"));


        //    }
        //    catch (Exception)
        //    {
        //        //  Console.WriteLine(exp.Message);

        //        //   Console.WriteLine("Click on the button " + strSelectButtonName + " failed" );
        //        results.ErrorMessage = "Click on the button " + strSelectButtonName + " failed";
        //        results.Result1 = KeyWords.Result_FAIL;
        //    }
        //    return results;
        //}


        
		

        public Result Select_MSG_Button_OK_Click1(IWebDriver driver, String locator, String target, String strComButtonName)
        {
            var results = new Result();

            try
            {
                // bool bFlag = false;
                //ICollection<IWebElement> lis_Button_Names = driver.FindElements(By.XPath("//*[contains(@" + locator + ", '" + target + "') and text()!='']"));
                ICollection<IWebElement> lis_Button_Names = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']"));
                List<IWebElement> elements = lis_Button_Names.ToList();
                // Console.WriteLine(elements.Count);
                for (int i = 0; i <= elements.Count; i++)
                {
                    string strButtonName = elements[i].Text;
                    if (strButtonName.ToLower().Equals(strComButtonName.ToLower().Trim()))
                    {
                        elements[i].Click();
                        //Thread.Sleep(1000);
                        //   bFlag = true;
                        ReportHandler._ChildTest.Log(LogStatus.Pass, "Click on the message button :- " + strButtonName);
                        break;
                    }
                }
                return results;
            }
            catch (Exception ex)
            {
                ReportHandler._ChildTest.Log(LogStatus.Error, ex.Message);
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed Select_MSG_Button_OK_Click Method";
                results.ErrorMessage1 = ex.Message;
                return results;
            }
        }


        public Result Select_MSG_Button_OK_Click(IWebDriver driver, String locator, String target, String strSubMenuName)
        {
            var results = new Result();

            try
            {
                //bool bFlag = false;
                ICollection<IWebElement> lis_Menu_Names = driver.FindElements(By.XPath("//*[contains(@" + locator + ", '" + target + "') and text()='" + strSubMenuName + "']"));
                // ICollection<IWebElement> lis_Menu_Names = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']"));
                List<IWebElement> elements = lis_Menu_Names.ToList();
                // Console.WriteLine(elements.Count);
                for (int i = 0; i <= elements.Count; i++)
                {
                    string strMenuName = elements[i].Text;
                    if (strMenuName.Equals(strSubMenuName))
                    {
                        elements[i].Click();
                        //Thread.Sleep(1000);
                        //    bFlag = true;
                        break;
                    }
                }
                return results;
            }
            catch (Exception ex)
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed Select_MSG_Button_OK_Click Method";
                results.ErrorMessage1 = ex.Message;
                return results;
            }
        }


        public Result Error_Msg_Read_TimeSheet(IWebDriver driver, String locator, String target)
        {
            var results = new Result();

            //Boolean bFlag = false;
            try
            {
                //// Console.WriteLine("//*[@" + locator + "='" + target + "']//li");
                ICollection<IWebElement> lis_Menu_Names = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']//div//div//ul//li"));
                ICollection<IWebElement> lis_Menu_Names1 = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']/div/div/ul/li"));
                List<IWebElement> elements = lis_Menu_Names.ToList();
                // Console.WriteLine(elements.Count);
                string strErrorMsg = "";
                for (int i = 0; i < elements.Count; i++)
                {
                    // Console.WriteLine(elements[i].Text);
                    if (elements[i].Text != "")
                    {
                        if (strErrorMsg != "")
                        {
                            strErrorMsg = strErrorMsg + "," + elements[i].Text;
                        }
                        else
                        {
                            strErrorMsg = elements[i].Text;
                        }
                    }
                }
                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = strErrorMsg;
                return results;
            }
            catch (Exception ex)
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed  Error_Msg_Read Method";
                results.ErrorMessage1 = ex.Message;
                return results;
            }
        }



        public Result Error_Msg_Read(IWebDriver driver, String locator, String target)
        {
            var results = new Result();

            // Boolean bFlag = false;
            try
            {
                //// Console.WriteLine("//*[@" + locator + "='" + target + "']//li");
                ICollection<IWebElement> lis_Menu_Names = driver.FindElements(By.XPath("//*[@" + locator + "='" + target + "']//li"));
                List<IWebElement> elements = lis_Menu_Names.ToList();
                // Console.WriteLine(elements.Count);
                string strErrorMsg = "";
                for (int i = 0; i < elements.Count; i++)
                {
                    // Console.WriteLine(elements[i].Text);
                    if (elements[i].Text != "")
                    {
                        if (strErrorMsg != "")
                        {
                            strErrorMsg = strErrorMsg + "," + elements[i].Text;
                        }
                        else
                        {
                            strErrorMsg = elements[i].Text;
                        }
                    }
                }
                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = strErrorMsg;
                return results;
            }
            catch (Exception ex)
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed  Error_Msg_Read Method";
                results.ErrorMessage1 = ex.Message;
                return results;
            }
        }

        public Result Get_Req_Number(IWebDriver driver, String locator, String target)
        {
            var results = new Result();
            string strReqNumber = "";
            // string strReqNumber1 = "";
            //  Boolean bFlag = false;
            target = "confirmHighlightBox";
            try
            {
                strReqNumber = driver.FindElement(By.XPath("//*[@" + locator + "='" + target + "']")).Text;

            }
            catch (Exception)
            {
                // Console.WriteLine("Problem failed Get_Req_Number Method");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed  Get_Req_Number Method";
                return results;
            }
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = strReqNumber;
            return results;
        }

        public Result Get_Supplier_Email(IWebDriver driver, String Xpathtarget)
        {
            var results = new Result();
            string strEmail = "";
            // string strReqNumber1 = "";
            //  Boolean bFlag = false;

            try
            {
                strEmail = driver.FindElement(By.XPath(Xpathtarget)).Text;
                //strReqNumber1 = driver.FindElement(By.XPath("//*[@" + locator + "='" + target + "']")).GetAttribute("param").;              
            }
            catch (Exception)
            {
                // Console.WriteLine("Problem failed Get_Req_Number Method");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed  Get_Supplier_Email Method";
                return results;
            }
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = strEmail;
            return results;
        }


        public Result Get_Err_Login(IWebDriver driver, String locator, String target)
        {
            var results = new Result();
            string strErrMsg = "";
            //  Boolean bFlag = false;
            try
            {
                strErrMsg = driver.FindElement(By.XPath("//*[@" + locator + "='" + target + "']")).Text;
            }
            catch (Exception)
            {
                // Console.WriteLine("Problem failed Get_Err_Login Method");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed  Get_Err_Login Method";
                return results;
            }
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = strErrMsg;
            return results;
        }

        public Result Total_Req_Links(IWebDriver driver, String locator, String target)
        {

            var results = new Result();
            string strErrMsg = "";
            //  Boolean bFlag = false;
            try
            {
                strErrMsg = driver.FindElement(By.XPath("//*[@" + locator + "='" + target + "']")).Text;
            }
            catch (Exception)
            {
                // Console.WriteLine("Problem failed Select_Req_Link Method");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed Total_Req_Links Method";
                return results;
            }
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = strErrMsg;
            return results;
        }

        public Result Select_RetiredEmployee_Date_From_Picker(IWebDriver driver, String givendat)
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
                //    Console.WriteLine("Year");
                // if (result >= 0)
                // {
                try
                {
                    givendat.Trim();
                    DateTime d = Convert.ToDateTime(givendat);
                    String day = d.Day.ToString();

                    int Month = d.Month;
                    String Year = d.Year.ToString();

                    DateTime date = DateTime.Parse(givendat);
                    System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                    string month = mfi.GetAbbreviatedMonthName(Month);


                    //  driver.FindElement(By.Id(datepickid)).Click();
                    driver.FindElement(By.CssSelector("span.spnretiredEmployee > img.ui-datepicker-trigger")).Click();
                    // driver.FindElement(By.XPath(target)).Click();

                    click(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_trigger);
                    Thread.Sleep(1000);

                    click(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_year);
                    Thread.Sleep(1000);
                    // Console.WriteLine(month);
                    select(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_year, Year);
                    Thread.Sleep(1000);
                    // Console.WriteLine(Convert.ToString(Month));

                    select(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_month, month);
                    Thread.Sleep(1000);
                    click(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_trigger);
                    Thread.Sleep(1000);




                    IWebElement dateWidget = driver.FindElement(By.Id("ui-datepicker-div"));
                    IList<IWebElement> columns = dateWidget.FindElements(By.TagName("td"));
                    foreach (IWebElement item in columns)
                    {
                        if (item.Text.Equals(day))
                        {
                            item.FindElement(By.LinkText(day)).Click();
                            break;
                        }
                    }

                    Thread.Sleep(1000);
                    results.Result1 = KeyWords.Result_PASS;
                    return results;
                }
                catch
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Error encountered while selecting date from datepicker1.";
                    return results;
                }


                //}
                // else
                //{
                //   results.Result1 = KeyWords.Result_FAIL;
                //   results.ErrorMessage = "Given date is less than the current date...";
                //   return results;
                // }
            }
            catch (Exception ex)
            {
                // var res = new Result();
                Console.WriteLine(ex.Message);
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Error encountered while selecting date from datepicker2.";
                return results;
            }
        }

        public Result Select_Start_Date_From_Picker(IWebDriver driver, String givendat)
        {

            var results = new Result();

            try
            {
                String TodayDate = "";
                int TodayDateIntVal = 0;

                if (givendat == "")
                {
                    DateTime CurrentDate = DateTime.Today;
                    TodayDate = CurrentDate.ToString("dd");
                    TodayDateIntVal = Int32.Parse(TodayDate);
                }
                else
                {
                    //  string ds = "25.05.2016";
                    DateTime dt;

                    if (DateTime.TryParseExact(givendat, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out dt))
                    {
                        givendat = dt.ToString("MM/dd/yyyy");
                    }
                    // string strTodayDate = DateTime.Today.ToString("MM/dd/yyyy");
                    DateTime CurrentDate = DateTime.Today;
                    string[] CurrentDate2 = CurrentDate.ToString("MM/dd/yyyy").Split('/');

                    string[] GivenDate = givendat.Split('/');
                    int intMonthCurrent = Int32.Parse(CurrentDate2[0].ToString());
                    int intMonthGiven = Int32.Parse(GivenDate[0].ToString());
                    // if(Int32.TryParse(CurrentDate2[0],) <= 
                    if (intMonthGiven < intMonthCurrent)
                    {
                        System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                        string month = mfi.GetAbbreviatedMonthName(intMonthCurrent);
                        select(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_month, month);
                        Thread.Sleep(1000);

                        TodayDate = CurrentDate2[1];
                    }
                    else
                    {
                        System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                        string month = mfi.GetAbbreviatedMonthName(intMonthGiven);
                        select(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_month, month);
                        Thread.Sleep(1000);
                        TodayDate = GivenDate[1];
                    }
                    TodayDateIntVal = Int32.Parse(TodayDate);
                }

                driver.FindElement(By.LinkText("" + TodayDateIntVal)).Click();
                ReportHandler._ChildTest.Log(LogStatus.Pass, "Date selected :- " + TodayDateIntVal);
                return results;

            }
            catch (Exception ex)
            {
                // var res = new Result();

                ReportHandler._ChildTest.Log(LogStatus.Error, ex.Message);
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Error encountered while selecting date from datepicker2.";
                string screenShotPath = CommonMethods.Capture(driver);
                ReportHandler._ChildTest.Log(LogStatus.Info, "Snapshot below: " + ReportHandler._ChildTest.AddScreenCapture(screenShotPath));
                return results;
            }
        }

        public Result Select_Date_In_DatePicker(IWebDriver driver, String date)
        {
            var results = new Result();
            DateTime CurrentDate = DateTime.Now;

            String TodayDate = CurrentDate.ToString("dd");
            int TodayDateIntVal = Int32.Parse(TodayDate);
            driver.FindElement(By.XPath("//*[@id='ui-datepicker-div']/div")).Click();

            //  int dateIntval = Int32.Parse(date);
            //if (TodayDateIntVal > dateIntval)
            //{
            //    driver.FindElement(By.XPath("//*[@id='ui-datepicker-div']/div/a[2]/span")).Click();
            //    Thread.Sleep(2000);
            //}
            driver.FindElement(By.LinkText("" + TodayDateIntVal)).Click();

            return results;
        }





        public Result Select_Start_Date_From_Picker_MassUpdate(IWebDriver driver, String givendat)
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
                //    Console.WriteLine("Year");
                // if (result >= 0)
                // {
                try
                {
                    givendat.Trim();
                    DateTime d = Convert.ToDateTime(givendat);
                    String day = d.Day.ToString();

                    int Month = d.Month;
                    String Year = d.Year.ToString();

                    DateTime date = DateTime.Parse(givendat);
                    System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                    string month = mfi.GetAbbreviatedMonthName(Month);


                    //  driver.FindElement(By.Id(datepickid)).Click();
                    driver.FindElement(By.XPath(KeyWords.XPATH_Date_datepicker_trigger)).Click();
                    //driver.FindElement(By.CssSelector(KeyWords.CSS_Date_datepicker_trigger)).Click();

                    // driver.FindElement(By.XPath(target)).Click();
                    click(driver, KeyWords.locator_XPath, KeyWords.XPATH_Date_datepicker_trigger);
                    click(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_trigger);
                    Thread.Sleep(1000);

                    click(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_year);
                    Thread.Sleep(1000);
                    // Console.WriteLine(month);
                    select(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_year, Year);
                    Thread.Sleep(1000);
                    // Console.WriteLine(Convert.ToString(Month));

                    select(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_month, month);
                    Thread.Sleep(1000);
                    click(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_trigger);
                    Thread.Sleep(1000);




                    IWebElement dateWidget = driver.FindElement(By.Id("ui-datepicker-div"));
                    IList<IWebElement> columns = dateWidget.FindElements(By.TagName("td"));
                    foreach (IWebElement item in columns)
                    {
                        if (item.Text.Equals(day))
                        {
                            item.FindElement(By.LinkText(day)).Click();
                            break;
                        }
                    }

                    Thread.Sleep(1000);
                    results.Result1 = KeyWords.Result_PASS;
                    return results;
                }
                catch
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Error encountered while selecting date from datepicker1.";
                    return results;
                }


                //}
                // else
                //{
                //   results.Result1 = KeyWords.Result_FAIL;
                //   results.ErrorMessage = "Given date is less than the current date...";
                //   return results;
                // }
            }
            catch (Exception ex)
            {
                // var res = new Result();
                Console.WriteLine(ex.Message);
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Error encountered while selecting date from datepicker2.";
                return results;
            }
        }



        public Result Select_End_Date_From_Picker(IWebDriver driver, String givendat)
        {

            var results = new Result();

            try
            {
                DateTime CurrentDate = DateTime.Now;
                DateTime CurrentDate2 = DateTime.Now;
                CurrentDate2 = CurrentDate.AddDays(190);

                string[] CurrentDateOnly = CurrentDate.ToString("MM/dd/yyyy").Split('/');

                string[] CurrentDateAdded = CurrentDate2.ToString("MM/dd/yyyy").Split('/');
                int intYearCurrent = Int32.Parse(CurrentDateOnly[2].ToString());
                int intYearGiven = Int32.Parse(CurrentDateAdded[2].ToString());
                string TodayDate;
                if (intYearGiven > intYearCurrent)
                {
                    System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                    click(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_year);
                    Thread.Sleep(1000);
                    // Console.WriteLine(month);
                    select(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_year, intYearGiven.ToString());
                    Thread.Sleep(1000);

                    TodayDate = CurrentDateAdded[1];
                }
                else
                {
                    click(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_year);
                    Thread.Sleep(1000);
                    // Console.WriteLine(month);
                    select(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_year, intYearCurrent.ToString());
                    Thread.Sleep(1000);
                    TodayDate = CurrentDateOnly[1];
                }
                //   TodayDateIntVal = Int32.Parse(TodayDate);


                TodayDate = CurrentDate2.ToString("dd");
                int TodayDateIntVal = Int32.Parse(TodayDate);
                // int dateIntval = Int32.Parse(givendat);
                // String ModifiedDate1 = givendat.AddDays(2).ToString("dd");
                driver.FindElement(By.XPath("//*[@id='ui-datepicker-div']/div/a[2]/span")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.LinkText("" + TodayDateIntVal)).Click();
                Thread.Sleep(1000);
                return results;
                //results.Result1 = KeyWords.Result_PASS;
                //TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                //DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                //String currenttime1 = indianTime.ToString("MM/dd/yyyy");

                //DateTime currenttime = Convert.ToDateTime(currenttime1);
                //DateTime giventime = Convert.ToDateTime(givendat);
                //int result = DateTime.Compare(giventime, currenttime);
                //// Console.WriteLine("Year");
                //// if (result >= 0)
                //// {
                //try
                //{
                //    givendat.Trim();
                //    DateTime d = Convert.ToDateTime(givendat);
                //    String day = d.Day.ToString();

                //    int Month = d.Month;
                //    String Year = d.Year.ToString();

                //    DateTime date = DateTime.Parse(givendat);
                //    System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                //    string month = mfi.GetAbbreviatedMonthName(Month);


                //    //  driver.FindElement(By.Id(datepickid)).Click();
                //    //   driver.FindElement(By.CssSelector(KeyWords.CSS_Date_datepicker_trigger)).Click();
                //    // driver.FindElement(By.XPath(target)).Click();
                //    try
                //    {
                //        driver.FindElement(By.XPath(KeyWords.XPath_Date_EndDate)).Click();
                //    }
                //    catch
                //    {
                //        driver.FindElement(By.XPath("//img[@alt='End Date']")).Click();
                //    }
                //    click(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_trigger);
                //    Thread.Sleep(1000);

                //    click(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_year);
                //    Thread.Sleep(1000);
                //    //  Console.WriteLine(month);
                //    select(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_year, Year);
                //    Thread.Sleep(1000);
                //    // Console.WriteLine(Convert.ToString(Month));

                //    select(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_month, month);
                //    Thread.Sleep(1000);
                //    click(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_trigger);
                //    Thread.Sleep(1000);


                //    IWebElement dateWidget = driver.FindElement(By.Id("ui-datepicker-div"));
                //    IList<IWebElement> columns = dateWidget.FindElements(By.TagName("td"));
                //    foreach (IWebElement item in columns)
                //    {
                //        if (item.Text.Equals(day))
                //        {
                //            item.FindElement(By.LinkText(day)).Click();
                //            break;
                //        }


                //    }
                //    //  click(driver, KeyWords.locator_LinkText, day);
                //    Thread.Sleep(1000);
                //    results.Result1 = KeyWords.Result_PASS;
                //    return results;
                //}
                //catch
                //{
                //    results.Result1 = KeyWords.Result_FAIL;
                //    results.ErrorMessage = "Error encountered while selecting date from datepicker1.";
                //    return results;
                //}


                ////}
                //// else
                ////{
                ////   results.Result1 = KeyWords.Result_FAIL;
                ////   results.ErrorMessage = "Given date is less than the current date...";
                ////   return results;
                //// }
            }
            catch
            {

                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Error encountered while selecting date from datepicker2.";
                return results;
            }
        }

        public Result Select_Date_End_Date_From_Picker(IWebDriver driver, String givendat)
        {

            var results = new Result();

            try
            {
                DateTime CurrentDate = DateTime.Now;
                String TodayDate = CurrentDate.ToString("dd");
                int TodayDateIntVal = Int32.Parse(TodayDate);
                // int dateIntval = Int32.Parse(givendat);
                // String ModifiedDate1 = givendat.AddDays(2).ToString("dd");
                driver.FindElement(By.XPath("//*[@id='ui-datepicker-div']/div/a[2]/span")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.LinkText("" + TodayDateIntVal)).Click();
                return results;

            }
            catch
            {

                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Error encountered while selecting date from datepicker2.";
                return results;
            }
        }


        public Result Select_TimeSheet_Date_From_Picker(IWebDriver driver, String givendat)
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
                //    Console.WriteLine("Year");
                // if (result >= 0)
                // {
                try
                {
                    givendat.Trim();
                    DateTime d = Convert.ToDateTime(givendat);
                    String day = d.Day.ToString();

                    int Month = d.Month;
                    String Year = d.Year.ToString();

                    DateTime date = DateTime.Parse(givendat);
                    System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                    string month = mfi.GetAbbreviatedMonthName(Month);


                    //  driver.FindElement(By.Id(datepickid)).Click();
                    //  driver.FindElement(By.CssSelector(KeyWords.CSS_Date_datepicker_trigger)).Click();
                    // driver.FindElement(By.XPath(target)).Click();

                    //   click(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_trigger);
                    //   Thread.Sleep(1000);

                    click(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_year);
                    Thread.Sleep(1000);
                    // Console.WriteLine(month);
                    results = select(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_year, Year);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(1000);
                        results.Result1 = KeyWords.Result_FAIL;
                        results.ErrorMessage = "Unable to select the given Year " + Year;
                        return results;
                    }
                    Thread.Sleep(1000);
                    // Console.WriteLine(Convert.ToString(Month));

                    results = select(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_month, month);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(1000);
                        results.Result1 = KeyWords.Result_FAIL;
                        results.ErrorMessage = "Unable to select the given Month " + month;
                        return results;
                    }
                    Thread.Sleep(1000);
                    click(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_trigger);
                    Thread.Sleep(1000);




                    IWebElement dateWidget = driver.FindElement(By.Id("ui-datepicker-div"));
                    IList<IWebElement> columns = dateWidget.FindElements(By.TagName("td"));
                    foreach (IWebElement item in columns)
                    {
                        if (item.Text.Equals(day))
                        {
                            item.FindElement(By.LinkText(day)).Click();
                            break;
                        }
                    }

                    Thread.Sleep(1000);
                    results.Result1 = KeyWords.Result_PASS;
                    return results;
                }
                catch
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Error encountered while selecting date from Select_TimeSheet_Date_From_Picker.";
                    return results;
                }


                //}
                // else
                //{
                //   results.Result1 = KeyWords.Result_FAIL;
                //   results.ErrorMessage = "Given date is less than the current date...";
                //   return results;
                // }
            }
            catch (Exception ex)
            {
                // var res = new Result();
                Console.WriteLine(ex.Message);
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Error encountered while selecting date from Select_TimeSheet_Date_From_Picker.";
                return results;
            }
        }

        public Result Select_Report_Supplier(IWebDriver driver, String strSelectGeneralLedgerAccount)
        {

            var results = new Result();

            try
            {

                // Thread.Sleep(5000);
                // driver.FindElement(By.XPath("//div[@" + KeyWords.locator_ID + "='" + KeyWords.ID_List_GLId_chosen + "']/a/span")).Click();
                // driver.FindElement(By.XPath("//div[@" + KeyWords.locator_ID + "='" + KeyWords.ID_List_GLId_chosen + "']/div/div/input")).Clear();
                //  string stemp = "";
                Boolean bFlag = false;
                for (int i = 0; i <= strSelectGeneralLedgerAccount.Length; i++)
                {
                    //stemp = stemp + strSelectGeneralLedgerAccount[i].ToString();
                    // Console.WriteLine(stemp);
                    // driver.FindElement(By.XPath("//div[@" + KeyWords.locator_ID + "='" + KeyWords.ID_List_GLId_chosen + "']/div/div/input")).SendKeys(stemp);
                    ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@id='tblFieldData']/div[12]/div/div/div/div/ul/li"));
                    List<IWebElement> elements = lis_ClientNames.ToList();

                    for (int j = 0; j < elements.Count; j++)
                    {
                        if (elements[j].Text.Trim() == strSelectGeneralLedgerAccount.Trim())
                        {
                            bFlag = true;
                            try
                            {
                                elements[j].Click();
                                driver.FindElement(By.CssSelector("div.opt.optover")).Click();
                            }
                            catch
                            {
                                //
                            }
                        }
                        if (bFlag)
                        {
                            //Inner for loop break
                            // Console.WriteLine("Inner for loop break");
                            break;
                        }
                    }
                    if (bFlag)
                    {
                        //Out for loop break
                        // Console.WriteLine("Outer for loop break");
                        break;
                    }
                }
                if (bFlag)
                {
                    //Out for loop break
                    // Console.WriteLine("Outer for loop break");
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Selected the given Select_Report_Supplier";
                    return results;
                    //break;
                }

            }
            catch
            {
                //var res = new Result();
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Unable to select the given Select_Report_Supplier";
                return results;
            }
            results.Result1 = KeyWords.Result_PASS;
            //results.ErrorMessage = strErrMsg;
            return results;
        }

        public Result Select_GLID_Choose(IWebDriver driver, String strSelectGeneralLedgerAccount)
        {

            var results = new Result();

            try
            {

                Thread.Sleep(5000);
                driver.FindElement(By.XPath("//div[@" + KeyWords.locator_ID + "='" + KeyWords.ID_List_GLId_chosen + "']/a/span")).Click();
                driver.FindElement(By.XPath("//div[@" + KeyWords.locator_ID + "='" + KeyWords.ID_List_GLId_chosen + "']/div/div/input")).Clear();
                string stemp = "";
                Boolean bFlag = false;
                for (int i = 0; i <= strSelectGeneralLedgerAccount.Length; i++)
                {
                    stemp = stemp + strSelectGeneralLedgerAccount[i].ToString();
                    // Console.WriteLine(stemp);
                    driver.FindElement(By.XPath("//div[@" + KeyWords.locator_ID + "='" + KeyWords.ID_List_GLId_chosen + "']/div/div/input")).SendKeys(stemp);
                    ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//div[@" + KeyWords.locator_ID + "='" + KeyWords.ID_List_GLId_chosen + "']/div/ul/li"));
                    List<IWebElement> elements = lis_ClientNames.ToList();

                    for (int j = 0; j < elements.Count; j++)
                    {
                        if (elements[j].Text.Trim() == strSelectGeneralLedgerAccount.Trim())
                        {
                            bFlag = true;
                            try
                            {
                                elements[j].Click();
                                driver.FindElement(By.CssSelector("div.opt.optover")).Click();
                            }
                            catch
                            {
                                //
                            }
                        }
                        if (bFlag)
                        {
                            //Inner for loop break
                            // Console.WriteLine("Inner for loop break");
                            break;
                        }
                    }
                    if (bFlag)
                    {
                        //Out for loop break
                        // Console.WriteLine("Outer for loop break");
                        break;
                    }
                }
                if (bFlag)
                {
                    //Out for loop break
                    // Console.WriteLine("Outer for loop break");
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Selected the given GL code";
                    return results;
                    //break;
                }

            }
            catch
            {
                //var res = new Result();
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Unable to select the given GL code";
                return results;
            }
            results.Result1 = KeyWords.Result_PASS;
            //results.ErrorMessage = strErrMsg;
            return results;
        }

        public Result Select_strSelecttxtChargeNumber_Choose(IWebDriver driver, String strSelecttxtChargeNumber)
        {

            var results = new Result();

            try
            {

                Thread.Sleep(5000);
                driver.FindElement(By.XPath("//div[@" + KeyWords.locator_ID + "='" + KeyWords.ID_Select_txtChargeNumber + "']/a/span")).Click();
                driver.FindElement(By.XPath("//div[@" + KeyWords.locator_ID + "='" + KeyWords.ID_Select_txtChargeNumber + "']/div/div/input")).Clear();
                string stemp = "";
                Boolean bFlag = false;
                for (int i = 0; i <= strSelecttxtChargeNumber.Length; i++)
                {
                    stemp = stemp + strSelecttxtChargeNumber[i].ToString();
                    // Console.WriteLine(stemp);
                    driver.FindElement(By.XPath("//div[@" + KeyWords.locator_ID + "='" + KeyWords.ID_Select_txtChargeNumber + "']/div/div/input")).SendKeys(stemp);
                    ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//div[@" + KeyWords.locator_ID + "='" + KeyWords.ID_Select_txtChargeNumber + "']/div/ul/li"));
                    List<IWebElement> elements = lis_ClientNames.ToList();

                    for (int j = 0; j < elements.Count; j++)
                    {
                        if (elements[j].Text.Trim() == strSelecttxtChargeNumber.Trim())
                        {
                            bFlag = true;
                            try
                            {
                                elements[j].Click();
                                driver.FindElement(By.CssSelector("div.opt.optover")).Click();
                            }
                            catch
                            {
                                //
                            }
                        }
                        if (bFlag)
                        {
                            //Inner for loop break
                            // Console.WriteLine("Inner for loop break");
                            break;
                        }
                    }
                    if (bFlag)
                    {
                        //Out for loop break
                        // Console.WriteLine("Outer for loop break");
                        break;
                    }
                }
                if (bFlag)
                {
                    //Out for loop break
                    // Console.WriteLine("Outer for loop break");
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Selected the given strSelecttxtChargeNumber";
                    return results;
                    //break;
                }

            }
            catch
            {
                //var res = new Result();
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Unable to select the given Select_strSelecttxtChargeNumber_Choose";
                return results;
            }
            results.Result1 = KeyWords.Result_PASS;
            //results.ErrorMessage = strErrMsg;
            return results;
        }

        public Result Logout_Link_Click(IWebDriver driver)
        {

            var results = new Result();
            string strErrMsg = "";
            //  Boolean bFlag = false;
            try
            {
                //click(driver, KeyWords.locator_XPath, KeyWords.CSS_Link_logout);
                driver.FindElement(By.XPath("//span[@class='spnUserFirstName']/following-sibling::span[@class='caret']")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//span[@class='sprite logoutSprite pull-left']/following-sibling::span[@class='d-inline']")).Click();
                Thread.Sleep(1000);
            }
            catch (Exception)
            {
                // Console.WriteLine("Problem failed Logout_Link_Click Method";
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed Logout_Link_Click Method";
                return results;
            }
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = strErrMsg;
            return results;
        }


        public Result Logout_Link_Click_NewUI(IWebDriver driver, String strProfileLogout)
        {

            var results = new Result();
            string strErrMsg = "";
            //  Boolean bFlag = false;
            try
            {
                // Thread.Sleep(5000);
                driver.FindElement(By.XPath("//span[@class='spnUserFirstName']/following-sibling::span[@class='caret']")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//span[@class='sprite logoutSprite pull-left']/following-sibling::span[@class='d-inline']")).Click();
                Thread.Sleep(1000);
                Actions action = new Actions(driver);
                Boolean bLogoutFind = false;
                for (int j = 7; j < 12; j++)
                {
                    // j = 8;
                    string strXPath = "//ul[@id='gn-menu']/li[" + j + "]/div/a";
                    //   string s = driver.FindElement(By.XPath(strXPath)).GetAttribute("data-content");

                    string strXPath1 = "//ul[@id='gn-menu']/li[" + j + "]";
                    string strProfile = driver.FindElement(By.XPath(strXPath1)).GetAttribute("data-content");

                    if ("Your Profile" == strProfile)
                    {
                        IWebElement we = driver.FindElement(By.XPath(strXPath));
                        action.MoveToElement(we).Build().Perform();
                        Thread.Sleep(5000);
                        //driver.FindElement(By.XPath("//ul[@id='gn-menu']/li[9]/div/a/span")).Click();// working
                        driver.FindElement(By.XPath(strXPath)).Click();

                        Thread.Sleep(2000);
                        // data-content
                        ICollection<IWebElement> lis_ProfileMenu_Names = driver.FindElements(By.XPath(KeyWords.XPath_ProfileMenu));
                        List<IWebElement> elements = lis_ProfileMenu_Names.ToList();

                        for (int i = 0; i < elements.Count; i++)
                        {
                            string strProfileMenuName = elements[i].Text;
                            if (strProfileMenuName.ToLower().Equals(strProfileLogout.ToLower()))
                            {
                                bLogoutFind = true;
                                elements[i].FindElement(By.XPath("./a")).Click();
                                // driver.FindElement(By.XPath(KeyWords.XPath_ProfileMenu+"[" + (i + 1) + "]/a")).Click();
                                //elements[i].Click();
                                //elements[i].FindElement(By.XPath

                                Thread.Sleep(1000);
                            }
                            if (bLogoutFind)
                            {
                                break;
                            }
                        }//for i close
                        if (bLogoutFind)
                        {
                            break;
                        }

                        if (!bLogoutFind)
                        {
                            results.Result1 = KeyWords.Result_FAIL;
                            results.ErrorMessage = "Logout is not find in the profile menu";
                            return results;
                        }
                    }// if close
                    Thread.Sleep(2000);
                }// for J close
            }//try close
            catch (Exception)
            {
                // Console.WriteLine("Problem failed Logout_Link_Click Method";
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed Logout_Link_Click Method";
                return results;
            }
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = strErrMsg;
            return results;
        }

        public Result REQ_Link_Click(IWebDriver driver, int intReqlistcount, string str_Link_ReqNumber)
        {

            var results = new Result();
            string strreqlnk = "";
            int k = 0;
            Boolean bFlag = false;
            try
            {
                for (int i = 1; i <= intReqlistcount; i++)
                {
                    k = k + 1;
                    strreqlnk = driver.FindElement(By.XPath("//table[@" + KeyWords.locator_ID + "='" + KeyWords.ID_List_regReqList + "']/tbody/tr[" + k + "]/td[2]/a")).Text;

                    if (str_Link_ReqNumber == strreqlnk)
                    {
                        bFlag = true;
                        break;
                    }
                    if ((k == 10) && (k < intReqlistcount))
                    {
                        k = 0;
                        //WDriver.FindElement(By.Id("regReqList_next")).Click();
                        click(driver, KeyWords.locator_ID, KeyWords.ID_List_regReqList_next);
                        Thread.Sleep(10000);
                    }
                }

                if (bFlag)
                {
                    driver.FindElement(By.XPath("//table[@" + KeyWords.locator_ID + "='" + KeyWords.ID_List_regReqList + "']/tbody/tr[" + k + "]/td[2]/a")).Click();
                }
                else
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = KeyWords.MSG_strRequirementNumberNotFind + " " + str_Link_ReqNumber;
                    return results;
                }
            }
            catch
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem identifying the REQ link in REQ_Link_Click Method";
                return results;

            }
            results.Result1 = KeyWords.Result_PASS;
            //results.ErrorMessage = strErrMsg;
            return results;
        }

        public Result Selected_Email_Supplier_Count1(IWebDriver driver, string strXPath)
        {

            var results = new Result();
            int iCount = 0;

            try
            {
                //iCount = driver.FindElements(By.XPath("//table[@" + KeyWords.locator_ID + "='" + KeyWords.ID_ListInfo_HistoryTableViewSuppReqs + "']/tbody/tr")).Count;
                iCount = driver.FindElements(By.XPath(strXPath)).Count;



            }
            catch
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem identifying the Selected Email in Selected_Email_Supplier_Count Method";
                return results;

            }

            if (iCount <= 0)
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "No records found";
            }
            else
            {
                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = iCount.ToString();
            }
            return results;
        }

        public Result Selected_Email_Supplier_Count(IWebDriver driver, string strXPath)
        {

            var results = new Result();
            int iCount = 0;

            try
            {
                //iCount = driver.FindElements(By.XPath("//table[@" + KeyWords.locator_ID + "='" + KeyWords.ID_ListInfo_HistoryTableViewSuppReqs + "']/tbody/tr")).Count;
                IWebElement ele = driver.FindElement(By.XPath(strXPath));
                iCount = ele.FindElements(By.TagName("td")).Count;
                //  iCount = driver.FindElements(By.XPath(strXPath)).Count;


            }
            catch
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem identifying the Selected Email in Selected_Email_Supplier_Count Method";
                return results;

            }

            if (iCount <= 0)
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "No records found";
            }
            else
            {
                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = iCount.ToString();
            }
            return results;
        }

        public Result REQ_Link_Candidate_Count(IWebDriver driver, string strXPath)
        {

            var results = new Result();
            int iCount = 0;

            try
            {
                iCount = driver.FindElements(By.XPath(strXPath)).Count;
            }
            catch
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem identifying the REQ link in REQ_Link_Candidate_Count Method";
                return results;

            }

            if (iCount <= 0)
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "No records found";
            }
            else
            {
                if (iCount == 1)
                {
                    Boolean bInfo = false;
                    try
                    {
                        bInfo = driver.FindElement(By.Id("regularCandidateListWithOffer_info")).Displayed;
                    }
                    catch
                    {
                        bInfo = false;
                    }
                    if (bInfo)
                    {
                        string strNoData = "";
                        try
                        {
                            strNoData = driver.FindElement(By.Id("regularCandidateListWithOffer_info")).Text;
                        }
                        catch
                        {
                            strNoData = "";
                        }
                        if ("Showing 0 to 0 of 0 entries" == strNoData)
                        {
                            iCount = 0;
                            results.Result1 = KeyWords.Result_FAIL;
                            results.ErrorMessage = "No records found";
                        }
                        else
                        {
                            results.Result1 = KeyWords.Result_PASS;
                            results.ErrorMessage = iCount.ToString();
                        }
                    }
                    else
                    {
                        results.Result1 = KeyWords.Result_PASS;
                        results.ErrorMessage = iCount.ToString();
                    }
                }
                else
                {
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = iCount.ToString();
                }
            }
            return results;
        }

        public Result REQ_Link_InvoiceBatch_Count(IWebDriver driver, string strXPath)
        {

            var results = new Result();
            int iCount = 0;

            try
            {
                iCount = driver.FindElements(By.XPath(strXPath)).Count;
            }
            catch
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem identifying the REQ link in REQ_Link_InvoiceBatch_Count Method";
                return results;

            }

            if (iCount <= 0)
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "No records found";
            }
            else
            {
                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = iCount.ToString();
            }
            return results;
        }

        //public Result add_TS_Task1(IWebDriver driver, String UnitNumberValue, String HoursType, String Shift, String ChargeNumber, string clientname)
        //{

        //    Result results = new Result();

        //    //Enter Unit number in Unit number text box
        //    sendText(driver, KeyWords.locator_ID, KeyWords.ID_Txt_txtGen1, UnitNumberValue, false);
        //    Thread.Sleep(500);

        //    // Select Hours type from "Hours type" drop down.

        //    results = select(driver, KeyWords.locator_ID, KeyWords.ID_Select_DefaultContent_CboHoursType, HoursType);
        //    if (results.Result1 == KeyWords.Result_FAIL)
        //    {
        //        try
        //        {
        //            results = selectDynamicDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_Select_DefaultContent_CboHoursType);
        //        }
        //        catch
        //        {
        //            results.Result1 = KeyWords.Result_FAIL;
        //            return results;
        //        }
        //    }

        //    // Choose charge number from charge# typoahead

        //    if (clientname == "Arizona Public Service")
        //    {
        //        Thread.Sleep(1000);
        //        results = select_List_typeahead(driver, KeyWords.locator_ID, KeyWords.ID_TS_ChargeNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, ChargeNumber, ChargeNumber);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            results = select_List_typeahead_AnyOne(driver, KeyWords.locator_ID, KeyWords.ID_TS_ChargeNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, ChargeNumber, ChargeNumber);
        //            //  return results;
        //        }
        //    }
        //    else
        //    {
        //        //shift
        //        results = select(driver, KeyWords.locator_ID, KeyWords.ID_Select_DefaultContent_CboShifts, Shift);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            try
        //            {
        //                results = selectDynamicDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_Select_DefaultContent_CboShifts);
        //            }
        //            catch
        //            {
        //                results.Result1 = KeyWords.Result_FAIL;
        //                return results;
        //            }
        //        }
        //        //Charge number 
        //        results = select(driver, KeyWords.locator_ID, KeyWords.ID_Select_DefaultContent_cboChargeNumber, ChargeNumber);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            try
        //            {
        //                results = selectDynamicDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_Select_DefaultContent_cboChargeNumber);
        //            }
        //            catch
        //            {
        //                results.Result1 = KeyWords.Result_FAIL;
        //                return results;
        //            }
        //        }
        //    }

        //    Thread.Sleep(1000);
        //    // Click on Add Task button
        //    driver.FindElement(By.Id(KeyWords.ID_Btn_DefaultContent_btnAddTask)).Click();

        //    // Wait until add task to be clickable
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));
        //    wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_Btn_DefaultContent_btnAddTask))));
        //    wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_Btn_DefaultContent_btnAddTask))));

        //    return results;
        //}
        //public Result add_TS_Task(IWebDriver driver, String UnitNumberValue, String HoursType, String Shift, String ChargeNumber, String TashHoursEnter, string clientname, int row)
        //{
        //    string str_Data_AddTasks = "";
        //    Result results = new Result();
        //    KeyWordMethods kwm = new KeyWordMethods();
        //    var resultsTimeEnter = new Result();
        //    CommonMethods objCommonMethods = new CommonMethods();
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(KeyWords.ExplicitWaitTime));
        //    int iRowiscreated = row + 1;
        //    Thread.Sleep(1500);


        //    //Enter Unit number in Unit number text box

        //    results = sendText(driver, KeyWords.locator_ID, KeyWords.ID_Txt_txtGen1, UnitNumberValue, false);
        //    if (results.Result1 == KeyWords.Result_FAIL)
        //    {
        //        try
        //        {
        //            results = sendText(driver, KeyWords.locator_ID, KeyWords.ID_Txt_txtGen1, UnitNumberValue, false);
        //        }
        //        catch
        //        {
        //            results.Result1 = KeyWords.Result_FAIL;
        //            return results;
        //        }
        //    }
        //    Thread.Sleep(500);

        //    // Select Hours type from "Hours type" drop down.

        //    results = select(driver, KeyWords.locator_ID, KeyWords.ID_Select_DefaultContent_CboHoursType, HoursType);
        //    //Time of Policy 
        //    if (HoursType == "Holiday Hours" && (clientname == "ARKEMA" || clientname == "SUPERVALU" || clientname == "SALLIE MAE"))
        //    {
        //        results = selectDynamicDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_Select_TimeofPolicy);
        //    }
        //    if (results.Result1 == KeyWords.Result_FAIL)
        //    {
        //        try
        //        {
        //            results = selectDynamicDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_Select_DefaultContent_CboHoursType);
        //        }
        //        catch
        //        {
        //            results.Result1 = KeyWords.Result_FAIL;
        //            return results;
        //        }
        //    }

        //    // Choose charge number from charge# typoahead

        //    Thread.Sleep(500);
        //    if (clientname == "Arizona Public Service")
        //    {
        //        results = select_List_typeahead(driver, KeyWords.locator_ID, KeyWords.ID_TS_ChargeNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, ChargeNumber, ChargeNumber);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            results = select_List_typeahead_Timesheet_AnyOne(driver, KeyWords.locator_ID, KeyWords.ID_TS_ChargeNumber, KeyWords.locator_class, KeyWords.CL_list_typeahead, ChargeNumber, ChargeNumber);
        //            //  return results;
        //        }
        //    }
        //    else
        //    {
        //        //shift
        //        results = select(driver, KeyWords.locator_ID, KeyWords.ID_Select_DefaultContent_CboShifts, Shift);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            try
        //            {
        //                results = selectDynamicDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_Select_DefaultContent_CboShifts);
        //            }
        //            catch
        //            {
        //                results.Result1 = KeyWords.Result_FAIL;
        //                return results;
        //            }
        //        }

        //        //Charge number 
        //        results = select(driver, KeyWords.locator_ID, KeyWords.ID_Select_DefaultContent_cboChargeNumber, ChargeNumber);
        //        if (results.Result1 == KeyWords.Result_FAIL)
        //        {
        //            try
        //            {
        //                results = selectDynamicDropdownByValue(driver, KeyWords.locator_ID, KeyWords.ID_Select_DefaultContent_cboChargeNumber);
        //            }
        //            catch
        //            {
        //                results.Result1 = KeyWords.Result_FAIL;
        //                return results;
        //            }
        //        }
        //    }

        //    Thread.Sleep(500);
        //    // Click on Add Task button
        //    driver.FindElement(By.Id(KeyWords.ID_Btn_DefaultContent_btnAddTask)).Click();

        //    // Wait until add task to be clickable

        //    wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_Btn_DefaultContent_btnAddTask))));
        //    wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_Btn_DefaultContent_btnAddTask))));

        //    Thread.Sleep(2000);
        //    objCommonMethods.Action_Page_Down(driver);
        //    Thread.Sleep(500);
        //    objCommonMethods.Action_Page_Down(driver);


        //    // Enter Time

        //    // string[] separators = { "#" };
        //    String[] hours = TashHoursEnter.Split('#');
        //    //var hours = TashHoursEnter.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        //    string strTaskTime = "";
        //    Thread.Sleep(1000);

        //    if (hours.Length >= 1)
        //    {
        //        for (int j = 0; j <= hours.Length - 1; j++)
        //        {
        //            strTaskTime = "";
        //            strTaskTime = hours[j].ToString().Trim();

        //            Boolean bTxtBoxEnable = false;
        //            for (int e = 1; e <= 60; e++)
        //            {
        //                try
        //                {
        //                    Thread.Sleep(3000);
        //                    bTxtBoxEnable = driver.FindElement(By.Id("txtH" + (j + 1) + iRowiscreated)).Enabled;
        //                }
        //                catch
        //                {

        //                }
        //                if (bTxtBoxEnable)
        //                    break;
        //            }
        //            if (strTaskTime == "0")
        //            {
        //                objCommonMethods.Action_Button_Tab(driver);
        //                if (!waitForElementInvisible(driver, KeyWords.by_Loading_Message, kwm._WDWait))
        //                {
        //                    waitForElementInvisible(driver, KeyWords.by_Loading_Message, kwm._WDWait);
        //                }

        //                // Thread.Sleep(1000);
        //                objCommonMethods.Action_Page_Down(driver);
        //                objCommonMethods.Action_Page_Down(driver);
        //            }
        //            else
        //            {
        //                if (clientname == "YP")
        //                {
        //                    string ypworkschedule;
        //                    ypworkschedule = driver.FindElement(By.Id("DefaultContent_CboWorkSchedule")).Text.Trim();
        //                    String[] separatorscomma = strTaskTime.Split(',');
        //                    if (ypworkschedule == "YP_Inout")
        //                    {
        //                        objCommonMethods.Action_Page_Down(driver);
        //                        objCommonMethods.Action_Page_Down(driver);
        //                        if (!driver.FindElement(By.Id("txtST" + (j + 1) + iRowiscreated)).Displayed)
        //                        {
        //                            objCommonMethods.Action_Page_Down(driver);
        //                        }

        //                        resultsTimeEnter = kwm.click(driver, KeyWords.locator_ID, "txtST" + (j + 1) + iRowiscreated);
        //                        // Thread.Sleep(2000);
        //                        resultsTimeEnter = kwm.sendText(driver, KeyWords.locator_ID, "txtStarttime", separatorscomma[0], false);
        //                        resultsTimeEnter = kwm.sendText(driver, KeyWords.locator_ID, "txtEndTime", separatorscomma[1], false);
        //                        //click on save
        //                        results = kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, "Save");
        //                        if (results.Result1 == KeyWords.Result_FAIL)
        //                        {
        //                            Thread.Sleep(3000);
        //                            results = kwm.select_MSG_Button(driver, KeyWords.locator_type, KeyWords.locator_button, "Save");
        //                            if (results.Result1 == KeyWords.Result_FAIL)
        //                            {
        //                                return results;
        //                            }
        //                        }
        //                    }
        //                    else if (driver.FindElement(By.XPath("//*[contains(@class,'lsLoader')]")).Displayed && driver.FindElement(By.Id("txtGen1")).Enabled)
        //                    {
        //                        if (!waitForElementInvisible(driver, KeyWords.by_Loading_Message, kwm._WDWait))
        //                        {
        //                            waitForElementInvisible(driver, KeyWords.by_Loading_Message, kwm._WDWait);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        resultsTimeEnter = kwm.sendText(driver, KeyWords.locator_ID, "txtH" + (j + 1) + iRowiscreated, separatorscomma[0], false);
        //                    }

        //                }
        //                else
        //                {
        //                    Thread.Sleep(2000);
        //                    resultsTimeEnter = kwm.sendText(driver, KeyWords.locator_ID, "txtH" + (j + 1) + iRowiscreated, strTaskTime, false);
        //                }
        //                Thread.Sleep(3000);
        //            }


        //            if (resultsTimeEnter.Result1 == KeyWords.Result_FAIL)
        //            {
        //                //Console.WriteLine("Time entered failed " + strTaskTime);
        //                resultsTimeEnter = kwm.sendText(driver, KeyWords.locator_ID, "txtH" + (j + 1) + iRowiscreated, strTaskTime, false);
        //                if (resultsTimeEnter.Result1 == KeyWords.Result_FAIL)
        //                {
        //                    Boolean blndivlsLoader = false;
        //                    for (int e = 1; e <= 60; e++)
        //                    {
        //                        try
        //                        {
        //                            blndivlsLoader = driver.FindElement(By.XPath("//*[@id='divlsLoader']/div")).Displayed;
        //                        }
        //                        catch
        //                        {
        //                            //blndivlsLoader = true;
        //                        }

        //                        if (!blndivlsLoader)
        //                            break;
        //                    }
        //                    resultsTimeEnter = kwm.sendText(driver, KeyWords.locator_ID, "txtH" + (j + 1) + iRowiscreated, strTaskTime, false);
        //                    if (resultsTimeEnter.Result1 == KeyWords.Result_FAIL)
        //                    {
        //                        Console.WriteLine("Time entered failed " + strTaskTime);
        //                    }
        //                }
        //            }
        //            Thread.Sleep(1000);
        //        }
        //        objCommonMethods.Action_Button_Tab(driver);
        //        Thread.Sleep(2000);
        //        objCommonMethods.Action_Button_Tab(driver);
        //        // Thread.Sleep(2000);

        //        // driver.FindElement(By.Id(KeyWords.ID_Txt_txtGen1)).Click();
        //        if (!waitForElementInvisible(driver, KeyWords.by_Loading_Message, kwm._WDWait))
        //        {
        //            waitForElementInvisible(driver, KeyWords.by_Loading_Message, kwm._WDWait);
        //        }
        //        //Loading Message
        //        for (int z = 1; z < 600; z++)
        //        {
        //            Boolean strValue = true;
        //            try
        //            {
        //                strValue = driver.FindElement(By.Id("loading-message")).Displayed;
        //            }
        //            catch
        //            {
        //                strValue = true;
        //            }

        //            if (!strValue)
        //            {
        //                break;
        //            }
        //            Thread.Sleep(1000);
        //        }
        //        Thread.Sleep(2000);
        //    }

        //    objCommonMethods.Action_Page_UP(driver);
        //    Thread.Sleep(500);
        //    objCommonMethods.Action_Page_UP(driver);
        //    Thread.Sleep(1000);

        //    return results;

        //}
        public Result TS_Link_CWNumber_Count(IWebDriver driver, string strXPath)
        {

            var results = new Result();
            int iCount = 0;

            try
            {
                //iCount = driver.FindElements(By.XPath("//table[@" + KeyWords.locator_ID + "='" + KeyWords.ID_ListInfo_HistoryTableViewSuppReqs + "']/tbody/tr")).Count;
                iCount = driver.FindElements(By.XPath(strXPath)).Count;
            }
            catch
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem identifying the REQ link in REQ_Link_Candidate_Count Method";
                return results;

            }

            if (iCount <= 0)
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "No records found";
            }
            else
            {
                if (iCount == 1)
                {
                    string strNoData = driver.FindElement(By.XPath(strXPath + "/td")).Text;
                    if ("No matching records found" == strNoData)
                    {
                        iCount = 0;
                    }

                    try
                    {
                        strNoData = driver.FindElement(By.Id("DefaultContent_LblNRecFound")).Text;
                    }
                    catch
                    {
                        strNoData = "";
                    }
                    if ("Sorry, No Records Found" == strNoData)
                    {
                        iCount = 0;
                    }
                }

                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = iCount.ToString();
            }
            return results;
        }

        public Boolean waitForElementInvisible(IWebDriver driver, By ele_Locator, WebDriverWait _WaitDriver)
        {

            try
            {

                _WaitDriver.Until(ExpectedConditions.InvisibilityOfElementLocated(ele_Locator));

                if (driver.FindElement(ele_Locator).Displayed)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception e)
            {

                return false;
            }


        }
        public Result GetNameFromReqNumber(string FNorLN, string str_Link_ReqNumber)
        {

            var results = new Result();
            string strFNorLN = "";
            try
            {
                int index1 = str_Link_ReqNumber.IndexOf('-');
                int index2 = str_Link_ReqNumber.IndexOf('-', index1 + 1);
                strFNorLN = str_Link_ReqNumber.Remove(index1, index2 - index1 + 1);
                strFNorLN = FNorLN + strFNorLN;
            }
            catch
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem identifying in GetNameFromReqNumber Method";
                return results;

            }
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = strFNorLN;
            return results;
        }

        public Result CW_REQ_Link_Click(IWebDriver driver, string strXpath)
        {

            var results = new Result();

            try
            {
                //strreqlnk = driver.FindElement(By.XPath("//table[@" + KeyWords.locator_ID + "='" + KeyWords.ID_ListInfo_HistoryTableViewSuppReqs + "']/tbody/tr[" + intReqlistcount + "]/td/a")).Text;
                driver.FindElement(By.XPath(strXpath)).Click();
            }
            catch
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem identifying the REQ link in CW_REQ_Link_Click Method";
                return results;

            }
            results.Result1 = KeyWords.Result_PASS;
            //results.ErrorMessage = strErrMsg;
            return results;
        }
        public Result CW_REQ_Link_Get_Text(IWebDriver driver, string strXpath)
        {

            var results = new Result();
            string strMsg = "";
            try
            {
                //strreqlnk = driver.FindElement(By.XPath("//table[@" + KeyWords.locator_ID + "='" + KeyWords.ID_ListInfo_HistoryTableViewSuppReqs + "']/tbody/tr[" + intReqlistcount + "]/td/a")).Text;
                strMsg = driver.FindElement(By.XPath(strXpath)).Text;
            }
            catch
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem identifying the REQ link in CW_REQ_Link_Click Method";
                return results;

            }
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = strMsg;
            return results;
        }


        public Result REQ_Link_Candidate_Click(IWebDriver driver, int intReqlistcount, string str_Link_ReqNumber)
        {

            var results = new Result();

            try
            {
                //strreqlnk = driver.FindElement(By.XPath("//table[@" + KeyWords.locator_ID + "='" + KeyWords.ID_ListInfo_HistoryTableViewSuppReqs + "']/tbody/tr[" + intReqlistcount + "]/td/a")).Text;
                driver.FindElement(By.XPath("//table[@" + KeyWords.locator_ID + "='" + KeyWords.ID_ListInfo_HistoryTableViewSuppReqs + "']/tbody/tr[" + intReqlistcount + "]/td/a")).Click();
            }
            catch
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem identifying the REQ link in REQ_Link_Candidate_Click Method";
                return results;

            }
            results.Result1 = KeyWords.Result_PASS;
            //results.ErrorMessage = strErrMsg;
            return results;
        }

        public Result Supplier_Table_CheckBox_Click(IWebDriver driver, string str_CheckBox_Suppliers, char strDelimiter1, char strDelimiter2, int intColumanEmailID)
        {

            var results = new Result();
            string[] listSuppliers;
            Boolean bSelectionSupplier = false;
            try
            {
                listSuppliers = str_CheckBox_Suppliers.Split(strDelimiter1);
                if (listSuppliers.Length > 0)
                {

                    for (int ls = 0; ls < listSuppliers.Length; ls++)
                    {
                        string strEmailID = listSuppliers[ls];
                        ReadOnlyCollection<IWebElement> allTheRows = driver.FindElements(By.XPath("//table[@" + KeyWords.locator_ID + "='" + KeyWords.ID_Table_tblSuppliers + "']/tbody/tr"));
                        List<IWebElement> elementstr = allTheRows.ToList();
                        for (int i = 0; i < elementstr.Count; i++)
                        {
                            string strAppEmailID = "";
                            ReadOnlyCollection<IWebElement> allTheCols = elementstr[i].FindElements(By.TagName("td"));
                            List<IWebElement> elementstd = allTheCols.ToList();
                            for (int j = 0; j < elementstd.Count; j++)
                            {
                                if (j == 0)
                                {
                                    //Console.WriteLine(elementstd[0].FindElement(By.TagName("input")).GetAttribute("id"));
                                }
                                else
                                {
                                    strAppEmailID = elementstd[intColumanEmailID].Text;
                                }
                                if (strAppEmailID.Trim().ToLower() == strEmailID.Trim().ToLower())
                                {
                                    elementstr[i].FindElement(By.XPath("./td/input")).Click();
                                    bSelectionSupplier = true;
                                }
                            }
                            if (bSelectionSupplier)
                                break;
                        }
                    }

                }
            }
            catch
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem with this Supplier_Table_CheckBox_Click Method";
                return results;
            }
            results.Result1 = KeyWords.Result_PASS;
            results.blnFlag = bSelectionSupplier;
            return results;
        }

        public Result Supplier_Table_CheckBox_Top10_Click(IWebDriver driver)
        {

            var results = new Result();
            // string[] listSuppliers;
            Boolean bSelectionSupplier1 = false;
            try
            {


                // Boolean bSelectionSupplier = false;
                ReadOnlyCollection<IWebElement> allTheRows = driver.FindElements(By.XPath("//table[@" + KeyWords.locator_ID + "='" + KeyWords.ID_Table_tblSuppliers + "']/tbody/tr"));
                List<IWebElement> elementstr = allTheRows.ToList();
                for (int i = 0; i < elementstr.Count; i++)
                {


                    elementstr[i].FindElement(By.XPath("./td/input")).Click();
                    bSelectionSupplier1 = true;


                    if (i == 10)
                        break;
                }

            }
            catch
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem with this Supplier_Table_CheckBox_Click Method";
                return results;
            }
            // Console.WriteLine("bSelectionSupplier1");
            //Console.WriteLine(bSelectionSupplier1);
            results.Result1 = KeyWords.Result_PASS;
            results.blnFlag = bSelectionSupplier1;
            return results;
        }

        public Result MassUpdate_Table_CheckBox_Top5_Click(IWebDriver driver)
        {

            var results = new Result();
            Boolean bmassupdate = false;
            for (int z = 1; z <= 5; z++)
            {
                String strtempxpth_massupdate = KeyWords.Xpath_Table_tblMassUpdate + "[" + z + "]" + "/td[1]/table/tbody/tr/td/input";
                String strtempxpth_massupdate_CwNum = KeyWords.Xpath_Table_tblMassUpdate + "[" + z + "]" + "/td[2]";
                String strtempxpth_massupdate_CwNum1 = KeyWords.Xpath_Table_tblMassUpdate + "[" + z + "]" + "/td[10]";
                try
                {
                    bmassupdate = driver.FindElement(By.XPath(strtempxpth_massupdate)).Displayed;
                }
                catch
                {
                    bmassupdate = false;
                }
                if (bmassupdate)
                {
                    Thread.Sleep(2000);

                    driver.FindElement(By.XPath(strtempxpth_massupdate)).Click();
                    results.listData.Add(driver.FindElement(By.XPath(strtempxpth_massupdate_CwNum)).Text);
                    results.listData2.Add(driver.FindElement(By.XPath(strtempxpth_massupdate_CwNum1)).Text);

                }
            }

            return results;
        }

        public Result MassTermination_Table_CheckBox_Top5_Click(IWebDriver driver)
        {

            var results = new Result();
            Boolean bmassupdate = false;
            for (int z = 1; z <= 5; z++)
            {
                String strtempxpth_massTermination = KeyWords.Xpath_Table_tblMassTermination + "[" + z + "]" + "/td[1]/table/tbody/tr/td/input";
                String strtempxpth_massTerminationCwNum = KeyWords.Xpath_Table_tblMassTermination + "[" + z + "]" + "/td[2]";
                // String strtempxpth_massupdate_CwNum1 = KeyWords.Xpath_Table_tblMassUpdate + "[" + z + "]" + "/td[10]";

                try
                {

                    bmassupdate = driver.FindElement(By.XPath(strtempxpth_massTermination)).Displayed;

                }
                catch
                {
                    bmassupdate = false;
                    //  return results;
                }
                objCommonMethods.Action_Page_Down(driver);
                if (bmassupdate)
                {
                    Thread.Sleep(5000);
                    driver.FindElement(By.XPath(strtempxpth_massTermination)).Click();
                    results.listData.Add(driver.FindElement(By.XPath(strtempxpth_massTerminationCwNum)).Text);
                    //results.listData.Add(driver.FindElement(By.XPath(strtempxpth_massTermination)).Text);
                    // results.listData2.Add(driver.FindElement(By.XPath(strtempxpth_massTermination)).Text);

                }

            }
            //if (bmassupdate)
            //{
            //    return results;
            //}
            //else
            //{
            //    results.Result1 = KeyWords.Result_FAIL;
            //    return results;

            //}
            return results;
        }

        public Result MassTermination_Tabs_Click(IWebDriver driver, String TabsClick)
        {
            Result res = new Result();

            var results = new Result();
            Boolean bTabClick = false;
            try
            {
                Boolean bmassTabs = false;
                for (int z = 1; z <= 4; z++)
                {
                    String strtempxpth_mass_popuptabs = KeyWords.Xpath_MassTermination_EligibleCWS + "[" + z + "]" + "/";

                    try
                    {

                        bmassTabs = driver.FindElement(By.XPath(strtempxpth_mass_popuptabs)).Displayed;

                    }
                    catch
                    {
                        bmassTabs = false;
                        //  return results;
                    }

                    if (bmassTabs)
                    {
                        Thread.Sleep(5000);
                        KeyWords.Xpath_MassTermination_EligibleCWS = strtempxpth_mass_popuptabs;
                        break;
                        // driver.FindElement(By.XPath(strtempxpth_mass_popuptabs)).Click();

                    }

                }
                ICollection<IWebElement> Tab_Menu_Names = driver.FindElements(By.XPath(KeyWords.Xpath_MassTermination_EligibleCWS));
                List<IWebElement> elements = Tab_Menu_Names.ToList();
                for (int i = 0; i < elements.Count; i++)
                {
                    string strTabName = elements[i].Text;
                    if (elements[i].Text.ToLower().Trim().EndsWith(TabsClick.ToLower().Trim()))
                    {
                        bTabClick = true;
                        elements[i].Click();
                        Thread.Sleep(5000);
                    }
                    if (bTabClick)
                    {
                        break;
                    }
                }
                if (!bTabClick)
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Unable to find the given Client name " + TabsClick;
                    return results;
                }
            }
            catch (Exception exClientChange)
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed Client_Change_Click_NewApp Method";
                results.ErrorMessage1 = exClientChange.Message;
                return results;
            }
            results.Result1 = KeyWords.Result_PASS;
            return results;
        }

        public Result MassTermination_Tabs_Click1(IWebDriver driver)
        {

            var results = new Result();
            Boolean bmassTab = false;
            for (int z = 1; z <= 5; z++)
            {
                String strtempxpth_massTabclick = KeyWords.Xpath_MassTermination_EligibleCWS + "[" + z + "]" + "/";
                //String strtempxpth_massupdate_CwNum = KeyWords.Xpath_Table_tblMassUpdate + "[" + z + "]" + "/td[2]";
                // String strtempxpth_massupdate_CwNum1 = KeyWords.Xpath_Table_tblMassUpdate + "[" + z + "]" + "/td[10]";

                try
                {

                    bmassTab = driver.FindElement(By.XPath(strtempxpth_massTabclick)).Displayed;

                }
                catch
                {
                    bmassTab = false;
                    //  return results;
                }
                // objCommonMethods.Action_Page_Down(driver);
                if (bmassTab)
                {
                    Thread.Sleep(5000);
                    driver.FindElement(By.XPath(strtempxpth_massTabclick)).Click();
                    // results.listData.Add(driver.FindElement(By.XPath(strtempxpth_massTermination)).Text);
                    //results.listData2.Add(driver.FindElement(By.XPath(strtempxpth_massTermination)).Text);

                }

            }

            return results;
        }

        //public Result Action_MoveElement(IWebDriver driver, String target)
        //{
        //    var results = new Result();
        //    try
        //    {
        //        Actions actions1 = new Actions(driver);
        //        IWebElement element = driver.FindElement(By.Id(target));
        //        actions1.MoveToElement(element).Build().Perform();
        //        results.Result1 = KeyWords.Result_PASS;
        //        return results;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Console.WriteLine(ex.Message);
        //        results.Result1 = KeyWords.Result_FAIL;
        //        return results;
        //    }
        //}
        public Result Error_Msg_Read_Submit_Resume_details(IWebDriver driver, String locatortarget)
        {
            var results = new Result();

            // Boolean bFlag = false;
            try
            {
                //// Console.WriteLine("//*[@" + locator + "='" + target + "']//li");
                ICollection<IWebElement> lis_Menu_Names = driver.FindElements(By.XPath(locatortarget));
                List<IWebElement> elements = lis_Menu_Names.ToList();
                //Console.WriteLine(elements.Count);
                string strErrorMsg = "";
                for (int i = 0; i < elements.Count; i++)
                {
                    // Console.WriteLine(elements[i].Text);
                    if (elements[i].Text != "")
                    {
                        if (strErrorMsg != "")
                        {
                            strErrorMsg = strErrorMsg + "," + elements[i].Text;
                        }
                        else
                        {
                            strErrorMsg = elements[i].Text;
                        }
                    }

                }
                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = strErrorMsg;
                return results;
            }
            catch (Exception)
            {
                //checkStatus = false;
                // Console.WriteLine("Problem failed Error_Msg_Read_Submit_Resume_details Method");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed  Error_Msg_Read_Submit_Resume_details Method";
                return results;


            }

        }

        public Result Select_Date_Picker_DOB(IWebDriver driver, String givendat)
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
                //    Console.WriteLine("Year");
                // if (result >= 0)
                // {
                try
                {
                    givendat.Trim();
                    DateTime d = Convert.ToDateTime(givendat);
                    String day = d.Day.ToString();

                    int Month = d.Month;
                    String Year = d.Year.ToString();

                    DateTime date = DateTime.Parse(givendat);
                    System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                    string month = mfi.GetAbbreviatedMonthName(Month);


                    //  driver.FindElement(By.Id(datepickid)).Click();
                    // driver.FindElement(By.CssSelector(KeyWords.CSS_Date_datepicker_trigger)).Click();
                    // driver.FindElement(By.XPath(target)).Click();

                    //    click(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_trigger);
                    //    Thread.Sleep(1000);

                    click(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_year);
                    Thread.Sleep(1000);
                    // Console.WriteLine(month);
                    select(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_year, Year);
                    Thread.Sleep(1000);
                    // Console.WriteLine(Convert.ToString(Month));

                    select(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_month, month);
                    Thread.Sleep(1000);
                    //   click(driver, KeyWords.locator_CSS, KeyWords.CSS_Date_datepicker_trigger);
                    //  Thread.Sleep(1000);




                    IWebElement dateWidget = driver.FindElement(By.Id("ui-datepicker-div"));
                    IList<IWebElement> columns = dateWidget.FindElements(By.TagName("td"));
                    foreach (IWebElement item in columns)
                    {
                        if (item.Text.Equals(day))
                        {
                            item.FindElement(By.LinkText(day)).Click();
                            break;
                        }
                    }

                    Thread.Sleep(1000);
                    results.Result1 = KeyWords.Result_PASS;
                    return results;
                }
                catch
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Error encountered while selecting date from datepicker1.";
                    return results;
                }


                //}
                // else
                //{
                //   results.Result1 = KeyWords.Result_FAIL;
                //   results.ErrorMessage = "Given date is less than the current date...";
                //   return results;
                // }
            }
            catch (Exception ex)
            {
                // var res = new Result();
                Console.WriteLine(ex.Message);
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Error encountered while selecting date from datepicker2.";
                return results;
            }
        }


        public Result Error_Msg_Read_Onboarding_details(IWebDriver driver, String locatortarget)
        {
            var results = new Result();

            // Boolean bFlag = false;
            try
            {
                //// Console.WriteLine("//*[@" + locator + "='" + target + "']//li");
                ICollection<IWebElement> lis_Menu_Names = driver.FindElements(By.XPath(locatortarget));
                List<IWebElement> elements = lis_Menu_Names.ToList();
                //Console.WriteLine(elements.Count);
                Boolean blnFind = false;
                string strErrorMsg = "";
                for (int i = 0; i < elements.Count; i++)
                {
                    // Console.WriteLine(elements[i].Text);
                    if (elements[i].Text != "")
                    {
                        blnFind = true;
                        if (strErrorMsg != "")
                        {
                            strErrorMsg = strErrorMsg + "," + elements[i].Text;
                        }
                        else
                        {
                            strErrorMsg = elements[i].Text;
                        }
                    }

                }
                if (blnFind == true)
                {
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = strErrorMsg;

                }
                else
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    //results.ErrorMessage = strErrorMsg;

                }
                return results;
            }
            catch (Exception)
            {
                //checkStatus = false;
                // Console.WriteLine("Problem failed Error_Msg_Read_Submit_Resume_details Method");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed  Error_Msg_Read_Onboarding_details Method";
                return results;


            }

        }



        public Result REQ_LinkTxt_Candidate_Click(IWebDriver driver, string str_Link_ReqNumber)
        {

            var results = new Result();

            try
            {
                //strreqlnk = driver.FindElement(By.XPath("//table[@" + KeyWords.locator_ID + "='" + KeyWords.ID_ListInfo_HistoryTableViewSuppReqs + "']/tbody/tr[" + intReqlistcount + "]/td/a")).Text;
                driver.FindElement(By.LinkText(str_Link_ReqNumber)).Click();
            }
            catch
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem identifying the REQ link in REQ_LinkTxt_Candidate_Click Method";
                return results;

            }
            results.Result1 = KeyWords.Result_PASS;
            //results.ErrorMessage = strErrMsg;
            return results;
        }

        public static IWebDriver CreateIEDriver(IWebDriver driver)
        {
            var options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            //Clean the session before launching the browser
            options.EnsureCleanSession = true;
            driver = new InternetExplorerDriver(options);

            return driver;
        }

        public Result Choose_Browser(IWebDriver driver, string str_Select_Browser)
        {

            var results = new Result();

            //bool bAccessLocationSelected = false;

            List<string> arr = new List<string>();

            // string[] listAvailableSuppliers;
            try
            {

                if (str_Select_Browser == Constants.Chrome)
                {

                    driver = Constants.CreateChromeDriver(driver);
                    //  driverApp = Constants.CreateChromeDriver(driverApp);  
                }
                else if (str_Select_Browser == Constants.IE)
                {
                    driver = CreateIEDriver(driver);
                    driver = new InternetExplorerDriver(@System.IO.Directory.GetCurrentDirectory());
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
                }
                else if (str_Select_Browser == Constants.Opera)
                {

                    //   driver = Constants.CreateOperaDriver(driver);
                    driver = new OperaDriver();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
                }
                else if (str_Select_Browser == Constants.IEEdge)
                {

                    driver = new EdgeDriver();
                    //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(120));
                }
                else
                {

                    driver = new FirefoxDriver();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
                }


            }
            catch
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem with this Choose_Browser Method";
                return results;
            }
            results.Result1 = KeyWords.Result_PASS;
            results.driver = driver;
            return results;
        }


        public Result Left_list_Menu_Click(IWebDriver driver, String target, String strSubMenuName, String strSubLevel)
        {
            var results = new Result();

            Boolean bFlag = false;
            try
            {

                ICollection<IWebElement> lis_Menu_Names = driver.FindElements(By.XPath(target));
                List<IWebElement> elements = lis_Menu_Names.ToList();
                for (int i = 0; i < elements.Count; i++)
                {
                    // // Console.WriteLine(elements[i].FindElement(By.XPath("./span")).Text);
                    string strMenuName = "";
                    if (strSubLevel == "")
                        strMenuName = elements[i].Text;
                    else
                        strMenuName = elements[i].FindElement(By.XPath(strSubLevel)).Text;


                    if (strMenuName.ToLower().Equals(strSubMenuName.ToLower()))
                    {
                        if (strSubLevel == "")
                            elements[i].Click();
                        else
                            elements[i].FindElement(By.XPath(strSubLevel)).Click();

                        Thread.Sleep(1000);
                        bFlag = true;
                        break;
                    }

                    if (bFlag)
                    {
                        break;
                    }

                }
                if (bFlag)
                {
                    // Console.WriteLine("Click on the Link menu name " + strSubMenuName + " successfully");
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Click on the Link menu name " + strSubMenuName + " successfully";
                    return results;
                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given Link menu name " + strSubMenuName + " not found");
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given Link menu name " + strSubMenuName + " not found";
                    return results;
                }


            }
            catch (Exception ex)
            {
                //checkStatus = false;
                // Console.WriteLine("Problem failed list_Menu_Click Method");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed left_list_Menu_Click Method";
                results.ErrorMessage1 = ex.Message;
                return results;


            }

        }

        public Result Center_list_Menu_Click(IWebDriver driver, String target, String strSubMenuName, String strSubLevel)
        {
            var results = new Result();

            Boolean bFlag = false;
            try
            {

                IWebElement reports_Requirements = driver.FindElement(By.XPath(target));
                IList<IWebElement> links = reports_Requirements.FindElements(By.TagName("li"));

                //  ICollection<IWebElement> lis_Menu_Names = driver.FindElements(By.XPath(target));
                // List<IWebElement> elements = links.ToList();
                for (int i = 0; i < links.Count; i++)
                {
                    // // Console.WriteLine(elements[i].FindElement(By.XPath("./span")).Text);
                    string strMenuName = "";
                    if (strSubLevel == "")
                        strMenuName = links[i].Text;
                    else
                        strMenuName = links[i].FindElement(By.XPath(strSubLevel)).Text;


                    if (strMenuName.ToLower().Equals(strSubMenuName.ToLower()))
                    {
                        if (strSubLevel == "")
                            links[i].Click();
                        else
                            links[i].FindElement(By.XPath(strSubLevel)).Click();

                        Thread.Sleep(1000);
                        bFlag = true;
                        break;
                    }

                    if (bFlag)
                    {
                        break;
                    }

                }
                if (bFlag)
                {
                    // Console.WriteLine("Click on the Link menu name " + strSubMenuName + " successfully");
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Click on the Link menu name " + strSubMenuName + " successfully";
                    return results;
                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given Link menu name " + strSubMenuName + " not found");
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given Link menu name " + strSubMenuName + " not found";
                    return results;
                }


            }
            catch (Exception ex)
            {
                //checkStatus = false;
                // Console.WriteLine("Problem failed list_Menu_Click Method");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem failed left_list_Menu_Click Method";
                results.ErrorMessage1 = ex.Message;
                return results;


            }

        }

        public WebDriverWait _WDWait { get; set; }

        public WebDriverWait WebDriver_Wait_Handler(IWebDriver driver, int timespan_sec)
        {
            WebDriverWait _WebDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timespan_sec));
            return _WebDriverWait;
        }


        public Result select_List_typeahead_Timesheet_AnyOne(IWebDriver driver, String locator, String target, String locator1, String target1, String strEnterText, String strcmpvalue)
        {
            CommonMethods objCommonMethods = new CommonMethods();
            var results = new Result();
            try
            {
                //IWebElement element = inspect(driver, locator, target,out KeyWords.sLabelName);
                //  string strCmpAppValue = string.Empty;
                //string strCmpGivenValue = string.Empty;
                string stemp = string.Empty;
                string target2 = "opt";
                Boolean bFlag = false;

                for (int i = 2; i <= strEnterText.Length - 1; i++)
                {
                    if (i == 2)
                    {
                        //string[] listNames = strEnterText.Split(',');
                        //stemp = listNames[0];
                        //stemp = strEnterText.Substring(0, i);
                        stemp = strEnterText.Substring(0, 2);
                        // Console.WriteLine(stemp);
                    }
                    if (i == 6)
                    {
                        results.Result1 = KeyWords.Result_FAIL;
                        results.ErrorMessage = "The given " + strcmpvalue + " name not found";
                        return results;
                    }
                    stemp = stemp + strEnterText[i].ToString();

                    sendText(driver, locator, target, stemp, false);

                    //    objCommonMethods.Action_Button_Backspacekey(driver);

                    Thread.Sleep(5000);
                    // target1 = "list-typeahead";
                    //  ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[@" + locator1 + "='" + target1 + "']//div"));
                    ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//div[@" + locator1 + "='" + target1 + "']//div[@" + locator1 + "='" + target2 + "']"));

                    List<IWebElement> elements = lis_ClientNames.ToList();
                    // Console.WriteLine(elements.Count);
                    for (int j = 0; j <= elements.Count - 1; j++)
                    {
                        // j.
                        // Console.WriteLine(elements[j].Text.Trim());
                        // Console.WriteLine(strcmpvalue.ToLower().Trim());
                        if (elements[j].Text.ToLower().Trim() != "")
                        {
                            bFlag = true;
                            Thread.Sleep(100);


                            if (elements[j].Text.ToLower().Trim() == "no result found")
                            {
                                i = strEnterText.Length;
                                bFlag = true;
                            }

                            try
                            {

                                // elements.Select(
                                //  Console.WriteLine(KeyWords.str_Browser_Execute.ToLower());
                                if (KeyWords.str_Browser_Execute.ToLower() == "mozilla")
                                {
                                    elements[j].Click();
                                    //  driver.FindElement(By.CssSelector("div.opt.optover")).Click();
                                }
                                else
                                {
                                    elements[j].Click();
                                }
                            }
                            catch
                            {
                                //
                                Console.WriteLine("div.opt.optover problem");
                            }
                            //  Console.WriteLine("match");

                            if (bFlag)
                            {
                                //Inner for loop break
                                //    Console.WriteLine("Inner for loop break");
                                break;
                            }
                        }
                    }
                    if (bFlag)
                    {
                        //Out for loop break
                        //Console.WriteLine("Outer for loop break");
                        break;
                    }

                }

                if (bFlag)
                {
                    // Console.WriteLine("Selecting " + strcmpvalue);
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Selecting " + strcmpvalue;
                }
                else
                {
                    //checkStatus = false;
                    // Console.WriteLine("The given " + strcmpvalue + " name not found");
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "The given " + strcmpvalue + " name not found";
                    click(driver, locator, target);
                }

                return results;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Selecting " + strcmpvalue + " failed";
                return results;
            }
        }


        public Result textClear(IWebDriver driver, String locator, String target)
        {
            Result result = new Result();
            try
            {
                IWebElement Text = inspect(driver, locator, target,out KeyWords.sLabelName);
                if (isElementPresent(driver, target))
                {
                    Text.Clear();
                    Text.Click();
                    Thread.Sleep(100);


                    Thread.Sleep(100);
                    // Console.WriteLine("Text Entered successfully");
                    result.Result1 = KeyWords.Result_PASS;

                    return result;

                }
                else
                {
                    result.Result1 = KeyWords.Result_FAIL;
                    result.ErrorMessage = "Unable to find the isElementPresent " + target;
                    return result;
                    // throw new Exception();                    
                }
            }
            catch (Exception)
            {
                //checkStatus = false;
                result.Result1 = KeyWords.Result_FAIL;
                result.ErrorMessage = "Text not entered " + target;
                // Console.WriteLine("Text not entered");
                return result;

            }

        }

        public Result click_Xpath(IWebDriver driver, String locator, String target)
        {
            Result results = new Result();
            try
            {
                IWebElement ele = inspect(driver, locator, target,out KeyWords.sLabelName);

                if (isElementDisplayedByXPath(driver, target))
                {

                    Thread.Sleep(1000);

                    ele.Click();
                    //Console.WriteLine("Clicking on Element Passed");
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Clicking on Element Passed";
                    return results;
                }
                else
                {
                    // throw new Exception();
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Problem finding the Element " + target;
                    return results;

                }

            }
            catch (Exception e)
            {

                // Console.WriteLine("Clicking on Element Failed");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Clicking on Element Failed " + target;
                results.ErrorMessage1 = e.Message;
                return results;
            }
        }

        public Result arrangingdata(String clientname, string submenuname)
        {


            string strSheetName = "Reports$";
            var labelmain = new Result();
            var innerfields = new Result();
            var updateresults = new Result();

            string strMainSql = "SELECT P6,P4,P5 FROM [" + strSheetName + "] where P3 = '" + clientname + "' and P5 = '" + submenuname + "'";
            ReadExcel ReadExcelHelper = new ReadExcel();
            labelmain = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strSheetName, strMainSql);

            foreach (DataRow drowMain in labelmain.dt.Rows)
            {
                try
                {
                    if (drowMain[0].ToString().Substring(drowMain[0].ToString().Length - 6) == "Client")
                    {
                        String inp6 = drowMain[0].ToString().Substring(0, drowMain[0].ToString().Length - 6);
                        string strMainSql1 = "SELECT TOP 1 P7,P8,P9,P10,P11,P12,P13,P14,P15,P16,P17,P18,P19,P20,P21,P22,P23,P24,P25,P26,P27,P28,P29,P30,P31,P32,P33,P34,P35,P36,P37,P38,P39,P40,P41,P42,P43,P44,P45,P46,P47,P48,P49,P50,P51,P52,P53,P54,P55,P56,P57,P58,P59,P60,P61,P62,P63,P64,P65,P66,P67,P68,P69,P70 FROM [" + strSheetName + "] where P6 = '" + inp6 + "'";
                        innerfields = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strSheetName, strMainSql1);

                    }
                    else if ((drowMain[0].ToString().Substring(drowMain[0].ToString().Length - 8) == "Supplier"))
                    {
                        String inp6 = drowMain[0].ToString().Substring(0, drowMain[0].ToString().Length - 8);
                        string strMainSql1 = "SELECT TOP 1 P7,P8,P9,P10,P11,P12,P13,P14,P15,P16,P17,P18,P19,P20,P21,P22,P23,P24,P25,P26,P27,P28,P29,P30,P31,P32,P33,P34,P35,P36,P37,P38,P39,P40,P41,P42,P43,P44,P45,P46,P47,P48,P49,P50,P51,P52,P53,P54,P55,P56,P57,P58,P59,P60,P61,P62,P63,P64,P65,P66,P67,P68,P69,P70 FROM [" + strSheetName + "] where P6 = '" + inp6 + "'";
                        innerfields = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strSheetName, strMainSql1);
                    }


                    else
                    {
                        string strMainSql1 = "SELECT TOP 1 P7,P8,P9,P10,P11,P12,P13,P14,P15,P16,P17,P18,P19,P20,P21,P22,P23,P24,P25,P26,P27,P28,P29,P30,P31,P32,P33,P34,P35,P36,P37,P38,P39,P40,P41,P42,P43,P44,P45,P46,P47,P48,P49,P50,P51,P52,P53,P54,P55,P56,P57,P58,P59,P60,P6P62,P63,P64,P65,P66,P67,P68,P69,P70 FROM [" + strSheetName + "] where P6 = '" + drowMain[0].ToString() + "'";
                        innerfields = ReadExcelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, strSheetName, strMainSql1);
                    }


                    int mxlimt = innerfields.dt.Columns.Count + 7;
                    for (int clm = 0 + 7; clm < mxlimt; clm++)
                    {

                        string strUpdateSqlMain = "Update [" + strSheetName + "] set P" + clm + " = '" + innerfields.dt.Rows[0][clm - 7].ToString() + "' where P3 = '" + clientname + "' and P5 = '" + submenuname + "' and P6 = '" + drowMain[0].ToString() + "'";
                        updateresults = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);
                        if (clm == 53)
                        {

                            //String example = "Update [Reports$] set P53 = "+'"//*[contains(@id,"'+'"1_oReportCell')]/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr[2]/td[2]/div/div/div[1]"' where P3 = 'Tufts' and P5 = 'Invoice' and P6 = 'Ad hoc Invoice Audit Report'";
                            //   ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, inputxpath);
                            String mainXpath = innerfields.dt.Rows[0][clm - 7].ToString().Replace("'", "#");
                            string inputxpath = "Update [" + strSheetName + "] set P" + clm + " = '" + mainXpath + "' where P3 ='" + clientname + "' and P5 = '" + submenuname + "' and P6 = '" + drowMain[0].ToString() + "'";
                            updateresults = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, inputxpath);

                        }

                    }
                }
                catch (Exception e)
                {

                    continue;
                }
            }
            return innerfields;
        }

        public Result writingmenussubmenus(IWebDriver driver, String mainmenu)
        {
            var results = new Result();
            ReadExcel ReadExcelHelper = new ReadExcel();

            if (mainmenu == "//*[@id='webuiPopover0']/div[2]/div/div[1]/ul/li")
            {
                ICollection<IWebElement> lis_Menu_Names = driver.FindElements(By.XPath(mainmenu));
                List<IWebElement> mainmemuelements = lis_Menu_Names.ToList();


                for (int p = 0; p < mainmemuelements.Count; p++)
                {
                    mainmemuelements[p].Click();



                    ///"'WHERE TestCaseId='" + p + "'";
                    string strUpdateSqlMain = "update [Sheet2$] set k0='" + mainmemuelements[p].Text + "'WHERE TestCaseId='" + p + "'";
                    results = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateSqlMain);


                    Thread.Sleep(1000);

                    ICollection<IWebElement> lis_submenu = driver.FindElements(By.XPath("//*[@id='webuiPopover0']/div[2]/div/div[2]/div[2]/div/ul/li"));
                    List<IWebElement> submenuitems = lis_submenu.ToList();
                    for (int submenu = 0; submenu < submenuitems.Count; submenu++)
                    {
                        ///int submenunum =submenu+p;
                        ///string submenusupdate = "update [sheet1$] set p" + p + " ='" + elements[p].Text + "'WHERE TestCaseId= '0'"+p;
                        string submenusupdate = "update [Sheet2$] set p" + submenu + " ='" + submenuitems[submenu].Text + "'WHERE TestCaseId='" + p + "'";

                        results = ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, submenusupdate);
                        Thread.Sleep(500);

                    }
                }

            }
            return results;
        }

        public Result GetLabelfromGrid(IWebDriver driver, string xpath_gridlablelocation, string reportname, string usertype)
        {

            var results = new Result();

            string[] reportnames = { "Client User by Function Group", "Rights List", "Supplier User Details", "User by Right", "Supplier Information", "Approved Expense", "Activity Report", "Status Report", "GHC Weekly Invoice V1.0", "GHC Weekly Invoice V2.0" };

            try
            {
                if (reportnames.Contains(reportname))
                {
                    try
                    {
                        results.ErrorMessage = driver.FindElement(By.XPath(xpath_gridlablelocation)).Text.Trim();
                    }
                    catch (Exception ex)
                    {
                        results.Result1 = KeyWords.Result_FAIL;
                        results.ErrorMessage = "Problem in fetching the label from grid";
                        results.ErrorMessage1 = ex.Message;
                    }

                    results.Result1 = KeyWords.Result_PASS;
                    return results;
                }
                // to handle "Contingent Worker with End Dates by Month" report for client user only
                else if (usertype == "client" && (reportname == "Contingent Worker with End Dates by Month" || reportname == "Contract Worker with End Dates by Month" || reportname == "Non Employee Worker with End Dates by Month" || reportname == "Non-Employee Worker with End Dates by Month"))
                {
                    try
                    {
                        results.ErrorMessage = driver.FindElement(By.XPath(xpath_gridlablelocation)).Text.Trim();
                    }
                    catch (Exception ex)
                    {
                        results.Result1 = KeyWords.Result_FAIL;
                        results.ErrorMessage = "Problem in fetching the label from grid";
                        results.ErrorMessage1 = ex.Message;
                    }

                    results.Result1 = KeyWords.Result_PASS;
                    return results;
                }
                else
                {
                    try
                    {
                        //driver.SwitchTo().Frame(0);
                        IWebElement gridlabel = driver.FindElement(By.XPath(xpath_gridlablelocation));
                        string stempvariable = null;
                        //int count = gridlabel.FindElements(By.TagName("span")).Count;
                        int count = driver.FindElements(By.XPath(xpath_gridlablelocation + "/span")).Count;
                        //Console.WriteLine("The span tag count is: " + count);
                        for (int i = 1; i <= count; i++)
                        {
                            stempvariable = stempvariable + driver.FindElement(By.XPath(xpath_gridlablelocation + "/span[" + i + "]")).Text;

                        }
                        //driver.SwitchTo().DefaultContent();
                        results.ErrorMessage = stempvariable.Trim();
                    }
                    catch (Exception ex)
                    {
                        results.Result1 = KeyWords.Result_FAIL;
                        results.ErrorMessage = "Problem in fetching the label from grid";
                        results.ErrorMessage1 = ex.Message;
                    }

                    results.Result1 = KeyWords.Result_PASS;
                    return results;
                }

            }

            catch (Exception ex)
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Problem occured while fetching the lable from the grid";
                results.ErrorMessage1 = ex.Message;
            }

            return results;
        }

        public Result Action_LookInto_Element(IWebDriver driver, String Locator, String strelement)
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
                    case "linktext": element = driver.FindElement(By.LinkText(strelement)); break;
                    case "partiallinktext": element = driver.FindElement(By.PartialLinkText(strelement)); break;
                    case "cssselector": element = driver.FindElement(By.CssSelector(strelement)); break;
                    default: break;
                }

                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                jse.ExecuteScript("arguments[0].scrollIntoView(true);", element);
                results.Result1 = KeyWords.Result_PASS;
                ReportHandler._ChildTest.Log(LogStatus.Pass, "Focus on the element successfully.");
                return results;
            }
            catch (Exception ex)
            {
                ReportHandler._ChildTest.Log(LogStatus.Fail, ex.Message);
                ReportHandler._ChildTest.Log(LogStatus.Info, ex.StackTrace);
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = ex.Message;
                return results;
            }
        }


        public Result Action_LookInto_Element_webEle(IWebDriver driver, IWebElement webEle)
        { 
            var results = new Result();
            try {
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                jse.ExecuteScript("arguments[0].scrollIntoView(true);", webEle); 
                results.Result1 = KeyWords.Result_PASS;
                return results; 
            } catch (Exception ex)
            { 
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = ex.Message;
            }
            return results; 
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
        //            default: break;
        //        }

        //        IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
        //        jse.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        //        results.Result1 = KeyWords.Result_PASS;
        //        return results;
        //    }
        //    catch (Exception ex)
        //    {
        //        results.Result1 = KeyWords.Result_FAIL;
        //        results.ErrorMessage = ex.Message;
        //        return results;
        //    }
        //}

        public Result tab5pagedown(IWebDriver driver, String locator, String target)
        {

            var results = new Result();
            for (int o = 0; o <= 10; o++)
            {
                results = click(driver, locator, target);

                if ((results.Result1 == KeyWords.Result_FAIL))
                {
                    // Console.WriteLine("I am here 1");
                    objCommonMethods.Action_Page_Down(driver);
                    Thread.Sleep(1000);
                }
                else
                {
                    return results;
                    break;
                }

            }
            return results;
        }

        public Result click_LinkText(IWebDriver driver, String locator, String target)
        {
            Result results = new Result();
            try
            {
                IWebElement ele = inspect(driver, locator, target,out KeyWords.sLabelName);

                if (isElementDisplayedByLinkText(driver, target))
                {

                    Thread.Sleep(1000);

                    ele.Click();
                    //Console.WriteLine("Clicking on Element Passed");
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Clicking on Element Passed";
                    return results;
                }
                else
                {
                    // throw new Exception();
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Problem finding the Element " + target;
                    return results;

                }

            }
            catch (Exception e)
            {

                // Console.WriteLine("Clicking on Element Failed");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Clicking on Element Failed " + target;
                results.ErrorMessage1 = e.Message;
                return results;
            }
        }

        /** Generic Method for Get text in a textbox */
        public Result GetText(IWebDriver driver, String locator, String target)
        {
            Result result = new Result();
            try
            {
                string sTemp = "";
                IWebElement Text = inspect(driver, locator, target,out KeyWords.sLabelName);
                if (isElementPresent(driver, target))
                {

                    // Text.Click();
                    Thread.Sleep(1000);

                    sTemp = Text.GetAttribute("value");
                    // Text.SendKeys(value + "");

                    Thread.Sleep(100);
                    // Console.WriteLine("Text Entered successfully");
                    result.Result1 = KeyWords.Result_PASS;
                    result.ErrorMessage = sTemp;
                    return result;

                }
                else
                {
                    result.Result1 = KeyWords.Result_FAIL;
                    result.ErrorMessage = "Unable to find the isElementPresent " + target;
                    return result;
                    // throw new Exception();                    
                }
            }
            catch (Exception)
            {
                //checkStatus = false;
                result.Result1 = KeyWords.Result_FAIL;
                result.ErrorMessage = "Text not entered " + target;
                // Console.WriteLine("Text not entered");
                return result;

            }

        }

        public Boolean isElementDisplayedByLinkText(IWebDriver driver, String strTarget)
        {
            try
            {
                if (driver.FindElement(By.LinkText(strTarget)).Displayed)
                {
                    // Console.WriteLine("I am here 1");
                    return true;
                }
                else
                {
                    //  Console.WriteLine("I am here 2");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                return false;
            }

        }

        //* Method for checking the Enabled of Element on the Web Page using XPath /
        public Boolean isElementEnabledByXPath(IWebDriver driver, String strTarget)
        {
            try
            {
                if (driver.FindElement(By.XPath(strTarget)).Enabled)
                {
                    // Console.WriteLine("I am here 1");
                    return true;
                }
                else
                {
                    //  Console.WriteLine("I am here 2");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                return false;
            }
        }

        #region calendar
        public Result Select_Date_From_Picker(IWebDriver driver, DateTime dtGivenDate)
        {

            var results = new Result();

            try
            {


                String trg_Day = dtGivenDate.Day.ToString();
                String trg_Month = dtGivenDate.Month.ToString();
                String trg_Year = dtGivenDate.Year.ToString();
                System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                String month = mfi.GetAbbreviatedMonthName(Int32.Parse(trg_Month));
                //results = setMonthName(trg_Month);

                string str_CurrentMonthOnCalender = driver.FindElement(By.XPath("//div[@id='ui-datepicker-div']//div//select[@data-handler='selectMonth']/option[@selected]")).Text;
                string str_CurrentYearOnCalender = driver.FindElement(By.XPath("//div[@id='ui-datepicker-div']//div//select[@data-handler='selectYear']/option[@selected]")).GetAttribute("value");

                if (!str_CurrentYearOnCalender.Equals(trg_Year))
                {
                    selectDropDownByXpath(driver, KeyWords.locator_XPath, "//div[@id='ui-datepicker-div']//div//select[@data-handler='selectYear']", trg_Year);
                }

                if (!month.Equals(str_CurrentMonthOnCalender))
                {

                    selectDropDownByXpath(driver, KeyWords.locator_XPath, "//div[@id='ui-datepicker-div']//div//select[@data-handler='selectMonth']", month);
                }



                try
                {
                    int TodayDateIntVal = Int32.Parse(trg_Day);
                    if (driver.FindElement(By.LinkText("" + TodayDateIntVal)).Enabled)//table[@class='ui-datepicker-calendar']//td/span[text()='12']/parent::td
                    {
                        driver.FindElement(By.LinkText("" + TodayDateIntVal)).Click();
                    }
                    else
                    {
                        click(driver, KeyWords.locator_XPath, "//*[@class='ui-datepicker-calendar']//a");
                    }
                }
                catch (Exception ex)
                {
                    click(driver, KeyWords.locator_XPath, "//*[@class='ui-datepicker-calendar']//a");
                }
                Thread.Sleep(1000);
                objCommonMethods.Action_Button_Tab(driver);
                results.Result1 = KeyWords.Result_PASS;
                return results;

            }
            catch (Exception ex)
            {
                // var res = new Result();
                Console.WriteLine(ex.Message);
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Error encountered while selecting date from datepicker2.";
                return results;
            }
        }

        public Result setMonthName(string strMonthNumber)
        {
            Result res = new Result();
            switch (strMonthNumber)
            {
                case "1": res.ErrorMessage = "Jan"; break;
                case "2": res.ErrorMessage = "Feb"; break;
                case "3": res.ErrorMessage = "Mar"; break;
                case "4": res.ErrorMessage = "Apr"; break;
                case "5": res.ErrorMessage = "May"; break;
                case "6": res.ErrorMessage = "Jun"; break;
                case "7": res.ErrorMessage = "Jul"; break;
                case "8": res.ErrorMessage = "Aug"; break;
                case "9": res.ErrorMessage = "Sep"; break;
                case "10": res.ErrorMessage = "Oct"; break;
                case "11": res.ErrorMessage = "Nov"; break;
                case "12": res.ErrorMessage = "Dec"; break;
                default: break;
            }
            return res;
        }
        #endregion


        public Result selectDropDownByXpath(IWebDriver driver, String locator, String target, String value)
        {

            var results = new Result();
            try
            {
                driver.FindElement(By.XPath(target)).Click();
                Thread.Sleep(2000);
                new SelectElement(driver.FindElement(By.XPath(target))).SelectByText(value);
                // Console.WriteLine("Selecting from a drop down " + value + "passed");

                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = "Selecting from a drop down " + value + " passed";
                return results;
            }
            catch (Exception)
            {

                // Console.WriteLine("Selecting from a drop down " + value + " failed");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Selecting from a drop down " + value + " failed";
                return results;


            }
        }

        public void comparisonsString(IWebDriver driver, String Locator, String Target)
        {

            IWebElement element = null;
            try
            {
                string dt = driver.FindElement(By.XPath(Target)).Text;
                DateTime dateneeded = DateTime.Parse(dt);
                if (dateneeded.Equals(KeyWords.dtStartDate))
                {

                    ReportHandler._ChildTest.Log(LogStatus.Pass, "Date is getting same value. " + dt + " :");
                }
                else
                {
                    ReportHandler._ChildTest.Log(LogStatus.Fail, "Date is not matched " + dt);
                    //  Console.WriteLine("I am here null KWM");
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, " Date is not matched: " + dt + "", 3);
                }

            }
            catch (Exception e)
            {
                ReportHandler._ChildTest.Log(LogStatus.Fail, e.Message);
                //  Console.WriteLine("I am here null KWM");
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, e.Message, 3);


            }

        }
        public void comparisonsStringValues(IWebDriver driver, String Locator, String Target, string compareelement)
        {

            IWebElement element = null;
            try
            {
                string labelValue = driver.FindElement(By.XPath(Target)).Text;
                if (labelValue.Contains("-"))
                {
                    string minval = labelValue.Split('-')[0].Trim();
                    String maxval = labelValue.Split('-')[1].Trim();

                    if (minval.Equals(compareelement))

                        Console.WriteLine("value is matched");

                    else if (maxval.Equals(compareelement))
                        Console.WriteLine("value is matched");
                }
                else if (labelValue.Equals(compareelement))
                    Console.WriteLine("Value is Matched");
                else
                {
                    ReportHandler._ChildTest.Log(LogStatus.Fail, "Value is not matched " + labelValue);
                    //  Console.WriteLine("I am here null KWM");
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, " value is not matched: " + labelValue + "", 3);
                }

            }
            catch (Exception e)
            {
                ReportHandler._ChildTest.Log(LogStatus.Fail, e.Message);
                //  Console.WriteLine("I am here null KWM");
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, e.Message, 3);


            }

        }

        public Result Estimatedcontractorvalue(IWebDriver driver, string nofdays, String nofresurces, string noofhours, string weekcount, string MaxBillRate)
        {

            var results = new Result();
            IWebElement element = null;
            try
            {
                MaxBillRate = MaxBillRate.Split(' ')[0].Trim();
                double val = 1.0;

                int days, week;
                var nofdaysIsSuccess = Int32.TryParse(nofdays.ToString(), out days);
                var weeksisSucess = Int32.TryParse(weekcount.ToString(), out week);
                int nores = Int32.Parse(nofresurces.ToString());
                float nohours = float.Parse(noofhours.ToString());
                float MaxBillrate = float.Parse(MaxBillRate.ToString());
                if (days > 0 && week > 0)
                {
                    val = (float)days / (float)week;
                    //val = Math.Round(val, 2);
                }

                double estimatedValue = val * (float)nores * (float)nohours * MaxBillrate;
                estimatedValue = Math.Round(estimatedValue, 2);

                //String value = (nofdays / weekcount) * nofresurces * noofhours*MaxBillRate;
                results.Result1 = KeyWords.Result_PASS;
                results._Var = estimatedValue.ToString();
                return results;



            }
            catch (Exception e)
            {
                ReportHandler._ChildTest.Log(LogStatus.Fail, e.Message);
                //  Console.WriteLine("I am here null KWM");
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, e.Message, 3);
                results.Result1 = KeyWords.Result_PASS;
                return results;

            }

        }

        public Result sendText_clr_backspace_phone(IWebDriver driver, String locator, String target, String text)
        {
            Result result = new Result();
            try
            {
                IWebElement Text = inspect(driver, locator, target,out KeyWords.sLabelName);
                if (isElementPresent(driver, target))
                {
                    Text.Clear();
                    Text.Click();
                    Thread.Sleep(100);

                    for (int i = 0; i < 12; i++)
                    {

                        objCommonMethods.Action_Button_Backspace(driver);

                    }


                    Text.SendKeys(text);

                    Thread.Sleep(100);
                    // Console.WriteLine("Text Entered successfully");
                    result.Result1 = KeyWords.Result_PASS;

                    return result;

                }
                else
                {
                    result.Result1 = KeyWords.Result_FAIL;
                    result.ErrorMessage = "Unable to find the isElementPresent " + target;
                    return result;
                    // throw new Exception();                    
                }
            }
            catch (Exception)
            {
                //checkStatus = false;
                result.Result1 = KeyWords.Result_FAIL;
                result.ErrorMessage = "Text not entered " + target;
                // Console.WriteLine("Text not entered");
                return result;

            }

        }

        public Result lableComparision(IWebDriver driver, String locator, String target, String ExpectedLabel)
        {
            var results = new Result();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            try
            {
                String ActualLabel = null;
                // Label Verification 
                try
                {
                    //  ActualLabel = getLabelName(driver, locator, target, "", "");
                    ActualLabel = driver.FindElement(By.XPath("//*[@id='" + target + "']/ancestor::div/preceding-sibling::label")).Text;
                }
                catch
                {
                    try
                    {
                        ActualLabel = driver.FindElement(By.XPath("//*[@id='" + target + "']/preceding-sibling::label")).Text;
                    }
                    catch
                    {
                        try
                        {
                            ActualLabel = driver.FindElement(By.XPath("//*[@id='" + target + "']/preceding-sibling::div/label")).Text;
                        }
                        catch
                        {
                            try
                            {
                                ActualLabel = driver.FindElement(By.XPath("//*[@id='" + target + "']/ancestor::div/preceding-sibling::div/label")).Text;
                            }
                            catch (Exception e)
                            {
                                results.Result1 = KeyWords.Result_FAIL;
                                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, e.Message, 1);
                                return results;
                            }
                        }



                    }
                }
                if (ActualLabel.Trim() == ExpectedLabel.Trim())
                {
                    // Both are same
                    ReportHandler._getLblChildTest().Log(LogStatus.Pass, "Actual Label <b>->" + ActualLabel.Trim() + "<b> && Expected Label-> <b>" + ExpectedLabel.Trim() + " <b>: Matched");
                }
                else
                {
                    ReportHandler._getLblChildTest().Log(LogStatus.Info, "Label Name ->" + ActualLabel.Trim() + " : Is not available in the repository");
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "******** Label Value mismatch *********", 3);
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "Expected Label is :" + ExpectedLabel, 3);
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "Actual Label is :" + ActualLabel, 3);
                }
                ReportHandler._getChildTest().Log(LogStatus.Pass, "Identified Element :" + ActualLabel);
            }
            catch (Exception e)
            {
                // Console.WriteLine("Problem failed Get_Req_Number Method");
                results.Result1 = KeyWords.Result_FAIL;
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, e.Message, 1);
                results.ErrorMessage = "Both Expected and Actual Labels are different";
                return results;
            }
            results.Result1 = KeyWords.Result_PASS;
            return results;
        }

        public Result lableComparision2(IWebDriver driver, String locator, String target, String ExpectedLabel)
        {
            var results = new Result();
            try
            {
                // Label Verification 
                String ActualLabel = driver.FindElement(By.XPath("//*[@id='" + target + "']/preceding-sibling::label")).Text;
                if (ActualLabel == ExpectedLabel)
                {
                    // Both are same
                }
                else
                {
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "******** Label Value mismatch *********", 3);
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "Expected Label is :" + ExpectedLabel, 3);
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "Actual Label is :" + ActualLabel, 3);
                }

            }
            catch (Exception e)
            {
                // Console.WriteLine("Problem failed Get_Req_Number Method");
                results.Result1 = KeyWords.Result_FAIL;
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, e.Message, 1);
                results.ErrorMessage = "Both Expected and Actual Labels are different";
                return results;
            }
            results.Result1 = KeyWords.Result_PASS;
            return results;
        }


        public Result lableComparisionRadioButton(IWebDriver driver, String locator, String target, String ExpectedLabel)
        {
            var results = new Result();
            try
            {
                // Label Verification 
                String ActualLabel = driver.FindElement(By.XPath("//*[@id='" + target + "']/ancestor::label/preceding-sibling::label")).Text;
                if (ActualLabel == ExpectedLabel)
                {
                    // Both are same
                }
                else
                {
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "******** Label Value mismatch *********", 3);
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "Expected Label is :" + ExpectedLabel, 3);
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "Actual Label is :" + ActualLabel, 3);
                }

            }
            catch (Exception e)
            {
                // Console.WriteLine("Problem failed Get_Req_Number Method");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Both Expected and Actual Labels are different";
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, e.Message, 1);
                return results;
            }
            results.Result1 = KeyWords.Result_PASS;
            return results;
        }

        public Result lableComparisionMultiSelectDDL(IWebDriver driver, String locator, String target, String ExpectedLabel)
        {
            var results = new Result();
            try
            {
                // Label Verification 
                String ActualLabel = driver.FindElement(By.XPath(target + "/preceding-sibling::label")).Text;
                if (ActualLabel == ExpectedLabel)
                {
                    // Both are same
                }
                else
                {
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "******** Label Value mismatch *********", 3);
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "Expected Label is :" + ExpectedLabel, 3);
                    objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, "Actual Label is :" + ActualLabel, 3);
                }

            }
            catch (Exception e)
            {
                // Console.WriteLine("Problem failed Get_Req_Number Method");
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Both Expected and Actual Labels are different";
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, e.Message, 1);
                return results;
            }
            results.Result1 = KeyWords.Result_PASS;
            return results;
        }

        public Result waitforelementandclick(IWebDriver driver, String locator, String target, By ele_Locator, WebDriverWait _WDWait)
        {

            Result results = new Result();


            waitForElementToBeClickable(driver, ele_Locator, _WDWait);

            results = click(driver, locator, target, "", "");

            return results;
        }

        public void mouserovertomainmenu(IWebDriver driver)
        {
            //click on home page button 

            Actions action = new Actions(driver);

            IWebElement we = driver.FindElement(By.XPath(KeyWords.XPath_MainMenu));

            action.MoveToElement(we).Build().Perform();



        }

        public Result select_MSG_Button_Close(IWebDriver driver, String locator, String target, String strSelectButtonName)
        {
            Result results = new Result();
            try
            {

                Boolean bFlag = false;

                ICollection<IWebElement> lis_ClientNames = driver.FindElements(By.XPath("//*[contains(@" + locator + ", '" + target + "') and text()='" + strSelectButtonName + "']"));

                List<IWebElement> elements = lis_ClientNames.ToList();

                for (int j = 0; j <= elements.Count; j++)
                {
                    if (elements[j].Text.ToLower().Trim() != "")
                    {

                        if (elements[j].Text.ToLower().Trim() == strSelectButtonName.ToLower().Trim())
                        {
                            bFlag = true;
                            try
                            {

                                elements[j].Click();

                            }
                            catch
                            {

                                elements[j].SendKeys(OpenQA.Selenium.Keys.Enter);
                            }
                        }
                        if (bFlag)
                        {

                            break;
                        }
                    }
                }




                if (bFlag)
                {

                    results.ErrorMessage = "Click on the " + strSelectButtonName;
                    results.Result1 = KeyWords.Result_PASS;

                }
                else
                {

                    results.ErrorMessage = "The given button " + strSelectButtonName + " name not found";
                    results.Result1 = KeyWords.Result_FAIL;
                }

                return results;
            }
            catch (Exception)
            {

                results.ErrorMessage = "Click on the button " + strSelectButtonName + " failed";
                results.Result1 = KeyWords.Result_FAIL;
            }
            return results;
        }

        public Result ReqAge(IWebDriver driver, string label)
        {
            Result result = new Result();
            int count = driver.FindElements(By.XPath("//table[@id='regReqList']//th")).Count;
            string Age = "";

            for (int i = 1; i <= count; i++)
            {

                string hearderName = driver.FindElement(By.XPath("//table[@id='regReqList']//th[" + i + "]")).Text;


                if (hearderName == label)
                {


                    Age = driver.FindElement(By.XPath("(//*[@id ='regReqList']//td)[" + i + "]")).Text;


                    break;
                }


            }
            result._Var = Age;
            return result;



        }
       

        #region SeleniumCommands
        //getattribute
        #endregion


        #region Wait
        public Boolean waitForElementToBeVisible(IWebDriver driver, By ele_Locator, WebDriverWait _WDWait)
        {

            try
            {
                _WDWait.Until(ExpectedConditions.ElementIsVisible(ele_Locator));


                if (driver.FindElement(ele_Locator).Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                objCommonMethods.WriteLogFileTestCaseErrorResult(KeyWords.strLogfilePath, e.Message, 3);
                return false;
            }


        }
        public Boolean waitForElementToBeClickable(IWebDriver driver, By ele_Locator, WebDriverWait _WDWait)
        {
            Result results = new Result();
            try
            {
                _WDWait.Until(ExpectedConditions.ElementToBeClickable(ele_Locator));

                if (driver.FindElement(ele_Locator).Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                ReportHandler._ChildTest.Log(LogStatus.Error, e.Message);
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = "Unable to find the expected element ";
                results.ErrorMessage1 = e.Message;
                return false;
            }


        }
        public Boolean waitForElementExists(IWebDriver driver, By ele_Locator, WebDriverWait _WDWait)
        {

            try
            {
                _WDWait.Until(ExpectedConditions.ElementExists(ele_Locator));

                if (driver.FindElement(ele_Locator).Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {

                return false;
            }


        }
        public Boolean waitForElementToBeSelected(IWebDriver driver, By ele_Locator, WebDriverWait _WDWait)
        {

            try
            {
                _WDWait.Until(ExpectedConditions.ElementToBeSelected(ele_Locator));

                if (driver.FindElement(ele_Locator).Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {

                return false;
            }


        }
        public Boolean waitForPageToLoad(IWebDriver driver, WebDriverWait _WDWait)
        {
            try
            {
                _WDWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("loading-overlay")));

                if (driver.FindElement(By.XPath("//div[@id='loading-overlay' and @style='display: none;']")).Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {

                return false;
            }
        }
        #endregion

        #region JavaScript Calls
        public Result jsClick(IWebDriver driver, String Locator, String strelement)
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
                    case "cssselector": element = driver.FindElement(By.CssSelector(strelement)); break;

                    default: break;
                }

                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                jse.ExecuteScript("arguments[0].click();", element);
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
        public Result jssendText(IWebDriver driver, String Locator, String strelement, String text)
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
                jse.ExecuteScript("arguments[0].value='" + text + "';", element);
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
        public Result jsCommand_Click(IWebDriver driver, String str_Command)
        {
            var results = new Result();
            try
            {
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                jse.ExecuteScript(str_Command);
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
        #endregion

        public String getLabelName(IWebDriver driver, String locator, String LocatorId, String sType = "", String sClassName = "")
        {
            var results = new Result();
            String sLableName = "";
            try
            {

                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                /*Returns Popup Tilte*/
                try
                {
                    if (sType.ToLower().Equals(KeyWords.Type_Popup))
                    {
                        sLableName = (String)jse.ExecuteScript("return $('div[aria-labelledby=\"ui-dialog-title-dialog\"]').find('div span.ui-dialog-title')[0].innerText");
                        if (sLableName != "")
                        {
                            ReportHandler._getChildTest().Log(LogStatus.Info, "Title of the Popup -" + sLableName);
                        }
                    }
                }
                catch
                {

                }
                if (LocatorId.Equals("DefaultContent_btnLog"))
                {
                    try
                    {
                        /*for Login button*/
                        sLableName = (String)jse.ExecuteScript("return $('#" + LocatorId + "')[0].value");
                    }
                    catch
                    {

                    }

                }
                else if (sType.Equals(KeyWords.Type_Button))
                {
                    try
                    {
                        /*Used for getting label names on button*/
                        sLableName = (String)jse.ExecuteScript("return $('#" + LocatorId + "')[0].innerText");

                    }
                    catch
                    {

                    }
                }
                if (sType.Equals(KeyWords.Type_Table) || sType.Equals(KeyWords.Type_table_radio_button))
                {
                    /*Used for getting label names of table headers*/
                    try
                    {
                        /*for radio buttons */
                        if (sType.Equals(KeyWords.Type_table_radio_button))
                        {
                            string sPropVal = (String)jse.ExecuteScript("return $('#" + LocatorId + "')[0].value");
                            String sParentName = (String)jse.ExecuteScript("return $('#" + LocatorId + "').parents('table').find('th[fieldName=\"" + LocatorId.Replace(sPropVal, "") + "\"]')[0].innerText");
                            sLableName = (String)jse.ExecuteScript("return $('#" + LocatorId + "').parent('label').find('span[for]')[0].innerText");
                            if (sParentName != "" && sLableName != "")
                            {
                                sLableName = sParentName + sLableName;
                            }
                            else
                            {
                                sLableName = sParentName;
                            }

                            sLableName = sLableName.Replace("\r\n", " ").Replace("\t", " ");
                        }
                        else if (sType.Equals(KeyWords.Type_Table))
                        {
                            sLableName = (String)jse.ExecuteScript("return $('#" + LocatorId + "').parents('table').find('thead').find('th[fieldName=\"" + LocatorId + "\"]')[0].innerText");
                        }

                    }
                    catch
                    {

                    }

                }

                try
                {
                    /*Reading Labels For radio button*/
                    if (sType.ToLower().Equals(KeyWords.Type_radio_button))
                    {
                        string sParentName = (String)jse.ExecuteScript("return $('#" + LocatorId + "').parents('div.form-group').find('label')[0].innerText");
                        sLableName = (String)jse.ExecuteScript("return $('#" + LocatorId + "').parent('label')[0].innerText");

                        if (sParentName != "" && sLableName != "")
                            sLableName = sParentName + sLableName;


                    }
                    else if (sType == "")
                        /*Reading Labels for Dropdowns, Typeaheads and textbox*/
                        sLableName = (String)jse.ExecuteScript("return $('#" + LocatorId + "').parents('div[class*=\"form-group\"]').find('label')[0].innerText");

                }
                catch
                {

                }

                if (sClassName != "")
                {
                    if (sClassName.Contains(" "))
                        sClassName.Replace(" ", ".");
                    sLableName = (String)jse.ExecuteScript("return $('div[aria-labelledby=\"ui-dialog-title-dialog\"]').find('button." + sClassName + "')[0].innerText");
                }
                results.Result1 = KeyWords.Result_PASS;
                return sLableName;
            }
            catch (Exception ex)
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = ex.Message;
                ReportHandler._getChildTest().Log(LogStatus.Error, ex.Message);
                return null;
            }
            finally
            {
                if (sLableName == "")
                    ReportHandler._getLblChildTest().Log(LogStatus.Info, "<b>Unable to find Label Name for the given Locator " + LocatorId);
            }
        }

        public Boolean _XMLReader()
        {
            XmlDocument xml_Doc = new XmlDocument();
            xml_Doc.Load(KeyWords.XMLFilePath);

            XmlNodeList nodeList = xml_Doc.DocumentElement.GetElementsByTagName("add");
            
            KeyWords.LabelDictionary.Clear();
            foreach (XmlNode node in nodeList)
            {
                KeyWords.LabelDictionary.Add(node.Attributes["key"].Value, node.Attributes["value"].Value);
            }

            return KeyWords.LabelDictionary.Count > 0 ? true : false;

        }
        
    }


}