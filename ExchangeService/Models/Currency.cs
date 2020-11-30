namespace ExchangeService.Models
{
    public class Currency
    {
        public string CurrencyCode { get; set; }
        public int Unit { get; set; }
        public string CurrencyName { get; set; }
        public decimal? ForexBuying { get; set; }
        public decimal? ForexSelling { get; set; }

    }
}
