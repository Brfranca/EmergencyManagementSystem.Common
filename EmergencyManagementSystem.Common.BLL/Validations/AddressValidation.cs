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
                .MaximumLength(8)
                .WithMessage("Favor inserir o CEP");

            RuleFor(e => e.City)
                .NotNull()
                .NotEmpty()
                .WithMessage("Cidade deve ser informada.")
                .Length(4, 60)
                .WithMessage("A cidade deve ter entre 3 e 100 letras.")
                .Must(IsValidName)
                .WithMessage("Nome da cidade não deve conter números e caracteres especiais.");

            RuleFor(e => e.District)
                .NotNull()
                .WithMessage("O bairro deve ser informado.")
                .Length(3, 60)
                .WithMessage("O bairro deve ter entre 3 e 60 letras.")
                .Must(IsValidName)
                .WithMessage("Nome do bairro não deve conter números e caracteres especiais.");


        }

        private bool IsValidName(string Name)
        {
            return Regex.IsMatch(Name, @"^[\p{L} \.\-]+$");
        }
    }
}
