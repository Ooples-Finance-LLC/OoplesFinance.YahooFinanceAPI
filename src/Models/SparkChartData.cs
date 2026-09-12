namespace OoplesFinance.YahooFinanceAPI.Models;

public class SparkInfo
{
    [JsonProperty("timestamp")]
    public List<int?> Timestamp { get; set; } = [];

    [JsonProperty("symbol")]
    public string Symbol { get; set; } = string.Empty;

    [JsonProperty("previousClose")]
    public object PreviousClose { get; set; } = new();

    [JsonProperty("chartPreviousClose")]
    public double? ChartPreviousClose { get; set; }

    [JsonProperty("dataGranularity")]
    public int? DataGranularity { get; set; }

    [JsonProperty("end")]
    public object End { get; set; } = new();

    [JsonProperty("start")]
    public object Start { get; set; } = new();

    [JsonProperty("close")]
    public List<double?> Close { get; set; } = [];
}