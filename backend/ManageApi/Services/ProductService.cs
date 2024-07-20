// Services/ProductService.cs
using ManageApi.Data;
using ManageApi.Interfaces;
using ManageApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageApi.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(p => p.Manage) // Eager load Manage if needed
                .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(long id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            if (product.ManageId != null && product.ManageId != 0)
            {
                var existingManage = await _context.Manages.FindAsync(product.ManageId);
                if (existingManage == null)
                {
                    throw new KeyNotFoundException("Invalid ManageId provided.");
                }
            }

            // Set ManageId to null if it's 0 or null to avoid accidental association
            if (product.ManageId == 0 || product.ManageId == null)
            {
                product.ManageId = null;
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task UpdateProductAsync(long id, Product product)
        {
            if (id != product.Id)
            {
                throw new KeyNotFoundException("Product id mismatch.");
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    throw new KeyNotFoundException("Product not found.");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task DeleteProductAsync(long id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found.");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        private bool ProductExists(long id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
