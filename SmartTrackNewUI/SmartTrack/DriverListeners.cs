using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Api;

using NUnit.Common;
using NUnit.ConsoleRunner;
using NUnit.Core;
using NUnit.Gui;
using NUnit.TestUtilities;
using NUnit.VisualStudio;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Chrome;



namespace SmartTrack_Automation
{


    public class DriverListeners 
    {
        public delegate void Encoder(object sender, EventArgs args);
        public event Encoder eEncode;
        public void OnElementClicked(object sender, WebElementEventArgs args)
        {

            Console.WriteLine("element Clicked");
            
        }
        
         public void Encode(string s)
         {
             Console.WriteLine("Encoding string.."+ s);
             Thread.Sleep(5000);
             IWebDriver driverD=null;
             IWebElement ele=null;
             //OnElementClicked(this,new WebElementEventArgs(driverD,ele));
             OnEncoded();
         }
         public void OnEncoded()
         {
             if(eEncode!=null){
                 eEncode(this,EventArgs.Empty);
             }
         }
    }
}
