using FlexibleFizzBuzzFunctions.Models;

namespace FlexibleFizzBuzzFunctions.Services;

public interface IFizzBuzzPartCalculator
{
    int Threshold { get; }
    string ExpectedResult { get; }
    WordObject Calculate(WordObject value);
    WordObject Calculate(int value);
}
