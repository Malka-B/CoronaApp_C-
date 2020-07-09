using CoronaApp.Services;
using CoronaApp.Services.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal
{
    public class AsDB : IPatientRepository
    {
        public Task DeleteLocationAsync(Location location)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> GetAsync(int patientId)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> LoginAsync(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterAsync(int id, string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Patient patient)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(List<Location> location, int patientId)
        {
            throw new NotImplementedException();
        }
    }


}
