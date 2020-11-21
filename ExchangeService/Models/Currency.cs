using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeService.Models
{
    public class Currency
    {
        public CurrencyCode CurrencyCode { get; set; }
        public int Unit { get; set; }
        public string CurrencyName { get; set; }
        public decimal ForexBuying { get; set; }
        public decimal ForexSelling { get; set; }
        public decimal BanknoteBuying { get; set; }
        public decimal BanknoteSelling { get; set; }
    }
}
