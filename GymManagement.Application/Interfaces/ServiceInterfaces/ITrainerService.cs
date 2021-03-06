using GymManagement.Application.ViewModels.TrainerViewModel;
using GymManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Interfaces.ServiceInterfaces
{
    public interface ITrainerService
    {
        List<TrainerQueryViewModel> GetTrainersWithEmployeeDetail();
        //bool AddMemberExerciseProgram(string memberId);
        bool EquipmentMaintenanceControl(int equipmentId);
    }
}
