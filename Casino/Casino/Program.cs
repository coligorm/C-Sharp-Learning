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
while (players.Any(player => player.Cash > 0))
{
    foreach (var player in players)
    {
        Console.WriteLine("___________________");
        Console.WriteLine($"{player.Name}'s turn");
        player.WriteMyInfo();
        Console.Write($"How much does {player.Name} want to bet: ");
        string? howMuch = Console.ReadLine();
        if (int.TryParse(howMuch, out int amount) && (amount <= player.Cash))
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
            }
            else
            {
                Console.WriteLine("Not enough money in the pot!");
            }
        }
        else
        {
            Console.WriteLine($"{player.Name}: Please enter a valid anount to bet.");
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