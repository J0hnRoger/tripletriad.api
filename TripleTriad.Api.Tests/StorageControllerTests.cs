using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace TripleTriad.Api.Tests;

public class StorageControllerTests
{
    private readonly HttpClient _client;

    public StorageControllerTests()
    {
        var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>
        { });

         _client = application.CreateClient(); 
    }
    
    [Fact]
    public async Task Storage_Upload()
    {
    }
}