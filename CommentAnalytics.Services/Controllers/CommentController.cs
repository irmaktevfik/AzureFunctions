using CommentAnalytics.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CommentAnalytics.Services.Controllers
{
    public class CommentController : ApiController
    {
        // POST: api/Comment
        [HttpPost]
        public async Task<HttpResponseMessage> SaveComment(CommentModel model)
        {
            if (!String.IsNullOrEmpty(model.value))
            {
                await Client.QueueClient.AddComment(model.value);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
