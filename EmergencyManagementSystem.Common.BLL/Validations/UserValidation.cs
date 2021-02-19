using EmergencyManagementSystem.Common.Common.Interfaces;
using EmergencyManagementSystem.Common.Entities.Entities;
using FluentValidation;

namespace EmergencyManagementSystem.Common.BLL.Validations
{
    public class UserValidation : BaseValidation<User>
    {
        private readonly IEmployeeDAL _employeeDAL;

        public UserValidation(IEmployeeDAL employeeDAL)
        {
            _employeeDAL = employeeDAL;

            RuleFor(d => d.EmployeeId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("Favor selecionar um funcionário")
                .NotEmpty()
                .WithMessage("Favor selecionar um funcionário")
                .Must(ExistEmployee)
                .WithMessage("Funcionário não encontrado");

            RuleFor(d => d.Login)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Usuário deve ser informado")
                .NotNull()
                .WithMessage("Usuário deve ser informado")
                .Length(8, 20)
                .WithMessage("Usuário deve conter entre 8 a 20 caracteres")
                .Must(LoginIsValid)
                .WithMessage("Usuário inválido");

            RuleFor(d => d.Password)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("Senha deve ser informada")
                .NotEmpty()
                .WithMessage("Senha deve ser informada")
                .Length(8, 20)
                .WithMessage("Senha deve conter entre 8 a 20 caracteres");
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
