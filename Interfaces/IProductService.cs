using FoodApplication.Models;
namespace FoodApplication.Interface
{
    public interface IProductService
    {
        Task<List<Product>> GetListProduct();
        Task<Product> GetDetailsById(Guid? id);
        Task<Product> CreateProduct(Product Product);
        Task UpdateProduct(Product Product);
        Task DeleteProduct(Product Product);
    }
}
