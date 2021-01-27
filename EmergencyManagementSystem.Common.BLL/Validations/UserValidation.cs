using EmergencyManagementSystem.Common.Common.Interfaces;
using EmergencyManagementSystem.Common.Common.Models;
using EmergencyManagementSystem.Common.DAL.DAL;
using EmergencyManagementSystem.Common.Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyManagementSystem.Common.BLL.Validations
{
    public class UserValidation : BaseValidation<User>
    {
        private readonly IEmployeeDAL _employeeDAL;

        public UserValidation(IEmployeeDAL employeeDAL)
        {
            _employeeDAL = employeeDAL;

            RuleFor(d => d.EmployeeId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor selecionar um funcionário")
                .Must(ExistEmployee)
                .WithMessage("Funcionário não encontrado");

            RuleFor(d => d.Login)
                .NotEmpty()
                .NotNull()
                .WithMessage("Usuário deve ser informado")
                .Length(15, 40)
                .WithMessage("Usuário deve conter entre 15 a 100 caracteres")
                .Must(LoginIsValid)
                .WithMessage("Usuário inválido");

            RuleFor(d => d.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Senha deve ser informada")
                .Length(8, 30)
                .WithMessage("Senha deve conter entre 8 a 30 caracteres");
        }

        private bool LoginIsValid(string arg)
        {
            //Lógica para validar o login
            return true;
        }

        private bool ExistEmployee(long employeeId)
        {
            return _employeeDAL.ExistEmployee(employeeId);
        }
    }
}
