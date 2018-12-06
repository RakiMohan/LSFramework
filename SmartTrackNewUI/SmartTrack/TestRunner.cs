using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartTrack_Automation;
using NUnit.Framework;
using NUnit.TestUtilities;
using NUnit.Common;
using System.Data;
using NUnit.Framework.Attributes;
using System.Xml;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium;
namespace SmartTrack_Automation
{
   
    //public class TestRunner : Initialiser
    //{
    ////    DriverListeners dl = new DriverListeners();
        
    ////   // [Test]
    ////    public void test7()
    ////    {
    ////        foreach(XmlNode node in _GetConditionalRuns())
    ////        {
    ////            foreach (XmlNode _node in node.SelectNodes("add"))
    ////            {
    ////                KeyWords.dict_Data.Add(_node.Attributes["key"].InnerText, _node.Attributes["value"].InnerText);
    ////            }
    ////            _LoadInputData(xml_Doc);
    ////        }
    ////        ExecuteStep("", () => Console.WriteLine(), true, true);
    ////        Console.WriteLine("tes7");
    ////        Assert.Fail();
            
    ////    }
        
    ////    [Test]
    ////    [DependentTest(true)]
    ////    public static void test8()
    ////    {
    ////        Console.WriteLine("tes8");
    ////    }
    ////    [Test]
    ////    public static void test6()
    ////    {
    ////        Console.WriteLine("test6");
    ////    }

    ////    [Test]
    ////    public void CreateRequrirement()
    ////    {
            
    ////        EventFiringWebDriver eventdriver = new EventFiringWebDriver(_CWDriver);
            
    ////        sendMail smail = new sendMail();
    ////        sendMessage smesg = new sendMessage();
    ////         //WebElementEventArgs bb= new WebElementEventArgs(dl,ele);
    ////        // eventdriver.ElementClicked += dl.OnElementClicked;//new EventHandler<WebElementEventArgs>(dl.OnElementClicked);
    ////        //eventdriver.ElementClicked += smail.OnElementClicked;
    ////        dl.eEncode += smail.OnEncoded;
    ////        dl.eEncode += smesg.OnEncoded;

    ////        dl.Encode("Name");
            
            
    ////    }

        
    ////    [Test]
    ////    public void Approve()
    ////    {
    ////        dl.Encode("Phone");
    ////    }
    ////    [Test]
    ////    public static void Broadcast()
    ////    {
            
    ////    }
    //}
    //public class sendMail
    //{
    //    public  void OnElementClicked(object sender,WebElementEventArgs arg)
    //    {
    //        Console.WriteLine("Mail Sent Successfully....");
    //    }

    //    public void OnEncoded(object sender, EventArgs args)
    //    {
    //        Console.WriteLine("Mail sent successfully..");
    //    }
    //}
    //public class sendMessage
    //{
    //    public  void OnElementClicked(object sender, WebElementEventArgs arg)
    //    {
    //        Console.WriteLine("Message Sent Successfully....");
    //    }
    //    public void OnEncoded(object sender, EventArgs args)
    //    {
    //        Console.WriteLine("Message sent successfully..");
    //    }
    //}
}
