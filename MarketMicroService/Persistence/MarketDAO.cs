
using Microsoft.EntityFrameworkCore;

namespace MarketMicroService;

public class MarketDAO : IMarketDAO
{
    public MarketDAO()
    {
    }

    public async Task<MarketM> GetMarketByIdAsync(string id)
    {
        var dbContext = DBConnection.GetDbContext();
        MarketM marketTask = await Task.FromResult(dbContext.Markets.Find(id));
        return marketTask;
    }

    public Task<List<MarketM>> GetMarketsAsync(int page, int limit)
    {
        var dbContext = DBConnection.GetDbContext();
        var markets = dbContext.Markets.Skip(page * limit).Take(limit).ToArray();
        List<MarketM> marketMs = markets.ToList();
        return Task.FromResult(marketMs);
    }

    public async Task<List<MarketM>> GetMarketsByNameAndCityAsync(string name, string city, int page, int limit)
    {
        using var dbContext = DBConnection.GetDbContext();
        var markets = await dbContext.Markets
            .Where(market => EF.Functions.Like(market.Name, $"%{name}%") &&
                             EF.Functions.Like(market.City, $"%{city}%"))
            .Skip(page * limit)
            .Take(limit)
            .ToArrayAsync();
        List<MarketM> marketMs = markets.ToList();
        return marketMs;
    }
}
