using EmergencyManagementSystem.Common.Entities.Entities;
using EmergencyManagementSystem.Common.Entities.Enums;
using System;

namespace EmergencyManagementSystem.Common.Common.Models
{
    public class EmployeeModel
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime BirthDate { get; set; }
        public Company Company { get; set; }
        public string ProfessionalRegistration { get; set; }
        public virtual Address Address { get; set; }
        public long AddressId { get; set; }
        public virtual Occupation Occupation { get; set; }
        public long OccupationId { get; set; }

    }
}
