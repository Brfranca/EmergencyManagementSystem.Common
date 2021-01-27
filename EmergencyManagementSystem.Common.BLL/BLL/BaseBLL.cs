using EmergencyManagementSystem.Common.Common.Interfaces.BLL;
using EmergencyManagementSystem.Common.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyManagementSystem.Common.BLL.BLL
{
    public abstract class BaseBLL<T> : IBaseBLL<T> where T : class
    {
        public abstract Result Register(T model);
        public abstract Result Update(T model);
        public abstract Result Delete(T model);
        public abstract Result<T> Find(params object[] Id);
    }
}
