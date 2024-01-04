namespace FlexibleFizzBuzzFunctions.Models;

public class SolverOptions
{
    public required string Delimiter { get; init; }
    public required IEnumerable<CaluculatorOptions> Calculators { get; init; }
}
