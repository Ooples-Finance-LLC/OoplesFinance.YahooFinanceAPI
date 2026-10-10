namespace OoplesFinance.YahooFinanceAPI.Models;

public class _52WeekChange
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class AnnualHoldingsTurnover
{
}

public class Beta
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class Beta3Year
{
}

public class BookValue
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class DateShortInterest
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class KeyStatistics
{
    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }

    [JsonProperty("priceHint")]
    public PriceHint PriceHint { get; set; } = new();

    [JsonProperty("enterpriseValue")]
    public EnterpriseValue EnterpriseValue { get; set; } = new();

    [JsonProperty("forwardPE")]
    public ForwardPE ForwardPE { get; set; } = new();

    [JsonProperty("profitMargins")]
    public ProfitMargins ProfitMargins { get; set; } = new();

    [JsonProperty("floatShares")]
    public FloatShares FloatShares { get; set; } = new();

    [JsonProperty("sharesOutstanding")]
    public SharesOutstanding SharesOutstanding { get; set; } = new();

    [JsonProperty("sharesShort")]
    public SharesShort SharesShort { get; set; } = new();

    [JsonProperty("sharesShortPriorMonth")]
    public SharesShortPriorMonth SharesShortPriorMonth { get; set; } = new();

    [JsonProperty("sharesShortPreviousMonthDate")]
    public SharesShortPreviousMonthDate SharesShortPreviousMonthDate { get; set; } = new();

    [JsonProperty("dateShortInterest")]
    public DateShortInterest DateShortInterest { get; set; } = new();

    [JsonProperty("sharesPercentSharesOut")]
    public SharesPercentSharesOut SharesPercentSharesOut { get; set; } = new();

    [JsonProperty("heldPercentInsiders")]
    public HeldPercentInsiders HeldPercentInsiders { get; set; } = new();

    [JsonProperty("heldPercentInstitutions")]
    public HeldPercentInstitutions HeldPercentInstitutions { get; set; } = new();

    [JsonProperty("shortRatio")]
    public ShortRatio ShortRatio { get; set; } = new();

    [JsonProperty("shortPercentOfFloat")]
    public ShortPercentOfFloat ShortPercentOfFloat { get; set; } = new();

    [JsonProperty("beta")]
    public Beta Beta { get; set; } = new();

    [JsonProperty("impliedSharesOutstanding")]
    public ImpliedSharesOutstanding ImpliedSharesOutstanding { get; set; } = new();

    [JsonProperty("morningStarOverallRating")]
    public MorningStarOverallRating MorningStarOverallRating { get; set; } = new();

    [JsonProperty("morningStarRiskRating")]
    public MorningStarRiskRating MorningStarRiskRating { get; set; } = new();

    [JsonProperty("category")]
    public object Category { get; set; } = new();

    [JsonProperty("bookValue")]
    public BookValue BookValue { get; set; } = new();

    [JsonProperty("priceToBook")]
    public PriceToBook PriceToBook { get; set; } = new();

    [JsonProperty("annualReportExpenseRatio")]
    public AnnualReportExpenseRatio AnnualReportExpenseRatio { get; set; } = new();

    [JsonProperty("ytdReturn")]
    public YtdReturnSummary YtdReturn { get; set; } = new();

    [JsonProperty("beta3Year")]
    public Beta3Year Beta3Year { get; set; } = new();

    [JsonProperty("totalAssets")]
    public TotalAssetsSummary TotalAssets { get; set; } = new();

    [JsonProperty("yield")]
    public Yield Yield { get; set; } = new();

    [JsonProperty("fundFamily")]
    public object FundFamily { get; set; } = new();

    [JsonProperty("fundInceptionDate")]
    public FundInceptionDate FundInceptionDate { get; set; } = new();

    [JsonProperty("legalType")]
    public object LegalType { get; set; } = new();

    [JsonProperty("threeYearAverageReturn")]
    public ThreeYearAverageReturn ThreeYearAverageReturn { get; set; } = new();

    [JsonProperty("fiveYearAverageReturn")]
    public FiveYearAverageReturn FiveYearAverageReturn { get; set; } = new();

    [JsonProperty("priceToSalesTrailing12Months")]
    public PriceToSalesTrailing12Months PriceToSalesTrailing12Months { get; set; } = new();

    [JsonProperty("lastFiscalYearEnd")]
    public LastFiscalYearEnd LastFiscalYearEnd { get; set; } = new();

    [JsonProperty("nextFiscalYearEnd")]
    public NextFiscalYearEnd NextFiscalYearEnd { get; set; } = new();

    [JsonProperty("mostRecentQuarter")]
    public MostRecentQuarter MostRecentQuarter { get; set; } = new();

    [JsonProperty("earningsQuarterlyGrowth")]
    public EarningsQuarterlyGrowth EarningsQuarterlyGrowth { get; set; } = new();

    [JsonProperty("revenueQuarterlyGrowth")]
    public RevenueQuarterlyGrowth RevenueQuarterlyGrowth { get; set; } = new();

    [JsonProperty("netIncomeToCommon")]
    public NetIncomeToCommon NetIncomeToCommon { get; set; } = new();

    [JsonProperty("trailingEps")]
    public TrailingEps TrailingEps { get; set; } = new();

    [JsonProperty("forwardEps")]
    public ForwardEps ForwardEps { get; set; } = new();

    [JsonProperty("pegRatio")]
    public PegRatio PegRatio { get; set; } = new();

    [JsonProperty("lastSplitFactor")]
    public string LastSplitFactor { get; set; } = string.Empty;

    [JsonProperty("lastSplitDate")]
    public LastSplitDate LastSplitDate { get; set; } = new();

    [JsonProperty("enterpriseToRevenue")]
    public EnterpriseToRevenue EnterpriseToRevenue { get; set; } = new();

    [JsonProperty("enterpriseToEbitda")]
    public EnterpriseToEbitda EnterpriseToEbitda { get; set; } = new();

    [JsonProperty("52WeekChange")]
    public _52WeekChange _52WeekChange { get; set; } = new();

    [JsonProperty("SandP52WeekChange")]
    public SandP52WeekChange SandP52WeekChange { get; set; } = new();

    [JsonProperty("lastDividendValue")]
    public LastDividendValue LastDividendValue { get; set; } = new();

    [JsonProperty("lastDividendDate")]
    public LastDividendDate LastDividendDate { get; set; } = new();

    [JsonProperty("lastCapGain")]
    public LastCapGain LastCapGain { get; set; } = new();

    [JsonProperty("annualHoldingsTurnover")]
    public AnnualHoldingsTurnover AnnualHoldingsTurnover { get; set; } = new();
}

