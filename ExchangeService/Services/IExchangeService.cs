using ExchangeService.Models;

namespace ExchangeService.Services
{
    public interface IExchangeService
    {
        public Response GetExchangeRates();

        public Currency GetExchangeRate(string currencyCode);
    }
}