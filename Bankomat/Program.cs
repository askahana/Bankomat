namespace Bankomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] userNames = {"AYA", "AKI", "TOBIAS", "MUSSEPIG", "DONALD" };
            int[] passWords = {1234, 1221, 2345, 3456, 4567 };
            Console.WriteLine("Välkommen till banken!");
            Console.Write("Insert your name: ");
            string inputName = Console.ReadLine();
            int index = 0;
            for(int i = 0; i < userNames.Length; i++)
            {
                if (userNames[i] == inputName.ToUpper()) 
                { 
                    index = i;
                    Console.Write("Insert your password: ");
                    int inputPass = Convert.ToInt32(Console.ReadLine());
                    if (passWords[index] != inputPass)
                    {
                        Console.WriteLine("Password is not correct.");
                    }
                    else
                    {
                        Account.Menu();
                    }
                }

            }
            
        }
    }
}