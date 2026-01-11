namespace OoplesFinance.YahooFinanceAPI.Models;

public class QuoteTypeQuoteSummary
{
    [JsonProperty("result")]
    public List<QuoteTypeResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class QuoteType
{
    [JsonProperty("exchange")]
    public string Exchange { get; set; } = string.Empty;

    [JsonProperty("quoteType")]
    public string QuoteTypeInfo { get; set; } = string.Empty;

    [JsonProperty("symbol")]
    public string Symbol { get; set; } = string.Empty;

    [JsonProperty("underlyingSymbol")]
    public string UnderlyingSymbol { get; set; } = string.Empty;

    [JsonProperty("shortName")]
    public string ShortName { get; set; } = string.Empty;

    [JsonProperty("longName")]
    public string LongName { get; set; } = string.Empty;

    [JsonProperty("firstTradeDateEpochUtc")]
    public int? FirstTradeDateEpochUtc { get; set; }

    [JsonProperty("timeZoneFullName")]
    public string TimeZoneFullName { get; set; } = string.Empty;

    [JsonProperty("timeZoneShortName")]
    public string TimeZoneShortName { get; set; } = string.Empty;

    [JsonProperty("uuid")]
    public string Uuid { get; set; } = string.Empty;

    [JsonProperty("gmtOffSetMilliseconds")]
    public int? GmtOffSetMilliseconds { get; set; }

    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }
}

public class QuoteTypeResult
{
    [JsonProperty("quoteType")]
    public QuoteType QuoteType { get; set; } = new();
}

public class QuoteTypeData
{
    [JsonProperty("quoteSummary")]
    public QuoteTypeQuoteSummary QuoteSummary { get; set; } = new();
}