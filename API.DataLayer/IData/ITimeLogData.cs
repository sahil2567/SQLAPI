using Patient_ApiSQLMigration.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.DataLayer.IData
{
    public interface ITimeLogData
    {
        Task<List<TimeLog>> GetTimeLog(string GSI1PK);
        Task<string> AddTimeLog(TimeLog timeLog);
        Task<string> UpdateTimeLog(TimeLog timeLog);
        Task<string> DeleteTimeLog(int Id);
    }
}
