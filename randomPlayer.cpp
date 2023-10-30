

#include "randomPlayer.h"

bool RandomPlayer::shouldBuy(Tile &tile)
{
    // Random Player -> The random player buy any property with a random possibility of 50%
    return rand() % 2 + 1 == 1;
}
