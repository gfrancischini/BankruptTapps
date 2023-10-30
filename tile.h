#ifndef __TILE_H__
#define __TILE_H__

#include "player.h"

class Tile
{
public:
    Tile(int buyPrice, int rentPrice);

    bool hasOwner();
    int getBuyPrice();
    int getRentPrice();
    void buy(shared_ptr<Player> &player);
    int payRent(Player *tenant);

private:
    int buyPrice;
    int rentPrice;
    weak_ptr<Player> owner;
};

#endif // __TILE_H__