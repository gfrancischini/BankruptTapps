using BankruptTapps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestBankruptTapps
{
    [TestClass]
    public class CautiousPlayerTest
    {

        [TestMethod]
        public void ShouldBuyPropertyReturnTrueIfMoneyLeftGreaterThan80()
        {
            CautiousPlayer player = new CautiousPlayer("player");
            Tile property = new Tile("tile", 100, 50);
            property.BuyPrice = 100;
            player.Money = 180;
            Assert.IsTrue(player.ShouldBuyProperty(property));
        }

        [TestMethod]
        public void ShouldBuyPropertyReturnFalseIfMoneyLeftLessThan80()
        {
            CautiousPlayer player = new CautiousPlayer("player");
            Tile property = new Tile("tile", 100, 50);
            property.BuyPrice = 100;
            player.Money = 179;
            Assert.IsFalse(player.ShouldBuyProperty(property));
        }
    }
}
