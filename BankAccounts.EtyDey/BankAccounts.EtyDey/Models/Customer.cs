using System.Collections.Generic;

namespace BankAccounts.EtyDey.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string Id { get; set; }        
        
        public List<Account> accounts { get; set; }
    }


}