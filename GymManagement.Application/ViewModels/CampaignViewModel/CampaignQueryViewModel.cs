using System;


namespace GymManagement.Application.ViewModels.CampaignViewModel
{
    public class CampaignQueryViewModel
    {
        public int Id { get; set; }
        public string CampaignName { get; set; }
        public double Price { get; set; }
        public short MonthlyPeriod { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
