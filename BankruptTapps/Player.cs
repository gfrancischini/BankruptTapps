using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankruptTapps
{
    public abstract class Player
    {
        private Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The current players name
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// The amount of money that the player has
        /// </summary>
        public int Money { get; set; }

        /// <summary>
        /// The current player position
        /// </summary>
        public int Position { get; set; }


        /// <summary>
        /// Build a new player
        /// </summary>
        /// <param name="name"></param>
        public Player(String name)
        {
            this.Name = name;
            this.Money = 100;
            this.Position = 0;
        }

        /// <summary>
        /// Print message about player information
        /// </summary>
        public void PrintPlayerInfo()
        {
            logger.Debug("--------------------------------------------------------------------");
            logger.Debug("Player {0}\nMoney: ${1}\nPosition: {2}", this.Name, this.Money, this.Position);
            logger.Debug("--------------------------------------------------------------------");
        }

        /// <summary>
        /// Check if the player should buy the property
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public abstract Boolean ShouldBuyProperty(Tile property);

    }
}
