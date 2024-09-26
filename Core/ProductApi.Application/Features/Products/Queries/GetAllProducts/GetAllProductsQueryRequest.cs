using MediatR;

namespace ProductApi.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<IList<GetAllProductsQueryResponse>>
    {
    }
}
