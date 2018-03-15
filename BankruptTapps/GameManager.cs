using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankruptTapps
{
    public class GameManager
    {
        public static int GAME_ROUND_DURATION = 1000;
        private Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private Random random = new Random();

        /// <summary>
        /// The board surface
        /// </summary>
        protected Board Board {get; set;}

        /// <summary>
        /// The players that are still playing
        /// </summary>
        protected List<Player> ActivePlayers { get; set; } = new List<Player>();

        /// <summary>
        /// The current round that is being played
        /// </summary>
        protected int CurrentRound { get; set; } = 0;
        

        /// <summary>
        /// Instantiate a new game manager
        /// </summary>
        /// <param name="board"></param>
        public GameManager(Board board)
        {
            this.Board = board;

            //as we are reusing the board as it could be a large board that is expensive to calculate
            //we need to make sure we clean it
            this.Board.Clean();
        }

        /// <summary>
        /// Add players to this instance
        /// </summary>
        /// <param name="player"></param>
        public void AddPlayers(Player player)
        {
            this.ActivePlayers.Add(player);
        }

        /// <summary>
        /// Run the game until there is a winner or timeout
        /// </summary>
        /// <returns></returns>
        public int RunGame()
        {
            for (this.CurrentRound = 0; this.CurrentRound < GAME_ROUND_DURATION; this.CurrentRound++)
            {
                this.logger.Debug("Running Round {0} of {1}", CurrentRound, GAME_ROUND_DURATION);
                if(this.RunRound() == false)
                {
                    return this.CurrentRound;
                }
            }
            return this.CurrentRound;
        }

        /// <summary>
        /// Retrieve the winner players
        /// </summary>
        /// <returns></returns>
        public Player GetWinner()
        {
            //need to sort if there is more than one player
            return this.ActivePlayers[0];
        }

        /// <summary>
        /// Check if the game is completed
        /// </summary>
        /// <returns></returns>
        protected Boolean IsGameCompleted()
        {
            return this.ActivePlayers.Count <= 1;
        }

        /// <summary>
        /// Run a round
        /// </summary>
        /// <returns></returns>
        protected Boolean RunRound()
        {
            foreach(Player player in this.ActivePlayers.ToArray()) { 
                this.RunPlayerTurn(player);

                if (this.IsGameCompleted())
                {
                    this.logger.Debug("Game is completed");
                    return false;
                }
            }
            return true;
            
        }

        /// <summary>
        /// Run a player turn
        /// </summary>
        /// <param name="player"></param>
        protected void RunPlayerTurn(Player player)
        {
            //move the player to the correct place
            Tile property = this.MovePlayer(player);

            //verify if player should pay the rent
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

        /// <summary>
        /// Check if player want to buy the property
        /// </summary>
        /// <param name="player"></param>
        /// <param name="property"></param>
        protected void AskPlayerToBuyProperty(Player player, Tile property)
        {
            if(player.Money > property.BuyPrice && player.ShouldBuyProperty(property))
            {
                    this.logger.Debug("Player {0} is buying the property {1} for ${2}", player.Name, 1, property.BuyPrice);
                    player.Money -= property.BuyPrice;
                    property.Owner = player;
            }
        }

        /// <summary>
        /// Declare player bankrupt (out of money)
        /// </summary>
        /// <param name="player"></param>
        protected void DeclarePlayerBankrupt(Player player)
        {
            this.logger.Debug("Player {0} is Bankrupt", player.Name);
            //every player property should be back to the board
            this.ActivePlayers.Remove(player);

            this.Board.RemovePlayer(player);
        }

        /// <summary>
        /// Move the player to the correct place
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        protected Tile MovePlayer(Player player)
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

            return this.Board.GetTileAtPosition(position);
        }

        /// <summary>
        /// Pay the player for running the entire board
        /// </summary>
        /// <param name="player"></param>
        protected void PayPlayerForCompletingTheBoard(Player player)
        {
            this.logger.Debug("Player {0} was payed for completing the board", player.Name);
            player.Money += 100;
        }

        /// <summary>
        /// Check if player is bankrupt
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        protected Boolean IsPlayerBankrupt(Player player)
        {
            return player.Money < 0;
        }

        /// <summary>
        /// Make player pay the rent
        /// </summary>
        /// <param name="property"></param>
        /// <param name="renter"></param>
        protected void PayRent(Tile property, Player renter)
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

        /// <summary>
        /// Check if the player should play the rent
        /// </summary>
        /// <param name="property"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        protected Boolean ShouldPayRent(Tile property, Player player)
        {
            return property.Owner != null && property.Owner != player;
        }

        /// <summary>
        /// Roll the dice
        /// </summary>
        /// <returns></returns>
        protected int RollDice()
        {
            int diceSides = 6;
            return random.Next(1, diceSides + 1);
        }
    }
}
