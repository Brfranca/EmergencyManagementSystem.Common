using EmergencyManagementSystem.Common.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyManagementSystem.Common.Common.Interfaces
{
    public interface IBaseDAL<T>
    {
        Result Insert(T entity);
        Result Update(T entity);
        Result Delete(T entity);
        Result Save();
    }
}
