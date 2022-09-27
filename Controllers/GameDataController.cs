using System.Text.Json.Serialization;
using Azure;
using Azure.Data.Tables;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TripleTriad.Api.Models;

namespace TripleTriad.Api.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class GameDataController : ControllerBase
{
    private readonly TableClient _tableClient;

    public GameDataController(IConfiguration config)
    {
        string url = config["AzureTable:AccountUrl"];
        _tableClient = new TableClient(new Uri(url),
            config["AzureTable:TableName"],
            new TableSharedKeyCredential(config["AzureTable:AccountName"],
                config["AzureTable:AccountKey"]));
    }
     
    [HttpGet("{gameName}/{playerId}")]
    public IActionResult Get([FromRoute] string gameName, [FromRoute]string playerId)
    {
        var result = _tableClient.GetEntity<GamingDataEntity>(gameName, playerId);
        return Ok(result.Value.ScriptableObjects);
    }
    
    [HttpPost("{gameName}/{playerId}")]
    public IActionResult Post(string gameName, string playerId, [FromBody]Dictionary<int, string> dictionary)
    {
        var serializedData = JsonConvert.SerializeObject(dictionary);
        var entity = new GamingDataEntity(gameName, playerId, serializedData);
        _tableClient.UpsertEntity(entity);
        return Ok();
    }
}