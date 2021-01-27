using EmergencyManagementSystem.Common.Common.Filters;
using EmergencyManagementSystem.Common.Entities.Entities;

namespace EmergencyManagementSystem.Common.Common.Interfaces
{
    public interface IOccupationDAL : IBaseDAL<Occupation>
    {
        Occupation Find(OccupationFilter filter);
    }
}
