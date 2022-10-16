
using ConsoleApp1;
using System;


namespace MySuperBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("kendra", 1000);

            Console.WriteLine(account.Balance);
        }
    }
}