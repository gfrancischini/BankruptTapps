using System;
using System.Collections.Generic;
using System.Text;

namespace BankruptTapps
{
    class PickyPlayer : Player
    {
        /// <summary>
        /// Create a new picky player instance
        /// </summary>
        /// <param name="name"></param>
        public PickyPlayer(String name) : base(name)
        {

        }

        /// <summary>
        /// Implement the picky player logic
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public override bool ShouldBuyProperty(Tile property)
        {
            //O jogador exigente compra qualquer propriedade, desde que o aluguel dela seja maior do
            //que 50 coins.            if(property.RentPrice >= 50)
            {
                return true;
            }
            return false;
        }
    }
}
