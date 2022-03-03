using GymManagement.Application.ViewModels.EquipmentViewModel;
using System.Collections.Generic;


namespace GymManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IEquipmentService
    {
        public List<EquipmentQueryViewModel> GetEquipmentsWithTrainer();
        bool Create(EquipmentCommandViewModel model);
        bool Update(EquipmentCommandViewModel model, int id);
        bool Delete(int id);
    }
}
