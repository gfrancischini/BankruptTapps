﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace BankruptTapps
{
    public class Board
    {
        /// <summary>
        /// The board size
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// The board tiles
        /// </summary>
        public Tile[] Tiles { get; set; }

        public Board(string[] boardConfiguration)
        {
            this.Size = boardConfiguration.Length;
            this.Tiles = new Tile[this.Size];
            for (int i = 0; i < this.Size; i++)
            {
                string[] piece = Regex.Replace(boardConfiguration[i].Trim(), @"\s+", " ").Split(' ');
                int buyPrice = int.Parse(piece[0]);
                int rentPrice = int.Parse(piece[1]);
                this.Tiles[i] = new Tile(i.ToString(), buyPrice, rentPrice);
            }
        }

        /// <summary>
        /// Clean the board
        /// </summary>
        public void Clean()
        {
            foreach (Tile property in Tiles)
            {
                property.Clean();
            }
        }


        /// <summary>
        /// Remove the properties that are associated with the player
        /// </summary>
        /// <param name="player"></param>
        public void RemovePlayer(Player player)
        {
            foreach (Tile property in this.Tiles)
            {
                if (property.Owner == player)
                {
                    property.Owner = null;
                }
            }
        }

        /// <summary>
        /// Get the property at the given position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Tile GetTileAtPosition(int position)
        {
            return this.Tiles[position];
        }
    }
}
