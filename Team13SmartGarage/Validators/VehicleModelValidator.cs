using FluentValidation;
using Team13SmartGarage.Services.Models.VehicleModelDTOs;
using Team13SmartGarage.Services.Models.VehiclesDTOs;

namespace Team13SmartGarage.Web.Validators
{
    public class VehicleModelValidator : AbstractValidator<VehicleModelDTO>
    {
        public VehicleModelValidator()
        {
            RuleFor(vm => vm.Name)
                .NotEmpty()
                .Length(1, 30);
        }
    }
}