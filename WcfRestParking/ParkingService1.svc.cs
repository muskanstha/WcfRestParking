using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfRestParking.Models;

namespace WcfRestParking
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ParkingService1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ParkingService1.svc or ParkingService1.svc.cs at the Solution Explorer and start debugging.
    public class ParkingService1 : IParkingService1
    {
        private static string connectionString = "Server=tcp:parkingdbs.database.windows.net,1433;Initial Catalog=ParkingDB;Persist Security Info=False;User ID=parkingdbs;Password=Namaste977;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public IList<Status> GetStatuses()
        {
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                string query = "SELECT  * FROM Status";
                SqlCommand getDestListCommand = new SqlCommand(query, databaseConnection);

                List<Status> aStatuses = new List<Status>();

                using (SqlDataReader reader = getDestListCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        aStatuses.Add(new Status(reader.GetString(0), reader.GetString(1), reader.GetDecimal(2)));
                    }
                }
                return aStatuses;
            }
        }

        public IList<Status> CreateStatus(Status aStatus)
        {
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                string query = "INSERT Status (SpotNo,IsFree,Distance) VALUES (@SpotNo,@IsFree,@Distance)";
                SqlCommand addCommand = new SqlCommand(query, databaseConnection);
                addCommand.Parameters.AddWithValue("@SpotNo", aStatus.SpotNo);
                addCommand.Parameters.AddWithValue("@IsFree", aStatus.IsFree);
                addCommand.Parameters.AddWithValue("@Distance", aStatus.Distance);

                int rowsAffected = addCommand.ExecuteNonQuery();

                return GetStatuses();
            }
        }

        public IList<Status> ChangeStatus(Status aStatus)
        {
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                string query = "UPDATE Status SET IsFree = @IsFree, Distance = @Distance WHERE SpotNo = @SpotNo";
                SqlCommand addCommand = new SqlCommand(query, databaseConnection);
                addCommand.Parameters.AddWithValue("@SpotNo", aStatus.SpotNo);
                addCommand.Parameters.AddWithValue("@IsFree", aStatus.IsFree);
                addCommand.Parameters.AddWithValue("@Distance", aStatus.Distance);

                int rowsAffected = addCommand.ExecuteNonQuery();

                return GetStatuses();
            }
        }

        // Logs
        public IList<Log> GetLogs()
        {
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                string query = "SELECT  * FROM Log";
                SqlCommand getDestListCommand = new SqlCommand(query, databaseConnection);

                List<Log> aLogs = new List<Log>();

                using (SqlDataReader reader = getDestListCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        aLogs.Add(new Log(reader.GetInt32(0), reader.GetDateTime(1), reader.GetString(2),reader.GetString(3)));
                    }
                }
                return aLogs;
            }
        }

        public IList<Log> CreateLog(Log alog)
        {
            using(SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                string query = "INSERT Log (Date,SpotNo,Action) VALUES (@Date,@SpotNo,@Action)";
                SqlCommand addCommand = new SqlCommand(query, databaseConnection);
                //addCommand.Parameters.AddWithValue("@Id", alog.Id);
                addCommand.Parameters.AddWithValue("@Date", alog.Date);
                addCommand.Parameters.AddWithValue("@SpotNo", alog.SpotNo);
                addCommand.Parameters.AddWithValue("@Action", alog.Action);

                int rowsAffected = addCommand.ExecuteNonQuery();

                return GetLogs();
            }
        }
    }
}
