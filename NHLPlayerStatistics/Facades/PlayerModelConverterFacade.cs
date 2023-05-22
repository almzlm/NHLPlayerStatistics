using NHLPlayerStatistics.Models;
using System.Linq;

namespace NHLPlayerStatistics.Facades;

public static class PlayerModelConverterFacade
{
    static PlayerModelConverterFacade()
    {

    }

    public static PlayerStats Convert( NHLPlayerDTO nhlModel)
    {
        if (nhlModel == null)
            return new PlayerStats();

        var season = nhlModel.stats.SelectMany(field => field.splits
                                  .Where(splits => splits.league.name == "National Hockey League"))
                                  .ToList();

        var filteredStats = season.Select(szn => new Stats { SeasonYear = szn.season, Assists = szn.stat.assists, Goals = szn.stat.goals, Points = szn.stat.points});

        

        var playerStats = new PlayerStats()
        {
            Player = new Player()
            {
                Name = "Alexander Ovechkin", //TODO : Find way to get Player name <--> ID mapping
            },

            Statistics = new List<Stats>(filteredStats)
        };

        return playerStats;
    }

}

