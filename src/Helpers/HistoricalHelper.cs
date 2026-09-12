
namespace OoplesFinance.YahooFinanceAPI.Helpers;

internal class HistoricalHelper : YahooJsonBase
{
    /// <summary>
    /// Parses the raw json data for the Financial Data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="jsonData"></param>
    /// <returns></returns>
    internal override IEnumerable<T> ParseYahooJsonData<T>(string jsonData)
    {
        var root = (JsonConvert.DeserializeObject<HistoricalDataRoot>(jsonData)?.Chart?.Result.FirstOrDefault()) ??
                throw new InvalidOperationException("No data available from Yahoo Finance");
        var historicalChartInfoList = new List<HistoricalChartInfo>();

        for (int i = 0; i < root.Timestamp.Count; i++)
        {
            historicalChartInfoList.Add(new HistoricalChartInfo
            {
                Date = root.Timestamp[i].GetValueOrDefault().FromUnixTimeStamp(),
                Open = Math.Round(root.Indicators?.Quote.FirstOrDefault()?.Open[i] ?? 0, 4),
                High = Math.Round(root.Indicators?.Quote.FirstOrDefault()?.High[i] ?? 0, 4),
                Low = Math.Round(root.Indicators?.Quote.FirstOrDefault()?.Low[i] ?? 0, 4),
                Close = Math.Round(root.Indicators?.Quote.FirstOrDefault()?.Close[i] ?? 0, 4),
                AdjustedClose = Math.Round(root.Indicators?.Adjclose.FirstOrDefault()?.Adjclose[i] ?? 0, 4),
                Volume = root.Indicators?.Quote.FirstOrDefault()?.Volume[i] ?? 0
            });
        }

        if (historicalChartInfoList.Count == 0)
        {
            throw new InvalidOperationException("Requested Information Not Available On Yahoo Finance");
        }

        return historicalChartInfoList.Cast<T>();
    }
}