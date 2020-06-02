using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Services;
using CoronaApp.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Entities;

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        // GET: api/<LocationController>
        [HttpGet]

       public List<Location> Get([FromQuery] LocationSearch locationSearch=null)
       {
          return _locationService.Get(locationSearch);
       }
      [HttpGet]
      [Route("{sort}")]
        public List<Location> Get()
        {
            return _locationService.Get();
        }
    
    }
}
