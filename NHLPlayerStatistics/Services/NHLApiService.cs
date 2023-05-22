using NHLPlayerStatistics.Facades;
using NHLPlayerStatistics.Interfaces;
using NHLPlayerStatistics.Models;
using System.Net;
using System.Text.Json;

namespace NHLPlayerStatistics.Services;

public class NHLApiService : INHLApiService
{

    private readonly IHttpClientFactory _httpClientFactory;

    public NHLApiService(IHttpClientFactory httpClientFactory) 
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<PlayerStats> GetPlayerStatisticsAsync(int playerId)
    {
        var httpRequestMessage = new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://statsapi.web.nhl.com/api/v1/people/{playerId}/stats?stats=yearByYear") //TODO : Put this in config
        };

        var httpResponse = await SendHttpRequest(httpRequestMessage);

        var result = await httpResponse.Content.ReadAsStringAsync();

        try
        {
            var playerDTO = JsonSerializer.Deserialize<NHLPlayerDTO>(result);

            var parsedPlayerStats = PlayerModelConverterFacade.Convert(playerDTO);
            return parsedPlayerStats ?? new PlayerStats();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception : {ex.Message}");
            return new PlayerStats();
        }

    }

    private async Task<HttpResponseMessage> SendHttpRequest(HttpRequestMessage httpRequest)
    {
        var httpClient = _httpClientFactory.CreateClient();
        var httpResponse = await httpClient.SendAsync(httpRequest);

        if (httpResponse.IsSuccessStatusCode && httpResponse != null)
        {
            return httpResponse;
        }
        else
        {
            return new HttpResponseMessage();
        }
    } 
}

