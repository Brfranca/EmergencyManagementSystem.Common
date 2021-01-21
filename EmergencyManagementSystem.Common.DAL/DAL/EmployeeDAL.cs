using EmergencyManagementSystem.Common.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyManagementSystem.Common.DAL.DAL
{
    public class EmployeeDAL : BaseDAL<Employee>
    {
        public EmployeeDAL(Context context) : base(context)
        {
        }

        public bool ExistEmployee(long employeeId)
        {
            return Set.Any(d => d.Id == employeeId);
        }

        public bool ExistCPF(string cpf)
        {
            return Set.Any(d => d.CPF == cpf);
        }

        public bool ExistRG(string rg)
        {
            return Set.Any(d => d.RG == rg);
        }
    }
}
