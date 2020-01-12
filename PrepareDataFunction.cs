using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FDAAzureApp
{
    public static class PrepareDataFunction
    {
        [FunctionName("PrepareDataFunction")]
        public static void Run([CosmosDBTrigger(
            databaseName: "FlightDataAnalyticsCosmosDB",
            collectionName: "TestSource",
            ConnectionStringSetting = "azurecosmosdbwn_DOCUMENTDB",
            LeaseCollectionName = "TestSource_leases",CreateLeaseCollectionIfNotExists =true)]IReadOnlyList<Document> input, ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                log.LogInformation("Documents modified " + input.Count);
                log.LogInformation("First document Id " + input[0].Id);
            }
        }
    }
}