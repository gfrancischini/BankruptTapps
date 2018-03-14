﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankruptTapps
{
    public class Property
    {
        /// <summary>
        /// The price required for renting the property. Integer because the values from the file are all integer
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

        public Property()
        {
            this.RentPrice = 10;
            this.BuyPrice = 20;
            this.Owner = null;
        }
    }
}
