using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExchangeService.Models;
using ExchangeService.Services;

namespace ExchangeService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeController : ControllerBase
    {
        private readonly IExchangeService _exchange;

        public ExchangeController(IExchangeService exchange)
        {
            _exchange = exchange;
        }

        [HttpPost]
        [Route("GetCurrencies")]
        public Response GetCurrencies()
        {
            //var resCurrencies = new Response() {Currencies = new List<Currency>()};
            var res = _exchange.GetExchangeRates();

            return res;

        }


        [HttpPost]
        [Route("GetCurrency/{currencyCode}")]
        public Currency GetCurrency(string currencyCode)
        {
            //var resCurrencies = new Response() {Currencies = new List<Currency>()};
            var res = _exchange.GetExchangeRate(currencyCode);

            return res;

        }


    }
}
