using EmergencyManagementSystem.Common.Common.Models;
using FluentValidation;
using System.Linq;

namespace EmergencyManagementSystem.Common.BLL.Validations
{
    public class BaseValidation<T> : AbstractValidator<T> where T : class
    {
        public new Result<T> Validate(T model)
        {
            var result = base.Validate(model);
            if (!result.IsValid)
                return Result<T>.BuildError(result.Errors.Select(d => d.ErrorMessage).ToList());

            return Result<T>.BuildSuccess(model);
        }
    }
}
