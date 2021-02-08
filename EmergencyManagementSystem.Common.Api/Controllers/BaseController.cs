using EmergencyManagementSystem.Common.Common.Interfaces.BLL;
using EmergencyManagementSystem.Common.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using X.PagedList;

namespace EmergencyManagementSystem.Common.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TModel, TEntity, TFilter> : ControllerBase
        where TModel : class
        where TEntity : class
        where TFilter : class
    {
        private readonly IBaseBLL<TModel, TEntity> _baseBLL;
        public BaseController(IBaseBLL<TModel, TEntity> baseBLL)
        {
            _baseBLL = baseBLL;
        }

        [HttpPost("Register")]
        public Result Register(TModel model)
        {
            return _baseBLL.Register(model);
        }

        [HttpPost("Delete")]
        public Result Delete(TModel model)
        {
            return _baseBLL.Delete(model);
        }

        [HttpPost("Update")]
        public Result Update(TModel model)
        {
            return _baseBLL.Update(model);
        }

        [HttpPost("FindPaginated")]
        public PaginationModel<TModel> FindPaginated(TFilter filter)
        {
            var result = _baseBLL.FindPaginated((IFilter)filter);
            return new PaginationModel<TModel>(result.ToListAsync().Result, new DataPagination(result.GetMetaData()));
        }
    }
}
