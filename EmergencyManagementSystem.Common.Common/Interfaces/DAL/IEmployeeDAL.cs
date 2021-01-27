using EmergencyManagementSystem.Common.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyManagementSystem.Common.Common.Interfaces
{
    public interface IEmployeeDAL : IBaseDAL<Employee>
    {
        bool ExistEmployee(long employeeId);
        bool ExistCPF(string cpf);
        bool ExistRG(string rg);
    }
}
