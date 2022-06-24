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
    public class PatientData : IPatientData
    {
        private IConfiguration configuration;
        public PatientData(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public async Task<string> AddPatient(Patient patient)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Insert Into [dbo].[PatientTable] (SK,ActiveStatus,CarecoordinatorId,CarecoordinatorName,City,Coach,CoachId,ConnectionId,ContactNo,CreatedDate,diagnosisId,diastolic,DOB,DoctorId,DoctorName,Email,FirstName,Gender,GSI1PK,GSI1SK,Height,Lang,LastName,MiddleName,MobilePhone,Notes,OTP,ProfileImage,reading,St,Street,systolic,UserId,UserName,UserTimeZone,UserType,Weight,WorkPhone,Zip,DeviceId,DeviceStatus,DeviceType,Program) Values ('" + patient.SK + "','" + patient.ActiveStatus + "','" + patient.CarecoordinatorId + "','" + patient.CarecoordinatorName + "','" + patient.City + "','" + patient.Coach + "','" + patient.CoachId + "','" + patient.ConnectionId + "','" + patient.ContactNo + "','" + patient.CreatedDate + "','" + patient.diagnosisId + "','" + patient.diastolic + "','" + patient.DOB + "','" + patient.DoctorId+"','" + patient.DoctorName + "','" + patient.Email + "','" + patient.FirstName + "','" + patient.Gender + "','" + patient.GSI1PK + "','" + patient.GSI1SK + "','" + patient.Height + "','" + patient.Lang + "','" + patient.LastName + "','" + patient.MiddleName + "','" + patient.MobilePhone + "','" + patient.Notes + "','" + patient.OTP + "','" + patient.ProfileImage + "','" + patient.reading + "','" + patient.St + "','" + patient.Street + "','" + patient.systolic + "','" + patient.UserId + "','" + patient.UserName + "','" + patient.UserTimeZone + "','" + patient.UserType + "','" + patient.Weight + "','" + patient.WorkPhone + "','" + patient.Zip + "','" + patient.DeviceId + "','" + patient.DeviceStatus + "','" + patient.DeviceType + "','" + patient.Program + "'); ";
                    string query1 = "Insert Into [dbo].[UserTable] (UserId,UserName,UserType,Email) Values ('" + patient.UserId + "','" + patient.UserName + "','" + patient.UserType + "','" + patient.Email + "'); ";
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

        public async Task<string> DeletePatient(int Id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Delete From [dbo].[PatientTable] Where Id = " + Id.ToString();
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

        public async Task<List<Patient>> GetPatient(string DoctorId, string ActiveStatus)
        {
            List<Patient> patients = new List<Patient>();
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    if (DoctorId.Contains("DOCTOR"))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Id,SK,ActiveStatus,CarecoordinatorId,CarecoordinatorName,City,Coach,CoachId,ConnectionId,ContactNo,CreatedDate,diagnosisId,diastolic,DOB,DoctorId,DoctorName,Email,FirstName,Gender,GSI1PK,GSI1SK,Height,Lang,LastName,MiddleName,MobilePhone,Notes,OTP,ProfileImage,reading,St,Street,systolic,UserId,UserName,UserTimeZone,UserType,Weight,WorkPhone,Zip,DeviceId,DeviceStatus,DeviceType,Program FROM [dbo].[PatientTable] Where DoctorId LIKE '" + DoctorId.ToString() + "' AND ActiveStatus LIKE '" + ActiveStatus.ToString() + "'", con);
                        cmd.CommandType = System.Data.CommandType.Text;
                        DataTable table = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                patients.Add(new Patient
                                {
                                    Id = Convert.ToInt32(table.Rows[i]["Id"].ToString()),
                                    SK = table.Rows[i]["SK"].ToString(),
                                    ActiveStatus = table.Rows[i]["ActiveStatus"].ToString(),
                                    CarecoordinatorId = table.Rows[i]["CarecoordinatorId"].ToString(),
                                    CarecoordinatorName = table.Rows[i]["CarecoordinatorName"].ToString(),
                                    City = table.Rows[i]["City"].ToString(),
                                    Coach = table.Rows[i]["Coach"].ToString(),
                                    CoachId = table.Rows[i]["CoachId"].ToString(),
                                    ConnectionId = table.Rows[i]["ConnectionId"].ToString(),
                                    ContactNo = table.Rows[i]["ContactNo"].ToString(),
                                    CreatedDate = table.Rows[i]["CreatedDate"].ToString(),
                                    diagnosisId = table.Rows[i]["diagnosisId"].ToString(),
                                    diastolic = table.Rows[i]["diastolic"].ToString(),
                                    DOB = table.Rows[i]["DOB"].ToString(),
                                    DoctorId = table.Rows[i]["DoctorId"].ToString(),
                                    DoctorName = table.Rows[i]["DoctorName"].ToString(),
                                    Email = table.Rows[i]["Email"].ToString(),
                                    FirstName = table.Rows[i]["FirstName"].ToString(),
                                    Gender = table.Rows[i]["Gender"].ToString(),
                                    GSI1PK = table.Rows[i]["GSI1PK"].ToString(),
                                    GSI1SK = table.Rows[i]["GSI1SK"].ToString(),
                                    Height = table.Rows[i]["Height"].ToString(),
                                    Lang = table.Rows[i]["Lang"].ToString(),
                                    LastName = table.Rows[i]["LastName"].ToString(),
                                    MiddleName = table.Rows[i]["MiddleName"].ToString(),
                                    MobilePhone = table.Rows[i]["MobilePhone"].ToString(),
                                    Notes = table.Rows[i]["Notes"].ToString(),
                                    OTP = table.Rows[i]["OTP"].ToString(),
                                    ProfileImage = table.Rows[i]["ProfileImage"].ToString(),
                                    reading = table.Rows[i]["reading"].ToString(),
                                    St = table.Rows[i]["St"].ToString(),
                                    Street = table.Rows[i]["Street"].ToString(),
                                    systolic = table.Rows[i]["systolic"].ToString(),
                                    UserId = table.Rows[i]["UserId"].ToString(),
                                    UserName = table.Rows[i]["UserName"].ToString(),
                                    UserTimeZone = table.Rows[i]["UserTimeZone"].ToString(),
                                    UserType = table.Rows[i]["UserType"].ToString(),
                                    Weight = table.Rows[i]["Weight"].ToString(),
                                    WorkPhone = table.Rows[i]["WorkPhone"].ToString(),
                                    Zip = table.Rows[i]["Zip"].ToString(),
                                    DeviceId = table.Rows[i]["DeviceId"].ToString(),
                                    DeviceStatus = table.Rows[i]["DeviceStatus"].ToString(),
                                    DeviceType = table.Rows[i]["DeviceType"].ToString(),
                                    Program = table.Rows[i]["Program"].ToString(),
                                });
                            }
                        }
                        return patients;
                    }
                    else if (DoctorId.Contains("PATIENT"))
                    {

                        SqlCommand cmd = new SqlCommand("SELECT Id,SK,ActiveStatus,CarecoordinatorId,CarecoordinatorName,City,Coach,CoachId,ConnectionId,ContactNo,CreatedDate,diagnosisId,diastolic,DOB,DoctorId,DoctorName,Email,FirstName,Gender,GSI1PK,GSI1SK,Height,Lang,LastName,MiddleName,MobilePhone,Notes,OTP,ProfileImage,reading,St,Street,systolic,UserId,UserName,UserTimeZone,UserType,Weight,WorkPhone,Zip,DeviceId,DeviceStatus,DeviceType,Program FROM [dbo].[PatientTable] Where SK LIKE '" + DoctorId.ToString() + "' AND ActiveStatus LIKE '" + ActiveStatus.ToString() + "'", con);
                        cmd.CommandType = System.Data.CommandType.Text;
                        DataTable table = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                patients.Add(new Patient
                                {
                                    Id = Convert.ToInt32(table.Rows[i]["Id"].ToString()),
                                    SK = table.Rows[i]["SK"].ToString(),
                                    ActiveStatus = table.Rows[i]["ActiveStatus"].ToString(),
                                    CarecoordinatorId = table.Rows[i]["CarecoordinatorId"].ToString(),
                                    CarecoordinatorName = table.Rows[i]["CarecoordinatorName"].ToString(),
                                    City = table.Rows[i]["City"].ToString(),
                                    Coach = table.Rows[i]["Coach"].ToString(),
                                    CoachId = table.Rows[i]["CoachId"].ToString(),
                                    ConnectionId = table.Rows[i]["ConnectionId"].ToString(),
                                    ContactNo = table.Rows[i]["ContactNo"].ToString(),
                                    CreatedDate = table.Rows[i]["CreatedDate"].ToString(),
                                    diagnosisId = table.Rows[i]["diagnosisId"].ToString(),
                                    diastolic = table.Rows[i]["diastolic"].ToString(),
                                    DOB = table.Rows[i]["DOB"].ToString(),
                                    DoctorId = table.Rows[i]["DoctorId"].ToString(),
                                    DoctorName = table.Rows[i]["DoctorName"].ToString(),
                                    Email = table.Rows[i]["Email"].ToString(),
                                    FirstName = table.Rows[i]["FirstName"].ToString(),
                                    Gender = table.Rows[i]["Gender"].ToString(),
                                    GSI1PK = table.Rows[i]["GSI1PK"].ToString(),
                                    GSI1SK = table.Rows[i]["GSI1SK"].ToString(),
                                    Height = table.Rows[i]["Height"].ToString(),
                                    Lang = table.Rows[i]["Lang"].ToString(),
                                    LastName = table.Rows[i]["LastName"].ToString(),
                                    MiddleName = table.Rows[i]["MiddleName"].ToString(),
                                    MobilePhone = table.Rows[i]["MobilePhone"].ToString(),
                                    Notes = table.Rows[i]["Notes"].ToString(),
                                    OTP = table.Rows[i]["OTP"].ToString(),
                                    ProfileImage = table.Rows[i]["ProfileImage"].ToString(),
                                    reading = table.Rows[i]["reading"].ToString(),
                                    St = table.Rows[i]["St"].ToString(),
                                    Street = table.Rows[i]["Street"].ToString(),
                                    systolic = table.Rows[i]["systolic"].ToString(),
                                    UserId = table.Rows[i]["UserId"].ToString(),
                                    UserName = table.Rows[i]["UserName"].ToString(),
                                    UserTimeZone = table.Rows[i]["UserTimeZone"].ToString(),
                                    UserType = table.Rows[i]["UserType"].ToString(),
                                    Weight = table.Rows[i]["Weight"].ToString(),
                                    WorkPhone = table.Rows[i]["WorkPhone"].ToString(),
                                    Zip = table.Rows[i]["Zip"].ToString(),
                                    DeviceId = table.Rows[i]["DeviceId"].ToString(),
                                    DeviceStatus = table.Rows[i]["DeviceStatus"].ToString(),
                                    DeviceType = table.Rows[i]["DeviceType"].ToString(),
                                    Program = table.Rows[i]["Program"].ToString(),
                                });
                            }
                        }
                        return patients;
                    }
                    else if (DoctorId.Contains("CARECOORDINATOR"))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Id,SK,ActiveStatus,CarecoordinatorId,CarecoordinatorName,City,Coach,CoachId,ConnectionId,ContactNo,CreatedDate,diagnosisId,diastolic,DOB,DoctorId,DoctorName,Email,FirstName,Gender,GSI1PK,GSI1SK,Height,Lang,LastName,MiddleName,MobilePhone,Notes,OTP,ProfileImage,reading,St,Street,systolic,UserId,UserName,UserTimeZone,UserType,Weight,WorkPhone,Zip,DeviceId,DeviceStatus,DeviceType,Program FROM [dbo].[PatientTable] Where CarecoordinatorId LIKE '" + DoctorId.ToString() + "' AND ActiveStatus LIKE '" + ActiveStatus.ToString() + "'", con);
                        cmd.CommandType = System.Data.CommandType.Text;
                        DataTable table = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                patients.Add(new Patient
                                {
                                    Id = Convert.ToInt32(table.Rows[i]["Id"].ToString()),
                                    SK = table.Rows[i]["SK"].ToString(),
                                    ActiveStatus = table.Rows[i]["ActiveStatus"].ToString(),
                                    CarecoordinatorId = table.Rows[i]["CarecoordinatorId"].ToString(),
                                    CarecoordinatorName = table.Rows[i]["CarecoordinatorName"].ToString(),
                                    City = table.Rows[i]["City"].ToString(),
                                    Coach = table.Rows[i]["Coach"].ToString(),
                                    CoachId = table.Rows[i]["CoachId"].ToString(),
                                    ConnectionId = table.Rows[i]["ConnectionId"].ToString(),
                                    ContactNo = table.Rows[i]["ContactNo"].ToString(),
                                    CreatedDate = table.Rows[i]["CreatedDate"].ToString(),
                                    diagnosisId = table.Rows[i]["diagnosisId"].ToString(),
                                    diastolic = table.Rows[i]["diastolic"].ToString(),
                                    DOB = table.Rows[i]["DOB"].ToString(),
                                    DoctorId = table.Rows[i]["DoctorId"].ToString(),
                                    DoctorName = table.Rows[i]["DoctorName"].ToString(),
                                    Email = table.Rows[i]["Email"].ToString(),
                                    FirstName = table.Rows[i]["FirstName"].ToString(),
                                    Gender = table.Rows[i]["Gender"].ToString(),
                                    GSI1PK = table.Rows[i]["GSI1PK"].ToString(),
                                    GSI1SK = table.Rows[i]["GSI1SK"].ToString(),
                                    Height = table.Rows[i]["Height"].ToString(),
                                    Lang = table.Rows[i]["Lang"].ToString(),
                                    LastName = table.Rows[i]["LastName"].ToString(),
                                    MiddleName = table.Rows[i]["MiddleName"].ToString(),
                                    MobilePhone = table.Rows[i]["MobilePhone"].ToString(),
                                    Notes = table.Rows[i]["Notes"].ToString(),
                                    OTP = table.Rows[i]["OTP"].ToString(),
                                    ProfileImage = table.Rows[i]["ProfileImage"].ToString(),
                                    reading = table.Rows[i]["reading"].ToString(),
                                    St = table.Rows[i]["St"].ToString(),
                                    Street = table.Rows[i]["Street"].ToString(),
                                    systolic = table.Rows[i]["systolic"].ToString(),
                                    UserId = table.Rows[i]["UserId"].ToString(),
                                    UserName = table.Rows[i]["UserName"].ToString(),
                                    UserTimeZone = table.Rows[i]["UserTimeZone"].ToString(),
                                    UserType = table.Rows[i]["UserType"].ToString(),
                                    Weight = table.Rows[i]["Weight"].ToString(),
                                    WorkPhone = table.Rows[i]["WorkPhone"].ToString(),
                                    Zip = table.Rows[i]["Zip"].ToString(),
                                    DeviceId = table.Rows[i]["DeviceId"].ToString(),
                                    DeviceStatus = table.Rows[i]["DeviceStatus"].ToString(),
                                    DeviceType = table.Rows[i]["DeviceType"].ToString(),
                                    Program = table.Rows[i]["Program"].ToString(),
                                });
                            }
                        }
                        return patients;
                    }
                    else if (DoctorId.Contains("COACH"))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Id,SK,ActiveStatus,CarecoordinatorId,CarecoordinatorName,City,Coach,CoachId,ConnectionId,ContactNo,CreatedDate,diagnosisId,diastolic,DOB,DoctorId,DoctorName,Email,FirstName,Gender,GSI1PK,GSI1SK,Height,Lang,LastName,MiddleName,MobilePhone,Notes,OTP,ProfileImage,reading,St,Street,systolic,UserId,UserName,UserTimeZone,UserType,Weight,WorkPhone,Zip,DeviceId,DeviceStatus,DeviceType,Program FROM [dbo].[PatientTable] Where CoachId LIKE '" + DoctorId.ToString() + "' AND ActiveStatus LIKE '" + ActiveStatus.ToString() + "'", con);
                        cmd.CommandType = System.Data.CommandType.Text;
                        DataTable table = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                patients.Add(new Patient
                                {
                                    Id = Convert.ToInt32(table.Rows[i]["Id"].ToString()),
                                    SK = table.Rows[i]["SK"].ToString(),
                                    ActiveStatus = table.Rows[i]["ActiveStatus"].ToString(),
                                    CarecoordinatorId = table.Rows[i]["CarecoordinatorId"].ToString(),
                                    CarecoordinatorName = table.Rows[i]["CarecoordinatorName"].ToString(),
                                    City = table.Rows[i]["City"].ToString(),
                                    Coach = table.Rows[i]["Coach"].ToString(),
                                    CoachId = table.Rows[i]["CoachId"].ToString(),
                                    ConnectionId = table.Rows[i]["ConnectionId"].ToString(),
                                    ContactNo = table.Rows[i]["ContactNo"].ToString(),
                                    CreatedDate = table.Rows[i]["CreatedDate"].ToString(),
                                    diagnosisId = table.Rows[i]["diagnosisId"].ToString(),
                                    diastolic = table.Rows[i]["diastolic"].ToString(),
                                    DOB = table.Rows[i]["DOB"].ToString(),
                                    DoctorId = table.Rows[i]["DoctorId"].ToString(),
                                    DoctorName = table.Rows[i]["DoctorName"].ToString(),
                                    Email = table.Rows[i]["Email"].ToString(),
                                    FirstName = table.Rows[i]["FirstName"].ToString(),
                                    Gender = table.Rows[i]["Gender"].ToString(),
                                    GSI1PK = table.Rows[i]["GSI1PK"].ToString(),
                                    GSI1SK = table.Rows[i]["GSI1SK"].ToString(),
                                    Height = table.Rows[i]["Height"].ToString(),
                                    Lang = table.Rows[i]["Lang"].ToString(),
                                    LastName = table.Rows[i]["LastName"].ToString(),
                                    MiddleName = table.Rows[i]["MiddleName"].ToString(),
                                    MobilePhone = table.Rows[i]["MobilePhone"].ToString(),
                                    Notes = table.Rows[i]["Notes"].ToString(),
                                    OTP = table.Rows[i]["OTP"].ToString(),
                                    ProfileImage = table.Rows[i]["ProfileImage"].ToString(),
                                    reading = table.Rows[i]["reading"].ToString(),
                                    St = table.Rows[i]["St"].ToString(),
                                    Street = table.Rows[i]["Street"].ToString(),
                                    systolic = table.Rows[i]["systolic"].ToString(),
                                    UserId = table.Rows[i]["UserId"].ToString(),
                                    UserName = table.Rows[i]["UserName"].ToString(),
                                    UserTimeZone = table.Rows[i]["UserTimeZone"].ToString(),
                                    UserType = table.Rows[i]["UserType"].ToString(),
                                    Weight = table.Rows[i]["Weight"].ToString(),
                                    WorkPhone = table.Rows[i]["WorkPhone"].ToString(),
                                    Zip = table.Rows[i]["Zip"].ToString(),
                                    DeviceId = table.Rows[i]["DeviceId"].ToString(),
                                    DeviceStatus = table.Rows[i]["DeviceStatus"].ToString(),
                                    DeviceType = table.Rows[i]["DeviceType"].ToString(),
                                    Program = table.Rows[i]["Program"].ToString(),
                                });
                            }
                        }
                        return patients;
                    }
                    else 
                    {

                        SqlCommand cmd = new SqlCommand("SELECT Id,SK,ActiveStatus,CarecoordinatorId,CarecoordinatorName,City,Coach,CoachId,ConnectionId,ContactNo,CreatedDate,diagnosisId,diastolic,DOB,DoctorId,DoctorName,Email,FirstName,Gender,GSI1PK,GSI1SK,Height,Lang,LastName,MiddleName,MobilePhone,Notes,OTP,ProfileImage,reading,St,Street,systolic,UserId,UserName,UserTimeZone,UserType,Weight,WorkPhone,Zip,DeviceId,DeviceStatus,DeviceType,Program FROM [dbo].[PatientTable]Where ActiveStatus LIKE '" + ActiveStatus.ToString() + "'", con);
                        cmd.CommandType = System.Data.CommandType.Text;
                        DataTable table = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                patients.Add(new Patient
                                {
                                    Id = Convert.ToInt32(table.Rows[i]["Id"].ToString()),
                                    SK = table.Rows[i]["SK"].ToString(),
                                    ActiveStatus = table.Rows[i]["ActiveStatus"].ToString(),
                                    CarecoordinatorId = table.Rows[i]["CarecoordinatorId"].ToString(),
                                    CarecoordinatorName = table.Rows[i]["CarecoordinatorName"].ToString(),
                                    City = table.Rows[i]["City"].ToString(),
                                    Coach = table.Rows[i]["Coach"].ToString(),
                                    CoachId = table.Rows[i]["CoachId"].ToString(),
                                    ConnectionId = table.Rows[i]["ConnectionId"].ToString(),
                                    ContactNo = table.Rows[i]["ContactNo"].ToString(),
                                    CreatedDate = table.Rows[i]["CreatedDate"].ToString(),
                                    diagnosisId = table.Rows[i]["diagnosisId"].ToString(),
                                    diastolic = table.Rows[i]["diastolic"].ToString(),
                                    DOB = table.Rows[i]["DOB"].ToString(),
                                    DoctorId = table.Rows[i]["DoctorId"].ToString(),
                                    DoctorName = table.Rows[i]["DoctorName"].ToString(),
                                    Email = table.Rows[i]["Email"].ToString(),
                                    FirstName = table.Rows[i]["FirstName"].ToString(),
                                    Gender = table.Rows[i]["Gender"].ToString(),
                                    GSI1PK = table.Rows[i]["GSI1PK"].ToString(),
                                    GSI1SK = table.Rows[i]["GSI1SK"].ToString(),
                                    Height = table.Rows[i]["Height"].ToString(),
                                    Lang = table.Rows[i]["Lang"].ToString(),
                                    LastName = table.Rows[i]["LastName"].ToString(),
                                    MiddleName = table.Rows[i]["MiddleName"].ToString(),
                                    MobilePhone = table.Rows[i]["MobilePhone"].ToString(),
                                    Notes = table.Rows[i]["Notes"].ToString(),
                                    OTP = table.Rows[i]["OTP"].ToString(),
                                    ProfileImage = table.Rows[i]["ProfileImage"].ToString(),
                                    reading = table.Rows[i]["reading"].ToString(),
                                    St = table.Rows[i]["St"].ToString(),
                                    Street = table.Rows[i]["Street"].ToString(),
                                    systolic = table.Rows[i]["systolic"].ToString(),
                                    UserId = table.Rows[i]["UserId"].ToString(),
                                    UserName = table.Rows[i]["UserName"].ToString(),
                                    UserTimeZone = table.Rows[i]["UserTimeZone"].ToString(),
                                    UserType = table.Rows[i]["UserType"].ToString(),
                                    Weight = table.Rows[i]["Weight"].ToString(),
                                    WorkPhone = table.Rows[i]["WorkPhone"].ToString(),
                                    Zip = table.Rows[i]["Zip"].ToString(),
                                    DeviceId = table.Rows[i]["DeviceId"].ToString(),
                                    DeviceStatus = table.Rows[i]["DeviceStatus"].ToString(),
                                    DeviceType = table.Rows[i]["DeviceType"].ToString(),
                                    Program = table.Rows[i]["Program"].ToString(),
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

        public async Task<string> UpdatePatient(Patient patient)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    string query = "Update [dbo].[PatientTable] SET SK='" + patient.SK + "',ActiveStatus='" + patient.ActiveStatus + "',CarecoordinatorId='" + patient.CarecoordinatorId + "',CarecoordinatorName='" + patient.CarecoordinatorName + "',City='" + patient.City + "',Coach='" + patient.Coach + "',CoachId='" + patient.CoachId + "',ConnectionId='" + patient.ConnectionId + "',ContactNo='" + patient.ContactNo + "',CreatedDate='" + patient.CreatedDate + "',diagnosisId='" + patient.diagnosisId + "',diastolic='" + patient.diastolic + "',DOB='" + patient.DOB + "',DoctorId='" + patient.DoctorId +"',DoctorName='" + patient.DoctorName + "',Email='" + patient.Email + "',FirstName='" + patient.FirstName + "',Gender='" + patient.Gender + "',GSI1PK='" + patient.GSI1PK + "',GSI1SK='" + patient.GSI1SK + "',Height='" + patient.Height + "',Lang='" + patient.Lang + "',LastName='" + patient.LastName + "',MiddleName='" + patient.MiddleName + "',MobilePhone='" + patient.MobilePhone + "',Notes='" + patient.Notes + "',OTP='" + patient.OTP + "',ProfileImage='" + patient.ProfileImage + "',reading='" + patient.reading + "',St='" + patient.St + "',Street='" + patient.Street + "',systolic='" + patient.systolic + "',UserId='" + patient.UserId + "',UserName='" + patient.UserName + "',UserTimeZone='" + patient.UserTimeZone + "',UserType='" + patient.UserType + "',Weight='" + patient.Weight + "',WorkPhone='" + patient.WorkPhone + "',Zip='" + patient.Zip + "',DeviceId='" + patient.DeviceId + "',DeviceStatus='" + patient.DeviceStatus + "',DeviceType='" + patient.DeviceType + "',Program='" + patient.Program + "' Where Id = " + patient.Id.ToString();
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
