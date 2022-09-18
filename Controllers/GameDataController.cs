using Microsoft.AspNetCore.Mvc;
using TripleTriad.Api.Models;

namespace TripleTriad.Api.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class GameDataController : ControllerBase
{
    public GameDataController()
    {
    }
     
    [HttpGet("{gameName}/{playerId}")]
    public IActionResult Get([FromRoute] string gameName, [FromRoute]string playerId)
    {
        // Save card
        return Ok("[{ id: 1, '{}'}, {id: 2, '{}'}]");
    }
    
    [HttpPost]
    public IActionResult Post([FromBody]string serializedData)
    {
        // Save card
        return Ok();
    }
    
}