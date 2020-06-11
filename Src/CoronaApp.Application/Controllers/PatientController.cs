using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Services;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Serilog;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using CoronaApp.Services.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // GET api/<PatientController>/5
        [HttpGet]
        public async Task<ActionResult<Patient>> GetAsync()
        {
            try
            {
                var idFromUserBaseController = this.User.FindFirst(ClaimTypes.Name).Value;
                Log.Information($"Someone gets patient with id: {idFromUserBaseController}");
                Patient patient = await _patientService.GetAsync(Convert.ToInt32(idFromUserBaseController));
                return Ok(patient);
            }
            catch (Exception e)
            {
                Log.Information(e.Message);
                return BadRequest(new { Status = false });
            }
        }

        // POST api/<PatientController>
        [HttpPost]
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
        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync([FromBody] RegisterModel register)
        {
            try
            {
                var registerToken = await _patientService.RegisterAsync(register.Id, register.Username, register.Password);
                return Ok(registerToken);
            }
            catch (Exception e)
            {
                Log.Information(e.Message);
                return BadRequest(new { Status = false });
            }
        }

        [HttpDelete]
        public async Task DeleteLocationAsync([FromBody] Location location)
        {
            try
            {
                await _patientService.DeleteLocationAsync(location);
            }
            catch (Exception e)
            {
                Log.Information(e.Message);                
            }
        }
    }
}
