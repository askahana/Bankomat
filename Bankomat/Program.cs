namespace Bankomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[][] balance = new double[5][];
            balance[0] = new double[] { 1234.00, 1234.00 };
            balance[1] = new double[] { 234, 2345, 234 };
            balance[2] = new double[] { 123, 234 };
            balance[3] = new double[] { 45999, 56778, 3456 };
            balance[4] = new double[] { 123, 234 };

            bool isWorking = true;
            while (isWorking) { 
                Console.WriteLine("Välkommen till banken!");
                Account user = new Account();
                int index = user.NameCheck();
                bool approved = user.PassCheck(index) && index != -1;

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
                        Account.Transfer(balance, index);
                        break;
                    case 3:
                        user.Withdraw(balance, index);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Välkommen åter!");
                        approved = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val");
                        break;
                }
            }
            }
        }
    }
}