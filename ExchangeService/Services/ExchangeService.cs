using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using ExchangeService.Models;

namespace ExchangeService.Services
{
    public class ExchangeService : IExchangeService
    {
        private const string Url = "https://www.tcmb.gov.tr/kurlar/today.xml";

        public Response GetExchangeRates()
        {
            var response = new Response() {Currencies = new List<Currency>()};
            try
            {
                var xElement = XDocument.Load(Url)
                    .Root;
                if (xElement != null)
                    response.Currencies = xElement
                        .Elements("Currency")
                        .Select(x => new Currency
                        {
                            CurrencyCode = x.Attribute("CurrencyCode")?.Value,
                            Unit = int.Parse(x.Element("Unit")?.Value ?? string.Empty),
                            CurrencyName = x.Element("CurrencyName")?.Value,
                            ForexBuying = decimal.Parse(x.Element("ForexBuying")?.Value ?? string.Empty),
                            ForexSelling = (decimal?) (string.IsNullOrEmpty((string) x.Element("ForexSelling"))
                                ? null
                                : x.Element("ForexSelling"))
                        })
                        .ToList();
            }
            catch (Exception e)
            {
                // ignored
            }

            return response;
        }

        public Currency GetExchangeRate(string currencyCode)
        {
            var exchangeRates = GetExchangeRates();

            var res = exchangeRates.Currencies
                .Find(t => t.CurrencyCode == currencyCode);

            return res;

        }
    }
}
