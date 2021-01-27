using EmergencyManagementSystem.Common.Common.Models;

namespace EmergencyManagementSystem.Common.Common.Interfaces.BLL
{
    public interface IBaseBLL<T> where T : class
    {
          Result Register(T model);
          Result Update(T model);
          Result Delete(T model);
          Result<T> Find(IFilter filter);
    }
}
