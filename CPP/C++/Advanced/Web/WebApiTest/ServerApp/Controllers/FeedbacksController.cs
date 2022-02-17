using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerApp.Controllers
{
    using Models;

    public class FeedbacksController : ApiController
    {
        private static List<FeedbackInfo> store = new List<FeedbackInfo>
        {
            new FeedbackInfo {From = "Greeter", Comment = "Welcome to Feedback Web-API" }
        };

        public IHttpActionResult Get(string id)
        {
            FeedbackInfo feedback = store.Find(entry => entry.From == id);

            if (feedback == null)
                return NotFound();

            return Ok(feedback);           
        }

        public IHttpActionResult Post(FeedbackInfo info)
        {
            FeedbackInfo feedback = store.Find(entry => entry.From == info.From);
            string action;

            if(feedback == null)
            {
                store.Add(info);
                action = "Accepted";
            }
            else
            {
                feedback.Comment = info.Comment;
                action = "Modified";
            }

            return Ok(action);
        }
    }
}
