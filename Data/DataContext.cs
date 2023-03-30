using dotnet_rpg.Models;

namespace dotnet_rpg.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }
        public DbSet<Character> Character => Set<Character>();
        public DbSet<User> Users => Set<User>();
    }
}