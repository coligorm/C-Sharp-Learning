using Guys;

double odds = .75;
Guy player = new Guy() { Name = "The player", Cash = 100 };

Console.WriteLine($"Welcome to the casino. The odds are {odds}");

while (player.Cash > 0)
{
    player.WriteMyInfo();
    Console.Write("How much do you want to bet: ");
    string? howMuch = Console.ReadLine();

    if (int.TryParse(howMuch, out int amount))
    {
        // Double or nothing bet
        int pot = player.GiveCash(amount) * 2;
        if (pot > 0)
        {
            if (Random.Shared.NextDouble() > odds)
            {
                Console.WriteLine($"You win {pot}");
                player.ReceiveCash(pot);
            }
            else
            {
                Console.WriteLine("Bad luck, you lose.");
            }
        }
    }
    else
    {
        Console.WriteLine("Please enter a valid number.");
    }
}
Console.WriteLine("The house always wins.");