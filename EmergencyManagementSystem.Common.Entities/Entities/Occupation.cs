using EmergencyManagementSystem.Common.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyManagementSystem.Common.Entities.Entities
{
    public class Occupation : IEntity<long>
    {
        public long Id { get; set; }
        public string Profession { get; set; }
    }
}
