namespace OoplesFinance.YahooFinanceAPI.Models;

public class FundOwnership
{
    [JsonProperty("ownershipList")]
    public List<OwnershipList> OwnershipList { get; set; } = [];

    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }
}

public class FundOwnershipQuoteSummary
{
    [JsonProperty("result")]
    public List<FundOwnershipResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class FundOwnershipResult
{
    [JsonProperty("fundOwnership")]
    public FundOwnership FundOwnership { get; set; } = new();
}

public class FundOwnershipData
{
    [JsonProperty("quoteSummary")]
    public FundOwnershipQuoteSummary QuoteSummary { get; set; } = new();
}