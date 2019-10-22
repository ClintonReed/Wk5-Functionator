using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CSC322Funculator
{
    public static class Sub
    {
        [FunctionName("Sub")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# Sub function processed a request.");


            string num1Parm = req.Query["num1"];
            string num2Parm = req.Query["num2"];

            //check 2 parms are passed

            if( num1Parm == null || num1Parm ==null) {
                return new BadRequestObjectResult("Please pass a num1 and num2 on the query string");
            }

            int num1 = int.Parse(num1Parm);
            int num2 = int.Parse(num2Parm);
            int sub = num1 - num2;

            return (ActionResult)new OkObjectResult($"Sub = {sub}");
        }
    }
}
