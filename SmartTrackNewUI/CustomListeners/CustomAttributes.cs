//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NUnit.Framework;



//namespace CustomListeners
//{
//    public class IgnoreTestAttribute : Attribute, ITestAction
//    {
//        private readonly Boolean bDependent;
//        public IgnoreTestAttribute(Boolean bVal)
//        {
//            bDependent = bVal;
//        }
//        public void AfterTest(NUnit.Framework.Interfaces.ITest test)
//        {
           
//        }

//        public void BeforeTest(NUnit.Framework.Interfaces.ITest test)
//        {
//            if (bDependent)
//            {
//                if (TestContext.CurrentContext.Result.Outcome.ToString().ToLower()!="passed")

//                    Assert.Ignore("Ignored :"+ test.Name);

//            }
            
//        }

//        public ActionTargets Targets
//        {
//            get;
//            private set;
//        }
//    }
//}
