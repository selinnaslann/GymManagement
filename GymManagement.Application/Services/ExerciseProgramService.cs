using AutoMapper;
using FluentValidation;
using GymManagement.Application.Extensions;
using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.Interfaces.UnitOfWorks;
using GymManagement.Application.Validations;
using GymManagement.Application.ViewModels.ExerciseProgramViewModel;
using GymManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Services
{
    public class ExerciseProgramService : IExerciseProgramService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public ExerciseProgramService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<ExerciseProgramQueryViewModel> GetAll()
        {
            var exercisePrograms = _unitOfWork.ExercisePrograms.GetAll();
            return _mapper.Map<List<ExerciseProgramQueryViewModel>>(exercisePrograms);

        }

        public bool Create(ExerciseProgramCommandViewModel model)
        {
            var validator = new ExerciseProgramValidator();
            validator.ValidateAndThrow(model);

            var exerciseProgram = _mapper.Map<ExerciseProgram>(model);

            _unitOfWork.ExercisePrograms.Create(exerciseProgram);

            return _unitOfWork.SaveChanges();
        }

        public bool Update(ExerciseProgramCommandViewModel model, int id)
        {
            var validator = new ExerciseProgramValidator();
            validator.ValidateAndThrow(model);

            var getExerciseProgram = _unitOfWork.ExercisePrograms.GetById(id);

            getExerciseProgram.IfIsNullThrowNotFoundException("Exercise Program", id);


            var vmModel = _mapper.Map<ExerciseProgram>(model);
            vmModel.Id = id;
            _unitOfWork.ExercisePrograms.Update(vmModel);

            return _unitOfWork.SaveChanges();
        }

        public bool Delete(int id)
        {
            var exerciseProgram = _unitOfWork.ExercisePrograms.GetById(id);

            exerciseProgram.IfIsNullThrowNotFoundException("Exercise Program", id);
            exerciseProgram.IsDeleted = true;
            _unitOfWork.ExercisePrograms.Update(exerciseProgram);
            return _unitOfWork.SaveChanges();
        }
    }
}
