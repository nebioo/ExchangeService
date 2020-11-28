using System;
using System.Collections.Generic;
using System.Text;
using ExchangeService.Enums;

namespace ExchangeService.Export
{
    public class Exporter
    {
        public IExportFactory ExporterExportFactory(ExportType export)
        {
            var exchange = new ExchangeService();
            var rates =exchange.GetExchangeRates();
            IExportFactory exportFactory = null;

            switch (export)
            {
                case ExportType.Csv:
                    exportFactory =  new CsvExport();
                    exportFactory.Export(rates.Currencies);
                    break;
                case ExportType.Xml:
                    exportFactory = new XmlExport();
                    exportFactory.Export(rates.Currencies);
                    break;

            }

            return exportFactory;
        }
    }
}
