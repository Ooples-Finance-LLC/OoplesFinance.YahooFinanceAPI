// AllHistoricalHelper.cs
//  Andrew Baylis
//  Created: 12/10/2024

namespace OoplesFinance.YahooFinanceAPI.Helpers;

internal class AllHistoricalHelper
{
    #region Internal Methods

    internal HistoricalFullData ParseYahooJsonData<T>(string jsonData)
    {
        var root = JsonConvert.DeserializeObject<HistoricalDataRoot>(jsonData)?.Chart?.Result.FirstOrDefault() ??
                   throw new InvalidOperationException("No data available from Yahoo Finance");

        var result = new HistoricalFullData { Meta = root.Meta };

        for (var i = 0; i < root.Timestamp.Count; i++)
        {
            result.Prices.Add(new HistoricalChartInfo
            {
                Meta = root.Meta,
                Date = root.Timestamp[i].GetValueOrDefault().FromUnixTimeStamp(),
                Open = Math.Round(root.Indicators?.Quote.FirstOrDefault()?.Open[i] ?? 0, 4),
                High = Math.Round(root.Indicators?.Quote.FirstOrDefault()?.High[i] ?? 0, 4),
                Low = Math.Round(root.Indicators?.Quote.FirstOrDefault()?.Low[i] ?? 0, 4),
                Close = Math.Round(root.Indicators?.Quote.FirstOrDefault()?.Close[i] ?? 0, 4),
                AdjustedClose = Math.Round(root.Indicators?.Adjclose.FirstOrDefault()?.Adjclose[i] ?? 0, 4),
                Volume = root.Indicators?.Quote.FirstOrDefault()?.Volume[i] ?? 0
            });
        }

        if (result.Prices.Count == 0)
        {
            throw new InvalidOperationException("Requested Information Not Available On Yahoo Finance");
        }

        if (root.Events.DividendData.Count > 0)
        {
            foreach (var dividend in root.Events.DividendData)
            {
                result.Dividends.Add(new DividendInfo(dividend.Value));
            }
        }

        if (root.Events.SplitData.Count > 0)
        {
            foreach (var split in root.Events.SplitData)
            {
                result.Splits.Add(new SplitInfo(split.Value));
            }
        }

        return result;
    }

    #endregion
}