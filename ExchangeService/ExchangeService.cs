using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ExchangeService.Enums;
using ExchangeService.Export;
using ExchangeService.Models;

namespace ExchangeService
{
    public class ExchangeService
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

        public List<Currency> SortExchangeRatesAsc(Sort sort, Forex forex)
        {
            var exchangeRates = GetExchangeRates();

            if (forex == Forex.Buying)
            {
                var res = exchangeRates.Currencies
                    .Where(x => x.ForexBuying != null)
                    .OrderBy(t => t.ForexBuying).ToList();
                return res;
            }
            else
            {
                var res = exchangeRates.Currencies
                    .Where(x => x.ForexSelling != null)
                    .OrderBy(t => t.ForexSelling).ToList();
                return res;
            }

            
        }

        public List<Currency> SortExchangeRatesDesc(Sort sort, Forex forex)
        {
            var exchangeRates = GetExchangeRates();

            if (forex == Forex.Buying)
            {
                var res = exchangeRates.Currencies
                    .Where(x => x.ForexBuying != null)
                    .OrderByDescending(t => t.ForexBuying).ToList();
                return res;
            }
            else
            {
                var res = exchangeRates.Currencies
                    .Where(x => x.ForexSelling != null)
                    .OrderByDescending(t => t.ForexSelling).ToList();
                return res;
            }
        }

        public void Export(ExportType export)
        {
            Exporter exporter = new Exporter();
            IExportFactory exportFactory = exporter.ExporterExportFactory(export);

        }
    }
}
