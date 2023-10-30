#ifndef __IMPULSIVEPLAYER_H__
#define __IMPULSIVEPLAYER_H__

#include "player.h"

class ImpulsivePlayer : public Player
{
public:
    ImpulsivePlayer(string name, int money) : Player("Impulsive " + name, money){};
    bool shouldBuy(Tile &tile);
};

#endif // __IMPULSIVEPLAYER_H__
