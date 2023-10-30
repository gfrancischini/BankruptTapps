#include <iostream>
#include <fstream>
#include <sstream>

#include <filesystem>

#include "board.h"
#include "tile.h"

using namespace std;
namespace fs = std::filesystem;

Board::Board(std::vector<Tile> tiles) : tiles(tiles)
{
}

Board loadBoard(string boardName)
{
    string board = "";
    string line;
    string column;
    auto boardPath = fs::current_path().string() + "/boards/" + boardName + ".txt";
    cout << boardPath << endl;
    std::ifstream ifs;

    ifs.open(boardPath, std::ios::in);

    std::vector<Tile> tiles{};
    if (ifs)
    {
        while (!ifs.eof())
        {
            while (std::getline(ifs, line))
            {
                istringstream ss{line};
                vector<string> internal;
                while (std::getline(ss, column, ' '))
                {
                    internal.push_back(column);
                }

                tiles.push_back(Tile(stoi(internal[0]), stoi(internal[1])));
                internal.clear();
            }
        }
        ifs.close();
    }
    else
        std::cout << "Unable to open file to read" << std::endl;

    return Board{tiles};
}