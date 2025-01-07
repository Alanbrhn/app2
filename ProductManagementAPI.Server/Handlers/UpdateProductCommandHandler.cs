using MediatR;
using ProductManagementAPI.Server.Commands;
using ProductManagementAPI.Server.Models;
using ProductManagementAPI.Server.Repositories;

namespace ProductManagementAPI.Server.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };

            return await _productRepository.UpdateAsync(product);
        }
    }
}
