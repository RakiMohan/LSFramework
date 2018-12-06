using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using CommonFiles;
using SmartTrack_Automation;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System.Data;
using System.Configuration;
using NUnit.TestUtilities;
using NUnit.Common;
using NUnit.Framework.Api;
using NUnit.Framework.Internal;
using System.Xml;
using NUnit.TestData;
using OpenQA.Selenium.Support.Events;
using CommonFiles.Users;
using System.IO;
using SmartTrack.DataAccess;

namespace SmartTrack_Automation
{
   //[TestFixture]
    public class Initialiser 
    {
        public static KeyWordMethods _kwm;
        public static CommonMethods cmnm;
        public static @ReadExcel excelHelper;
        public static Result results;
        public static ExtentReports _ExecutionReport,_LabelReport;
        public static DataRow dtRow;
        public static DataRowCollection lst_MasterSheetRow, lst_Client_MasterSheetRow,lst_Client_MainSheetRow,lst_Client_DataSheetRow;
        public static List<Master> lst_MasterSheetData;
        public static List<DataRow> lst_Client_TestStepData;
        public static Boolean bIsDependentOnAbove=true,bExecutionStatus=true,bIsNotDependentOnAbove=false;
        public static TestStatus PreviousTestExecutionStatus;
        public static Dictionary<string,TestStatus> dict_TestCaseExecutionStatus= new Dictionary<string,TestStatus>();
        public static IList<String> lst_StepMesages = new List<String>();
        public XmlDocument xml_Doc;
        public static Dictionary<Object, DataRow> dict_MasterSheet,dict_MainSheet,dict_Datasheet;
        public EventFiringWebDriver mspDriver;
        
        
        
        public void Framework_Initialisers()
        {
           // Console.WriteLine("From Initialiser: TestFixtureSetup- m1()");
            _kwm = new KeyWordMethods();
            cmnm = new CommonMethods();
            excelHelper = new ReadExcel();
            results = new Result();

        }
        //[TestFixtureSetUp]
        public void RunObjects()
        {
            Console.WriteLine("From Initialiser: TestFixtureSetup- m1()");
        }

        public void initialise_LocalObjects()
        {
            dict_MasterSheet = new Dictionary<Object, DataRow>();
            dict_MainSheet = new Dictionary<Object, DataRow>();
            dict_Datasheet = new Dictionary<Object, DataRow>();
            lst_Client_TestStepData = new List<DataRow>();
            DataHandler.lst_DataObjectParams = new List<DataSheetParams>();
            
        }

        #region BrowserInstances
        public static EventFiringWebDriver driverMSP 
        {
            get
            {
                return MSP_User.Instance._MSPDriver;
            }
        }
        public static EventFiringWebDriver driverClient
        {
            get
            {
                return Client_User.Instance._ClientDriver;
            }
        }
        public static EventFiringWebDriver driverSupplier
        {
            get
            {
                return Supplier_User.Instance._SupplierDriver;
            }
        }
        public static EventFiringWebDriver driverCW
        {
            get
            {
                return CW_User.Instance._CWDriver;
            }
        }

        void _Init_CloseDrivers()
        {
            MSP_User.Instance.CloseBrowser();
            Client_User.Instance.CloseBrowser();
            Supplier_User.Instance.CloseBrowser();
            CW_User.Instance.CloseBrowser();
        }
        #endregion BrowserInstances

        #region objGetters
        public static KeyWordMethods getKWM()
        {
            if (_kwm != null)
            {
                return _kwm;
            }
            else
            {
                throw new Exception("KeyWordMethods Object not initialised ");
            }

        }

        public static CommonMethods getCMNM()
        {
            if (cmnm != null)
            {
                return cmnm;
            }
            else
            {
                throw new Exception("CommonMethods Object not initialised ");
            }

        }

        public static ReadExcel getExcelHelper()
        {
            if (excelHelper != null)
            {
                return excelHelper;
            }
            else
            {
                throw new Exception("ReadExcel Object not initialised ");
            }

        }

        public static Result getResult()
        {
            if (results != null)
            {
                return results;
            }
            else
            {
                throw new Exception("Results Object not initialised ");
            }
        }

        

        public static ExtentReports getExecutionReport()
        {
            if (_ExecutionReport != null)
            {
                return _ExecutionReport;
            }
            else
            {
                throw new Exception("ExecutionReport Object not initialised ");
            }
        }

