using AutoMapper;
using EmergencyManagementSystem.Common.BLL.Validations;
using EmergencyManagementSystem.Common.Common.Filters;
using EmergencyManagementSystem.Common.Common.Interfaces;
using EmergencyManagementSystem.Common.Common.Interfaces.BLL;
using EmergencyManagementSystem.Common.Common.Models;
using EmergencyManagementSystem.Common.Entities.Entities;
using System;
using System.Linq;
using X.PagedList;

namespace EmergencyManagementSystem.Common.BLL.BLL
{
    public class EmployeeBLL : BaseBLL<EmployeeModel, Employee>, IEmployeeBLL
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeDAL _employeeDAL;
        private readonly EmployeeValidation _employeeValidation;
        private readonly IAddressBLL _addressBLL;
        public EmployeeBLL(IEmployeeDAL employeeDAL, EmployeeValidation employeeValidation,
            IMapper mapper, IAddressBLL addressBLL) : base(employeeDAL)
        {
            _employeeDAL = employeeDAL;
            _employeeValidation = employeeValidation;
            _mapper = mapper;
            _addressBLL = addressBLL;
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
                return Result<EmployeeModel>.BuildSuccess(employeeModel);
            }
            catch (Exception error)
            {
                return Result<EmployeeModel>.BuildError("Erro ao localizar o funcionário.", error);
            }
        }

        public override IQueryable<EmployeeModel> ApplyFilterPagination(IQueryable<Employee> query, IFilter filter)
        {
            var employeeFilter = (EmployeeFilter)filter;

            if (!string.IsNullOrWhiteSpace(employeeFilter.Name))
                query = query.Where(d => d.Name == employeeFilter.Name);
            if (!string.IsNullOrWhiteSpace(employeeFilter.CPF))
                query = query.Where(d => d.CPF == employeeFilter.CPF);

            return query.Select(d => _mapper.Map<EmployeeModel>(d));
        }

        public override Result<Employee> Register(EmployeeModel employeeModel)
        {
            try
            {
                var employee = _mapper.Map<Employee>(employeeModel);
                employee.Guid = Guid.NewGuid();

                var resultAdress = _addressBLL.Register(employeeModel.AddressModel);
                if (!resultAdress.Success)
                    return Result<Employee>.BuildError(resultAdress.Messages);

                employee.Address = resultAdress.Model;

                var result = _employeeValidation.Validate(employee);
                if (!result.Success)
                    return result;

                _employeeDAL.Insert(employee);

                var resultSave = _employeeDAL.Save();
                if (!resultSave.Success)
                    return Result<Employee>.BuildError(resultSave.Messages);

                return Result<Employee>.BuildSuccess(employee);
            }
            catch (Exception error)
            {
                return Result<Employee>.BuildError("Erro no momento de registar o funcionário.", error);
            }
        }

        public override Result<Employee> Update(EmployeeModel model)
        {
            try
            {
                var employee = _mapper.Map<Employee>(model);

                var resultAdress = _addressBLL.Update(model.AddressModel);
                if (!resultAdress.Success)
                    return Result<Employee>.BuildError(resultAdress.Messages);

                employee.Address = resultAdress.Model;

                var result = _employeeValidation.Validate(employee);
                if (!result.Success)
                    return result;

                _employeeDAL.Update(employee);

                var resultSave = _employeeDAL.Save();
                if (!resultSave.Success)
                    return Result<Employee>.BuildError(resultSave.Messages);

                return Result<Employee>.BuildSuccess(employee);

                //Employee employee = _mapper.Map<Employee>(model);

                //var result = _employeeValidation.Validate(employee);
                //if (!result.Success)
                //    return result;

                //_employeeDAL.Update(employee);
                //return _employeeDAL.Save();
            }
            catch (Exception error)
            {
                return Result<Employee>.BuildError("Erro ao alterar o registro do funcionário.", error);
            }
        }
    }
}
