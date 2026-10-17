namespace OoplesFinance.YahooFinanceAPI.Models;

public class InsiderHolder
{
    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("relation")]
    public string Relation { get; set; } = string.Empty;

    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;

    [JsonProperty("transactionDescription")]
    public string TransactionDescription { get; set; } = string.Empty;

    [JsonProperty("latestTransDate")]
    public LatestTransDate LatestTransDate { get; set; } = new();

    [JsonProperty("positionDirect")]
    public PositionDirect PositionDirect { get; set; } = new();

    [JsonProperty("positionDirectDate")]
    public PositionDirectDate PositionDirectDate { get; set; } = new();

    [JsonProperty("positionIndirect")]
    public PositionIndirect PositionIndirect { get; set; } = new();

    [JsonProperty("positionIndirectDate")]
    public PositionIndirectDate PositionIndirectDate { get; set; } = new();
}

public class InsiderHolders
{
    [JsonProperty("holders")]
    public List<InsiderHolder> Holders { get; set; } = [];

    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }
}

public class LatestTransDate
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class PositionDirect
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class PositionDirectDate
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class PositionIndirect
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class PositionIndirectDate
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class InsiderHolderQuoteSummary
{
    [JsonProperty("result")]
    public List<InsiderHolderResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class InsiderHolderResult
{
    [JsonProperty("insiderHolders")]
    public InsiderHolders InsiderHolders { get; set; } = new();
}

public class InsiderHolderData
{
    [JsonProperty("quoteSummary")]
    public InsiderHolderQuoteSummary QuoteSummary { get; set; } = new();
}