using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace csc322funculator
{
    public static class Divide
    {
        [FunctionName("Divide")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# Divide function processed a request.");

            string num1Parm = req.Query["num1"];
            string num2Parm = req.Query["num2"];

            //check 2 parms are passed

            if( num1Parm == null || num2Parm == null) {
                return new BadRequestObjectResult("Please pass a num1 and num2 on the query string");
            }

            int num1 = int.Parse(num1Parm);
            int num2 = int.Parse(num2Parm);
            int sum = num1 / num2;

            return (ActionResult)new OkObjectResult($"Sum = {sum}");
        }
    }
}
