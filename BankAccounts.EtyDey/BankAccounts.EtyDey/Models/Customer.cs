using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankAccounts.EtyDey.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string Id { get; set; }        
        public string AccountNo { get; set; }
        public double AccountBalance { get; set; }
    }


}