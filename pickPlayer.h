#ifndef __PICKPLAYER_H__
#define __PICKPLAYER_H__

#include "player.h"

class PickPlayer : public Player
{
public:
    PickPlayer(string name, int money) : Player("Pick " + name, money){};
    bool shouldBuy(Tile &tile);
};

#endif // __PICKPLAYER_H__