using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_
{
    public class Game
    {
        public string Number { get; }
        public decimal Reward { get; }
        public string Status { get; }
        public string OpponentName { get; }
        private static int gameNumberSeed = 2341;
        public int numberOfGames { get; }

        public Game(string opponentName, decimal reward, string status)
        {
            Reward = reward;
            OpponentName = opponentName;
            this.Status = status;

            this.Number = gameNumberSeed.ToString();
            gameNumberSeed++;
            numberOfGames++;
        }
    }
}