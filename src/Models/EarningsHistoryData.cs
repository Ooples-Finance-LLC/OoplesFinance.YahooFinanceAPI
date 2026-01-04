namespace OoplesFinance.YahooFinanceAPI.Models;

public class EarningsHistory
{
    [JsonProperty("history")]
    public List<EarningsHistoryInfo> History { get; set; } = [];

    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }
}

public class EpsActual
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class EpsDifference
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class EpsEstimate
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class EarningsHistoryInfo
{
    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }

    [JsonProperty("epsActual")]
    public EpsActual EpsActual { get; set; } = new();

    [JsonProperty("epsEstimate")]
    public EpsEstimate EpsEstimate { get; set; } = new();

    [JsonProperty("epsDifference")]
    public EpsDifference EpsDifference { get; set; } = new();

    [JsonProperty("surprisePercent")]
    public SurprisePercent SurprisePercent { get; set; } = new();

    [JsonProperty("quarter")]
    public Quarter Quarter { get; set; } = new();

    [JsonProperty("period")]
    public string Period { get; set; } = string.Empty;
}

public class Quarter
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class EarningsHistoryQuoteSummary
{
    [JsonProperty("result")]
    public List<EarningsHistoryResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class EarningsHistoryResult
{
    [JsonProperty("earningsHistory")]
    public EarningsHistory EarningsHistory { get; set; } = new();
}

public class EarningsHistoryData
{
    [JsonProperty("quoteSummary")]
    public EarningsHistoryQuoteSummary QuoteSummary { get; set; } = new();
}

public class SurprisePercent
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}