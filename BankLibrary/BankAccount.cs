using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
  public  class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
         
        public decimal Balance 
        {
            get
            {

                decimal balance = 0;

                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        private static int accountNumberSeed = 123456789;

        private List<Transaction> allTransactions  = new List<Transaction>();

        public BankAccount(string name,decimal initialBalance)
        {
            this.Owner = name;
            MakeDeposit(initialBalance,DateTime.Now, "Initial Balance");
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        public void MakeDeposit(decimal amount,DateTime date,string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }

            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);

        }

        public void MakeWithdrawal(decimal amount,DateTime date, string note)
        {
             if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");

            }
             if(Balance -amount <= 0)
            {
                throw new InvalidOperationException("Insufficient Balance");
            }

             var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new StringBuilder();

            report.AppendLine("Date\tAmount\tNote");
            foreach(var item in allTransactions)
            {
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");
            }

            return report.ToString();
        }


    }
}
