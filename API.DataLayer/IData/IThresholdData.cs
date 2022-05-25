using Patient_ApiSQLMigration.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.DataLayer.IData
{
    public interface IThresholdData
    {
        Task<List<Threshold>> GetThreshold();
        Task<string> AddThreshold(Threshold threshold);
        Task<string> UpdateThreshold(Threshold threshold);
        Task<string> DeleteThreshold(int Id);
    }
}
