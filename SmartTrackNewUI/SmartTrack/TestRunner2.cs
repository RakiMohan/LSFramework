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
using CommonFiles.Users;
namespace SmartTrack_Automation
{
   
    public class TestRunner2 : Initialiser
    {
        DriverListeners dl = new DriverListeners();
        IWebDriver _driver;
        EventFiringWebDriver eventDriver;
        static int i = 1, j=1;
       // [Test]
        public void test1()
        {
            
            sendMail smail = new sendMail();
            eventDriver = new EventFiringWebDriver(_driver);
            eventDriver.ElementClicked+= new EventHandler<WebElementEventArgs> (OnElementClick);
            eventDriver.Navigated += new EventHandler<WebDriverNavigationEventArgs>(OnNavigated);

            eventDriver.Navigate().GoToUrl("https://google.com");
            
        }
        //[Test]
        public void test2()
        {

            driverMSP.Navigate().GoToUrl("https://gmail.com");

            
        }

       // [Test]
        public void test3()
        {
            driverCW.Navigate().GoToUrl("https://google.com");
            driverMSP.Navigate().GoToUrl("https://appsheet.com");
        }

        static void OnElementClick(object sender, WebElementEventArgs args)
        {
            Console.WriteLine("Clicked on Element"+ i++);
        }
        static void OnNavigated(object sender, WebDriverNavigationEventArgs args)
        {
            Console.WriteLine("navigated to" + args.Url);
        }
    }
    public class sendMail
    {
        public  void OnElementClicked(object sender,WebElementEventArgs arg)
        {
            Console.WriteLine("Mail Sent Successfully....");
        }

        public void OnEncoded(object sender, EventArgs args)
        {
            Console.WriteLine("Mail sent successfully..");
        }
    }
    public class sendMessage
    {
        public  void OnElementClicked(object sender, WebElementEventArgs arg)
        {
            Console.WriteLine("Message Sent Successfully....");
        }
        public void OnEncoded(object sender, EventArgs args)
        {
            Console.WriteLine("Message sent successfully..");
        }
    }
}

//List<string> li = new List<string>() {"1","2","3" };
//                foreach (string s in li)
//                {
//                    var _main = new Main()
//                    {
//                        TestScenarioID = s,
//                        Description = s+s,
//                        TestCaseID = s+s+s,
//                        DataSheet = s+s+s+s

//                    };
//                    Dictionary<object, string> dc = new Dictionary<object, string>();
//                    dc.Add(_main, "");
//                }