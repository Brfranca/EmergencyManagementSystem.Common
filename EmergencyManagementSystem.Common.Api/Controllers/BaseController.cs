using EmergencyManagementSystem.Common.Common.Interfaces.BLL;
using EmergencyManagementSystem.Common.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyManagementSystem.Common.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TModel, TEntity> : ControllerBase
        where TModel : class
        where TEntity : class
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

        [HttpGet("Find")]
        public Result<TModel> Find(IFilter filter)
        {
            return _baseBLL.Find(filter);
        }

        [HttpPost("Update")]
        public Result Update(TModel model)
        {
            return _baseBLL.Update(model);
        }
    }
}
