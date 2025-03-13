namespace FirstConsoleApp;

internal class Guy
{
    public string? Name;
    public int Cash;

    public int GiveCash(int amount)
    {
        if (amount > Cash)
        {
            Console.WriteLine($"{Name} does not have enough to give ${amount}! \n " +
                $"{Name}'s balance: ${Cash}");
            return 0;
        }
        else if (amount <= 0)
        {
            Console.WriteLine($"${amount} is not a valid amount! \n " +
                $"Please enter a valid amount");
            return 0;
        }
        else
        {
            Cash -= amount;
            Console.WriteLine($"{Name} has gave ${amount} and has ${Cash} remaining");
            return amount;
        }
    }

    public void ReceiveCash(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine(Name + " says: " + amount + " isn't an amount I'll take");
        } else
        {
            Cash += amount;
            Console.WriteLine($"{Name} has received ${amount} and now has ${Cash}.");
        }
    }

    public void WriteMyInfo()
    {
        Console.WriteLine($"My name is {Name} and I have ${Cash}.");
    }
}
