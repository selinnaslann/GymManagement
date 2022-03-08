using FluentValidation;
using GymManagement.Application.ViewModels.TrainerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Validations
{
    public class TrainerValidator : AbstractValidator<TrainerCommandViewModel>
    {
        public TrainerValidator()
        {
            RuleFor(e => e.EmployeeDetail).NotNull();
            RuleFor(e => e.WorkerContract).NotNull();
        }
    }
}
