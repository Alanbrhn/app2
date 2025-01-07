using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Server.Data;
using ProductManagementAPI.Server.Models;
using ProductManagementAPI.Server.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagementAPI.Server.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<Product>>
    {
        private readonly ApplicationDbContext _context;

        public GetProductsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(request.Name))
            {
                query = query.Where(p => p.Name.Contains(request.Name));
            }

            if (request.MinPrice.HasValue)
            {
                query = query.Where(p => p.Price >= request.MinPrice.Value);
            }

            if (request.MaxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= request.MaxPrice.Value);
            }

            return await query.ToListAsync(cancellationToken);
        }
    }
}
