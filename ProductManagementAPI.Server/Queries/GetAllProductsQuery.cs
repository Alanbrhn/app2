using MediatR;
using ProductManagementAPI.Server.Models;

namespace ProductManagementAPI.Server.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>> { }
}
