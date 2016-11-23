using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommentAnalytics.Services.Repository
{
    public class AzureStorageRepository : RoleEntryPoint
    {
        internal CloudStorageAccount storageAccount;

        public AzureStorageRepository()
        {
            storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=http;AccountName=commentanalytics;AccountKey=y4+iTmo0MkYekMUbF6gT63yJfxVWr+TxI7c/oH6O12UBJUs/p0nudVQ2MhUGMu1PQ9L5bXz11Iwal2XQ9a84VQ==;");
        }

        public override bool OnStart()
        {

            return base.OnStart();
        }


    }
}