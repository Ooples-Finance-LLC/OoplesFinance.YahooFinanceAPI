namespace OoplesFinance.YahooFinanceAPI.Models;

public class BalanceSheetHistoryQuarterly
{
    [JsonProperty("balanceSheetStatements")]
    public List<BalanceSheetStatement> BalanceSheetStatements { get; set; } = [];

    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }
}

public class BalanceSheetHistoryQuarterlyQuoteSummary
{
    [JsonProperty("result")]
    public List<BalanceSheetHistoryQuarterlyResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class BalanceSheetHistoryQuarterlyResult
{
    [JsonProperty("balanceSheetHistoryQuarterly")]
    public BalanceSheetHistoryQuarterly BalanceSheetHistoryQuarterly { get; set; } = new();
}

public class BalanceSheetHistoryQuarterlyData
{
    [JsonProperty("quoteSummary")]
    public BalanceSheetHistoryQuarterlyQuoteSummary QuoteSummary { get; set; } = new();
}