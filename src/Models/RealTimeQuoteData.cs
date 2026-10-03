namespace OoplesFinance.YahooFinanceAPI.Models;

public class QuoteResponse
{
    [JsonProperty("result")]
    public List<RealTimeQuoteResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class RealTimeQuoteResult
{
    [JsonProperty("language")]
    public string Language { get; set; } = string.Empty;

    [JsonProperty("region")]
    public string Region { get; set; } = string.Empty;

    [JsonProperty("quoteType")]
    public string QuoteType { get; set; } = string.Empty;

    [JsonProperty("typeDisp")]
    public string TypeDisp { get; set; } = string.Empty;

    [JsonProperty("quoteSourceName")]
    public string QuoteSourceName { get; set; } = string.Empty;

    [JsonProperty("triggerable")]
    public bool? Triggerable { get; set; }

    [JsonProperty("customPriceAlertConfidence")]
    public string CustomPriceAlertConfidence { get; set; } = string.Empty;

    [JsonProperty("currency")]
    public string Currency { get; set; } = string.Empty;

    [JsonProperty("fiftyTwoWeekHighChange")]
    public double? FiftyTwoWeekHighChange { get; set; }

    [JsonProperty("fiftyTwoWeekHighChangePercent")]
    public double? FiftyTwoWeekHighChangePercent { get; set; }

    [JsonProperty("fiftyTwoWeekLow")]
    public double? FiftyTwoWeekLow { get; set; }

    [JsonProperty("fiftyTwoWeekHigh")]
    public double? FiftyTwoWeekHigh { get; set; }

    [JsonProperty("dividendDate")]
    public int? DividendDate { get; set; }

    [JsonProperty("earningsTimestamp")]
    public int? EarningsTimestamp { get; set; }

    [JsonProperty("earningsTimestampStart")]
    public int? EarningsTimestampStart { get; set; }

    [JsonProperty("earningsTimestampEnd")]
    public int? EarningsTimestampEnd { get; set; }

    [JsonProperty("trailingAnnualDividendRate")]
    public double? TrailingAnnualDividendRate { get; set; }

    [JsonProperty("trailingPE")]
    public double? TrailingPE { get; set; }

    [JsonProperty("trailingAnnualDividendYield")]
    public double? TrailingAnnualDividendYield { get; set; }

    [JsonProperty("epsTrailingTwelveMonths")]
    public double? EpsTrailingTwelveMonths { get; set; }

    [JsonProperty("epsForward")]
    public double? EpsForward { get; set; }

    [JsonProperty("epsCurrentYear")]
    public double? EpsCurrentYear { get; set; }

    [JsonProperty("priceEpsCurrentYear")]
    public double? PriceEpsCurrentYear { get; set; }

    [JsonProperty("sharesOutstanding")]
    public long? SharesOutstanding { get; set; }

    [JsonProperty("bookValue")]
    public double? BookValue { get; set; }

    [JsonProperty("fiftyDayAverage")]
    public double? FiftyDayAverage { get; set; }

    [JsonProperty("fiftyDayAverageChange")]
    public double? FiftyDayAverageChange { get; set; }

    [JsonProperty("fiftyDayAverageChangePercent")]
    public double? FiftyDayAverageChangePercent { get; set; }

    [JsonProperty("twoHundredDayAverage")]
    public double? TwoHundredDayAverage { get; set; }

    [JsonProperty("twoHundredDayAverageChange")]
    public double? TwoHundredDayAverageChange { get; set; }

    [JsonProperty("twoHundredDayAverageChangePercent")]
    public double? TwoHundredDayAverageChangePercent { get; set; }

    [JsonProperty("marketCap")]
    public long? MarketCap { get; set; }

    [JsonProperty("forwardPE")]
    public double? ForwardPE { get; set; }

    [JsonProperty("priceToBook")]
    public double? PriceToBook { get; set; }

    [JsonProperty("sourceInterval")]
    public int? SourceInterval { get; set; }

    [JsonProperty("exchangeDataDelayedBy")]
    public int? ExchangeDataDelayedBy { get; set; }

    [JsonProperty("averageAnalystRating")] public string AverageAnalystRating { get; set; } = string.Empty;

    [JsonProperty("tradeable")]
    public bool? Tradeable { get; set; }

    [JsonProperty("cryptoTradeable")]
    public bool? CryptoTradeable { get; set; }

    [JsonProperty("regularMarketChangePercent")]
    public double? RegularMarketChangePercent { get; set; }

    [JsonProperty("regularMarketPrice")]
    public double? RegularMarketPrice { get; set; }

    [JsonProperty("marketState")]
    public string MarketState { get; set; } = string.Empty;

    [JsonProperty("exchange")]
    public string Exchange { get; set; } = string.Empty;

    [JsonProperty("shortName")]
    public string ShortName { get; set; } = string.Empty;

    [JsonProperty("longName")]
    public string LongName { get; set; } = string.Empty;

    [JsonProperty("messageBoardId")]
    public string MessageBoardId { get; set; } = string.Empty;

    [JsonProperty("exchangeTimezoneName")]
    public string ExchangeTimezoneName { get; set; } = string.Empty;

    [JsonProperty("exchangeTimezoneShortName")]
    public string ExchangeTimezoneShortName { get; set; } = string.Empty;

    [JsonProperty("gmtOffSetMilliseconds")]
    public int? GmtOffSetMilliseconds { get; set; }

    [JsonProperty("market")]
    public string Market { get; set; } = string.Empty;

    [JsonProperty("esgPopulated")]
    public bool? EsgPopulated { get; set; }

    [JsonProperty("firstTradeDateMilliseconds")]
    public object FirstTradeDateMilliseconds { get; set; } = new();

    [JsonProperty("priceHint")]
    public int? PriceHint { get; set; }

    [JsonProperty("postMarketChangePercent")]
    public double? PostMarketChangePercent { get; set; }

    [JsonProperty("postMarketTime")]
    public int? PostMarketTime { get; set; }

    [JsonProperty("postMarketPrice")]
    public double? PostMarketPrice { get; set; }

    [JsonProperty("postMarketChange")]
    public double? PostMarketChange { get; set; }

    [JsonProperty("regularMarketChange")]
    public double? RegularMarketChange { get; set; }

    [JsonProperty("regularMarketTime")]
    public int? RegularMarketTime { get; set; }

    [JsonProperty("regularMarketDayHigh")]
    public double? RegularMarketDayHigh { get; set; }

    [JsonProperty("regularMarketDayRange")]
    public string RegularMarketDayRange { get; set; } = string.Empty;

    [JsonProperty("regularMarketDayLow")]
    public double? RegularMarketDayLow { get; set; }

    [JsonProperty("regularMarketVolume")]
    public long? RegularMarketVolume { get; set; }

    [JsonProperty("regularMarketPreviousClose")]
    public double? RegularMarketPreviousClose { get; set; }

    [JsonProperty("bid")]
    public double? Bid { get; set; }

    [JsonProperty("ask")]
    public double? Ask { get; set; }

    [JsonProperty("bidSize")]
    public int? BidSize { get; set; }

    [JsonProperty("askSize")]
    public int? AskSize { get; set; }

    [JsonProperty("fullExchangeName")]
    public string FullExchangeName { get; set; } = string.Empty;

    [JsonProperty("financialCurrency")]
    public string FinancialCurrency { get; set; } = string.Empty;

    [JsonProperty("regularMarketOpen")]
    public double? RegularMarketOpen { get; set; }

    [JsonProperty("averageDailyVolume3Month")]
    public long? AverageDailyVolume3Month { get; set; }

    [JsonProperty("averageDailyVolume10Day")]
    public long? AverageDailyVolume10Day { get; set; }

    [JsonProperty("fiftyTwoWeekLowChange")]
    public double? FiftyTwoWeekLowChange { get; set; }

    [JsonProperty("fiftyTwoWeekLowChangePercent")]
    public double? FiftyTwoWeekLowChangePercent { get; set; }

    [JsonProperty("fiftyTwoWeekRange")]
    public string FiftyTwoWeekRange { get; set; } = string.Empty;

    [JsonProperty("displayName")]
    public string DisplayName { get; set; } = string.Empty;

    [JsonProperty("symbol")]
    public string Symbol { get; set; } = string.Empty;
}

public class RealTimeQuoteData
{
    [JsonProperty("quoteResponse")]
    public QuoteResponse QuoteResponse { get; set; } = new();
}