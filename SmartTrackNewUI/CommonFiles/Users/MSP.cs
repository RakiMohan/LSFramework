using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.Events;
using CommonFiles;
using System.Configuration;
using OpenQA.Selenium;

namespace CommonFiles.Users
{
    public class MSP_User : User
    {
        private static MSP_User instance;
        private EventFiringWebDriver _driverMSP;
        public static MSP_User Instance
        {
            get
            {
                if(instance==null)
                {
                    instance= Activator.CreateInstance<MSP_User>();
                }

                return instance;
            }
        }

        public EventFiringWebDriver _MSPDriver 
        {
          get
            {
                if (_driverMSP == null)
                    _driverMSP= BrowserAppFactory.Instance.getDriver(ConfigurationManager.AppSettings["MSP_Browser"].ToString());
                
                return _driverMSP;
            }

        }

        public void CloseBrowser()
        {
            if (this._driverMSP != null)
            {
                _driverMSP.Quit();
                LogHandler.Instance.LogStep(ConfigurationManager.AppSettings["MSP_Browser"].ToString() + " Instance for MSP is Closed");
            }
            else
                LogHandler.Instance.LogStep(ConfigurationManager.AppSettings["MSP_Browser"].ToString() + " Instance for MSP is Not Initialised in the current run");
        }
    }
}
