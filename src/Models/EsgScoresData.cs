namespace OoplesFinance.YahooFinanceAPI.Models;

public class EnvironmentPercentile
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class EnvironmentScore
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class EsgScores
{
    [JsonProperty("maxAge")]
    public int? MaxAge { get; set; }

    [JsonProperty("totalEsg")]
    public TotalEsg TotalEsg { get; set; } = new();

    [JsonProperty("environmentScore")]
    public EnvironmentScore EnvironmentScore { get; set; } = new();

    [JsonProperty("socialScore")]
    public SocialScore SocialScore { get; set; } = new();

    [JsonProperty("governanceScore")]
    public GovernanceScore GovernanceScore { get; set; } = new();

    [JsonProperty("ratingYear")]
    public int? RatingYear { get; set; }

    [JsonProperty("ratingMonth")]
    public int? RatingMonth { get; set; }

    [JsonProperty("highestControversy")]
    public double? HighestControversy { get; set; }

    [JsonProperty("esgPerformance")]
    public string EsgPerformance { get; set; } = string.Empty;

    [JsonProperty("peerCount")]
    public int? PeerCount { get; set; }

    [JsonProperty("peerGroup")]
    public string PeerGroup { get; set; } = string.Empty;

    [JsonProperty("relatedControversy")]
    public List<string> RelatedControversy { get; set; } = [];

    [JsonProperty("peerEsgScorePerformance")]
    public PeerEsgScorePerformance PeerEsgScorePerformance { get; set; } = new();

    [JsonProperty("peerGovernancePerformance")]
    public PeerGovernancePerformance PeerGovernancePerformance { get; set; } = new();

    [JsonProperty("peerSocialPerformance")]
    public PeerSocialPerformance PeerSocialPerformance { get; set; } = new();

    [JsonProperty("peerEnvironmentPerformance")]
    public PeerEnvironmentPerformance PeerEnvironmentPerformance { get; set; } = new();

    [JsonProperty("peerHighestControversyPerformance")]
    public PeerHighestControversyPerformance PeerHighestControversyPerformance { get; set; } = new();

    [JsonProperty("percentile")]
    public Percentile Percentile { get; set; } = new();

    [JsonProperty("environmentPercentile")]
    public EnvironmentPercentile EnvironmentPercentile { get; set; } = new();

    [JsonProperty("socialPercentile")]
    public SocialPercentile SocialPercentile { get; set; } = new();

    [JsonProperty("governancePercentile")]
    public GovernancePercentile GovernancePercentile { get; set; } = new();

    [JsonProperty("adult")]
    public bool? Adult { get; set; }

    [JsonProperty("alcoholic")]
    public bool? Alcoholic { get; set; }

    [JsonProperty("animalTesting")]
    public bool? AnimalTesting { get; set; }

    [JsonProperty("catholic")]
    public bool? Catholic { get; set; }

    [JsonProperty("controversialWeapons")]
    public bool? ControversialWeapons { get; set; }

    [JsonProperty("smallArms")]
    public bool? SmallArms { get; set; }

    [JsonProperty("furLeather")]
    public bool? FurLeather { get; set; }

    [JsonProperty("gambling")]
    public bool? Gambling { get; set; }

    [JsonProperty("gmo")]
    public bool? Gmo { get; set; }

    [JsonProperty("militaryContract")]
    public bool? MilitaryContract { get; set; }

    [JsonProperty("nuclear")]
    public bool? Nuclear { get; set; }

    [JsonProperty("pesticides")]
    public bool? Pesticides { get; set; }

    [JsonProperty("palmOil")]
    public bool? PalmOil { get; set; }

    [JsonProperty("coal")]
    public bool? Coal { get; set; }

    [JsonProperty("tobacco")]
    public bool? Tobacco { get; set; }
}

public class GovernancePercentile
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class GovernanceScore
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class PeerEnvironmentPerformance
{
    [JsonProperty("min")]
    public double? Min { get; set; }

    [JsonProperty("avg")]
    public double? Avg { get; set; }

    [JsonProperty("max")]
    public double? Max { get; set; }
}

public class PeerEsgScorePerformance
{
    [JsonProperty("min")]
    public double? Min { get; set; }

    [JsonProperty("avg")]
    public double? Avg { get; set; }

    [JsonProperty("max")]
    public double? Max { get; set; }
}

public class PeerGovernancePerformance
{
    [JsonProperty("min")]
    public double? Min { get; set; }

    [JsonProperty("avg")]
    public double? Avg { get; set; }

    [JsonProperty("max")]
    public double? Max { get; set; }
}

public class PeerHighestControversyPerformance
{
    [JsonProperty("min")]
    public double? Min { get; set; }

    [JsonProperty("avg")]
    public double? Avg { get; set; }

    [JsonProperty("max")]
    public double? Max { get; set; }
}

public class PeerSocialPerformance
{
    [JsonProperty("min")]
    public double? Min { get; set; }

    [JsonProperty("avg")]
    public double? Avg { get; set; }

    [JsonProperty("max")]
    public double? Max { get; set; }
}

public class Percentile
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class EsgScoresQuoteSummary
{
    [JsonProperty("result")]
    public List<EsgScoresResult> Results { get; set; } = [];

    [JsonProperty("error")]
    public object Error { get; set; } = new();
}

public class EsgScoresResult
{
    [JsonProperty("esgScores")]
    public EsgScores EsgScores { get; set; } = new();
}

public class EsgScoresData
{
    [JsonProperty("quoteSummary")]
    public EsgScoresQuoteSummary QuoteSummary { get; set; } = new();
}

public class SocialPercentile
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class SocialScore
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}

public class TotalEsg
{
    [JsonProperty("raw")]
    public double? Raw { get; set; }

    [JsonProperty("fmt")]
    public string Fmt { get; set; } = string.Empty;
}