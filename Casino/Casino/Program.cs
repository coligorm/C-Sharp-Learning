using Guys;

double odds = .75;
Guy player1 = new Guy() { Name = "Player 1", Cash = 100 };
Guy player2 = new Guy() { Name = "Player 2", Cash = 100 };
List<Guy> players = new List<Guy>();

Console.WriteLine($"Welcome to the casino. The odds are {odds}");
Console.WriteLine("How many players would like to play?");
string? input = Console.ReadLine();
if (int.TryParse(input, out int numberOfPlayers))
{
    for (int i = 0; i < numberOfPlayers; i++)
    {
        players.Add(new Guy() { Name = $"Player {i + 1}", Cash = 100 });
        players[i].WriteMyInfo();
    }
}
else
{
    Console.WriteLine($"{player2.Name}: Please enter a valid number.");
}

while (players.Any(player => player.Cash > 0)) 
{
    foreach (var player in players)
    {
        player.WriteMyInfo();
        Console.Write($"How much does {player.Name} want to bet: ");
        string? howMuch = Console.ReadLine();
        if (int.TryParse(howMuch, out int amount))
        {
            
        }
    }
    player1.WriteMyInfo();
    player2.WriteMyInfo();
    Console.Write($"How much does {player1.Name} want to bet: ");
    string? howMuchPlayer1 = Console.ReadLine();
    Console.Write($"How much does {player2.Name} want to bet: ");
    string? howMuchPlayer2 = Console.ReadLine();

    if (int.TryParse(howMuchPlayer1, out int amountP1))
    {
        if (int.TryParse(howMuchPlayer2, out int amountP2))
        {
            // Double or nothing bet
            int pot = player1.GiveCash(amountP1) * 2;
            pot = player2.GiveCash(amountP2) * 2;
            if (pot > 0)
            {
                // Player 1 Players
                if (Random.Shared.NextDouble() > odds)
                {
                    Console.WriteLine($"{player1.Name} wins {pot}");
                    player1.ReceiveCash(pot);
                }
                else if (Random.Shared.NextDouble() > odds)
                {
                    Console.WriteLine($"{player2.Name} wins {pot}");
                    player2.ReceiveCash(pot);
                }
                else
                {
                    Console.WriteLine("Bad luck, you both lose.");
                }
            }
        }
        else
        {
            Console.WriteLine($"{player2.Name}: Please enter a valid number.");
        }
    }
    else
    {
        Console.WriteLine($"{player1.Name}: Please enter a valid number.");
    }
}
Console.WriteLine("At least one of ye got away with something!");