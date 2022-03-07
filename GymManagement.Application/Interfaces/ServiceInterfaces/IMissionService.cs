using GymManagement.Application.ViewModels.MissionViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IMissionService
    {
        List<MissionQueryViewModel> GetAll();
        MissionQueryViewModel GetById(int id);
        bool Create(MissionCommandViewModel model);
        bool Update(MissionCommandViewModel model, int id);
        bool Delete(int id);
    }
}
