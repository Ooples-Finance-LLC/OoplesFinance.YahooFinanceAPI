namespace OoplesFinance.YahooFinanceAPI.Models;

public class SectorTrendQuoteSummary
{
    [JsonProperty("result")]
    public List<SectorTrendResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class SectorTrendResult
{
    [JsonProperty("sectorTrend")]
    public SectorTrend SectorTrend { get; set; } = new();
}

public class SectorTrendData
{
    [JsonProperty("quoteSummary")]
    public SectorTrendQuoteSummary QuoteSummary { get; set; } = new();
}

public class SectorTrend
{
    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }

    [JsonProperty("symbol")]
    public object Symbol { get; set; } = new();

    [JsonProperty("peRatio")]
    public PeRatio PeRatio { get; set; } = new();

    [JsonProperty("pegRatio")]
    public PegRatio PegRatio { get; set; } = new();

    [JsonProperty("estimates")]
    public List<object> Estimates { get; set; } = [];
}