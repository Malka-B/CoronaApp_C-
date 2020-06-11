using CoronaApp.Services.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task DeleteLocationAsync(Location location)
        {
            await _patientRepository.DeleteLocationAsync(location);
        }

        public async Task<Patient> GetAsync(int patientId)
        {
            return await _patientRepository.GetAsync(patientId);
        }
        public async Task SaveAsync(Patient patient)
        {
            await _patientRepository.SaveAsync(patient);
        }
        
        public async Task<IdAndToken> LoginAsync(string userName, string password)
        {
            var p = await _patientRepository.LoginAsync(userName, password);
            if (p != null)
            {
               /* var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("ThisIsAnImportantSecret");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, p.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };*/
                var token = CreatTokenInService(p.Id);
                return new IdAndToken { Id = p.Id, Token = token };
            }

            else
            {

                return null;
            }
        }

        public async Task<string> RegisterAsync(int id, string userName, string password)
        {
            if (await _patientRepository.RegisterAsync(id, userName, password))
            {
              /*  var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("ThisIsAnImportantSecret");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);*/
                return CreatTokenInService(id);
            }
            else
            {
                return null;
            }
        }

        public string CreatTokenInService(int id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ThisIsAnImportantSecret");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
