using System.ComponentModel.DataAnnotations;

namespace Basic_CURD_Operation.Models
{
    public class Products
    {
        public int Id { get; set; } 
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int stock { get; set; }
    }
}
