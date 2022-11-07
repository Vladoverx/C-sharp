using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_
{
    public class Game
    {
        public GameAccount winner;
        public GameAccount Opponent1;
        public GameAccount Opponent2;
        private static int GameNumberSeed = 2341;
        public string GameNumber { get; }
        public int Reward { get; }

        public Game(GameAccount opponent1, GameAccount opponent2, int reward)
        {
            if (reward < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(reward), "Reward must be positive");
            }
            Reward = reward;
            Opponent1 = opponent1;
            Opponent2 = opponent2;

            this.GameNumber = GameNumberSeed.ToString();
            GameNumberSeed++;
        }
    }
}