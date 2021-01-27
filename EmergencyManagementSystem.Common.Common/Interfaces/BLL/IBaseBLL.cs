using EmergencyManagementSystem.Common.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyManagementSystem.Common.Common.Interfaces.BLL
{
    public interface IBaseBLL<T> where T : class
    {
          Result Register(T model);
          Result Update(T model);
          Result Delete(T model);
          Result<T> Find(params object[] Id);
    }
}
