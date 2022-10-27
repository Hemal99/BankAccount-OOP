using Xunit;
using BankLibrary;

namespace BankingTest
{
    public class UnitTest1
    {
        [Fact]
        public void TrueIsTrue()
        {
            Assert.True(true);
        }

        [Fact]
        public void CantTakeMoreThanYouHave()
        {
            var account = new BankAccount("Kendra", 1000);

            // Test for negative balance
            Assert.Throws<InvalidOperationException>(
              () => account.MakeWithdrawal(75000, DateTime.Now, "Attempt to overdraw")
                ) ;
        }

        [Fact]
        public void NeedMoneyToStart()
        {
            var account = new BankAccount("Kendra", 1000);

            // Test that the initial balance must be positive.
            Assert.Throws<ArgumentOutOfRangeException>(
              () => new BankAccount("invalid",-55)
                );
        }
    } 
}