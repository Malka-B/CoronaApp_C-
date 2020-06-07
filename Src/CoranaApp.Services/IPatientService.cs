using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface IPatientService
    {
        public Task<Patient> Get(string id);

        public Task Save(Patient patient);

        public Task DeleteLocation(Location location);
    }
}
