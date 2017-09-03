using System.Data.Entity;

namespace WebApplication3.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}