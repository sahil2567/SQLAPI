using Patient_ApiSQLMigration.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.DataLayer.IData
{
    public interface ICareCoordinatorData
    {
        Task<List<CareCoordinator>> GetCareCoordinator();
        Task<string> AddCareCoordinator(CareCoordinator careCoordinator);
        Task<string> UpdateCareCoordinator(CareCoordinator careCoordinator);
        Task<string> DeleteCareCoordinator(int Id);
    }
}
