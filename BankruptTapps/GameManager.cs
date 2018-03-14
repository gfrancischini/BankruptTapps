using System;
using System.Collections.Generic;
using System.Text;

namespace BankruptTapps
{
    public class GameManager
    {
        public Board Board {get; set;}
        public Player[] players = new Player[4];

        public GameManager()
        {
            this.Board = new Board();

            for(int i = 0; i < 4; i++)
            {
                this.players[i] = new Player();
            }
        }

        public void RunGame()
        {
            for (int i = 0; i < 1000; i++)
            {
                if(this.IsGameCompleted())
                {
                    return;
                }
                RunTurn();
            }
        }

        public Boolean IsGameCompleted()
        {
            return false;
        }

        public void RunTurn()
        {
            for(int i = 0; i < 4; i++)
            {
                this.RunPlayerTurn(this.players[0]);
            }
        }

        public void RunPlayerTurn(Player player)
        {
            Property property = this.MovePlayer(player);

            //verificar se tem aluguel
            if (this.ShouldPayRent(null))
            {
                //pay maximun rent
                this.PayRent(null, player);

                //check for bankrupt
                if(this.IsPlayerBankrupt(player))
                {
                    this.DeclarePlayerBankrupt(player);
                }
            }
            else
            {
                this.AskPlayerToBuyProperty(player, property);
            }
        }

        public void AskPlayerToBuyProperty(Player player, Property property)
        {
            if(player.ShouldBuyProperty(property))
            {
                if(player.Money > property.BuyPrice)
                {
                    player.Money -= property.BuyPrice;
                    property.Owner = player;
                }
            }
        }

        public void DeclarePlayerBankrupt(Player player)
        {
            //every player property should be back to the board
        }


        public Property MovePlayer(Player player)
        {
            int dice = this.RollDice();
            int position = player.Position + dice;
            if(position >= this.Board.Size)
            {
                position -= this.Board.Size;
                //monetize the player for running the entire board

                this.PayPlayerForCompletingTheBoard(player);
            }

            return this.Board.properties[position];
        }

        public void PayPlayerForCompletingTheBoard(Player player)
        {
            player.Money += 100;
        }

        public Boolean IsPlayerBankrupt(Player player)
        {
            return player.Money < 0;
        }

        public void PayRent(Property property, Player renter)
        {
            renter.Money -= property.RentPrice;
            int rentedPrice = property.RentPrice;
            if (renter.Money < 0)
            {
                rentedPrice -= renter.Money;
            }
            property.Owner.Money += rentedPrice;
        }

        public Boolean ShouldPayRent(Property property)
        {
            return property.Owner != null;
        }

        public int RollDice()
        {
            int diceSides = 6;
            Random random = new Random();
            return random.Next(1, diceSides + 1);
        }
    }
}
