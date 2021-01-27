using AutoMapper;
using EmergencyManagementSystem.Common.BLL.Validations;
using EmergencyManagementSystem.Common.Common.Filters;
using EmergencyManagementSystem.Common.Common.Interfaces;
using EmergencyManagementSystem.Common.Common.Interfaces.BLL;
using EmergencyManagementSystem.Common.Common.Models;
using EmergencyManagementSystem.Common.Entities.Entities;
using System;

namespace EmergencyManagementSystem.Common.BLL.BLL
{
    public class EmployeeBLL : BaseBLL<EmployeeModel>, IEmployeeBLL
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeDAL _employeeDAL;
        private readonly EmployeeValidation _employeeValidation;
        public EmployeeBLL(IEmployeeDAL employeeDAL, EmployeeValidation employeeValidation, IMapper mapper)
        {
            _employeeDAL = employeeDAL;
            _employeeValidation = employeeValidation;
            _mapper = mapper;
        }

        public override Result Delete(EmployeeModel model)
        {
            try
            {
                Employee employee = _mapper.Map<Employee>(model);
                _employeeDAL.Delete(employee);
                return _employeeDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao deletar o registro do funcionário.", error);
            }
        }

        public override Result<EmployeeModel> Find(IFilter filter)
        {
            try
            {
                Employee employee = _employeeDAL.Find((EmployeeFilter)filter);
                EmployeeModel employeeModel = _mapper.Map<EmployeeModel>(employee);
                return Result<EmployeeModel>.BuildSucess(employeeModel);
            }
            catch (Exception error)
            {
                return Result<EmployeeModel>.BuildError("Erro ao localizar o funcionário.", error);
            }
        }

        public override Result Register(EmployeeModel employeeModel)
        {
            try
            {
                var employee = _mapper.Map<Employee>(employeeModel);

                var result = _employeeValidation.Validate(employee);
                if (!result.Success)
                    return result;

                _employeeDAL.Insert(employee);
                return _employeeDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro no momento de registar o funcionário.", error);
            }
        }

        public override Result Update(EmployeeModel model)
        {
            try
            {
                Employee employee = _mapper.Map<Employee>(model);
                 _employeeDAL.Update(employee);
                return _employeeDAL.Save();
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao alterar o registro do funcionário.", error);
            }
        }
    }
}
