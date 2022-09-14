using FluentValidation;
using Imi.Project.Mobile.Core.Modals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Domain.Validators
{
    public class RecruiterValidator : AbstractValidator<Recruiter>
    {
        public RecruiterValidator()
        {
            RuleFor(Recruiter => Recruiter.FirstName)
                 .NotEmpty()
                 .WithMessage("This cannot be empty")
                 .Length(3, 20)
                 .WithMessage("Length must be between 3 and 30");
            RuleFor(Recruiter => Recruiter.LastName)
                 .NotEmpty()
                 .WithMessage("This cannot be empty")
                 .Length(3, 20)
                 .WithMessage("Length must be between 3 and 20");
            RuleFor(Recruiter => Recruiter.Email)
                 .NotEmpty()
                 .WithMessage("This cannot be empty")
                 .Length(10, 30)
                 .WithMessage("Length must be between 10 and 30");
            RuleFor(Recruiter => Recruiter.Phone)
                 .NotEmpty()
                 .WithMessage("This cannot be empty")
                 .Length(8, 15)
                 .WithMessage("Length must be between 8 and 15");
            RuleFor(Recruiter => Recruiter.Password)
                 .NotEmpty()
                 .WithMessage("This cannot be empty")
                 .Length(10, 20)
                 .WithMessage("Length must be between 10 and 20");
            RuleFor(Recruiter => Recruiter.ImageUrl)
                 .NotEmpty()
                 .WithMessage("This cannot be empty");
            RuleFor(Recruiter => Recruiter.DateOfBirth)
                .NotNull()
                .WithMessage("This cannot be empty");
        }
    }
}
