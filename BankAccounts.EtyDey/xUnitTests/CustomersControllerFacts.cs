using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;
using BankAccounts.EtyDey.Controllers;
using Xunit.Abstractions;
using BankAccounts.EtyDey.Models;
using System.Globalization;

namespace xUnitTests
{
    public class CustomersControllerFacts
    {
        public class Index
        {
            //As we have hardcoded data, we need to use Account balance and return calculated value
            //Otherwise we can use FindCustomer() Method and Update() Method
            ITestOutputHelper _output;

            public Index(ITestOutputHelper output)
            {
                _output = output;                
            }
            [Fact]
            public void CustomersControllerReturnsViewWithDefaultName()
            {
                //Arrange
                var controller = new CustomersController();

                //Act
                var result = controller.Index();

                //Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                Assert.NotNull(viewResult.ViewName);
            }

            [Fact]
            public void CaseOne()
            {
                // Arrange  
                var controller = new CustomersController();
                Customer cust = new Customer();
                cust.Name = "Stewie Griffin";
                cust.Id = "777";
                cust.AccountNo = "1234";
                cust.AccountBalance = 100;
                
               
                // Act  
                var expectedValue = 700;
                var newBalance = controller.AccountDeposit(cust.AccountBalance, 300, "USD");
                cust.AccountBalance = newBalance;

                //Assert  
                Assert.Equal(expectedValue, newBalance);
                _output.WriteLine("Account Number: {0} Balance: ${1} CAD", cust.AccountNo, cust.AccountBalance.ToString("N", CultureInfo.InvariantCulture));
            }

            [Fact]
            public void CaseTwo()
            {
                // Arrange 
                var controller = new CustomersController();
                Customer cust = new Customer();
                cust.Name = "Glenn Quagmire";
                cust.Id = "504";
                cust.AccountNo = "2001";
                cust.AccountBalance = 35000;
              
                var BlAfterWithdraw1 = controller.AccountWithdraw(cust.AccountBalance, 5000, "mxn");
                var BlAfterWithdraw2 = controller.AccountWithdraw(BlAfterWithdraw1, 12500, "usd");
                var BlAfterDposit = controller.AccountDeposit(BlAfterWithdraw2, 300, "cad");


                // Act  
                var expectedValue = 9800;
                cust.AccountBalance = BlAfterDposit;

                //Assert  
                Assert.Equal(expectedValue, cust.AccountBalance);
                _output.WriteLine("Account Number: {0} Balance: ${1} CAD", cust.AccountNo, cust.AccountBalance.ToString("N", CultureInfo.InvariantCulture));
            }

            [Fact]
            public void CaseThree()
            {
                //As we have hardcoded data, we need to use Account balance and return calculated value
                //Otherwise we can use FindCustomer() Method and Update() Method
                // Arrange  
                var controller = new CustomersController();
                Customer Account1 = new Customer();
                Account1.Name = "Joe Swanson";
                Account1.Id = "002";
                Account1.AccountNo = "1010";
                Account1.AccountBalance = 7425;

                Customer Account2 = new Customer();
                Account2.Name = Account1.Name;
                Account2.Id = Account1.Id;
                Account2.AccountNo = "5500";
                Account2.AccountBalance = 15000;

                var WithdrawMoneyFmAcc2 = controller.AccountWithdraw(Account2.AccountBalance, 5000, "CAD");
                var transferMoneyFmAcc1 = controller.AccountWithdraw(Account1.AccountBalance, 7300, "CAD");
                var transferMoneyToAcc2 = controller.AccountDeposit(WithdrawMoneyFmAcc2, 7300, "CAD");
                var DepositMoneyToAcc1 = controller.AccountDeposit(transferMoneyFmAcc1, 13726, "MXN");

                // Act  
                var expectedValueForAcc1 = 1497.60;
                Account1.AccountBalance = DepositMoneyToAcc1;

                var expectedValueForAcc2 = 17300;
                Account2.AccountBalance = transferMoneyToAcc2;

                //Assert  
                Assert.Equal(expectedValueForAcc1, Account1.AccountBalance);
                Assert.Equal(expectedValueForAcc2, Account2.AccountBalance);
                _output.WriteLine("Account Number: {0} Balance: ${1} CAD", Account1.AccountNo, Account1.AccountBalance.ToString("N", CultureInfo.InvariantCulture));
                _output.WriteLine("Account Number: {0} Balance: ${1} CAD", Account2.AccountNo, Account2.AccountBalance.ToString("N", CultureInfo.InvariantCulture));
            }

            [Fact]
            public void CaseFour()
            {
                //As we have hardcoded data, we need to use Account balance and return calculated value
                //Otherwise we can use FindCustomer() Method and Update()
                // Arrange  
                var controller = new CustomersController();
                Customer Account1 = new Customer();
                Account1.Name = "Peter Griffin";
                Account1.Id = "123";
                Account1.AccountNo = "0123";
                Account1.AccountBalance = 150;

                Customer Account2 = new Customer();
                Account2.Name = "Lois Griffin";
                Account2.Id = "456";
                Account2.AccountNo = "0456";
                Account2.AccountBalance = 65000;

                var WithdrawMoneyFmAcc1 = controller.AccountWithdraw(Account1.AccountBalance, 70, "USD");
                var DepositMoneyToAcc2 = controller.AccountDeposit(Account2.AccountBalance, 23789, "usd");
                var transferMoneyFmAcc2 = controller.AccountWithdraw(DepositMoneyToAcc2, 23.75, "CAD");
                var transferMoneyToAcc1 = controller.AccountDeposit(WithdrawMoneyFmAcc1, 23.75, "CAD");
               

                // Act  
                var expectedValueForAcc1 = 33.75;
                Account1.AccountBalance = transferMoneyToAcc1;

                var expectedValueForAcc2 = 112554.25;
                Account2.AccountBalance = transferMoneyFmAcc2;

                //Assert  
                Assert.Equal(expectedValueForAcc1, Account1.AccountBalance);
                Assert.Equal(expectedValueForAcc2, Account2.AccountBalance);
                _output.WriteLine("Account Number: {0} Balance: ${1} CAD", Account1.AccountNo, Account1.AccountBalance.ToString("N",CultureInfo.InvariantCulture));
                _output.WriteLine("Account Number: {0} Balance: ${1} CAD", Account2.AccountNo, Account2.AccountBalance.ToString("N", CultureInfo.InvariantCulture));
            }
        }
    }
}
