using EmergencyManagementSystem.Common.Common.Interfaces.BLL;

namespace EmergencyManagementSystem.Common.Common.Filters
{
    public class EmployeeFilter : FilterBase
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; }
    }
}
