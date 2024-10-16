using Microsoft.AspNetCore.Mvc;
using Moq;
using PokemonAPI.Controllers;
using PokemonAPI.Interfaces;

namespace UnitTests
{
    public class ControllerTests
    {
        private readonly Mock<IPokemonService> _mockService;
        private readonly PokemonController _controller;
        public ControllerTests()
        {
            _mockService = new Mock<IPokemonService>();
            _controller = new PokemonController(_mockService.Object);
        }
        [Fact]
        public async Task Pokemon_GetStrongestPokemonByName_ReturnsOkWithValidPokemon()
        {
            // Arrange
            string firstPokemon = "ditto";
            string secondPokemon = "clefairy";
            string expectedResponse = "ditto is stronger than clefairy!";
            _mockService.Setup(x => x.ComparePokemonStrengthAsync(firstPokemon, secondPokemon)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetStrongestPokemonByName(firstPokemon, secondPokemon) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResponse, result.Value);
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async Task Pokemon_GetStrongestPokemonByName_ReturnsBadRequestWithInvalidPokemon()
        {
            // Arrange
            string firstPokemon = "clafary";
            string secondPokemon = "ditto";
            _mockService.Setup(x => x.ComparePokemonStrengthAsync(firstPokemon, secondPokemon)).ThrowsAsync(new ArgumentException("Invalid Pokemon name."));

            // Act
            var result = await _controller.GetStrongestPokemonByName(firstPokemon, secondPokemon) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Invalid Pokemon name.", result.Value);
            Assert.Equal(400, result.StatusCode);
        }
    }
}