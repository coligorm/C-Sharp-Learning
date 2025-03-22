namespace AbilityScore;

/// <summary>
/// Calculates the ability score based on roll result, divide factor, add amount, and minimum value.
/// </summary>
/// <remarks>
/// Fields:
/// <list type="bullet">
/// <item>
/// <term>RollResult</term>
/// <description>The result of rolling 4d6 dice.</description>
/// </item>
/// <item>
/// <term>DivideBy</term>
/// <description>The factor by which the roll result is divided.</description>
/// </item>
/// <item>
/// <term>AddAmount</term>
/// <description>The amount to add to the divided result.</description>
/// </item>
/// <item>
/// <term>Minimum</term>
/// <description>The minimum value for the ability score.</description>
/// </item>
/// <item>
/// <term>Score</term>
/// <description>The calculated ability score.</description>
/// </item>
/// </list>
/// </remarks>
public class AbilityScoreCalculator
{
    public int RollResult = 14;
    public double DivideBy = 1.75;
    public int AddAmount = 2;
    public int Minimum = 3;
    public int Score;

    /// <summary>
    /// Calculates the ability score and updates the Score property.
    /// </summary>
    public void CalculateAbilityScore()
    {
        double divide = RollResult / DivideBy;
        int added = AddAmount + (int)divide;

        if (added < Minimum)
        {
            Score = Minimum;
        }
        else
        {
            Score = added;
        }
    }
}
