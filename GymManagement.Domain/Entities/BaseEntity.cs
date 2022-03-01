using System;

namespace GymManagement.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool  IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
