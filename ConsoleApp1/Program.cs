
using BankLibrary;

namespace MySuperBank
{
   public class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("kendra", 1000);

            Console.Write(account.Owner);
            


        }
    }
}