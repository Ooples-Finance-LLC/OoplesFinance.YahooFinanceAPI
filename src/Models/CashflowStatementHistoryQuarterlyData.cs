namespace OoplesFinance.YahooFinanceAPI.Models;

public class CashflowStatementHistoryQuarterly
{
    [JsonProperty("cashflowStatements")]
    public List<CashflowStatement> CashflowStatements { get; set; } = [];

    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }
}

public class CashflowStatementHistoryQuarterlyQuoteSummary
{
    [JsonProperty("result")]
    public List<CashflowStatementHistoryQuarterlyResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class CashflowStatementHistoryQuarterlyResult
{
    [JsonProperty("cashflowStatementHistoryQuarterly")]
    public CashflowStatementHistoryQuarterly CashflowStatementHistoryQuarterly { get; set; } = new();
}

public class CashflowStatementHistoryQuarterlyData
{
    [JsonProperty("quoteSummary")]
    public CashflowStatementHistoryQuarterlyQuoteSummary QuoteSummary { get; set; } = new();
}