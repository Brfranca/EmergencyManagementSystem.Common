﻿using AutoMapper;
using EmergencyManagementSystem.Common.BLL.Validations;
using EmergencyManagementSystem.Common.Common.Models;
using EmergencyManagementSystem.Common.DAL.DAL;
using EmergencyManagementSystem.Common.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyManagementSystem.Common.BLL.BLL
{
    public class EmployeeBLL
    {
        private readonly IMapper _mapper;
        private readonly EmployeeDAL _employeeDAL;
        private readonly EmployeeValidation _employeeValidation;
        public EmployeeBLL(EmployeeDAL employeeDAL, EmployeeValidation employeeValidation, IMapper mapper)
        {
            _employeeDAL = employeeDAL;
            _employeeValidation = employeeValidation;
            _mapper = mapper;
        }

        public Result Register(EmployeeModel employeeModel)
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
                return Result.BuildError("Erro no momento de registar o usuário.", error);
            }
        }
    }
}