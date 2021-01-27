using EmergencyManagementSystem.Common.Entities.Enums;
using EmergencyManagementSystem.Common.Entities.Interfaces;
using System;

namespace EmergencyManagementSystem.Common.Entities.Entities
{
    public class Employee : IEntity<long>
    {
        public long Id { get; set; }
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
        public short OccupationId { get; set; }
    }
}
