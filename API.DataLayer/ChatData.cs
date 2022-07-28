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
    public class ChatData : IChatData
    {
        private IConfiguration configuration;
        public ChatData(IConfiguration _configuration)
        {
            configuration = _configuration;
        }


        public async Task<List<Chat>> GetChat(int ReceiverId)
        {
            List<Chat> patients = new List<Chat>();
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DBConnectionString").ToString()))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Chat] Where ReceiverId = "+ReceiverId+"", con);
                    cmd.CommandType = System.Data.CommandType.Text;
                    DataTable table = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            patients.Add(new Chat
                            {
                                ChatId = Convert.ToInt32(table.Rows[i]["ChatId"].ToString()),
                                SenderId = table.Rows[i]["SenderId"].ToString(),
                                ReceiverId = table.Rows[i]["ReceiverId"].ToString(),
                                ChatLink = table.Rows[i]["ChatLink"].ToString(),
                                
                                

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

    }
}
