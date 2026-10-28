namespace OoplesFinance.YahooFinanceAPI.Models;

public class History
{
    [JsonProperty("epochGradeDate")]
    public int? EpochGradeDate { get; set; }

    [JsonProperty("firm")]
    public string Firm { get; set; } = string.Empty;

    [JsonProperty("toGrade")]
    public string ToGrade { get; set; } = string.Empty;

    [JsonProperty("fromGrade")]
    public string FromGrade { get; set; } = string.Empty;

    [JsonProperty("action")]
    public string Action { get; set; } = string.Empty;
}

public class UpgradeDowngradeHistoryQuoteSummary
{
    [JsonProperty("result")]
    public List<UpgradeDowngradeHistoryResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class UpgradeDowngradeHistoryResult
{
    [JsonProperty("upgradeDowngradeHistory")]
    public UpgradeDowngradeHistory UpgradeDowngradeHistory { get; set; } = new();
}

public class UpgradeDowngradeHistoryData
{
    [JsonProperty("quoteSummary")]
    public UpgradeDowngradeHistoryQuoteSummary QuoteSummary { get; set; } = new();
}

public class UpgradeDowngradeHistory
{
    [JsonProperty("history")]
    public List<History> History { get; set; } = [];

    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }
}