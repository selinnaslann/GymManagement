using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.ViewModels.TrainerViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;
        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpPost]
        public IActionResult CreateTrainer([FromBody] TrainerCommandViewModel model)
        {
            if (_managerService.CreateTrainer(model))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{trainerId}")]

        public IActionResult AddMissionToTrainer([FromQuery] int missionId, int trainerId)
        {
            //Buraya bakılacak...
            if (_managerService.AddMissionToTrainer(missionId, trainerId))
            {
                return Ok();
            }
            return BadRequest();
        }






    }
}
