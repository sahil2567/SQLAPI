using Patient_ApiSQLMigration.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.DataLayer.IData
{
    public interface IBPData
    {
        Task<List<BP>> GetBP(string GSI1PK);
        Task<string> AddBP(BP bp);
        Task<string> UpdateBP(BP bp);
        Task<string> DeleteBP(int Id);
    }
}
