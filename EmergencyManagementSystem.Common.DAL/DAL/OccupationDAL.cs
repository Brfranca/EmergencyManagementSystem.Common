using EmergencyManagementSystem.Common.Common.Filters;
using EmergencyManagementSystem.Common.Common.Interfaces;
using EmergencyManagementSystem.Common.Entities.Entities;
using System.Linq;

namespace EmergencyManagementSystem.Common.DAL.DAL
{
    public class OccupationDAL : BaseDAL<Occupation>, IOccupationDAL
    {
        public OccupationDAL(Context context) : base(context)
        {
        }

        public Occupation Find(OccupationFilter filter)
        {
            return Set.FirstOrDefault(x => x.Profession == filter.Profession);
        }
    }
}
