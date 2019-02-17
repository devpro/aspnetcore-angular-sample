using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Devpro.AspNetCoreAngularSample.WebApp.IntegrationTests.ApiResources
{
    [Trait("Environment", "Localhost")]
    public class SampleDataResourceTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public SampleDataResourceTest(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetSampleData_ReturnsHttpOkResponse()
        {
            // Arrange & Act
            var response = await _client.GetAsync("/api/SampleData/WeatherForecasts");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            // Assert
            stringResponse.Should().NotBeNullOrEmpty();
        }
    }
}
