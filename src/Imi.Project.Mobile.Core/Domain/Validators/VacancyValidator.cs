using FluentValidation;
using Imi.Project.Mobile.Core.Modals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Domain.Validators
{
    public class VacancyValidator : AbstractValidator<Vacancy>
    {
        public VacancyValidator()
        {
            RuleFor(Vacancy => Vacancy.Name)
                .NotEmpty()
                .WithMessage("This cannot be empty");
        }
    }
}
