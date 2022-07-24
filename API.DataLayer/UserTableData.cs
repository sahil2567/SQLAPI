using API.DataLayer.IData;
using Microsoft.Extensions.Configuration;
using Patient_ApiSQLMigration.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace API.DataLayer
{
    public class UserTableData : IUserTableData
    {
        private IConfiguration configuration;
        public UserTableData(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public async Task<string> AddUserTable(UserTable userTable)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Insert Into [dbo].[UserTable] (UserId,UserName,UserType,Email,SNO) Values ('" + userTable.UserId + "','" + userTable.UserName + "','" + userTable.UserType + "','" + userTable.Email + "','" + userTable.SNO + "'); ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = System.Data.CommandType.Text;
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    return i > 0 ? "Y" : "N";
                }
            }
            catch (Exception ex)
            {
                return "N";
            }
            finally
            {

            }
        }

        public async Task<string> DeleteUserTable(int Id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Delete From [dbo].[UserTable] Where Id = " + Id.ToString();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = System.Data.CommandType.Text;
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    return i > 0 ? "Y" : "N";
                }
            }
            catch (Exception ex)
            {
                return "N";
            }
            finally
            {

            }
        }

        public async Task<List<UserTable>> GetUserTable()
        {
            List<UserTable> patients = new List<UserTable>();
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {

                    SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[UserTable]", con);
                    cmd.CommandType = System.Data.CommandType.Text;
                    DataTable table = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            patients.Add(new UserTable
                            {
                                Id = Convert.ToInt32(table.Rows[i]["Id"].ToString()),
                                UserId = table.Rows[i]["UserId"].ToString(),
                                UserType = table.Rows[i]["UserType"].ToString(),
                                UserName = table.Rows[i]["UserName"].ToString(),
                                Email = table.Rows[i]["Email"].ToString(),
                                SNO= table.Rows[i]["SNO"].ToString(),


                            });
                        }
                    }
                    return patients;
                
                


                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }

        public async Task<string> UpdateUserTable(UserTable userTable)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = System.Data.CommandType.Text;
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    return i > 0 ? "Y" : "N";
                }
            }
            catch (Exception ex)
            {
                return "N";
            }
            finally
            {

            }
        }
    }
}
