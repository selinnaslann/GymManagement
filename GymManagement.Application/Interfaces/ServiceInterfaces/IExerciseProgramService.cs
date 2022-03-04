using GymManagement.Application.ViewModels.ExerciseProgramViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IExerciseProgramService
    {
        List<ExerciseProgramQueryViewModel> GetAll();
        bool Create(ExerciseProgramCommandViewModel model);
        bool Update(ExerciseProgramCommandViewModel model, int id);
        bool Delete(int id);
    }
}
