using NHLPlayerStatistics.Models;

namespace NHLPlayerStatistics.Interfaces;
public interface INHLApiService
{
    public Task<PlayerStats> GetPlayerStatisticsAsync(int playerId);
}

