namespace PokemonAPI.Models
{
    public class PokemonStat
    {
        public StatDetail Stat { get; set; } = new StatDetail();
        public int Base_stat { get; set; }
    }
    public class StatDetail
    {
        public string Name { get; set; } = string.Empty;
    }
}
