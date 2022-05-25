using Patient_ApiSQLMigration.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.DataLayer.IData
{
    public interface INotificationData
    {
        Task<List<Notification>> GetNotification();
        Task<string> AddNotification(Notification notification);
        Task<string> UpdateNotification(Notification notification);
        Task<string> DeleteNotification(int Id);
    }
}
