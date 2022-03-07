using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.ViewModels.CampaignViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagement.WebAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService _campaignService;

        public CampaignController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [Authorize(Roles ="Member")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _campaignService.GetAll();
            return Ok(result);
        }

        [Authorize(Roles ="Admin")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_campaignService.GetById(id));
        }
        [HttpPost]
        public IActionResult Create(CampaignCommandViewModel model)
        {
            var result = _campaignService.Create(model);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] CampaignCommandViewModel model,int id)
        {
            var result = _campaignService.Update(model, id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _campaignService.Delete(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
