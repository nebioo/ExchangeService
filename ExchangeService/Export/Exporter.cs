using System;
using System.Collections.Generic;
using System.Text;
using ExchangeService.Enums;

namespace ExchangeService.Export
{
    public class Exporter
    {
        public bool ExporterExportFactory(ExportType export)
        {
            try
            {
                var exchange = new ExchangeService();
                var rates = exchange.GetExchangeRates();
                IExportFactory exportFactory = null;

                switch (export)
                {
                    case ExportType.Csv:
                        exportFactory = new CsvExport();
                        var csvResult = exportFactory.Export(rates.Currencies);
                        return csvResult;
                    case ExportType.Xml:
                        exportFactory = new XmlExport();
                        var xmlResult = exportFactory.Export(rates.Currencies);
                        return xmlResult;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            

        }
    }
}
