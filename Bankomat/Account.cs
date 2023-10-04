using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    public class Account
    {
        private string[] UserNames = { "AYA", "AKI", "TOBIAS", "MUSSEPIG", "OLLE" };
        private int[] PassWords = { 1103, 1221, 2345, 3456, 0901 };
        private string[] AccountNames= { "Lönekonto", "Sparkonto", "Aktiekonto", "Betalkonto", "Privatkonto" };
        private decimal[][] Balance = new decimal[5][] 
        {
        new decimal[] { 12340, 1234 },
        new decimal[] { 234, 2345, 234 },
        new decimal[] { 123, 234 },
        new decimal[] { 45999, 56778, 3456 },
        new decimal[] { 123, 234 }
        };
        public int CheckName()
        {
            int index = 0;
            Console.Write("Ange ditt namn: ");
           
                string inputName = Console.ReadLine();
                for (int i = 0; i < UserNames.Length; i++)
                {
                    if (UserNames[i] == inputName.ToUpper())
                    {
                        index = i;
                        return index;
                    }
                }
            return -1;
        }
        public bool CheckPass(int index)
        {
            if (index == -1)
            {
                Console.WriteLine("Fel användarnamn. Försök igen.");
                Console.ReadKey();
                return false;
            }
                for (int i = 0; i < 3; i++)
                {
                Console.Write("Ange password: ");
                try { 
                    int inputPass = Convert.ToInt32(Console.ReadLine());
                
                    if (PassWords[index] == inputPass)
                        return true;
                    else
                        Console.WriteLine("Password is not correct.");
                    }
                    catch (Exception e)
                    {
                    Console.WriteLine("Fel pin-kod! Vänligen försök igen.");
                    }
                }

            Console.WriteLine("You tried 3 times. Please try again after 3 minutes.");
            Thread.Sleep(1000*60*3);
            return false;
        }
    
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Vad vill du göra?");
            string menu1 = "1. Se dina konton och saldo";
            string menu2 = "2. Överföring mellan konton";
            string menu3 = "3. Ta ut pengar";
            string menu4 = "4. Sätta in pengar";
            string menu5 = "5. Logga ut";
            Console.WriteLine("\n\t"+menu1 + "\n\t" + menu2 + "\n\t" + menu3 + "\n\t" + menu4 + "\n\t" + menu5);
        }
        public void CheckBalance(int index)
        {
            Console.Clear();
            Console.WriteLine("--------Dina konto hos oss--------");
            for (int i = 0; i < Balance[index].Length; i++) {
                Console.WriteLine( $"Saldo på {AccountNames[i]} : {Balance[index][i]} kr");
            }
            Console.WriteLine("\nKlicka enter för att komma till huvudmenyn");
            Console.ReadKey();
        }
        public bool XisNotValid(int x, int index)
        {
            if (x <= 0 || x > Balance[index].Length)
            {
                Console.WriteLine($"Ange ett tal mellan 1 till {Balance[index].Length}");
                Console.ReadKey();
            }
            return true;
        }
        public void Transfer (int index)
        {
            Console.Clear();
            Console.WriteLine("--------Överföra pengar--------");
            Console.WriteLine("Vilket konto vill du överföra pengar från?");
            for (int i = 0; i < Balance[index].Length; i++)
                Console.WriteLine((i+1) + ". " + AccountNames[i]);
            int x = Convert.ToInt32(Console.ReadLine());
            //if (XisNotValid(x, index))
                if (x <= 0 || x > Balance[index].Length)
                {
                    Console.WriteLine($"Ange ett tal mellan 1 till {Balance[index].Length}");
                    Console.ReadKey();
                    return;
                }
            Console.WriteLine("Vilket konto vill du lägga pengar till?");
            int y = Convert.ToInt32(Console.ReadLine());
            //if (XisNotValid(y, index))
            if (y <= 0 || y > Balance[index].Length)
            {
                Console.WriteLine($"Ange ett tal mellan 1 till {Balance[index].Length}");
                Console.ReadKey();
                return;
            }
            Console.Write("Summa: ");
            decimal money = Convert.ToDecimal(Console.ReadLine());
            if (Balance[index][x - 1] < money) { 
                Console.WriteLine("You cannot do this action. You do not have enough money.");
                return;
            }
            else 
            { 
                Balance[index][x-1] -= money;
                Balance[index][y-1] += money;
            }
            Console.Clear();
            Console.ReadKey();
            Console.WriteLine("--------Nuvarande saldo--------");
            Console.WriteLine($"\n{AccountNames[x-1]}: {Balance[index][x-1]} kr");
            Console.WriteLine($"{AccountNames[y-1]}: {Balance[index][y-1]} kr");
            Console.WriteLine("\nKlicka enter för att komma till huvudmenyn");
            Console.ReadKey();
        }
        public void Withdraw(int index)
        {
            Console.Clear();
            Console.WriteLine("--------TA UT PENGAR--------");
            Console.WriteLine("Vilket konto vill du ta ut pengar?");
            for (int i = 0; i < Balance[index].Length; i++)
                Console.WriteLine((i+1) + ". " + AccountNames[i]);
            int x = Convert.ToInt32(Console.ReadLine());
            //if (XisNotValid(x, index)) 
            //    return;
            if (x <= 0 || x > Balance[index].Length)
            {
                Console.WriteLine($"Ange ett tal mellan 1 till {Balance[index].Length}");
                Console.ReadKey();
                return;
            }
            Console.Write("Insert the amount: ");
            decimal money = Convert.ToDecimal(Console.ReadLine());
            bool approved = CheckPass(index);
            while (approved) {
                Console.ReadKey();
                if (Balance[index][x - 1] < money)
                {
                    Console.WriteLine("You cannot do this action. You do not have enough money.");
                    return;
                }
                else
                {
                    Balance[index][x - 1] -= money;
                    Console.WriteLine($"\n{AccountNames[x - 1]}: {Balance[index][x - 1]} kr");
                    approved = false;
                }   
            }
            Console.WriteLine("\nKlicka enter för att komma till huvudmenyn");
            Console.ReadKey();   
        }
        public void Deposit(int index)
        {
            Console.WriteLine("--------SÄTTA IN PENGAR--------");
            Console.WriteLine("Vilket konto vill du sätta in pengar?");
            for (int i = 0; i < Balance[index].Length; i++)
                Console.WriteLine((i + 1) + ". " + AccountNames[i]);
            int x = Convert.ToInt32(Console.ReadLine());
            if (x <= 0 || x > Balance[index].Length)
            {
                Console.WriteLine($"Ange ett tal mellan 1 till {Balance[index].Length}");
                Console.ReadKey();
                return;
            }
            Console.Write("Insert the amount: ");
            decimal money = Convert.ToDecimal(Console.ReadLine());
            bool approved = CheckPass(index);
            while (approved)
            {
                    Balance[index][x - 1] += money;
                    Console.WriteLine($"\n{AccountNames[x - 1]}: {Balance[index][x - 1]} kr");
                    approved = false;
            }
            Console.WriteLine("\nKlicka enter för att komma till huvudmenyn");
            Console.ReadKey();
        }
        public void Farewell()
        {
            Console.Clear();
            Console.WriteLine("Välkommen åter!");
            Console.ReadKey();
        }

    }
}
