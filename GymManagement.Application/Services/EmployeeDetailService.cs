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
    public class EmployeeDetailService : IEmployeeDetailService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Create(EmployeeDetail model)
        {
            var validator = new EmployeeDetailValidator();
            validator.ValidateAndThrow(model);

            _unitOfWork.EmployeeDetails.Create(model);

            return _unitOfWork.SaveChanges();
        }

        public bool Delete(int id)
        {
            var employeeDetail = _unitOfWork.EmployeeDetails.GetById(id);

            employeeDetail.IfIsNullThrowNotFoundException("Employee Detail", id);

            employeeDetail.IsDeleted = true;
            _unitOfWork.EmployeeDetails.Update(employeeDetail);
            if (_unitOfWork.SaveChanges())
            {
                return true;
            }

            return false;
        }

        public EmployeeDetail GetById(int id)
        {
            return _unitOfWork.EmployeeDetails.GetById(id);
        }

        public bool Update(EmployeeDetail model, int id)
        {
            var validator = new EmployeeDetailValidator();
            validator.ValidateAndThrow(model);
            var employeeDetail = _unitOfWork.EmployeeDetails.GetById(id);
            employeeDetail.IfIsNullThrowNotFoundException("Employee Detail", id);
            _unitOfWork.EmployeeDetails.Update(model);
            if (_unitOfWork.SaveChanges())
            {
                return true;
            }

            return false;

        }
    }
}
