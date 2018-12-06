using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartTrack_Automation;
using NUnit.Framework;
using NUnit.TestUtilities;
using NUnit.Common;
using System.Data;
using NUnit.Framework.Attributes;
using System.Xml;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium;

namespace SmartTrack_Automation
{

    public class Exec_CreateRequirement : Initialiser
    {

        [Test]
        [TestCase(new object[]{"MSP$","001","001"})]
        //[TestCase(new object[] { "MSP$", "004", "001" })]
        public void TC01_Fn_CreateRequirement(object[] _params)
        {

            foreach (DataRow dr in getTestStepData(_params[0].ToString(), _params[1].ToString(), _params[2].ToString()))
            {

                CreateRequirement obj_CreateRequirement = new CreateRequirement(driverMSP,getKWM(),getCMNM(),dr);
                driverMSP.Url = "https://transformationqa1.hcmondemand.net";
                
            }
        }

        
    }
}
