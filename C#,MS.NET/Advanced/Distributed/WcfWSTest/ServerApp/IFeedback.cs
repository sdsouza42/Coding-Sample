using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ServerApp
{
    [DataContract(Name = "FeedbackInfo")]
    public class FeedbackDetail
    {
        [DataMember(Name = "From", IsRequired = true)]
        public string Name { get; set; }

        [DataMember(Name = "Comment", IsRequired = true)]
        public string Text { get; set; }
    }

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFeedback" in both code and config file together.
    [ServiceContract(Name = "Feedback")]
    public interface IFeedback
    {
        [OperationContract(Name = "ReadFeedback")]
        [WebInvoke(Method = "GET", UriTemplate = "read/{name}", ResponseFormat = WebMessageFormat.Json)]
        FeedbackDetail Review(string name);

        [WebInvoke(Method = "POST", UriTemplate = "write", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        [OperationContract(Name = "WriteFeedback")]
        string Submit(FeedbackDetail detail);
    }
}
