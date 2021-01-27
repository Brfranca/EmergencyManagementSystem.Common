using EmergencyManagementSystem.Common.Common.Interfaces;
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
    public class OccupationController : BaseController<OccupationModel>
    {
        public OccupationController(IOccupationBLL occupationBLL) : base(occupationBLL)
        {

        }
    }
}
