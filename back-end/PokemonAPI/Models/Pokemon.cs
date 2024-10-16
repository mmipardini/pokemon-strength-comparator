namespace PokemonAPI.Models
{
    public class Pokemon
    {
        public string Name { get; set; } = string.Empty;
        public IList<PokemonStat> Stats { get; set; } = new List<PokemonStat>();
    }
}
