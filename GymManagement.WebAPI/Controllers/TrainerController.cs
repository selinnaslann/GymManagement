using GymManagement.Application.Interfaces.ServiceInterfaces;
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
    public class TrainerController : ControllerBase
    {

        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpGet]
        public IActionResult GetTrainersWithEmployeeDetail()
        {
            return Ok(_trainerService.GetTrainersWithEmployeeDetail());
        }

        [HttpPut("{equipmentId}")]
        public IActionResult EquipmentMaintenanceControl(int equipmentId)
        {
            var result = _trainerService.EquipmentMaintenanceControl(equipmentId);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }



    }
}
