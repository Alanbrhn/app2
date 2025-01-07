using MediatR;
using ProductManagementAPI.Server.Models;

namespace ProductManagementAPI.Server.Queries
{
    public class GetProductByIdQuery : IRequest<Product?>
    {
        public int Id { get; set; }
    }
}
