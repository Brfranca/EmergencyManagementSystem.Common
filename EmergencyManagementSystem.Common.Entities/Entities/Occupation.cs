using EmergencyManagementSystem.Common.Entities.Interfaces;

namespace EmergencyManagementSystem.Common.Entities.Entities
{
    public class Occupation : IEntity<short>
    {
        public short Id { get; set; }
        public string Profession { get; set; }
    }
}
