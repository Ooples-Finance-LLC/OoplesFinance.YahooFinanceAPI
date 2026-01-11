namespace OoplesFinance.YahooFinanceAPI.Models;

[Serializable]
public class AdjClose
{
    [JsonProperty("adjclose")]
    public List<double?> Adjclose { get; set; } = [];
}

public class DividendChart
{
    [JsonProperty("result")]
    public List<DividendResult> Result { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class CurrentTradingPeriod
{
    [JsonProperty("pre")]
    public Pre Pre { get; set; } = new();

    [JsonProperty("regular")]
    public Regular Regular { get; set; } = new();

    [JsonProperty("post")]
    public Post Post { get; set; } = new();
}

public class Dividends
{
    [JsonProperty("amount")]
    public double? Amount { get; set; }

    [JsonProperty("date")]
    public int? Date { get; set; }
}

public class DividendEvents
{
    [JsonProperty("dividends")]
    public Dictionary<long, Dividends> DividendData { get; set; } = [];
}

public class Indicators
{
    [JsonProperty("quote")]
    public List<Quote> Quote { get; set; } = [];

    [JsonProperty("adjclose")]
    public List<AdjClose> Adjclose { get; set; } = [];
}

public class Meta
{
    [JsonProperty("currency")]
    public string Currency { get; set; } = string.Empty;

    [JsonProperty("symbol")]
    public string Symbol { get; set; } = string.Empty;

    [JsonProperty("exchangeName")]
    public string ExchangeName { get; set; } = string.Empty;

    [JsonProperty("fullExchangeName")]
    public string FullExchangeName { get; set; } = string.Empty;

    [JsonProperty("instrumentType")]
    public string InstrumentType { get; set; } = string.Empty;

    [JsonProperty("firstTradeDate")]
    public int? FirstTradeDate { get; set; }

    [JsonProperty("regularMarketTime")]
    public int? RegularMarketTime { get; set; }

    [JsonProperty("hasPrePostMarketData")]
    public bool? HasPrePostMarketData { get; set; }

    [JsonProperty("gmtoffset")]
    public int? Gmtoffset { get; set; }

    [JsonProperty("timezone")]
    public string Timezone { get; set; } = string.Empty;

    [JsonProperty("exchangeTimezoneName")]
    public string ExchangeTimezoneName { get; set; } = string.Empty;

    [JsonProperty("regularMarketPrice")]
    public double? RegularMarketPrice { get; set; }

    [JsonProperty("fiftyTwoWeekHigh")]
    public double? FiftyTwoWeekHigh { get; set; }

    [JsonProperty("fiftyTwoWeekLow")]
    public double? FiftyTwoWeekLow { get; set; }

    [JsonProperty("regularMarketDayHigh")]
    public double? RegularMarketDayHigh { get; set; }

    [JsonProperty("regularMarketDayLow")]
    public double? RegularMarketDayLow { get; set; }

    [JsonProperty("regularMarketVolume")]
    public long? RegularMarketVolume { get; set; }

    [JsonProperty("longName")]
    public string LongName { get; set; } = string.Empty;

    [JsonProperty("shortName")]
    public string ShortName { get; set; } = string.Empty;

    [JsonProperty("chartPreviousClose")]
    public double? ChartPreviousClose { get; set; }

    [JsonProperty("priceHint")]
    public int? PriceHint { get; set; }

    [JsonProperty("currentTradingPeriod")]
    public CurrentTradingPeriod CurrentTradingPeriod { get; set; } = new();

    [JsonProperty("dataGranularity")]
    public string DataGranularity { get; set; } = string.Empty;

    [JsonProperty("range")]
    public string Range { get; set; } = string.Empty;

    [JsonProperty("validRanges")]
    public List<string> ValidRanges { get; set; } = [];
}

public class Post
{
    [JsonProperty("timezone")]
    public string Timezone { get; set; } = string.Empty;

    [JsonProperty("start")]
    public int? Start { get; set; }

    [JsonProperty("end")]
    public int? End { get; set; }

    [JsonProperty("gmtoffset")]
    public int? Gmtoffset { get; set; }
}

public class Pre
{
    [JsonProperty("timezone")]
    public string Timezone { get; set; } = string.Empty;

    [JsonProperty("start")]
    public int? Start { get; set; }

    [JsonProperty("end")]
    public int? End { get; set; }

    [JsonProperty("gmtoffset")]
    public int? Gmtoffset { get; set; }
}

public class Quote
{
    [JsonProperty("close")]
    public List<double?> Close { get; set; } = [];

    [JsonProperty("high")]
    public List<double?> High { get; set; } = [];

    [JsonProperty("low")]
    public List<double?> Low { get; set; } = [];

    [JsonProperty("volume")]
    public List<long?> Volume { get; set; } = [];

    [JsonProperty("open")]
    public List<double?> Open { get; set; } = [];
}

public class Regular
{
    [JsonProperty("timezone")]
    public string Timezone { get; set; } = string.Empty;

    [JsonProperty("start")]
    public int? Start { get; set; }

    [JsonProperty("end")]
    public int? End { get; set; }

    [JsonProperty("gmtoffset")]
    public int? Gmtoffset { get; set; }
}

public class DividendResult
{
    [JsonProperty("meta")]
    public Meta Meta { get; set; } = new();

    [JsonProperty("timestamp")]
    public List<int?> Timestamp { get; set; } = [];

    [JsonProperty("events")]
    public DividendEvents Events { get; set; } = new();

    [JsonProperty("indicators")]
    public Indicators Indicators { get; set; } = new();
}

public class DividendRoot
{
    [JsonProperty("chart")]
    public DividendChart Chart { get; set; } = new();
}

public partial class DividendItem
{
    public long Name { get; set; }
    public Dividends DividendDataObject { get; set; } = new();
}