using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team13SmartGarage.Services.Models.ServiceDTOs;

namespace Team13SmartGarage.Web.Validators
{
    public class ServiceValidator :  AbstractValidator<ServiceDTO>
    {
        public ServiceValidator()
        {
            RuleFor(s => s.VehicleType).IsInEnum();
            RuleFor(s => s.Name).Length(5, 100);
            RuleFor(s => s.FixedPrice).GreaterThan(0);
            RuleFor(s => s.PricePerHour).GreaterThan(0);
            RuleFor(s => s.WorkHours).GreaterThan(0);
        }
    }
}
