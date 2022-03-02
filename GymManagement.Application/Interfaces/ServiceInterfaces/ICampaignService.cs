using GymManagement.Application.ViewModels.CampaignViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Interfaces.ServiceInterfaces
{
    public interface ICampaignService
    {
        List<CampaignQueryViewModel> GetAll();
        bool Create(CampaignCommandViewModel model);
        bool Update(CampaignCommandViewModel model);

    }
}
