using BankruptTapps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestBankruptTapps
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void BoardCleanShouldCleanOwners()
        {
            Board board = new Board(new string[] { "50 100", "200 300" });
            board.Tiles[0].Owner = new RandomPlayer("Random1");
            board.Tiles[1].Owner = new RandomPlayer("Random2");
            board.Clean();

            Assert.IsNull(board.Tiles[0].Owner);
            Assert.IsNull(board.Tiles[1].Owner);
        }

        [TestMethod]
        public void BoardRemovePlayerShouldCleanPlayerProperties()
        {
            Board board = new Board(new string[] { "50 100", "200 300" });

            Player owner = new RandomPlayer("Random1");
            board.Tiles[0].Owner = owner;

            Player owner2 = new RandomPlayer("Random2");
            board.Tiles[1].Owner = owner2;

            board.RemovePlayer(owner);

            Assert.IsNull(board.Tiles[0].Owner);
            Assert.AreEqual(owner2, board.Tiles[1].Owner);
        }
    }
}
