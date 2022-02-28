using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Domain.Entities
{
    public class Worker:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SgkNumber { get; set; }
        public double Salary { get; set; }
        public DateTime PaymentDate { get; set; }
    }

    public class Contract
    {
        public DateTime EndDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public short Duration { get; set; }
        public bool IsActive { get; set; }


    }
}
