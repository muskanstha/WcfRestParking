using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfRestParking.Models;

namespace WcfRestParking
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IParkingService1" in both code and config file together.
    [ServiceContract]
    public interface IParkingService1
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "statuses/")]
        IList<Status> GetStatuses();
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "statuses/")]
        IList<Status> CreateStatus(Status aStatus);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "statuses/")]
        IList<Status> ChangeStatus(Status aStatus);
       

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "logs/")]
        IList<Log> GetLogs();
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "logs/")]
        IList<Log> CreateLog(Log alog);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    
}
