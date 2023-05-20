namespace NHLPlayerStatistics.Models;

public class PlayerStats
{
    public Player Player { get; set; } = new Player();
    public List<Stats>? Statistics { get; set; }

}
