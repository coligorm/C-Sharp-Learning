using Guys;

decimal worseOdds = 0.75M;
decimal betterOdds = 0.5M;
decimal odds;
List<Guy> players = new List<Guy>();
int numberOfPlayers;

Console.WriteLine($"Welcome to the casino.\n" +
    $"The worse odds are {worseOdds}\n" +
    $"The better odds are {betterOdds}");
Console.WriteLine("How many players would like to play?");
while (!int.TryParse(Console.ReadLine(), out numberOfPlayers) || numberOfPlayers == 0)
{
    Console.WriteLine("Please enter a valid number of players.");
}

for (int i = 0; i < numberOfPlayers; i++)
{
    players.Add(new Guy() { Name = $"Player {i + 1}", Cash = 100 });
    players[i].WriteMyInfo();
}

while (players.Any(player => player.Cash > 0))
{
    for (int i = 0; i < players.Count; i++)
    {
        Guy? player = players[i];
        Console.WriteLine("\n__________________\n");
        Console.WriteLine($"{player.Name}'s turn");
        player.WriteMyInfo();

        string input;
        do
        {
            Console.WriteLine("What odds do you want to bet against? b or w");
            input = Console.ReadLine();
        } while (input != "b" && input != "w");

        odds = input == "b" ? betterOdds : worseOdds;

        // Loops until vaild bet is placed
        while (true)
        {
            Console.Write($"\nHow much does {player.Name} want to bet: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                decimal bet = player.GiveCash(amount);
                decimal pot;
                if (odds == 0.75M)
                {
                    pot = bet * 2;
                }
                else
                {
                    pot = bet * 1.25M;
                }

                if (pot > 0)
                {
                    if (Random.Shared.NextDouble() > (double)odds)
                    {
                        Console.WriteLine($"{player.Name} wins {pot}");
                        player.ReceiveCash(pot);
                    }
                    else
                    {
                        Console.WriteLine("Unlucky, you lose!");
                    }
                    // Successful bet - whether win or lose
                    break;
                }
                else
                {
                    Console.WriteLine("Not enough money in the pot!");
                    Console.WriteLine("Try again!");
                }
            }
            else
            {
                Console.WriteLine($"{player.Name}: Please enter a valid anount to bet.");
            }

        }

        if (player.Cash == 0)
        {
            Console.WriteLine($"{player.Name} has bust!");
            players.RemoveAt(i);
            i--;
        }

    }
}
Console.WriteLine("\n\nGame Over!\nAll players have bust\n\nThe house always wins!");