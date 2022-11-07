using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_
{
    public class GameAccount
    {
        private static List<GameAccount> allAccounts = new List<GameAccount>();
        public List<Game> accountGameHistory = new List<Game>();
        
        public string UserName { get; }
        public int GamesCount { get; set; } = 0;
        public int CurrentRating { get; set; }

        public GameAccount(string name)
        {
            UserName = name;
            CurrentRating = 1; 
        }

        public static GameAccount createAccount(string userName)
        {
            GameAccount account = new GameAccount(userName);
            allAccounts.Add(account);

            return account;
        }

        public void winGame(string opponentName, int rating)
        {
            CurrentRating += rating;
            GamesCount++;
        }

        public void loseGame(string opponentName, int rating)
        {
            CurrentRating -= rating;
            GamesCount++;
            if (CurrentRating <= 0)
            {
                CurrentRating = 1;
            }
        }

        public static string getStats(string accountName)
        {
            GameAccount acc = findByName(accountName);
            var report = new System.Text.StringBuilder();

            string opponent;
            string result; 
            Console.WriteLine("Stats of user: {0} \nCurrent Rating: {1}\n", accountName, acc.CurrentRating);
            report.AppendLine("Number Of Game\tStatus\tReward\tOpponent Name");
            foreach (Game game in acc.accountGameHistory)
            { 
                if (game.winner == acc)
                {
                    result = "Won";
                } 
                else 
                {
                    result = "Lose";
                }

                if (game.Opponent1 == acc)
                {
                    opponent = game.Opponent2.UserName;
                }
                else 
                {
                    opponent = game.Opponent1.UserName;
                }
                report.AppendLine($"{game.GameNumber}\t\t{result}\t{game.Reward}\t{opponent}");
            }
            return report.ToString();
        }

        public static GameAccount findByName(string accountName)
        {
            GameAccount temp = allAccounts[0];
            for(int i = 0; temp.UserName != accountName; i++)
            {
                temp = allAccounts[i];
            }
            return temp;
        }
    }
}