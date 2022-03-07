using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.ViewModels.MissionViewModel
{
    public class MissionQueryViewModel
    {
        public int Id { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
