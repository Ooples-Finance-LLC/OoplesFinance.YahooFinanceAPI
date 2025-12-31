using Moq;
using Moq.Contrib.HttpClient;
using System.Net;

namespace OoplesFinance.YahooFinanceAPI.Tests.Unit;

public sealed class YahooClientTests : IDisposable
{
    private readonly YahooClient _sut;
    private readonly Mock<HttpMessageHandler> _mockHandler;
    private const string BadSymbol = "OOPLES";
    private const string GoodSymbol = "MSFT";
    private const string GoodFundSymbol = "VTSAX";
    private const int ValidCount = 10;
    private const int InvalidCount = -1;
    private readonly DateTime _startDate;
    private readonly IEnumerable<string> _emptySymbols;
    private readonly IEnumerable<string> _tooManySymbols;
    private readonly IEnumerable<string> _goodSymbols;

    public YahooClientTests()
    {
        _mockHandler = new Mock<HttpMessageHandler>();
        OoplesFinance.YahooFinanceAPI.Helpers.CrumbHelper.handler = _mockHandler.Object;
        SetupMockResponses();

        _sut = new YahooClient();
        _startDate = DateTime.Now.AddMonths(-1);
        _emptySymbols = [];
        _tooManySymbols = Enumerable.Repeat(GoodSymbol, 255);
        _goodSymbols = Enumerable.Repeat(GoodSymbol, 20);
    }

