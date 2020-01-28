using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BankAccounts.EtyDey.Models
{
    public class CustomerManager
    {
        public static IEnumerable<Customer> GetAllCustomers()
        {
            if(!File.Exists("CustomerDetails.json"))
            {
                List<Customer> customerList = new List<Customer>();
                customerList.Add(new Customer { Name = "Stewie Griffin", Id = "777", accounts = new List<Account> { new Account { AccountNo = "1234", AccountBalance = 100 } } });
                customerList.Add(new Customer { Name = "Glenn Quagmire", Id = "504", accounts = new List<Account> { new Account { AccountNo = "2001", AccountBalance = 35000 } } });
                customerList.Add(new Customer { Name = "Joe Swanson", Id = "002", accounts = new List<Account> { new Account { AccountNo = "1010", AccountBalance = 7425 }, new Account { AccountNo = "5500", AccountBalance = 15000 } } });
                customerList.Add(new Customer { Name = "Peter Griffin", Id = "123", accounts = new List<Account> { new Account { AccountNo = "0123", AccountBalance = 150 } } });
                customerList.Add(new Customer { Name = "Lois Griffin", Id = "456", accounts = new List<Account> { new Account { AccountNo = "0456", AccountBalance = 65000 } } });

                var jsonList = JsonConvert.SerializeObject(customerList);
                //string customerList = "[{\"Name\":\"Stewie Griffin\",\"Id\":\"777\",\"accounts\":[{\"AccountNo\":\"1234\",\"AccountBalance\":100.0}]},{\"Name\":\"Glenn Quagmire\",\"Id\":\"504\",\"accounts\":[{\"AccountNo\":\"2001\",\"AccountBalance\":35000}]},{\"Name\":\"Joe Swanson\",\"Id\":\"002\",\"accounts\":[{\"AccountNo\":\"1010\",\"AccountBalance\":7425},{\"AccountNo\":\"5500\",\"AccountBalance\":15000}]},{\"Name\":\"Peter Griffin\",\"Id\":\"123\",\"accounts\":[{\"AccountNo\":\"0123\",\"AccountBalance\":150}]},{\"Name\":\"Lois Griffin\",\"Id\":\"456\",\"accounts\":[{\"AccountNo\":\"0456\",\"AccountBalance\":65000}]}]";
                File.WriteAllText("CustomerDetails.json", jsonList);
            }
            string Datalist = File.ReadAllText("CustomerDetails.json");
            var customers = JsonConvert.DeserializeObject<List<Customer>>(Datalist);
            return customers;
        }

        public static Account FindAccount(string AccNo)
        { 
            var account = new Account();
            foreach(Customer cust in GetAllCustomers())
            {
                if(cust.accounts.SingleOrDefault(a => a.AccountNo == AccNo) != null)
                {
                    account = cust.accounts.SingleOrDefault(a => a.AccountNo == AccNo);
                }
            }
            return account;
        }

        public static bool UpdateAccount(string AccNo, double Amount)
        {
            try
            {
                var customers = GetAllCustomers();
                var account = new Account();
                foreach (Customer cust in customers)
                {
                    if (cust.accounts.SingleOrDefault(a => a.AccountNo == AccNo) != null)
                    {
                        account = cust.accounts.SingleOrDefault(a => a.AccountNo == AccNo);
                        account.AccountBalance = Amount;
                    }
                }

                using (StreamWriter file = File.CreateText(@"CustomerDetails.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, customers);
                }
                    return true;
            }
            catch
            {
                return false;
            }
            

           /* try
            {
                //var jObject = JsonConvert.DeserializeObject<JArray>(Datalist).ToObject<List<JObject>>();
                //var jObject = JObject.Parse(Datalist);
                foreach (var item in array)
                {
                    //JArray accountList = (JArray)jObj["accounts"];
                    foreach (var account in item["accounts"])
                    {
                        if(account["AccountNo"].Value.toString() == AccNo)
                        {
                            account["AccountBalance"] = 700;
                        }
                        
                    }

                    //item["accounts"] = accountList;

                }
                string output = JsonConvert.SerializeObject(array, Formatting.Indented);
                File.WriteAllText("CustomerDetails.json", output);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }*/
        }
    }
}