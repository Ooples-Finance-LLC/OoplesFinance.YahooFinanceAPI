namespace OoplesFinance.YahooFinanceAPI.Models;

public class MajorDirectHolders
{
    [JsonProperty("holders")]
    public List<object> Holders { get; set; } = [];

    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }
}

public class MajorDirectHoldersQuoteSummary
{
    [JsonProperty("result")]
    public List<MajorDirectHoldersResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class MajorDirectHoldersResult
{
    [JsonProperty("majorDirectHolders")]
    public MajorDirectHolders MajorDirectHolders { get; set; } = new();
}

public class MajorDirectHoldersData
{
    [JsonProperty("quoteSummary")]
    public MajorDirectHoldersQuoteSummary QuoteSummary { get; set; } = new();
}