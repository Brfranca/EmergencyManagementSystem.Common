using EmergencyManagementSystem.Common.Common.Interfaces.BLL;
using EmergencyManagementSystem.Common.Entities.Enums;
using System;
using System.Collections.Generic;

namespace EmergencyManagementSystem.Common.Common.Filters
{
    public class EmployeeFilter : FilterBase
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; }
        public Occupation Occupation { get; set; }
        public Guid Guid { get; set; }
        public bool IsMember { get; set; }
        public List<Guid> EmployeeGuidWorking { get; set; }
    }
}
