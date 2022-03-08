using FluentValidation;
using GymManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Validations
{
    public class WorkerContractValidator : AbstractValidator<WorkerContract>
    {
        public WorkerContractValidator()
        {
            RuleFor(w => w.Duration).NotEmpty();
            RuleFor(w => w.UpdateDate).NotEmpty();
            RuleFor(w => w.EndDate).NotEmpty();
        }
    }
}
