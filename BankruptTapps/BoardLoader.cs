using System;
using System.Collections.Generic;
using System.Text;

namespace BankruptTapps
{
    public class BoardLoader
    {
        public string[] ParseConfiguration(string boardConfigurationPath)
        {
            string configuration = Utils.ReadFile(boardConfigurationPath);
            string[] lines = configuration.Split('\n');
            return lines;
        }

        public Board CreateBoard()
        {
            string[] boardConfiguration = this.ParseConfiguration("C:\\Git\\BankruptTapps\\BankruptTapps\\gameConfig.txt");
            return new Board(boardConfiguration);
        }
    }
}
