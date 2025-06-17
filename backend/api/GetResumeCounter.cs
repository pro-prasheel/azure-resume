using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http;
using System.Text;

namespace Company.Function
{
    public static class GetResumeCounter
    {
        [FunctionName("GetResumeCounter")]
        public static HttpResponseMessage Run(
                [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
                [CosmosDB(databaseName: "AzureResume", containerName: "Counter", Connection = "AzureResumeConnectionString", Id = "1", PartitionKey = "1")] Counter counter,
                [CosmosDB(databaseName: "AzureResume", containerName: "Counter", Connection = "AzureResumeConnectionString", Id = "1", PartitionKey = "1")] out Counter updatedCounter,
                ILogger log)

                
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            updatedCounter = counter;
            updatedCounter.Count += 1;

            var jsonToReturn = JsonConvert.SerializeObject(updatedCounter);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
            };
        }
    }
}

//     public class Counter
//     {
//         public int Count { get; set; }
//     }
// }


    // public class Counter
    // {
    //     public int Count { get; set; }
    // };

//     public static class GetResumeCounter : NewBaseType
//     {
//     };
// };

    // public static class NewBaseType : NewBaseType, INewBaseType
    // {
    // }

    // public static class GetResumeCounter : NewBaseType
    // {
    // }

// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Azure.Functions.Worker;
// using Microsoft.Extensions.Logging;
// using Newtonsoft.Json;
// using System.Net.Http;
// using System.Text;

// namespace Company.Function;

// public static class NewBaseType
// {
//     [Function("GetResumeCounter")]
//     public static HttpResponseMessage Run(
//         [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,

//         [CosmosDB(
//             databaseName: "AzureResume",
//             collectionName: "Counter",
//             ConnectionStringSetting = "AzureResumeConnectionString",
//             Id = "1",
//             PartitionKey = "1")] Counter counter,

//         [CosmosDB(
//             databaseName: "AzureResume",
//             collectionName: "Counter",
//             ConnectionStringSetting = "AzureResumeConnectionString",
//             PartitionKey = "1")] out Counter updatedCounter,

//         ILogger log)
//     {
//         log.LogInformation("C# HTTP trigger function processed a request.");

//         updatedCounter = counter;
//         updatedCounter.Count += 1;

//         var jsonToReturn = JsonConvert.SerializeObject(counter);

//         return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
//         {
//             Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
//         };
//     }
// }

// public static class NewBaseType : NewBaseType
// {
// }

// public static class GetResumeCounter : NewBaseType
// {
// }

// public class NewBaseType : NewBaseType
// {
// }

// public class GetResumeCounter : NewBaseType
// {
//     private readonly ILogger<GetResumeCounter> _logger;

//     public GetResumeCounter(ILogger<GetResumeCounter> logger)
//     {
//         _logger = logger;
//     }
// }