using FlexibleFizzBuzzFunctions.Models;
using Microsoft.Extensions.Options;

namespace FlexibleFizzBuzzFunctions.Services;

public class FlexibleFizzBuzzSolver : IFizzBuzzSolver
{
    private readonly IEnumerable<IFizzBuzzPartCalculator> _calculators;
    private readonly string _delimiter;

    public FlexibleFizzBuzzSolver(IOptions<SolverOptions> options)
    {
        _calculators = options.Value.Calculators.Select(item => new NaturalNumberWordCalculator(item.Threshold, item.ExpectedResult));
        _delimiter = options.Value.Delimiter;
    }

    public string Execute(int start, int end)
    {
        var count = end - start + 1;
        if (count < 0)
        {
            return string.Empty;
        }
        var results = Enumerable.Range(start, count).Select(CalculateItem);
        return string.Join(_delimiter, results);
    }

    private string CalculateItem(int value)
    {
        var target = new WordObject(value, value.ToString(), false);
        foreach (var calculator in _calculators)
        {
            target = calculator.Calculate(target);
        }
        return target.Result;
    }
}
