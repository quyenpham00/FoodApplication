using System.ComponentModel.DataAnnotations;

namespace FoodApplication.Models
{
    public class Product
    {
        [Key]
        public string ProductId { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public float? Price { get; set; }
    }
}
