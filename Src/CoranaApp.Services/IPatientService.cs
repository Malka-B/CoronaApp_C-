using CoronaApp.Services.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface IPatientService
    {
        public Task<Patient> GetAsync(int patientId);

        public Task SaveAsync(Patient patient);

        public Task DeleteLocationAsync(Location location);

        public Task<IdAndToken> LoginAsync(string userName, string password);
                
        public Task<string> RegisterAsync(int id, string userName, string password);
       
        public Task UpdateAsync(List<Location> location, int patientId);
    }
}
