namespace Bankomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[][] balance = new double[5][];
            balance[0] = new double[] { 1234.00, 1234.00 };
            balance[1] = new double[] { 234.00, 2345.00, 234.00 };
            balance[2] = new double[] { 123.00, 234.00 };
            balance[3] = new double[] { 45999.00, 56778.00, 3456.00 };
            balance[4] = new double[] { 123.00, 234.00 };

            bool isWorking = true;
            while (isWorking) {
                Console.Clear();
                Console.WriteLine("Välkommen till banken!");
                Account user = new Account();
                int index = user.CheckName();
                bool approved = user.CheckPass(index) && index != -1;

            while (approved) 
            {
                Account.Menu();
                    try { 
                    int menuChoice = Convert.ToInt32(Console.ReadLine());
                    switch (menuChoice)
                    {
                        case 1:
                            user.CheckBalance(balance, index);
                            break;
                        case 2:
                            Account.Transfer(balance, index);
                            break;
                        case 3:
                            user.Withdraw(balance, index);
                            break;
                        case 4:
                            approved = false;
                            break;
                        default:
                                Console.WriteLine("Ogiltigt val");
                                Console.ReadLine();
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
    }
}