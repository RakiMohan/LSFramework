using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using System.Diagnostics;
using OpenQA.Selenium.Interactions;
using RelevantCodes.ExtentReports;
using CommonFiles;
using SmartTrack.DataAccess.Repository;
using SmartTrack.DataAccess.Models;
using SmartTrack;



namespace SmartTrack_Automation
{
    public class BroadCastActions
    {

       
    KeyWordMethods kwm = new KeyWordMethods();

            CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();

            public Result sendReminder(IWebDriver WDriver, DataRow Broadcast_Data)
            {

                kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
                CommonMethods objCommonMethods = new CommonMethods();
                var results = new Result();
                
                @ReadExcel ReadExcelHelper = new ReadExcel();
              //  WorksapcRequirementModel worksapcereq = createRequirementRepository.Getworkspacerequiement(Workspace_Requirement);
                //IList<string> approver_list = new List<string>();
                //Dictionary<string, string> dict_Approvers = new Dictionary<string, string>();
                bool bVal_Approved = false;
                WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));
                BroadcastModel broadcastModel = createRequirementRepository.GetBroadcastData(Broadcast_Data);
                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

                


                // client selection 
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        // return results;
                    }
                }
                //   click on main menu given name
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }

                // Wait for requirement to be loaded



                objCommonMethods.Action_Page_Down(WDriver);
                try
                {
                    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));
                    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));


                    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();


                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);
                }
                catch
                {
                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Txt_Filter_ReqNumber);

                    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();

                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, "Submitted to");
                }


                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));

                Thread.Sleep(2000);

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

                // click on first req number with approval status

                //int requistionscountwithapprovestatus = WDriver.FindElements(By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus)).Count;

                //Thread.Sleep(2000);
                //List<String> listofrequistionscountwithapprovestatus = new List<string>();
                //for (int j = 1; j <= requistionscountwithapprovestatus; j++)
                //{
                //    listofrequistionscountwithapprovestatus.Add(WDriver.FindElement(By.XPath("//*[@id='regReqList']/tbody/tr[" + j + "]/td[2]/a")).Text);
                //}


                //for (int i = 0; i < requistionscountwithapprovestatus; i++)
                //{
                //    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));

                    //WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();
                    //kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, listofrequistionscountwithapprovestatus[i]);

                    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
                    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));

                    kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus);
                    //wait until  Action list is loaded

                    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Myworkspace_Req_saveascatalog))));
                    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Myworkspace_Req_saveascatalog))));



                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_saveascatalog);

                    Thread.Sleep(2000);

                    kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_saveascatalog);

                    Thread.Sleep(2000);

                    if (kwm.isElementDisplayed(WDriver, KeyWords.ID_saveascatalaog_NameCatalog))
                    {

                        kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Closebutton_saveascatalog);


                        // click on send remainder in action list 

                        wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Myworkspace_Req_sendReminder))));
                        wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Myworkspace_Req_sendReminder))));

                        kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_sendReminder);

                        objCommonMethods.Action_Page_Down(WDriver);
                        // wait untill send Remainder popup will displayed 

                        wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.Id_SendRemainder_emailList))));
                        wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.Id_SendRemainder_emailList))));


                        SelectElement se = new SelectElement(WDriver.FindElement((By.Id(KeyWords.Id_SendRemainder_emailList)))); //Locating select list

                        IList<IWebElement> ElementCount = se.Options;
                        int NumberOfemails = ElementCount.Count;

                        if (NumberOfemails > 0)
                        {
                            se.SelectByIndex(0);
                           
                        }
                        else
                        {
                            // click on submitt button 

                            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_class, KeyWords.locator_class_button, broadcastModel.str_Btn_Submit);
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                Thread.Sleep(3000);
                                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_class_button, broadcastModel.str_Btn_Submit);
                                if (results.Result1 == KeyWords.Result_FAIL)
                                {
                                    return results;
                                }
                            }

                            objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

                            Thread.Sleep(2000);
                        }
                    }

                    else
                    {

                        kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Closebutton_saveascatalog);
                    }


                    Thread.Sleep(2000);

                    kwm.select_MSG_Button_Close(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Close");

                    kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.ID_returnList);


                

                // click on submitt button 

                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_class, KeyWords.locator_class_button, broadcastModel.str_Btn_Submit);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(3000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_class_button, broadcastModel.str_Btn_Submit);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }

                // click on yes button 

                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_class, KeyWords.locator_class_button, "Yes");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(2000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_class_button, "Yes");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

                // click on Close button 
                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Closebutton))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Closebutton))));


                results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Closebutton);

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(3000);
                    results = kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Closebutton);

                }


                /*     END OF send remainder   */


                //results = kwm.GetText_Xpath(WDriver, KeyWords.XPath_Link_SearchResult_CW);

               // string strUpdateMailIDinTimesheet = "Update [MSP$] set P6 = '" + results._Var + "'  WHERE TestCaseID= 'WR004' and P3 ='" + worksapcereq.strClientName + "'";
               // ReadExcelHelper.UpdateDataToExcelFile(KeyWords.strExlInputPath, strUpdateMailIDinTimesheet);



                results.Result1 = KeyWords.Result_PASS;

                return results;
            }
    
            //public Result addComments(IWebDriver WDriver, DataRow Broadcast_Data,  string target)
            //{

            //    kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
            //    CommonMethods objCommonMethods = new CommonMethods();
            //    var results = new Result();
            //    CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
                
            //   // WorksapcRequirementModel worksapcereq = createRequirementRepository.Getworkspacerequiement(Workspace_Requirement);
             
            //    //IList<string> approver_list = new List<string>();
            //    //Dictionary<string, string> dict_Approvers = new Dictionary<string, string>();
            //    bool bVal_Approved = false;
            //    WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));
            //    BroadcastModel broadcastModel = createRequirementRepository.GetBroadcastData(Broadcast_Data);


            //    //   click on main menu given name
            //    //results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, worksapcereq.strMainMenuLink, worksapcereq.strSubMenuLink);
            //    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, "My Workspace","Requirements");
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        Thread.Sleep(5000);
            //        //results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, worksapcereq.strMainMenuLink, worksapcereq.strSubMenuLink);
            //        results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, "My Workspace", "Requirements");
            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            //results.ErrorMessage1 = "Unable to click on the Main menu";
            //            return results;
            //        }
            //    }

            //    // Wait for requirement to be loaded



            //    objCommonMethods.Action_Page_Down(WDriver);
            //    try
            //    {
            //        wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));
            //        wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));


            //        WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();


            //        kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);
            //    }
            //    catch
            //    {
            //        kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Txt_Filter_ReqNumber);

            //        WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();

            //        kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);
            //    }



            //    Thread.Sleep(2000);

            //    objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");


            //    // wait for  req number 
            //    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
            //    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
            //    kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus);

            //    /* click on Add comments  starts  */

            //    wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_List_listMenu1))));
            //    wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_List_listMenu1))));


            //    // click on Add comment
            //    kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_addcomments);

            //    // enter comments 

            //    wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_Txt_TxtComment))));
            //    wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_Txt_TxtComment))));

            //    objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

            //    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, target);

            //    kwm.sendText(WDriver, KeyWords.locator_ID, target, "Comment Added", false);

            //    // click on submitt button 

            //    results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Submit_button);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        Thread.Sleep(3000);
            //        results = kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.Xpath_Submit_button);
            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            return results;
            //        }
            //    }

            //    objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
            //    // click on yes button 

            //    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Yes_button_dialog_confirmreqcomm1))));
            //    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Yes_button_dialog_confirmreqcomm1))));

            //    results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Yes_button_dialog_confirmreqcomm1);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        Thread.Sleep(3000);
            //        results = kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.Xpath_Yes_button_dialog_confirmreqcomm1);
            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            return results;
            //        }
            //    }

            //    objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
             

            //    // Click on OK button
            //    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        Thread.Sleep(5000);
            //        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "OK");
            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            Thread.Sleep(3000);
            //            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
            //            if (results.Result1 == KeyWords.Result_FAIL)
            //            {
            //                return results;
            //            }
            //        }
            //    }

            //    results.Result1 = KeyWords.Result_PASS;
            //    results.ErrorMessage = "Success";
            //    return results;

            //}


            public Result addComments(IWebDriver WDriver, DataRow Broadcast_Data, string target)
            {

                kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
                CommonMethods objCommonMethods = new CommonMethods();
                var results = new Result();
                CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();

                // WorksapcRequirementModel worksapcereq = createRequirementRepository.Getworkspacerequiement(Workspace_Requirement);

                //IList<string> approver_list = new List<string>();
                //Dictionary<string, string> dict_Approvers = new Dictionary<string, string>();
                bool bVal_Approved = false;
                WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));
                BroadcastModel broadcastModel = createRequirementRepository.GetBroadcastData(Broadcast_Data);


                //   click on main menu given name
                //results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, worksapcereq.strMainMenuLink, worksapcereq.strSubMenuLink);
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, "My Workspace", "Requirements");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    //results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, worksapcereq.strMainMenuLink, worksapcereq.strSubMenuLink);
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, "My Workspace", "Requirements");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }

                // Wait for requirement to be loaded



                objCommonMethods.Action_Page_Down(WDriver);
                try
                {
                    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));
                    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));


                    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();


                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);
                }
                catch
                {
                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Txt_Filter_ReqNumber);

                    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();

                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);
                }



                Thread.Sleep(2000);

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");


                // wait for  req number 
                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
                kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus);

                /* click on Add comments  starts  */

                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_List_listMenu1))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_List_listMenu1))));


                // click on Add comment
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_addcomments);

                // enter comments 

                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_Txt_TxtComment))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_Txt_TxtComment))));

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, target);


                string mycomment = "mycomment" + DateTime.Now.ToString("_yyyyMMdd_HHMMss"); ;
                kwm.sendText(WDriver, KeyWords.locator_ID, target, mycomment, false);

                // click on submitt button 

                results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Submit_button);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(3000);
                    results = kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.Xpath_Submit_button);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                // click on yes button 

                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(3000);
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }
                }


                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");


                // Click on OK button
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "OK");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(3000);
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }
                }



                /* Wait for page to load after adding comment  */

                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_List_listMenu1))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_List_listMenu1))));

                // Click on Expand All button
                kwm.jsClick(WDriver, KeyWords.locator_ID, "tabsAll");
                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[@id='Table2_filter']//input");
                if (kwm.isElementDisplayedXpath(WDriver, "//*[@id='Table2_filter']//input"))
                {
                    kwm.sendText(WDriver, KeyWords.locator_XPath, "//*[@id='Table2_filter']//input", mycomment, false);
                    if (kwm.GetText_Xpath(WDriver, "//table[@id='Table2']//td[@class='lastChildPR']")._Var == mycomment)
                    {
                        results.Result1 = KeyWords.Result_PASS;
                        results.ErrorMessage = "Success";
                        return results;
                    }
                    else
                    {
                        results.Result1 = KeyWords.Result_FAIL;
                        results.ErrorMessage = "Fail";
                        return results;
                    }
                }
                else
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Fail";
                    return results;
                }

            }

            public Result requeueMethod(IWebDriver WDriver, DataRow Broadcast_Data, string added_Manager, string update_manager)
            {

                kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
                CommonMethods objCommonMethods = new CommonMethods();
                var results = new Result();
                CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();

               // WorksapcRequirementModel worksapcereq = createRequirementRepository.Getworkspacerequiement(Workspace_Requirement);
                //IList<string> approver_list = new List<string>();
                //Dictionary<string, string> dict_Approvers = new Dictionary<string, string>();

                WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));
                BroadcastModel broadcastModel = createRequirementRepository.GetBroadcastData(Broadcast_Data);

                //   click on main menu given name
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }

                // Wait for requirement to be loaded

                objCommonMethods.Action_Page_Down(WDriver);
                try
                {
                    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));
                    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));


                    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();


                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);
                }
                catch
                {
                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Txt_Filter_ReqNumber);

                    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();

                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);
                }



                Thread.Sleep(2000);

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");


                // wait for  req number 
                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
                kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus);


                // click on Reuqueu
                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_List_listMenu1))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_List_listMenu1))));
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_reque);

                Thread.Sleep(2000);
                // click on submitt button 
                objCommonMethods.Action_Page_Down(WDriver);

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                // click on requeue list 
                kwm.jsClick(WDriver, KeyWords.locator_ID, "wEnd");

                // add approver

               // if (broadcastModel.str_addapprover != "")
                //{
                    //  Thread.Sleep(2000);
                   // results = kwm.select_List_typeahead(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_requeueList_addApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, worksapcereq.str_addapprover, worksapcereq.str_addapprover);
                results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_requeueList_addApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, added_Manager, added_Manager);    
                if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_requeueList_addApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, worksapcereq.str_addapprover, worksapcereq.str_addapprover);
                        results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_requeueList_addApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, added_Manager ,added_Manager );    
                    //  return results;
                    }
               // }

                // click on add button

                results = kwm.click(WDriver,KeyWords.locator_ID,"Button3");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(2000);
                    results = kwm.click(WDriver, KeyWords.locator_ID, "Button3");

                }
                // click on approver add button

               // kwm.jsClick(WDriver, KeyWords.locator_XPath, "//*[contains(@id, 'indiviual')]/span[contains(text(),'" + broadcastModel.str_addapprover + "')]");

                kwm.jsClick(WDriver, KeyWords.locator_XPath, "//td[@id='tEnd']//div[@type='indiviual']");

                // update approver
               // if (broadcastModel.str_addapprover_update != "")
               // {
                    //  Thread.Sleep(2000);
                  //  results = kwm.select_List_typeahead(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_requeueList_addApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, worksapcereq.str_addapprover_update, worksapcereq.str_addapprover_update);
                results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_requeueList_addApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, update_manager, update_manager);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                      //  results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_requeueList_addApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, worksapcereq.str_addapprover_update, worksapcereq.str_addapprover_update);
                        results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_requeueList_addApprover, KeyWords.locator_class, KeyWords.CL_list_typeahead, update_manager, update_manager);
                        //  return results;
                    }
              //  }

                // click on UPdate

                kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.ID_addButton_btnUpdate);


                // click on approver add button

                kwm.jsClick(WDriver, KeyWords.locator_XPath, "//td[@id='tEnd']//div[@type='indiviual']");

                // click on requeue reomve button 
                kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.ID_btn_removeRequeue_btnRemove);


                // selecting reason for requeue

                results = kwm.select(WDriver, KeyWords.locator_ID, "reason", "Change in approvers");

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                
                results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, "reason", 1);
                }


                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_btnSubmit);

                results = kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_btnSubmit);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(3000);
                    results = kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_btnSubmit);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

                // click on yes button  


                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(3000);
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }
                }

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

                // Click on OK button
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "OK");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(3000);
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }
                }
                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = "Success";
                return results;

                /* click on Requeqe Ends  */

            }

            public Result cancelRequisition(IWebDriver WDriver, DataRow Broadcast_Data)
            {
                kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
                CommonMethods objCommonMethods = new CommonMethods();
                var results = new Result();
                CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();

               // WorksapcRequirementModel worksapcereq = createRequirementRepository.Getworkspacerequiement(Workspace_Requirement);
                //IList<string> approver_list = new List<string>();
                //Dictionary<string, string> dict_Approvers = new Dictionary<string, string>();

                WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));
                BroadcastModel broadcastModel = createRequirementRepository.GetBroadcastData(Broadcast_Data);


                //   click on main menu given name
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }

                // Wait for requirement to be loaded



                objCommonMethods.Action_Page_Down(WDriver);
                try
                {
                    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));
                    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));


                    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();


                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);
                }
                catch
                {
                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Txt_Filter_ReqNumber);

                    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();

                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);
                }



                Thread.Sleep(2000);

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");


                // wait for  req number 
                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
                kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus);


                // cancel starts
                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_List_listMenu1))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_List_listMenu1))));


                // click on cancel button 
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_Cancel);


                // wait for select for reason to cancel appers 


                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_Select_CancelReason))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_Select_CancelReason))));

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

                // select reason for cancel
                //if (broadcastModel.str_Select_CancelReason != "")
               // {
                   // results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_CancelReason, broadcastModel.str_Select_CancelReason);

                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_CancelReason, "Cancelled: Needs Changed");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                       // results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_CancelReason, broadcastModel.str_Select_CancelReason);

                        results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_CancelReason,1);
                        //  return results;
                    }
               // }


                // enter comment

                // kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Comment_Textarea1, broadcastModel.str_Txt_addComments, false);

                    objCommonMethods.Action_Button_Tab(WDriver);
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_Comment_Textarea1, "Test", false);

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

                // Cancel requirement
                //results = kwm.select_MSG_Button(WDriver, KeyWords.locator_class, KeyWords.locator_class_button, broadcastModel.str_Btn_CancelRequirement);
                //if (results.Result1 == KeyWords.Result_FAIL)
                //{
                //    Thread.Sleep(3000);
                //    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_class_button, broadcastModel.str_Btn_CancelRequirement);
                //    if (results.Result1 == KeyWords.Result_FAIL)
                //    {
                //        return results;
                //    }
                //}

                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_class, KeyWords.locator_class_button, "Cancel Requirement");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(3000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_class_button, "Cancel Requirement");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                // click on yes button 

                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Yes_button_cancelconfirm))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Yes_button_cancelconfirm))));

                results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Yes_button_cancelconfirm);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(3000);
                    results = kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.Xpath_Yes_button_cancelconfirm);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                 

                // Click on OK button
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "OK");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(3000);
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }
                }
                
                
                
                // End of Cancel Requirement

                // verification of req number in search requirement       

                //   click on main menu given name
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, "Search Requirements");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(2000);
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, "Search Requirements");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }


                // wait for status menu 

                wait.Until(ExpectedConditions.ElementIsVisible((By.Id("ddlReqStatus"))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id("ddlReqStatus"))));

                results = kwm.selectDropDown(WDriver, KeyWords.locator_ID, "ddlReqStatus", "Cancelled");

                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(2000);
                    results = kwm.selectDropDown(WDriver, KeyWords.locator_ID, "ddlReqStatus", "Cancelled");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }

              //  objCommonMethods.Action_Page_Down(WDriver);

                kwm.Action_MoveElement(WDriver, "btnSearchReq");

                results = kwm.jsClick(WDriver, KeyWords.locator_ID, "btnSearchReq");

                // enter req number in searck feld

                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//*[@id='regReqSearchList_filter']//input"))));

                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[@id='regReqSearchList_filter']//input");

                results = kwm.sendTextXPathOnly(WDriver, "//*[@id='regReqSearchList_filter']//input", broadcastModel.str_Link_ReqNumber);



                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("(//*[@id='regReqSearchList']//a)[1]"))));
               // wait.Until(ExpectedConditions.ElementToBeClickable((By.Id("(//*[@id='regReqSearchList']//a)[1]"))));

                string ReqNumber = WDriver.FindElement(By.XPath("(//*[@id='regReqSearchList']//a)[1]")).Text;



                if (ReqNumber == broadcastModel.str_Link_ReqNumber)
                {

                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Success";
                    return results;

                }
                else {
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Failed";
                    return results;
                
                }

            }

            //public Result saveAsCatalog(IWebDriver WDriver, DataRow Broadcast_Data)
            //{
            //    kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
            //    CommonMethods objCommonMethods = new CommonMethods();
            //    var results = new Result();
            //    CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();

            //   // WorksapcRequirementModel worksapcereq = createRequirementRepository.Getworkspacerequiement(Workspace_Requirement);
            //    //IList<string> approver_list = new List<string>();
            //    //Dictionary<string, string> dict_Approvers = new Dictionary<string, string>();

            //    WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));

            //    BroadcastModel broadcastModel = createRequirementRepository.GetBroadcastData(Broadcast_Data);

            //    //   click on main menu given name
            //    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        Thread.Sleep(5000);
            //        results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            //results.ErrorMessage1 = "Unable to click on the Main menu";
            //            return results;
            //        }
            //    }

            //    // Wait for requirement to be loaded



            //    objCommonMethods.Action_Page_Down(WDriver);
            //    try
            //    {
            //        wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));
            //        wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));

            //        try
            //        {
            //            WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();
            //        }

            //        catch { 
            //        //
            //        }
            //        kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);
            //    }
            //    catch
            //    {
            //        kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Txt_Filter_ReqNumber);

            //        try
            //        {
            //            WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();
            //        }

            //        catch
            //        {
            //            //
            //        }

            //        kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);
            //    }



            //    Thread.Sleep(2000);

            //    objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");


            //    // wait for  req number 
            //    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
            //    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
            //    kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus);



            //    // click on save as catalog 

            //    wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_List_listMenu1))));
            //    wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_List_listMenu1))));


            //    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_saveascatalog);
            //    // click on Edit button 
            //    kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_saveascatalog);


            //    Thread.Sleep(2000);


            //    // enter catalog name 

            //    if (kwm.isElementDisplayed(WDriver, KeyWords.ID_saveascatalaog_NameCatalog))
            //    {
            //        DateTime date1 = DateTime.Now;

            //        string catalogname = date1.ToString("yyyyMMddHHmmss");

            //        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_saveascatalaog_NameCatalog, catalogname, false);

            //        objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

            //        // click on submitt button 
            //        results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Submit_button);
            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            Thread.Sleep(3000);
            //            results = kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.Xpath_Submit_button);
            //            if (results.Result1 == KeyWords.Result_FAIL)
            //            {
            //                return results;
            //            }
            //        }


            //        objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
            //        // click on yes button 

            //        //wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Yes_button_dialog_confirmreqcomm1))));
            //        //wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Yes_button_dialog_confirmreqcomm1))));

            //        //results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Yes_button_dialog_confirmreqcomm1);
            //        //if (results.Result1 == KeyWords.Result_FAIL)
            //        //{
            //        //    Thread.Sleep(3000);
            //        //    results = kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.Xpath_Yes_button_dialog_confirmreqcomm1);
            //        //    if (results.Result1 == KeyWords.Result_FAIL)
            //        //    {
            //        //        return results;
            //        //    }
            //        //}


            //        // click on yes button  


            //        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            Thread.Sleep(5000);
            //            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
            //            if (results.Result1 == KeyWords.Result_FAIL)
            //            {
            //                Thread.Sleep(3000);
            //                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
            //                if (results.Result1 == KeyWords.Result_FAIL)
            //                {
            //                    return results;
            //                }
            //            }
            //        }

            //        objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
            //        // click on Ok button 
            //        wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Ok_button_SaveCatalogSuccessDialog))));
            //        wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Ok_button_SaveCatalogSuccessDialog))));

            //        results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Ok_button_SaveCatalogSuccessDialog);
            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            Thread.Sleep(3000);
            //            results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Ok_button);
            //            if (results.Result1 == KeyWords.Result_FAIL)
            //            {
            //                return results;
            //            }
            //        }
            //    }

            //    else
            //    {

            //        kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Closebutton_saveascatalog);
            //    }
            //    // End of catalog //

            //    results.Result1 = KeyWords.Result_PASS;
            //    results.ErrorMessage = "Success";
            //    return results;
            //}

            public Result saveAsCatalog(IWebDriver WDriver, DataRow Broadcast_Data)
            {
                kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
                CommonMethods objCommonMethods = new CommonMethods();
                var results = new Result();
                CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();

                // WorksapcRequirementModel worksapcereq = createRequirementRepository.Getworkspacerequiement(Workspace_Requirement);
                //IList<string> approver_list = new List<string>();
                //Dictionary<string, string> dict_Approvers = new Dictionary<string, string>();

                WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));

                BroadcastModel broadcastModel = createRequirementRepository.GetBroadcastData(Broadcast_Data);

                //   click on main menu given name
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }

                // Wait for requirement to be loaded



                objCommonMethods.Action_Page_Down(WDriver);
                try
                {
                    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));
                    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));

                    try
                    {
                        WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();
                    }

                    catch
                    {
                        //
                    }
                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);
                }
                catch
                {
                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Txt_Filter_ReqNumber);

                    try
                    {
                        WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();
                    }

                    catch
                    {
                        //
                    }

                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);
                }



                Thread.Sleep(2000);

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");


                // wait for  req number 
                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
                kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus);



                // click on save as catalog 

                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_List_listMenu1))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_List_listMenu1))));


                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_saveascatalog);
                // click on Edit button 
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_saveascatalog);


                Thread.Sleep(2000);


                // enter catalog name 
                string catalogname = null;
                if (kwm.isElementDisplayed(WDriver, KeyWords.ID_saveascatalaog_NameCatalog))
                {
                    catalogname = "MyCatalog_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_saveascatalaog_NameCatalog, catalogname, false);

                    objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

                    // click on submitt button 
                    results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Submit_button);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(3000);
                        results = kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.Xpath_Submit_button);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }


                    objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

                    // click on yes button 
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(5000);
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            Thread.Sleep(3000);
                            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
                            if (results.Result1 == KeyWords.Result_FAIL)
                            {
                                return results;
                            }
                        }
                    }


                    objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

                    // click on Ok button 
                    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Ok_button_SaveCatalogSuccessDialog))));
                    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Ok_button_SaveCatalogSuccessDialog))));

                    results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Ok_button_SaveCatalogSuccessDialog);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(3000);
                        results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Ok_button);
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }
                }

                else
                {

                    kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Closebutton_saveascatalog);
                }
                // End of catalog //






                //   click on main menu given name
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, "Requirements", "Create Requirements");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, "Requirements", "Create Requirements");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }

                kwm.waitForElementToBeVisible(WDriver, By.XPath("//*[@class='instedEM' and text()='Quick Pick from a Catalog']"), kwm._WDWait);
                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[text()='Quick Pick from a Catalog']");
                kwm.select_RequisitionType(WDriver, "Quick Pick from a Catalog");

                //Catalog page code

                kwm.waitForElementToBeClickable(WDriver, By.Id("searchButton1"), wait);
                kwm.jsClick(WDriver, KeyWords.locator_ID, "searchButton1");

                kwm.waitForElementToBeClickable(WDriver, By.XPath("//div[@id='tblJobTitle_filter']//input"), wait);
                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//div[@id='tblJobTitle_filter']//input");
                if (kwm.isElementDisplayedXpath(WDriver, "//div[@id='tblJobTitle_filter']//input"))
                {
                    kwm.sendText(WDriver, KeyWords.locator_XPath, "//div[@id='tblJobTitle_filter']//input", catalogname, false);
                    Thread.Sleep(2000);
                    if (kwm.GetText_Xpath(WDriver, "//table[@id='tblJobTitle']//td[contains(@aria-label, 'Catalog Name')]")._Var == catalogname)
                    {
                        results.Result1 = KeyWords.Result_PASS;
                        results.ErrorMessage = "Sucess";
                        return results;
                    }
                    else
                    {
                        results.Result1 = KeyWords.Result_FAIL;
                        results.ErrorMessage = "Fail";
                        return results;
                    }

                }
                else
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Fail";
                    return results;
                }
            }

            public Result assignMspPoc(IWebDriver WDriver, DataRow Broadcast_Data)
            {
                kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
                CommonMethods objCommonMethods = new CommonMethods();
                var results = new Result();
                CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();

             //   WorksapcRequirementModel worksapcereq = createRequirementRepository.Getworkspacerequiement(Workspace_Requirement);
                //IList<string> approver_list = new List<string>();
                //Dictionary<string, string> dict_Approvers = new Dictionary<string, string>();
                bool bVal_Approved = false;
                WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));
                BroadcastModel broadcastModel = createRequirementRepository.GetBroadcastData(Broadcast_Data);

                //   click on main menu given name
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }

                // Wait for requirement to be loaded



                objCommonMethods.Action_Page_Down(WDriver);
                try
                {
                    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));
                    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));


                    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();


                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);
                }
                catch
                {
                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Txt_Filter_ReqNumber);

                    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();

                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);
                }



                Thread.Sleep(2000);

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");


                // wait for  req number 
                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
                kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus);

                // Assign MSP point of contact //

                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_List_listMenu1))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_List_listMenu1))));


                // click on Assign MSP POC button 
                kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_AssignMSPPointofContact);

                // wait for assign msp poc appears


                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_assignmspoc_txtassignmsppoc))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_assignmspoc_txtassignmsppoc))));

                // enter MSP POC name 

               // if (broadcastModel.str_assignmspoc_txtassignmsppoc != "")
               // {
                    //  Thread.Sleep(2000);
                   // results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_assignmspoc_txtassignmsppoc, KeyWords.locator_class, KeyWords.CL_list_typeahead, broadcastModel.str_assignmspoc_txtassignmsppoc, worksapcereq.str_assignmspoc_txtassignmsppoc);
                results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_assignmspoc_txtassignmsppoc, KeyWords.locator_class, KeyWords.CL_list_typeahead, "Akbar, Hilal");    
                if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results = kwm.select_List_typeahead_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_assignmspoc_txtassignmsppoc, KeyWords.locator_class, KeyWords.CL_list_typeahead, broadcastModel.str_assignmspoc_txtassignmsppoc, worksapcereq.str_assignmspoc_txtassignmsppoc);

                        results = kwm.select_List_typeahead_temp_AnyOne(WDriver, KeyWords.locator_ID, KeyWords.ID_assignmspoc_txtassignmsppoc, KeyWords.locator_class, KeyWords.CL_list_typeahead, "Akbar, Hilal");
                    //  return results;
                    }
              //  }

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                // click on submitt button 
                results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Submit_button);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(3000);
                    results = kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.Xpath_Submit_button);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                // click on yes button 

                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Yes_button_dialog_confirmmsg))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Yes_button_dialog_confirmmsg))));

                results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Yes_button_dialog_confirmmsg);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(3000);
                    results = kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.Xpath_Yes_button_dialog_confirmmsg);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                // click on Ok button 

                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Ok_button_msppoc))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Ok_button_msppoc))));
                results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Ok_button_msppoc);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(3000);
                    results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Ok_button_msppoc);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }

                // end of Assign MSP POC Xpath_Myworkspace_Req_Cancel

                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = "Success";
                return results;
            }

            //public Result editRequisition(IWebDriver WDriver, DataRow Workspace_Requirement)
            //{
            //    kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
            //    CommonMethods objCommonMethods = new CommonMethods();
            //    var results = new Result();
            //    CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();

            //    WorksapcRequirementModel worksapcereq = createRequirementRepository.Getworkspacerequiement(Workspace_Requirement);
            //    //IList<string> approver_list = new List<string>();
            //    //Dictionary<string, string> dict_Approvers = new Dictionary<string, string>();
            //    bool bVal_Approved = false;
            //    WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));


            //    //   click on main menu given name
            //    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, worksapcereq.strMainMenuLink, worksapcereq.strSubMenuLink);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        Thread.Sleep(5000);
            //        results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, worksapcereq.strMainMenuLink, worksapcereq.strSubMenuLink);
            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            //results.ErrorMessage1 = "Unable to click on the Main menu";
            //            return results;
            //        }
            //    }

            //    // Wait for requirement to be loaded



            //    objCommonMethods.Action_Page_Down(WDriver);
            //    try
            //    {
            //        wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));
            //        wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));


            //        WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();


            //        kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, worksapcereq.strReqNumber);
            //    }
            //    catch
            //    {
            //        kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Txt_Filter_ReqNumber);

            //        WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();

            //        kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, worksapcereq.strReqNumber);
            //    }



            //    Thread.Sleep(2000);

            //    objCommonMethods.SaveScreenShot_EachPage(WDriver, worksapcereq.strClientName + "_");


            //    // wait for  req number 
            //    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
            //    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
            //    kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus);


            //    /* click on Edit  starts  */

            //    wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_List_listMenu1))));
            //    wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_List_listMenu1))));

            //    objCommonMethods.SaveScreenShot_EachPage(WDriver, worksapcereq.strClientName + "_");
            //    // click on Edit button 
            //    kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_edit);


            //    wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_btntab_first))));
            //    wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_btntab_first))));

            //    // click on first tab 
            //    kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btntab_first);


            //    // change organization id 

            //    wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_T1_select_Organization_organizationID))));
            //    wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_T1_select_Organization_organizationID))));

            //    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Organization_organizationID);
            //    if (worksapcereq.str_T1_select_Department_organizationID != "")
            //    {
            //        results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Organization_organizationID, worksapcereq.str_T1_select_Department_organizationID);
            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_select_Organization_organizationID, worksapcereq.str_T1_select_Department_organizationID);
            //            //  return results;
            //        }
            //    }
            //    Thread.Sleep(2000);

            //    objCommonMethods.Action_Button_Tab(WDriver);
            //    objCommonMethods.SaveScreenShot_EachPage(WDriver, worksapcereq.strClientName + "_");
            //    Thread.Sleep(2000);
            //    // objCommonMethods.Action_Page_UP(WDriver);

            //    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_T5_btn_tab5);

            //    // click on fifth tab ID_T5_btn_tab_fifth
            //    kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.ID_T5_btn_tab5);



            //    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_btnSubmit);

            //    // Click on Submit button 

            //    results = kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_btnSubmit);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        Thread.Sleep(3000);
            //        results = kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_btnSubmit);
            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            return results;
            //        }
            //    }
            //    objCommonMethods.SaveScreenShot_EachPage(WDriver, worksapcereq.strClientName + "_");
            //    // click on yes button 

            //    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Yes_button_dialog_reqSubmiteDialog))));
            //    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Yes_button_dialog_reqSubmiteDialog))));

            //    results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Yes_button_dialog_reqSubmiteDialog);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        Thread.Sleep(3000);
            //        results = kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.Xpath_Yes_button_dialog_reqSubmiteDialog);
            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            return results;
            //        }
            //    }
            //    // End of Edit button //

            //    results.Result1 = KeyWords.Result_PASS;
            //    results.ErrorMessage = "Success";
            //    return results;

            //}

            //public Result changeStatus(IWebDriver WDriver, DataRow Broadcast_Data,string status)
            //{


            //    /* change status */
            //    kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
            //    CommonMethods objCommonMethods = new CommonMethods();
            //    var results = new Result();
            //    CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();

            //  //  WorksapcRequirementModel worksapcereq = createRequirementRepository.Getworkspacerequiement(Workspace_Requirement);
            //    //IList<string> approver_list = new List<string>();
            //    //Dictionary<string, string> dict_Approvers = new Dictionary<string, string>();
            //    bool bVal_Approved = false;
            //    WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));

            //    BroadcastModel broadcastModel = createRequirementRepository.GetBroadcastData(Broadcast_Data);
            //    // client selection 
            //    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        Thread.Sleep(5000);
            //        results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            //results.ErrorMessage1 = "Unable to click on the Main menu";
            //            // return results;
            //        }
            //    }

            //    //   click on main menu given name
            //    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        Thread.Sleep(5000);
            //        results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            //results.ErrorMessage1 = "Unable to click on the Main menu";
            //            return results;
            //        }
            //    }

            //    // Wait for requirement to be loaded



            //    objCommonMethods.Action_Page_Down(WDriver);
            //    //try
            //    //{
            //    //    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));
            //    //    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));


            //    //    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();


            //    //    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, worksapcereq.strReqNumber);
            //    //}
            //    //catch
            //    //{
            //    //    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Txt_Filter_ReqNumber);

            //    //    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();

            //    //    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, worksapcereq.strReqNumber);
            //    //}



            //    //Thread.Sleep(2000);

            //    objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");


            //    try
            //    {
            //        wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));
            //        wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));


            //        WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();


            //        kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);


            //        Thread.Sleep(1000);
            //    }
            //    catch
            //    {
            //        kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Txt_Filter_ReqNumber);

            //        WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();

            //        kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, "Open");
            //    }

            //    // wait for  req number 
            //    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//*[@id='regReqList']/tbody/tr/td/a[contains(text(),'" + broadcastModel.str_Link_ReqNumber + "')]"))));
            //    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath("//*[@id='regReqList']/tbody/tr/td/a[contains(text(),'" + broadcastModel.str_Link_ReqNumber + "')]"))));
            //    kwm.jsClick(WDriver, KeyWords.locator_XPath, "//*[@id='regReqList']/tbody/tr/td/a[contains(text(),'" + broadcastModel.str_Link_ReqNumber + "')]");


            //    /* wait  for action list menu  */

            //    wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_List_listMenu1))));
            //    wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_List_listMenu1))));

            //    objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

            //    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_ChangeStatus);

            //    // click on chnage status button 
            //    kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_ChangeStatus);



            //        // click on chnage status button 
            //        wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Myworkspace_Req_ChangeStatus))));
            //        wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Myworkspace_Req_ChangeStatus))));
            //        kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_ChangeStatus);

            //        // wait for page loading 
            //        wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_Txt_TxtComment))));
            //        wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_Txt_TxtComment))));


            //        // select status 
            //        kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Statuslist, status);

                    
            //        // send comments 
            //           // kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_changestatus_Comments, broadcastModel.str_ID_comment, false);

            //            kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_changestatus_Comments, "Test", false);


            //            objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
            //        //click on submit button

            //        kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_button_Submit);


            //        objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
            //        //// Click on Yes button
            //        //results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, broadcastModel.str_Btn_Yes);
            //        //if (results.Result1 == KeyWords.Result_FAIL)
            //        //{
            //        //    Thread.Sleep(5000);
            //        //    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, broadcastModel.str_Btn_Yes);
            //        //    if (results.Result1 == KeyWords.Result_FAIL)
            //        //    {
            //        //        Thread.Sleep(3000);
            //        //        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, broadcastModel.str_Btn_Yes);
            //        //        if (results.Result1 == KeyWords.Result_FAIL)
            //        //        {
            //        //            return results;
            //        //        }
            //        //    }
            //        //}

            //        // Click on Yes button
            //        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            Thread.Sleep(2000);
            //            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "yes");
            //            if (results.Result1 == KeyWords.Result_FAIL)
            //            {
            //                Thread.Sleep(2000);
            //                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
            //                if (results.Result1 == KeyWords.Result_FAIL)
            //                {
            //                    return results;
            //                }
            //            }
            //        }


            //        objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
            //        // Click on OK button
            //        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            Thread.Sleep(5000);
            //            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "OK");
            //            if (results.Result1 == KeyWords.Result_FAIL)
            //            {
            //                Thread.Sleep(3000);
            //                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
            //                if (results.Result1 == KeyWords.Result_FAIL)
            //                {
            //                    return results;
            //                }
            //            }


            //        }


            //            results.Result1 = KeyWords.Result_PASS;
            //            results.ErrorMessage = "Success";
            //            return results;



            //            /* end of check status  */
                    
            //}

            public Result changeStatus(IWebDriver WDriver, DataRow Broadcast_Data, string status)
            {


                /* change status */
                kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
                CommonMethods objCommonMethods = new CommonMethods();
                var results = new Result();
                CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();

                //  WorksapcRequirementModel worksapcereq = createRequirementRepository.Getworkspacerequiement(Workspace_Requirement);
                //IList<string> approver_list = new List<string>();
                //Dictionary<string, string> dict_Approvers = new Dictionary<string, string>();
                bool bVal_Approved = false;
                WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));

                BroadcastModel broadcastModel = createRequirementRepository.GetBroadcastData(Broadcast_Data);
                // client selection 
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        // return results;
                    }
                }

                //   click on main menu given name
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }

                // Wait for requirement to be loaded



                objCommonMethods.Action_Page_Down(WDriver);
                //try
                //{
                //    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));
                //    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));


                //    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();


                //    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, worksapcereq.strReqNumber);
                //}
                //catch
                //{
                //    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Txt_Filter_ReqNumber);

                //    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();

                //    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, worksapcereq.strReqNumber);
                //}



                //Thread.Sleep(2000);

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");


                try
                {
                    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));
                    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));


                    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();


                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);


                    Thread.Sleep(1000);
                }
                catch
                {
                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Txt_Filter_ReqNumber);

                    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();

                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, "Open");
                }

                // wait for  req number 
                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//*[@id='regReqList']/tbody/tr/td/a[contains(text(),'" + broadcastModel.str_Link_ReqNumber + "')]"))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath("//*[@id='regReqList']/tbody/tr/td/a[contains(text(),'" + broadcastModel.str_Link_ReqNumber + "')]"))));
                kwm.jsClick(WDriver, KeyWords.locator_XPath, "//*[@id='regReqList']/tbody/tr/td/a[contains(text(),'" + broadcastModel.str_Link_ReqNumber + "')]");


                /* wait  for action list menu  */

                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_List_listMenu1))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_List_listMenu1))));

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_ChangeStatus);

                // click on chnage status button 
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_ChangeStatus);



                // click on chnage status button 
                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Myworkspace_Req_ChangeStatus))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Myworkspace_Req_ChangeStatus))));
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_ChangeStatus);

                // wait for page loading 
                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_Txt_TxtComment))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_Txt_TxtComment))));


                // select status 
                kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_Statuslist, status);


                // send comments 
                // kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_changestatus_Comments, broadcastModel.str_ID_comment, false);

                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_changestatus_Comments, "Test", false);


                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                //click on submit button

                kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_button_Submit);


                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                //// Click on Yes button
                //results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, broadcastModel.str_Btn_Yes);
                //if (results.Result1 == KeyWords.Result_FAIL)
                //{
                //    Thread.Sleep(5000);
                //    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, broadcastModel.str_Btn_Yes);
                //    if (results.Result1 == KeyWords.Result_FAIL)
                //    {
                //        Thread.Sleep(3000);
                //        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, broadcastModel.str_Btn_Yes);
                //        if (results.Result1 == KeyWords.Result_FAIL)
                //        {
                //            return results;
                //        }
                //    }
                //}

                // Click on Yes button
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(2000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "yes");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(2000);
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }
                }


                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                // Click on OK button
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "OK");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(3000);
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }


                }



                /* wait  for action list menu  */
                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_List_listMenu1))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_List_listMenu1))));

                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[contains(text(),'Requirement Status')]/following-sibling::label");

                if (kwm.GetText_Xpath(WDriver, "//*[contains(text(),'Requirement Status')]/following-sibling::label")._Var == status)
                {
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Success";
                    return results;
                }
                else
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Fail";
                    return results;
                }

                /* end of check status  */

            }
            public Result convertRequisitionToPayroll(IWebDriver WDriver, DataRow Broadcast_Data)
            {
                kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
                CommonMethods objCommonMethods = new CommonMethods();
                var results = new Result();
                CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();

               // WorksapcRequirementModel worksapcereq = createRequirementRepository.Getworkspacerequiement(Workspace_Requirement);
                //IList<string> approver_list = new List<string>();
                //Dictionary<string, string> dict_Approvers = new Dictionary<string, string>();
                bool bVal_Approved = false;
                WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));

                BroadcastModel broadcastModel = createRequirementRepository.GetBroadcastData(Broadcast_Data);

                //   click on main menu given name
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }

                // Wait for requirement to be loaded



                objCommonMethods.Action_Page_Down(WDriver);
                try
                {
                    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));
                    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));


                    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();


                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);
                }
                catch
                {
                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Txt_Filter_ReqNumber);

                    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();

                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);
                }



                Thread.Sleep(2000);

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");


                // wait for  req number 
                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
                kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus);


                /* click on convert requisition to payroll   */

                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_List_listMenu1))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_List_listMenu1))));

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                // click on Edit button 
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_convertReqtopayrolled);



                // click on yes button 

                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Yes_button_dialog_reqSubmiteDialog))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Yes_button_dialog_reqSubmiteDialog))));

                results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Yes_button_dialog_reqSubmiteDialog);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(3000);
                    results = kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.Xpath_Yes_button_dialog_reqSubmiteDialog);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }


                // Click on OK button
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(2000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "OK");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(2000);
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }
                }
                // End of convert req to payrolled button //


                // verification of Req number in Identified Candidate

                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, "Identified Candidate Requirements");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, "Identified Candidate Requirements");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }

                // Wait for requirement to be loaded



                objCommonMethods.Action_Page_Down(WDriver);
                try
                {
                    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//*[@id='IdentifiedReqList_filter']/label/input"))));
                    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath("//*[@id='IdentifiedReqList_filter']/label/input"))));


                    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();


                    results = kwm.sendTextXPathOnly(WDriver, "//*[@id='IdentifiedReqList_filter']/label/input", broadcastModel.str_Link_ReqNumber);

                    Thread.Sleep(2000);
                }
                catch
                {
                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[@id='IdentifiedReqList_filter']/label/input");

                    WDriver.FindElement(By.XPath("//*[@id='IdentifiedReqList_filter']/label/input")).Clear();

                    kwm.sendTextXPathOnly(WDriver, "//*[@id='IdentifiedReqList_filter']/label/input", broadcastModel.str_Link_ReqNumber);
                }



                Thread.Sleep(2000);

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");


                // wait for  req number 
                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//*[@id='IdentifiedReqList']/tbody/tr/td[2]/a"))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath("//*[@id='IdentifiedReqList']/tbody/tr/td[2]/a"))));



                string IdentifiedReqNumber = WDriver.FindElement(By.XPath("(//*[@id='IdentifiedReqList']//a)[1]")).Text;

                if (IdentifiedReqNumber == broadcastModel.str_Link_ReqNumber)
                {


                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Success";
                    return results;

                }

                else {
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Failed";
                    return results;
                
                }
                

            }

            public Result recallRequisition(IWebDriver WDriver, DataRow Broadcast_Data)
            {
                kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
                CommonMethods objCommonMethods = new CommonMethods();
                var results = new Result();
                CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();

                //WorksapcRequirementModel worksapcereq = createRequirementRepository.Getworkspacerequiement(Workspace_Requirement);
                //IList<string> approver_list = new List<string>();
                //Dictionary<string, string> dict_Approvers = new Dictionary<string, string>();
                bool bVal_Approved = false;
                WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));
                BroadcastModel broadcastModel = createRequirementRepository.GetBroadcastData(Broadcast_Data);
                // client selection 
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        // return results;
                    }
                }
                //   click on main menu given name
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }

                // Wait for requirement to be loaded



                objCommonMethods.Action_Page_Down(WDriver);
                try
                {
                    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));
                    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));


                    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();


                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);

                    Thread.Sleep(1000);

                }
                catch
                {
                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Txt_Filter_ReqNumber);

                    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();

                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);
                }



                Thread.Sleep(2000);

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");


                // wait for  req number 
                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
                kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus);


                /* wait  for action list menu  */

                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_List_listMenu1))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_List_listMenu1))));

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_recallRequisition);

                // click on recall requisition button 
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_recallRequisition);


                // wait for select reason for recall requisition
                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_str_RecallReason))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_str_RecallReason))));

                objCommonMethods.Action_LookInto_Element_ID(WDriver, KeyWords.ID_str_RecallReason);
                // select reason for recall requisition
                //if (broadcastModel.str_Select_CancelReason != "")
                //{
                   // results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_str_RecallReason, broadcastModel.str_Select_CancelReason);

                results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_str_RecallReason, "Program need changed");

                    if (results.Result1 == KeyWords.Result_FAIL)
                    {

                        //results = kwm.select(WDriver, KeyWords.locator_ID, KeyWords.ID_str_RecallReason, broadcastModel.str_Select_CancelReason);

                        results = kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_str_RecallReason,1);
                        //  return results;
                    }
                //}

                // enter comments

                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_TxtComment);

              //  kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_TxtComment, broadcastModel.str_Txt_addComments, false);

                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_TxtComment, "Test", false);


                // click on Recall button


                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Recall");


                // click on yes button 


                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(3000);
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Yes");
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }
                }


                // Click on OK button
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "OK");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(3000);
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }
                }
                // End of recall requisition //

                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = "Success";
                return results;

            }

            public Result viewETKDetails(IWebDriver WDriver, DataRow Broadcast_Data)
            {
                kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
                CommonMethods objCommonMethods = new CommonMethods();
                var results = new Result();
                CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();

             //   WorksapcRequirementModel worksapcereq = createRequirementRepository.Getworkspacerequiement(Workspace_Requirement);
                //IList<string> approver_list = new List<string>();
                //Dictionary<string, string> dict_Approvers = new Dictionary<string, string>();
                bool bVal_Approved = false;
                WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));

                BroadcastModel broadcastModel = createRequirementRepository.GetBroadcastData(Broadcast_Data);
                //   click on main menu given name
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }

                // Wait for requirement to be loaded



                objCommonMethods.Action_Page_Down(WDriver);
                try
                {
                    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));
                    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));


                    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();


                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);

                    Thread.Sleep(2000);
                }
                catch
                {
                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Txt_Filter_ReqNumber);

                    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();

                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);
                }



                //Thread.Sleep(2000);

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");


                // wait for  req number 
                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
                kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus);


                /* wait  for action list menu  */

                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_List_listMenu1))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_List_listMenu1))));

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

                // click on view ETK Details button 
                kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_viewETKDetails);

                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//div[@class='ui-dialog-buttonset']/button[text()[normalize-space() ='Print']]"))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath("//div[@class='ui-dialog-buttonset']/button[text()[normalize-space() ='Print']]"))));


                results = kwm.jsClick(WDriver, KeyWords.locator_XPath, "//div[@class='ui-dialog-buttonset']/button[text()[normalize-space() ='Print']]");

                Thread.Sleep(3000);
                String beforeHandleWin = WDriver.CurrentWindowHandle;

                String windowHandle = WDriver.WindowHandles.Last();

                WDriver.SwitchTo().Window(windowHandle); // switches to the new window
                WDriver.Close(); // Now closes the new window


                Thread.Sleep(1000);

                WDriver.SwitchTo().Window(beforeHandleWin); // switches to main window

                //Actions escapeKey = new Actions(WDriver);
                //escapeKey.SendKeys(Keys.Escape).Build().Perform();

              //  bool br = objCommonMethods.Action_Button_Escape(WDriver); // to escape print page 



                // click on Export button


                //results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Export PDF");
                results = kwm.jsClick(WDriver, KeyWords.locator_XPath, "//div[@class='ui-dialog-buttonset']/button[text()[normalize-space() ='Export PDF']]");



                // click on Close button


                //results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Close");

                results = kwm.jsClick(WDriver, KeyWords.locator_XPath, "//div[@class='ui-dialog-buttonset']/button[text()[normalize-space() ='Close']]");


                //// click on yes button 

                //wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Yes_button_dialog_reqSubmiteDialog))));
                //wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Yes_button_dialog_reqSubmiteDialog))));

                //results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Yes_button_dialog_reqSubmiteDialog);
                //if (results.Result1 == KeyWords.Result_FAIL)
                //{
                //    Thread.Sleep(3000);
                //    results = kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.Xpath_Yes_button_dialog_reqSubmiteDialog);
                //    if (results.Result1 == KeyWords.Result_FAIL)
                //    {
                //        return results;
                //    }
                //}



                // End of view ETK Details //

                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = "Success";
                return results;

            }

            public Result openDiscussion(IWebDriver WDriver, DataRow Broadcast_Data, string hiringManager)
            {
                kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, Constants.ExplicitWaitTime);
                CommonMethods objCommonMethods = new CommonMethods();
                var results = new Result();
                CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();

               // WorksapcRequirementModel worksapcereq = createRequirementRepository.Getworkspacerequiement(Workspace_Requirement);
                //IList<string> approver_list = new List<string>();
                //Dictionary<string, string> dict_Approvers = new Dictionary<string, string>();
                bool bVal_Approved = false;
                WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));

                BroadcastModel broadcastModel = createRequirementRepository.GetBroadcastData(Broadcast_Data);
                // client selection 
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        // return results;
                    }
                }

                //   click on main menu given name
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }

                // Wait for requirement to be loaded



                objCommonMethods.Action_Page_Down(WDriver);
                try
                {
                    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));
                    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));


                    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();


                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);

                    Thread.Sleep(1000);
                }
                catch
                {
                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Txt_Filter_ReqNumber);

                    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();

                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);
                }



                //Thread.Sleep(2000);

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");


                // wait for  req number 
                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
                kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus);


                // wait  for action list menu  

                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_List_listMenu1))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_List_listMenu1))));

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_OpenDiscussion);

                // click on Open Discussion button 
                kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_OpenDiscussion);


                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_str_proposedStartDate))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_str_proposedStartDate))));

                // click on start Date 

                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_str_proposedStartDate);
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_str_proposedStartDate);

                // send start date 
                // kwm.Select_Start_Date_From_Picker(WDriver, broadcastModel.str_openDiscussion_startDate);

                kwm.Select_Start_Date_From_Picker(WDriver, "");




                // click on start Time
                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_str_propesedStartTime);
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_str_propesedStartTime);

                // send start time 
               // kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_str_propesedStartTime, broadcastModel.str_openDiscussion_starttime, false);

                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_str_propesedStartTime, "02:10", false);

                // click on End Date 
                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_str_proposedEndDate);
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_str_proposedEndDate);


                Thread.Sleep(1000);
                // send End date 
                //kwm.Select_Start_Date_From_Picker(WDriver, broadcastModel.str_openDiscussion_EndDate);

                kwm.Select_Start_Date_From_Picker(WDriver, "");

                // click on End Time
                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_str_propesedEndTime);
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_str_propesedEndTime);

                // send end time 
                //kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_str_propesedEndTime, broadcastModel.str_openDiscussion_Endtime, false);

                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_str_propesedEndTime, "22:20", false);

                Thread.Sleep(2000);

                objCommonMethods.Action_Button_Tab(WDriver);

                // select hosts

                //kwm.select_List_typeaheads(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_hosts_hiringManager, broadcastModel.str_openDiscussion_hosts);

                kwm.select_List_typeaheads(WDriver, KeyWords.locator_ID, KeyWords.ID_T1_Typeahead_hosts_hiringManager, hiringManager);

                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_ID, KeyWords.ID_addButton_hosts_hiringManager);

                // click on add button

                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_addButton_hosts_hiringManager);


                // click on Submit button

                kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Submit");

                // click on yes button 

                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Yes_button_dialog_OpenDiscussion))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Yes_button_dialog_OpenDiscussion))));

                results = kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Yes_button_dialog_OpenDiscussion);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(3000);
                    results = kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.Xpath_Yes_button_dialog_OpenDiscussion);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        return results;
                    }
                }


                // Click on OK button
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "OK");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(3000);
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }
                }

                // End of open discussion Details //

                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = "Success";
                return results;
            }  

            public Result ReBroadcast_Method(IWebDriver WDriver, DataRow Broadcast_Data)
            {
                KeyWordMethods kwm = new KeyWordMethods();
                ReadExcel ReadExcelHelper_local = new ReadExcel();
                kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 10);
                CommonMethods objCommonMethods = new CommonMethods();
                var results = new Result();
                var Result_ScreenShot = new Result();
                List<string> listExistClients = new List<string>() { };
                List<string> str_list_SupplierMailId = new List<string>();
                CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();
                BroadcastModel broadcastModel = createRequirementRepository.GetBroadcastData(Broadcast_Data);


                //listExistClients = new List<string>() { Constants.Discover };
                //if (listExistClients.Contains(broadcastModel.strClientName.ToLower()))
                //{
                //    results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
                //    if (results.Result1 == KeyWords.Result_FAIL)
                //    {
                //        Thread.Sleep(5000);
                //        results = kwm.Client_Change_Click_NewApp_Discover(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
                //        if (results.Result1 == KeyWords.Result_FAIL)
                //        {
                //            Boolean bFlagDropDwon = false;
                //            try
                //            {
                //                // bFlagDropDwon = WDriver.FindElement(By.XPath(KeyWords.XPath_supplierMenu_ClientDropDown)).Enabled;
                //                bFlagDropDwon = kwm.isElementEnabledByXPath(WDriver, KeyWords.XPath_supplierMenu_ClientDropDown);
                //            }
                //            catch
                //            {
                //                bFlagDropDwon = false;
                //            }
                //            if (bFlagDropDwon)
                //                return results;
                //        }
                //    }
                //}
                //listExistClients = new List<string>() { Constants.Discover };
                //if (!listExistClients.Contains(broadcastModel.strClientName.ToLower()))
                //{
                //    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
                //    if (results.Result1 == KeyWords.Result_FAIL)
                //    {
                //        Thread.Sleep(5000);
                //        results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
                //        if (results.Result1 == KeyWords.Result_FAIL)
                //        {
                //            Boolean bFlagDropDwon = false;
                //            try
                //            {
                //                // bFlagDropDwon = WDriver.FindElement(By.XPath(KeyWords.XPath_supplierMenu_ClientDropDown)).Enabled;
                //                bFlagDropDwon = kwm.isElementEnabledByXPath(WDriver, KeyWords.XPath_supplierMenu_ClientDropDown);
                //            }
                //            catch
                //            {
                //                bFlagDropDwon = false;
                //            }
                //            if (bFlagDropDwon)
                //                return results;
                //        }
                //    }
                //}

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }

                if (!kwm.waitForElementExists(WDriver, By.XPath("//table[@id='regReqList']//tbody//tr"), kwm._WDWait))
                {
                    Thread.Sleep(2000);
                }

                //Search requirement
                kwm.sendText_XPath(WDriver, KeyWords.locator_XPath, KeyWords.XPath_SearchBox_Requirements_regReqList, broadcastModel.str_Link_ReqNumber, broadcastModel.str_Link_ReqNumber, false);

                //Wait for Requirement to load
                if (!kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_Img_Processing), kwm._WDWait))
                {
                    kwm.waitForElementToBeClickable(WDriver, By.XPath("//table[@id='regReqList']//td/a[contains(text(),'" + broadcastModel.str_Link_ReqNumber + "')]"), kwm._WDWait);
                }

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");

                //Click on Requirement Link
                WDriver.FindElement(By.XPath("//table[@id='regReqList']//td/a[contains(text(),'" + broadcastModel.str_Link_ReqNumber + "')]")).Click();

                //wait for page to load
                kwm.waitForElementExists(WDriver, By.XPath(KeyWords.XPath_OverlayLoader), kwm._WDWait);

                //Wait for broadcast link to be Displayed
                kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_ActionListMenu_Broadcast_reqBroadcast), kwm._WDWait);

                //Click on Broadcast menu link
                kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_rebroadcast);

                //Wait for form to load
                Thread.Sleep(1000);
                kwm.waitForElementToBeVisible(WDriver, By.Id(KeyWords.ID_Button_SelectSuppliers_PayRateMarkup), kwm._WDWait);
                kwm.waitForElementToBeClickable(WDriver, By.Id(KeyWords.ID_Button_SelectSuppliers_PayRateMarkup), kwm._WDWait);
                kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_Button_SelectSuppliers_PayRateMarkup);
                Thread.Sleep(1000);

                if (kwm.isElementDisplayedByXPath(WDriver, "//div[@aria-labelledby='ui-dialog-title-PleaseWaitPopup' and contains(@style,'display: none')]"))
                {
                    kwm.waitForElementToBeVisible(WDriver, By.XPath("//div[@aria-labelledby='ui-dialog-title-PleaseWaitPopup' and contains(@style,'display: none')]"), kwm._WDWait);
                }

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                //Click on Distribution List
                if (kwm.isElementDisplayedByXPath(WDriver, KeyWords.XPath_li_DistributionList))
                {
                    kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.XPath_li_DistributionList);
                }

                //Wait for dialog box 
                if (!kwm.isElementDisplayedByXPath(WDriver, KeyWords.XPath_MsgBox_DistributionListPopup))
                {
                    kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_MsgBox_DistributionListPopup), kwm._WDWait);
                }
                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                //wait for distrubution dropdown list
                if (kwm.isElementDisplayed(WDriver, KeyWords.ID_MsgBox_Select_DistributionList_ddlDistList))
                {

                    // enter min payrate
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_payRateMin, broadcastModel.str_Txt_BillRate_Min, false);

                    // enter max payrate
                    kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_payRateMax, broadcastModel.str_Txt_BillRate_Max, false);


                    //select the value by index in distrubution dropdown list
                    kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_Select_ddlDistList, 1);

                    //wait for tier dropdown to load
                    kwm.waitForElementToBeSelected(WDriver, By.Id(KeyWords.ID_MsgBox_Select_Tiers_ddlTiers), kwm._WDWait);

                    //select the value by index in distrubution dropdown list
                    kwm.selectByIndex(WDriver, KeyWords.locator_ID, KeyWords.ID_MsgBox_Select_Tiers_ddlTiers, 1);

                    Thread.Sleep(3000);

                    //kwm.click(WDriver, KeyWords.locator_ID, "viewSuppliers");

                    //kwm.waitForElementToBeVisible(WDriver, By.Id("dlgConfirmSuppliers"), kwm._WDWait);
                    //if (kwm.isElementDisplayed(WDriver, "dlgConfirmSuppliers"))
                    //{
                    //    kwm.waitForElementToBeVisible(WDriver, By.Id("tblSuppliers_wrapper"), kwm._WDWait);
                    //    if (kwm.isElementDisplayedByXPath(WDriver, "//table[@id='tblSuppliers']//tbody/tr[1]"))
                    //    {
                    //        kwm.click(WDriver, KeyWords.locator_ID, "chkSelectAll");
                    //        foreach (IWebElement ele in WDriver.FindElements(By.XPath("//table[@id='tblSuppliers']//tbody/tr//td[@class='primaryEmail']//div")).ToList())
                    //        {
                    //            //Add supplier mail id's to list
                    //            str_list_SupplierMailId.Add(ele.Text);

                    //        }
                    //    }

                    //}
                    //kwm.click(WDriver, KeyWords.locator_XPath, "//div[@aria-labelledby='ui-dialog-title-dlgConfirmSuppliers']//button[text()='Select']");
                    //kwm.waitForElementExists(WDriver, By.Id("selectedSuppliers"), kwm._WDWait);

                    objCommonMethods.Action_Page_Down(WDriver);

                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.XPath_MsgBox_Btn_Broadcast_Broadcast);

                    kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.XPath_MsgBox_Btn_Broadcast_Broadcast);

                    if (kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_MsgBox_ConfirmSuppliers_Btn_Yes_Yes), kwm._WDWait))
                    {
                        objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                        //click on yes button on confirm supplier popup
                        kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.XPath_MsgBox_ConfirmSuppliers_Btn_Yes_Yes);


                        kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_MsgBox_dlgBroadcastSent_Btn_OK_OK), kwm._WDWait);
                        kwm.waitForElementToBeClickable(WDriver, By.XPath(KeyWords.XPath_MsgBox_dlgBroadcastSent_Btn_OK_OK), kwm._WDWait);

                        objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                        //Click on Ok button
                        kwm.click(WDriver, KeyWords.locator_XPath, KeyWords.XPath_MsgBox_dlgBroadcastSent_Btn_OK_OK);

                    }
                    else
                    {
                        objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                        results.ErrorMessage = "Yes button is not displayed/clickable";
                        results.Result1 = KeyWords.Result_FAIL;
                        return results;
                    }

                }
                else
                {
                    objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                    results.ErrorMessage = "Distribution Dropdown is not displayed/selected";
                    results.Result1 = KeyWords.Result_FAIL;
                    return results;

                }

                ////wait for page to load
                //kwm.waitForElementExists(WDriver, By.XPath(KeyWords.XPath_OverlayLoader), kwm._WDWait);

                //if (!kwm.isElementDisplayedByXPath(WDriver, KeyWords.XPath_OverlayLoader))
                //{
                //    kwm.waitForElementToBeVisible(WDriver, By.XPath(KeyWords.XPath_OverlayLoader), kwm._WDWait);
                //}

                //if (kwm.isElementDisplayedByXPath(WDriver, KeyWords.XPath_ActionListMenu_BroadcastDetails_reqBroadcastDetails))
                //{

                objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                results.ErrorMessage = "Broadcast is successfull";
                results.listData = str_list_SupplierMailId;
                results.Result1 = KeyWords.Result_PASS;
                return results;

                //return results;
                ////----------------------------------------------------------------------------------------



                ////Edit method calling 
                //string strSubLevel = "./label";
                //objCommonMethods.SaveScreenShot_EachPage(WDriver, broadcastModel.strClientName + "_");
                //if (broadcastModel.str_Link_Edit != "")
                //{
                //    results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, broadcastModel.str_Link_Edit, strSubLevel);
                //    if (results.Result1 == KeyWords.Result_FAIL)
                //    {
                //        Thread.Sleep(2000);
                //        results = kwm.list_Menu_Click(WDriver, KeyWords.locator_ID, KeyWords.ID_List_listMenu1, broadcastModel.str_Link_Edit, strSubLevel);
                //        if (results.Result1 == KeyWords.Result_FAIL)
                //        {
                //            return results;
                //        }
                //    }

                //}
            }

            //public Result reOpenRequistion(IWebDriver WDriver, DataRow Broadcast_Data)
            //{
            //    KeyWordMethods kwm = new KeyWordMethods();
            //    ReadExcel ReadExcelHelper_local = new ReadExcel();
            //    kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 10);
            //    CommonMethods objCommonMethods = new CommonMethods();
            //    var results = new Result();
            //    var Result_ScreenShot = new Result();
            //    List<string> listExistClients = new List<string>() { };
            //    List<string> str_list_SupplierMailId = new List<string>();
            //    CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();

            //  //  WorksapcRequirementModel worksapcereq = createRequirementRepository.Getworkspacerequiement(Workspace_Requirement);
            //    //IList<string> approver_list = new List<string>();
            //    //Dictionary<string, string> dict_Approvers = new Dictionary<string, string>();
            //    bool bVal_Approved = false;
            //    WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));

            //    BroadcastModel broadcastModel = createRequirementRepository.GetBroadcastData(Broadcast_Data);
            //    // client selection 
            //    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        Thread.Sleep(5000);
            //        results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            //results.ErrorMessage1 = "Unable to click on the Main menu";
            //            // return results;
            //        }
            //    }

            //    //   click on main menu given name
            //    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        Thread.Sleep(5000);
            //        results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            //results.ErrorMessage1 = "Unable to click on the Main menu";
            //            return results;
            //        }
            //    }

               
               
            //    // calling status method with closed


            //    objCommonMethods.Action_LookInto_Element_ID(WDriver, KeyWords.ID_button_btnSearchReq);

            //    //// click on search button 
            //    //wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_button_btnSearchReq))));
            //    //wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_button_btnSearchReq))));
            //    //kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.ID_button_btnSearchReq);

            //    //// Wait for requirement to be loaded



            //  //  objCommonMethods.Action_Page_Down(WDriver);
            //    try
            //    {
            //        wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));
            //        wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));


            //        WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();


            //        kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);

            //        Thread.Sleep(2000);
            //    }
            //    catch
            //    {
            //        kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Txt_Filter_ReqNumber);

            //        WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();

            //        kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);
            //    }


            //    // wait for  req number 

            //    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
            //    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
            //    kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus);

                
            //    // wait for ListMenu 
            //         wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_List_listMenu1))));
            //         wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_List_listMenu1))));

            //        int optionCount = WDriver.FindElements(By.XPath(KeyWords.Xpath_Myworkspace_Req_ReOpenrequirement)).Count;
                
            //    if(optionCount == 0){

            //        //  Calling status change foe Closed option
                
            //              changeStatus(WDriver,Broadcast_Data,"Closed");
                     
            //    }
               
            //        //  click on Re-open 

            //    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Myworkspace_Req_ReOpenrequirement))));
            //    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Myworkspace_Req_ReOpenrequirement))));
            //        kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_ReOpenrequirement);

            //        // enter comment
            //        wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_Txt_TxtComment))));
            //        wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_Txt_TxtComment))));
            //        // kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_changestatus_Comments, broadcastModel.str_ID_comment, false);
            //        kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_changestatus_Comments, "Test", false);
            //        //click on submit button

            //        kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_button_Submit);


            //        // click on yes button

            //        wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Yes_button_dialog_confirmreopen1))));
            //        wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Yes_button_dialog_confirmreopen1))));
            //        kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Yes_button_dialog_confirmreopen1);

            //        // Click on OK button
            //        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
            //        if (results.Result1 == KeyWords.Result_FAIL)
            //        {
            //            Thread.Sleep(5000);
            //            results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "OK");
            //            if (results.Result1 == KeyWords.Result_FAIL)
            //            {
            //                Thread.Sleep(3000);
            //                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
            //                if (results.Result1 == KeyWords.Result_FAIL)
            //                {
            //                    return results;
            //                }
            //            }
            //        }
                
                
            //    results.Result1 = KeyWords.Result_PASS;
            //    results.ErrorMessage = "Success";
            //    return results;

            //}

            public Result reOpenRequistion(IWebDriver WDriver, DataRow Broadcast_Data)
            {
                KeyWordMethods kwm = new KeyWordMethods();
                ReadExcel ReadExcelHelper_local = new ReadExcel();
                kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 10);
                CommonMethods objCommonMethods = new CommonMethods();
                var results = new Result();
                var Result_ScreenShot = new Result();
                List<string> listExistClients = new List<string>() { };
                List<string> str_list_SupplierMailId = new List<string>();
                CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();

                //  WorksapcRequirementModel worksapcereq = createRequirementRepository.Getworkspacerequiement(Workspace_Requirement);
                //IList<string> approver_list = new List<string>();
                //Dictionary<string, string> dict_Approvers = new Dictionary<string, string>();
                bool bVal_Approved = false;
                WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));

                BroadcastModel broadcastModel = createRequirementRepository.GetBroadcastData(Broadcast_Data);
                // client selection 
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        // return results;
                    }
                }

                //   click on main menu given name
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }



                // calling status method with closed


                objCommonMethods.Action_LookInto_Element_ID(WDriver, KeyWords.ID_button_btnSearchReq);

                //// click on search button 
                //wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_button_btnSearchReq))));
                //wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_button_btnSearchReq))));
                //kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.ID_button_btnSearchReq);

                //// Wait for requirement to be loaded



                //  objCommonMethods.Action_Page_Down(WDriver);
                try
                {
                    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));
                    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));


                    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();


                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);
                }
                catch
                {
                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Txt_Filter_ReqNumber);

                    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();

                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);
                }


                // wait for  req number 

                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
                kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus);


                // wait for ListMenu 
                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_List_listMenu1))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_List_listMenu1))));

                int optionCount = WDriver.FindElements(By.XPath(KeyWords.Xpath_Myworkspace_Req_ReOpenrequirement)).Count;

                if (optionCount == 0)
                {

                    //  Calling status change foe Closed option

                    changeStatus(WDriver, Broadcast_Data, "Closed");

                }

                //  click on Re-open 

                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Myworkspace_Req_ReOpenrequirement))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Myworkspace_Req_ReOpenrequirement))));
                kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_ReOpenrequirement);

                // enter comment
                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_Txt_TxtComment))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_Txt_TxtComment))));
                // kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_changestatus_Comments, broadcastModel.str_ID_comment, false);
                kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_Txt_changestatus_Comments, "Test", false);
                //click on submit button

                kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_button_Submit);


                // click on yes button

                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Yes_button_dialog_confirmreopen1))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Yes_button_dialog_confirmreopen1))));
                kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Yes_button_dialog_confirmreopen1);

                // Click on OK button
                results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "OK");
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        Thread.Sleep(3000);
                        results = kwm.select_MSG_Button(WDriver, KeyWords.locator_type, KeyWords.locator_button, "Ok");
                        if (results.Result1 == KeyWords.Result_FAIL)
                        {
                            return results;
                        }
                    }
                }



                /* wait  for action list menu  */
                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_List_listMenu1))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_List_listMenu1))));

                kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, "//*[contains(text(),'Requirement Status')]/following-sibling::label");

                if (kwm.GetText_Xpath(WDriver, "//*[contains(text(),'Requirement Status')]/following-sibling::label")._Var == "Open")
                {
                    results.Result1 = KeyWords.Result_PASS;
                    results.ErrorMessage = "Success";
                    return results;
                }
                else
                {
                    results.Result1 = KeyWords.Result_FAIL;
                    results.ErrorMessage = "Fail";
                    return results;
                }



            }

            public Result broadacastDetails(IWebDriver WDriver, DataRow Broadcast_Data) {


                KeyWordMethods kwm = new KeyWordMethods();
                ReadExcel ReadExcelHelper_local = new ReadExcel();
                kwm._WDWait = kwm.WebDriver_Wait_Handler(WDriver, 10);
                CommonMethods objCommonMethods = new CommonMethods();
                var results = new Result();
                var Result_ScreenShot = new Result();
                List<string> listExistClients = new List<string>() { };
                List<string> str_list_SupplierMailId = new List<string>();
                CreateRequirementRepository createRequirementRepository = new CreateRequirementRepository();

                //  WorksapcRequirementModel worksapcereq = createRequirementRepository.Getworkspacerequiement(Workspace_Requirement);
                //IList<string> approver_list = new List<string>();
                //Dictionary<string, string> dict_Approvers = new Dictionary<string, string>();
                bool bVal_Approved = false;
                WebDriverWait wait = new WebDriverWait(WDriver, TimeSpan.FromSeconds(300));

                BroadcastModel broadcastModel = createRequirementRepository.GetBroadcastData(Broadcast_Data);
                // client selection 
                results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Client_Change_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strClientName);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        // return results;
                    }
                }

                //   click on main menu given name
                results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                if (results.Result1 == KeyWords.Result_FAIL)
                {
                    Thread.Sleep(5000);
                    results = kwm.Main_Sub_Menu_Click_NewApp(WDriver, KeyWords.locator_ID, KeyWords.ID_MainMenu, broadcastModel.strMainMenuLink, broadcastModel.strSubMenuLink);
                    if (results.Result1 == KeyWords.Result_FAIL)
                    {
                        //results.ErrorMessage1 = "Unable to click on the Main menu";
                        return results;
                    }
                }



                // calling status method with closed


                objCommonMethods.Action_LookInto_Element_ID(WDriver, KeyWords.ID_button_btnSearchReq);

                //// click on search button 
                //wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_button_btnSearchReq))));
                //wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_button_btnSearchReq))));
                //kwm.jsClick(WDriver, KeyWords.locator_ID, KeyWords.ID_button_btnSearchReq);

                //// Wait for requirement to be loaded



                //  objCommonMethods.Action_Page_Down(WDriver);
                try
                {
                    wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));
                    wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber))));


                    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();


                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);

                    Thread.Sleep(2000);

                    
                }
                catch
                {
                    kwm.Action_LookInto_Element(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Txt_Filter_ReqNumber);

                    WDriver.FindElement(By.XPath(KeyWords.Xpath_Txt_Filter_ReqNumber)).Clear();

                    kwm.sendTextXPathOnly(WDriver, KeyWords.Xpath_Txt_Filter_ReqNumber, broadcastModel.str_Link_ReqNumber);
                }


                // wait for  req number 

                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath(KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus))));
                kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_firstreqwithapprovalstatus);


                // wait for ListMenu 
                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(KeyWords.ID_List_listMenu1))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id(KeyWords.ID_List_listMenu1))));



                // click on Broadcast Details
                kwm.jsClick(WDriver, KeyWords.locator_XPath, KeyWords.Xpath_Myworkspace_Req_broadCastDetails);

                // waits for Broadcast History
                wait.Until(ExpectedConditions.ElementIsVisible((By.Id("tabsExpandCollapse"))));
                wait.Until(ExpectedConditions.ElementToBeClickable((By.Id("tabsExpandCollapse"))));
                results = kwm.jsClick(WDriver, KeyWords.locator_ID, "tabsExpandCollapse");

                // waits for Broadcast Sent Details
               
                results = kwm.jsClick(WDriver, KeyWords.locator_XPath, "(//*[@class='hitarea expandable-hitarea lastExpandable-hitarea'])[1]");
                

                // click on Supplier Button

                results = kwm.jsClick(WDriver, KeyWords.locator_XPath, "//*[@id='ulSupplier']/li[1]/div");


                //  Getting Supplier email Id 

                String supplierMail = WDriver.FindElement(By.XPath("//*[@id='ulSupContact']//input")).GetAttribute("email");



                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = "Success";
                return results;   
            }


        }
    }

