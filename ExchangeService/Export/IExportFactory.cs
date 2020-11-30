using ExchangeService.Models;
using System.Collections.Generic;

namespace ExchangeService.Export
{
    public interface IExportFactory
    {
        public bool Export(List<Currency> currencies);
    }
}
