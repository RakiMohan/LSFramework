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
    public class IEBrowser
    {
        private static IEBrowser instance;
        public static IEBrowser Instance
        {
            get
            {
                if (instance == null)
                {
                    if (instance == null)
                    {
                        instance = Activator.CreateInstance<IEBrowser>();
                    }
                }
                return instance;
            }
        }
        public IWebDriver GetBrowser()
        {

            //var options = new InternetExplorerOptions();
            //options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            ////Clean the session before launching the browser
            //options.EnsureCleanSession = true;
            //DesiredCapabilities capabilities = DesiredCapabilities.InternetExplorer();
            //capabilities.SetCapability(CapabilityType.AcceptSslCertificates, true);
            //capabilities.SetCapability("requireWindowFocus", true);
            return new InternetExplorerDriver();
                

        }
    }
}
