using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankruptTapps
{
    public class Player
    {
        public String Name { get; set; }

        public int Money { get; set; }

        public int Position { get; set; }

        private Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public Player(String name)
        {
            this.Name = name;
            this.Money = 100;
            this.Position = 0;
        }

        public void PrintPlayerInfo()
        {
            logger.Debug("--------------------------------------------------------------------");
            logger.Debug("Player {0}\nMoney: ${1}\nPosition: {2}", this.Name, this.Money, this.Position);
            logger.Debug("--------------------------------------------------------------------");
        }
      
        public Boolean ShouldBuyProperty(Property property)
        {
            return true;
        }

        public void Move()
        {

        }

       
    }
}
