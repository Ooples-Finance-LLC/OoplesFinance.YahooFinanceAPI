namespace OoplesFinance.YahooFinanceAPI.Models;

public class InstitutionOwnership
{
    [JsonProperty("ownershipList")]
    public List<OwnershipList> OwnershipList { get; set; } = [];

    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }
}

public class OwnershipList
{
    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }

    [JsonProperty("reportDate")]
    public ReportDate ReportDate { get; set; } = new();

    [JsonProperty("organization")]
    public string Organization { get; set; } = string.Empty;

    [JsonProperty("pctHeld")]
    public PctHeld PctHeld { get; set; } = new();

    [JsonProperty("position")]
    public Position Position { get; set; } = new();

    [JsonProperty("value")]
    public Value Value { get; set; } = new();
}

public class PctHeld
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class Position
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class InstitutionOwnershipQuoteSummary
{
    [JsonProperty("result")]
    public List<InstitutionOwnershipResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class ReportDate
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class InstitutionOwnershipResult
{
    [JsonProperty("institutionOwnership")]
    public InstitutionOwnership InstitutionOwnership { get; set; } = new();
}

public class InstitutionOwnershipData
{
    [JsonProperty("quoteSummary")]
    public InstitutionOwnershipQuoteSummary QuoteSummary { get; set; } = new();
}
