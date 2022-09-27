using System.Collections.Generic;
using System.IO.Pipes;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using TripleTriad.Api.Models;
using Xunit;

namespace TripleTriad.Api.Tests;

public class CardControllerTests
{
    private readonly HttpClient _client;

    public CardControllerTests()
    {
        var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>
        { });

         _client = application.CreateClient();
    }
    
    [Fact]
    public async Task GetAllCards()
    {
        string partitionKey = "tripletriadcards";
        CreateCardRequest newCard = new CreateCardRequest()
        { 
            Name = "API Test Card",
            ImageUrl = "https://jrrstorage.blob.core.windows.net/gamingimages/tripletriad/cards/Minion.png",
            
            Top = 1,
            Right = 2,
            Bottom = 3,
            Left = 4
        };
        
        string json = JsonConvert.SerializeObject(newCard);
        var payload = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync($"/api/cards", payload);
        response.StatusCode.Should().Be(HttpStatusCode.OK); 
        
        var getResponse = await _client.GetAsync($"/api/cards");
        getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        var result = await getResponse.Content.ReadFromJsonAsync<List<CardDto>>();
        result.Should().HaveCount(1);
    }
    
    [Fact]
    public async Task PostCard()
    {
        string partitionKey = "tripletriadcards";
        CardDto newCard = new CardDto()
        { 
            Id = 0,
            Name = "API Test Card",
            ImageUrl = "https://jrrstorage.blob.core.windows.net/gamingimages/tripletriad/cards/Minion.png",
            
            Top = 1,
            Right = 2,
            Bottom = 3,
            Left = 4
        };
        
        string json = JsonConvert.SerializeObject(newCard);
        var payload = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.GetAsync($"/api/cards");
        response.StatusCode.Should().Be(HttpStatusCode.OK); 
    }
}