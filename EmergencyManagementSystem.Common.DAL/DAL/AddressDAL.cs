using EmergencyManagementSystem.Common.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyManagementSystem.Common.DAL.DAL
{
    public class AddressDAL : BaseDAL<Address>
    {
        public AddressDAL(Context context) : base(context)
        {
        }
    }
}
