using EmergencyManagementSystem.Common.Common.Filters;
using EmergencyManagementSystem.Common.Common.Interfaces.BLL;
using EmergencyManagementSystem.Common.Common.Models;
using EmergencyManagementSystem.Common.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyManagementSystem.Common.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequesterController : BaseController<RequesterModel, Requester, RequesterFilter>
    {
        public RequesterController(IRequesterBLL requesterBLL) : base(requesterBLL)
        {
        }
    }
}
