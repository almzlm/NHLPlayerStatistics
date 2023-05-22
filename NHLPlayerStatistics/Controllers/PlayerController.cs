using Microsoft.AspNetCore.Mvc;
using NHLPlayerStatistics.Interfaces;
using NHLPlayerStatistics.Models;

namespace NHLPlayerStatistics.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : Controller
{

    #region dependency injection
    IStatisticsFetcherService _statsFetcher;
    #endregion

    public PlayerController(IStatisticsFetcherService statsFetcher) 
    {
        _statsFetcher = statsFetcher;
    }   

    [HttpGet("{playerId}")]
    public async Task<JsonResult> GetPlayerStatistics(int playerId)
    {
        return Json(await _statsFetcher.PlayerCareerStatistics(playerId));

    }
}
