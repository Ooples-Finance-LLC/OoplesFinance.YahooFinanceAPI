namespace OoplesFinance.YahooFinanceAPI.Models;

public class BuyInfoCount
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class BuyInfoShares
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class BuyPercentInsiderShares
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class NetInfoCount
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class NetInfoShares
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class NetPercentInsiderShares
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class NetSharePurchaseActivity
{
    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }

    [JsonProperty("period")]
    public string Period { get; set; } = string.Empty;

    [JsonProperty("buyInfoCount")]
    public BuyInfoCount BuyInfoCount { get; set; } = new();

    [JsonProperty("buyInfoShares")]
    public BuyInfoShares BuyInfoShares { get; set; } = new();

    [JsonProperty("buyPercentInsiderShares")]
    public BuyPercentInsiderShares BuyPercentInsiderShares { get; set; } = new();

    [JsonProperty("sellInfoCount")]
    public SellInfoCount SellInfoCount { get; set; } = new();

    [JsonProperty("sellInfoShares")]
    public SellInfoShares SellInfoShares { get; set; } = new();

    [JsonProperty("sellPercentInsiderShares")]
    public SellPercentInsiderShares SellPercentInsiderShares { get; set; } = new();

    [JsonProperty("netInfoCount")]
    public NetInfoCount NetInfoCount { get; set; } = new();

    [JsonProperty("netInfoShares")]
    public NetInfoShares NetInfoShares { get; set; } = new();

    [JsonProperty("netPercentInsiderShares")]
    public NetPercentInsiderShares NetPercentInsiderShares { get; set; } = new();

    [JsonProperty("totalInsiderShares")]
    public TotalInsiderShares TotalInsiderShares { get; set; } = new();
}

public class NetSharePurchaseActivityQuoteSummary
{
    [JsonProperty("result")]
    public List<NetSharePurchaseActivityResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class NetSharePurchaseActivityResult
{
    [JsonProperty("netSharePurchaseActivity")]
    public NetSharePurchaseActivity NetSharePurchaseActivity { get; set; } = new();
}

public class NetSharePurchaseActivityData
{
    [JsonProperty("quoteSummary")]
    public NetSharePurchaseActivityQuoteSummary QuoteSummary { get; set; } = new();
}

public class SellInfoCount
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class SellInfoShares
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class SellPercentInsiderShares
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class TotalInsiderShares
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}