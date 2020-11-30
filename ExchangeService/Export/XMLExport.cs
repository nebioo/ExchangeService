using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using CsvHelper;
using ExchangeService.Models;

namespace ExchangeService.Export
{
    public class XmlExport : IExportFactory
    {
        public bool Export(List<Currency> currencies)
        {
            try
            {
                var xmlWriter = new XmlSerializer(typeof(List<Currency>));

                FileStream file = File.Create("./export.xml");
                xmlWriter.Serialize(file, currencies);

                file.Close();
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