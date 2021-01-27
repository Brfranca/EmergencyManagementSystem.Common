using EmergencyManagementSystem.Common.Common.Models;

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
