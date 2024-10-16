using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Interfaces;

namespace PokemonAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _service;
        public PokemonController(IPokemonService service)
        {
            _service = service;
        }
        [HttpGet("strongest")]
        public async Task<IActionResult> GetStrongestPokemonByName([FromQuery] string firstPokemon, string secondPokemon)
        {
            try
            {
                var pokemon = await _service.ComparePokemonStrengthAsync(firstPokemon, secondPokemon);

                return Ok(pokemon);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
