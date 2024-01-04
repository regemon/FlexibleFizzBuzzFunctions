using FlexibleFizzBuzzFunctions.Models;
using Google.Protobuf.WellKnownTypes;

namespace FlexibleFizzBuzzFunctions.Services;

public class SimpleFizzBuzzSolver : IFizzBuzzSolver
{
    private readonly string _delimiter;

    public SimpleFizzBuzzSolver(string delimiter)
    {
        _delimiter = delimiter;
    }

    public string Execute(int start, int end)
    {
        var count = end - start + 1;
        if (count < 0)
        {
            return string.Empty;
        }
        var results = Enumerable.Range(start, count).Select(item =>
            new FizzObject(item, item.ToString(), false).Execute().Execute().Result);
        return string.Join(_delimiter, results);
    }
}
