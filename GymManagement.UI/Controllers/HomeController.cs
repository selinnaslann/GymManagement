using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;



namespace GymManagement.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICampaignService _campaignService;

        public HomeController(ILogger<HomeController> logger, ICampaignService campaignService)
        {
            _logger = logger;
            _campaignService = campaignService;
        }

        public IActionResult Index()
        {
            var campaigns = _campaignService.GetAll();

            return View(campaigns);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}