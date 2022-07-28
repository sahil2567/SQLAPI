using Patient_ApiSQLMigration.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.DataLayer.IData
{
    public interface IChatData
    {
        Task<List<Chat>> GetChat(int ReceiverId);
        
    }
}
