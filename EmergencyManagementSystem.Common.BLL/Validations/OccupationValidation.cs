using EmergencyManagementSystem.Common.Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyManagementSystem.Common.BLL.Validations
{
    public class OccupationValidation : BaseValidation<Occupation>
    {
        public OccupationValidation()
        {
            RuleFor(o => o.Profession)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o cargo profissional.")
                .MaximumLength(50)
                .WithMessage("O cargo deve ter no máximo 50 letras.");
        }
    }
}
