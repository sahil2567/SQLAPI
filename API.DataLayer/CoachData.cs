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
    public class CoachData : ICoachData
    {
        private IConfiguration configuration;
        public CoachData(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public async Task<string> AddCoach(Coach coach)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Insert Into [dbo].[CoachTable] (SK,ActiveStatus,ContactNo,CreatedDate,Email,GSI1PK,GSI1SK,UserId,UserName,UserType) Values ('"+coach.SK+"', '"+coach.ActiveStatus+"', '"+coach.ContactNo+"', '"+coach.CreatedDate+"', '"+coach.Email+"', '"+coach.GSI1PK+"', '"+coach.GSI1SK+"', '"+coach.UserId+"', '"+coach.UserName+"', '"+coach.UserType+"'); ";
                    string query1 = "Insert Into [dbo].[UserTable] (UserId,UserName,UserType,Email) Values ('" + coach.UserId + "','" + coach.UserName + "','" + coach.UserType + "','" + coach.Email + "'); ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd1.CommandType = System.Data.CommandType.Text;
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    int j = cmd1.ExecuteNonQuery();
                    con.Close();
                    return i > 0 && j > 0 ? "Y" : "N";
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

        public async Task<string> DeleteCoach(int Id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Delete From [dbo].[CoachTable] Where Id = " + Id.ToString();
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

        public async Task<List<Coach>> GetCoach(string ActiveStatus)
        {
            List<Coach> patients = new List<Coach>();
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Id,SK,ActiveStatus,ContactNo,CreatedDate,Email,GSI1PK,GSI1SK,UserId,UserName,UserType FROM [dbo].[CoachTable] Where ActiveStatus LIKE '" + ActiveStatus.ToString() + "'", con);
                    cmd.CommandType = System.Data.CommandType.Text;
                    DataTable table = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            patients.Add(new Coach
                            {
                                Id = Convert.ToInt32(table.Rows[i]["Id"].ToString()),
                                SK = table.Rows[i]["SK"].ToString(),
                                ActiveStatus = table.Rows[i]["ActiveStatus"].ToString(),
                                ContactNo = table.Rows[i]["ContactNo"].ToString(),
                                CreatedDate = table.Rows[i]["CreatedDate"].ToString(),
                                Email = table.Rows[i]["Email"].ToString(),
                                GSI1PK = table.Rows[i]["GSI1PK"].ToString(),
                                GSI1SK = table.Rows[i]["GSI1SK"].ToString(),

                                UserId = table.Rows[i]["UserId"].ToString(),
                                UserType = table.Rows[i]["UserType"].ToString(),
                                UserName = table.Rows[i]["UserName"].ToString(),


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

        public async Task<string> UpdateCoach(Coach coach)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Update [dbo].[CoachTable] SET SK='" + coach.SK + "',ActiveStatus='" + coach.ActiveStatus + "',ContactNo='" + coach.ContactNo + "',CreatedDate='" + coach.CreatedDate + "',Email='" + coach.Email + "',GSI1PK='" + coach.GSI1PK + "',GSI1SK='" + coach.GSI1SK + "',UserId='" + coach.UserId + "',UserName='" + coach.UserName + "',UserType='" + coach.UserType + "' Where Id = " + coach.Id.ToString();
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
