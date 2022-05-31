using Patient_ApiSQLMigration.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.DataLayer.IData
{
    public interface IBGData
    {
        Task<List<BG>> GetBG(string GSI1PK);
        Task<string> AddBG(BG bg);
        Task<string> UpdateBG(BG bg);
        Task<string> DeleteBG(int Id);
    }
}
