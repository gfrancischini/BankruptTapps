#ifndef __PLAYER_H__
#define __PLAYER_H__

#include <string>
using namespace std;

class Tile;

class Player
{
public:
    Player(string name, int money);
    ~Player();

    void setPosition(int position);

    int getPosition();
    string getName();

    int getMoney();

    int payMoney(int amount);

    int receiveMoney(int amount);

    virtual bool shouldBuy(Tile &tile);

private:
    string name;
    int money;
    int position;
};
#endif // __PLAYER_H__