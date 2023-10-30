#ifndef __CAUTIOUSPLAYER_H__
#define __CAUTIOUSPLAYER_H__

#include "player.h"

class CautiousPlayer : public Player
{
public:
    CautiousPlayer(string name, int money) : Player("Cautious  " + name, money){};
    bool shouldBuy(Tile &tile);
};

#endif // __CAUTIOUSPLAYER_H__