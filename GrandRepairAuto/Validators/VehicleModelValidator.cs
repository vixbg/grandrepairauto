using FluentValidation;
using GrandRepairAuto.Services.Models.VehicleModelDTOs;
using GrandRepairAuto.Services.Models.VehiclesDTOs;

namespace GrandRepairAuto.Web.Validators
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