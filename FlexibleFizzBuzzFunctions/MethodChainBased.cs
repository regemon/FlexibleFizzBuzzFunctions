using Grpc.Net.Client.Balancer;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using System.Net;
using FlexibleFizzBuzzFunctions.Services;

namespace FlexibleFizzBuzzFunctions;

public class MethodChainBased
{

    [Function(nameof(MethodChainBased))]
    public HttpResponseData Execute(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "fizzbuzz/methodchain/{start}/{count}")] HttpRequestData req,
        int start,
        int count)
    {
        var solver = new SimpleFizzBuzzSolver(",");
        var result = solver.Execute(start, count);
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.WriteString(result);
        return response;
    }
}
