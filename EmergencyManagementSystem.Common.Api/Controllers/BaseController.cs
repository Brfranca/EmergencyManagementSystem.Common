using EmergencyManagementSystem.Common.Common.Interfaces.BLL;
using EmergencyManagementSystem.Common.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public Result Find(object id)
        {
            return _baseBLL.Find(id);
        }

        [HttpPost("Update")]
        public Result Update(T model)
        {
            return _baseBLL.Update(model);
        }
    }
}
