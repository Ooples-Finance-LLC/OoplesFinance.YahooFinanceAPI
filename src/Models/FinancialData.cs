namespace OoplesFinance.YahooFinanceAPI.Models;

public class CurrentPrice
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class CurrentRatio
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class DebtToEquity
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class EarningsGrowth
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class Ebitda
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class EbitdaMargins
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class FinancialData
{
    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }

    [JsonProperty("currentPrice")]
    public CurrentPrice CurrentPrice { get; set; } = new();

    [JsonProperty("targetHighPrice")]
    public TargetHighPrice TargetHighPrice { get; set; } = new();

    [JsonProperty("targetLowPrice")]
    public TargetLowPrice TargetLowPrice { get; set; } = new();

    [JsonProperty("targetMeanPrice")]
    public TargetMeanPrice TargetMeanPrice { get; set; } = new();

    [JsonProperty("targetMedianPrice")]
    public TargetMedianPrice TargetMedianPrice { get; set; } = new();

    [JsonProperty("recommendationMean")]
    public RecommendationMean RecommendationMean { get; set; } = new();

    [JsonProperty("recommendationKey")]
    public string RecommendationKey { get; set; } = string.Empty;

    [JsonProperty("numberOfAnalystOpinions")]
    public NumberOfAnalystOpinions NumberOfAnalystOpinions { get; set; } = new();

    [JsonProperty("totalCash")]
    public TotalCash TotalCash { get; set; } = new();

    [JsonProperty("totalCashPerShare")]
    public TotalCashPerShare TotalCashPerShare { get; set; } = new();

    [JsonProperty("ebitda")]
    public Ebitda Ebitda { get; set; } = new();

    [JsonProperty("totalDebt")]
    public TotalDebt TotalDebt { get; set; } = new();

    [JsonProperty("quickRatio")]
    public QuickRatio QuickRatio { get; set; } = new();

    [JsonProperty("currentRatio")]
    public CurrentRatio CurrentRatio { get; set; } = new();

    [JsonProperty("totalRevenue")]
    public TotalRevenue TotalRevenue { get; set; } = new();

    [JsonProperty("debtToEquity")]
    public DebtToEquity DebtToEquity { get; set; } = new();

    [JsonProperty("revenuePerShare")]
    public RevenuePerShare RevenuePerShare { get; set; } = new();

    [JsonProperty("returnOnAssets")]
    public ReturnOnAssets ReturnOnAssets { get; set; } = new();

    [JsonProperty("returnOnEquity")]
    public ReturnOnEquity ReturnOnEquity { get; set; } = new();

    [JsonProperty("grossProfits")]
    public GrossProfits GrossProfits { get; set; } = new();

    [JsonProperty("freeCashflow")]
    public FreeCashflow FreeCashflow { get; set; } = new();

    [JsonProperty("operatingCashflow")]
    public OperatingCashflow OperatingCashflow { get; set; } = new();

    [JsonProperty("earningsGrowth")]
    public EarningsGrowth EarningsGrowth { get; set; } = new();

    [JsonProperty("revenueGrowth")]
    public RevenueGrowth RevenueGrowth { get; set; } = new();

    [JsonProperty("grossMargins")]
    public GrossMargins GrossMargins { get; set; } = new();

    [JsonProperty("ebitdaMargins")]
    public EbitdaMargins EbitdaMargins { get; set; } = new();

    [JsonProperty("operatingMargins")]
    public OperatingMargins OperatingMargins { get; set; } = new();

    [JsonProperty("profitMargins")]
    public ProfitMargins ProfitMargins { get; set; } = new();

    [JsonProperty("financialCurrency")]
    public string FinancialCurrency { get; set; } = string.Empty;
}

public class FreeCashflow
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class GrossMargins
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class GrossProfits
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class NumberOfAnalystOpinions
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class OperatingCashflow
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class OperatingMargins
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class QuickRatio
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class FinancialQuoteSummary
{
    [JsonProperty("result")]
    public List<FinancialDataResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class RecommendationMean
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class FinancialDataResult
{
    [JsonProperty("financialData")]
    public FinancialData FinancialData { get; set; } = new();
}

public class ReturnOnAssets
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class ReturnOnEquity
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class RevenueGrowth
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class RevenuePerShare
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class FinancialDataRoot
{
    [JsonProperty("quoteSummary")]
    public FinancialQuoteSummary QuoteSummary { get; set; } = new();
}

public class TargetHighPrice
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class TargetLowPrice
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class TargetMeanPrice
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class TargetMedianPrice
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class TotalCash
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class TotalCashPerShare
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class TotalDebt
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class TotalRevenue
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}