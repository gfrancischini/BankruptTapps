using System;
using System.Collections.Generic;
using System.Text;

namespace BankruptTapps
{
    public class Board
    {
        public int Size {get; set;}
        public Property[] properties;

        public Board()
        {
            this.Size = 20;
            this.properties = new Property[this.Size];
            for (int i = 0; i < this.Size; i++)
            {
                this.properties[i] = new Property();
            }
        }

        public void DoPlay()
        {
            
        }
    }
}
