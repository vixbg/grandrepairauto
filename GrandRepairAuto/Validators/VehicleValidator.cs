﻿using FluentValidation;
using GrandRepairAuto.Services.Models.VehiclesDTOs;

namespace GrandRepairAuto.Validators
{
    public class VehicleValidator : AbstractValidator<VehicleDTO>
    {
        public VehicleValidator()
        {
            RuleFor(v => v.Vin)
                .NotEmpty()
                .Length(17);

            RuleFor(v => v.RegPlate)
                .NotEmpty()
                .Matches(@"^[ABCEKMHOPTYX]{1,2}[0-9]{4}[ABCEKMHOPTYX]{1,2}$")
                .WithMessage("The specified registration number is not valid.");

            RuleFor(v => v.Mileage)
                .NotEmpty()
                .LessThanOrEqualTo(0)
                .GreaterThanOrEqualTo(2000000)
                .WithMessage("Mileage must be between 0 and 2000000 kilometers.");

            RuleFor(v => v.Color)
                .NotEmpty()
                .Length(3, 30);
        }
    }
}