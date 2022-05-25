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
    public class TimeLogData : ITimeLogData
    {
        private IConfiguration configuration;
        public TimeLogData(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public async Task<string> AddTimeLog(TimeLog timeLog)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Insert Into [dbo].[TimeLogTable] (SK,ActiveStatus,CreatedDate,EndDT,GSI1PK,GSI1SK,PerformedBy,PerformedOn,StartDT,TaskType,TimeAmount,UserName) Values ('" + timeLog.SK + "','" + timeLog.ActiveStatus + "','" + timeLog.CreatedDate + "','" + timeLog.EndDT + "','" + timeLog.GSI1PK + "','" + timeLog.GSI1SK + "','" + timeLog.PerformedBy + "','" + timeLog.PerformedOn + "','" + timeLog.StartDT + "','" + timeLog.TaskType + "','" + timeLog.TimeAmount + "','" + timeLog.UserName + "'); ";
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

        public async Task<string> DeleteTimeLog(int Id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Delete From [dbo].[TimeLogTable] Where Id = " + Id.ToString();
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

        public async Task<List<TimeLog>> GetTimeLog(string GSI1PK)
        {
            List<TimeLog> patients = new List<TimeLog>();
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    if (Equals(GSI1PK,"TIMELOG_READING_"))
                    {
                         SqlCommand  cmd = new SqlCommand("SELECT Id,SK,ActiveStatus,CreatedDate,EndDT,GSI1PK,GSI1SK,PerformedBy,PerformedOn,StartDT,TaskType,TimeAmount,UserName FROM [dbo].[TimeLogTable]", con);
                        cmd.CommandType = System.Data.CommandType.Text;
                        DataTable table = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                patients.Add(new TimeLog
                                {
                                    Id = Convert.ToInt32(table.Rows[i]["Id"].ToString()),
                                    SK = table.Rows[i]["SK"].ToString(),
                                    ActiveStatus = table.Rows[i]["ActiveStatus"].ToString(),
                                    EndDT = table.Rows[i]["EndDT"].ToString(),
                                    CreatedDate = table.Rows[i]["CreatedDate"].ToString(),
                                    PerformedBy = table.Rows[i]["PerformedBy"].ToString(),
                                    GSI1PK = table.Rows[i]["GSI1PK"].ToString(),
                                    GSI1SK = table.Rows[i]["GSI1SK"].ToString(),
                                    PerformedOn = table.Rows[i]["PerformedOn"].ToString(),
                                    StartDT = table.Rows[i]["StartDT"].ToString(),
                                    TaskType = table.Rows[i]["TaskType"].ToString(),
                                    TimeAmount = table.Rows[i]["TimeAmount"].ToString(),
                                    UserName = table.Rows[i]["UserName"].ToString(),


                                });
                            }
                        }
                        return patients;
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Id,SK,ActiveStatus,CreatedDate,EndDT,GSI1PK,GSI1SK,PerformedBy,PerformedOn,StartDT,TaskType,TimeAmount,UserName FROM [dbo].[TimeLogTable] Where GSI1PK LIKE '" + GSI1PK.ToString()+"'" , con);
                        cmd.CommandType = System.Data.CommandType.Text;
                        DataTable table = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                patients.Add(new TimeLog
                                {
                                    Id = Convert.ToInt32(table.Rows[i]["Id"].ToString()),
                                    SK = table.Rows[i]["SK"].ToString(),
                                    ActiveStatus = table.Rows[i]["ActiveStatus"].ToString(),
                                    EndDT = table.Rows[i]["EndDT"].ToString(),
                                    CreatedDate = table.Rows[i]["CreatedDate"].ToString(),
                                    PerformedBy = table.Rows[i]["PerformedBy"].ToString(),
                                    GSI1PK = table.Rows[i]["GSI1PK"].ToString(),
                                    GSI1SK = table.Rows[i]["GSI1SK"].ToString(),
                                    PerformedOn = table.Rows[i]["PerformedOn"].ToString(),
                                    StartDT = table.Rows[i]["StartDT"].ToString(),
                                    TaskType = table.Rows[i]["TaskType"].ToString(),
                                    TimeAmount = table.Rows[i]["TimeAmount"].ToString(),
                                    UserName = table.Rows[i]["UserName"].ToString(),


                                });
                            }
                        }
                        return patients;
                    }
                   
                   
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

        public async Task<string> UpdateTimeLog(TimeLog timeLog)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Update [dbo].[TimeLogTable] SET SK='" + timeLog.SK + "',ActiveStatus='" + timeLog.ActiveStatus + "',CreatedDate='" + timeLog.CreatedDate + "',EndDT='" + timeLog.EndDT + "',GSI1PK='" + timeLog.GSI1PK + "',GSI1SK='" + timeLog.GSI1SK + "',PerformedBy='" + timeLog.PerformedBy + "',PerformedOn='" + timeLog.PerformedOn + "',StartDT='" + timeLog.StartDT + "',TaskType='" + timeLog.TaskType+"',TimeAmount='" + timeLog.TimeAmount + "',UserName='" + timeLog.UserName + "' Where Id = " + timeLog.Id.ToString();
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
