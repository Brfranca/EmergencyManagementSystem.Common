using EmergencyManagementSystem.Common.DAL.DAL;
using EmergencyManagementSystem.Common.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using System.Text.RegularExpressions;

namespace EmergencyManagementSystem.Common.BLL.Validations
{
    public class AddressValidation : BaseValidation<Address>
    {
        private readonly AddressDAL _addressDAL;

        public AddressValidation(AddressDAL addressDAL)
        {
            _addressDAL = addressDAL;

            RuleFor(e => e.CEP)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor inserir o CEP")
                .Length(8)
                .WithMessage("O CEP deve conter 8 caracteres.");

            RuleFor(e => e.City)
                .NotNull()
                .NotEmpty()
                .WithMessage("Cidade deve ser informada.")
                .Length(4, 60)
                .WithMessage("A cidade deve ter entre 3 e 100 letras.")
                .Must(IsValidName)
                .WithMessage("Nome da cidade não deve conter números e caracteres especiais.");

            RuleFor(e => e.District)
                .Length(3, 60)
                .WithMessage("O bairro deve ter entre 3 e 60 letras.")
                .Must(IsValidName)
                .WithMessage("Nome do bairro não deve conter números e caracteres especiais.");

            RuleFor(e => e.Complement)
                .Length(3, 60)
                .WithMessage("O complemento deve ter entre 3 e 60 letras.");

            RuleFor(e => e.Number)
                .Length(3, 10)
                .WithMessage("O número deve ter entre 3 e 10 letras.");

            RuleFor(e => e.Reference)
                .Length(3, 60)
                .WithMessage("A referência deve ter entre 3 e 60 letras");

            RuleFor(e => e.State)
                .NotNull()
                .NotEmpty()
                .WithMessage("O estado deve ser informado.")
                .Length(2)
                .WithMessage("O estado deve conter 2 letras.");

            RuleFor(e => e.Street)
                .NotNull()
                .NotEmpty()
                .WithMessage("A rua deve ser informada.")
                .Length(3, 60)
                .WithMessage("A rua deve conter entre 3 e 60 letras.");

        }

        private bool IsValidName(string Name)
        {
            return Regex.IsMatch(Name, @"^[\p{L} \.\-]+$");
        }
    }
}
