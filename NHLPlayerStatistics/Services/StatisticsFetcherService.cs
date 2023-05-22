using NHLPlayerStatistics.Interfaces;
using NHLPlayerStatistics.Models;

namespace NHLPlayerStatistics.Services;

public class StatisticsFetcherService : IStatisticsFetcherService
{

    #region dependency injection
    INHLApiService _nhlApiService;
    #endregion

    public StatisticsFetcherService(INHLApiService nhlApiService)
    {
        _nhlApiService = nhlApiService;
    }

    public async Task<PlayerStats> PlayerCareerStatistics(int playerId)
    {
        //Get the stats from client
        return await _nhlApiService.GetPlayerStatisticsAsync(playerId);
    }
}

