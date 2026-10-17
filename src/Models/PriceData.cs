namespace OoplesFinance.YahooFinanceAPI.Models;

public class AverageDailyVolume3Month
{
}

public class PostMarketChange
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class PostMarketChangePercent
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class PostMarketPrice
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class PreMarketChange
{
}

public class PreMarketPrice
{
}

public class Price
{
    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }

    [JsonProperty("preMarketChange")]
    public PreMarketChange PreMarketChange { get; set; } = new();

    [JsonProperty("preMarketPrice")]
    public PreMarketPrice PreMarketPrice { get; set; } = new();

    [JsonProperty("preMarketSource")]
    public string PreMarketSource { get; set; } = string.Empty;

    [JsonProperty("postMarketChangePercent")]
    public PostMarketChangePercent PostMarketChangePercent { get; set; } = new();

    [JsonProperty("postMarketChange")]
    public PostMarketChange PostMarketChange { get; set; } = new();

    [JsonProperty("postMarketTime")]
    public int? PostMarketTime { get; set; }

    [JsonProperty("postMarketPrice")]
    public PostMarketPrice PostMarketPrice { get; set; } = new();

    [JsonProperty("postMarketSource")]
    public string PostMarketSource { get; set; } = string.Empty;

    [JsonProperty("regularMarketChangePercent")]
    public RegularMarketChangePercent RegularMarketChangePercent { get; set; } = new();

    [JsonProperty("regularMarketChange")]
    public RegularMarketChange RegularMarketChange { get; set; } = new();

    [JsonProperty("regularMarketTime")]
    public int? RegularMarketTime { get; set; }

    [JsonProperty("priceHint")]
    public PriceHint PriceHint { get; set; } = new();

    [JsonProperty("regularMarketPrice")]
    public RegularMarketPrice RegularMarketPrice { get; set; } = new();

    [JsonProperty("regularMarketDayHigh")]
    public RegularMarketDayHigh RegularMarketDayHigh { get; set; } = new();

    [JsonProperty("regularMarketDayLow")]
    public RegularMarketDayLow RegularMarketDayLow { get; set; } = new();

    [JsonProperty("regularMarketVolume")]
    public RegularMarketVolume RegularMarketVolume { get; set; } = new();

    [JsonProperty("averageDailyVolume10Day")]
    public AverageDailyVolume10Day AverageDailyVolume10Day { get; set; } = new();

    [JsonProperty("averageDailyVolume3Month")]
    public AverageDailyVolume3Month AverageDailyVolume3Month { get; set; } = new();

    [JsonProperty("regularMarketPreviousClose")]
    public RegularMarketPreviousClose RegularMarketPreviousClose { get; set; } = new();

    [JsonProperty("regularMarketSource")]
    public string RegularMarketSource { get; set; } = string.Empty;

    [JsonProperty("regularMarketOpen")]
    public RegularMarketOpen RegularMarketOpen { get; set; } = new();

    [JsonProperty("strikePrice")]
    public StrikePrice StrikePrice { get; set; } = new();

    [JsonProperty("openInterest")]
    public OpenInterest OpenInterest { get; set; } = new();

    [JsonProperty("exchange")]
    public string Exchange { get; set; } = string.Empty;

    [JsonProperty("exchangeName")]
    public string ExchangeName { get; set; } = string.Empty;

    [JsonProperty("exchangeDataDelayedBy")]
    public int? ExchangeDataDelayedBy { get; set; }

    [JsonProperty("marketState")]
    public string MarketState { get; set; } = string.Empty;

    [JsonProperty("quoteType")]
    public string QuoteType { get; set; } = string.Empty;

    [JsonProperty("symbol")]
    public string Symbol { get; set; } = string.Empty;

    [JsonProperty("underlyingSymbol")]
    public object UnderlyingSymbol { get; set; } = new();

    [JsonProperty("shortName")]
    public string ShortName { get; set; } = string.Empty;

    [JsonProperty("longName")]
    public string LongName { get; set; } = string.Empty;

    [JsonProperty("currency")]
    public string Currency { get; set; } = string.Empty;

    [JsonProperty("quoteSourceName")]
    public string QuoteSourceName { get; set; } = string.Empty;

    [JsonProperty("currencySymbol")]
    public string CurrencySymbol { get; set; } = string.Empty;

    [JsonProperty("fromCurrency")]
    public object FromCurrency { get; set; } = new();

    [JsonProperty("lastMarket")]
    public object LastMarket { get; set; } = new();

    [JsonProperty("volume24Hr")]
    public Volume24Hr Volume24Hr { get; set; } = new();

    [JsonProperty("volumeAllCurrencies")]
    public VolumeAllCurrencies VolumeAllCurrencies { get; set; } = new();

    [JsonProperty("circulatingSupply")]
    public CirculatingSupply CirculatingSupply { get; set; } = new();

    [JsonProperty("marketCap")]
    public MarketCap MarketCap { get; set; } = new();
}

public class PriceQuoteSummary
{
    [JsonProperty("result")]
    public List<PriceResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class RegularMarketChange
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class RegularMarketChangePercent
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class RegularMarketPrice
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class PriceResult
{
    [JsonProperty("price")]
    public Price Price { get; set; } = new();
}

public class PriceData
{
    [JsonProperty("quoteSummary")]
    public PriceQuoteSummary QuoteSummary { get; set; } = new();
}