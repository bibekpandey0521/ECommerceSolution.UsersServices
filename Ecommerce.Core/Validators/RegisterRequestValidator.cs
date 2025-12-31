using Ecommerce.Core.Dto;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            // Email
            RuleFor(temp => temp.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email address format");
            // Password
            RuleFor(temp => temp.Password)
                .NotEmpty().WithMessage("Password is required");
            // Validate the Person property
            RuleFor(request => request.PersonName)
                .NotEmpty().WithMessage("PersonName can't be blank")
                .Length(1, 50).WithMessage("Person Name should be 1 to 50 characters long");
            // Validate the Gender property
            RuleFor(request => request.Gender)
                .IsInEnum().WithMessage("Invalid gender option");
        }
    }
}
