using FinanceTools.Core.Models;
using TinyCsvParser.Mapping;

namespace FinanceTools.Core.Services.CsvParsing.CsvMapping
{
    public class YahooFinanceCsvMarketPriceMapping : CsvMapping<MarketPrice>
    {
        public YahooFinanceCsvMarketPriceMapping()
            : base()
        {
            MapProperty(0, x => x.Date);
            MapProperty(4, x => x.Price);
        }
    }
}
