namespace MarketMicroService;

public class ParseProtoEntityToModel
{
    public static MarketEntity ParseMarketModelToMarketProtoEntity(MarketM market)
    {
        MarketEntity marketEntity = new()
        {
            Id = market.Id,
            Name = market.Name,
            City = market.City,
            Address = market.Address,
            Description = market.Description,
            CreatedAt = market.CreatedAt.ToString(),
            UpdatedAt = market.UpdatedAt.ToString()
        };
        return marketEntity;
    }
}
