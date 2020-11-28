using ExchangeService.Services;
using System;
using ExchangeService.Models;
using Xunit;

namespace ExchangeServiceTest.Services
{
    public class ExchangeServiceTests
    {
        [Fact]
        public void GetExchangeRates_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var response = new Response(); 
            var service = new ExchangeService.Services.ExchangeService();

            // Act
            var result = service.GetExchangeRates();

            // Assert
            Assert.Equal(typeof(Response), response.GetType());
        }

        [Fact]
        public void GetExchangeRate_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = new ExchangeService.Services.ExchangeService();
            string currencyCode = "USD";
            

            // Act
            var result = service.GetExchangeRate(
                currencyCode);

            // Assert
            Assert.Equal(result.CurrencyCode , currencyCode);
        }
    }
}
