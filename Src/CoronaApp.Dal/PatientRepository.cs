using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Services;
using Microsoft.AspNetCore.Mvc;
using CoronaApp.Services.Models;

namespace CoronaApp.Dal
{
    public class PatientRepository : IPatientRepository
    {
        CoronaContext _coronaContext;

        public PatientRepository(CoronaContext coronaContext)
        {
            _coronaContext = coronaContext;
        }

        public async Task DeleteLocationAsync(Location location)
        {
            Location location1 = await _coronaContext.Location
            .FirstOrDefaultAsync(l => l.StartDate == location.StartDate &&
                                      l.EndDate == location.EndDate &&
                                      l.Adress == location.Adress &&
                                      l.City == location.City);
            _coronaContext.Location.Remove(location1);
            await _coronaContext.SaveChangesAsync();
        }

        public async Task<Patient> GetAsync(int patientId)
        {
            Patient p = await GetPatientByIdAsync(patientId);
            return p;
        }

        public async Task SaveAsync(Patient patient)
        {
            Patient patientToUpdate = await GetPatientByIdAsync(patient.Id);
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

        public async Task<Patient> LoginAsync(string userName, string password)
        {
            Patient loginPatient = await _coronaContext.Patient
                                                        .Include(p => p.LocationsList)
                                                        .FirstOrDefaultAsync(p => p.UserName == userName
                                                        && p.Password == password);
            return loginPatient;
        }

        public async Task<bool> RegisterAsync(int id, string userName, string password)
        {
            Patient p = await _coronaContext.Patient
                                            .Include(p => p.LocationsList)
                                            .FirstOrDefaultAsync(p => p.UserName == userName
                                            && p.Password == password);
            if (p == null)
            {
                Patient newPatient = new Patient { Id = id, UserName = userName, Password = password };
                await _coronaContext.Patient.AddAsync(newPatient);
            }
            await _coronaContext.SaveChangesAsync();
            return true;
        }

        //public async Task<Patient> GetPatientByUserNamePasswordAsync(string userName, string password)
        //{
        //    return await _coronaContext.Patient
        //        .Include(p => p.LocationsList)
        //        .FirstOrDefaultAsync(p => p.UserName == userName
        //                               && p.Password == password);
        //}

        private async Task<Patient> GetPatientByIdAsync(int patientId)
        {
            return await _coronaContext.Patient
                            .Include(p => p.LocationsList)
                            .FirstOrDefaultAsync(p => p.Id == patientId);
        }
    }
}
