using FluentValidation;
using Team13SmartGarage.Services.Models.VehiclesDTOs;

namespace Team13SmartGarage.Validators
{
    public class VehicleValidator : AbstractValidator<VehicleDTO>
    {
        public VehicleValidator()
        {
            RuleFor(v => v.Vin).NotNull().Length(17);
            RuleFor(v => v.RegPlate)
                .NotNull()
                .Matches(@"^[ABCEKMHOPTYX]{1,2}\s?[0-9]{4}\s?[ABCEKMHOPTYX]{1,2}$")
                .WithMessage("The specified registration number is not valid.");
            
        }
    }
}