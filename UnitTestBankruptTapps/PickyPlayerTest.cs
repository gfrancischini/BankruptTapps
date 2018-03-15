using BankruptTapps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestBankruptTapps
{
    [TestClass]
    public class PickyPlayerTest
    {

        [TestMethod]
        public void ShouldBuyPropertyReturnTrueIfRentGreaterThan50()
        {
            PickyPlayer player = new PickyPlayer("player");
            Tile property = new Tile(100, 50);
            property.RentPrice = 50;
            player.Money = 180;
            Assert.IsTrue(player.ShouldBuyProperty(property));
        }

        [TestMethod]
        public void ShouldBuyPropertyReturnFalseIfRentLeftLessThan50()
        {
            PickyPlayer player = new PickyPlayer("player");
            Tile property = new Tile(100, 50);
            property.RentPrice = 49;
            player.Money = 180;
            Assert.IsFalse(player.ShouldBuyProperty(property));
        }
    }
}
