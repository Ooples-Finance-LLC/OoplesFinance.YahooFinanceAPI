namespace OoplesFinance.YahooFinanceAPI.Models;

public class _30daysAgo
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class _60daysAgo
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class _7daysAgo
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class _90daysAgo
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class Avg
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class Current
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class DownLast30days
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class DownLast90days
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class EarningsEstimate
{
    [JsonProperty("avg")]
    public Avg Avg { get; set; } = new();

    [JsonProperty("low")]
    public Low Low { get; set; } = new();

    [JsonProperty("high")]
    public High High { get; set; } = new();

    [JsonProperty("yearAgoEps")]
    public YearAgoEps YearAgoEps { get; set; } = new();

    [JsonProperty("numberOfAnalysts")]
    public NumberOfAnalysts NumberOfAnalysts { get; set; } = new();

    [JsonProperty("growth")]
    public Growth Growth { get; set; } = new();
}

public class EarningsTrend
{
    [JsonProperty("trend")]
    public List<EarningsTrendInfo> Trends { get; set; } = [];

    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }
}

public class EpsRevisions
{
    [JsonProperty("upLast7days")]
    public UpLast7days UpLast7days { get; set; } = new();

    [JsonProperty("upLast30days")]
    public UpLast30days UpLast30days { get; set; } = new();

    [JsonProperty("downLast30days")]
    public DownLast30days DownLast30days { get; set; } = new();

    [JsonProperty("downLast90days")]
    public DownLast90days DownLast90days { get; set; } = new();
}

public class EpsTrend
{
    [JsonProperty("current")]
    public Current Current { get; set; } = new();

    [JsonProperty("7daysAgo")]
    public _7daysAgo _7daysAgo { get; set; } = new();

    [JsonProperty("30daysAgo")]
    public _30daysAgo _30daysAgo { get; set; } = new();

    [JsonProperty("60daysAgo")]
    public _60daysAgo _60daysAgo { get; set; } = new();

    [JsonProperty("90daysAgo")]
    public _90daysAgo _90daysAgo { get; set; } = new();
}

public class High
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class Low
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class NumberOfAnalysts
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class EarningsTrendQuoteSummary
{
    [JsonProperty("result")]
    public List<EarningsTrendResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class EarningsTrendResult
{
    [JsonProperty("earningsTrend")]
    public EarningsTrend EarningsTrend { get; set; } = new();
}

public class RevenueEstimate
{
    [JsonProperty("avg")]
    public Avg Avg { get; set; } = new();

    [JsonProperty("low")]
    public Low Low { get; set; } = new();

    [JsonProperty("high")]
    public High High { get; set; } = new();

    [JsonProperty("numberOfAnalysts")]
    public NumberOfAnalysts NumberOfAnalysts { get; set; } = new();

    [JsonProperty("yearAgoRevenue")]
    public YearAgoRevenue YearAgoRevenue { get; set; } = new();

    [JsonProperty("growth")]
    public Growth Growth { get; set; } = new();
}

public class EarningsTrendData
{
    [JsonProperty("quoteSummary")]
    public EarningsTrendQuoteSummary QuoteSummary { get; set; } = new();
}

public class EarningsTrendInfo
{
    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }

    [JsonProperty("period")]
    public string Period { get; set; } = string.Empty;

    [JsonProperty("endDate")]
    public string EndDate { get; set; } = string.Empty;

    [JsonProperty("growth")]
    public Growth Growth { get; set; } = new();

    [JsonProperty("earningsEstimate")]
    public EarningsEstimate EarningsEstimate { get; set; } = new();

    [JsonProperty("revenueEstimate")]
    public RevenueEstimate RevenueEstimate { get; set; } = new();

    [JsonProperty("epsTrend")]
    public EpsTrend EpsTrend { get; set; } = new();

    [JsonProperty("epsRevisions")]
    public EpsRevisions EpsRevisions { get; set; } = new();
}

public class UpLast30days
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class UpLast7days
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class YearAgoEps
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class YearAgoRevenue
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}