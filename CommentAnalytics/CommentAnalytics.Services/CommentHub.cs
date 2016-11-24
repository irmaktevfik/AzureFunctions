using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using Microsoft.AspNet.SignalR.Hubs;

namespace CommentAnalytics.Services
{
    [HubName("CommentHub")]
    public class CommentHub : Hub
    {
        public void PostComment(string comment, int score)
        {
            var commentScore = new CommentsModel() { Percentage = score, Comment = comment };
            Clients.All.commentShow(Newtonsoft.Json.JsonConvert.SerializeObject(commentScore));
        }
    }

    public class CommentsModel
    {
        [JsonProperty(PropertyName = "percentage")]
        public int Percentage { get; set; }

        [JsonProperty(PropertyName = "comment")]
        public string Comment { get; set; }
    }
}