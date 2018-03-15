using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BankruptTapps
{
    public class Board
    {
        public int Size {get; set;}
        public Property[] properties;

        public Board(string[] boardConfiguration)
        {
            this.Size = boardConfiguration.Length;
            this.properties = new Property[this.Size];
            for (int i = 0; i < this.Size; i++)
            {
                string[] piece = Regex.Replace(boardConfiguration[i].Trim(), @"\s+", " ").Split(' ');
                int buyPrice = int.Parse(piece[0]);
                int rentPrice = int.Parse(piece[1]);
                this.properties[i] = new Property(buyPrice, rentPrice);
            }
        }

        public void Clean()
        {
            foreach(Property property in properties)
            {
                property.Clean();
            }
        }
    }
}
