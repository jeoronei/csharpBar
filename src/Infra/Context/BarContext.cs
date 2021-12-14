using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class BarContext : DbContext
    {
        public BarContext(DbContextOptions options) : base(options) { }

        public DbSet<Bar> Bar { get; set; }
    }
}
