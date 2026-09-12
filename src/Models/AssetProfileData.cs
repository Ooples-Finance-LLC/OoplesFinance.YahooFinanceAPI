namespace OoplesFinance.YahooFinanceAPI.Models;

public class AssetProfile
{
    [JsonProperty("address1")]
    public string Address1 { get; set; } = string.Empty;

    [JsonProperty("city")]
    public string City { get; set; } = string.Empty;

    [JsonProperty("state")]
    public string State { get; set; } = string.Empty;

    [JsonProperty("zip")]
    public string Zip { get; set; } = string.Empty;

    [JsonProperty("country")]
    public string Country { get; set; } = string.Empty;

    [JsonProperty("phone")]
    public string Phone { get; set; } = string.Empty;

    [JsonProperty("website")]
    public string Website { get; set; } = string.Empty;

    [JsonProperty("industry")]
    public string Industry { get; set; } = string.Empty;

    [JsonProperty("sector")]
    public string Sector { get; set; } = string.Empty;

    [JsonProperty("longBusinessSummary")]
    public string LongBusinessSummary { get; set; } = string.Empty;

    [JsonProperty("fullTimeEmployees")]
    public int? FullTimeEmployees { get; set; }

    [JsonProperty("companyOfficers")]
    public List<CompanyOfficer> CompanyOfficers { get; set; } = [];

    [JsonProperty("auditRisk")]
    public int? AuditRisk { get; set; }

    [JsonProperty("boardRisk")]
    public int? BoardRisk { get; set; }

    [JsonProperty("compensationRisk")]
    public int? CompensationRisk { get; set; }

    [JsonProperty("shareHolderRightsRisk")]
    public int? ShareHolderRightsRisk { get; set; }

    [JsonProperty("overallRisk")]
    public int? OverallRisk { get; set; }

    [JsonProperty("governanceEpochDate")]
    public int? GovernanceEpochDate { get; set; }

    [JsonProperty("compensationAsOfEpochDate")]
    public int? CompensationAsOfEpochDate { get; set; }

    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }
}

public class CompanyOfficer
{
    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("age")]
    public int? Age { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; } = string.Empty;

    [JsonProperty("yearBorn")]
    public int? YearBorn { get; set; }

    [JsonProperty("fiscalYear")]
    public int? FiscalYear { get; set; }

    [JsonProperty("totalPay")]
    public TotalPay TotalPay { get; set; } = new();

    [JsonProperty("exercisedValue")]
    public ExercisedValue ExercisedValue { get; set; } = new();

    [JsonProperty("unexercisedValue")]
    public UnexercisedValue UnexercisedValue { get; set; } = new();
}

public class ExercisedValue
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public object Fmt { get; set; } = new();

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class AssetProfileQuoteSummary
{
    [JsonProperty("result")]
    public List<AssetProfileResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class AssetProfileResult
{
    [JsonProperty("assetProfile")]
    public AssetProfile AssetProfile { get; set; } = new();
}

public class AssetProfileData
{
    [JsonProperty("quoteSummary")]
    public AssetProfileQuoteSummary QuoteSummary { get; set; } = new();
}

public class TotalPay
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}

public class UnexercisedValue
{
    [JsonProperty("raw")]
    public int? Raw { get; set; }

    [JsonProperty("fmt")]
    public object Fmt { get; set; } = new();

    [JsonProperty("longFmt")]
    public string LongFmt { get; set; } = string.Empty;
}