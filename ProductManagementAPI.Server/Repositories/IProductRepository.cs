using ProductManagementAPI.Server.Models;

namespace ProductManagementAPI.Server.Repositories
{
    public interface IProductRepository
    {
        Task<int> AddAsync(Product product); 
        Task<IEnumerable<Product>> GetAllAsync(); 
        Task<Product> GetByIdAsync(int id);
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
        Task<List<Product>> GetProductsAsync(string name, decimal? minPrice, decimal? maxPrice);
    }
}
