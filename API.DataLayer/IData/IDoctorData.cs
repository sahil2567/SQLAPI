using Patient_ApiSQLMigration.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.DataLayer.IData
{
    public interface IDoctorData
    {
        Task<List<Doctor>> GetDoctor(string ActiveStatus);
        Task<string> AddDoctor(Doctor doctor);
        Task<string> UpdateDoctor(Doctor doctor);
        Task<string> DeleteDoctor(int Id);
    }
}
