using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyManagementSystem.Common.Entities.Interface
{
    public interface IEntity<T> where T : struct
    {
        T Id { get; set; }
    }
}
