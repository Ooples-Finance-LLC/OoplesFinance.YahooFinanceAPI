namespace OoplesFinance.YahooFinanceAPI.Models;

public class _10y
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class _3y
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class _5y
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class AnnualReportExpenseRatio
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class DeferredSalesLoad
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class FeesExpensesInvestment
{
    [JsonProperty("annualReportExpenseRatio")]
    public AnnualReportExpenseRatio AnnualReportExpenseRatio { get; set; } = new();

    [JsonProperty("frontEndSalesLoad")]
    public FrontEndSalesLoad FrontEndSalesLoad { get; set; } = new();

    [JsonProperty("deferredSalesLoad")]
    public DeferredSalesLoad DeferredSalesLoad { get; set; } = new();

    [JsonProperty("twelveBOne")]
    public TwelveBOne TwelveBOne { get; set; } = new();

    [JsonProperty("netExpRatio")]
    public NetExpRatio NetExpRatio { get; set; } = new();

    [JsonProperty("grossExpRatio")]
    public GrossExpRatio GrossExpRatio { get; set; } = new();

    [JsonProperty("annualHoldingsTurnover")]
    public AnnualHoldingsTurnover AnnualHoldingsTurnover { get; set; } = new();

    [JsonProperty("totalNetAssets")]
    public TotalNetAssets TotalNetAssets { get; set; } = new();

    [JsonProperty("projectionValues")]
    public ProjectionValues ProjectionValues { get; set; } = new();
}

public class FeesExpensesInvestmentCat
{
    [JsonProperty("annualReportExpenseRatio")]
    public AnnualReportExpenseRatio AnnualReportExpenseRatio { get; set; } = new();

    [JsonProperty("frontEndSalesLoad")]
    public FrontEndSalesLoad FrontEndSalesLoad { get; set; } = new();

    [JsonProperty("deferredSalesLoad")]
    public DeferredSalesLoad DeferredSalesLoad { get; set; } = new();

    [JsonProperty("twelveBOne")]
    public TwelveBOne TwelveBOne { get; set; } = new();

    [JsonProperty("annualHoldingsTurnover")]
    public AnnualHoldingsTurnover AnnualHoldingsTurnover { get; set; } = new();

    [JsonProperty("totalNetAssets")]
    public TotalNetAssets TotalNetAssets { get; set; } = new();

    [JsonProperty("projectionValuesCat")]
    public ProjectionValuesCat ProjectionValuesCat { get; set; } = new();
}

public class FrontEndSalesLoad
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class FundProfile
{
    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }

    [JsonProperty("styleBoxUrl")]
    public string StyleBoxUrl { get; set; } = string.Empty;

    [JsonProperty("family")]
    public string Family { get; set; } = string.Empty;

    [JsonProperty("categoryName")]
    public string CategoryName { get; set; } = string.Empty;

    [JsonProperty("legalType")]
    public object LegalType { get; set; } = new();

    [JsonProperty("managementInfo")]
    public ManagementInfo ManagementInfo { get; set; } = new();

    [JsonProperty("feesExpensesInvestment")]
    public FeesExpensesInvestment FeesExpensesInvestment { get; set; } = new();

    [JsonProperty("feesExpensesInvestmentCat")]
    public FeesExpensesInvestmentCat FeesExpensesInvestmentCat { get; set; } = new();

    [JsonProperty("initInvestment")]
    public InitInvestment InitInvestment { get; set; } = new();

    [JsonProperty("initIraInvestment")]
    public InitIraInvestment InitIraInvestment { get; set; } = new();

    [JsonProperty("initAipInvestment")]
    public InitAipInvestment InitAipInvestment { get; set; } = new();

    [JsonProperty("subseqInvestment")]
    public SubseqInvestment SubseqInvestment { get; set; } = new();

    [JsonProperty("subseqIraInvestment")]
    public SubseqIraInvestment SubseqIraInvestment { get; set; } = new();

    [JsonProperty("subseqAipInvestment")]
    public SubseqAipInvestment SubseqAipInvestment { get; set; } = new();

    [JsonProperty("brokerages")]
    public List<string> Brokerages { get; set; } = [];
}

public class GrossExpRatio
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class InitAipInvestment
{
}

public class InitInvestment
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class InitIraInvestment
{
}

public class ManagementInfo
{
    [JsonProperty("managerName")]
    public string ManagerName { get; set; } = string.Empty;

    [JsonProperty("managerBio")]
    public string ManagerBio { get; set; } = string.Empty;

    [JsonProperty("startdate")]
    public Startdate Startdate { get; set; } = new();
}

public class NetExpRatio
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class ProjectionValues
{
    [JsonProperty("5y")]
    public _5y _5y { get; set; } = new();

    [JsonProperty("3y")]
    public _3y _3y { get; set; } = new();

    [JsonProperty("10y")]
    public _10y _10y { get; set; } = new();
}

public class ProjectionValuesCat
{
    [JsonProperty("5y")]
    public _5y _5y { get; set; } = new();

    [JsonProperty("3y")]
    public _3y _3y { get; set; } = new();

    [JsonProperty("10y")]
    public _10y _10y { get; set; } = new();
}

public class FundProfileQuoteSummary
{
    [JsonProperty("result")]
    public List<FundProfileResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class FundProfileResult
{
    [JsonProperty("fundProfile")]
    public FundProfile FundProfile { get; set; } = new();
}

public class FundProfileData
{
    [JsonProperty("quoteSummary")]
    public FundProfileQuoteSummary QuoteSummary { get; set; } = new();
}

public class Startdate
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class SubseqAipInvestment
{
}

public class SubseqInvestment
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class SubseqIraInvestment
{
}

public class TotalNetAssets
{
}

public class TwelveBOne
{
}