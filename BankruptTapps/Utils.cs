using System;
using System.Collections.Generic;
using System.Text;

namespace BankruptTapps
{
    public class Utils
    {
        public static string ReadFile(string path)
        {
            return System.IO.File.ReadAllText(path);
        }

    }
}
