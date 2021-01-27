using EmergencyManagementSystem.Common.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyManagementSystem.Common.DAL.DAL
{
    public class OccupationDAL : BaseDAL<Occupation>
    {
        public OccupationDAL(Context context) : base(context)
        {
        }
    }
}
