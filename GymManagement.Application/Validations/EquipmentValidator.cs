using FluentValidation;
using GymManagement.Application.ViewModels.EquipmentViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Validations
{
    public class EquipmentValidator : AbstractValidator<EquipmentCommandViewModel>
    {
        public EquipmentValidator()
        {
            RuleFor(e => e.Name).NotEmpty().MinimumLength(3);
            RuleFor(e => e.Duration).GreaterThan(Convert.ToByte(1));
        }
    }
}
