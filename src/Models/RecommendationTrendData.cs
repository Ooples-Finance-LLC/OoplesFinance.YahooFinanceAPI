namespace OoplesFinance.YahooFinanceAPI.Models;

public class RecommendationTrendQuoteSummary
{
    [JsonProperty("result")]
    public List<RecommendationTrendResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class RecommendationTrend
{
    [JsonProperty("trend")]
    public List<Trend> Trend { get; set; } = [];

    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }
}

public class RecommendationTrendResult
{
    [JsonProperty("recommendationTrend")]
    public RecommendationTrend RecommendationTrend { get; set; } = new();
}

public class RecommendationTrendData
{
    [JsonProperty("quoteSummary")]
    public RecommendationTrendQuoteSummary QuoteSummary { get; set; } = new();
}

public class Trend
{
    [JsonProperty("period")]
    public string Period { get; set; } = string.Empty;

    [JsonProperty("strongBuy")]
    public int? StrongBuy { get; set; }

    [JsonProperty("buy")]
    public int? Buy { get; set; }

    [JsonProperty("hold")]
    public int? Hold { get; set; }

    [JsonProperty("sell")]
    public int? Sell { get; set; }

    [JsonProperty("strongSell")]
    public int? StrongSell { get; set; }
}