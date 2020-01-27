using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankAccounts.EtyDey.Models;
using System.Data;

namespace BankAccounts.EtyDey.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        //As we have hardcoded data, we need to use Account balance and return calculated value
        //Otherwise we can use FindCustomer() Method and Update()
        public double AccountDeposit(double AccBalance, double DpAmount, string Currency)
        {
            var Balance = AccountOperation.Deposit(AccBalance, DpAmount, Currency);
            return Balance;
        }

        public double AccountWithdraw(double AccBalance, double WdAmount, string Currency)
        {
            var Balance = AccountOperation.Withdraw(AccBalance, WdAmount, Currency);
            return Balance;
        }

        public void AccountTransfer(double BalanceFrom, double Balanceto, double WdAmount, double DpAmount, string Currency)
        {

            //UpdateTransferFunds()
        }
    }
}