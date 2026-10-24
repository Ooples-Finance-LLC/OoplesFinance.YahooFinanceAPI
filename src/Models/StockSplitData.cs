namespace OoplesFinance.YahooFinanceAPI.Models;

[Serializable]

public class StockSplitRoot
{
    [JsonProperty("chart")]
    public StockSplitChart Chart { get; set; } = new();
}

public class StockSplitResult
{
    [JsonProperty("meta")]
    public Meta Meta { get; set; } = new();

    [JsonProperty("timestamp")]
    public List<int?> Timestamp { get; set; } = [];

    [JsonProperty("events")]
    public StockSplitEvents Events { get; set; } = new();

    [JsonProperty("indicators")]
    public Indicators Indicators { get; set; } = new();
}

public class StockSplitChart
{
    [JsonProperty("result")]
    public List<StockSplitResult> Result { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class StockSplitEvents
{
    [JsonProperty("splits")]
    public Dictionary<long, Splits> SplitData { get; set; } = [];
}

public partial class SplitItem
{
    public long Name { get; set; }
    public Splits SplitDataObject { get; set; } = new();
}

public class Splits
{
    [JsonProperty("date")]
    public long? Date { get; set; }

    [JsonProperty("numerator")]
    public long? Numerator { get; set; }

    [JsonProperty("denominator")]
    public long? Denominator { get; set; }

    [JsonProperty("splitRatio")]
    public string SplitRatio { get; set; } = string.Empty;
}