using Microsoft.EntityFrameworkCore;

namespace Andrew_SuperheroAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<CharacterDTO> characters { get; set; }
    }
}
