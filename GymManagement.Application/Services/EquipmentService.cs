using AutoMapper;
using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.Interfaces.UnitOfWorks;
using GymManagement.Application.ViewModels.EquipmentViewModel;
using GymManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EquipmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Create(EquipmentCommandViewModel model)
        {
            var equipment = _mapper.Map<Equipment>(model);
            equipment.MaintenancePeriod = equipment.CreatedDate.AddMonths(model.Duration);
            _unitOfWork.Equipments.Create(equipment);
            if (_unitOfWork.SaveChanges())
            {
                return true;
            }
            return false;

        }

        public bool Delete(int id)
        {
            var equipment = _unitOfWork.Equipments.GetById(id);
            if (equipment is null)
            {
                throw new InvalidOperationException("Equipment is not found");
            }
            equipment.IsDeleted = true;
            _unitOfWork.Equipments.Update(equipment);
            if (_unitOfWork.SaveChanges())
            {
                return true;
            }
            return false;
        }

        public List<EquipmentQueryViewModel> GetEquipmentsWithTrainer()
        {
            var equipments= _unitOfWork.Equipments.GetEquipmentsWithTrainer();
           return  _mapper.Map<List<EquipmentQueryViewModel>>(equipments);

        }

        public bool Update(EquipmentCommandViewModel model, int id)
        {
            var equipment = _mapper.Map<Equipment>(model);
            var getByequipment = _unitOfWork.Equipments.GetById(id);
            
            if (getByequipment is null)
            {
                throw new InvalidOperationException("Equipment is not found");
            }
            
            equipment.MaintenancePeriod = equipment.CreatedDate.AddMonths(model.Duration);
            _unitOfWork.Equipments.Update(equipment);

            if (_unitOfWork.SaveChanges())
            {
                return true;
            }
            return false;
        }
    }
}
