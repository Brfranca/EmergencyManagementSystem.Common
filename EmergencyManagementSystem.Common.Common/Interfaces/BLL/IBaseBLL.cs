using EmergencyManagementSystem.Common.Common.Models;

namespace EmergencyManagementSystem.Common.Common.Interfaces.BLL
{
    public interface IBaseBLL<TModel, TEntity>
        where TModel : class
        where TEntity : class
    {
        Result<TEntity> Register(TModel model);
        Result Update(TModel model);
        Result Delete(TModel model);
        Result<TModel> Find(IFilter filter);
    }
}
