using EmergencyManagementSystem.Common.Entities.Entities;
using FluentValidation;
using System.Text.RegularExpressions;

namespace EmergencyManagementSystem.Common.BLL.Validations
{
    public class AddressValidation : BaseValidation<Address>
    {
        public AddressValidation()
        {
            RuleFor(e => e.CEP)
                .Cascade(CascadeMode.Stop)
                .Length(8)
                .WithMessage("O CEP deve conter 8 números.");

            RuleFor(e => e.City)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar a cidade.")
                .Length(3, 100)
                .WithMessage("A cidade deve ter entre 3 e 100 letras.")
                .Must(IsValidName)
                .WithMessage("O nome da cidade não deve conter números e caracteres especiais.");

            RuleFor(e => e.District)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(60)
                .WithMessage("O bairro deve ter entre 3 e 60 letras.")
                .Must(IsValidName)
                .WithMessage("O nome do bairro não deve conter números e caracteres especiais.");

            RuleFor(e => e.Complement)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(60)
                .WithMessage("O complemento deve ter no máximo 60 caracteres.");

            RuleFor(e => e.Number)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(10)
                .WithMessage("O número deve ter no máximo 10 caracteres.");

            RuleFor(e => e.Reference)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(60)
                .WithMessage("A referência deve ter no máximo 60 caracteres.");

            RuleFor(e => e.Street)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o nome da rua.")
                .Length(3, 60)
                .WithMessage("A rua deve conter entre 3 e 60 letras.");
        }

        private bool IsValidName(string name)
        {
            if (name == null)
                return true;
            return Regex.IsMatch(name, @"^[\p{L} \.\-]+$");
        }
    }
}
