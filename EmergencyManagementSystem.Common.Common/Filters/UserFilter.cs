using EmergencyManagementSystem.Common.Common.Interfaces.BLL;

namespace EmergencyManagementSystem.Common.Common.Filters
{
    public class UserFilter : FilterBase
    {
        public long EmployeeId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
