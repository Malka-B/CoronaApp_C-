using CoronaApp.Services;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal
{
    public class AsDB : IPatientRepository
    {
        public Task DeleteLocation(Location location)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> Get(int id)
        {
            Patient p = new Patient { Id = id, Age = 55, LocationsList = new List<Location> { } };

            return Task.FromResult(p); 
        }
    

    public Task Save(Patient patient)
    {
        throw new NotImplementedException();
    }
}

        
}
