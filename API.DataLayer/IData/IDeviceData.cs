using Patient_ApiSQLMigration.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.DataLayer.IData
{
    public interface IDeviceData
    {
        Task<List<Device>> GetDevice();
        Task<string> AddDevice(Device device);
        Task<string> UpdateDevice(Device device);
        Task<string> DeleteDevice(int Id);
    }
}
