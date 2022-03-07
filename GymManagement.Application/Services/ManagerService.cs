using GymManagement.Application.Extensions;
using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.Interfaces.UnitOfWorks;
using GymManagement.Application.ViewModels.TrainerViewModel;
using GymManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Services
{
    public class ManagerService:IManagerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManagerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool CreateTrainer(TrainerCommandViewModel model)
        {
            _unitOfWork.EmployeeDetails.Create(model.EmployeeDetail);
            _unitOfWork.WorkerContracts.Create(model.WorkerContract);
            _unitOfWork.SaveChanges();

            var employeeDetail = _unitOfWork.EmployeeDetails
                .Get(e => e.InsuranceNumber == model.EmployeeDetail.InsuranceNumber)
                .FirstOrDefault();

            var workerContract = _unitOfWork.WorkerContracts.GetAll()
                .OrderByDescending(x => x.Id).FirstOrDefault();

            Trainer trainer = new()
            {
                EmployeeDetailId = employeeDetail.Id,
                WorkerContractId = workerContract.Id
            };

            _unitOfWork.Trainers.Create(trainer);

            return _unitOfWork.SaveChanges();
            //Burada Member SingUp yapılacak yani Trainer Login olabilmesi için Users tablosuna eklenecek 
            //TrainerCommandViewModel de UserName,Email vb bilgiler istenecek.
        }

        public bool AddMissionToTrainer(int missionId, int trainerId)
        {
            var trainer = _unitOfWork.Trainers.GetById(trainerId);

            trainer.IfIsNullThrowNotFoundException("Trainer", trainerId);

            var mission = _unitOfWork.Missions.GetById(missionId);

            mission.IfIsNullThrowNotFoundException("Mission", trainerId);

            //Bu kısma daha sonra bakılacak!!! HATA VAR !!!
            mission.Trainers.Add(trainer);
            _unitOfWork.Missions.Update(mission);
            return _unitOfWork.SaveChanges();
        }
    }
}
