

#include "pickPlayer.h"
#include "tile.h"

bool PickPlayer::shouldBuy(Tile &tile)
{
    // Picky Player -> The pick player only buy properties that the Rent Value is greater than 50 coins

    if (tile.getRentPrice() >= 50)
    {
        return true;
    }
    return false;
}
