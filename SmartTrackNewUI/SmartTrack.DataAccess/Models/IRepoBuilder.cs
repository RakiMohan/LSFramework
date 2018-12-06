using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SmartTrack.DataAccess.Models
{
    public interface IRepoBuilder
    {
       void buildRepository(DataRow dr);
       void NavigateTo();
       void setWebdriverWait();
       void setWebdriverWait(int val);

    }
}
