namespace OoplesFinance.YahooFinanceAPI.Models;

public class CalendarEvents
{
    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }

    [JsonProperty("earnings")]
    public Earnings Earnings { get; set; } = new();

    [JsonProperty("exDividendDate")]
    public ExDividendDate ExDividendDate { get; set; } = new();

    [JsonProperty("dividendDate")]
    public DividendDate DividendDate { get; set; } = new();
}

public class DividendDate
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class Earnings
{
    [JsonProperty("earningsDate")]
    public List<EarningsDate> EarningsDate { get; set; } = [];

    [JsonProperty("earningsAverage")]
    public EarningsAverage EarningsAverage { get; set; } = new();

    [JsonProperty("earningsLow")]
    public EarningsLow EarningsLow { get; set; } = new();

    [JsonProperty("earningsHigh")]
    public EarningsHigh EarningsHigh { get; set; } = new();

    [JsonProperty("revenueAverage")]
    public RevenueAverage RevenueAverage { get; set; } = new();

    [JsonProperty("revenueLow")]
    public RevenueLow RevenueLow { get; set; } = new();

    [JsonProperty("revenueHigh")]
    public RevenueHigh RevenueHigh { get; set; } = new();
}

public class EarningsAverage
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class EarningsDate
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class EarningsHigh
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class EarningsLow
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class CalendarEventsQuoteSummary
{
    [JsonProperty("result")]
    public List<CalendarEventsResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class CalendarEventsResult
{
    [JsonProperty("calendarEvents")]
    public CalendarEvents CalendarEvents { get; set; } = new();
}

public class RevenueAverage
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class RevenueHigh
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class RevenueLow
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class CalendarEventsData
{
    [JsonProperty("quoteSummary")]
    public CalendarEventsQuoteSummary QuoteSummary { get; set; } = new();
}