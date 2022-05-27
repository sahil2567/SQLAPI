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
    public class CareCoordinatorData : ICareCoordinatorData
    {
        private IConfiguration configuration;
        public CareCoordinatorData(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public async Task<string> AddCareCoordinator(CareCoordinator careCoordinator)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Insert Into [dbo].[CareCoordinatorTable] (SK,ActiveStatus,ContactNo,CreatedDate,Email,GSI1PK,GSI1SK,UserId,UserName,UserType) Values ('" + careCoordinator.SK + "', '" + careCoordinator.ActiveStatus + "', '" + careCoordinator.ContactNo + "', '" + careCoordinator.CreatedDate + "', '" + careCoordinator.Email + "', '" + careCoordinator.GSI1PK + "', '" + careCoordinator.GSI1SK + "', '" + careCoordinator.UserId + "', '" + careCoordinator.UserName + "', '" + careCoordinator.UserType + "'); ";
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

        public async Task<string> DeleteCareCoordinator(int Id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Delete From [dbo].[CareCoordinatorTable] Where Id = " + Id.ToString();
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

        public async Task<List<CareCoordinator>> GetCareCoordinator(string ActiveStatus)
        {
            List<CareCoordinator> patients = new List<CareCoordinator>();
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Id,SK,ActiveStatus,ContactNo,CreatedDate,Email,GSI1PK,GSI1SK,UserId,UserName,UserType FROM [dbo].[CareCoordinatorTable] Where ActiveStatus LIKE '" + ActiveStatus.ToString() + "'", con);
                    cmd.CommandType = System.Data.CommandType.Text;
                    DataTable table = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            patients.Add(new CareCoordinator
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

        public async Task<string> UpdateCareCoordinator(CareCoordinator careCoordinator)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Update [dbo].[CareCoordinatorTable] SET SK='" + careCoordinator.SK + "',ActiveStatus='" + careCoordinator.ActiveStatus + "',ContactNo='" + careCoordinator.ContactNo + "',CreatedDate='" + careCoordinator.CreatedDate + "',Email='" + careCoordinator.Email + "',GSI1PK='" + careCoordinator.GSI1PK + "',GSI1SK='" + careCoordinator.GSI1SK + "',UserId='" + careCoordinator.UserId + "',UserName='" + careCoordinator.UserName + "',UserType='" + careCoordinator.UserType + "' Where Id = " + careCoordinator.Id.ToString();
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