        public static ExtentReports getLabelReport()
        {
            if (_LabelReport != null)
            {
                return _LabelReport;
            }
            else
            {
                throw new Exception("ExecutionReport Object not initialised ");
            }
        }
        #endregion

        #region setConfigs
        static void setMasterConfig()
        {
            ConfigurationManager.AppSettings["URL1"] = lst_MasterSheetRow[0]["Url1"].ToString();
            ConfigurationManager.AppSettings["URL2"] = lst_MasterSheetRow[0]["Url2"].ToString();
            ConfigurationManager.AppSettings["Client"] = lst_MasterSheetRow[0]["ClientName"].ToString();
            ConfigurationManager.AppSettings["RunMode"] = lst_MasterSheetRow[0]["RunMode"].ToString();
            ConfigurationManager.AppSettings["MSP_Browser"] = lst_MasterSheetRow[0]["BrowserMSP"].ToString();
            ConfigurationManager.AppSettings["Client_Browser"] = lst_MasterSheetRow[0]["BrowserAPP"].ToString();
            ConfigurationManager.AppSettings["Supplier_Browser"] = lst_MasterSheetRow[0]["BrowserSUP"].ToString();
            //ConfigurationManager.AppSettings["CW_User"] = lst_MasterSheetRow[0]["BrowserCW"].ToString();

        }
        #endregion

        #region Navigation
        void _NavigateToURL(IWebDriver _driver ,string sURL)
        {
            try
            {
                _driver.Navigate().GoToUrl(sURL);
            }
            catch(Exception e)
            {

            }
        }
        void _NavigateToScreen()
        {
        }
        #endregion

        #region Reporting
        public void StartReport()
        {

            Thread.Sleep(100);
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath; // project path of your solution
            DateTime date1 = DateTime.Now;
            string report_number = date1.ToString("yyyyMMMddHHmmss");
            string reportPath = projectPath + "Reports\\" + report_number + ".html";
            //string reportPath = projectPath + "Reports\\testreport5.html";

            // true if you want to append data to the report.  Replace existing report with new report.  False to create new report each time
            _ExecutionReport = new ExtentReports(reportPath, false);
            _ExecutionReport.AddSystemInfo("Host Name", "localhost")
                .AddSystemInfo("Environment", "QA")
                .AddSystemInfo("User Name", "Automation Team");

            _ExecutionReport.LoadConfig(projectPath + "extent-config.xml");
            string labelReportPath = projectPath + "LabelReports\\" + "LabelReport_" + report_number + ".html";

            _LabelReport = new ExtentReports(labelReportPath, false);
            _LabelReport.AddSystemInfo("Host Name", "localhost")
                .AddSystemInfo("Environment", "QA")
                .AddSystemInfo("User Name", "Automation Team");

            _LabelReport.LoadConfig(projectPath + "lbl-config.xml");


        }
        #endregion Reporting

        #region DataRegion
        public static void getMasterFileData() 
        {
            String sMasterFileQuery = "SELECT ClientID,ClientName,RunMode,Url1,Url2,BrowserMSP,BrowserAPP,BrowserSUP,Results FROM [" + KeyWords.strMasterSheetName + "] where RunMode = 'Yes'";
            lst_MasterSheetRow = excelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath_Master, KeyWords.strMasterSheetName, sMasterFileQuery).dt.Rows;
            if (lst_MasterSheetRow.Count > 0)
            {
                results.blnResult = true;
                
            }
               

        }

        public static void getMasterSheetData()
        {
            string sDirFile = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Input\\all_clients_input_data\\" + ConfigurationManager.AppSettings["Client"].ToString().Trim()+".xlsx";
            if (ConfigurationManager.AppSettings["Client"].ToString() != "" && File.Exists(sDirFile))
            {
                KeyWords.strExlInputPath = sDirFile;
                string sMasterSheetQuery = "SELECT TestScenarioID,RunMode,Client,Description FROM [" + KeyWords.strMasterSheetName + "] where RunMode = 'Yes'";
                lst_Client_MasterSheetRow = excelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, KeyWords.strMasterSheetName, sMasterSheetQuery).dt.Rows;
            }
            
