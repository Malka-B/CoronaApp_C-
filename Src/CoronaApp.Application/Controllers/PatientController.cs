using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Services;
using CoronaApp.Services.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        IPatientRepository _patientRepository;
        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }


        // GET api/<PatientController>/5

        [HttpGet]
     
       // public Patient Get([FromQuery] string patientId)
        //{
          // return _patientRepository.Get(patientId);            
       // }

        // POST api/<PatientController>
        [HttpPost]
        /*public void Save([FromBody] Patient patient)
        {
            _patientRepository.Save(patient);
            
          
        }*/

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

       

           // Patient patient = AsDB.PatientList.Find(p => p.PatientID == patientId);

            //Location locationToDelete = patient.LocationsList.Find(l => l.StartDate == location.StartDate &&

        }
    
}
