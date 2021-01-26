using EmergencyManagementSystem.Common.Entities.Enums;
using EmergencyManagementSystem.Common.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public long OccupationId { get; set; }
    }
}
