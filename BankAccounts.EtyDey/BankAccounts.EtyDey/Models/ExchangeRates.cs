using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankAccounts.EtyDey.Models
{
    public class ExchangeRates
    {
        public string Currency { get; set; }
        public double Rate { get; set; }
    }

    public class ExchangeRateManager
    {
        public static IEnumerable<ExchangeRates> GetAllRates()
        {
            var rates = new List<ExchangeRates>();
            rates.Add(new ExchangeRates { Currency = "CAD", Rate = 1 });
            rates.Add(new ExchangeRates { Currency = "USD", Rate = 0.5 });
            rates.Add(new ExchangeRates { Currency = "MXN", Rate = 10 });
            return rates;
        }

        public static ExchangeRates FindRate(string currency)
        {
            var rate = GetAllRates().SingleOrDefault(e => e.Currency == currency.ToUpper());
            return rate;
        }

        public static double CurrencyConvert(string ccy, double Amount)
        {
            var ExRate = FindRate(ccy);
            var ExAmount = Amount / ExRate.Rate;
            return ExAmount;
        }
    }

}