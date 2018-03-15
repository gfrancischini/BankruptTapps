using System;
using System.Collections.Generic;
using System.Text;

namespace BankruptTapps
{
    class CautiousPlayer : Player
    {
        /// <summary>
        /// Create a new cautious player instance
        /// </summary>
        /// <param name="name"></param>
        public CautiousPlayer(String name) : base(name)
        {

        }

        /// <summary>
        /// Implement the cautios player logic
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public override bool ShouldBuyProperty(Tile property)
        {
            //O jogador cauteloso compra qualquer propriedade desde que ele tenha uma reserva de
            //80 coins sobrando depois de realizada a compra.
            if (this.Money - property.BuyPrice >= 80)
            {
                return true;
            }
            return false;
        }
    }
}
