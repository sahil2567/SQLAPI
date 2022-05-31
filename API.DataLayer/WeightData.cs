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
    public class WeightData : IWeightData
    {
        private IConfiguration configuration;
        public WeightData(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public async Task<string> AddWeight(Weight weight)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Insert Into [dbo].[WeightTable] (SK,ActionTaken,BatteryVoltage,BMI,CreatedDate,Date_Received,Date_Recorded,DeviceId,GSI1PK,GSI1SK,IMEI,MeasurementDateTime,MeasurementTimestamp,RSSI,SignalStrength,Tare,TimeSlots,Unit,UserName,weight) Values ('" + weight.SK + "','" + weight.ActionTaken + "','" + weight.BatteryVoltage + "','" + weight.BMI + "','" + weight.CreatedDate + "','" + weight.Date_Received + "','" + weight.Date_Recorded + "','" + weight.DeviceId + "','" + weight.GSI1PK + "','" + weight.GSI1SK + "','" + weight.IMEI + "','" + weight.MeasurementDateTime + "','" + weight.MeasurementTimestamp + "','" + weight.RSSI+"','" + weight.SignalStrength + "','" + weight.Tare + "','" + weight.TimeSlots + "','" + weight.Unit + "','" + weight.UserName + "','" + weight.weight + "');";


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

        public async Task<string> DeleteWeight(int Id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Delete From [dbo].[WeightTable] Where Id = " + Id.ToString();
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

        public async Task<List<Weight>> GetWeight(string GSI1PK)
        {
            List<Weight> patients = new List<Weight>();
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    if (Equals(GSI1PK, "DEVICE_WS_"))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Id,SK,ActionTaken,BatteryVoltage,BMI,CreatedDate,Date_Received,Date_Recorded,DeviceId,GSI1PK,GSI1SK,IMEI,MeasurementDateTime,MeasurementTimestamp,RSSI,SignalStrength,Tare,TimeSlots,Unit,UserName,weight FROM [dbo].[WeightTable]", con);
                        cmd.CommandType = System.Data.CommandType.Text;
                        DataTable table = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                patients.Add(new Weight
                                {
                                    Id = Convert.ToInt32(table.Rows[i]["Id"].ToString()),
                                    SK = table.Rows[i]["SK"].ToString(),
                                    ActionTaken = table.Rows[i]["ActionTaken"].ToString(),
                                    BatteryVoltage = table.Rows[i]["BatteryVoltage"].ToString(),
                                    BMI = table.Rows[i]["BMI"].ToString(),
                                    CreatedDate = table.Rows[i]["CreatedDate"].ToString(),
                                    Date_Received = table.Rows[i]["Date_Received"].ToString(),
                                    Date_Recorded = table.Rows[i]["Date_Recorded"].ToString(),
                                    DeviceId = table.Rows[i]["DeviceId"].ToString(),
                                    GSI1PK = table.Rows[i]["GSI1PK"].ToString(),
                                    GSI1SK = table.Rows[i]["GSI1SK"].ToString(),
                                    IMEI = table.Rows[i]["IMEI"].ToString(),
                                    MeasurementDateTime = table.Rows[i]["MeasurementDateTime"].ToString(),
                                    MeasurementTimestamp = table.Rows[i]["MeasurementTimestamp"].ToString(),
                                    RSSI = table.Rows[i]["RSSI"].ToString(),
                                    SignalStrength = table.Rows[i]["SignalStrength"].ToString(),
                                    Tare = table.Rows[i]["Tare"].ToString(),
                                    TimeSlots = table.Rows[i]["TimeSlots"].ToString(),
                                    Unit = table.Rows[i]["Unit"].ToString(),
                                    UserName = table.Rows[i]["UserName"].ToString(),
                                    weight = table.Rows[i]["weight"].ToString(),


                                });
                            }
                        }
                        return patients;
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Id,SK,ActionTaken,BatteryVoltage,BMI,CreatedDate,Date_Received,Date_Recorded,DeviceId,GSI1PK,GSI1SK,IMEI,MeasurementDateTime,MeasurementTimestamp,RSSI,SignalStrength,Tare,TimeSlots,Unit,UserName,weight FROM [dbo].[WeightTable] Where GSI1PK LIKE '" + GSI1PK.ToString() + "'", con);
                        cmd.CommandType = System.Data.CommandType.Text;
                        DataTable table = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                patients.Add(new Weight
                                {
                                    Id = Convert.ToInt32(table.Rows[i]["Id"].ToString()),
                                    SK = table.Rows[i]["SK"].ToString(),
                                    ActionTaken = table.Rows[i]["ActionTaken"].ToString(),
                                    BatteryVoltage = table.Rows[i]["BatteryVoltage"].ToString(),
                                    BMI = table.Rows[i]["BMI"].ToString(),
                                    CreatedDate = table.Rows[i]["CreatedDate"].ToString(),
                                    Date_Received = table.Rows[i]["Date_Received"].ToString(),
                                    Date_Recorded = table.Rows[i]["Date_Recorded"].ToString(),
                                    DeviceId = table.Rows[i]["DeviceId"].ToString(),
                                    GSI1PK = table.Rows[i]["GSI1PK"].ToString(),
                                    GSI1SK = table.Rows[i]["GSI1SK"].ToString(),
                                    IMEI = table.Rows[i]["IMEI"].ToString(),
                                    MeasurementDateTime = table.Rows[i]["MeasurementDateTime"].ToString(),
                                    MeasurementTimestamp = table.Rows[i]["MeasurementTimestamp"].ToString(),
                                    RSSI = table.Rows[i]["RSSI"].ToString(),
                                    SignalStrength = table.Rows[i]["SignalStrength"].ToString(),
                                    Tare = table.Rows[i]["Tare"].ToString(),
                                    TimeSlots = table.Rows[i]["TimeSlots"].ToString(),
                                    Unit = table.Rows[i]["Unit"].ToString(),
                                    UserName = table.Rows[i]["UserName"].ToString(),
                                    weight = table.Rows[i]["weight"].ToString(),


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

        public async Task<string> UpdateWeight(Weight weight)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Update [dbo].[WeightTable] SET SK='" + weight.SK + "',ActionTaken='" + weight.ActionTaken + "',BatteryVoltage='" + weight.BatteryVoltage + "',BMI='" + weight.BMI + "',CreatedDate='" + weight.CreatedDate + "',Date_Received='" + weight.Date_Received + "',Date_Recorded='" + weight.Date_Recorded + "',DeviceId='" + weight.DeviceId + "',GSI1PK='" + weight.GSI1PK + "',GSI1SK='" + weight.GSI1SK + "',IMEI='" + weight.IMEI + "',MeasurementDateTime='" + weight.MeasurementDateTime + "',MeasurementTimestamp='" + weight.MeasurementTimestamp + "',RSSI='" + weight.RSSI + "',SignalStrength='" + weight.SignalStrength + "',Tare='" + weight.Tare + "',TimeSlots='" + weight.TimeSlots + "',Unit='" + weight.Unit + "',UserName='" + weight.UserName + "',Weight='" + weight.weight + "' Where Id = " + weight.Id.ToString();
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
