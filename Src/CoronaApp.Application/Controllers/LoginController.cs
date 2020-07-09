using CoronaApp.Services;
using CoronaApp.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;


        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost("loginAsync")]
        public async Task<ActionResult> LoginAsync([FromBody] AuthenticateModel authenticate)
        {
            try
            {
                var patientId = await _loginService.LoginAsync(authenticate.Username, authenticate.Password);

                return Ok(patientId);

            }
            catch (Exception e)
            {
                Log.Information(e.Message);
                return BadRequest(new { Status = false });
            }
        }
    }
}
