using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.ViewModels.TrainerViewModel
{
    public class TrainerQueryViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }
        public bool WorkerContractIsActive { get; set; }
    }
}
