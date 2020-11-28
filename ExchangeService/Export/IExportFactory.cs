using System.Collections.Generic;
using System.Text;
using ExchangeService.Models;

namespace ExchangeService.Export
{
    public interface IExportFactory
    {
        public void Export(List<Currency> currencies);
    }
}
