using Newtonsoft.Json;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;

namespace PokemonAPI.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _httpClient;
        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Pokemon> GetPokemonDataAsync(string pokemonName)
        {
            string url = $"https://pokeapi.co/api/v2/pokemon/{pokemonName.ToLower()}";
            var response = await _httpClient.GetStringAsync(url);
            var serializedResponse = JsonConvert.DeserializeObject<Pokemon>(response);

            if(serializedResponse == null)
                throw new InvalidOperationException($"Failed to deserialize data for {pokemonName}.");
            else
                return serializedResponse;
        }
        public async Task<string> ComparePokemonStrengthAsync(string firstPokemon, string secondPokemon)
        {
            var firstPokemonData = await GetPokemonDataAsync(firstPokemon);
            var secondPokemonData = await GetPokemonDataAsync(secondPokemon);

            var firstPokemonHP = GetPokemonHP(firstPokemonData);
            var secondPokemonHP = GetPokemonHP(secondPokemonData);

            if (firstPokemonHP > secondPokemonHP)
                return $"{firstPokemonData.Name} is stronger than {secondPokemonData.Name}!";
            else if (secondPokemonHP > firstPokemonHP)
                return $"{secondPokemonData.Name} is stronger than {firstPokemonData.Name}!";
            else
                return $"{firstPokemonData.Name} and {secondPokemonData.Name} have equal strength!";
        }
        private static int GetPokemonHP(Pokemon pokemon)
        {
            var hpStat = pokemon.Stats.FirstOrDefault(x => x.Stat.Name == "hp");
            if (hpStat == null)
                throw new InvalidOperationException($"Pokemon {pokemon.Name} does not have an 'hp' stat.");

            return hpStat.Base_stat;
        }
    }
}
