using CoronaApp.Services.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Patient = Entities.Patient;

namespace CoronaApp.Services
{
    public interface IPatientRepository
    {
        public Task<Patient> GetAsync(int patientId);

        public Task SaveAsync(Patient patient);

        public Task DeleteLocationAsync(Location location);

        public Task<Patient> LoginAsync(string userName, string password);

        public Task<bool> RegisterAsync(int id, string userName, string password);
        
        public Task UpdateAsync(List<Location> location, int patientId);
    }
}
