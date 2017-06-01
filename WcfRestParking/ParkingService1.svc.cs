using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WcfRestParking.Models;

namespace WcfRestParking
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ParkingService1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ParkingService1.svc or ParkingService1.svc.cs at the Solution Explorer and start debugging.
    public class ParkingService1 : IParkingService1
    {
        private static string connectionString = "Server=tcp:parkingdbs.database.windows.net,1433;Initial Catalog=ParkingDB;Persist Security Info=False;User ID=parkingdbs;Password=Namaste977;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        /// <summary>
        /// By: Bipin Rai 
        /// MEthod that gets the current list of statuses stored in the azure database
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// By: Yogesh 
        /// method to create status
        /// </summary>
        /// <param name="aStatus"></param>
        /// <returns></returns>
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
        /// <summary>
        /// by: Deepak
        /// Every time sensor sends the data Status is updated with the new data
        /// </summary>
        /// <param name="aStatus"></param>
        /// List of new Status is stored in database
        /// <returns>List of Statuses with the new updated status</returns>
        /// 
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

                int rowsaffected = addCommand.ExecuteNonQuery();

                return GetStatuses();
            }
        }
        /// <summary>
        /// by:Deepak
        /// remove the specific status from the list provided the sportNo
        /// new list is store in the database
        /// </summary>
        /// <param name="spotNo"></param>
        /// <returns>new list of status</returns>
        public IList<Status> DeleteStatuses(string spotNo)
        {
            using (SqlConnection databaseConnection= new SqlConnection(connectionString))
            {
                {
                    databaseConnection.Open();
                    string query = "DELETE From Status Where SpotNO=@spotNo";
                    SqlCommand deleteCommand= new SqlCommand(query,databaseConnection);
                    deleteCommand.Parameters.AddWithValue("@SpotNo",spotNo);
                    int rowsaffected = deleteCommand.ExecuteNonQuery();
                    return GetStatuses();
                }
            }
        }


        // Logs
        /// <summary>
        /// By: Muskan
        /// Method to get the current list of logs stored in the database using connection string
        /// </summary>
        /// <returns></returns>
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
                        aLogs.Add(new Log(reader.GetInt32(0), reader.GetDateTime(1), reader.GetString(2), reader.GetString(3)));
                    }
                }
                aLogs.Sort();
                return aLogs;
            }
        }
        /// <summary>
        /// By: Muskan
        /// Method to create logs in the database
        /// </summary>
        /// <param name="alog"></param>
        /// <returns></returns>

        public IList<Log> CreateLog(Log alog)
        {
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                string query = "INSERT Log (Date,SpotNo,Action) VALUES (@Date,@SpotNo,@Action)";
                SqlCommand addCommand = new SqlCommand(query, databaseConnection);
                addCommand.Parameters.AddWithValue("@Date", alog.Date);
                addCommand.Parameters.AddWithValue("@SpotNo", alog.SpotNo);
                addCommand.Parameters.AddWithValue("@Action", alog.Action);

                int rowsAffected = addCommand.ExecuteNonQuery();

                return GetLogs();
            }
        }
        /// <summary>
        /// Using yahoo weather api to get the current weather status of Roskilde
        /// By: Muskan
        /// </summary>
        /// <returns></returns>
        public WeatherText.Condition GetCondition()
        {
            using (HttpClient client = new HttpClient())
            {
                string uri = "https://query.yahooapis.com/v1/public/yql?q=select%20item.condition.text%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22roskilde%2C%20dk%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";
                string content = client.GetStringAsync(uri).Result;
                JObject ajJObject = JObject.Parse(content);
                //string theText = ajJObject.query.k
                WeatherText aRootObjecteatherData = JsonConvert.DeserializeObject<WeatherText>(content);
                //return new WeatherText("aww");
                return aRootObjecteatherData.query.results.channel.item.condition;
            }

        }
    }

}
