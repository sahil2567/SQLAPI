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
    public class DeviceData : IDeviceData
    {
        private IConfiguration configuration;
        public DeviceData(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public async Task<string> AddDevice(Device device)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Insert Into [dbo].[DeviceTable] (SK, GSI1PK, DeviceId, DeviceType) Values ('" + device.SK + "','" + device.GSI1PK + "','" + device.DeviceId + "','" + device.DeviceType + "');";


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

        public async Task<string> DeleteDevice(int Id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Delete From [dbo].[DeviceTable] Where Id = " + Id.ToString();
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

        public async Task<List<Device>> GetDevice()
        {
            List<Device> patients = new List<Device>();
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Id,SK, GSI1PK, DeviceId, DeviceType FROM [dbo].[DeviceTable]", con);
                    cmd.CommandType = System.Data.CommandType.Text;
                    DataTable table = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            patients.Add(new Device
                            {
                                Id = Convert.ToInt32(table.Rows[i]["Id"].ToString()),
                                SK = table.Rows[i]["SK"].ToString(),
                                GSI1PK = table.Rows[i]["GSI1PK"].ToString(),
                                DeviceId = table.Rows[i]["DeviceId"].ToString(),
                                DeviceType = table.Rows[i]["DeviceType"].ToString(),


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

        public async Task<string> UpdateDevice(Device device)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Update [dbo].[DeviceTable] SET SK='" + device.SK + "',GSI1PK='" + device.GSI1PK + "',DeviceId='" + device.DeviceId + "',DeviceType='" + device.DeviceType + "' Where Id = " + device.Id.ToString();
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
