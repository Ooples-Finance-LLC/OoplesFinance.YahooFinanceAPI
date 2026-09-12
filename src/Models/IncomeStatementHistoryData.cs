namespace OoplesFinance.YahooFinanceAPI.Models;

public class CostOfRevenue
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class DiscontinuedOperations
{
}

public class Ebit
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class EffectOfAccountingCharges
{
}

public class ExtraordinaryItems
{
}

public class GrossProfit
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class IncomeBeforeTax
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class IncomeStatementHistory
{
    [JsonProperty("incomeStatementHistory")]
    public List<IncomeStatementHistory> IncomeStatementHistoryInfo { get; set; } = [];

    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }

    [JsonProperty("endDate")]
    public EndDate EndDate { get; set; } = new();

    [JsonProperty("totalRevenue")]
    public TotalRevenue TotalRevenue { get; set; } = new();

    [JsonProperty("costOfRevenue")]
    public CostOfRevenue CostOfRevenue { get; set; } = new();

    [JsonProperty("grossProfit")]
    public GrossProfit GrossProfit { get; set; } = new();

    [JsonProperty("researchDevelopment")]
    public ResearchDevelopment ResearchDevelopment { get; set; } = new();

    [JsonProperty("sellingGeneralAdministrative")]
    public SellingGeneralAdministrative SellingGeneralAdministrative { get; set; } = new();

    [JsonProperty("nonRecurring")]
    public NonRecurring NonRecurring { get; set; } = new();

    [JsonProperty("otherOperatingExpenses")]
    public OtherOperatingExpenses OtherOperatingExpenses { get; set; } = new();

    [JsonProperty("totalOperatingExpenses")]
    public TotalOperatingExpenses TotalOperatingExpenses { get; set; } = new();

    [JsonProperty("operatingIncome")]
    public OperatingIncome OperatingIncome { get; set; } = new();

    [JsonProperty("totalOtherIncomeExpenseNet")]
    public TotalOtherIncomeExpenseNet TotalOtherIncomeExpenseNet { get; set; } = new();

    [JsonProperty("ebit")]
    public Ebit Ebit { get; set; } = new();

    [JsonProperty("interestExpense")]
    public InterestExpense InterestExpense { get; set; } = new();

    [JsonProperty("incomeBeforeTax")]
    public IncomeBeforeTax IncomeBeforeTax { get; set; } = new();

    [JsonProperty("incomeTaxExpense")]
    public IncomeTaxExpense IncomeTaxExpense { get; set; } = new();

    [JsonProperty("minorityInterest")]
    public MinorityInterest MinorityInterest { get; set; } = new();

    [JsonProperty("netIncomeFromContinuingOps")]
    public NetIncomeFromContinuingOps NetIncomeFromContinuingOps { get; set; } = new();

    [JsonProperty("discontinuedOperations")]
    public DiscontinuedOperations DiscontinuedOperations { get; set; } = new();

    [JsonProperty("extraordinaryItems")]
    public ExtraordinaryItems ExtraordinaryItems { get; set; } = new();

    [JsonProperty("effectOfAccountingCharges")]
    public EffectOfAccountingCharges EffectOfAccountingCharges { get; set; } = new();

    [JsonProperty("otherItems")]
    public OtherItems OtherItems { get; set; } = new();

    [JsonProperty("netIncome")]
    public NetIncome NetIncome { get; set; } = new();

    [JsonProperty("netIncomeApplicableToCommonShares")]
    public NetIncomeApplicableToCommonShares NetIncomeApplicableToCommonShares { get; set; } = new();
}

public class IncomeTaxExpense
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class InterestExpense
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class MinorityInterest
{
}

public class NetIncomeApplicableToCommonShares
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class NetIncomeFromContinuingOps
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class NonRecurring
{
}

public class OperatingIncome
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class OtherItems
{
}

public class OtherOperatingExpenses
{
}

public class IncomeStatementHistoryQuoteSummary
{
    [JsonProperty("result")]
    public List<IncomeStatementHistoryResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class ResearchDevelopment
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class IncomeStatementHistoryResult
{
    [JsonProperty("incomeStatementHistory")]
    public IncomeStatementHistory IncomeStatementHistory { get; set; } = new();
}

public class IncomeStatementHistoryData
{
    [JsonProperty("quoteSummary")]
    public IncomeStatementHistoryQuoteSummary QuoteSummary { get; set; } = new();
}

public class SellingGeneralAdministrative
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class TotalOperatingExpenses
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class TotalOtherIncomeExpenseNet
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}