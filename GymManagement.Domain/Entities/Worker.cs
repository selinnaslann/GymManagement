using System.Collections.Generic;

namespace GymManagement.Domain.Entities
{
    public class Worker : BaseEntity
    {
        public int EmployeeDetailId { get; set; }
        public EmployeeDetail EmployeeDetail { get; set; }
        public int WorkerContractId { get; set; }
        public WorkerContract WorkerContract { get; set; }
        public List<Mission> Missions { get; set; }
    }
}
