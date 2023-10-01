﻿using System;
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
            Console.Write("Ange ditt namn: ");
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
                Console.Write("Ange pin-kod: ");
                int inputPass = Convert.ToInt32(Console.ReadLine());
                if (passWords[index] == inputPass)
                {
                    Console.Clear();
                    Console.WriteLine("Välkommen till SutBanken!\nTryck enter.");
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
        public static void CheckBalance(double [][]balance, int index)
        {
            Console.Clear();
            string[] accountNames = {"Lönekonto", "Sparkonto", "Aktiekonto" };
            for (int i = 0; i < balance[index].Length; i++)
            {
                Console.WriteLine($"The balance of {accountNames[i]}: {balance[index][i]} kr");
            }
            
            Console.ReadKey();
        }
        public static void Transfer (double[][] balance, int index)
        {
            Console.WriteLine("Vilket konto vill du överföra pengar från?");
            Console.WriteLine("1. Lönekonto \n2. Sparkonto\n3. Aktiekonto\n4. Hobbikonto\n5. Reskonto");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Vilket konto vill du lägga pengar till?");
            int y = Convert.ToInt32(Console.ReadLine());
            Console.Write("The amount of money: ");
            double money = Convert.ToDouble(Console.ReadLine());
            balance[index][x-1] -= money;
            balance[index][y-1] += money;

            Console.WriteLine(balance[index][x - 1] + " kr" +
               balance[index][y - 1] + "kr");
            
            Console.WriteLine("Klicka enter för att komma till huvudmenyn");
            Console.ReadKey();
        }
        public static void Withdraw(List<double> a, int index)
        {
            Console.WriteLine("TA UT PENGAR");
            Console.Write("Insert the amount: ");
            double money = Convert.ToDouble(Console.ReadLine());
            if (a[index] < money)
                Console.WriteLine("You cannot do this action. You do not have enough money.");    
            else
                a[index] -= money;
            Console.WriteLine("Klicka enter för att komma till huvudmenyn");
            Console.ReadKey();
        }

    }
}
