using EmergencyManagementSystem.Common.Common.Interfaces.DAL;
using FluentValidation;
using EmergencyManagementSystem.Common.Entities.Entities;
using System.Text.RegularExpressions;

namespace EmergencyManagementSystem.Common.BLL.Validations
{
    public class RequesterValidation : BaseValidation<Requester>
    {
        private readonly IRequesterDAL _requesterDAL;
        public RequesterValidation(IRequesterDAL requesterDAL)
        {
            _requesterDAL = requesterDAL;

            RuleFor(e => e.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("Favor informar o nome.")
                .NotEmpty()
                .WithMessage("Favor informar o nome.")
                .Length(3, 100)
                .WithMessage("O nome deve ter entre 3 e 100 letras.")
                .Must(IsValidName)
                .WithMessage("O nome não deve conter números ou caracteres especiais.");

            RuleFor(e => e.Address)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("Favor inserir o endereço.");

            RuleFor(e => e.Telephone)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("Favor informar o telefone.")
                .NotEmpty()
                .WithMessage("Favor informar o telefone.")
                .Must(IsValidPhone)
                .WithMessage("Telefone inválido");
        }

        private bool IsValidName(string Name)
        {
            return Regex.IsMatch(Name, @"^[\p{L} \.\-]+$");
        }

        private bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^\(?(?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$");
        }
    }
}
