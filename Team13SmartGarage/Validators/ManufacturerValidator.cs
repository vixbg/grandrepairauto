using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team13SmartGarage.Services.Models.ManufacturerDTOs;

namespace Team13SmartGarage.Web.Validators
{
    public class ManufacturerValidator : AbstractValidator<ManufacturerDTO>
    {
        public ManufacturerValidator()
        {
            RuleFor(m => m.Name).NotEmpty().Length(1, 30);
        }
    }
}
