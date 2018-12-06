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
    public class Supplier_User : User
    {
        private static Supplier_User instance;
        private EventFiringWebDriver _driverSupplier;
        public static Supplier_User Instance
        {
            get
            {
                if (instance == null)
                {
                    instance= Activator.CreateInstance<Supplier_User>();

                }

                return instance;
            }
        }

        public EventFiringWebDriver _SupplierDriver
        {
            get
            {
                if (_driverSupplier == null)
                   _driverSupplier= BrowserAppFactory.Instance.getDriver(ConfigurationManager.AppSettings["Supplier_Browser"].ToString());
                
                return _driverSupplier;
            }
        }

        public void CloseBrowser()
        {
            if (this._driverSupplier != null)
            {
                _driverSupplier.Quit();
                LogHandler.Instance.LogStep(ConfigurationManager.AppSettings["Supplier_Browser"].ToString() + " Instance for Supplier User is Closed");
            }
            else
                LogHandler.Instance.LogStep("Supplier Browser-" + ConfigurationManager.AppSettings["Supplier_Browser"].ToString() + "- Is Not Initialised in the current run");
        }
    }
}
