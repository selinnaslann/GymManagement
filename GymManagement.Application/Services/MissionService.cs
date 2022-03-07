using AutoMapper;
using GymManagement.Application.Extensions;
using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.Interfaces.UnitOfWorks;
using GymManagement.Application.ViewModels.MissionViewModel;
using GymManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Services
{
    public class MissionService:IMissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public MissionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<MissionQueryViewModel> GetAll()
        {
            var missions = _unitOfWork.Missions.GetAll();

            return _mapper.Map<List<MissionQueryViewModel>>(missions);
        }

        public MissionQueryViewModel GetById(int id)
        {
            var mission = _unitOfWork.Missions.GetById(id);

            mission.IfIsNullThrowNotFoundException("Trainer", id);

            return _mapper.Map<MissionQueryViewModel>(mission);

        }

        public bool Create(MissionCommandViewModel model)
        {
            var mission = _mapper.Map<Mission>(model);
            _unitOfWork.Missions.Create(mission);

            return _unitOfWork.SaveChanges();
        }

        public bool Update(MissionCommandViewModel model, int id)
        {
            var mission = _unitOfWork.Missions.GetById(id);

            mission.IfIsNullThrowNotFoundException("Trainer", id);

            var vmModel = _mapper.Map<Mission>(model);
            vmModel.Id = id;
            _unitOfWork.Missions.Update(vmModel);

            return _unitOfWork.SaveChanges();

        }

        public bool Delete(int id)
        {
            var mission = _unitOfWork.Missions.GetById(id);

            mission.IfIsNullThrowNotFoundException("Trainer", id);

            mission.IsDeleted = true;
            _unitOfWork.Missions.Update(mission);
            return _unitOfWork.SaveChanges();
        }
    }
}
