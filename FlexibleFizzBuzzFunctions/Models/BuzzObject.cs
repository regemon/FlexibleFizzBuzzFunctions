namespace FlexibleFizzBuzzFunctions.Models;

public record BuzzObject(int Number, string Result, bool HasConverted) : IFizzBuzzTarget
{
    private const int Threshold = 5;
    private const string ExpectedResult = "Buzz";

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

