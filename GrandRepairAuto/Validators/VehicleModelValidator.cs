using FluentValidation;
using GrandRepairAuto.Services.Models.VehicleModelDTOs;

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