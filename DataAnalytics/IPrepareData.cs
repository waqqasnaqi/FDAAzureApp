using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Documents;
using Microsoft.Extensions.Logging;

namespace DataAnalytics
{
    public interface IPrepareData
    {
        IReadOnlyList<Document> PrepareData(IReadOnlyList<Document> input, ILogger log);       
    }
}
