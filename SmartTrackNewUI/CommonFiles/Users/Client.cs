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
    public class Client_User : User
    {
        private static Client_User instance;
        private EventFiringWebDriver _driverClient;
        public static Client_User Instance
        {
            get
            {
                if (instance == null)
                {
                    instance= Activator.CreateInstance<Client_User>();

                }

                return instance;
            }
        }

        public EventFiringWebDriver _ClientDriver
        {
            get
            {
                if (_driverClient==null)
                _driverClient = BrowserAppFactory.Instance.getDriver(ConfigurationManager.AppSettings["Client_Browser"].ToString());
                
                return _driverClient;
            }
        }
        public void CloseBrowser()
        {
            if (this._driverClient != null)
            {
                _driverClient.Quit();
                LogHandler.Instance.LogStep(ConfigurationManager.AppSettings["Client_Browser"].ToString() + " Instance for Client User is Closed");
            }
            else
                LogHandler.Instance.LogStep("Client Browser:- " + ConfigurationManager.AppSettings["Client_Browser"].ToString() + "- Is Not Initialised in the current run");
        }
    }
}
