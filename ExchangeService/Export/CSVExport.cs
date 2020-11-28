using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using ExchangeService.Models;

namespace ExchangeService.Export
{
    public class CsvExport : IExportFactory
    {
        public void Export(List<Currency> currencies)
        {
            using var file = new StreamWriter( "./export.csv");
            using var csv = new CsvWriter(file);
            csv.WriteRecords(currencies);
        }
    }
}