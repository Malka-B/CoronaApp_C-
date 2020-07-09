using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Services;
using CoronaApp.Services.Models;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientControllerForAngular : ControllerBase
    {
        private readonly IPatientService _patientService;
        // private IEndpointInstance _endpointInstance;

        public PatientControllerForAngular(IPatientService patientService)
        {
            _patientService = patientService;
            //_endpointInstance = endpointInstance;
        }


        [HttpGet("getById")]
        public async Task<ActionResult<Patient>> GetAsync([FromQuery] int id)
        {
            try
            {
                
                Patient patient = await _patientService.GetAsync(id);
                return Ok(patient);
            }
            catch (Exception e)
            {
                Log.Information(e.Message);
                return BadRequest(new { Status = false });
            }
        }

        // POST api/<PatientController>
        [HttpPost("postAngular")]
        public async Task SaveAsync([FromBody] Patient patient)
        {
            try
            {
                await _patientService.SaveAsync(patient);
            }
            catch (Exception e)
            {
                Log.Information(e.Message);
            }

        }

        [HttpPut("put")]
        public async Task<bool> UpdateAsync([FromBody] List<Location> location,[FromQuery] int patientId)
        {
            try
            {
                await _patientService.UpdateAsync(location, patientId);
                return true;
            }
            catch (Exception e)
            {
                Log.Information(e.Message);
                return false;
            }

        }

        [AllowAnonymous]
        [HttpPost("loginAsync")]
        public async Task<ActionResult> LoginAsync([FromBody] AuthenticateModel authenticate)
        {
            try
            {
                var token = await _patientService.LoginAsync(authenticate.Username, authenticate.Password);
                if (token != null)
                {
                    return Ok(token);
                }
                else
                {
                    return BadRequest(new { message = "Username or password is incorrect" });
                }
            }
            catch (Exception e)
            {
                Log.Information(e.Message);
                return BadRequest(new { Status = false });
            }
        }

        [AllowAnonymous]
        [HttpPost("registerAngular")]
        public async Task<ActionResult> RegisterAsync([FromBody] RegisterModel register)
        {
            try
            {
                //await NewPatientRegistered(register.Id);
                var registerToken = await _patientService.RegisterAsync(register.Id, register.Username, register.Password);
                return Ok(true);
            }
            catch (Exception e)
            {
                Log.Information(e.Message);
                return BadRequest(new { Status = false });
            }
        }

        [HttpDelete("deleteAngular")]
        public async Task<bool> DeleteLocationAsync([FromBody] Location location)
        {
            try
            {
                await _patientService.DeleteLocationAsync(location);
                return true;
            }
            catch (Exception e)
            {
                Log.Information(e.Message);
                return false;
            }
        }
    }
}
