#region namespaces
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

#endregion

namespace CommonFiles
{
    public class FirefoxBrowser
    {
        private static FirefoxBrowser instance;
        public static FirefoxBrowser Instance
        {
            get
            {
                if (instance == null)
                {
                        if (instance == null)
                        {
                            instance = Activator.CreateInstance<FirefoxBrowser>();
                        }
                }
                return instance;
            }
        }

        public IWebDriver GetBrowser()
        {

            //FirefoxProfile profile = new FirefoxProfile();
            //profile.SetPreference("setEnableNativeEvents", true);
            //profile.SetPreference("setAcceptUntrustedCertificates", true);
            //profile.SetPreference("setAssumeUntrustedCertificateIssuer", true);
            return new FirefoxDriver();
                
        }
    }
}
