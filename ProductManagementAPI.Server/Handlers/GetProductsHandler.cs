using MediatR;
using ProductManagementAPI.Server.Models;
using ProductManagementAPI.Server.Queries;
using ProductManagementAPI.Server.Repositories;

namespace ProductManagementAPI.Server.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<Product>>
    {
        private readonly IProductRepository _repository;

        public GetProductsHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetProductsAsync(request.Name, request.MinPrice, request.MaxPrice);
        }
    }
}
