using Patient_ApiSQLMigration.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.DataLayer.IData
{
    public interface ICoachData
    {
        Task<List<Coach>> GetCoach();
        Task<string> AddCoach(Coach coach);
        Task<string> UpdateCoach(Coach coach);
        Task<string> DeleteCoach(int Id);
    }
}