public class EarningsQuarterlyGrowth
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class EnterpriseToEbitda
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class EnterpriseToRevenue
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class EnterpriseValue
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class FiveYearAverageReturn
{
}

public class FloatShares
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class ForwardEps
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class ForwardPE
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class FundInceptionDate
{
}

public class HeldPercentInsiders
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class HeldPercentInstitutions
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class ImpliedSharesOutstanding
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public object Fmt { get; set; } = new();

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class LastCapGain
{
}

public class LastDividendDate
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class LastDividendValue
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class LastFiscalYearEnd
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class LastSplitDate
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class MorningStarOverallRating
{
}

public class MorningStarRiskRating
{
}

public class MostRecentQuarter
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class NetIncomeToCommon
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class NextFiscalYearEnd
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class PegRatio
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class PriceHint
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class PriceToBook
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class ProfitMargins
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class QuoteSummaryStatistic
{
    [JsonProperty("result")]
    public List<KeyStatisticResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class KeyStatisticResult
{
    [JsonProperty("defaultKeyStatistics")]
    public KeyStatistics DefaultKeyStatistics { get; set; } = new();
}

public class RevenueQuarterlyGrowth
{
}

public class KeyStatisticData
{
    [JsonProperty("quoteSummary")]
    public QuoteSummaryStatistic QuoteSummary { get; set; } = new();
}

public class SandP52WeekChange
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class SharesOutstanding
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class SharesPercentSharesOut
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class SharesShort
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class SharesShortPreviousMonthDate
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class SharesShortPriorMonth
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class ShortPercentOfFloat
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class ShortRatio
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class ThreeYearAverageReturn
{
}

public class TotalAssetsSummary
{
}

public class TrailingEps
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class Yield
{
}

public class YtdReturnSummary
{
}