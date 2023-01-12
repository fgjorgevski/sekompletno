using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TREKS.SeKompletno.DomainModels.Models;
using TREKS.SeKompletno.RequestModels;
using TREKS.SeKompletno.Services.Interfaces;

namespace TREKS.SeKompletno.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ManufacturerController : ControllerBase
    {
        public readonly IManufacturerService _manufacturerService;

        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }


        [HttpPost]
        [Route("CreateManfacturer")]
        public IActionResult CreateManufacturer([FromBody] ManufacturerModel model)
        {
            _manufacturerService.AddManufacturer(model);

            return Ok("Manafacturer added");
        }

        [HttpDelete]
        [Route("DeleteManafacturerById")]
        public IActionResult DeleteManafacturer([FromQuery] int id)
        {
            _manufacturerService.DeleteManufacturerById(id);
            return Ok("Manafacturer deleted");
        }
    }
}
