using Microsoft.AspNetCore.Mvc;
using TripleTriad.Api.Models;

namespace TripleTriad.Api.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class PlayerController : ControllerBase
{
    public PlayerController()
    {
    }

    [HttpGet("/{playerName}")]
    public List<PlayerDto> Get(string playerName)
    {
        return new List<PlayerDto>();
    }
    
    [HttpPost]
    public IActionResult Post([FromBody]CreateCardRequest createCard)
    {
        // Save card
        return Ok();
    }
    
    [HttpPut("/{playerId}")]
    public IActionResult Put(int cardId, [FromBody]CreateCardRequest updateCardRequest)
    {
        // Update card
        return Ok();
    }
    
    [HttpDelete("/{playerId}")]
    public IActionResult Delete(int cardId)
    {
        // Delete card
        return Ok();
    }
}