using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    public class Account
    {
        public int NameCheck()
        {
            string[] userNames = { "AYA", "AKI", "TOBIAS", "MUSSEPIG", "DONALD" };
            int index = 0;
            Console.Write("Insert your name: ");
            string inputName = Console.ReadLine();
            for (int i = 0; i < userNames.Length; i++)
            {
                if (userNames[i] == inputName.ToUpper())
                {
                    index = i;  
                    return index;
                }
            }
            return -1;
        }
        public bool PassCheck(int index)
        {
            int[] passWords = { 1234, 1221, 2345, 3456, 4567 };
            for (int i = 0; i < 3; i++) 
            {
                Console.Write("Insert your password: ");
                int inputPass = Convert.ToInt32(Console.ReadLine());
                if (passWords[index] == inputPass)
                {
                    Console.WriteLine("Login succeded");
                    Console.ReadKey();
                    return true;
                }
                else
                    Console.WriteLine("Password is not correct.");
            }
            Console.WriteLine("You tried 3 times. Please try again after 3 minutes.\n Either username or password is not correct.");
            return false;   
        }
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("What can I help you today?");
            string menu1 = "1. Se dina konton och saldo";
            string menu2 = "2. Överföring mellan konton";
            string menu3 = "3. Ta ut pengar";
            string menu4 = "4. Logga ut";
            Console.WriteLine(menu1 + "\n" + menu2 + "\n" + menu3 + "\n" + menu4);
        }
        public static void CheckBalance(List<double>a, int index)
        {
            Console.WriteLine(a[index]);
            Console.ReadKey();
        }
        public static void Move(List<double>a, int index, double money, int x)
        {
            a[index] -= money;
            a[x] += money;
        }
        public static void Remove(List<double> a, int index, double money)
        {
            a[index] -= money;
        }

    }
}
