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
    public class BPData : IBPData
    {
        private IConfiguration configuration;
        public BPData(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public async Task<string> AddBP(BP bp)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Insert Into [dbo].[BloodPressureTable] (SK, ActionTaken, BatteryVoltage, CreatedDate, Date_Received, Date_Recorded, DeviceId,Diastolic,GSI1PK,GSI1SK,IMEI,Irregular,MeasurementDateTime,MeasurementTimestamp,Pulse,SignalStrength,Systolic,TimeSlots,Unit,UserName) Values ('" + bp.SK + "', '" + bp.ActionTaken + "', '" + bp.BatteryVoltage + "', '" + bp.CreatedDate + "', '" + bp.Date_Received + "', '" + bp.Date_Recorded + "', '" + bp.DeviceId + "','" + bp.Diastolic + "','" + bp.GSI1PK + "','" + bp.GSI1SK + "','" + bp.IMEI + "','" + bp.Irregular + "','" + bp.MeasurementDateTime + "','" + bp.MeasurementTimestamp + "','" + bp.Pulse + "','" + bp.SignalStrength + "','" + bp.Systolic + "','" + bp.TimeSlots + "','" + bp.Unit + "','" + bp.UserName + "');";
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

        public async Task<string> DeleteBP(int Id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Delete From [dbo].[BloodPressureTable] Where Id = " + Id.ToString();
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

        public async Task<List<BP>> GetBP(string GSI1PK)
        {
            List<BP> patients = new List<BP>();
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    if (Equals(GSI1PK, "DEVICE_BP_"))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Id,SK, ActionTaken, BatteryVoltage, CreatedDate, Date_Received, Date_Recorded, DeviceId,Diastolic,GSI1PK,GSI1SK,IMEI,Irregular,MeasurementDateTime,MeasurementTimestamp,Pulse,SignalStrength,Systolic,TimeSlots,Unit,UserName FROM [dbo].[BloodPressureTable]", con);
                        cmd.CommandType = System.Data.CommandType.Text;
                        DataTable table = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                patients.Add(new BP
                                {
                                    Id = Convert.ToInt32(table.Rows[i]["Id"].ToString()),
                                    SK = table.Rows[i]["SK"].ToString(),
                                    ActionTaken = table.Rows[i]["ActionTaken"].ToString(),
                                    BatteryVoltage = table.Rows[i]["BatteryVoltage"].ToString(),
                                    CreatedDate = table.Rows[i]["CreatedDate"].ToString(),
                                    Date_Received = table.Rows[i]["Date_Received"].ToString(),
                                    Date_Recorded = table.Rows[i]["Date_Recorded"].ToString(),
                                    DeviceId = table.Rows[i]["DeviceId"].ToString(),
                                    Diastolic = table.Rows[i]["Diastolic"].ToString(),
                                    GSI1PK = table.Rows[i]["GSI1PK"].ToString(),
                                    GSI1SK = table.Rows[i]["GSI1SK"].ToString(),
                                    IMEI = table.Rows[i]["IMEI"].ToString(),
                                    Irregular = table.Rows[i]["Irregular"].ToString(),
                                    MeasurementDateTime = table.Rows[i]["MeasurementDateTime"].ToString(),
                                    MeasurementTimestamp = table.Rows[i]["MeasurementTimestamp"].ToString(),
                                    Pulse = table.Rows[i]["Pulse"].ToString(),
                                    SignalStrength = table.Rows[i]["SignalStrength"].ToString(),
                                    Systolic = table.Rows[i]["Systolic"].ToString(),
                                    TimeSlots = table.Rows[i]["TimeSlots"].ToString(),
                                    Unit = table.Rows[i]["Unit"].ToString(),
                                    UserName = table.Rows[i]["UserName"].ToString(),
                                });
                            }
                        }
                        return patients;
                    

                }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Id,SK, ActionTaken, BatteryVoltage, CreatedDate, Date_Received, Date_Recorded, DeviceId,Diastolic,GSI1PK,GSI1SK,IMEI,Irregular,MeasurementDateTime,MeasurementTimestamp,Pulse,SignalStrength,Systolic,TimeSlots,Unit,UserName FROM [dbo].[BloodPressureTable] Where GSI1PK LIKE '" + GSI1PK.ToString() + "'", con);
                        cmd.CommandType = System.Data.CommandType.Text;
                        DataTable table = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                patients.Add(new BP
                                {
                                    Id = Convert.ToInt32(table.Rows[i]["Id"].ToString()),
                                    SK = table.Rows[i]["SK"].ToString(),
                                    ActionTaken = table.Rows[i]["ActionTaken"].ToString(),
                                    BatteryVoltage = table.Rows[i]["BatteryVoltage"].ToString(),
                                    CreatedDate = table.Rows[i]["CreatedDate"].ToString(),
                                    Date_Received = table.Rows[i]["Date_Received"].ToString(),
                                    Date_Recorded = table.Rows[i]["Date_Recorded"].ToString(),
                                    DeviceId = table.Rows[i]["DeviceId"].ToString(),
                                    Diastolic = table.Rows[i]["Diastolic"].ToString(),
                                    GSI1PK = table.Rows[i]["GSI1PK"].ToString(),
                                    GSI1SK = table.Rows[i]["GSI1SK"].ToString(),
                                    IMEI = table.Rows[i]["IMEI"].ToString(),
                                    Irregular = table.Rows[i]["Irregular"].ToString(),
                                    MeasurementDateTime = table.Rows[i]["MeasurementDateTime"].ToString(),
                                    MeasurementTimestamp = table.Rows[i]["MeasurementTimestamp"].ToString(),
                                    Pulse = table.Rows[i]["Pulse"].ToString(),
                                    SignalStrength = table.Rows[i]["SignalStrength"].ToString(),
                                    Systolic = table.Rows[i]["Systolic"].ToString(),
                                    TimeSlots = table.Rows[i]["TimeSlots"].ToString(),
                                    Unit = table.Rows[i]["Unit"].ToString(),
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

        public async Task<string> UpdateBP(BP bp)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Update [dbo].[BloodPressureTable] SET SK='" + bp.SK + "',ActionTaken= '" + bp.ActionTaken + "', BatteryVoltage ='" + bp.BatteryVoltage + "',CreatedDate= '" + bp.CreatedDate + "', Date_Received = '" + bp.Date_Received + "', Date_Recorded = '" + bp.Date_Recorded + "',DeviceId = '" + bp.DeviceId + "',Diastolic='" + bp.Diastolic + "',GSI1PK='" + bp.GSI1PK + "',GSI1SK='" + bp.GSI1SK + "',IMEI='" + bp.IMEI + "',Irregular='" + bp.Irregular + "',MeasurementDateTime='" + bp.MeasurementDateTime + "',MeasurementTimestamp='" + bp.MeasurementTimestamp + "',Pulse='" + bp.Pulse + "',SignalStrength='" + bp.SignalStrength + "',Systolic='" + bp.Systolic + "',TimeSlots='" + bp.TimeSlots + "',Unit='" + bp.Unit + "',UserName='" + bp.UserName + "' Where Id = " + bp.Id.ToString();
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
