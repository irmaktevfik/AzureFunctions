using CommentAnalytics.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CommentAnalytics.Services.Client
{
    public class QueueClient
    {
        const string QUEUENAME = "comments";
        private static bool isQueueCreated;

        public QueueClient()
        {
            isQueueCreated = false;
        }

        internal async static Task AddComment(string comment)
        {
            Repository.QueueRepository repository = new QueueRepository();
            if (!isQueueCreated)
            {
                isQueueCreated = await repository.CreateQueueAsync(QUEUENAME);
            }
            await repository.InsertMessageAsync(QUEUENAME, comment);
        }
    }
}