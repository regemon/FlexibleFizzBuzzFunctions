using FlexibleFizzBuzzFunctions.Models;

namespace FlexibleFizzBuzzFunctions.Services;
public record NaturalNumberWordCalculator(int Threshold, string ExpectedResult) : IFizzBuzzPartCalculator
{
    public WordObject Calculate(WordObject value)
    {
        if (value.Number <= 0 || value.Number % Threshold != 0)
        {
            return value;
        }
        var result = value.HasConverted
            ? $"{value.Result}{ExpectedResult}"
            : ExpectedResult;
        return new WordObject(value.Number, result, true);
    }

    public WordObject Calculate(int value)
    {
        var target = new WordObject(value, value.ToString(), false);
        return Calculate(target);
    }
}
