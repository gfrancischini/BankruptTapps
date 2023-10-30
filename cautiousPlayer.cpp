

#include "cautiousPlayer.h"
#include "tile.h"

bool CautiousPlayer::shouldBuy(Tile &tile)
{
    // Cautious Player -> The cautious player only buy properties if after paying
    // for the property his bank account has at least 80 coins left.

    if (this->getMoney() - tile.getBuyPrice() >= 80)
    {
        return true;
    }
    return false;
}
