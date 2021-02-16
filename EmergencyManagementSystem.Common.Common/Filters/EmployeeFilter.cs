using EmergencyManagementSystem.Common.Common.Interfaces.BLL;
using EmergencyManagementSystem.Common.Entities.Enums;

namespace EmergencyManagementSystem.Common.Common.Filters
{
    public class EmployeeFilter : FilterBase
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; }
        public Occupation Occupation { get; set; }
    }
}
