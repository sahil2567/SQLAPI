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
    public class DoctorData : IDoctorData
    {
        private IConfiguration configuration;
        public DoctorData(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public async Task<string> AddDoctor(Doctor doctor)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Insert Into [dbo].[DoctorTable] (SK,ActiveStatus,ContactNo,CreatedDate,Email,GSI1PK,GSI1SK,UserId,UserName,UserType) Values ('"+doctor.SK+"', '"+doctor.ActiveStatus+"', '"+doctor.ContactNo+"', '"+doctor.CreatedDate+"', '"+doctor.Email+"', '"+doctor.GSI1PK+"', '"+doctor.GSI1SK+"', '"+doctor.UserId+"', '"+doctor.UserName+"', '"+doctor.UserType+"'); ";
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

        public async Task<string> DeleteDoctor(int Id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Delete From [dbo].[DoctorTable] Where Id = " + Id.ToString();
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

        public async Task<List<Doctor>> GetDoctor( string ActiveStatus)
        {
            List<Doctor> patients = new List<Doctor>();
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Id,SK,ActiveStatus,ContactNo,CreatedDate,Email,GSI1PK,GSI1SK,UserId,UserName,UserType FROM [dbo].[DoctorTable] Where ActiveStatus LIKE '" + ActiveStatus.ToString() + "'", con);
                    cmd.CommandType = System.Data.CommandType.Text;
                    DataTable table = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            patients.Add(new Doctor
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

        public async Task<string> UpdateDoctor(Doctor doctor)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Update [dbo].[DoctorTable] SET SK='" + doctor.SK + "',ActiveStatus='" + doctor.ActiveStatus + "',ContactNo='" + doctor.ContactNo + "',CreatedDate='" + doctor.CreatedDate + "',Email='" + doctor.Email + "',GSI1PK='" + doctor.GSI1PK + "',GSI1SK='" + doctor.GSI1SK + "',UserId='" + doctor.UserId + "',UserName='" + doctor.UserName + "',UserType='" + doctor.UserType + "' Where Id = " + doctor.Id.ToString();
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
