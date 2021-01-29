using EmergencyManagementSystem.Common.Common.Filters;
using EmergencyManagementSystem.Common.Common.Interfaces.DAL;
using EmergencyManagementSystem.Common.Entities.Entities;
using System.Linq;

namespace EmergencyManagementSystem.Common.DAL.DAL
{
    public class RequesterDAL : BaseDAL<Requester>, IRequesterDAL
    {
        public RequesterDAL(Context context) : base(context)
        {
        }

        public Requester Find(RequesterFilter filter)
        {
            return Set.FirstOrDefault(x => x.Telephone == filter.Telephone);
        }
    }
}
