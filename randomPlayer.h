#ifndef __RANDOMPLAYER_H__
#define __RANDOMPLAYER_H__

#include "player.h"

class RandomPlayer : public Player
{
public:
    RandomPlayer(string name, int money) : Player("Random " + name, money){};
    bool shouldBuy(Tile &tile);
};

#endif // __RANDOMPLAYER_H__