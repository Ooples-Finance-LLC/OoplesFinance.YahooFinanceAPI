namespace OoplesFinance.YahooFinanceAPI.Models;

public class IncomeStatementHistoryItem
{
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

public class IncomeStatementHistoryQuarterly
{
    [JsonProperty("incomeStatementHistory")]
    public List<IncomeStatementHistoryItem> IncomeStatementHistory { get; set; } = [];

    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }
}

public class IncomeStatementHistoryQuarterlyQuoteSummary
{
    [JsonProperty("result")]
    public List<IncomeStatementHistoryQuarterlyResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class IncomeStatementHistoryQuarterlyResult
{
    [JsonProperty("incomeStatementHistoryQuarterly")]
    public IncomeStatementHistoryQuarterly IncomeStatementHistoryQuarterly { get; set; } = new();
}

public class IncomeStatementHistoryQuarterlyData
{
    [JsonProperty("quoteSummary")]
    public IncomeStatementHistoryQuarterlyQuoteSummary QuoteSummary { get; set; } = new();
}