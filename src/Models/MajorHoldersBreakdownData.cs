namespace OoplesFinance.YahooFinanceAPI.Models;

public class InsidersPercentHeld
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class InstitutionsCount
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class InstitutionsFloatPercentHeld
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class InstitutionsPercentHeld
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class MajorHoldersBreakdown
{
    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }

    [JsonProperty("insidersPercentHeld")]
    public InsidersPercentHeld InsidersPercentHeld { get; set; } = new();

    [JsonProperty("institutionsPercentHeld")]
    public InstitutionsPercentHeld InstitutionsPercentHeld { get; set; } = new();

    [JsonProperty("institutionsFloatPercentHeld")]
    public InstitutionsFloatPercentHeld InstitutionsFloatPercentHeld { get; set; } = new();

    [JsonProperty("institutionsCount")]
    public InstitutionsCount InstitutionsCount { get; set; } = new();
}

public class MajorHoldersBreakdownQuoteSummary
{
    [JsonProperty("result")]
    public List<MajorHoldersBreakdownResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class MajorHoldersBreakdownResult
{
    [JsonProperty("majorHoldersBreakdown")]
    public MajorHoldersBreakdown MajorHoldersBreakdown { get; set; } = new();
}

public class MajorHoldersBreakdownData
{
    [JsonProperty("quoteSummary")]
    public MajorHoldersBreakdownQuoteSummary QuoteSummary { get; set; } = new();
}