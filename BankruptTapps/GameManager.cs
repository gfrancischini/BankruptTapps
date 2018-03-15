using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankruptTapps
{
    public class GameManager
    {
        public static int GAME_ROUND_DURATION = 1000;

        public Board Board {get; set;}
        private Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private List<Player> activePlayers = new List<Player>();
        private int currentRound = 0;
        Random random = new Random();


        public GameManager(Board board)
        {
            this.Board = board;
        }

        public void AddPlayers(Player player)
        {
            this.activePlayers.Add(player);
        }

      
        public int RunGame()
        {
            for (this.currentRound = 0; this.currentRound < GAME_ROUND_DURATION; this.currentRound++)
            {
                this.logger.Debug("Running Round {0} of {1}", currentRound, GAME_ROUND_DURATION);
                if(this.RunRound() == false)
                {
                    return currentRound;
                }
            }
            return currentRound;
        }

        public Player GetWinner()
        {
            //need to sort if there is more than one player
            return this.activePlayers[0];
        }

        public Boolean IsGameCompleted()
        {
            return this.activePlayers.Count <= 1;
        }

        public Boolean RunRound()
        {
            foreach(Player player in this.activePlayers.ToArray()) { 
                this.RunPlayerTurn(player);

                if (this.IsGameCompleted())
                {
                    this.logger.Debug("Game is completed");
                    return false;
                }
            }
            return true;
            
        }

        public void RunPlayerTurn(Player player)
        {
            Property property = this.MovePlayer(player);

            //verificar se tem aluguel
            if (this.ShouldPayRent(property, player))
            {
                //pay maximun rent
                this.PayRent(property, player);

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

            player.PrintPlayerInfo();
        }

        public void AskPlayerToBuyProperty(Player player, Property property)
        {
            if(player.Money > property.BuyPrice && player.ShouldBuyProperty(property))
            {
                    this.logger.Debug("Player {0} is buying the property {1} for ${2}", player.Name, 1, property.BuyPrice);
                    player.Money -= property.BuyPrice;
                    property.Owner = player;
            }
        }

        public void DeclarePlayerBankrupt(Player player)
        {
            this.logger.Debug("Player {0} is Bankrupt", player.Name);
            //every player property should be back to the board
            this.activePlayers.Remove(player);
        }


        public Property MovePlayer(Player player)
        {
            int dice = this.RollDice();
            int position = player.Position + dice;
            if(position >= this.Board.Size)
            {
                position -= this.Board.Size;
                this.PayPlayerForCompletingTheBoard(player);
            }
            player.Position = position;

            this.logger.Debug("Player {0} rolled the dice {1} and moved to position {2}", player.Name, dice, position);

            return this.Board.properties[position];
        }

        /// <summary>
        ///                 //monetize the player for running the entire board
        /// </summary>
        /// <param name="player"></param>
        public void PayPlayerForCompletingTheBoard(Player player)
        {
            this.logger.Debug("Player {0} was payed for completing the board", player.Name);
            player.Money += 100;
        }

        public Boolean IsPlayerBankrupt(Player player)
        {
            return player.Money < 0;
        }

        public void PayRent(Property property, Player renter)
        {
            this.logger.Debug("Player {0} is paying ${1} for Player {2} because of the rent price", renter.Name, property.RentPrice, 1);
            renter.Money -= property.RentPrice;
            int rentedPrice = property.RentPrice;
            if (renter.Money < 0)
            {
                rentedPrice -= renter.Money;
            }
            property.Owner.Money += rentedPrice;
        }

        public Boolean ShouldPayRent(Property property, Player player)
        {
            return property.Owner != null && property.Owner != player;
        }

        public int RollDice()
        {
            int diceSides = 6;
            
            return random.Next(1, diceSides + 1);
        }
    }
}
