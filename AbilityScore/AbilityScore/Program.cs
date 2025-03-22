using AbilityScore;

AbilityScoreCalculator calculator = new AbilityScoreCalculator();

while (true)
{
    calculator.RollResult = ReadInt(calculator.RollResult, "Starting 4d6 roll");
    calculator.DivideBy = ReadDouble(calculator.DivideBy, "Divide by");
    calculator.AddAmount = ReadInt(calculator.AddAmount, "Add amount");
    calculator.Minimum = ReadInt(calculator.Minimum, "Minimum");
    calculator.CalculateAbilityScore();
    Console.WriteLine($"Calculated ability score: {calculator.Score}");
    Console.WriteLine($"Press Q to quit, any other key to continue");
    char keyChar = Console.ReadKey(true).KeyChar;

    if ((keyChar == 'Q') || (keyChar == 'q'))
    {
        return;
    }
}

/// <summary>
/// Takes in two parameters, int defaultValue and string prompt.
/// The method prints to console what the current default value is.
/// If the user inputs a value, the default is updated and used until the program closes.
/// If the user does not enter a value, then the current default is used
/// </summary>
/// <param name="defaultValue">The default value to use if the user does not provide input.</param>
/// <param name="prompt">The text that is displayed to the user</param>
/// <returns>An int of either default value or updated user value input</returns>
static int ReadInt(int defaultValue, string prompt)
{
    Console.Write($"{prompt} [{defaultValue}]: ");
    if (int.TryParse(Console.ReadLine(), out int newValue))
    {
        Console.WriteLine($"\t using value {newValue}");
        defaultValue = newValue;
    }
    else
    {
        Console.WriteLine($"\t using default value {defaultValue}");
    }
    return defaultValue;
}

/// <summary>
/// Takes in two parameters, double defaultValue and string prompt.
/// The method prints to console what the current default value is.
/// If the user inputs a value, the default is updated and used until the program closes.
/// If the user does not enter a value, then the current default is used
/// </summary>
/// <param name="defaultValue">The default value to use if the user does not provide input.</param>
/// <param name="prompt">The text that is displayed to the user</param>
/// <returns>A double of either default value or updated user value input</returns>
static double ReadDouble(double defaultValue, string prompt)
{
    Console.Write($"{prompt} [{defaultValue}]: ");
    if (double.TryParse(Console.ReadLine(), out double newValue))
    {
        Console.WriteLine($"\t using value {newValue}");
        defaultValue = newValue;
    }
    else
    {
        Console.WriteLine($"\t using default value {defaultValue}");
    }
    return defaultValue;
}