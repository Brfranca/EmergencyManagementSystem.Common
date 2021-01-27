using EmergencyManagementSystem.Common.Common.Filters;
using EmergencyManagementSystem.Common.Entities.Entities;

namespace EmergencyManagementSystem.Common.Common.Interfaces
{
    public interface IUserDAL : IBaseDAL<User>
    {
        User Find(UserFilter filter);
    }
}
