using System;
using System.Collections.Generic;
using System.Text;

namespace BankruptTapps
{
    public class RandomPlayer : Player
    {
        private static Random random = new Random();
        /// <summary>
        /// Create a new random player instance
        /// </summary>
        /// <param name="name"></param>
        public RandomPlayer(String name) : base(name)
        {

        }

        /// <summary>
        /// Implement the random player logic
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public override bool ShouldBuyProperty(Tile property)
        {
            //O jogador aleatório compra a propriedade que ele parar em cima com probabilidade de 50 %.
            return random.Next(0, 2) == 1;
        }
    }
}
