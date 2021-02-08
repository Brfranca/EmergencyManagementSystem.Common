using EmergencyManagementSystem.Common.Common.Interfaces.BLL;
using EmergencyManagementSystem.Common.Common.Models;
using System;
using System.Linq;
using X.PagedList;

namespace EmergencyManagementSystem.Common.Common.Interfaces
{
    public interface IBaseDAL<TEntity>
    {
        Result Insert(TEntity entity);
        Result Update(TEntity entity);
        Result Delete(TEntity entity);
        Result Save();
        IPagedList<TModel> FindPaginated<TModel>(IFilter filter,
            Func<IQueryable<TEntity>, IFilter, IQueryable<TModel>> applyFilter);
    }
}
