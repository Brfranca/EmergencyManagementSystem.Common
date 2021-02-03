using EmergencyManagementSystem.Common.Entities.Entities;
using System;

namespace EmergencyManagementSystem.Common.Common.Models
{
    public class RequesterModel
    {
        public long Id { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
