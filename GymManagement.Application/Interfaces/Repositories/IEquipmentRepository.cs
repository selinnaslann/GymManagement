using GymManagement.Application.ViewModels.EquipmentViewModel;
using GymManagement.Domain.Entities;
using System.Collections.Generic;

namespace GymManagement.Application.Interfaces.Repositories
{
    public interface IEquipmentRepository : IRepositoryBase<Equipment>
    {
        public List<EquipmentQueryViewModel> GetEquipmentsWithTrainer();
        
    }
}
