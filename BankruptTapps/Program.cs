using System;

namespace BankruptTapps
{
    class Program
    {
        static int MAX_RUNS = 300;

        static void Main(string[] args)
        {
            var logger = NLog.LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();
            logger.Info("Welcome to Bankrupt");

            for (int i = 0; i < MAX_RUNS; i++)
            {
                logger.Info("Running Game {0} of {1}", i, MAX_RUNS);
                GameManager game = new GameManager();
                game.RunGame();
                logger.Info("Player {0} wins!!", game.GetWinner().Name);
            }
        }
    }
}
