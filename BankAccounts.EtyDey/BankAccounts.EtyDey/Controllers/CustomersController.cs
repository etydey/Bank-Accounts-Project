using System.Web.Mvc;
using BankAccounts.EtyDey.Models;

namespace BankAccounts.EtyDey.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        //Account Deposit
        public bool AccountDeposit(string AccNo, double Amount, string Currency)
        {
            var deposit = AccountOperation.Deposit(AccNo, Amount, Currency);
            return deposit;
        }

        //Withdraw from Account
        public bool AccountWithdraw(string AccNo, double Amount, string Currency)
        {
            var withdraw = AccountOperation.Withdraw(AccNo, Amount, Currency);
            return withdraw;
        }

        //Fund Transfer between Accounts
        public bool FundTransfer(string accountFrom, string AccountTo, double Amount, string Currency)
        {
            var withdraw = AccountOperation.Withdraw(accountFrom, Amount, Currency);
            var deposit = AccountOperation.Deposit(AccountTo, Amount, Currency);
            if(withdraw==true && deposit == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Get Customer Account
        public Account GetCustomerAccount(string AccNo)
        {
            return CustomerManager.FindAccount(AccNo);
        }
    }
}