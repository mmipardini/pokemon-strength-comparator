using Moq.Protected;
using Moq;
using Newtonsoft.Json;
using PokemonAPI.Models;
using PokemonAPI.Services;
using System.Net;

namespace UnitTests
{
    public class ServiceTests
    {
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;
        private readonly PokemonService _pokemonService;
        private readonly HttpClient _httpClient;
        public ServiceTests()
        {
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_mockHttpMessageHandler.Object);
            _pokemonService = new PokemonService(_httpClient);
        }
        [Fact]
        public async Task Pokemon_GetPokemonDataAsync_ReturnsDataWhenValidName()
        {
            // Arrange
            string pokemonName = "pikachu";
            string jsonResponse = "{\"name\": \"pikachu\", \"stats\": [{\"stat\": {\"name\": \"hp\"}, \"base_stat\": 35}]}";
            _mockHttpMessageHandler.Protected().Setup<Task<HttpResponseMessage>>(
                    "SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(jsonResponse) });

            // Act
            var result = await _pokemonService.GetPokemonDataAsync(pokemonName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("pikachu", result.Name);
            Assert.Equal(35, result.Stats.First(x => x.Stat.Name == "hp").Base_stat);
        }
        [Fact]
        public async Task Pokemon_ComparePokemonStrengthAsync_ReturnsCorrectComparison()
        {
            // Arrange
            var pikachuData = new Pokemon { Name = "pikachu", Stats = new List<PokemonStat> { new() { Stat = new StatDetail { Name = "hp" }, Base_stat = 35 } } };
            var charizardData = new Pokemon { Name = "charizard", Stats = new List<PokemonStat> { new() { Stat = new StatDetail { Name = "hp" }, Base_stat = 78 } } };

            _mockHttpMessageHandler.Protected().Setup<Task<HttpResponseMessage>>(
                    "SendAsync", ItExpr.Is<HttpRequestMessage>(req => req.RequestUri != null && req.RequestUri.ToString().Contains("pikachu")), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(JsonConvert.SerializeObject(pikachuData)) });

            _mockHttpMessageHandler.Protected().Setup<Task<HttpResponseMessage>>(
                "SendAsync", ItExpr.Is<HttpRequestMessage>(req => req.RequestUri != null && req.RequestUri.ToString().Contains("charizard")), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(JsonConvert.SerializeObject(charizardData)) });

            // Act
            var result = await _pokemonService.ComparePokemonStrengthAsync("pikachu", "charizard");

            // Assert
            Assert.Equal("charizard is stronger than pikachu!", result);
        }
    }
}
