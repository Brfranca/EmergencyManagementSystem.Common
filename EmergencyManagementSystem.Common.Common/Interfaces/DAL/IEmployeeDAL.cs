using EmergencyManagementSystem.Common.Common.Filters;
using EmergencyManagementSystem.Common.Entities.Entities;

namespace EmergencyManagementSystem.Common.Common.Interfaces
{
    public interface IEmployeeDAL : IBaseDAL<Employee>
    {
        Employee Find(EmployeeFilter filter);
        bool ExistEmployee(long employeeId);
        bool ExistCPF(string cpf);
        bool ExistRG(string rg);
    }
}
