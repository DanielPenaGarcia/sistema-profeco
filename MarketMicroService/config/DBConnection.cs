using MarketMicroService;
using Microsoft.EntityFrameworkCore;

public static class DBConnection
{
    private static readonly string connectionString = "server=localhost;user=root;password=1234;database=marketmicroservice";
    private static readonly MySqlServerVersion serverVersion = new(new Version(8, 0, 21));

    private static readonly ServiceCollection serviceCollection = new();

    static DBConnection()
    {
        serviceCollection.AddDbContext<MarketMicroServiceConext>(options =>
            options.UseMySql(connectionString, serverVersion)
        );
    }

    public static MarketMicroServiceConext GetDbContext()
    {
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var dbContext = serviceProvider.GetRequiredService<MarketMicroServiceConext>();

        return dbContext;
    }
}
