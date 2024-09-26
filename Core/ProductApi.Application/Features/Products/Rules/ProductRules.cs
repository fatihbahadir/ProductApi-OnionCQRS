using ProductApi.Application.Bases;
using ProductApi.Application.Features.Products.Exceptions;
using ProductApi.Application.Features.Products.Rules;
using ProductApi.Domain.Entities;

namespace ProductApi.Application.Features.Products.Rules
{
    public class ProductRules : BaseRules
    {
        public Task ProductTitleMustNotBeSame(IList<Product> products , string requestTitle)
        {
            if (products.Any(x => x.Title == requestTitle)) throw new ProductTitleMustNotBeSameException();
            return Task.CompletedTask;
        }
    }
}
