using FluentValidation;
using Imi.Project.Mobile.Core.Modals.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Domain.Validators
{
    public class BuildingValidator : AbstractValidator<BaseBuilding>
    {
        public BuildingValidator()
        {
            RuleFor(Building => Building.Name)
                 .NotEmpty()
                 .WithMessage("This cannot be empty")
                 .Length(3, 20)
                 .WithMessage("Length must be between 3 and 30");
            RuleFor(Building => Building.PostCode)
                .NotEmpty()
                .WithMessage("This cannot be empty")
                .InclusiveBetween(1000, 9999)
                .WithMessage("Postcode is between 1000 and 9999");
            RuleFor(Building => Building.Street)
                .NotEmpty()
                .WithMessage("This cannot be empty")
                .Length(5, 35)
                .WithMessage("Length must be between 5 and 35");
            RuleFor(Building => Building.WebsiteUrl)
                .NotEmpty()
                .WithMessage("This cannot be empty")
                .Length(5, 35)
                .WithMessage("Length must be between 5 and 35");
        }
    }
}
