using EmergencyManagementSystem.Common.Common.Filters;
using EmergencyManagementSystem.Common.Common.Interfaces;
using EmergencyManagementSystem.Common.Common.Models;
using EmergencyManagementSystem.Common.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyManagementSystem.Common.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<UserModel, User, UserFilter>
    {
        public UserController(IUserBLL userBLL) : base(userBLL)
        {
        }
    }
}
