// HistoricalData.cs
//  Andrew Baylis
//  Created: 11/10/2024

namespace OoplesFinance.YahooFinanceAPI.Models;

[Serializable]
public class HistoricalDataRoot
{
    #region Properties

    [JsonProperty("chart")]
    public Chart? Chart { get; set; }

    #endregion
}

public class Chart
{
    #region Properties

    [JsonProperty("error")]
    public object Error { get; set; } = new();

    [JsonProperty("result")]
    public List<Result> Result { get; set; } = [];

    #endregion
}

public class Result
{
    #region Properties

    [JsonProperty("events")]
    public HistoricalEvent Events { get; set; } = new();

    [JsonProperty("indicators")]
    public Indicators Indicators { get; set; } = new();

    [JsonProperty("meta")]
    public Meta Meta { get; set; } = new();

    [JsonProperty("timestamp")]
    public List<long?> Timestamp { get; set; } = [];

    #endregion
}

public class HistoricalEvent
{
    #region Properties

    [JsonProperty("dividends")]
    public Dictionary<long, Dividends> DividendData { get; set; } = new();

    [JsonProperty("splits")]
    public Dictionary<long, Splits> SplitData { get; set; } = new();

    #endregion
}

public class HistoricalChartInfo
{
    #region Properties

    public double AdjustedClose { get; set; }

    public double Close { get; set; }

    public DateTime Date { get; set; }

    public double High { get; set; }

    public double Low { get; set; }

    public Meta Meta { get; set; } = new();

    public double Open { get; set; }

    public long Volume { get; set; }

    #endregion
}

public class HistoricalFullData
{
    #region Properties

    public List<DividendInfo> Dividends { get; set; } = new();

    public Meta Meta { get; set; } = new();

    public List<HistoricalChartInfo> Prices { get; set; } = new();

    public List<SplitInfo> Splits { get; set; } = new();

    #endregion
}

public class DividendInfo
{
    public DividendInfo(Dividends d)
    {
        var dt = (long)d.Date.GetValueOrDefault();
        Date = dt.FromUnixTimeStamp();
        Amount = d.Amount;
    }

    #region Properties

    public double? Amount { get; set; }

    public DateTime Date { get; set; }

    #endregion
}

public class SplitInfo
{
    public SplitInfo(Splits s)
    {
        Date = s.Date.GetValueOrDefault().FromUnixTimeStamp();
        Denominator = s.Denominator;
        Numerator = s.Numerator;
        SplitRatio = s.SplitRatio;
    }

    #region Properties

    public DateTime? Date { get; set; }

    public long? Denominator { get; set; }

    public long? Numerator { get; set; }

    public string SplitRatio { get; set; }

    #endregion
}