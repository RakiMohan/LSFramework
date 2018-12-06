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

namespace SmartTrack
{


    public class TestListeners :EventListener
    {

        public void RunFinished(Exception exception)
        {
            throw new NotImplementedException();
        }

        public void RunFinished(TestResult result)
        {
            throw new NotImplementedException();
        }

        public void RunStarted(string name, int testCount)
        {
            throw new NotImplementedException();
        }

        public void SuiteFinished(TestResult result)
        {
            throw new NotImplementedException();
        }

        public void SuiteStarted(TestName testName)
        {
            throw new NotImplementedException();
        }

        public void TestFinished(TestResult result)
        {
            throw new NotImplementedException();
        }

        public void TestOutput(TestOutput testOutput)
        {
            throw new NotImplementedException();
        }

        public void TestStarted(TestName testName)
        {
            throw new NotImplementedException();
        }

        public void UnhandledException(Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}
