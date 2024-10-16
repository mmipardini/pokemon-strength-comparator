using PokemonAPI.Models;

namespace PokemonAPI.Interfaces
{
    public interface IPokemonService
    {
        Task<Pokemon> GetPokemonDataAsync(string pokemonName);
        Task<string> ComparePokemonStrengthAsync(string firstPokemon, string secondPokemon);
    }
}
