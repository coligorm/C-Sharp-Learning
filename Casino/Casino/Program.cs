using Guys;

double odds = .75;
Guy player = new Guy() { Name = "The player", Cash = 100 };

Console.WriteLine($"Welcome to the casino. The odds are {odds}");

while (true)
{
    player.WriteMyInfo();
    Console.Write("How much do you want to bet: ");
    string? howMuch = Console.ReadLine();

    int pot = 0;
    //double rand = 0;
    if (int.TryParse(howMuch, out int amount))
    {
        pot = player.GiveCash(amount);        
    }
    if (pot > 0)
    {
        pot *= 2;
        double rand = Random.Shared.NextDouble();
        if (rand > odds)
        {
            Console.WriteLine($"You win {pot}");
            player.ReceiveCash(pot);
        }
        else
        {
            Console.WriteLine("Bad luck, you lose.");
        }
    }

    if (player.Cash <= 0)
    {
        Console.WriteLine("The house always wins.");
        break;
    }
}