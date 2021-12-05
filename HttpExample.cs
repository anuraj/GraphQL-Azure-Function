using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using HotChocolate.AzureFunctions;

namespace GraphQL_Azure_Function
{
    public class HttpExample
    {
        [FunctionName("HttpExample")]
        public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "graphql")] HttpRequest req,
        [GraphQL] IGraphQLRequestExecutor executor, 
        ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            return await executor.ExecuteAsync(req);
        }
    }
}
