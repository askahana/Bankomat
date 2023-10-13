using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    public class Account
    {
        private string[] AccountNames = { "Lönekonto", "Sparkonto", "Aktiekonto", "Betalkonto", "Privatkonto" };
        private decimal[][] Balance = new decimal[5][]
        {
        new decimal[] { 12340m, 1234m, 23456.45m, 45677m },
        new decimal[] { 234m, 2345m, 234m },
        new decimal[] { 123m , 2345m},
        new decimal[] { 45999m, 56778m, 3456m },
        new decimal[] { 123m, 234m, 34567m }
        };
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Vad vill du göra?");
            string menu1 = "1. Se dina konton och saldo";
            string menu2 = "2. Överföring mellan konton";
            string menu3 = "3. Ta ut pengar";
            string menu4 = "4. Sätta in pengar";
            string menu5 = "5. Logga ut";
            Console.WriteLine("\n\t" + menu1 + "\n\t" + menu2 + "\n\t" + menu3 + "\n\t" + menu4 + "\n\t" + menu5);
        }
        public void MenuChoice()
        {
            bool isWorking = true;
            while (isWorking)
            {
                Console.Clear();
                Console.WriteLine("Välkommen till Banken!");
                LogIn login = new LogIn();
                int index = login.CheckNameAndIndex();      // Användarens index-nummer.
                bool approved = login.CheckPass(index);    // Inlogning. Om pinkod stämmer. 
                Account user = new Account();
                while (approved)
                {
                    Account.Menu();
                    try      // Om användaren matar in annat än siffra, går till catch.
                    {
                        int menuChoice = Convert.ToInt32(Console.ReadLine());
                        switch (menuChoice)
                        {
                            case 1:
                                user.CheckBalance(index);
                                break;
                            case 2:
                                user.Transfer(index);
                                break;
                            case 3:
                                user.Withdraw(index);
                                break;
                            case 4:
                                user.Deposit(index);
                                break;
                            case 5:
                                user.Farewell();
                                approved = false;
                                break;
                            default:
                                Console.WriteLine("Ange tal mellan 1 till 5.");
                                Console.ReadKey();
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("ERROR!!! Ange ett tal.");
                        Console.ReadKey();
                    }
                }
            }
        }
        public void CheckBalance(int index)         // Metod för att visa saldo.
        {
            Console.Clear();
            Console.WriteLine("--------Saldo--------");
            ShowAccount(index);
            Console.WriteLine("\nKlicka enter för att komma till huvudmenyn");
            Console.ReadKey();
        }
        public void ShowAccount(int index)      // Den här visar Kontonamn och saldo. 
        {                                       // Skaffade den här för att slippa upprepade koder.
            for (int i = 0; i < Balance[index].Length; i++)
                Console.WriteLine($"{i+1}. {AccountNames[i]} : {Balance[index][i]} kr");
            Console.WriteLine();
        }
        public bool XisNotValid(int x, int index)           // Den här används vid överföring etc. Om kontonnummer som användaren
        {                                                   // matar in inte finns på index-nummer, är det true.
            if (x <= 0 || x > Balance[index].Length)
            {
                Console.WriteLine($"Ange ett tal mellan 1 till {Balance[index].Length}. \nKlicka enter för att komma till huvudmenyn.");
                Console.ReadKey();
                return true;
            }
            return false;
        }
        public bool BalanceIsTooHigh(int index, decimal money, int x)
        {
            if (Balance[index][x - 1] < money || money < 0)
            {    // Om användaren vill ta ut mer pengar än det som finns i kontot, eller om det är ett negativ tal.
                Console.WriteLine("\nBeloppet är för stort eller negativ tal. Vänligen försök igen.");
                Console.ReadKey();
                return true ;
            }
            return false;
        }
        public void Transfer(int index)                    // Överföra pengar.
        {
            Console.Clear();
            Console.WriteLine("--------Överföra pengar--------\nVilket konto vill du överföra pengar från?");
            ShowAccount(index);     // Visa konto
            int x = Convert.ToInt32(Console.ReadLine()); // Här lagras konto-nummer.
            if (XisNotValid(x, index) == true)      // Om x är mindre eller större än antal konto, kan inte gå vidare.
                return;
            Console.WriteLine("Vilket konto vill du lägga pengar till?");
            int y = Convert.ToInt32(Console.ReadLine());
            if (XisNotValid(y, index) == true)
                return;
            Console.Write("Summa: ");
            decimal money = Convert.ToDecimal(Console.ReadLine(), CultureInfo.InvariantCulture);
            if (BalanceIsTooHigh(index, money, x))
                return;
            else
            {
                Balance[index][x - 1] -= money;         // Ta bort pengar från x-1 konto.
                Balance[index][y - 1] += money;         // Addera pengar till y-1 konto.
            }
            Console.Clear();
            Console.WriteLine("--------Nuvarande saldo--------");
            Console.WriteLine($"\n{AccountNames[x - 1]}: {Balance[index][x - 1]} kr" +
                $"\n{AccountNames[y - 1]}: {Balance[index][y - 1]} kr" +
                $"\nKlicka enter för att komma till huvudmenyn");
            Console.ReadKey();
        }
        public void Withdraw(int index)             // Ta ut pengar.
        {
            Console.Clear();
            Console.WriteLine("--------TA UT PENGAR--------\nVilket konto vill du ta ut pengar?");
            ShowAccount(index);
            int x = Convert.ToInt32(Console.ReadLine());    // Här lagras konto-nummer.
            if (XisNotValid(x, index) == true)
                return;
            Console.Write("Mata in summan: ");
            decimal money = Convert.ToDecimal(Console.ReadLine(), CultureInfo.InvariantCulture);
            LogIn user = new LogIn();
            bool approved = user.CheckPass(index);       // kontrollerar pinkod. // Om pinkod stämmer kan användaren ta ut pengar.
            while (approved)
            {                      
                if (BalanceIsTooHigh(index, money, x))
                    return;
                else
                {
                    Balance[index][x - 1] -= money;     // Ta bort summan från x-1 konto.
                    Console.WriteLine($"\nNuvarande saldo: {AccountNames[x - 1]}: {Balance[index][x - 1]} kr");
                    approved = false;
                }
            }
            Console.WriteLine("\nKlicka enter för att komma till huvudmenyn");
            Console.ReadKey();
        }
        public void Deposit(int index)          // sätta in pengar.
        {
            Console.Clear();
            Console.WriteLine("--------SÄTTA IN PENGAR--------");
            Console.WriteLine("Vilket konto vill du sätta in pengar?");
            ShowAccount(index);
            int x = Convert.ToInt32(Console.ReadLine());
            if (XisNotValid(x, index) == true)
                return;
            Console.Write("Mata in summan: ");
            decimal money = Convert.ToDecimal(Console.ReadLine(), CultureInfo.InvariantCulture);
            LogIn user = new LogIn();
            bool approved = user.CheckPass(index);       // Kontrollerar pin-kod för att kunna förtsätta.
            while (approved)                        // Om pinkod stämmer kan användaren sätta in pengar.
            {
                Balance[index][x - 1] += money;     // Addera summan till x-1 konto.
                Console.WriteLine($"\nNuvarande saldo: {AccountNames[x - 1]}: {Balance[index][x - 1]} kr");
                approved = false;
            }
            Console.WriteLine("\nKlicka enter för att komma till huvudmenyn");
            Console.ReadKey();
        }
        public void Farewell()      // Hejdå meddelande.
        {
            Console.Clear();
            Console.WriteLine("Tack för besöket. Välkommen åter!\nDu kommer nu tas tillbaka till inloggningsskärmen.");
            Thread.Sleep(4000);
            Console.Clear();
            Thread.Sleep(1000);
        }
    }
}
