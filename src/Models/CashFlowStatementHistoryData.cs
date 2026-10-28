namespace OoplesFinance.YahooFinanceAPI.Models;

public class CapitalExpenditures
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class CashflowStatement
{
    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }

    [JsonProperty("endDate")]
    public EndDate EndDate { get; set; } = new();

    [JsonProperty("netIncome")]
    public NetIncome NetIncome { get; set; } = new();

    [JsonProperty("depreciation")]
    public Depreciation Depreciation { get; set; } = new();

    [JsonProperty("changeToNetincome")]
    public ChangeToNetincome ChangeToNetincome { get; set; } = new();

    [JsonProperty("changeToAccountReceivables")]
    public ChangeToAccountReceivables ChangeToAccountReceivables { get; set; } = new();

    [JsonProperty("changeToLiabilities")]
    public ChangeToLiabilities ChangeToLiabilities { get; set; } = new();

    [JsonProperty("changeToInventory")]
    public ChangeToInventory ChangeToInventory { get; set; } = new();

    [JsonProperty("changeToOperatingActivities")]
    public ChangeToOperatingActivities ChangeToOperatingActivities { get; set; } = new();

    [JsonProperty("totalCashFromOperatingActivities")]
    public TotalCashFromOperatingActivities TotalCashFromOperatingActivities { get; set; } = new();

    [JsonProperty("capitalExpenditures")]
    public CapitalExpenditures CapitalExpenditures { get; set; } = new();

    [JsonProperty("investments")]
    public Investments Investments { get; set; } = new();

    [JsonProperty("otherCashflowsFromInvestingActivities")]
    public OtherCashflowsFromInvestingActivities OtherCashflowsFromInvestingActivities { get; set; } = new();

    [JsonProperty("totalCashflowsFromInvestingActivities")]
    public TotalCashflowsFromInvestingActivities TotalCashflowsFromInvestingActivities { get; set; } = new();

    [JsonProperty("dividendsPaid")]
    public DividendsPaid DividendsPaid { get; set; } = new();

    [JsonProperty("netBorrowings")]
    public NetBorrowings NetBorrowings { get; set; } = new();

    [JsonProperty("otherCashflowsFromFinancingActivities")]
    public OtherCashflowsFromFinancingActivities OtherCashflowsFromFinancingActivities { get; set; } = new();

    [JsonProperty("totalCashFromFinancingActivities")]
    public TotalCashFromFinancingActivities TotalCashFromFinancingActivities { get; set; } = new();

    [JsonProperty("changeInCash")]
    public ChangeInCash ChangeInCash { get; set; } = new();

    [JsonProperty("repurchaseOfStock")]
    public RepurchaseOfStock RepurchaseOfStock { get; set; } = new();

    [JsonProperty("issuanceOfStock")]
    public IssuanceOfStock IssuanceOfStock { get; set; } = new();
}

public class CashflowStatementHistory
{
    [JsonProperty("cashflowStatements")]
    public List<CashflowStatement> CashflowStatements { get; set; } = [];

    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }
}

public class ChangeInCash
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class ChangeToAccountReceivables
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class ChangeToInventory
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class ChangeToLiabilities
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class ChangeToNetincome
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class ChangeToOperatingActivities
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class Depreciation
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class DividendsPaid
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class Investments
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class IssuanceOfStock
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class NetBorrowings
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class NetIncome
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class OtherCashflowsFromFinancingActivities
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class OtherCashflowsFromInvestingActivities
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class CashflowStatementHistoryQuoteSummary
{
    [JsonProperty("result")]
    public List<CashflowStatementHistoryResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class RepurchaseOfStock
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class CashflowStatementHistoryResult
{
    [JsonProperty("cashflowStatementHistory")]
    public CashflowStatementHistory CashflowStatementHistory { get; set; } = new();
}

public class CashflowStatementHistoryData
{
    [JsonProperty("quoteSummary")]
    public CashflowStatementHistoryQuoteSummary QuoteSummary { get; set; } = new();
}

public class TotalCashflowsFromInvestingActivities
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class TotalCashFromFinancingActivities
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class TotalCashFromOperatingActivities
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}