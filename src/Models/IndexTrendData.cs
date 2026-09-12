namespace OoplesFinance.YahooFinanceAPI.Models;

public class Estimate
{
    [JsonProperty("period")]
    public string Period { get; set; } = string.Empty;

    [JsonProperty("growth")]
    public Growth Growth { get; set; } = new();
}

public class Growth
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class IndexTrend
{
    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }

    [JsonProperty("symbol")]
    public string Symbol { get; set; } = string.Empty;

    [JsonProperty("peRatio")]
    public PeRatio PeRatio { get; set; } = new();

    [JsonProperty("pegRatio")]
    public PegRatio PegRatio { get; set; } = new();

    [JsonProperty("estimates")]
    public List<Estimate> Estimates { get; set; } = [];
}

public class PeRatio
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class IndexTrendQuoteSummary
{
    [JsonProperty("result")]
    public List<IndexTrendResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class IndexTrendResult
{
    [JsonProperty("indexTrend")]
    public IndexTrend IndexTrend { get; set; } = new();
}

public class IndexTrendData
{
    [JsonProperty("quoteSummary")]
    public IndexTrendQuoteSummary QuoteSummary { get; set; } = new();
}