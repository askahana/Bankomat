namespace Bankomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;
            while (isWorking)
            {
                Console.Clear();
                Console.WriteLine("Välkommen till Banken!");
                Account user = new Account();
                int index = user.CheckNameAndIndex();              // Användarens index-nummer.
                bool approved = user.CheckPass(index);    // Om pinkod stämmer.
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
    }
}