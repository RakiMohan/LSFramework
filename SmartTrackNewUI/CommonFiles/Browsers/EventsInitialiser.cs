using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium;

namespace CommonFiles
{
    public class EventsInitialiser : LogHandler
    {
        public static void _TriggerDriverEvents(EventFiringWebDriver eventDriver)
        {
            eventDriver.Navigated += _eventDriver_Navigated;
            eventDriver.NavigatedBack += eventDriver_NavigatedBack;
            eventDriver.ElementClicked += eventDriver_ElementClicked;
            eventDriver.ElementClicking += eventDriver_ElementClicking;
            eventDriver.FindingElement += eventDriver_FindingElement;
            eventDriver.FindElementCompleted += eventDriver_FindElementCompleted;
            eventDriver.ElementValueChanged += eventDriver_ElementValueChanged;
        }

        static void eventDriver_ElementValueChanged(object sender, WebElementEventArgs e)
        {
            Console.WriteLine("Element Value Changed - ");
            LogHandler.Instance.LogStep("Element Value Changed - " + e.Element.Text);
        }

        static void eventDriver_FindElementCompleted(object sender, FindElementEventArgs e)
        {
            Console.WriteLine("Completed finding - " + e.Element);
            LogHandler.Instance.LogStep("Completed finding - " + e.Element);
        }

        static void eventDriver_FindingElement(object sender, FindElementEventArgs e)
        {
            Console.WriteLine("finding Element-" + e.Element);
            LogHandler.Instance.LogStep("finding Element - " + e.Element);
        }

        static void eventDriver_ElementClicking(object sender, WebElementEventArgs e)
        {
            Console.WriteLine("Clicking on Element - " + e.Element);
            LogHandler.Instance.LogStep("Clicking on Element - " + e.Element);
        }

        static void eventDriver_ElementClicked(object sender, WebElementEventArgs e)
        {
            Console.WriteLine("Clicked on Element - "+ e.Element);
            LogHandler.Instance.LogStep("Clicked on Element - " + e.Element);
        }

        static void eventDriver_NavigatedBack(object sender, WebDriverNavigationEventArgs e)
        {
            
        }

        static void _eventDriver_Navigated(object sender, WebDriverNavigationEventArgs e)
        {
            Console.WriteLine("Navigated to -"+e.Url);
            LogHandler.Instance.LogStep("Navigated to -" + e.Url);
        }
    }
}
