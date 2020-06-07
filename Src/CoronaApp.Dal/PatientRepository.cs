using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Services;

namespace CoronaApp.Dal
{
    public class PatientRepository : IPatientRepository
    {
        CoronaContext _coronaContext;

        public PatientRepository(CoronaContext coronaContext)
        {
            _coronaContext = coronaContext;
        }

        public async Task DeleteLocation(Location location)
        {
                Location location1 = await _coronaContext.Location
                .FirstOrDefaultAsync(l => l.StartDate == location.StartDate &&
                l.EndDate == location.EndDate &&
                l.Address == location.Address &&
                l.City == location.City);
            _coronaContext.Location.Remove(location1);
            await _coronaContext.SaveChangesAsync();            
        }

        public async Task<Patient> Get(string patientId)
        {
            Patient p = await _coronaContext.Patient
                .Include(p => p.LocationsList)
                .FirstOrDefaultAsync(p => p.Id == patientId);
            return p;
        }

        public async Task Save(Patient patient)
        {
            Patient patientToUpdate = await _coronaContext.Patient
                .Include(p => p.LocationsList)
                .FirstOrDefaultAsync(p => p.Id == patient.Id);
            if (patientToUpdate != null)
            {
                patientToUpdate.LocationsList.AddRange(patient.LocationsList);
            }
            else
            {
                await _coronaContext.Patient.AddAsync(patient);
            }
            await _coronaContext.SaveChangesAsync();
        }
    }
}
