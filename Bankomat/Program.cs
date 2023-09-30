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
            List<double> balance = new List<double>();
            balance.Add(123.35);
            balance.Add(0);
            balance.Add(234.45);
            balance.Add(2300);
            balance.Add(3456);
            while (approved) 
            {
                
                Account.Menu();
                int menuChoice = Convert.ToInt32(Console.ReadLine());
                switch (menuChoice)
                {
                    case 1:
                        Account.CheckBalance(balance, index);
                        break;
                    case 2:
                        break;
                    case 3:
                        Account.CheckBalance(balance, index);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Thanks for using.");
                        approved = false;
                        break;
                    default:
                        break;
                }
            }

        }
    }
}