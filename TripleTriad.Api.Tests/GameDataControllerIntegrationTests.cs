using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace TripleTriad.Api.Tests;

public class GameDataControllerIntegrationTests 
{
    private readonly HttpClient _client;

    public GameDataControllerIntegrationTests()
    {
        var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>
        { });

         _client = application.CreateClient();
    }
    
    [Fact]
    public async Task GameDataController_SaveDatas()
    {
        string gamename = "integrationtests";
        string playerName = "INTEGRATION";
        string data = "[{ id: 1, '{ <serializedData> }'}]";
        string json = JsonConvert.SerializeObject(data);
        var payload = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync($"/api/gamedata/{gamename}/{playerName}", payload);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GameDataController_LoadDatas()
    {
        string gamename = "integrationtests";
        string playerName = "INTEGRATION";
        var response = await _client.GetAsync($"/api/gamedata/{gamename}/{playerName}");
        string responseContent = await response.Content.ReadAsStringAsync();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}