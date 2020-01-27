
namespace BankAccounts.EtyDey.Models
{
    public class AccountOperation
    {
        public static bool Deposit(string AccNo, double Amount, string Currency)
        {
            var account = CustomerManager.FindAccount(AccNo);
            var depositAmt = ExchangeRateManager.CurrencyConvert(Currency, Amount);
            account.AccountBalance = account.AccountBalance + depositAmt;
            var update = CustomerManager.UpdateAccount(AccNo, account.AccountBalance);
            return update;
        }

        public static bool Withdraw(string AccNo, double Amount, string Currency)
        {
            var account = CustomerManager.FindAccount(AccNo);
            var depositAmt = ExchangeRateManager.CurrencyConvert(Currency, Amount);
            account.AccountBalance = account.AccountBalance - depositAmt;
            var update = CustomerManager.UpdateAccount(AccNo, account.AccountBalance);
            return update;
        }

    }
}