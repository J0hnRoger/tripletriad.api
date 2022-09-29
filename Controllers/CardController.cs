using Azure.Data.Tables;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TripleTriad.Api.Models;

namespace TripleTriad.Api.Controllers;

[ApiController]
[Route("api/cards")]
public class CardController : ControllerBase
{
    private readonly TableClient _tableClient;

    public CardController(IConfiguration config)
    {
        string url = config["AzureTable:AccountUrl"];
        _tableClient = new TableClient(new Uri(url),
            config["AzureTable:TableName"],
            new TableSharedKeyCredential(config["AzureTable:AccountName"],
                config["AzureTable:AccountKey"]));
    }

    [HttpGet]
    public ActionResult<List<CardDto>> Get()
    {
        var result = _tableClient.Query<CardEntity>(filter: $"PartitionKey eq 'tripletriad:cards'");
        
        return Ok(result);
    }
    
    [HttpPost]
    public IActionResult Post([FromBody]CreateCardRequest newCard)
    {
        // Upload Image 
        var newEntity = new CardEntity("tripletriad:cards", Guid.NewGuid().ToString(), newCard.Name,newCard.Top, 
            newCard.Right,newCard.Bottom, newCard.Left, newCard.ImageUrl);
         _tableClient.UpsertEntity(newEntity);
        return Ok();
    }
    
    [HttpPut("{cardId}")]
    public IActionResult Put(int cardId, [FromBody]CreateCardRequest updateCardRequest)
    {
        // Save card
        return Ok();
    }
    
    [HttpDelete("{cardId}")]
    public IActionResult Delete(int cardId)
    {
        // Delete card
        return Ok();
    }
}