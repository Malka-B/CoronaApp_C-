using CoronaApp.Services.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Patient = Entities.Patient;

namespace CoronaApp.Services
{
    public interface IPatientRepository
    {
        public Task<Patient> Get(int patientId);

        public Task Save(Patient patient);

        public Task DeleteLocation(Location location);
    }
}
