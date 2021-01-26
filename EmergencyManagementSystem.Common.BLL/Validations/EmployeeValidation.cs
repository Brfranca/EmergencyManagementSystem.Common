using EmergencyManagementSystem.Common.DAL.DAL;
using EmergencyManagementSystem.Common.Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmergencyManagementSystem.Common.BLL.Validations
{
    public class EmployeeValidation : BaseValidation<Employee>
    {
        private readonly EmployeeDAL _employeeDAL;

        public EmployeeValidation(EmployeeDAL employeeDAL)
        {
            _employeeDAL = employeeDAL;

            RuleFor(e => e.Address)
                .NotNull()
                .WithMessage("Favor inserir o endereço.");

            RuleFor(e => e.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("O nome deve ser informado.")
                .Length(3, 100)
                .WithMessage("O nome deve ter entre 3 e 100 letras.")
                .Must(ContainsFullName)
                .WithMessage("Insira o nome completo.")
                .Must(IsValidName)
                .WithMessage("Nome não deve conter números e caracteres especiais.");

            RuleFor(e => e.CPF)
                .NotNull()
                .NotEmpty()
                .WithMessage("O CPF deve ser informado.")
                .Length(11)
                .WithMessage("O CPF deve conter 11 caracteres.")
                .Must(IsValidCPF)
                .WithMessage("CPF inválido.")
                .Must(ExistCPF)
                .WithMessage("CPF já cadastrado em nossa base de dados.");

            RuleFor(e => e.BirthDate)
                .NotNull()
                .NotEmpty()
                .WithMessage("A data de nascimento deve ser informada.")
                .Must(IsValidAge)
                .WithMessage("O funcionários deve ter no mínimo 16 anos.");
            //talvez validar se é uma data

            RuleFor(e => e.RG)
                .NotNull()
                .NotEmpty()
                .WithMessage("O RG deve ser informado.")
                .Must(IsValidRG)
                .WithMessage("O RG deve conter apenas números.")
                .Must(ExistRG)
                .WithMessage("RG já cadastrado em nossa base de dados.");

            RuleFor(e => e.Telephone)
                .NotNull()
                .NotEmpty()
                .WithMessage("O Telefone deve ser informado.")
                .Must(IsValidPhone)
                .WithMessage("Telefone inválido");

            RuleFor(e => e.Occupation)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor inserir a profissão do funcionário.");

            RuleFor(e => e.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("O e-mail deve ser informado.")
                .Must(IsValidEmail)
                .WithMessage("E-mail inválido.");

            RuleFor(e => e.ProfessionalRegistration)
                .MaximumLength(50)
                .WithMessage("O registro profissional deve conter o máximo de 20 digitos.");

            RuleFor(e => e.Company)
                .NotNull()
                .WithMessage("Favor informar a coorporação.");
        }

        private bool ContainsFullName(string fullName)
        {
            var names = fullName.Split(' ').Where(d => !string.IsNullOrWhiteSpace(d)).ToList();
            if (names.Count <= 1)
            {
                return false;
            }
            return true;
        }

        private bool IsValidCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }

        private bool ExistCPF(string cpf)
        {
            return _employeeDAL.ExistCPF(cpf);
        }

        private bool ExistRG(string rg)
        {
            return _employeeDAL.ExistRG(rg);
        }

        private bool IsValidAge(DateTime birth)
        {
            DateTime birth_16 = birth.AddYears(16);
            DateTime today = DateTime.Now;
            if (birth_16.Date >= today.Date)
                return true;
            return false;
        }

        private bool IsValidName(string Name)
        {
            return Regex.IsMatch(Name, @"^[\p{L} \.\-]+$");
        }

        private bool IsValidRG(string rg)
        {
            return rg.All(char.IsNumber);
        }

        private bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^\(?(?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$");
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
        }
    }
}
