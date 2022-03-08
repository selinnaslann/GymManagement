using FluentValidation;
using GymManagement.Application.Extensions;
using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.Interfaces.UnitOfWorks;
using GymManagement.Application.Validations;
using GymManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Services
{
    public class WorkerContractService : IWorkerContractService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorkerContractService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<WorkerContract> GetAll()
        {
            return _unitOfWork.WorkerContracts.GetAll();
        }

        public WorkerContract GetById(int id)
        {
            return _unitOfWork.WorkerContracts.GetById(id);
        }

        public bool Create(WorkerContract model)
        {
            var validotor = new WorkerContractValidator();
            validotor.ValidateAndThrow(model);

            _unitOfWork.WorkerContracts.Create(model);

            return _unitOfWork.SaveChanges();
        }

        public bool Update(WorkerContract model, int id)
        {
            var validotor = new WorkerContractValidator();
            validotor.ValidateAndThrow(model);

            _unitOfWork.WorkerContracts.Update(model);

            return _unitOfWork.SaveChanges();
        }

        public bool Delete(int id)
        {

            var workerContract = _unitOfWork.WorkerContracts.GetById(id);
            workerContract.IfIsNullThrowNotFoundException("Worker Contract", id);

            workerContract.IsDeleted = true;

            _unitOfWork.WorkerContracts.Update(workerContract);
            return _unitOfWork.SaveChanges();
        }
    }
}
