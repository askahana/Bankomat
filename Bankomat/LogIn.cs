using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class LogIn
    {
        private string[] UserNames;
        private int[] PassWords;
        public LogIn()
        {
            UserNames = new string [5]{ "AYA", "AKI", "TOBIAS", "MUSSEPIG", "OLLE" };
            PassWords = new int [5] { 1103, 1221, 1234, 3456, 0901 };
        }
        public int CheckNameAndIndex()
        {
            int index = 0;                                  // För att kunna veta vilket index-nummer användare har.
            Console.Write("Ange ditt namn: ");
            string inputName = Console.ReadLine();          // Användare matar in användarnamn.
            for (int i = 0; i < UserNames.Length; i++)
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
    }
}
