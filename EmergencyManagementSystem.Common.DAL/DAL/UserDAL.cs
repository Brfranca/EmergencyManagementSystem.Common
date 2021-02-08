using EmergencyManagementSystem.Common.Common.Filters;
using EmergencyManagementSystem.Common.Common.Interfaces;
using EmergencyManagementSystem.Common.Common.Utils;
using EmergencyManagementSystem.Common.Entities.Entities;
using System.Linq;

namespace EmergencyManagementSystem.Common.DAL.DAL
{
    public class UserDAL : BaseDAL<User>, IUserDAL
    {
        public UserDAL(Context context) : base(context)
        {
        }

        public User Find(UserFilter filter)
        {
            return Set.FirstOrDefault
                (
                    d => d.Login == filter.Login
                    && d.Password == Hash.Create(filter.Password)
                );
        }
    }
}
