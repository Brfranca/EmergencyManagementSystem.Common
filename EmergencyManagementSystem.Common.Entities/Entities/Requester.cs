using EmergencyManagementSystem.Common.Entities.Interfaces;

namespace EmergencyManagementSystem.Common.Entities.Entities
{
    public class Requester : IEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public int AddressId { get; set; }
    }
}
