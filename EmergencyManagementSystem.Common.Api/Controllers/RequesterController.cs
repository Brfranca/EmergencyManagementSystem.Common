using EmergencyManagementSystem.Common.Common.Interfaces.BLL;
using EmergencyManagementSystem.Common.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyManagementSystem.Common.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequesterController : BaseController<RequesterModel>
    {
        public RequesterController(IRequesterBLL requesterBLL) : base(requesterBLL)
        {
        }
    }
}
