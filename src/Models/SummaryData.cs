namespace OoplesFinance.YahooFinanceAPI.Models;

public class Ask
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class AskSize
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class AverageDailyVolume10Day
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class AverageVolume
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class AverageVolume10days
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class BetaSummary
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class Bid
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class BidSize
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class CirculatingSupply
{
}

public class DayHigh
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class DayLow
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class DividendRate
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class DividendYield
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class ExDividendDate
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class ExpireDate
{
}

public class FiftyDayAverage
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class FiftyTwoWeekHigh
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class FiftyTwoWeekLow
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class FiveYearAvgDividendYield
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class MarketCap
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class MaxSupply
{
}

public class NavPrice
{
}

public class Open
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class OpenInterest
{
}

public class PayoutRatio
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class PreviousClose
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class PriceHintSummary
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class PriceToSalesTrailing12Months
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class QuoteSummary
{
    [JsonProperty("result")]
    public List<ResultSummary> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class RegularMarketDayHigh
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class RegularMarketDayLow
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class RegularMarketOpen
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class RegularMarketPreviousClose
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class RegularMarketVolume
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class ResultSummary
{
    [JsonProperty("summaryDetail")]
    public SummaryDetail SummaryDetail { get; set; } = new();
}

public class SummaryData
{
    [JsonProperty("quoteSummary")]
    public QuoteSummary QuoteSummary { get; set; } = new();
}

public class StrikePrice
{
}

public class SummaryDetail
{
    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }

    [JsonProperty("priceHint")]
    public PriceHint PriceHint { get; set; } = new();

    [JsonProperty("previousClose")]
    public PreviousClose PreviousClose { get; set; } = new();

    [JsonProperty("open")]
    public Open Open { get; set; } = new();

    [JsonProperty("dayLow")]
    public DayLow DayLow { get; set; } = new();

    [JsonProperty("dayHigh")]
    public DayHigh DayHigh { get; set; } = new();

    [JsonProperty("regularMarketPreviousClose")]
    public RegularMarketPreviousClose RegularMarketPreviousClose { get; set; } = new();

    [JsonProperty("regularMarketOpen")]
    public RegularMarketOpen RegularMarketOpen { get; set; } = new();

    [JsonProperty("regularMarketDayLow")]
    public RegularMarketDayLow RegularMarketDayLow { get; set; } = new();

    [JsonProperty("regularMarketDayHigh")]
    public RegularMarketDayHigh RegularMarketDayHigh { get; set; } = new();

    [JsonProperty("dividendRate")]
    public DividendRate DividendRate { get; set; } = new();

    [JsonProperty("dividendYield")]
    public DividendYield DividendYield { get; set; } = new();

    [JsonProperty("exDividendDate")]
    public ExDividendDate ExDividendDate { get; set; } = new();

    [JsonProperty("payoutRatio")]
    public PayoutRatio PayoutRatio { get; set; } = new();

    [JsonProperty("fiveYearAvgDividendYield")]
    public FiveYearAvgDividendYield FiveYearAvgDividendYield { get; set; } = new();

    [JsonProperty("beta")]
    public Beta Beta { get; set; } = new();

    [JsonProperty("trailingPE")]
    public TrailingPE TrailingPE { get; set; } = new();

    [JsonProperty("forwardPE")]
    public ForwardPE ForwardPE { get; set; } = new();

    [JsonProperty("volume")]
    public Volume Volume { get; set; } = new();

    [JsonProperty("regularMarketVolume")]
    public RegularMarketVolume RegularMarketVolume { get; set; } = new();

    [JsonProperty("averageVolume")]
    public AverageVolume AverageVolume { get; set; } = new();

    [JsonProperty("averageVolume10days")]
    public AverageVolume10days AverageVolume10days { get; set; } = new();

    [JsonProperty("averageDailyVolume10Day")]
    public AverageDailyVolume10Day AverageDailyVolume10Day { get; set; } = new();

    [JsonProperty("bid")]
    public Bid Bid { get; set; } = new();

    [JsonProperty("ask")]
    public Ask Ask { get; set; } = new();

    [JsonProperty("bidSize")]
    public BidSize BidSize { get; set; } = new();

    [JsonProperty("askSize")]
    public AskSize AskSize { get; set; } = new();

    [JsonProperty("marketCap")]
    public MarketCap MarketCap { get; set; } = new();

    [JsonProperty("yield")]
    public Yield Yield { get; set; } = new();

    [JsonProperty("ytdReturn")]
    public YtdReturnSummary YtdReturn { get; set; } = new();

    [JsonProperty("totalAssets")]
    public TotalAssetsSummary TotalAssets { get; set; } = new();

    [JsonProperty("expireDate")]
    public ExpireDate ExpireDate { get; set; } = new();

    [JsonProperty("strikePrice")]
    public StrikePrice StrikePrice { get; set; } = new();

    [JsonProperty("openInterest")]
    public OpenInterest OpenInterest { get; set; } = new();

    [JsonProperty("fiftyTwoWeekLow")]
    public FiftyTwoWeekLow FiftyTwoWeekLow { get; set; } = new();

    [JsonProperty("fiftyTwoWeekHigh")]
    public FiftyTwoWeekHigh FiftyTwoWeekHigh { get; set; } = new();

    [JsonProperty("priceToSalesTrailing12Months")]
    public PriceToSalesTrailing12Months PriceToSalesTrailing12Months { get; set; } = new();

    [JsonProperty("fiftyDayAverage")]
    public FiftyDayAverage FiftyDayAverage { get; set; } = new();

    [JsonProperty("twoHundredDayAverage")]
    public TwoHundredDayAverage TwoHundredDayAverage { get; set; } = new();

    [JsonProperty("trailingAnnualDividendRate")]
    public TrailingAnnualDividendRate TrailingAnnualDividendRate { get; set; } = new();

    [JsonProperty("trailingAnnualDividendYield")]
    public TrailingAnnualDividendYield TrailingAnnualDividendYield { get; set; } = new();

    [JsonProperty("navPrice")]
    public NavPrice NavPrice { get; set; } = new();

    [JsonProperty("currency")]
    public string Currency { get; set; } = string.Empty;

    [JsonProperty("fromCurrency")]
    public object FromCurrency { get; set; } = new();

    [JsonProperty("toCurrency")]
    public object ToCurrency { get; set; } = new();

    [JsonProperty("lastMarket")]
    public object LastMarket { get; set; } = new();

    [JsonProperty("coinMarketCapLink")]
    public object CoinMarketCapLink { get; set; } = new();

    [JsonProperty("volume24Hr")]
    public Volume24Hr Volume24Hr { get; set; } = new();

    [JsonProperty("volumeAllCurrencies")]
    public VolumeAllCurrencies VolumeAllCurrencies { get; set; } = new();

    [JsonProperty("circulatingSupply")]
    public CirculatingSupply CirculatingSupply { get; set; } = new();

    [JsonProperty("algorithm")]
    public object Algorithm { get; set; } = new();

    [JsonProperty("maxSupply")]
    public MaxSupply MaxSupply { get; set; } = new();

    [JsonProperty("startDate")]
    public StartDate StartDate { get; set; } = new();

    [JsonProperty("tradeable")]
    public bool? Tradeable { get; set; }
}

public class TrailingAnnualDividendRate
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class TrailingAnnualDividendYield
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class TrailingPE
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class TwoHundredDayAverage
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class Volume
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class Volume24Hr
{
}

public class VolumeAllCurrencies
{
}

public class YtdReturn
{
}