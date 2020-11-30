using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using ExchangeService.Models;

namespace ExchangeService.Export
{
    public class CsvExport : IExportFactory
    {
        public bool Export(List<Currency> currencies)
        {
            try
            {
                using var file = new StreamWriter("./export.csv");
                using var csv = new CsvWriter(file);
                csv.WriteRecords(currencies);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}