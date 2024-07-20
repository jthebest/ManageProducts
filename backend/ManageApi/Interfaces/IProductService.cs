// Interfaces/IProductService.cs
using ManageApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageApi.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(long id);
        Task<Product> CreateProductAsync(Product product);
        Task UpdateProductAsync(long id, Product product);
        Task DeleteProductAsync(long id);
    }
}
