using Microsoft.AspNetCore.Mvc;
using TripleTriad.Api.Models;

namespace TripleTriad.Api.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class CardController : ControllerBase
{
    public CardController()
    {
    }

    [HttpGet]
    public List<CardDto> Get()
    {
        return new List<CardDto>();
    }
    
    [HttpPost]
    public IActionResult Post([FromBody]CreateCardRequest createCard)
    {
        // Save card
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