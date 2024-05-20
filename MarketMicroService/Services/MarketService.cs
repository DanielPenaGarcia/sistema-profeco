using Grpc.Core;

namespace MarketMicroService;

public class MarketService: Market.MarketBase
{
    private IMarketDAO marketDAO = new MarketDAO();

    public MarketService()
    {
    }

    public override async Task<GetMarketByIdResponse> GetMarketById(GetMarketByIdRequest request, ServerCallContext context)
    {
        MarketM market = await marketDAO.GetMarketByIdAsync(request.Id);
        MarketEntity marketEntity = ParseProtoEntityToModel.ParseMarketModelToMarketProtoEntity(market);
        return new GetMarketByIdResponse
        {
            Market = marketEntity
        };
    }

    public override async Task<GetMarketsResponse> GetMarkets(GetMarketsRequest request, ServerCallContext context){
        PaginationConfig paginationConfig = request.Pagination;
        List<MarketM> marketMs = await marketDAO.GetMarketsAsync(paginationConfig.Page, paginationConfig.Limit);
        List<MarketEntity> marketEntities = [];
        foreach (MarketM market in marketMs)
        {
            MarketEntity marketEntity = ParseProtoEntityToModel.ParseMarketModelToMarketProtoEntity(market);
            marketEntities.Add(marketEntity);
        }
        return new GetMarketsResponse
        {
            Markets = { marketEntities }
        };
    }

    public override async Task<GetMarketsByNameAndCityResponse> GetMarketsByNameAndCity(GetMarketsByNameAndCityRequest request, ServerCallContext context){
        PaginationConfig paginationConfig = request.Pagination;
        List<MarketM> marketMs = await marketDAO.GetMarketsByNameAndCityAsync(request.Name, request.City, paginationConfig.Page, paginationConfig.Limit);
        List<MarketEntity> marketEntities = [];
        foreach (MarketM market in marketMs)
        {
            MarketEntity marketEntity = ParseProtoEntityToModel.ParseMarketModelToMarketProtoEntity(market);
            marketEntities.Add(marketEntity);
        }
        return new GetMarketsByNameAndCityResponse
        {
            Markets = { marketEntities }
        };
    }
}
