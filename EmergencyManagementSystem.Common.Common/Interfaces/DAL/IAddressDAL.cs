using EmergencyManagementSystem.Common.Common.Filters;
using EmergencyManagementSystem.Common.Entities.Entities;

namespace EmergencyManagementSystem.Common.Common.Interfaces
{
    public interface IAddressDAL : IBaseDAL<Address>
    {
        Address Find(AddressFilter filter);
    }
}
