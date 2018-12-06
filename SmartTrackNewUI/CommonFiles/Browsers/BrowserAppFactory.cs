using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;

namespace CommonFiles
{
    public class BrowserAppFactory
    {
        
        private static BrowserAppFactory instance;
        public static BrowserAppFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    if (instance == null)
                    {
                        instance = Activator.CreateInstance<BrowserAppFactory>();
                    }
                }
                return instance;
            }
        }

        public EventFiringWebDriver getDriver(string sBrowser)
        {
            switch (sBrowser.ToUpper())
            {
                case "CHROME":
                    return getEventFiringWD(ChromeBrowser.Instance.GetBrowser());

                case "FIREFOX":
                    return getEventFiringWD(FirefoxBrowser.Instance.GetBrowser());

                case "IE":
                    return getEventFiringWD(IEBrowser.Instance.GetBrowser());

                default:
                    return getEventFiringWD(FirefoxBrowser.Instance.GetBrowser());
            }
        }

        static EventFiringWebDriver getEventFiringWD(IWebDriver _dr)
        {
            EventFiringWebDriver eventDr = new EventFiringWebDriver(_dr);
            EventsInitialiser._TriggerDriverEvents(eventDr);
            return eventDr;
        }

       
    }
}
