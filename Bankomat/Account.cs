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
        //double[][] balance = new double[5][];
        //   balance[0] = new double[] { 1234.00, 1234.00 };
        //   balance[1] = new double[] { 234, 2345, 234 };
        //   balance[2] = new double[] { 123, 234 };
        //   balance[3] = new double[] { 45999, 56778, 3456 };
        //   balance[4] = new double[] { 123, 234 };
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
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Ange password: "); 
                try { 
                    int inputPass = Convert.ToInt32(Console.ReadLine());
                    if (PassWords[index] == inputPass)
                    {
                        return true;
                    }
                    else
                        Console.WriteLine("Password is not correct.");
                    }
                catch(Exception)
                {
                    Console.WriteLine ("Antigen är användarnamn inte korrekt, eller så angav du inte siffror.\nVänligen försök igen.");
                    CheckName();
                }
            }   
            Console.WriteLine("You tried 3 times. Please try again after 3 minutes.");
            Console.ReadKey();
            return false;   
        }
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Vad vill du göra?");
            string menu1 = "1. Se dina konton och saldo";
            string menu2 = "2. Överföring mellan konton";
            string menu3 = "3. Ta ut pengar";
            string menu4 = "4. Logga ut";
            Console.WriteLine("\n\t"+menu1 + "\n\t" + menu2 + "\n\t" + menu3 + "\n\t" + menu4);
        }
        public void CheckBalance(double [][]balance, int index)
        {
            Console.Clear();
            Console.WriteLine("--------Dina konto hos oss--------");
            for (int i = 0; i < balance[index].Length; i++) {
                Console.WriteLine( $"Saldo på {AccountNames[i]} : {balance[index][i]} kr");
            }
            Console.WriteLine("Klicka enter för att komma till huvudmenyn");
            Console.ReadKey();
        }
        public static void Transfer (double[][] balance, int index)
        {
            Console.Clear();
            Console.WriteLine("--------Överföra pengar--------");
            Console.WriteLine("Vilket konto vill du överföra pengar från?");
            string[] accountNames = {"1. Lönekonto", "2. Sparkonto", "3. Aktiekonto", "4. Betalkonto", "5. Privatkonto" };
            for (int i = 0; i < balance[index].Length; i++)
                Console.WriteLine(accountNames[i]);
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Vilket konto vill du lägga pengar till?");
            int y = Convert.ToInt32(Console.ReadLine());
            Console.Write("Summa: ");
            double money = Convert.ToDouble(Console.ReadLine());
            if (balance[index][x - 1] < money) { 
                Console.WriteLine("You cannot do this action. You do not have enough money.");
                return;
            }
            else 
            { 
                balance[index][x-1] -= money;
                balance[index][y-1] += money;
            }
            Console.Clear();
            Console.ReadKey();
            Console.WriteLine("--------Nuvarande saldo--------");
            Console.WriteLine($"\n{accountNames[x-1]}: {balance[index][x-1]} kr");
            Console.WriteLine($"{accountNames[y-1]}: {balance[index][y-1]} kr");
            Console.WriteLine("Klicka enter för att komma till huvudmenyn");
            Console.ReadKey();
        }
        public void Withdraw(double[][] balance, int index)
        {
            Console.Clear();
            Console.WriteLine("--------TA UT PENGAR--------");
            Console.WriteLine("Vilket konto vill du ta ut pengar?");
            string[] accountNames = { "1. Lönekonto", "2. Sparkonto", "3. Aktiekonto", "4. Betalkonto", "5. Privatkonto" };
            for (int i = 0; i < balance[index].Length; i++)
                Console.WriteLine(accountNames[i]);
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Insert the amount: ");
            double money = Convert.ToDouble(Console.ReadLine());
            bool approved = CheckPass(index);
            while (approved) {
                Console.ReadKey();
                if (balance[index][x - 1] < money)
                {
                    Console.WriteLine("You cannot do this action. You do not have enough money.");
                    return;
                }
                else
                {
                    balance[index][x - 1] -= money;
                    Console.WriteLine($"\n{accountNames[x - 1]}: {balance[index][x - 1]} kr");
                    approved = false;
                }   
            }
            Console.WriteLine("\nKlicka enter för att komma till huvudmenyn");
            Console.ReadKey();
        }
    }
}
