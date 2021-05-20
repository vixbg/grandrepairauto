using FluentValidation;
using Team13SmartGarage.Services.Models.VehiclesDTOs;

namespace Team13SmartGarage.Validators
{
    public class VehicleValidator : AbstractValidator<VehicleDTO>
    {
        public VehicleValidator()
        {
            RuleFor(v => v.Vin).NotNull().Length(17, 17);
            RuleFor(v => v.RegPlate).NotNull().Must(r => r.StartsWith("CA")).WithMessage("The specified registration number is not valid.");
            
        }
    }
}