using System;
using System.Collections.Generic;
using DataAnalytics;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace FDAAzureApp
{
    public static class DataFunction
    {
        [FunctionName("PrepareDataFunction")]
        public static void Run([CosmosDBTrigger(
            databaseName: "FlightDataAnalyticsCosmosDB",
            collectionName: "TestSource",
            ConnectionStringSetting = "azurecosmosdbwn_DOCUMENTDB",
            LeaseCollectionName = "TestSource_leases",CreateLeaseCollectionIfNotExists =true,MaxItemsPerInvocation =2)]IReadOnlyList<Document> input, ILogger log)
        {            
            if (input != null && input.Count > 0)
            {
                //var departureAirport = CosmosDBHelper.GetItemsByQuery(client, "FlightDataAnalyticsCosmosDB", "Airports", "select TOP 1 * from c where DepAptIATACode = " +input.);
                IPrepareData prepareData = new PrepareData();
                IReadOnlyList<Document> documents = prepareData.PrepareData(input, log);
                log.LogInformation("Documents modified " + documents);
                log.LogInformation("Documents modified " + input.Count);
                log.LogInformation("First document Id " + input[0].Id);
            }
        }
    }
}