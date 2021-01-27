using EmergencyManagementSystem.Common.Common.Interfaces.BLL;
using EmergencyManagementSystem.Common.Common.Models;

namespace EmergencyManagementSystem.Common.BLL.BLL
{
    public abstract class BaseBLL<T> : IBaseBLL<T> where T : class
    {
        public abstract Result Register(T model);
        public abstract Result Update(T model);
        public abstract Result Delete(T model);
        public abstract Result<T> Find(IFilter filter);
    }
}
