using AutoMapper;
using EmergencyManagementSystem.Common.Common.Models;
using EmergencyManagementSystem.Common.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyManagementSystem.Common.DAL.DAL
{
    public class UserDAL : BaseDAL<User>
    {
        public UserDAL(Context context) : base(context)
        {
        }
    }
}
