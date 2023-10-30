#ifndef __BOARD_H__
#define __BOARD_H__

#include "tile.h"

using namespace std;
namespace fs = std::filesystem;

class Board
{
public:
    Board(std::vector<Tile> tiles);
    std::vector<Tile> tiles{};
};

Board loadBoard(string boardName);

#endif // __BOARD_H__