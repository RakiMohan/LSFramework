using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
namespace Test
{
    
    public class SampleRun
    {
        [Test]
        public void t()
        {
            IWebDriver dr = new FirefoxDriver();
            dr.Navigate().GoToUrl("https://google.com");
            WebDriverWait _wait = new WebDriverWait(dr,TimeSpan.FromSeconds(10));
            
        }
        
    }
}
