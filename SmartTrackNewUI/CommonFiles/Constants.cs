// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Constants.cs" company="DCR Workforce Inc">
//   Copyright (c) DCR Workforce Inc. All rights reserved.
//   This code and information should not be copied and used outside of DCR Workforce Inc.
// </copyright>
// <summary>
//   Defines the Registration Repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CommonFiles
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Opera;
    using OpenQA.Selenium.Remote;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Constants
    {
        public const int ExplicitWaitTime = 60; // Value in Seconds

        //Constants for google
        public const string Google = "google";
        public const string TestCase010 = "010";

        public const string TestCase001 = "001";

        public const string TestCase001E = "001E";

        public const string TestCase002 = "002";

        public const string TestCase003 = "003";

        public const string TestCase004 = "004";

        public const string TestCase005 = "005";

        public const string TestCase006 = "006";

        public const string TestCase007 = "007";

        public const string TestCase008 = "008";

        public const string TestCase009 = "009";

        public const string TestCase011 = "011";

        public const string TestCase012 = "012";

        public const string TestCase013 = "013";

        public const string TestCase014 = "014";

        public const string TestCase015 = "015";

        public const string TestCase016 = "016";

        public const string TestCase017 = "017";

        public const string TestCase018 = "018";

        public const string TestCase019 = "019";

        public const string TestCase020 = "020";

        public const string TestCase021 = "021";

        public const string TestCase022 = "022";

        public const string TestCase023 = "023";

        public const string TestCase026 = "026";

        public const string TestCase027 = "027";

        public const string TestCase028 = "028";

        public const string TestCase030 = "030";

        public const string TestCase031 = "031";

        public const string TestCase032 = "032";

        public const string TestCase033 = "033";

        public const string TestCase034 = "034";

        public const string TestCase035 = "035";

        public const string TestCase036 = "036";

        public const string TestCase037 = "037";

        public const string TestCase039 = "039";

        public const string TestCase040 = "040";

        public const string TestCase041 = "041";
        public const string TestCase045 = "045";

        public const string TestCase046 = "046";

        public const string TestCase047 = "047";

        public const string TestCase048 = "048";

        public const string TestCase049 = "049";

        public const string TestCase050 = "050";

        public const string TestCase051 = "051";

        public const string TestCase052 = "052";

        public const string TestCase053 = "053";

        public const string TestCase054 = "054";

        public const string TestCase070 = "070";

        public const string TestCase081 = "081";
        public const string TestCase007E = "007E";

        public const string LoginUser_Role = "";

        public const string OK = "OK";

        public const string No = "No";

        public const string SaveandContinue = "save & continue";

        public const string cancel = "cancel";

        public const string NunitConsolePath = "'D:\\DCRNew\\NUnit-2.6.4\\bin\\nunit-console.exe";

        public const string NunitApproveBinPath = "\\SmartTrack_Approve.dll";

        public const string NunitBroadCastBinPath = "\\SmartTrack_Broadcast.dll";

        public const string NunitSupplierBinPath = "\\SmartTrack_Supplier.dll";

        public const string NunitSupplierAWOBinPath = "\\SmartTrack_Supplier_AWO.dll";

        public const string NunitSupplierIWOBinPath = "\\SmartTrack_MSP_IWO.dll";

        public const string NunitSupplierAOBinPath = "\\SmartTrack_Supplier_AO.dll";

        public const string NunitMSPSMBinPath = "\\SmartTrack_MSP_SM.dll";

        public const string NunitInterviewFlowBinPath = "\\SmartTrack_Interview_Process.dll";

        public const string NunitMSPOBBinPath = "\\SmartTrack_MSP_OB.dll";

        public const string NunitMSPCWBinPath = "\\SmartTrack_MSP_CW.dll";

        public const string NunitMSPOHEOBinPath = "\\SmartTrack_MSP_OH_EO.dll";

        public const string NunitMSPEOBinPath = "\\SmartTrack_MSP_EO.dll";

        public const string ChormeOptionMaximized = "--start-maximized";

        public const string ChromeTestType = "test-type";

        public const string Chrome = "chrome";

        public const string IE = "ie";

        public const string Opera = "opera";

        public const string IEEdge = "ieedge";

        public const string NvEnergy = "nv energy";

        public const string SaviTechnologies = "savi technologies";

        public const string Sts = "sts";

        public const string IsGs = "leidos";

        public const string STTM = "stttm";

        public const string MFC = "mfc";

        public const string LmPinellas = "lm-pinellas";

        public const string AmCom = "amcom";

        public const string DCR = "dcr";

        public const string YP = "yp";

        public const string Meritor = "meritor";

        public const string GHC = "ghc";

        public const string BDA = "bda";

        public const string Arkema = "arkema";

        public const string Aero = "aero";

        public const string Supervalu = "supervalu";

        public const string Caesars = "caesars";

        public const string Epri = "epri";

        public const string Costco = "costco";

        public const string Discover = "discover";

        public const string Keybank = "keybank";

        public const string Welchallyn = "welch allyn";

        public const string APS = "arizona public service";

        public const string StewartTitle = "stewart title";

        public const string Dyncorp = "dyncorp";

        public const string Altria = "altria";

        public const string Ryder = "ryder";

        public const string EBS = "ebs";

        public const string RMS = "rms";

        public const string STGEN = "stgen";

        public const string STTTM = "stttm";

        public const string Fabco = "fabco";

        public const string EMERSON = "emerson";

        public const string KCPL = "kcpl";

        public const string SallieMae = "sallie mae";

        public const string SOF = "sof"; //Adding a clients to list

        public const string HillRom = "hill-rom"; //Adding a clients to list

        public const string Martiz = "maritz"; //Adding a clients to list

        public const string Bimbo = "bimbo bakeries";

        public const string Colgate = "colgate";

        public const string STNow = "smart track now";

        public const string ThermoFisher = "thermo fisher";

        public const string SunTrust = "suntrust";

        public const string Tufts = "tufts";

        public const string PHHMortgage = "phh mortgage";

        public const string Cpchem = "cpchem";

        public const string Tesla = "tesla";

        public const string QuickenLoans = "quicken loans";

        public const string Georgetown = "georgetown";

        public const string COE = "city of edmonton";

        public const string Lear = "lear";

        public const string EQT = "eqt";

        public const string SIGMA = "sigma";

        public const string GeoLocation = "geographical location";

        public const string SvmsBroadcast = "social vms broadcast";

        public const string SupplierMarkup = "supplier markup";

        public const string PayRateMarkup = "PayRateMarkup";

        public const string Approve = "Approve";

        public const string Approved = "Approved";

        public const string Reject = "Reject";

        public const string Rejected = "Rejected";

        public const string Done = "Done";

        public const string Pass = "Pass";

        public const string ADDCandToResumeBank = "add candidate to resume bank";

        public const string LoadingMessage = "loading-message";


        public static IWebDriver CreateChromeDriver(IWebDriver driver)
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            driver = new ChromeDriver(driverService, new ChromeOptions());

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArguments("test-type");
            return driver;
        }

        //public static IWebDriver CreateOperaDriver(IWebDriver driver)
        //{

        //    DesiredCapabilities opera = DesiredCapabilities.Opera();
        //    opera.SetCapability("opera.profile", @"D:\\STAUTO\\SMARTTrack70MAIN\\SMARTTrack-MAIN-Automation\\SmartTrackAutomation-New\\SmartTrack\\bin\\Debug\\operadriver.exe");
        //    driver = new RemoteWebDriver(opera);
        //    // driver = new OperaDriver("D:\\STAUTO\\SMARTTrack70MAIN\\SMARTTrack-MAIN-Automation\\SmartTrackAutomation-New\\SmartTrack\\bin\\Debug\\operadriver.exe");
        //    //var driverService = OperaDriverService.CreateDefaultService();
        //    //driverService.HideCommandPromptWindow = true;
        //    //driver = new OperaDriver(driverService, new OperaOptions());
        //    //driver=new OperaDriver("D:\\STAUTO\\SMARTTrack70MAIN\\SMARTTrack-MAIN-Automation\\SmartTrackAutomation-New\\SmartTrack\\bin\\Debug\\operadriver.exe");
        //    // OperaOptions options = new OperaOptions();

        //    //driver = new OperaDriver(driverService, options);
        //    //options.AddArgument("--start-maximized");
        //    //options.AddArguments("test-type");
        //    return driver;

        //}


    }
}
