using EmergencyManagementSystem.Common.Common.Filters;
using EmergencyManagementSystem.Common.Common.Interfaces;
using EmergencyManagementSystem.Common.Entities.Entities;
using System.Linq;

namespace EmergencyManagementSystem.Common.DAL.DAL
{
    public class EmployeeDAL : BaseDAL<Employee>, IEmployeeDAL
    {
        public EmployeeDAL(Context context) : base(context)
        {
        }

        public Employee Find(EmployeeFilter filter)
        {
            return Set.FirstOrDefault(d => d.CPF == filter.CPF);
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
