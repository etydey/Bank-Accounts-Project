using System.Web.Mvc;
using Xunit;
using BankAccounts.EtyDey.Controllers;
using Xunit.Abstractions;
using System.Globalization;

namespace xUnitTests
{
    public class CustomersControllerFacts
    {
        public class Index
        {
            //Output Variable
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
                //Arrange
                var controller = new CustomersController();
                var expectedValue = true;

                //Act
                bool deposit = controller.AccountDeposit("1234", 300, "USD");                

                //Assert  
                Assert.Equal(expectedValue, deposit);

                //Act
                var account = controller.GetCustomerAccount("1234");

                //Assert  
                Assert.NotNull(account);
                 _output.WriteLine("Bank Account: {0}, Balance: ${1} CAD", account.AccountNo, account.AccountBalance.ToString("N", CultureInfo.InvariantCulture));
            }

              [Fact]
              public void CaseTwo()
              {
                // Arrange 
                var controller = new CustomersController();
                var expectedValue = true;

                //Act
                bool withdraw1 = controller.AccountWithdraw("2001", 5000, "MXN");
                bool withdraw2 = controller.AccountWithdraw("2001", 12500, "USD");
                bool deposit = controller.AccountDeposit("2001", 300, "CAD");


                //Assert  
                Assert.Equal(expectedValue, withdraw1);
                Assert.Equal(expectedValue, withdraw2);
                Assert.Equal(expectedValue, deposit);


                //Act
                var account = controller.GetCustomerAccount("2001");

                //Assert  
                Assert.NotNull(account);
                _output.WriteLine("Bank Account: {0}, Balance: ${1} CAD", account.AccountNo, account.AccountBalance.ToString("N", CultureInfo.InvariantCulture));
            }

              [Fact]
              public void CaseThree()
              {
                // Arrange  
                var controller = new CustomersController();
                var expectedValue = true;

                //Act
                bool withdraw = controller.AccountWithdraw("5500", 5000, "CAD");
                bool transfer = controller.FundTransfer("1010", "5500", 7300, "CAD");
                bool deposit = controller.AccountDeposit("1010", 13726, "MXN");


                //Assert  
                Assert.Equal(expectedValue, withdraw);
                Assert.Equal(expectedValue, transfer);
                Assert.Equal(expectedValue, deposit);

                //Act
                var account1010 = controller.GetCustomerAccount("1010");
                var account5500 = controller.GetCustomerAccount("5500");

                //Assert  
                Assert.NotNull(account1010);
                Assert.NotNull(account5500);
                _output.WriteLine("Account Number: {0} Balance: ${1} CAD", account1010.AccountNo, account1010.AccountBalance.ToString("N", CultureInfo.InvariantCulture));
                _output.WriteLine("Account Number: {0} Balance: ${1} CAD", account5500.AccountNo, account5500.AccountBalance.ToString("N", CultureInfo.InvariantCulture));
            }

            [Fact]
              public void CaseFour()
              {
                //Arrange
                var controller = new CustomersController();
                var expectedValue = true;

                //Act
                bool withdraw = controller.AccountWithdraw("0123", 70, "USD");
                bool deposit = controller.AccountDeposit("0456", 23789, "USD");
                bool transfer = controller.FundTransfer("0456", "0123", 23.75, "CAD");

                //Assert
                Assert.Equal(expectedValue, withdraw);
                Assert.Equal(expectedValue, deposit);
                Assert.Equal(expectedValue, transfer);

                //Act
                var account0123 = controller.GetCustomerAccount("0123");
                var account0456 = controller.GetCustomerAccount("0456");

                //Assert
                Assert.NotNull(account0123);
                Assert.NotNull(account0456);
                _output.WriteLine("Account Number: {0} Balance: ${1} CAD", account0123.AccountNo, account0123.AccountBalance.ToString("N", CultureInfo.InvariantCulture));
                _output.WriteLine("Account Number: {0} Balance: ${1} CAD", account0456.AccountNo, account0456.AccountBalance.ToString("N", CultureInfo.InvariantCulture));
            }
        }
    }
}
