using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Services;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }


        // GET api/<PatientController>/5
        [HttpGet]
        public async Task<Patient> Get([FromQuery] int patientId)
        {
            Log.Information($"Someone gets patient with id: {patientId}");            
            return await _patientService.Get(patientId);
        }


        // POST api/<PatientController>
        [HttpPost]
        public async Task Save([FromBody] Patient patient)
        {
            await _patientService.Save(patient);

        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Patient value)
        {

        }

        [HttpDelete]
        public async Task DeleteLocation([FromBody] Location location)
        {
            await _patientService.DeleteLocation(location);
        }
    }
}
