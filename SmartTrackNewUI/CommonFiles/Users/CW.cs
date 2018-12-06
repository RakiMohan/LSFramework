using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonFiles;
using System.Configuration;
using OpenQA.Selenium.Support.Events;
namespace CommonFiles.Users
{
    public class CW_User : User
    {
        private static CW_User instance;
        private EventFiringWebDriver _driverCW;
        public static CW_User Instance
        {
            get
            {
                if (instance == null)
                {
                    instance= Activator.CreateInstance<CW_User>();

                }

                return instance;
            }
        }

        public EventFiringWebDriver _CWDriver
        {
            get
            {
                if(_driverCW==null)
                     _driverCW= BrowserAppFactory.Instance.getDriver(ConfigurationManager.AppSettings["CW_Browser"].ToString());

                return _driverCW;
            }
        }
        public void CloseBrowser()
        {
            if (this._driverCW != null)
            {
                _driverCW.Quit();
                LogHandler.Instance.LogStep(ConfigurationManager.AppSettings["CW_Browser"].ToString() + " Instance for CW is Closed");
                
            }
            else
                LogHandler.Instance.LogStep(ConfigurationManager.AppSettings["CW_Browser"].ToString() + " Instance for CW is Not Initialised in the current run");
        }
    }
}
