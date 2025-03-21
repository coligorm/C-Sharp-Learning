using Guys;
//
// OPTIONAL ADDITION
// Add a way to change odds
// Better odds, higher reward
//
double odds = .75;
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
    Console.WriteLine("Please enter a valid number of players.");
}
//
// TO FIX:
// Game doesnt exit when a player busts
//
while (!players.Any(player => player.Cash == 0))
{
    foreach (var player in players)
    {
        Console.WriteLine("\n__________________\n");
        Console.WriteLine($"{player.Name}'s turn");
        player.WriteMyInfo();

        // Loops until vaild bet is placed
        while (true)
        {
            Console.Write($"\nHow much does {player.Name} want to bet: ");
            if (int.TryParse(Console.ReadLine(), out int amount))
            {
                int bet = player.GiveCash(amount);
                int pot = bet * 2;
                if (pot > 0)
                {
                    if (Random.Shared.NextDouble() > odds)
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
        }

    } 
}
//
// OPTIONAL ADDITION:
// Add a way to continue and remove the player who bust
//
Console.WriteLine("Game Over!");
Console.WriteLine("At least one player has bust, so everyone leaves");