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
        private List<string> UserNames = new List<string> { "AYA", "AKI", "TOBIAS", "MUSSEPIG", "OLLE" };
        private List<int> PassWords = new List<int> { 1103, 1221, 2345, 3456, 0901 };
        private string[] AccountNames = { "Lönekonto", "Sparkonto", "Aktiekonto", "Betalkonto", "Privatkonto" };
        private decimal[][] Balance = new decimal[5][]
        {
        new decimal[] { 12340, 1234, 23456, 45677 },
        new decimal[] { 234, 2345, 234, 34567 },
        new decimal[] { 123, 234 },
        new decimal[] { 45999, 56778, 3456 },
        new decimal[] { 123, 234, 34567 }
        };
        public int CheckNameAndIndex()                  
        {
            int index = 0;                                  // För att kunna veta vilket index-nummer användare har.
            Console.Write("Ange ditt namn: ");
            string inputName = Console.ReadLine();          // Användare matar in användarnamn.
            for (int i = 0; i < UserNames.Count; i++)
            {
                if (UserNames[i] == inputName.ToUpper())
                {
                    index = i;                              // Om användarnamn finns i Array, returneras index.
                    return index;
                }
            }
            return -1;                                      // Om användarens inmatning och namnen i Array är inte samma,
        }                                                   // returneras -1.
        public bool CheckPass(int index)        // Kontrollera pin-kod.
        {
            if (index == -1)                    // Om användarnamn inte stämmer, får användaren inte skriva pin-koden.
            {
                Console.WriteLine("Fel användarnamn. Försök igen.");
                Console.ReadKey();
                return false;
            }
            for (int i = 0; i < 3; i++)     // Användaren får skriva pinkod max 3 gånger.
            {
                Console.Write("Ange pin-kod: ");
                try
                {
                    int inputPass = Convert.ToInt32(Console.ReadLine());        // Användare matar in pinkod.
                    if (PassWords[index] == inputPass)
                        return true;
                    else
                        Console.WriteLine("Felaktig pin-kod. Vänligen försök igen.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Felaktig pin-kod! Ange siffror.");
                }
            }
            Console.WriteLine("Du har försökt 3 gånger. Vänligen vänta 3 minuter.");
            Thread.Sleep(1000 * 60 * 3);         // Om användaren skriver in fel pinkod tre gånger, måste anävndaren
            return false;                        // vänta 3 minuter.
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
            Console.WriteLine("\n\t" + menu1 + "\n\t" + menu2 + "\n\t" + menu3 + "\n\t" + menu4 + "\n\t" + menu5);
        }
        public void CheckBalance(int index)         // Här kan användare se saldo.
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
            decimal money = Convert.ToDecimal(Console.ReadLine());
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
            decimal money = Convert.ToDecimal(Console.ReadLine());
            bool approved = CheckPass(index);       // kontrollerar pinkod.
            while (approved)
            {                      // Om pinkod stämmer kan användaren ta ut pengar.
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
            decimal money = Convert.ToDecimal(Console.ReadLine());
            bool approved = CheckPass(index);
            while (approved)
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
