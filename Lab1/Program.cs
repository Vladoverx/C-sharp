using System;

namespace C_
{
    class Program
    {
        static void Main(string[] args)
        {
            var acc1 = new GameAccount("pako", 1);
            var acc2 = new GameAccount("mako", 1);

            acc1.winGame("fred", 5);
            acc1.loseGame("moby", 20);
            acc1.winGame("alf", 10);
            acc1.winGame("gary", 10);

            acc2.winGame("jim", 5);
            acc2.winGame("kate", 10);
            acc2.loseGame("sally", 20);

            contest(acc1);
            contest(acc1);
            contest(acc1);
            contest(acc1);

            contest(acc2);
            contest(acc2);
            contest(acc2);
            contest(acc2);

            Console.WriteLine(acc1.GetStats());
            Console.WriteLine(acc2.GetStats());
        }

        static void contest(GameAccount player)
        {
            Random rnd = new Random();

            string[] players = { "fred", "moby", "alf", "gary","jim", "kate",
                                 "sally", "frodo","noob", "simon" };

            int pIndex = rnd.Next(players.Length);
            int reward = rnd.Next(5, 21);
            int chance = rnd.Next(0, 2);

            if (chance == 1)
            {
                player.winGame(players[pIndex], reward);
            } else
            {
                player.loseGame(players[pIndex], reward);
            }
        }
    }
}
