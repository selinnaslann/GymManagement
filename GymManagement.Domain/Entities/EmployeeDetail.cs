using System;


namespace GymManagement.Domain.Entities
{
    public class EmployeeDetail : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string InsuranceNumber { get; set; }
        public double Salary { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
