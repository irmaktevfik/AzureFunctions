using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CommentAnalytics.Mobile.Repository
{
    public class Comment : BaseRepository
    {
        public async Task<HttpResponseMessage> SaveComment(CommentModel comment)
        {
            return await base.Post<CommentModel>(comment, "SaveComment","comment");
        }
    }
}
