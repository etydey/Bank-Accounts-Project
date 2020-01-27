using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankAccounts.EtyDey.Models
{
    public class CustomerManager
    {
        public static IEnumerable<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();
            customers.Add(new Customer {Name = "Stewie Griffin", Id = "777", AccountNo = "1234", AccountBalance=100 });
            customers.Add(new Customer {Name = "Glenn Quagmire", Id = "504", AccountNo = "2001", AccountBalance=35000 });
            customers.Add(new Customer {Name = "Joe Swanson", Id = "002" , AccountNo = "1010", AccountBalance=7425 });
            customers.Add(new Customer {Name = "Joe Swanson", Id = "002", AccountNo = "5500", AccountBalance=15000 });
            customers.Add(new Customer { Name = "Peter Griffin", Id = "123", AccountNo = "0123", AccountBalance = 150 });
            customers.Add(new Customer { Name = "Lois Griffin", Id = "456", AccountNo = "0456", AccountBalance = 65000 });
            return customers;
        }

        public static Customer FindCustomer(string AccNo)
        {
            var customer = GetAllCustomers().SingleOrDefault(c => c.AccountNo == AccNo);
            return customer;
        }
    }
}