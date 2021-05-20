using FluentValidation;
using Team13SmartGarage.Services.Models.VehiclesDTOs;

namespace Team13SmartGarage.Validators
{
    public class VehicleCreateValidator : AbstractValidator<VehicleCreateDTO>
    {
        public VehicleCreateValidator()
        {
            RuleFor(v => v.Vin).NotNull().Length(17);
            RuleFor(v => v.RegPlate).NotNull().Must(r => r.StartsWith("CA")).WithMessage("The specified registration number is not valid.");
            
        }
    }
}