            foreach(DataRow dr in lst_Client_MasterSheetRow)
            {
                var _master = new Master()
                {
                    TestScenarioID=dr["TestScenarioID"].ToString(),
                    Description = dr["Description"].ToString()
                };
                dict_MasterSheet.Add(_master, dr);
            }
        }
        
        public static void getMainSheetData()
        {
            
            foreach(KeyValuePair<Object, DataRow> entry in dict_MasterSheet)
            {
                string strMainSheetQuery = "SELECT * FROM [" + KeyWords.strMainSheetName + "] where TestScenario = '" + ((Master)entry.Key).TestScenarioID + "' and Include ='yes'";
                lst_Client_MainSheetRow = excelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, KeyWords.strMainSheetName, strMainSheetQuery).dt.Rows;
            }

            foreach (DataRow dr in lst_Client_MainSheetRow)
            {
                var _main = new Main()
                {
                    TestScenarioID = dr["TestScenario"].ToString(),
                    Description = dr["Description"].ToString(),
                    TestCaseID=dr["TestCaseID"].ToString(),
                    DataSheet=dr["DataSheet"].ToString()

                };
                dict_MainSheet.Add(_main, dr);
            }
        }

        public static void getDataSheetRow()
        {
            foreach (KeyValuePair<Object, DataRow> entry in dict_MainSheet)
            {
                string sStepQuery = "SELECT * FROM [" + entry.Value["DataSheet"].ToString()+ "] where TestScenario = '" + entry.Key +"'";
                lst_Client_DataSheetRow = excelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, entry.Value["DataSheet"].ToString(), sStepQuery).dt.Rows;
            }

            foreach (DataRow dr in lst_Client_MainSheetRow)
            {
                var _main = new Main()
                {
                    TestScenarioID = dr["TestScenarioID"].ToString(),
                    Description = dr["Description"].ToString(),
                    TestCaseID = dr["TestCaseID"].ToString(),
                    DataSheet = dr["DataSheet"].ToString()

                };
                dict_Datasheet.Add(_main, dr);
            }
            
        }

        public static List<DataRow> getTestStepData(string sSheetName, string sScenarioID, string sTestCaseID )
        {
            
            string sStepQuery = "";
            foreach (KeyValuePair<Object, DataRow> entry in dict_MasterSheet)
            {
                if (((Master)entry.Key).TestScenarioID == sScenarioID && entry.Value["RunMode"].ToString().ToLower().Equals("yes"))
                {
                    foreach (KeyValuePair<Object, DataRow> eMain in dict_MainSheet)
                    {
                        if (((Main)eMain.Key).TestScenarioID == ((Master)entry.Key).TestScenarioID && eMain.Value["Include"].ToString().ToLower().Equals("yes") && ((Main)eMain.Key).TestCaseID==sTestCaseID)
                        {
                            sStepQuery = "SELECT * FROM [" + sSheetName + "] where TestScenario = '" + sScenarioID + "' and TestCaseID = '" + sTestCaseID+ "'";
                        }
                    }
                    if (sStepQuery != "")
                    {
                        lst_Client_DataSheetRow = excelHelper.GetDataTableFromExcelFile(KeyWords.strExlInputPath, sSheetName, sStepQuery).dt.Rows;
                        foreach (DataRow r in lst_Client_DataSheetRow)
                        {
                            lst_Client_TestStepData.Add(r);

                        }
                    }
                    else
                        throw new NullReferenceException("sStepQuery is Null. No Test Step Data can be retrieved");

                }
                
            }
            return lst_Client_TestStepData; 
        }

        public XmlNodeList _GetConditionalRuns()
        {
            xml_Doc = new XmlDocument();

            xml_Doc.Load(KeyWords.XMLFilePath);

            XmlNodeList xmlNodelist_ConditionalRuns = xml_Doc.FirstChild.SelectNodes("CreateRequirement/ConditionalRuns/Run");

            return xmlNodelist_ConditionalRuns;

        }
        public Boolean _LoadInputData(XmlDocument _doc)
        {
            XmlNodeList xmlNodeList_Data = xml_Doc.FirstChild.SelectNodes("CreateRequirement/Common/add");
            return true;
        }
        #endregion DataRegion

        #region Setup
        [TestFixtureSetUp]
        public void testFixtureSetup()
        {
            try
            {
                initialise_LocalObjects();
                Framework_Initialisers();
                getMasterFileData();
                setMasterConfig();
                getMasterSheetData();
                getMainSheetData();
                //getDataSheetRow();
                

                Console.WriteLine("Executed testFixtureSetup()"+DateTime.Now);
                Thread.Sleep(5000);
                string currentPath = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                string XMLPath = currentPath.Substring(0, currentPath.LastIndexOf("packages"));
                string projectPath = new Uri(XMLPath).LocalPath; // project path of your solution
                KeyWords.XMLFilePath = projectPath + @"SmartTrack.DataAccess\Labels\CAESARS.xml";
                KeyWords.dict_Data=new Dictionary<string, string>();

                
                LogHandler.Instance._CreateLogger();
                //ExecuteStep("Creating Log File", () => LogHandler.Instance._CreateLogger(), false);
                
                
            }catch(Exception e){
                Console.WriteLine("Excetpion - " + e);
            }

        }
        [SetUp]
        public void setupRun()
        {
            Console.WriteLine("Executed setupRun()");
           // getMasterFileData();
        }
        #endregion
       
        #region TearDown
        [TearDown]
        public void tearDownRun()
        {
            Console.WriteLine("Executed tearDownRun() - Test status :" + TestContext.CurrentContext.Result.Status);
            dict_TestCaseExecutionStatus.Add(TestContext.CurrentContext.Test.Name, TestContext.CurrentContext.Result.Status);
            PreviousTestExecutionStatus = TestContext.CurrentContext.Result.Status;
            
        }
        [TestFixtureTearDown]
        public void testFixtureTearDown()
        {
            Thread.Sleep(5000);
           // ExecuteStep("Closing Browsers",()=> _Init_CloseDrivers());
           _Init_CloseDrivers();
           LogHandler.Instance._CloseLogger();
           //ExecuteStep("Closing Log File", () => LogHandler.Instance._CloseLogger(),false);
           
           Console.WriteLine("Executed testFixtureTearDown()" + DateTime.Now);

        }
        #endregion

        #region Generic
        private static string sLoginUser,sPWD;
        protected static T Sheet<T>()
        {
            Type sheetType = typeof(T);
            if (sheetType != null)
            {
                T _obj = (T)Activator.CreateInstance(sheetType);
                return _obj;
            }
            else
                return default(T) ;
        }
        protected static T Sheet<T>(DataRow dr)
        {
            Type sheetType = typeof(T);
            if (sheetType != null)
            {
                T _obj = (T)Activator.CreateInstance(sheetType, new object[]{ dr });
                
                return _obj;
            }
            else
                return default(T);
        }

        string _getLoginUser()
        {
            if (sLoginUser != "")
            {
                return sLoginUser;
            }
            else
                throw new NullReferenceException();
        }

        //void _SetLoginData(String sUserType, String sSheetName, String sScenarioID, String sTestCaseID)
        //{
        //    string sQuery1;
        //    try
        //    {
        //        sQuery1 = "SELECT * FROM [" + sSheetName + "] WHERE TestCaseId= '" + sTestCaseID + "' and TestScenario = '" + sScenarioID + "'";
        //        DataRow dtr = getTestStepData(sSheetName, sQuery1);
        //        switch (sUserType.ToUpper())
        //        {
        //            case "MSP":
        //                sLoginUser = ConfigurationManager.AppSettings["MSP_User"] = dtr["UserId"].ToString();
        //                break;
        //            case "CLIENT":
        //               sLoginUser = ConfigurationManager.AppSettings["Client_User"] = dtr["UserId"].ToString();
        //                break;
        //            case "SUPPLIER":
        //               sLoginUser = ConfigurationManager.AppSettings["Supplier_User"] = dtr["UserId"].ToString();
        //                break;
        //            case "CW":
        //               sLoginUser= ConfigurationManager.AppSettings["CW_User"] = dtr["UserId"].ToString();
        //                break;
        //            default: break;
        //        }

        //       sPWD= ConfigurationManager.AppSettings["PWD"] = dtr["Password"].ToString();




        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}
        
        public Result _Login(IWebDriver WDriver, DataRow LoginData)
        {
            try
            {
                ExecuteStep("Navigate To URL", ()=>_NavigateToURL(WDriver, ConfigurationManager.AppSettings["URL1"]),true,true);
                
                _kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txtEmailAddress, _getLoginUser(), false);
                _kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txtEmailAddress, ConfigurationManager.AppSettings["Pwd"], false);

            }catch(Exception e)
            {

            }




           

            
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
            

            if (results.Result1 == KeyWords.Result_FAIL)
            {
                return results;
            }
            //ImplicitTwentySeconds(WDriver);
           // results = kwm.sendText(WDriver, KeyWords.locator_ID, KeyWords.ID_txtPassword, pwd, false);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                return results;
            }
            //ImplicitTwentySeconds(WDriver);
            //results = kwm.click(WDriver, KeyWords.locator_ID, KeyWords.ID_btnLogin);
            if (results.Result1 == KeyWords.Result_FAIL)
            {
                return results;
            }
            // Thread.Sleep(5000);
            // Implicitt(WDriver);
            //ImplicitThirtySeconds(WDriver);
            // Console.WriteLine("Testing Login error msg");
            //if (kwm.isElementPresent(WDriver, KeyWords.ID_btnLogin))
            //{
            //    Thread.Sleep(5000);
            //}
            //if (kwm.isElementPresent(WDriver, KeyWords.ID_DefaultContent_errorPanel))
            //{
            //    // Console.WriteLine("Testing Login error msg1");
            //    results = kwm.Get_Err_Login(WDriver, KeyWords.locator_ID, KeyWords.ID_DefaultContent_lblError);
            //    if (results.Result1 == KeyWords.Result_PASS)
            //    {
            //        if (results.ErrorMessage != "")
            //        {
            //            results.Result1 = KeyWords.Result_FAIL;
            //            return results;
            //        }

            //    }
            //    if (results.Result1 == KeyWords.Result_FAIL)
            //    {
            //        return results;
            //    }
            //}

            Boolean bFlag = false;
            for (int i = 1; i < 200; i++)
            {
                Thread.Sleep(100);

                // if (kwm.isElementDisplayed(WDriver, KeyWords.ID_Menu_gnmenu))

                //Added new method as per new ui change
                //if (kwm.isElementDisplayedXpath(WDriver, KeyWords.ID_Menu_gnmenu))
                //{
                //    bFlag = true;
                //    Thread.Sleep(100);
                //    //  Console.WriteLine("i count ---> ");
                //    //  Console.WriteLine(i);

                //}
                if (bFlag)
                    break;
            }
            if (bFlag)
            {
                results.Result1 = KeyWords.Result_PASS;
                results.ErrorMessage = KeyWords.MSG_strLoginsuccessfully;
                return results;
            }
            if (!_kwm.isElementPresent(WDriver, KeyWords.ID_Menu_gnmenu))
            {
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = KeyWords.MSG_strLoginTakingLongTime;
                return results;
            }
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = KeyWords.MSG_strLoginsuccessfully;
            return results;
        }

        public void ExecuteStep(string sMessage, Action method, bool bDependentOnAbove = true, bool bStopExecutionOnFail=true)
        {

            try
            {

                if (bDependentOnAbove)
                {
                    if (Result.PrevStepResult == TestState.Success)
                    {
                        method();
                        Result.PrevStepResult = TestState.Success;
                        Assert.Pass(sMessage + "- Execution: Pass");
                    }
                    else
                    {
                        Result.PrevStepResult = TestState.Skipped;
                        Console.WriteLine(sMessage + ": Skipped");
                        Console.WriteLine("Skipped executing -" + sMessage + ". as "+lst_StepMesages.Last()+" Skipped");
                        LogHandler.Instance.LogStep(LogLevel.Severe, sMessage + ": Skipped");
                        LogHandler.Instance.LogStep(LogLevel.Warning, "Unable to Execute -" + sMessage + ". as " + lst_StepMesages.Last() + " Failed");
                        //throw new Exception("Unable to Execute -" + sMessage + ". Previous Step Failed");
                    }

                }
                else
                {
                    method();
                    Result.PrevStepResult = TestState.Success;
                    Assert.Pass(sMessage + "- Execution: Pass");
                }
            }
            catch (SuccessException se)
            {
                
            }
            catch (Exception e)
            {

                if (bStopExecutionOnFail)
                {
                    Assert.Fail();
                }
            }
            finally
            {
                lst_StepMesages.Add(sMessage);
                
            }
        }
        #endregion Generic
    }

    public class DependentTestAttribute : Attribute, ITestAction
    {
        private readonly Boolean bDependent;

        public DependentTestAttribute(Boolean bVal)
        {
            bDependent = bVal;
        }
        public void AfterTest(TestDetails testDetails)
        {
            
        }
        
        public void BeforeTest(TestDetails testDetails)
        {
            try
            {
                if (bDependent)
                {
                    if (Initialiser.PreviousTestExecutionStatus != TestStatus.Passed)
                    {
                        Assert.Ignore();
                        
                    }

                }
            }catch(Exception e)
            {
                Console.WriteLine("Ignored - "+ TestContext.CurrentContext.Test.Name);
                Assert.Ignore();
                
            }

        }

        public ActionTargets Targets
        {
            get;
            private set;
        }

    }
}
