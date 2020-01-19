using Microsoft.Azure.Documents;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace DataAnalytics
{
    public class PrepareData:IPrepareData
    {
        IReadOnlyList<Document> IPrepareData.PrepareData(IReadOnlyList<Document> input, ILogger log)
        {
            CosmosDBHelper            
            return input; 
        }        
    }
}
