using Google.Protobuf.WellKnownTypes;

namespace FlexibleFizzBuzzFunctions.Models;

public record FizzObject(int Number, string Result, bool HasConverted) : IFizzBuzzTarget
{
    private const int Threshold = 3;
    private const string ExpectedResult = "Fizz";

    public IFizzBuzzTarget Execute()
    {
        if (Number <= 0 || Number % Threshold != 0)
        {
            return new BuzzObject(Number, Result, HasConverted);
        }

        var result = HasConverted
            ? $"{Result}{ExpectedResult}"
            : ExpectedResult;

        return new BuzzObject(Number, result, true);
    }
}
