using Microsoft.AspNetCore.Mvc;
using NHLPlayerStatistics.Interfaces;
using NHLPlayerStatistics.Models;

namespace NHLPlayerStatistics.Controllers
{
    public class PlayerController : Controller
    {

        #region dependency injection
        IStatisticsFetcherService _statsFetcher;
        #endregion

        public PlayerController(IStatisticsFetcherService statsFetcher) 
        {
            _statsFetcher = statsFetcher;
        }   

        [Route("Player/{playerId}")]
        public JsonResult Get(int playerId)
        {
            var result = _statsFetcher.PlayerCareerStatistics(playerId);
            return Json(result);
        }
    }
}
