namespace OoplesFinance.YahooFinanceAPI.Models;

public class AccountsPayable
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class BalanceSheetHistory
{
    [JsonProperty("balanceSheetStatements")]
    public List<BalanceSheetStatement> BalanceSheetStatements { get; set; } = [];

    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }
}

public class BalanceSheetStatement
{
    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }

    [JsonProperty("endDate")]
    public EndDate EndDate { get; set; } = new();

    [JsonProperty("cash")]
    public Cash Cash { get; set; } = new();

    [JsonProperty("shortTermInvestments")]
    public ShortTermInvestments ShortTermInvestments { get; set; } = new();

    [JsonProperty("netReceivables")]
    public NetReceivables NetReceivables { get; set; } = new();

    [JsonProperty("inventory")]
    public Inventory Inventory { get; set; } = new();

    [JsonProperty("otherCurrentAssets")]
    public OtherCurrentAssets OtherCurrentAssets { get; set; } = new();

    [JsonProperty("totalCurrentAssets")]
    public TotalCurrentAssets TotalCurrentAssets { get; set; } = new();

    [JsonProperty("longTermInvestments")]
    public LongTermInvestments LongTermInvestments { get; set; } = new();

    [JsonProperty("propertyPlantEquipment")]
    public PropertyPlantEquipment PropertyPlantEquipment { get; set; } = new();

    [JsonProperty("otherAssets")]
    public OtherAssets OtherAssets { get; set; } = new();

    [JsonProperty("totalAssets")]
    public TotalAssets TotalAssets { get; set; } = new();

    [JsonProperty("accountsPayable")]
    public AccountsPayable AccountsPayable { get; set; } = new();

    [JsonProperty("shortLongTermDebt")]
    public ShortLongTermDebt ShortLongTermDebt { get; set; } = new();

    [JsonProperty("otherCurrentLiab")]
    public OtherCurrentLiab OtherCurrentLiab { get; set; } = new();

    [JsonProperty("longTermDebt")]
    public LongTermDebt LongTermDebt { get; set; } = new();

    [JsonProperty("otherLiab")]
    public OtherLiab OtherLiab { get; set; } = new();

    [JsonProperty("totalCurrentLiabilities")]
    public TotalCurrentLiabilities TotalCurrentLiabilities { get; set; } = new();

    [JsonProperty("totalLiab")]
    public TotalLiab TotalLiab { get; set; } = new();

    [JsonProperty("commonStock")]
    public CommonStock CommonStock { get; set; } = new();

    [JsonProperty("retainedEarnings")]
    public RetainedEarnings RetainedEarnings { get; set; } = new();

    [JsonProperty("treasuryStock")]
    public TreasuryStock TreasuryStock { get; set; } = new();

    [JsonProperty("otherStockholderEquity")]
    public OtherStockholderEquity OtherStockholderEquity { get; set; } = new();

    [JsonProperty("totalStockholderEquity")]
    public TotalStockholderEquity TotalStockholderEquity { get; set; } = new();

    [JsonProperty("netTangibleAssets")]
    public NetTangibleAssets NetTangibleAssets { get; set; } = new();
}

public class Cash
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class CommonStock
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class EndDate
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class Inventory
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class LongTermDebt
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class LongTermInvestments
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class NetReceivables
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class NetTangibleAssets
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class OtherAssets
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class OtherCurrentAssets
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class OtherCurrentLiab
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class OtherLiab
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class OtherStockholderEquity
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class PropertyPlantEquipment
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class BalanceSheetHistoryQuoteSummary
{
    [JsonProperty("result")]
    public List<BalanceSheetHistoryResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class BalanceSheetHistoryResult
{
    [JsonProperty("balanceSheetHistory")]
    public BalanceSheetHistory BalanceSheetHistory { get; set; } = new();
}

public class RetainedEarnings
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class BalanceSheetHistoryData
{
    [JsonProperty("quoteSummary")]
    public BalanceSheetHistoryQuoteSummary QuoteSummary { get; set; } = new();
}

public class ShortLongTermDebt
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class ShortTermInvestments
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class TotalAssets
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class TotalCurrentAssets
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class TotalCurrentLiabilities
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class TotalLiab
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class TotalStockholderEquity
{
    [JsonProperty("raw")]
    public object Raw { get; set; } = new();

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class TreasuryStock
{
    [JsonProperty("raw")]
    public long? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}