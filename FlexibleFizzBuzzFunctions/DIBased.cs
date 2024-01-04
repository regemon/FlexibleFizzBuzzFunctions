using FlexibleFizzBuzzFunctions.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;

namespace FlexibleFizzBuzzFunctions;

public class DIBased
{
    private readonly IFizzBuzzSolver _solver;

    public DIBased(IFizzBuzzSolver solver)
    {
        _solver = solver;
    }

    [Function(nameof(DIBased))]
    public HttpResponseData Execute(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "fizzbuzz/di/{start}/{count}")] HttpRequestData req,
        int start,
        int count)
    {
        var result = _solver.Execute(start, count);
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.WriteString(result);
        return response;
    }
}
