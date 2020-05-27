using FinanceTools.Core.Models;
using FinanceTools.Core.Services.CsvParsing.CsvMapping;
using TinyCsvParser;

namespace FinanceTools.Core.Services.CsvParsing
{
    public static class CsvParserProvider
    {
        public static CsvParser<MarketPrice> YahooFinanceCsvParser
        {
            get
            {
                CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
                YahooFinanceCsvMarketPriceMapping csvMapper = new YahooFinanceCsvMarketPriceMapping();
                CsvParser<MarketPrice> csvParser = new CsvParser<MarketPrice>(csvParserOptions, csvMapper);
                return csvParser;
            }
        }
    }
}
