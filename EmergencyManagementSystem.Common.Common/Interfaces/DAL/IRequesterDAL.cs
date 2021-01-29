using EmergencyManagementSystem.Common.Common.Filters;
using EmergencyManagementSystem.Common.Entities.Entities;

namespace EmergencyManagementSystem.Common.Common.Interfaces.DAL
{
    public interface IRequesterDAL : IBaseDAL<Requester>
    {
        Requester Find(RequesterFilter filter);
    }
}
