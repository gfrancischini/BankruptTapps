#ifndef __GAMEMANAGER_H__
#define __GAMEMANAGER_H__

#include "board.h"

class GameManager
{
public:
    GameManager(Board board);
    Board board;

    vector<shared_ptr<Player>> activePlayers{};
    void run();
    bool playRound();

    Tile *movePlayer(shared_ptr<Player> &player);
    void removeBankruptedPlayers();
    int rollDice();

private:
    int currentRound{0};
};
#endif // __GAMEMANAGER_H__