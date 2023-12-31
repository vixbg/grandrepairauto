﻿using FluentValidation;
using GrandRepairAuto.Services.Models.ServiceDTOs;

namespace GrandRepairAuto.Web.Validators
{
    public class ServiceValidator : AbstractValidator<ServiceDTO>
    {
        public ServiceValidator()
        {
            RuleFor(s => s.VehicleType).IsInEnum();

            RuleFor(s => s.Name)
                .NotEmpty()
                .Length(5, 100);

            RuleFor(s => s.PricePerHour)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(s => s.WorkHours)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