    private void SetupMockResponses()
    {
        // Crumb
        _mockHandler.SetupRequest(HttpMethod.Get, "https://query1.finance.yahoo.com/v1/test/getcrumb")
            .ReturnsResponse(HttpStatusCode.OK, "test_crumb");

        // Chart / Historical (Fixed braces)
        var chartJson = @"{""chart"":{""result"":[{""timestamp"":[1600000000],""indicators"":{""quote"":[{""close"":[100.0],""open"":[100.0],""high"":[100.0],""low"":[100.0],""volume"":[1000]}],""adjclose"":[{""adjclose"":[100.0]}]},""events"":{""dividends"":{""1600000000"":{""amount"":0.5,""date"":1600000000}},""splits"":{""1600000000"":{""numerator"":2,""denominator"":1,""splitRatio"":""2:1"",""date"":1600000000}}}}]}}";
        
        _mockHandler.SetupRequest(HttpMethod.Get, r => r.RequestUri.ToString().Contains($"/v8/finance/chart/{GoodSymbol}"))
            .ReturnsResponse(HttpStatusCode.OK, chartJson);

        // Screener / Trending
        var screenerJson = @"{""finance"":{""result"":[{""quotes"":[{""symbol"":""MSFT"",""language"":""en"",""region"":""US"",""typeDisp"":""Equity"",""quoteType"":""EQUITY""}]}]}}";
        _mockHandler.SetupRequest(HttpMethod.Get, r => r.RequestUri.ToString().Contains("/finance/screener"))
            .ReturnsResponse(HttpStatusCode.OK, screenerJson);
        _mockHandler.SetupRequest(HttpMethod.Get, r => r.RequestUri.ToString().Contains("/finance/trending"))
            .ReturnsResponse(HttpStatusCode.OK, screenerJson);

        // QuoteSummary (Stats)
        var quoteSummaryJson = @"{
            ""quoteSummary"": {
                ""result"": [{
                    ""defaultKeyStatistics"": { ""enterpriseValue"": { ""raw"": 100 } },
                    ""summaryDetail"": { ""maxAge"": 1 },
                    ""financialData"": { ""currentPrice"": { ""raw"": 100 } },
                    ""insiderHolders"": { ""holders"": [{""name"":""Holder""}] },
                    ""insiderTransactions"": { ""transactions"": [{""filerName"":""Filer""}] },
                    ""institutionOwnership"": { ""ownershipList"": [{""organization"":""Org""}] },
                    ""fundOwnership"": { ""ownershipList"": [{""organization"":""Fund""}] },
                    ""majorDirectHolders"": { ""holders"": [{""holder"":""Major""}] },
                    ""secFilings"": { ""filings"": [{""date"":""2020-01-01""}] },
                    ""majorHoldersBreakdown"": { ""insidersPercentHeld"": { ""raw"": 0.1 } },
                    ""esgScores"": { ""totalEsg"": { ""raw"": 10 } },
                    ""recommendationTrend"": { ""trend"": [{""period"":""0m""}] },
                    ""indexTrend"": { ""symbol"": ""SP500"", ""peRatio"": { ""raw"": 20 } },
                    ""sectorTrend"": { ""symbol"": ""Sector"" },
                    ""earningsTrend"": { ""trend"": [{""period"":""0q""}] },
                    ""assetProfile"": { ""address1"": ""1 Way"" },
                    ""fundProfile"": { ""family"": ""FundFamily"" },
                    ""calendarEvents"": { ""earnings"": { ""earningsDate"": [{""raw"":1600000000}] } },
                    ""earnings"": { ""financialsChart"": { ""yearly"": [{""date"":2020}], ""quarterly"": [{""date"":""3Q""}] } },
                    ""balanceSheetHistory"": { ""balanceSheetStatements"": [{""cash"":{""raw"":100}}] },
                    ""cashflowStatementHistory"": { ""cashflowStatements"": [{""netIncome"":{""raw"":100}}] },
                    ""incomeStatementHistory"": { ""incomeStatementHistory"": [{""totalRevenue"":{""raw"":100}}] },
                    ""earningsHistory"": { ""history"": [{""epsActual"":{""raw"":1}}] },
                    ""quoteType"": { ""symbol"": ""MSFT"" },
                    ""price"": { ""regularMarketPrice"": { ""raw"": 100 } },
                    ""netSharePurchaseActivity"": { ""buyInfoCount"": { ""raw"": 10 } },
                    ""incomeStatementHistoryQuarterly"": { ""incomeStatementHistory"": [{""totalRevenue"":{""raw"":100}}] },
                    ""cashflowStatementHistoryQuarterly"": { ""cashflowStatements"": [{""netIncome"":{""raw"":100}}] },
                    ""balanceSheetHistoryQuarterly"": { ""balanceSheetStatements"": [{""cash"":{""raw"":100}}] },
                    ""upgradeDowngradeHistory"": { ""history"": [{""firm"":""Firm"",""action"":""Up""}] }
                }]
            }
        }";
        // Match GoodSymbol and GoodFundSymbol explicitly
        _mockHandler.SetupRequest(HttpMethod.Get, r => r.RequestUri.ToString().Contains($"/quoteSummary/{GoodSymbol}"))
            .ReturnsResponse(HttpStatusCode.OK, quoteSummaryJson);
        _mockHandler.SetupRequest(HttpMethod.Get, r => r.RequestUri.ToString().Contains($"/quoteSummary/{GoodFundSymbol}"))
            .ReturnsResponse(HttpStatusCode.OK, quoteSummaryJson);

        // RealTimeQuote
        var realTimeJson = @"{""quoteResponse"":{""result"":[{""symbol"":""MSFT"",""regularMarketPrice"":100.0}]}}";
        _mockHandler.SetupRequest(HttpMethod.Get, r => r.RequestUri.ToString().Contains("/v7/finance/quote") && r.RequestUri.ToString().Contains(GoodSymbol))
            .ReturnsResponse(HttpStatusCode.OK, realTimeJson);

        // Market Summary
        var marketSummaryJson = @"{""marketSummaryResponse"":{""result"":[{""symbol"":""^GSPC"",""regularMarketPrice"":{""raw"":100}}]}}";
        _mockHandler.SetupRequest(HttpMethod.Get, r => r.RequestUri.ToString().Contains("/marketSummary"))
            .ReturnsResponse(HttpStatusCode.OK, marketSummaryJson);

        // AutoComplete
        var autoCompleteJson = @"{""resultSet"":{""Result"":[{""symbol"":""MSFT""}]}}";
        _mockHandler.SetupRequest(HttpMethod.Get, r => r.RequestUri.ToString().Contains("/autocomplete") && !r.RequestUri.ToString().Contains("string.Empty"))
            .ReturnsResponse(HttpStatusCode.OK, autoCompleteJson);

