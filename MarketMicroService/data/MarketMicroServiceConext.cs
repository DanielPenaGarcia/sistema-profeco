using Microsoft.EntityFrameworkCore;

namespace MarketMicroService
{
    public class MarketMicroServiceConext : DbContext
    {
        public MarketMicroServiceConext(DbContextOptions<MarketMicroServiceConext> options) : base(options) {}

        public DbSet<MarketM> Markets { get; set; }
    }
}
