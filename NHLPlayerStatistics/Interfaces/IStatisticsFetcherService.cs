using NHLPlayerStatistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLPlayerStatistics.Interfaces;

public interface IStatisticsFetcherService
{
    Task<PlayerStats> PlayerCareerStatistics(int playerId);
}

