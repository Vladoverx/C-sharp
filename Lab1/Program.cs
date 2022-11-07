using System;

namespace C_
{
    class Program
    {
        static void Main(string[] args)
        {
            GameAccount.createAccount("Pako");
            GameAccount.createAccount("Mako");

            match("Pako", "Mako", 30);
            match("Pako", "Mako", 10);
            match("Pako", "Mako", 15);
            match("Pako", "Mako", 5);
            match("Pako", "Mako", 5);

            Console.WriteLine(GameAccount.getStats("Pako"));
            Console.WriteLine(GameAccount.getStats("Mako"));
        }

        public static void match(string opponent1, string opponent2, int reward)
        {
            GameAccount player1 = GameAccount.findByName(opponent1);
            GameAccount player2 = GameAccount.findByName(opponent2);

            try
            {
                Game game = new Game(player1, player2, reward);
                Random rnd = new Random();
                int chance = rnd.Next(0, 2);
            
                if (chance == 1)
                {
                    game.winner = player1;
                    player1.winGame(player2.UserName, reward);
                    player2.loseGame(player1.UserName, reward);
                } else
                {
                    game.winner = player2;
                    player2.winGame(player1.UserName, reward);
                    player1.loseGame(player2.UserName, reward);
                }
                player1.accountGameHistory.Add(game);
                player2.accountGameHistory.Add(game);
                }
            catch (System.ArgumentOutOfRangeException)
            {
                Console.WriteLine("Reward of the game must be positive");
                throw;
            }
        }
    }
}
