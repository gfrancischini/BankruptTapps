
#include "tile.h"
#include "player.h"
#include <iostream>

using namespace std;

Tile::Tile(int buyPrice, int rentPrice) : buyPrice{buyPrice}, rentPrice{rentPrice}
{
}

bool Tile::hasOwner()
{
    auto owner = this->owner.lock();
    return owner != NULL;
    // return this->owner != NULL;
}

// Player *Tile::getOwner()
// {
//     return this->owner;
// }

int Tile::getBuyPrice()
{
    return buyPrice;
}

int Tile::getRentPrice()
{
    return rentPrice;
}

void Tile::buy(shared_ptr<Player> &player)
{
    this->owner = weak_ptr<Player>(player);
    player->payMoney(this->buyPrice);
}

int Tile::payRent(Player *tenant)
{
    auto owner = this->owner.lock();
    if (owner == NULL)
    {
        // when the tile has no owner no rent is payed
        return 0;
    }
    if (owner.get() == tenant)
    {
        // the tenant is the owner so he doesn't need to pay rent
        return 0;
    }
    int payedAmount = tenant->payMoney(this->rentPrice);
    owner->receiveMoney(payedAmount);

    cout << "Player " << tenant->getName() << " ($" << tenant->getMoney() << ") payed the rent " << payedAmount << " to " << owner->getName() << endl;
    return payedAmount;
}