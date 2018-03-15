using System;
using System.Collections.Generic;
using System.Text;

namespace BankruptTapps
{
    public class Utils
    {
        /// <summary>
        /// Read the entire file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ReadFile(string path)
        {
            return System.IO.File.ReadAllText(path);
        }

    }
}
