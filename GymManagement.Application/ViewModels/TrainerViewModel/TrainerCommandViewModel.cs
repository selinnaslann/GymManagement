using GymManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.ViewModels.TrainerViewModel
{
    public class TrainerCommandViewModel
    {
        public EmployeeDetail EmployeeDetail { get; set; }
        public WorkerContract WorkerContract { get; set; }
    }
}
