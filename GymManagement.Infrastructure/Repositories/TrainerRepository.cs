using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Application.ViewModels.TrainerViewModel;
using GymManagement.Domain.Entities;
using GymManagement.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Infrastructure.Repositories
{
    public class TrainerRepository : RepositoryBase<Trainer>, ITrainerRepository
    {
        private readonly GymManagementDbContext _context;

        public TrainerRepository(GymManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public List<TrainerQueryViewModel> GetTrainersWithEmployeeDetail()
        {
            var result = _context.Trainers.Select(trainer => new TrainerQueryViewModel
            {
                Id = trainer.Id,
                FirstName = trainer.EmployeeDetail.FirstName,
                LastName = trainer.EmployeeDetail.LastName,
                Salary = trainer.EmployeeDetail.Salary,
                WorkerContractIsActive = trainer.WorkerContract.IsActive
            });

            return result.ToList();
        }



    }
}