        // SparkChart
        var sparkJson = @"{""spark"":{""result"":[{""symbol"":""MSFT"",""response"":[{""timestamp"":[1600000000],""indicators"":{""quote"":[{""close"":[100.0]}]}}]}]}}";
        _mockHandler.SetupRequest(HttpMethod.Get, r => r.RequestUri.ToString().Contains("/finance/spark") && r.RequestUri.ToString().Contains(GoodSymbol))
            .ReturnsResponse(HttpStatusCode.OK, sparkJson);

        // Insights (Fixed shortTerm and added reports)
        var insightsJson = @"{""finance"":{""result"":{""instrumentInfo"":{""technicalEvents"":{""shortTerm"":""Bearish""}},""reports"":[{""id"":""1"",""title"":""Report""}]}}}";
        _mockHandler.SetupRequest(HttpMethod.Get, r => r.RequestUri.ToString().Contains($"/insights?symbol={GoodSymbol}"))
            .ReturnsResponse(HttpStatusCode.OK, insightsJson);
        
        // Recommendations
        var recommendJson = @"{""finance"":{""result"":[{""symbol"":""MSFT"",""recommendedSymbols"":[{""symbol"":""AAPL""}]}]}}";
        _mockHandler.SetupRequest(HttpMethod.Get, r => r.RequestUri.ToString().Contains($"/recommendationsbysymbol/{GoodSymbol}"))
            .ReturnsResponse(HttpStatusCode.OK, recommendJson);

