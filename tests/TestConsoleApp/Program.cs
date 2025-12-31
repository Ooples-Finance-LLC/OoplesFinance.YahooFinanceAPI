using OoplesFinance.YahooFinanceAPI;
using OoplesFinance.YahooFinanceAPI.Enums;

try
{
    var startDate = DateTime.Now.AddYears(-10);
    var symbol = "GOOG";
    var fundSymbol = "VSMPX";
    var symbols = new string[] { symbol, "MSFT", "NFLX", "TSLA", "YHOO", "SPY", "A", "AA", "GOOG", "F", "UBER", "LYFT" };

    var yahooClient = new YahooClient();

    var historicalDataList = await yahooClient.GetHistoricalDataAsync(symbol, DataFrequency.Daily, startDate);
    var chartInfoList = await yahooClient.GetChartInfoAsync("GOOG", TimeRange._1Year, TimeInterval._1Day);
    var data = await yahooClient.GetChartInfoAsync("CAPE", TimeRange._1Day, TimeInterval._1Day);
    Console.WriteLine();
    //var capitalGainList = await yahooClient.GetCapitalGainDataAsync(symbol, DataFrequency.Monthly, startDate);
    //var dividendList = await yahooClient.GetDividendDataAsync(symbol, DataFrequency.Weekly, startDate);
    //var stockSplitList = await yahooClient.GetStockSplitDataAsync(symbol, DataFrequency.Monthly, startDate);
    //var topTrendingList = await yahooClient.GetTopTrendingStocksAsync(Country.UnitedStates, 10);
    //var recommendedList = await yahooClient.GetStockRecommendationsAsync(symbol);
    //var keyStatsList = await yahooClient.GetKeyStatisticsAsync(symbol);
    //var summaryDetailsList = await yahooClient.GetSummaryDetailsAsync(symbol);
    //var insiderHoldersList = await yahooClient.GetInsiderHoldersAsync(symbol);
    //var insiderTransactionsList = await yahooClient.GetInsiderTransactionsAsync(symbol);
    //var financialDataList = await yahooClient.GetFinancialDataAsync(symbol);
    //var institutionOwnershipList = await yahooClient.GetInstitutionOwnershipAsync(symbol);
    //var fundOwnershipList = await yahooClient.GetFundOwnershipAsync(symbol);
    //var majorDirectHoldersList = await yahooClient.GetMajorDirectHoldersAsync(symbol);
    //var secFilingsList = await yahooClient.GetSecFilingsAsync(symbol);
    //var insightsList = await yahooClient.GetInsightsAsync(symbol);
    //var majorHoldersBreakdownList = await yahooClient.GetMajorHoldersBreakdownAsync(symbol);
    //var upgradeDowngradeHistoryList = await yahooClient.GetUpgradeDowngradeHistoryAsync(symbol);
    //var esgScoresList = await yahooClient.GetEsgScoresAsync(symbol);
    //var recommendationTrendList = await yahooClient.GetRecommendationTrendAsync(symbol);
    //var indexTrendList = await yahooClient.GetIndexTrendAsync(symbol);
    //var sectorTrendList = await yahooClient.GetSectorTrendAsync(symbol);
    //var earningsTrendList = await yahooClient.GetEarningsTrendAsync(symbol);
    //var assetProfileList = await yahooClient.GetAssetProfileAsync(symbol);
    //var fundProfileList = await yahooClient.GetFundProfileAsync(fundSymbol);
    //var calendarEventsList = await yahooClient.GetCalendarEventsAsync(symbol);
    //var earningsList = await yahooClient.GetEarningsAsync(symbol);
    //var balanceSheetHistoryList = await yahooClient.GetBalanceSheetHistoryAsync(symbol);
    //var cashflowStatementHistoryList = await yahooClient.GetCashflowStatementHistoryAsync(symbol);
    //var incomeStatementHistoryList = await yahooClient.GetIncomeStatementHistoryAsync(symbol);
    //var earningsHistoryList = await yahooClient.GetEarningsHistoryAsync(symbol);
    //var quoteTypeList = await yahooClient.GetQuoteTypeAsync(symbol);
    //var priceList = await yahooClient.GetPriceInfoAsync(symbol);
    //var netSharePurchaseActivityList = await yahooClient.GetNetSharePurchaseActivityAsync(symbol);
    //var incomeStatementHistoryQuarterlyList = await yahooClient.GetIncomeStatementHistoryQuarterlyAsync(symbol);
    //var cashflowStatementHistoryQuarterlyList = await yahooClient.GetCashflowStatementHistoryQuarterlyAsync(symbol);
    //var balanceSheetHistoryQuarterlyList = await yahooClient.GetBalanceSheetHistoryQuarterlyAsync(symbol);
    //var sparkChartInfoList = await yahooClient.GetSparkChartInfoAsync(symbols, TimeRange._1Month, TimeInterval._1Day);
    //var realTimeQuoteList = await yahooClient.GetRealTimeQuotesAsync(symbols);
    //var marketSummaryList = await yahooClient.GetMarketSummaryAsync();
    //var autoCompleteList = await yahooClient.GetAutoCompleteInfoAsync("Google");
    //var topGainersList = await yahooClient.GetTopGainersAsync(10);
    //var topLosersList = await yahooClient.GetTopLosersAsync(10);
    //var smallCapGainersList = await yahooClient.GetSmallCapGainersAsync(10);
    //var mostActiveStocksList = await yahooClient.GetMostActiveStocksAsync(10);
    //var aggressiveSmallCapsList = await yahooClient.GetAggressiveSmallCapStocksAsync(10);
    //var conservativeForeignFundsList = await yahooClient.GetConservativeForeignFundsAsync(10);
    //var growthTechStocksList = await yahooClient.GetGrowthTechnologyStocksAsync(10);
    //var highYieldBondsList = await yahooClient.GetHighYieldBondsAsync(10);
    //var mostShortedStocksList = await yahooClient.GetMostShortedStocksAsync(10);
    //var portfolioAnchorsList = await yahooClient.GetPortfolioAnchorsAsync(10);
    //var solidLargeGrowthFundsList = await yahooClient.GetSolidLargeGrowthFundsAsync(10);
    //var solidMidcapGrowthFundsList = await yahooClient.GetSolidMidcapGrowthFundsAsync(10);
    //var topMutualFundsList = await yahooClient.GetTopMutualFundsAsync(10);
    //var undervaluedGrowthStocksList = await yahooClient.GetUndervaluedGrowthStocksAsync(10);
    //var undervaluedLargeCapsList = await yahooClient.GetUndervaluedLargeCapStocksAsync(10);
    //var undervaluedWideMoatStocksList = await yahooClient.GetUndervaluedWideMoatStocksAsync(10);
    //var morningstarFiveStarStocksList = await yahooClient.GetMorningstarFiveStarStocksAsync(10);
    //var strongUndervaluedStocksList = await yahooClient.GetStrongUndervaluedStocksAsync(10);
    //var analystStrongBuyStocksList = await yahooClient.GetAnalystStrongBuyStocksAsync(10);
    //var latestAnalystUpgradedStocksList = await yahooClient.GetLatestAnalystUpgradedStocksAsync(10);
    //var mostInstitutionallyBoughtLargeCapStocksList = await yahooClient.GetMostInstitutionallyBoughtLargeCapStocksAsync(10);
    //var mostInstitutionallyHeldLargeCapStocksList = await yahooClient.GetMostInstitutionallyHeldLargeCapStocksAsync(10);
    //var mostInstitutionallySoldLargeCapStocksList = await yahooClient.GetMostInstitutionallySoldLargeCapStocksAsync(10);
    //var stocksWithMostInstitutionalBuyersList = await yahooClient.GetStocksWithMostInstitutionalBuyersAsync(10);
    //var stocksWithMostInstitutionalSellersList = await yahooClient.GetStocksWithMostInstitutionalSellersAsync(10);
    //var stocksMostBoughtByHedgeFundsList = await yahooClient.GetStocksMostBoughtByHedgeFundsAsync(10);
    //var stocksMostBoughtByPensionFundsList = await yahooClient.GetStocksMostBoughtByPensionFundsAsync(10);
    //var stocksMostBoughtByPrivateEquityList = await yahooClient.GetStocksMostBoughtByPrivateEquityAsync(10);
    //var stocksMostBoughtBySovereignWealthFundsList = await yahooClient.GetStocksMostBoughtBySovereignWealthFundsAsync(10);
    //var topStocksOwnedByCathieWoodList = await yahooClient.GetTopStocksOwnedByCathieWoodAsync(10);
    //var topStocksOwnedByGoldmanSachsList = await yahooClient.GetTopStocksOwnedByGoldmanSachsAsync(10);
    //var topStocksOwnedByWarrenBuffetList = await yahooClient.GetTopStocksOwnedByWarrenBuffetAsync(10);
    //var topStocksOwnedByRayDalioList = await yahooClient.GetTopStocksOwnedByRayDalioAsync(10);
    //var topBearishStocksRightNowList = await yahooClient.GetTopBearishStocksRightNowAsync(10);
    //var topBullishStocksRightNowList = await yahooClient.GetTopBullishStocksRightNowAsync(10);
    //var topUpsideBreakoutStocksList = await yahooClient.GetTopUpsideBreakoutStocksAsync(10);

    var r = await yahooClient.GetRealTimeQuotesAsync("TSLA");
    Console.WriteLine($"{r?.Symbol} {r?.RegularMarketPrice} {r?.Bid} {r?.BidSize} {r?.Ask} {r?.AskSize}");

    Console.WriteLine();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.StackTrace);
}

Console.WriteLine();