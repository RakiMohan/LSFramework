using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using OpenQA.Selenium;
using NUnit.Framework;

namespace SmartTrack_Automation
{
   // [TestClass]
    public class Result
    {
        public static TestState PrevStepResult { get; set; }
        public Result()
        {
            listData = new List<string>();
            listData2 = new List<string>();
            
        }
        
        public string Result1 { get; set; }

        public Boolean blnResult { get; set; }

        public string Message { get; set; }

        public string ErrorMessage { get; set; }

        public string ErrorMessage1 { get; set; }

        public DataTable dt { get; set; }

        public string _Var { get; set; }
        public List<string> listData { get; set; }

        public List<string> listData2 { get; set; }

        public Boolean blnFlag { get; set; }

        public IWebDriver driver { get; set; }

       
    }
}
