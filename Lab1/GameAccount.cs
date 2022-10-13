using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_
{
    public class GameAccount
    {
        private List<Game> allGames = new List<Game>();
        public string UserName { get; }
        public decimal GamesCount { get; set; }
        public decimal CurrentRating {
            get
            {
                decimal rating = 0;
                foreach (var item in allGames)
                {
                    rating += item.Reward;
                }

                return rating;
            }
        }

        public GameAccount(string name, decimal CurrentRating)
        {
            UserName = name;

            winGame("", CurrentRating); 
        }

        public void winGame(string opponentName, decimal rating)
        {
            if (rating <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating of game must be positive");
            }
            var win = new Game(opponentName, rating, "Win");
            allGames.Add(win);
            GamesCount++;
        }

        public void loseGame(string opponentName, decimal rating)
        {
            if (rating <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating of game must be positive");
            }
            if (CurrentRating - rating <= 0)
            {
                while(CurrentRating - rating != 1)
                {
                    rating--;
                }
            }
            var lose = new Game(opponentName, -rating, "Lose");
            allGames.Add(lose);
            GamesCount++;
        }

        public string GetStats()
        {
            var report = new System.Text.StringBuilder();

            decimal rating = 0;
            report.AppendLine("Number Of Game\tStatus\tReward\tYour Rating\tOpponent Name");
            foreach (var item in allGames)
            {
                rating += item.Reward;
                report.AppendLine($"{item.Number}\t\t{item.Status}\t{item.Reward}\t{rating}\t\t{item.OpponentName}");
            }

            return report.ToString();
        }
    }
}