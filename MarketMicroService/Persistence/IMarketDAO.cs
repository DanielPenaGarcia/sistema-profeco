namespace MarketMicroService;

public interface IMarketDAO
{
    Task<MarketM> GetMarketByIdAsync(string id);
    Task<List<MarketM>> GetMarketsAsync(int page, int limit);
    Task<List<MarketM>> GetMarketsByNameAndCityAsync(string name, string city, int page, int limit);
}
