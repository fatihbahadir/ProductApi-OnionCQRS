using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductApi.Application.DTOs;
using ProductApi.Application.Interfaces.AutoMapper;
using ProductApi.Application.Interfaces.UnitOfWorks;
using ProductApi.Domain.Entities;

namespace ProductApi.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(include: x => x.Include(b => b.Brand));

            var brand = mapper.Map<BrandDto, Brand>(new Brand());

            var map = mapper.Map<GetAllProductsQueryResponse, Product>(products);

            foreach (var item in map) 
                item.Price -= (item.Price * item.Discount/100);

            throw new Exception("hata mesajı");
        }
    }
}
