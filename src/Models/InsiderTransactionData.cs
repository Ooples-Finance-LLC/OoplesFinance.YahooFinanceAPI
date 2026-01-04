namespace OoplesFinance.YahooFinanceAPI.Models;

public class InsiderTransactions
{
    [JsonProperty("transactions")]
    public List<Transaction> Transactions { get; set; } = [];

    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }
}

public class InsiderTransactionQuoteSummary
{
    [JsonProperty("result")]
    public List<InsiderTransactionResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class InsiderTransactionResult
{
    [JsonProperty("insiderTransactions")]
    public InsiderTransactions InsiderTransactions { get; set; } = new();
}

public class InsiderTransactionData
{
    [JsonProperty("quoteSummary")]
    public InsiderTransactionQuoteSummary QuoteSummary { get; set; } = new();
}

public class Shares
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class StartDate
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class Transaction
{
    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }

    [JsonProperty("shares")]
    public Shares Shares { get; set; } = new();

    [JsonProperty("value")]
    public Value Value { get; set; } = new();

    [JsonProperty("filerUrl")]
    public string FilerUrl { get; set; } = string.Empty;

    [JsonProperty("transactionText")]
    public string TransactionText { get; set; } = string.Empty;

    [JsonProperty("filerName")]
    public string FilerName { get; set; } = string.Empty;

    [JsonProperty("filerRelation")]
    public string FilerRelation { get; set; } = string.Empty;

    [JsonProperty("moneyText")]
    public string MoneyText { get; set; } = string.Empty;

    [JsonProperty("startDate")]
    public StartDate StartDate { get; set; } = new();

    [JsonProperty("ownership")]
    public string Ownership { get; set; } = string.Empty;
}

public class Value
{
    [JsonProperty("raw")]
    public float? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}