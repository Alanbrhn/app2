using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Server.Data;
using ProductManagementAPI.Server.Models;
using Serilog;

namespace ProductManagementAPI.Server.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly Serilog.ILogger _logger; 

        public ProductRepository(ApplicationDbContext context, Serilog.ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> AddAsync(Product product)
        {
            try
            {
                product.CreatedAt = DateTime.UtcNow;
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                _logger.Information("Product added successfully with ID: {ProductId}", product.Id);
                return product.Id;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occurred while adding a product");
                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            try
            {
                var products = await _context.Products.ToListAsync();
                _logger.Information("Retrieved all products. Count: {Count}", products.Count);
                return products;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occurred while retrieving all products");
                throw;
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    _logger.Warning("Product with ID: {ProductId} not found", id);
                }
                else
                {
                    _logger.Information("Retrieved product with ID: {ProductId}", id);
                }
                return product;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occurred while retrieving product with ID: {ProductId}", id);
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            try
            {
                var existingProduct = await GetByIdAsync(product.Id);
                if (existingProduct == null)
                {
                    _logger.Warning("Cannot update product. Product with ID: {ProductId} not found", product.Id);
                    return false;
                }

                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;

                _context.Products.Update(existingProduct);
                await _context.SaveChangesAsync();

                _logger.Information("Product with ID: {ProductId} updated successfully", product.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occurred while updating product with ID: {ProductId}", product.Id);
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var product = await GetByIdAsync(id);
                if (product == null)
                {
                    _logger.Warning("Cannot delete product. Product with ID: {ProductId} not found", id);
                    return false;
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                _logger.Information("Product with ID: {ProductId} deleted successfully", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occurred while deleting product with ID: {ProductId}", id);
                throw;
            }
        }

        public async Task<List<Product>> GetProductsAsync(string name, decimal? minPrice, decimal? maxPrice)
        {
            try
            {
                var query = _context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(p => p.Name.Contains(name));
                }

                if (minPrice.HasValue)
                {
                    query = query.Where(p => p.Price >= minPrice.Value);
                }

                if (maxPrice.HasValue)
                {
                    query = query.Where(p => p.Price <= maxPrice.Value);
                }

                var products = await query.ToListAsync();
                _logger.Information("Retrieved products matching criteria. Count: {Count}", products.Count);
                return products;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occurred while retrieving products with filters");
                throw;
            }
        }
    }
}
