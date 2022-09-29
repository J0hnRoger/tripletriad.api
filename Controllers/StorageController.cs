using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace TripleTriad.Api.Controllers;


[ApiController]
[Route("api/storage")]
public class StorageController : ControllerBase
{
    private readonly BlobContainerClient _blobContainerClient;

    public StorageController(IConfiguration config)
    {
        _blobContainerClient = new BlobContainerClient(config["Storage:ConnectionString"], "gamingimages");
    }
   
    [HttpPost]
    public async Task<ActionResult<string>> Post()
    {
        try
        {
            var blob = _blobContainerClient.GetBlobClient($"tripletriad/cards/{DateTime.Now.ToString("yyyddhhmmss")}.jpg");
            await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
            using (var fileStream = Request.BodyReader.AsStream())
            {
                await blob.UploadAsync(fileStream);
            }

            string url = blob.Uri.ToString();
            return Ok(url);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Error while uploading: {ex}");
        }
    }
}