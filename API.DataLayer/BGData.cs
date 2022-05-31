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
    public class BGData : IBGData
    {
        private IConfiguration configuration;
        public BGData(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public async Task<string> AddBG(BG bg)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Insert Into [dbo].[BloodGlucoseTable] (SK,ActionTaken,ActiveStatus,Battery,BatteryVoltage,Before_Meal,BloodGlucosemgdl,BloodGlucosemmol,CreatedDate,Date_Received,Date_Recorded,Device_Model,DeviceId,Event_Flag,GSI1PK,GSI1SK,MeasurementDateTime,Meter_Id,Reading,Reading_Id,Reading_Type,SignalStrength,Time_Zone_Offset,TimeSlots,UpdateDate,UserName) Values ('" + bg.SK + "','" + bg.ActionTaken + "','" + bg.ActiveStatus + "','" + bg.Battery + "','" + bg.BatteryVoltage + "','" + bg.Before_Meal + "','" + bg.BloodGlucosemgdl + "','" + bg.BloodGlucosemmol + "','" + bg.CreatedDate + "','" + bg.Date_Received + "','" + bg.Date_Recorded + "','" + bg.Device_Model + "','" + bg.DeviceId + "','" + bg.Event_Flag + "','" + bg.GSI1PK + "','" + bg.GSI1SK + "','" + bg.MeasurementDateTime + "','" + bg.Meter_Id + "','" + bg.Reading + "','" + bg.Reading_Id + "','" + bg.Reading_Type + "','" + bg.SignalStrength + "','" + bg.Time_Zone_Offset + "','" + bg.TimeSlots + "','" + bg.UpdateDate + "','" + bg.UserName + "');";
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

        public async Task<string> DeleteBG(int Id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Delete From [dbo].[BloodGlucoseTable] Where Id = " + Id.ToString();
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

        public async Task<List<BG>> GetBG(string GSI1PK)
        {
            List<BG> patients = new List<BG>();
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    if (Equals(GSI1PK, "DEVICE_BG_"))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Id,SK,ActionTaken,ActiveStatus,Battery,BatteryVoltage,Before_Meal,BloodGlucosemgdl,BloodGlucosemmol,CreatedDate,Date_Received,Date_Recorded,Device_Model,DeviceId,Event_Flag,GSI1PK,GSI1SK,MeasurementDateTime,Meter_Id,Reading,Reading_Id,Reading_Type,SignalStrength,Time_Zone_Offset,TimeSlots,UpdateDate,UserName FROM [dbo].[BloodGlucoseTable]", con);
                        cmd.CommandType = System.Data.CommandType.Text;
                        DataTable table = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                patients.Add(new BG
                                {
                                    Id = Convert.ToInt32(table.Rows[i]["Id"].ToString()),
                                    SK = table.Rows[i]["SK"].ToString(),
                                    ActionTaken = table.Rows[i]["ActionTaken"].ToString(),
                                    ActiveStatus = table.Rows[i]["ActiveStatus"].ToString(),
                                    Battery = table.Rows[i]["Battery"].ToString(),
                                    BatteryVoltage = table.Rows[i]["BatteryVoltage"].ToString(),
                                    Before_Meal = table.Rows[i]["Before_Meal"].ToString(),
                                    BloodGlucosemgdl = table.Rows[i]["BloodGlucosemgdl"].ToString(),
                                    BloodGlucosemmol = table.Rows[i]["BloodGlucosemmol"].ToString(),
                                    CreatedDate = table.Rows[i]["CreatedDate"].ToString(),
                                    Date_Received = table.Rows[i]["Date_Received"].ToString(),
                                    Date_Recorded = table.Rows[i]["Date_Recorded"].ToString(),
                                    Device_Model = table.Rows[i]["Device_Model"].ToString(),
                                    DeviceId = table.Rows[i]["DeviceId"].ToString(),
                                    Event_Flag = table.Rows[i]["Event_Flag"].ToString(),
                                    GSI1PK = table.Rows[i]["GSI1PK"].ToString(),
                                    GSI1SK = table.Rows[i]["GSI1SK"].ToString(),
                                    MeasurementDateTime = table.Rows[i]["MeasurementDateTime"].ToString(),
                                    Meter_Id = table.Rows[i]["Meter_Id"].ToString(),
                                    Reading = table.Rows[i]["Reading"].ToString(),
                                    Reading_Id = table.Rows[i]["Reading_Id"].ToString(),
                                    Reading_Type = table.Rows[i]["Reading_Type"].ToString(),
                                    SignalStrength = table.Rows[i]["SignalStrength"].ToString(),
                                    Time_Zone_Offset = table.Rows[i]["Time_Zone_Offset"].ToString(),
                                    TimeSlots = table.Rows[i]["TimeSlots"].ToString(),
                                    UpdateDate = table.Rows[i]["UpdateDate"].ToString(),
                                    UserName = table.Rows[i]["UserName"].ToString(),


                                });
                            }
                        }
                        return patients;

                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Id,SK,ActionTaken,ActiveStatus,Battery,BatteryVoltage,Before_Meal,BloodGlucosemgdl,BloodGlucosemmol,CreatedDate,Date_Received,Date_Recorded,Device_Model,DeviceId,Event_Flag,GSI1PK,GSI1SK,MeasurementDateTime,Meter_Id,Reading,Reading_Id,Reading_Type,SignalStrength,Time_Zone_Offset,TimeSlots,UpdateDate,UserName FROM [dbo].[BloodGlucoseTable] Where GSI1PK LIKE '" + GSI1PK.ToString() + "'", con);
                        cmd.CommandType = System.Data.CommandType.Text;
                        DataTable table = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                patients.Add(new BG
                                {
                                    Id = Convert.ToInt32(table.Rows[i]["Id"].ToString()),
                                    SK = table.Rows[i]["SK"].ToString(),
                                    ActionTaken = table.Rows[i]["ActionTaken"].ToString(),
                                    ActiveStatus = table.Rows[i]["ActiveStatus"].ToString(),
                                    Battery = table.Rows[i]["Battery"].ToString(),
                                    BatteryVoltage = table.Rows[i]["BatteryVoltage"].ToString(),
                                    Before_Meal = table.Rows[i]["Before_Meal"].ToString(),
                                    BloodGlucosemgdl = table.Rows[i]["BloodGlucosemgdl"].ToString(),
                                    BloodGlucosemmol = table.Rows[i]["BloodGlucosemmol"].ToString(),
                                    CreatedDate = table.Rows[i]["CreatedDate"].ToString(),
                                    Date_Received = table.Rows[i]["Date_Received"].ToString(),
                                    Date_Recorded = table.Rows[i]["Date_Recorded"].ToString(),
                                    Device_Model = table.Rows[i]["Device_Model"].ToString(),
                                    DeviceId = table.Rows[i]["DeviceId"].ToString(),
                                    Event_Flag = table.Rows[i]["Event_Flag"].ToString(),
                                    GSI1PK = table.Rows[i]["GSI1PK"].ToString(),
                                    GSI1SK = table.Rows[i]["GSI1SK"].ToString(),
                                    MeasurementDateTime = table.Rows[i]["MeasurementDateTime"].ToString(),
                                    Meter_Id = table.Rows[i]["Meter_Id"].ToString(),
                                    Reading = table.Rows[i]["Reading"].ToString(),
                                    Reading_Id = table.Rows[i]["Reading_Id"].ToString(),
                                    Reading_Type = table.Rows[i]["Reading_Type"].ToString(),
                                    SignalStrength = table.Rows[i]["SignalStrength"].ToString(),
                                    Time_Zone_Offset = table.Rows[i]["Time_Zone_Offset"].ToString(),
                                    TimeSlots = table.Rows[i]["TimeSlots"].ToString(),
                                    UpdateDate = table.Rows[i]["UpdateDate"].ToString(),
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

        public async Task<string> UpdateBG(BG bg)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Update [dbo].[BloodGlucoseTable] SET SK='" + bg.SK + "',ActionTaken='" + bg.ActionTaken + "',ActiveStatus='" + bg.ActiveStatus + "',Battery='" + bg.Battery + "',BatteryVoltage='" + bg.BatteryVoltage + "',Before_Meal='" + bg.Before_Meal + "',BloodGlucosemgdl='" + bg.BloodGlucosemgdl + "',BloodGlucosemmol='" + bg.BloodGlucosemmol + "',CreatedDate='" + bg.CreatedDate + "',Date_Received='" + bg.Date_Received + "',Date_Recorded='" + bg.Date_Recorded + "',Device_Model='" + bg.Device_Model + "',DeviceId='" + bg.DeviceId + "',Event_Flag='" + bg.Event_Flag + "',GSI1PK='" + bg.GSI1PK + "',GSI1SK='" + bg.GSI1SK + "',MeasurementDateTime='" + bg.MeasurementDateTime + "',Meter_Id='" + bg.Meter_Id + "',Reading='" + bg.Reading + "',Reading_Id='" + bg.Reading_Id + "',Reading_Type='" + bg.Reading_Type + "',SignalStrength='" + bg.SignalStrength + "',Time_Zone_Offset='" + bg.Time_Zone_Offset + "',TimeSlots='" + bg.TimeSlots + "',UpdateDate='" + bg.UpdateDate + "',UserName='" + bg.UserName + "' Where Id = " + bg.Id.ToString();
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
