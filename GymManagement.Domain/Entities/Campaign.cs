
using System.Collections.Generic;

namespace GymManagement.Domain.Entities
{
    public class Campaign : BaseEntity
    {
        public string CampaignName { get; set; }
        public double Price { get; set; }
        public short MonthlyPeriod { get; set; }
        public List<Member> Members { get; set; }

    }
}
