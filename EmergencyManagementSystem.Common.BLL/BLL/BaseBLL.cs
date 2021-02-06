using EmergencyManagementSystem.Common.Common.Interfaces.BLL;
using EmergencyManagementSystem.Common.Common.Models;

namespace EmergencyManagementSystem.Common.BLL.BLL
{
    public abstract class BaseBLL<TModel, TEntity> : IBaseBLL<TModel, TEntity> 
        where TModel : class
        where TEntity : class
    {
        public abstract Result<TEntity> Register(TModel model);
        public abstract Result Update(TModel model);
        public abstract Result Delete(TModel model);
        public abstract Result<TModel> Find(IFilter filter);
    }
}
