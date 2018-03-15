using BankruptTapps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestBankruptTapps
{
    [TestClass]
    public class GameManagerTest
    {
        public class ExposedGameManager : GameManager {
            public ExposedGameManager(Board board) : base(board)
            {

            }

            new public Player GetWinner()
            {
                return base.GetWinner();
            }

            new public Boolean IsGameCompleted()
            {
                return base.IsGameCompleted();
            }

            new public void DeclarePlayerBankrupt(Player player)
            {
                base.DeclarePlayerBankrupt(player);
            }

            new public void PayPlayerForCompletingTheBoard(Player player)
            {
                base.PayPlayerForCompletingTheBoard(player);
            }

            new public Boolean IsPlayerBankrupt(Player player)
            {
                return base.IsPlayerBankrupt(player);
            }

            new public Boolean ShouldPayRent(Tile property, Player player)
            {
                return base.ShouldPayRent(property, player);
            }

            new public void PayRent(Tile property, Player renter)
            {
                base.PayRent(property, renter);
            }
        }

        [TestMethod]
        public void PayRentShouldDecreseRenterMoney()
        {
            Board board = new Board(new string[] { "50 100" });
            ExposedGameManager game = new ExposedGameManager(board);

            Player playerPropertyOwner = new RandomPlayer("playerPropertyOwner");
            Tile property = board.Tiles[0];
            property.Owner = playerPropertyOwner;

            Player player = new RandomPlayer("Random");
            game.AddPlayers(player);

            property.RentPrice = 50;
            player.Money = 90;
            game.PayRent(property, player);
            Assert.AreEqual(40, player.Money);
        }

        [TestMethod]
        public void PayRentShouldIncreaseRenterMoney()
        {
            Board board = new Board(new string[] { "50 100" });
            ExposedGameManager game = new ExposedGameManager(board);

            Player playerPropertyOwner = new RandomPlayer("playerPropertyOwner");
            
            Tile property = board.Tiles[0];
            property.Owner = playerPropertyOwner;

            Player player = new RandomPlayer("Random");
            game.AddPlayers(player);

            property.RentPrice = 50;
           
            player.Money = 90;
            playerPropertyOwner.Money = 0;
            game.PayRent(property, player);
            Assert.AreEqual(50, playerPropertyOwner.Money);
            
            player.Money = 20;
            playerPropertyOwner.Money = 0;
            game.PayRent(property, player);
            Assert.AreEqual(20, playerPropertyOwner.Money);
        }


        [TestMethod]
        public void ShouldPayRentShouldReturnFalse()
        {
            Board board = new Board(new string[] { "50 100" });
            ExposedGameManager game = new ExposedGameManager(board);

            Tile property = board.Tiles[0];
            
            Player player = new RandomPlayer("Random");
            game.AddPlayers(player);

            property.Owner = null;
            Assert.IsFalse(game.ShouldPayRent(property, player));

            property.Owner = player;
            Assert.IsFalse(game.ShouldPayRent(property, player));
        }

        [TestMethod]
        public void ShouldPayRentShouldReturnTrue()
        {
            Board board = new Board(new string[] { "50 100" });
            ExposedGameManager game = new ExposedGameManager(board);

            Tile property = board.Tiles[0];

            Player player = new RandomPlayer("Random");
            game.AddPlayers(player);

            property.Owner = new RandomPlayer("Random2");
            Assert.IsTrue(game.ShouldPayRent(property, player));
        }


        [TestMethod]
        public void IsPlayerBankruptShouldReturnFalse()
        {
            Board board = new Board(new string[] { "50 100" });
            ExposedGameManager game = new ExposedGameManager(board);

            Player player = new RandomPlayer("Random");
            game.AddPlayers(player);

            player.Money = 0;
            Assert.IsFalse(game.IsPlayerBankrupt(player));

            player.Money = 1000;
            Assert.IsFalse(game.IsPlayerBankrupt(player));
        }

        [TestMethod]
        public void IsPlayerBankruptShouldReturnTrue()
        {
            Board board = new Board(new string[] { "50 100" });
            ExposedGameManager game = new ExposedGameManager(board);

            Player player = new RandomPlayer("Random");
            game.AddPlayers(player);

            player.Money = -1;
            Assert.IsTrue(game.IsPlayerBankrupt(player));
        }

        [TestMethod]
        public void PayPlayerForCompletingTheBoardShouldIncreatePlayerMoney()
        {
            Board board = new Board(new string[] { "50 100" });
            ExposedGameManager game = new ExposedGameManager(board);

            Player player = new RandomPlayer("Random");
            player.Money = 0;
            game.AddPlayers(player);

            game.PayPlayerForCompletingTheBoard(player);

            Assert.AreEqual(100, player.Money);
        }

        [TestMethod]
        public void DeclarePlayerBankruptShouldRemoveThePlayerFromCollection()
        {
            Board board = new Board(new string[] { "50 100" });
            ExposedGameManager game = new ExposedGameManager(board);

            Player player = new RandomPlayer("Random");
            game.AddPlayers(player);

            game.DeclarePlayerBankrupt(player);

            Assert.AreEqual(0, game.ActivePlayers.Count);
        }

        [TestMethod]
        public void DeclarePlayerBankruptShouldResetPropertyOwner()
        {
            Player player = new RandomPlayer("Random");

            Board board = new Board(new string[] { "50 100" });
            board.Tiles[0].Owner = player;
            ExposedGameManager game = new ExposedGameManager(board);

            game.AddPlayers(player);

            game.DeclarePlayerBankrupt(player);

            Assert.AreEqual(null, board.Tiles[0].Owner);
        }

        [TestMethod]
        public void GetWinnerShouldReturnTheWinner()
        {
            Board board = new Board(new string[] { "50 100" });
            ExposedGameManager game = new ExposedGameManager(board);

            game.AddPlayers(new RandomPlayer("Random"));
            game.AddPlayers(new RandomPlayer("Random1"));
            game.AddPlayers(new RandomPlayer("Random2"));
            game.AddPlayers(new RandomPlayer("Random3"));

            Assert.AreEqual("Random", game.GetWinner().Name);
        }

        [TestMethod]
        public void IsGameCompletedShouldReturnFalse()
        {
            Board board = new Board(new string[] { "50 100" });
            ExposedGameManager game = new ExposedGameManager(board);

            //should return false when there is more than one player playing
            game.AddPlayers(new RandomPlayer("Random"));
            game.AddPlayers(new RandomPlayer("Random1"));

            Assert.IsFalse(game.IsGameCompleted());
        }

        [TestMethod]
        public void IsGameCompletedShouldReturnTrue()
        {
            Board board = new Board(new string[] { "50 100" });
            ExposedGameManager game = new ExposedGameManager(board);

            //should return true when there is only one player
            game.AddPlayers(new RandomPlayer("Random"));

            Assert.IsTrue(game.IsGameCompleted());
        }
    }
}
