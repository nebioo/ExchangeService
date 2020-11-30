using System.Collections.Generic;
using System.Text;
using ExchangeService.Models;

namespace ExchangeService.Export
{
    public interface IExportFactory
    {
        public bool Export(List<Currency> currencies);
    }
}
