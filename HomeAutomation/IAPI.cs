using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HomeAutomation
{
    [ServiceContract]
    public interface IAPI
    {
        [WebGet(UriTemplate = "/status/set/{n}/{a}")]
        [OperationContract]
        int SetStatus(string n, string a);

        [WebGet(UriTemplate = "/status/get/{n}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        string GetStatus(string n);

        [WebGet(UriTemplate = "/event/set/{l}/{t}/{d}")]
        [OperationContract]
        int SetEvent(string l, string t, string d);

        [WebGet(UriTemplate = "/event/get/{l}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        string GetEvent(string l);

        [WebGet(UriTemplate = "/environment/set/{l}/{s}/{t}/{u}/{r}")]
        [OperationContract]
        int SetEnvironment(string l, string s, string t, string u, string r);

        [WebGet(UriTemplate = "/environment/get/{l}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        string GetEnvironment(string l);
    }
}
