using EmergencyManagementSystem.Common.Common.Interfaces.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyManagementSystem.Common.Common.Filters
{
    public class FilterBase : IFilter
    {
        public int CurrentPage { get; set; }
    }
}
