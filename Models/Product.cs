using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodApplication.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
        public decimal? Price { get; set; }
    }
    public class ProductResponse
    {
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }

        public string? Description { get; set; }
        public decimal? Price { get; set; }

        public ProductResponse(Product product)
        {
            Name = product.Name;
            ImageUrl = product.ImageUrl;
            Description = product.Description;
            Price = product.Price;
        }
    }
}
