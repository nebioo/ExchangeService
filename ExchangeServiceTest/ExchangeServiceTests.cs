using ExchangeService;
using ExchangeService.Enums;
using ExchangeService.Models;
using Xunit;

namespace ExchangeServiceTest
{
    public class ExchangeServiceTests
    {

        [Fact()]
        public void ExportTest()
        {
            var service = new ExchangeService.ExchangeService();
            var result = service.Export(ExportType.Csv);
            if (result)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
            

        }
        [Fact]
        public void GetExchangeRates_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var response = new Response();
            var service = new ExchangeService.ExchangeService();

            // Act
            var result = service.GetExchangeRates();

            // Assert
            Assert.Equal(typeof(Response), response.GetType());
        }

        [Fact]
        public void GetExchangeRate_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = new ExchangeService.ExchangeService();
            string currencyCode = "USD";


            // Act
            var result = service.GetExchangeRate(
                currencyCode);

            // Assert
            Assert.Equal(result.CurrencyCode, currencyCode);
        }

        [Fact()]
        public void SortExchangeRatesAscTest()
        {
            var service = new ExchangeService.ExchangeService();

            var result = service.SortExchangeRatesAsc(Sort.Asc, Forex.Buying);
            if (result[0].ForexBuying < result[1].ForexBuying)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }

        }

        [Fact()]
        public void SortExchangeRatesDescTest()
        {
            var service = new ExchangeService.ExchangeService();

            var result = service.SortExchangeRatesDesc(Sort.Desc, Forex.Selling);
            if (result[0].ForexSelling > result[1].ForexSelling)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }
    }
}
