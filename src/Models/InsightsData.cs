namespace OoplesFinance.YahooFinanceAPI.Models;

public class Company
{
    [JsonProperty("innovativeness")]
    public double? Innovativeness { get; set; }

    [JsonProperty("hiring")]
    public double? Hiring { get; set; }

    [JsonProperty("sustainability")]
    public double? Sustainability { get; set; }

    [JsonProperty("insiderSentiments")]
    public double? InsiderSentiments { get; set; }

    [JsonProperty("earningsReports")]
    public double? EarningsReports { get; set; }

    [JsonProperty("dividends")]
    public double? Dividends { get; set; }
}

public class CompanySnapshot
{
    [JsonProperty("sectorInfo")]
    public string SectorInfo { get; set; } = string.Empty;

    [JsonProperty("company")]
    public Company Company { get; set; } = new();

    [JsonProperty("sector")]
    public Sector Sector { get; set; } = new();
}

public class Finance
{
    [JsonProperty("result")]
    public InsightsResult Result { get; set; } = new();

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class InstrumentInfo
{
    [JsonProperty("technicalEvents")]
    public TechnicalEvents TechnicalEvents { get; set; } = new();

    [JsonProperty("keyTechnicals")]
    public KeyTechnicals KeyTechnicals { get; set; } = new();

    [JsonProperty("valuation")]
    public Valuation Valuation { get; set; } = new();

    [JsonProperty("recommendation")]
    public Recommendation Recommendation { get; set; } = new();
}

public class KeyTechnicals
{
    [JsonProperty("provider")]
    public string Provider { get; set; } = string.Empty;

    [JsonProperty("support")]
    public double? Support { get; set; }

    [JsonProperty("resistance")]
    public double? Resistance { get; set; }

    [JsonProperty("stopLoss")]
    public double? StopLoss { get; set; }
}

public class Recommendation
{
    [JsonProperty("targetPrice")]
    public double? TargetPrice { get; set; }

    [JsonProperty("provider")]
    public string Provider { get; set; } = string.Empty;

    [JsonProperty("rating")]
    public string Rating { get; set; } = string.Empty;
}

public class Report
{
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty("title")]
    public string Title { get; set; } = string.Empty;

    [JsonProperty("provider")]
    public string Provider { get; set; } = string.Empty;

    [JsonProperty("publishedOn")]
    public DateTime? PublishedOn { get; set; } = new();

    [JsonProperty("summary")]
    public string Summary { get; set; } = string.Empty;
}

public class InsightsResult
{
    [JsonProperty("symbol")]
    public string Symbol { get; set; } = string.Empty;

    [JsonProperty("instrumentInfo")]
    public InstrumentInfo InstrumentInfo { get; set; } = new();

    [JsonProperty("reports")]
    public List<Report> Reports { get; set; } = [];

    [JsonProperty("companySnapshot")]
    public CompanySnapshot CompanySnapshot { get; set; } = new();
}

public class InsightsData
{
    [JsonProperty("finance")]
    public Finance Finance { get; set; } = new();
}

public class Sector
{
    [JsonProperty("innovativeness")]
    public double? Innovativeness { get; set; }

    [JsonProperty("hiring")]
    public double? Hiring { get; set; }

    [JsonProperty("sustainability")]
    public double? Sustainability { get; set; }

    [JsonProperty("insiderSentiments")]
    public double? InsiderSentiments { get; set; }

    [JsonProperty("earningsReports")]
    public double? EarningsReports { get; set; }

    [JsonProperty("dividends")]
    public double? Dividends { get; set; }
}

public class TechnicalEvents
{
    [JsonProperty("provider")]
    public string Provider { get; set; } = string.Empty;

    [JsonProperty("shortTerm")]
    public string ShortTerm { get; set; } = string.Empty;

    [JsonProperty("midTerm")]
    public string MidTerm { get; set; } = string.Empty;

    [JsonProperty("longTerm")]
    public string LongTerm { get; set; } = string.Empty;
}

public class Valuation
{
    [JsonProperty("color")]
    public double? Color { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; } = string.Empty;

    [JsonProperty("discount")]
    public string Discount { get; set; } = string.Empty;

    [JsonProperty("relativeValue")]
    public string RelativeValue { get; set; } = string.Empty;

    [JsonProperty("provider")]
    public string Provider { get; set; } = string.Empty;
}