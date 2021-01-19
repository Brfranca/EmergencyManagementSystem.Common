﻿using EmergencyManagementSystem.Common.Common.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyManagementSystem.Common.BLL.Validations
{
    public class BaseValidation<T> : AbstractValidator<T> where T : class
    {
        public new Result<T> Validate(T model)
        {
            var result = base.Validate(model);
            if (!result.IsValid)
                return Result<T>.BuildError(result.Errors.Select(d => d.ErrorMessage).ToList());

            return Result<T>.BuildSucess(model);
        }
    }
}
