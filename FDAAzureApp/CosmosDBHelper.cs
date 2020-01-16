using Microsoft.Azure.Documents.Client;
using System.Linq;
using System.Collections.Generic;

namespace FDAAzureApp
{
    public static class CosmosDBHelper
    {
        public static IEnumerable<dynamic> GetItemsByQuery(DocumentClient client, string databaseName, string containerName, string query)
        {            
                using (client)
                {
                return client.CreateDocumentQuery(UriFactory.CreateDocumentCollectionUri(databaseName, containerName),
                   query, new FeedOptions { EnableCrossPartitionQuery = true });
                }            
        }
    }
}
 