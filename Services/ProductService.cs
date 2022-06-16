using FoodApplication.Data;
using FoodApplication.Interface;
using FoodApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodApplication.Services
{
    public class ProductService : IProductService
    {
        private readonly AuthContext _context;

        public ProductService(AuthContext context)
        {
            _context = context; //test git
        }


        public async Task<List<Product>> GetListProduct()
        {
            var listProducts = new List<Product>();
            if (_context.Product != null)
            {
                listProducts = await _context.Product.ToListAsync();
            }
            return listProducts;
        }

        public async Task<Product> GetDetailsById(int? id)
        {
            var Product = new Product();
            if (_context.Product != null)
            {
                Product = await _context.Product
              .FirstOrDefaultAsync(m => m.ProductId.Equals(id));
            }
            return Product;
        }

        public async Task<Product> CreateProduct(Product Product)
        {
            _context.Add(Product);
            await _context.SaveChangesAsync();
            return Product;
        }

        public async Task UpdateProduct(Product Product)
        {
            _context.Update(Product);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteProduct(Product Product)
        {
            if (Product != null)
            {
                 _context.Product.Remove(Product);
            }
            await _context.SaveChangesAsync();

        }

    }
}

