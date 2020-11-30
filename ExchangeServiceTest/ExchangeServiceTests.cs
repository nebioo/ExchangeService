using ExchangeService.Enums;
using ExchangeService.Models;
using Xunit;

namespace ExchangeService.Tests
{
    public class ExchangeServiceTests
    {
 

        [Fact()]
        public void ExportCsvTest()
        {
            var service = new ExchangeService();
            var result = service.Export(ExportType.Csv);
            Assert.True(result);
        }

        [Fact()]
        public void ExportXmlTest()
        {
            var service = new ExchangeService();
            var result = service.Export(ExportType.Xml);
            Assert.True(result);
        }


        [Fact]
        public void GetExchangeRates_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var response = new Response();
            var service = new ExchangeService();

            // Act
            var result = service.GetExchangeRates();

            // Assert
            Assert.Equal(typeof(Response), result.GetType());
        }

        [Fact]
        public void GetExchangeRate_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = new ExchangeService();
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
            var service = new ExchangeService();

            var result = service.SortExchangeRatesAsc(Sort.Asc, Forex.Buying);
            Assert.True(result[0].ForexBuying < result[1].ForexBuying);
        }

        [Fact()]
        public void SortExchangeRatesDescTest()
        {
            var service = new ExchangeService();

            var result = service.SortExchangeRatesDesc(Sort.Desc, Forex.Selling);
            Assert.True(result[0].ForexSelling > result[1].ForexSelling);
        }
    }
}
