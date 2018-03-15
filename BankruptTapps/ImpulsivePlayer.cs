using System;
using System.Collections.Generic;
using System.Text;

namespace BankruptTapps
{
    class ImpulsivePlayer : Player
    {
        /// <summary>
        /// Create a new impulsive player instance
        /// </summary>
        /// <param name="name"></param>
        public ImpulsivePlayer(String name) : base(name)
        {

        }

        /// <summary>
        /// Implement the impulsive player logic
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public override bool ShouldBuyProperty(Tile property)
        {
            //O jogador impulsivo compra qualquer propriedade sobre a qual ele parar.
            return true;
        }
    }
}
