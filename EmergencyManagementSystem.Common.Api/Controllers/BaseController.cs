using EmergencyManagementSystem.Common.Common.Interfaces.BLL;
using EmergencyManagementSystem.Common.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyManagementSystem.Common.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : class
    {
        private readonly IBaseBLL<T> _baseBLL;
        public BaseController(IBaseBLL<T> baseBLL)
        {
            _baseBLL = baseBLL;
        }

        [HttpPost("Register")]
        public Result Register(T model)
        {
            return _baseBLL.Register(model);
        }

        [HttpPost("Delete")]
        public Result Delete(T model)
        {
            return _baseBLL.Delete(model);
        }

        [HttpGet("Find")]
        public Result<T> Find(IFilter filter)
        {
            return _baseBLL.Find(filter);
        }

        [HttpPost("Update")]
        public Result Update(T model)
        {
            return _baseBLL.Update(model);
        }
    }
}
