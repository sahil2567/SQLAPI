using Patient_ApiSQLMigration.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.DataLayer.IData
{
    public interface IWeightData
    {
        Task<List<Weight>> GetWeight(string GSI1PK);
        Task<string> AddWeight(Weight weight);
        Task<string> UpdateWeight(Weight weight);
        Task<string> DeleteWeight(int Id);
    }
}
