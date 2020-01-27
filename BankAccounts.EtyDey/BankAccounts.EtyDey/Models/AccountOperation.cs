using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankAccounts.EtyDey.Models
{
    public class AccountOperation
    {
        public static double Deposit(double Balance, double Amount, string Currency)
        {
            //var customer = CustomerManager.FindCustomer(AccNo);
            var depositAmt = ExchangeRateManager.CurrencyConvert(Currency, Amount);
            Balance = Balance + depositAmt;
            return Balance;
        }

        public static double Withdraw(double Balance, double Amount, string Currency)
        {
            //var customer = CustomerManager.FindCustomer(AccNo);
           var withdrawAmt = ExchangeRateManager.CurrencyConvert(Currency, Amount);
            Balance = Balance - withdrawAmt;
            return Balance;
        }

       /* public static Customer Transfer(double BalanceFrom, double Balanceto, string AccNoTo, double Amount, string Currency)
        {
            //var customerFrom = CustomerManager.FindCustomer(AccNoFrom);
            //var customerTo = CustomerManager.FindCustomer(AccNoTo);
            var transferAmt = ExchangeRateManager.CurrencyConvert(Currency, Amount);
            customerfrom.AccountBalance = customerfrom.AccountBalance + transferAmt;
            customerTo.AccountBalance = customerTo.AccountBalance + transferAmt;
            return customerTo;
        }*/

    }
}