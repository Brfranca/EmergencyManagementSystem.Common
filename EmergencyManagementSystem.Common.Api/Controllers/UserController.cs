using EmergencyManagementSystem.Common.BLL.BLL;
using EmergencyManagementSystem.Common.Common.Filters;
using EmergencyManagementSystem.Common.Common.Interfaces;
using EmergencyManagementSystem.Common.Common.Interfaces.BLL;
using EmergencyManagementSystem.Common.Common.Models;
using EmergencyManagementSystem.Common.Entities.Entities;
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
    public class UserController : BaseController<UserModel, User, UserFilter>
    {
        private readonly IUserBLL _userBLL;
        public UserController(IUserBLL userBLL) : base(userBLL)
        {
            _userBLL = userBLL;
        }

        [HttpPost("Find")]
        public Result<UserModel> Find(UserFilter filter)
        {
            return _userBLL.Find(filter);
        }
    }
}
