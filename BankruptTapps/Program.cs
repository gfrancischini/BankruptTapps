using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankruptTapps
{
    class Statistics
    {
        public string WinnerName { get; set; }
        public int Rounds { get; set; }

        public Statistics(string winnerName, int rounds)
        {
            this.WinnerName = winnerName;
            this.Rounds = rounds;
        }
    }

    class Program
    {
        static int MAX_RUNS = 300;
        static Logger logger = LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();

        static void Main(string[] args)
        {
            logger.Info("Welcome to Bankrupt");

            List<Statistics> statistics = new List<Statistics>();

            BoardLoader boardLoader = new BoardLoader();
            Board board = boardLoader.CreateBoard();

            for (int i = 0; i < MAX_RUNS; i++)
            {
                logger.Info("Running Game {0} of {1}", i, MAX_RUNS);

                GameManager game = new GameManager(board);
                CreateAndAddSpecificPlayers(game);
                int rounds = game.RunGame();

                statistics.Add(new Statistics(game.GetWinner().Name, rounds));

                logger.Info("Player {0} wins with {1}!!", game.GetWinner().Name, rounds);
            }

            PrintStatistcs(statistics);

            Console.ReadKey();

        }

        /// <summary>
        /// Create the 4 default players
        /// </summary>
        /// <param name="game"></param>
        static void CreateAndAddSpecificPlayers(GameManager game)
        {
            game.AddPlayers(new CautiousPlayer("Cauteloso"));
            game.AddPlayers(new ImpulsivePlayer("Impulsivo"));
            game.AddPlayers(new PickyPlayer("Exigente"));
            game.AddPlayers(new RandomPlayer("Aleatorio"));
        }

        /// <summary>
        /// Print output statistics
        /// </summary>
        /// <param name="statistics"></param>
        static void PrintStatistcs(List<Statistics> statistics)
        {
            logger.Info("----------------------------------------------------------------------------");
            logger.Info("-------------------------------------Stats----------------------------------");

            //Quantas partidas terminam por time out (1000 rodadas);
            int timeoutCount = statistics.Count(game => game.Rounds == GameManager.GAME_ROUND_DURATION);
            logger.Info("Timeout Rounds {0}", timeoutCount);

            //Quantos turnos em média demora uma partida;
            double averageRounds = statistics.Average(game => game.Rounds);
            logger.Info("Average Rounds {0}", averageRounds);

            //Qual a porcentagem de vitórias por comportamento dos jogadores;
            var winners = statistics.GroupBy(game => game.WinnerName).OrderBy(winner => winner.Key);
            foreach (var winner in winners)
            {
                logger.Info("Player {0}: {1}%", winner.Key, ((double)winner.Count() / statistics.Count())*100);
            }

            //Qual o comportamento que mais vence.
            var bestWinner = winners.OrderByDescending(winner => winner.Count()).First();
            logger.Info("Who Wins the Most {0}", bestWinner.Key, bestWinner.Count());

            logger.Info("----------------------------------------------------------------------------");
        }
    }
}
