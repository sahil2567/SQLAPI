using Patient_ApiSQLMigration.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.DataLayer.IData
{
    public interface IUserTableData
    {
        Task<List<UserTable>> GetUserTable();
        Task<string> AddUserTable(UserTable userTable);
        Task<string> UpdateUserTable(UserTable userTable);
        Task<string> DeleteUserTable(int Id);
    }
}
