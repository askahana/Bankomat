namespace Bankomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till banken!");
            Account user = new Account();
            int index = user.NameCheck();
            bool approved = user.PassCheck(index) && index != -1;

            while (approved) 
            { 
                Account.Menu();
                Console.WriteLine("What can I help you today?");
                int menuChoice = Convert.ToInt32(Console.ReadLine()); ;
            }

        }
    }
}