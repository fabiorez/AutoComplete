using System.Data.Entity;

namespace autocomplete.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}