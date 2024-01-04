using FlexibleFizzBuzzFunctions.Services;

namespace FlexibleFizzBuzzFunctions.Models;

public interface IFizzBuzzTarget
{
    int Number { get; }
    string Result { get; }
    bool HasConverted { get; }

    public IFizzBuzzTarget Execute();
}
