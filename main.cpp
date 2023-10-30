#include <iostream>
#include "board.h"
#include "gameManager.h"

#include <filesystem>

using namespace std;

int main()
{
    srand((unsigned int)time(NULL));
    // srand(0);
    std::cout << "Current path is " << std::filesystem::current_path() << '\n';

    Board board = loadBoard("default");

    GameManager gameManager{board};

    gameManager.run();
}