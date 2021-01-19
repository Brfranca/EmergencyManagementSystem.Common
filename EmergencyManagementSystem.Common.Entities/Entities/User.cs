using EmergencyManagementSystem.Common.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyManagementSystem.Common.Entities.Entities
{
    public class User : IEntity<long>
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public long EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
