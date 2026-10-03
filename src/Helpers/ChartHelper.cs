namespace OoplesFinance.YahooFinanceAPI.Helpers;

internal class ChartHelper : YahooJsonBase
{
    /// <summary>
    /// Parses the raw json data for the Chart data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="jsonData"></param>
    /// <returns></returns>
    internal override IEnumerable<T> ParseYahooJsonData<T>(string jsonData)
    {
        var root = JsonConvert.DeserializeObject<ChartRoot>(jsonData)?.Chart.Result.FirstOrDefault();

        var result = new ChartInfo
        {
            DateList = new List<DateTime>(root != null ? root.Timestamp.Select(x => x.FromUnixTimeStamp()) : []),
            CloseList = new List<double>(root != null ? root.Indicators?.Quote.SelectMany(x => x.Close.Select(y => y.GetValueOrDefault())) ?? [] : []),
            OpenList = new List<double>(root != null ? root.Indicators?.Quote.SelectMany(x => x.Open.Select(y => y.GetValueOrDefault())) ?? [] : []),
            HighList = new List<double>(root != null ? root.Indicators?.Quote.SelectMany(x => x.High.Select(y => y.GetValueOrDefault())) ?? [] : []),
            VolumeList = new List<long>(root != null ? root.Indicators?.Quote.SelectMany(x => x.Volume.Select(y => y.GetValueOrDefault())) ?? [] : []),
            LowList = new List<double>(root != null ? root.Indicators?.Quote.SelectMany(x => x.Low.Select(y => y.GetValueOrDefault())) ?? [] : [])
        };

        if (result.DateList.Count == 0 || result.CloseList.Count == 0 || result.OpenList.Count == 0 || result.HighList.Count == 0 ||
            result.VolumeList.Count == 0 || result.LowList.Count == 0)
        {
            throw new InvalidOperationException("Requested Information Not Available On Yahoo Finance");
        }

        return new[] { result }.Cast<T>();
    }
}