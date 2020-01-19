using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Models;

namespace FDAAzureApp
{
    public class CosmosDBHelper
    {
        private readonly string endpointUri = "https://azurecosmosdbwn.documents.azure.com:443/"; //ConfigurationManager.AppSettings["EndPointUri"];        
        private static readonly string PrimaryKey = "8mqLyweVWWUxqXz1LqWzN46CnvibY73tMC5jq7cGKsV3QVHYOiScHoeND6YbpbKbCtvNsCPGWKTHBzL0LiMBag==";  //ConfigurationManager.AppSettings["PrimaryKey"];       

        //private Database database;
        private Container container;

        // The name of the database and container we will create
        private string databaseId; // "FlightDataAnalyticsCosmosDB";
        private string containerId; // "Airports";        

        public CosmosDBHelper(string databaseId, string containerId)
        {
            this.databaseId = databaseId;
            this.containerId = containerId;
            CosmosClient cosmosClient = new CosmosClient(endpointUri, PrimaryKey);
            this.container = cosmosClient.GetContainer(databaseId, containerId);
        }

        // <QueryItemsAsync>
        /// <summary>
        /// Run a query (using Azure Cosmos DB SQL syntax) against the container
        /// </summary>
        public async Task QueryItemsAsync(string sqlQueryText)
        {
            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            FeedIterator<Airport> queryResultSetIterator = this.container.GetItemQueryIterator<Airport>(queryDefinition);

            List<Airport> airports = new List<Airport>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<Airport> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (Airport apt in currentResultSet)
                {
                    airports.Add(apt);
                }
            }
        }
    }
    }
 