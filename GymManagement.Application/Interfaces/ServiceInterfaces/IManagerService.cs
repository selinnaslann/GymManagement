using GymManagement.Application.ViewModels.TrainerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IManagerService
    {
        bool CreateTrainer(TrainerCommandViewModel model);
        bool AddMissionToTrainer(int missionId, int trainerId);
    }
}
