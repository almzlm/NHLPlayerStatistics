using NHLPlayerStatistics.Interfaces;
using NHLPlayerStatistics.Models;
using System.Net;

namespace NHLPlayerStatistics.Services;

public class NHLApiService : INHLApiService
{

    private readonly IHttpClientFactory _httpClientFactory;

    public NHLApiService(IHttpClientFactory httpClientFactory) 
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<PlayerStats> GetPlayerStatistics(int playerId)
    {
        var httpRequestMessage = new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://statsapi.web.nhl.com/api/v1/people/{playerId}/stats?stats=yearByYear")
        };

        var httpResponse = await SendHttpRequest(httpRequestMessage);

        var result = httpResponse.Content.ReadAsStringAsync();

        //TODO : map result to PlayerStats
        return new PlayerStats();
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

