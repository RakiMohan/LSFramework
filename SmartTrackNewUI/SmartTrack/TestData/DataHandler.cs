using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTrack_Automation
{
    public class DataHandler
    {
        public static List<DataSheetParams> lst_DataObjectParams;
        public static void _AddDataObjectParams(string SheetName, string TestScenarioID, string TestCaseID)
        {
            DataSheetParams _dsp = new DataSheetParams(SheetName, TestScenarioID, TestCaseID);
            if (lst_DataObjectParams != null)
            {
                lst_DataObjectParams.Add(_dsp);
            }
            else
                throw new NullReferenceException("List<DataSheetParams> lst_DataObjectParams is null.To add the DataSheetParams object, it has to be initialised");
        }
    }

    public class DataSheetParams
    {
        public  string sSheetName { get; set; }
        public  string sScenarioID { get; set; }
        public  string sTestCaseID { get; set; }

        public DataSheetParams(string SheetName, string TestScenarioID, string TestCaseID)
        {
            sSheetName = SheetName;
            sScenarioID = TestScenarioID;
            sTestCaseID = TestCaseID;
        }
    }
}
