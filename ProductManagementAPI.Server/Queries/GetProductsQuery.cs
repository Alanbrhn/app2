using MediatR;
using ProductManagementAPI.Server.Models;
using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.Server.Queries
{
    public class GetProductsQuery : IRequest<List<Product>>
    {
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "MinPrice must be greater than 0.")]
        public decimal? MinPrice { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "MaxPrice must be greater than 0.")]
        public decimal? MaxPrice { get; set; }

        public GetProductsQuery(string name = null, decimal? minPrice = null, decimal? maxPrice = null)
        {
            Name = name;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
        }
    }
}
