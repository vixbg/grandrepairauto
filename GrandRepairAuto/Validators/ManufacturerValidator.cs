using FluentValidation;
using GrandRepairAuto.Services.Models.ManufacturerDTOs;

namespace GrandRepairAuto.Web.Validators
{
    public class ManufacturerValidator : AbstractValidator<ManufacturerDTO>
    {
        public ManufacturerValidator()
        {
            RuleFor(m => m.Name).NotEmpty().Length(1, 30);
        }
    }
}
