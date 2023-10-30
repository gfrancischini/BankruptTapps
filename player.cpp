#include "player.h"
#include <iostream>
#include "tile.h"

Player::Player(string name, int money) : name{name}, money{money}, position{0} {}

Player::~Player()
{
    std::cout << "Destroying " << this->name << std::endl;
}

void Player::setPosition(int position)
{
    this->position = position;
}

int Player::getPosition()
{
    return this->position;
}

string Player::getName()
{
    return this->name;
}

int Player::getMoney()
{
    return this->money;
}

bool Player::shouldBuy(Tile &tile)
{
    if (this->getMoney() - tile.getBuyPrice() >= 0)
    {
        return true;
    }
    return false;
}

int Player::payMoney(int amount)
{
    // we need to check if the player has enought money to pay the rent
    if (this->money - amount < 0)
    {
        // not enought money so he will give everything he has
        int availableMoney = this->money;
        // indicates that he is bankrupted
        this->money = -1;
        return availableMoney;
    }
    this->money -= amount;
    return amount;
}

int Player::receiveMoney(int amount)
{
    this->money += amount;
    return this->money;
}
