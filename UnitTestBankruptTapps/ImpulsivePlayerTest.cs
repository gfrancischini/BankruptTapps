using BankruptTapps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestBankruptTapps
{
    [TestClass]
    public class ImpulsivePlayerTest
    {

        [TestMethod]
        public void ShouldBuyPropertyReturnTrueAlways()
        {
            ImpulsivePlayer player = new ImpulsivePlayer("player");
            Tile property = new Tile(100, 50);
            property.BuyPrice = 100;
            player.Money = 180;
            Assert.IsTrue(player.ShouldBuyProperty(property));

            property.BuyPrice = 100;
            player.Money = 0;
            Assert.IsTrue(player.ShouldBuyProperty(property));

            property.BuyPrice = -100;
            player.Money = 0;
            Assert.IsTrue(player.ShouldBuyProperty(property));

            property.BuyPrice = 2000;
            player.Money = -10;
            Assert.IsTrue(player.ShouldBuyProperty(property));
        }
    }
}
