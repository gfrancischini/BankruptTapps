#include "gameManager.h"
#include "impulsivePlayer.h"
#include "pickPlayer.h"
#include "randomPlayer.h"
#include "cautiousPlayer.h"

#include <iostream>

const int GAME_ROUND_DURATION = 1000;
const int DICE_SIDES = 6;

bool MatchMember(Player m1, Player m2)
{
    return m1.getName() == m2.getName();
}

GameManager::GameManager(Board board) : board(board)
{
    // Player *player = new ImpulsivePlayer("Player 1", 100);

    this->activePlayers.push_back(make_shared<ImpulsivePlayer>("Player 1", 100));
    this->activePlayers.push_back(make_shared<PickPlayer>("Player 2", 100));
    this->activePlayers.push_back(make_shared<RandomPlayer>("Player 3", 100));
    this->activePlayers.push_back(make_shared<CautiousPlayer>("Player 4", 100));
}

void GameManager::run()
{
    cout << "Game started" << endl;
    for (this->currentRound = 0; this->currentRound < GAME_ROUND_DURATION; this->currentRound++)
    {
        cout << "Round " << this->currentRound << endl;
        if (!this->playRound())
        {
            cout << "End of Game" << endl;
            break;
        }
    }

    if (this->activePlayers.size() == 1)
    {
        cout << "The winner is " << this->activePlayers[0]->getName() << endl;
    }
    else
    {
        // print draw message with active players names
        cout << "Draw " << this->activePlayers.size() << endl;
    }
}

bool GameManager::playRound()
{
    for (auto &player : this->activePlayers)
    {
        Tile *tile = this->movePlayer(player);
        // we need to check if the current tile has a owner
        // and also make sure that the current player is not the owner of the tile
        if (tile->hasOwner())
        {
            int payedRent = tile->payRent(player.get());
        }
        else
        {
            if (player->getMoney() >= tile->getBuyPrice() && player->shouldBuy(*tile))
            {
                tile->buy(player);
                cout << "Player " << player->getName() << " ($" << player->getMoney() << ") bought the tile " << player->getPosition() << " $" << tile->getBuyPrice() << endl;
            }
            else
            {
                cout << "Player " << player->getName() << " is on tile " << player->getPosition() << " without owner" << endl;
            }
        }
    }

    this->removeBankruptedPlayers();

    if (this->activePlayers.size() == 1)
    {
        return false;
    }
    return true;
}

void GameManager::removeBankruptedPlayers()
{
    // remove the bankrupted player from the active players
    this->activePlayers.erase(std::remove_if(this->activePlayers.begin(),
                                             this->activePlayers.end(),
                                             [](shared_ptr<Player> vPlayer)
                                             {
                                                 if (vPlayer->getMoney() < 0)
                                                 {
                                                     cout << "Player " << vPlayer->getName() << " is bankrupted" << endl;
                                                     return true;
                                                 }
                                                 return false;
                                             }),
                              this->activePlayers.end());
}

Tile *GameManager::movePlayer(shared_ptr<Player> &player)
{
    int dice = this->rollDice();

    unsigned long position = player->getPosition() + dice;

    cout << "Player " << player->getName() << " ($" << player->getMoney() << ") rolled the dice " << dice << " and moved to position " << position << endl;

    if (position >= this->board.tiles.size())
    {
        // reset the player position as he completed a full turn on the board
        position -= this->board.tiles.size();

        // and also give him some money
        player->receiveMoney(100);

        cout << "Player " << player->getName() << " ($" << player->getMoney() << ") received money for completing the full board" << endl;
    }

    player->setPosition(position);

    return &this->board.tiles[position];
}

int GameManager::rollDice()
{
    return rand() % DICE_SIDES + 1; // between dice_size and 1
}
