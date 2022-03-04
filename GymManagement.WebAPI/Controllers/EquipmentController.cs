using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.ViewModels.CampaignViewModel;
using GymManagement.Application.ViewModels.EquipmentViewModel;
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
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpPost]
        public IActionResult Create(EquipmentCommandViewModel model)
        {
            var result = _equipmentService.Create(model);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] EquipmentCommandViewModel model, int id)
        {
            var result = _equipmentService.Update(model, id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _equipmentService.Delete(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult GetEquipmentsWithTrainer()
        {
            return Ok(_equipmentService.GetEquipmentsWithTrainer());
        }
    }
}
