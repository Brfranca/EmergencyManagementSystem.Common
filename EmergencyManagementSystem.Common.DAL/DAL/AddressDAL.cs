using EmergencyManagementSystem.Common.Common.Filters;
using EmergencyManagementSystem.Common.Common.Interfaces;
using EmergencyManagementSystem.Common.Entities.Entities;
using System.Linq;

namespace EmergencyManagementSystem.Common.DAL.DAL
{
    public class AddressDAL : BaseDAL<Address>, IAddressDAL
    {
        public AddressDAL(Context context) : base(context)
        {
        }

        public Address Find(AddressFilter filter)
        {
            return Set.FirstOrDefault(d => d.Id == filter.Id);
        }
    }
}
