using System;
using System.Collections.Generic;
using System.Text;

namespace BankruptTapps
{
    public class Player
    {
        public int Money { get; set; }

        public int Position { get; set; }

        public Player()
        {
            this.Money = 100;
            this.Position = 0;
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
