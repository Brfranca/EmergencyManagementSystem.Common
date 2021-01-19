 using EmergencyManagementSystem.Common.BLL.BLL;
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
    public class UserController : ControllerBase
    {
        private readonly UserBLL _userBLL;
        public UserController(UserBLL userBLL)
        {
            _userBLL = userBLL;
        }

        [HttpPost("Register")]
        public Result Register(UserModel userModel)
        {
            return _userBLL.Register(userModel);
        }


    }
}
