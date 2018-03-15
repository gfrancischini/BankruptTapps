using System;
using System.Collections.Generic;
using System.Text;

namespace BankruptTapps
{
    public class Tile
    {
        /// <summary>
        /// The tile name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The price required for renting the property. Integer because the values from the file are all integer
        /// This class can be overriden in the future and implement a custom rent price getter including hotels, houses.
        /// </summary>
        public int RentPrice { get; set; }

        /// <summary>
        /// The price for buying the property
        /// </summary>
        public int BuyPrice { get; set; }

        /// <summary>
        /// The current property owner. Can be null when the property has no owner
        /// </summary>
        public Player Owner { get; set; }

        public Tile(string name, int buyPrice, int rentPrice)
        {
            this.Name = name;
            this.BuyPrice = buyPrice;
            this.RentPrice = rentPrice;
            this.Owner = null;
        }

        /// <summary>
        /// Clean the current property tile
        /// </summary>
        public void Clean()
        {
            this.Owner = null;
        }
    }
}
