using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommentAnalytics.Services.Client
{
    public class CommentModel : TableEntity
    {
        public CommentModel()
        {
            RowKey = DateTime.UtcNow.ToString("ddMMyyyyHHmmssfff");
        }

        public string Comment { get; set; }
        public string Language { get; set; }
        public float SentimentScore { get; set; }
        public string SentimentKeyPhrases { get; set; }
    }
}