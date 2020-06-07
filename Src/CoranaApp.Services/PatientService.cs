using Entities;
using System;
using System.Collections.Generic;
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

        public async Task DeleteLocation(Location location)
        {
            await _patientRepository.DeleteLocation(location);
        }

        public async Task<Patient> Get(int patientId)
        {
            return await _patientRepository.Get(patientId);
        }

        public async Task Save(Patient patient)
        {
            await _patientRepository.Save(patient);
        }
    }
}
