using Patient_ApiSQLMigration.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.DataLayer.IData
{
    public interface IPatientData
    {
        Task<List<Patient>> GetPatient(string DoctorId, string ActiveStatus);
        Task<string> AddPatient(Patient patient);
        Task<string> UpdatePatient(Patient patient);
        Task<string> DeletePatient(int Id);
    }
}
