using System.Collections.Generic;
using System.ServiceModel.Web;

namespace ServerApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Feedback" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Feedback.svc or Feedback.svc.cs at the Solution Explorer and start debugging.
    public class FeedbackService : IFeedback
    {
        private static List<FeedbackDetail> store = new List<FeedbackDetail>
        {
            new FeedbackDetail {Name="Greeter", Text="Welcome to WCF WebService" }
        };

        public FeedbackDetail Review(string name)
        {
            FeedbackDetail feedback = store.Find(entry => entry.Name == name);

            if (feedback == null)
                throw new WebFaultException(System.Net.HttpStatusCode.NotFound);

            return feedback;
        }

        public string Submit(FeedbackDetail detail)
        {
            FeedbackDetail feedback = store.Find(entry => entry.Name == detail.Name);
            string action;

            if (feedback == null)
            {
                store.Add(detail);
                action = "Accepted";
            }
            else
            {
                feedback.Text = detail.Text;
                action = "Modified";
            }

            return action;
        }
    }
}
