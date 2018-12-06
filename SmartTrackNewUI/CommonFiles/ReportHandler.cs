using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelevantCodes.ExtentReports;

namespace CommonFiles
{
    public class ReportHandler
    {
        public static ExtentTest _ParentTest, _ChildTest, _LblParent, _LblChild;
        public static Boolean _IsLabelReportRequired;

        public static ExtentTest _getParentTest()
        {

            if (_ParentTest != null)
                return _ParentTest;
            else
                throw new Exception("ExtentTest Variable is null. Please set the value for ExtentTest.var_ExtTest to use extent reports.");
        }
        public static ExtentTest _getChildTest()
        {

            if (_ChildTest != null)
                return _ChildTest;
            else
                throw new Exception("ExtentTest Variable is null. Please set the value for ExtentTest.var_ExtTest to use extent reports.");
        }
        public static ExtentTest _getLblParentTest()
        {

            if (_LblParent != null)
                return _LblParent;
            else
                throw new Exception("ExtentTest Variable is null. Please set the value for ExtentTest.var_ExtTest to use extent reports.");
        }
        public static ExtentTest _getLblChildTest()
        {

            if (_LblChild != null)
                return _LblChild;
            else
                throw new Exception("ExtentTest Variable is null. Please set the value for ExtentTest.var_ExtTest to use extent reports.");
        }
    }
}
