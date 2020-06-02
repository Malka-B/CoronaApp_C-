using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Services.Models
{
    public class PatientRepository : IPatientRepository
    {
        public Patient Get(string patientId)
        {
            //Patient patientLocations = AsDB.PatientList.Find(l => l.PatientID == patientId);
            //if (patientLocations != null)
            //{
              //  return patientLocations;
            //}
            return null;
            
        }

        public void Save(Patient patient)
        {
        
        }
    }
}
