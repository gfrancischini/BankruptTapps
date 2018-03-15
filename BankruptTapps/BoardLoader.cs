using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BankruptTapps
{
    public class BoardLoader
    {
        /// <summary>
        /// Parse board configuration file
        /// </summary>
        /// <param name="boardConfigurationPath"></param>
        /// <returns></returns>
        public string[] ParseConfiguration(string boardConfigurationPath)
        {
            string configuration = Utils.ReadFile(boardConfigurationPath);
            string[] lines = configuration.Split('\n');
            return lines;
        }

        /// <summary>
        /// Create a new board based on the configuration file
        /// </summary>
        /// <returns></returns>
        public Board CreateBoard()
        {
            string[] boardConfiguration = this.ParseConfiguration(Path.Combine(Directory.GetCurrentDirectory(), "gameConfig.txt"));
            return new Board(boardConfiguration);
        }
    }
}