        // Bad Symbol Handling - Return 404 which usually triggers empty/null parsing or exception in Helpers
        _mockHandler.SetupRequest(HttpMethod.Get, r => r.RequestUri.ToString().Contains(BadSymbol))
            .ReturnsResponse(HttpStatusCode.NotFound, "{}");
    }

    public void Dispose()
    {
        OoplesFinance.YahooFinanceAPI.Helpers.CrumbHelper.Reset();
    }

    [Fact]
    public async Task GetHistoricalData_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetHistoricalDataAsync(BadSymbol, DataFrequency.Daily, _startDate);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetHistoricalData_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetHistoricalDataAsync(GoodSymbol, DataFrequency.Daily, _startDate);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetStockSplitData_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetStockSplitDataAsync(BadSymbol, DataFrequency.Daily, _startDate);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetStockSplitData_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetStockSplitDataAsync(GoodSymbol, DataFrequency.Daily, _startDate);

        // Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetDividendData_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetDividendDataAsync(BadSymbol, DataFrequency.Daily, _startDate);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetDividendData_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetDividendDataAsync(GoodSymbol, DataFrequency.Daily, _startDate);

        // Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetCapitalGainData_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetCapitalGainDataAsync(BadSymbol, DataFrequency.Daily, _startDate);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetCapitalGainData_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetCapitalGainDataAsync(string.Empty, DataFrequency.Daily, _startDate);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetCapitalGainData_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetCapitalGainDataAsync(GoodSymbol, DataFrequency.Daily, _startDate);

        // Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetHistoricalData_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetHistoricalDataAsync(string.Empty, DataFrequency.Daily, _startDate);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetDividendData_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetDividendDataAsync(string.Empty, DataFrequency.Daily, _startDate);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetStockSplitData_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetStockSplitDataAsync(string.Empty, DataFrequency.Daily, _startDate);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetTopTrendingStocks_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetTopTrendingStocksAsync(Country.UnitedStates, InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetTopTrendingStocks_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetTopTrendingStocksAsync(Country.UnitedStates, ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetStockRecommendations_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetStockRecommendationsAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetStockRecommendations_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetStockRecommendationsAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetStockRecommendations_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetStockRecommendationsAsync(GoodSymbol);

        // Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetKeyStatistics_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetKeyStatisticsAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetKeyStatistics_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetKeyStatisticsAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetKeyStatistics_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetKeyStatisticsAsync(GoodSymbol);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetSummaryDetails_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetSummaryDetailsAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetSummaryDetails_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetSummaryDetailsAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetSummaryDetails_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetSummaryDetailsAsync(GoodSymbol);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetInsiderHolders_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetInsiderHoldersAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetInsiderHolders_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetInsiderHoldersAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetInsiderHolders_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetInsiderHoldersAsync(GoodSymbol);

        // Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetInsiderTransactions_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetInsiderTransactionsAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetInsiderTransactions_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetInsiderTransactionsAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetInsiderTransactions_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetInsiderTransactionsAsync(GoodSymbol);

        // Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetFinancialData_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetFinancialDataAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetFinancialData_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetFinancialDataAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetFinancialData_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetFinancialDataAsync(GoodSymbol);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetInstitutionOwnership_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetInstitutionOwnershipAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetInstitutionOwnership_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetInstitutionOwnershipAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetInstitutionOwnership_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetInstitutionOwnershipAsync(GoodSymbol);

        // Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetFundOwnership_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetFundOwnershipAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetFundOwnership_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetFundOwnershipAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetFundOwnership_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetFundOwnershipAsync(GoodSymbol);

        // Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetMajorDirectHolders_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetMajorDirectHoldersAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetMajorDirectHolders_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetMajorDirectHoldersAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetMajorDirectHolders_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetMajorDirectHoldersAsync(GoodSymbol);

        // Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetSecFilings_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetSecFilingsAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetSecFilings_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetSecFilingsAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetSecFilings_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetSecFilingsAsync(GoodSymbol);

        // Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetInsights_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetInsightsAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetInsights_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetInsightsAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetInsights_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetInsightsAsync(GoodSymbol);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetMajorHoldersBreakdown_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetMajorHoldersBreakdownAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetMajorHoldersBreakdown_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetMajorHoldersBreakdownAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetMajorHoldersBreakdown_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetMajorHoldersBreakdownAsync(GoodSymbol);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetUpgradeDowngradeHistory_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetUpgradeDowngradeHistoryAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetUpgradeDowngradeHistory_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetUpgradeDowngradeHistoryAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetUpgradeDowngradeHistory_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetUpgradeDowngradeHistoryAsync(GoodSymbol);

        // Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetEsgScores_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetEsgScoresAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetEsgScores_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetEsgScoresAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetEsgScores_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetEsgScoresAsync(GoodSymbol);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetRecommendationTrend_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetRecommendationTrendAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetRecommendationTrend_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetRecommendationTrendAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetRecommendationTrend_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetRecommendationTrendAsync(GoodSymbol);

        // Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetIndexTrend_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetIndexTrendAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetIndexTrend_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetIndexTrendAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetIndexTrend_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetIndexTrendAsync(GoodSymbol);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetSectorTrend_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetSectorTrendAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetSectorTrend_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetSectorTrendAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetSectorTrend_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetSectorTrendAsync(GoodSymbol);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetEarningsTrend_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetEarningsTrendAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetEarningsTrend_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetEarningsTrendAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetEarningsTrend_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetEarningsTrendAsync(GoodSymbol);

        // Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetAssetProfile_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetAssetProfileAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetAssetProfile_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetAssetProfileAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetAssetProfile_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetAssetProfileAsync(GoodSymbol);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetFundProfile_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetFundProfileAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetFundProfile_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetFundProfileAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetFundProfile_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetFundProfileAsync(GoodFundSymbol);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetCalendarEvents_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetCalendarEventsAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetCalendarEvents_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetCalendarEventsAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetCalendarEvents_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetCalendarEventsAsync(GoodSymbol);

        // Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetEarnings_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetEarningsAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetEarnings_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetEarningsAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetEarnings_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetEarningsAsync(GoodSymbol);

        // Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetBalanceSheetHistory_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetBalanceSheetHistoryAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetBalanceSheetHistory_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetBalanceSheetHistoryAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetBalanceSheetHistory_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetBalanceSheetHistoryAsync(GoodSymbol);

        // Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetCashflowStatementHistory_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetCashflowStatementHistoryAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetCashflowStatementHistory_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetCashflowStatementHistoryAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetCashflowStatementHistory_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetCashflowStatementHistoryAsync(GoodSymbol);

        // Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetIncomeStatementHistory_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetIncomeStatementHistoryAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetIncomeStatementHistory_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetIncomeStatementHistoryAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetIncomeStatementHistory_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetIncomeStatementHistoryAsync(GoodSymbol);

        // Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetEarningsHistory_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetEarningsHistoryAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetEarningsHistory_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetEarningsHistoryAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetEarningsHistory_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetEarningsHistoryAsync(GoodSymbol);

        // Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetQuoteType_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetQuoteTypeAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetQuoteType_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetQuoteTypeAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetQuoteType_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetQuoteTypeAsync(GoodSymbol);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetPriceInfo_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetPriceInfoAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetPriceInfo_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetPriceInfoAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetPriceInfo_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetPriceInfoAsync(GoodSymbol);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetNetSharePurchaseActivity_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetNetSharePurchaseActivityAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetNetSharePurchaseActivity_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetNetSharePurchaseActivityAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetNetSharePurchaseActivity_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetNetSharePurchaseActivityAsync(GoodSymbol);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetIncomeStatementHistoryQuarterly_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetIncomeStatementHistoryQuarterlyAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetIncomeStatementHistoryQuarterly_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetIncomeStatementHistoryQuarterlyAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetIncomeStatementHistoryQuarterly_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetIncomeStatementHistoryQuarterlyAsync(GoodSymbol);

        // Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetCashflowStatementHistoryQuarterly_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetCashflowStatementHistoryQuarterlyAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetCashflowStatementHistoryQuarterly_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetCashflowStatementHistoryQuarterlyAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetCashflowStatementHistoryQuarterly_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetCashflowStatementHistoryQuarterlyAsync(GoodSymbol);

        // Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetBalanceSheetHistoryQuarterly_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetBalanceSheetHistoryQuarterlyAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetBalanceSheetHistoryQuarterly_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetBalanceSheetHistoryQuarterlyAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetBalanceSheetHistoryQuarterly_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetBalanceSheetHistoryQuarterlyAsync(GoodSymbol);

        // Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetChartInfo_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetChartInfoAsync(BadSymbol, TimeRange._1Day, TimeInterval._1Minute);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetChartInfo_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetChartInfoAsync(string.Empty, TimeRange._1Day, TimeInterval._1Minute);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetChartInfo_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetChartInfoAsync(GoodSymbol, TimeRange._1Day, TimeInterval._1Minute);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetSparkChartInfo_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetSparkChartInfoAsync(BadSymbol, TimeRange._1Day, TimeInterval._1Minute);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetSparkChartInfo_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetSparkChartInfoAsync(string.Empty, TimeRange._1Day, TimeInterval._1Minute);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetSparkChartInfo_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetSparkChartInfoAsync(GoodSymbol, TimeRange._1Day, TimeInterval._1Minute);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetSparkChartInfo_ThrowsException_WhenEmptySymbolListIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetSparkChartInfoAsync(_emptySymbols, TimeRange._1Day, TimeInterval._1Minute);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbols Parameter Must Contain At Least One Symbol");
    }

    [Fact]
    public async Task GetSparkChartInfo_ThrowsException_WhenTooManySymbolsAreUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetSparkChartInfoAsync(_tooManySymbols, TimeRange._1Day, TimeInterval._1Minute);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbols Parameter Can't Have More Than 250 Symbols");
    }

    [Fact]
    public async Task GetSparkChartInfo_ReturnsData_WhenValidSymbolsListIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetSparkChartInfoAsync(_goodSymbols, TimeRange._1Day, TimeInterval._1Minute);

        // Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetRealTimeQuotes_ThrowsException_WhenNoSymbolIsFound()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetRealTimeQuotesAsync(BadSymbol);

        // Assert
        await result.Should().ThrowAsync<InvalidOperationException>().WithMessage("Requested Information Not Available On Yahoo Finance");
    }

    [Fact]
    public async Task GetRealTimeQuotes_ThrowsException_WhenEmptySymbolIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetRealTimeQuotesAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbol Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetRealTimeQuotes_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetRealTimeQuotesAsync(GoodSymbol);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetRealTimeQuotes_ThrowsException_WhenEmptySymbolListIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetRealTimeQuotesAsync(_emptySymbols);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbols Parameter Must Contain At Least One Symbol");
    }

    [Fact]
    public async Task GetRealTimeQuotes_ThrowsException_WhenTooManySymbolsAreUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetRealTimeQuotesAsync(_tooManySymbols);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Symbols Parameter Can't Have More Than 250 Symbols");
    }

    [Fact]
    public async Task GetRealTimeQuotes_ReturnsData_WhenValidSymbolsListIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetRealTimeQuotesAsync(_goodSymbols);

        // Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetMarketSummary_ReturnsInfo_WhenValidResultsAreFound()
    {
        // Arrange

        // Act
        var result = await _sut.GetMarketSummaryAsync();

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetAutoCompleteInfo_ThrowsException_WhenEmptySearchTermIsUsed()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetAutoCompleteInfoAsync(string.Empty);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("The Search Term Parameter Can't Be Empty Or Null");
    }

    [Fact]
    public async Task GetAutoCompleteInfo_ReturnsData_WhenValidSymbolIsUsed()
    {
        // Arrange

        // Act
        var result = await _sut.GetAutoCompleteInfoAsync(GoodSymbol);

        // Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetTopGainers_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetTopGainersAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetTopGainers_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetTopGainersAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetTopLosers_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetTopLosersAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetTopLosers_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetTopLosersAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetSmallCapGainers_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetSmallCapGainersAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetSmallCapGainers_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetSmallCapGainersAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetMostActiveStocks_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetMostActiveStocksAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetMostActiveStocks_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetMostActiveStocksAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetAggressiveSmallCapStocks_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetAggressiveSmallCapStocksAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetAggressiveSmallCapStocks_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetAggressiveSmallCapStocksAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetConservativeForeignFunds_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetConservativeForeignFundsAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetConservativeForeignFunds_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetConservativeForeignFundsAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetGrowthTechnologyStocks_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetGrowthTechnologyStocksAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetGrowthTechnologyStocks_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetGrowthTechnologyStocksAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetHighYieldBonds_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetHighYieldBondsAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetHighYieldBonds_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetHighYieldBondsAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetMostShortedStocks_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetMostShortedStocksAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetMostShortedStocks_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetMostShortedStocksAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetPortfolioAnchors_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetPortfolioAnchorsAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetPortfolioAnchors_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetPortfolioAnchorsAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetSolidLargeGrowthFunds_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetSolidLargeGrowthFundsAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetSolidLargeGrowthFunds_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetSolidLargeGrowthFundsAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetSolidMidcapGrowthFunds_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetSolidMidcapGrowthFundsAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetSolidMidcapGrowthFunds_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetSolidMidcapGrowthFundsAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetTopMutualFunds_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetTopMutualFundsAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetTopMutualFunds_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetTopMutualFundsAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetUndervaluedGrowthStocks_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetUndervaluedGrowthStocksAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetUndervaluedGrowthStocks_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetUndervaluedGrowthStocksAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetUndervaluedLargeCapStocks_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetUndervaluedLargeCapStocksAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetUndervaluedLargeCapStocks_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetUndervaluedLargeCapStocksAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetUndervaluedWideMoatStocks_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetUndervaluedWideMoatStocksAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetUndervaluedWideMoatStocks_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetUndervaluedWideMoatStocksAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetMorningstarFiveStarStocks_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetMorningstarFiveStarStocksAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetMorningstarFiveStarStocks_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetMorningstarFiveStarStocksAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetStrongUndervaluedStocks_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetStrongUndervaluedStocksAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetStrongUndervaluedStocks_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetStrongUndervaluedStocksAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetAnalystStrongBuyStocks_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetAnalystStrongBuyStocksAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetAnalystStrongBuyStocks_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetAnalystStrongBuyStocksAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetLatestAnalystUpgradedStocks_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetLatestAnalystUpgradedStocksAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetLatestAnalystUpgradedStocks_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetLatestAnalystUpgradedStocksAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetMostInstitutionallyBoughtLargeCapStocks_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetMostInstitutionallyBoughtLargeCapStocksAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetMostInstitutionallyBoughtLargeCapStocks_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetMostInstitutionallyBoughtLargeCapStocksAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetMostInstitutionallyHeldLargeCapStocks_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetMostInstitutionallyHeldLargeCapStocksAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetMostInstitutionallyHeldLargeCapStocks_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetMostInstitutionallyHeldLargeCapStocksAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetMostInstitutionallySoldLargeCapStocks_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetMostInstitutionallySoldLargeCapStocksAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetMostInstitutionallySoldLargeCapStocks_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetMostInstitutionallySoldLargeCapStocksAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetStocksWithMostInstitutionalBuyers_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetStocksWithMostInstitutionalBuyersAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetStocksWithMostInstitutionalBuyers_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetStocksWithMostInstitutionalBuyersAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetStocksWithMostInstitutionalSellers_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetStocksWithMostInstitutionalSellersAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetStocksWithMostInstitutionalSellers_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetStocksWithMostInstitutionalSellersAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetStocksMostBoughtByHedgeFunds_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetStocksMostBoughtByHedgeFundsAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetStocksMostBoughtByHedgeFunds_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetStocksMostBoughtByHedgeFundsAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetStocksMostBoughtByPensionFunds_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetStocksMostBoughtByPensionFundsAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetStocksMostBoughtByPensionFunds_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetStocksMostBoughtByPensionFundsAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetStocksMostBoughtByPrivateEquity_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetStocksMostBoughtByPrivateEquityAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetStocksMostBoughtByPrivateEquity_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetStocksMostBoughtByPrivateEquityAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetStocksMostBoughtBySovereignWealthFunds_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetStocksMostBoughtBySovereignWealthFundsAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetStocksMostBoughtBySovereignWealthFunds_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetStocksMostBoughtBySovereignWealthFundsAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetTopStocksOwnedByCathieWood_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetTopStocksOwnedByCathieWoodAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetTopStocksOwnedByCathieWood_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetTopStocksOwnedByCathieWoodAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetTopStocksOwnedByGoldmanSachs_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetTopStocksOwnedByGoldmanSachsAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetTopStocksOwnedByGoldmanSachs_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetTopStocksOwnedByGoldmanSachsAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetTopStocksOwnedByRayDalio_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetTopStocksOwnedByRayDalioAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetTopStocksOwnedByRayDalio_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetTopStocksOwnedByRayDalioAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetTopStocksOwnedByWarrenBuffet_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetTopStocksOwnedByWarrenBuffetAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetTopStocksOwnedByWarrenBuffet_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetTopStocksOwnedByWarrenBuffetAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetTopBearishStocksRightNow_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetTopBearishStocksRightNowAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetTopBearishStocksRightNow_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetTopBearishStocksRightNowAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetTopBullishStocksRightNow_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetTopBullishStocksRightNowAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetTopBullishStocksRightNow_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetTopBullishStocksRightNowAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetTopUpsideBreakoutStocks_ThrowsException_WhenCountIsInvalid()
    {
        // Arrange

        // Act
        var result = async () => await _sut.GetTopUpsideBreakoutStocksAsync(InvalidCount);

        // Assert
        await result.Should().ThrowAsync<ArgumentException>().WithMessage("Count Must Be At Least 1 To Return Any Data");
    }

    [Fact]
    public async Task GetTopUpsideBreakoutStocks_ReturnsData_WhenCountIsValid()
    {
        // Arrange

        // Act
        var result = await _sut.GetTopUpsideBreakoutStocksAsync(ValidCount);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task CreateCrumbHelpInstance_ReturnsValidCrumb()
    {
        // Arrange

        // Act
        var crumbHelperInstance = await Helpers.CrumbHelper.GetInstance();

        // Assert
        crumbHelperInstance.Crumb.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task CreateCrumbHelpInstance_ThrowsException_WhenFetchCrumbFailed()
    {
        // Arrange
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.SetupRequest(HttpMethod.Get, "https://query1.finance.yahoo.com/v1/test/getcrumb")
            .ReturnsResponse(HttpStatusCode.NotFound, "");
        OoplesFinance.YahooFinanceAPI.Helpers.CrumbHelper.handler = mockHandler.Object;

        // Act
        var ex = await Record.ExceptionAsync(()=>Helpers.CrumbHelper.GetInstance(true));
        
        // Assert
        ex.Should().NotBeNull();
    }
}