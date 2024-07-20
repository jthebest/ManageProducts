using ManageApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageApi.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(int id, Product product);
        Task<bool> DeleteProductAsync(int id);
        Task<IEnumerable<Product>> GetProductsByManageAsync(int manageId);
        Task<Product> ArchiveProductAsync(int id, bool archived);
    }
}
