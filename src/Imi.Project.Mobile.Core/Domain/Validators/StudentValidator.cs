using FluentValidation;
using Imi.Project.Mobile.Core.Modals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Domain.Validators
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(Student => Student.FirstName)
                 .NotEmpty()
                 .WithMessage("This cannot be empty")
                 .Length(3, 20)
                 .WithMessage("Length must be between 3 and 30");
            RuleFor(Student => Student.LastName)
                 .NotEmpty()
                 .WithMessage("This cannot be empty")
                 .Length(3, 20)
                 .WithMessage("Length must be between 3 and 20");
            RuleFor(Student => Student.Email)
                 .NotEmpty()
                 .WithMessage("This cannot be empty")
                 .Length(10, 30)
                 .WithMessage("Length must be between 10 and 30");
            RuleFor(Student => Student.Phone)
                 .NotEmpty()
                 .WithMessage("This cannot be empty")
                 .Length(8, 15)
                 .WithMessage("Length must be between 8 and 15");
            RuleFor(Student => Student.Password)
                 .NotEmpty()
                 .WithMessage("This cannot be empty")
                 .Length(10, 20)
                 .WithMessage("Length must be between 10 and 20");
            RuleFor(Student => Student.ImageUrl)
                 .NotEmpty()
                 .WithMessage("This cannot be empty");
            RuleFor(Student => Student.DateOfBirth)
                .NotNull()
                .WithMessage("This cannot be empty");
        }
    }
}
