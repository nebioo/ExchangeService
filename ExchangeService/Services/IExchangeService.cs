using System.Collections.Generic;
using ExchangeService.Enums;
using ExchangeService.Models;

namespace ExchangeService.Services
{
    public interface IExchangeService
    {
        public Response GetExchangeRates();

        public Currency GetExchangeRate(string currencyCode);

        public List<Currency> SortExchangeRatesAsc(Sort sort, Forex forex);

        public List<Currency> SortExchangeRatesDesc(Sort sort, Forex forex);

    }
}