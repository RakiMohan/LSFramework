using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTrack.DataAccess
{
   public class Main : DataSheet
    {
       public  string TestScenarioID { get; set; }

       public  string TestCaseID { get; set; }

       public string Description{ get; set; }

       public string DataSheet { get; set; }
    }
}
