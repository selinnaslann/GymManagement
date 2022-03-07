using GymManagement.Application.ViewModels.TrainerViewModel;
using GymManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Interfaces.Repositories
{
    public interface ITrainerRepository : IRepositoryBase<Trainer>
    {
        List<TrainerQueryViewModel> GetTrainersWithEmployeeDetail();
}   }

