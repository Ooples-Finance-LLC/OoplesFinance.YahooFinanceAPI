namespace OoplesFinance.YahooFinanceAPI.Models;

public class Actual
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class CurrentQuarterEstimate
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class EarningsInfo
{
    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }

    [JsonProperty("earningsChart")]
    public EarningsChart EarningsChart { get; set; } = new();

    [JsonProperty("financialsChart")]
    public FinancialsChart FinancialsChart { get; set; } = new();

    [JsonProperty("financialCurrency")]
    public string FinancialCurrency { get; set; } = string.Empty;

    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class EarningsChart
{
    [JsonProperty("quarterly")]
    public List<Quarterly> Quarterly { get; set; } = [];

    [JsonProperty("currentQuarterEstimate")]
    public CurrentQuarterEstimate CurrentQuarterEstimate { get; set; } = new();

    [JsonProperty("currentQuarterEstimateDate")]
    public string CurrentQuarterEstimateDate { get; set; } = string.Empty;

    [JsonProperty("currentQuarterEstimateYear")]
    public int? CurrentQuarterEstimateYear { get; set; }

    [JsonProperty("earningsDate")]
    public List<EarningsDate> EarningsDate { get; set; } = [];
}

public class EarningsEstimateInfo
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class FinancialsChart
{
    [JsonProperty("yearly")]
    public List<Yearly> Yearly { get; set; } = [];

    [JsonProperty("quarterly")]
    public List<Quarterly> Quarterly { get; set; } = [];
}

public class Quarterly
{
    [JsonProperty("date")]
    public string Date { get; set; } = string.Empty;

    [JsonProperty("actual")]
    public Actual Actual { get; set; } = new();

    [JsonProperty("estimate")]
    public EarningsEstimateInfo Estimate { get; set; } = new();

    [JsonProperty("revenue")]
    public Revenue Revenue { get; set; } = new();

    [JsonProperty("earnings")]
    public EarningsInfo Earnings { get; set; } = new();
}

public class EarningsQuoteSummary
{
    [JsonProperty("result")]
    public List<EarningsResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class EarningsResult
{
    [JsonProperty("earnings")]
    public EarningsInfo Earnings { get; set; } = new();
}

public class Revenue
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class EarningsData
{
    [JsonProperty("quoteSummary")]
    public EarningsQuoteSummary QuoteSummary { get; set; } = new();
}

public class Yearly
{
    [JsonProperty("date")]
    public int? Date { get; set; }

    [JsonProperty("revenue")]
    public Revenue Revenue { get; set; } = new();

    [JsonProperty("earnings")]
    public EarningsInfo Earnings { get; set; } = new();
}