namespace OoplesFinance.YahooFinanceAPI.Models;

public class Filing
{
    [JsonProperty("date")]
    public DateTime Date { get; set; } = new();

    [JsonProperty("epochDate")]
    public int? EpochDate { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; } = string.Empty;

    [JsonProperty("title")]
    public string Title { get; set; } = string.Empty;

    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;

    [JsonProperty("edgarUrl")]
    public string EdgarUrl { get; set; } = string.Empty;

    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }
}

public class SecFilingsQuoteSummary
{
    [JsonProperty("result")]
    public List<SecFilingsResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class SecFilingsResult
{
    [JsonProperty("secFilings")]
    public SecFilings SecFilings { get; set; } = new();
}

public class SecFilingsData
{
    [JsonProperty("quoteSummary")]
    public SecFilingsQuoteSummary QuoteSummary { get; set; } = new();
}

public class SecFilings
{
    [JsonProperty("filings")]
    public List<Filing> Filings { get; set; } = [];

    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }
}