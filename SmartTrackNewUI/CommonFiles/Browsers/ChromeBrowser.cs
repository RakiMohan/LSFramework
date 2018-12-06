using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using SmartTrack_Automation;

namespace CommonFiles
{
    public class ChromeBrowser
    {
        ChromeDriver _driver;
        private static ChromeBrowser instance;
        public static ChromeBrowser Instance
        {
            get
            {
                if (instance == null)
                {
                    if (instance == null)
                    {
                        instance = Activator.CreateInstance<ChromeBrowser>();
                    }
                }
                return instance;
            }
        }
        public IWebDriver GetBrowser()
        {
            this._driver = new ChromeDriver();
            return _driver;
        }

        
    }
}
