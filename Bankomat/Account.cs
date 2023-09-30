using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    public class Account
    {
        public int UserMatch(string userName)
        {
            int index = 0;
          return index;
        }
        public bool IsMatch()
        {
            Console.WriteLine();
            return true;
        }

        public static void Menu()
        {
            string menu1 = "1. Se dina konton och saldo";
            string menu2 = "2. Överföring mellan konton";
            string menu3 = "3. Ta ut pengar";
            string menu4 = "4. Logga ut";

            Console.WriteLine(menu1 + "\n" + menu2 + "\n" + menu3 + "\n" + menu4);

        }
    }
}
